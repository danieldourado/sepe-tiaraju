using UnityEngine;
using System.Collections;


public class Weapon : MonoBehaviour 
{
	GameObject go;
	DamageData data;
	bool draw;
	Vector3[] positionss;

	public void Shoot(GameObject go, DamageData data)
	{
		this.go = go;
		this.data = data;



		/*

		//go.GetComponent<Health>().TakeDamage(data.damage_ammount);

		//Debug.DrawLine(transform.position, go.transform.position, new Color(5f,5f,5f));
		Vector3[] positions = new Vector3[2];
		positions[0] = transform.position;

		var posX = (transform.position.x + go.transform.position.x)/2;
		if(posX < 0) posX *= -1;

		var posY = go.transform.position.y + 10f;

		//position2.y = data.range - position2.x;
		//position2.y = transform.position.y + position2.y;

		//positions[1] = new Vector3(posX, posY);

		TravelData ts = go.GetComponent<MoverData>().travel;

		float timeFactor = data.maxTimeProjectileStaysInAir / ts.time;


		Vector3 predictedPositionFactor = ts.difference * timeFactor;
		 

		positions[1] = go.transform.position - predictedPositionFactor;
		//positions[1] = go.transform.position;
*/

		positionss = GeneratePath();
		draw = true;

		GameObject newGo = Instantiate(data.projectile) as GameObject;
		//newGo.transform.SetParent(transform.parent);
                                                   			//newGo.transform.localScale = transform.localScale;
		newGo.GetComponent<Projectile>().HitTarget(positionss, data, go);

	}

	Vector3[] GeneratePath ()
	{
		var myPos = transform.position;
		var targetPos =  go.transform.position;

		Vector3[] positions = new Vector3[3];
		positions[0] = myPos;

		Vector3 middlePoint = new Vector3();

		middlePoint.x = (myPos.x + targetPos.x)/2;
		middlePoint.y = (myPos.y + targetPos.y)/2;

		if(data.weaponType == DamageData.WeaponType.Bomb)
		{
			if(myPos.y > targetPos.y)
				middlePoint.y = myPos.y + Vector2.Distance(myPos, targetPos)/4;
			else
				middlePoint.y = targetPos.y + Vector2.Distance(myPos, targetPos)/4;
		}


		positions[1] = middlePoint;
		
		var posY = go.transform.position.y + 10f;

		float timeProjWillStayInAir = 0f;
		timeProjWillStayInAir = Vector2.Distance(myPos, targetPos);
		timeProjWillStayInAir = timeProjWillStayInAir / data.range;
		timeProjWillStayInAir = timeProjWillStayInAir * data.maxTimeProjectileStaysInAir;

		TravelData ts = go.GetComponent<MoverData>().travel;
		float timeFactor = timeProjWillStayInAir / ts.time;
		
		Vector3 endPoint = new Vector3();
		endPoint = ts.difference * timeFactor;
		
		positions[2] = targetPos - endPoint;

		return positions;
	}

	void Update()
	{
		if(!draw) return;
		Debug.DrawLine(positionss[1], positionss[2]);
	}
}
