using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLesmaoDaDireitaParaEsquerda : MonoBehaviour
{
    public int vida = 3;
    public float speed = -10.0f;
    public bool eInimigo = true;
    public string animacaoMorte;
    public string podeSerAtingidoPor;
    public string atinge;

    private Animator animacao2;

    void Awake ()
    {
        animacao2 = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
      {
         if(other.gameObject.CompareTag(podeSerAtingidoPor))
         
         {
            vida--;
            if (vida == 0)
            {
                animacao2.Play(animacaoMorte);
                
                if(eInimigo)
                {
                    Fase.inimigos = Fase.inimigos - 1;
                    print(Fase.inimigos);
                }
                Destroy(this.gameObject, 0.4f);

            }         
         }

         
      }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(atinge))
        
         {
            animacao2.Play(animacaoMorte);
            
            Destroy(this.gameObject, 0.4f);          
         }
    }
    
}
