using UnityEngine;

public class KeyboardMovement: IMovement {
	private bool up;
	private bool down;
	private bool left;
	private bool right;
	private float totalSpeed = 40f;
    private float diagonalSpeed;
    private Rigidbody2D playerBody;
    private GameObject playerObject;
	
    public KeyboardMovement(ref Rigidbody2D playerBody, GameObject gameObject){
        this.playerBody = playerBody;
        playerObject = gameObject;
        SetDiagonalSpeed(totalSpeed);
    }

    public void Move(){
        MoveVertical();
		MoveHorizontal();
    }

    private void SetDiagonalSpeed(float speed){
        diagonalSpeed = speed * Mathf.Sqrt(2)/2;
    }

    private void MoveHorizontal()
    {
        var speed = up || down? diagonalSpeed: totalSpeed;
        if (right)
            playerBody.AddForce(playerObject.transform.right * speed);
        if (left)
            playerBody.AddForce(playerObject.transform.right * speed * -1);
    }

    private void MoveVertical()
    {
        var speed = left || right? diagonalSpeed: totalSpeed;
        if (up)
            playerBody.AddForce(playerObject.transform.up * speed);
        if (down)
            playerBody.AddForce(playerObject.transform.up * speed * -1);
    }

    public void SetMovement()
    {
        ResetMovement();
        SetVertical();
        SetHorizontal();
    }

    private void ResetMovement()
    {
        up = false;
        down = false;
        left = false;
        right = false;
    }

    private void SetHorizontal()
    {
        if (Input.GetKey("a")){
			left = true;
		}		
		if (Input.GetKey("d")){
			right = true;
			left = false;
		}
    }

    private void SetVertical(){
		if (Input.GetKey("w")){
			up = true;
		}		
		if (Input.GetKey("s")){
			down = true;
			up = false;
		}
	}
}
