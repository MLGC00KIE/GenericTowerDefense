using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowers : MonoBehaviour {

    public Transform tower;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if (this.gameObject.GetComponent<Score>().GetScore() >= 100)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "TowerLocation")
                    {
                        Transform newTower = Instantiate(tower);
                        newTower.position = hit.transform.position;
                        Destroy(hit.transform.gameObject);
                        this.gameObject.GetComponent<Score>().AddScore(-100);

                    }
                }
            }

        }
    }
}
