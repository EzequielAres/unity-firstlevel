using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public float parallaxEffect;

    private new Transform camera;
    private Vector3 lastCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        lastCameraPosition = camera.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 backgroundMovement = camera.position - lastCameraPosition;
        transform.position += new Vector3(backgroundMovement.x * parallaxEffect, backgroundMovement.y, 0);
        lastCameraPosition = camera.position;
    }
}
