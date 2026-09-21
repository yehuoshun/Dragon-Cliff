using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006C9 RID: 1737
public class Punishment : ActiveSkillLogicBase
{
	// Token: 0x06002ED5 RID: 11989 RVA: 0x0013CB5B File Offset: 0x0013AF5B
	public Punishment()
	{
	}

	// Token: 0x06002ED6 RID: 11990 RVA: 0x0013CB7C File Offset: 0x0013AF7C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new RageCostTalent(SkillType.Punishment, 1),
			new PushProgressTalent(SkillType.Punishment, 2),
			new TacticTargetAttributeDebuffTalent(SkillType.Punishment, 3)
		};
	}

	// Token: 0x1700060E RID: 1550
	// (get) Token: 0x06002ED7 RID: 11991 RVA: 0x0013CBC3 File Offset: 0x0013AFC3
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x1700060F RID: 1551
	// (get) Token: 0x06002ED8 RID: 11992 RVA: 0x0013CBCB File Offset: 0x0013AFCB
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000610 RID: 1552
	// (get) Token: 0x06002ED9 RID: 11993 RVA: 0x0013CBD3 File Offset: 0x0013AFD3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000611 RID: 1553
	// (get) Token: 0x06002EDA RID: 11994 RVA: 0x0013CBDB File Offset: 0x0013AFDB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EDB RID: 11995 RVA: 0x0013CBE3 File Offset: 0x0013AFE3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002EDC RID: 11996 RVA: 0x0013CBEA File Offset: 0x0013AFEA
	public override double GetGaugeCost(Skill skill)
	{
		return 100.0;
	}

	// Token: 0x06002EDD RID: 11997 RVA: 0x0013CBF5 File Offset: 0x0013AFF5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002EDE RID: 11998 RVA: 0x0013CC01 File Offset: 0x0013B001
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002EDF RID: 11999 RVA: 0x0013CC09 File Offset: 0x0013B009
	private double ActiveDamageRate(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002EE0 RID: 12000 RVA: 0x0013CC28 File Offset: 0x0013B028
	private double PassiveDamageRate(Skill skill)
	{
		return 0.1 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002EE1 RID: 12001 RVA: 0x0013CC48 File Offset: 0x0013B048
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.DamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.DamageRateKey, this.PassiveDamageRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002EE2 RID: 12002 RVA: 0x0013CC9C File Offset: 0x0013B09C
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002EE3 RID: 12003 RVA: 0x0013CCB8 File Offset: 0x0013B0B8
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && eventTriggerUnit == skillOwner)
		{
			List<IBattleUnit> enemies = skillOwner.GetLiveEnemyTargets(false, true);
			if (enemies.Any<IBattleUnit>())
			{
				IBattleUnit selected = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				ReleaseableDamage releaseable = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selected, processingSkill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(selected, skillOwner, OutputType.RealDamage, this.PassiveDamageRate(processingSkill.Skill) * skillOwner.GetMaxLife(AttributeRetrievalLevel.Skill))
						}, selected, skillOwner, true, false)
					})
				}, processingSkill.SourceUnit);
				IEnumerator enumerator = releaseable.Release().GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06002EE4 RID: 12004 RVA: 0x0013CCF8 File Offset: 0x0013B0F8
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		BunsisterStarMultipleHitData star = skill.SourceUnit.SpecialEffects.OfType<BunsisterStarMultipleHitData>().FirstOrDefault<BunsisterStarMultipleHitData>();
		foreach (IBattleUnit target in strategy.Selections)
		{
			if (star != null && (double)UnityEngine.Random.value <= star.Chance)
			{
				damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, this.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.7)
					}, target, skill.SourceUnit, true, false)
				}));
				damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, this.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.7)
					}, target, skill.SourceUnit, true, false)
				}));
			}
			else
			{
				damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, this.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill))
					}, target, skill.SourceUnit, true, false)
				}));
			}
		}
		ReleaseableDamage releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
		IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object _ = enumerator2.Current;
				yield return _;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator2 as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x04002725 RID: 10021
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x04002726 RID: 10022
	private OutputType _skillOutputType;

	// Token: 0x04002727 RID: 10023
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002728 RID: 10024
	private SkillType _skillType = SkillType.Punishment;

	// Token: 0x02000E21 RID: 3617
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B09 RID: 23305 RVA: 0x0013CD29 File Offset: 0x0013B129
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator0()
		{
		}

		// Token: 0x06005B0A RID: 23306 RVA: 0x0013CD34 File Offset: 0x0013B134
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || eventTriggerUnit != skillOwner)
				{
					goto IL_1BB;
				}
				enemies = skillOwner.GetLiveEnemyTargets(false, true);
				if (!enemies.Any<IBattleUnit>())
				{
					goto IL_1BB;
				}
				selected = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				releaseable = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selected, processingSkill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(selected, skillOwner, OutputType.RealDamage, base.PassiveDamageRate(processingSkill.Skill) * skillOwner.GetMaxLife(AttributeRetrievalLevel.Skill))
						}, selected, skillOwner, true, false)
					})
				}, processingSkill.SourceUnit);
				enumerator = releaseable.Release().GetEnumerator();
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
			IL_1BB:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001300 RID: 4864
		// (get) Token: 0x06005B0B RID: 23307 RVA: 0x0013CF18 File Offset: 0x0013B318
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001301 RID: 4865
		// (get) Token: 0x06005B0C RID: 23308 RVA: 0x0013CF20 File Offset: 0x0013B320
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B0D RID: 23309 RVA: 0x0013CF28 File Offset: 0x0013B328
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

		// Token: 0x06005B0E RID: 23310 RVA: 0x0013CF98 File Offset: 0x0013B398
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B0F RID: 23311 RVA: 0x0013CF9F File Offset: 0x0013B39F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B10 RID: 23312 RVA: 0x0013CFA8 File Offset: 0x0013B3A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Punishment.<PassiveBeingActiveEventProcess>c__Iterator0 <PassiveBeingActiveEventProcess>c__Iterator = new Punishment.<PassiveBeingActiveEventProcess>c__Iterator0();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004C4B RID: 19531
		internal AdventureEventType eventType;

		// Token: 0x04004C4C RID: 19532
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004C4D RID: 19533
		internal IBattleUnit skillOwner;

		// Token: 0x04004C4E RID: 19534
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04004C4F RID: 19535
		internal IBattleUnit <selected>__2;

		// Token: 0x04004C50 RID: 19536
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004C51 RID: 19537
		internal ReleaseableDamage <releaseable>__2;

		// Token: 0x04004C52 RID: 19538
		internal IEnumerator $locvar0;

		// Token: 0x04004C53 RID: 19539
		internal object <_>__3;

		// Token: 0x04004C54 RID: 19540
		internal IDisposable $locvar1;

		// Token: 0x04004C55 RID: 19541
		internal Punishment $this;

		// Token: 0x04004C56 RID: 19542
		internal object $current;

		// Token: 0x04004C57 RID: 19543
		internal bool $disposing;

		// Token: 0x04004C58 RID: 19544
		internal int $PC;
	}

	// Token: 0x02000E22 RID: 3618
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B11 RID: 23313 RVA: 0x0013D00C File Offset: 0x0013B40C
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator1()
		{
		}

		// Token: 0x06005B12 RID: 23314 RVA: 0x0013D014 File Offset: 0x0013B414
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				star = skill.SourceUnit.SpecialEffects.OfType<BunsisterStarMultipleHitData>().FirstOrDefault<BunsisterStarMultipleHitData>();
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						if (star != null && (double)UnityEngine.Random.value <= star.Chance)
						{
							damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, base.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.7)
								}, target, skill.SourceUnit, true, false)
							}));
							damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, base.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * 0.7)
								}, target, skill.SourceUnit, true, false)
							}));
						}
						else
						{
							damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(target, skill.SourceUnit, OutputType.RealDamage, base.ActiveDamageRate(skill.Skill) * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill))
								}, target, skill.SourceUnit, true, false)
							}));
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
				enumerator2 = releaseable.Release().GetEnumerator();
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
				if (enumerator2.MoveNext())
				{
					_ = enumerator2.Current;
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001302 RID: 4866
		// (get) Token: 0x06005B13 RID: 23315 RVA: 0x0013D374 File Offset: 0x0013B774
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001303 RID: 4867
		// (get) Token: 0x06005B14 RID: 23316 RVA: 0x0013D37C File Offset: 0x0013B77C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B15 RID: 23317 RVA: 0x0013D384 File Offset: 0x0013B784
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005B16 RID: 23318 RVA: 0x0013D3F4 File Offset: 0x0013B7F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B17 RID: 23319 RVA: 0x0013D3FB File Offset: 0x0013B7FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B18 RID: 23320 RVA: 0x0013D404 File Offset: 0x0013B804
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Punishment.<CastSkillLogic>c__Iterator1 <CastSkillLogic>c__Iterator = new Punishment.<CastSkillLogic>c__Iterator1();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004C59 RID: 19545
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004C5A RID: 19546
		internal AdventureUnitSkill skill;

		// Token: 0x04004C5B RID: 19547
		internal BunsisterStarMultipleHitData <star>__0;

		// Token: 0x04004C5C RID: 19548
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004C5D RID: 19549
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004C5E RID: 19550
		internal ReleaseableDamage <releaseable>__0;

		// Token: 0x04004C5F RID: 19551
		internal IEnumerator $locvar1;

		// Token: 0x04004C60 RID: 19552
		internal object <_>__1;

		// Token: 0x04004C61 RID: 19553
		internal IDisposable $locvar2;

		// Token: 0x04004C62 RID: 19554
		internal Punishment $this;

		// Token: 0x04004C63 RID: 19555
		internal object $current;

		// Token: 0x04004C64 RID: 19556
		internal bool $disposing;

		// Token: 0x04004C65 RID: 19557
		internal int $PC;
	}
}
