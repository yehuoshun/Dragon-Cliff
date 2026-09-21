using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000878 RID: 2168
[Serializable]
public class SoulCollectionData : ISpecialEffectDataLoad
{
	// Token: 0x06003DC2 RID: 15810 RVA: 0x001813A7 File Offset: 0x0017F7A7
	public SoulCollectionData()
	{
	}

	// Token: 0x06003DC3 RID: 15811 RVA: 0x001813AF File Offset: 0x0017F7AF
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003DC4 RID: 15812 RVA: 0x001813CF File Offset: 0x0017F7CF
	public double GetEffectPowerValue()
	{
		return (1.0 + this.IncreaseAmount) * ((double)this.BoostTypes.Count + 1.0);
	}

	// Token: 0x06003DC5 RID: 15813 RVA: 0x001813F8 File Offset: 0x0017F7F8
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SoulCollection;
	}

	// Token: 0x06003DC6 RID: 15814 RVA: 0x001813FC File Offset: 0x0017F7FC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{increase}", this.IncreaseAmount.DoubleToString()).Replace("{boosttypes}", string.Join(", ", (from b in this.BoostTypes
		select b.GetDescription().Title).Distinct<string>().ToArray<string>())).ToString();
		return description;
	}

	// Token: 0x06003DC7 RID: 15815 RVA: 0x00181482 File Offset: 0x0017F882
	[CompilerGenerated]
	private static string <GetDescription>m__0(BoostType b)
	{
		return b.GetDescription().Title;
	}

	// Token: 0x04002ED3 RID: 11987
	public double IncreaseAmount;

	// Token: 0x04002ED4 RID: 11988
	public List<BoostType> BoostTypes;

	// Token: 0x04002ED5 RID: 11989
	public bool? IsStarEf;

	// Token: 0x04002ED6 RID: 11990
	[CompilerGenerated]
	private static Func<BoostType, string> <>f__am$cache0;
}
