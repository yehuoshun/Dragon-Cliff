using System;

// Token: 0x02000877 RID: 2167
[Serializable]
public class SnowMaideEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003DBD RID: 15805 RVA: 0x0018134D File Offset: 0x0017F74D
	public SnowMaideEnhancementData()
	{
	}

	// Token: 0x06003DBE RID: 15806 RVA: 0x00181355 File Offset: 0x0017F755
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SnowMaideEnhancement;
	}

	// Token: 0x06003DBF RID: 15807 RVA: 0x0018135C File Offset: 0x0017F75C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.Seconds.ToExpression());
		return description;
	}

	// Token: 0x06003DC0 RID: 15808 RVA: 0x00181397 File Offset: 0x0017F797
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DC1 RID: 15809 RVA: 0x0018139F File Offset: 0x0017F79F
	public double GetEffectPowerValue()
	{
		return this.Seconds;
	}

	// Token: 0x04002ED1 RID: 11985
	public double Seconds;

	// Token: 0x04002ED2 RID: 11986
	public bool IsStar;
}
