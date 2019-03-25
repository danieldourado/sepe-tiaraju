using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchDetector2D : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick (PointerEventData eventData)
	{
		FindObjectOfType<TouchOrganizer>().Hide();

		goToSendMessage.SendMessage("OnClick");
	}

	protected GameObject goToSendMessage;
	
	void Awake()
	{
		gameObject.name = "Touch Detector";
	}
	
	public void Setup (float radiusOfTouch, GameObject goToSendMessage)
	{
		if(radiusOfTouch != 0f)
		{
			var cc = gameObject.AddComponent<CircleCollider2D>();
			cc.radius = radiusOfTouch;
			cc.isTrigger = true;
			gameObject.layer = 8;
		}
		this.goToSendMessage = goToSendMessage;
	}
}
