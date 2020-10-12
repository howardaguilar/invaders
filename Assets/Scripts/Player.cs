using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shottingOffset;
    public GameObject particle;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);

        Destroy(shot, 3f);

      }
      // Move player
      if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 3 * Time.deltaTime);
        }
      else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 4 * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Player is destroyed when another gameObject collides with it
        Destroy(gameObject);
        Destroy(collision.gameObject);
        // Particle Stuff
        GameObject particles = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(particles, 2f);
        //amp++;
    }
}
