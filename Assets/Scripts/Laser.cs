using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Miguel Valle 17102
// Sebastian Arriola 11463
public class Laser : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
