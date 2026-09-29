# 龙崖（Dragon Cliff）MOD 修改教程

> 版本：2026-09-29 实战汇总
> 方法：dnSpy 改 `Assembly-CSharp.dll`（patch 路线已废弃）
> 铁律：改前备份 DLL；源码仓库只标注不改逻辑，一切修改以本教程为准
> 说明：每章均含【修改前】原版代码与【修改后】目标代码，可对照还原

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

**目的**：掉落宝石直接 25 级（25 是合成/锻造上限，原版掉落永远到不了）。

**位置**：`DifficultyLevelMeasurement` 类 → `GetGemLevel(double difficultyValue, int starRating)`（private static）

**修改前**（原版，按星级+难度分段查表，3 星档最高 20）：

```csharp
private static int GetGemLevel(double difficultyValue, int starRating)
{
    if (starRating == 1)
    {
        // 难度 ≤10→1，≤26→2，≤35→3，≤42→4，≤100→5，≤130→6，≤210→7，其余→8
        ...
    }
    else if (starRating == 2)
    {
        // 难度 ≤80→8，≤200→9，其余→10
        ...
    }
    else
    {
        // 难度 ≤50→10，≤100→11，≤200→12，≤300→13，≤400→14，≤500→15，
        // ≤600→16，≤700→17，≤800→18，≤5000→19，其余→20
        ...
    }
}
```

**修改后**（Edit Method 整体替换方法体）：

```csharp
private static int GetGemLevel(double difficultyValue, int starRating)
{
    return 25;
}
```

**说明**：覆盖普通掉落 + 无尽模式；`GemGeneratorBase.GenerateGem` 会把 `level>=25` 钳到 25，不会溢出。

---

## 2. 居民最大数量

**目的**：居民槽位上限 30 → 127。

**位置**：`PlayerProfile` 类 → **静态构造函数** `static PlayerProfile()`（.cctor）里的 `MaxResidentSlot` 赋值。原值在字段声明处：

**修改前**：
```csharp
public static readonly int MaxResidentSlot = 30;
```

**修改后**（改 .cctor 里的赋值，或 Edit Field 改初值）：
```csharp
public static readonly int MaxResidentSlot = 127;
```

**说明**：`NumberOfResidentSlots` 是 int，改 127 无溢出；实际瓶颈是城镇寻路性能。别 Edit Class（类里 lambda 多）。

---

## 3. 居民 buff 上限一族（6 条）

**目的**：城镇总加成闸门全开（原版加成超过上限被 clamp、溢出单独记账）。

**位置**：`PlayerProfile` 静态构造函数 `static PlayerProfile()`，6 条赋值。

**修改前**：
```csharp
MaxReisdentPriceBoost   = 20.0;   // 武器/护甲售价加成
MaxProductionRate       = 50.0;   // 生产加成
MaxItemQualityBoostRate = 30.0;   // 掉落品质
MaxChestBoost           = 10.0;   // 仅 UI 显示用
MaxDivineHeartBoost     = 10.0;   // 宝箱祝福
MaxPracticePointsBoost  = 30.0;   // 修炼点
```

**修改后**：
```csharp
MaxReisdentPriceBoost   = 99999.0;
MaxProductionRate       = 99999.0;
MaxItemQualityBoostRate = 99999.0;
MaxChestBoost           = 99999.0;
MaxDivineHeartBoost     = 99999.0;
MaxPracticePointsBoost  = 99999.0;
```

**说明**：改大后溢出值自动重算，UI 自适应；这些是"总和闸门"，单兵强度看第 4 章。

---

## 4. 必远古 + 居民 buff 爆炸

**目的**：全员装备远古 + 居民单兵 buff 数十倍。

### 4.1 必远古（品质入口）

**位置**：`GenerationDistribution` 类 → `GetGrade()`（public QualityGrade）

**修改前**（原版，按权重随机）：
```csharp
public QualityGrade GetGrade()
{
    float num = UnityEngine.Random.Range(0f, 1f);
    if ((double)num >= this.RareChance + this.LegendaryChance + this.EpicChance + this.AncientChance)
    {
        return QualityGrade.Normal;
    }
    if ((double)num >= this.LegendaryChance + this.EpicChance + this.AncientChance)
    {
        return QualityGrade.Rare;
    }
    if ((double)num >= this.LegendaryChance + this.AncientChance)
    {
        return QualityGrade.Epic;
    }
    if ((double)num >= this.AncientChance)
    {
        return QualityGrade.Legendary;
    }
    return QualityGrade.Ancient;
}
```

**修改后**（Edit Method 整体替换）：
```csharp
public QualityGrade GetGrade()
{
    return QualityGrade.Ancient;
}
```

### 4.2 居民品质系数区间（单兵倍率主改点）

**位置**：`ResidentsExtensions` 类 → `CreateResidentByQuality`（public static）

