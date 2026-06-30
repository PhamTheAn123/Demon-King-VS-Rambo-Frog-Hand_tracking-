# Hướng Dẫn Vẽ Sơ Đồ Tuần Tự (Sequence Diagram)

Tài liệu này hướng dẫn cách vẽ sơ đồ tuần tự (Sequence Diagram) theo chuẩn UML cho dự án game **Demon King vs Rambo Frog** (Hand Tracking). Sơ đồ tuần tự thể hiện **thứ tự tương tác theo thời gian** giữa các đối tượng trong một kịch bản (use case) cụ thể.

---

## 1. Kiến Thức Cơ Bản Về Sequence Diagram

### 1.1. Sequence Diagram là gì?

Sequence Diagram (Sơ đồ tuần tự) là một loại sơ đồ tương tác trong UML, mô tả:

*   **Các đối tượng (Objects/Actors)** tham gia vào một kịch bản.
*   **Thứ tự các thông điệp (Messages)** được gửi giữa các đối tượng theo **trục thời gian dọc** (từ trên xuống).
*   **Thời gian sống (Lifeline)** và **khoảng hoạt động (Activation Bar)** của mỗi đối tượng.

### 1.2. Các Thành Phần Chính

```
   Tác nhân        :Đối tượng A          :Đối tượng B          :Đối tượng C
   (Actor)         ┌──────────┐          ┌──────────┐          ┌──────────┐
      ○            │  Tên A   │          │  Tên B   │          │  Tên C   │
     /|\           └────┬─────┘          └────┬─────┘          └────┬─────┘
     / \                │                     │                     │
      │                 │───── Thông điệp ───>│                     │
      │                 │                     │── Thông điệp ──────>│
      │                 │                     │<── Phản hồi ────────│
      │                 │<──── Phản hồi ──────│                     │
      │                 │                     │                     │
```

### 1.3. Ký Hiệu UML Trong Sequence Diagram

| Ký hiệu                  | Tên gọi                | Mô tả                                                                |
|---------------------------|------------------------|-----------------------------------------------------------------------|
| `──────────>`             | Synchronous Message     | Thông điệp đồng bộ (lời gọi hàm, chờ phản hồi)                     |
| `- - - - - ->`            | Asynchronous Message    | Thông điệp bất đồng bộ (gửi đi không chờ phản hồi)                 |
| `<─ ─ ─ ─ ─ ─`           | Return Message          | Thông điệp phản hồi / giá trị trả về (đường đứt nét)                |
| `──────────>│`            | Self-call               | Đối tượng gọi chính nó                                               |
| `█` (thanh dọc trên lifeline) | Activation Bar      | Khoảng thời gian đối tượng đang xử lý (đang thực thi)               |
| `│` (đường dọc đứt nét)  | Lifeline               | Đường sống của đối tượng theo trục thời gian                         |
| `[điều kiện]`             | Guard / Condition       | Điều kiện để thông điệp được gửi (đặt trong ngoặc vuông)            |
| `X`                       | Object Destruction      | Đối tượng bị hủy                                                     |
| `╔══ alt ══╗`             | Alt Fragment            | Khối rẽ nhánh (if/else)                                              |
| `╔══ loop ═╗`             | Loop Fragment           | Khối lặp (while/for)                                                 |
| `╔══ opt ══╗`             | Opt Fragment            | Khối tùy chọn (chỉ thực hiện nếu điều kiện đúng)                    |

---

## 2. Các Kịch Bản Sequence Diagram Quan Trọng

Dưới đây là các kịch bản (use case) chính trong dự án, kèm mã Mermaid hoàn chỉnh:

---

### 2.1. Kịch bản 1: Người Chơi Bắn Súng (Player Shoots)

**Mô tả**: Người chơi thực hiện hành động bắn súng, từ lúc nhận input đến khi đạn va chạm với kẻ địch.

