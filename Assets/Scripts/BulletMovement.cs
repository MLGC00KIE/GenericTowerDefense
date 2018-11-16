using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    [SerializeField]
    private float speed;

    public Transform TargetObject;

	// Update is called once per frame
	void Update () {
        transform.LookAt(TargetObject);
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void Awake()
    {
        Destroy(this.gameObject, 2f);
    }
}
