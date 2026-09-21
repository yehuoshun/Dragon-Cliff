using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006DE RID: 1758
public class StableDamageDefinition : IDamageDefinition
{
	// Token: 0x06002FAE RID: 12206 RVA: 0x0014600C File Offset: 0x0014440C
	public StableDamageDefinition(List<DamageHitDefinition> damageHits, TargetDefinition targetDefinition, AdventureUnitSkill skill)
	{
		this.DamageHits = damageHits;
		this.TargetDefinition = targetDefinition;
		if (targetDefinition.NumberOfTargets != null && skill.GetExtraSkillTargets() > 0)
		{
			targetDefinition.SetNumberOfTargets(new int?(targetDefinition.NumberOfTargets.Value + skill.GetExtraSkillTargets()));
		}
	}

	// Token: 0x17000641 RID: 1601
	// (get) Token: 0x06002FAF RID: 12207 RVA: 0x0014606C File Offset: 0x0014446C
	// (set) Token: 0x06002FB0 RID: 12208 RVA: 0x00146074 File Offset: 0x00144474
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

	// Token: 0x17000642 RID: 1602
	// (get) Token: 0x06002FB1 RID: 12209 RVA: 0x0014607D File Offset: 0x0014447D
	// (set) Token: 0x06002FB2 RID: 12210 RVA: 0x00146085 File Offset: 0x00144485
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

	// Token: 0x06002FB3 RID: 12211 RVA: 0x00146090 File Offset: 0x00144490
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
					return new DamagePotionValue(caster2, battleUnit, (outputType == null) ? caster.GetOutputType() : outputType.Value, p.DamageRate + damageSource.GetMainSkillDamageBoostRate());
				}).ToList<DamagePotionValue>(), battleUnit, caster, true, false)).ToList<DamageComponentValue>()));
			}
		}
		return new ReleaseableDamage(list, caster);
	}

	// Token: 0x04002757 RID: 10071
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamageHitDefinition> <DamageHits>k__BackingField;

	// Token: 0x04002758 RID: 10072
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TargetDefinition <TargetDefinition>k__BackingField;

	// Token: 0x02000E48 RID: 3656
	[CompilerGenerated]
	private sealed class <GetReleaseableDamage>c__AnonStorey0
	{
		// Token: 0x06005BE9 RID: 23529 RVA: 0x00146168 File Offset: 0x00144568
		public <GetReleaseableDamage>c__AnonStorey0()
		{
		}

		// Token: 0x04004E0C RID: 19980
		internal IBattleUnit caster;

		// Token: 0x04004E0D RID: 19981
		internal IBattleEffectSource damageSource;
	}

	// Token: 0x02000E49 RID: 3657
	[CompilerGenerated]
	private sealed class <GetReleaseableDamage>c__AnonStorey1
	{
		// Token: 0x06005BEA RID: 23530 RVA: 0x00146170 File Offset: 0x00144570
		public <GetReleaseableDamage>c__AnonStorey1()
		{
		}

		// Token: 0x06005BEB RID: 23531 RVA: 0x00146178 File Offset: 0x00144578
		internal DamageComponentValue <>m__0(DamageHitDefinition hit)
		{
			return new DamageComponentValue(hit.Potions.Select(delegate(DamageHitModuleDefinition p)
			{
				IBattleUnit caster = this.<>f__ref$0.caster;
				IBattleUnit target = this.battleUnit;
				OutputType? outputType = p.OutputType;
				return new DamagePotionValue(caster, target, (outputType == null) ? this.<>f__ref$0.caster.GetOutputType() : outputType.Value, p.DamageRate + this.<>f__ref$0.damageSource.GetMainSkillDamageBoostRate());
			}).ToList<DamagePotionValue>(), this.battleUnit, this.<>f__ref$0.caster, true, false);
		}

		// Token: 0x06005BEC RID: 23532 RVA: 0x001461B0 File Offset: 0x001445B0
		internal DamagePotionValue <>m__1(DamageHitModuleDefinition p)
		{
			IBattleUnit caster = this.<>f__ref$0.caster;
			IBattleUnit target = this.battleUnit;
			OutputType? outputType = p.OutputType;
			return new DamagePotionValue(caster, target, (outputType == null) ? this.<>f__ref$0.caster.GetOutputType() : outputType.Value, p.DamageRate + this.<>f__ref$0.damageSource.GetMainSkillDamageBoostRate());
		}

		// Token: 0x04004E0E RID: 19982
		internal IBattleUnit battleUnit;

		// Token: 0x04004E0F RID: 19983
		internal StableDamageDefinition.<GetReleaseableDamage>c__AnonStorey0 <>f__ref$0;
	}
}
