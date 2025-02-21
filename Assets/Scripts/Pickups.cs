using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tocando gema");
        if (collision.tag == "Gem")
        {
            Scoring.totalScore++;
            scoreText.text = "PUNTUACIÓN: " + Scoring.totalScore;
            Debug.Log(Scoring.totalScore++);
            Destroy(collision.gameObject);
        }


    }



}
