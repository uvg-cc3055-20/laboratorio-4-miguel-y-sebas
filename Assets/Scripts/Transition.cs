using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    // texto para mostrar el highscore
    public Text high;

    public void Start()
    {
        // actualizamos el highscore con el valor guardado en PlayerPrefs
        high.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString("n2");
    }
    
    // carga la escena con indice n 
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }
}
