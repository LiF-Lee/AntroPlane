using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public GameObject explosionEffect;

    private bool isDelayFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForDelay());
    }

    void Update()
    {
        if (isDelayFinish)
        {
            Vector3 dir = Vector3.forward;
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    IEnumerator waitForDelay()
    {
        if (isDelayFinish)
            yield return null;
        yield return new WaitForSeconds(3);
        isDelayFinish = true;    
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = gameObject.transform.position;
    }
}