```mermaid
sequenceDiagram
    actor Player as Người chơi

    participant HIP as HandInputProvider
    participant PC as PlayerController
    participant GC as GunController
    participant B as Bullet
    participant BUI as BulletUI
    participant GE as GroundEnemy

    Player ->> HIP: Cử chỉ tay (ngón cái chạm ngón trỏ)
    activate HIP
    HIP ->> HIP: UpdateRightHandAim()
    Note right of HIP: Tính khoảng cách<br/>ngón cái ↔ ngón trỏ<br/>< 0.06f → ShootHeld = true
    HIP -->> PC: ShootHeld = true, AimScreenPos
    deactivate HIP

    activate PC
    PC ->> PC: UpdateInputs()
    Note right of PC: inputShootHeld = true
    PC ->> PC: Kiểm tra Time.time >= nextShootTime

    alt Đạn còn & hết Cooldown
        PC ->> GC: Shoot()
        activate GC
        GC ->> GC: Kiểm tra currentClip > 0

        alt currentClip > 0
            GC ->> GC: Phát âm thanh (shootSound.Play)
            GC ->> B: Instantiate(bullet, shootPoint)
            activate B
            GC ->> B: AddForce(direction * bulletSpeed)
            GC ->> GC: gunAnimator.SetTrigger("shoot")
            GC ->> GC: currentClip--
            GC ->> BUI: UpdateBullets(currentClip)
            activate BUI
            BUI ->> BUI: Cập nhật icon đạn (full/empty)
            BUI -->> GC: 
            deactivate BUI

            alt currentClip == 0 && currentAmmo > 0
                GC ->> GC: StartCoroutine(ReloadCoroutine)
                Note right of GC: Chờ 1.5 giây → FinishReload()
            end

            GC -->> PC: 
            deactivate GC
        end

        B ->> GE: OnTriggerEnter2D(collision)
        Note right of B: Va chạm kẻ địch
        B ->> GE: TakeDamage(bulletDamage)
        activate GE
        GE ->> GE: currentHealth -= damage
        GE ->> GE: StartCoroutine(Flash)

        alt currentHealth <= 0
            GE ->> GE: Die()
            GE ->> GE: anim.SetTrigger("die")
        end
        deactivate GE
        B ->> B: Destroy(gameObject)
        deactivate B
    end
    deactivate PC
```

---

### 2.2. Kịch bản 2: Người Chơi Di Chuyển & Nhảy (Player Movement & Jump)

**Mô tả**: Luồng xử lý input di chuyển và nhảy (hỗ trợ nhảy kép) từ Hand Tracking.

```mermaid
sequenceDiagram
    actor Player as Người chơi

    participant HIP as HandInputProvider
    participant PC as PlayerController
    participant RB as Rigidbody2D
    participant Anim as Animator

    Player ->> HIP: Xòe ngón tay trước camera
    activate HIP
    HIP ->> HIP: UpdateMovementFromHand()
    HIP ->> HIP: CountExtendedFingers()
    Note right of HIP: 1 ngón → MoveX = -1 (trái)<br/>2+ ngón → MoveX = +1 (phải)
    HIP ->> HIP: UpdateLeftHandGestures()
    Note right of HIP: 4+ ngón → JumpDown = true
    HIP -->> PC: MoveX, JumpDown, JumpHeld, JumpUp
    deactivate HIP

    activate PC
    PC ->> PC: UpdateInputs()
    PC ->> PC: CheckEnvironment()
    Note right of PC: isGrounded = OverlapCircle(...)<br/>canDoubleJump = true (nếu trên đất)

    PC ->> PC: HandleMovementInput()
    Note right of PC: currentSpeed = MoveTowards(target)

    PC ->> PC: HandleJumpInput()

    alt inputJumpDown == true
        alt isGrounded == true
            PC ->> RB: linearVelocity = (x, jumpForce)
            activate RB
            Note right of RB: Nhảy thường
            RB -->> PC: 
            deactivate RB
        else !isGrounded && canDoubleJump
            PC ->> RB: linearVelocity = (x, jumpForce)
            activate RB
            Note right of RB: Nhảy kép
            RB -->> PC: 
            deactivate RB
            PC ->> PC: canDoubleJump = false
            PC ->> PC: smokeFX.Play()
        end
    end

    PC ->> PC: UpdateAnimations()
    PC ->> Anim: SetBool("isJumping", !isGrounded)
    activate Anim
    PC ->> Anim: SetBool("isRunning", moving && grounded)
    PC ->> Anim: SetFloat("verticalSpeed", rb.velocity.y)
    Anim -->> PC: 
    deactivate Anim

    Note over PC, RB: FixedUpdate()
    PC ->> RB: linearVelocity = (currentSpeed, y)
    activate RB
    RB -->> PC: 
    deactivate RB
    deactivate PC
```

