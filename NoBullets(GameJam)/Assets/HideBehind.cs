using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehind : MonoBehaviour
{
	bool inReach;

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Hideble")
			inReach = true;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Hideble")
			inReach = false;
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
				}

				else if (GetComponent<GirlState>().state == GirlState.State.Hide)
				{
					GetComponent<SpriteRenderer>().color = Color.white;
					GetComponent<GirlState>().state = GirlState.State.Walk;
				}
			}

		}
	}
	
}
