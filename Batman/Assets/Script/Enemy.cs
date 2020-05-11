using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBtwShots = 0.2f;
    [SerializeField] float maxTimeBtwShots = 3f;
    [SerializeField] GameObject EnemyShootPrefab;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip enemyShoot;
    [SerializeField] int Point;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        }
    }

    private void Fire()
    {
        GameObject ss = Instantiate(EnemyShootPrefab, transform.position, Quaternion.identity) as GameObject;
        ss.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -110);
        AudioSource.PlayClipAtPoint(enemyShoot, Camera.main.transform.position, 0.5f);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (Health == 0)
            Explo();
        else
        {
            Health -= damageDealer.GetDamage();
            damageDealer.Hit();

        }
    }

    private void Explo()
    {

        FindObjectOfType<Score>().AddToScore(Point);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX,transform.position,Quaternion.identity);
        Destroy(explosion, 0.5f);
        AudioSource.PlayClipAtPoint(deathSound,Camera.main.transform.position,0.7f);
    }
}
