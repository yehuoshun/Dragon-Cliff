using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008CC RID: 2252
public class DevilSpellProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F51 RID: 16209 RVA: 0x0018F084 File Offset: 0x0018D484
	public DevilSpellProcess()
	{
	}

	// Token: 0x17000B5A RID: 2906
	// (get) Token: 0x06003F52 RID: 16210 RVA: 0x0018F08C File Offset: 0x0018D48C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DevilSpell;
		}
	}

	// Token: 0x17000B5B RID: 2907
	// (get) Token: 0x06003F53 RID: 16211 RVA: 0x0018F093 File Offset: 0x0018D493
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x06003F54 RID: 16212 RVA: 0x0018F09A File Offset: 0x0018D49A
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 55 && itemType.GetResourceCategory().IsWeapon();
	}

	// Token: 0x06003F55 RID: 16213 RVA: 0x0018F0B8 File Offset: 0x0018D4B8
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DevilSpellData
				{
					IsStar = true,
					Rate = (double)UnityEngine.Random.Range(0.5f, 0.8f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DevilSpellData
			{
				IsStar = true,
				Rate = (double)UnityEngine.Random.Range(0.8f, 1f)
			}
		};
	}
}
