using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    [SerializeField]
    private Transform target;
    public float range = 15f;
    public float delayBetweenShots = 1f;

    public string enemyTag = "enemy";

    public bool isRotateAbleTurret = true;

    public Transform partToRotate = null;
    public float turnspeed = 10f;
    public Transform projectile = null;
    public Transform bulletStartLocation;

    private Vector3 rotation;

    private float timer = 0f;

    private void Start()
    {
        //InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
            return;

        if (isRotateAbleTurret)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;

            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        TryShoot();


        timer += Time.deltaTime;

    }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    public void Shoot()
    {
        Transform bullet = Instantiate(projectile);
        bullet.transform.position = bulletStartLocation.position;
        bullet.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        bullet.GetComponent<BulletMovement>().TargetObject = target;
    }





    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void TryShoot()
    {
        if (timer >= delayBetweenShots)
        {
            Shoot();
            timer = 0;
        } else
        {
            return;
        }
    }
}
