using UnityEngine;

public class BossAnimationEvents : MonoBehaviour
{
    private BossController bossController;
    private BossHealth bossHealth;
    private DashAttack dashAttack;
    private ChaseAttack chaseAttack;
    private ShootFireballsAttack shootFireballsAttack;
    

    private void Awake()
    {
        bossController = GetComponentInParent<BossController>();
        bossHealth = GetComponentInParent<BossHealth>();
        dashAttack = GetComponentInParent<DashAttack>();
        chaseAttack = GetComponentInParent<ChaseAttack>();
        shootFireballsAttack = GetComponentInParent<ShootFireballsAttack>();
    }

    // Animation Event: Được gọi khi melee attack animation kết thúc (cho ChaseAttack)
    public void EndMeleeAttack()
    {
        if (chaseAttack != null)
        {
            chaseAttack.EndMeleeAttack();
            Debug.Log("Animation Event: Melee Attack kết thúc!");
        }
    }


    // Animation Event: Được gọi khi prepare dash animation hoàn thành và sẵn sàng bắt đầu dash
    public void StartDash()
    {
        // Chỉ cần để trống vì DashAttack sẽ tự xử lý dash movement
        // Animation event này có thể được sử dụng để trigger effects hoặc sounds
        Debug.Log("Animation Event: Dash bắt đầu!");
    }

    // Animation Event: Được gọi khi boss bắt đầu uống thuốc
    public void StartDrinkPotion()
    {
        Debug.Log("Animation Event: Boss bắt đầu uống thuốc!");
    }

    // Animation Event: Được gọi khi boss uống thuốc xong
    public void EndDrinkPotion()
    {
        if (bossController != null)
        {
            bossController.CompletePhase2Drink();
            Debug.Log("Animation Event: Boss uống thuốc xong!");
        }
    }

    // Animation Event: Được gọi khi fire breath animation hoàn thành
    public void EndFireBreath()
    {
        // Gây sát thương lên player khi animation fire breath kết thúc
        DealDamageToPlayer();
        Debug.Log("Animation Event: Fire breath kết thúc!");
    }
    // Hàm gây sát thương lên player
    public void DealDamageToPlayer()
    {
        if (dashAttack != null && dashAttack.player != null)
        {
            PlayerHealth playerHealth = dashAttack.player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Số damage boss gây ra, có thể chỉnh sửa
                Debug.Log("Boss gây sát thương lên player!");
            }
        }
    }

    public void ShootFireball()
    {
        ShootFireballsAttack shootFireballs = GetComponentInParent<ShootFireballsAttack>();
        if (shootFireballs != null)
        {
            shootFireballs.ShootFireballFromEvent();
            Debug.Log("Animation Event: Boss bắn fireball!");
        }
        else
        {
            Debug.LogWarning("ShootFireballsAttack component không tìm thấy!");
        }
    }

    // Animation Event: Được gọi khi animation bắn fireball kết thúc
    public void EndShootFireball()
    {
        if (shootFireballsAttack != null)
        {
            shootFireballsAttack.StopShooting();
            Debug.Log("Animation Event: Boss dừng bắn fireball!");
        }
        else
        {
            Debug.LogWarning("ShootFireballsAttack component không tìm thấy!");
        }
    }

    // Animation Event: Được gọi khi animation chết kết thúc
    public void EndDieAnimation()
    {
        if (bossHealth != null)
        {
            bossHealth.DieAnimation();
            Debug.Log("Animation Event: Boss chết hoàn tất!");
        }
        else
        {
            Debug.LogWarning("BossHealth component không tìm thấy!");
        }
    }
}
