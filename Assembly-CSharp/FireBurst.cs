using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006F3 RID: 1779
public class FireBurst : MainSkillBase
{
	// Token: 0x060030A0 RID: 12448 RVA: 0x0014AB8A File Offset: 0x00148F8A
	public FireBurst()
	{
	}

	// Token: 0x170006A2 RID: 1698
	// (get) Token: 0x060030A1 RID: 12449 RVA: 0x0014AB92 File Offset: 0x00148F92
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x170006A3 RID: 1699
	// (get) Token: 0x060030A2 RID: 12450 RVA: 0x0014AB95 File Offset: 0x00148F95
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006A4 RID: 1700
	// (get) Token: 0x060030A3 RID: 12451 RVA: 0x0014AB98 File Offset: 0x00148F98
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x170006A5 RID: 1701
	// (get) Token: 0x060030A4 RID: 12452 RVA: 0x0014AB9B File Offset: 0x00148F9B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006A6 RID: 1702
	// (get) Token: 0x060030A5 RID: 12453 RVA: 0x0014AB9E File Offset: 0x00148F9E
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FireBurst;
		}
	}

	// Token: 0x170006A7 RID: 1703
	// (get) Token: 0x060030A6 RID: 12454 RVA: 0x0014ABA5 File Offset: 0x00148FA5
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030A7 RID: 12455 RVA: 0x0014ABAD File Offset: 0x00148FAD
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060030A8 RID: 12456 RVA: 0x0014ABCC File Offset: 0x00148FCC
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x060030A9 RID: 12457 RVA: 0x0014AC4B File Offset: 0x0014904B
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030AA RID: 12458 RVA: 0x0014AC52 File Offset: 0x00149052
	private double StunChancePerSeed(Skill skill)
	{
		return 0.16;
	}

	// Token: 0x060030AB RID: 12459 RVA: 0x0014AC60 File Offset: 0x00149060
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.StunChancePerSeed(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060030AC RID: 12460 RVA: 0x0014ACC4 File Offset: 0x001490C4
	public override IEnumerable PriorDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		List<IBattleUnit> targets = (from d in damage.BattleDamages
		select d.Target into t
		where t.Status == BattleUnitStatus.Active
		select t).ToList<IBattleUnit>();
		foreach (IBattleUnit battleUnit in targets)
		{
			foreach (FireSeedEffect fireseed in battleUnit.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>())
			{
				IEnumerator enumerator3 = this.StunLogicPerExplosion(battleUnit, skill).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _ = enumerator3.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060030AD RID: 12461 RVA: 0x0014ACF8 File Offset: 0x001490F8
	private IEnumerable StunLogicPerExplosion(IBattleUnit unit, AdventureUnitSkill skill)
	{
		double chance = this.StunChancePerSeed(skill.Skill);
		if ((double)UnityEngine.Random.value <= chance)
		{
			IEnumerator enumerator = LockTimeEffect.AddStunSeconds(unit, 2f, skill, false).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x04002796 RID: 10134
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E55 RID: 3669
	[CompilerGenerated]
	private sealed class <PriorDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C44 RID: 23620 RVA: 0x0014AD29 File Offset: 0x00149129
		[DebuggerHidden]
		public <PriorDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C45 RID: 23621 RVA: 0x0014AD34 File Offset: 0x00149134
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = (from d in damage.BattleDamages
				select d.Target into t
				where t.Status == BattleUnitStatus.Active
				select t).ToList<IBattleUnit>();
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_6:
					try
					{
						switch (num)
						{
						case 1u:
							Block_9:
							try
							{
								switch (num)
								{
								}
								if (enumerator3.MoveNext())
								{
									_ = enumerator3.Current;
									this.$current = _;
									if (!this.$disposing)
									{
										this.$PC = 1;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator2.MoveNext())
						{
							fireseed = enumerator2.Current;
							enumerator3 = base.StunLogicPerExplosion(battleUnit, skill).GetEnumerator();
							num = 4294967293u;
							goto Block_9;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.BattleEffects.OfType<FireSeedEffect>().ToList<FireSeedEffect>().GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001340 RID: 4928
		// (get) Token: 0x06005C46 RID: 23622 RVA: 0x0014AF8C File Offset: 0x0014938C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001341 RID: 4929
		// (get) Token: 0x06005C47 RID: 23623 RVA: 0x0014AF94 File Offset: 0x00149394
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C48 RID: 23624 RVA: 0x0014AF9C File Offset: 0x0014939C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005C49 RID: 23625 RVA: 0x0014B054 File Offset: 0x00149454
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C4A RID: 23626 RVA: 0x0014B05B File Offset: 0x0014945B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x0014B064 File Offset: 0x00149464
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireBurst.<PriorDamageProcess>c__Iterator0 <PriorDamageProcess>c__Iterator = new FireBurst.<PriorDamageProcess>c__Iterator0();
			<PriorDamageProcess>c__Iterator.$this = this;
			<PriorDamageProcess>c__Iterator.damage = damage;
			<PriorDamageProcess>c__Iterator.skill = skill;
			return <PriorDamageProcess>c__Iterator;
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x0014B0B0 File Offset: 0x001494B0
		private static IBattleUnit <>m__0(BattleDamage d)
		{
			return d.Target;
		}

		// Token: 0x06005C4D RID: 23629 RVA: 0x0014B0B8 File Offset: 0x001494B8
		private static bool <>m__1(IBattleUnit t)
		{
			return t.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04004EA9 RID: 20137
		internal ReleaseableDamage damage;

		// Token: 0x04004EAA RID: 20138
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004EAB RID: 20139
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004EAC RID: 20140
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004EAD RID: 20141
		internal List<FireSeedEffect>.Enumerator $locvar1;

		// Token: 0x04004EAE RID: 20142
		internal FireSeedEffect <fireseed>__2;

		// Token: 0x04004EAF RID: 20143
		internal AdventureUnitSkill skill;

		// Token: 0x04004EB0 RID: 20144
		internal IEnumerator $locvar2;

		// Token: 0x04004EB1 RID: 20145
		internal object <_>__3;

		// Token: 0x04004EB2 RID: 20146
		internal IDisposable $locvar3;

		// Token: 0x04004EB3 RID: 20147
		internal FireBurst $this;

		// Token: 0x04004EB4 RID: 20148
		internal object $current;

		// Token: 0x04004EB5 RID: 20149
		internal bool $disposing;

		// Token: 0x04004EB6 RID: 20150
		internal int $PC;

		// Token: 0x04004EB7 RID: 20151
		private static Func<BattleDamage, IBattleUnit> <>f__am$cache0;

		// Token: 0x04004EB8 RID: 20152
		private static Func<IBattleUnit, bool> <>f__am$cache1;
	}

	// Token: 0x02000E56 RID: 3670
	[CompilerGenerated]
	private sealed class <StunLogicPerExplosion>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C4E RID: 23630 RVA: 0x0014B0C3 File Offset: 0x001494C3
		[DebuggerHidden]
		public <StunLogicPerExplosion>c__Iterator1()
		{
		}

		// Token: 0x06005C4F RID: 23631 RVA: 0x0014B0CC File Offset: 0x001494CC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				chance = base.StunChancePerSeed(skill.Skill);
				if ((double)UnityEngine.Random.value > chance)
				{
					goto IL_F7;
				}
				enumerator = LockTimeEffect.AddStunSeconds(unit, 2f, skill, false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_F7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001342 RID: 4930
		// (get) Token: 0x06005C50 RID: 23632 RVA: 0x0014B1EC File Offset: 0x001495EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001343 RID: 4931
		// (get) Token: 0x06005C51 RID: 23633 RVA: 0x0014B1F4 File Offset: 0x001495F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C52 RID: 23634 RVA: 0x0014B1FC File Offset: 0x001495FC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005C53 RID: 23635 RVA: 0x0014B26C File Offset: 0x0014966C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C54 RID: 23636 RVA: 0x0014B273 File Offset: 0x00149673
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C55 RID: 23637 RVA: 0x0014B27C File Offset: 0x0014967C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireBurst.<StunLogicPerExplosion>c__Iterator1 <StunLogicPerExplosion>c__Iterator = new FireBurst.<StunLogicPerExplosion>c__Iterator1();
			<StunLogicPerExplosion>c__Iterator.$this = this;
			<StunLogicPerExplosion>c__Iterator.skill = skill;
			<StunLogicPerExplosion>c__Iterator.unit = unit;
			return <StunLogicPerExplosion>c__Iterator;
		}

		// Token: 0x04004EB9 RID: 20153
		internal AdventureUnitSkill skill;

		// Token: 0x04004EBA RID: 20154
		internal double <chance>__0;

		// Token: 0x04004EBB RID: 20155
		internal IBattleUnit unit;

		// Token: 0x04004EBC RID: 20156
		internal IEnumerator $locvar0;

		// Token: 0x04004EBD RID: 20157
		internal object <_>__1;

		// Token: 0x04004EBE RID: 20158
		internal IDisposable $locvar1;

		// Token: 0x04004EBF RID: 20159
		internal FireBurst $this;

		// Token: 0x04004EC0 RID: 20160
		internal object $current;

		// Token: 0x04004EC1 RID: 20161
		internal bool $disposing;

		// Token: 0x04004EC2 RID: 20162
		internal int $PC;
	}
}
