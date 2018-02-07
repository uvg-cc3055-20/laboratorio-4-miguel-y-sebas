using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWing : MonoBehaviour
{
    // prefab para el laser que dispara la nave
    public GameObject laserPrefab;
    // velocidad de la nave
    public float speed = 5f;
    // utilizadas para que la nave no se pueda salir de la pantalla
    public float leftBoundary;
    public float rightBoundary;
    // punto para instanciar el laser 0
    public Transform laserP0;
    // punto para instanciar el laser 1
    public Transform laserP1;
    // RigidBody2D de la nave
    private Rigidbody2D rb;

    private void Start()
    {
        // obtenemos el componente RigidBody2D que esta en nuestra nave
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
#if UNITY_ANDROID
        // obtener y almacenar el valor del acelerometro en x
        float movX = Input.acceleration.x;
        // desplazar la nave dependiendo del valor del acelerometro
        rb.transform.Translate(Vector2.right * speed * movX * Time.deltaTime);
        // mantener la nave en la pantalla
        if (transform.position.x < leftBoundary)
            transform.position = new Vector2(leftBoundary, transform.position.y);
        if (transform.position.x > rightBoundary)
            transform.position = new Vector2(rightBoundary, transform.position.y);
        // solo disparamos si hay al menos un touch detectado
        if (Input.touchCount > 0)
        {
            // para no spamear disparos, solo disparamos si el touch esta en su fase inicial
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // instanciamos ambos lasers
                Instantiate(laserPrefab, laserP0.position, laserPrefab.transform.rotation);
                Instantiate(laserPrefab, laserP1.position, laserPrefab.transform.rotation);
            }
        }
#endif
    }

    // si algo entra al collider de la nave, es un meteorito, por lo que el juego termina 
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        GameController.instance.muerto = true;
    }
}
