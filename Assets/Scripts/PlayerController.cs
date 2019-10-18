using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rigidBody;

    private int score;
    public Text scoreText;
    public Text winText;



	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        SetWinText();
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            if (score == 12)
            {
                winText.enabled = true;
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetWinText()
    {
        winText.text = "You win!";
        winText.enabled = false;
    }
}
