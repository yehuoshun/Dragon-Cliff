using System;

// Token: 0x020007D1 RID: 2001
[Serializable]
public class CrashExtraHitData : ISpecialEffectDataLoad
{
	// Token: 0x06003A57 RID: 14935 RVA: 0x00177C75 File Offset: 0x00176075
	public CrashExtraHitData()
	{
	}

	// Token: 0x06003A58 RID: 14936 RVA: 0x00177C7D File Offset: 0x0017607D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CrashExtraHit;
	}

	// Token: 0x06003A59 RID: 14937 RVA: 0x00177C84 File Offset: 0x00176084
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.Extra.ToString());
		return description;
	}

	// Token: 0x06003A5A RID: 14938 RVA: 0x00177CC5 File Offset: 0x001760C5
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A5B RID: 14939 RVA: 0x00177CCD File Offset: 0x001760CD
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002D00 RID: 11520
	public int Extra;

	// Token: 0x04002D01 RID: 11521
	public bool IsStar;
}
