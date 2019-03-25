using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{
	public delegate void SceneChange();
	public static SceneChange OnSceneChange;

	private string sceneToLoad;
	
	public void LoadSceneAsync(string sceneName)
	{
		DoLoadSceneAsync(sceneName);
	}

	private void DoLoadSceneAsync(string sceneName)
	{
		Main.instance.EnableLoadingScreen();
		sceneToLoad = sceneName;
		SetNormalTime();
		Invoke("PreLoadAsync", Main.instance.showWithEffect.TIME*2);
	}

	void SetNormalTime ()
	{
		Time.timeScale = 1f;
		TimeManager timeManager = FindObjectOfType<TimeManager>();
		if(timeManager) timeManager.timeTarget = 1f ;
	}
	
	private void PreLoadAsync()
	{
		StartCoroutine(LoadAsync(sceneToLoad));

		if (OnSceneChange != null)
			OnSceneChange();
	}

	private IEnumerator LoadAsync(string levelName)
	{
		AsyncOperation operation = Application.LoadLevelAsync(levelName);
		while(!operation.isDone) {
			yield return operation.isDone;
			Main.instance.Log("loading progress: " + operation.progress);
		}
		Main.instance.Log("load done");
	}
}
