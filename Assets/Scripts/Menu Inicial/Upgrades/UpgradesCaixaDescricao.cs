using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradesCaixaDescricao : MonoBehaviour 
{
	private UpgradeInfo upgradeInfo;
	public Image icone;
	public Text texto;
	public Text preco ;

	public void ShowDescription(UpgradeInfo upgradeInfo)
	{
		icone.gameObject.SetActive(true);
		this.upgradeInfo = upgradeInfo;
		icone.sprite = upgradeInfo.spriteEnabled;
		texto.text = upgradeInfo.description;
		preco.text = upgradeInfo.preco.ToString();
	}

	public void Upgrade()
	{
		if(upgradeInfo == null) return;

		var upgradeVO = new UpgradeVO();
		upgradeVO.level = upgradeInfo.upgradeLevel;
		upgradeVO.type = upgradeInfo.upgradeType;
		upgradeVO.price = upgradeInfo.preco;
		Main.instance.score.AddUpgrade(upgradeVO);

		ResetDescription();
	}

	void ResetDescription ()
	{
		this.upgradeInfo = null;
		icone.gameObject.SetActive(false);
		texto.text = "";
		preco.text = "";
	}

	public void ResetUpgrades()
	{
		Main.instance.score.ResetUpgrades();
	}
}
