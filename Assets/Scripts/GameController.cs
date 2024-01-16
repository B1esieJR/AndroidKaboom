using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject basketPrefab;
    static private int numBasket=3;
    public float basketSpacingY = 1f;
    static private Vector2 _lowerPoints;
    private float ObjectWidth;
  
    public Vector2 LowerPoints => _lowerPoints;

    // Start is called before the first frame update
    void Start()
    {
        ObjectWidth = basketPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        _lowerPoints = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        for (var i = 0; i < numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector2 pos = Vector2.zero;
            print(pos);
            pos.y = -_lowerPoints.y-ObjectWidth/2 + (basketSpacingY+i);
            pos.x = -_lowerPoints.x+ObjectWidth;
            tBasketGO.transform.position = pos;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
