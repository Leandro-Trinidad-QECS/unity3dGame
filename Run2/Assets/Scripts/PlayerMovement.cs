using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 7.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Animator anim;
    public Collider coll;
	private void Start()
	{
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
	}
	void Update()
    {
            
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {


            
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
                

        } else {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"),moveDirection.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed / 2;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}