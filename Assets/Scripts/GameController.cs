using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public float t=0;
    public Text s;
    public bool muerto = false;
	void Start () {
        instance = this;	
	}
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    void Update () {
        if (muerto == false)
        {
            t = t + Time.deltaTime;
            s.text = "Time : " + t.ToString("n2");
        } else
        {
            if (t>PlayerPrefs.GetFloat("Highscore"))
            PlayerPrefs.SetFloat("Highscore", t);
            LoadScene(0);
        }
	}
}
