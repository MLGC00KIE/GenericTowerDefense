using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private GameObject gameMasterWithScoreObject;

    [SerializeField]
    private int ScoreToAdd = 50;


    private void Awake()
    {
        gameMasterWithScoreObject = GameObject.FindGameObjectWithTag("GAMEMASTER");
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col);
        if (col.gameObject.tag == "bullet")
        {
            gameMasterWithScoreObject.GetComponent<Score>().AddScore(ScoreToAdd);
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "end")
        {
            gameMasterWithScoreObject.GetComponent<Lives>().AddLives(-1);
            Destroy(this.gameObject);

        }
    }
}
