using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;

    private float yRange = 4f;

    void Start()
    {
        SetRandomColor();
    }

    void Update()
    {
        //to make the player jump
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //to prevent the player from falling infinitely before starting
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(0f, -yRange, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //when player changes color
        if(col.tag == "ColorChanger")
        {
            SoundManager.PlaySound("colorChange");
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        //if player completes the level
        if(col.tag == "Win")
        {
            SoundManager.PlaySound("winSound");
            Destroy(col.gameObject);
            Invoke("Win", 0.5f);
            return;
        }
        //if player collides with different color
        if(col.tag != currentColor)
        {
            //Debug.Log("game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //loading the level completion scene
    public void Win()
    {
        SceneManager.LoadScene("LevelCompleted");
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0,4);

        switch(index)
        {
            case 0: currentColor = "Blue";
                    sr.color = colorBlue;
                    break;
            case 1: currentColor = "Yellow";
                    sr.color = colorYellow;
                    break;
            case 2: currentColor = "Purple";
                    sr.color = colorPurple;
                    break;
            case 3: currentColor = "Pink";
                    sr.color = colorPink;
                    break;
        }
    }
}
