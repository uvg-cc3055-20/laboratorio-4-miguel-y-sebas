using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Miguel Valle 17102
// Sebastian Arriola 11463
public class CreadorDeRocasEspacialesLocas : MonoBehaviour
{
    // arreglo para los distintos prefabs de rocas
    public GameObject[] rocas;
    private float i = 0f; // tiempo transcurrido desde la creacion de la ultima roca
    private float j = 1f; // tiempo entre creacion de rocas

    public void Update()
    {
        // si ya paso el tiempo suficiente para crear una nueva roca y el jugador no ha perdido
        if ((i >= j)&&(GameController.instance.muerto == false))
        {
            // escoger una roca al azar del arreglo
            int k = Random.Range(0, rocas.Length);
            Instantiate(rocas[k], new Vector2(Random.Range(-2.7f, 2.8f), 5.5f), Quaternion.identity);
            i = 0; // reiniciar el tiempo transcurrido entre creacion de rocas
        }
        // sumar el tiempo que duro el ultimo frame al tiempo transcurrido entre creacion de rocas
        i = i + Time.deltaTime;
    }
}
