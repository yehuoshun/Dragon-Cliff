using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006DD RID: 1757
public class RelativeDamageDefinition : IDamageDefinition
{
	// Token: 0x06002FA6 RID: 12198 RVA: 0x00145DD4 File Offset: 0x001441D4
	public RelativeDamageDefinition(List<DamageHitDefinition> damageHits, TargetDefinition targetDefinition, Func<IBattleUnit, IBattleUnit, double> relativeModifierFunc, AdventureUnitSkill skill)
	{
		this.DamageHits = damageHits;
		this.TargetDefinition = targetDefinition;
		if (targetDefinition.NumberOfTargets != null && skill.GetExtraSkillTargets() > 0)
		{
			targetDefinition.SetNumberOfTargets(new int?(targetDefinition.NumberOfTargets.Value + skill.GetExtraSkillTargets()));
		}
		this.RelativeModifierFunc = relativeModifierFunc;
	}

	// Token: 0x1700063E RID: 1598
	// (get) Token: 0x06002FA7 RID: 12199 RVA: 0x00145E3D File Offset: 0x0014423D
	// (set) Token: 0x06002FA8 RID: 12200 RVA: 0x00145E45 File Offset: 0x00144245
	public List<DamageHitDefinition> DamageHits
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageHits>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageHits>k__BackingField = value;
		}
	}

	// Token: 0x1700063F RID: 1599
	// (get) Token: 0x06002FA9 RID: 12201 RVA: 0x00145E4E File Offset: 0x0014424E
	// (set) Token: 0x06002FAA RID: 12202 RVA: 0x00145E56 File Offset: 0x00144256
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

	// Token: 0x17000640 RID: 1600
	// (get) Token: 0x06002FAB RID: 12203 RVA: 0x00145E5F File Offset: 0x0014425F
	// (set) Token: 0x06002FAC RID: 12204 RVA: 0x00145E67 File Offset: 0x00144267
	public Func<IBattleUnit, IBattleUnit, double> RelativeModifierFunc
	{
		[CompilerGenerated]
		get
		{
			return this.<RelativeModifierFunc>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<RelativeModifierFunc>k__BackingField = value;
		}
	}

	// Token: 0x06002FAD RID: 12205 RVA: 0x00145E70 File Offset: 0x00144270
	public ReleaseableDamage GetReleaseableDamage(IBattleUnit caster, IBattleEffectSource damageSource)
	{
		List<IBattleUnit> targets = this.TargetDefinition.GetTargets(caster);
		List<BattleDamage> list = new List<BattleDamage>();
		using (List<IBattleUnit>.Enumerator enumerator = targets.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IBattleUnit battleUnit = enumerator.Current;
				list.Add(new BattleDamage(battleUnit, damageSource, (from hit in this.DamageHits
				select new DamageComponentValue(hit.Potions.Select(delegate(DamageHitModuleDefinition p)
				{
					IBattleUnit caster2 = caster;
					IBattleUnit battleUnit = battleUnit;
					OutputType? outputType = p.OutputType;
					return new DamagePotionValue(caster2, battleUnit, (outputType == null) ? caster.GetOutputType() : outputType.Value, p.DamageRate + this.RelativeModifierFunc(caster, battleUnit));
				}).ToList<DamagePotionValue>(), battleUnit, caster, true, false)).ToList<DamageComponentValue>()));
			}
		}
		return new ReleaseableDamage(list, caster);
	}

	// Token: 0x04002754 RID: 10068
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamageHitDefinition> <DamageHits>k__BackingField;

	// Token: 0x04002755 RID: 10069
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TargetDefinition <TargetDefinition>k__BackingField;

	// Token: 0x04002756 RID: 10070
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<IBattleUnit, IBattleUnit, double> <RelativeModifierFunc>k__BackingField;

	// Token: 0x02000E46 RID: 3654
	[CompilerGenerated]
	private sealed class <GetReleaseableDamage>c__AnonStorey0
	{
		// Token: 0x06005BE5 RID: 23525 RVA: 0x00145F44 File Offset: 0x00144344
		public <GetReleaseableDamage>c__AnonStorey0()
		{
		}

		// Token: 0x04004E08 RID: 19976
		internal IBattleUnit caster;

		// Token: 0x04004E09 RID: 19977
		internal RelativeDamageDefinition $this;
	}

	// Token: 0x02000E47 RID: 3655
	[CompilerGenerated]
	private sealed class <GetReleaseableDamage>c__AnonStorey1
	{
		// Token: 0x06005BE6 RID: 23526 RVA: 0x00145F4C File Offset: 0x0014434C
		public <GetReleaseableDamage>c__AnonStorey1()
		{
		}

		// Token: 0x06005BE7 RID: 23527 RVA: 0x00145F54 File Offset: 0x00144354
		internal DamageComponentValue <>m__0(DamageHitDefinition hit)
		{
			return new DamageComponentValue(hit.Potions.Select(delegate(DamageHitModuleDefinition p)
			{
				IBattleUnit caster = this.<>f__ref$0.caster;
				IBattleUnit target = this.battleUnit;
				OutputType? outputType = p.OutputType;
				return new DamagePotionValue(caster, target, (outputType == null) ? this.<>f__ref$0.caster.GetOutputType() : outputType.Value, p.DamageRate + this.<>f__ref$0.$this.RelativeModifierFunc(this.<>f__ref$0.caster, this.battleUnit));
			}).ToList<DamagePotionValue>(), this.battleUnit, this.<>f__ref$0.caster, true, false);
		}

		// Token: 0x06005BE8 RID: 23528 RVA: 0x00145F8C File Offset: 0x0014438C
		internal DamagePotionValue <>m__1(DamageHitModuleDefinition p)
		{
			IBattleUnit caster = this.<>f__ref$0.caster;
			IBattleUnit target = this.battleUnit;
			OutputType? outputType = p.OutputType;
			return new DamagePotionValue(caster, target, (outputType == null) ? this.<>f__ref$0.caster.GetOutputType() : outputType.Value, p.DamageRate + this.<>f__ref$0.$this.RelativeModifierFunc(this.<>f__ref$0.caster, this.battleUnit));
		}

		// Token: 0x04004E0A RID: 19978
		internal IBattleUnit battleUnit;

		// Token: 0x04004E0B RID: 19979
		internal RelativeDamageDefinition.<GetReleaseableDamage>c__AnonStorey0 <>f__ref$0;
	}
}
