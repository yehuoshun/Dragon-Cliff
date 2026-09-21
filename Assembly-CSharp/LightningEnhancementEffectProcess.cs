using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000903 RID: 2307
public class LightningEnhancementEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004042 RID: 16450 RVA: 0x0019D05C File Offset: 0x0019B45C
	public LightningEnhancementEffectProcess()
	{
	}

	// Token: 0x17000BC6 RID: 3014
	// (get) Token: 0x06004043 RID: 16451 RVA: 0x0019D064 File Offset: 0x0019B464
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LightningEnhancement;
		}
	}

	// Token: 0x17000BC7 RID: 3015
	// (get) Token: 0x06004044 RID: 16452 RVA: 0x0019D06B File Offset: 0x0019B46B
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x06004045 RID: 16453 RVA: 0x0019D072 File Offset: 0x0019B472
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06004046 RID: 16454 RVA: 0x0019D078 File Offset: 0x0019B478
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new LightningEnhancementData
				{
					IsStar = true,
					SpreadNumber = UnityEngine.Random.Range(1, 3)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new LightningEnhancementData
			{
				IsStar = true,
				SpreadNumber = 3
			}
		};
	}
}
