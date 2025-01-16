using System.Threading;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float count, timeRange, countAnimation, attackfunction, timeRangeAnimation;
    public GameObject bullet;
    public Transform player, bulletSpawnPoint;

    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        count += Time.deltaTime;

        if (count >= timeRange)
        {
            enemyAnimator.SetBool("IsAttacking", true);
            Disparar();
            count = 0;
        }

    }

    void Disparar()
    {
        GameObject balaNueva = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        balaNueva.transform.LookAt(player.position);
    }
}
