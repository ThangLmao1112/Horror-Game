using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Mục tiêu")]
    public Transform player;

    [Header("Cài đặt AI")]
    public float chaseSpeed = 5f;
    public float killDistance = 1.5f;

    [Header("Trạng thái")]
    public bool isActive = false;

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        
        if (!isActive || player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Nếu đến đủ gần → bắt người chơi!
        if (distanceToPlayer <= killDistance)
        {
            KillPlayer();
        }
        else
        {
            ChasePlayer();
        }
    }

    void KillPlayer()
    {
        agent.isStopped = true;

        // Quay mặt về phía người chơi
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;

        // Gọi Game Over
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
            isActive = false; // Dừng AI
        }

        Debug.Log("BẠN ĐÃ BỊ BẮT!");
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);

        // Cập nhật animation
        if (animator != null)
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);

            Debug.Log("Speed: " + speed); // Để debug
        }
    }

    public void ActivateEnemy()
    {
        isActive = true;
        gameObject.SetActive(true);

        if (player != null)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 30f;
            randomDirection.y = 0;
            Vector3 spawnPosition = player.position + randomDirection;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPosition, out hit, 10f, NavMesh.AllAreas))
            {
                transform.position = hit.position + Vector3.up * 1f;
            }
            else
            {
                transform.position = player.position + (player.forward * -20f) + Vector3.up * 1f;
            }
        }

        Debug.Log("SÁT NHÂN XUẤT HIỆN!");
    }
}