using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    public float patrolSpeed = 3f;
    public float chaseSpeed = 5f;
    private int currentWaypoint = 0;
    public float detectionRange = 10f;
    public LayerMask detectionLayer;
    public float rotationSpeed = 5f;
    public bool playerDetected = false;
    private WeaponController weaponController;
    private EnemyShooting enemyShooting;

    void Start()
    {
        weaponController = GetComponent<WeaponController>();
        enemyShooting = GetComponent<EnemyShooting>();

        if (weaponController == null)
        {
            Debug.LogError("WeaponController not found on the enemy GameObject");
        }
        if (enemyShooting == null)
        {
            Debug.LogError("EnemyShooting not found on the enemy GameObject");
        }
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        playerDetected = CheckForPlayer(directionToPlayer);

        if (playerDetected)
        {
            // Rotate towards and move towards the player
            RotateTowardsPlayer(directionToPlayer);
            MoveTowardsPlayer();

            // Fire at the player
            if (Time.time >= enemyShooting.nextFireTime)
            {
                enemyShooting.ShootAtPlayer(player);
                enemyShooting.nextFireTime = Time.time + 1f / enemyShooting.fireRate;
            }
        }
        else
        {
            Patrol();
        }
    }

    private bool CheckForPlayer(Vector3 directionToPlayer)
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, detectionLayer))
            {
                return hit.transform == player;
            }
        }
        return false;
    }

    private void RotateTowardsPlayer(Vector3 directionToPlayer)
    {
        Vector3 direction = directionToPlayer.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveTowardsPlayer()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}
