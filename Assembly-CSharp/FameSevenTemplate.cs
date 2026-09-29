using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000552 RID: 1362
public class FameSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002774 RID: 10100 RVA: 0x00118AD5 File Offset: 0x00116ED5
	public FameSevenTemplate()
	{
	}

	// Token: 0x17000337 RID: 823
	// (get) Token: 0x06002775 RID: 10101 RVA: 0x00118ADD File Offset: 0x00116EDD
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameSeven;
		}
	}

	// Token: 0x06002776 RID: 10102 RVA: 0x00118AE4 File Offset: 0x00116EE4
	// ==================== MOD 标记 2026-09-30 ====================
	// 【荣光(Fame)饰品星辰特效·已改待测试】命中 100% 驱散敌方增益。
	// 原版 Random.Range(1,3) 是 int 上界排他 → 实际驱散 1~2 个。
	// 已改为固定数量（见方法体），Edit Method (C#) 可直接改（无 lambda）。
	// 触发条件（DispelOnHitProcess）：命中(!IsMissed) + 直接伤害(IsDirectDamage)；
	//   被闪避/反射/dot 不触发。详见 change.md §4.2。
	// =============================================================
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

	// Token: 0x06002777 RID: 10103 RVA: 0x00118B28 File Offset: 0x00116F28
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 1000.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 1000.0)
		};
	}

	// Token: 0x17000338 RID: 824
	// (get) Token: 0x06002778 RID: 10104 RVA: 0x00118B66 File Offset: 0x00116F66
	public override int ItemTierNumber
	{
		get
		{
			return 53;
		}
	}
}
