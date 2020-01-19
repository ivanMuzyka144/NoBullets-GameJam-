using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject myCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
            Debug.Log("Triggered");
			myCamera.GetComponent<Animator>().SetBool("ShouldMove", !(myCamera.GetComponent<Animator>().GetBool("ShouldMove")));
		}
    }
    
}
