using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTowerLv2 : Turret {

	// Use this for initialization
	void Start () {
        range = 15f;
        turnspeed = 10f;
        isRotateAbleTurret = true;


        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
	
}
