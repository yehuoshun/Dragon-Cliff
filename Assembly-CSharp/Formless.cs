using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Assets.Scripts.Core.SpecialEffect.Dataload;

// Token: 0x020006C2 RID: 1730
public class Formless : ActiveSkillLogicBase
{
	// Token: 0x06002E56 RID: 11862 RVA: 0x0013647F File Offset: 0x0013487F
	public Formless()
	{
	}

	// Token: 0x06002E57 RID: 11863 RVA: 0x001364A8 File Offset: 0x001348A8
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new FormlessDebuffTalent(SkillType.Formless, 1),
			new FormlessExtraHitTalent(SkillType.Formless, 2),
			new FormlessDispelEnhancementTalent(SkillType.Formless, 3)
		};
	}

	// Token: 0x170005F2 RID: 1522
	// (get) Token: 0x06002E58 RID: 11864 RVA: 0x001364EF File Offset: 0x001348EF
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005F3 RID: 1523
	// (get) Token: 0x06002E59 RID: 11865 RVA: 0x001364F7 File Offset: 0x001348F7
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005F4 RID: 1524
	// (get) Token: 0x06002E5A RID: 11866 RVA: 0x001364FF File Offset: 0x001348FF
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005F5 RID: 1525
	// (get) Token: 0x06002E5B RID: 11867 RVA: 0x00136507 File Offset: 0x00134907
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E5C RID: 11868 RVA: 0x0013650F File Offset: 0x0013490F
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileSingleStrategy>();
	}

	// Token: 0x06002E5D RID: 11869 RVA: 0x00136516 File Offset: 0x00134916
	public override double GetGaugeCost(Skill skill)
	{
		return 75.0;
	}

	// Token: 0x06002E5E RID: 11870 RVA: 0x00136521 File Offset: 0x00134921
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1.5f);
	}

	// Token: 0x06002E5F RID: 11871 RVA: 0x0013652D File Offset: 0x0013492D
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileSingleStrategy(skill);
	}

	// Token: 0x06002E60 RID: 11872 RVA: 0x00136535 File Offset: 0x00134935
	private int TotalNumberOfHits(Skill skill)
	{
		return 3 + (skill.Level - 1) * 2;
	}

	// Token: 0x06002E61 RID: 11873 RVA: 0x00136543 File Offset: 0x00134943
	private double SingleHitRate(Skill skill)
	{
		return 0.8;
	}

	// Token: 0x06002E62 RID: 11874 RVA: 0x0013654E File Offset: 0x0013494E
	private double CasterSingleHitRate(Skill skill)
	{
		return 0.4;
	}

	// Token: 0x06002E63 RID: 11875 RVA: 0x00136559 File Offset: 0x00134959
	private double AdditionalCritBonusRate(Skill skill)
	{
		return 0.5 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E64 RID: 11876 RVA: 0x00136578 File Offset: 0x00134978
	private double AdditionalCritBonusCasterRate(Skill skill)
	{
		return 0.5 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E65 RID: 11877 RVA: 0x00136598 File Offset: 0x00134998
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.NumberOfActiveTriggers, this.TotalNumberOfHits(skill).ToString()).Replace(this.MainDamageRateKey, this.SingleHitRate(skill).ToExpressionMultiply100()).Replace(this.AdditionalMainDamageRateKey, this.AdditionalCritBonusRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.CasterSingleHitRate(skill).ToExpressionMultiply100()).Replace(this.AdditionalCasterDamageRateKey, this.AdditionalCritBonusCasterRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E66 RID: 11878 RVA: 0x00136658 File Offset: 0x00134A58
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		foreach (IBattleUnit target in strategy.Selections)
		{
			int num = this.TotalNumberOfHits(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<FormlessExtraHitData>().Sum((FormlessExtraHitData s) => s.Extra) + skill.SourceUnit.SpecialEffects.OfType<CubeStarSkillBoostData>().Sum((CubeStarSkillBoostData s) => s.Extra);
			List<DamageComponentValue> list = new List<DamageComponentValue>();
			for (int j = 0; j < num; j++)
			{
				list.Add(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Divine, this.SingleHitRate(skill.Skill)),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), this.CasterSingleHitRate(skill.Skill))
				}, target, skill.SourceUnit, true, false).AddCode(Formless._formlessActiveSourceKey));
			}
			damages.Add(new BattleDamage(target, skill, list));
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
		int numberOfCrit = 0;
		int numberOfEdgelessBoosts = 0;
		bool hasMiss = false;
		EdgelessData edgeless = skill.SourceUnit.SpecialEffects.OfType<EdgelessData>().FirstOrDefault<EdgelessData>();
		foreach (BattleDamage battleDamage in releaseable.BattleDamages)
		{
			foreach (DamageComponent damageComponent in battleDamage.Damages)
			{
				if (damageComponent.IsCrit && !damageComponent.HasFullyNeutralized())
				{
					numberOfCrit++;
				}
				if (edgeless != null)
				{
					if (!damageComponent.IsMissed)
					{
						numberOfEdgelessBoosts++;
					}
					else
					{
						numberOfEdgelessBoosts = 0;
						hasMiss = true;
					}
				}
			}
		}
		FormlessAttributeDecayData attributeDecay = skill.SourceUnit.SpecialEffects.OfType<FormlessAttributeDecayData>().FirstOrDefault<FormlessAttributeDecayData>();
		if (attributeDecay != null)
		{
			foreach (BattleDamage bdamage in releaseable.BattleDamages)
			{
				int numberofValidHits = 0;
				double totaldamage = 0.0;
				foreach (DamageComponent damageComponent2 in bdamage.Damages)
				{
					if (damageComponent2.IsCrit && !damageComponent2.HasFullyNeutralized())
					{
						numberOfCrit++;
						numberofValidHits++;
						totaldamage += damageComponent2.GetTotalDamageSoFar();
					}
				}
				double totalDecay = attributeDecay.DecayRate * (double)numberofValidHits * totaldamage;
				if (totalDecay > 0.0)
				{
					IEnumerator enumerator7 = bdamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Allresistances,
							ModificationType = ModificationType.Addition,
							Value = -totalDecay,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "formlessattributedecay", new int?(1), new float?((float)attributeDecay.Seconds), null, true, true), false).GetEnumerator();
					try
					{
						while (enumerator7.MoveNext())
						{
							object _2 = enumerator7.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator7 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		FormlessDispelData dispel = skill.SourceUnit.SpecialEffects.OfType<FormlessDispelData>().FirstOrDefault<FormlessDispelData>();
		if (dispel != null)
		{
			foreach (BattleDamage bdamage2 in releaseable.BattleDamages)
			{
				int numberofValidHits2 = 0;
				foreach (DamageComponent damageComponent3 in bdamage2.Damages)
				{
					if (damageComponent3.IsCrit && !damageComponent3.HasFullyNeutralized())
					{
						numberOfCrit++;
						numberofValidHits2++;
					}
				}
				int totalDispels = dispel.NumberOfDispels * numberofValidHits2;
				if (totalDispels > 0)
				{
					IEnumerator enumerator10 = UnitStyleConfigurationBase.DispelPositiveEffects(bdamage2.Target, new int?(totalDispels)).GetEnumerator();
					try
					{
						while (enumerator10.MoveNext())
						{
							object _3 = enumerator10.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator10 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
		}
		if (numberOfCrit > 0 && !skill.SourceUnit.SpecialEffects.OfType<FormlessAttributeDecayData>().Any<FormlessAttributeDecayData>() && !skill.SourceUnit.SpecialEffects.OfType<FormlessDispelData>().Any<FormlessDispelData>())
		{
			List<BattleDamage> extraDamages = new List<BattleDamage>();
			List<IBattleUnit> targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
			if (targets.Any<IBattleUnit>())
			{
				foreach (IBattleUnit target2 in targets)
				{
					extraDamages.Add(new BattleDamage(target2, skill, Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(skill.SourceUnit, target2, OutputType.Divine, this.AdditionalCritBonusRate(skill.Skill)),
						new DamagePotionValue(skill.SourceUnit, target2, skill.SourceUnit.GetOutputType(), this.AdditionalCritBonusCasterRate(skill.Skill))
					}, target2, skill.SourceUnit, true, false), numberOfCrit).ToList<DamageComponentValue>()));
				}
				ReleaseableDamage extraReleaseable = new ReleaseableDamage(extraDamages, skill.SourceUnit);
				IEnumerator enumerator12 = extraReleaseable.Release().GetEnumerator();
				try
				{
					while (enumerator12.MoveNext())
					{
						object _4 = enumerator12.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator12 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				foreach (BattleDamage battleDamage2 in extraReleaseable.BattleDamages)
				{
					foreach (DamageComponent damageComponent4 in battleDamage2.Damages)
					{
						if (edgeless != null)
						{
							if (!damageComponent4.IsMissed)
							{
								numberOfEdgelessBoosts++;
							}
							else
							{
								numberOfEdgelessBoosts = 0;
								hasMiss = true;
							}
						}
					}
				}
			}
		}
		if (edgeless != null && numberOfEdgelessBoosts > 0)
		{
			string code = "edgelessunique";
			if (numberOfEdgelessBoosts > 20)
			{
				numberOfEdgelessBoosts = 20;
			}
			if (hasMiss)
			{
				List<BattleEffectBase> toremove = (from ef in skill.SourceUnit.BattleEffects
				where ef.EffectSourceIdentityCode == code
				select ef).ToList<BattleEffectBase>();
				foreach (BattleEffectBase battleEffectBase in toremove)
				{
					IEnumerator enumerator16 = skill.SourceUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					try
					{
						while (enumerator16.MoveNext())
						{
							object _5 = enumerator16.Current;
							yield return _5;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator16 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
			}
			for (int i = 0; i < numberOfEdgelessBoosts; i++)
			{
				IEnumerator enumerator17 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						Value = edgeless.BoostRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, code, new int?(20), null, null, false, false, false), false).GetEnumerator();
				try
				{
					while (enumerator17.MoveNext())
					{
						object _6 = enumerator17.Current;
						yield return _6;
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator17 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002E67 RID: 11879 RVA: 0x00136689 File Offset: 0x00134A89
	private double PassiveBoostRate(Skill skill)
	{
		return 0.08 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x06002E68 RID: 11880 RVA: 0x001366A8 File Offset: 0x00134AA8
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x06002E69 RID: 11881 RVA: 0x001366C4 File Offset: 0x00134AC4
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage)
		{
			BattleDamage damage = data as BattleDamage;
			if (damage != null && damage.Dealer == processingSkill.SourceUnit)
			{
				foreach (DamageComponent damageComponent in from d in damage.Damages
				where d.IsCritDamage() && !d.IsMissed
				select d)
				{
					IEnumerator enumerator2 = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateCritRateBoostEffect(base.GetType().FullName, this.PassiveBoostRate(processingSkill.Skill), processingSkill), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06002E6A RID: 11882 RVA: 0x00136700 File Offset: 0x00134B00
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> tobeRemoved = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect critRateBoostEffect in tobeRemoved)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(critRateBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x06002E6B RID: 11883 RVA: 0x0013672C File Offset: 0x00134B2C
	public static bool IsDirectTriggeredDamage(DamageComponent damage)
	{
		bool result;
		if (damage != null && !damage.HasFullyNeutralized() && damage.IsDirectDamage && damage.IsCritDamage())
		{
			result = damage.GetCodes().Any((string c) => c == Formless._formlessActiveSourceKey);
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06002E6C RID: 11884 RVA: 0x0013678B File Offset: 0x00134B8B
	// Note: this type is marked as 'beforefieldinit'.
	static Formless()
	{
	}

	// Token: 0x06002E6D RID: 11885 RVA: 0x00136797 File Offset: 0x00134B97
	[CompilerGenerated]
	private static bool <IsDirectTriggeredDamage>m__0(string c)
	{
		return c == Formless._formlessActiveSourceKey;
	}

	// Token: 0x04002706 RID: 9990
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x04002707 RID: 9991
	private OutputType _skillOutputType = OutputType.Divine;

	// Token: 0x04002708 RID: 9992
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x04002709 RID: 9993
	private SkillType _skillType = SkillType.Formless;

	// Token: 0x0400270A RID: 9994
	private static readonly string _formlessActiveSourceKey = "FormlessActiveSourceKey";

	// Token: 0x0400270B RID: 9995
	[CompilerGenerated]
	private static Func<string, bool> <>f__am$cache0;

	// Token: 0x02000E0D RID: 3597
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A69 RID: 23145 RVA: 0x001367A4 File Offset: 0x00134BA4
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005A6A RID: 23146 RVA: 0x001367AC File Offset: 0x00134BAC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						int num2 = base.TotalNumberOfHits(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<FormlessExtraHitData>().Sum((FormlessExtraHitData s) => s.Extra) + skill.SourceUnit.SpecialEffects.OfType<CubeStarSkillBoostData>().Sum((CubeStarSkillBoostData s) => s.Extra);
						List<DamageComponentValue> list = new List<DamageComponentValue>();
						for (int j = 0; j < num2; j++)
						{
							list.Add(new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Divine, base.SingleHitRate(skill.Skill)),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), base.CasterSingleHitRate(skill.Skill))
							}, target, skill.SourceUnit, true, false).AddCode(Formless._formlessActiveSourceKey));
						}
						damages.Add(new BattleDamage(target, skill, list));
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
			case 2u:
				goto IL_401;
			case 3u:
				Block_8:
				try
				{
					switch (num)
					{
					case 3u:
						Block_66:
						try
						{
							switch (num)
							{
							}
							if (enumerator10.MoveNext())
							{
								_3 = enumerator10.Current;
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
								if ((disposable3 = (enumerator10 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					}
					while (enumerator8.MoveNext())
					{
						bdamage2 = enumerator8.Current;
						numberofValidHits2 = 0;
						enumerator9 = bdamage2.Damages.GetEnumerator();
						try
						{
							while (enumerator9.MoveNext())
							{
								DamageComponent damageComponent = enumerator9.Current;
								if (damageComponent.IsCrit && !damageComponent.HasFullyNeutralized())
								{
									numberOfCrit++;
									numberofValidHits2++;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator9).Dispose();
						}
						totalDispels = dispel.NumberOfDispels * numberofValidHits2;
						if (totalDispels > 0)
						{
							enumerator10 = UnitStyleConfigurationBase.DispelPositiveEffects(bdamage2.Target, new int?(totalDispels)).GetEnumerator();
							num = 4294967293u;
							goto Block_66;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator8).Dispose();
					}
				}
				goto IL_842;
			case 4u:
				Block_14:
				try
				{
					switch (num)
					{
					}
					if (enumerator12.MoveNext())
					{
						_4 = enumerator12.Current;
						this.$current = _4;
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable4 = (enumerator12 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				enumerator13 = extraReleaseable.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						BattleDamage battleDamage = enumerator13.Current;
						foreach (DamageComponent damageComponent2 in battleDamage.Damages)
						{
							if (edgeless != null)
							{
								if (!damageComponent2.IsMissed)
								{
									numberOfEdgelessBoosts++;
								}
								else
								{
									numberOfEdgelessBoosts = 0;
									hasMiss = true;
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator13).Dispose();
				}
				goto IL_B38;
			case 5u:
				Block_20:
				try
				{
					switch (num)
					{
					case 5u:
						Block_100:
						try
						{
							switch (num)
							{
							}
							if (enumerator16.MoveNext())
							{
								_5 = enumerator16.Current;
								this.$current = _5;
								if (!this.$disposing)
								{
									this.$PC = 5;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable5 = (enumerator16 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator15.MoveNext())
					{
						battleEffectBase = enumerator15.Current;
						enumerator16 = skill.SourceUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
						num = 4294967293u;
						goto Block_100;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator15).Dispose();
					}
				}
				goto IL_CD1;
			case 6u:
				Block_21:
				try
				{
					switch (num)
					{
					}
					if (enumerator17.MoveNext())
					{
						_6 = enumerator17.Current;
						this.$current = _6;
						if (!this.$disposing)
						{
							this.$PC = 6;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable6 = (enumerator17 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
				i++;
				goto IL_E1A;
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
			numberOfCrit = 0;
			numberOfEdgelessBoosts = 0;
			hasMiss = false;
			edgeless = skill.SourceUnit.SpecialEffects.OfType<EdgelessData>().FirstOrDefault<EdgelessData>();
			enumerator3 = releaseable.BattleDamages.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					BattleDamage battleDamage2 = enumerator3.Current;
					foreach (DamageComponent damageComponent3 in battleDamage2.Damages)
					{
						if (damageComponent3.IsCrit && !damageComponent3.HasFullyNeutralized())
						{
							numberOfCrit++;
						}
						if (edgeless != null)
						{
							if (!damageComponent3.IsMissed)
							{
								numberOfEdgelessBoosts++;
							}
							else
							{
								numberOfEdgelessBoosts = 0;
								hasMiss = true;
							}
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator3).Dispose();
			}
			attributeDecay = skill.SourceUnit.SpecialEffects.OfType<FormlessAttributeDecayData>().FirstOrDefault<FormlessAttributeDecayData>();
			if (attributeDecay == null)
			{
				goto IL_656;
			}
			enumerator5 = releaseable.BattleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_401:
				switch (num)
				{
				case 2u:
					Block_48:
					try
					{
						switch (num)
						{
						}
						if (enumerator7.MoveNext())
						{
							_2 = enumerator7.Current;
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
							if ((disposable2 = (enumerator7 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator5.MoveNext())
				{
					bdamage = enumerator5.Current;
					numberofValidHits = 0;
					totaldamage = 0.0;
					enumerator6 = bdamage.Damages.GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							DamageComponent damageComponent4 = enumerator6.Current;
							if (damageComponent4.IsCrit && !damageComponent4.HasFullyNeutralized())
							{
								numberOfCrit++;
								numberofValidHits++;
								totaldamage += damageComponent4.GetTotalDamageSoFar();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator6).Dispose();
					}
					totalDecay = attributeDecay.DecayRate * (double)numberofValidHits * totaldamage;
					if (totalDecay > 0.0)
					{
						enumerator7 = bdamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.Allresistances,
								ModificationType = ModificationType.Addition,
								Value = -totalDecay,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "formlessattributedecay", new int?(1), new float?((float)attributeDecay.Seconds), null, true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_48;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			IL_656:
			dispel = skill.SourceUnit.SpecialEffects.OfType<FormlessDispelData>().FirstOrDefault<FormlessDispelData>();
			if (dispel != null)
			{
				enumerator8 = releaseable.BattleDamages.GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			}
			IL_842:
			if (numberOfCrit > 0 && !skill.SourceUnit.SpecialEffects.OfType<FormlessAttributeDecayData>().Any<FormlessAttributeDecayData>() && !skill.SourceUnit.SpecialEffects.OfType<FormlessDispelData>().Any<FormlessDispelData>())
			{
				extraDamages = new List<BattleDamage>();
				targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
				if (targets.Any<IBattleUnit>())
				{
					enumerator11 = targets.GetEnumerator();
					try
					{
						while (enumerator11.MoveNext())
						{
							IBattleUnit target2 = enumerator11.Current;
							extraDamages.Add(new BattleDamage(target2, skill, Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target2, OutputType.Divine, base.AdditionalCritBonusRate(skill.Skill)),
								new DamagePotionValue(skill.SourceUnit, target2, skill.SourceUnit.GetOutputType(), base.AdditionalCritBonusCasterRate(skill.Skill))
							}, target2, skill.SourceUnit, true, false), numberOfCrit).ToList<DamageComponentValue>()));
						}
					}
					finally
					{
						((IDisposable)enumerator11).Dispose();
					}
					extraReleaseable = new ReleaseableDamage(extraDamages, skill.SourceUnit);
					enumerator12 = extraReleaseable.Release().GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
			}
			IL_B38:
			if (edgeless == null || numberOfEdgelessBoosts <= 0)
			{
				goto IL_E2B;
			}
			string code = "edgelessunique";
			if (numberOfEdgelessBoosts > 20)
			{
				numberOfEdgelessBoosts = 20;
			}
			if (hasMiss)
			{
				toremove = (from ef in skill.SourceUnit.BattleEffects
				where ef.EffectSourceIdentityCode == code
				select ef).ToList<BattleEffectBase>();
				enumerator15 = toremove.GetEnumerator();
				num = 4294967293u;
				goto Block_20;
			}
			IL_CD1:
			i = 0;
			IL_E1A:
			if (i < numberOfEdgelessBoosts)
			{
				enumerator17 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						Value = edgeless.BoostRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, code, new int?(20), null, null, false, false, false), false).GetEnumerator();
				num = 4294967293u;
				goto Block_21;
			}
			IL_E2B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012DC RID: 4828
		// (get) Token: 0x06005A6B RID: 23147 RVA: 0x0013778C File Offset: 0x00135B8C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012DD RID: 4829
		// (get) Token: 0x06005A6C RID: 23148 RVA: 0x00137794 File Offset: 0x00135B94
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A6D RID: 23149 RVA: 0x0013779C File Offset: 0x00135B9C
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator7 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator10 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator8).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator12 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable5 = (enumerator16 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator15).Dispose();
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator17 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005A6E RID: 23150 RVA: 0x001379B0 File Offset: 0x00135DB0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A6F RID: 23151 RVA: 0x001379B7 File Offset: 0x00135DB7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A70 RID: 23152 RVA: 0x001379C0 File Offset: 0x00135DC0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Formless.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Formless.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005A71 RID: 23153 RVA: 0x00137A0C File Offset: 0x00135E0C
		private static int <>m__0(FormlessExtraHitData s)
		{
			return s.Extra;
		}

		// Token: 0x06005A72 RID: 23154 RVA: 0x00137A14 File Offset: 0x00135E14
		private static int <>m__1(CubeStarSkillBoostData s)
		{
			return s.Extra;
		}

		// Token: 0x04004B02 RID: 19202
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004B03 RID: 19203
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004B04 RID: 19204
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004B05 RID: 19205
		internal AdventureUnitSkill skill;

		// Token: 0x04004B06 RID: 19206
		internal ReleaseableDamage <releaseable>__0;

		// Token: 0x04004B07 RID: 19207
		internal IEnumerator $locvar1;

		// Token: 0x04004B08 RID: 19208
		internal object <_>__1;

		// Token: 0x04004B09 RID: 19209
		internal IDisposable $locvar2;

		// Token: 0x04004B0A RID: 19210
		internal int <numberOfCrit>__0;

		// Token: 0x04004B0B RID: 19211
		internal int <numberOfEdgelessBoosts>__0;

		// Token: 0x04004B0C RID: 19212
		internal bool <hasMiss>__0;

		// Token: 0x04004B0D RID: 19213
		internal EdgelessData <edgeless>__0;

		// Token: 0x04004B0E RID: 19214
		internal List<BattleDamage>.Enumerator $locvar3;

		// Token: 0x04004B0F RID: 19215
		internal FormlessAttributeDecayData <attributeDecay>__0;

		// Token: 0x04004B10 RID: 19216
		internal List<BattleDamage>.Enumerator $locvar5;

		// Token: 0x04004B11 RID: 19217
		internal BattleDamage <bdamage>__2;

		// Token: 0x04004B12 RID: 19218
		internal int <numberofValidHits>__3;

		// Token: 0x04004B13 RID: 19219
		internal double <totaldamage>__3;

		// Token: 0x04004B14 RID: 19220
		internal List<DamageComponent>.Enumerator $locvar6;

		// Token: 0x04004B15 RID: 19221
		internal double <totalDecay>__3;

		// Token: 0x04004B16 RID: 19222
		internal IEnumerator $locvar7;

		// Token: 0x04004B17 RID: 19223
		internal object <_>__4;

		// Token: 0x04004B18 RID: 19224
		internal IDisposable $locvar8;

		// Token: 0x04004B19 RID: 19225
		internal FormlessDispelData <dispel>__0;

		// Token: 0x04004B1A RID: 19226
		internal List<BattleDamage>.Enumerator $locvar9;

		// Token: 0x04004B1B RID: 19227
		internal BattleDamage <bdamage>__5;

		// Token: 0x04004B1C RID: 19228
		internal int <numberofValidHits>__6;

		// Token: 0x04004B1D RID: 19229
		internal List<DamageComponent>.Enumerator $locvarA;

		// Token: 0x04004B1E RID: 19230
		internal int <totalDispels>__6;

		// Token: 0x04004B1F RID: 19231
		internal IEnumerator $locvarB;

		// Token: 0x04004B20 RID: 19232
		internal object <_>__7;

		// Token: 0x04004B21 RID: 19233
		internal IDisposable $locvarC;

		// Token: 0x04004B22 RID: 19234
		internal List<BattleDamage> <extraDamages>__8;

		// Token: 0x04004B23 RID: 19235
		internal List<IBattleUnit> <targets>__8;

		// Token: 0x04004B24 RID: 19236
		internal List<IBattleUnit>.Enumerator $locvarD;

		// Token: 0x04004B25 RID: 19237
		internal ReleaseableDamage <extraReleaseable>__9;

		// Token: 0x04004B26 RID: 19238
		internal IEnumerator $locvarE;

		// Token: 0x04004B27 RID: 19239
		internal object <_>__10;

		// Token: 0x04004B28 RID: 19240
		internal IDisposable $locvarF;

		// Token: 0x04004B29 RID: 19241
		internal List<BattleDamage>.Enumerator $locvar10;

		// Token: 0x04004B2A RID: 19242
		internal List<BattleEffectBase> <toremove>__12;

		// Token: 0x04004B2B RID: 19243
		internal List<BattleEffectBase>.Enumerator $locvar12;

		// Token: 0x04004B2C RID: 19244
		internal BattleEffectBase <battleEffectBase>__13;

		// Token: 0x04004B2D RID: 19245
		internal IEnumerator $locvar13;

		// Token: 0x04004B2E RID: 19246
		internal object <_>__14;

		// Token: 0x04004B2F RID: 19247
		internal IDisposable $locvar14;

		// Token: 0x04004B30 RID: 19248
		internal int <i>__15;

		// Token: 0x04004B31 RID: 19249
		internal IEnumerator $locvar15;

		// Token: 0x04004B32 RID: 19250
		internal object <_>__16;

		// Token: 0x04004B33 RID: 19251
		internal IDisposable $locvar16;

		// Token: 0x04004B34 RID: 19252
		internal Formless $this;

		// Token: 0x04004B35 RID: 19253
		internal object $current;

		// Token: 0x04004B36 RID: 19254
		internal bool $disposing;

		// Token: 0x04004B37 RID: 19255
		internal int $PC;

		// Token: 0x04004B38 RID: 19256
		private static Func<FormlessExtraHitData, int> <>f__am$cache0;

		// Token: 0x04004B39 RID: 19257
		private static Func<CubeStarSkillBoostData, int> <>f__am$cache1;

		// Token: 0x04004B3A RID: 19258
		private Formless.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey3 $locvar17;

		// Token: 0x02000E10 RID: 3600
		private sealed class <CastSkillLogic>c__AnonStorey3
		{
			// Token: 0x06005A85 RID: 23173 RVA: 0x00137A1C File Offset: 0x00135E1C
			public <CastSkillLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06005A86 RID: 23174 RVA: 0x00137A24 File Offset: 0x00135E24
			internal bool <>m__0(BattleEffectBase ef)
			{
				return ef.EffectSourceIdentityCode == this.code;
			}

			// Token: 0x04004B54 RID: 19284
			internal string code;

			// Token: 0x04004B55 RID: 19285
			internal Formless.<CastSkillLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000E0E RID: 3598
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A73 RID: 23155 RVA: 0x00137A37 File Offset: 0x00135E37
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005A74 RID: 23156 RVA: 0x00137A40 File Offset: 0x00135E40
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage)
				{
					goto IL_1C6;
				}
				damage = (data as BattleDamage);
				if (damage == null || damage.Dealer != processingSkill.SourceUnit)
				{
					goto IL_1C6;
				}
				enumerator = (from d in damage.Damages
				where d.IsCritDamage() && !d.IsMissed
				select d).GetEnumerator();
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
					break;
				}
				if (enumerator.MoveNext())
				{
					damageComponent = enumerator.Current;
					enumerator2 = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateCritRateBoostEffect(base.GetType().FullName, base.PassiveBoostRate(processingSkill.Skill), processingSkill), false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			IL_1C6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012DE RID: 4830
		// (get) Token: 0x06005A75 RID: 23157 RVA: 0x00137C54 File Offset: 0x00136054
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012DF RID: 4831
		// (get) Token: 0x06005A76 RID: 23158 RVA: 0x00137C5C File Offset: 0x0013605C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A77 RID: 23159 RVA: 0x00137C64 File Offset: 0x00136064
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
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005A78 RID: 23160 RVA: 0x00137CFC File Offset: 0x001360FC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A79 RID: 23161 RVA: 0x00137D03 File Offset: 0x00136103
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A7A RID: 23162 RVA: 0x00137D0C File Offset: 0x0013610C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Formless.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new Formless.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.data = data;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x06005A7B RID: 23163 RVA: 0x00137D64 File Offset: 0x00136164
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsCritDamage() && !d.IsMissed;
		}

		// Token: 0x04004B3B RID: 19259
		internal AdventureEventType eventType;

		// Token: 0x04004B3C RID: 19260
		internal object data;

		// Token: 0x04004B3D RID: 19261
		internal BattleDamage <damage>__1;

		// Token: 0x04004B3E RID: 19262
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004B3F RID: 19263
		internal IEnumerator<DamageComponent> $locvar0;

		// Token: 0x04004B40 RID: 19264
		internal DamageComponent <damageComponent>__2;

		// Token: 0x04004B41 RID: 19265
		internal IEnumerator $locvar1;

		// Token: 0x04004B42 RID: 19266
		internal object <_>__3;

		// Token: 0x04004B43 RID: 19267
		internal IDisposable $locvar2;

		// Token: 0x04004B44 RID: 19268
		internal Formless $this;

		// Token: 0x04004B45 RID: 19269
		internal object $current;

		// Token: 0x04004B46 RID: 19270
		internal bool $disposing;

		// Token: 0x04004B47 RID: 19271
		internal int $PC;

		// Token: 0x04004B48 RID: 19272
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}

	// Token: 0x02000E0F RID: 3599
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A7C RID: 23164 RVA: 0x00137D7D File Offset: 0x0013617D
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005A7D RID: 23165 RVA: 0x00137D88 File Offset: 0x00136188
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				tobeRemoved = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName
				select ef).ToList<AttributeModificationEffect>();
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
					critRateBoostEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(critRateBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012E0 RID: 4832
		// (get) Token: 0x06005A7E RID: 23166 RVA: 0x00137F18 File Offset: 0x00136318
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012E1 RID: 4833
		// (get) Token: 0x06005A7F RID: 23167 RVA: 0x00137F20 File Offset: 0x00136320
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A80 RID: 23168 RVA: 0x00137F28 File Offset: 0x00136328
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

		// Token: 0x06005A81 RID: 23169 RVA: 0x00137FBC File Offset: 0x001363BC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A82 RID: 23170 RVA: 0x00137FC3 File Offset: 0x001363C3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A83 RID: 23171 RVA: 0x00137FCC File Offset: 0x001363CC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Formless.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new Formless.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005A84 RID: 23172 RVA: 0x0013800C File Offset: 0x0013640C
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName;
		}

		// Token: 0x04004B49 RID: 19273
		internal AdventureUnitSkill skill;

		// Token: 0x04004B4A RID: 19274
		internal List<AttributeModificationEffect> <tobeRemoved>__0;

		// Token: 0x04004B4B RID: 19275
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004B4C RID: 19276
		internal AttributeModificationEffect <critRateBoostEffect>__1;

		// Token: 0x04004B4D RID: 19277
		internal IEnumerator $locvar1;

		// Token: 0x04004B4E RID: 19278
		internal object <_>__2;

		// Token: 0x04004B4F RID: 19279
		internal IDisposable $locvar2;

		// Token: 0x04004B50 RID: 19280
		internal Formless $this;

		// Token: 0x04004B51 RID: 19281
		internal object $current;

		// Token: 0x04004B52 RID: 19282
		internal bool $disposing;

		// Token: 0x04004B53 RID: 19283
		internal int $PC;
	}
}
