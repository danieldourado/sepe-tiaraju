using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UITitledBox : MonoBehaviour 
{
	public Sprite nineSliceSprite;
	public Sprite titleSprite;

	GameObject nineSliceGO;
	GameObject titleGO;
	RectTransform rt;

	void Start () 
	{
		rt = GetComponent<RectTransform>();
	}
	void Update () 
	{
		if (Application.isEditor && !Application.isPlaying) 
		{
			CheckGameObjectsCreated();
			UpdateNineSliceSize();
		}
	}

	void CheckGameObjectsCreated ()
	{
		nineSliceGO = transform.Find("9SliceBackground").gameObject;
		if(nineSliceGO == null)
		{
			nineSliceGO = GetGameObjectWithImage();
			AddToThisTransform(nineSliceGO);
			nineSliceGO.name = "9SliceBackground";
		}

		titleGO = transform.Find("Title").gameObject;
		if(titleGO == null)
		{
			titleGO = GetGameObjectWithImage();
			AddToThisTransform(titleGO);
			titleGO.name = "Title";
		}



		nineSliceGO.GetComponent<Image>().sprite = nineSliceSprite;
		nineSliceGO.GetComponent<Image>().type = Image.Type.Sliced;
		titleGO.GetComponent<Image>().sprite = titleSprite;
		titleGO.GetComponent<Image>().rectTransform.sizeDelta = titleSprite.rect.size;
	}
	void UpdateNineSliceSize ()
	{
		nineSliceGO.GetComponent<RectTransform>().sizeDelta = rt.sizeDelta;
	}
	GameObject GetGameObjectWithImage()
	{
		var go = new GameObject();
		go.AddComponent<Image>();
		return go;
	}
	GameObject AddToThisTransform(GameObject go)
	{
		go.transform.SetParent(this.transform);
		return go;
	}
}
