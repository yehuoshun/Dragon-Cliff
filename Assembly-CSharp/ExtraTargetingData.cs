using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020007FD RID: 2045
[Serializable]
public class ExtraTargetingData : ISpecialEffectDataLoad
{
	// Token: 0x06003B36 RID: 15158 RVA: 0x001794C6 File Offset: 0x001778C6
	public ExtraTargetingData()
	{
	}

	// Token: 0x06003B37 RID: 15159 RVA: 0x001794CE File Offset: 0x001778CE
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B38 RID: 15160 RVA: 0x001794EE File Offset: 0x001778EE
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.CandidateTypes.Count) * (1.0 + (double)this.Extra);
	}

	// Token: 0x06003B39 RID: 15161 RVA: 0x00179518 File Offset: 0x00177918
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ExtraTargetting;
	}

	// Token: 0x06003B3A RID: 15162 RVA: 0x0017951C File Offset: 0x0017791C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{types}", string.Join(", ", (from t in this.CandidateTypes
		select t.GetDescription().Title).Distinct<string>().ToArray<string>())).Replace("{number}", this.Extra.ToString()).ToString();
		return description;
	}

	// Token: 0x06003B3B RID: 15163 RVA: 0x001795A8 File Offset: 0x001779A8
	[CompilerGenerated]
	private static string <GetDescription>m__0(TargetCandidateType t)
	{
		return t.GetDescription().Title;
	}

	// Token: 0x04002D90 RID: 11664
	public List<TargetCandidateType> CandidateTypes;

	// Token: 0x04002D91 RID: 11665
	public int Extra;

	// Token: 0x04002D92 RID: 11666
	public bool? IsStarEf;

	// Token: 0x04002D93 RID: 11667
	[CompilerGenerated]
	private static Func<TargetCandidateType, string> <>f__am$cache0;
}
