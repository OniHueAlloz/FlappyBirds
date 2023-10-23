using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{
    public int vida = 10;
    private Animator animacaoBoss;
    public static bool bossLive = true;
    private bool iniciarContagem = false;
    private float timer = 5.0f ;
    public GameObject jogador;
    public string nomeDoLevel;

    void Awake ()
    {
      animacaoBoss = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        
        if (iniciarContagem)
        {
          timer -= Time.deltaTime;
          print(timer);
        }

        if (timer == 0.0f)
        {
          SceneManager.LoadScene(nomeDoLevel);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Shoot"))
    {
      vida--;
      print(vida);
      if (vida <= 0)
      {
        bossLive = false;
        animacaoBoss.Play("DeadBoss");
        Destroy(jogador, 0.3f);        
        Destroy(this.gameObject, 0.4f);
        SceneManager.LoadScene(nomeDoLevel);
      }   
    }
  }
}
