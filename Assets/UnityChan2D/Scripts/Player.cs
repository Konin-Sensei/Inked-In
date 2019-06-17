 using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 10;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	public float moveSpeed = 12;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;
    private Animator m_animator;
	private SpriteRenderer m_renderer;

	void Start() {
		controller = GetComponent<Controller2D> ();
        m_animator = GetComponent<Animator> ();
		m_renderer = GetComponent<SpriteRenderer> ();
        m_animator.applyRootMotion = false;

		gravity = -(1 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void FixedUpdate() {

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
            m_animator.SetFloat("Vertical",0);
            if(!controller.collisions.above){
                m_animator.SetBool("isGround", true);
            }
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKey (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
            m_animator.SetTrigger("Jump");
            m_animator.SetFloat("Vertical",velocity.y);
            m_animator.SetBool("isGround", false);
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        float verticalHelper = velocity.y + (gravity * Time.deltaTime);
        velocity.y += (gravity * Time.deltaTime);
        
        m_animator.SetFloat("Vertical",velocity.y);
        m_animator.SetFloat("Horizontal",velocity.x);
		if(velocity.x < 0){
			m_renderer.flipX = true;
		}else{
			m_renderer.flipX = false;
		}
        if(velocity.y < -10){
            m_animator.SetBool("isGround", false);
        }
		controller.Move (velocity * Time.deltaTime);
	}
}