using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueBoss : MonoBehaviour
{
    public Transform ataque1Prefab;
    public Transform ataque2Prefab;
    private int cargaAtaque1 = 0;
    private int cargaAtaque2 = 0;
    private Vector3 spawnAtaque;
    public GameObject bossLocation;
    public float offsetX;
    public float offsetY;
    Rigidbody2D ataqueCorpo;
    Vector2 pedraImpulso = new Vector2(-300f, 400f);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("reload1", 0f, 3f);
        InvokeRepeating("reload2", 0f, 7f);        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.bossLive)
        {
            spawnAtaque = bossLocation.transform.position + new Vector3 (-1 * offsetX, -1 * offsetY, 0.0f);

            if(cargaAtaque1>0)
            {
                Instantiate(ataque1Prefab, spawnAtaque, Quaternion.identity);
                cargaAtaque1--;
            }
            if(cargaAtaque2>0)
            {
                Transform ataque2 = Instantiate(ataque2Prefab, spawnAtaque, Quaternion.identity);
                ataqueCorpo = ataque2.GetComponent<Rigidbody2D> ();
                ataqueCorpo.AddForce(pedraImpulso);
                cargaAtaque2--;
            }
        }
        
    }

    void reload1()
    {
        cargaAtaque1++;
    }
    void reload2()
    {
        cargaAtaque2++;
    }
}
