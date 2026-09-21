using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006CD RID: 1741
public class SpiritOfDemon : ActiveSkillLogicBase
{
	// Token: 0x06002F1A RID: 12058 RVA: 0x0014076A File Offset: 0x0013EB6A
	public SpiritOfDemon()
	{
	}

	// Token: 0x06002F1B RID: 12059 RVA: 0x0014078C File Offset: 0x0013EB8C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SpiritOfDemonPetTalent(SkillType.SpiritOfDemon, 1),
			new SpiritOfDemonPetTalent(SkillType.SpiritOfDemon, 2),
			new SpiritOfDemonPetTalent(SkillType.SpiritOfDemon, 3)
		};
	}

	// Token: 0x1700061E RID: 1566
	// (get) Token: 0x06002F1C RID: 12060 RVA: 0x001407D3 File Offset: 0x0013EBD3
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x1700061F RID: 1567
	// (get) Token: 0x06002F1D RID: 12061 RVA: 0x001407DB File Offset: 0x0013EBDB
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000620 RID: 1568
	// (get) Token: 0x06002F1E RID: 12062 RVA: 0x001407E3 File Offset: 0x0013EBE3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000621 RID: 1569
	// (get) Token: 0x06002F1F RID: 12063 RVA: 0x001407EB File Offset: 0x0013EBEB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F20 RID: 12064 RVA: 0x001407F3 File Offset: 0x0013EBF3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002F21 RID: 12065 RVA: 0x001407FA File Offset: 0x0013EBFA
	public override double GetGaugeCost(Skill skill)
	{
		return 100.0;
	}

	// Token: 0x06002F22 RID: 12066 RVA: 0x00140805 File Offset: 0x0013EC05
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(4f);
	}

	// Token: 0x06002F23 RID: 12067 RVA: 0x00140811 File Offset: 0x0013EC11
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002F24 RID: 12068 RVA: 0x00140819 File Offset: 0x0013EC19
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002F25 RID: 12069 RVA: 0x00140820 File Offset: 0x0013EC20
	private double GetMainBoostValue(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.5;
	}

	// Token: 0x06002F26 RID: 12070 RVA: 0x0014083F File Offset: 0x0013EC3F
	private double GetSecondaryBoostValue(Skill skill)
	{
		return (double)skill.Level * 0.05;
	}

	// Token: 0x06002F27 RID: 12071 RVA: 0x00140854 File Offset: 0x0013EC54
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.OutputBoostRateKey, this.GetMainBoostValue(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.OutputBoostRateKey, this.GetSecondaryBoostValue(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002F28 RID: 12072 RVA: 0x001408A8 File Offset: 0x0013ECA8
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<UnitClass> minionTypes = new List<UnitClass>
		{
			UnitClass.ConjourerSpiritRed,
			UnitClass.ConjourerSpiritBlue,
			UnitClass.ConjourerSpiritGreen
		};
		UnitClass selected = minionTypes[UnityEngine.Random.Range(0, minionTypes.Count)];
		IEnumerator enumerator = this.SummonPet(skill, selected).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object p = enumerator.Current;
				yield return p;
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

	// Token: 0x06002F29 RID: 12073 RVA: 0x001408D4 File Offset: 0x0013ECD4
	public IEnumerable SummonPet(AdventureUnitSkill skill, UnitClass selected)
	{
		List<AttributeType> attributes = UnitExtensions.GetAllResistances();
		List<AttributeModifier> modifiers = (from a in attributes
		select new AttributeModifier
		{
			AttributeType = a,
			ModificationType = ModificationType.Addition,
			Value = skill.SourceUnit.GetAttributeValue_Final(a, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Normal
		}).ToList<AttributeModifier>();
		modifiers.Add(new AttributeModifier
		{
			AttributeType = AttributeType.HitRateAdjustment,
			ModificationType = ModificationType.Addition,
			Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.HitRateAdjustment, AttributeRetrievalLevel.Gear),
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Normal
		});
		modifiers.Add(new AttributeModifier
		{
			AttributeType = AttributeType.DodgeRateAdjustment,
			ModificationType = ModificationType.Addition,
			Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.DodgeRateAdjustment, AttributeRetrievalLevel.Gear),
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Normal
		});
		modifiers.Add(new AttributeModifier
		{
			AttributeType = AttributeType.EffectHitRating,
			ModificationType = ModificationType.Addition,
			Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Gear),
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Normal
		});
		modifiers.Add(new AttributeModifier
		{
			AttributeType = AttributeType.EffectResistanceRating,
			ModificationType = ModificationType.Addition,
			Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectResistanceRating, AttributeRetrievalLevel.Gear),
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Normal
		});
		List<SkillType> skills = new List<SkillType>();
		List<ISpecialEffectDataLoad> specialEffects = new List<ISpecialEffectDataLoad>();
		specialEffects.AddRange((from e in UnitExtensions.GetAllDamageElements()
		select new ElementEffectData
		{
			ElementType = e
		}).Cast<ISpecialEffectDataLoad>());
		if (selected == UnitClass.ConjourerSpiritRed)
		{
			skills.Add(SkillType.FireBall);
			specialEffects.Add(new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Vitality,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Agility,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Intelligience,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
		}
		if (selected == UnitClass.ConjourerSpiritGreen)
		{
			skills.Add(SkillType.DivineLight);
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Vitality,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Agility,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Intelligience,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
		}
		if (selected == UnitClass.ConjourerSpiritBlue)
		{
			skills.Add(SkillType.Stun);
			specialEffects.Add(new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 6
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Vitality,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill) * 2.0,
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Agility,
				ModificationType = ModificationType.Addition,
				Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Intelligience,
				ModificationType = ModificationType.Addition,
				Value = 200.0,
				AttributeModifierType = AttributeModifierType.Normal
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.TauntOnHit,
				ModificationType = ModificationType.Addition,
				Value = 1.0,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Normal
			});
		}
		int skillLevel = skill.Skill.Level * 3;
		PetBattleUnit unit = PetBattleUnit.Create(modifiers, skill.SourceUnit, new List<AdventureUnitSkill>(), selected, specialEffects);
		List<AdventureUnitSkill> sks = (from s in skills
		select s.CreateMonsterSkill(skillLevel) into s
		select s.InitializeBattleUnitSkill(unit)).ToList<AdventureUnitSkill>();
		unit._skills = sks;
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			IEnumerator enumerator = battleEncounter.AddPet(unit).GetEnumerator();
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
			if (skill.SourceUnit.SpecialEffects.OfType<ConjurerStarTeamBuffData>().Any<ConjurerStarTeamBuffData>())
			{
				ConjurerStarTeamBuffData buff = skill.SourceUnit.SpecialEffects.OfType<ConjurerStarTeamBuffData>().First<ConjurerStarTeamBuffData>();
				if (buff != null)
				{
					List<IBattleUnit> targets = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
					AttributeType attributeType = (selected != UnitClass.ConjourerSpiritRed) ? ((selected != UnitClass.ConjourerSpiritGreen) ? AttributeType.HitRateAdjustment : AttributeType.DodgeRateAdjustment) : AttributeType.ReflectiveDamage;
					double rate = (selected != UnitClass.ConjourerSpiritRed) ? ((selected != UnitClass.ConjourerSpiritGreen) ? buff.HitRate : buff.DodgeRate) : buff.ReflectionRate;
					foreach (IBattleUnit battleUnit in targets)
					{
						IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = attributeType,
								ModificationType = ModificationType.Addition,
								Value = rate,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "spiritofdemonuniquebuff", new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			}
		}
		IEnumerator enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(unit, skill.SourceUnit, 1.0).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002F2A RID: 12074 RVA: 0x00140908 File Offset: 0x0013ED08
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			List<IBattleUnit> friendlyUnits = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit unit in friendlyUnits)
			{
				double boost = this.GetSecondaryBoostValue(skill.Skill);
				SpiritOfDemonEffect boostEffect = new SpiritOfDemonEffect(skill.SourceUnit.GetId() + base.GetType().FullName + "passive", null, false, boost, skill);
				IEnumerator enumerator2 = unit.ApplySkillEffect(boostEffect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002F2B RID: 12075 RVA: 0x00140934 File Offset: 0x0013ED34
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			List<IBattleUnit> friendlyUnits = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit unit in friendlyUnits)
			{
				List<SpiritOfDemonEffect> tobeRemoved = (from ef in unit.BattleEffects.OfType<SpiritOfDemonEffect>()
				where ef.EffectSourceIdentityCode == skill.SourceUnit.GetId() + this.GetType().FullName + "passive"
				select ef).ToList<SpiritOfDemonEffect>();
				foreach (SpiritOfDemonEffect spiritOfDemonEffect in tobeRemoved)
				{
					IEnumerator enumerator3 = unit.LooseSkillEffect(spiritOfDemonEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002736 RID: 10038
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x04002737 RID: 10039
	private OutputType _skillOutputType;

	// Token: 0x04002738 RID: 10040
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002739 RID: 10041
	private SkillType _skillType = SkillType.SpiritOfDemon;

	// Token: 0x02000E2F RID: 3631
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B5D RID: 23389 RVA: 0x0014095E File Offset: 0x0013ED5E
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005B5E RID: 23390 RVA: 0x00140968 File Offset: 0x0013ED68
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				minionTypes = new List<UnitClass>
				{
					UnitClass.ConjourerSpiritRed,
					UnitClass.ConjourerSpiritBlue,
					UnitClass.ConjourerSpiritGreen
				};
				selected = minionTypes[UnityEngine.Random.Range(0, minionTypes.Count)];
				enumerator = base.SummonPet(skill, selected).GetEnumerator();
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
					p = enumerator.Current;
					this.$current = p;
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

		// Token: 0x17001312 RID: 4882
		// (get) Token: 0x06005B5F RID: 23391 RVA: 0x00140AAC File Offset: 0x0013EEAC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001313 RID: 4883
		// (get) Token: 0x06005B60 RID: 23392 RVA: 0x00140AB4 File Offset: 0x0013EEB4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B61 RID: 23393 RVA: 0x00140ABC File Offset: 0x0013EEBC
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

		// Token: 0x06005B62 RID: 23394 RVA: 0x00140B2C File Offset: 0x0013EF2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B63 RID: 23395 RVA: 0x00140B33 File Offset: 0x0013EF33
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B64 RID: 23396 RVA: 0x00140B3C File Offset: 0x0013EF3C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritOfDemon.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new SpiritOfDemon.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004D0B RID: 19723
		internal List<UnitClass> <minionTypes>__0;

		// Token: 0x04004D0C RID: 19724
		internal UnitClass <selected>__0;

		// Token: 0x04004D0D RID: 19725
		internal AdventureUnitSkill skill;

		// Token: 0x04004D0E RID: 19726
		internal IEnumerator $locvar0;

		// Token: 0x04004D0F RID: 19727
		internal object <p>__1;

		// Token: 0x04004D10 RID: 19728
		internal IDisposable $locvar1;

		// Token: 0x04004D11 RID: 19729
		internal SpiritOfDemon $this;

		// Token: 0x04004D12 RID: 19730
		internal object $current;

		// Token: 0x04004D13 RID: 19731
		internal bool $disposing;

		// Token: 0x04004D14 RID: 19732
		internal int $PC;
	}

	// Token: 0x02000E30 RID: 3632
	[CompilerGenerated]
	private sealed class <SummonPet>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B65 RID: 23397 RVA: 0x00140B7C File Offset: 0x0013EF7C
		[DebuggerHidden]
		public <SummonPet>c__Iterator1()
		{
		}

		// Token: 0x06005B66 RID: 23398 RVA: 0x00140B84 File Offset: 0x0013EF84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				attributes = UnitExtensions.GetAllResistances();
				modifiers = (from a in attributes
				select new AttributeModifier
				{
					AttributeType = a,
					ModificationType = ModificationType.Addition,
					Value = skill.SourceUnit.GetAttributeValue_Final(a, AttributeRetrievalLevel.Skill) * this.GetMainBoostValue(skill.Skill),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				}).ToList<AttributeModifier>();
				modifiers.Add(new AttributeModifier
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.HitRateAdjustment, AttributeRetrievalLevel.Gear),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				});
				modifiers.Add(new AttributeModifier
				{
					AttributeType = AttributeType.DodgeRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.DodgeRateAdjustment, AttributeRetrievalLevel.Gear),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				});
				modifiers.Add(new AttributeModifier
				{
					AttributeType = AttributeType.EffectHitRating,
					ModificationType = ModificationType.Addition,
					Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Gear),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				});
				modifiers.Add(new AttributeModifier
				{
					AttributeType = AttributeType.EffectResistanceRating,
					ModificationType = ModificationType.Addition,
					Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectResistanceRating, AttributeRetrievalLevel.Gear),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				});
				skills = new List<SkillType>();
				specialEffects = new List<ISpecialEffectDataLoad>();
				specialEffects.AddRange((from e in UnitExtensions.GetAllDamageElements()
				select new ElementEffectData
				{
					ElementType = e
				}).Cast<ISpecialEffectDataLoad>());
				if (selected == UnitClass.ConjourerSpiritRed)
				{
					skills.Add(SkillType.FireBall);
					specialEffects.Add(new ExtraTargetingData
					{
						IsStarEf = new bool?(false),
						CandidateTypes = new List<TargetCandidateType>
						{
							TargetCandidateType.HostileAlive
						},
						Extra = 2
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Vitality,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
				}
				if (selected == UnitClass.ConjourerSpiritGreen)
				{
					skills.Add(SkillType.DivineLight);
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Vitality,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Intelligience, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
				}
				if (selected == UnitClass.ConjourerSpiritBlue)
				{
					skills.Add(SkillType.Stun);
					specialEffects.Add(new ExtraTargetingData
					{
						IsStarEf = new bool?(false),
						CandidateTypes = new List<TargetCandidateType>
						{
							TargetCandidateType.HostileAlive
						},
						Extra = 6
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Vitality,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill) * 2.0,
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						ModificationType = ModificationType.Addition,
						Value = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) * base.GetMainBoostValue(skill.Skill),
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Addition,
						Value = 200.0,
						AttributeModifierType = AttributeModifierType.Normal
					});
					modifiers.Add(new AttributeModifier
					{
						AttributeType = AttributeType.TauntOnHit,
						ModificationType = ModificationType.Addition,
						Value = 1.0,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Normal
					});
				}
				int skillLevel = skill.Skill.Level * 3;
				PetBattleUnit unit = PetBattleUnit.Create(modifiers, skill.SourceUnit, new List<AdventureUnitSkill>(), selected, specialEffects);
				sks = (from s in skills
				select s.CreateMonsterSkill(skillLevel) into s
				select s.InitializeBattleUnitSkill(unit)).ToList<AdventureUnitSkill>();
				unit._skills = sks;
				battleEncounter = (skill.SourceUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_A88;
				}
				enumerator = battleEncounter.AddPet(unit).GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_91E;
			case 3u:
				Block_15:
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
				this.$PC = -1;
				return false;
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
			if (!<SummonPet>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<ConjurerStarTeamBuffData>().Any<ConjurerStarTeamBuffData>())
			{
				goto IL_A88;
			}
			buff = <SummonPet>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<ConjurerStarTeamBuffData>().First<ConjurerStarTeamBuffData>();
			if (buff == null)
			{
				goto IL_A88;
			}
			targets = <SummonPet>c__AnonStorey.skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			attributeType = ((selected != UnitClass.ConjourerSpiritRed) ? ((selected != UnitClass.ConjourerSpiritGreen) ? AttributeType.HitRateAdjustment : AttributeType.DodgeRateAdjustment) : AttributeType.ReflectiveDamage);
			rate = ((selected != UnitClass.ConjourerSpiritRed) ? ((selected != UnitClass.ConjourerSpiritGreen) ? buff.HitRate : buff.DodgeRate) : buff.ReflectionRate);
			enumerator2 = targets.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_91E:
				switch (num)
				{
				case 2u:
					Block_23:
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
				}
				if (enumerator2.MoveNext())
				{
					battleUnit = enumerator2.Current;
					enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<SummonPet>c__AnonStorey.skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = attributeType,
							ModificationType = ModificationType.Addition,
							Value = rate,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "spiritofdemonuniquebuff", new int?(1), null, null, false, false, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_23;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_A88:
			enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(<SummonPet>c__AnonStorey.unit, <SummonPet>c__AnonStorey.skill.SourceUnit, 1.0).GetEnumerator();
			num = 4294967293u;
			goto Block_15;
		}

		// Token: 0x17001314 RID: 4884
		// (get) Token: 0x06005B67 RID: 23399 RVA: 0x00141744 File Offset: 0x0013FB44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001315 RID: 4885
		// (get) Token: 0x06005B68 RID: 23400 RVA: 0x0014174C File Offset: 0x0013FB4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B69 RID: 23401 RVA: 0x00141754 File Offset: 0x0013FB54
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
			case 2u:
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
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

		// Token: 0x06005B6A RID: 23402 RVA: 0x00141864 File Offset: 0x0013FC64
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B6B RID: 23403 RVA: 0x0014186B File Offset: 0x0013FC6B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B6C RID: 23404 RVA: 0x00141874 File Offset: 0x0013FC74
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritOfDemon.<SummonPet>c__Iterator1 <SummonPet>c__Iterator = new SpiritOfDemon.<SummonPet>c__Iterator1();
			<SummonPet>c__Iterator.$this = this;
			<SummonPet>c__Iterator.skill = skill;
			<SummonPet>c__Iterator.selected = selected;
			return <SummonPet>c__Iterator;
		}

		// Token: 0x06005B6D RID: 23405 RVA: 0x001418C0 File Offset: 0x0013FCC0
		private static ElementEffectData <>m__0(OutputType e)
		{
			return new ElementEffectData
			{
				ElementType = e
			};
		}

		// Token: 0x04004D15 RID: 19733
		internal List<AttributeType> <attributes>__0;

		// Token: 0x04004D16 RID: 19734
		internal AdventureUnitSkill skill;

		// Token: 0x04004D17 RID: 19735
		internal List<AttributeModifier> <modifiers>__0;

		// Token: 0x04004D18 RID: 19736
		internal List<SkillType> <skills>__0;

		// Token: 0x04004D19 RID: 19737
		internal List<ISpecialEffectDataLoad> <specialEffects>__0;

		// Token: 0x04004D1A RID: 19738
		internal UnitClass selected;

		// Token: 0x04004D1B RID: 19739
		internal List<AdventureUnitSkill> <sks>__0;

		// Token: 0x04004D1C RID: 19740
		internal BattleEncounter <battleEncounter>__0;

		// Token: 0x04004D1D RID: 19741
		internal IEnumerator $locvar0;

		// Token: 0x04004D1E RID: 19742
		internal object <_>__1;

		// Token: 0x04004D1F RID: 19743
		internal IDisposable $locvar1;

		// Token: 0x04004D20 RID: 19744
		internal ConjurerStarTeamBuffData <buff>__2;

		// Token: 0x04004D21 RID: 19745
		internal List<IBattleUnit> <targets>__3;

		// Token: 0x04004D22 RID: 19746
		internal AttributeType <attributeType>__3;

		// Token: 0x04004D23 RID: 19747
		internal double <rate>__3;

		// Token: 0x04004D24 RID: 19748
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04004D25 RID: 19749
		internal IBattleUnit <battleUnit>__4;

		// Token: 0x04004D26 RID: 19750
		internal IEnumerator $locvar3;

		// Token: 0x04004D27 RID: 19751
		internal object <_>__5;

		// Token: 0x04004D28 RID: 19752
		internal IDisposable $locvar4;

		// Token: 0x04004D29 RID: 19753
		internal IEnumerator $locvar5;

		// Token: 0x04004D2A RID: 19754
		internal object <_>__6;

		// Token: 0x04004D2B RID: 19755
		internal IDisposable $locvar6;

		// Token: 0x04004D2C RID: 19756
		internal SpiritOfDemon $this;

		// Token: 0x04004D2D RID: 19757
		internal object $current;

		// Token: 0x04004D2E RID: 19758
		internal bool $disposing;

		// Token: 0x04004D2F RID: 19759
		internal int $PC;

		// Token: 0x04004D30 RID: 19760
		private SpiritOfDemon.<SummonPet>c__Iterator1.<SummonPet>c__AnonStorey4 $locvar7;

		// Token: 0x04004D31 RID: 19761
		private static Func<OutputType, ElementEffectData> <>f__am$cache0;

		// Token: 0x02000E33 RID: 3635
		private sealed class <SummonPet>c__AnonStorey4
		{
			// Token: 0x06005B7E RID: 23422 RVA: 0x001418DB File Offset: 0x0013FCDB
			public <SummonPet>c__AnonStorey4()
			{
			}

			// Token: 0x06005B7F RID: 23423 RVA: 0x001418E4 File Offset: 0x0013FCE4
			internal AttributeModifier <>m__0(AttributeType a)
			{
				return new AttributeModifier
				{
					AttributeType = a,
					ModificationType = ModificationType.Addition,
					Value = this.skill.SourceUnit.GetAttributeValue_Final(a, AttributeRetrievalLevel.Skill) * this.<>f__ref$1.$this.GetMainBoostValue(this.skill.Skill),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Normal
				};
			}

			// Token: 0x06005B80 RID: 23424 RVA: 0x0014194C File Offset: 0x0013FD4C
			internal Skill <>m__1(SkillType s)
			{
				return s.CreateMonsterSkill(this.skillLevel);
			}

			// Token: 0x06005B81 RID: 23425 RVA: 0x0014195A File Offset: 0x0013FD5A
			internal AdventureUnitSkill <>m__2(Skill s)
			{
				return s.InitializeBattleUnitSkill(this.unit);
			}

			// Token: 0x04004D50 RID: 19792
			internal AdventureUnitSkill skill;

			// Token: 0x04004D51 RID: 19793
			internal int skillLevel;

			// Token: 0x04004D52 RID: 19794
			internal PetBattleUnit unit;

			// Token: 0x04004D53 RID: 19795
			internal SpiritOfDemon.<SummonPet>c__Iterator1 <>f__ref$1;
		}
	}

	// Token: 0x02000E31 RID: 3633
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B6E RID: 23406 RVA: 0x00141968 File Offset: 0x0013FD68
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator2()
		{
		}

		// Token: 0x06005B6F RID: 23407 RVA: 0x00141970 File Offset: 0x0013FD70
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				battleEncounter = (skill.SourceUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_1CA;
				}
				friendlyUnits = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyUnits.GetEnumerator();
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
				}
				if (enumerator.MoveNext())
				{
					unit = enumerator.Current;
					boost = base.GetSecondaryBoostValue(skill.Skill);
					boostEffect = new SpiritOfDemonEffect(skill.SourceUnit.GetId() + base.GetType().FullName + "passive", null, false, boost, skill);
					enumerator2 = unit.ApplySkillEffect(boostEffect, false).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1CA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001316 RID: 4886
		// (get) Token: 0x06005B70 RID: 23408 RVA: 0x00141B88 File Offset: 0x0013FF88
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001317 RID: 4887
		// (get) Token: 0x06005B71 RID: 23409 RVA: 0x00141B90 File Offset: 0x0013FF90
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B72 RID: 23410 RVA: 0x00141B98 File Offset: 0x0013FF98
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

		// Token: 0x06005B73 RID: 23411 RVA: 0x00141C2C File Offset: 0x0014002C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B74 RID: 23412 RVA: 0x00141C33 File Offset: 0x00140033
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B75 RID: 23413 RVA: 0x00141C3C File Offset: 0x0014003C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritOfDemon.<PassiveEffectApplies>c__Iterator2 <PassiveEffectApplies>c__Iterator = new SpiritOfDemon.<PassiveEffectApplies>c__Iterator2();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004D32 RID: 19762
		internal AdventureUnitSkill skill;

		// Token: 0x04004D33 RID: 19763
		internal BattleEncounter <battleEncounter>__0;

		// Token: 0x04004D34 RID: 19764
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04004D35 RID: 19765
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004D36 RID: 19766
		internal IBattleUnit <unit>__2;

		// Token: 0x04004D37 RID: 19767
		internal double <boost>__3;

		// Token: 0x04004D38 RID: 19768
		internal SpiritOfDemonEffect <boostEffect>__3;

		// Token: 0x04004D39 RID: 19769
		internal IEnumerator $locvar1;

		// Token: 0x04004D3A RID: 19770
		internal object <_>__4;

		// Token: 0x04004D3B RID: 19771
		internal IDisposable $locvar2;

		// Token: 0x04004D3C RID: 19772
		internal SpiritOfDemon $this;

		// Token: 0x04004D3D RID: 19773
		internal object $current;

		// Token: 0x04004D3E RID: 19774
		internal bool $disposing;

		// Token: 0x04004D3F RID: 19775
		internal int $PC;
	}

	// Token: 0x02000E32 RID: 3634
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B76 RID: 23414 RVA: 0x00141C7C File Offset: 0x0014007C
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator3()
		{
		}

		// Token: 0x06005B77 RID: 23415 RVA: 0x00141C84 File Offset: 0x00140084
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				battleEncounter = (skill.SourceUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_227;
				}
				friendlyUnits = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyUnits.GetEnumerator();
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
					Block_5:
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
							spiritOfDemonEffect = enumerator2.Current;
							enumerator3 = unit.LooseSkillEffect(spiritOfDemonEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_8;
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
					unit = enumerator.Current;
					tobeRemoved = (from ef in unit.BattleEffects.OfType<SpiritOfDemonEffect>()
					where ef.EffectSourceIdentityCode == <PassiveEffectLooses>c__AnonStorey.skill.SourceUnit.GetId() + <PassiveEffectLooses>c__AnonStorey.<>f__ref$3.$this.GetType().FullName + "passive"
					select ef).ToList<SpiritOfDemonEffect>();
					enumerator2 = tobeRemoved.GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_227:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001318 RID: 4888
		// (get) Token: 0x06005B78 RID: 23416 RVA: 0x00141F10 File Offset: 0x00140310
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001319 RID: 4889
		// (get) Token: 0x06005B79 RID: 23417 RVA: 0x00141F18 File Offset: 0x00140318
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B7A RID: 23418 RVA: 0x00141F20 File Offset: 0x00140320
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

		// Token: 0x06005B7B RID: 23419 RVA: 0x00141FD8 File Offset: 0x001403D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B7C RID: 23420 RVA: 0x00141FDF File Offset: 0x001403DF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B7D RID: 23421 RVA: 0x00141FE8 File Offset: 0x001403E8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritOfDemon.<PassiveEffectLooses>c__Iterator3 <PassiveEffectLooses>c__Iterator = new SpiritOfDemon.<PassiveEffectLooses>c__Iterator3();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x04004D40 RID: 19776
		internal AdventureUnitSkill skill;

		// Token: 0x04004D41 RID: 19777
		internal BattleEncounter <battleEncounter>__0;

		// Token: 0x04004D42 RID: 19778
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04004D43 RID: 19779
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004D44 RID: 19780
		internal IBattleUnit <unit>__2;

		// Token: 0x04004D45 RID: 19781
		internal List<SpiritOfDemonEffect> <tobeRemoved>__3;

		// Token: 0x04004D46 RID: 19782
		internal List<SpiritOfDemonEffect>.Enumerator $locvar1;

		// Token: 0x04004D47 RID: 19783
		internal SpiritOfDemonEffect <spiritOfDemonEffect>__4;

		// Token: 0x04004D48 RID: 19784
		internal IEnumerator $locvar2;

		// Token: 0x04004D49 RID: 19785
		internal object <_>__5;

		// Token: 0x04004D4A RID: 19786
		internal IDisposable $locvar3;

		// Token: 0x04004D4B RID: 19787
		internal SpiritOfDemon $this;

		// Token: 0x04004D4C RID: 19788
		internal object $current;

		// Token: 0x04004D4D RID: 19789
		internal bool $disposing;

		// Token: 0x04004D4E RID: 19790
		internal int $PC;

		// Token: 0x04004D4F RID: 19791
		private SpiritOfDemon.<PassiveEffectLooses>c__Iterator3.<PassiveEffectLooses>c__AnonStorey5 $locvar4;

		// Token: 0x02000E34 RID: 3636
		private sealed class <PassiveEffectLooses>c__AnonStorey5
		{
			// Token: 0x06005B82 RID: 23426 RVA: 0x00142028 File Offset: 0x00140428
			public <PassiveEffectLooses>c__AnonStorey5()
			{
			}

			// Token: 0x06005B83 RID: 23427 RVA: 0x00142030 File Offset: 0x00140430
			internal bool <>m__0(SpiritOfDemonEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.skill.SourceUnit.GetId() + this.<>f__ref$3.$this.GetType().FullName + "passive";
			}

			// Token: 0x04004D54 RID: 19796
			internal AdventureUnitSkill skill;

			// Token: 0x04004D55 RID: 19797
			internal SpiritOfDemon.<PassiveEffectLooses>c__Iterator3 <>f__ref$3;
		}
	}
}
