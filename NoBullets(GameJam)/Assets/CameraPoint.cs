using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public GameObject camera;
    public Transform nextPoint;
    private bool startChange = false;
    public bool shouldChange = true;
    public float speed = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Changes");
            startChange = true;
        }
    }

    private void Update()
    {
        if (shouldChange && startChange)
        {
            float step = speed * Time.deltaTime;

            camera.transform.position = Vector3.MoveTowards(camera.transform.position, nextPoint.position, step);
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -10);
            if (Vector3.Distance(camera.transform.position, nextPoint.position) < 0.1f)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, -10);
                shouldChange = false;
            }
        }
    }

}
