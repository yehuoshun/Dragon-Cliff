# 龙崖（Dragon Cliff）MOD 修改教程

> 版本：2026-09-29 实战汇总
> 方法：dnSpy 改 `Assembly-CSharp.dll`（patch 路线已废弃）
> 铁律：改前备份 DLL；源码仓库只标注不改逻辑，一切修改以本教程为准

---

## 0. 通用操作要点

| 要点 | 说明 |
|---|---|
| **备份** | 改任何东西前复制一份 `game_Data/Managed/Assembly-CSharp.dll` |
| **Edit Method vs Edit Class** | 含 LINQ/lambda 的方法（如 `CalculateCombineResult`、`IsCombineable`）**Edit Method (C#) 必失败**（报 Invalid token `'<'`），只能右键 **Edit Method Body** 改 IL |
| **纯常量方法**（如 GetMaxLevel、GetGrade） | 可直接 Edit Method (C#) |
| **改 IL 常量** | `ldc.i4.5` 这种直接点数值改；用上方 C# 注释行定位，别改错位置 |
| **保存** | File → Save Module，重进游戏生效 |
| **旧数据不追溯** | 已生成的居民/存档数值已定死，改代码只影响新生成 |

---

## 1. 宝石掉落满级 25

**目的**：掉落宝石直接 25 级（原版 3 星最高 20，25 是合成/锻造上限）。

- 位置：`DifficultyLevelMeasurement` 类 → `GetGemLevel(double, int)`（private static）
- 改法（Edit Method，整体替换方法体）：

```csharp
private static int GetGemLevel(double difficultyValue, int starRating)
{
    return 25;
}
```

- 覆盖普通掉落 + 无尽模式；`GenerateGem` 会把 `level>=25` 钳到 25，不会溢出。

---

## 2. 居民最大数量

**目的**：居民槽位上限 30 → 127。

- 位置：`PlayerProfile` 类 → 静态字段 `MaxResidentSlot = 30`
- 写法：找**静态构造函数 `static PlayerProfile()`**，改赋值 `MaxResidentSlot = 30` → `127`（别 Edit Class，类里 lambda 多）
- 注意：实际瓶颈是城镇寻路性能（NodeController），别贪太大

---

## 3. 居民 buff 上限一族（6 条）

**目的**：城镇总加成闸门全开。

- 位置：`PlayerProfile` 静态构造函数，6 条赋值：

```csharp
MaxReisdentPriceBoost  = 20.0   → 99999.0   // 武器/护甲售价加成
MaxProductionRate      = 50.0   → 99999.0   // 生产加成
MaxItemQualityBoostRate= 30.0   → 99999.0   // 掉落品质
MaxChestBoost          = 10.0   → 99999.0   // 仅 UI 显示用
MaxDivineHeartBoost    = 10.0   → 99999.0   // 宝箱祝福
MaxPracticePointsBoost = 30.0   → 99999.0   // 修炼点
```

- 语义：超过上限被 clamp、溢出单独记账；改大后溢出值自动重算，UI 自适应

---

## 4. 必远古 + 居民 buff 爆炸

**目的**：全员装备远古 + 居民单兵 buff 数十倍。

**4.1 必远古（入口）**
- 位置：`GenerationDistribution` → `GetGrade()`
- 改法（Edit Method 整体替换）：

```csharp
public QualityGrade GetGrade()
{
    return QualityGrade.Ancient;
}
```

**4.2 居民品质系数区间（"随机数"，单兵倍率主改点）**
- 位置：`ResidentsExtensions` → `CreateResidentByQuality`
- 改法：5 个 `Random.Range` 区间整体放大（配合必远古，全员判 Ancient 可接受）：

```csharp
num = UnityEngine.Random.Range(0f, 2f);     // Normal   原 0~0.2
num = UnityEngine.Random.Range(2f, 4f);     // Rare     原 0.2~0.4
num = UnityEngine.Random.Range(4f, 6f);     // Epic     原 0.4~0.6
num = UnityEngine.Random.Range(6f, 8f);     // Legendary 原 0.6~0.8
num = UnityEngine.Random.Range(8f, 10f);    // Ancient  原 0.8~1.0
```

- 效果：单兵 buff = 难度查表基准 × (系数+1)，生产最高 +303%，售价/修炼/掉宝 +151.5%，神心 +60.6%
- 可选（保品质梯度版）：区间不动，改 `CreateResidentByCoeff` 里 `determinedQualityCoef + 1.0` → `determinedQualityCoef * 10.0 + 1.0`
- ⚠️ 只对**新招募**居民生效

---

## 5. 【必远古副作用】合成任务卡死修复（3 处）

**症状**：必远古后铁匠合成做不了 → 合成任务卡死。

**根因**：`IsCombineable` 要求三件至少一件非远古；且全远古时最低品质=Ancient(5) → `num=(int)(5+1)=6`，原判定 `num<5 || num==5` 两层全卡。

**5.1 `BuildingExtensions.IsCombineable`**（含 LINQ，走 IL）
- 删条件：`items.Any((Item i) => i.ItemGrade != QualityGrade.Ancient) &&`
- num 判定：`(num < 5 || (num == 5 && GetForgeLevel() >= 2))` 改为
  ```csharp
  (num <= 5 || (num == 6 && GetForgeLevel() >= 2))
  ```
- IL 等价改法：`num < 5` 与 `num == 5` 两处 `ldc.i4.5` 常量都改成 `ldc.i4.6`（分支指令不动）

**5.2 `BuildingExtensions.CalculateCombineResult`**（含大量 LINQ，必须走 IL）
- 找到 `num2` 判定的 IL：
  ```cil
  ldloc.s  V_9
  ldc.i4.5        ; ← 改成 6
  blt      进if体
  ldloc.s  V_9
  ldc.i4.5        ; ← 改成 6
  bne.un    跳过
  call GetForgeLevel()
  ldc.i4.2
  blt      跳过
  ```
- 改后等价：`if (num2 < 6 || (num2 == 6 && GetForgeLevel() >= 2))`

**5.3 产出品质（防枚举越界，必须走 IL）**
- 找到 `GetItemGenerationQuality` 调用前的品质参数 `ldloc.s V_9`，替换为 `ldc.i4.5`（固定 Ancient）
- 改后反编译应显示：`GetItemGenerationQuality(QualityGrade.Ancient, type2, ResourceSourceType.Combine)`
- 原因：`(QualityGrade)num2` 在 num2=6 时会 cast 出枚举外值（枚举只有 1~5）

**验证**：铁匠三件同类型同等级远古 → 合成可点 → 3 换 1 远古。

---

## 6. 学院技能等级上限

**目的**：技能上限 9/3/9 → 99。

**6.1 `SkillLogicBase.GetMaxLevel`**（全技能统一入口，无子类 override，一处全生效）
```csharp
public int GetMaxLevel()
{
    if (this.SkillCommandType == SkillCommandType.Main)       return 99;
    if (this.SkillCommandType == SkillCommandType.Active)    return 99;
    if (this.SkillCommandType == SkillCommandType.Secondary) return 99;
    return 0;
}
```

**6.2 【必改配套】`LevelBarController.Init` 双 9 封顶**
- ⚠️ **不改会崩**：`ColorPicker.GetGradientColor` 只认 listSize 3/9，其他值直接抛异常 → 学院打不开（实战踩过）
- 颜色表 `Gradients` 只有 9 色，循环超 9 会越界
```csharp
public void Init(int level, int maxLevel)
{
    this.ResetBar();
    int displayMax = Math.Min(maxLevel, 9);              // 9 格封顶
    for (int i = 0; i < displayMax; i++)
    {
        SkillColorBlockController component = UnityEngine.Object.Instantiate<GameObject>(this.ColorBlockPre).GetComponent<SkillColorBlockController>();
        component.transform.SetParent(base.transform, false);
        component.Init(i + 1 <= level, ColorPicker.GetGradientColor(i, 9));   // 颜色参数固定 9
    }
}
```

**已知行为差异（非 bug）**：
- 主动技能 3 级+ 升级成本返回空 → 免费升级（白嫖）
- 档位制技能（if Level==1/2 else 兜底）超档后效果不再涨；线性公式的（如奥术）才继续涨
- 上限别填 int.MaxValue：升级成本 `(level-5)*12000` int 乘法，约升到 17.9 万级时溢出变负

---

## 附：修改点速查（源码标注位置）

| 功能 | 类/方法 | 标注 commit |
|---|---|---|
| 宝石掉落 25 | `DifficultyLevelMeasurement.GetGemLevel` | 87d96ec |
| 居民上限 | `PlayerProfile.MaxResidentSlot` 附近 | a90e179 |
| buff 上限族 | `PlayerProfile` 静态构造 | a90e179 |
| 系数区间/查表 | `ResidentsExtensions.CreateResidentByQuality` + 6 个 effect 类 | 30c7308 |
| 合成修复 | `BuildingExtensions.IsCombineable/CalculateCombineResult` | 92a79be→ea7c976 |
| 技能上限 | `SkillLogicBase.GetMaxLevel` | e746690→421d38f |
| UI 封顶 | `LevelBarController.Init` + `ColorPicker.GetGradientColor` | 3bc6ca2→0327d89 |