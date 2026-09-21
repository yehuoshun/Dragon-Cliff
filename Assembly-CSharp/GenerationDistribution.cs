using System;
using UnityEngine;

// Token: 0x020005E8 RID: 1512
[Serializable]
public class GenerationDistribution
{
	// Token: 0x060029BF RID: 10687 RVA: 0x0011C394 File Offset: 0x0011A794
	public GenerationDistribution(double rareChance, double epicChance, double legendaryChance, double ancientChance)
	{
		if (rareChance < 0.0 || legendaryChance < 0.0 || epicChance < 0.0 || ancientChance < 0.0)
		{
			throw new Exception("Invalid chance");
		}
		this.RareChance = rareChance;
		this.LegendaryChance = legendaryChance;
		this.EpicChance = epicChance;
		this.AncientChance = ancientChance;
	}

	// Token: 0x060029C0 RID: 10688 RVA: 0x0011C40C File Offset: 0x0011A80C
	public GenerationDistribution BoostDrop(double boostRate)
	{
		this.AncientChance *= 1.0 + boostRate;
		if (this.AncientChance < 0.0)
		{
			this.AncientChance = 0.0;
		}
		if (this.AncientChance > 1.0)
		{
			this.AncientChance = 1.0;
		}
		this.LegendaryChance *= 1.0 + boostRate;
		if (this.AncientChance + this.LegendaryChance > 1.0)
		{
			this.LegendaryChance = 1.0 - this.AncientChance;
		}
		this.EpicChance *= 1.0 + boostRate;
		if (this.EpicChance + this.AncientChance + this.LegendaryChance > 1.0)
		{
			this.EpicChance = 1.0 - this.AncientChance - this.LegendaryChance;
		}
		this.RareChance *= 1.0 + boostRate;
		if (this.EpicChance + this.AncientChance + this.LegendaryChance + this.RareChance > 1.0)
		{
			this.RareChance = 1.0 - this.AncientChance - this.LegendaryChance - this.EpicChance;
		}
		return this;
	}

	// Token: 0x060029C1 RID: 10689 RVA: 0x0011C580 File Offset: 0x0011A980
	public QualityGrade GetGrade()
	{
		float num = UnityEngine.Random.Range(0f, 1f);
		if ((double)num >= this.RareChance + this.LegendaryChance + this.EpicChance + this.AncientChance)
		{
			return QualityGrade.Normal;
		}
		if ((double)num >= this.LegendaryChance + this.EpicChance + this.AncientChance)
		{
			return QualityGrade.Rare;
		}
		if ((double)num >= this.LegendaryChance + this.AncientChance)
		{
			return QualityGrade.Epic;
		}
		if ((double)num >= this.AncientChance)
		{
			return QualityGrade.Legendary;
		}
		return QualityGrade.Ancient;
	}

	// Token: 0x060029C2 RID: 10690 RVA: 0x0011C604 File Offset: 0x0011AA04
	public GenerationDistribution Duplicate()
	{
		return new GenerationDistribution(this.RareChance, this.LegendaryChance, this.EpicChance, this.AncientChance);
	}

	// Token: 0x04002241 RID: 8769
	public double RareChance;

	// Token: 0x04002242 RID: 8770
	public double LegendaryChance;

	// Token: 0x04002243 RID: 8771
	public double EpicChance;

	// Token: 0x04002244 RID: 8772
	public double AncientChance;
}
