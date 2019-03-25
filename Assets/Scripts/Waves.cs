using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;

public class Waves : MonoBehaviour 
{
	[HideInInspector]
	public int currentWave = 0;
	//public int quantidadeDeWaves = 5;
	public List<int> tempoDasWaves;
	//public float tempoEntreWaves = 20f;
	public int lifePrimeiraWave = 0;
	public float multiplicadorLifeProximaWave = 1.3f;

	public float quantidadeDeInimigosProLifeDaWave = 4;
	
	[HideInInspector]
	public float intervalForSpawn;

	public float tempoEntreInimigos = 0.5f;


	public float lifeDessaWave;

	public int dinheiroInicial = 100;
	
	public float tempoParaProximaWave = 0f;

	[Header("Wave Automatica")]
	public List<GameObject> automaticEnemiesList;

	public float tempoDaWaveAtual = 0;

	[Header("Waves Personalizadas")]
	[Header("Atributo 2: Tempo que aparece")]
	[Header("Atributo 3: Prefab do Inimigo")]
	[Header("Atributo 1: Wave que aparece")]
	

	public List<CustomWave> customWaves;

	private Transform enemiesContainer;

	private List<GameObject> spawnList;
	private bool isStarted;

	private bool isCurrentWaveFinished;


	void Start () 
	{

		FindObjectOfType<GameData>().money = dinheiroInicial;

		spawnList = new List<GameObject>();
		intervalForSpawn = tempoEntreInimigos;
		GameObject go = new GameObject();
		go.name = "Enemies";
		enemiesContainer = go.transform;
	
		//GameStateManager.OnGameStateChangeToWaveStarted += SpawnNewEnemy;

		lifeDessaWave = 0;

		GameStateManager.OnGameEventChanged += StartWave;

		CalculateAutomaticWave();
		Reset();
	}

	void CalculateAutomaticWave ()
	{
		if(lifePrimeiraWave == 0) return;
		do
		{
			currentWave++;
			spawnList = new List<GameObject>();
			CalculateWave();

		}
		while(currentWave <= tempoDasWaves.Count);
	}

	void Reset()
	{
		spawnList = new List<GameObject>();
		lifeDessaWave = 0;
		intervalForSpawn = tempoEntreInimigos;
		currentWave = 0;
		tempoDaWaveAtual = 0f;
	}

	void StartWave(GameEvent ge)
	{
		if(ge == GameEvent.StartWave)
		{
			isStarted = true;
			GameStateManager.GameState = GameState.Loading;
			GameStateManager.GameState = GameState.WaveStarted;
			FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Play();
		}
		if(ge == GameEvent.CallWaveEarly)
		{
			CallNextWaveEarly();
		}
	}



	
	void FixedUpdate () 
	{
		if(!isStarted) return;

		UpdateIntervalBetweenWaves();
		UpdateIntervalForSpawn();
		UpdateCustomWaves();
	}

	void UpdateIntervalBetweenWaves ()
	{
		tempoParaProximaWave -= Time.deltaTime;
		tempoDaWaveAtual += Time.deltaTime;
		if(tempoParaProximaWave < 0)
		{
			StartNewWave();
		}
	}

	void StartNewWave ()
	{
		if(currentWave >= tempoDasWaves.Count) return;
		tempoParaProximaWave = tempoDasWaves[currentWave];
		tempoDaWaveAtual = 0f;
		currentWave ++;
		CalculateWave();
	}

	void CalculateWave ()
	{
		lifeDessaWave = lifePrimeiraWave*(multiplicadorLifeProximaWave*currentWave);
		var tempWaveLife = lifeDessaWave;
		while(tempWaveLife > 0)
		{
			var enemy = GetEnemyFromTargetLife(tempWaveLife);
			tempWaveLife -= enemy.GetComponent<Health>().startHealth;
			spawnList.Add(enemy);
		}
	}

	GameObject GetEnemyFromTargetLife (float tempWaveTargetLife)
	{
		foreach(GameObject tempEnemy in automaticEnemiesList)
		{
			var tempData = tempEnemy.GetComponent<Health>();
			var enemyLife = tempData.startHealth;

			if((tempWaveTargetLife/enemyLife)<= quantidadeDeInimigosProLifeDaWave)
			{
				return tempEnemy;
			}
		}
		return automaticEnemiesList[automaticEnemiesList.Count-1];
	}

	void UpdateIntervalForSpawn ()
	{
		intervalForSpawn -= Time.deltaTime;
		if(intervalForSpawn<0)
		{
			SpawnNewEnemy();
			intervalForSpawn = Random.Range(tempoEntreInimigos, tempoEntreInimigos*3);
		}
	}

	void UpdateCustomWaves ()
	{
		List<CustomWave> used = new List<CustomWave>();
		foreach(CustomWave tempCustomWave in customWaves)
		{
			if(currentWave >= tempCustomWave.wave)
			{
				if(tempoDaWaveAtual >= tempCustomWave.tempo)
				{
					SpawnNewEnemy(tempCustomWave.enemyPrefab);
					used.Add(tempCustomWave);
				}
			}
		}

		foreach(CustomWave tempCustomWave in used)
		{
			customWaves.Remove(tempCustomWave);
		}
	}

	void SpawnNewEnemy (GameObject customUnity = null)
	{
		GameObject spawnUnity = null;

		if(customUnity == null)
		{
			if(spawnList.Count ==0 ) return;
			spawnUnity = spawnList[0];
			spawnList.Remove(spawnList[0]);
		}
		else
		{
			spawnUnity = customUnity;
		}

		var tempUnit = Instantiate<GameObject>(spawnUnity);
		tempUnit.transform.SetParent(enemiesContainer);
		
	}

	public bool CanCallNextWaveEarly()
	{
		if(spawnList == null) return false;
		return spawnList.Count == 0;
	}

	void CallNextWaveEarly ()
	{
		var percentageOfWave = tempoParaProximaWave/tempoDasWaves[currentWave];
		tempoParaProximaWave = -1f;
		FixedUpdate();
		float reward = (lifeDessaWave/10) * percentageOfWave;
		FindObjectOfType<GameData>().IncreaseMoney((int)reward);
		Main.instance.score.playerData.progressData.wavesCalledEarly++;
	}

	public bool isFinished()
	{
		bool lastwave = currentWave == tempoDasWaves.Count;
		bool lastEnemy = spawnList.Count == 0;

		return lastwave && lastEnemy;
	}
}

[System.Serializable]
public class CustomWave
{
	public int wave;
	public int tempo;
	public GameObject enemyPrefab;
}
