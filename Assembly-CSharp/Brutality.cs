using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x020006BA RID: 1722
public class Brutality : ActiveSkillLogicBase
{
	// Token: 0x06002DCC RID: 11724 RVA: 0x00131287 File Offset: 0x0012F687
	public Brutality()
	{
	}

	// Token: 0x06002DCD RID: 11725 RVA: 0x001312B0 File Offset: 0x0012F6B0
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new PriorCastDecayTalent(SkillType.Brutality, 1),
			new PriorCastDecayTalent(SkillType.Brutality, 2),
			new PriorCastDispelTalent(SkillType.Brutality, 3)
		};
	}

	// Token: 0x170005D2 RID: 1490
	// (get) Token: 0x06002DCE RID: 11726 RVA: 0x001312F7 File Offset: 0x0012F6F7
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005D3 RID: 1491
	// (get) Token: 0x06002DCF RID: 11727 RVA: 0x001312FF File Offset: 0x0012F6FF
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005D4 RID: 1492
	// (get) Token: 0x06002DD0 RID: 11728 RVA: 0x00131307 File Offset: 0x0012F707
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005D5 RID: 1493
	// (get) Token: 0x06002DD1 RID: 11729 RVA: 0x0013130F File Offset: 0x0012F70F
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002DD2 RID: 11730 RVA: 0x00131317 File Offset: 0x0012F717
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileSingleStrategy>();
	}

	// Token: 0x06002DD3 RID: 11731 RVA: 0x0013131E File Offset: 0x0012F71E
	public override double GetGaugeCost(Skill skill)
	{
		return 65.0;
	}

	// Token: 0x06002DD4 RID: 11732 RVA: 0x00131329 File Offset: 0x0012F729
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1.5f);
	}

	// Token: 0x06002DD5 RID: 11733 RVA: 0x00131335 File Offset: 0x0012F735
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileSingleStrategy(skill);
	}

	// Token: 0x06002DD6 RID: 11734 RVA: 0x0013133D File Offset: 0x0012F73D
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002DD7 RID: 11735 RVA: 0x00131344 File Offset: 0x0012F744
	private double ActiveDamageRate(Skill skill)
	{
		if (skill.Level == 1)
		{
			return 2.5;
		}
		if (skill.Level == 2)
		{
			return 4.5;
		}
		return 6.0;
	}

	// Token: 0x06002DD8 RID: 11736 RVA: 0x0013137B File Offset: 0x0012F77B
	private double ActiveCasterDamageRate(Skill skill)
	{
		if (skill.Level == 1)
		{
			return 2.0;
		}
		if (skill.Level == 2)
		{
			return 3.0;
		}
		return 4.0;
	}

	// Token: 0x06002DD9 RID: 11737 RVA: 0x001313B4 File Offset: 0x0012F7B4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.MainDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.ActiveCasterDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002DDA RID: 11738 RVA: 0x0013141F File Offset: 0x0012F81F
	private double PassiveBoostRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002DDB RID: 11739 RVA: 0x00131440 File Offset: 0x0012F840
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStrengthBoostEffect(skill, this.PassiveBoostRate(skill.Skill) * skill.SourceUnit.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill), base.GetType().FullName + "passive", null), false).GetEnumerator();
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

	// Token: 0x06002DDC RID: 11740 RVA: 0x0013146C File Offset: 0x0012F86C
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect physicalPenetrationBoostEffect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(physicalPenetrationBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x06002DDD RID: 11741 RVA: 0x00131498 File Offset: 0x0012F898
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		double additionalRate = skill.SourceUnit.SpecialEffects.OfType<RedHornStarDamageBoostData>().Sum((RedHornStarDamageBoostData s) => s.Rate);
		foreach (IBattleUnit target in strategy.Selections)
		{
			damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, this.ActiveDamageRate(skill.Skill) + additionalRate),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), this.ActiveCasterDamageRate(skill.Skill) + additionalRate)
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

	// Token: 0x040026E4 RID: 9956
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x040026E5 RID: 9957
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x040026E6 RID: 9958
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026E7 RID: 9959
	private SkillType _skillType = SkillType.Brutality;

	// Token: 0x02000DF5 RID: 3573
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059AB RID: 22955 RVA: 0x001314C9 File Offset: 0x0012F8C9
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator0()
		{
		}

		// Token: 0x060059AC RID: 22956 RVA: 0x001314D4 File Offset: 0x0012F8D4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStrengthBoostEffect(skill, base.PassiveBoostRate(skill.Skill) * skill.SourceUnit.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill), base.GetType().FullName + "passive", null), false).GetEnumerator();
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

		// Token: 0x170012B2 RID: 4786
		// (get) Token: 0x060059AD RID: 22957 RVA: 0x00131618 File Offset: 0x0012FA18
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012B3 RID: 4787
		// (get) Token: 0x060059AE RID: 22958 RVA: 0x00131620 File Offset: 0x0012FA20
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059AF RID: 22959 RVA: 0x00131628 File Offset: 0x0012FA28
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

		// Token: 0x060059B0 RID: 22960 RVA: 0x00131698 File Offset: 0x0012FA98
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059B1 RID: 22961 RVA: 0x0013169F File Offset: 0x0012FA9F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059B2 RID: 22962 RVA: 0x001316A8 File Offset: 0x0012FAA8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Brutality.<PassiveEffectApplies>c__Iterator0 <PassiveEffectApplies>c__Iterator = new Brutality.<PassiveEffectApplies>c__Iterator0();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x040049ED RID: 18925
		internal AdventureUnitSkill skill;

		// Token: 0x040049EE RID: 18926
		internal IEnumerator $locvar0;

		// Token: 0x040049EF RID: 18927
		internal object <_>__1;

		// Token: 0x040049F0 RID: 18928
		internal IDisposable $locvar1;

		// Token: 0x040049F1 RID: 18929
		internal Brutality $this;

		// Token: 0x040049F2 RID: 18930
		internal object $current;

		// Token: 0x040049F3 RID: 18931
		internal bool $disposing;

		// Token: 0x040049F4 RID: 18932
		internal int $PC;
	}

	// Token: 0x02000DF6 RID: 3574
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059B3 RID: 22963 RVA: 0x001316E8 File Offset: 0x0012FAE8
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator1()
		{
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x001316F0 File Offset: 0x0012FAF0
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
					physicalPenetrationBoostEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(physicalPenetrationBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012B4 RID: 4788
		// (get) Token: 0x060059B5 RID: 22965 RVA: 0x00131880 File Offset: 0x0012FC80
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012B5 RID: 4789
		// (get) Token: 0x060059B6 RID: 22966 RVA: 0x00131888 File Offset: 0x0012FC88
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059B7 RID: 22967 RVA: 0x00131890 File Offset: 0x0012FC90
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

		// Token: 0x060059B8 RID: 22968 RVA: 0x00131924 File Offset: 0x0012FD24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059B9 RID: 22969 RVA: 0x0013192B File Offset: 0x0012FD2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059BA RID: 22970 RVA: 0x00131934 File Offset: 0x0012FD34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Brutality.<PassiveEffectLooses>c__Iterator1 <PassiveEffectLooses>c__Iterator = new Brutality.<PassiveEffectLooses>c__Iterator1();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x060059BB RID: 22971 RVA: 0x00131974 File Offset: 0x0012FD74
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x040049F5 RID: 18933
		internal AdventureUnitSkill skill;

		// Token: 0x040049F6 RID: 18934
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x040049F7 RID: 18935
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x040049F8 RID: 18936
		internal AttributeModificationEffect <physicalPenetrationBoostEffect>__1;

		// Token: 0x040049F9 RID: 18937
		internal IEnumerator $locvar1;

		// Token: 0x040049FA RID: 18938
		internal object <_>__2;

		// Token: 0x040049FB RID: 18939
		internal IDisposable $locvar2;

		// Token: 0x040049FC RID: 18940
		internal Brutality $this;

		// Token: 0x040049FD RID: 18941
		internal object $current;

		// Token: 0x040049FE RID: 18942
		internal bool $disposing;

		// Token: 0x040049FF RID: 18943
		internal int $PC;
	}

	// Token: 0x02000DF7 RID: 3575
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059BC RID: 22972 RVA: 0x0013199B File Offset: 0x0012FD9B
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator2()
		{
		}

		// Token: 0x060059BD RID: 22973 RVA: 0x001319A4 File Offset: 0x0012FDA4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				additionalRate = skill.SourceUnit.SpecialEffects.OfType<RedHornStarDamageBoostData>().Sum((RedHornStarDamageBoostData s) => s.Rate);
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
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, base.ActiveDamageRate(skill.Skill) + additionalRate),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), base.ActiveCasterDamageRate(skill.Skill) + additionalRate)
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

		// Token: 0x170012B6 RID: 4790
		// (get) Token: 0x060059BE RID: 22974 RVA: 0x00131C04 File Offset: 0x00130004
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012B7 RID: 4791
		// (get) Token: 0x060059BF RID: 22975 RVA: 0x00131C0C File Offset: 0x0013000C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x00131C14 File Offset: 0x00130014
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

		// Token: 0x060059C1 RID: 22977 RVA: 0x00131C84 File Offset: 0x00130084
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059C2 RID: 22978 RVA: 0x00131C8B File Offset: 0x0013008B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059C3 RID: 22979 RVA: 0x00131C94 File Offset: 0x00130094
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Brutality.<CastSkillLogic>c__Iterator2 <CastSkillLogic>c__Iterator = new Brutality.<CastSkillLogic>c__Iterator2();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x060059C4 RID: 22980 RVA: 0x00131CE0 File Offset: 0x001300E0
		private static double <>m__0(RedHornStarDamageBoostData s)
		{
			return s.Rate;
		}

		// Token: 0x04004A00 RID: 18944
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004A01 RID: 18945
		internal AdventureUnitSkill skill;

		// Token: 0x04004A02 RID: 18946
		internal double <additionalRate>__0;

		// Token: 0x04004A03 RID: 18947
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004A04 RID: 18948
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004A05 RID: 18949
		internal ReleaseableDamage <rs>__0;

		// Token: 0x04004A06 RID: 18950
		internal IEnumerator $locvar1;

		// Token: 0x04004A07 RID: 18951
		internal object <_>__1;

		// Token: 0x04004A08 RID: 18952
		internal IDisposable $locvar2;

		// Token: 0x04004A09 RID: 18953
		internal Brutality $this;

		// Token: 0x04004A0A RID: 18954
		internal object $current;

		// Token: 0x04004A0B RID: 18955
		internal bool $disposing;

		// Token: 0x04004A0C RID: 18956
		internal int $PC;

		// Token: 0x04004A0D RID: 18957
		private static Func<RedHornStarDamageBoostData, double> <>f__am$cache0;
	}
}
