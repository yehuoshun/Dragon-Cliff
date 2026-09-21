using System;

// Token: 0x02000804 RID: 2052
[Serializable]
public class FieryTaleEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003B5A RID: 15194 RVA: 0x001798A2 File Offset: 0x00177CA2
	public FieryTaleEffectData()
	{
	}

	// Token: 0x06003B5B RID: 15195 RVA: 0x001798AA File Offset: 0x00177CAA
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B5C RID: 15196 RVA: 0x001798CA File Offset: 0x00177CCA
	public double GetEffectPowerValue()
	{
		return (double)(this.StartFires + this.FiresPerHit);
	}

	// Token: 0x06003B5D RID: 15197 RVA: 0x001798DA File Offset: 0x00177CDA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FieryTaleEffect;
	}

	// Token: 0x06003B5E RID: 15198 RVA: 0x001798E0 File Offset: 0x00177CE0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{start}", this.StartFires.ToString()).Replace("{perhit}", this.FiresPerHit.ToString());
		return description;
	}

	// Token: 0x04002DA3 RID: 11683
	public int StartFires;

	// Token: 0x04002DA4 RID: 11684
	public int FiresPerHit;

	// Token: 0x04002DA5 RID: 11685
	public bool? IsStarEf;
}
