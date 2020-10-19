using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Audio stuff
    private AudioSource audioSource;
    public AudioClip playerPew;
    public AudioClip playerBoom;
    public AudioClip barrierBreak;

    public GameObject bullet;
  public Transform shottingOffset;
    public GameObject particle;

    // Shoot thing
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerAnimator = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
            //PlayerPew();
            playerAnimator.SetTrigger("Shoot");
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
        PlayerBoom();
        // Player is destroyed when another gameObject collides with it
        Destroy(gameObject);
        Destroy(collision.gameObject);
        // Particle Stuff
        GameObject particles = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(particles, 2f);
        //amp++;
        // Swap to credits
        SceneManager.LoadScene("Credits");
    }

    // Sound effects
    public void PlayerPew()
    {
            audioSource.PlayOneShot(playerPew);
    }

    public void PlayerBoom()
    {
        audioSource.PlayOneShot(playerBoom);
    }

    public void barrierClink()
    {
        audioSource.PlayOneShot(barrierBreak);
    }
}
