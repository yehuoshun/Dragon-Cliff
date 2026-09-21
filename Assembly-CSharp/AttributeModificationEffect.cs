using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000734 RID: 1844
public class AttributeModificationEffect : BattleEffectBase
{
	// Token: 0x060033D3 RID: 13267 RVA: 0x0015BB70 File Offset: 0x00159F70
	private AttributeModificationEffect()
	{
	}

	// Token: 0x060033D4 RID: 13268 RVA: 0x0015BB78 File Offset: 0x00159F78
	public static AttributeModificationEffect CreateAgilityBoostEffect(string effectSourceIdentityCode, double boostValue, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, IBattleEffectSource effectSource)
	{
		Description description = BattleEffectType.AgilityBoost.GetDescription();
		description.Details1 = description.Details1.Replace("{boostvalue}", boostValue.DoubleToString());
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_maxNumberOfLastingSeconds = maxNumberOfLastingSeconds,
			_numberOfLastingTurns = numberOfLastingTurns,
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					Value = boostValue,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_battleEffectType = BattleEffectType.AgilityBoost,
			_isThroughEffect = false,
			_canBeImmuned = false,
			_canBeDispersed = true,
			_maxStackableInstances = new int?(1),
			Description = description,
			TurnEventsCollected = new List<AdventureEventType>(),
			_battleEffectNatureForWearer = BattleEffectNature.Positive
		};
	}

	// Token: 0x060033D5 RID: 13269 RVA: 0x0015BC50 File Offset: 0x0015A050
	public static AttributeModificationEffect CreateArcaneFocusedEffect(AdventureUnitSkill casingSkill, double boostValue, string sourceIdentityCode)
	{
		Description description = BattleEffectType.ArcaneFocused.GetDescription();
		description.Details1 = description.Details1.Replace("{boostvalue}", (boostValue * 100.0).ToExpression());
		return new AttributeModificationEffect
		{
			_effectSource = casingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectType = BattleEffectType.ArcaneFocused,
			TurnEventsCollected = new List<AdventureEventType>(),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.CritDamage,
					ModificationType = ModificationType.Addition,
					Value = boostValue,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			Description = description,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxStackableInstances = new int?(5),
			_numberOfLastingTurns = new int?(3),
			_maxNumberOfLastingSeconds = null,
			_battleEffectNatureForWearer = BattleEffectNature.Positive
		};
	}

	// Token: 0x060033D6 RID: 13270 RVA: 0x0015BD34 File Offset: 0x0015A134
	public static AttributeModificationEffect CreateArmorEnhancementEffect(string effectSourceIdentityCode, double changeValue, ModificationType modificationType, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, IBattleEffectSource effectSource)
	{
		Description description = BattleEffectType.ArmorEnhancement.GetDescription();
		if (modificationType == ModificationType.Addition)
		{
			description.Details1 = description.Details1.Replace("{value}", changeValue.DoubleToString());
		}
		else
		{
			description.Details1 = description.Details1.Replace("{value}", changeValue.ToExpressionMultiply100() + "%");
		}
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_maxNumberOfLastingSeconds = maxNumberOfLastingSeconds,
			_numberOfLastingTurns = numberOfLastingTurns,
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Allresistances,
					Value = changeValue,
					ModificationType = modificationType,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			Description = description,
			TurnEventsCollected = new List<AdventureEventType>(),
			_battleEffectType = BattleEffectType.ArmorEnhancement,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxStackableInstances = new int?(1),
			_battleEffectNatureForWearer = BattleEffectNature.Positive
		};
	}

	// Token: 0x060033D7 RID: 13271 RVA: 0x0015BE40 File Offset: 0x0015A240
	public static AttributeModificationEffect CreateAttributeObtainEffect(IBattleEffectSource efsource, AttributeType boostAttributeType, double boostValue, string sourceIdentityCode)
	{
		return new AttributeModificationEffect
		{
			_effectSourceIdentityCode = sourceIdentityCode,
			_effectSource = efsource,
			TurnEventsCollected = new List<AdventureEventType>(),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = boostValue,
					AttributeType = boostAttributeType,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			Description = BattleEffectType.AttributeObtain.GetDescription(),
			_maxNumberOfLastingSeconds = null,
			_numberOfLastingTurns = new int?(2),
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_isThroughEffect = false,
			_canBeImmuned = false,
			_canBeDispersed = true,
			_maxStackableInstances = new int?(5),
			_battleEffectType = BattleEffectType.AttributeObtain
		};
	}

	// Token: 0x060033D8 RID: 13272 RVA: 0x0015BEFC File Offset: 0x0015A2FC
	public static AttributeModificationEffect CreateShieldBurnEffect(IBattleEffectSource effectSource, string sourceIdentityCode, int? numberOfLastingTurns, float? numberOfLastingSeconds, List<AttributeModifier> modifiers)
	{
		return new AttributeModificationEffect
		{
			_effectSourceIdentityCode = sourceIdentityCode,
			_effectSource = effectSource,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = BattleEffectType.ArmorReduction.GetDescription(),
			_modifiers = modifiers,
			_numberOfLastingTurns = numberOfLastingTurns,
			_maxNumberOfLastingSeconds = numberOfLastingSeconds,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.ArmorReduction,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxStackableInstances = new int?(1)
		};
	}

	// Token: 0x060033D9 RID: 13273 RVA: 0x0015BF7C File Offset: 0x0015A37C
	public static AttributeModificationEffect CreateArmorReplaceEffect(IBattleEffectSource effectSource, double replacementValue, AttributeType type, string sourceIdentityCode)
	{
		Description description = BattleEffectType.AttributeReplacement.GetDescription();
		description.Details1 = description.Details1.Replace("{attributetype}", type.GetDescription().Title);
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = sourceIdentityCode,
			_maxStackableInstances = new int?(2),
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.AttributeReplacement,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(4f),
			_numberOfLastingTurns = null,
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = type,
					Value = replacementValue,
					ModificationType = ModificationType.Replacement,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			Description = description,
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060033DA RID: 13274 RVA: 0x0015C064 File Offset: 0x0015A464
	public static AttributeModificationEffect CreateAttributeStolenEffect(IBattleEffectSource efsource, AttributeType boostAttributeType, double boostValue, string sourceIdentityCode)
	{
		return new AttributeModificationEffect
		{
			_effectSourceIdentityCode = sourceIdentityCode,
			_effectSource = efsource,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.AttributeStolen,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(6f),
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = boostValue,
					AttributeType = boostAttributeType,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			Description = BattleEffectType.AttributeStolen.GetDescription(),
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060033DB RID: 13275 RVA: 0x0015C124 File Offset: 0x0015A524
	public static AttributeModificationEffect CreateBloodCurseEffect(string effectSourceIdentityCode, int? numberOfLastingTurns, double speedBoostRate, double outputRate, IBattleEffectSource effectSource)
	{
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_maxNumberOfLastingSeconds = null,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.BloodCurseEffect,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = speedBoostRate,
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					Value = outputRate,
					AttributeType = effectSource.SourceUnit.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_maxStackableInstances = new int?(1),
			_numberOfLastingTurns = numberOfLastingTurns,
			Description = BattleEffectType.BloodCurseEffect.GetDescription(),
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060033DC RID: 13276 RVA: 0x0015C228 File Offset: 0x0015A628
	public static AttributeModificationEffect CreateBrightCircleEffect(AdventureUnitSkill causingSkill, double basevalue, double additionalRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.BrightCircle.GetDescription();
		description.Details1 = description.Details1.Replace("{baseamount}", basevalue.ToExpression()).Replace("{rate}", additionalRate.ToExpressionMultiply100());
		IBattleUnit caster = causingSkill.SourceUnit;
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			TurnEventsCollected = new List<AdventureEventType>(),
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.BrightCircle,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(3),
			_modifiers = (from r in UnitExtensions.GetAllResistances()
			select new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Addition,
				Value = basevalue + caster.GetAttributeValue_Final(r, AttributeRetrievalLevel.Skill) * additionalRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}).ToList<AttributeModifier>(),
			_numberOfLastingTurns = new int?(3),
			Description = description
		};
	}

	// Token: 0x060033DD RID: 13277 RVA: 0x0015C324 File Offset: 0x0015A724
	public static AttributeModificationEffect CreateChillEffect(AdventureUnitSkill causingSkill, double speedReductionRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Chill.GetDescription();
		description.Details1 = description.Details1.Replace("{speedreductionrate}", (speedReductionRate * 100.0).ToExpression());
		return new AttributeModificationEffect
		{
			_effectSourceIdentityCode = sourceIdentityCode,
			_effectSource = causingSkill,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.Chill,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(4f),
			_maxStackableInstances = new int?(2),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					Value = -speedReductionRate,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			Description = description,
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060033DE RID: 13278 RVA: 0x0015C40C File Offset: 0x0015A80C
	public static AttributeModificationEffect CreateCritRateBoostEffect(string effectSourceIdentityCode, double boostRate, IBattleEffectSource effectSource)
	{
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.CritRateBoost,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(10),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.CritRate,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = BattleEffectType.CritRateBoost.GetDescription()
		};
	}

	// Token: 0x060033DF RID: 13279 RVA: 0x0015C4D8 File Offset: 0x0015A8D8
	public static AttributeModificationEffect CreateFlourishEffect(AdventureUnitSkill causingSkill, double boostRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Flourish.GetDescription();
		description.Details1 = description.Details1.Replace("{boostrate}", boostRate.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Flourish,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(3),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.PhysicalResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.FireResistanceResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.ShadowResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.IceResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.PoisonResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.DivineResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = boostRate,
					AttributeType = AttributeType.LightningResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(2),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E0 RID: 13280 RVA: 0x0015C6D8 File Offset: 0x0015AAD8
	public static AttributeModificationEffect CreateHarmonyEffect(AdventureUnitSkill causingSkill, double spellPowerIncreaseRate, string sourceIdentityCode, IBattleUnit target)
	{
		Description description = BattleEffectType.Harmony.GetDescription();
		description.Details1 = description.Details1.Replace("{spellpowerincreaserate}", spellPowerIncreaseRate.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Harmony,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = spellPowerIncreaseRate,
					AttributeType = target.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			Description = description,
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060033E1 RID: 13281 RVA: 0x0015C7C0 File Offset: 0x0015ABC0
	public static AttributeModificationEffect CreateHealingReductionEffect(string effectSourceIdentityCode, int? numberOfLastingTurns, float? lastingSeconds, double reductionRate, IBattleEffectSource effectSource, bool canbeimmune)
	{
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.HealingReduction,
			_canBeDispersed = true,
			_canBeImmuned = canbeimmune,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = -reductionRate,
					AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = numberOfLastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = BattleEffectType.HealingReduction.GetDescription()
		};
	}

	// Token: 0x060033E2 RID: 13282 RVA: 0x0015C888 File Offset: 0x0015AC88
	public static AttributeModificationEffect CreateIntelligienceBoostEffect(string effectSourceIdentityCode, double boostValue, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, IBattleEffectSource effectSource)
	{
		Description description = BattleEffectType.IntelligienceBoost.GetDescription();
		description.Details1 = description.Details1.Replace("{value}", boostValue.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSourceIdentityCode = effectSourceIdentityCode,
			_effectSource = effectSource,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.IntelligienceBoost,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = maxNumberOfLastingSeconds,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Intelligience,
					Value = boostValue,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = numberOfLastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E3 RID: 13283 RVA: 0x0015C960 File Offset: 0x0015AD60
	public static AttributeModificationEffect CreateMoraleReductionEffect(AdventureUnitSkill causingSkill, double decreaseRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.MoraleReduction.GetDescription();
		description.Details1 = description.Details1.Replace("{decreaserate}", decreaseRate.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.MoraleReduction,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = -decreaseRate,
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(1),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E4 RID: 13284 RVA: 0x0015CA40 File Offset: 0x0015AE40
	public static AttributeModificationEffect CreateMultiStrikeFocusedEffect(AdventureUnitSkill causingSkill, double critRateIncrease, string sourceIdentityCode)
	{
		Description description = BattleEffectType.MultiStrikeFocused.GetDescription();
		description.Details1 = description.Details1.Replace("{focusvalue}", critRateIncrease.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.MultiStrikeFocused,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(3),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = critRateIncrease,
					AttributeType = AttributeType.CritRate,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(1),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E5 RID: 13285 RVA: 0x0015CB20 File Offset: 0x0015AF20
	public static AttributeModificationEffect CreatePossessedEffect(IBattleEffectSource efsource, List<BoostSetting> boosts, string sourceIdentityCode, int lastingTurns)
	{
		AttributeModificationEffect attributeModificationEffect = new AttributeModificationEffect();
		attributeModificationEffect._effectSource = efsource;
		attributeModificationEffect._effectSourceIdentityCode = sourceIdentityCode;
		attributeModificationEffect._battleEffectNatureForWearer = BattleEffectNature.Positive;
		attributeModificationEffect._battleEffectType = BattleEffectType.Empowerment;
		attributeModificationEffect._canBeDispersed = true;
		attributeModificationEffect._canBeImmuned = false;
		attributeModificationEffect._isThroughEffect = false;
		attributeModificationEffect._maxNumberOfLastingSeconds = null;
		attributeModificationEffect._maxStackableInstances = new int?(1);
		attributeModificationEffect._modifiers = (from b in boosts
		select new AttributeModifier
		{
			AttributeType = b.BoostAttribute,
			Value = b.BoostValue,
			ModificationType = ModificationType.Addition,
			AttributeModifierType = AttributeModifierType.Skill
		}).ToList<AttributeModifier>();
		attributeModificationEffect._numberOfLastingTurns = new int?(lastingTurns);
		attributeModificationEffect.TurnEventsCollected = new List<AdventureEventType>();
		attributeModificationEffect.Description = BattleEffectType.Empowerment.GetDescription();
		return attributeModificationEffect;
	}

	// Token: 0x060033E6 RID: 13286 RVA: 0x0015CBD4 File Offset: 0x0015AFD4
	public static AttributeModificationEffect CreatePrincepleEffect(AdventureUnitSkill causingSkill, double increaseRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Principle.GetDescription();
		description.Details1 = description.Details1.Replace("{increaserate}", increaseRate.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Principle,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(5),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.PhysicalResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.FireResistanceResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.ShadowResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.IceResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.PoisonResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.DivineResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = increaseRate,
					AttributeType = AttributeType.LightningResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(2),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E7 RID: 13287 RVA: 0x0015CDD4 File Offset: 0x0015B1D4
	public static AttributeModificationEffect CreateRageEffect(AdventureUnitSkill causingSkill, double critRateIncrease, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Rage.GetDescription();
		description.Details1 = description.Details1.Replace("{critrate}", critRateIncrease.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Rage,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(5),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = critRateIncrease,
					AttributeType = AttributeType.CritRate,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(2),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E8 RID: 13288 RVA: 0x0015CEB4 File Offset: 0x0015B2B4
	public static AttributeModificationEffect CreateRelentlessEffect(AdventureUnitSkill causingSkill, double armorReductionRate, double strengthIncreaserate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Relentless.GetDescription();
		description.Details1 = description.Details1.Replace("{armorreductionrate}", (armorReductionRate * 100.0).ToExpression()).Replace("{strengthincreaserate}", (strengthIncreaserate * 100.0).ToExpression());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Relentless,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(5),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = -armorReductionRate,
					AttributeType = AttributeType.PhysicalResistance,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					Value = strengthIncreaserate,
					AttributeType = AttributeType.Strength,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = new int?(3),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033E9 RID: 13289 RVA: 0x0015CFE8 File Offset: 0x0015B3E8
	public static AttributeModificationEffect CreateReturnedSoulEffect(List<AttributeModifier> modifiers, IBattleEffectSource effectSource, string sourceIdentityCode)
	{
		return new AttributeModificationEffect
		{
			_effectSource = effectSource,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.ReturnedSoul,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(3),
			_modifiers = modifiers,
			_numberOfLastingTurns = new int?(3),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = BattleEffectType.ReturnedSoul.GetDescription()
		};
	}

	// Token: 0x060033EA RID: 13290 RVA: 0x0015D074 File Offset: 0x0015B474
	public static AttributeModificationEffect CreateStaminaEffect(AdventureUnitSkill causingSkill, double increaseAmount, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Stamina.GetDescription();
		description.Details1 = description.Details1.Replace("{increaseamount}", increaseAmount.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.Stamina,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DamageReduction,
					ModificationType = ModificationType.Addition,
					Value = increaseAmount,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033EB RID: 13291 RVA: 0x0015D15C File Offset: 0x0015B55C
	public static AttributeModificationEffect CreateStrengthBoostEffect(AdventureUnitSkill causingSkill, double strengthBoostValue, string sourceIdentityCode, int? numberOfLastingTurns)
	{
		Description description = BattleEffectType.StrengthBoost.GetDescription();
		description.Details1 = description.Details1.Replace("{strengthboostrate}", strengthBoostValue.ToExpression());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.StrengthBoost,
			_canBeDispersed = true,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = strengthBoostValue,
					AttributeType = AttributeType.Strength,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = numberOfLastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033EC RID: 13292 RVA: 0x0015D234 File Offset: 0x0015B634
	public static AttributeModificationEffect CreateStrengthDecayEffect(AdventureUnitSkill causingSkill, double strengthDecayrate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.StrengthDecay.GetDescription();
		description.Details1 = description.Details1.Replace("{strengthdecayrate}", strengthDecayrate.ToExpressionMultiply100());
		List<AttributeModifier> list = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = -strengthDecayrate,
				AttributeType = AttributeType.Strength,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
		if (causingSkill.SourceUnit.GetUnitType() == UnitClass.Duelist && causingSkill.SourceUnit.SpecialEffects.OfType<ArroganceData>().Any<ArroganceData>())
		{
			list.Add(new AttributeModifier
			{
				Value = -strengthDecayrate,
				AttributeType = AttributeType.Intelligience,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			});
			ArroganceData arroganceData = causingSkill.SourceUnit.SpecialEffects.OfType<ArroganceData>().First<ArroganceData>();
			list.Add(new AttributeModifier
			{
				AttributeType = AttributeType.HitRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = -arroganceData.HitRateDeductionRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
		}
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.StrengthDecay,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(5),
			_modifiers = list,
			_numberOfLastingTurns = new int?(1),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033ED RID: 13293 RVA: 0x0015D3CC File Offset: 0x0015B7CC
	public static AttributeModificationEffect CreatePhysicalDamageProc(IBattleUnit dealer, double reductionValue)
	{
		Description description = BattleEffectType.BrokenArmor.GetDescription();
		description.Details1 = description.Details1.Replace("{value}", (-reductionValue).ToExpression());
		List<AttributeModifier> modifiers = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = reductionValue,
				AttributeType = AttributeType.PhysicalResistance,
				ModificationType = ModificationType.Addition,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
		return new AttributeModificationEffect
		{
			_effectSource = dealer,
			_effectSourceIdentityCode = AttributeModificationEffect.PhysicalDamage_Proc,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.BrokenArmor,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(6f),
			_maxStackableInstances = new int?(1),
			_modifiers = modifiers,
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033EE RID: 13294 RVA: 0x0015D4C0 File Offset: 0x0015B8C0
	public static AttributeModificationEffect CreateIceDamageProc(IBattleUnit dealer, double reductionValue)
	{
		Description description = BattleEffectType.Slowdown.GetDescription();
		description.Details1 = description.Details1.Replace("{reductionrate}", (-reductionValue).ToExpression());
		return new AttributeModificationEffect
		{
			_effectSource = dealer,
			_effectSourceIdentityCode = AttributeModificationEffect.IceDamage_Proc,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.Slowdown,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(6f),
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = reductionValue,
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033EF RID: 13295 RVA: 0x0015D5A4 File Offset: 0x0015B9A4
	public static AttributeModificationEffect CreateDivineDamageProc(IBattleUnit dealer, double reductionValue, AttributeType outputType)
	{
		Description description = BattleEffectType.DivineShine.GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{value}", (-reductionValue).ToExpression()).Replace("{type}", outputType.GetDescription().Title).ToString();
		return new AttributeModificationEffect
		{
			_effectSource = dealer,
			_effectSourceIdentityCode = AttributeModificationEffect.DivineDamage_Proc,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.DivineShine,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(6f),
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = reductionValue,
					AttributeType = outputType,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F0 RID: 13296 RVA: 0x0015D6A4 File Offset: 0x0015BAA4
	public static AttributeModificationEffect CreatePoisonDamageProc(IBattleUnit dealer, double reductionRate)
	{
		Description description = BattleEffectType.Constraint.GetDescription();
		description.Details1 = description.Details1.Replace("{reductionrate}", (-reductionRate).ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = dealer,
			_effectSourceIdentityCode = AttributeModificationEffect.PoisonDamage_Proc,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.Constraint,
			_canBeDispersed = true,
			_canBeImmuned = true,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = new float?(10f),
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					Value = reductionRate,
					AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate,
					ModificationType = ModificationType.Addition,
					AttributeModifierType = AttributeModifierType.Skill
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F1 RID: 13297 RVA: 0x0015D78C File Offset: 0x0015BB8C
	public static AttributeModificationEffect CreateStoneEffect(AdventureUnitSkill causingSkill, double damageReductionRate, string sourceIdentityCode)
	{
		Description description = BattleEffectType.Stone.GetDescription();
		description.Details1 = description.Details1.Replace("{defensivereductionrate}", damageReductionRate.ToExpressionMultiply100());
		return new AttributeModificationEffect
		{
			_effectSource = causingSkill,
			_effectSourceIdentityCode = sourceIdentityCode,
			_battleEffectNatureForWearer = BattleEffectNature.Neutral,
			_battleEffectType = BattleEffectType.Stone,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					ModificationType = ModificationType.Addition,
					AttributeType = AttributeType.DamageReduction,
					Value = damageReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = new int?(2),
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F2 RID: 13298 RVA: 0x0015D87C File Offset: 0x0015BC7C
	public static AttributeModificationEffect CreateArbitraryPostiveAttributeModificationEffect(IBattleUnit causingUnit, List<AttributeModifier> modifiers, string sourceId, int? maxStack, float? lastingSeconds, int? lastingTurns, bool canbeImmune, bool canbeDispersed, bool isthrough = false)
	{
		Description description = BattleEffectType.EnhancedAttributes.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = sourceId,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.EnhancedAttributes,
			_canBeDispersed = canbeDispersed,
			_canBeImmuned = canbeImmune,
			_isThroughEffect = isthrough,
			_maxNumberOfLastingSeconds = lastingSeconds,
			_maxStackableInstances = maxStack,
			_modifiers = modifiers,
			_numberOfLastingTurns = lastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F3 RID: 13299 RVA: 0x0015D900 File Offset: 0x0015BD00
	public static AttributeModificationEffect CreateArbitraryNegativeAttributeModificationEffect(IBattleUnit causingUnit, List<AttributeModifier> modifiers, string sourceId, int? maxStack, float? lastingSeconds, int? lastingTurns, bool canbeImmune, bool canbeDispersed)
	{
		Description description = BattleEffectType.AttributeWeakened.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = sourceId,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.AttributeWeakened,
			_canBeDispersed = canbeDispersed,
			_canBeImmuned = canbeImmune,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = lastingSeconds,
			_maxStackableInstances = maxStack,
			_modifiers = modifiers,
			_numberOfLastingTurns = lastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F4 RID: 13300 RVA: 0x0015D980 File Offset: 0x0015BD80
	public static AttributeModificationEffect CreateDamageIncreasedEffect(IBattleUnit causingUnit, double increaseRate, string sourceId, int? maxStack, float? lastingSeconds, int? lastingTurns, bool canBeImmune, bool canbeDispersed)
	{
		Description description = BattleEffectType.DamageIncreased.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = sourceId,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.DamageIncreased,
			_canBeDispersed = canbeDispersed,
			_canBeImmuned = canBeImmune,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = lastingSeconds,
			_maxStackableInstances = maxStack,
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DamageReduction,
					ModificationType = ModificationType.Addition,
					Value = -increaseRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = lastingTurns,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F5 RID: 13301 RVA: 0x0015DA40 File Offset: 0x0015BE40
	public static AttributeModificationEffect CreateGreatGodnessProtectionEffect(IBattleUnit causingUnit, double damageReductionRate)
	{
		Description description = BattleEffectType.GreatGodnessProtection.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = BattleEffectType.GreatGodnessProtection.ToString(),
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_battleEffectType = BattleEffectType.DamageIncreased,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DamageReduction,
					ModificationType = ModificationType.Addition,
					Value = damageReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F6 RID: 13302 RVA: 0x0015DB2C File Offset: 0x0015BF2C
	public static AttributeModificationEffect CreateSinisterRageEffect(IBattleUnit causingUnit, double agilityReductionRate, double rageReductionRate)
	{
		Description description = BattleEffectType.SinisterRage.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = AttributeModificationEffect.SinsterKey,
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.SinisterRage,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = true,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(10),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Addition,
					Value = -agilityReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.HealingAbsorbRate,
					ModificationType = ModificationType.Replacement,
					Value = 0.0,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.SkillRageEfficiencyRate,
					ModificationType = ModificationType.Addition,
					Value = -rageReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F7 RID: 13303 RVA: 0x0015DC8C File Offset: 0x0015C08C
	public static AttributeModificationEffect CreateDarknessOutputDepressionEffect(IBattleUnit causingUnit, double opReductionRate)
	{
		Description description = BattleEffectType.DarknessOutputDepression.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = BattleEffectType.DarknessOutputDepression.ToString(),
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.DarknessOutputDepression,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Strength,
					ModificationType = ModificationType.Multiplication,
					Value = -opReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Intelligience,
					ModificationType = ModificationType.Multiplication,
					Value = -opReductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F8 RID: 13304 RVA: 0x0015DDB0 File Offset: 0x0015C1B0
	public static AttributeModificationEffect CreateDarknessHealDepressionEffect(IBattleUnit causingUnit, double reductionRate)
	{
		Description description = BattleEffectType.DarknessHealDepression.GetDescription();
		return new AttributeModificationEffect
		{
			_effectSource = causingUnit,
			_effectSourceIdentityCode = BattleEffectType.DarknessHealDepression.ToString(),
			_battleEffectNatureForWearer = BattleEffectNature.Negative,
			_battleEffectType = BattleEffectType.DarknessHealDepression,
			_canBeDispersed = false,
			_canBeImmuned = false,
			_isThroughEffect = false,
			_maxNumberOfLastingSeconds = null,
			_maxStackableInstances = new int?(1),
			_modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate,
					ModificationType = ModificationType.Addition,
					Value = -reductionRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			},
			_numberOfLastingTurns = null,
			TurnEventsCollected = new List<AdventureEventType>(),
			Description = description
		};
	}

	// Token: 0x060033F9 RID: 13305 RVA: 0x0015DE9C File Offset: 0x0015C29C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && this._battleEffectType == BattleEffectType.BloodCurseEffect && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (listener.SpecialEffects.OfType<BloodCurseDispelOnHitData>().Any<BloodCurseDispelOnHitData>())
			{
				int dispel = listener.SpecialEffects.OfType<BloodCurseDispelOnHitData>().Sum((BloodCurseDispelOnHitData s) => s.NumberOfDispels);
				foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(damageBattleDamage.Target, new int?(dispel)).GetEnumerator();
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
			if (listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().Any<BloodCurseOutputDepressionEnhancementData>())
			{
				double depressionRate = listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().Sum((BloodCurseOutputDepressionEnhancementData s) => s.Rate);
				int seconds = listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().First<BloodCurseOutputDepressionEnhancementData>().Seconds;
				foreach (BattleDamage damageBattleDamage2 in damage.BattleDamages)
				{
					IEnumerator enumerator4 = damageBattleDamage2.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(listener, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = damageBattleDamage2.Target.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = -depressionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "bloodcurseoutputdepress", new int?(1), new float?((float)seconds), null, true, true), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x060033FA RID: 13306 RVA: 0x0015DEDC File Offset: 0x0015C2DC
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this._modifiers;
	}

	// Token: 0x060033FB RID: 13307 RVA: 0x0015DEE4 File Offset: 0x0015C2E4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x17000821 RID: 2081
	// (get) Token: 0x060033FC RID: 13308 RVA: 0x0015DF00 File Offset: 0x0015C300
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000822 RID: 2082
	// (get) Token: 0x060033FD RID: 13309 RVA: 0x0015DF08 File Offset: 0x0015C308
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000823 RID: 2083
	// (get) Token: 0x060033FE RID: 13310 RVA: 0x0015DF10 File Offset: 0x0015C310
	// (set) Token: 0x060033FF RID: 13311 RVA: 0x0015DF18 File Offset: 0x0015C318
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x17000824 RID: 2084
	// (get) Token: 0x06003400 RID: 13312 RVA: 0x0015DF21 File Offset: 0x0015C321
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000825 RID: 2085
	// (get) Token: 0x06003401 RID: 13313 RVA: 0x0015DF29 File Offset: 0x0015C329
	// (set) Token: 0x06003402 RID: 13314 RVA: 0x0015DF31 File Offset: 0x0015C331
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x17000826 RID: 2086
	// (get) Token: 0x06003403 RID: 13315 RVA: 0x0015DF3A File Offset: 0x0015C33A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000827 RID: 2087
	// (get) Token: 0x06003404 RID: 13316 RVA: 0x0015DF42 File Offset: 0x0015C342
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000828 RID: 2088
	// (get) Token: 0x06003405 RID: 13317 RVA: 0x0015DF4A File Offset: 0x0015C34A
	// (set) Token: 0x06003406 RID: 13318 RVA: 0x0015DF52 File Offset: 0x0015C352
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x17000829 RID: 2089
	// (get) Token: 0x06003407 RID: 13319 RVA: 0x0015DF5B File Offset: 0x0015C35B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700082A RID: 2090
	// (get) Token: 0x06003408 RID: 13320 RVA: 0x0015DF63 File Offset: 0x0015C363
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003409 RID: 13321 RVA: 0x0015DF6C File Offset: 0x0015C36C
	// Note: this type is marked as 'beforefieldinit'.
	static AttributeModificationEffect()
	{
	}

	// Token: 0x0600340A RID: 13322 RVA: 0x0015DFCC File Offset: 0x0015C3CC
	[CompilerGenerated]
	private static AttributeModifier <CreatePossessedEffect>m__0(BoostSetting b)
	{
		return new AttributeModifier
		{
			AttributeType = b.BoostAttribute,
			Value = b.BoostValue,
			ModificationType = ModificationType.Addition,
			AttributeModifierType = AttributeModifierType.Skill
		};
	}

	// Token: 0x04002867 RID: 10343
	public static string AttributeObtain_PartialKey = "attributeobtain";

	// Token: 0x04002868 RID: 10344
	public static string PhysicalDamage_Proc = "UNIQUEBROKENARMOR";

	// Token: 0x04002869 RID: 10345
	public static string DivineDamage_Proc = "UNIQUEDIVINEDAMAGE";

	// Token: 0x0400286A RID: 10346
	public static string PoisonDamage_Proc = "UNIQUEPOISONDAMAGE";

	// Token: 0x0400286B RID: 10347
	public static string IceDamage_Proc = "UNIQUEICEDAMAGE";

	// Token: 0x0400286C RID: 10348
	public static string SinsterKey = "SINSITERRAGEKEY";

	// Token: 0x0400286D RID: 10349
	public static string BlessedSinKey = "BLESSEDSINKEY";

	// Token: 0x0400286E RID: 10350
	public static string PostDamageReleaseRemovePartial = "PostDamageReleaseRemovePartial";

	// Token: 0x0400286F RID: 10351
	private string _effectSourceIdentityCode;

	// Token: 0x04002870 RID: 10352
	private BattleEffectType _battleEffectType;

	// Token: 0x04002871 RID: 10353
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002872 RID: 10354
	private int? _numberOfLastingTurns;

	// Token: 0x04002873 RID: 10355
	private bool _isThroughEffect;

	// Token: 0x04002874 RID: 10356
	private bool _canBeImmuned;

	// Token: 0x04002875 RID: 10357
	private bool _canBeDispersed;

	// Token: 0x04002876 RID: 10358
	private int? _maxStackableInstances;

	// Token: 0x04002877 RID: 10359
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002878 RID: 10360
	public List<AttributeModifier> _modifiers;

	// Token: 0x04002879 RID: 10361
	private IBattleEffectSource _effectSource;

	// Token: 0x0400287A RID: 10362
	[CompilerGenerated]
	private static Func<BoostSetting, AttributeModifier> <>f__am$cache0;

	// Token: 0x02000E8D RID: 3725
	[CompilerGenerated]
	private sealed class <CreateBrightCircleEffect>c__AnonStorey1
	{
		// Token: 0x06005DC4 RID: 24004 RVA: 0x0015E006 File Offset: 0x0015C406
		public <CreateBrightCircleEffect>c__AnonStorey1()
		{
		}

		// Token: 0x06005DC5 RID: 24005 RVA: 0x0015E010 File Offset: 0x0015C410
		internal AttributeModifier <>m__0(AttributeType r)
		{
			return new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Addition,
				Value = this.basevalue + this.caster.GetAttributeValue_Final(r, AttributeRetrievalLevel.Skill) * this.additionalRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x04005147 RID: 20807
		internal double basevalue;

		// Token: 0x04005148 RID: 20808
		internal IBattleUnit caster;

		// Token: 0x04005149 RID: 20809
		internal double additionalRate;
	}

	// Token: 0x02000E8E RID: 3726
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DC6 RID: 24006 RVA: 0x0015E065 File Offset: 0x0015C465
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005DC7 RID: 24007 RVA: 0x0015E070 File Offset: 0x0015C470
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || this._battleEffectType != BattleEffectType.BloodCurseEffect || eventTriggerUnit != listener || !(data is ReleaseableDamage))
				{
					goto IL_3D9;
				}
				damage = (data as ReleaseableDamage);
				if (!listener.SpecialEffects.OfType<BloodCurseDispelOnHitData>().Any<BloodCurseDispelOnHitData>())
				{
					goto IL_1DB;
				}
				dispel = listener.SpecialEffects.OfType<BloodCurseDispelOnHitData>().Sum((BloodCurseDispelOnHitData s) => s.NumberOfDispels);
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_11:
				try
				{
					switch (num)
					{
					case 2u:
						Block_24:
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
						break;
					}
					if (enumerator3.MoveNext())
					{
						damageBattleDamage2 = enumerator3.Current;
						enumerator4 = damageBattleDamage2.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(listener, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = damageBattleDamage2.Target.GetOutputAttributeType(),
								ModificationType = ModificationType.Multiplication,
								Value = -depressionRate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "bloodcurseoutputdepress", new int?(1), new float?((float)seconds), null, true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_24;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_3D9;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_13:
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
					damageBattleDamage = enumerator.Current;
					enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(damageBattleDamage.Target, new int?(dispel)).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1DB:
			if (listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().Any<BloodCurseOutputDepressionEnhancementData>())
			{
				depressionRate = listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().Sum((BloodCurseOutputDepressionEnhancementData s) => s.Rate);
				seconds = listener.SpecialEffects.OfType<BloodCurseOutputDepressionEnhancementData>().First<BloodCurseOutputDepressionEnhancementData>().Seconds;
				enumerator3 = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			}
			IL_3D9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001394 RID: 5012
		// (get) Token: 0x06005DC8 RID: 24008 RVA: 0x0015E4C4 File Offset: 0x0015C8C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001395 RID: 5013
		// (get) Token: 0x06005DC9 RID: 24009 RVA: 0x0015E4CC File Offset: 0x0015C8CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DCA RID: 24010 RVA: 0x0015E4D4 File Offset: 0x0015C8D4
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
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005DCB RID: 24011 RVA: 0x0015E5C8 File Offset: 0x0015C9C8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DCC RID: 24012 RVA: 0x0015E5CF File Offset: 0x0015C9CF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DCD RID: 24013 RVA: 0x0015E5D8 File Offset: 0x0015C9D8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AttributeModificationEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new AttributeModificationEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005DCE RID: 24014 RVA: 0x0015E63C File Offset: 0x0015CA3C
		private static int <>m__0(BloodCurseDispelOnHitData s)
		{
			return s.NumberOfDispels;
		}

		// Token: 0x06005DCF RID: 24015 RVA: 0x0015E644 File Offset: 0x0015CA44
		private static double <>m__1(BloodCurseOutputDepressionEnhancementData s)
		{
			return s.Rate;
		}

		// Token: 0x0400514A RID: 20810
		internal AdventureEventType eventType;

		// Token: 0x0400514B RID: 20811
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400514C RID: 20812
		internal IBattleUnit listener;

		// Token: 0x0400514D RID: 20813
		internal object data;

		// Token: 0x0400514E RID: 20814
		internal ReleaseableDamage <damage>__1;

		// Token: 0x0400514F RID: 20815
		internal int <dispel>__2;

		// Token: 0x04005150 RID: 20816
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005151 RID: 20817
		internal BattleDamage <damageBattleDamage>__3;

		// Token: 0x04005152 RID: 20818
		internal IEnumerator $locvar1;

		// Token: 0x04005153 RID: 20819
		internal object <_>__4;

		// Token: 0x04005154 RID: 20820
		internal IDisposable $locvar2;

		// Token: 0x04005155 RID: 20821
		internal double <depressionRate>__5;

		// Token: 0x04005156 RID: 20822
		internal int <seconds>__5;

		// Token: 0x04005157 RID: 20823
		internal List<BattleDamage>.Enumerator $locvar3;

		// Token: 0x04005158 RID: 20824
		internal BattleDamage <damageBattleDamage>__6;

		// Token: 0x04005159 RID: 20825
		internal IEnumerator $locvar4;

		// Token: 0x0400515A RID: 20826
		internal object <_>__7;

		// Token: 0x0400515B RID: 20827
		internal IDisposable $locvar5;

		// Token: 0x0400515C RID: 20828
		internal AttributeModificationEffect $this;

		// Token: 0x0400515D RID: 20829
		internal object $current;

		// Token: 0x0400515E RID: 20830
		internal bool $disposing;

		// Token: 0x0400515F RID: 20831
		internal int $PC;

		// Token: 0x04005160 RID: 20832
		private static Func<BloodCurseDispelOnHitData, int> <>f__am$cache0;

		// Token: 0x04005161 RID: 20833
		private static Func<BloodCurseOutputDepressionEnhancementData, double> <>f__am$cache1;
	}
}