---

### 2.3. Kịch bản 3: Boss Tấn Công Dash + Phun Lửa (Dash-Fire Combo)

**Mô tả**: Boss thực hiện combo Dash lướt nhanh về phía người chơi rồi phun lửa.

```mermaid
sequenceDiagram
    participant BC as BossController
    participant DA as DashAttack
    participant Anim as Animator
    participant PH as PlayerHealth
    participant BAE as BossAnimationEvents
    participant PHUI as PlayerHealthUI

    Note over BC: stateTimer <= 0 → ChooseRandomAttack()
    BC ->> BC: ChooseRandomAttack()
    activate BC
    Note right of BC: Random chọn DashFireCombo
    BC ->> BC: currentState = DashFireCombo
    BC ->> DA: StartDashFireCombo(player)
    deactivate BC

    activate DA
    DA ->> DA: isPerformingCombo = true
    DA ->> DA: DashFireComboCoroutine()

    alt Player trong tầm phun lửa
        DA ->> DA: PerformFireBreath()
        DA ->> Anim: SetTrigger("fireBreath")
        activate Anim
        Anim -->> DA: 
        deactivate Anim
        Note right of DA: Chờ 1.5 giây
        DA ->> DA: CompleteCombo()
    else Player ngoài tầm phun lửa
        DA ->> Anim: SetBool("isPreparingDash", true)
        activate Anim
        DA ->> Anim: SetTrigger("prepareDash")
        Anim -->> DA: 
        deactivate Anim
        Note right of DA: Chờ 0.3 giây chuẩn bị

        DA ->> DA: PerformDash()
        DA ->> Anim: SetBool("isDashing", true)
        activate Anim
        DA ->> Anim: SetTrigger("dash")
        Anim -->> DA: 
        deactivate Anim

        loop Trong thời gian dashDuration
            DA ->> DA: Lerp vị trí từ start → target
            DA ->> DA: FaceDirection(dashDirection)
        end

        DA ->> Anim: SetBool("isDashing", false)
        Note right of DA: Chờ fireBreathDelay (0.2s)

        DA ->> DA: PerformFireBreath()
        DA ->> Anim: SetTrigger("fireBreath")
        activate Anim
        Anim ->> BAE: EndFireBreath() [Animation Event]
        activate BAE
        BAE ->> BAE: DealDamageToPlayer()
        BAE ->> PH: TakeDamage(1)
        activate PH
        PH ->> PH: currentHealth -= 1
        PH ->> PHUI: UpdateHeart(currentHealth)
        activate PHUI
        PHUI -->> PH: 
        deactivate PHUI
        PH ->> PH: StartCoroutine(FlashRed)

        alt currentHealth <= 0
            PH ->> PH: Die()
        end
        PH -->> BAE: 
        deactivate PH
        BAE -->> Anim: 
        deactivate BAE
        Anim -->> DA: 
        deactivate Anim

        DA ->> DA: CompleteCombo()
    end

    DA -->> BC: OnComboComplete?.Invoke()
    deactivate DA

    activate BC
    BC ->> BC: currentState = Idle
    BC ->> BC: stateTimer = idleDuration
    deactivate BC
```

---

### 2.4. Kịch bản 4: Boss Đuổi & Tấn Công Cận Chiến (Chase Attack)

**Mô tả**: Boss đuổi theo người chơi và thực hiện tấn công cận chiến khi đến gần.

