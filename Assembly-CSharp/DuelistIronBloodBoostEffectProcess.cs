using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008D5 RID: 2261
public class DuelistIronBloodBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F77 RID: 16247 RVA: 0x00191551 File Offset: 0x0018F951
	public DuelistIronBloodBoostEffectProcess()
	{
	}

	// Token: 0x17000B6C RID: 2924
	// (get) Token: 0x06003F78 RID: 16248 RVA: 0x00191559 File Offset: 0x0018F959
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DuelistIronBloodBoost;
		}
	}

	// Token: 0x17000B6D RID: 2925
	// (get) Token: 0x06003F79 RID: 16249 RVA: 0x00191560 File Offset: 0x0018F960
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x06003F7A RID: 16250 RVA: 0x00191567 File Offset: 0x0018F967
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 50 && (itemType.GetResourceCategory().IsMeleeWeapon() || itemType.GetResourceCategory().IsMeleeArmor());
	}

	// Token: 0x06003F7B RID: 16251 RVA: 0x00191594 File Offset: 0x0018F994
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DuelistIronBloodBoostData
				{
					IsStar = true,
					DamageReflectionRate = (double)UnityEngine.Random.Range(1.5f, 2.2f),
					ResilienceRate = (double)UnityEngine.Random.Range(0.2f, 0.5f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DuelistIronBloodBoostData
			{
				IsStar = true,
				DamageReflectionRate = (double)UnityEngine.Random.Range(2.2f, 2.5f),
				ResilienceRate = (double)UnityEngine.Random.Range(0.5f, 0.6f)
			}
		};
	}
}
