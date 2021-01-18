using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 4f;
    public GameObject KillingEffect;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count++;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude>=health)
        {
            die();
        }
    }

    void die()
    {
        Instantiate(KillingEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        count--;

        //if(count==0)
        //{
        //    Debug.Log("Game Over...!!");
        //}
    }
}
