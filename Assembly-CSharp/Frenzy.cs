using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006C3 RID: 1731
public class Frenzy : ActiveSkillLogicBase
{
	// Token: 0x06002E6E RID: 11886 RVA: 0x00138029 File Offset: 0x00136429
	public Frenzy()
	{
	}

	// Token: 0x06002E6F RID: 11887 RVA: 0x0013804C File Offset: 0x0013644C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new FrenzyDispelTalent(SkillType.Frenzy, 1),
			new FrenzyPushTalent(SkillType.Frenzy, 2),
			new FrenzyStunTalent(SkillType.Frenzy, 3)
		};
	}

	// Token: 0x170005F6 RID: 1526
	// (get) Token: 0x06002E70 RID: 11888 RVA: 0x00138093 File Offset: 0x00136493
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005F7 RID: 1527
	// (get) Token: 0x06002E71 RID: 11889 RVA: 0x0013809B File Offset: 0x0013649B
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005F8 RID: 1528
	// (get) Token: 0x06002E72 RID: 11890 RVA: 0x001380A3 File Offset: 0x001364A3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005F9 RID: 1529
	// (get) Token: 0x06002E73 RID: 11891 RVA: 0x001380AB File Offset: 0x001364AB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E74 RID: 11892 RVA: 0x001380B3 File Offset: 0x001364B3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002E75 RID: 11893 RVA: 0x001380BA File Offset: 0x001364BA
	public override double GetGaugeCost(Skill skill)
	{
		return 70.0;
	}

	// Token: 0x06002E76 RID: 11894 RVA: 0x001380C5 File Offset: 0x001364C5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(2.5f);
	}

	// Token: 0x06002E77 RID: 11895 RVA: 0x001380D1 File Offset: 0x001364D1
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002E78 RID: 11896 RVA: 0x001380D9 File Offset: 0x001364D9
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002E79 RID: 11897 RVA: 0x001380E0 File Offset: 0x001364E0
	private double ActiveDamageRate(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E7A RID: 11898 RVA: 0x001380FF File Offset: 0x001364FF
	private double PassiveDamageRate(Skill skill)
	{
		return 0.06 + (double)(skill.Level - 1) * 0.03;
	}

	// Token: 0x06002E7B RID: 11899 RVA: 0x00138120 File Offset: 0x00136520
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.AdditionalDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.AdditionalDamageRateKey, this.PassiveDamageRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E7C RID: 11900 RVA: 0x00138174 File Offset: 0x00136574
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			IEnumerator enumerator2 = strategySelection.ApplySkillEffect(new FrenzyEffect(base.GetType().FullName + "active", null, new int?(2), this.ActiveDamageRate(skill.Skill), skill), false).GetEnumerator();
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

	// Token: 0x06002E7D RID: 11901 RVA: 0x001381A8 File Offset: 0x001365A8
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		List<IBattleUnit> friendlyAll = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
		foreach (IBattleUnit battleUnit in friendlyAll)
		{
			IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new FrenzyEffect(base.GetType().FullName + "passive", null, null, this.PassiveDamageRate(skill.Skill), skill), false).GetEnumerator();
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

	// Token: 0x06002E7E RID: 11902 RVA: 0x001381D4 File Offset: 0x001365D4
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<IBattleUnit> friendlyAll = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
		foreach (IBattleUnit battleUnit in friendlyAll)
		{
			List<FrenzyEffect> toRemove = (from ef in battleUnit.BattleEffects.OfType<FrenzyEffect>()
			where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
			select ef).ToList<FrenzyEffect>();
			foreach (FrenzyEffect frenzyEffect in toRemove)
			{
				IEnumerator enumerator3 = battleUnit.LooseSkillEffect(frenzyEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x0400270C RID: 9996
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x0400270D RID: 9997
	private OutputType _skillOutputType;

	// Token: 0x0400270E RID: 9998
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x0400270F RID: 9999
	private SkillType _skillType = SkillType.Frenzy;

	// Token: 0x02000E11 RID: 3601
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A87 RID: 23175 RVA: 0x001381FE File Offset: 0x001365FE
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005A88 RID: 23176 RVA: 0x00138208 File Offset: 0x00136608
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = strategy.Selections.GetEnumerator();
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
					strategySelection = enumerator.Current;
					enumerator2 = strategySelection.ApplySkillEffect(new FrenzyEffect(base.GetType().FullName + "active", null, new int?(2), base.ActiveDamageRate(skill.Skill), skill), false).GetEnumerator();
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

		// Token: 0x170012E2 RID: 4834
		// (get) Token: 0x06005A89 RID: 23177 RVA: 0x001383C4 File Offset: 0x001367C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012E3 RID: 4835
		// (get) Token: 0x06005A8A RID: 23178 RVA: 0x001383CC File Offset: 0x001367CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A8B RID: 23179 RVA: 0x001383D4 File Offset: 0x001367D4
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

		// Token: 0x06005A8C RID: 23180 RVA: 0x00138468 File Offset: 0x00136868
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A8D RID: 23181 RVA: 0x0013846F File Offset: 0x0013686F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A8E RID: 23182 RVA: 0x00138478 File Offset: 0x00136878
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Frenzy.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Frenzy.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004B56 RID: 19286
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004B57 RID: 19287
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004B58 RID: 19288
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004B59 RID: 19289
		internal AdventureUnitSkill skill;

		// Token: 0x04004B5A RID: 19290
		internal IEnumerator $locvar1;

		// Token: 0x04004B5B RID: 19291
		internal object <_>__2;

		// Token: 0x04004B5C RID: 19292
		internal IDisposable $locvar2;

		// Token: 0x04004B5D RID: 19293
		internal Frenzy $this;

		// Token: 0x04004B5E RID: 19294
		internal object $current;

		// Token: 0x04004B5F RID: 19295
		internal bool $disposing;

		// Token: 0x04004B60 RID: 19296
		internal int $PC;
	}

	// Token: 0x02000E12 RID: 3602
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A8F RID: 23183 RVA: 0x001384C4 File Offset: 0x001368C4
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005A90 RID: 23184 RVA: 0x001384CC File Offset: 0x001368CC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				friendlyAll = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyAll.GetEnumerator();
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
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new FrenzyEffect(base.GetType().FullName + "passive", null, null, base.PassiveDamageRate(skill.Skill), skill), false).GetEnumerator();
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

		// Token: 0x170012E4 RID: 4836
		// (get) Token: 0x06005A91 RID: 23185 RVA: 0x001386A0 File Offset: 0x00136AA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012E5 RID: 4837
		// (get) Token: 0x06005A92 RID: 23186 RVA: 0x001386A8 File Offset: 0x00136AA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A93 RID: 23187 RVA: 0x001386B0 File Offset: 0x00136AB0
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

		// Token: 0x06005A94 RID: 23188 RVA: 0x00138744 File Offset: 0x00136B44
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A95 RID: 23189 RVA: 0x0013874B File Offset: 0x00136B4B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A96 RID: 23190 RVA: 0x00138754 File Offset: 0x00136B54
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Frenzy.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new Frenzy.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004B61 RID: 19297
		internal AdventureUnitSkill skill;

		// Token: 0x04004B62 RID: 19298
		internal List<IBattleUnit> <friendlyAll>__0;

		// Token: 0x04004B63 RID: 19299
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004B64 RID: 19300
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004B65 RID: 19301
		internal IEnumerator $locvar1;

		// Token: 0x04004B66 RID: 19302
		internal object <_>__2;

		// Token: 0x04004B67 RID: 19303
		internal IDisposable $locvar2;

		// Token: 0x04004B68 RID: 19304
		internal Frenzy $this;

		// Token: 0x04004B69 RID: 19305
		internal object $current;

		// Token: 0x04004B6A RID: 19306
		internal bool $disposing;

		// Token: 0x04004B6B RID: 19307
		internal int $PC;
	}

	// Token: 0x02000E13 RID: 3603
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A97 RID: 23191 RVA: 0x00138794 File Offset: 0x00136B94
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005A98 RID: 23192 RVA: 0x0013879C File Offset: 0x00136B9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				friendlyAll = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyAll.GetEnumerator();
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
						case 1u:
							Block_7:
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
							frenzyEffect = enumerator2.Current;
							enumerator3 = battleUnit.LooseSkillEffect(frenzyEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
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
					toRemove = (from ef in battleUnit.BattleEffects.OfType<FrenzyEffect>()
					where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
					select ef).ToList<FrenzyEffect>();
					enumerator2 = toRemove.GetEnumerator();
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

		// Token: 0x170012E6 RID: 4838
		// (get) Token: 0x06005A99 RID: 23193 RVA: 0x001389CC File Offset: 0x00136DCC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012E7 RID: 4839
		// (get) Token: 0x06005A9A RID: 23194 RVA: 0x001389D4 File Offset: 0x00136DD4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A9B RID: 23195 RVA: 0x001389DC File Offset: 0x00136DDC
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

		// Token: 0x06005A9C RID: 23196 RVA: 0x00138A94 File Offset: 0x00136E94
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A9D RID: 23197 RVA: 0x00138A9B File Offset: 0x00136E9B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A9E RID: 23198 RVA: 0x00138AA4 File Offset: 0x00136EA4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Frenzy.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new Frenzy.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005A9F RID: 23199 RVA: 0x00138AE4 File Offset: 0x00136EE4
		internal bool <>m__0(FrenzyEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004B6C RID: 19308
		internal AdventureUnitSkill skill;

		// Token: 0x04004B6D RID: 19309
		internal List<IBattleUnit> <friendlyAll>__0;

		// Token: 0x04004B6E RID: 19310
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004B6F RID: 19311
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004B70 RID: 19312
		internal List<FrenzyEffect> <toRemove>__2;

		// Token: 0x04004B71 RID: 19313
		internal List<FrenzyEffect>.Enumerator $locvar1;

		// Token: 0x04004B72 RID: 19314
		internal FrenzyEffect <frenzyEffect>__3;

		// Token: 0x04004B73 RID: 19315
		internal IEnumerator $locvar2;

		// Token: 0x04004B74 RID: 19316
		internal object <_>__4;

		// Token: 0x04004B75 RID: 19317
		internal IDisposable $locvar3;

		// Token: 0x04004B76 RID: 19318
		internal Frenzy $this;

		// Token: 0x04004B77 RID: 19319
		internal object $current;

		// Token: 0x04004B78 RID: 19320
		internal bool $disposing;

		// Token: 0x04004B79 RID: 19321
		internal int $PC;
	}
}
