using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpgradeColumn : MonoBehaviour 
{
	public GameObject genericUpgradeButtonPrefab;
	public List<UpgradeInfo> upgradeInfos;

	void Start () 
	{
		AddButtonsToVLG();
	}

	void AddButtonsToVLG ()
	{
		var vlg = GetComponent<VerticalLayoutGroup>();

		RemoveAllChildren(vlg.transform);

		for (int i = upgradeInfos.Count -1; i>=0; i--)
		{

			var tempButton = Instantiate<GameObject>(genericUpgradeButtonPrefab);
			tempButton.transform.parent = vlg.transform;
			var upgradeButton = tempButton.GetComponent<UpgradeButton>();
			upgradeButton.SetUpgradeInfo(upgradeInfos[i]);
		}
	}

	void RemoveAllChildren (Transform vlgTransform)
	{
		var children = new List<GameObject>();
		foreach (Transform child in vlgTransform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
