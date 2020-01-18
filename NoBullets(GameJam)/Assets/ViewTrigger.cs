using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrigger : MonoBehaviour
{
    public GameObject enemy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemy.GetComponent<ShootInGirl>().Shoot();
        }
    }
}
