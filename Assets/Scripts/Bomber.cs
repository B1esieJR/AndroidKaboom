using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float _bomberSpeed = 5f;
    [SerializeField] private float leftAndRightEdge = 8f;
    [SerializeField] private float chanceToTurn = 0.02f;
    [SerializeField] private float secondsBetweenBombDrops = 1f;
    private float ObjectWidth;
    // Start is called before the first frame update
    void Start()
    {
      
      ObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        Invoke("BombsDrop", 2f);
    }
    private float checkBoundsXworld()
    {
        Vector2 tempPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().LowerPoints;
        return tempPos.x - ObjectWidth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        BomberMove();
        
    }
    void BomberMove()
    {
        Vector2 pos = transform.position;
        pos.x += _bomberSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -checkBoundsXworld())
        {
            _bomberSpeed = Mathf.Abs(_bomberSpeed);
            this.transform.Rotate(0, Mathf.Abs(180), 0);
        }
        else if (pos.x > checkBoundsXworld())
        {
            
            _bomberSpeed = -Mathf.Abs(_bomberSpeed);    
            this.transform.Rotate(0, Mathf.Abs(180), 0);
        }
        else if (Random.value < chanceToTurn)
        {
            _bomberSpeed *= -1;
            this.transform.Rotate(0, Mathf.Abs(180), 0);
        }      
    }
    private void BombsDrop()
    {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = transform.position;
        Invoke("BombsDrop", secondsBetweenBombDrops);
    }
       
   
}
