using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Car : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xpadding = 2f;
    [SerializeField] float ypadding = 2f;
    [SerializeField] float Health=500f;
    [Header("Prefab")]
    [SerializeField] GameObject shootPrefab;
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject destroyVFX;
    [SerializeField] AudioClip playerSound;
    [SerializeField] AudioClip playerShoot;
    float projectileFiringPeriod = 0.15f;

    float xMin,xMax,yMin,yMax;
    // Start is called before the first frame update
    void Start()
    {
        moveBoundaries();
    }

    

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (Health == 0)
        {

            FindObjectOfType<Level>().GameOver();
            Destroy(gameObject);
            GameObject destroy = Instantiate(destroyVFX,transform.position,Quaternion.identity);
            Destroy(destroy, 2f);
            AudioSource.PlayClipAtPoint(playerSound,Camera.main.transform.position,1f);

        }
            
        else
        {
            Health -= damageDealer.GetDamage();
            damageDealer.Hit();
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopAllCoroutines();
        }
    }

    

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject shoot = Instantiate(shootPrefab, transform.position, Quaternion.identity) as GameObject;
            shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(playerShoot,Camera.main.transform.position,0.25f);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
        
    }

    public float HealthRet()
    {
        return Health;
    }
   

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
   
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXPos,newYPos);
 
    }

    private void moveBoundaries()
    {
        Camera mainCamera = Camera.main;
        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xpadding;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xpadding;

        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + ypadding;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - ypadding;
    }
}
