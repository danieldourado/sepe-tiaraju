using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Settings))]
public class Main : MonoBehaviour 
{	
	[HideInInspector]
	public GameSounds sounds;
	[HideInInspector]
	public Settings settings;
	[HideInInspector]
	public Score score;
	[HideInInspector]
	public SceneLoader sceneLoader;
	[HideInInspector]
	public AudioManager audioManager;
	[HideInInspector]
	public ShowWithEffect showWithEffect;
	private GameObject loadingScreen;
	private bool instantiatedNotFromFirstScreen;

	public Level.LevelScenes currentLevel;

	private static Main _instance;
	public static Main instance
	{
		get
		{
			return GetInstance();
		}
	}

	public void Awake () 
	{
		
		//Time.maximumDeltaTime = 0.03f;
		//GetInstance();
		GetLoadingScreen();
		GetSettingsObject();
		GetSceneLoaderObject();
		GetAudioManager();
		SetPlatformSpecifics();
		GetScoreComponent();
		GetShowWithEffect();
		GetSoundsObject();
		score.currentScoreStars = 20;
	}

	void Start()
	{
		GameStateManager.OnGameEventChanged += CheckEvent;
		sceneLoader.LoadSceneAsync(settings.MAIN_MENU_SCENE);
	}

	private void CheckEvent(GameEvent e)
	{
		if(e == GameEvent.MainMenu)
		{
			sceneLoader.LoadSceneAsync(settings.MAIN_MENU_SCENE);
		}
		if(e == GameEvent.RestartGame)
		{
			sceneLoader.LoadSceneAsync(settings.GAMEPLAY_SCENE);
		}
	}

	private static Main GetInstance ()
	{
		if(_instance == null)
		{
			var obj = GameObject.FindObjectOfType<Main>();
			if(obj == null)
			{
				GameObject go = Instantiate(Resources.Load("Main") as GameObject);
				_instance = go.GetComponent<Main>();
				_instance.instantiatedNotFromFirstScreen = true;
			}
			else
			{
				_instance = obj;
			}
			DontDestroyOnLoad(_instance.gameObject);
		}

		return _instance;
		/*
		else if(_instance != this)
		{
			Destroy(this);
		}
		DontDestroyOnLoad(gameObject);
*/
	}
	
	void GetLoadingScreen ()
	{
		loadingScreen = FindObjectOfType<LoadingScreen>().gameObject;
	}


	void GetSettingsObject ()
	{
		settings = GetComponent<Settings>();
	}

	void GetSceneLoaderObject ()
	{
		sceneLoader = gameObject.AddComponent(typeof(SceneLoader)) as SceneLoader;
	}

	void GetAudioManager ()
	{
		audioManager = gameObject.AddComponent(typeof(AudioManager)) as AudioManager;
	}
	
	void SetPlatformSpecifics ()
	{
		//Application.targetFrameRate = 60;
		UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;

		if (Application.platform == RuntimePlatform.Android)
		{
			settings.IS_TOUCH_SCREEN = true;


			//Application.targetFrameRate = 60;
		}
		else if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			settings.IS_TOUCH_SCREEN = true;
		}
	}

	void GetScoreComponent ()
	{
		score = gameObject.AddComponent<Score>();
	}

	void GetShowWithEffect ()
	{
		showWithEffect = gameObject.AddComponent<ShowWithEffect>();
	}

	void GetSoundsObject ()
	{
		sounds = gameObject.GetComponent<GameSounds>();
	}

	public void Log(string message)
	{
		if(settings.DEBUG_MODE) Debug.Log(message);
	}

	public void DisableLoadingScreen()
	{
		loadingScreen.SendMessage("Hide");
		//loadingScreen.SetActive(false);
	}

	public void LoadLevel(Level.LevelScenes level)
	{
		currentLevel = level;
		sceneLoader.LoadSceneAsync(settings.GAMEPLAY_SCENE);
	}

	public void EnableLoadingScreen()
	{
		loadingScreen.SendMessage("Show");
	}
}
