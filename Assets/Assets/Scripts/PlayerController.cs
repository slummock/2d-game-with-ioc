using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerBody;
	private KeyboardMovement keyboardMovement;

	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		keyboardMovement = new KeyboardMovement(ref playerBody, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		keyboardMovement.SetMovement();
	}

	void FixedUpdate(){
		keyboardMovement.Move();
	}
}
