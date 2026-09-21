using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006BB RID: 1723
public class Crash : ActiveSkillLogicBase
{
	// Token: 0x06002DDE RID: 11742 RVA: 0x00131CE8 File Offset: 0x001300E8
	public Crash()
	{
	}

	// Token: 0x06002DDF RID: 11743 RVA: 0x00131D10 File Offset: 0x00130110
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new CrashExtraDamageTalent(SkillType.Crash, 1),
			new CrashExtraHitTalent(SkillType.Crash, 2),
			new CrashDispelTalent(SkillType.Crash, 3)
		};
	}

	// Token: 0x170005D6 RID: 1494
	// (get) Token: 0x06002DE0 RID: 11744 RVA: 0x00131D57 File Offset: 0x00130157
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005D7 RID: 1495
	// (get) Token: 0x06002DE1 RID: 11745 RVA: 0x00131D5F File Offset: 0x0013015F
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005D8 RID: 1496
	// (get) Token: 0x06002DE2 RID: 11746 RVA: 0x00131D67 File Offset: 0x00130167
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005D9 RID: 1497
	// (get) Token: 0x06002DE3 RID: 11747 RVA: 0x00131D6F File Offset: 0x0013016F
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002DE4 RID: 11748 RVA: 0x00131D77 File Offset: 0x00130177
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002DE5 RID: 11749 RVA: 0x00131D7E File Offset: 0x0013017E
	public override double GetGaugeCost(Skill skill)
	{
		return 40.0;
	}

	// Token: 0x06002DE6 RID: 11750 RVA: 0x00131D89 File Offset: 0x00130189
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002DE7 RID: 11751 RVA: 0x00131D95 File Offset: 0x00130195
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002DE8 RID: 11752 RVA: 0x00131D9D File Offset: 0x0013019D
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002DE9 RID: 11753 RVA: 0x00131DA4 File Offset: 0x001301A4
	private int NumberOfHits(Skill skill)
	{
		return 3 + (skill.Level - 1);
	}

	// Token: 0x06002DEA RID: 11754 RVA: 0x00131DB0 File Offset: 0x001301B0
	private double DamageRate(Skill skill)
	{
		return 0.9;
	}

	// Token: 0x06002DEB RID: 11755 RVA: 0x00131DBB File Offset: 0x001301BB
	private double CasterDamageRate(Skill skill)
	{
		return 0.7;
	}

	// Token: 0x06002DEC RID: 11756 RVA: 0x00131DC6 File Offset: 0x001301C6
	private double ArmorEnhance(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002DED RID: 11757 RVA: 0x00131DE8 File Offset: 0x001301E8
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.NumberOfActiveTriggers, this.NumberOfHits(skill).ToString()).Replace(this.MainDamageRateKey, this.DamageRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.CasterDamageRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.ArmorEnhance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002DEE RID: 11758 RVA: 0x00131E78 File Offset: 0x00130278
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		if (strategy.Selections.Any<IBattleUnit>())
		{
			Dictionary<IBattleUnit, List<DamageComponentValue>> hits = new Dictionary<IBattleUnit, List<DamageComponentValue>>();
			int numberOfHits = this.NumberOfHits(skill.Skill);
			if (skill.SourceUnit.GetUnitType() == UnitClass.StreetMan)
			{
				numberOfHits += skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect s) => s.Extra);
			}
			numberOfHits += skill.SourceUnit.SpecialEffects.OfType<CrashExtraHitData>().Sum((CrashExtraHitData s) => s.Extra);
			numberOfHits += skill.SourceUnit.SpecialEffects.OfType<StreetManStarHitBoostData>().Sum((StreetManStarHitBoostData s) => s.Extra);
			StreetManStarHitBoostData star = skill.SourceUnit.SpecialEffects.OfType<StreetManStarHitBoostData>().FirstOrDefault<StreetManStarHitBoostData>();
			CrashDispelData dispel = skill.SourceUnit.SpecialEffects.OfType<CrashDispelData>().FirstOrDefault<CrashDispelData>();
			double totalEffectResistance = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectResistanceRating, AttributeRetrievalLevel.Skill);
			for (int i = 0; i < numberOfHits; i++)
			{
				IBattleUnit selection = strategy.Selections[UnityEngine.Random.Range(0, strategy.Selections.Count)];
				List<DamagePotionValue> potions = new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, selection, OutputType.Physical, this.DamageRate(skill.Skill)),
					new DamagePotionValue(skill.SourceUnit, selection, skill.SourceUnit.GetOutputType(), this.CasterDamageRate(skill.Skill))
				};
				foreach (CrashExtraDamageData crashExtraDamageData in skill.SourceUnit.SpecialEffects.OfType<CrashExtraDamageData>().ToList<CrashExtraDamageData>())
				{
					potions.Add(new DamagePotionValue(skill.SourceUnit, selection, crashExtraDamageData.Type, crashExtraDamageData.Rate));
				}
				if (hits.ContainsKey(selection))
				{
					hits[selection].Add(new DamageComponentValue(potions, selection, skill.SourceUnit, true, false));
				}
				else
				{
					hits.Add(selection, new List<DamageComponentValue>
					{
						new DamageComponentValue(potions, selection, skill.SourceUnit, true, false)
					});
				}
				if (dispel != null)
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(selection, new int?(dispel.NumberOfDispel)).GetEnumerator();
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
				if (star != null)
				{
					IEnumerator enumerator3 = selection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectResistanceRating,
							ModificationType = ModificationType.Addition,
							Value = -totalEffectResistance * 2.0,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "streetmandecayunique", new int?(5), null, new int?(1), false, true), false).GetEnumerator();
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
			List<BattleDamage> damages = (from h in hits
			select new BattleDamage(h.Key, skill, h.Value)).ToList<BattleDamage>();
			ReleaseableDamage releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
			IEnumerator enumerator4 = releaseable.Release().GetEnumerator();
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
			if (skill.SourceUnit.SpecialEffects.OfType<StreetManEnhancementData>().Any<StreetManEnhancementData>())
			{
				StreetManEnhancementData enhancement = skill.SourceUnit.SpecialEffects.OfType<StreetManEnhancementData>().First<StreetManEnhancementData>();
				int currentExtra = skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect e) => e.Extra);
				double extraStrength = skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect e) => e.ExtraStrength);
				string code = "streetmanenhancement";
				foreach (BattleDamage releaseableBattleDamage in releaseable.BattleDamages)
				{
					using (List<DamageComponent>.Enumerator enumerator6 = releaseableBattleDamage.Damages.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							DamageComponent damageComponent = enumerator6.Current;
							if (!damageComponent.IsMissed)
							{
								double existingValue = (from ef in damageComponent.Target.BattleEffects.OfType<AttributeModificationEffect>()
								where ef.EffectSourceIdentityCode == code
								select ef).Sum((AttributeModificationEffect ef) => ef.GetAdditionalModifiers(damageComponent.Target, damageComponent.Target.CurrentEncounter).Sum((AttributeModifier a) => -a.Value));
								double ntake = enhancement.SuckRate * damageComponent.Target.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
								double toreduce = existingValue + ntake;
								if (toreduce > 0.0)
								{
									IEnumerator enumerator7 = damageComponent.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
									{
										new AttributeModifier
										{
											AttributeType = AttributeType.Strength,
											ModificationType = ModificationType.Addition,
											Value = -toreduce,
											Key = string.Empty,
											AttributeModifierType = AttributeModifierType.Skill
										}
									}, code, new int?(1), new float?(10f), null, true, true), false).GetEnumerator();
									try
									{
										while (enumerator7.MoveNext())
										{
											object _4 = enumerator7.Current;
											yield return _4;
										}
									}
									finally
									{
										IDisposable disposable4;
										if ((disposable4 = (enumerator7 as IDisposable)) != null)
										{
											disposable4.Dispose();
										}
									}
									extraStrength += toreduce;
								}
							}
						}
					}
				}
				IEnumerator enumerator8 = skill.SourceUnit.ApplySkillEffect(new CrashExtraEffect(currentExtra + enhancement.ExtraHits, skill, extraStrength), false).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _5 = enumerator8.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator8 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002DEF RID: 11759 RVA: 0x00131EAC File Offset: 0x001302AC
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		double boost = this.ArmorEnhance(skill.Skill);
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArmorEnhancementEffect(base.GetType().FullName + "passive", boost, ModificationType.Multiplication, null, null, skill), false).GetEnumerator();
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

	// Token: 0x06002DF0 RID: 11760 RVA: 0x00131ED8 File Offset: 0x001302D8
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect armorEnhancementEffect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(armorEnhancementEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x040026E8 RID: 9960
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x040026E9 RID: 9961
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x040026EA RID: 9962
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026EB RID: 9963
	private SkillType _skillType = SkillType.Crash;

	// Token: 0x02000DF8 RID: 3576
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059C5 RID: 22981 RVA: 0x00131F02 File Offset: 0x00130302
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x00131F0C File Offset: 0x0013030C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (strategy.Selections.Any<IBattleUnit>())
				{
					hits = new Dictionary<IBattleUnit, List<DamageComponentValue>>();
					numberOfHits = base.NumberOfHits(skill.Skill);
					if (skill.SourceUnit.GetUnitType() == UnitClass.StreetMan)
					{
						numberOfHits += skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect s) => s.Extra);
					}
					numberOfHits += skill.SourceUnit.SpecialEffects.OfType<CrashExtraHitData>().Sum((CrashExtraHitData s) => s.Extra);
					numberOfHits += skill.SourceUnit.SpecialEffects.OfType<StreetManStarHitBoostData>().Sum((StreetManStarHitBoostData s) => s.Extra);
					star = skill.SourceUnit.SpecialEffects.OfType<StreetManStarHitBoostData>().FirstOrDefault<StreetManStarHitBoostData>();
					dispel = skill.SourceUnit.SpecialEffects.OfType<CrashDispelData>().FirstOrDefault<CrashDispelData>();
					totalEffectResistance = skill.SourceUnit.GetAttributeValue_Final(AttributeType.EffectResistanceRating, AttributeRetrievalLevel.Skill);
					i = 0;
					goto IL_5F6;
				}
				goto IL_BA6;
			case 1u:
				Block_10:
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
				Block_12:
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
				goto IL_5E8;
			case 3u:
				Block_14:
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
				if (<CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<StreetManEnhancementData>().Any<StreetManEnhancementData>())
				{
					enhancement = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<StreetManEnhancementData>().First<StreetManEnhancementData>();
					currentExtra = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect e) => e.Extra);
					extraStrength = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.BattleEffects.OfType<CrashExtraEffect>().Sum((CrashExtraEffect e) => e.ExtraStrength);
					string code = "streetmanenhancement";
					enumerator5 = releaseable.BattleDamages.GetEnumerator();
					num = 4294967293u;
					goto Block_18;
				}
				goto IL_BA6;
			case 4u:
				goto IL_7FE;
			case 5u:
				goto IL_B22;
			default:
				return false;
			}
			IL_4B4:
			if (star != null)
			{
				enumerator3 = selection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectResistanceRating,
						ModificationType = ModificationType.Addition,
						Value = -totalEffectResistance * 2.0,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "streetmandecayunique", new int?(5), null, new int?(1), false, true), false).GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			}
			IL_5E8:
			i++;
			IL_5F6:
			if (i >= numberOfHits)
			{
				damages = (from h in hits
				select new BattleDamage(h.Key, <CastSkillLogic>c__AnonStorey.skill, h.Value)).ToList<BattleDamage>();
				releaseable = new ReleaseableDamage(damages, <CastSkillLogic>c__AnonStorey.skill.SourceUnit);
				enumerator4 = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			}
			selection = strategy.Selections[UnityEngine.Random.Range(0, strategy.Selections.Count)];
			potions = new List<DamagePotionValue>
			{
				new DamagePotionValue(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, selection, OutputType.Physical, base.DamageRate(<CastSkillLogic>c__AnonStorey.skill.Skill)),
				new DamagePotionValue(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, selection, <CastSkillLogic>c__AnonStorey.skill.SourceUnit.GetOutputType(), base.CasterDamageRate(<CastSkillLogic>c__AnonStorey.skill.Skill))
			};
			enumerator = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<CrashExtraDamageData>().ToList<CrashExtraDamageData>().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					CrashExtraDamageData crashExtraDamageData = enumerator.Current;
					potions.Add(new DamagePotionValue(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, selection, crashExtraDamageData.Type, crashExtraDamageData.Rate));
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (hits.ContainsKey(selection))
			{
				hits[selection].Add(new DamageComponentValue(potions, selection, <CastSkillLogic>c__AnonStorey.skill.SourceUnit, true, false));
			}
			else
			{
				hits.Add(selection, new List<DamageComponentValue>
				{
					new DamageComponentValue(potions, selection, <CastSkillLogic>c__AnonStorey.skill.SourceUnit, true, false)
				});
			}
			if (dispel != null)
			{
				enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(selection, new int?(dispel.NumberOfDispel)).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			goto IL_4B4;
			Block_18:
			try
			{
				IL_7FE:
				switch (num)
				{
				case 4u:
					Block_42:
					try
					{
						switch (num)
						{
						case 4u:
							Block_47:
							try
							{
								switch (num)
								{
								}
								if (enumerator7.MoveNext())
								{
									_4 = enumerator7.Current;
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
									if ((disposable4 = (enumerator7 as IDisposable)) != null)
									{
										disposable4.Dispose();
									}
								}
							}
							extraStrength += toreduce;
							break;
						}
						while (enumerator6.MoveNext())
						{
							DamageComponent damageComponent = enumerator6.Current;
							if (!damageComponent.IsMissed)
							{
								existingValue = (from ef in damageComponent.Target.BattleEffects.OfType<AttributeModificationEffect>()
								where ef.EffectSourceIdentityCode == <CastSkillLogic>c__AnonStorey2.code
								select ef).Sum((AttributeModificationEffect ef) => ef.GetAdditionalModifiers(damageComponent.Target, damageComponent.Target.CurrentEncounter).Sum((AttributeModifier a) => -a.Value));
								ntake = enhancement.SuckRate * damageComponent.Target.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
								toreduce = existingValue + ntake;
								if (toreduce > 0.0)
								{
									enumerator7 = damageComponent.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, new List<AttributeModifier>
									{
										new AttributeModifier
										{
											AttributeType = AttributeType.Strength,
											ModificationType = ModificationType.Addition,
											Value = -toreduce,
											Key = string.Empty,
											AttributeModifierType = AttributeModifierType.Skill
										}
									}, <CastSkillLogic>c__AnonStorey2.code, new int?(1), new float?(10f), null, true, true), false).GetEnumerator();
									num = 4294967293u;
									goto Block_47;
								}
							}
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator6).Dispose();
						}
					}
					break;
				}
				if (enumerator5.MoveNext())
				{
					releaseableBattleDamage = enumerator5.Current;
					enumerator6 = releaseableBattleDamage.Damages.GetEnumerator();
					num = 4294967293u;
					goto Block_42;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			enumerator8 = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.ApplySkillEffect(new CrashExtraEffect(currentExtra + enhancement.ExtraHits, <CastSkillLogic>c__AnonStorey.skill, extraStrength), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_B22:
				switch (num)
				{
				}
				if (enumerator8.MoveNext())
				{
					_5 = enumerator8.Current;
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
					if ((disposable5 = (enumerator8 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			IL_BA6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012B8 RID: 4792
		// (get) Token: 0x060059C7 RID: 22983 RVA: 0x00132B90 File Offset: 0x00130F90
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012B9 RID: 4793
		// (get) Token: 0x060059C8 RID: 22984 RVA: 0x00132B98 File Offset: 0x00130F98
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059C9 RID: 22985 RVA: 0x00132BA0 File Offset: 0x00130FA0
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
			case 4u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable4 = (enumerator7 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator6).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator8 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060059CA RID: 22986 RVA: 0x00132D54 File Offset: 0x00131154
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059CB RID: 22987 RVA: 0x00132D5B File Offset: 0x0013115B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059CC RID: 22988 RVA: 0x00132D64 File Offset: 0x00131164
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Crash.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Crash.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x060059CD RID: 22989 RVA: 0x00132DB0 File Offset: 0x001311B0
		private static int <>m__0(CrashExtraEffect s)
		{
			return s.Extra;
		}

		// Token: 0x060059CE RID: 22990 RVA: 0x00132DB8 File Offset: 0x001311B8
		private static int <>m__1(CrashExtraHitData s)
		{
			return s.Extra;
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x00132DC0 File Offset: 0x001311C0
		private static int <>m__2(StreetManStarHitBoostData s)
		{
			return s.Extra;
		}

		// Token: 0x060059D0 RID: 22992 RVA: 0x00132DC8 File Offset: 0x001311C8
		private static int <>m__3(CrashExtraEffect e)
		{
			return e.Extra;
		}

		// Token: 0x060059D1 RID: 22993 RVA: 0x00132DD0 File Offset: 0x001311D0
		private static double <>m__4(CrashExtraEffect e)
		{
			return e.ExtraStrength;
		}

		// Token: 0x04004A0E RID: 18958
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004A0F RID: 18959
		internal Dictionary<IBattleUnit, List<DamageComponentValue>> <hits>__1;

		// Token: 0x04004A10 RID: 18960
		internal AdventureUnitSkill skill;

		// Token: 0x04004A11 RID: 18961
		internal int <numberOfHits>__1;

		// Token: 0x04004A12 RID: 18962
		internal StreetManStarHitBoostData <star>__1;

		// Token: 0x04004A13 RID: 18963
		internal CrashDispelData <dispel>__1;

		// Token: 0x04004A14 RID: 18964
		internal double <totalEffectResistance>__1;

		// Token: 0x04004A15 RID: 18965
		internal int <i>__2;

		// Token: 0x04004A16 RID: 18966
		internal IBattleUnit <selection>__3;

		// Token: 0x04004A17 RID: 18967
		internal List<DamagePotionValue> <potions>__3;

		// Token: 0x04004A18 RID: 18968
		internal List<CrashExtraDamageData>.Enumerator $locvar0;

		// Token: 0x04004A19 RID: 18969
		internal IEnumerator $locvar1;

		// Token: 0x04004A1A RID: 18970
		internal object <_>__4;

		// Token: 0x04004A1B RID: 18971
		internal IDisposable $locvar2;

		// Token: 0x04004A1C RID: 18972
		internal IEnumerator $locvar3;

		// Token: 0x04004A1D RID: 18973
		internal object <_>__5;

		// Token: 0x04004A1E RID: 18974
		internal IDisposable $locvar4;

		// Token: 0x04004A1F RID: 18975
		internal List<BattleDamage> <damages>__1;

		// Token: 0x04004A20 RID: 18976
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04004A21 RID: 18977
		internal IEnumerator $locvar5;

		// Token: 0x04004A22 RID: 18978
		internal object <_>__6;

		// Token: 0x04004A23 RID: 18979
		internal IDisposable $locvar6;

		// Token: 0x04004A24 RID: 18980
		internal StreetManEnhancementData <enhancement>__7;

		// Token: 0x04004A25 RID: 18981
		internal int <currentExtra>__7;

		// Token: 0x04004A26 RID: 18982
		internal double <extraStrength>__7;

		// Token: 0x04004A27 RID: 18983
		internal List<BattleDamage>.Enumerator $locvar7;

		// Token: 0x04004A28 RID: 18984
		internal BattleDamage <releaseableBattleDamage>__8;

		// Token: 0x04004A29 RID: 18985
		internal List<DamageComponent>.Enumerator $locvar8;

		// Token: 0x04004A2A RID: 18986
		internal double <existingValue>__10;

		// Token: 0x04004A2B RID: 18987
		internal double <ntake>__10;

		// Token: 0x04004A2C RID: 18988
		internal double <toreduce>__10;

		// Token: 0x04004A2D RID: 18989
		internal IEnumerator $locvar9;

		// Token: 0x04004A2E RID: 18990
		internal object <_>__11;

		// Token: 0x04004A2F RID: 18991
		internal IDisposable $locvarA;

		// Token: 0x04004A30 RID: 18992
		internal IEnumerator $locvarB;

		// Token: 0x04004A31 RID: 18993
		internal object <_>__12;

		// Token: 0x04004A32 RID: 18994
		internal IDisposable $locvarC;

		// Token: 0x04004A33 RID: 18995
		internal Crash $this;

		// Token: 0x04004A34 RID: 18996
		internal object $current;

		// Token: 0x04004A35 RID: 18997
		internal bool $disposing;

		// Token: 0x04004A36 RID: 18998
		internal int $PC;

		// Token: 0x04004A37 RID: 18999
		private Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey3 $locvarD;

		// Token: 0x04004A38 RID: 19000
		private static Func<CrashExtraEffect, int> <>f__am$cache0;

		// Token: 0x04004A39 RID: 19001
		private static Func<CrashExtraHitData, int> <>f__am$cache1;

		// Token: 0x04004A3A RID: 19002
		private static Func<StreetManStarHitBoostData, int> <>f__am$cache2;

		// Token: 0x04004A3B RID: 19003
		private Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey4 $locvarE;

		// Token: 0x04004A3C RID: 19004
		private static Func<CrashExtraEffect, int> <>f__am$cache3;

		// Token: 0x04004A3D RID: 19005
		private static Func<CrashExtraEffect, double> <>f__am$cache4;

		// Token: 0x04004A3E RID: 19006
		private Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey5 $locvarF;

		// Token: 0x02000DFB RID: 3579
		private sealed class <CastSkillLogic>c__AnonStorey3
		{
			// Token: 0x060059E3 RID: 23011 RVA: 0x00132DD8 File Offset: 0x001311D8
			public <CastSkillLogic>c__AnonStorey3()
			{
			}

			// Token: 0x060059E4 RID: 23012 RVA: 0x00132DE0 File Offset: 0x001311E0
			internal BattleDamage <>m__0(KeyValuePair<IBattleUnit, List<DamageComponentValue>> h)
			{
				return new BattleDamage(h.Key, this.skill, h.Value);
			}

			// Token: 0x04004A53 RID: 19027
			internal AdventureUnitSkill skill;

			// Token: 0x04004A54 RID: 19028
			internal Crash.<CastSkillLogic>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000DFC RID: 3580
		private sealed class <CastSkillLogic>c__AnonStorey4
		{
			// Token: 0x060059E5 RID: 23013 RVA: 0x00132DFB File Offset: 0x001311FB
			public <CastSkillLogic>c__AnonStorey4()
			{
			}

			// Token: 0x04004A55 RID: 19029
			internal string code;

			// Token: 0x04004A56 RID: 19030
			internal Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey3 <>f__ref$3;
		}

		// Token: 0x02000DFD RID: 3581
		private sealed class <CastSkillLogic>c__AnonStorey5
		{
			// Token: 0x060059E6 RID: 23014 RVA: 0x00132E03 File Offset: 0x00131203
			public <CastSkillLogic>c__AnonStorey5()
			{
			}

			// Token: 0x060059E7 RID: 23015 RVA: 0x00132E0B File Offset: 0x0013120B
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.<>f__ref$4.code;
			}

			// Token: 0x060059E8 RID: 23016 RVA: 0x00132E24 File Offset: 0x00131224
			internal double <>m__1(AttributeModificationEffect ef)
			{
				return ef.GetAdditionalModifiers(this.damageComponent.Target, this.damageComponent.Target.CurrentEncounter).Sum((AttributeModifier a) => -a.Value);
			}

			// Token: 0x060059E9 RID: 23017 RVA: 0x00132E74 File Offset: 0x00131274
			private static double <>m__2(AttributeModifier a)
			{
				return -a.Value;
			}

			// Token: 0x04004A57 RID: 19031
			internal DamageComponent damageComponent;

			// Token: 0x04004A58 RID: 19032
			internal Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey3 <>f__ref$3;

			// Token: 0x04004A59 RID: 19033
			internal Crash.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey4 <>f__ref$4;

			// Token: 0x04004A5A RID: 19034
			private static Func<AttributeModifier, double> <>f__am$cache0;
		}
	}

	// Token: 0x02000DF9 RID: 3577
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059D2 RID: 22994 RVA: 0x00132E7D File Offset: 0x0013127D
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x060059D3 RID: 22995 RVA: 0x00132E88 File Offset: 0x00131288
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				boost = base.ArmorEnhance(skill.Skill);
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArmorEnhancementEffect(base.GetType().FullName + "passive", boost, ModificationType.Multiplication, null, null, skill), false).GetEnumerator();
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

		// Token: 0x170012BA RID: 4794
		// (get) Token: 0x060059D4 RID: 22996 RVA: 0x00132FD0 File Offset: 0x001313D0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012BB RID: 4795
		// (get) Token: 0x060059D5 RID: 22997 RVA: 0x00132FD8 File Offset: 0x001313D8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059D6 RID: 22998 RVA: 0x00132FE0 File Offset: 0x001313E0
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

		// Token: 0x060059D7 RID: 22999 RVA: 0x00133050 File Offset: 0x00131450
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059D8 RID: 23000 RVA: 0x00133057 File Offset: 0x00131457
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059D9 RID: 23001 RVA: 0x00133060 File Offset: 0x00131460
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Crash.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new Crash.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004A3F RID: 19007
		internal AdventureUnitSkill skill;

		// Token: 0x04004A40 RID: 19008
		internal double <boost>__0;

		// Token: 0x04004A41 RID: 19009
		internal IEnumerator $locvar0;

		// Token: 0x04004A42 RID: 19010
		internal object <_>__1;

		// Token: 0x04004A43 RID: 19011
		internal IDisposable $locvar1;

		// Token: 0x04004A44 RID: 19012
		internal Crash $this;

		// Token: 0x04004A45 RID: 19013
		internal object $current;

		// Token: 0x04004A46 RID: 19014
		internal bool $disposing;

		// Token: 0x04004A47 RID: 19015
		internal int $PC;
	}

	// Token: 0x02000DFA RID: 3578
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059DA RID: 23002 RVA: 0x001330A0 File Offset: 0x001314A0
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x060059DB RID: 23003 RVA: 0x001330A8 File Offset: 0x001314A8
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
					armorEnhancementEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(armorEnhancementEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012BC RID: 4796
		// (get) Token: 0x060059DC RID: 23004 RVA: 0x00133238 File Offset: 0x00131638
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012BD RID: 4797
		// (get) Token: 0x060059DD RID: 23005 RVA: 0x00133240 File Offset: 0x00131640
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059DE RID: 23006 RVA: 0x00133248 File Offset: 0x00131648
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

		// Token: 0x060059DF RID: 23007 RVA: 0x001332DC File Offset: 0x001316DC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059E0 RID: 23008 RVA: 0x001332E3 File Offset: 0x001316E3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059E1 RID: 23009 RVA: 0x001332EC File Offset: 0x001316EC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Crash.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new Crash.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x060059E2 RID: 23010 RVA: 0x0013332C File Offset: 0x0013172C
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004A48 RID: 19016
		internal AdventureUnitSkill skill;

		// Token: 0x04004A49 RID: 19017
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004A4A RID: 19018
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004A4B RID: 19019
		internal AttributeModificationEffect <armorEnhancementEffect>__1;

		// Token: 0x04004A4C RID: 19020
		internal IEnumerator $locvar1;

		// Token: 0x04004A4D RID: 19021
		internal object <_>__2;

		// Token: 0x04004A4E RID: 19022
		internal IDisposable $locvar2;

		// Token: 0x04004A4F RID: 19023
		internal Crash $this;

		// Token: 0x04004A50 RID: 19024
		internal object $current;

		// Token: 0x04004A51 RID: 19025
		internal bool $disposing;

		// Token: 0x04004A52 RID: 19026
		internal int $PC;
	}
}
