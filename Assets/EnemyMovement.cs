using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float nextWaypointDistanceThreshold = 0.1f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 directionToWaypoint = target.position - transform.position;

        transform.Translate(directionToWaypoint.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= nextWaypointDistanceThreshold)
        {
            nextWaypoint();
        }
    }

    private void nextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
