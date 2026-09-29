# 龙崖（Dragon Cliff）MOD 修改教程

> 版本：2026-09-30（v5，§4.1 实测改法定稿：两处已改验证成功；v2 已移除合成修复章节）
> 方法：dnSpy 改 `Assembly-CSharp.dll`（patch 路线已废弃）
> 铁律：改前备份 DLL；源码仓库只标注不改逻辑，一切修改以本教程为准
> 说明：每章均含【修改前】原版代码与【修改后】目标代码，可对照还原

---

## 0. 通用操作要点

| 要点 | 说明 |
|---|---|
| **备份** | 改任何东西前复制一份 `game_Data/Managed/Assembly-CSharp.dll` |
| **Edit Method vs Edit Class** | 含 LINQ/lambda 的方法（如 `SchoolMenuController.UpdatePages`、`GetListByFurnaceTab`）**Edit Method (C#) 必失败**（报 Invalid token `'<'` / CS0121 歧义），只能右键 **Edit Method Body** 改 IL |
| **纯常量方法**（如 GetMaxLevel、GetGrade） | 可直接 Edit Method (C#) |
| **改 IL 常量** | `ldc.i4.5` 这种直接点数值改；用上方 C# 注释行定位，别改错位置 |
| **保存** | File → Save Module，重进游戏生效 |
| **旧数据不追溯** | 已生成的居民/存档数值已定死，改代码只影响新生成 |

---

# 一、掉落类

## 1.1 宝石掉落满级 25

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

## 1.2 商店饰品必定星辰

> ✅ **已改验证成功（2026-09-30）**：商店刷新饰品带星辰特效。

**目的**：原版商店饰品永远不星辰（生成时 `forceStar=false` 被资格闸拦截），改后 Ancient 品质饰品必定星辰。

**位置**：`DifficultyLevelMeasurement` 类 → 两个方法：`GetStarChance`（概率闸）+ `GetQualityConfig`（资格闸）。**两处都改，缺一不可**（实战踩坑：只改概率闸，饰品仍不星辰）。

**① 概率闸 `GetStarChance`**（public，原版按来源分档：商店/掉落 1%、合成 1.5%、卷轴 30%、1 星 0.05%、其他 0.1%）

**修改后**（Edit Method (C#) 整体替换，无 lambda）：
```csharp
public double GetStarChance(ResourceSourceType itemSource)
{
    return 1.0;
}
```

**② 资格闸 `GetQualityConfig`**（private，flag 决定谁能参与星辰判定）

**修改前**（饰品需要 tier>35 且 forceStar，商店饰品 forceStar=false → 恒无资格）：
```csharp
bool flag = ((resourceCategory.IsWeapon() || resourceCategory.IsArmor()) && correspondingItemTierLevel > 35) || (resourceCategory == ResourceCategory.Accessory && correspondingItemTierLevel > 35 && forceStar) || (resourceCategory == ResourceCategory.Scrolls && correspondingItemTierLevel > 35);
```

**修改后**（饰品无条件有资格，只改中间一段）：
```csharp
bool flag = ((resourceCategory.IsWeapon() || resourceCategory.IsArmor()) && correspondingItemTierLevel > 35) || resourceCategory == ResourceCategory.Accessory || (resourceCategory == ResourceCategory.Scrolls && correspondingItemTierLevel > 35);
```

**生效链路**：商店饰品 → Ancient（§2.3 梯度 90%）→ flag=true → `Random.value <= 1.0` 恒真 → `CreateStar()` → 挂星辰特效。

**边界**：配合 90% 远古梯度，约 90% 饰品星辰；10% 非远古不星辰。顺带：商店/掉落的 Ancient 武器/护甲/卷轴（tier>35）也必定星辰。

## 1.3 商店进货频率与补货量

> ✅ **已改（2026-09-30）**：进货周期改短 + 每次补 10 个商品（老板 dnSpy 已实施）。

**目的**：商店刷新太慢（原版 20 天补 1 个），改为高频大补——配合 §1.2 商店饰品必定星辰，更快刷荣光/装备。

**机制**：
- 周期：`PlayerProfile.ShopRefreshDays = 20`（天），`SystemProcessor.ShopRefresh` 每天倒计时，归零补货后重置
- 每次补货量：`RefreshStock(measurement, N)` 的 N（原版 1）
- 额外：**通关冒险**也补 1 个（`SystemProcessor.cs` :699）；**商店建造时**补 1 个（`Shop.cs` :241）

**已改位置（3 处）**：
| 位置 | 原值 | 已改 |
|---|---|---|
| `PlayerProfile.ShopRefreshDays` | 20 天 | 改短（值以老板改动为准） |
| `SystemProcessor.ShopRefresh` 补货量 | 1 | **10** |
| （通关/建造补货量同法可改） | 1 | 未动 |

**dnSpy 改法**：
- 周期：Edit Field / .cctor 改 `ldc.i4.s 20` → 目标天数（static readonly）
- 补货量：`RefreshStock(..., 1)` 的常量 1 → 10（`ldc.i4.1` → `ldc.i4.s 10`）

---

# 二、居民类

## 2.1 居民槽位上限 30 → 127

**目的**：可招募/持有的居民数量上限放宽。

**位置**：`PlayerProfile` 类 → `public static readonly int MaxResidentSlot = 30;`（字段声明处，或静态构造函数 `static PlayerProfile()` 里的赋值）

**修改前**：
```csharp
public static readonly int MaxResidentSlot = 30;
```

**修改后**（改 .cctor 里的赋值，或 Edit Field 改初值）：
```csharp
public static readonly int MaxResidentSlot = 127;
```

**说明**：`NumberOfResidentSlots` 是 int，改 127 无溢出；实际瓶颈是城镇寻路性能。别 Edit Class（类里 lambda 多）。

## 2.2 居民 buff 上限一族（6 条）

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

**说明**：改大后溢出值自动重算，UI 自适应；这些是"总和闸门"，单兵强度看 2.4。注意 `MaxChestBoost` 只用于 UI 显示上限，宝箱祝福真 clamp 走 `MaxDivineHeartBoost`；`Chest._luckBoostKey`（宝箱祝福累加）本身无 clamp，可无限叠。

## 2.3 品质梯度：90% 远古 + 非远古保底（合成不卡）

> ✅ 已改（2026-09-30 待验证）：梯度版，合成材料不断供。

**目的**：绝大多数掉落/居民判为远古，同时保留 10% 非远古材料——`IsCombineable` 要求三件至少一件非远古，有非远古掉落才能继续合成（详见 4.1 的坑）。

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

**修改后**（Edit Method 整体替换；GetGrade 无 lambda，Edit Method (C#) 可改）：
```csharp
public QualityGrade GetGrade()
{
    float num = UnityEngine.Random.Range(0f, 1f);
    if ((double)num < 0.9)
    {
        return QualityGrade.Ancient;      // 90% 远古
    }
    if ((double)num < 0.95)
    {
        return QualityGrade.Legendary;    // 5% 传奇
    }
    if ((double)num < 0.975)
    {
        return QualityGrade.Epic;         // 2.5% 史诗
    }
    if ((double)num < 0.99)
    {
        return QualityGrade.Rare;         // 1.5% 稀有
    }
    return QualityGrade.Normal;           // 1% 普通
}
```

> ⚠️ **概率坑（实战踩过）**：判定必须用 `<` 低分位区间。写 `>= 0.9` 只覆盖 0.9~1.0 的 **10%**，普通反而占 81%——远古率暴跌。90% 远古 = `num < 0.9`。

> ⚠️ **必远古的代价（历史）**：若改回一刀切 `return QualityGrade.Ancient;`，**铁匠合成/合成任务会卡死**（全远古断供，详见 4.1）。梯度版就是为避开这个坑。

## 2.4 居民品质系数区间（单兵倍率主改点）

**目的**：居民单兵 buff 强度数十倍（配合 2.3 必远古，全员判 Ancient）。

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

**说明**：单兵 buff = 难度查表基准（6 个 effect 类：`ArmorSaleResidentEffect` / `WeaponSaleResidentEffect` / `ProductionResidentEffect` / `LuckResidentEffect` / `PracticeResidentEffect` / `DivineHeartResidentEffect`）× (系数+1)，生产最高 +303%、售价/修炼/掉宝 +151.5%、神心 +60.6%。只对新招募居民生效。

**保品质梯度版（不想动 2.3 时）**：区间不动，改 `CreateResidentByCoeff` 里 `determinedQualityCoef + 1.0` → `determinedQualityCoef * 10.0 + 1.0`。

---

# 三、技能类（学院）

## 3.1 学院技能等级上限 9/3/9 → 99

**目的**：主/副技能 9 级、主动 3 级上限放开（初始 1 级，面板 1~10）。

**位置**：`SkillLogicBase` 类 → `GetMaxLevel()`（全技能统一入口，无子类 override，一处全生效）

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

**说明**：实际升级还受学院等级/任务门槛限制（`GetSkillRequiredSchoolLevel`：主/副 ≥4 级需学院 2 级、≥6 级需学院 3 级；主动 ≥2 级需学院 2 级）。

## 3.2 【必改配套】LevelBar UI 封顶（不改会崩）

> ⚠️ 不改会崩：`ColorPicker.GetGradientColor` 只认 listSize 3/9，其他值直接抛异常 → 学院打不开（实战踩过）。颜色表 `Gradients` 只有 9 色（索引 0~8），循环超 9 越界。

**位置**：`LevelBarController` 类 → `Init(int level, int maxLevel)`

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

---

# 四、装备类

## 4.1 饰品镶宝石（原版 0 插槽）

> ✅ **已改验证成功（2026-09-30）**：两处修改均已实施，新生成饰品可镶宝石。

**目的**：饰品（Accessory）也能镶嵌宝石。原版饰品强制 0 插槽，品质再高也白搭。

**要改 2 处，缺一不可**：

**① 插槽生成**（`ItemExtensions.SocketGenerations`，private static）

**修改前**（饰品强制 0 插槽）：
```csharp
int num = (type.GetResourceCategory() == ResourceCategory.Accessory) ? 0 : dictionary[grade].WeightedRandomSelect<GemSocketNumberPresentable>().NumberOfSockets;
```

**修改后**（饰品走品质插槽表：普通 0 / 稀有 20%1 / 史诗 50%1 / 传奇 80%1·20%2 / 远古 2）：
```csharp
int num = (type.GetResourceCategory() == (ResourceCategory)127) ? 0 : dictionary[grade].WeightedRandomSelect<GemSocketNumberPresentable>().NumberOfSockets;
```

**dnSpy（实测改法）**：Edit Method Body (IL)，**只改一行**：`ldc.i4.s 13` → `ldc.i4.s 127`（beq 保留不动）。原理：条件 `== 13` 永假（枚举无 127），恒走 WeightedRandomSelect 分支，`ldc.i4.0` 成死代码无害。

> ⚠️ 踩坑记录：**不要**把 `beq 00D7` 改成 `nop`——`beq` 弹出两个操作数而 `nop` 不弹，`ldc.i4.s 13` 残留在栈上导致后续调用栈不平衡，保存报错。改常量值（13→127）保持栈平衡才是正解。

**② 可镶判定**（`Item.GetSocketableGems`，public）

**修改前**（只放行武器/护甲）：
```csharp
if (resourceCategory.IsWeapon() || resourceCategory.IsArmor())
```

**修改后**（放行饰品）：
```csharp
if (resourceCategory.IsWeapon() || resourceCategory.IsArmor() || resourceCategory == ResourceCategory.Accessory)
```

**dnSpy（实测改法）**：本方法虽含 lambda/LINQ，但 **Edit Method (C#) 实测可直接改成功**（未踩 Invalid token `<` 坑）；若报错再转 Edit Method Body (IL)：在 `IsArmor()` 的 `brtrue` 之后插入 4 条指令：
```
ldloc.0            // resourceCategory（第一个局部变量）
ldc.i4.s 13        // ResourceCategory.Accessory 枚举值 = 13
ceq
brtrue <原 if 体标签>
```

**说明**：只影响**新生成**饰品，已有库存不追溯（插槽在生成时定死）。

## 4.2 荣光饰品：星辰特效命中驱散（待测试）

> ⚠️ **待测试（2026-09-30）**：老板已改 NumberOfDispels，游戏内未验证。

**背景**：荣光（Fame）系列饰品 1~7 号（tier 4/9/14/19/37/45/53，力智饰品），**5/6/7 号**的星辰特效 = **命中 100% 驱散敌方增益**。配合 §1.2 商店饰品必定星辰，刷到荣光 5/6/7 即驱散神器。

**位置**：`FameFiveTemplate` / `FameSixTemplate` / `FameSevenTemplate` 类 → `GenerateStarEffects(QualityGrade grade, int itemTierNumber)`（三处代码相同）

**原版**（`Random.Range(1, 3)` int 重载上界排他 → **实际驱散 1~2 个**）：
```csharp
public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
{
    return new List<ISpecialEffectDataLoad>
    {
        new DispelOnHitData
        {
            Chance = 1.0,
            IsStar = true,
            NumberOfDispels = UnityEngine.Random.Range(1, 3)
        }
    };
}
```

**改法**（Edit Method (C#)，无 lambda 可直接改）：
```csharp
NumberOfDispels = 3        // 固定 3 个（原版实际 1~2，Range 上界排他）
NumberOfDispels = UnityEngine.Random.Range(1, 4)   // 1~3 随机（含 3）
```

**触发条件**（`DispelOnHitProcess`）：`!IsMissed && IsDirectDamage` —— **命中 + 直接伤害**才触发：
- 命中本体伤害 ✓（千刃每刀、技能主伤害）
- 被闪避 ✗、反射伤害 ✗、持续伤害 dot ✗
- 驱散数量 = NumberOfDispels

---

# 五、风险与副作用清单（改前必读）

## 4.1 必远古 → 铁匠合成/合成任务卡死 ⚠️（当前最大坑）

- **现象**：`GenerationDistribution.GetGrade()` 改 return Ancient 后，铁匠合成无法进行 → 合成类任务（ItemCombined 事件）卡死。
- **根因**：`BuildingExtensions.IsCombineable` 硬条件 `items.Any(i => i.ItemGrade != Ancient)`（三件至少一件非远古）——全远古断供；且全远古时最低品质=Ancient(5)，`num=(int)(5+1)=6`，原判定 `num<5 || num==5` 两层全卡（光删 Any 不够）。
- **完整解法 3 处**（源码 `BuildingExtensions.cs` 有标注，含 IL 改法）：
  1. `IsCombineable`：删 Any(非远古) 条件 + num 判定 `5→6`
  2. `CalculateCombineResult`：num2 判定同款（含大量 LINQ，只能 Edit Method Body 改 IL）
  3. 产出品质：`(QualityGrade)num2` cast 越界（6 无枚举值）→ IL 固定传 Ancient
- **当前状态**：**该修复方案已废弃**（老板拍板回滚，未找出"点合成无反应"根因——卡在 QuickMake 链路，无日志可查）。老板 dnSpy 需自行还原的合成改动共 6 处：`IsCombineable`（Any 条件 / num 5→6 / forge≥2→≥1）、`CalculateCombineResult`（num2 判定 + v2 分支）、`GetListByFurnaceTab`（品质过滤删除）、`SelectItem`（<Ancient→item!=null）、`UpdateItems`（grade 封顶）。
- **结论**：要合成就别开必远古；开了就别指望合成任务。

## 4.2 技能上限相关

| 风险 | 说明 | 对策 |
|---|---|---|
| **UI 崩溃（双 9 坑）** | GetMaxLevel 改 99 后 LevelBar 传 99 → `ColorPicker.GetGradientColor` 只认 3/9 直接抛异常，学院打不开 | 必须同步改 3.2 |
| **主动技能白嫖** | Active ≥3 级 `GetLevelUpgradeCost` 返回空列表 → 升级条件对空集合为 true → 免费升级 | 可接受则不管；不可接受需另改成本逻辑 |
| **档位制不涨** | 技能效果多为 `if(Level==1/2) else 兜底`，超档后效果不再涨；线性公式的（如奥术）才随等级涨 | 改数值时认准线性公式技能 |
| **int 溢出** | 上限别填 int.MaxValue：升级成本 `(level-5)*12000` int 乘法，约 17.9 万级时溢出变负 | 建议 99~200 |

## 4.3 通用

- **旧数据不追溯**：已生成的居民/存档数值定死，改代码只影响新生成（招募、掉落）。
- **Edit Method (C#) 遇 LINQ 必炸**：含 LINQ/lambda 的方法只能 Edit Method Body 改 IL，否则 Invalid token `'<'`（见第 0 章）。
- **必远古副作用扩散**：全远古下居民品质判定、合成、任务事件（ItemCombined）等链路都会受影响，改前想清楚。

---

# 附录：修改点速查（源码标注位置）

| 分类 | 功能 | 类/方法 | 标注 commit |
|---|---|---|---|
| 掉落 | 宝石掉落 25 | `DifficultyLevelMeasurement.GetGemLevel` | 87d96ec |
| 居民 | 槽位上限 30→127 | `PlayerProfile.MaxResidentSlot` | 本次 v3 补标 |
| 居民 | buff 上限族 6 条 | `PlayerProfile` 静态构造 | a90e179 |
| 居民 | 品质系数区间 | `ResidentsExtensions.CreateResidentByQuality` | 30c7308 |
| 居民 | 6 个 effect 查表基准 | `ArmorSale/WeaponSale/Production/Luck/Practice/DivineHeartResidentEffect` | 30c7308 |
| 居民 | 必远古 | `GenerationDistribution.GetGrade` | 本次 v3 补标 |
| 技能 | 等级上限 | `SkillLogicBase.GetMaxLevel` | e746690→421d38f |
| 技能 | UI 封顶 | `LevelBarController.Init` + `ColorPicker.GetGradientColor` | 3bc6ca2→0327d89 |
| 装备 | 饰品镶宝石（插槽生成） | `ItemExtensions.SocketGenerations` | 本次 v4 补标 |
| 装备 | 饰品镶宝石（可镶判定） | `Item.GetSocketableGems` | 本次 v4 补标 |
| 合成 | 卡合成警示（已废弃方案） | `BuildingExtensions.IsCombineable` | 92a79be→ea7c976 |
| 教程 | 本文件 | `change.md` | 54471ad→2dbb4ad（v3 重排，v4 加装备类） |
