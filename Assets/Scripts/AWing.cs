using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWing : MonoBehaviour
{
    public GameObject laserPrefab;
    public float speed = 5f;
    public float leftBoundary;
    public float rightBoundary;
    public Transform laserP0;
    public Transform laserP1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movX = Input.acceleration.x;
        if(transform.position.x > leftBoundary && transform.position.x < rightBoundary)
            rb.transform.Translate(Vector2.right * speed * movX * Time.deltaTime);
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Instantiate(laserPrefab, laserP0.position, laserPrefab.transform.rotation);
                Instantiate(laserPrefab, laserP1.position, laserPrefab.transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameController.instance.muerto = true;
    }
}
