﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public Text countText;
    public float speed;
    private int count;
    public Text winText;
	void Start()
	{
        count = 0;
        setCountText ();
        rb = GetComponent<Rigidbody>();
        winText.text = "";

	}

	void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

		
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();


        }
	}
    void setCountText(){
        countText.text = "Count: " + count.ToString();
        if(count>=5){
            winText.text = "You win";
        }
    }

}
