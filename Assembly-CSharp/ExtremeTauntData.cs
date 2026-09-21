using System;

// Token: 0x020007FE RID: 2046
[Serializable]
public class ExtremeTauntData : ISpecialEffectDataLoad
{
	// Token: 0x06003B3C RID: 15164 RVA: 0x001795B5 File Offset: 0x001779B5
	public ExtremeTauntData()
	{
	}

	// Token: 0x06003B3D RID: 15165 RVA: 0x001795BD File Offset: 0x001779BD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ExtremeTaunt;
	}

	// Token: 0x06003B3E RID: 15166 RVA: 0x001795C4 File Offset: 0x001779C4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.TauntSeconds.ToString());
		return description;
	}

	// Token: 0x06003B3F RID: 15167 RVA: 0x00179605 File Offset: 0x00177A05
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B40 RID: 15168 RVA: 0x0017960D File Offset: 0x00177A0D
	public double GetEffectPowerValue()
	{
		return (double)this.TauntSeconds;
	}

	// Token: 0x04002D94 RID: 11668
	public bool IsStar;

	// Token: 0x04002D95 RID: 11669
	public int TauntSeconds;
}
