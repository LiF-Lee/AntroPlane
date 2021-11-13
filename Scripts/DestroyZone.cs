using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);

        //if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        //{
        //    other.gameObject.SetActive(false);
        //    if (other.gameObject.name.Contains("Bullet"))
        //    {
        //        if (GameObject.Find("Player") == null)
        //        {
        //            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
        //            player.bulletObjectPool.Add(other.gameObject);
        //        }
        //    }
        //}
    }
}
