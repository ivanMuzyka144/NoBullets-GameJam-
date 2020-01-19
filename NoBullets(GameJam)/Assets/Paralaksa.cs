using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaksa : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parralaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parralaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parralaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parralax = (previousCamPos.x - cam.position.x) * parralaxScales[i] * 0.05f;
            float backgroundTargetPosX = backgrounds[i].position.x + parralax;
            Vector3 backgroundsTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundsTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
