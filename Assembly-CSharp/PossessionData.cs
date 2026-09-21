using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000844 RID: 2116
[Serializable]
public class PossessionData : ISpecialEffectDataLoad
{
	// Token: 0x06003C94 RID: 15508 RVA: 0x0017BA33 File Offset: 0x00179E33
	public PossessionData()
	{
	}

	// Token: 0x06003C95 RID: 15509 RVA: 0x0017BA3B File Offset: 0x00179E3B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C96 RID: 15510 RVA: 0x0017BA5C File Offset: 0x00179E5C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Boosts.Sum((BoostSetting b) => b.BoostValue)) * (1.0 + this.Chance);
	}

	// Token: 0x06003C97 RID: 15511 RVA: 0x0017BAAC File Offset: 0x00179EAC
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Possession;
	}

	// Token: 0x06003C98 RID: 15512 RVA: 0x0017BAB0 File Offset: 0x00179EB0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{eventtype}", this.TriggerEventType.GetDescription().Title).Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{boosts}", string.Join(", ", (from b in this.Boosts
		select b.GetDescription()).ToArray<string>())).Replace("{lastingturns}", this.LastingTurns.ToString()).ToString();
		return description;
	}

	// Token: 0x06003C99 RID: 15513 RVA: 0x0017BB66 File Offset: 0x00179F66
	[CompilerGenerated]
	private static double <GetEffectPowerValue>m__0(BoostSetting b)
	{
		return b.BoostValue;
	}

	// Token: 0x06003C9A RID: 15514 RVA: 0x0017BB6E File Offset: 0x00179F6E
	[CompilerGenerated]
	private static string <GetDescription>m__1(BoostSetting b)
	{
		return b.GetDescription();
	}

	// Token: 0x04002E50 RID: 11856
	public double Chance;

	// Token: 0x04002E51 RID: 11857
	public List<BoostSetting> Boosts;

	// Token: 0x04002E52 RID: 11858
	public AdventureEventType TriggerEventType;

	// Token: 0x04002E53 RID: 11859
	public string PossessionEffectSourceIdentityCode;

	// Token: 0x04002E54 RID: 11860
	public int LastingTurns;

	// Token: 0x04002E55 RID: 11861
	public bool? IsStarEf;

	// Token: 0x04002E56 RID: 11862
	[CompilerGenerated]
	private static Func<BoostSetting, double> <>f__am$cache0;

	// Token: 0x04002E57 RID: 11863
	[CompilerGenerated]
	private static Func<BoostSetting, string> <>f__am$cache1;
}