```mermaid
sequenceDiagram
    participant BC as BossController
    participant CA as ChaseAttack
    participant Anim as Animator
    participant BAE as BossAnimationEvents
    participant PH as PlayerHealth

    BC ->> BC: ChooseRandomAttack()
    activate BC
    Note right of BC: Random chọn ChaseAttack
    BC ->> CA: TriggerChaseAttack()
    BC ->> CA: StartChaseAttack(player)
    deactivate BC

    activate CA
    CA ->> CA: isPerformingChaseAttack = true
    CA ->> CA: chaseStartTime = Time.time

    loop Mỗi frame Update()
        CA ->> BC: GetDistanceToPlayer()
        activate BC
        BC -->> CA: distanceToPlayer
        deactivate BC

        alt distanceToPlayer > meleeAttackRange
            CA ->> CA: ChasePlayer()
            Note right of CA: Di chuyển về phía player<br/>với tốc độ chaseSpeed
            CA ->> Anim: SetBool("isChasing", true)
        else distanceToPlayer <= meleeAttackRange
            alt Hết cooldown tấn công
                CA ->> CA: PerformMeleeAttack()
                CA ->> Anim: SetBool("isAttacking", true)
                activate Anim
                CA ->> Anim: SetTrigger("attack")

                Anim ->> BAE: EndMeleeAttack() [Animation Event]
                activate BAE
                BAE ->> CA: EndMeleeAttack()
                CA ->> CA: isAttacking = false
                CA ->> Anim: SetBool("isAttacking", false)
                BAE -->> Anim: 
                deactivate BAE
                Anim -->> CA: 
                deactivate Anim
            end
        end
    end

    Note over BC, CA: Khi elapsedTime >= chaseAttackDuration
    BC ->> CA: StopChaseAttack()
    CA ->> CA: isPerformingChaseAttack = false
    CA ->> Anim: SetBool("isChasing", false)
    CA -->> BC: OnChaseAttackComplete?.Invoke()
    deactivate CA

    activate BC
    BC ->> BC: currentState = Idle
    BC ->> BC: stateTimer = idleDuration
    deactivate BC
```

---

### 2.5. Kịch bản 5: Nhặt Vật Phẩm (Item Pickup)

**Mô tả**: Người chơi va chạm với hộp đạn hoặc vật phẩm hồi máu.

```mermaid
sequenceDiagram
    actor Player as Người chơi
    participant AP as AmmoPickup
    participant GC as GunController
    participant BUI as BulletUI
    participant HI as HealthItem
    participant PH as PlayerHealth
    participant PHUI as PlayerHealthUI

    Note over Player, AP: === Nhặt Hộp Đạn ===
    Player ->> AP: OnTriggerEnter2D(collision)
    activate AP
    AP ->> GC: AddAmmo(ammoAmount)
    activate GC
    GC ->> GC: currentAmmo += ammoAmount
    GC ->> GC: Clamp currentAmmo <= maxAmmo

    alt currentClip == 0 && currentAmmo > 0
        GC ->> GC: StartCoroutine(ReloadCoroutine)
        Note right of GC: Chờ 1.5s → FinishReload()
        GC ->> GC: FinishReload()
        GC ->> GC: currentClip += reloadAmount
        GC ->> GC: currentAmmo -= reloadAmount
    end

    GC ->> BUI: UpdateBullets(currentClip)
    activate BUI
    BUI -->> GC: 
    deactivate BUI
    GC -->> AP: 
    deactivate GC
    AP ->> AP: Destroy(gameObject)
    deactivate AP

    Note over Player, HI: === Nhặt Vật Phẩm Hồi Máu ===
    Player ->> HI: OnTriggerEnter2D(collision)
    activate HI
    HI ->> HI: Kiểm tra Tag == "Player"
    HI ->> PH: Heal(healAmount)
    activate PH
    PH ->> PH: currentHealth += healAmount
    PH ->> PH: Clamp currentHealth <= maxHealth
    PH ->> PHUI: UpdateHeart(currentHealth)
    activate PHUI
    PHUI -->> PH: 
    deactivate PHUI
    PH -->> HI: 
    deactivate PH
    HI ->> HI: Destroy(gameObject)
    deactivate HI
```

---

### 2.6. Kịch bản 6: Người Chơi Chết & Hiển Thị UI (Player Death)

**Mô tả**: Luồng xử lý khi người chơi chết do bị kẻ địch tấn công hoặc rơi vào bẫy.