**修改前**（原版 5 档随机区间）：
```csharp
float num = UnityEngine.Random.Range(0f, 0.2f);
if (value == QualityGrade.Rare)
{
    num = UnityEngine.Random.Range(0.2f, 0.4f);
}
if (value == QualityGrade.Epic)
{
    num = UnityEngine.Random.Range(0.4f, 0.6f);
}
if (value == QualityGrade.Legendary)
{
    num = UnityEngine.Random.Range(0.6f, 0.8f);
}
if (value == QualityGrade.Ancient)
{
    num = UnityEngine.Random.Range(0.8f, 1f);
}
```

**修改后**（10 倍档：系数 20~100，配合必远古全员判 Ancient 可接受）：
```csharp
float num = UnityEngine.Random.Range(0f, 2f);
if (value == QualityGrade.Rare)
{
    num = UnityEngine.Random.Range(2f, 4f);
}
if (value == QualityGrade.Epic)
{
    num = UnityEngine.Random.Range(4f, 6f);
}
if (value == QualityGrade.Legendary)
{
    num = UnityEngine.Random.Range(6f, 8f);
}
if (value == QualityGrade.Ancient)
{
    num = UnityEngine.Random.Range(8f, 10f);
}
```

**说明**：单兵 buff = 难度查表基准 × (系数+1)，生产最高 +303%、售价/修炼/掉宝 +151.5%、神心 +60.6%。只对新招募居民生效。保品质梯度版：区间不动，改 `CreateResidentByCoeff` 里 `determinedQualityCoef + 1.0` → `determinedQualityCoef * 10.0 + 1.0`。

---

## 5. 【必远古副作用】合成修复

**症状**：必远古后铁匠合成做不了 → 合成任务（ItemCombined 事件）卡死。

**根因**：`IsCombineable` 要求三件至少一件非远古；且全远古时最低品质=Ancient(5) → `num=(int)(5+1)=6`，原判定 `num<5 || num==5` 两层全卡。

### 5.1 `BuildingExtensions.IsCombineable`（含 LINQ，走 IL）

**修改前**（关键条件行）：
```csharp
if (items.Any((Item i) => i.ItemGrade != QualityGrade.Ancient)   // ← 必删
    && items.All((Item i) => i.Level == level)
    && (num < 5 || (num == 5 && BuildingExtensions.GetForgeLevel() >= 2))
    && (category.IsWeapon() || category.IsArmor() || category == ResourceCategory.Consumable
        || (category == ResourceCategory.Gem && level < ItemExtensions.MaxGemLevel)))
```

**修改后**：
```csharp
if (items.All((Item i) => i.Level == level)
    && (num <= 5 || (num == 6 && BuildingExtensions.GetForgeLevel() >= 2))
    && (category.IsWeapon() || category.IsArmor() || category == ResourceCategory.Consumable
        || (category == ResourceCategory.Gem && level < ItemExtensions.MaxGemLevel)))
```

**IL 等价改法**：删除 Any 条件的整段 lambda 调用+分支；`num < 5`/`num == 5` 两处 `ldc.i4.5` 常量改 `ldc.i4.6`（分支指令不动）。

### 5.2 `BuildingExtensions.CalculateCombineResult`（大量 LINQ，必须走 IL）

**修改前**：
```csharp
int num2 = (int)(qualityGrade + 1);
if (num2 < 5 || (num2 == 5 && BuildingExtensions.GetForgeLevel() >= 2))
```

**修改后**（等价）：
```csharp
int num2 = (int)(qualityGrade + 1);
if (num2 < 6 || (num2 == 6 && BuildingExtensions.GetForgeLevel() >= 2))
```

**IL 操作**（Edit Method Body，找到 `num2` 判定段）：
```cil
ldloc.s  V_9
ldc.i4.5        ; ← 改 6
blt      进if体
ldloc.s  V_9
ldc.i4.5        ; ← 改 6
bne.un    跳过
call GetForgeLevel()
ldc.i4.2
blt      跳过
```
改后反编译应显示：`if (num2 < 6 || (num2 == 6 && GetForgeLevel() >= 2))`

### 5.3 产出品质（防枚举越界）

**修改前**（原行）：
```csharp
type2.ItemGenerate(ResourceSourceType.Combine,
    productionDifficultyLevelMeasurement2.GetItemGenerationQuality((QualityGrade)num2, type2, ResourceSourceType.Combine),
    itemTierLevel, 1)
```

**修改后 v1（固定远古，已验证可解任务）**：IL 里把传给 `GetItemGenerationQuality` 的品质参数 `ldloc.s V_9` 换成 `ldc.i4.5`，反编译显示：
```csharp
GetItemGenerationQuality(QualityGrade.Ancient, type2, ResourceSourceType.Combine)
```

**修改后 v2（远古合成星辰，推荐终端形态，待验证）**：产出段加分支——全远古（num2==6）产星辰，低品质维持原金字塔：
```csharp
ItemGenerationQuality quality = (num2 == 6)
    ? ItemGenerationQuality.CreateStar()
    : productionDifficultyLevelMeasurement2.GetItemGenerationQuality((QualityGrade)(num2 > 5 ? 5 : num2), type2, ResourceSourceType.Combine);
type2.ItemGenerate(ResourceSourceType.Combine, quality, itemTierLevel, 1);
```

