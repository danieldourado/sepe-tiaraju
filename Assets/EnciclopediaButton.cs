using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class EnciclopediaButton : MonoBehaviour 
{
	public InfoData data;
	private Image image;
	private Button button;
	
	private EnciclopediaSelectedSprite enciclopediaSprite;
	private EnciclopediaSelectedDescription enciclopediaDescription;
	private EnciclopediaSelectedNome enciclopediaNome;
	
	
	void Start () 
	{
		enciclopediaSprite = FindObjectOfType<EnciclopediaSelectedSprite>();
		enciclopediaDescription = FindObjectOfType<EnciclopediaSelectedDescription>();
		enciclopediaNome = FindObjectOfType<EnciclopediaSelectedNome>();

		SetImage () ;

		button = GetComponent<Button>();
		button.onClick.AddListener(delegate { OnClick(); });
	}
	
	public void OnClick()
	{
		enciclopediaSprite.GetComponent<Image>().overrideSprite = data.thumbnail;
		enciclopediaDescription.GetComponent<Text>().text = data.description;
		enciclopediaNome.GetComponent<Text>().text = data.name;
		
	}
	
	void SetImage () 
	{
		image = GetComponent<Image>();
		Sprite imageSprite = data.thumbnail;
		image.sprite = imageSprite;
		
	}
	
}
