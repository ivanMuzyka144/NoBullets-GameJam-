using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;


    public float speed = 2f;
    public bool isGoToLeft = true;

    
    void Update()
    {
        float step = speed * Time.deltaTime; 

        if (isGoToLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, step);
            if (Vector3.Distance(transform.position, leftPoint.position) < 0.1f)
            {
                isGoToLeft = false;
                gameObject.transform.localScale =  new Vector3(-1, 1,0);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, step);
            if (Vector3.Distance(transform.position, rightPoint.position) < 0.1f)
            {
                isGoToLeft = true;
                gameObject.transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }
}
