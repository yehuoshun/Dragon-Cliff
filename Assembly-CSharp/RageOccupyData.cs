using System;

// Token: 0x0200084C RID: 2124
[Serializable]
public class RageOccupyData : ISpecialEffectDataLoad
{
	// Token: 0x06003CBB RID: 15547 RVA: 0x0017BF07 File Offset: 0x0017A307
	public RageOccupyData()
	{
	}

	// Token: 0x06003CBC RID: 15548 RVA: 0x0017BF0F File Offset: 0x0017A30F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RageOccupy;
	}

	// Token: 0x06003CBD RID: 15549 RVA: 0x0017BF18 File Offset: 0x0017A318
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Volum.ToExpression());
		return description;
	}

	// Token: 0x06003CBE RID: 15550 RVA: 0x0017BF53 File Offset: 0x0017A353
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003CBF RID: 15551 RVA: 0x0017BF56 File Offset: 0x0017A356
	public double GetEffectPowerValue()
	{
		return 1.0 / (1.0 + Math.Abs(this.Volum));
	}

	// Token: 0x04002E68 RID: 11880
	public double Volum;
}
