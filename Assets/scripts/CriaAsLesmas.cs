using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarAsLesmas : MonoBehaviour
{

    public GameObject inimigoPrefab;
    public float intialDelay;
    public float enemyPeriod;
    public float enemyHeight;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("CreateEnemy",intialDelay,enemyPeriod); 
    }

    void CreateEnemy()
   {
      if(Fase.inimigos > 0)
      {
         float a = Random.Range(-enemyHeight,enemyHeight);
         var enemyTransform = Instantiate(inimigoPrefab,this.gameObject.transform).transform;
         enemyTransform.position += a * Vector3.up;
      }
   }

   void update()
   {

   }
   
   
}
