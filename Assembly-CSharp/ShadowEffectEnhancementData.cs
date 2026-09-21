using System;

// Token: 0x02000874 RID: 2164
[Serializable]
public class ShadowEffectEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003DAE RID: 15790 RVA: 0x001811D6 File Offset: 0x0017F5D6
	public ShadowEffectEnhancementData()
	{
	}

	// Token: 0x06003DAF RID: 15791 RVA: 0x001811DE File Offset: 0x0017F5DE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ShadowEffectEnhancement;
	}

	// Token: 0x06003DB0 RID: 15792 RVA: 0x001811E8 File Offset: 0x0017F5E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.AdditionalTargets.ToString());
		return description;
	}

	// Token: 0x06003DB1 RID: 15793 RVA: 0x00181229 File Offset: 0x0017F629
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DB2 RID: 15794 RVA: 0x00181231 File Offset: 0x0017F631
	public double GetEffectPowerValue()
	{
		return (double)this.AdditionalTargets;
	}

	// Token: 0x04002EC8 RID: 11976
	public int AdditionalTargets;

	// Token: 0x04002EC9 RID: 11977
	public bool IsStar;
}
