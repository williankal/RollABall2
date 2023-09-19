using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.InputSystem;

using TMPro;


public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
	public TextMeshProUGUI timeText;

    public TextMeshProUGUI countText;
    private int count;
    private float time;
    private float movementX;
    private float movementY;

    public GameObject winTextObject;
    public GameObject loseTextObject;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 7;
		time = 25.0f;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count < 1)
        {
            SceneManager.LoadScene("MenuWin");
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }
	void Update(){
		if (time > 0){
			time = time - Time.deltaTime;
			timeText.text = "Time: "+Convert.ToInt32(time).ToString();
		}
		else{
			SceneManager.LoadScene("Scenes/MenuLoss");
		}
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
    }
}