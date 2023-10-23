using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamiteExplode : MonoBehaviour
{
    private Animator animacao;
    public string alvo;
    public string animacaoContato;
    void Awake ()
    {
        animacao = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(alvo))
        {
            animacao.Play(animacaoContato);
            Destroy(this.gameObject, 0.4f);    
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(alvo))
        {
            animacao.Play(animacaoContato);
            Destroy(this.gameObject, 0.4f);    
        }   
    }
}
