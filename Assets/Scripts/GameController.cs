using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject basketPrefab;
    static private int numBasket=3;
    public float basketSpacingY = 1f;
    static private Vector2 _lowerPoints;
    private float ObjectWidth;
    private List<GameObject> basketList;
  
    public Vector2 LowerPoints => _lowerPoints;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        ObjectWidth = basketPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        _lowerPoints = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        for (var i = 0; i < numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector2 pos = Vector2.zero;
            pos.y = -_lowerPoints.y-ObjectWidth/2 + (basketSpacingY+i);
            pos.x = -_lowerPoints.x+ObjectWidth;
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bombDetonation()
    {
        GameObject[] bombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tBomb in bombArray)
            Destroy(tBomb);
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
