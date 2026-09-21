using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public abstract class ResidentBase : IPresentable
{
	// Token: 0x0600262E RID: 9774 RVA: 0x00111DA4 File Offset: 0x001101A4
	protected ResidentBase()
	{
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x0600262F RID: 9775
	public abstract ResidentType ResidentType { get; }

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06002630 RID: 9776
	public abstract int ResidentRankParameter { get; }

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06002631 RID: 9777
	public abstract List<JourneyContributeType> JourneyContributeTypes { get; }

	// Token: 0x06002632 RID: 9778 RVA: 0x00111DAC File Offset: 0x001101AC
	public double GetHappyChance(Resident resident)
	{
		if (resident.Grade <= QualityGrade.Epic)
		{
			return 0.5;
		}
		if (resident.Grade <= QualityGrade.Legendary)
		{
			return 0.75;
		}
		return 1.0;
	}

	// Token: 0x06002633 RID: 9779 RVA: 0x00111DE3 File Offset: 0x001101E3
	public void TriggerHappyState(Resident resident)
	{
		if ((double)UnityEngine.Random.value <= this.GetHappyChance(resident))
		{
			this.GenerateHappyEffect(resident);
		}
	}

	// Token: 0x06002634 RID: 9780 RVA: 0x00111E00 File Offset: 0x00110200
	protected int GetStandardizedEffectLastingDays()
	{
		return UnityEngine.Random.Range(6, 11);
	}

	// Token: 0x06002635 RID: 9781
	protected abstract void GenerateHappyEffect(Resident resident);

	// Token: 0x06002636 RID: 9782 RVA: 0x00111E18 File Offset: 0x00110218
	public List<JourneyContributionModifier> GenerateJourneyContributions(DifficultyLevelMeasurement measurement, QualityGrade grade)
	{
		Dictionary<QualityGrade, double> dictionary = new Dictionary<QualityGrade, double>
		{
			{
				QualityGrade.Normal,
				0.6
			},
			{
				QualityGrade.Rare,
				0.7
			},
			{
				QualityGrade.Epic,
				0.8
			},
			{
				QualityGrade.Legendary,
				0.9
			},
			{
				QualityGrade.Ancient,
				1.0
			}
		};
		List<JourneyContributeType> journeyContributeTypes = this.JourneyContributeTypes;
		double num = 1.0 / Convert.ToDouble(journeyContributeTypes.Count);
		double ratio = dictionary[grade] * num;
		List<JourneyContributionModifier> list = new List<JourneyContributionModifier>();
		foreach (JourneyContributeType type in journeyContributeTypes)
		{
			list.AddRange(type.GetGenerator().Generate(measurement, ratio));
		}
		return list;
	}

	// Token: 0x06002637 RID: 9783 RVA: 0x00111F0C File Offset: 0x0011030C
	public virtual List<IResidentEffect> GetEffects(DifficultyLevelMeasurement correspondingDifficultyMeasurement, double growthCoeffecient)
	{
		return new List<IResidentEffect>();
	}

	// Token: 0x06002638 RID: 9784 RVA: 0x00111F13 File Offset: 0x00110313
	public virtual int GetPresence()
	{
		return 100;
	}

	// Token: 0x06002639 RID: 9785 RVA: 0x00111F17 File Offset: 0x00110317
	// Note: this type is marked as 'beforefieldinit'.
	static ResidentBase()
	{
	}

	// Token: 0x040020C2 RID: 8386
	public static double EpicResidentCoefficient = 1.6;
}
