using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlState : MonoBehaviour
{
	public State state;

	void Start()
	{
		state = State.Walk;
	}

	public enum State
	{
		Walk,
		Hide,
		Climb
	}

	public void SetWalk()
	{
		state = State.Walk;
		GetComponent<Rigidbody2D>().gravityScale = 1;
		GetComponent<SpriteRenderer>().color = Color.white;
	}
	public void SetHide()
	{
		state = State.Hide;
		GetComponent<SpriteRenderer>().color = Color.grey;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	public void SetClimbing()
	{
		state = State.Climb;
		GetComponent<Rigidbody2D>().gravityScale = 0;

	}

}
