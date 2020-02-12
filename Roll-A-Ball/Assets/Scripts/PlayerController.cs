using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bounceForce;
    public float speed;
    public float boostedSpeed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
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
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false); //code called every time player touches a trigger collider
            count++;
            SetCountText();
        }

        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            speed = boostedSpeed;
            Invoke("speed", 3);
        }

        if(other.gameObject.tag == "Bouncer")
        {
            rb.AddForce(Vector3.up * bounceForce);
        }

        if(other.gameObject.tag == "WinZone")
        {
            winText.text = "You Win!!";
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
