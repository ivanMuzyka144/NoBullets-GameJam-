using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
	public float speed = 400;
	private Rigidbody2D rb;
	private bool isGrounded = true;
	private float xDisplacement;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public float jumpSpeed = 200;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		if (GetComponent<GirlState>().state == GirlState.State.Walk)
		{
			xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

			if (Input.GetButtonDown("Jump") && isGrounded)
			{
				rb.AddForce(new Vector2(0, jumpSpeed));
				isGrounded = false;
			}


			if (rb.velocity.y < 0)
			{
				rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			}
			else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
			{
				rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
			}

			//animator.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x));
			//animator.SetFloat("jumpSpeed", rb.velocity.y);

			if (rb.velocity.x < 0)
			{
				transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			}
			else if (rb.velocity.x > 0)
			{
				transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//animator.SetTrigger("grounded");
		isGrounded = true;
	}
}
