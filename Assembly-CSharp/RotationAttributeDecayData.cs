using System;

// Token: 0x02000856 RID: 2134
[Serializable]
public class RotationAttributeDecayData : ISpecialEffectDataLoad
{
	// Token: 0x06003CED RID: 15597 RVA: 0x0017C3D5 File Offset: 0x0017A7D5
	public RotationAttributeDecayData()
	{
	}

	// Token: 0x06003CEE RID: 15598 RVA: 0x0017C3DD File Offset: 0x0017A7DD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RotationAttributeDecay;
	}

	// Token: 0x06003CEF RID: 15599 RVA: 0x0017C3E4 File Offset: 0x0017A7E4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{rate}", (this.ModificationType != ModificationType.Multiplication && !this.Type.IsPercentageValue()) ? this.Value.ToExpression() : (this.Value.ToExpressionMultiply100() + "%")).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003CF0 RID: 15600 RVA: 0x0017C48A File Offset: 0x0017A88A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CF1 RID: 15601 RVA: 0x0017C492 File Offset: 0x0017A892
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x04002E80 RID: 11904
	public AttributeType Type;

	// Token: 0x04002E81 RID: 11905
	public double Value;

	// Token: 0x04002E82 RID: 11906
	public ModificationType ModificationType;

	// Token: 0x04002E83 RID: 11907
	public int Seconds;

	// Token: 0x04002E84 RID: 11908
	public bool IsStar;
}
