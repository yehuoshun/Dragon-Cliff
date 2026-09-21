using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006C5 RID: 1733
public class GrandMeteorolite : ActiveSkillLogicBase
{
	// Token: 0x06002E90 RID: 11920 RVA: 0x00139824 File Offset: 0x00137C24
	public GrandMeteorolite()
	{
	}

	// Token: 0x06002E91 RID: 11921 RVA: 0x0013984C File Offset: 0x00137C4C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TacticTargetAttributeDebuffTalent(SkillType.GrandMeteorolite, 1),
			new MeteoroliteElementalTalent(SkillType.GrandMeteorolite, 2),
			new MeteoroliteElementalTalent(SkillType.GrandMeteorolite, 3)
		};
	}

	// Token: 0x170005FE RID: 1534
	// (get) Token: 0x06002E92 RID: 11922 RVA: 0x00139893 File Offset: 0x00137C93
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005FF RID: 1535
	// (get) Token: 0x06002E93 RID: 11923 RVA: 0x0013989B File Offset: 0x00137C9B
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000600 RID: 1536
	// (get) Token: 0x06002E94 RID: 11924 RVA: 0x001398A3 File Offset: 0x00137CA3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000601 RID: 1537
	// (get) Token: 0x06002E95 RID: 11925 RVA: 0x001398AB File Offset: 0x00137CAB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E96 RID: 11926 RVA: 0x001398B3 File Offset: 0x00137CB3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002E97 RID: 11927 RVA: 0x001398BA File Offset: 0x00137CBA
	public override double GetGaugeCost(Skill skill)
	{
		return 70.0;
	}

	// Token: 0x06002E98 RID: 11928 RVA: 0x001398C5 File Offset: 0x00137CC5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1.5f);
	}

	// Token: 0x06002E99 RID: 11929 RVA: 0x001398D1 File Offset: 0x00137CD1
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002E9A RID: 11930 RVA: 0x001398D9 File Offset: 0x00137CD9
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002E9B RID: 11931 RVA: 0x001398E0 File Offset: 0x00137CE0
	private double ActiveDamageRate(Skill skill)
	{
		if (skill.Level == 1)
		{
			return 1.25;
		}
		if (skill.Level == 2)
		{
			return 1.75;
		}
		return 2.5;
	}

	// Token: 0x06002E9C RID: 11932 RVA: 0x00139917 File Offset: 0x00137D17
	private double PassiveBoostRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002E9D RID: 11933 RVA: 0x00139938 File Offset: 0x00137D38
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.MainDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E9E RID: 11934 RVA: 0x001399A4 File Offset: 0x00137DA4
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		OutputType damageType = OutputType.Fire;
		double damageRate = this.ActiveDamageRate(skill.Skill);
		GrandMeteoroliteElementalChangeData elementalEnhancement = skill.SourceUnit.SpecialEffects.OfType<GrandMeteoroliteElementalChangeData>().FirstOrDefault<GrandMeteoroliteElementalChangeData>();
		if (elementalEnhancement != null)
		{
			damageType = elementalEnhancement.Type;
			damageRate += elementalEnhancement.ExtraDamageRate;
		}
		foreach (IBattleUnit target in strategy.Selections)
		{
			damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, damageType, damageRate),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
				}, target, skill.SourceUnit, true, false)
			}));
		}
		ReleaseableDamage rs = new ReleaseableDamage(damages, skill.SourceUnit);
		IEnumerator enumerator2 = rs.Release().GetEnumerator();
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

	// Token: 0x06002E9F RID: 11935 RVA: 0x001399D8 File Offset: 0x00137DD8
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateIntelligienceBoostEffect(base.GetType().FullName, this.PassiveBoostRate(skill.Skill), null, null, skill), false).GetEnumerator();
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

	// Token: 0x06002EA0 RID: 11936 RVA: 0x00139A04 File Offset: 0x00137E04
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect intelligienceBoostEffect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(intelligienceBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x04002715 RID: 10005
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x04002716 RID: 10006
	private OutputType _skillOutputType = OutputType.Fire;

	// Token: 0x04002717 RID: 10007
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002718 RID: 10008
	private SkillType _skillType = SkillType.GrandMeteorolite;

	// Token: 0x02000E16 RID: 3606
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AB1 RID: 23217 RVA: 0x00139A2E File Offset: 0x00137E2E
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005AB2 RID: 23218 RVA: 0x00139A38 File Offset: 0x00137E38
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				damageType = OutputType.Fire;
				damageRate = base.ActiveDamageRate(skill.Skill);
				elementalEnhancement = skill.SourceUnit.SpecialEffects.OfType<GrandMeteoroliteElementalChangeData>().FirstOrDefault<GrandMeteoroliteElementalChangeData>();
				if (elementalEnhancement != null)
				{
					damageType = elementalEnhancement.Type;
					damageRate += elementalEnhancement.ExtraDamageRate;
				}
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, damageType, damageRate),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
							}, target, skill.SourceUnit, true, false)
						}));
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				rs = new ReleaseableDamage(damages, skill.SourceUnit);
				enumerator2 = rs.Release().GetEnumerator();
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

		// Token: 0x170012EC RID: 4844
		// (get) Token: 0x06005AB3 RID: 23219 RVA: 0x00139CAC File Offset: 0x001380AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012ED RID: 4845
		// (get) Token: 0x06005AB4 RID: 23220 RVA: 0x00139CB4 File Offset: 0x001380B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AB5 RID: 23221 RVA: 0x00139CBC File Offset: 0x001380BC
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

		// Token: 0x06005AB6 RID: 23222 RVA: 0x00139D2C File Offset: 0x0013812C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AB7 RID: 23223 RVA: 0x00139D33 File Offset: 0x00138133
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AB8 RID: 23224 RVA: 0x00139D3C File Offset: 0x0013813C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GrandMeteorolite.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new GrandMeteorolite.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004BA3 RID: 19363
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004BA4 RID: 19364
		internal OutputType <damageType>__0;

		// Token: 0x04004BA5 RID: 19365
		internal AdventureUnitSkill skill;

		// Token: 0x04004BA6 RID: 19366
		internal double <damageRate>__0;

		// Token: 0x04004BA7 RID: 19367
		internal GrandMeteoroliteElementalChangeData <elementalEnhancement>__0;

		// Token: 0x04004BA8 RID: 19368
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004BA9 RID: 19369
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004BAA RID: 19370
		internal ReleaseableDamage <rs>__0;

		// Token: 0x04004BAB RID: 19371
		internal IEnumerator $locvar1;

		// Token: 0x04004BAC RID: 19372
		internal object <_>__1;

		// Token: 0x04004BAD RID: 19373
		internal IDisposable $locvar2;

		// Token: 0x04004BAE RID: 19374
		internal GrandMeteorolite $this;

		// Token: 0x04004BAF RID: 19375
		internal object $current;

		// Token: 0x04004BB0 RID: 19376
		internal bool $disposing;

		// Token: 0x04004BB1 RID: 19377
		internal int $PC;
	}

	// Token: 0x02000E17 RID: 3607
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AB9 RID: 23225 RVA: 0x00139D88 File Offset: 0x00138188
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005ABA RID: 23226 RVA: 0x00139D90 File Offset: 0x00138190
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateIntelligienceBoostEffect(base.GetType().FullName, base.PassiveBoostRate(skill.Skill), null, null, skill), false).GetEnumerator();
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

		// Token: 0x170012EE RID: 4846
		// (get) Token: 0x06005ABB RID: 23227 RVA: 0x00139EC0 File Offset: 0x001382C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012EF RID: 4847
		// (get) Token: 0x06005ABC RID: 23228 RVA: 0x00139EC8 File Offset: 0x001382C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005ABD RID: 23229 RVA: 0x00139ED0 File Offset: 0x001382D0
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

		// Token: 0x06005ABE RID: 23230 RVA: 0x00139F40 File Offset: 0x00138340
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005ABF RID: 23231 RVA: 0x00139F47 File Offset: 0x00138347
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AC0 RID: 23232 RVA: 0x00139F50 File Offset: 0x00138350
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GrandMeteorolite.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new GrandMeteorolite.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004BB2 RID: 19378
		internal AdventureUnitSkill skill;

		// Token: 0x04004BB3 RID: 19379
		internal IEnumerator $locvar0;

		// Token: 0x04004BB4 RID: 19380
		internal object <_>__1;

		// Token: 0x04004BB5 RID: 19381
		internal IDisposable $locvar1;

		// Token: 0x04004BB6 RID: 19382
		internal GrandMeteorolite $this;

		// Token: 0x04004BB7 RID: 19383
		internal object $current;

		// Token: 0x04004BB8 RID: 19384
		internal bool $disposing;

		// Token: 0x04004BB9 RID: 19385
		internal int $PC;
	}

	// Token: 0x02000E18 RID: 3608
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AC1 RID: 23233 RVA: 0x00139F90 File Offset: 0x00138390
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005AC2 RID: 23234 RVA: 0x00139F98 File Offset: 0x00138398
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName
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
					intelligienceBoostEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(intelligienceBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012F0 RID: 4848
		// (get) Token: 0x06005AC3 RID: 23235 RVA: 0x0013A128 File Offset: 0x00138528
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012F1 RID: 4849
		// (get) Token: 0x06005AC4 RID: 23236 RVA: 0x0013A130 File Offset: 0x00138530
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AC5 RID: 23237 RVA: 0x0013A138 File Offset: 0x00138538
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

		// Token: 0x06005AC6 RID: 23238 RVA: 0x0013A1CC File Offset: 0x001385CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AC7 RID: 23239 RVA: 0x0013A1D3 File Offset: 0x001385D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AC8 RID: 23240 RVA: 0x0013A1DC File Offset: 0x001385DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GrandMeteorolite.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new GrandMeteorolite.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005AC9 RID: 23241 RVA: 0x0013A21C File Offset: 0x0013861C
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName;
		}

		// Token: 0x04004BBA RID: 19386
		internal AdventureUnitSkill skill;

		// Token: 0x04004BBB RID: 19387
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004BBC RID: 19388
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004BBD RID: 19389
		internal AttributeModificationEffect <intelligienceBoostEffect>__1;

		// Token: 0x04004BBE RID: 19390
		internal IEnumerator $locvar1;

		// Token: 0x04004BBF RID: 19391
		internal object <_>__2;

		// Token: 0x04004BC0 RID: 19392
		internal IDisposable $locvar2;

		// Token: 0x04004BC1 RID: 19393
		internal GrandMeteorolite $this;

		// Token: 0x04004BC2 RID: 19394
		internal object $current;

		// Token: 0x04004BC3 RID: 19395
		internal bool $disposing;

		// Token: 0x04004BC4 RID: 19396
		internal int $PC;
	}
}
