using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy sounds
    private AudioSource audioSource;
    public AudioClip enemyPow;

    public GameObject particle;
    bool bounceRight = true;
    private int amp = 1;
    // BULLET STUFF
    public GameObject EnemyBullet;
    public Transform EnemyshottingOffset;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ouch!");
        // Destroy self and colliding object
        //Debug.Log(gameObject.name);
        Destroy(gameObject);
        Destroy(collision.gameObject);
        // Particle Stuff
        GameObject particles = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(particles, 2f);
        //amp++;
    }

    void Update()
    {
        // Have enemy move left/right and down as it gets near the edges
        if (bounceRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * amp);
            if (gameObject.transform.position.x + 2 > 9)
            {
                transform.Translate(Vector3.down *  1);
                bounceRight = false;
            }
        } else if (!bounceRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * amp);
            if (gameObject.transform.position.x - 2 < -9)
            {
                transform.Translate(Vector3.down *  1);
                bounceRight = true;
            }
        }
        // Fire bullet at random times
        int num = Random.Range(1, 1500);
        if (num == 1)
        {
            enemyShoot();
            GameObject shot = Instantiate(EnemyBullet, EnemyshottingOffset.position, Quaternion.identity);

            Destroy(shot, 3f);

        }
    }
    // Increase speed
    public void speedIncrease()
    {
        amp++;
    }

    // Sound effects
    public void enemyShoot()
    {
        audioSource.PlayOneShot(enemyPow);
    }
}