```mermaid
sequenceDiagram
    participant GE as GroundEnemy
    participant PH as PlayerHealth
    participant PHUI as PlayerHealthUI
    participant DUI as DeadUI
    participant SM as SceneManager

    Note over GE, PH: Kẻ địch tấn công người chơi
    GE ->> PH: OnTriggerEnter2D("EnemyAttack")
    activate PH
    PH ->> PH: TakeDamage(enemy.damage)
    PH ->> PH: currentHealth -= damage
    PH ->> PHUI: UpdateHeart(currentHealth)
    activate PHUI
    PHUI ->> PHUI: Chuyển heart sprites sang emptyHeart
    PHUI -->> PH: 
    deactivate PHUI
    PH ->> PH: StartCoroutine(FlashRed)
    Note right of PH: Nhấp nháy đỏ 0.1s

    alt currentHealth <= 0
        PH ->> PH: Die()
        PH ->> DUI: FindObjectOfType<DeadUI>()
        activate DUI
        PH ->> DUI: ShowDeadPanel()
        DUI ->> DUI: deadPanel.SetActive(true)
        DUI ->> DUI: Time.timeScale = 0
        DUI ->> DUI: deathMessageText = "You are Dead!"
        Note right of DUI: Game bị tạm dừng hoàn toàn

        alt Người chơi bấm Restart
            DUI ->> SM: LoadScene("Lever-1")
            DUI ->> DUI: Time.timeScale = 1
        else Người chơi bấm Main Menu
            DUI ->> SM: LoadScene("MainMenu")
            DUI ->> DUI: Time.timeScale = 1
        else Người chơi bấm Quit
            DUI ->> DUI: Application.Quit()
        end
        deactivate DUI
    end
    deactivate PH
```

---

### 2.7. Kịch bản 7: Enemy Mặt Đất Phát Hiện & Tấn Công (GroundEnemy AI)

**Mô tả**: Luồng xử lý AI khi kẻ địch mặt đất phát hiện và tấn công người chơi.

```mermaid
sequenceDiagram
    actor Player as Người chơi
    participant TAC as TriggerAreaCheck
    participant GE as GroundEnemy
    participant HZC as HotZoneCheck
    participant PH as PlayerHealth
    participant Anim as Animator

    Note over Player, TAC: Player bước vào TriggerZone
    Player ->> TAC: OnTriggerEnter2D(collision)
    activate TAC
    TAC ->> TAC: gameObject.SetActive(false)
    TAC ->> GE: target = player.transform
    TAC ->> GE: inRange = true
    TAC ->> GE: hotZone.SetActive(true)
    deactivate TAC

    activate GE
    GE ->> GE: EnemyLogic()
    GE ->> GE: distance = Vector2.Distance(pos, target)

    loop Mỗi frame (khi inRange == true)
        alt distance > attackDistance
            GE ->> GE: StopAttack()
            GE ->> GE: Move()
            GE ->> Anim: SetBool("canWalk", true)
            Note right of GE: Di chuyển về phía player
        else distance <= attackDistance && !cooling
            GE ->> GE: Attack()
            GE ->> Anim: SetBool("canWalk", false)
            activate Anim
            GE ->> Anim: SetBool("Attack", true)
            Note right of Anim: Phát animation tấn công

            Anim ->> GE: DealDamageToPlayer() [Animation Event]
            GE ->> PH: TakeDamage(damage)
            activate PH
            PH ->> PH: currentHealth -= damage
            PH -->> GE: 
            deactivate PH

            Anim ->> GE: TriggerCooling() [Animation Event]
            GE ->> GE: cooling = true
            Anim -->> GE: 
            deactivate Anim

            GE ->> GE: Cooldown()
            Note right of GE: timer -= deltaTime<br/>Khi timer <= 0 → cooling = false
        end
    end

    Note over Player, HZC: Player rời khỏi HotZone
    Player ->> HZC: OnTriggerExit2D(collision)
    activate HZC
    HZC ->> HZC: inRange = false
    HZC ->> GE: triggerZone.SetActive(true)
    HZC ->> GE: inRange = false
    HZC ->> GE: target = null
    HZC ->> GE: SelectTarget()
    Note right of GE: Quay về tuần tra<br/>giữa leftLimit ↔ rightLimit
    deactivate HZC
    deactivate GE
```

---

### 2.8. Kịch bản 8: Boss Bắn Cầu Lửa (Shoot Fireballs)

**Mô tả**: Boss bắn cầu lửa về phía người chơi.

