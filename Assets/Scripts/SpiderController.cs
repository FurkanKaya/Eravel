﻿ using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour
{

    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D myRigidbody;

	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    // örümcek kamera görüş açısındaysa sola -x yönde hareket eder
	void Update ()
    {
	    if(canMove)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
	}

    // kamera görüş açısına giren örümceğin harekete başlamasını sağlar
    void OnBecameVisible()
    {
        canMove = true;
    }

    // boşluğa düşen örümceğin nesnesinin deaktif edilmesini sağlar
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        //respawn sonrası aktif edilen örümceğin, hareket için yine ekrana girmeyi beklemesini sağlar
        canMove = false;
    }

}
