using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020007B5 RID: 1973
[Serializable]
public class AttributeBoostData : ISpecialEffectDataLoad
{
	// Token: 0x060039C5 RID: 14789 RVA: 0x00176CF3 File Offset: 0x001750F3
	public AttributeBoostData()
	{
	}

	// Token: 0x060039C6 RID: 14790 RVA: 0x00176CFB File Offset: 0x001750FB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AttributeBoostOnStart;
	}

	// Token: 0x060039C7 RID: 14791 RVA: 0x00176D00 File Offset: 0x00175100
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		string text = string.Empty;
		if (this.AdditionBoosts.Any<BoostSetting>())
		{
			text += string.Join(", ", (from b in this.AdditionBoosts
			select b.BoostAttribute.GetDescription().Title + "+" + ((!b.BoostAttribute.IsPercentageValue()) ? b.BoostValue.ToExpression() : (b.BoostValue.ToExpressionMultiply100() + "%"))).ToArray<string>());
			if (this.MultiplicationBoosts.Any<BoostSetting>())
			{
				text += ",";
			}
		}
		if (this.MultiplicationBoosts.Any<BoostSetting>())
		{
			text += string.Join(", ", (from b in this.MultiplicationBoosts
			select b.BoostAttribute.GetDescription().Title + "+" + b.BoostValue.ToExpressionMultiply100() + "%").ToArray<string>());
		}
		description.Details1 = description.Details1.Replace("{boosts}", text);
		return description;
	}

	// Token: 0x060039C8 RID: 14792 RVA: 0x00176DEF File Offset: 0x001751EF
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039C9 RID: 14793 RVA: 0x00176DF8 File Offset: 0x001751F8
	public double GetEffectPowerValue()
	{
		return this.AdditionBoosts.Sum((BoostSetting b) => b.BoostValue) + this.MultiplicationBoosts.Sum((BoostSetting b) => b.BoostValue);
	}

	// Token: 0x060039CA RID: 14794 RVA: 0x00176E58 File Offset: 0x00175258
	[CompilerGenerated]
	private static string <GetDescription>m__0(BoostSetting b)
	{
		return b.BoostAttribute.GetDescription().Title + "+" + ((!b.BoostAttribute.IsPercentageValue()) ? b.BoostValue.ToExpression() : (b.BoostValue.ToExpressionMultiply100() + "%"));
	}

	// Token: 0x060039CB RID: 14795 RVA: 0x00176EB4 File Offset: 0x001752B4
	[CompilerGenerated]
	private static string <GetDescription>m__1(BoostSetting b)
	{
		return b.BoostAttribute.GetDescription().Title + "+" + b.BoostValue.ToExpressionMultiply100() + "%";
	}

	// Token: 0x060039CC RID: 14796 RVA: 0x00176EE0 File Offset: 0x001752E0
	[CompilerGenerated]
	private static double <GetEffectPowerValue>m__2(BoostSetting b)
	{
		return b.BoostValue;
	}

	// Token: 0x060039CD RID: 14797 RVA: 0x00176EE8 File Offset: 0x001752E8
	[CompilerGenerated]
	private static double <GetEffectPowerValue>m__3(BoostSetting b)
	{
		return b.BoostValue;
	}

	// Token: 0x04002CAB RID: 11435
	public List<BoostSetting> AdditionBoosts;

	// Token: 0x04002CAC RID: 11436
	public List<BoostSetting> MultiplicationBoosts;

	// Token: 0x04002CAD RID: 11437
	public bool IsStar;

	// Token: 0x04002CAE RID: 11438
	[CompilerGenerated]
	private static Func<BoostSetting, string> <>f__am$cache0;

	// Token: 0x04002CAF RID: 11439
	[CompilerGenerated]
	private static Func<BoostSetting, string> <>f__am$cache1;

	// Token: 0x04002CB0 RID: 11440
	[CompilerGenerated]
	private static Func<BoostSetting, double> <>f__am$cache2;

	// Token: 0x04002CB1 RID: 11441
	[CompilerGenerated]
	private static Func<BoostSetting, double> <>f__am$cache3;
}
