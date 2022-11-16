
using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour{
	public Vector2 edge;
	public Transform player;
	public void Start(){
		Camera c = GetComponent<Camera>();
		edge.y = c.orthographicSize;
		edge.x = c.aspect *edge.y;
		StartCoroutine(Coroutine());
    }

	public Vector3 GetSpot(){
		bool placeable = false;
		Vector2 spot = new Vector2();
		while(!placeable){
			spot.x = Random.Range(-edge.x,edge.x);
			spot.y = Random.Range(-edge.y,edge.y);
			float distance = ((Vector2)player.position-spot).magnitude;
			placeable = distance>2;
			if(distance>2){
				placeable &= !Physics2D.OverlapCircle(spot,0.5f);
			}
		}

		return spot;
	}

	IEnumerator Coroutine(){
		while (true){
			yield return new WaitForSeconds(1);
			Vector3 spot = GetSpot();
			GameObject enemy = Instantiate<GameObject>(Resources.Load<GameObject>("enemy"));
			enemy.transform.position=spot;
		}
	}

}
