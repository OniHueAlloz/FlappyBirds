using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    public void Play ()
    {
        Fase.inimigos = 5;
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void Quit ()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
