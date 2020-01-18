using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public GameObject leftCollider;
    public GameObject rightCollider;

    public float speed = 2f;
    public bool isGoToLeft = true;

    
    void Update()
    {
        float step = speed * Time.deltaTime; 

        if (isGoToLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, step);
            if (Vector3.Distance(transform.position, leftPoint.position) < 0.001f)
            {
                isGoToLeft = false;
                leftCollider.SetActive(false);
                rightCollider.SetActive(true);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, step);
            if (Vector3.Distance(transform.position, rightPoint.position) < 0.001f)
            {
                isGoToLeft = true;
                leftCollider.SetActive(true);
                rightCollider.SetActive(false);
            }
        }
    }
}
