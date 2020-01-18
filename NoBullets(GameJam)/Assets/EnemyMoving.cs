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
	public float chaseTime = 1f;

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

	void PatrolArea()
	{
		float step = speed * Time.deltaTime;

		if (isGoToLeft)
		{
			transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, step);
			if (Vector3.Distance(transform.position, leftPoint.position) < 0.1f)
			{
				isGoToLeft = false;
				gameObject.transform.localScale = new Vector3(-1, 1, 0);
			}
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, step);
			if (Vector3.Distance(transform.position, rightPoint.position) < 0.1f)
			{
				isGoToLeft = true;
				gameObject.transform.localScale = new Vector3(1, 1, 0);
			}
		}
	}

	public void SpotGirl(Vector3 position, float time)
	{
		isSpotted = true;
		spottedTime = time;
		girlPosition = position;
		Debug.Log("RUNNING!");
	}
	public void RunToGirl()
	{

		float step = speed * 2.5f * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, girlPosition, step);
		if (Vector3.Distance(transform.position, girlPosition) < 3f)
		{
			gameObject.transform.localScale = new Vector3(-1, 1, 0);
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
