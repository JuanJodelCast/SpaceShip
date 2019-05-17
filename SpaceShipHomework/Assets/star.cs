using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public float speed = 1;

    private int lives = 5;

    private Rigidbody2D rig;


    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(-1, 0);

        rig.velocity = (movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (!other.GetComponent<bomb>().isEnemy)
        {
            Destroy(other.gameObject);
            lives--;
        }

        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }




}