using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006B9 RID: 1721
public class BloodCurse : ActiveSkillLogicBase
{
	// Token: 0x06002DB9 RID: 11705 RVA: 0x0013056C File Offset: 0x0012E96C
	public BloodCurse()
	{
	}

	// Token: 0x06002DBA RID: 11706 RVA: 0x00130590 File Offset: 0x0012E990
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new BloodCurseDispelPartyTalent(SkillType.BloodCurse, 1),
			new BloodCurseDispelOnHitTalent(SkillType.BloodCurse, 2),
			new BloodCurseDepressionTalent(SkillType.BloodCurse, 3)
		};
	}

	// Token: 0x170005CE RID: 1486
	// (get) Token: 0x06002DBB RID: 11707 RVA: 0x001305D7 File Offset: 0x0012E9D7
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005CF RID: 1487
	// (get) Token: 0x06002DBC RID: 11708 RVA: 0x001305DF File Offset: 0x0012E9DF
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005D0 RID: 1488
	// (get) Token: 0x06002DBD RID: 11709 RVA: 0x001305E7 File Offset: 0x0012E9E7
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005D1 RID: 1489
	// (get) Token: 0x06002DBE RID: 11710 RVA: 0x001305EF File Offset: 0x0012E9EF
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002DBF RID: 11711 RVA: 0x001305F7 File Offset: 0x0012E9F7
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<SelfStrategy>();
	}

	// Token: 0x06002DC0 RID: 11712 RVA: 0x001305FE File Offset: 0x0012E9FE
	public override double GetGaugeCost(Skill skill)
	{
		return 60.0;
	}

	// Token: 0x06002DC1 RID: 11713 RVA: 0x00130609 File Offset: 0x0012EA09
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(0f);
	}

	// Token: 0x06002DC2 RID: 11714 RVA: 0x00130615 File Offset: 0x0012EA15
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new SelfStrategy(skill);
	}

	// Token: 0x06002DC3 RID: 11715 RVA: 0x0013061D File Offset: 0x0012EA1D
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002DC4 RID: 11716 RVA: 0x00130624 File Offset: 0x0012EA24
	private double ActiveSpeedRate(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.4;
	}

	// Token: 0x06002DC5 RID: 11717 RVA: 0x00130643 File Offset: 0x0012EA43
	private double ActiveOutputRate(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002DC6 RID: 11718 RVA: 0x00130662 File Offset: 0x0012EA62
	private double PassiveSpeedRate(Skill skill)
	{
		return 0.05 + (double)(skill.Level - 1) * 0.01;
	}

	// Token: 0x06002DC7 RID: 11719 RVA: 0x00130681 File Offset: 0x0012EA81
	private double PassiveOutputRate(Skill skill)
	{
		return 0.08 + (double)(skill.Level - 1) * 0.02;
	}

	// Token: 0x06002DC8 RID: 11720 RVA: 0x001306A0 File Offset: 0x0012EAA0
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.SpeedIncreaseRateKey, this.ActiveSpeedRate(skill).ToExpressionMultiply100()).Replace(this.LifeOnHitIncreaseKey, this.ActiveOutputRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.ReplaceToBuilder(this.SpeedIncreaseRateKey, this.PassiveSpeedRate(skill).ToExpressionMultiply100()).Replace(this.LifeOnHitIncreaseKey, this.PassiveOutputRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06002DC9 RID: 11721 RVA: 0x0013072C File Offset: 0x0012EB2C
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		if (skill.SourceUnit.SpecialEffects.OfType<BloodCurseDispelPartyEnhancementData>().Any<BloodCurseDispelPartyEnhancementData>())
		{
			int totalDispel = skill.SourceUnit.SpecialEffects.OfType<BloodCurseDispelPartyEnhancementData>().Sum((BloodCurseDispelPartyEnhancementData s) => s.NumberOfDispels);
			List<IBattleUnit> targets = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(battleUnit, new int?(totalDispel)).GetEnumerator();
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
		}
		foreach (IBattleUnit unit in strategy.Selections)
		{
			IEnumerator enumerator4 = unit.ApplySkillEffect(AttributeModificationEffect.CreateBloodCurseEffect(base.GetType().FullName + "active", new int?(2), this.ActiveSpeedRate(skill.Skill), this.ActiveOutputRate(skill.Skill), skill), false).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _2 = enumerator4.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator4 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			IEnumerator enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(unit, null).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _3 = enumerator5.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator5 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06002DCA RID: 11722 RVA: 0x00130760 File Offset: 0x0012EB60
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateBloodCurseEffect(base.GetType().FullName + "passive", new int?(2), this.PassiveSpeedRate(skill.Skill), this.PassiveOutputRate(skill.Skill), skill), false).GetEnumerator();
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

	// Token: 0x06002DCB RID: 11723 RVA: 0x0013078C File Offset: 0x0012EB8C
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> tobeRemoved = (from s in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where s.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select s).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect bloodCurseEffect in tobeRemoved)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(bloodCurseEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x040026E0 RID: 9952
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x040026E1 RID: 9953
	private OutputType _skillOutputType;

	// Token: 0x040026E2 RID: 9954
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x040026E3 RID: 9955
	private SkillType _skillType = SkillType.BloodCurse;

	// Token: 0x02000DF2 RID: 3570
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005991 RID: 22929 RVA: 0x001307B6 File Offset: 0x0012EBB6
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005992 RID: 22930 RVA: 0x001307C0 File Offset: 0x0012EBC0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!skill.SourceUnit.SpecialEffects.OfType<BloodCurseDispelPartyEnhancementData>().Any<BloodCurseDispelPartyEnhancementData>())
				{
					goto IL_1A5;
				}
				totalDispel = skill.SourceUnit.SpecialEffects.OfType<BloodCurseDispelPartyEnhancementData>().Sum((BloodCurseDispelPartyEnhancementData s) => s.NumberOfDispels);
				targets = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				Block_5:
				try
				{
					switch (num)
					{
					case 2u:
						Block_18:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_2 = enumerator4.Current;
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
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(unit, null).GetEnumerator();
						num = 4294967293u;
						break;
					case 3u:
						break;
					default:
						goto IL_37B;
					}
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_3 = enumerator5.Current;
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
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					IL_37B:
					if (enumerator3.MoveNext())
					{
						unit = enumerator3.Current;
						enumerator4 = unit.ApplySkillEffect(AttributeModificationEffect.CreateBloodCurseEffect(base.GetType().FullName + "active", new int?(2), base.ActiveSpeedRate(skill.Skill), base.ActiveOutputRate(skill.Skill), skill), false).GetEnumerator();
						num = 4294967293u;
						goto Block_18;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				this.$PC = -1;
				return false;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_7:
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
					battleUnit = enumerator.Current;
					enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(battleUnit, new int?(totalDispel)).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1A5:
			enumerator3 = strategy.Selections.GetEnumerator();
			num = 4294967293u;
			goto Block_5;
		}

		// Token: 0x170012AC RID: 4780
		// (get) Token: 0x06005993 RID: 22931 RVA: 0x00130BFC File Offset: 0x0012EFFC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012AD RID: 4781
		// (get) Token: 0x06005994 RID: 22932 RVA: 0x00130C04 File Offset: 0x0012F004
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005995 RID: 22933 RVA: 0x00130C0C File Offset: 0x0012F00C
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
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					case 2u:
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005996 RID: 22934 RVA: 0x00130D54 File Offset: 0x0012F154
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005997 RID: 22935 RVA: 0x00130D5B File Offset: 0x0012F15B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005998 RID: 22936 RVA: 0x00130D64 File Offset: 0x0012F164
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BloodCurse.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new BloodCurse.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005999 RID: 22937 RVA: 0x00130DB0 File Offset: 0x0012F1B0
		private static int <>m__0(BloodCurseDispelPartyEnhancementData s)
		{
			return s.NumberOfDispels;
		}

		// Token: 0x040049C4 RID: 18884
		internal AdventureUnitSkill skill;

		// Token: 0x040049C5 RID: 18885
		internal int <totalDispel>__1;

		// Token: 0x040049C6 RID: 18886
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040049C7 RID: 18887
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040049C8 RID: 18888
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040049C9 RID: 18889
		internal IEnumerator $locvar1;

		// Token: 0x040049CA RID: 18890
		internal object <_>__3;

		// Token: 0x040049CB RID: 18891
		internal IDisposable $locvar2;

		// Token: 0x040049CC RID: 18892
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x040049CD RID: 18893
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x040049CE RID: 18894
		internal IBattleUnit <unit>__4;

		// Token: 0x040049CF RID: 18895
		internal IEnumerator $locvar4;

		// Token: 0x040049D0 RID: 18896
		internal object <_>__5;

		// Token: 0x040049D1 RID: 18897
		internal IDisposable $locvar5;

		// Token: 0x040049D2 RID: 18898
		internal IEnumerator $locvar6;

		// Token: 0x040049D3 RID: 18899
		internal object <_>__6;

		// Token: 0x040049D4 RID: 18900
		internal IDisposable $locvar7;

		// Token: 0x040049D5 RID: 18901
		internal BloodCurse $this;

		// Token: 0x040049D6 RID: 18902
		internal object $current;

		// Token: 0x040049D7 RID: 18903
		internal bool $disposing;

		// Token: 0x040049D8 RID: 18904
		internal int $PC;

		// Token: 0x040049D9 RID: 18905
		private static Func<BloodCurseDispelPartyEnhancementData, int> <>f__am$cache0;
	}

	// Token: 0x02000DF3 RID: 3571
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600599A RID: 22938 RVA: 0x00130DB8 File Offset: 0x0012F1B8
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x0600599B RID: 22939 RVA: 0x00130DC0 File Offset: 0x0012F1C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateBloodCurseEffect(base.GetType().FullName + "passive", new int?(2), base.PassiveSpeedRate(skill.Skill), base.PassiveOutputRate(skill.Skill), skill), false).GetEnumerator();
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

		// Token: 0x170012AE RID: 4782
		// (get) Token: 0x0600599C RID: 22940 RVA: 0x00130F04 File Offset: 0x0012F304
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012AF RID: 4783
		// (get) Token: 0x0600599D RID: 22941 RVA: 0x00130F0C File Offset: 0x0012F30C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600599E RID: 22942 RVA: 0x00130F14 File Offset: 0x0012F314
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

		// Token: 0x0600599F RID: 22943 RVA: 0x00130F84 File Offset: 0x0012F384
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059A0 RID: 22944 RVA: 0x00130F8B File Offset: 0x0012F38B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059A1 RID: 22945 RVA: 0x00130F94 File Offset: 0x0012F394
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BloodCurse.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new BloodCurse.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x040049DA RID: 18906
		internal AdventureUnitSkill skill;

		// Token: 0x040049DB RID: 18907
		internal IEnumerator $locvar0;

		// Token: 0x040049DC RID: 18908
		internal object <_>__1;

		// Token: 0x040049DD RID: 18909
		internal IDisposable $locvar1;

		// Token: 0x040049DE RID: 18910
		internal BloodCurse $this;

		// Token: 0x040049DF RID: 18911
		internal object $current;

		// Token: 0x040049E0 RID: 18912
		internal bool $disposing;

		// Token: 0x040049E1 RID: 18913
		internal int $PC;
	}

	// Token: 0x02000DF4 RID: 3572
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059A2 RID: 22946 RVA: 0x00130FD4 File Offset: 0x0012F3D4
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x060059A3 RID: 22947 RVA: 0x00130FDC File Offset: 0x0012F3DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				tobeRemoved = (from s in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where s.EffectSourceIdentityCode == base.GetType().FullName + "passive"
				select s).ToList<AttributeModificationEffect>();
				enumerator = tobeRemoved.GetEnumerator();
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
					bloodCurseEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(bloodCurseEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012B0 RID: 4784
		// (get) Token: 0x060059A4 RID: 22948 RVA: 0x0013116C File Offset: 0x0012F56C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012B1 RID: 4785
		// (get) Token: 0x060059A5 RID: 22949 RVA: 0x00131174 File Offset: 0x0012F574
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059A6 RID: 22950 RVA: 0x0013117C File Offset: 0x0012F57C
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

		// Token: 0x060059A7 RID: 22951 RVA: 0x00131210 File Offset: 0x0012F610
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059A8 RID: 22952 RVA: 0x00131217 File Offset: 0x0012F617
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059A9 RID: 22953 RVA: 0x00131220 File Offset: 0x0012F620
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BloodCurse.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new BloodCurse.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x060059AA RID: 22954 RVA: 0x00131260 File Offset: 0x0012F660
		internal bool <>m__0(AttributeModificationEffect s)
		{
			return s.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x040049E2 RID: 18914
		internal AdventureUnitSkill skill;

		// Token: 0x040049E3 RID: 18915
		internal List<AttributeModificationEffect> <tobeRemoved>__0;

		// Token: 0x040049E4 RID: 18916
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x040049E5 RID: 18917
		internal AttributeModificationEffect <bloodCurseEffect>__1;

		// Token: 0x040049E6 RID: 18918
		internal IEnumerator $locvar1;

		// Token: 0x040049E7 RID: 18919
		internal object <_>__2;

		// Token: 0x040049E8 RID: 18920
		internal IDisposable $locvar2;

		// Token: 0x040049E9 RID: 18921
		internal BloodCurse $this;

		// Token: 0x040049EA RID: 18922
		internal object $current;

		// Token: 0x040049EB RID: 18923
		internal bool $disposing;

		// Token: 0x040049EC RID: 18924
		internal int $PC;
	}
}
