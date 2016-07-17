using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 150f;
    public GameObject projectile;
    public float projectileSpeed;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 50;

    public AudioClip enemyFireSound;
    public AudioClip enemyDeathSound;

    private Score scoreKeep;

    void OnTriggerEnter2D(Collider2D col)
    { 
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if(missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if(health <= 0)
            {
                Explode();   
            }
        }
    }

    void Start()
    {
       scoreKeep = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Explode()
    {
        scoreKeep.ScoreIncrementor(scoreValue);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
    }

    void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyFireSound, transform.position);
    }

}
