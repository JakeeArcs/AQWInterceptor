using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AQWInterceptor.Proxy
{
    public delegate void Intercepted(string message, SenderType type);

    public class Proxy
    {
        public static event Intercepted OnPacketIntercepted;

        private string IP;
        private int Port = 5588;
        private TcpListener Listener;
        private TcpClient Client;
        private TcpClient Server;
        private Thread MyThread;

        public bool IsRunning;
        public bool ShouldExit;

        public Proxy()
        {
            Listener = new TcpListener(IPAddress.Loopback, Port);
            IsRunning = false;
            ShouldExit = false;
            MyThread = new Thread(StartListening) { Name = "Proxy Thread" };
        }

        public void StartProxy(string ip, int port = 5588)
        {
            IsRunning = true;
            IP = ip;
            Port = port;
            MyThread.Start();
        }

        public void StopProxy()
        {
            ShouldExit = true;
            Listener.Stop();
            if (Client != null)
                Client.Client.Shutdown(SocketShutdown.Both);

            if (Server != null)
                Server.Client.Shutdown(SocketShutdown.Both);
            
            if (MyThread.IsAlive)
                MyThread.Abort();
        }

        private void StartListening()
        {
            Listener.Start();
            while(!ShouldExit)
            {
                Client = Listener.AcceptTcpClient();
                Debug.WriteLine("Client opened");
                Server = new TcpClient();
                Server.Connect(IP, Port);
                Debug.WriteLine("Server opened");

                Task.Factory.StartNew(() => Intercept(Client, Server, SenderType.Client));
                Task.Factory.StartNew(() => Intercept(Server, Client, SenderType.Server));
            }
        }

        private async Task Intercept(TcpClient sender, TcpClient receiver, SenderType type)
        {
            byte[] buffer = new byte[4096];
            int read = 0;
            List<byte> cpackets = new List<byte>();
            while (!ShouldExit)
            {
                read = await sender.GetStream().ReadAsync(buffer, 0, 4096);

                if (read == 0)
                {
                    sender.Client.Shutdown(SocketShutdown.Both);
                    receiver.Client.Shutdown(SocketShutdown.Both);
                    Debug.WriteLine(type.ToString() + " closed");
                    return;
                }

                for (int i = 0; i < read; i++)
                {
                    byte b = buffer[i];
                    if (b > 0)
                        cpackets.Add(b);
                    else
                    {
                        byte[] data = cpackets.ToArray();
                        cpackets.Clear();

                        string message = Encoding.UTF8.GetString(data, 0, data.Length);
                        OnPacketIntercepted?.Invoke(message, type);
                        byte[] msg = new byte[message.Length + 1];
                        Buffer.BlockCopy(ToBytes(message), 0, msg, 0, message.Length);
                        await receiver.GetStream().WriteAsync(msg, 0, msg.Length);
                        msg = null;
                    }
                }
            }

            Debug.WriteLine(type.ToString() + " closed");
        }

        private byte[] ToBytes(string s)
        {
            return s.Select(c => (byte)c).ToArray();
        }
    }
}
