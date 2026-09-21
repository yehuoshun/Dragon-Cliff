using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000929 RID: 2345
public class StarfallEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040F1 RID: 16625 RVA: 0x001A591C File Offset: 0x001A3D1C
	public StarfallEffectProcess()
	{
	}

	// Token: 0x17000C11 RID: 3089
	// (get) Token: 0x060040F2 RID: 16626 RVA: 0x001A5924 File Offset: 0x001A3D24
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Starfall;
		}
	}

	// Token: 0x17000C12 RID: 3090
	// (get) Token: 0x060040F3 RID: 16627 RVA: 0x001A5927 File Offset: 0x001A3D27
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x060040F4 RID: 16628 RVA: 0x001A592E File Offset: 0x001A3D2E
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x060040F5 RID: 16629 RVA: 0x001A5934 File Offset: 0x001A3D34
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.6,
				DamageType = allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)],
				DamagePercentage = 2.5 * (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f)),
				IsStarEf = new bool?(false)
			}
		};
	}
}
