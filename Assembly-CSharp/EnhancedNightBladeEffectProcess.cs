using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008DC RID: 2268
public class EnhancedNightBladeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F96 RID: 16278 RVA: 0x00192856 File Offset: 0x00190C56
	public EnhancedNightBladeEffectProcess()
	{
	}

	// Token: 0x06003F97 RID: 16279 RVA: 0x00192874 File Offset: 0x00190C74
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		return resourceCategory.IsMeleeWeapon() || resourceCategory.IsMeleeArmor();
	}

	// Token: 0x06003F98 RID: 16280 RVA: 0x001928A4 File Offset: 0x00190CA4
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new NightBladeEnhancementData
				{
					DamageRate = (double)UnityEngine.Random.Range(1f, 2f),
					EffectHitRating = (double)UnityEngine.Random.Range(200, 400),
					EffectHitDecayRate = (double)UnityEngine.Random.Range(0.3f, 0.5f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new NightBladeEnhancementData
			{
				DamageRate = (double)UnityEngine.Random.Range(2f, 2.5f),
				EffectHitRating = (double)UnityEngine.Random.Range(300, 400),
				EffectHitDecayRate = (double)UnityEngine.Random.Range(0.4f, 0.5f)
			}
		};
	}

	// Token: 0x17000B7A RID: 2938
	// (get) Token: 0x06003F99 RID: 16281 RVA: 0x00192972 File Offset: 0x00190D72
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B7B RID: 2939
	// (get) Token: 0x06003F9A RID: 16282 RVA: 0x0019297A File Offset: 0x00190D7A
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x04002F85 RID: 12165
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.EnhancedNightBlade;

	// Token: 0x04002F86 RID: 12166
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>();
}
