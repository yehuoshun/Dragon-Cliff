using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008EE RID: 2286
public class GhostSmokeBoostProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FE3 RID: 16355 RVA: 0x00196AA8 File Offset: 0x00194EA8
	public GhostSmokeBoostProcess()
	{
	}

	// Token: 0x17000B9E RID: 2974
	// (get) Token: 0x06003FE4 RID: 16356 RVA: 0x00196AB0 File Offset: 0x00194EB0
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.GhostSmokeBoost;
		}
	}

	// Token: 0x17000B9F RID: 2975
	// (get) Token: 0x06003FE5 RID: 16357 RVA: 0x00196AB7 File Offset: 0x00194EB7
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x06003FE6 RID: 16358 RVA: 0x00196ABE File Offset: 0x00194EBE
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 55;
	}

	// Token: 0x06003FE7 RID: 16359 RVA: 0x00196ACC File Offset: 0x00194ECC
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new GhostSmokeBoostData
				{
					IsStar = true,
					Rate = (double)UnityEngine.Random.Range(0.2f, 0.5f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new GhostSmokeBoostData
			{
				IsStar = true,
				Rate = (double)UnityEngine.Random.Range(0.5f, 0.6f)
			}
		};
	}
}
