using UnityEngine;
using System.Collections;

public class ButtonMapaFasesIntro : MonoBehaviour 
{
	public Sprite sprite;
	public void OnClick()
	{
		FindObjectOfType<DescricaoFaseScreen>().Setup(sprite,GetComponent<Level>().level);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
