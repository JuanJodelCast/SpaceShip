using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milenium : MonoBehaviour
{
    public GameObject missle;
    public float speed;
    public GameObject gameOver;
    private Rigidbody2D rigid;
    private int lives = 5;


    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float moveV = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0, moveV);

        rigid.velocity = (movement * speed);


    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            missle.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            missle.GetComponent<bomb>().isEnemy = false;
            Instantiate(missle);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<bomb>() != null)
        {
            Destroy(other.gameObject);
            lives--;
            StartCoroutine("changeColor");
        }


        if (other.GetComponent<bomb>().isEnemy)
        {
            Destroy(other.gameObject);
            lives--;
            StartCoroutine("changeColor");
        }

        if (lives < 1)
        {
            Instantiate(gameOver);
            Destroy(this.gameObject);

        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Lives: " + lives.ToString());

    }

    IEnumerator changeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.0f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}

