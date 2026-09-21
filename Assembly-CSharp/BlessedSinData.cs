using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020007BA RID: 1978
[Serializable]
public class BlessedSinData : ISpecialEffectDataLoad
{
	// Token: 0x060039E2 RID: 14818 RVA: 0x00177186 File Offset: 0x00175586
	public BlessedSinData()
	{
	}

	// Token: 0x060039E3 RID: 14819 RVA: 0x0017718E File Offset: 0x0017558E
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x060039E4 RID: 14820 RVA: 0x001771AE File Offset: 0x001755AE
	public double GetEffectPowerValue()
	{
		return this.LifeOnHitRate + this.DamagePerSecondPerType;
	}

	// Token: 0x060039E5 RID: 14821 RVA: 0x001771BD File Offset: 0x001755BD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BlessedSinEffect;
	}

	// Token: 0x060039E6 RID: 14822 RVA: 0x001771C4 File Offset: 0x001755C4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{hithealrate}", this.LifeOnHitRate.ToExpressionMultiply100()).Replace("{damage}", this.DamagePerSecondPerType.DoubleToString()).Replace("{damagetypes}", string.Join(", ", (from d in this.DamageTypes
		select d.GetDescription().Title.Replace(" Damage", string.Empty).Replace("伤害", string.Empty)).ToArray<string>())).ToString();
		return description;
	}

	// Token: 0x060039E7 RID: 14823 RVA: 0x0017725A File Offset: 0x0017565A
	[CompilerGenerated]
	private static string <GetDescription>m__0(OutputType d)
	{
		return d.GetDescription().Title.Replace(" Damage", string.Empty).Replace("伤害", string.Empty);
	}

	// Token: 0x04002CC2 RID: 11458
	public double LifeOnHitRate;

	// Token: 0x04002CC3 RID: 11459
	public double DamagePerSecondPerType;

	// Token: 0x04002CC4 RID: 11460
	public List<OutputType> DamageTypes;

	// Token: 0x04002CC5 RID: 11461
	public bool? IsStarEf;

	// Token: 0x04002CC6 RID: 11462
	[CompilerGenerated]
	private static Func<OutputType, string> <>f__am$cache0;
}