**v2 IL 级操作（从 v1 状态出发，Edit Method Body）**：

修改前 IL（v1，已固定远古）：
```cil
188  026D  ldloc.s   V_13     ; this = measurement2
189  026F  ldc.i4.5           ; 品质固定 5（v1）
190  0271  ldloc.s   V_10     ; type2
191  0273  ldc.i4.4           ; Combine
192  0274  callvirt  GetItemGenerationQuality(QualityGrade, ResourceType, ResourceSourceType)
193  0279  ldloc.s   V_12     ; itemTierLevel
194  027B  ldc.i4.1
195  027C  call      ItemGenerate(ResourceType, ResourceSourceType, ItemGenerationQuality, int32, int32)
```

修改后 IL（v2 分支）：
```cil
      ldloc.s     V_9          ; num2
      ldc.i4.6
      bne.un      →原逻辑      ; num2 != 6 → 走原品质+1 路径
      call        ItemGenerationQuality::CreateStar()   ; num2==6 → 星辰
      br          →合并点
原逻辑:
188  026D  ldloc.s   V_13     ; this（不动）
189  026F  ldloc.s   V_9      ; ★改回：品质 = num2（原版 (QualityGrade)num2）
190  0271  ldloc.s   V_10     ; type2（不动）
191  0273  ldc.i4.4           ; Combine（不动）
192  0274  callvirt  GetItemGenerationQuality（不动）
合并点:
193  0279  ldloc.s   V_12     ; itemTierLevel（不动）
194  027B  ldc.i4.1           ; （不动）
195  027C  call      ItemGenerate（不动）
```

dnSpy 具体操作：① 选中 188 行右键插入 5 条指令（ldloc.s V_9 / ldc.i4.6 / bne.un→188 / call CreateStar / br→193）；② 把 189 的 ldc.i4.5 改回 ldloc.s V_9；③ 其余不动保存。跳转目标用操作数下拉选对应指令行，插入后行号自动重排，按逻辑位置选。

**说明**：`CreateStar()` = 远古+星标（星辰），卷轴制作已在用；星辰可继续当合成原料（按远古品质计 num=6），形成星辰→星辰消耗循环，每轮亏 2 件。v1 为解任务保底，v2 为消耗口升级。

---

## 6. 学院技能等级上限

**目的**：技能上限 9/3/9 → 99。

### 6.1 `SkillLogicBase.GetMaxLevel`（全技能统一入口，无子类 override）

**修改前**：
```csharp
public int GetMaxLevel()
{
    if (this.SkillCommandType == SkillCommandType.Main)
    {
        return 9;
    }
    if (this.SkillCommandType == SkillCommandType.Active)
    {
        return 3;
    }
    if (this.SkillCommandType == SkillCommandType.Secondary)
    {
        return 9;
    }
    return 0;
}
```

**修改后**：
```csharp
public int GetMaxLevel()
{
    if (this.SkillCommandType == SkillCommandType.Main)
    {
        return 99;
    }
    if (this.SkillCommandType == SkillCommandType.Active)
    {
        return 99;
    }
    if (this.SkillCommandType == SkillCommandType.Secondary)
    {
        return 99;
    }
    return 0;
}
```

### 6.2 【必改配套】`LevelBarController.Init` 双 9 封顶

> ⚠️ 不改会崩：`ColorPicker.GetGradientColor` 只认 listSize 3/9，其他值直接抛异常 → 学院打不开（实战踩过）。颜色表 `Gradients` 只有 9 色（索引 0~8），循环超 9 越界。

**修改前**：
```csharp
public void Init(int level, int maxLevel)
{
    this.ResetBar();
    for (int i = 0; i < maxLevel; i++)
    {
        SkillColorBlockController component = UnityEngine.Object.Instantiate<GameObject>(this.ColorBlockPre).GetComponent<SkillColorBlockController>();
        component.transform.SetParent(base.transform, false);
        component.Init(i + 1 <= level, ColorPicker.GetGradientColor(i, maxLevel));
    }
}
```

**修改后**：
```csharp
public void Init(int level, int maxLevel)
{
    this.ResetBar();
    int displayMax = Math.Min(maxLevel, 9);
    for (int i = 0; i < displayMax; i++)
    {
        SkillColorBlockController component = UnityEngine.Object.Instantiate<GameObject>(this.ColorBlockPre).GetComponent<SkillColorBlockController>();
        component.transform.SetParent(base.transform, false);
        component.Init(i + 1 <= level, ColorPicker.GetGradientColor(i, 9));
    }
}
```

**已知行为差异（非 bug）**：
- 主动技能 3 级+ 升级成本返回空 → 免费升级（白嫖）
- 档位制技能（if Level==1/2 else 兜底）超档后效果不再涨；线性公式的（如奥术）才继续涨
- 上限别填 int.MaxValue：升级成本 `(level-5)*12000` int 乘法，约 17.9 万级时溢出变负

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
| 修改教程 | `change.md`（本文件） | 54471ad |