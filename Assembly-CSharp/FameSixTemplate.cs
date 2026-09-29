using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000553 RID: 1363
public class FameSixTemplate : AccessoryTemplateBase
{
	// Token: 0x06002779 RID: 10105 RVA: 0x00118B6A File Offset: 0x00116F6A
	public FameSixTemplate()
	{
	}

	// Token: 0x17000339 RID: 825
	// (get) Token: 0x0600277A RID: 10106 RVA: 0x00118B72 File Offset: 0x00116F72
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameSix;
		}
	}

	// Token: 0x0600277B RID: 10107 RVA: 0x00118B7C File Offset: 0x00116F7C
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

	// Token: 0x0600277C RID: 10108 RVA: 0x00118BC0 File Offset: 0x00116FC0
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 800.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 800.0)
		};
	}

	// Token: 0x1700033A RID: 826
	// (get) Token: 0x0600277D RID: 10109 RVA: 0x00118BFE File Offset: 0x00116FFE
	public override int ItemTierNumber
	{
		get
		{
			return 45;
		}
	}
}
