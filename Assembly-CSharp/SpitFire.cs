using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006CE RID: 1742
public class SpitFire : ActiveSkillLogicBase
{
	// Token: 0x06002F2C RID: 12076 RVA: 0x0014206C File Offset: 0x0014046C
	public SpitFire()
	{
	}

	// Token: 0x06002F2D RID: 12077 RVA: 0x00142094 File Offset: 0x00140494
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SpitFireSelfProtectionTalent(SkillType.GodsFire, 1),
			new SpitFireFocusTalent(SkillType.GodsFire, 2),
			new SpitFireDispelTalent(SkillType.GodsFire, 3)
		};
	}

	// Token: 0x17000622 RID: 1570
	// (get) Token: 0x06002F2E RID: 12078 RVA: 0x001420DB File Offset: 0x001404DB
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000623 RID: 1571
	// (get) Token: 0x06002F2F RID: 12079 RVA: 0x001420E3 File Offset: 0x001404E3
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000624 RID: 1572
	// (get) Token: 0x06002F30 RID: 12080 RVA: 0x001420EB File Offset: 0x001404EB
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000625 RID: 1573
	// (get) Token: 0x06002F31 RID: 12081 RVA: 0x001420F3 File Offset: 0x001404F3
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F32 RID: 12082 RVA: 0x001420FB File Offset: 0x001404FB
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<SelfStrategy>();
	}

	// Token: 0x06002F33 RID: 12083 RVA: 0x00142102 File Offset: 0x00140502
	public override double GetGaugeCost(Skill skill)
	{
		return 60.0;
	}

	// Token: 0x06002F34 RID: 12084 RVA: 0x0014210D File Offset: 0x0014050D
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F35 RID: 12085 RVA: 0x00142119 File Offset: 0x00140519
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new SelfStrategy(skill);
	}

	// Token: 0x06002F36 RID: 12086 RVA: 0x00142121 File Offset: 0x00140521
	private float TotalBuffLength(Skill skill)
	{
		return 10f;
	}

	// Token: 0x06002F37 RID: 12087 RVA: 0x00142128 File Offset: 0x00140528
	private double ActiveDamageRate(Skill skill)
	{
		return 1.5 + (double)(skill.Level - 1) * 0.7;
	}

	// Token: 0x06002F38 RID: 12088 RVA: 0x00142147 File Offset: 0x00140547
	private double ActiveFireseedRate(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.5;
	}

	// Token: 0x06002F39 RID: 12089 RVA: 0x00142166 File Offset: 0x00140566
	private double PassiveChance(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.3;
	}

	// Token: 0x06002F3A RID: 12090 RVA: 0x00142188 File Offset: 0x00140588
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.LastingSecondsKey, ((int)this.TotalBuffLength(skill)).ToString()).Replace(this.MainDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100()).Replace(this.AdditionalMainDamageRateKey, this.ActiveFireseedRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002F3B RID: 12091 RVA: 0x0014221C File Offset: 0x0014061C
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		SpitFireFocusEnhancementData focus = skill.SourceUnit.SpecialEffects.OfType<SpitFireFocusEnhancementData>().FirstOrDefault<SpitFireFocusEnhancementData>();
		FireAssassinStarImmuneData star = skill.SourceUnit.SpecialEffects.OfType<FireAssassinStarImmuneData>().FirstOrDefault<FireAssassinStarImmuneData>();
		foreach (IBattleUnit unit in strategy.Selections)
		{
			if (focus != null)
			{
				IEnumerator enumerator2 = unit.ApplySkillEffect(new SpitFireMonsterEffect(base.GetType().FullName, new float?((float)focus.LastingSeconds), this.ActiveDamageRate(skill.Skill) + focus.DamageBoostRate, this.ActiveFireseedRate(skill.Skill), skill), false).GetEnumerator();
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
			else
			{
				IEnumerator enumerator3 = unit.ApplySkillEffect(new SpitFireMonsterEffect(base.GetType().FullName, new float?(this.TotalBuffLength(skill.Skill)), this.ActiveDamageRate(skill.Skill), this.ActiveFireseedRate(skill.Skill), skill), false).GetEnumerator();
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
			if (star != null && (double)UnityEngine.Random.value <= star.Chance)
			{
				for (int i = 0; i < star.NumberOfShields; i++)
				{
					IEnumerator enumerator4 = unit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), skill, true), false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x06002F3C RID: 12092 RVA: 0x00142250 File Offset: 0x00140650
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased,
			AdventureEventType.UnitPostReceivesDamage_Single
		};
	}

	// Token: 0x06002F3D RID: 12093 RVA: 0x00142274 File Offset: 0x00140674
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && data is ReleaseableDamage && eventTriggerUnit == skillOwner)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (damage.Dealer == skillOwner)
			{
				foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
				{
					double totalExtraFireDamage = 0.0;
					foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
					{
						if ((double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
						{
							totalExtraFireDamage += processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 0.8;
						}
					}
					if (totalExtraFireDamage > 0.0)
					{
						IEnumerator enumerator3 = FireSeedEffect.AddFireSeed(damageBattleDamage.Target, totalExtraFireDamage, processingSkill.SourceUnit).GetEnumerator();
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
			}
		}
		if (eventType == AdventureEventType.UnitPostReceivesDamage_Single)
		{
			DamageComponent damage2 = data as DamageComponent;
			if (damage2 != null && !damage2.IsMissed && damage2.IsDirectDamage && damage2.Dealer == processingSkill.SourceUnit && (double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
			{
				double damageValue = processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 0.8;
				IEnumerator enumerator4 = FireSeedEffect.AddFireSeed(damage2.Target, damageValue, processingSkill.SourceUnit).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x0400273A RID: 10042
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x0400273B RID: 10043
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x0400273C RID: 10044
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x0400273D RID: 10045
	private SkillType _skillType = SkillType.GodsFire;

	// Token: 0x02000E35 RID: 3637
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B84 RID: 23428 RVA: 0x001422BC File Offset: 0x001406BC
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005B85 RID: 23429 RVA: 0x001422C4 File Offset: 0x001406C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				focus = skill.SourceUnit.SpecialEffects.OfType<SpitFireFocusEnhancementData>().FirstOrDefault<SpitFireFocusEnhancementData>();
				star = skill.SourceUnit.SpecialEffects.OfType<FireAssassinStarImmuneData>().FirstOrDefault<FireAssassinStarImmuneData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_5:
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
				case 2u:
					Block_6:
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
					break;
				case 3u:
					Block_9:
					try
					{
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
					i++;
					goto IL_3A5;
				default:
					goto IL_3BB;
				}
				if (star == null || (double)UnityEngine.Random.value > star.Chance)
				{
					goto IL_3BB;
				}
				i = 0;
				IL_3A5:
				if (i < star.NumberOfShields)
				{
					enumerator4 = unit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), skill, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
				IL_3BB:
				if (enumerator.MoveNext())
				{
					unit = enumerator.Current;
					if (focus != null)
					{
						enumerator2 = unit.ApplySkillEffect(new SpitFireMonsterEffect(base.GetType().FullName, new float?((float)focus.LastingSeconds), base.ActiveDamageRate(skill.Skill) + focus.DamageBoostRate, base.ActiveFireseedRate(skill.Skill), skill), false).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
					enumerator3 = unit.ApplySkillEffect(new SpitFireMonsterEffect(base.GetType().FullName, new float?(base.TotalBuffLength(skill.Skill)), base.ActiveDamageRate(skill.Skill), base.ActiveFireseedRate(skill.Skill), skill), false).GetEnumerator();
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

		// Token: 0x1700131A RID: 4890
		// (get) Token: 0x06005B86 RID: 23430 RVA: 0x00142728 File Offset: 0x00140B28
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700131B RID: 4891
		// (get) Token: 0x06005B87 RID: 23431 RVA: 0x00142730 File Offset: 0x00140B30
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B88 RID: 23432 RVA: 0x00142738 File Offset: 0x00140B38
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
			case 3u:
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005B89 RID: 23433 RVA: 0x00142864 File Offset: 0x00140C64
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B8A RID: 23434 RVA: 0x0014286B File Offset: 0x00140C6B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B8B RID: 23435 RVA: 0x00142874 File Offset: 0x00140C74
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpitFire.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new SpitFire.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004D56 RID: 19798
		internal AdventureUnitSkill skill;

		// Token: 0x04004D57 RID: 19799
		internal SpitFireFocusEnhancementData <focus>__0;

		// Token: 0x04004D58 RID: 19800
		internal FireAssassinStarImmuneData <star>__0;

		// Token: 0x04004D59 RID: 19801
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004D5A RID: 19802
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004D5B RID: 19803
		internal IBattleUnit <unit>__1;

		// Token: 0x04004D5C RID: 19804
		internal IEnumerator $locvar1;

		// Token: 0x04004D5D RID: 19805
		internal object <_>__2;

		// Token: 0x04004D5E RID: 19806
		internal IDisposable $locvar2;

		// Token: 0x04004D5F RID: 19807
		internal IEnumerator $locvar3;

		// Token: 0x04004D60 RID: 19808
		internal object <_>__3;

		// Token: 0x04004D61 RID: 19809
		internal IDisposable $locvar4;

		// Token: 0x04004D62 RID: 19810
		internal int <i>__4;

		// Token: 0x04004D63 RID: 19811
		internal IEnumerator $locvar5;

		// Token: 0x04004D64 RID: 19812
		internal object <_>__5;

		// Token: 0x04004D65 RID: 19813
		internal IDisposable $locvar6;

		// Token: 0x04004D66 RID: 19814
		internal SpitFire $this;

		// Token: 0x04004D67 RID: 19815
		internal object $current;

		// Token: 0x04004D68 RID: 19816
		internal bool $disposing;

		// Token: 0x04004D69 RID: 19817
		internal int $PC;
	}

	// Token: 0x02000E36 RID: 3638
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B8C RID: 23436 RVA: 0x001428C0 File Offset: 0x00140CC0
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005B8D RID: 23437 RVA: 0x001428C8 File Offset: 0x00140CC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || !(data is ReleaseableDamage) || eventTriggerUnit != skillOwner)
				{
					goto IL_252;
				}
				damage = (data as ReleaseableDamage);
				if (damage.Dealer != skillOwner)
				{
					goto IL_252;
				}
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_13:
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
				goto IL_3AE;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_17:
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
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					totalExtraFireDamage = 0.0;
					enumerator2 = damageBattleDamage.Damages.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							DamageComponent damageComponent = enumerator2.Current;
							if ((double)UnityEngine.Random.value <= base.PassiveChance(processingSkill.Skill))
							{
								totalExtraFireDamage += processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 0.8;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (totalExtraFireDamage > 0.0)
					{
						enumerator3 = FireSeedEffect.AddFireSeed(damageBattleDamage.Target, totalExtraFireDamage, processingSkill.SourceUnit).GetEnumerator();
						num = 4294967293u;
						goto Block_17;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_252:
			if (eventType == AdventureEventType.UnitPostReceivesDamage_Single)
			{
				damage2 = (data as DamageComponent);
				if (damage2 != null && !damage2.IsMissed && damage2.IsDirectDamage && damage2.Dealer == processingSkill.SourceUnit && (double)UnityEngine.Random.value <= base.PassiveChance(processingSkill.Skill))
				{
					damageValue = processingSkill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 0.8;
					enumerator4 = FireSeedEffect.AddFireSeed(damage2.Target, damageValue, processingSkill.SourceUnit).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			IL_3AE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700131C RID: 4892
		// (get) Token: 0x06005B8E RID: 23438 RVA: 0x00142CF4 File Offset: 0x001410F4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700131D RID: 4893
		// (get) Token: 0x06005B8F RID: 23439 RVA: 0x00142CFC File Offset: 0x001410FC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B90 RID: 23440 RVA: 0x00142D04 File Offset: 0x00141104
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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
			}
		}

		// Token: 0x06005B91 RID: 23441 RVA: 0x00142DD8 File Offset: 0x001411D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B92 RID: 23442 RVA: 0x00142DDF File Offset: 0x001411DF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B93 RID: 23443 RVA: 0x00142DE8 File Offset: 0x001411E8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpitFire.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new SpitFire.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.data = data;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004D6A RID: 19818
		internal AdventureEventType eventType;

		// Token: 0x04004D6B RID: 19819
		internal object data;

		// Token: 0x04004D6C RID: 19820
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004D6D RID: 19821
		internal IBattleUnit skillOwner;

		// Token: 0x04004D6E RID: 19822
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04004D6F RID: 19823
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004D70 RID: 19824
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04004D71 RID: 19825
		internal double <totalExtraFireDamage>__3;

		// Token: 0x04004D72 RID: 19826
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04004D73 RID: 19827
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004D74 RID: 19828
		internal IEnumerator $locvar2;

		// Token: 0x04004D75 RID: 19829
		internal object <_>__4;

		// Token: 0x04004D76 RID: 19830
		internal IDisposable $locvar3;

		// Token: 0x04004D77 RID: 19831
		internal DamageComponent <damage>__5;

		// Token: 0x04004D78 RID: 19832
		internal double <damageValue>__6;

		// Token: 0x04004D79 RID: 19833
		internal IEnumerator $locvar4;

		// Token: 0x04004D7A RID: 19834
		internal object <_>__7;

		// Token: 0x04004D7B RID: 19835
		internal IDisposable $locvar5;

		// Token: 0x04004D7C RID: 19836
		internal SpitFire $this;

		// Token: 0x04004D7D RID: 19837
		internal object $current;

		// Token: 0x04004D7E RID: 19838
		internal bool $disposing;

		// Token: 0x04004D7F RID: 19839
		internal int $PC;
	}
}
