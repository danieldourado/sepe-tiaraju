using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour 
{
	public UpgradeInfo upgradeInfo;
	public GameObject priceGO;
	private Image image;
	private bool isEnabled;
	private Text text;

	void Awake () 
	{
		image = GetComponent<Image>();
		text = GetComponentInChildren<Text>();
	}

	public void SetUpgradeInfo (UpgradeInfo tempUpgradeInfo)
	{
		this.upgradeInfo = tempUpgradeInfo;
		text.text = upgradeInfo.preco.ToString();
		this.image.sprite = tempUpgradeInfo.spriteEnabled;
	}

	void Update () 
	{
		var currentUpgrades = Main.instance.score.playerData.currentUpgrades;
		bool hasUpdate = false;

		foreach(UpgradeVO existingUpgrade in currentUpgrades)
		{
			if(existingUpgrade.type == upgradeInfo.upgradeType)
			{
				hasUpdate = true;
				//se,ja tem upgrade feito maior que esse
				if(existingUpgrade.level >= upgradeInfo.upgradeLevel)
				{
					SetUsed();
					return;
				}
				//se tem upgrade menor pra fazer antes desse
				if((upgradeInfo.upgradeLevel - existingUpgrade.level) > 1)
				{
					SetDisabled();
					return;
				}
			}
		}

		//se nao ha upgrades feitos ainda, desabilita todos > 1
		if(hasUpdate == false)
		{
			if(upgradeInfo.upgradeLevel > 1)
			{
				SetDisabled();
				return;
			}
		}

		var stars = Main.instance.score.currentScoreStars;
		if(stars >= upgradeInfo.preco)
		{
			SetEnabled();
		}
		else
		{
			SetDisabled();
		}
	}
	
	public void SetEnabled()
	{
		isEnabled = true;
		SetEnabledTexture();
		priceGO.SetActive(true);
	}
	public void SetDisabled()
	{
		isEnabled = false;
		SetDisabledTexture();
		priceGO.SetActive(false);
	}
	public void SetUsed()
	{
		isEnabled = false;
		priceGO.SetActive(false);
	}

	void SetEnabledTexture ()
	{
		image.sprite = upgradeInfo.spriteEnabled;
	}

	void SetDisabledTexture ()
	{
		image.sprite = upgradeInfo.spriteDisabled;
	}

	
	public void ShowDescription()
	{
		if(isEnabled)
			FindObjectOfType<UpgradesCaixaDescricao>().ShowDescription(upgradeInfo);
	}
	
	public Sprite GetIcone()
	{
		return upgradeInfo.spriteDisabled;
	}
}
