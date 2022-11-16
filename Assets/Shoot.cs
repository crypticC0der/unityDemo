using UnityEngine;
using TMPro;
using System.Collections;

public class Shoot : MonoBehaviour{
	public LineRenderer lr;
	public TextMeshProUGUI output;

	public void Start(){
		Score.scoreboard = output;
	}

	public void Update(){
		Vector3 p = Input.mousePosition;
		Vector3 pos = Camera.main.ScreenToWorldPoint( p);
		pos.z=0;
		RaycastHit2D rh = Physics2D.Raycast(transform.position,pos-transform.position,20,~(1<<6));
		if(rh){
			pos=rh.point;
		}

		lr.SetPosition(0,transform.position);
		lr.SetPosition(1,pos);

		if(Input.GetMouseButtonDown(0)){

			StartCoroutine(Flash());
			Enemy e;
			if(e = rh.collider.GetComponent<Enemy>()){
				e.Die();
			}
		}
	}

	public IEnumerator Flash(){
		//save the inital color
		Color initialStart=lr.startColor;
		Color initialend=lr.endColor;

		//set a temp color
		lr.endColor=Color.red;
		lr.startColor=lr.endColor;

		//wait
		yield return new WaitForSeconds(0.1f);

		//go back to the saved color
		lr.endColor=initialend;
		lr.startColor=initialStart;
	}
}
