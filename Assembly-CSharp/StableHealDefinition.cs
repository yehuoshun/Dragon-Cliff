using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006E1 RID: 1761
public class StableHealDefinition : IHealDefinition
{
	// Token: 0x06002FBC RID: 12220 RVA: 0x0014626C File Offset: 0x0014466C
	public StableHealDefinition(List<double> healPercentagesPerTarget, TargetDefinition targetDefinition, OutputType healType, AdventureUnitSkill skill)
	{
		this.HealPercentagesPerTarget = healPercentagesPerTarget;
		this.TargetDefinition = targetDefinition;
		if (targetDefinition.NumberOfTargets != null && skill.GetExtraSkillTargets() > 0)
		{
			targetDefinition.SetNumberOfTargets(new int?(targetDefinition.NumberOfTargets.Value + skill.GetExtraSkillTargets()));
		}
		this.HealType = healType;
	}

	// Token: 0x17000646 RID: 1606
	// (get) Token: 0x06002FBD RID: 12221 RVA: 0x001462D5 File Offset: 0x001446D5
	// (set) Token: 0x06002FBE RID: 12222 RVA: 0x001462DD File Offset: 0x001446DD
	public List<double> HealPercentagesPerTarget
	{
		[CompilerGenerated]
		get
		{
			return this.<HealPercentagesPerTarget>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealPercentagesPerTarget>k__BackingField = value;
		}
	}

	// Token: 0x17000647 RID: 1607
	// (get) Token: 0x06002FBF RID: 12223 RVA: 0x001462E6 File Offset: 0x001446E6
	// (set) Token: 0x06002FC0 RID: 12224 RVA: 0x001462EE File Offset: 0x001446EE
	public TargetDefinition TargetDefinition
	{
		[CompilerGenerated]
		get
		{
			return this.<TargetDefinition>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<TargetDefinition>k__BackingField = value;
		}
	}

	// Token: 0x17000648 RID: 1608
	// (get) Token: 0x06002FC1 RID: 12225 RVA: 0x001462F7 File Offset: 0x001446F7
	// (set) Token: 0x06002FC2 RID: 12226 RVA: 0x001462FF File Offset: 0x001446FF
	public OutputType HealType
	{
		[CompilerGenerated]
		get
		{
			return this.<HealType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealType>k__BackingField = value;
		}
	}

	// Token: 0x06002FC3 RID: 12227 RVA: 0x00146308 File Offset: 0x00144708
	public ReleaseableHeal GetReleaseableHeal(IBattleUnit caster, IBattleEffectSource healSource, OutputType healType)
	{
		List<IBattleUnit> targets = this.TargetDefinition.GetTargets(caster);
		List<BattleHeal> list = new List<BattleHeal>();
		UnitOutputCapacity outputCapacity = caster.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		double healCapacity = outputCapacity.Value;
		foreach (IBattleUnit target in targets)
		{
			list.Add(new BattleHeal(target, healSource, (from p in this.HealPercentagesPerTarget
			select new HealComponentValue
			{
				RawHeal = healCapacity * p,
				IsDirectHeal = true,
				HealType = healType
			}).ToList<HealComponentValue>(), false));
		}
		return new ReleaseableHeal(list, caster);
	}

	// Token: 0x0400275C RID: 10076
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<double> <HealPercentagesPerTarget>k__BackingField;

	// Token: 0x0400275D RID: 10077
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TargetDefinition <TargetDefinition>k__BackingField;

	// Token: 0x0400275E RID: 10078
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <HealType>k__BackingField;

	// Token: 0x02000E4A RID: 3658
	[CompilerGenerated]
	private sealed class <GetReleaseableHeal>c__AnonStorey0
	{
		// Token: 0x06005BED RID: 23533 RVA: 0x001463C4 File Offset: 0x001447C4
		public <GetReleaseableHeal>c__AnonStorey0()
		{
		}

		// Token: 0x06005BEE RID: 23534 RVA: 0x001463CC File Offset: 0x001447CC
		internal HealComponentValue <>m__0(double p)
		{
			return new HealComponentValue
			{
				RawHeal = this.healCapacity * p,
				IsDirectHeal = true,
				HealType = this.healType
			};
		}

		// Token: 0x04004E10 RID: 19984
		internal double healCapacity;

		// Token: 0x04004E11 RID: 19985
		internal OutputType healType;
	}
}
