using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
	public float speed = 400;
	private Rigidbody2D rb;
	private bool isGrounded = true;
	private float xDisplacement;

	public float jumpSpeed = 200;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		

		animator.SetFloat("HorizontalSpeed", Mathf.Abs(rb.velocity.x));
		animator.SetFloat("VerticalSpeed", rb.velocity.y);

		if (GetComponent<GirlState>().state == GirlState.State.Walk)
		{
			xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

			if (Input.GetButtonDown("Jump") && isGrounded)
			{
				rb.AddForce(new Vector2(0, jumpSpeed));
				isGrounded = false;
				
			}

			if (Input.GetAxis("Horizontal") < 0)
			{
				transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
			}
			else if (Input.GetAxis("Horizontal") > 0)
			{
				transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			}
			//animator.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x));
			//animator.SetFloat("jumpSpeed", rb.velocity.y);


		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		animator.SetBool("isGrounded", true);
		isGrounded = true;
	}
}
