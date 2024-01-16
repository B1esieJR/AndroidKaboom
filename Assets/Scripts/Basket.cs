using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Basket : MonoBehaviour
{
    private Text _scoreGT;
    public Text Score { get => _scoreGT;
        set { _scoreGT = value; }
    }
    private void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        _scoreGT = scoreGo.GetComponent<Text>();
        Score.text = "0";
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition2D = Input.mousePosition;
        mousePosition2D.z = -Camera.main.transform.position.z;
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePosition3D.x;
        this.transform.position = pos;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Bomb")
        {
            Destroy(collidedWith);
        }
        int score = int.Parse(_scoreGT.text);
        score += 100;
        _scoreGT.text = score.ToString();
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
