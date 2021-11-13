using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

    private GameObject airplanePosition;

    void Start()
    {
        airplanePosition = GameObject.Find("Fire Position").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        planeRotationController(h, v);

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void planeRotationController(float h, float v)
    {
        Vector3 tempRot = new Vector3();

        if (h > 0) tempRot.z = -25;
        else if (h < 0) tempRot.z = 25;
        else tempRot.z = 0;

        if (v > 0) tempRot.x = -25;
        else if (v < 0) tempRot.x = 25;
        else tempRot.x = 0;

        airplanePosition.transform.rotation = Quaternion.Euler(tempRot);
    }
}
