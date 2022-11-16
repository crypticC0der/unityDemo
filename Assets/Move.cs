using UnityEngine;
public class Move : MonoBehaviour{

    public float speed=5;
	public Rigidbody2D rb;
	public void Start(){
		//gets the rigidbody component using the template getcomponent
		rb = GetComponent<Rigidbody2D>();
    }

	public void Update(){
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		//create movement vector, it has magnitude and direction
		Vector3 movement = new Vector3(x,y,0);

		//keep the direction of movement but set the magnitude to speed
		movement = movement.normalized * speed;
		//set the movement to be based off the time step
		movement*=Time.deltaTime;

		//update the position through the transform component
		rb.AddForce(movement);
    }
}
