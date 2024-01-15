using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private float _bomberSpeed = 2f;
    [SerializeField] private float leftAndRightEdge = 8f;
    [SerializeField] private float chanceToTurn = 0.1f;
    [SerializeField] private float secondsBetweenBombDrops = 1f;
    private float ObjectWidth;
    // Start is called before the first frame update
    void Start()
    {
        
      ObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    private float checkBoundsXworld()
    {
        Vector2 tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        return tempPos.x - ObjectWidth;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += _bomberSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -checkBoundsXworld())
        {
            _bomberSpeed = Mathf.Abs(_bomberSpeed);
            this.transform.Rotate(0, -180, 0);

        }
        else if (pos.x > checkBoundsXworld())
        {
            _bomberSpeed = -Mathf.Abs(_bomberSpeed);
            this.transform.Rotate(0, 180, 0);
        }
    }
}
