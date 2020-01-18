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
		Hide
	}
}
