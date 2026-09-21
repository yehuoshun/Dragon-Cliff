using System;

// Token: 0x02000845 RID: 2117
[Serializable]
public class BoostSetting
{
	// Token: 0x06003C9B RID: 15515 RVA: 0x0017BB76 File Offset: 0x00179F76
	public BoostSetting()
	{
	}

	// Token: 0x06003C9C RID: 15516 RVA: 0x0017BB80 File Offset: 0x00179F80
	public string GetDescription()
	{
		if (this.BoostValue > 0.0)
		{
			if (this.BoostAttribute.IsPercentageValue())
			{
				return this.BoostAttribute.GetDescription().Title + "+" + this.BoostValue.ToExpressionMultiply100() + "%";
			}
			return this.BoostAttribute.GetDescription().Title + "+" + this.BoostValue.ToExpression();
		}
		else
		{
			if (this.BoostAttribute.IsPercentageValue())
			{
				return this.BoostAttribute.GetDescription().Title + this.BoostValue.ToExpressionMultiply100() + "%";
			}
			return this.BoostAttribute.GetDescription().Title + this.BoostValue.ToExpression();
		}
	}

	// Token: 0x04002E58 RID: 11864
	public AttributeType BoostAttribute;

	// Token: 0x04002E59 RID: 11865
	public double BoostValue;
}
