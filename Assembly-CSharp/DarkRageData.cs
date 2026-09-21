using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020007D6 RID: 2006
[Serializable]
public class DarkRageData : ISpecialEffectDataLoad
{
	// Token: 0x06003A70 RID: 14960 RVA: 0x00177EC6 File Offset: 0x001762C6
	public DarkRageData()
	{
	}

	// Token: 0x06003A71 RID: 14961 RVA: 0x00177ECE File Offset: 0x001762CE
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A72 RID: 14962 RVA: 0x00177EEE File Offset: 0x001762EE
	public double GetEffectPowerValue()
	{
		return this.ChargeRate;
	}

	// Token: 0x06003A73 RID: 14963 RVA: 0x00177EF6 File Offset: 0x001762F6
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DarkKnightRage;
	}

	// Token: 0x06003A74 RID: 14964 RVA: 0x00177EFC File Offset: 0x001762FC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{rate}", this.ChargeRate.ToExpressionMultiply100()).Replace("{attributes}", string.Join(", ", (from a in this.ChargeAttributeTypes
		select a.GetDescription().Title).ToArray<string>())).ToString();
		return description;
	}

	// Token: 0x06003A75 RID: 14965 RVA: 0x00177F7D File Offset: 0x0017637D
	[CompilerGenerated]
	private static string <GetDescription>m__0(AttributeType a)
	{
		return a.GetDescription().Title;
	}

	// Token: 0x04002D0B RID: 11531
	public List<AttributeType> ChargeAttributeTypes;

	// Token: 0x04002D0C RID: 11532
	public double ChargeRate;

	// Token: 0x04002D0D RID: 11533
	public bool? IsStarEf;

	// Token: 0x04002D0E RID: 11534
	[CompilerGenerated]
	private static Func<AttributeType, string> <>f__am$cache0;
}
