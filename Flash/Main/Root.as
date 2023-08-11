package Main {
	import flash.display.MovieClip;
	import flash.display.LoaderInfo;
	import flash.events.Event;
	import flash.events.ProgressEvent;
	import flash.events.IOErrorEvent;
	import flash.external.ExternalInterface;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.system.ApplicationDomain;
	import flash.display.Loader;
	import flash.system.Security;
	import flash.system.SecurityDomain;
	import flash.display.Stage;
	import flash.system.LoaderContext;
	import flash.text.TextField;

	public class Root extends MovieClip {

		private var sURL: String = "https://game.aq.com/game/";
		private var urlLoader: URLLoader;
		private var gameLoader: Loader;
		public var gameDomain: ApplicationDomain;
		private var gameVars: Object;
		private var isEU: Boolean;
		private var stg: Stage;
		private var loadText: TextField;

		public var sTitle: String;
		public static var Game: * ;


		public function Root() {
			addEventListener(Event.ADDED_TO_STAGE, onAddedToStage);
			loadText = LoadingText;
		}

		public function onAddedToStage(event: Event): void {
			removeEventListener(Event.ADDED_TO_STAGE, onAddedToStage);
			stop();
			Security.allowDomain("*");
			Security.allowInsecureDomain("*");
			urlLoader = new URLLoader();
			urlLoader.addEventListener(Event.COMPLETE, onDataComplete);
			urlLoader.load(new URLRequest(sURL + "api/data/gameversion?ver=" + Math.random()));
		}

		public function onDataComplete(event: Event): void {
			urlLoader.removeEventListener(Event.COMPLETE, onDataComplete);
			gameVars = JSON.parse(event.target.data);
			sTitle = gameVars.sTitle;
			isEU = gameVars.isEU == "true";
			initGameLoad();
		}

		public function initGameLoad(): void {
			gameLoader = new Loader();
			gameLoader.contentLoaderInfo.addEventListener(Event.COMPLETE, onComplete);
			gameLoader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS, onProgress);
			gameLoader.load(new URLRequest(sURL + "gamefiles/" + gameVars.sFile));
		}

		public function onProgress(event: Event): void {
			loadText.text = "Loading " + Math.round(Number(event.currentTarget.bytesLoaded / event.currentTarget.bytesTotal) * 100).toString() + "%";
		}

		public function onComplete(event: Event): void {
			gameLoader.contentLoaderInfo.removeEventListener(ProgressEvent.PROGRESS, onProgress);
			gameLoader.contentLoaderInfo.removeEventListener(Event.COMPLETE, onComplete);
			stg = stage;
			stg.removeChildAt(0);
			Game = stg.addChild(MovieClip(Loader(event.target.loader).content));
			Game.params.sTitle = sTitle;
			Game.params.vars = gameVars;
			Game.params.isWeb = false;
			Game.params.sURL = sURL;
			Game.params.sBG = gameVars.sBG;
			Game.params.isEU = isEU;
			Game.params.doSignup = false;
			Game.params.loginURL = sURL + "api/login/now";
			Game.params.test = false;
			Game.loginLoader.addEventListener(Event.COMPLETE, onLoginComplete);
		}
		
		public function onLoginComplete(event: Event): void {
			var objs:* = JSON.parse(event.target.data);
			var x:int;
			for (x = 0; x < objs.servers.length; x++) {
				objs.servers[x].sName = objs.servers[x].sIP + ":" + objs.servers[x].iPort;
				trace(objs.servers[x].sPort);
				objs.servers[x].sIP = "127.0.0.1";
				trace(x);
			}
			
			objs = JSON.stringify(objs);
			event.target.data = objs;
		}
	}
}