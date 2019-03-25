using UnityEngine;
using System.Collections;

public class UpgradeInfo : MonoBehaviour 
{
	public Upgrade.UpgradeType upgradeType;
	[Range(1,5)]
	public int upgradeLevel;
	public Sprite spriteEnabled, spriteDisabled;
	public string description = "descriçao padrao";
	public int preco = 1;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
