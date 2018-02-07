using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeRocasEspacialesLocas : MonoBehaviour
{
    public GameObject[] meteorito0;
    private float i = 0;
    private float j = 1;
    public void Update()
    {
        if ((i >= j)&&(GameController.instance.muerto == false))
        {
            int k = Random.Range(0, meteorito0.Length);
            Instantiate(meteorito0[k], new Vector2(Random.Range(-2.7f, 2.8f), 5.5f), Quaternion.identity);
            i = 0;
        }
        i = i + Time.deltaTime;
    }
}