```mermaid
sequenceDiagram
    participant BC as BossController
    participant SFA as ShootFireballsAttack
    participant Anim as Animator
    participant FB as Fireball (Prefab)
    participant PH as PlayerHealth

    BC ->> BC: ChooseRandomAttack()
    activate BC
    Note right of BC: Random chọn ShootFireballs
    BC ->> BC: currentState = ShootFireballs
    BC ->> BC: TriggerShootFireballs()
    BC ->> BC: fireballShotsCount = 0
    deactivate BC

    loop fireballShotsCount < maxFireballShots
        activate BC
        BC ->> SFA: ShootFireball()
        activate SFA
        SFA ->> Anim: SetBool("isShooting", true)
        SFA ->> Anim: SetTrigger("shootFireBall")
        SFA ->> SFA: Tính hướng bắn (player.pos - firePoint.pos)
        SFA ->> FB: Instantiate(fireballPrefab, firePoint)
        activate FB
        SFA ->> FB: rb.linearVelocity = direction * fireballSpeed
        SFA -->> BC: 
        deactivate SFA
        BC ->> BC: fireballShotsCount++
        deactivate BC

        Note right of FB: Fireball bay về phía player

        alt Va chạm Player
            FB ->> PH: TakeDamage(1)
            activate PH
            PH ->> PH: currentHealth -= 1
            PH -->> FB: 
            deactivate PH
            FB ->> FB: Destroy(gameObject)
            deactivate FB
        end
    end

    activate BC
    BC ->> BC: currentState = Idle
    BC ->> BC: stateTimer = idleDuration
    deactivate BC
```

---

## 3. Ký Hiệu UML Tóm Tắt Cho Sequence Diagram

| Thành phần                | Cách vẽ trên Draw.io                                                |
|---------------------------|----------------------------------------------------------------------|
| **Actor (Tác nhân)**       | Hình người que (stickman) ở đầu lifeline                           |
| **Object (Đối tượng)**    | Hộp chữ nhật chứa tên đối tượng (`:TênLớp`)                       |
| **Lifeline (Đường sống)** | Đường đứt nét kéo dọc xuống từ Object                               |
| **Activation Bar**         | Thanh chữ nhật mỏng trên lifeline (đối tượng đang xử lý)           |
| **Synchronous Message**    | Mũi tên đặc (→) với nhãn tên phương thức                           |
| **Return Message**         | Mũi tên đứt nét (⇢) quay về object gọi                            |
| **Self-call**              | Mũi tên vòng lại chính lifeline đó                                  |
| **Alt Fragment**           | Hộp viền đứt nét có nhãn `alt` ở góc trái, chia bằng đường ngang   |
| **Loop Fragment**          | Hộp viền đứt nét có nhãn `loop` ở góc trái                         |
| **Opt Fragment**           | Hộp viền đứt nét có nhãn `opt` ở góc trái                          |
| **Note**                   | Hộp nhỏ ghi chú, nối vào lifeline bằng đường đứt nét               |
| **Destroy (X)**            | Dấu X lớn ở cuối lifeline                                           |

---

## 4. Hướng Dẫn Vẽ Sequence Diagram Trên Draw.io

### Bước 1: Nhập sơ đồ từ Mermaid (Cách nhanh nhất)

