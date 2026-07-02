using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("References")]
    public Animator anim;
    public Transform player;
    public Transform raycastOrigin;
    public DashAttack dashAttack;
    public ChaseAttack chaseAttack;
    public ShootFireballsAttack shootFireballs;
    public BossHealth bossHealth;

    [Header("Attack Toggles")]
    public bool dashAttackOn = false;
    public bool chaseAttackOn = false;
    public bool shootFireballsOn = false;
    public bool autoEnableAttacksIfNone = true;
    public bool useScriptedPhase1 = true;

    [Header("Attack Ranges & Durations")]
    public float dashFireComboRange = 10f;
    public float chaseAttackDuration = 3f;
    public float idleDuration = 1f;
    public float fireballAttackDuration = 3f;
    public int maxFireballShots = 3;
    public float postChaseMeleeDuration = 1.5f;
    public float waitAfterFireballsAtA = 1f;
    public float waitAfterFireballsAtB = 2f;

    [Header("Movement")]
    public bool moveToA = false;
    public bool moveToB = false;
    public Transform targetA;
    public Transform targetB;
    public Transform targetC;
    public float moveSpeed = 3f;
    public float sizeMultiplier = 1.5f;
    public float speedMultiplier = 1.15f; // 15% increase

    [Header("Layers")]
    public LayerMask obstacleLayerMask = ~0;
    public LayerMask playerLayer = 1;

    [Header("Gizmos")]
    public bool showDashRange = true;
    public bool showFireBreathRange = true;
    public bool showChaseRange = true;
    public bool showPlayerLine = true;

    private enum BossState1
    {
        Idle,
        DashFireCombo,
        ShootFireballs,
        ChaseAttack       
    }
    private BossState1 currentState = BossState1.Idle;
    public float stateTimer;
    private Vector3 originalScale;
    private int fireballShotsCount = 0;
    private float fireballAttackTimer = 0f;
    public float fireballShotInterval = 0.6f;
    public float phase2HealthPercent = 50f;

    private Rigidbody2D rb;
    private bool inPhase2 = false;
    private bool isExecutingSequence = false;
    private Coroutine sequenceCoroutine;
    private bool phase2DrinkCompleted = false;

    private void Start()
    {
        stateTimer = idleDuration;
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        if (anim == null) anim = GetComponent<Animator>() ?? GetComponentInChildren<Animator>();
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
        if (raycastOrigin == null) raycastOrigin = transform;
        if (autoEnableAttacksIfNone && !dashAttackOn && !chaseAttackOn && !shootFireballsOn)
        {
            dashAttackOn = true;
            chaseAttackOn = true;
            shootFireballsOn = true;
        }

        InitializeAttackComponents();
        if (bossHealth != null)
        {
            bossHealth.OnHealthPercentChanged += OnHealthPercentChanged;
            bossHealth.OnDied += OnBossDied;
        }
    }

    private void Update()
    {
        if (player != null && currentState != BossState1.DashFireCombo) FacePlayer();

        // Phase2: override all other behavior
        if (inPhase2)
        {
            if (chaseAttackOn && chaseAttack != null && !chaseAttack.IsPerformingChaseAttack)
            {
                TriggerChaseAttack();
            }
            return;
        }

        bool isDashAttacking = dashAttackOn && dashAttack != null && dashAttack.IsPerformingCombo;
        bool isChaseAttacking = chaseAttackOn && chaseAttack != null && chaseAttack.IsPerformingChaseAttack;
        if (isDashAttacking || isChaseAttacking) return;
        stateTimer -= Time.deltaTime;
        bool isMovingToTarget = (moveToA && targetA != null) || (moveToB && targetB != null);
        if (anim != null) anim.SetBool("isChasing", isMovingToTarget);

        // If player enters dash range start scripted sequence
        if (!isExecutingSequence && dashAttackOn && dashAttack != null && player != null)
        {
            float distToPlayer = GetDistanceToPlayer();
            if (distToPlayer <= dashFireComboRange)
            {
                sequenceCoroutine = StartCoroutine(Phase1DashSequence());
            }
        }

        switch (currentState)
        {
            case BossState1.Idle:
                if (moveToA && targetA != null)
                {
                    MoveAndJumpToPlatform(targetA.position, 8f, 1.5f);
                    FaceMoveDirection(targetA.position);
                }
                else if (moveToB && targetB != null)
                {
                    MoveAndJumpToPlatform(targetB.position, 8f, 1.5f);
                    FaceMoveDirection(targetB.position);
                }
                if (!useScriptedPhase1 && stateTimer <= 0f)
                {
                    ChooseAttackByPriority();
                }
                break;
            case BossState1.DashFireCombo:
                // Dash chỉ thực hiện 1 lần, khi xong sẽ gọi OnDashFireComboComplete để về Idle
                break;
            case BossState1.ChaseAttack:
                if (chaseAttack != null && chaseAttack.IsPerformingChaseAttack)
                {
                    float elapsedTime = chaseAttack.GetElapsedTime();
                    if (elapsedTime >= chaseAttackDuration)
                    {
                        chaseAttack.StopChaseAttack();
                        currentState = BossState1.Idle;
                        stateTimer = idleDuration;
                    }
                }
                else
                {
                    // Khi chase xong thì về Idle
                    currentState = BossState1.Idle;
                    stateTimer = idleDuration;
                }
                break;
            case BossState1.ShootFireballs:
                // Chỉ thực hiện 1 lần, sau đó về Idle
                if (fireballShotsCount < maxFireballShots)
                {
                    if (shootFireballs != null)
                    {
                        shootFireballs.ShootFireball();
                        fireballShotsCount++;
                    }
                }
                else
                {
                    currentState = BossState1.Idle;
                    stateTimer = idleDuration;
                }
                break;
        }
    }

    public float GetDistanceToPlayer()
    {
        return Vector3.Distance(raycastOrigin.position, player.position);
    }

    public bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - raycastOrigin.position).normalized;
        float distanceToPlayer = GetDistanceToPlayer();
        int obstacleOnlyMask = obstacleLayerMask & ~playerLayer;
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, directionToPlayer, out hit, distanceToPlayer, obstacleOnlyMask)) return false;
        return true;
    }

    public void FacePlayer()
    {
        if (player == null) return;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 scale = transform.localScale;
        if (directionToPlayer.x > 0) scale.x = Mathf.Abs(scale.x);
        else if (directionToPlayer.x < 0) scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    public void FaceMoveDirection(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 scale = transform.localScale;
        if (direction.x > 0) scale.x = Mathf.Abs(scale.x);
        else if (direction.x < 0) scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void ChooseAttackByDistance()
    {
        if (player == null) return;
        float distanceToPlayer = GetDistanceToPlayer();
        bool canSeePlayer = CanSeePlayer();
        if (canSeePlayer)
        {
            if (shootFireballsOn && shootFireballs != null)
            {
                TriggerShootFireballs();
                currentState = BossState1.ShootFireballs;
            }
            else if (distanceToPlayer <= dashFireComboRange && dashAttackOn && dashAttack != null && dashAttack.CanPerformDashAttack())
            {
                TriggerDashFireCombo();
                currentState = BossState1.DashFireCombo;
            }
            else if (chaseAttackOn && chaseAttack != null)
            {
                TriggerChaseAttack();
                currentState = BossState1.ChaseAttack;
            }
            else stateTimer = idleDuration;
        }
        else
        {
            if (chaseAttackOn && chaseAttack != null)
            {
                TriggerChaseAttack();
                currentState = BossState1.ChaseAttack;
            }
            else stateTimer = idleDuration;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (raycastOrigin == null) return;
        // Vẽ vùng dashFireComboRange
        if (showDashRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(raycastOrigin.position, dashFireComboRange);
        }

        // Vẽ vùng fire breath (dash combo)
        if (showFireBreathRange && dashAttack != null)
        {
            Gizmos.color = new Color(1f, 0.5f, 0f, 1f);
            Gizmos.DrawWireSphere(raycastOrigin.position, dashAttack.fireBreathRange);
        }

        // Vẽ vùng chaseAttack
        if (showChaseRange && chaseAttack != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(raycastOrigin.position, chaseAttack.meleeAttackRange);
        }

        // Vẽ đường thẳng tới player
        if (showPlayerLine && player != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(raycastOrigin.position, player.position);
            // Vẽ vị trí boss
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(raycastOrigin.position, 0.2f);
        }
    }

    // Chọn đòn tấn công theo thứ tự cố định cho BossState1
    private void ChooseAttackByPriority()
    {
        if (player == null) return;
        if (shootFireballsOn && shootFireballs != null)
        {
            TriggerShootFireballs();
            currentState = BossState1.ShootFireballs;
            return;
        }

        if (dashAttackOn && dashAttack != null && dashAttack.CanPerformDashAttack())
        {
            TriggerDashFireCombo();
            currentState = BossState1.DashFireCombo;
            return;
        }

        if (chaseAttackOn && chaseAttack != null)
        {
            TriggerChaseAttack();
            currentState = BossState1.ChaseAttack;
            return;
        }

        stateTimer = idleDuration;
    }

    public void TriggerShootFireballs()
    {
        if (!shootFireballsOn || shootFireballs == null) return;
        fireballShotsCount = 0;
        fireballAttackTimer = 0f;
        currentState = BossState1.ShootFireballs;
    }
    public void TriggerChaseAttack()
    {
        if (!chaseAttackOn) return;
        if (chaseAttack == null) EnsureChaseAttackInitialized();
        if (chaseAttack == null) return;
        currentState = BossState1.ChaseAttack;
        chaseAttack.StartChaseAttack(player);
    }
    public void SetChaseAttackDuration(float newDuration)
    {
        chaseAttackDuration = Mathf.Max(0.1f, newDuration);
    }
    public float GetChaseAttackDuration()
    {
        return chaseAttackDuration;
    }
    private void OnChaseAttackComplete()
    {
        currentState = BossState1.Idle;
        stateTimer = idleDuration;
    }
    public void TriggerDashFireCombo()
    {
        if (!dashAttackOn || dashAttack == null) return;
        currentState = BossState1.DashFireCombo;
        dashAttack.StartDashFireCombo(player);
    }
    
    private void OnHealthPercentChanged(float percent)
    {
        if (!inPhase2 && percent <= phase2HealthPercent)
        {
            if (chaseAttack != null && chaseAttack.IsPerformingChaseAttack)
            {
                chaseAttack.StopChaseAttack();
            }

            if (dashAttack != null && dashAttack.IsPerformingCombo)
            {
                dashAttack.StopCombo();
            }

            StopFireballLoop();
            StartCoroutine(EnterPhase2());
        }
    }

    private IEnumerator EnterPhase2()
    {
        inPhase2 = true;
        isExecutingSequence = false;
        phase2DrinkCompleted = false;
        if (sequenceCoroutine != null) StopCoroutine(sequenceCoroutine);
        StopFireballLoop();
        if (dashAttack != null && dashAttack.IsPerformingCombo)
        {
            dashAttack.StopCombo();
        }
        if (chaseAttack != null)
        {
            chaseAttack.StopChaseAttack();
            chaseAttack.enabled = false;
        }
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        // Become invulnerable while drinking
        if (bossHealth != null) bossHealth.SetInvulnerable(true);
        // Teleport to C
        if (targetC != null)
        {
            transform.position = targetC.position;
        }
        if (anim != null)
        {
            anim.Play("idle", 0, 0f);
            anim.SetBool("isChasing", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isShooting", false);
        }

        yield return new WaitForSeconds(2f);

        if (anim != null)
        {
            anim.ResetTrigger("drink");
            anim.Play("drink_potion", 0, 0f);
        }
        float elapsed = 0f;
        const float fallbackDuration = 3f;
        while (!phase2DrinkCompleted && elapsed < fallbackDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        if (!phase2DrinkCompleted)
        {
            CompletePhase2Drink();
        }
        yield break;
    }

    private void EnsureChaseAttackInitialized()
    {
        if (chaseAttack == null)
        {
            chaseAttack = GetComponent<ChaseAttack>() ?? gameObject.AddComponent<ChaseAttack>();
        }

        if (chaseAttack == null) return;

        if (!chaseAttack.enabled)
        {
            chaseAttack.enabled = true;
        }

        chaseAttack.anim = anim;
        chaseAttack.player = player;
        chaseAttack.raycastOrigin = raycastOrigin;
        chaseAttack.OnChaseAttackComplete -= OnChaseAttackComplete;
        chaseAttack.OnChaseAttackComplete += OnChaseAttackComplete;
    }

    private void InitializeAttackComponents()
    {
        if (dashAttackOn)
        {
            if (dashAttack == null)
            {
                dashAttack = GetComponent<DashAttack>() ?? gameObject.AddComponent<DashAttack>();
            }

            if (dashAttack != null)
            {
                dashAttack.anim = anim;
                dashAttack.player = player;
                dashAttack.fireBreathRange = 4f;
                dashAttack.raycastOrigin = raycastOrigin;
                dashAttack.obstacleLayerMask = obstacleLayerMask;
                dashAttack.playerLayer = playerLayer;
                dashAttack.OnComboComplete -= OnDashFireComboComplete;
                dashAttack.OnComboComplete += OnDashFireComboComplete;
            }
        }

        if (chaseAttackOn)
        {
            EnsureChaseAttackInitialized();
        }

        if (shootFireballsOn)
        {
            if (shootFireballs == null)
            {
                shootFireballs = GetComponent<ShootFireballsAttack>() ?? gameObject.AddComponent<ShootFireballsAttack>();
            }

            if (shootFireballs != null)
            {
                shootFireballs.anim = anim;
                shootFireballs.player = player;
                if (shootFireballs.firePoint == null)
                {
                    shootFireballs.firePoint = raycastOrigin != null ? raycastOrigin : transform;
                }
            }
        }
    }

    public void CompletePhase2Drink()
    {
        if (phase2DrinkCompleted) return;

        phase2DrinkCompleted = true;

        if (bossHealth != null) bossHealth.SetInvulnerable(false);

        // Buff size and speed once the drink animation finishes.
        transform.localScale = new Vector3(originalScale.x * sizeMultiplier, originalScale.y * sizeMultiplier, originalScale.z);
        moveSpeed *= speedMultiplier;

        // Phase 2 uses chase only.
        dashAttackOn = false;
        shootFireballsOn = false;
        chaseAttackOn = true;
        EnsureChaseAttackInitialized();

        currentState = BossState1.Idle;
        stateTimer = idleDuration;

        if (anim != null)
        {
            anim.Play("idle", 0, 0f);
            anim.SetBool("isChasing", true);
            anim.SetBool("isAttacking", false);
        }

        if (chaseAttack != null && player != null)
        {
            chaseAttack.StartChaseAttack(player);
            currentState = BossState1.ChaseAttack;
        }
    }

    private IEnumerator Phase1DashSequence()
    {
        isExecutingSequence = true;
        StopFireballLoop();
        // Trigger dash+fire
        TriggerDashFireCombo();
        // wait until dash combo finishes
        yield return new WaitUntil(() => dashAttack == null || !dashAttack.IsPerformingCombo);

        // Teleport to A then B and shoot fireballs at each point
        if (shootFireballsOn && shootFireballs != null)
        {
            if (targetA != null || targetB != null)
            {
                yield return StartCoroutine(ShootFireballsFromTargets());
            }
            else
            {
                yield return StartCoroutine(ShootFireballsBurst());
            }
        }

        // Start chase attack for chaseAttackDuration
        if (chaseAttackOn && chaseAttack != null)
        {
            StopFireballLoop();
            TriggerChaseAttack();
            yield return new WaitForSeconds(chaseAttackDuration);
            if (chaseAttack != null) chaseAttack.StopChaseAttack();
        }

        // After chase: decide next action based on distance
        float dist = (player != null) ? GetDistanceToPlayer() : float.MaxValue;
        if (player != null && dist > dashFireComboRange && dashAttackOn && dashAttack != null && dashAttack.CanPerformDashAttack())
        {
            // Player far: dash + fire
            TriggerDashFireCombo();
        }
        else if (player != null && chaseAttackOn && chaseAttack != null)
        {
            float meleeRange = chaseAttack.meleeAttackRange;
            if (dist <= meleeRange)
            {
                // Player close: short melee chase
                StopFireballLoop();
                TriggerChaseAttack();
                yield return new WaitForSeconds(postChaseMeleeDuration);
                if (chaseAttack != null) chaseAttack.StopChaseAttack();
            }
            else if (shootFireballsOn && shootFireballs != null)
            {
                // Player near: teleport to A then B and shoot
                yield return StartCoroutine(ShootFireballsFromTargets());
            }
        }

        isExecutingSequence = false;
        yield break;
    }

    private void TeleportToTarget(Transform target)
    {
        if (target == null) return;
        transform.position = target.position;
        FaceMoveDirection(target.position);
    }

    private IEnumerator ShootFireballsFromTargets()
    {
        if (!shootFireballsOn || shootFireballs == null) yield break;

        if (targetA != null)
        {
            TeleportToTarget(targetA);
            yield return StartCoroutine(ShootFireballsBurst());
            if (waitAfterFireballsAtA > 0f)
            {
                yield return new WaitForSeconds(waitAfterFireballsAtA);
            }
        }

        if (targetB != null)
        {
            TeleportToTarget(targetB);
            yield return StartCoroutine(ShootFireballsBurst());
            if (waitAfterFireballsAtB > 0f)
            {
                yield return new WaitForSeconds(waitAfterFireballsAtB);
            }
        }
    }

    private IEnumerator ShootFireballsBurst()
    {
        if (!shootFireballsOn || shootFireballs == null) yield break;
        shootFireballs.SetEventFireEnabled(true);
        for (int i = 0; i < maxFireballShots; i++)
        {
            shootFireballs.ShootFireball();
            yield return new WaitForSeconds(fireballShotInterval);
        }

        shootFireballs.StopShooting();
        shootFireballs.SetEventFireEnabled(false);
    }

    private void StopFireballLoop()
    {
        if (shootFireballs == null) return;
        shootFireballs.SetEventFireEnabled(false);
        shootFireballs.StopShooting();
    }
    private void OnDashFireComboComplete()
    {
        currentState = BossState1.Idle;
        stateTimer = idleDuration;
    }
    private void OnDestroy()
    {
        if (dashAttackOn && dashAttack != null) dashAttack.OnComboComplete -= OnDashFireComboComplete;
        if (chaseAttackOn && chaseAttack != null) chaseAttack.OnChaseAttackComplete -= OnChaseAttackComplete;
        if (bossHealth != null)
        {
            bossHealth.OnHealthPercentChanged -= OnHealthPercentChanged;
            bossHealth.OnDied -= OnBossDied;
        }
    }

    private void OnBossDied()
    {
        StopFireballLoop();
        if (dashAttack != null && dashAttack.IsPerformingCombo)
        {
            dashAttack.StopCombo();
        }

        if (chaseAttack != null)
        {
            chaseAttack.StopChaseAttack();
            chaseAttack.enabled = false;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        enabled = false;
    }

    public void MoveAndJumpToPlatform(Vector3 targetPosition, float jumpForce, float moveDistance)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float horizontalDistance = Mathf.Abs(targetPosition.x - transform.position.x);
        float verticalDistance = targetPosition.y - transform.position.y;
        // Nếu chưa gần vị trí nhảy, di chuyển lại gần
        if (horizontalDistance > moveDistance)
        {
            Vector3 moveTarget = transform.position + new Vector3(Mathf.Sign(targetPosition.x - transform.position.x) * moveDistance, 0, 0);
            if (rb != null)
            {
                Vector3 newPos = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed * Time.deltaTime);
                rb.MovePosition(newPos);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed * Time.deltaTime);
            }
        }
        // Nếu đã gần vị trí nhảy hoặc đang ở dưới platform, thực hiện nhảy thẳng tới vị trí
        else if (rb != null && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            Vector2 jumpDir = (targetPosition - transform.position).normalized;
            // Tính lực nhảy để boss bay thẳng tới vị trí platform
            float jumpX = (targetPosition.x - transform.position.x);
            float jumpY = Mathf.Max(1f, verticalDistance);
            rb.AddForce(new Vector2(jumpX, jumpY) * jumpForce, ForceMode2D.Impulse);
        }
    }
}
