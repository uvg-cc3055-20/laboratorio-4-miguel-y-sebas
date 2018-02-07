using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // singleton
    public static GameController instance;
    // tiempo total transcurrido de la partida
    public float timeEllapsed=0;
    // texto para mostrar el tiempo transcurrido
    public Text s;
    // determina si el jugador esta vivo o muerto
    public bool muerto = false;

	void Start ()
    {  
        // asignamos este objeto a la variable estatica instance
        instance = this;	
	}

    // carga la escena en el indice n
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }


    void Update ()
    {
        // si el jugador esta vivo, incrementamos el tiempo transcurrido y
        // actualizamos el texto
        if (muerto == false)
        {
            timeEllapsed = timeEllapsed + Time.deltaTime;
            s.text = "Time : " + timeEllapsed.ToString("n2");
        }
        // si el jugador esta muerto, revisamos si hay un nuevo highscore
        // y lo guardamos de ser asi. Por ultimo se carga la escena del menu.
        else
        {
            if (timeEllapsed>PlayerPrefs.GetFloat("Highscore"))
            PlayerPrefs.SetFloat("Highscore", timeEllapsed);
            LoadScene(0);
        }
	}
}
