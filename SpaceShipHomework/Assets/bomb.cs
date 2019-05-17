using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float speed = 5;
    public bool isEnemy = false;

    private Rigidbody2D rig;


    void Start()
    {
        if (isEnemy)
        {
            transform.localRotation = Quaternion.Euler(0, 180, -90);
        }
        rig = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 movement;
        if (!isEnemy)
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = new Vector2(-1, 0);
        }

        rig.velocity = (movement * speed);
    }
}