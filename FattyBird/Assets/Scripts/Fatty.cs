using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatty : MonoBehaviour
{
    public float Force; // Lentämisvoima, säädetään Unityn puolella
    private bool isDead = false; // Onko lintu osunut maahan

    private Rigidbody2D rb2d; // Fysiikat

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0) // Lentää ylöspäin hiiren klikkauksella
        {
            Touch touch = Input.GetTouch(0);

            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, Force));
        }
    }

    void OnCollisionEnter2D(Collision2D other) // Kun lintu osuu collideriin, se kuolee
    {
        GameController.instance.BirdDied(); // Gamecontroller scriptissä on game over ruutu
        isDead = true;
    }
}