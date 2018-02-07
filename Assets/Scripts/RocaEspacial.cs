using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaEspacial : MonoBehaviour
{
    private float speed = 4.5f;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -5.5f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("laser"))
        {
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Player"))
        {
            GameController.instance.muerto = true;
        }
    }
}
