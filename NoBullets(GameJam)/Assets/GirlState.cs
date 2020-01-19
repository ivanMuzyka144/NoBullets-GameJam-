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
		GetComponent<Animator>().SetBool("isHiding", false);
		GetComponent<Animator>().SetBool("isClimbing", false);
		state = State.Walk;
		GetComponent<Rigidbody2D>().gravityScale = 1;
		
	}
	public void SetHide()
	{
		state = State.Hide;
		GetComponent<Animator>().SetBool("isHiding", true);
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	public void SetClimbing()
	{
		GetComponent<Animator>().SetBool("isClimbing", true);
		state = State.Climb;
		GetComponent<Rigidbody2D>().gravityScale = 0;

	}

}
