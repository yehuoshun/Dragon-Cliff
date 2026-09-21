using System;

// Token: 0x02000857 RID: 2135
[Serializable]
public class RotationDispelEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003CF2 RID: 15602 RVA: 0x0017C49A File Offset: 0x0017A89A
	public RotationDispelEnhancementData()
	{
	}

	// Token: 0x06003CF3 RID: 15603 RVA: 0x0017C4A2 File Offset: 0x0017A8A2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RotationDispelEnhancement;
	}

	// Token: 0x06003CF4 RID: 15604 RVA: 0x0017C4AC File Offset: 0x0017A8AC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003CF5 RID: 15605 RVA: 0x0017C4ED File Offset: 0x0017A8ED
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CF6 RID: 15606 RVA: 0x0017C4F5 File Offset: 0x0017A8F5
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002E85 RID: 11909
	public int NumberOfDispels;

	// Token: 0x04002E86 RID: 11910
	public bool IsStar;
}
