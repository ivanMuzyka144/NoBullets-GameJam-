using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehind : MonoBehaviour
{
	bool inReach;
	GameObject hideObject;

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Hideble")
		{
			inReach = true;
			hideObject = col.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Hideble")
		{
			inReach = false;
			hideObject = null;
		}
	}

	void Update()
	{
		if (inReach) {
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (GetComponent<GirlState>().state == GirlState.State.Walk)
				{
					GetComponent<SpriteRenderer>().color = Color.grey;
					GetComponent<GirlState>().state = GirlState.State.Hide;
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;

					MoveToHide();

				}

				else if (GetComponent<GirlState>().state == GirlState.State.Hide)
				{
					GetComponent<SpriteRenderer>().color = Color.white;
					GetComponent<GirlState>().state = GirlState.State.Walk;
				}
			}

		}
	}

	void MoveToHide()
	{
		if (hideObject.transform.childCount > 1)
		{
			if (Vector2.Distance(hideObject.transform.GetChild(0).transform.position, transform.position) <=
							Vector2.Distance(hideObject.transform.GetChild(1).transform.position, transform.position))
			{
				transform.position = hideObject.transform.GetChild(0).transform.position;
			}
			else
			{
				transform.position = hideObject.transform.GetChild(1).transform.position;
			}
		}
		else
		{
			transform.position = hideObject.transform.GetChild(0).transform.position;
		}
	}
}
