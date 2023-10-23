using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControlaJogadorMouseEsquerdo : MonoBehaviour {

  bool comecou;
  bool acabou;
  Rigidbody2D corpoJogador;
  Rigidbody2D dinamitecorpo;
  Vector2 forcaImpulso = new Vector2(0, 500f);
  Vector2 dinamiteImpulso = new Vector2(350f, 350f);
  public int vida = 3;
  public int cargas = 3;
  public float time;
  public Transform dinamitePrefab;
  public GameObject spawnDinamite;
  protected float Animacao;
  public GameObject heart2;
  public GameObject heart3;

  [SerializeField] private string retornarAoMenu;


  void Start () { 
    corpoJogador = GetComponent<Rigidbody2D> ();

    InvokeRepeating("reload", 0f, 1.5f);
    
  }
  
  void Update () 
  {
    
  }

  private void OnFly ()
  {
    if (!comecou) {
        comecou = true;
        corpoJogador.isKinematic = false;
      }

      corpoJogador.velocity = new Vector2 (0, 0);
      corpoJogador.AddForce(forcaImpulso);
  }

  private void reload()
  {
    cargas++;
  }
  private void OnShoot ()
  {
    if (cargas > 0)
    {
      cargas--;
      attack();
    }
  }

  void attack ()
  {
    Vector3 posicaoObjeto = GameObject.Find("SpawnAtaques").transform.position;
    Transform dinamite = Instantiate(dinamitePrefab, posicaoObjeto, Quaternion.identity);
    Destroy(dinamite.gameObject, 10f);

    dinamitecorpo = dinamite.GetComponent<Rigidbody2D> ();
    dinamitecorpo.AddForce(dinamiteImpulso);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
        
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Dead"))
    {
      vida = vida - 3;
      if (vida <= 0)
      {
        //Destroy(this.gameObject);
        SceneManager.LoadScene(retornarAoMenu);
      }   
    }
    
    if(other.gameObject.CompareTag("Enemy"))
    {
      vida--;
      if (vida <= 2)
      {
        heart3.SetActive(false);
        if (vida <= 1)
        {
          heart2.SetActive(false);
          if (vida <= 0)
          {
            SceneManager.LoadScene(retornarAoMenu);
          }
        }
      }       
    }    
  }
}
