using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour {
    public Text high;
    public void Start()
    {
        high.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString("n2");
    }
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }
}
