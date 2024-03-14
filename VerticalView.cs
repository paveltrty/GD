using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mose : MonoBehaviour
{
    public float max_angle = 50;
    public float low_angle = -50;
    public float vertSens = 3.0f;

    public float vert_rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vert_rot -= Input.GetAxis("Mouse Y") * Time.deltaTime * vertSens;
        vert_rot = Mathf.Clamp(vert_rot, low_angle, max_angle);
        transform.localEulerAngles = new Vector3(vert_rot, 0, 0);
    }
}