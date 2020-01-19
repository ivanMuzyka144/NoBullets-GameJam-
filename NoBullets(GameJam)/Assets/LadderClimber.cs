using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimber : MonoBehaviour
{
	bool inReach;
	GameObject ladder;

	public float climbingSpeed = 200f;

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag == "Ladder")
		{

			inReach = true;
			ladder = col.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ladder")
		{
			inReach = false;
			ladder = null;
		}
	}



	void Update()
	{
		
		if (inReach)
		{
			if (Input.GetAxis("Vertical") != 0)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxis("Vertical") * climbingSpeed * Time.deltaTime);
				GetComponent<Rigidbody2D>().gravityScale = 0;
				GetComponent<GirlState>().SetClimbing();
				Ladder l = ladder.GetComponent<Ladder>();
				if (l!=null)
				{
					if(l.left)
						transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
					else
					{
						transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
					}
				}
				
			}

		}
		else
		{
			GetComponent<Rigidbody2D>().gravityScale = 1;
			GetComponent<GirlState>().SetWalk();
		}
		if (Input.GetButtonDown("Jump"))
		{
			GetComponent<GirlState>().SetWalk();
			
		}
	}
}
