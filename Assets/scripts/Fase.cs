using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase : MonoBehaviour
{
    public static int inimigos = 1;
    public bool spawnBoss = false;
    public GameObject boss;
    public GameObject start;
    private Vector3 posicao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (inimigos <= 0 & inimigos >= -2)   
     {
        spawnBoss = true;
        if (spawnBoss)
        {
            Instantiate(boss,start.transform.position,Quaternion.identity);
        }
        spawnBoss = false;
        inimigos = -3;
     }
    }
}
