using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum GameState
{
	WaveStarted,
    Dead,
	MainMenu,
	Loading,
	Pause
}


public enum GameEvent
{
	TowerBuilt,
	TowerPreview,
	StartWave,
	CallWaveEarly,
	Reinforcements,
	HeroSelected,
	Pause,
	RestartGame,
	MainMenu,
	GameOver,
	ShowPauseScreen,
	Win,
	SpecialHability2,
	SpecialHability3
}

public static class GameStateManager
{
    public delegate void OnGameStateChange();
	public static OnGameStateChange OnGameStateChangeToWaveStarted;
	public static OnGameStateChange OnGameStateChangeToDead;
	public static OnGameStateChange OnGameStateChangeToMainMenu;
	public static OnGameStateChange OnGameStateChangeToLoading;
	public static OnGameStateChange OnGameStateChangeToPause;

    private static GameState gameState;
    public static GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
			if(gameState == value) return;

            gameState = value;
            
            switch(value)
            {
				
				case GameState.WaveStarted:
					if (OnGameStateChangeToWaveStarted != null)
						OnGameStateChangeToWaveStarted();
					break;


                case GameState.Dead:
                    if (OnGameStateChangeToDead != null)
                        OnGameStateChangeToDead();
                    break;


				case GameState.MainMenu:
					if (OnGameStateChangeToMainMenu != null)
						OnGameStateChangeToMainMenu();
					break;
				
				case GameState.Loading:
					if (OnGameStateChangeToLoading != null)
						OnGameStateChangeToLoading();
					break;

				case GameState.Pause:
					if (OnGameStateChangeToPause != null)
						OnGameStateChangeToPause();
					break;
            }

			//if(Main.instance.settings.DEBUG_MODE)
			//{
				UnityEngine.Debug.Log("Gamestate is now "+value.ToString());
			//}
        }
    }


	public delegate void OnGameEventChange(GameEvent ge);
	public static OnGameEventChange OnGameEventChanged;
	
	private static GameEvent gameEvent;
	public static GameEvent GameEvent
	{
		get
		{
			return gameEvent;
		}
		set
		{	
			gameEvent = value;
			
			OnGameEventChanged(value);
			
			//if(Main.instance.settings.DEBUG_MODE)
      			//{
			//}
		}
	}








}   