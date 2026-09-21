using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006D0 RID: 1744
public class SwiftWind : ActiveSkillLogicBase
{
	// Token: 0x06002F51 RID: 12113 RVA: 0x00143B11 File Offset: 0x00141F11
	public SwiftWind()
	{
	}

	// Token: 0x06002F52 RID: 12114 RVA: 0x00143B34 File Offset: 0x00141F34
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SwiftwindDamageTalent(SkillType.SwiftWind, 1),
			new SwiftWindAgilityBoostTalent(SkillType.SwiftWind, 2),
			new SwiftWindPushEnhancementTalent(SkillType.SwiftWind, 3)
		};
	}

	// Token: 0x1700062A RID: 1578
	// (get) Token: 0x06002F53 RID: 12115 RVA: 0x00143B7B File Offset: 0x00141F7B
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x1700062B RID: 1579
	// (get) Token: 0x06002F54 RID: 12116 RVA: 0x00143B83 File Offset: 0x00141F83
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x1700062C RID: 1580
	// (get) Token: 0x06002F55 RID: 12117 RVA: 0x00143B8B File Offset: 0x00141F8B
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x1700062D RID: 1581
	// (get) Token: 0x06002F56 RID: 12118 RVA: 0x00143B93 File Offset: 0x00141F93
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F57 RID: 12119 RVA: 0x00143B9B File Offset: 0x00141F9B
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		if (profile.GetSpecialEffects().OfType<SwiftWindDamageSwitchEnhancementData>().Any<SwiftWindDamageSwitchEnhancementData>())
		{
			return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
		}
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002F58 RID: 12120 RVA: 0x00143BBD File Offset: 0x00141FBD
	public override double GetGaugeCost(Skill skill)
	{
		return 40.0;
	}

	// Token: 0x06002F59 RID: 12121 RVA: 0x00143BC8 File Offset: 0x00141FC8
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F5A RID: 12122 RVA: 0x00143BD4 File Offset: 0x00141FD4
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		if (skill.SourceUnit.SpecialEffects.OfType<SwiftWindDamageSwitchEnhancementData>().Any<SwiftWindDamageSwitchEnhancementData>())
		{
			return new HostileAllStrategy(skill);
		}
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002F5B RID: 12123 RVA: 0x00143BFD File Offset: 0x00141FFD
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002F5C RID: 12124 RVA: 0x00143C04 File Offset: 0x00142004
	private double ActiveBoostValue(Skill skill)
	{
		if (skill.Level == 1)
		{
			return 600.0;
		}
		if (skill.Level == 2)
		{
			return 900.0;
		}
		return 1500.0;
	}

	// Token: 0x06002F5D RID: 12125 RVA: 0x00143C3B File Offset: 0x0014203B
	private float ActiveLastingSeconds(Skill skill)
	{
		return 7f;
	}

	// Token: 0x06002F5E RID: 12126 RVA: 0x00143C42 File Offset: 0x00142042
	private double PassiveBoostValue(Skill skill)
	{
		return (double)(skill.Level * 100);
	}

	// Token: 0x06002F5F RID: 12127 RVA: 0x00143C50 File Offset: 0x00142050
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.SpeedIncreaseValueKey, ((int)this.ActiveBoostValue(skill)).ToString()).Replace(this.BoostRateKey, this.ActiveProgressPushRate(skill).ToExpressionMultiply100()).Replace(this.LastingSecondsKey, ((int)this.ActiveLastingSeconds(skill)).ToString()).ToString();
		description.Details2 = description.Details2.Replace(this.SpeedIncreaseValueKey, ((int)this.PassiveBoostValue(skill)).ToString());
		return description;
	}

	// Token: 0x06002F60 RID: 12128 RVA: 0x00143CF5 File Offset: 0x001420F5
	private double ActiveProgressPushRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002F61 RID: 12129 RVA: 0x00143D14 File Offset: 0x00142114
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		SwiftWindDamageSwitchEnhancementData damageEnhancement = skill.SourceUnit.SpecialEffects.OfType<SwiftWindDamageSwitchEnhancementData>().FirstOrDefault<SwiftWindDamageSwitchEnhancementData>();
		SwiftWindAgilityBoostEnhancementData agilityBoost = skill.SourceUnit.SpecialEffects.OfType<SwiftWindAgilityBoostEnhancementData>().FirstOrDefault<SwiftWindAgilityBoostEnhancementData>();
		SwiftWindPushBoostEnhancementData pushBoost = skill.SourceUnit.SpecialEffects.OfType<SwiftWindPushBoostEnhancementData>().FirstOrDefault<SwiftWindPushBoostEnhancementData>();
		if (damageEnhancement == null)
		{
			double pushRate = this.ActiveProgressPushRate(skill.Skill);
			double agilityValue = this.ActiveBoostValue(skill.Skill);
			if (agilityBoost != null)
			{
				pushRate = 0.0;
				agilityValue = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * agilityBoost.AgilityBoostRate;
			}
			if (pushBoost != null)
			{
				pushRate = pushBoost.PushRate;
				agilityValue = 0.0;
			}
			foreach (IBattleUnit strategySelection in strategy.Selections)
			{
				UnitTurnProgressUpdateEvent pushEffect = new UnitTurnProgressUpdateEvent
				{
					Dealer = skill.SourceUnit,
					ChangePercentage = pushRate,
					CausingSource = skill
				};
				IEnumerator enumerator2 = strategySelection.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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
				IEnumerator enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateAgilityBoostEffect(base.GetType().FullName + "active", agilityValue, new float?(this.ActiveLastingSeconds(skill.Skill)), null, skill), false).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		else
		{
			ReleaseableDamage releaseabledamage = new ReleaseableDamage((from s in strategy.Selections
			select new BattleDamage(s, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					DamagePotionValue.CreateRawValuedDamageComponent(s, skill.SourceUnit, skill.SourceUnit.GetOutputType(), skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * damageEnhancement.DamageRate)
				}, s, skill.SourceUnit, true, false)
			})).ToList<BattleDamage>(), skill.SourceUnit);
			IEnumerator enumerator4 = releaseabledamage.Release().GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _3 = enumerator4.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator4 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06002F62 RID: 12130 RVA: 0x00143D48 File Offset: 0x00142148
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateAgilityBoostEffect(base.GetType().FullName + "passive", this.PassiveBoostValue(skill.Skill), null, null, skill), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002F63 RID: 12131 RVA: 0x00143D74 File Offset: 0x00142174
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect agilityBoostEffect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(agilityBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x04002742 RID: 10050
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x04002743 RID: 10051
	private OutputType _skillOutputType;

	// Token: 0x04002744 RID: 10052
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002745 RID: 10053
	private SkillType _skillType = SkillType.SwiftWind;

	// Token: 0x02000E3B RID: 3643
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BA9 RID: 23465 RVA: 0x00143D9E File Offset: 0x0014219E
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005BAA RID: 23466 RVA: 0x00143DA8 File Offset: 0x001421A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				SwiftWindDamageSwitchEnhancementData damageEnhancement = skill.SourceUnit.SpecialEffects.OfType<SwiftWindDamageSwitchEnhancementData>().FirstOrDefault<SwiftWindDamageSwitchEnhancementData>();
				agilityBoost = skill.SourceUnit.SpecialEffects.OfType<SwiftWindAgilityBoostEnhancementData>().FirstOrDefault<SwiftWindAgilityBoostEnhancementData>();
				pushBoost = skill.SourceUnit.SpecialEffects.OfType<SwiftWindPushBoostEnhancementData>().FirstOrDefault<SwiftWindPushBoostEnhancementData>();
				if (damageEnhancement != null)
				{
					releaseabledamage = new ReleaseableDamage((from s in strategy.Selections
					select new BattleDamage(s, skill, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(s, skill.SourceUnit, skill.SourceUnit.GetOutputType(), skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * damageEnhancement.DamageRate)
						}, s, skill.SourceUnit, true, false)
					})).ToList<BattleDamage>(), skill.SourceUnit);
					enumerator4 = releaseabledamage.Release().GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
				pushRate = base.ActiveProgressPushRate(skill.Skill);
				agilityValue = base.ActiveBoostValue(skill.Skill);
				if (agilityBoost != null)
				{
					pushRate = 0.0;
					agilityValue = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * agilityBoost.AgilityBoostRate;
				}
				if (pushBoost != null)
				{
					pushRate = pushBoost.PushRate;
					agilityValue = 0.0;
				}
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
			case 2u:
				break;
			case 3u:
				goto IL_427;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
					enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateAgilityBoostEffect(base.GetType().FullName + "active", agilityValue, new float?(base.ActiveLastingSeconds(<CastSkillLogic>c__AnonStorey.skill.Skill)), null, <CastSkillLogic>c__AnonStorey.skill), false).GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				default:
					goto IL_39D;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IL_39D:
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					pushEffect = new UnitTurnProgressUpdateEvent
					{
						Dealer = <CastSkillLogic>c__AnonStorey.skill.SourceUnit,
						ChangePercentage = pushRate,
						CausingSource = <CastSkillLogic>c__AnonStorey.skill
					};
					enumerator2 = strategySelection.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			goto IL_4A9;
			Block_6:
			try
			{
				IL_427:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_4A9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001322 RID: 4898
		// (get) Token: 0x06005BAB RID: 23467 RVA: 0x001442CC File Offset: 0x001426CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001323 RID: 4899
		// (get) Token: 0x06005BAC RID: 23468 RVA: 0x001442D4 File Offset: 0x001426D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BAD RID: 23469 RVA: 0x001442DC File Offset: 0x001426DC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					case 2u:
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005BAE RID: 23470 RVA: 0x00144404 File Offset: 0x00142804
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BAF RID: 23471 RVA: 0x0014440B File Offset: 0x0014280B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BB0 RID: 23472 RVA: 0x00144414 File Offset: 0x00142814
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SwiftWind.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new SwiftWind.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004DA8 RID: 19880
		internal AdventureUnitSkill skill;

		// Token: 0x04004DA9 RID: 19881
		internal SwiftWindAgilityBoostEnhancementData <agilityBoost>__0;

		// Token: 0x04004DAA RID: 19882
		internal SwiftWindPushBoostEnhancementData <pushBoost>__0;

		// Token: 0x04004DAB RID: 19883
		internal double <pushRate>__1;

		// Token: 0x04004DAC RID: 19884
		internal double <agilityValue>__1;

		// Token: 0x04004DAD RID: 19885
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004DAE RID: 19886
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004DAF RID: 19887
		internal IBattleUnit <strategySelection>__2;

		// Token: 0x04004DB0 RID: 19888
		internal UnitTurnProgressUpdateEvent <pushEffect>__3;

		// Token: 0x04004DB1 RID: 19889
		internal IEnumerator $locvar1;

		// Token: 0x04004DB2 RID: 19890
		internal object <_>__4;

		// Token: 0x04004DB3 RID: 19891
		internal IDisposable $locvar2;

		// Token: 0x04004DB4 RID: 19892
		internal IEnumerator $locvar3;

		// Token: 0x04004DB5 RID: 19893
		internal object <_>__5;

		// Token: 0x04004DB6 RID: 19894
		internal IDisposable $locvar4;

		// Token: 0x04004DB7 RID: 19895
		internal ReleaseableDamage <releaseabledamage>__6;

		// Token: 0x04004DB8 RID: 19896
		internal IEnumerator $locvar5;

		// Token: 0x04004DB9 RID: 19897
		internal object <_>__7;

		// Token: 0x04004DBA RID: 19898
		internal IDisposable $locvar6;

		// Token: 0x04004DBB RID: 19899
		internal SwiftWind $this;

		// Token: 0x04004DBC RID: 19900
		internal object $current;

		// Token: 0x04004DBD RID: 19901
		internal bool $disposing;

		// Token: 0x04004DBE RID: 19902
		internal int $PC;

		// Token: 0x04004DBF RID: 19903
		private SwiftWind.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey3 $locvar7;

		// Token: 0x02000E3E RID: 3646
		private sealed class <CastSkillLogic>c__AnonStorey3
		{
			// Token: 0x06005BC2 RID: 23490 RVA: 0x00144460 File Offset: 0x00142860
			public <CastSkillLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06005BC3 RID: 23491 RVA: 0x00144468 File Offset: 0x00142868
			internal BattleDamage <>m__0(IBattleUnit s)
			{
				return new BattleDamage(s, this.skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(s, this.skill.SourceUnit, this.skill.SourceUnit.GetOutputType(), this.skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * this.damageEnhancement.DamageRate)
					}, s, this.skill.SourceUnit, true, false)
				});
			}

			// Token: 0x04004DD3 RID: 19923
			internal AdventureUnitSkill skill;

			// Token: 0x04004DD4 RID: 19924
			internal SwiftWindDamageSwitchEnhancementData damageEnhancement;

			// Token: 0x04004DD5 RID: 19925
			internal SwiftWind.<CastSkillLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000E3C RID: 3644
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BB1 RID: 23473 RVA: 0x001444ED File Offset: 0x001428ED
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005BB2 RID: 23474 RVA: 0x001444F8 File Offset: 0x001428F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateAgilityBoostEffect(base.GetType().FullName + "passive", base.PassiveBoostValue(skill.Skill), null, null, skill), false).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001324 RID: 4900
		// (get) Token: 0x06005BB3 RID: 23475 RVA: 0x00144634 File Offset: 0x00142A34
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001325 RID: 4901
		// (get) Token: 0x06005BB4 RID: 23476 RVA: 0x0014463C File Offset: 0x00142A3C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BB5 RID: 23477 RVA: 0x00144644 File Offset: 0x00142A44
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

		// Token: 0x06005BB6 RID: 23478 RVA: 0x001446B4 File Offset: 0x00142AB4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BB7 RID: 23479 RVA: 0x001446BB File Offset: 0x00142ABB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BB8 RID: 23480 RVA: 0x001446C4 File Offset: 0x00142AC4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SwiftWind.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new SwiftWind.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004DC0 RID: 19904
		internal AdventureUnitSkill skill;

		// Token: 0x04004DC1 RID: 19905
		internal IEnumerator $locvar0;

		// Token: 0x04004DC2 RID: 19906
		internal object <_>__1;

		// Token: 0x04004DC3 RID: 19907
		internal IDisposable $locvar1;

		// Token: 0x04004DC4 RID: 19908
		internal SwiftWind $this;

		// Token: 0x04004DC5 RID: 19909
		internal object $current;

		// Token: 0x04004DC6 RID: 19910
		internal bool $disposing;

		// Token: 0x04004DC7 RID: 19911
		internal int $PC;
	}

	// Token: 0x02000E3D RID: 3645
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BB9 RID: 23481 RVA: 0x00144704 File Offset: 0x00142B04
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005BBA RID: 23482 RVA: 0x0014470C File Offset: 0x00142B0C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
				select ef).ToList<AttributeModificationEffect>();
				enumerator = toRemove.GetEnumerator();
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
					Block_4:
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
					break;
				}
				if (enumerator.MoveNext())
				{
					agilityBoostEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(agilityBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
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

		// Token: 0x17001326 RID: 4902
		// (get) Token: 0x06005BBB RID: 23483 RVA: 0x0014489C File Offset: 0x00142C9C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001327 RID: 4903
		// (get) Token: 0x06005BBC RID: 23484 RVA: 0x001448A4 File Offset: 0x00142CA4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BBD RID: 23485 RVA: 0x001448AC File Offset: 0x00142CAC
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
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005BBE RID: 23486 RVA: 0x00144940 File Offset: 0x00142D40
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BBF RID: 23487 RVA: 0x00144947 File Offset: 0x00142D47
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BC0 RID: 23488 RVA: 0x00144950 File Offset: 0x00142D50
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SwiftWind.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new SwiftWind.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005BC1 RID: 23489 RVA: 0x00144990 File Offset: 0x00142D90
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004DC8 RID: 19912
		internal AdventureUnitSkill skill;

		// Token: 0x04004DC9 RID: 19913
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004DCA RID: 19914
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004DCB RID: 19915
		internal AttributeModificationEffect <agilityBoostEffect>__1;

		// Token: 0x04004DCC RID: 19916
		internal IEnumerator $locvar1;

		// Token: 0x04004DCD RID: 19917
		internal object <_>__2;

		// Token: 0x04004DCE RID: 19918
		internal IDisposable $locvar2;

		// Token: 0x04004DCF RID: 19919
		internal SwiftWind $this;

		// Token: 0x04004DD0 RID: 19920
		internal object $current;

		// Token: 0x04004DD1 RID: 19921
		internal bool $disposing;

		// Token: 0x04004DD2 RID: 19922
		internal int $PC;
	}
}
