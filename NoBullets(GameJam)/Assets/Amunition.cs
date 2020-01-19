using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amunition : MonoBehaviour
{
    bool canDestroy = false;
    public float progress = 0;
    float speedOfProgress = 0.5f;
    float weightOfProgress = 12.5f;

    public GameObject circle;
    public GameObject sector1;
    public GameObject sector2;
    public GameObject sector3;
    public GameObject sector4;
    public GameObject sector5;
    public GameObject sector6;
    public GameObject sector7;
    public GameObject sector8;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canDestroy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canDestroy = false;
        }
    }
    void Update()
    {
        if (canDestroy && Input.GetKey(KeyCode.E))
        {
            if(circle.activeSelf == false)
            {
                circle.SetActive(true);
            }

            if (progress == weightOfProgress)
            {
                sector1.SetActive(true);
            }
            if (progress == weightOfProgress * 2)
            {
                sector2.SetActive(true);
            }
            if (progress == weightOfProgress * 3)
            {
                sector3.SetActive(true);
            }
            if (progress == weightOfProgress * 4)
            {
                sector4.SetActive(true);
            }
            if (progress == weightOfProgress * 5)
            {
                sector5.SetActive(true);
            }
            if (progress == weightOfProgress * 6)
            {
                sector6.SetActive(true);
            }
            if (progress == weightOfProgress * 7)
            {
                sector7.SetActive(true);
            }
            if (progress == weightOfProgress * 8)
            {
                sector8.SetActive(true);
            }

            progress += speedOfProgress;
            if (progress > 105)
            {
				circle.GetComponent<SpriteRenderer>().enabled=false;
                Debug.Log("Destroyed!");
            }
        }
        else
        {
            progress = 0;
            circle.SetActive(false);
        }
    }
}
