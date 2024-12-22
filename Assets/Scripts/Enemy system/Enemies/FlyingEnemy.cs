using System.Collections;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float retreatDistance = 5f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int damage = 10;

    private GameObject player;
    private bool canAttack = true;
    private bool isRetreating = false;
    private Vector3 retreatTarget;

    private float fixedHeight;

    private void OnEnable()
    {
        FindPlayer();
        fixedHeight = transform.position.y;
        StartCoroutine(EnemyBehaviorLoop());
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    private IEnumerator EnemyBehaviorLoop()
    {
        while (true)
        {
            if (player == null) yield break;

            yield return StartCoroutine(MoveTowardsPlayer());

            if (canAttack)
            {
                AttackPlayer();
                yield return new WaitForSeconds(attackCooldown);
            }

            yield return StartCoroutine(RetreatFromPlayer());

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        while (Vector3.Distance(transform.position, player.transform.position) > attackDistance)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction.y = 0;
            transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void AttackPlayer()
    {
        //Attack Logic

        Debug.Log("Attacking player!");
    }

    private IEnumerator RetreatFromPlayer()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 randomOffset = new Vector3(randomDirection.x, 0, randomDirection.y) * retreatDistance;
        retreatTarget = transform.position + randomOffset;
        retreatTarget.y = fixedHeight;

        isRetreating = true;

        while (Vector3.Distance(transform.position, retreatTarget) > 0.1f)
        {
            Vector3 direction = (retreatTarget - transform.position).normalized;
            direction.y = 0;
            transform.position += direction * moveSpeed * Time.deltaTime;
            yield return null;
        }

        isRetreating = false;
        Debug.Log("Finished retreating.");
    }
}
