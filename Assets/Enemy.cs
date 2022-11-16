using UnityEngine;
public class Enemy: MonoBehaviour{

	public static float speed =1;
	Rigidbody2D rb;
	Vector3 direction;

	void newDirection(){
		float rad = Random.Range(0,2*Mathf.PI);
		direction = new Vector3(Mathf.Sin(rad),Mathf.Cos(rad));
	}

	public void Start(){
		rb = GetComponent<Rigidbody2D>();
		newDirection();
	}

	public void Update(){
		rb.velocity=direction;
	}

	public void Die(){
		Score.Increase();
		Destroy(this.gameObject);
	}

    void OnCollisionEnter2D(Collision2D col){
		direction=col.relativeVelocity.normalized;
	}
}
