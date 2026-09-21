using System;

// Token: 0x02000806 RID: 2054
[Serializable]
public class FirstHandEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003B64 RID: 15204 RVA: 0x00179993 File Offset: 0x00177D93
	public FirstHandEffectData()
	{
	}

	// Token: 0x06003B65 RID: 15205 RVA: 0x0017999B File Offset: 0x00177D9B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B66 RID: 15206 RVA: 0x001799BB File Offset: 0x00177DBB
	public double GetEffectPowerValue()
	{
		return Math.Abs(this.StartProgress);
	}

	// Token: 0x06003B67 RID: 15207 RVA: 0x001799C8 File Offset: 0x00177DC8
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FirstHand;
	}

	// Token: 0x06003B68 RID: 15208 RVA: 0x001799CC File Offset: 0x00177DCC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.StartProgress.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002DA8 RID: 11688
	public double StartProgress;

	// Token: 0x04002DA9 RID: 11689
	public bool? IsStarEf;
}