1.  Truy cập [Draw.io](https://app.diagrams.net).
2.  Bấm **+ (Insert)** → **Advanced** → **Mermaid**.
3.  Sao chép đoạn mã Mermaid của kịch bản bạn muốn vẽ (từ **Mục 2**) và dán vào hộp thoại.
4.  Bấm **Insert** → Draw.io tự động sinh sơ đồ tuần tự.
5.  Chỉnh sửa bố cục, căn chỉnh lại các lifeline cho đều nhau.

### Bước 2: Vẽ thủ công (Chi tiết hơn)

#### a. Tạo các đối tượng (Participants)

1.  Bật thư viện **UML** ở panel bên trái (More Shapes → UML).
2.  Tìm hình **Lifeline** hoặc **Object** và kéo thả lên canvas.
3.  Sắp xếp các đối tượng **theo hàng ngang** ở phía trên cùng:
    ```
    [Người chơi]   [HandInputProvider]   [PlayerController]   [GunController]   [Bullet]
    ```
4.  Kéo **đường dọc đứt nét** (Lifeline) từ mỗi đối tượng xuống dưới.

#### b. Vẽ các thông điệp

1.  Dùng **Arrow** (mũi tên) để nối từ lifeline A sang lifeline B.
2.  **Double-click** vào mũi tên để thêm nhãn (tên phương thức được gọi).
3.  Dùng **Dashed Arrow** (mũi tên đứt nét) cho **Return Message**.

#### c. Thêm Activation Bar

1.  Vẽ một **Rectangle nhỏ dọc** (hẹp, cao) đặt trên lifeline tại vị trí đối tượng đang xử lý.
2.  Bắt đầu activation bar khi nhận thông điệp, kết thúc khi gửi return message.

#### d. Thêm Fragment (alt/loop/opt)

1.  Vẽ một **Rectangle viền đứt nét** bao quanh nhóm thông điệp cần đặt điều kiện.
2.  Thêm nhãn ở góc trái trên (ví dụ: `alt`, `loop`, `opt`).
3.  Nếu là `alt`, vẽ **đường ngang đứt nét** ở giữa để phân chia hai nhánh (if/else).
4.  Ghi điều kiện trong **[ngoặc vuông]** trên đường phân chia.

### Bước 3: Tô màu và hoàn thiện

*   **Actor (Người chơi)**: Màu xanh dương (`#3B82F6`).
*   **Nhóm Player**: Lifeline và activation bar màu xanh lá (`#10B981`).
*   **Nhóm Boss**: Lifeline và activation bar màu đỏ (`#EF4444`).
*   **Nhóm Enemy**: Lifeline và activation bar màu cam (`#F59E0B`).
*   **Nhóm UI**: Lifeline và activation bar màu tím (`#8B5CF6`).
*   **Fragment alt/loop**: Viền màu xám đậm, nền trong suốt hoặc xám rất nhạt.

---

## 5. Mẹo Vẽ Sequence Diagram Chuẩn

1.  **Đặt tên đối tượng theo format `:TênLớp`**: Ví dụ `:PlayerController`, `:GunController`. Dấu `:` ở đầu cho biết đây là một **instance** (thể hiện) của lớp đó.

2.  **Thứ tự đối tượng từ trái sang phải**: Sắp xếp theo thứ tự tương tác. Đối tượng gọi đầu tiên đặt bên trái, đối tượng nhận cuối cùng đặt bên phải.

3.  **Nhãn thông điệp = Tên phương thức**: Ghi rõ tên hàm được gọi, ví dụ `Shoot()`, `TakeDamage(1)`, `AddAmmo(7)`.

4.  **Sử dụng Fragment hợp lý**: Chỉ dùng `alt`, `loop`, `opt` khi cần thiết, tránh lồng quá nhiều fragment gây rối.

5.  **Thêm Note khi cần giải thích**: Dùng Note (hộp ghi chú) để giải thích logic phức tạp mà không thể hiện rõ qua tên phương thức.

6.  **Đồng bộ vs Bất đồng bộ**: 
    *   `Instantiate()`, `Destroy()` → Dùng mũi tên **đồng bộ** (mũi tên đặc).
    *   `StartCoroutine()` → Dùng mũi tên **bất đồng bộ** (mũi tên đứt nét) vì coroutine chạy trên nhiều frame.

7.  **Giữ sơ đồ tập trung**: Mỗi Sequence Diagram chỉ nên mô tả **một kịch bản cụ thể**. Không cố gắng nhồi nhiều use case vào 1 sơ đồ.

---

## 6. Bảng Tổng Hợp Các Kịch Bản

| # | Kịch bản                          | Đối tượng chính                                             | Số lượng message |
|---|-------------------------------------|-------------------------------------------------------------|------------------|
| 1 | Người chơi bắn súng               | Player → HIP → PC → GC → Bullet → Enemy                   | ~15              |
| 2 | Di chuyển & nhảy                   | Player → HIP → PC → RB → Animator                          | ~12              |
| 3 | Boss Dash-Fire Combo               | BC → DA → Anim → BAE → PH                                  | ~20              |
| 4 | Boss Chase Attack                  | BC → CA → Anim → BAE → PH                                  | ~15              |
| 5 | Nhặt vật phẩm                      | Player → AmmoPickup/HealthItem → GC/PH → UI                | ~10              |
| 6 | Người chơi chết                    | Enemy → PH → PHUI → DeadUI → SceneManager                  | ~12              |
| 7 | GroundEnemy AI                     | Player → TAC → GE → HZC → PH → Anim                       | ~18              |
| 8 | Boss bắn cầu lửa                   | BC → SFA → Anim → Fireball → PH                            | ~12              |
