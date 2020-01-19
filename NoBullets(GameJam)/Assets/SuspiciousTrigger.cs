using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (collision.gameObject.GetComponent<GirlState>().state != GirlState.State.Hide)
			{
				transform.GetComponentInParent<EnemyMoving>().SpotGirl(collision.gameObject.transform.position, Time.time);
				
			}
		}
	}
}
