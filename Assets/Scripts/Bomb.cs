using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   static private Vector2 _hitPoint;
    static private GameController explosion;
    // Start is called before the first frame update
    void Start()
    {
       _hitPoint= Camera.main.GetComponent<GameController>().LowerPoints;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -_hitPoint.y)
        {
            Destroy(this.gameObject);
            GameController explosion = Camera.main.GetComponent<GameController>();
            explosion.bombDetonation();


        }
        
     
    }
}
