using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020007C4 RID: 1988
[Serializable]
public class ChargeData : ISpecialEffectDataLoad
{
	// Token: 0x06003A15 RID: 14869 RVA: 0x0017765F File Offset: 0x00175A5F
	public ChargeData()
	{
	}

	// Token: 0x06003A16 RID: 14870 RVA: 0x00177667 File Offset: 0x00175A67
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A17 RID: 14871 RVA: 0x00177687 File Offset: 0x00175A87
	public double GetEffectPowerValue()
	{
		return this.ChargeCap;
	}

	// Token: 0x06003A18 RID: 14872 RVA: 0x0017768F File Offset: 0x00175A8F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Charge;
	}

	// Token: 0x06003A19 RID: 14873 RVA: 0x00177694 File Offset: 0x00175A94
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{damagetypes}", string.Join(", ", (from t in this.ChargingDamageTypes
		select t.GetDescription().Title).Distinct<string>().ToArray<string>())).Replace("{max}", this.ChargeCap.ToExpression()).Replace("{boosttype}", this.BoostAttributeType.GetDescription().Title).ToString();
		return description;
	}

	// Token: 0x06003A1A RID: 14874 RVA: 0x00177734 File Offset: 0x00175B34
	[CompilerGenerated]
	private static string <GetDescription>m__0(OutputType t)
	{
		return t.GetDescription().Title;
	}

	// Token: 0x04002CDE RID: 11486
	public List<OutputType> ChargingDamageTypes;

	// Token: 0x04002CDF RID: 11487
	public double ChargeCap;

	// Token: 0x04002CE0 RID: 11488
	public AttributeType BoostAttributeType;

	// Token: 0x04002CE1 RID: 11489
	public bool? IsStarEf;

	// Token: 0x04002CE2 RID: 11490
	[CompilerGenerated]
	private static Func<OutputType, string> <>f__am$cache0;
}
