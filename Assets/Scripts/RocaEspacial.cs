using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaEspacial : MonoBehaviour
{
    // se usa para desactivar el sprite de la roca
    private SpriteRenderer sprite;
    // se usa para que la roca emita un sonido de explosion
    private AudioSource audioSource;
    // el collider2D que esta en esta roca
    private Collider2D col;
    // velocidad de la roca
    private float speed = 4.5f;

    private void Start()
    {
        // obtenemos los componentes necesarios
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<PolygonCollider2D>();
    }
    
    private void Update()
    {
        // cada frame, la roca se desplaza hacia abajo
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        // revisamos si la roca ya salio de la pantalla y la destruimos
        // si ya no es visible
        if (transform.position.y < -5.5f)
            Destroy(gameObject);
    }

    // 2 cosas pueden entrar al collider de la roca, un disparo y el jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si entra un disparo
        if(collision.CompareTag("laser"))
        {
            // desactivamos el collider para que ya no detecte mas colisiones
            col.enabled = false;
            // desactivamos el sprite para que la roca ya no sea visible
            sprite.enabled = false;
            // le damos play al sonido de la explosion
            audioSource.Play();
            // destruimos el GameObject del laser
            Destroy(collision.gameObject);
            // destruimos este objeto cuando el audio haya terminado de sonar
            Destroy(gameObject, audioSource.clip.length);
        }
        // si entra el jugador
        else if(collision.CompareTag("Player"))
        {
            // la variable muerto de GameController controla cuando el juego termina
            GameController.instance.muerto = true;
        }
    }
}
