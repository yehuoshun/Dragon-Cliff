using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008DB RID: 2267
public class EnhancedChubbyLadyEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F91 RID: 16273 RVA: 0x0019275B File Offset: 0x00190B5B
	public EnhancedChubbyLadyEffectProcess()
	{
	}

	// Token: 0x17000B78 RID: 2936
	// (get) Token: 0x06003F92 RID: 16274 RVA: 0x00192779 File Offset: 0x00190B79
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B79 RID: 2937
	// (get) Token: 0x06003F93 RID: 16275 RVA: 0x00192781 File Offset: 0x00190B81
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003F94 RID: 16276 RVA: 0x0019278C File Offset: 0x00190B8C
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		return resourceCategory.IsMeleeWeapon() || resourceCategory.IsMeleeArmor();
	}

	// Token: 0x06003F95 RID: 16277 RVA: 0x001927B4 File Offset: 0x00190BB4
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new EnhancedChubbyLadyData
				{
					DamageRate = (double)UnityEngine.Random.Range(1f, 1.5f),
					ShieldBoost = (double)UnityEngine.Random.Range(1f, 2.5f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new EnhancedChubbyLadyData
			{
				DamageRate = (double)UnityEngine.Random.Range(1.5f, 2f),
				ShieldBoost = (double)UnityEngine.Random.Range(2.5f, 3f)
			}
		};
	}

	// Token: 0x04002F83 RID: 12163
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.EnhancedChubbyLady;

	// Token: 0x04002F84 RID: 12164
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>();
}
