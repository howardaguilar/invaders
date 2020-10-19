using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip barrierBreak;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Barriers only purpose is to be destroyed/stop bullets
    void OnCollisionEnter2D(Collision2D collision)
    {
        //barrierClink();
        Destroy(gameObject);
        Destroy(collision.gameObject);

    }
    // Sound effects
    public void barrierClink()
    {
        audioSource.PlayOneShot(barrierBreak);
    }
}
