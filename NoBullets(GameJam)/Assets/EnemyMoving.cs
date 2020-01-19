using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
	public Transform leftPoint;
	public Transform rightPoint;


	public float speed = 2f;
	public bool isGoToLeft = true;

	bool isSpotted = false;
	float spottedTime;
	Vector3 girlPosition;
	public float chaseTime = 3f;

	float step;

	void Update()
	{

		if (!isSpotted)
		{
			PatrolArea();
		}
		else
		{
			if (Time.time - spottedTime < chaseTime)
			{
				RunToGirl();
			}
			else
			{
				isSpotted = false;
			}
		}

	}

	void RotateToTarget(Vector2 target)
	{
		if (transform.position.x - target.x > 0)
		{
			transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		}
		else
		{
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
		}
	}

	void PatrolArea()
	{
		step = speed * Time.deltaTime;
		GetComponent<Animator>().SetBool("isWalking", true);
		GetComponent<Animator>().SetBool("isRunning", false);

		if (isGoToLeft)
		{
			RotateToTarget(leftPoint.position);
			transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, step);
			if (Vector3.Distance(transform.position, leftPoint.position) <4f)
			{
				isGoToLeft = false;
			
			}
		}
		else
		{
			RotateToTarget(rightPoint.position);
			transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, step);
			if (Vector3.Distance(transform.position, rightPoint.position) < 4f)
			{
				isGoToLeft = true;
				
			}
		}
	}

	public void SpotGirl(Vector3 position, float time)
	{
		FindObjectOfType<AudioManager>().Play("ChaseTheme");
		isSpotted = true;
		spottedTime = time;
		girlPosition = position;
		Debug.Log("RUNNING!");
	}

	public void RunToGirl()
	{
		GetComponent<Animator>().SetBool("isWalking", false);
		GetComponent<Animator>().SetBool("isRunning", true);
		step = speed * 2.5f * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, girlPosition, step);
		if (Vector3.Distance(transform.position, girlPosition) < 3f)
		{
			RotateToTarget(girlPosition);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), GetComponent<CapsuleCollider2D>());

		}

	}
}
