using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.Skills.SkillEffect;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Core.Battle.RunePower;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public static class BattleUnitExtensions
{
	// Token: 0x0600214E RID: 8526 RVA: 0x000E9B93 File Offset: 0x000E7F93
	public static bool IsAliveInBattle(this IBattleUnit unit)
	{
		return unit.Status == BattleUnitStatus.Active;
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x000E9BA0 File Offset: 0x000E7FA0
	public static IBattleUnit GetPetOrNull(this IBattleUnit owner)
	{
		if (owner.IsPlayer)
		{
			return owner.CurrentEncounter.PlayerUnits.OfType<PetBattleUnit>().FirstOrDefault((PetBattleUnit p) => p.OwnerUnit == owner);
		}
		return owner.CurrentEncounter.EnemyUnits.OfType<PetBattleUnit>().FirstOrDefault((PetBattleUnit p) => p.OwnerUnit == owner);
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x000E9C18 File Offset: 0x000E8018
	public static IEnumerable DoTurn(this IBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			Adventure currentAdventure = unit.CurrentAdventure;
			double? actionCountSoFar = currentAdventure.ActionCountSoFar;
			currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() + 1.0));
		}
		if (!unit.IsPlayer)
		{
			if (unit.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad s) => s.GetSpecialEffectType() == SpecialEffectType.Thorns))
			{
				if (unit.CurrentEncounter.PlayerUnits.All((IBattleUnit u) => u.HealthPoints > 0.0))
				{
					IBattleUnit dealer = unit.CurrentEncounter.PlayerUnits.FirstOrDefault<IBattleUnit>();
					List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Desc, new int?(1)).GetTargets(dealer);
					ReleaseableDamage releaseable = new ReleaseableDamage((from t in targets
					select new BattleDamage(t, new SpecialEffectTriggerSource(dealer, SpecialEffectType.Thorns), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(t, dealer, OutputType.RealDamage, dealer.GetReflectiveRateInBattle() * t.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Gear) * 6.0)
						}, t, dealer, false, true)
					})).ToList<BattleDamage>(), dealer);
					IEnumerator enumerator = releaseable.Release().GetEnumerator();
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
				}
			}
		}
		IEnumerator enumerator2 = BattleUnitExtensions.DoTurnLogic(unit).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object _2 = enumerator2.Current;
				yield return _2;
			}
		}
		finally
		{
			IDisposable disposable2;
			if ((disposable2 = (enumerator2 as IDisposable)) != null)
			{
				disposable2.Dispose();
			}
		}
		if (unit.IsPlayer && unit.CurrentAdventure.RunePower != null)
		{
			int adventurePointCollectionRate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightAdventurePointsCollection);
			IEnumerator enumerator3 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, adventurePointCollectionRate, unit).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
			int turnCollectionRate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightTurnCollection);
			IEnumerator enumerator4 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, turnCollectionRate, unit).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		IEnumerable<IBattleUnit> playerUnits = unit.CurrentEncounter.PlayerUnits;
		if (BattleUnitExtensions.<>f__mg$cache0 == null)
		{
			BattleUnitExtensions.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
		}
		foreach (IBattleUnit un in playerUnits.Where(BattleUnitExtensions.<>f__mg$cache0).ToList<IBattleUnit>())
		{
			IEnumerator enumerator6 = un.SelfEventCallback(un, AdventureEventType.AttributeCheckup, null).GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object _5 = enumerator6.Current;
					yield return _5;
				}
			}
			finally
			{
				IDisposable disposable5;
				if ((disposable5 = (enumerator6 as IDisposable)) != null)
				{
					disposable5.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06002151 RID: 8529 RVA: 0x000E9C3C File Offset: 0x000E803C
	private static IEnumerable DoTurnLogic(IBattleUnit unit)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitEntersTurn, null)).GetEnumerator();
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
		if (unit.CanAct())
		{
			if (unit.CanCast())
			{
				IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitSelectsSkill, null)).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				List<AdventureUnitSkill> avaliableSkills = (from sk in unit.Skills
				where sk.GetSkillLogic().CastingStyle == CastingStyle.DirectCast && sk.GetSkillLogic().SkillCommandType == SkillCommandType.Main
				select sk).ToList<AdventureUnitSkill>();
				if (avaliableSkills.Any<AdventureUnitSkill>())
				{
					foreach (AdventureUnitSkill selectedSkill in avaliableSkills)
					{
						IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitSelectedSkill, selectedSkill)).GetEnumerator();
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
						SkillLogicBase selectedSkillLogic = selectedSkill.GetSkillLogic();
						IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCastsSkill, new SkillCastBattleEvent
						{
							Skill = selectedSkill,
							SkillLogic = selectedSkillLogic
						})).GetEnumerator();
						try
						{
							while (enumerator5.MoveNext())
							{
								object _4 = enumerator5.Current;
								yield return _4;
							}
						}
						finally
						{
							IDisposable disposable4;
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
						if (unit.CanCast() && unit.CanAct())
						{
							IEnumerator enumerator6 = selectedSkillLogic.Cast(selectedSkill).GetEnumerator();
							try
							{
								while (enumerator6.MoveNext())
								{
									object _5 = enumerator6.Current;
									yield return _5;
								}
							}
							finally
							{
								IDisposable disposable5;
								if ((disposable5 = (enumerator6 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						IEnumerator enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostCastSkill, new SkillCastBattleEvent
						{
							Skill = selectedSkill,
							SkillLogic = selectedSkillLogic
						})).GetEnumerator();
						try
						{
							while (enumerator7.MoveNext())
							{
								object _6 = enumerator7.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator7 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
					IEnumerator enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesSkillCast, null)).GetEnumerator();
					try
					{
						while (enumerator8.MoveNext())
						{
							object _7 = enumerator8.Current;
							yield return _7;
						}
					}
					finally
					{
						IDisposable disposable7;
						if ((disposable7 = (enumerator8 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator9 = unit.NormalAttack().GetEnumerator();
					try
					{
						while (enumerator9.MoveNext())
						{
							object _8 = enumerator9.Current;
							yield return _8;
						}
					}
					finally
					{
						IDisposable disposable8;
						if ((disposable8 = (enumerator9 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				IEnumerator enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesAction, null)).GetEnumerator();
				try
				{
					while (enumerator10.MoveNext())
					{
						object _9 = enumerator10.Current;
						yield return _9;
					}
				}
				finally
				{
					IDisposable disposable9;
					if ((disposable9 = (enumerator10 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
			}
			else
			{
				IEnumerator enumerator11 = unit.NormalAttack().GetEnumerator();
				try
				{
					while (enumerator11.MoveNext())
					{
						object _10 = enumerator11.Current;
						yield return _10;
					}
				}
				finally
				{
					IDisposable disposable10;
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				IEnumerator enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesAction, null)).GetEnumerator();
				try
				{
					while (enumerator12.MoveNext())
					{
						object _11 = enumerator12.Current;
						yield return _11;
					}
				}
				finally
				{
					IDisposable disposable11;
					if ((disposable11 = (enumerator12 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
			}
		}
		IEnumerator enumerator13 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesTurn, null)).GetEnumerator();
		try
		{
			while (enumerator13.MoveNext())
			{
				object _12 = enumerator13.Current;
				yield return _12;
			}
		}
		finally
		{
			IDisposable disposable12;
			if ((disposable12 = (enumerator13 as IDisposable)) != null)
			{
				disposable12.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x000E9C60 File Offset: 0x000E8060
	public static IEnumerable Escape(this IBattleUnit unit)
	{
		unit.Status = BattleUnitStatus.Escaped;
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitEscaped, unit)).GetEnumerator();
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
		UnityEngine.Debug.Log(unit.GetUnitType() + " escaped");
		yield break;
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x000E9C84 File Offset: 0x000E8084
	public static IEnumerable NormalAttack(this IBattleUnit unit)
	{
		IEnumerator enumerator = unit.GetUnitClassStyle().GetStyleConfig().NormalAttack(unit).GetEnumerator();
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

	// Token: 0x06002154 RID: 8532 RVA: 0x000E9CA8 File Offset: 0x000E80A8
	public static List<Item> ReplaceItem(this List<Item> items, Item replacement)
	{
		List<Item> list = (from i in items
		select i).ToList<Item>();
		Item item = items.FirstOrDefault((Item i) => i.SlotType == replacement.SlotType);
		if (item != null)
		{
			list.Remove(item);
		}
		list.Add(replacement);
		return list;
	}

	// Token: 0x06002155 RID: 8533 RVA: 0x000E9D1C File Offset: 0x000E811C
	public static List<AttributeModifier> GetAllAttributes_Complete(this AdventurerProfile profile, Item replacementItem = null)
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		list.AddRange(profile.GetNakedAttributes());
		list.AddRange(profile.Attributes);
		List<Item> list2 = profile.GetEquipments();
		if (replacementItem != null)
		{
			list2 = list2.ReplaceItem(replacementItem);
		}
		list.AddRange(list2.SelectMany((Item i) => i.GetAttributeModifiers()));
		list.AddRange(list2.SelectMany((Item i) => i.GetSpecialEffects().OfType<IAttributeModifierSpecialEffect>().SelectMany((IAttributeModifierSpecialEffect s) => s.GetModifiers(profile))));
		list.AddRange(profile.SpecialEffects.OfType<IAttributeModifierSpecialEffect>().SelectMany((IAttributeModifierSpecialEffect s) => s.GetModifiers(profile)));
		list.AddRange((from t in profile.Talents
		where t.GetCurrentLevel() > 0
		select t).SelectMany((IAdventurerTalent c) => c.GetSpecialEffects(profile)).OfType<IAttributeModifierSpecialEffect>().SelectMany((IAttributeModifierSpecialEffect s) => s.GetModifiers(profile)));
		List<SetItemResult> setBenefits = list2.GetSetBenefits();
		list.AddRange(setBenefits.SelectMany((SetItemResult b) => b.MinorModifiers));
		list.AddRange(setBenefits.SelectMany((SetItemResult b) => b.MajorModifiers));
		return list;
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x000E9E94 File Offset: 0x000E8294
	private static double CalculateFinalPercentagedValue(double percentage, double value)
	{
		if (percentage >= 0.0)
		{
			if (value >= 0.0)
			{
				return value * percentage;
			}
			return -value * percentage;
		}
		else
		{
			if (value >= 0.0)
			{
				return value * percentage;
			}
			return -(value * percentage);
		}
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x000E9ED4 File Offset: 0x000E82D4
	public static double GetAttributeValue(this List<AttributeModifier> attributes, AttributeType type, AttributeRetrievalLevel retrievalLevel)
	{
		List<AttributeModifier> list = (from a in attributes
		where (!type.IsResistanceAttribute()) ? (a.AttributeType == type) : (a.AttributeType == type || a.AttributeType == AttributeType.Allresistances)
		select a).ToList<AttributeModifier>();
		List<AttributeModifier> source = (from a in list
		where a.AttributeModifierType == AttributeModifierType.Normal
		select a).ToList<AttributeModifier>();
		double num = (from a in source
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double percentage = (from a in source
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value);
		double num2 = BattleUnitExtensions.CalculateFinalPercentagedValue(percentage, num);
		num += num2;
		if (source.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			num = attributes.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		num = type.ValidateAttributeValue(num);
		if (retrievalLevel == AttributeRetrievalLevel.Naked)
		{
			return num;
		}
		List<AttributeModifier> source2 = (from a in list
		where a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded || a.AttributeModifierType == AttributeModifierType.Growth
		select a).ToList<AttributeModifier>();
		double num3 = (from a in source2
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double percentage2 = (from a in source2
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value);
		double num4 = BattleUnitExtensions.CalculateFinalPercentagedValue(percentage2, num3 + num);
		double num5 = num3 + num + num4;
		num5 = type.ValidateAttributeValue(num5);
		if (source2.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			num5 = source2.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		List<AttributeModifier> source3 = (from a in list
		where a.AttributeModifierType == AttributeModifierType.SetBonus
		select a).ToList<AttributeModifier>();
		double num6 = (from a in source3
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double percentage3 = (from a in source3
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value);
		double num7 = BattleUnitExtensions.CalculateFinalPercentagedValue(percentage3, num5 + num6);
		double num8 = num5 + num6 + num7;
		num8 = type.ValidateAttributeValue(num8);
		if (retrievalLevel == AttributeRetrievalLevel.Gear)
		{
			return num8;
		}
		return BattleUnitExtensions.CalculateSkillLevelAttributeFinalValue(type, list, num8);
	}

	// Token: 0x06002158 RID: 8536 RVA: 0x000EA264 File Offset: 0x000E8664
	private static double CalculateSkillLevelAttributeFinalValue(AttributeType type, List<AttributeModifier> filteredAttributes, double bonusLevelResult)
	{
		List<AttributeModifier> source = (from a in filteredAttributes
		where a.AttributeModifierType == AttributeModifierType.Skill
		select a).ToList<AttributeModifier>();
		double num = (from a in source
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double percentage = (from a in source
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value);
		double num2 = BattleUnitExtensions.CalculateFinalPercentagedValue(percentage, bonusLevelResult + num);
		double value = bonusLevelResult + num + num2;
		if (source.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			value = source.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		return type.ValidateAttributeValue(value);
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x000EA398 File Offset: 0x000E8798
	public static double ValidateAttributeValue(this AttributeType type, double value)
	{
		if (type == AttributeType.PhysicalResistance || type == AttributeType.FireResistanceResistance || type == AttributeType.PoisonResistance || type == AttributeType.DivineResistance || type == AttributeType.LightningResistance || type == AttributeType.IceResistance || type == AttributeType.ShadowResistance)
		{
			return value;
		}
		if (type == AttributeType.ReceivedHealEffectivenessChangeRate || type == AttributeType.DealFireDamageEffectivenessChangeRate || type == AttributeType.DealPhysicalDamageEffectivenessChangeRate || type == AttributeType.DealPoisonDamageEffectivenessChangeRate || type == AttributeType.DealDivineDamageEffectivenessChangeRate || type == AttributeType.DealLightningDamageEffectivenessChangeRate || type == AttributeType.DealIceDamageEffectivenessChangeRate || type == AttributeType.DealShadowDamageEffectivenessChangeRate)
		{
			if (value <= -1.0)
			{
				return -1.0;
			}
			return value;
		}
		else
		{
			if (type == AttributeType.DamageReduction || type == AttributeType.SkillRageEfficiencyRate)
			{
				return value;
			}
			if (type == AttributeType.CritDamage)
			{
				if (value < 1.0)
				{
					return 1.0;
				}
				return value;
			}
			else
			{
				if (value < 0.0)
				{
					return 0.0;
				}
				return value;
			}
		}
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x000EA4A4 File Offset: 0x000E88A4
	public static bool IsTurnRelevant(this IBattleUnit unit)
	{
		return unit.GetUnitClassStyle() != UnitClassStyle.Statue && !unit.SpecialEffects.OfType<StandingGunData>().Any<StandingGunData>() && !unit.BattleEffects.OfType<TurnFrozenEffect>().Any<TurnFrozenEffect>();
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x000EA4E0 File Offset: 0x000E88E0
	public static bool IsDamageEffectiveness(this AttributeType type)
	{
		return (from s in BattleUnitExtensions.ElementAttributeTypes
		select s.Value).Any((AttributeType a) => a == type);
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x000EA534 File Offset: 0x000E8934
	public static double GetOutputEffectiveness(this IBattleUnit unit, OutputType type, AttributeRetrievalLevel level)
	{
		if (BattleUnitExtensions.ElementAttributeTypes.ContainsKey(type))
		{
			double num = 1.0 + unit.GetAttributeValue_Final(BattleUnitExtensions.ElementAttributeTypes[type], level);
			if (num > 100.0)
			{
				num = 100.0;
			}
			return num;
		}
		return 1.0;
	}

	// Token: 0x0600215D RID: 8541 RVA: 0x000EA594 File Offset: 0x000E8994
	public static double GetNegativeAttributeValue(this List<AttributeModifier> attributes, AttributeType type, AttributeRetrievalLevel retrievalLevel)
	{
		double num = 0.0;
		List<AttributeModifier> source = (from a in attributes
		where a.AttributeType == type
		select a).ToList<AttributeModifier>();
		List<AttributeModifier> source2 = (from a in source
		where a.AttributeModifierType == AttributeModifierType.Normal
		select a).ToList<AttributeModifier>();
		double num2 = (from a in source2
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		num += (from a in source2
		where a.ModificationType == ModificationType.Addition && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		double num3 = (from a in source2
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value) + 1.0;
		double num4 = (from a in source2
		where a.ModificationType == ModificationType.Multiplication && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		double num5 = num4 * num2;
		num2 *= num3;
		num += num5;
		if (source2.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			num = attributes.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value - num2;
			num2 = attributes.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		if (retrievalLevel == AttributeRetrievalLevel.Naked)
		{
			return num;
		}
		List<AttributeModifier> source3 = (from a in source
		where a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded
		select a).ToList<AttributeModifier>();
		double num6 = (from a in source3
		where a.ModificationType == ModificationType.Addition && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		num += num6;
		double num7 = (from a in source3
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double num8 = (from a in source3
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value) + 1.0;
		double num9 = (from a in source3
		where a.ModificationType == ModificationType.Multiplication && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		double num10 = num2 * num9;
		num += num10;
		double num11 = num2 * num8;
		double num12 = num7 + num11;
		if (source3.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			num = source3.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value - num12;
			num12 = source3.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		if (retrievalLevel == AttributeRetrievalLevel.Gear)
		{
			return num;
		}
		List<AttributeModifier> source4 = (from a in source
		where a.AttributeModifierType == AttributeModifierType.Skill || a.AttributeModifierType == AttributeModifierType.Growth
		select a).ToList<AttributeModifier>();
		double num13 = (from a in source4
		where a.ModificationType == ModificationType.Addition
		select a).Sum((AttributeModifier a) => a.Value);
		double num14 = (from a in source4
		where a.ModificationType == ModificationType.Addition && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		num += num14;
		double num15 = (from a in source4
		where a.ModificationType == ModificationType.Multiplication
		select a).Sum((AttributeModifier a) => a.Value) + 1.0;
		double num16 = (from a in source4
		where a.ModificationType == ModificationType.Multiplication && a.Value < 0.0
		select a).Sum((AttributeModifier a) => a.Value);
		double num17 = num16 * num12;
		num += num17;
		double num18 = num12 * num15;
		double num19 = num13 + num18;
		if (source4.Any((AttributeModifier a) => a.ModificationType == ModificationType.Replacement))
		{
			num = source4.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value - num19;
			num19 = source4.Last((AttributeModifier a) => a.ModificationType == ModificationType.Replacement).Value;
		}
		return num;
	}

	// Token: 0x0600215E RID: 8542 RVA: 0x000EABAC File Offset: 0x000E8FAC
	public static BattleUnitAttributeBriefSet GetAttributeBrief(this IBattleUnit unit)
	{
		int releventMonsterLevel = unit.CurrentAdventure.GetReleventMonsterLevel();
		return new BattleUnitAttributeBriefSet
		{
			NakedBrief = new BattleUnitAttributeBrief
			{
				OutputValue = unit.GetOutputCapacity(AttributeRetrievalLevel.Naked).Value,
				PhysicalDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Physical, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				FireDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Fire, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				DivineDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Divine, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				IceDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Ice, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				LighteningDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Lightening, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				PoisonDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Poison, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				ShadowDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Shadow, AttributeRetrievalLevel.Naked, releventMonsterLevel, null),
				Toughness = unit.GetToughnessValue(AttributeRetrievalLevel.Naked),
				Agility = unit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Naked)
			},
			WithBattleEffects = new BattleUnitAttributeBrief
			{
				OutputValue = unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value,
				PhysicalDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Physical, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				FireDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Fire, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				LighteningDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Lightening, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				DivineDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Divine, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				ShadowDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Shadow, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				PoisonDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Poison, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				IceDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Ice, AttributeRetrievalLevel.Skill, releventMonsterLevel, null),
				Toughness = unit.GetToughnessValue(AttributeRetrievalLevel.Skill),
				Agility = unit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill)
			},
			WithGears = new BattleUnitAttributeBrief
			{
				OutputValue = unit.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value,
				PhysicalDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Physical, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				FireDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Fire, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				LighteningDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Lightening, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				DivineDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Divine, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				ShadowDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Shadow, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				PoisonDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Poison, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				IceDefenceRatio = 1.0 - unit.GetDamageMultiplier(OutputType.Ice, AttributeRetrievalLevel.Gear, releventMonsterLevel, null),
				Toughness = unit.GetToughnessValue(AttributeRetrievalLevel.Gear),
				Agility = unit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Gear)
			}
		};
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x000EAE9C File Offset: 0x000E929C
	public static double GetAttributeValue_Final(this IBattleUnit unit, AttributeType type, AttributeRetrievalLevel retrievalLevel)
	{
		if (type == AttributeType.Agility && unit.GetUnitType() == UnitClass.ToughWoman)
		{
			ToughWomanSwiftnessData toughWomanSwiftnessData = unit.SpecialEffects.OfType<ToughWomanSwiftnessData>().FirstOrDefault<ToughWomanSwiftnessData>();
			if (toughWomanSwiftnessData != null)
			{
				double num = BattleUnitExtensions.CalculateFinalAttributeValue(unit, type, retrievalLevel);
				double num2 = BattleUnitExtensions.CalculateFinalAttributeValue(unit, AttributeType.Strength, retrievalLevel);
				return num + num2 * toughWomanSwiftnessData.Rate;
			}
		}
		return BattleUnitExtensions.CalculateFinalAttributeValue(unit, type, retrievalLevel);
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x000EAEFC File Offset: 0x000E92FC
	private static double CalculateFinalAttributeValue(IBattleUnit unit, AttributeType type, AttributeRetrievalLevel retrievalLevel)
	{
		if (retrievalLevel == AttributeRetrievalLevel.Naked)
		{
			return (!unit.NakedAttributeValues.ContainsKey(type)) ? 0.0 : unit.NakedAttributeValues[type];
		}
		if (retrievalLevel == AttributeRetrievalLevel.Gear)
		{
			return (!unit.GearedAttributeValues.ContainsKey(type)) ? 0.0 : unit.GearedAttributeValues[type];
		}
		List<AttributeModifier> filteredAttributes = (from a in unit.GetModifiers()
		where (!type.IsResistanceAttribute()) ? (a.AttributeType == type) : (a.AttributeType == type || a.AttributeType == AttributeType.Allresistances)
		select a).ToList<AttributeModifier>();
		return BattleUnitExtensions.CalculateSkillLevelAttributeFinalValue(type, filteredAttributes, (!unit.GearedAttributeValues.ContainsKey(type)) ? 0.0 : unit.GearedAttributeValues[type]);
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x000EAFF0 File Offset: 0x000E93F0
	public static double GetCritDamageReductionRate(this IBattleUnit unit, IBattleUnit dealer, AttributeRetrievalLevel retrievalLevel)
	{
		double num = unit.GetAttributeValue_Final(AttributeType.Resilience, retrievalLevel);
		double result = 0.0;
		if (dealer.GetUnitType() == UnitClass.DrunkReader && dealer.SpecialEffects.OfType<DrunkReaderEnhancementData>().Any<DrunkReaderEnhancementData>())
		{
			num *= 0.5;
		}
		if (dealer.BattleEffects.OfType<FocusEffect>().Any<FocusEffect>())
		{
			num *= 0.5;
		}
		if (dealer.SpecialEffects.OfType<OffensiveDamageIgnoreByAttackerData>().Any<OffensiveDamageIgnoreByAttackerData>() && (dealer.GetUnitClassStyle() == UnitClassStyle.PhysicalKiller || dealer.GetUnitClassStyle() == UnitClassStyle.SpellKiller))
		{
			OffensiveDamageIgnoreByAttackerData offensiveDamageIgnoreByAttackerData = dealer.SpecialEffects.OfType<OffensiveDamageIgnoreByAttackerData>().First<OffensiveDamageIgnoreByAttackerData>();
			double num2 = offensiveDamageIgnoreByAttackerData.ResilienceRate * dealer.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Skill);
			num -= num2;
		}
		if (num > 0.0)
		{
			if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == -1)
			{
				result = num / (num + 2500.0);
			}
			else
			{
				result = num / (num + 1500.0);
			}
		}
		return result;
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x000EB104 File Offset: 0x000E9504
	public static double GetAttributeValue_Final(this AdventurerProfile unit, AttributeType type, AttributeRetrievalLevel retrievalLevel, Item replacementItem)
	{
		if (type == AttributeType.Agility && unit.UnitClass == UnitClass.ToughWoman)
		{
			ToughWomanSwiftnessData toughWomanSwiftnessData = unit.GetSpecialEffects().OfType<ToughWomanSwiftnessData>().FirstOrDefault<ToughWomanSwiftnessData>();
			if (toughWomanSwiftnessData != null)
			{
				double attributeValue = unit.GetAllAttributes_Complete(replacementItem).GetAttributeValue(type, retrievalLevel);
				double attributeValue2 = unit.GetAllAttributes_Complete(replacementItem).GetAttributeValue(AttributeType.Strength, retrievalLevel);
				return attributeValue + attributeValue2 * toughWomanSwiftnessData.Rate;
			}
		}
		return unit.GetAllAttributes_Complete(replacementItem).GetAttributeValue(type, retrievalLevel);
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x000EB178 File Offset: 0x000E9578
	public static double GetAttributeValue_Final(this AdventurerProfile unit, AttributeType type, AttributeRetrievalLevel retrievalLevel)
	{
		Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> attributeValues = unit.GetAttributeValues();
		if (type == AttributeType.Agility && unit.UnitClass == UnitClass.ToughWoman)
		{
			ToughWomanSwiftnessData toughWomanSwiftnessData = unit.GetSpecialEffects().OfType<ToughWomanSwiftnessData>().FirstOrDefault<ToughWomanSwiftnessData>();
			if (toughWomanSwiftnessData != null)
			{
				double num = attributeValues.RetrieveLeveledValue(retrievalLevel, AttributeType.Agility);
				double num2 = attributeValues.RetrieveLeveledValue(retrievalLevel, AttributeType.Strength);
				return num + num2 * toughWomanSwiftnessData.Rate;
			}
		}
		return attributeValues.RetrieveLeveledValue(retrievalLevel, type);
	}

	// Token: 0x06002164 RID: 8548 RVA: 0x000EB1E0 File Offset: 0x000E95E0
	public static double RetrieveLeveledValue(this Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> values, AttributeRetrievalLevel level, AttributeType type)
	{
		if (!values.ContainsKey(AttributeRetrievalLevel.Naked))
		{
			return 0.0;
		}
		bool flag = type.IsResistanceAttribute();
		double num = values[AttributeRetrievalLevel.Naked][type][ModificationType.Addition].GetValueOrDefault();
		double num2 = values[AttributeRetrievalLevel.Naked][type][ModificationType.Multiplication].GetValueOrDefault();
		if (flag)
		{
			num += values[AttributeRetrievalLevel.Naked][AttributeType.Allresistances][ModificationType.Addition].GetValueOrDefault();
			num2 += values[AttributeRetrievalLevel.Naked][AttributeType.Allresistances][ModificationType.Multiplication].GetValueOrDefault();
		}
		double num3 = BattleUnitExtensions.CalculateFinalPercentagedValue(num2, num);
		double num4 = num + num3;
		num4 = type.ValidateAttributeValue(num4);
		if (values[AttributeRetrievalLevel.Naked][type][ModificationType.Replacement] != null)
		{
			num4 = values[AttributeRetrievalLevel.Naked][type][ModificationType.Replacement].Value;
		}
		if (flag && values[AttributeRetrievalLevel.Naked][AttributeType.Allresistances][ModificationType.Replacement] != null)
		{
			num4 = values[AttributeRetrievalLevel.Naked][AttributeType.Allresistances][ModificationType.Replacement].Value;
		}
		if (level == AttributeRetrievalLevel.Naked)
		{
			return num4;
		}
		double num5 = values[AttributeRetrievalLevel.Gear][type][ModificationType.Addition].GetValueOrDefault();
		double num6 = values[AttributeRetrievalLevel.Gear][type][ModificationType.Multiplication].GetValueOrDefault();
		if (flag)
		{
			num5 += values[AttributeRetrievalLevel.Gear][AttributeType.Allresistances][ModificationType.Addition].GetValueOrDefault();
			num6 += values[AttributeRetrievalLevel.Gear][AttributeType.Allresistances][ModificationType.Multiplication].GetValueOrDefault();
		}
		double num7 = BattleUnitExtensions.CalculateFinalPercentagedValue(num6, num5 + num4);
		double num8 = num5 + num7 + num4;
		num8 = type.ValidateAttributeValue(num8);
		if (values[AttributeRetrievalLevel.Gear][type][ModificationType.Replacement] != null)
		{
			num8 = values[AttributeRetrievalLevel.Gear][type][ModificationType.Replacement].Value;
		}
		if (flag && values[AttributeRetrievalLevel.Gear][AttributeType.Allresistances][ModificationType.Replacement] != null)
		{
			num8 = values[AttributeRetrievalLevel.Gear][AttributeType.Allresistances][ModificationType.Replacement].Value;
		}
		double num9 = values[AttributeRetrievalLevel.Bonus][type][ModificationType.Addition].GetValueOrDefault();
		double num10 = values[AttributeRetrievalLevel.Bonus][type][ModificationType.Multiplication].GetValueOrDefault();
		if (flag)
		{
			num9 += values[AttributeRetrievalLevel.Bonus][AttributeType.Allresistances][ModificationType.Addition].GetValueOrDefault();
			num10 += values[AttributeRetrievalLevel.Bonus][AttributeType.Allresistances][ModificationType.Multiplication].GetValueOrDefault();
		}
		double num11 = BattleUnitExtensions.CalculateFinalPercentagedValue(num10, num9 + num8);
		double num12 = num11 + num9 + num8;
		num12 = type.ValidateAttributeValue(num12);
		if (values[AttributeRetrievalLevel.Bonus][AttributeType.Allresistances][ModificationType.Replacement] != null)
		{
			num12 = values[AttributeRetrievalLevel.Bonus][AttributeType.Allresistances][ModificationType.Replacement].Value;
		}
		return num12;
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x000EB54C File Offset: 0x000E994C
	public static List<AttributeDisplayValue> GetAttributeDisplayValues(this AdventurerProfile profile, AttributeRetrievalLevel retrievalLevel)
	{
		IEnumerable<AttributeType> enumerable = from a in ItemExtensions.AllAttributeTypes
		where a != AttributeType.None && a != AttributeType.Allresistances
		select a;
		List<AttributeDisplayValue> list = new List<AttributeDisplayValue>();
		foreach (AttributeType attributeType in enumerable)
		{
			double attributeValue_Final = profile.GetAttributeValue_Final(attributeType, retrievalLevel);
			list.Add(new AttributeDisplayValue
			{
				AttributeType = attributeType,
				Value = attributeValue_Final,
				ModificationType = ModificationType.Addition,
				Profile = profile,
				Unit = null
			});
		}
		return list;
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x000EB60C File Offset: 0x000E9A0C
	public static List<AttributeDisplayValue> GetAttributeDisplayValues(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		IEnumerable<AttributeType> enumerable = from a in ItemExtensions.AllAttributeTypes
		where a != AttributeType.None
		select a;
		List<AttributeDisplayValue> list = new List<AttributeDisplayValue>();
		foreach (AttributeType attributeType in enumerable)
		{
			double attributeValue_Final = unit.GetAttributeValue_Final(attributeType, retrievalLevel);
			list.Add(new AttributeDisplayValue
			{
				AttributeType = attributeType,
				Value = attributeValue_Final,
				ModificationType = ModificationType.Addition,
				Unit = unit,
				Profile = null
			});
		}
		return list;
	}

	// Token: 0x06002167 RID: 8551 RVA: 0x000EB6CC File Offset: 0x000E9ACC
	public static List<AttributeDisplayValue> GetDisplayValues(this List<AttributeModifier> modifiers)
	{
		return (from m in modifiers
		select new AttributeDisplayValue
		{
			ModificationType = m.ModificationType,
			AttributeType = m.AttributeType,
			Value = m.Value
		}).ToList<AttributeDisplayValue>();
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x000EB6F8 File Offset: 0x000E9AF8
	public static EquipedItemResult GetItemEquipedResult(this AdventurerProfile profile, Item item)
	{
		List<AttributeDisplayValue> list = new List<AttributeDisplayValue>();
		List<AttributeType> list2 = (from a in ItemExtensions.AllAttributeTypes
		where a != AttributeType.Allresistances
		select a).ToList<AttributeType>();
		foreach (AttributeType attributeType in list2)
		{
			double value = profile.GetAttributeValue_Final(attributeType, AttributeRetrievalLevel.Gear, item) - profile.GetAttributeValue_Final(attributeType, AttributeRetrievalLevel.Gear);
			if (Math.Abs(value) > 1E-07)
			{
				list.Add(new AttributeDisplayValue
				{
					AttributeType = attributeType,
					Value = value,
					ModificationType = ModificationType.Addition
				});
			}
		}
		List<<>__AnonType1<ISpecialEffectDataLoad, string>> originalBenefits = (from ef in profile.GetEquipments().GetSetBenefits().SelectMany((SetItemResult b) => b.MajorEffects)
		select new
		{
			Effect = ef,
			AsString = JsonUtility.ToJson(ef)
		}).ToList();
		List<<>__AnonType1<ISpecialEffectDataLoad, string>> updatedBenefits = (from ef in profile.GetEquipments().ReplaceItem(item).GetSetBenefits().SelectMany((SetItemResult b) => b.MajorEffects)
		select new
		{
			Effect = ef,
			AsString = JsonUtility.ToJson(ef)
		}).ToList();
		var source = (from o in originalBenefits
		where updatedBenefits.All(u => u.AsString != o.AsString)
		select o).ToList();
		var source2 = (from u in updatedBenefits
		where originalBenefits.All(o => o.AsString != u.AsString)
		select u).ToList();
		EquipedItemResult equipedItemResult = new EquipedItemResult();
		equipedItemResult.AddedSpecialEffects = (from a in source2
		select a.Effect).ToList<ISpecialEffectDataLoad>();
		equipedItemResult.Changes = list;
		equipedItemResult.LostSpecialEffects = (from a in source
		select a.Effect).ToList<ISpecialEffectDataLoad>();
		return equipedItemResult;
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x000EB93C File Offset: 0x000E9D3C
	public static UnitOutputCapacity GetOutputCapacity(this AdventurerProfile profile, AttributeRetrievalLevel retrievalLevel)
	{
		return new UnitOutputCapacity(profile, retrievalLevel);
	}

	// Token: 0x0600216A RID: 8554 RVA: 0x000EB945 File Offset: 0x000E9D45
	public static UnitOutputCapacity GetOutputCapacity(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		return new UnitOutputCapacity(unit, retrievalLevel);
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x000EB950 File Offset: 0x000E9D50
	public static AttributeType GetOutputAttributeType(this IBattleUnit unit)
	{
		if (unit.GetUnitType() == UnitClass.ToughWoman)
		{
			ToughWomanSwiftnessData toughWomanSwiftnessData = unit.SpecialEffects.OfType<ToughWomanSwiftnessData>().FirstOrDefault<ToughWomanSwiftnessData>();
			if (toughWomanSwiftnessData != null)
			{
				return AttributeType.Agility;
			}
		}
		List<ClassCategory> source = new List<ClassCategory>
		{
			ClassCategory.Healer,
			ClassCategory.CasterWarrior,
			ClassCategory.CasterTank,
			ClassCategory.CasterSupport,
			ClassCategory.CasterAssassin,
			ClassCategory.Statue
		};
		ClassCategory category = unit.GetUnitClassStyle().GetClassCategory();
		if (source.Any((ClassCategory c) => c == category))
		{
			return AttributeType.Intelligience;
		}
		return AttributeType.Strength;
	}

	// Token: 0x0600216C RID: 8556 RVA: 0x000EB9EC File Offset: 0x000E9DEC
	public static AttributeType GetOutputAttributeType(this AdventurerProfile unit)
	{
		if (unit.UnitClass == UnitClass.ToughWoman)
		{
			ToughWomanSwiftnessData toughWomanSwiftnessData = unit.GetSpecialEffects().OfType<ToughWomanSwiftnessData>().FirstOrDefault<ToughWomanSwiftnessData>();
			if (toughWomanSwiftnessData != null)
			{
				return AttributeType.Agility;
			}
		}
		List<ClassCategory> source = new List<ClassCategory>
		{
			ClassCategory.Healer,
			ClassCategory.CasterWarrior,
			ClassCategory.CasterTank,
			ClassCategory.CasterSupport,
			ClassCategory.CasterAssassin,
			ClassCategory.Statue
		};
		ClassCategory category = unit.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory();
		if (source.Any((ClassCategory c) => c == category))
		{
			return AttributeType.Intelligience;
		}
		return AttributeType.Strength;
	}

	// Token: 0x0600216D RID: 8557 RVA: 0x000EBA90 File Offset: 0x000E9E90
	public static AttributeDisplayValue GetValue(this List<AttributeDisplayValue> values, AttributeType type)
	{
		AttributeDisplayValue result;
		if ((result = values.FirstOrDefault((AttributeDisplayValue v) => v.AttributeType == type)) == null)
		{
			result = new AttributeDisplayValue
			{
				AttributeType = type,
				Value = 0.0,
				ModificationType = ModificationType.Addition
			};
		}
		return result;
	}

	// Token: 0x0600216E RID: 8558 RVA: 0x000EBAEC File Offset: 0x000E9EEC
	public static List<AttributeModifier> AddValue(this List<AttributeModifier> originals, AttributeType type, double value)
	{
		if (originals.Count((AttributeModifier m) => m.AttributeType == type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty) < 3)
		{
			originals.Add(new AttributeModifier
			{
				AttributeType = type,
				ModificationType = ModificationType.Addition,
				Value = value,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Normal
			});
		}
		else
		{
			AttributeModifier attributeModifier = originals.First((AttributeModifier m) => m.AttributeType == type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty);
			originals.Remove(attributeModifier);
			AttributeModifier attributeModifier2 = originals.First((AttributeModifier m) => m.AttributeType == type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty);
			attributeModifier2.Value += attributeModifier.Value;
			originals.Add(new AttributeModifier
			{
				AttributeType = type,
				ModificationType = ModificationType.Addition,
				Value = value,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Normal
			});
		}
		return originals;
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x000EBBD8 File Offset: 0x000E9FD8
	public static double GetSpeed(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 100.0 && unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == 1)
		{
			return Math.Sqrt(unit.GetAttributeValue_Final(AttributeType.Agility, retrievalLevel));
		}
		if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == 2)
		{
			return Math.Sqrt(unit.GetAttributeValue_Final(AttributeType.Agility, retrievalLevel)) * 0.4;
		}
		if (unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating == -1 || unit.CurrentAdventure.CorrespondingDifficultyMeasurement.StarRating > 2)
		{
			return Math.Sqrt(unit.GetAttributeValue_Final(AttributeType.Agility, retrievalLevel)) * 0.15;
		}
		return Math.Sqrt(unit.GetAttributeValue_Final(AttributeType.Agility, retrievalLevel));
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x000EBCA8 File Offset: 0x000EA0A8
	public static double GetMaxLife(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		double attributeValue_Final = unit.GetAttributeValue_Final(AttributeType.Vitality, retrievalLevel);
		ClassCategory classCategory = unit.GetUnitClassStyle().GetClassCategory();
		double num = 4.0;
		if (unit is AdventurerBattleUnit)
		{
			if (classCategory == ClassCategory.CasterTank || classCategory == ClassCategory.MeleeTank)
			{
				num = 5.0;
			}
			if (classCategory == ClassCategory.MeleeWarrior || classCategory == ClassCategory.CasterWarrior)
			{
				num = 4.5;
			}
		}
		double num2 = attributeValue_Final * num;
		if (num2 <= 0.0)
		{
			return 1.0;
		}
		if (retrievalLevel == AttributeRetrievalLevel.Skill && num2 < unit.HealthPoints)
		{
			unit.HealthPoints = num2;
		}
		return num2;
	}

	// Token: 0x06002171 RID: 8561 RVA: 0x000EBD48 File Offset: 0x000EA148
	public static double GetMaxLife(this AdventurerProfile unit, AttributeRetrievalLevel retrievalLevel)
	{
		double attributeValue_Final = unit.GetAttributeValue_Final(AttributeType.Vitality, retrievalLevel);
		ClassCategory classCategory = unit.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory();
		double num = 4.0;
		if (classCategory == ClassCategory.CasterTank || classCategory == ClassCategory.MeleeTank)
		{
			num = 5.0;
		}
		if (classCategory == ClassCategory.MeleeWarrior || classCategory == ClassCategory.CasterWarrior)
		{
			num = 4.5;
		}
		double num2 = attributeValue_Final * num;
		if (num2 <= 0.0)
		{
			return 1.0;
		}
		return num2;
	}

	// Token: 0x06002172 RID: 8562 RVA: 0x000EBDD0 File Offset: 0x000EA1D0
	public static double CritRate(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		double num = unit.GetAttributeValue_Final(AttributeType.CritRate, retrievalLevel);
		if (num > 1.0)
		{
			num = 1.0;
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	// Token: 0x06002173 RID: 8563 RVA: 0x000EBE1C File Offset: 0x000EA21C
	public static double GetCritDamageRate(this IBattleUnit unit, AttributeRetrievalLevel retrievalLevel)
	{
		double num = unit.GetAttributeValue_Final(AttributeType.CritDamage, retrievalLevel);
		if (num < 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	// Token: 0x06002174 RID: 8564 RVA: 0x000EBE4C File Offset: 0x000EA24C
	private static double GetInitDefensiveRating(double ratingValue, int attackerLevel)
	{
		if (attackerLevel < 1)
		{
			attackerLevel = 1;
		}
		if (ratingValue < 0.0)
		{
			return 1.0 + ratingValue / (ratingValue - 100.0);
		}
		return 1.0 - ratingValue / (ratingValue + BattleUnitExtensions.GetMonsterLevelCoe((double)attackerLevel));
	}

	// Token: 0x06002175 RID: 8565 RVA: 0x000EBEA0 File Offset: 0x000EA2A0
	private static double GetMonsterLevelCoe(double attackerlevel)
	{
		if (attackerlevel <= 30.0)
		{
			return attackerlevel * 10.0;
		}
		if (attackerlevel <= 40.0)
		{
			return 300.0 + (attackerlevel - 30.0) * 40.0;
		}
		if (attackerlevel <= 50.0)
		{
			return 700.0 + (attackerlevel - 40.0) * 60.0;
		}
		if (attackerlevel <= 60.0)
		{
			return 1300.0 + (attackerlevel - 50.0) * 80.0;
		}
		if (attackerlevel <= 70.0)
		{
			return 2100.0 + (attackerlevel - 60.0) * 100.0;
		}
		if (attackerlevel <= 80.0)
		{
			return 3100.0 + (attackerlevel - 70.0) * 120.0;
		}
		if (attackerlevel <= 90.0)
		{
			return 4300.0 + (attackerlevel - 80.0) * 140.0;
		}
		return 5700.0 + (attackerlevel - 90.0) * 150.0;
	}

	// Token: 0x06002176 RID: 8566 RVA: 0x000EC004 File Offset: 0x000EA404
	public static double GetDamageMultiplier(this IBattleUnit unit, OutputType type, AttributeRetrievalLevel retrievalLevel, int attackerLevel, IBattleUnit attackerNullable)
	{
		Dictionary<OutputType, AttributeType> dictionary = new Dictionary<OutputType, AttributeType>
		{
			{
				OutputType.Physical,
				AttributeType.PhysicalResistance
			},
			{
				OutputType.Fire,
				AttributeType.FireResistanceResistance
			},
			{
				OutputType.Ice,
				AttributeType.IceResistance
			},
			{
				OutputType.Shadow,
				AttributeType.ShadowResistance
			},
			{
				OutputType.Poison,
				AttributeType.PoisonResistance
			},
			{
				OutputType.Divine,
				AttributeType.DivineResistance
			},
			{
				OutputType.Lightening,
				AttributeType.LightningResistance
			}
		};
		Dictionary<OutputType, AttributeType> dictionary2 = new Dictionary<OutputType, AttributeType>
		{
			{
				OutputType.Physical,
				AttributeType.PhysicalPenetration
			},
			{
				OutputType.Fire,
				AttributeType.FirePenetration
			},
			{
				OutputType.Ice,
				AttributeType.IcePenetration
			},
			{
				OutputType.Shadow,
				AttributeType.ShadowPenetration
			},
			{
				OutputType.Poison,
				AttributeType.PoisonPenetration
			},
			{
				OutputType.Divine,
				AttributeType.DivinePenetration
			},
			{
				OutputType.Lightening,
				AttributeType.LighteningPenetration
			}
		};
		if (!dictionary.ContainsKey(type))
		{
			return 1.0;
		}
		float num = Convert.ToSingle(unit.GetAttributeValue_Final(dictionary[type], retrievalLevel));
		float num2 = 1f;
		if (num > 0f && attackerNullable != null && attackerNullable.BattleEffects.OfType<FocusEffect>().Any<FocusEffect>())
		{
			num2 -= 0.5f;
		}
		AttributeType type2 = dictionary2[type];
		if (attackerNullable != null)
		{
			num2 -= Convert.ToSingle(attackerNullable.GetAttributeValue_Final(type2, AttributeRetrievalLevel.Skill));
		}
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		num *= num2;
		if (attackerNullable != null && attackerNullable.SpecialEffects.OfType<OffensiveDamageIgnoreByAttackerData>().Any<OffensiveDamageIgnoreByAttackerData>())
		{
			OffensiveDamageIgnoreByAttackerData offensiveDamageIgnoreByAttackerData = attackerNullable.SpecialEffects.OfType<OffensiveDamageIgnoreByAttackerData>().First<OffensiveDamageIgnoreByAttackerData>();
			double value = attackerNullable.GetAttributeValue_Final(dictionary[type], AttributeRetrievalLevel.Skill) * offensiveDamageIgnoreByAttackerData.ResistanceRate;
			num -= Convert.ToSingle(value);
		}
		double num3 = BattleUnitExtensions.GetInitDefensiveRating((double)num, attackerLevel);
		double num4 = 0.0;
		num4 += unit.GetAttributeValue_Final(AttributeType.DamageReduction, retrievalLevel);
		if (unit.BattleEffects.Any((BattleEffectBase ef) => ef is DamageReductionEffect) && retrievalLevel == AttributeRetrievalLevel.Skill)
		{
			List<DamageReductionEffect> source = (from r in unit.BattleEffects.OfType<DamageReductionEffect>()
			where r.ReductionTypes.Any((OutputType t) => t == type)
			select r).ToList<DamageReductionEffect>();
			if (source.Any<DamageReductionEffect>())
			{
				num4 += (double)source.Sum((DamageReductionEffect r) => r.ReductionRate);
			}
		}
		num3 *= 1.0 - num4;
		if ((unit is AdventurerBattleUnit || unit is PetBattleUnit) && num3 <= 0.1)
		{
			return 0.1;
		}
		if (unit is EnemyBattleUnit && num3 <= 0.001)
		{
			return 0.001;
		}
		return num3;
	}

	// Token: 0x06002177 RID: 8567 RVA: 0x000EC2E8 File Offset: 0x000EA6E8
	public static double GetDamageMultiplier(this AdventurerProfile unit, OutputType type, int attackerLevel, AttributeRetrievalLevel retrievalLevel)
	{
		Dictionary<OutputType, AttributeType> dictionary = new Dictionary<OutputType, AttributeType>
		{
			{
				OutputType.Physical,
				AttributeType.PhysicalResistance
			},
			{
				OutputType.Fire,
				AttributeType.FireResistanceResistance
			},
			{
				OutputType.Ice,
				AttributeType.IceResistance
			},
			{
				OutputType.Shadow,
				AttributeType.ShadowResistance
			},
			{
				OutputType.Poison,
				AttributeType.PoisonResistance
			},
			{
				OutputType.Divine,
				AttributeType.DivineResistance
			},
			{
				OutputType.Lightening,
				AttributeType.LightningResistance
			}
		};
		if (!dictionary.ContainsKey(type))
		{
			return 1.0;
		}
		float num = Convert.ToSingle(unit.GetAttributeValue_Final(dictionary[type], retrievalLevel));
		double num2 = BattleUnitExtensions.GetInitDefensiveRating((double)num, attackerLevel);
		num2 *= 1.0 - unit.GetAttributeValue_Final(AttributeType.DamageReduction, retrievalLevel);
		if (num2 <= 0.1)
		{
			return 0.1;
		}
		return num2;
	}

	// Token: 0x06002178 RID: 8568 RVA: 0x000EC3A0 File Offset: 0x000EA7A0
	public static IEnumerable<BattleEffectBase> GetDesperseableEffects(this IEnumerable<BattleEffectBase> effects)
	{
		return from ef in effects
		where ef.CanBeDispersed
		select ef;
	}

	// Token: 0x06002179 RID: 8569 RVA: 0x000EC3C5 File Offset: 0x000EA7C5
	public static IEnumerable<BattleEffectBase> GetHarmfulEffects(this IEnumerable<BattleEffectBase> effects)
	{
		return from ef in effects
		where ef.BattleEffectNatureForWearer == BattleEffectNature.Negative
		select ef;
	}

	// Token: 0x0600217A RID: 8570 RVA: 0x000EC3EA File Offset: 0x000EA7EA
	public static IEnumerable<BattleEffectBase> GetPositiveEffects(this IEnumerable<BattleEffectBase> effects)
	{
		return from ef in effects
		where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive
		select ef;
	}

	// Token: 0x0600217B RID: 8571 RVA: 0x000EC410 File Offset: 0x000EA810
	public static IEnumerable ReceivesHeal(this IBattleUnit unit, BattleHeal heal)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesHeal, heal)).GetEnumerator();
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
		double maxLife = unit.GetMaxLife(AttributeRetrievalLevel.Skill);
		foreach (HealComponent healComponent in heal.Heals)
		{
			if (!healComponent.IsNeutralized && healComponent.GetFinalHealSoFar() > 0.0)
			{
				double num = maxLife - unit.HealthPoints;
				if (num < 0.0)
				{
					num = 0.0;
				}
				double num2 = (healComponent.CalculatedHealValue > num) ? num : healComponent.CalculatedHealValue;
				if (num2 < 0.0)
				{
					num2 = 0.0;
				}
				healComponent.ExceededHealValue = new double?((healComponent.CalculatedHealValue > num) ? (healComponent.CalculatedHealValue - num) : 0.0);
				if (healComponent.FinalHealValue != null)
				{
					if (healComponent.FinalHealValue > num2)
					{
						healComponent.FinalHealValue = new double?(num2);
					}
				}
				else
				{
					healComponent.FinalHealValue = new double?(num2);
				}
				unit.HealthPoints += healComponent.FinalHealValue.Value;
				if (unit.HealthPoints < 0.0)
				{
					unit.HealthPoints = 0.0;
				}
			}
		}
		double totalDirectHeal = (from h in heal.Heals
		where h.IsDirectHeal
		select h).Sum((HealComponent h) => h.CalculatedHealValue);
		if (totalDirectHeal > 0.0)
		{
			double absorbRate = unit.GetAttributeValue_Final(AttributeType.HealingAbsorbRate, AttributeRetrievalLevel.Skill);
			if (absorbRate > 0.0)
			{
				IEnumerator enumerator3 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(unit, heal.HealSource, absorbRate * totalDirectHeal).GetEnumerator();
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
		IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostReceivesHeal, heal)).GetEnumerator();
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
		if (heal.Healer.GetUnitType() == UnitClass.GoldenShaman && totalDirectHeal > 0.0)
		{
			ReflectiveHealData exlusive = heal.Healer.SpecialEffects.OfType<ReflectiveHealData>().FirstOrDefault<ReflectiveHealData>();
			if (exlusive != null)
			{
				IEnumerator enumerator5 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.ReflectiveDamage,
						ModificationType = ModificationType.Addition,
						Value = exlusive.Rate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "goldenshamanreflective", new int?(7), new float?(2f), null, false, true, false), false).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _4 = enumerator5.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		if (unit.HealthPoints >= maxLife)
		{
			unit.HealthPoints = maxLife;
		}
		if (unit.HealthPoints < 0.0)
		{
			unit.HealthPoints = 0.0;
		}
		yield break;
	}

	// Token: 0x0600217C RID: 8572 RVA: 0x000EC43C File Offset: 0x000EA83C
	public static IEnumerable EntersEncounter(this IBattleUnit unit, IEncounter encounter)
	{
		unit.BattleEffects = (from ef in unit.BattleEffects
		where ef.IsThroughEffect
		select ef).ToList<BattleEffectBase>();
		Adventure currentAdventure = encounter.CurrentAdventure;
		if (currentAdventure != null && currentAdventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
		{
			Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = currentAdventure.BattleEffectsDictionary[unit.GetId()];
			foreach (KeyValuePair<AdventureEventType, Dictionary<string, BattleEffectBase>> keyValuePair in dictionary)
			{
				List<KeyValuePair<string, BattleEffectBase>> list = (from ef in keyValuePair.Value
				where !ef.Value.IsThroughEffect
				select ef).ToList<KeyValuePair<string, BattleEffectBase>>();
				foreach (KeyValuePair<string, BattleEffectBase> keyValuePair2 in list)
				{
					keyValuePair.Value.Remove(keyValuePair2.Key);
				}
			}
		}
		if (unit is EnemyBattleUnit)
		{
			EnemyBattleUnit enemyBattleUnit = unit as EnemyBattleUnit;
			enemyBattleUnit.HealthPoints = enemyBattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
		}
		yield break;
	}

	// Token: 0x0600217D RID: 8573 RVA: 0x000EC468 File Offset: 0x000EA868
	public static IEnumerable LooseSkillEffect(this IBattleUnit unit, BattleEffectBase effect, EffectWearsOffType wearoffType)
	{
		if (wearoffType == EffectWearsOffType.Dispersed && unit.IsPlayer && effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && unit.CurrentAdventure.RunePower != null)
		{
			int rate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.GhostBreathsDisperseNegativeEffectCollection);
			IEnumerator enumerator = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.GhostBreaths, rate, unit).GetEnumerator();
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
		}
		unit.BattleEffects.Remove(effect);
		Adventure adventure = unit.CurrentAdventure;
		if (adventure != null && adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
		{
			Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = adventure.BattleEffectsDictionary[unit.GetId()];
			foreach (AdventureEventType key in effect.CorrespondingEvents())
			{
				if (dictionary.ContainsKey(key))
				{
					dictionary[key].Remove(effect.Id);
				}
			}
		}
		IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitLoosesEffect, effect)).GetEnumerator();
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
		if (unit.IsAliveInBattle())
		{
			IEnumerator enumerator4 = effect.PosWearsOffProcess_ActiveUnit(unit, wearoffType).GetEnumerator();
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
		else
		{
			IEnumerator enumerator5 = effect.PosWearsOffProcess_InactiveUnit(unit, wearoffType).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _4 = enumerator5.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator5 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x0600217E RID: 8574 RVA: 0x000EC49C File Offset: 0x000EA89C
	public static double GetEffectTimeRatio(this IBattleUnit caster, IBattleUnit target)
	{
		double num = caster.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill) + 1.0;
		if (num < 0.0)
		{
			num = 0.0;
		}
		num *= 1.0 - target.SpecialEffects.OfType<NegativeEffectSpeedupData>().Sum((NegativeEffectSpeedupData t) => t.DecreaseRate);
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	// Token: 0x0600217F RID: 8575 RVA: 0x000EC530 File Offset: 0x000EA930
	public static double GetEffectHitChance(this IBattleUnit caster, IBattleUnit target)
	{
		double num = target.GetAttributeValue_Final(AttributeType.EffectResistanceRating, AttributeRetrievalLevel.Skill) - caster.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Skill);
		if (num < 0.0)
		{
			return 1.0;
		}
		return 1.0 - num / (num + caster.Level * 10.0);
	}

	// Token: 0x06002180 RID: 8576 RVA: 0x000EC590 File Offset: 0x000EA990
	public static bool EffectApplySucceeded(this IBattleUnit caster, IBattleUnit target)
	{
		double effectHitChance = caster.GetEffectHitChance(target);
		return (double)UnityEngine.Random.value <= effectHitChance;
	}

	// Token: 0x06002181 RID: 8577 RVA: 0x000EC5B1 File Offset: 0x000EA9B1
	public static bool CanAct(this IBattleUnit unit)
	{
		return unit.Status == BattleUnitStatus.Active && !unit.BattleEffects.OfType<LockTimeEffect>().Any<LockTimeEffect>();
	}

	// Token: 0x06002182 RID: 8578 RVA: 0x000EC5D5 File Offset: 0x000EA9D5
	public static bool CanCast(this IBattleUnit unit)
	{
		return true;
	}

	// Token: 0x06002183 RID: 8579 RVA: 0x000EC5D8 File Offset: 0x000EA9D8
	public static bool IsEffectImmune(this IBattleUnit unit)
	{
		return unit.BattleEffects.OfType<EffectImmuneEffect>().Any((EffectImmuneEffect e) => (double)UnityEngine.Random.value <= e.Chance);
	}

	// Token: 0x06002184 RID: 8580 RVA: 0x000EC607 File Offset: 0x000EAA07
	private static bool CanBeImmuned(this BattleEffectBase effect)
	{
		return effect.CanBeImmuned && effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && !effect.SourceUnit.BattleEffects.OfType<EmbracedMindEffect>().Any<EmbracedMindEffect>();
	}

	// Token: 0x06002185 RID: 8581 RVA: 0x000EC63C File Offset: 0x000EAA3C
	public static IEnumerable ApplySkillEffect(this IBattleUnit unit, BattleEffectBase effect, bool ignoreTimeReduction = false)
	{
		bool effectCanbeImmuned = effect.CanBeImmuned();
		bool tobeResisted = effectCanbeImmuned && !effect.SourceUnit.EffectApplySucceeded(unit);
		if (effectCanbeImmuned)
		{
			double num = unit.SpecialEffects.OfType<LightningShieldData>().Sum((LightningShieldData r) => r.NegativeResistance);
			if ((double)UnityEngine.Random.value <= num)
			{
				tobeResisted = true;
			}
			if (unit.IsEffectImmune())
			{
				tobeResisted = true;
			}
		}
		if (effectCanbeImmuned && effect is TauntEffect)
		{
			if (unit.SpecialEffects.Any((ISpecialEffectDataLoad ef) => ef is EmeraldOfClearHeartData))
			{
				tobeResisted = true;
			}
		}
		if (unit.GetUnitClassStyle() == UnitClassStyle.Statue && effect.NumberOfLastingTurns != null)
		{
			tobeResisted = true;
		}
		if (effect.NumberOfLastingTurns != null && !ignoreTimeReduction)
		{
			double num2 = effect.SourceUnit.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill) + 1.0;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			int value = (int)Math.Round((double)effect.NumberOfLastingTurns.Value * num2, 0, MidpointRounding.ToEven);
			effect.NumberOfLastingTurns = new int?(value);
		}
		if (effect.MaxNumberOfLastingSeconds != null && !ignoreTimeReduction)
		{
			double num3 = effect.SourceUnit.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill) + 1.0;
			if (num3 < 0.0)
			{
				num3 = 0.0;
			}
			double value2 = (double)effect.MaxNumberOfLastingSeconds.Value * num3;
			effect.MaxNumberOfLastingSeconds = new float?(Convert.ToSingle(value2));
		}
		if (effect.BattleEffectNatureForWearer == BattleEffectNature.Positive && effect.SourceUnit.SpecialEffects.OfType<PositiveEffectBoostData>().Any<PositiveEffectBoostData>())
		{
			double num4 = effect.SourceUnit.SpecialEffects.OfType<PositiveEffectBoostData>().Sum((PositiveEffectBoostData s) => s.Chance);
			if ((double)UnityEngine.Random.value <= num4)
			{
				effect.CanBeDispersed = false;
			}
		}
		if (effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && effect.SourceUnit.SpecialEffects.OfType<NegativeEffectBoostData>().Any<NegativeEffectBoostData>())
		{
			double num5 = effect.SourceUnit.SpecialEffects.OfType<NegativeEffectBoostData>().Sum((NegativeEffectBoostData s) => s.Chance);
			if ((double)UnityEngine.Random.value <= num5)
			{
				effect.CanBeDispersed = false;
			}
		}
		NegativeEffectSpeedupData negativeDefenceEffect = unit.SpecialEffects.OfType<NegativeEffectSpeedupData>().FirstOrDefault<NegativeEffectSpeedupData>();
		if (negativeDefenceEffect != null && effect.EffectSource.SourceUnit != unit && effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && !ignoreTimeReduction)
		{
			if (effect.MaxNumberOfLastingSeconds != null)
			{
				effect.MaxNumberOfLastingSeconds = new float?(Convert.ToSingle((double)effect.MaxNumberOfLastingSeconds.Value * (1.0 - negativeDefenceEffect.DecreaseRate)));
			}
			else if (effect.NumberOfLastingTurns != null)
			{
				int num6 = (int)Math.Round(Convert.ToDouble(effect.NumberOfLastingTurns.Value) * (1.0 - negativeDefenceEffect.DecreaseRate), 0);
				if (num6 == 0)
				{
					effect.NumberOfLastingTurns = new int?(1);
				}
				else
				{
					effect.NumberOfLastingTurns = new int?(num6);
				}
			}
		}
		if (effect is LockTimeEffect && effectCanbeImmuned)
		{
			double num7 = unit.SpecialEffects.OfType<TimeLockResistanceData>().Sum((TimeLockResistanceData r) => r.Chance);
			if ((double)UnityEngine.Random.value <= num7)
			{
				tobeResisted = true;
			}
		}
		if (tobeResisted)
		{
			IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleEffectResisted, effect)).GetEnumerator();
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
		}
		else
		{
			if (effect.SourceUnit.IsPlayer && effect.SourceUnit.CurrentAdventure.RunePower != null && effect is TauntEffect)
			{
				int tauntCollectionRate = effect.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.VitalEnergyTauntCollection);
				IEnumerator enumerator2 = effect.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.VitalEnergy, tauntCollectionRate, effect.SourceUnit).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (effect.MaxStackableInstances != null && effect.MaxStackableInstances.Value == unit.BattleEffects.Count((BattleEffectBase ef) => ef.GetType() == effect.GetType() && ef.EffectSourceIdentityCode == effect.EffectSourceIdentityCode))
			{
				BattleEffectBase existing = unit.BattleEffects.FirstOrDefault((BattleEffectBase ef) => ef.EffectSourceIdentityCode == effect.EffectSourceIdentityCode);
				if (existing != null)
				{
					IEnumerator enumerator3 = unit.LooseSkillEffect(existing, EffectWearsOffType.Duplicate).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _3 = enumerator3.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					if (!existing.CanBeDispersed)
					{
						effect.CanBeDispersed = false;
					}
				}
			}
			unit.BattleEffects.Add(effect);
			Adventure adventure = unit.CurrentAdventure;
			if (adventure != null)
			{
				if (adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = adventure.BattleEffectsDictionary[unit.GetId()];
					foreach (AdventureEventType key in effect.CorrespondingEvents())
					{
						if (dictionary.ContainsKey(key))
						{
							dictionary[key].Add(effect.Id, effect);
						}
						else
						{
							dictionary.Add(key, new Dictionary<string, BattleEffectBase>
							{
								{
									effect.Id,
									effect
								}
							});
						}
					}
				}
				else
				{
					adventure.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
					Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary2 = adventure.BattleEffectsDictionary[unit.GetId()];
					foreach (AdventureEventType key2 in effect.CorrespondingEvents())
					{
						if (dictionary2.ContainsKey(key2))
						{
							dictionary2[key2].Add(effect.Id, effect);
						}
						else
						{
							dictionary2.Add(key2, new Dictionary<string, BattleEffectBase>
							{
								{
									effect.Id,
									effect
								}
							});
						}
					}
				}
			}
			IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesEffect, effect)).GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object _4 = enumerator6.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator6 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
			if (effect.MaxStackableInstances != null && effect.MaxStackableInstances.Value == unit.BattleEffects.Count((BattleEffectBase ef) => ef.EffectSourceIdentityCode == effect.EffectSourceIdentityCode))
			{
				IEnumerator enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleEffectCapStackReached, effect)).GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _5 = enumerator7.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator7 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002186 RID: 8582 RVA: 0x000EC670 File Offset: 0x000EAA70
	public static double GetReflectiveRateInBattle(this IBattleUnit unit)
	{
		if (unit.IsPlayer)
		{
			bool flag = unit.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad s) => s.GetSpecialEffectType() == SpecialEffectType.Thorns);
			if (flag)
			{
				return unit.GetAllLiveFriendlyTargetsIncSelf(false).Sum((IBattleUnit s) => s.GetAttributeValue_Final(AttributeType.ReflectiveDamage, AttributeRetrievalLevel.Skill)) * 2.0;
			}
		}
		return unit.GetAttributeValue_Final(AttributeType.ReflectiveDamage, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x06002187 RID: 8583 RVA: 0x000EC6FC File Offset: 0x000EAAFC
	public static IEnumerable DisperseEffect(this IBattleUnit wearingUnit, BattleEffectBase effect, IBattleUnit dispersedByUnit)
	{
		if (effect.CanBeDispersed)
		{
			IEnumerator enumerator = wearingUnit.LooseSkillEffect(effect, EffectWearsOffType.Dispersed).GetEnumerator();
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
			IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(wearingUnit, AdventureEventType.BattleEffectDispersed, new EffectDispersedEvent
			{
				BattleEffect = effect,
				DispersedBy = dispersedByUnit
			})).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06002188 RID: 8584 RVA: 0x000EC730 File Offset: 0x000EAB30
	public static IEnumerable ChangeTurnCounterProgress(this IBattleUnit unit, UnitTurnProgressUpdateEvent change)
	{
		if (unit.IsTurnRelevant())
		{
			BattleEncounter battleEncounter = unit.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null && battleEncounter.TurnCounter.ContainsKey(unit))
			{
				double currentProgress = battleEncounter.TurnCounter[unit];
				double proposedChange = PlayerProfile.TurnSpeedGauge * change.ChangePercentage;
				if (proposedChange < 0.0 && unit.SpecialEffects.OfType<TurnResistanceData>().Any<TurnResistanceData>())
				{
					double num = unit.SpecialEffects.OfType<TurnResistanceData>().Sum((TurnResistanceData r) => r.Rate);
					double num2 = 1.0 - num;
					if (num2 < 0.0)
					{
						num2 = 0.0;
					}
					proposedChange *= num2;
				}
				double finalChange = proposedChange;
				double resultedProgress = currentProgress + proposedChange;
				if (resultedProgress < 0.0)
				{
					finalChange = 0.0 - currentProgress;
				}
				else if (resultedProgress > PlayerProfile.TurnSpeedGauge)
				{
					finalChange = PlayerProfile.TurnSpeedGauge - currentProgress;
				}
				UnitTurnProgressUpdateResultEvent finalChangePayload = new UnitTurnProgressUpdateResultEvent
				{
					CausingSkill = change.CausingSource,
					ActualChangePercentage = finalChange,
					BattleUnit = unit,
					CausedByUnit = change.Dealer,
					ProposedChangePercentage = proposedChange
				};
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PriorUnitTurnProgressChange, finalChangePayload)).GetEnumerator();
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
				if (battleEncounter.TurnCounter.ContainsKey(unit))
				{
					Dictionary<IBattleUnit, double> turnCounter;
					(turnCounter = battleEncounter.TurnCounter)[unit] = turnCounter[unit] + finalChange;
				}
				IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitTurnProgressAlterred, finalChangePayload)).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002189 RID: 8585 RVA: 0x000EC75C File Offset: 0x000EAB5C
	// Note: this type is marked as 'beforefieldinit'.
	static BattleUnitExtensions()
	{
	}

	// Token: 0x0600218A RID: 8586 RVA: 0x000EC85B File Offset: 0x000EAC5B
	[CompilerGenerated]
	private static Item <ReplaceItem>m__0(Item i)
	{
		return i;
	}

	// Token: 0x0600218B RID: 8587 RVA: 0x000EC85E File Offset: 0x000EAC5E
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetAllAttributes_Complete>m__1(Item i)
	{
		return i.GetAttributeModifiers();
	}

	// Token: 0x0600218C RID: 8588 RVA: 0x000EC866 File Offset: 0x000EAC66
	[CompilerGenerated]
	private static bool <GetAllAttributes_Complete>m__2(IAdventurerTalent t)
	{
		return t.GetCurrentLevel() > 0;
	}

	// Token: 0x0600218D RID: 8589 RVA: 0x000EC871 File Offset: 0x000EAC71
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetAllAttributes_Complete>m__3(SetItemResult b)
	{
		return b.MinorModifiers;
	}

	// Token: 0x0600218E RID: 8590 RVA: 0x000EC879 File Offset: 0x000EAC79
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetAllAttributes_Complete>m__4(SetItemResult b)
	{
		return b.MajorModifiers;
	}

	// Token: 0x0600218F RID: 8591 RVA: 0x000EC881 File Offset: 0x000EAC81
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__5(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Normal;
	}

	// Token: 0x06002190 RID: 8592 RVA: 0x000EC88C File Offset: 0x000EAC8C
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__6(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x06002191 RID: 8593 RVA: 0x000EC897 File Offset: 0x000EAC97
	[CompilerGenerated]
	private static double <GetAttributeValue>m__7(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x06002192 RID: 8594 RVA: 0x000EC89F File Offset: 0x000EAC9F
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__8(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x06002193 RID: 8595 RVA: 0x000EC8AA File Offset: 0x000EACAA
	[CompilerGenerated]
	private static double <GetAttributeValue>m__9(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x06002194 RID: 8596 RVA: 0x000EC8B2 File Offset: 0x000EACB2
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__A(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x06002195 RID: 8597 RVA: 0x000EC8BD File Offset: 0x000EACBD
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__B(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x06002196 RID: 8598 RVA: 0x000EC8C8 File Offset: 0x000EACC8
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__C(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded || a.AttributeModifierType == AttributeModifierType.Growth;
	}

	// Token: 0x06002197 RID: 8599 RVA: 0x000EC8EE File Offset: 0x000EACEE
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__D(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x06002198 RID: 8600 RVA: 0x000EC8F9 File Offset: 0x000EACF9
	[CompilerGenerated]
	private static double <GetAttributeValue>m__E(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x000EC901 File Offset: 0x000EAD01
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__F(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x0600219A RID: 8602 RVA: 0x000EC90C File Offset: 0x000EAD0C
	[CompilerGenerated]
	private static double <GetAttributeValue>m__10(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x0600219B RID: 8603 RVA: 0x000EC914 File Offset: 0x000EAD14
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__11(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x0600219C RID: 8604 RVA: 0x000EC91F File Offset: 0x000EAD1F
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__12(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x0600219D RID: 8605 RVA: 0x000EC92A File Offset: 0x000EAD2A
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__13(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.SetBonus;
	}

	// Token: 0x0600219E RID: 8606 RVA: 0x000EC935 File Offset: 0x000EAD35
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__14(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x0600219F RID: 8607 RVA: 0x000EC940 File Offset: 0x000EAD40
	[CompilerGenerated]
	private static double <GetAttributeValue>m__15(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021A0 RID: 8608 RVA: 0x000EC948 File Offset: 0x000EAD48
	[CompilerGenerated]
	private static bool <GetAttributeValue>m__16(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060021A1 RID: 8609 RVA: 0x000EC953 File Offset: 0x000EAD53
	[CompilerGenerated]
	private static double <GetAttributeValue>m__17(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021A2 RID: 8610 RVA: 0x000EC95B File Offset: 0x000EAD5B
	[CompilerGenerated]
	private static bool <CalculateSkillLevelAttributeFinalValue>m__18(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Skill;
	}

	// Token: 0x060021A3 RID: 8611 RVA: 0x000EC966 File Offset: 0x000EAD66
	[CompilerGenerated]
	private static bool <CalculateSkillLevelAttributeFinalValue>m__19(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x060021A4 RID: 8612 RVA: 0x000EC971 File Offset: 0x000EAD71
	[CompilerGenerated]
	private static double <CalculateSkillLevelAttributeFinalValue>m__1A(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021A5 RID: 8613 RVA: 0x000EC979 File Offset: 0x000EAD79
	[CompilerGenerated]
	private static bool <CalculateSkillLevelAttributeFinalValue>m__1B(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060021A6 RID: 8614 RVA: 0x000EC984 File Offset: 0x000EAD84
	[CompilerGenerated]
	private static double <CalculateSkillLevelAttributeFinalValue>m__1C(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021A7 RID: 8615 RVA: 0x000EC98C File Offset: 0x000EAD8C
	[CompilerGenerated]
	private static bool <CalculateSkillLevelAttributeFinalValue>m__1D(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x000EC997 File Offset: 0x000EAD97
	[CompilerGenerated]
	private static bool <CalculateSkillLevelAttributeFinalValue>m__1E(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021A9 RID: 8617 RVA: 0x000EC9A2 File Offset: 0x000EADA2
	[CompilerGenerated]
	private static AttributeType <IsDamageEffectiveness>m__1F(KeyValuePair<OutputType, AttributeType> s)
	{
		return s.Value;
	}

	// Token: 0x060021AA RID: 8618 RVA: 0x000EC9AB File Offset: 0x000EADAB
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__20(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Normal;
	}

	// Token: 0x060021AB RID: 8619 RVA: 0x000EC9B6 File Offset: 0x000EADB6
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__21(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x060021AC RID: 8620 RVA: 0x000EC9C1 File Offset: 0x000EADC1
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__22(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021AD RID: 8621 RVA: 0x000EC9C9 File Offset: 0x000EADC9
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__23(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition && a.Value < 0.0;
	}

	// Token: 0x060021AE RID: 8622 RVA: 0x000EC9EB File Offset: 0x000EADEB
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__24(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021AF RID: 8623 RVA: 0x000EC9F3 File Offset: 0x000EADF3
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__25(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060021B0 RID: 8624 RVA: 0x000EC9FE File Offset: 0x000EADFE
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__26(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021B1 RID: 8625 RVA: 0x000ECA06 File Offset: 0x000EAE06
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__27(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication && a.Value < 0.0;
	}

	// Token: 0x060021B2 RID: 8626 RVA: 0x000ECA28 File Offset: 0x000EAE28
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__28(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021B3 RID: 8627 RVA: 0x000ECA30 File Offset: 0x000EAE30
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__29(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021B4 RID: 8628 RVA: 0x000ECA3B File Offset: 0x000EAE3B
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__2A(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021B5 RID: 8629 RVA: 0x000ECA46 File Offset: 0x000EAE46
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__2B(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021B6 RID: 8630 RVA: 0x000ECA51 File Offset: 0x000EAE51
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__2C(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded;
	}

	// Token: 0x060021B7 RID: 8631 RVA: 0x000ECA6B File Offset: 0x000EAE6B
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__2D(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition && a.Value < 0.0;
	}

	// Token: 0x060021B8 RID: 8632 RVA: 0x000ECA8D File Offset: 0x000EAE8D
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__2E(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021B9 RID: 8633 RVA: 0x000ECA95 File Offset: 0x000EAE95
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__2F(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x060021BA RID: 8634 RVA: 0x000ECAA0 File Offset: 0x000EAEA0
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__30(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021BB RID: 8635 RVA: 0x000ECAA8 File Offset: 0x000EAEA8
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__31(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060021BC RID: 8636 RVA: 0x000ECAB3 File Offset: 0x000EAEB3
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__32(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021BD RID: 8637 RVA: 0x000ECABB File Offset: 0x000EAEBB
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__33(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication && a.Value < 0.0;
	}

	// Token: 0x060021BE RID: 8638 RVA: 0x000ECADD File Offset: 0x000EAEDD
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__34(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021BF RID: 8639 RVA: 0x000ECAE5 File Offset: 0x000EAEE5
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__35(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021C0 RID: 8640 RVA: 0x000ECAF0 File Offset: 0x000EAEF0
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__36(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021C1 RID: 8641 RVA: 0x000ECAFB File Offset: 0x000EAEFB
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__37(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021C2 RID: 8642 RVA: 0x000ECB06 File Offset: 0x000EAF06
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__38(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Skill || a.AttributeModifierType == AttributeModifierType.Growth;
	}

	// Token: 0x060021C3 RID: 8643 RVA: 0x000ECB20 File Offset: 0x000EAF20
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__39(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x060021C4 RID: 8644 RVA: 0x000ECB2B File Offset: 0x000EAF2B
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__3A(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021C5 RID: 8645 RVA: 0x000ECB33 File Offset: 0x000EAF33
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__3B(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition && a.Value < 0.0;
	}

	// Token: 0x060021C6 RID: 8646 RVA: 0x000ECB55 File Offset: 0x000EAF55
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__3C(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021C7 RID: 8647 RVA: 0x000ECB5D File Offset: 0x000EAF5D
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__3D(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060021C8 RID: 8648 RVA: 0x000ECB68 File Offset: 0x000EAF68
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__3E(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021C9 RID: 8649 RVA: 0x000ECB70 File Offset: 0x000EAF70
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__3F(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication && a.Value < 0.0;
	}

	// Token: 0x060021CA RID: 8650 RVA: 0x000ECB92 File Offset: 0x000EAF92
	[CompilerGenerated]
	private static double <GetNegativeAttributeValue>m__40(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x060021CB RID: 8651 RVA: 0x000ECB9A File Offset: 0x000EAF9A
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__41(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021CC RID: 8652 RVA: 0x000ECBA5 File Offset: 0x000EAFA5
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__42(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021CD RID: 8653 RVA: 0x000ECBB0 File Offset: 0x000EAFB0
	[CompilerGenerated]
	private static bool <GetNegativeAttributeValue>m__43(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x060021CE RID: 8654 RVA: 0x000ECBBB File Offset: 0x000EAFBB
	[CompilerGenerated]
	private static bool <GetAttributeDisplayValues>m__44(AttributeType a)
	{
		return a != AttributeType.None && a != AttributeType.Allresistances;
	}

	// Token: 0x060021CF RID: 8655 RVA: 0x000ECBCE File Offset: 0x000EAFCE
	[CompilerGenerated]
	private static bool <GetAttributeDisplayValues>m__45(AttributeType a)
	{
		return a != AttributeType.None;
	}

	// Token: 0x060021D0 RID: 8656 RVA: 0x000ECBD8 File Offset: 0x000EAFD8
	[CompilerGenerated]
	private static AttributeDisplayValue <GetDisplayValues>m__46(AttributeModifier m)
	{
		return new AttributeDisplayValue
		{
			ModificationType = m.ModificationType,
			AttributeType = m.AttributeType,
			Value = m.Value
		};
	}

	// Token: 0x060021D1 RID: 8657 RVA: 0x000ECC10 File Offset: 0x000EB010
	[CompilerGenerated]
	private static bool <GetItemEquipedResult>m__47(AttributeType a)
	{
		return a != AttributeType.Allresistances;
	}

	// Token: 0x060021D2 RID: 8658 RVA: 0x000ECC1A File Offset: 0x000EB01A
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetItemEquipedResult>m__48(SetItemResult b)
	{
		return b.MajorEffects;
	}

	// Token: 0x060021D3 RID: 8659 RVA: 0x000ECC22 File Offset: 0x000EB022
	[CompilerGenerated]
	private static <>__AnonType1<ISpecialEffectDataLoad, string> <GetItemEquipedResult>m__49(ISpecialEffectDataLoad ef)
	{
		return new
		{
			Effect = ef,
			AsString = JsonUtility.ToJson(ef)
		};
	}

	// Token: 0x060021D4 RID: 8660 RVA: 0x000ECC30 File Offset: 0x000EB030
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetItemEquipedResult>m__4A(SetItemResult b)
	{
		return b.MajorEffects;
	}

	// Token: 0x060021D5 RID: 8661 RVA: 0x000ECC38 File Offset: 0x000EB038
	[CompilerGenerated]
	private static <>__AnonType1<ISpecialEffectDataLoad, string> <GetItemEquipedResult>m__4B(ISpecialEffectDataLoad ef)
	{
		return new
		{
			Effect = ef,
			AsString = JsonUtility.ToJson(ef)
		};
	}

	// Token: 0x060021D6 RID: 8662 RVA: 0x000ECC46 File Offset: 0x000EB046
	[CompilerGenerated]
	private static ISpecialEffectDataLoad <GetItemEquipedResult>m__4C(<>__AnonType1<ISpecialEffectDataLoad, string> a)
	{
		return a.Effect;
	}

	// Token: 0x060021D7 RID: 8663 RVA: 0x000ECC4E File Offset: 0x000EB04E
	[CompilerGenerated]
	private static ISpecialEffectDataLoad <GetItemEquipedResult>m__4D(<>__AnonType1<ISpecialEffectDataLoad, string> a)
	{
		return a.Effect;
	}

	// Token: 0x060021D8 RID: 8664 RVA: 0x000ECC56 File Offset: 0x000EB056
	[CompilerGenerated]
	private static bool <GetDamageMultiplier>m__4E(BattleEffectBase ef)
	{
		return ef is DamageReductionEffect;
	}

	// Token: 0x060021D9 RID: 8665 RVA: 0x000ECC61 File Offset: 0x000EB061
	[CompilerGenerated]
	private static float <GetDamageMultiplier>m__4F(DamageReductionEffect r)
	{
		return r.ReductionRate;
	}

	// Token: 0x060021DA RID: 8666 RVA: 0x000ECC69 File Offset: 0x000EB069
	[CompilerGenerated]
	private static bool <GetDesperseableEffects>m__50(BattleEffectBase ef)
	{
		return ef.CanBeDispersed;
	}

	// Token: 0x060021DB RID: 8667 RVA: 0x000ECC71 File Offset: 0x000EB071
	[CompilerGenerated]
	private static bool <GetHarmfulEffects>m__51(BattleEffectBase ef)
	{
		return ef.BattleEffectNatureForWearer == BattleEffectNature.Negative;
	}

	// Token: 0x060021DC RID: 8668 RVA: 0x000ECC7C File Offset: 0x000EB07C
	[CompilerGenerated]
	private static bool <GetPositiveEffects>m__52(BattleEffectBase ef)
	{
		return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
	}

	// Token: 0x060021DD RID: 8669 RVA: 0x000ECC87 File Offset: 0x000EB087
	[CompilerGenerated]
	private static double <GetEffectTimeRatio>m__53(NegativeEffectSpeedupData t)
	{
		return t.DecreaseRate;
	}

	// Token: 0x060021DE RID: 8670 RVA: 0x000ECC8F File Offset: 0x000EB08F
	[CompilerGenerated]
	private static bool <IsEffectImmune>m__54(EffectImmuneEffect e)
	{
		return (double)UnityEngine.Random.value <= e.Chance;
	}

	// Token: 0x060021DF RID: 8671 RVA: 0x000ECCA2 File Offset: 0x000EB0A2
	[CompilerGenerated]
	private static bool <GetReflectiveRateInBattle>m__55(ISpecialEffectDataLoad s)
	{
		return s.GetSpecialEffectType() == SpecialEffectType.Thorns;
	}

	// Token: 0x060021E0 RID: 8672 RVA: 0x000ECCB1 File Offset: 0x000EB0B1
	[CompilerGenerated]
	private static double <GetReflectiveRateInBattle>m__56(IBattleUnit s)
	{
		return s.GetAttributeValue_Final(AttributeType.ReflectiveDamage, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x04001D56 RID: 7510
	public static Dictionary<OutputType, AttributeType> ElementAttributeTypes = new Dictionary<OutputType, AttributeType>
	{
		{
			OutputType.Physical,
			AttributeType.DealPhysicalDamageEffectivenessChangeRate
		},
		{
			OutputType.Fire,
			AttributeType.DealFireDamageEffectivenessChangeRate
		},
		{
			OutputType.Ice,
			AttributeType.DealIceDamageEffectivenessChangeRate
		},
		{
			OutputType.Shadow,
			AttributeType.DealShadowDamageEffectivenessChangeRate
		},
		{
			OutputType.Poison,
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		},
		{
			OutputType.Divine,
			AttributeType.DealDivineDamageEffectivenessChangeRate
		},
		{
			OutputType.Lightening,
			AttributeType.DealLightningDamageEffectivenessChangeRate
		}
	};

	// Token: 0x04001D57 RID: 7511
	public static Dictionary<OutputType, AttributeType> ResistanceToOutput = new Dictionary<OutputType, AttributeType>
	{
		{
			OutputType.Physical,
			AttributeType.PhysicalResistance
		},
		{
			OutputType.Fire,
			AttributeType.FireResistanceResistance
		},
		{
			OutputType.Ice,
			AttributeType.IceResistance
		},
		{
			OutputType.Shadow,
			AttributeType.ShadowResistance
		},
		{
			OutputType.Poison,
			AttributeType.PoisonResistance
		},
		{
			OutputType.Divine,
			AttributeType.DivineResistance
		},
		{
			OutputType.Lightening,
			AttributeType.LightningResistance
		}
	};

	// Token: 0x04001D58 RID: 7512
	public static Dictionary<AttributeType, OutputType> OutputToResistances = new Dictionary<AttributeType, OutputType>
	{
		{
			AttributeType.PhysicalResistance,
			OutputType.Physical
		},
		{
			AttributeType.FireResistanceResistance,
			OutputType.Fire
		},
		{
			AttributeType.IceResistance,
			OutputType.Ice
		},
		{
			AttributeType.ShadowResistance,
			OutputType.Shadow
		},
		{
			AttributeType.PoisonResistance,
			OutputType.Poison
		},
		{
			AttributeType.DivineResistance,
			OutputType.Divine
		},
		{
			AttributeType.LightningResistance,
			OutputType.Lightening
		}
	};

	// Token: 0x04001D59 RID: 7513
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x04001D5A RID: 7514
	[CompilerGenerated]
	private static Func<Item, Item> <>f__am$cache0;

	// Token: 0x04001D5B RID: 7515
	[CompilerGenerated]
	private static Func<Item, IEnumerable<AttributeModifier>> <>f__am$cache1;

	// Token: 0x04001D5C RID: 7516
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache2;

	// Token: 0x04001D5D RID: 7517
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<AttributeModifier>> <>f__am$cache3;

	// Token: 0x04001D5E RID: 7518
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<AttributeModifier>> <>f__am$cache4;

	// Token: 0x04001D5F RID: 7519
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache5;

	// Token: 0x04001D60 RID: 7520
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache6;

	// Token: 0x04001D61 RID: 7521
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache7;

	// Token: 0x04001D62 RID: 7522
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache8;

	// Token: 0x04001D63 RID: 7523
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache9;

	// Token: 0x04001D64 RID: 7524
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheA;

	// Token: 0x04001D65 RID: 7525
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheB;

	// Token: 0x04001D66 RID: 7526
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheC;

	// Token: 0x04001D67 RID: 7527
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheD;

	// Token: 0x04001D68 RID: 7528
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cacheE;

	// Token: 0x04001D69 RID: 7529
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheF;

	// Token: 0x04001D6A RID: 7530
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache10;

	// Token: 0x04001D6B RID: 7531
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache11;

	// Token: 0x04001D6C RID: 7532
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache12;

	// Token: 0x04001D6D RID: 7533
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache13;

	// Token: 0x04001D6E RID: 7534
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache14;

	// Token: 0x04001D6F RID: 7535
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache15;

	// Token: 0x04001D70 RID: 7536
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache16;

	// Token: 0x04001D71 RID: 7537
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache17;

	// Token: 0x04001D72 RID: 7538
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache18;

	// Token: 0x04001D73 RID: 7539
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache19;

	// Token: 0x04001D74 RID: 7540
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache1A;

	// Token: 0x04001D75 RID: 7541
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1B;

	// Token: 0x04001D76 RID: 7542
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache1C;

	// Token: 0x04001D77 RID: 7543
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1D;

	// Token: 0x04001D78 RID: 7544
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1E;

	// Token: 0x04001D79 RID: 7545
	[CompilerGenerated]
	private static Func<KeyValuePair<OutputType, AttributeType>, AttributeType> <>f__am$cache1F;

	// Token: 0x04001D7A RID: 7546
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache20;

	// Token: 0x04001D7B RID: 7547
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache21;

	// Token: 0x04001D7C RID: 7548
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache22;

	// Token: 0x04001D7D RID: 7549
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache23;

	// Token: 0x04001D7E RID: 7550
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache24;

	// Token: 0x04001D7F RID: 7551
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache25;

	// Token: 0x04001D80 RID: 7552
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache26;

	// Token: 0x04001D81 RID: 7553
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache27;

	// Token: 0x04001D82 RID: 7554
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache28;

	// Token: 0x04001D83 RID: 7555
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache29;

	// Token: 0x04001D84 RID: 7556
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2A;

	// Token: 0x04001D85 RID: 7557
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2B;

	// Token: 0x04001D86 RID: 7558
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2C;

	// Token: 0x04001D87 RID: 7559
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2D;

	// Token: 0x04001D88 RID: 7560
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache2E;

	// Token: 0x04001D89 RID: 7561
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2F;

	// Token: 0x04001D8A RID: 7562
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache30;

	// Token: 0x04001D8B RID: 7563
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache31;

	// Token: 0x04001D8C RID: 7564
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache32;

	// Token: 0x04001D8D RID: 7565
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache33;

	// Token: 0x04001D8E RID: 7566
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache34;

	// Token: 0x04001D8F RID: 7567
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache35;

	// Token: 0x04001D90 RID: 7568
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache36;

	// Token: 0x04001D91 RID: 7569
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache37;

	// Token: 0x04001D92 RID: 7570
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache38;

	// Token: 0x04001D93 RID: 7571
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache39;

	// Token: 0x04001D94 RID: 7572
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache3A;

	// Token: 0x04001D95 RID: 7573
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache3B;

	// Token: 0x04001D96 RID: 7574
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache3C;

	// Token: 0x04001D97 RID: 7575
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache3D;

	// Token: 0x04001D98 RID: 7576
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache3E;

	// Token: 0x04001D99 RID: 7577
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache3F;

	// Token: 0x04001D9A RID: 7578
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache40;

	// Token: 0x04001D9B RID: 7579
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache41;

	// Token: 0x04001D9C RID: 7580
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache42;

	// Token: 0x04001D9D RID: 7581
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache43;

	// Token: 0x04001D9E RID: 7582
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache44;

	// Token: 0x04001D9F RID: 7583
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache45;

	// Token: 0x04001DA0 RID: 7584
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeDisplayValue> <>f__am$cache46;

	// Token: 0x04001DA1 RID: 7585
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache47;

	// Token: 0x04001DA2 RID: 7586
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache48;

	// Token: 0x04001DA3 RID: 7587
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, <>__AnonType1<ISpecialEffectDataLoad, string>> <>f__am$cache49;

	// Token: 0x04001DA4 RID: 7588
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache4A;

	// Token: 0x04001DA5 RID: 7589
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, <>__AnonType1<ISpecialEffectDataLoad, string>> <>f__am$cache4B;

	// Token: 0x04001DA6 RID: 7590
	[CompilerGenerated]
	private static Func<<>__AnonType1<ISpecialEffectDataLoad, string>, ISpecialEffectDataLoad> <>f__am$cache4C;

	// Token: 0x04001DA7 RID: 7591
	[CompilerGenerated]
	private static Func<<>__AnonType1<ISpecialEffectDataLoad, string>, ISpecialEffectDataLoad> <>f__am$cache4D;

	// Token: 0x04001DA8 RID: 7592
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache4E;

	// Token: 0x04001DA9 RID: 7593
	[CompilerGenerated]
	private static Func<DamageReductionEffect, float> <>f__am$cache4F;

	// Token: 0x04001DAA RID: 7594
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache50;

	// Token: 0x04001DAB RID: 7595
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache51;

	// Token: 0x04001DAC RID: 7596
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache52;

	// Token: 0x04001DAD RID: 7597
	[CompilerGenerated]
	private static Func<NegativeEffectSpeedupData, double> <>f__am$cache53;

	// Token: 0x04001DAE RID: 7598
	[CompilerGenerated]
	private static Func<EffectImmuneEffect, bool> <>f__am$cache54;

	// Token: 0x04001DAF RID: 7599
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache55;

	// Token: 0x04001DB0 RID: 7600
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache56;

	// Token: 0x02000D38 RID: 3384
	[CompilerGenerated]
	private sealed class <GetPetOrNull>c__AnonStoreyA
	{
		// Token: 0x06005696 RID: 22166 RVA: 0x000ECCBF File Offset: 0x000EB0BF
		public <GetPetOrNull>c__AnonStoreyA()
		{
		}

		// Token: 0x06005697 RID: 22167 RVA: 0x000ECCC7 File Offset: 0x000EB0C7
		internal bool <>m__0(PetBattleUnit p)
		{
			return p.OwnerUnit == this.owner;
		}

		// Token: 0x06005698 RID: 22168 RVA: 0x000ECCD7 File Offset: 0x000EB0D7
		internal bool <>m__1(PetBattleUnit p)
		{
			return p.OwnerUnit == this.owner;
		}

		// Token: 0x04004539 RID: 17721
		internal IBattleUnit owner;
	}

	// Token: 0x02000D39 RID: 3385
	[CompilerGenerated]
	private sealed class <DoTurn>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005699 RID: 22169 RVA: 0x000ECCE7 File Offset: 0x000EB0E7
		[DebuggerHidden]
		public <DoTurn>c__Iterator0()
		{
		}

		// Token: 0x0600569A RID: 22170 RVA: 0x000ECCF0 File Offset: 0x000EB0F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (unit.IsPlayer)
				{
					Adventure currentAdventure = unit.CurrentAdventure;
					double? actionCountSoFar = currentAdventure.ActionCountSoFar;
					currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() + 1.0));
				}
				if (unit.IsPlayer)
				{
					goto IL_234;
				}
				if (!unit.CurrentAdventure.PlayerEffects.Any((ISpecialEffectDataLoad s) => s.GetSpecialEffectType() == SpecialEffectType.Thorns))
				{
					goto IL_234;
				}
				if (!unit.CurrentEncounter.PlayerUnits.All((IBattleUnit u) => u.HealthPoints > 0.0))
				{
					goto IL_234;
				}
				IBattleUnit dealer = unit.CurrentEncounter.PlayerUnits.FirstOrDefault<IBattleUnit>();
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Desc, new int?(1)).GetTargets(dealer);
				releaseable = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(dealer, SpecialEffectType.Thorns), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, dealer, OutputType.RealDamage, dealer.GetReflectiveRateInBattle() * t.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Gear) * 6.0)
					}, t, dealer, false, true)
				})).ToList<BattleDamage>(), dealer);
				enumerator = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
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
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				if (unit.IsPlayer && unit.CurrentAdventure.RunePower != null)
				{
					adventurePointCollectionRate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightAdventurePointsCollection);
					enumerator3 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, adventurePointCollectionRate, unit).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
				goto IL_49E;
			case 3u:
				goto IL_346;
			case 4u:
				goto IL_41A;
			case 5u:
				Block_16:
				try
				{
					switch (num)
					{
					case 5u:
						Block_42:
						try
						{
							switch (num)
							{
							}
							if (enumerator6.MoveNext())
							{
								_5 = enumerator6.Current;
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
								if ((disposable5 = (enumerator6 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator5.MoveNext())
					{
						un = enumerator5.Current;
						enumerator6 = un.SelfEventCallback(un, AdventureEventType.AttributeCheckup, null).GetEnumerator();
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
			IL_234:
			enumerator2 = BattleUnitExtensions.DoTurnLogic(unit).GetEnumerator();
			num = 4294967293u;
			goto Block_10;
			Block_13:
			try
			{
				IL_346:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			turnCollectionRate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightTurnCollection);
			enumerator4 = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, turnCollectionRate, unit).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_41A:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_49E:
			IEnumerable<IBattleUnit> playerUnits = unit.CurrentEncounter.PlayerUnits;
			if (BattleUnitExtensions.<>f__mg$cache0 == null)
			{
				BattleUnitExtensions.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			enumerator5 = playerUnits.Where(BattleUnitExtensions.<>f__mg$cache0).ToList<IBattleUnit>().GetEnumerator();
			num = 4294967293u;
			goto Block_16;
		}

		// Token: 0x17001244 RID: 4676
		// (get) Token: 0x0600569B RID: 22171 RVA: 0x000ED32C File Offset: 0x000EB72C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001245 RID: 4677
		// (get) Token: 0x0600569C RID: 22172 RVA: 0x000ED334 File Offset: 0x000EB734
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600569D RID: 22173 RVA: 0x000ED33C File Offset: 0x000EB73C
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
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
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600569E RID: 22174 RVA: 0x000ED4CC File Offset: 0x000EB8CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600569F RID: 22175 RVA: 0x000ED4D3 File Offset: 0x000EB8D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056A0 RID: 22176 RVA: 0x000ED4DC File Offset: 0x000EB8DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<DoTurn>c__Iterator0 <DoTurn>c__Iterator = new BattleUnitExtensions.<DoTurn>c__Iterator0();
			<DoTurn>c__Iterator.unit = unit;
			return <DoTurn>c__Iterator;
		}

		// Token: 0x060056A1 RID: 22177 RVA: 0x000ED510 File Offset: 0x000EB910
		private static bool <>m__0(ISpecialEffectDataLoad s)
		{
			return s.GetSpecialEffectType() == SpecialEffectType.Thorns;
		}

		// Token: 0x060056A2 RID: 22178 RVA: 0x000ED51F File Offset: 0x000EB91F
		private static bool <>m__1(IBattleUnit u)
		{
			return u.HealthPoints > 0.0;
		}

		// Token: 0x0400453A RID: 17722
		internal IBattleUnit unit;

		// Token: 0x0400453B RID: 17723
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x0400453C RID: 17724
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x0400453D RID: 17725
		internal IEnumerator $locvar0;

		// Token: 0x0400453E RID: 17726
		internal object <_>__2;

		// Token: 0x0400453F RID: 17727
		internal IDisposable $locvar1;

		// Token: 0x04004540 RID: 17728
		internal IEnumerator $locvar2;

		// Token: 0x04004541 RID: 17729
		internal object <_>__3;

		// Token: 0x04004542 RID: 17730
		internal IDisposable $locvar3;

		// Token: 0x04004543 RID: 17731
		internal int <adventurePointCollectionRate>__4;

		// Token: 0x04004544 RID: 17732
		internal IEnumerator $locvar4;

		// Token: 0x04004545 RID: 17733
		internal object <_>__5;

		// Token: 0x04004546 RID: 17734
		internal IDisposable $locvar5;

		// Token: 0x04004547 RID: 17735
		internal int <turnCollectionRate>__4;

		// Token: 0x04004548 RID: 17736
		internal IEnumerator $locvar6;

		// Token: 0x04004549 RID: 17737
		internal object <_>__6;

		// Token: 0x0400454A RID: 17738
		internal IDisposable $locvar7;

		// Token: 0x0400454B RID: 17739
		internal List<IBattleUnit>.Enumerator $locvar8;

		// Token: 0x0400454C RID: 17740
		internal IBattleUnit <un>__7;

		// Token: 0x0400454D RID: 17741
		internal IEnumerator $locvar9;

		// Token: 0x0400454E RID: 17742
		internal object <_>__8;

		// Token: 0x0400454F RID: 17743
		internal IDisposable $locvarA;

		// Token: 0x04004550 RID: 17744
		internal object $current;

		// Token: 0x04004551 RID: 17745
		internal bool $disposing;

		// Token: 0x04004552 RID: 17746
		internal int $PC;

		// Token: 0x04004553 RID: 17747
		private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache0;

		// Token: 0x04004554 RID: 17748
		private static Func<IBattleUnit, bool> <>f__am$cache1;

		// Token: 0x04004555 RID: 17749
		private BattleUnitExtensions.<DoTurn>c__Iterator0.<DoTurn>c__AnonStoreyB $locvarB;

		// Token: 0x02000D50 RID: 3408
		private sealed class <DoTurn>c__AnonStoreyB
		{
			// Token: 0x0600571C RID: 22300 RVA: 0x000ED532 File Offset: 0x000EB932
			public <DoTurn>c__AnonStoreyB()
			{
			}

			// Token: 0x0600571D RID: 22301 RVA: 0x000ED53C File Offset: 0x000EB93C
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.dealer, SpecialEffectType.Thorns), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, this.dealer, OutputType.RealDamage, this.dealer.GetReflectiveRateInBattle() * t.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Gear) * 6.0)
					}, t, this.dealer, false, true)
				});
			}

			// Token: 0x04004612 RID: 17938
			internal IBattleUnit dealer;

			// Token: 0x04004613 RID: 17939
			internal BattleUnitExtensions.<DoTurn>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000D3A RID: 3386
	[CompilerGenerated]
	private sealed class <DoTurnLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056A3 RID: 22179 RVA: 0x000ED5B6 File Offset: 0x000EB9B6
		[DebuggerHidden]
		public <DoTurnLogic>c__Iterator1()
		{
		}

		// Token: 0x060056A4 RID: 22180 RVA: 0x000ED5C0 File Offset: 0x000EB9C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitEntersTurn, null)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_13B;
			case 3u:
			case 4u:
			case 5u:
			case 6u:
				goto IL_219;
			case 7u:
				goto IL_5A2;
			case 8u:
				goto IL_642;
			case 9u:
				Block_11:
				try
				{
					switch (num)
					{
					}
					if (enumerator10.MoveNext())
					{
						_9 = enumerator10.Current;
						this.$current = _9;
						if (!this.$disposing)
						{
							this.$PC = 9;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable9 = (enumerator10 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				goto IL_8BA;
			case 10u:
				goto IL_78C;
			case 11u:
				goto IL_836;
			case 12u:
				Block_14:
				try
				{
					switch (num)
					{
					}
					if (enumerator13.MoveNext())
					{
						_12 = enumerator13.Current;
						this.$current = _12;
						if (!this.$disposing)
						{
							this.$PC = 12;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable12 = (enumerator13 as IDisposable)) != null)
						{
							disposable12.Dispose();
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
			if (!unit.CanAct())
			{
				goto IL_8BA;
			}
			if (!unit.CanCast())
			{
				enumerator11 = unit.NormalAttack().GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			}
			enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitSelectsSkill, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_13B:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			avaliableSkills = (from sk in unit.Skills
			where sk.GetSkillLogic().CastingStyle == CastingStyle.DirectCast && sk.GetSkillLogic().SkillCommandType == SkillCommandType.Main
			select sk).ToList<AdventureUnitSkill>();
			if (!avaliableSkills.Any<AdventureUnitSkill>())
			{
				enumerator9 = unit.NormalAttack().GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			enumerator3 = avaliableSkills.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_219:
				switch (num)
				{
				case 3u:
					Block_28:
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
					selectedSkillLogic = selectedSkill.GetSkillLogic();
					enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCastsSkill, new SkillCastBattleEvent
					{
						Skill = selectedSkill,
						SkillLogic = selectedSkillLogic
					})).GetEnumerator();
					num = 4294967293u;
					break;
				case 4u:
					break;
				case 5u:
					goto IL_409;
				case 6u:
					Block_33:
					try
					{
						switch (num)
						{
						}
						if (enumerator7.MoveNext())
						{
							_6 = enumerator7.Current;
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
							if ((disposable6 = (enumerator7 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
					goto IL_551;
				default:
					goto IL_551;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_4 = enumerator5.Current;
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
						if ((disposable4 = (enumerator5 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				if (!unit.CanCast() || !unit.CanAct())
				{
					goto IL_48B;
				}
				enumerator6 = selectedSkillLogic.Cast(selectedSkill).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_409:
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_5 = enumerator6.Current;
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
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				IL_48B:
				enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostCastSkill, new SkillCastBattleEvent
				{
					Skill = selectedSkill,
					SkillLogic = selectedSkillLogic
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_33;
				IL_551:
				if (enumerator3.MoveNext())
				{
					selectedSkill = enumerator3.Current;
					enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitSelectedSkill, selectedSkill)).GetEnumerator();
					num = 4294967293u;
					goto Block_28;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			enumerator8 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesSkillCast, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_5A2:
				switch (num)
				{
				}
				if (enumerator8.MoveNext())
				{
					_7 = enumerator8.Current;
					this.$current = _7;
					if (!this.$disposing)
					{
						this.$PC = 7;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable7 = (enumerator8 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
			}
			goto IL_6C4;
			Block_10:
			try
			{
				IL_642:
				switch (num)
				{
				}
				if (enumerator9.MoveNext())
				{
					_8 = enumerator9.Current;
					this.$current = _8;
					if (!this.$disposing)
					{
						this.$PC = 8;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable8 = (enumerator9 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			IL_6C4:
			enumerator10 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesAction, null)).GetEnumerator();
			num = 4294967293u;
			goto Block_11;
			Block_12:
			try
			{
				IL_78C:
				switch (num)
				{
				}
				if (enumerator11.MoveNext())
				{
					_10 = enumerator11.Current;
					this.$current = _10;
					if (!this.$disposing)
					{
						this.$PC = 10;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
			}
			enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesAction, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_836:
				switch (num)
				{
				}
				if (enumerator12.MoveNext())
				{
					_11 = enumerator12.Current;
					this.$current = _11;
					if (!this.$disposing)
					{
						this.$PC = 11;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable11 = (enumerator12 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
			}
			IL_8BA:
			enumerator13 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitCompletesTurn, null)).GetEnumerator();
			num = 4294967293u;
			goto Block_14;
		}

		// Token: 0x17001246 RID: 4678
		// (get) Token: 0x060056A5 RID: 22181 RVA: 0x000EE078 File Offset: 0x000EC478
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001247 RID: 4679
		// (get) Token: 0x060056A6 RID: 22182 RVA: 0x000EE080 File Offset: 0x000EC480
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056A7 RID: 22183 RVA: 0x000EE088 File Offset: 0x000EC488
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
			case 4u:
			case 5u:
			case 6u:
				try
				{
					switch (num)
					{
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
						}
						finally
						{
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
						break;
					case 5u:
						try
						{
						}
						finally
						{
							if ((disposable5 = (enumerator6 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
						break;
					case 6u:
						try
						{
						}
						finally
						{
							if ((disposable6 = (enumerator7 as IDisposable)) != null)
							{
								disposable6.Dispose();
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
			case 7u:
				try
				{
				}
				finally
				{
					if ((disposable7 = (enumerator8 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			case 8u:
				try
				{
				}
				finally
				{
					if ((disposable8 = (enumerator9 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				break;
			case 9u:
				try
				{
				}
				finally
				{
					if ((disposable9 = (enumerator10 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				break;
			case 10u:
				try
				{
				}
				finally
				{
					if ((disposable10 = (enumerator11 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				break;
			case 11u:
				try
				{
				}
				finally
				{
					if ((disposable11 = (enumerator12 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
				break;
			case 12u:
				try
				{
				}
				finally
				{
					if ((disposable12 = (enumerator13 as IDisposable)) != null)
					{
						disposable12.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060056A8 RID: 22184 RVA: 0x000EE3EC File Offset: 0x000EC7EC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056A9 RID: 22185 RVA: 0x000EE3F3 File Offset: 0x000EC7F3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056AA RID: 22186 RVA: 0x000EE3FC File Offset: 0x000EC7FC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<DoTurnLogic>c__Iterator1 <DoTurnLogic>c__Iterator = new BattleUnitExtensions.<DoTurnLogic>c__Iterator1();
			<DoTurnLogic>c__Iterator.unit = unit;
			return <DoTurnLogic>c__Iterator;
		}

		// Token: 0x060056AB RID: 22187 RVA: 0x000EE430 File Offset: 0x000EC830
		private static bool <>m__0(AdventureUnitSkill sk)
		{
			return sk.GetSkillLogic().CastingStyle == CastingStyle.DirectCast && sk.GetSkillLogic().SkillCommandType == SkillCommandType.Main;
		}

		// Token: 0x04004556 RID: 17750
		internal IBattleUnit unit;

		// Token: 0x04004557 RID: 17751
		internal IEnumerator $locvar0;

		// Token: 0x04004558 RID: 17752
		internal object <_>__1;

		// Token: 0x04004559 RID: 17753
		internal IDisposable $locvar1;

		// Token: 0x0400455A RID: 17754
		internal IEnumerator $locvar2;

		// Token: 0x0400455B RID: 17755
		internal object <_>__2;

		// Token: 0x0400455C RID: 17756
		internal IDisposable $locvar3;

		// Token: 0x0400455D RID: 17757
		internal List<AdventureUnitSkill> <avaliableSkills>__3;

		// Token: 0x0400455E RID: 17758
		internal List<AdventureUnitSkill>.Enumerator $locvar4;

		// Token: 0x0400455F RID: 17759
		internal AdventureUnitSkill <selectedSkill>__4;

		// Token: 0x04004560 RID: 17760
		internal IEnumerator $locvar5;

		// Token: 0x04004561 RID: 17761
		internal object <_>__5;

		// Token: 0x04004562 RID: 17762
		internal IDisposable $locvar6;

		// Token: 0x04004563 RID: 17763
		internal SkillLogicBase <selectedSkillLogic>__6;

		// Token: 0x04004564 RID: 17764
		internal IEnumerator $locvar7;

		// Token: 0x04004565 RID: 17765
		internal object <_>__7;

		// Token: 0x04004566 RID: 17766
		internal IDisposable $locvar8;

		// Token: 0x04004567 RID: 17767
		internal IEnumerator $locvar9;

		// Token: 0x04004568 RID: 17768
		internal object <_>__8;

		// Token: 0x04004569 RID: 17769
		internal IDisposable $locvarA;

		// Token: 0x0400456A RID: 17770
		internal IEnumerator $locvarB;

		// Token: 0x0400456B RID: 17771
		internal object <_>__9;

		// Token: 0x0400456C RID: 17772
		internal IDisposable $locvarC;

		// Token: 0x0400456D RID: 17773
		internal IEnumerator $locvarD;

		// Token: 0x0400456E RID: 17774
		internal object <_>__10;

		// Token: 0x0400456F RID: 17775
		internal IDisposable $locvarE;

		// Token: 0x04004570 RID: 17776
		internal IEnumerator $locvarF;

		// Token: 0x04004571 RID: 17777
		internal object <_>__11;

		// Token: 0x04004572 RID: 17778
		internal IDisposable $locvar10;

		// Token: 0x04004573 RID: 17779
		internal IEnumerator $locvar11;

		// Token: 0x04004574 RID: 17780
		internal object <_>__12;

		// Token: 0x04004575 RID: 17781
		internal IDisposable $locvar12;

		// Token: 0x04004576 RID: 17782
		internal IEnumerator $locvar13;

		// Token: 0x04004577 RID: 17783
		internal object <_>__13;

		// Token: 0x04004578 RID: 17784
		internal IDisposable $locvar14;

		// Token: 0x04004579 RID: 17785
		internal IEnumerator $locvar15;

		// Token: 0x0400457A RID: 17786
		internal object <_>__14;

		// Token: 0x0400457B RID: 17787
		internal IDisposable $locvar16;

		// Token: 0x0400457C RID: 17788
		internal IEnumerator $locvar17;

		// Token: 0x0400457D RID: 17789
		internal object <_>__15;

		// Token: 0x0400457E RID: 17790
		internal IDisposable $locvar18;

		// Token: 0x0400457F RID: 17791
		internal object $current;

		// Token: 0x04004580 RID: 17792
		internal bool $disposing;

		// Token: 0x04004581 RID: 17793
		internal int $PC;

		// Token: 0x04004582 RID: 17794
		private static Func<AdventureUnitSkill, bool> <>f__am$cache0;
	}

	// Token: 0x02000D3B RID: 3387
	[CompilerGenerated]
	private sealed class <Escape>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056AC RID: 22188 RVA: 0x000EE454 File Offset: 0x000EC854
		[DebuggerHidden]
		public <Escape>c__Iterator2()
		{
		}

		// Token: 0x060056AD RID: 22189 RVA: 0x000EE45C File Offset: 0x000EC85C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				unit.Status = BattleUnitStatus.Escaped;
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitEscaped, unit)).GetEnumerator();
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
			UnityEngine.Debug.Log(unit.GetUnitType() + " escaped");
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001248 RID: 4680
		// (get) Token: 0x060056AE RID: 22190 RVA: 0x000EE580 File Offset: 0x000EC980
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001249 RID: 4681
		// (get) Token: 0x060056AF RID: 22191 RVA: 0x000EE588 File Offset: 0x000EC988
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056B0 RID: 22192 RVA: 0x000EE590 File Offset: 0x000EC990
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

		// Token: 0x060056B1 RID: 22193 RVA: 0x000EE600 File Offset: 0x000ECA00
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056B2 RID: 22194 RVA: 0x000EE607 File Offset: 0x000ECA07
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056B3 RID: 22195 RVA: 0x000EE610 File Offset: 0x000ECA10
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<Escape>c__Iterator2 <Escape>c__Iterator = new BattleUnitExtensions.<Escape>c__Iterator2();
			<Escape>c__Iterator.unit = unit;
			return <Escape>c__Iterator;
		}

		// Token: 0x04004583 RID: 17795
		internal IBattleUnit unit;

		// Token: 0x04004584 RID: 17796
		internal IEnumerator $locvar0;

		// Token: 0x04004585 RID: 17797
		internal object <_>__1;

		// Token: 0x04004586 RID: 17798
		internal IDisposable $locvar1;

		// Token: 0x04004587 RID: 17799
		internal object $current;

		// Token: 0x04004588 RID: 17800
		internal bool $disposing;

		// Token: 0x04004589 RID: 17801
		internal int $PC;
	}

	// Token: 0x02000D3C RID: 3388
	[CompilerGenerated]
	private sealed class <NormalAttack>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056B4 RID: 22196 RVA: 0x000EE644 File Offset: 0x000ECA44
		[DebuggerHidden]
		public <NormalAttack>c__Iterator3()
		{
		}

		// Token: 0x060056B5 RID: 22197 RVA: 0x000EE64C File Offset: 0x000ECA4C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = unit.GetUnitClassStyle().GetStyleConfig().NormalAttack(unit).GetEnumerator();
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

		// Token: 0x1700124A RID: 4682
		// (get) Token: 0x060056B6 RID: 22198 RVA: 0x000EE744 File Offset: 0x000ECB44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700124B RID: 4683
		// (get) Token: 0x060056B7 RID: 22199 RVA: 0x000EE74C File Offset: 0x000ECB4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056B8 RID: 22200 RVA: 0x000EE754 File Offset: 0x000ECB54
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

		// Token: 0x060056B9 RID: 22201 RVA: 0x000EE7C4 File Offset: 0x000ECBC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056BA RID: 22202 RVA: 0x000EE7CB File Offset: 0x000ECBCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056BB RID: 22203 RVA: 0x000EE7D4 File Offset: 0x000ECBD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<NormalAttack>c__Iterator3 <NormalAttack>c__Iterator = new BattleUnitExtensions.<NormalAttack>c__Iterator3();
			<NormalAttack>c__Iterator.unit = unit;
			return <NormalAttack>c__Iterator;
		}

		// Token: 0x0400458A RID: 17802
		internal IBattleUnit unit;

		// Token: 0x0400458B RID: 17803
		internal IEnumerator $locvar0;

		// Token: 0x0400458C RID: 17804
		internal object <_>__1;

		// Token: 0x0400458D RID: 17805
		internal IDisposable $locvar1;

		// Token: 0x0400458E RID: 17806
		internal object $current;

		// Token: 0x0400458F RID: 17807
		internal bool $disposing;

		// Token: 0x04004590 RID: 17808
		internal int $PC;
	}

	// Token: 0x02000D3D RID: 3389
	[CompilerGenerated]
	private sealed class <ReplaceItem>c__AnonStoreyC
	{
		// Token: 0x060056BC RID: 22204 RVA: 0x000EE808 File Offset: 0x000ECC08
		public <ReplaceItem>c__AnonStoreyC()
		{
		}

		// Token: 0x060056BD RID: 22205 RVA: 0x000EE810 File Offset: 0x000ECC10
		internal bool <>m__0(Item i)
		{
			return i.SlotType == this.replacement.SlotType;
		}

		// Token: 0x04004591 RID: 17809
		internal Item replacement;
	}

	// Token: 0x02000D3E RID: 3390
	[CompilerGenerated]
	private sealed class <GetAllAttributes_Complete>c__AnonStoreyD
	{
		// Token: 0x060056BE RID: 22206 RVA: 0x000EE825 File Offset: 0x000ECC25
		public <GetAllAttributes_Complete>c__AnonStoreyD()
		{
		}

		// Token: 0x060056BF RID: 22207 RVA: 0x000EE82D File Offset: 0x000ECC2D
		internal IEnumerable<AttributeModifier> <>m__0(Item i)
		{
			return i.GetSpecialEffects().OfType<IAttributeModifierSpecialEffect>().SelectMany((IAttributeModifierSpecialEffect s) => s.GetModifiers(this.profile));
		}

		// Token: 0x060056C0 RID: 22208 RVA: 0x000EE84B File Offset: 0x000ECC4B
		internal IEnumerable<AttributeModifier> <>m__1(IAttributeModifierSpecialEffect s)
		{
			return s.GetModifiers(this.profile);
		}

		// Token: 0x060056C1 RID: 22209 RVA: 0x000EE859 File Offset: 0x000ECC59
		internal IEnumerable<ISpecialEffectDataLoad> <>m__2(IAdventurerTalent c)
		{
			return c.GetSpecialEffects(this.profile);
		}

		// Token: 0x060056C2 RID: 22210 RVA: 0x000EE867 File Offset: 0x000ECC67
		internal IEnumerable<AttributeModifier> <>m__3(IAttributeModifierSpecialEffect s)
		{
			return s.GetModifiers(this.profile);
		}

		// Token: 0x060056C3 RID: 22211 RVA: 0x000EE875 File Offset: 0x000ECC75
		internal IEnumerable<AttributeModifier> <>m__4(IAttributeModifierSpecialEffect s)
		{
			return s.GetModifiers(this.profile);
		}

		// Token: 0x04004592 RID: 17810
		internal AdventurerProfile profile;
	}

	// Token: 0x02000D3F RID: 3391
	[CompilerGenerated]
	private sealed class <GetAttributeValue>c__AnonStoreyE
	{
		// Token: 0x060056C4 RID: 22212 RVA: 0x000EE883 File Offset: 0x000ECC83
		public <GetAttributeValue>c__AnonStoreyE()
		{
		}

		// Token: 0x060056C5 RID: 22213 RVA: 0x000EE88C File Offset: 0x000ECC8C
		internal bool <>m__0(AttributeModifier a)
		{
			return (!this.type.IsResistanceAttribute()) ? (a.AttributeType == this.type) : (a.AttributeType == this.type || a.AttributeType == AttributeType.Allresistances);
		}

		// Token: 0x04004593 RID: 17811
		internal AttributeType type;
	}

	// Token: 0x02000D40 RID: 3392
	[CompilerGenerated]
	private sealed class <IsDamageEffectiveness>c__AnonStoreyF
	{
		// Token: 0x060056C6 RID: 22214 RVA: 0x000EE8DA File Offset: 0x000ECCDA
		public <IsDamageEffectiveness>c__AnonStoreyF()
		{
		}

		// Token: 0x060056C7 RID: 22215 RVA: 0x000EE8E2 File Offset: 0x000ECCE2
		internal bool <>m__0(AttributeType a)
		{
			return a == this.type;
		}

		// Token: 0x04004594 RID: 17812
		internal AttributeType type;
	}

	// Token: 0x02000D41 RID: 3393
	[CompilerGenerated]
	private sealed class <GetNegativeAttributeValue>c__AnonStorey10
	{
		// Token: 0x060056C8 RID: 22216 RVA: 0x000EE8ED File Offset: 0x000ECCED
		public <GetNegativeAttributeValue>c__AnonStorey10()
		{
		}

		// Token: 0x060056C9 RID: 22217 RVA: 0x000EE8F5 File Offset: 0x000ECCF5
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.type;
		}

		// Token: 0x04004595 RID: 17813
		internal AttributeType type;
	}

	// Token: 0x02000D42 RID: 3394
	[CompilerGenerated]
	private sealed class <CalculateFinalAttributeValue>c__AnonStorey11
	{
		// Token: 0x060056CA RID: 22218 RVA: 0x000EE905 File Offset: 0x000ECD05
		public <CalculateFinalAttributeValue>c__AnonStorey11()
		{
		}

		// Token: 0x060056CB RID: 22219 RVA: 0x000EE910 File Offset: 0x000ECD10
		internal bool <>m__0(AttributeModifier a)
		{
			return (!this.type.IsResistanceAttribute()) ? (a.AttributeType == this.type) : (a.AttributeType == this.type || a.AttributeType == AttributeType.Allresistances);
		}

		// Token: 0x04004596 RID: 17814
		internal AttributeType type;
	}

	// Token: 0x02000D44 RID: 3396
	[CompilerGenerated]
	private sealed class <GetItemEquipedResult>c__AnonStorey12
	{
		// Token: 0x060056D2 RID: 22226 RVA: 0x000EE95E File Offset: 0x000ECD5E
		public <GetItemEquipedResult>c__AnonStorey12()
		{
		}

		// Token: 0x060056D3 RID: 22227 RVA: 0x000EE968 File Offset: 0x000ECD68
		internal bool <>m__0(<>__AnonType1<ISpecialEffectDataLoad, string> o)
		{
			return this.updatedBenefits.All(u => u.AsString != o.AsString);
		}

		// Token: 0x060056D4 RID: 22228 RVA: 0x000EE9A0 File Offset: 0x000ECDA0
		internal bool <>m__1(<>__AnonType1<ISpecialEffectDataLoad, string> u)
		{
			return this.originalBenefits.All(o => o.AsString != u.AsString);
		}

		// Token: 0x04004599 RID: 17817
		internal List<<>__AnonType1<ISpecialEffectDataLoad, string>> updatedBenefits;

		// Token: 0x0400459A RID: 17818
		internal List<<>__AnonType1<ISpecialEffectDataLoad, string>> originalBenefits;

		// Token: 0x02000D51 RID: 3409
		private sealed class <GetItemEquipedResult>c__AnonStorey13
		{
			// Token: 0x0600571E RID: 22302 RVA: 0x000EE9D8 File Offset: 0x000ECDD8
			public <GetItemEquipedResult>c__AnonStorey13()
			{
			}

			// Token: 0x0600571F RID: 22303 RVA: 0x000EE9E0 File Offset: 0x000ECDE0
			internal bool <>m__0(<>__AnonType1<ISpecialEffectDataLoad, string> u)
			{
				return u.AsString != this.o.AsString;
			}

			// Token: 0x04004614 RID: 17940
			internal <>__AnonType1<ISpecialEffectDataLoad, string> o;

			// Token: 0x04004615 RID: 17941
			internal BattleUnitExtensions.<GetItemEquipedResult>c__AnonStorey12 <>f__ref$18;
		}

		// Token: 0x02000D52 RID: 3410
		private sealed class <GetItemEquipedResult>c__AnonStorey14
		{
			// Token: 0x06005720 RID: 22304 RVA: 0x000EE9F8 File Offset: 0x000ECDF8
			public <GetItemEquipedResult>c__AnonStorey14()
			{
			}

			// Token: 0x06005721 RID: 22305 RVA: 0x000EEA00 File Offset: 0x000ECE00
			internal bool <>m__0(<>__AnonType1<ISpecialEffectDataLoad, string> o)
			{
				return o.AsString != this.u.AsString;
			}

			// Token: 0x04004616 RID: 17942
			internal <>__AnonType1<ISpecialEffectDataLoad, string> u;

			// Token: 0x04004617 RID: 17943
			internal BattleUnitExtensions.<GetItemEquipedResult>c__AnonStorey12 <>f__ref$18;
		}
	}

	// Token: 0x02000D45 RID: 3397
	[CompilerGenerated]
	private sealed class <GetOutputAttributeType>c__AnonStorey15
	{
		// Token: 0x060056D5 RID: 22229 RVA: 0x000EEA18 File Offset: 0x000ECE18
		public <GetOutputAttributeType>c__AnonStorey15()
		{
		}

		// Token: 0x060056D6 RID: 22230 RVA: 0x000EEA20 File Offset: 0x000ECE20
		internal bool <>m__0(ClassCategory c)
		{
			return c == this.category;
		}

		// Token: 0x0400459B RID: 17819
		internal ClassCategory category;
	}

	// Token: 0x02000D46 RID: 3398
	[CompilerGenerated]
	private sealed class <GetOutputAttributeType>c__AnonStorey16
	{
		// Token: 0x060056D7 RID: 22231 RVA: 0x000EEA2B File Offset: 0x000ECE2B
		public <GetOutputAttributeType>c__AnonStorey16()
		{
		}

		// Token: 0x060056D8 RID: 22232 RVA: 0x000EEA33 File Offset: 0x000ECE33
		internal bool <>m__0(ClassCategory c)
		{
			return c == this.category;
		}

		// Token: 0x0400459C RID: 17820
		internal ClassCategory category;
	}

	// Token: 0x02000D47 RID: 3399
	[CompilerGenerated]
	private sealed class <GetValue>c__AnonStorey17
	{
		// Token: 0x060056D9 RID: 22233 RVA: 0x000EEA3E File Offset: 0x000ECE3E
		public <GetValue>c__AnonStorey17()
		{
		}

		// Token: 0x060056DA RID: 22234 RVA: 0x000EEA46 File Offset: 0x000ECE46
		internal bool <>m__0(AttributeDisplayValue v)
		{
			return v.AttributeType == this.type;
		}

		// Token: 0x0400459D RID: 17821
		internal AttributeType type;
	}

	// Token: 0x02000D48 RID: 3400
	[CompilerGenerated]
	private sealed class <AddValue>c__AnonStorey18
	{
		// Token: 0x060056DB RID: 22235 RVA: 0x000EEA56 File Offset: 0x000ECE56
		public <AddValue>c__AnonStorey18()
		{
		}

		// Token: 0x060056DC RID: 22236 RVA: 0x000EEA5E File Offset: 0x000ECE5E
		internal bool <>m__0(AttributeModifier m)
		{
			return m.AttributeType == this.type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty;
		}

		// Token: 0x060056DD RID: 22237 RVA: 0x000EEA90 File Offset: 0x000ECE90
		internal bool <>m__1(AttributeModifier m)
		{
			return m.AttributeType == this.type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty;
		}

		// Token: 0x060056DE RID: 22238 RVA: 0x000EEAC2 File Offset: 0x000ECEC2
		internal bool <>m__2(AttributeModifier m)
		{
			return m.AttributeType == this.type && m.ModificationType == ModificationType.Addition && m.Key == string.Empty;
		}

		// Token: 0x0400459E RID: 17822
		internal AttributeType type;
	}

	// Token: 0x02000D49 RID: 3401
	[CompilerGenerated]
	private sealed class <GetDamageMultiplier>c__AnonStorey19
	{
		// Token: 0x060056DF RID: 22239 RVA: 0x000EEAF4 File Offset: 0x000ECEF4
		public <GetDamageMultiplier>c__AnonStorey19()
		{
		}

		// Token: 0x060056E0 RID: 22240 RVA: 0x000EEAFC File Offset: 0x000ECEFC
		internal bool <>m__0(DamageReductionEffect r)
		{
			return r.ReductionTypes.Any((OutputType t) => t == this.type);
		}

		// Token: 0x060056E1 RID: 22241 RVA: 0x000EEB15 File Offset: 0x000ECF15
		internal bool <>m__1(OutputType t)
		{
			return t == this.type;
		}

		// Token: 0x0400459F RID: 17823
		internal OutputType type;
	}

	// Token: 0x02000D4A RID: 3402
	[CompilerGenerated]
	private sealed class <ReceivesHeal>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056E2 RID: 22242 RVA: 0x000EEB20 File Offset: 0x000ECF20
		[DebuggerHidden]
		public <ReceivesHeal>c__Iterator4()
		{
		}

		// Token: 0x060056E3 RID: 22243 RVA: 0x000EEB28 File Offset: 0x000ECF28
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesHeal, heal)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_35D;
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
				if (heal.Healer.GetUnitType() != UnitClass.GoldenShaman || totalDirectHeal <= 0.0)
				{
					goto IL_606;
				}
				exlusive = heal.Healer.SpecialEffects.OfType<ReflectiveHealData>().FirstOrDefault<ReflectiveHealData>();
				if (exlusive != null)
				{
					enumerator5 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.ReflectiveDamage,
							ModificationType = ModificationType.Addition,
							Value = exlusive.Rate,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "goldenshamanreflective", new int?(7), new float?(2f), null, false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
				goto IL_606;
			case 4u:
				goto IL_584;
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
			maxLife = unit.GetMaxLife(AttributeRetrievalLevel.Skill);
			enumerator2 = heal.Heals.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					HealComponent healComponent = enumerator2.Current;
					if (!healComponent.IsNeutralized && healComponent.GetFinalHealSoFar() > 0.0)
					{
						double num2 = maxLife - unit.HealthPoints;
						if (num2 < 0.0)
						{
							num2 = 0.0;
						}
						double num3 = (healComponent.CalculatedHealValue > num2) ? num2 : healComponent.CalculatedHealValue;
						if (num3 < 0.0)
						{
							num3 = 0.0;
						}
						healComponent.ExceededHealValue = new double?((healComponent.CalculatedHealValue > num2) ? (healComponent.CalculatedHealValue - num2) : 0.0);
						if (healComponent.FinalHealValue != null)
						{
							if (healComponent.FinalHealValue > num3)
							{
								healComponent.FinalHealValue = new double?(num3);
							}
						}
						else
						{
							healComponent.FinalHealValue = new double?(num3);
						}
						unit.HealthPoints += healComponent.FinalHealValue.Value;
						if (unit.HealthPoints < 0.0)
						{
							unit.HealthPoints = 0.0;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			totalDirectHeal = (from h in heal.Heals
			where h.IsDirectHeal
			select h).Sum((HealComponent h) => h.CalculatedHealValue);
			if (totalDirectHeal <= 0.0)
			{
				goto IL_3DF;
			}
			absorbRate = unit.GetAttributeValue_Final(AttributeType.HealingAbsorbRate, AttributeRetrievalLevel.Skill);
			if (absorbRate <= 0.0)
			{
				goto IL_3DF;
			}
			enumerator3 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(unit, heal.HealSource, absorbRate * totalDirectHeal).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_35D:
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
			IL_3DF:
			enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitPostReceivesHeal, heal)).GetEnumerator();
			num = 4294967293u;
			goto Block_9;
			Block_13:
			try
			{
				IL_584:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_606:
			if (unit.HealthPoints >= maxLife)
			{
				unit.HealthPoints = maxLife;
			}
			if (unit.HealthPoints < 0.0)
			{
				unit.HealthPoints = 0.0;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700124E RID: 4686
		// (get) Token: 0x060056E4 RID: 22244 RVA: 0x000EF218 File Offset: 0x000ED618
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700124F RID: 4687
		// (get) Token: 0x060056E5 RID: 22245 RVA: 0x000EF220 File Offset: 0x000ED620
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056E6 RID: 22246 RVA: 0x000EF228 File Offset: 0x000ED628
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
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060056E7 RID: 22247 RVA: 0x000EF354 File Offset: 0x000ED754
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056E8 RID: 22248 RVA: 0x000EF35B File Offset: 0x000ED75B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056E9 RID: 22249 RVA: 0x000EF364 File Offset: 0x000ED764
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<ReceivesHeal>c__Iterator4 <ReceivesHeal>c__Iterator = new BattleUnitExtensions.<ReceivesHeal>c__Iterator4();
			<ReceivesHeal>c__Iterator.unit = unit;
			<ReceivesHeal>c__Iterator.heal = heal;
			return <ReceivesHeal>c__Iterator;
		}

		// Token: 0x060056EA RID: 22250 RVA: 0x000EF3A4 File Offset: 0x000ED7A4
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal;
		}

		// Token: 0x060056EB RID: 22251 RVA: 0x000EF3AC File Offset: 0x000ED7AC
		private static double <>m__1(HealComponent h)
		{
			return h.CalculatedHealValue;
		}

		// Token: 0x040045A0 RID: 17824
		internal IBattleUnit unit;

		// Token: 0x040045A1 RID: 17825
		internal BattleHeal heal;

		// Token: 0x040045A2 RID: 17826
		internal IEnumerator $locvar0;

		// Token: 0x040045A3 RID: 17827
		internal object <_>__1;

		// Token: 0x040045A4 RID: 17828
		internal IDisposable $locvar1;

		// Token: 0x040045A5 RID: 17829
		internal double <maxLife>__0;

		// Token: 0x040045A6 RID: 17830
		internal List<HealComponent>.Enumerator $locvar2;

		// Token: 0x040045A7 RID: 17831
		internal double <totalDirectHeal>__0;

		// Token: 0x040045A8 RID: 17832
		internal double <absorbRate>__2;

		// Token: 0x040045A9 RID: 17833
		internal IEnumerator $locvar3;

		// Token: 0x040045AA RID: 17834
		internal object <_>__3;

		// Token: 0x040045AB RID: 17835
		internal IDisposable $locvar4;

		// Token: 0x040045AC RID: 17836
		internal IEnumerator $locvar5;

		// Token: 0x040045AD RID: 17837
		internal object <_>__4;

		// Token: 0x040045AE RID: 17838
		internal IDisposable $locvar6;

		// Token: 0x040045AF RID: 17839
		internal ReflectiveHealData <exlusive>__5;

		// Token: 0x040045B0 RID: 17840
		internal IEnumerator $locvar7;

		// Token: 0x040045B1 RID: 17841
		internal object <_>__6;

		// Token: 0x040045B2 RID: 17842
		internal IDisposable $locvar8;

		// Token: 0x040045B3 RID: 17843
		internal object $current;

		// Token: 0x040045B4 RID: 17844
		internal bool $disposing;

		// Token: 0x040045B5 RID: 17845
		internal int $PC;

		// Token: 0x040045B6 RID: 17846
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x040045B7 RID: 17847
		private static Func<HealComponent, double> <>f__am$cache1;
	}

	// Token: 0x02000D4B RID: 3403
	[CompilerGenerated]
	private sealed class <EntersEncounter>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056EC RID: 22252 RVA: 0x000EF3B4 File Offset: 0x000ED7B4
		[DebuggerHidden]
		public <EntersEncounter>c__Iterator5()
		{
		}

		// Token: 0x060056ED RID: 22253 RVA: 0x000EF3BC File Offset: 0x000ED7BC
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				unit.BattleEffects = (from ef in unit.BattleEffects
				where ef.IsThroughEffect
				select ef).ToList<BattleEffectBase>();
				Adventure currentAdventure = encounter.CurrentAdventure;
				if (currentAdventure != null && currentAdventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = currentAdventure.BattleEffectsDictionary[unit.GetId()];
					foreach (KeyValuePair<AdventureEventType, Dictionary<string, BattleEffectBase>> keyValuePair in dictionary)
					{
						List<KeyValuePair<string, BattleEffectBase>> list = (from ef in keyValuePair.Value
						where !ef.Value.IsThroughEffect
						select ef).ToList<KeyValuePair<string, BattleEffectBase>>();
						foreach (KeyValuePair<string, BattleEffectBase> keyValuePair2 in list)
						{
							keyValuePair.Value.Remove(keyValuePair2.Key);
						}
					}
				}
				if (unit is EnemyBattleUnit)
				{
					EnemyBattleUnit enemyBattleUnit = unit as EnemyBattleUnit;
					enemyBattleUnit.HealthPoints = enemyBattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				}
			}
			return false;
		}

		// Token: 0x17001250 RID: 4688
		// (get) Token: 0x060056EE RID: 22254 RVA: 0x000EF558 File Offset: 0x000ED958
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001251 RID: 4689
		// (get) Token: 0x060056EF RID: 22255 RVA: 0x000EF560 File Offset: 0x000ED960
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056F0 RID: 22256 RVA: 0x000EF568 File Offset: 0x000ED968
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060056F1 RID: 22257 RVA: 0x000EF56A File Offset: 0x000ED96A
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056F2 RID: 22258 RVA: 0x000EF571 File Offset: 0x000ED971
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056F3 RID: 22259 RVA: 0x000EF57C File Offset: 0x000ED97C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<EntersEncounter>c__Iterator5 <EntersEncounter>c__Iterator = new BattleUnitExtensions.<EntersEncounter>c__Iterator5();
			<EntersEncounter>c__Iterator.unit = unit;
			<EntersEncounter>c__Iterator.encounter = encounter;
			return <EntersEncounter>c__Iterator;
		}

		// Token: 0x060056F4 RID: 22260 RVA: 0x000EF5BC File Offset: 0x000ED9BC
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.IsThroughEffect;
		}

		// Token: 0x060056F5 RID: 22261 RVA: 0x000EF5C4 File Offset: 0x000ED9C4
		private static bool <>m__1(KeyValuePair<string, BattleEffectBase> ef)
		{
			return !ef.Value.IsThroughEffect;
		}

		// Token: 0x040045B8 RID: 17848
		internal IBattleUnit unit;

		// Token: 0x040045B9 RID: 17849
		internal IEncounter encounter;

		// Token: 0x040045BA RID: 17850
		internal object $current;

		// Token: 0x040045BB RID: 17851
		internal bool $disposing;

		// Token: 0x040045BC RID: 17852
		internal int $PC;

		// Token: 0x040045BD RID: 17853
		private static Func<BattleEffectBase, bool> <>f__am$cache0;

		// Token: 0x040045BE RID: 17854
		private static Func<KeyValuePair<string, BattleEffectBase>, bool> <>f__am$cache1;
	}

	// Token: 0x02000D4C RID: 3404
	[CompilerGenerated]
	private sealed class <LooseSkillEffect>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056F6 RID: 22262 RVA: 0x000EF5D5 File Offset: 0x000ED9D5
		[DebuggerHidden]
		public <LooseSkillEffect>c__Iterator6()
		{
		}

		// Token: 0x060056F7 RID: 22263 RVA: 0x000EF5E0 File Offset: 0x000ED9E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (wearoffType != EffectWearsOffType.Dispersed || !unit.IsPlayer || effect.BattleEffectNatureForWearer != BattleEffectNature.Negative || unit.CurrentAdventure.RunePower == null)
				{
					goto IL_143;
				}
				rate = unit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.GhostBreathsDisperseNegativeEffectCollection);
				enumerator = unit.CurrentAdventure.RunePower.AddPower(RunePowerType.GhostBreaths, rate, unit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_10:
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
				if (unit.IsAliveInBattle())
				{
					enumerator4 = effect.PosWearsOffProcess_ActiveUnit(unit, wearoffType).GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
				enumerator5 = effect.PosWearsOffProcess_InactiveUnit(unit, wearoffType).GetEnumerator();
				num = 4294967293u;
				goto Block_13;
			case 3u:
				goto IL_2F9;
			case 4u:
				goto IL_3A5;
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
			IL_143:
			unit.BattleEffects.Remove(effect);
			adventure = unit.CurrentAdventure;
			if (adventure != null && adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
			{
				Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = adventure.BattleEffectsDictionary[unit.GetId()];
				foreach (AdventureEventType key in effect.CorrespondingEvents())
				{
					if (dictionary.ContainsKey(key))
					{
						dictionary[key].Remove(effect.Id);
					}
				}
			}
			enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitLoosesEffect, effect)).GetEnumerator();
			num = 4294967293u;
			goto Block_10;
			Block_12:
			try
			{
				IL_2F9:
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
			goto IL_427;
			Block_13:
			try
			{
				IL_3A5:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_427:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001252 RID: 4690
		// (get) Token: 0x060056F8 RID: 22264 RVA: 0x000EFA60 File Offset: 0x000EDE60
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001253 RID: 4691
		// (get) Token: 0x060056F9 RID: 22265 RVA: 0x000EFA68 File Offset: 0x000EDE68
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060056FA RID: 22266 RVA: 0x000EFA70 File Offset: 0x000EDE70
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
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060056FB RID: 22267 RVA: 0x000EFB9C File Offset: 0x000EDF9C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060056FC RID: 22268 RVA: 0x000EFBA3 File Offset: 0x000EDFA3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060056FD RID: 22269 RVA: 0x000EFBAC File Offset: 0x000EDFAC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<LooseSkillEffect>c__Iterator6 <LooseSkillEffect>c__Iterator = new BattleUnitExtensions.<LooseSkillEffect>c__Iterator6();
			<LooseSkillEffect>c__Iterator.wearoffType = wearoffType;
			<LooseSkillEffect>c__Iterator.unit = unit;
			<LooseSkillEffect>c__Iterator.effect = effect;
			return <LooseSkillEffect>c__Iterator;
		}

		// Token: 0x040045BF RID: 17855
		internal EffectWearsOffType wearoffType;

		// Token: 0x040045C0 RID: 17856
		internal IBattleUnit unit;

		// Token: 0x040045C1 RID: 17857
		internal BattleEffectBase effect;

		// Token: 0x040045C2 RID: 17858
		internal int <rate>__1;

		// Token: 0x040045C3 RID: 17859
		internal IEnumerator $locvar0;

		// Token: 0x040045C4 RID: 17860
		internal object <_>__2;

		// Token: 0x040045C5 RID: 17861
		internal IDisposable $locvar1;

		// Token: 0x040045C6 RID: 17862
		internal Adventure <adventure>__0;

		// Token: 0x040045C7 RID: 17863
		internal IEnumerator $locvar3;

		// Token: 0x040045C8 RID: 17864
		internal object <_>__3;

		// Token: 0x040045C9 RID: 17865
		internal IDisposable $locvar4;

		// Token: 0x040045CA RID: 17866
		internal IEnumerator $locvar5;

		// Token: 0x040045CB RID: 17867
		internal object <_>__4;

		// Token: 0x040045CC RID: 17868
		internal IDisposable $locvar6;

		// Token: 0x040045CD RID: 17869
		internal IEnumerator $locvar7;

		// Token: 0x040045CE RID: 17870
		internal object <_>__5;

		// Token: 0x040045CF RID: 17871
		internal IDisposable $locvar8;

		// Token: 0x040045D0 RID: 17872
		internal object $current;

		// Token: 0x040045D1 RID: 17873
		internal bool $disposing;

		// Token: 0x040045D2 RID: 17874
		internal int $PC;
	}

	// Token: 0x02000D4D RID: 3405
	[CompilerGenerated]
	private sealed class <ApplySkillEffect>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060056FE RID: 22270 RVA: 0x000EFBF8 File Offset: 0x000EDFF8
		[DebuggerHidden]
		public <ApplySkillEffect>c__Iterator7()
		{
		}

		// Token: 0x060056FF RID: 22271 RVA: 0x000EFC00 File Offset: 0x000EE000
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectCanbeImmuned = effect.CanBeImmuned();
				tobeResisted = (effectCanbeImmuned && !effect.SourceUnit.EffectApplySucceeded(unit));
				if (effectCanbeImmuned)
				{
					double num2 = unit.SpecialEffects.OfType<LightningShieldData>().Sum((LightningShieldData r) => r.NegativeResistance);
					if ((double)UnityEngine.Random.value <= num2)
					{
						tobeResisted = true;
					}
					if (unit.IsEffectImmune())
					{
						tobeResisted = true;
					}
				}
				if (effectCanbeImmuned && effect is TauntEffect)
				{
					if (unit.SpecialEffects.Any((ISpecialEffectDataLoad ef) => ef is EmeraldOfClearHeartData))
					{
						tobeResisted = true;
					}
				}
				if (unit.GetUnitClassStyle() == UnitClassStyle.Statue && effect.NumberOfLastingTurns != null)
				{
					tobeResisted = true;
				}
				if (effect.NumberOfLastingTurns != null && !ignoreTimeReduction)
				{
					double num3 = effect.SourceUnit.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill) + 1.0;
					if (num3 < 0.0)
					{
						num3 = 0.0;
					}
					int value = (int)Math.Round((double)effect.NumberOfLastingTurns.Value * num3, 0, MidpointRounding.ToEven);
					effect.NumberOfLastingTurns = new int?(value);
				}
				if (effect.MaxNumberOfLastingSeconds != null && !ignoreTimeReduction)
				{
					double num4 = effect.SourceUnit.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill) + 1.0;
					if (num4 < 0.0)
					{
						num4 = 0.0;
					}
					double value2 = (double)effect.MaxNumberOfLastingSeconds.Value * num4;
					effect.MaxNumberOfLastingSeconds = new float?(Convert.ToSingle(value2));
				}
				if (effect.BattleEffectNatureForWearer == BattleEffectNature.Positive && effect.SourceUnit.SpecialEffects.OfType<PositiveEffectBoostData>().Any<PositiveEffectBoostData>())
				{
					double num5 = effect.SourceUnit.SpecialEffects.OfType<PositiveEffectBoostData>().Sum((PositiveEffectBoostData s) => s.Chance);
					if ((double)UnityEngine.Random.value <= num5)
					{
						effect.CanBeDispersed = false;
					}
				}
				if (effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && effect.SourceUnit.SpecialEffects.OfType<NegativeEffectBoostData>().Any<NegativeEffectBoostData>())
				{
					double num6 = effect.SourceUnit.SpecialEffects.OfType<NegativeEffectBoostData>().Sum((NegativeEffectBoostData s) => s.Chance);
					if ((double)UnityEngine.Random.value <= num6)
					{
						effect.CanBeDispersed = false;
					}
				}
				negativeDefenceEffect = unit.SpecialEffects.OfType<NegativeEffectSpeedupData>().FirstOrDefault<NegativeEffectSpeedupData>();
				if (negativeDefenceEffect != null && effect.EffectSource.SourceUnit != unit && effect.BattleEffectNatureForWearer == BattleEffectNature.Negative && !ignoreTimeReduction)
				{
					if (effect.MaxNumberOfLastingSeconds != null)
					{
						effect.MaxNumberOfLastingSeconds = new float?(Convert.ToSingle((double)effect.MaxNumberOfLastingSeconds.Value * (1.0 - negativeDefenceEffect.DecreaseRate)));
					}
					else if (effect.NumberOfLastingTurns != null)
					{
						int num7 = (int)Math.Round(Convert.ToDouble(effect.NumberOfLastingTurns.Value) * (1.0 - negativeDefenceEffect.DecreaseRate), 0);
						if (num7 == 0)
						{
							effect.NumberOfLastingTurns = new int?(1);
						}
						else
						{
							effect.NumberOfLastingTurns = new int?(num7);
						}
					}
				}
				if (effect is LockTimeEffect && effectCanbeImmuned)
				{
					double num8 = unit.SpecialEffects.OfType<TimeLockResistanceData>().Sum((TimeLockResistanceData r) => r.Chance);
					if ((double)UnityEngine.Random.value <= num8)
					{
						tobeResisted = true;
					}
				}
				if (tobeResisted)
				{
					enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleEffectResisted, effect)).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (effect.SourceUnit.IsPlayer && effect.SourceUnit.CurrentAdventure.RunePower != null && effect is TauntEffect)
					{
						tauntCollectionRate = effect.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.VitalEnergyTauntCollection);
						enumerator2 = effect.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.VitalEnergy, tauntCollectionRate, effect.SourceUnit).GetEnumerator();
						num = 4294967293u;
						goto Block_43;
					}
					goto IL_7E8;
				}
				break;
			case 1u:
				break;
			case 2u:
				goto IL_764;
			case 3u:
				Block_47:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				if (!existing.CanBeDispersed)
				{
					<ApplySkillEffect>c__AnonStorey1A.effect.CanBeDispersed = false;
					goto IL_93C;
				}
				goto IL_93C;
			case 4u:
				Block_53:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_4 = enumerator6.Current;
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
						if ((disposable4 = (enumerator6 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				if (<ApplySkillEffect>c__AnonStorey1A.effect.MaxStackableInstances != null && <ApplySkillEffect>c__AnonStorey1A.effect.MaxStackableInstances.Value == unit.BattleEffects.Count((BattleEffectBase ef) => ef.EffectSourceIdentityCode == <ApplySkillEffect>c__AnonStorey1A.effect.EffectSourceIdentityCode))
				{
					enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.BattleEffectCapStackReached, <ApplySkillEffect>c__AnonStorey1A.effect)).GetEnumerator();
					num = 4294967293u;
					goto Block_56;
				}
				goto IL_D1F;
			case 5u:
				goto IL_C9B;
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
			goto IL_D1F;
			Block_43:
			try
			{
				IL_764:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_7E8:
			if (<ApplySkillEffect>c__AnonStorey1A.effect.MaxStackableInstances != null && <ApplySkillEffect>c__AnonStorey1A.effect.MaxStackableInstances.Value == unit.BattleEffects.Count((BattleEffectBase ef) => ef.GetType() == <ApplySkillEffect>c__AnonStorey1A.effect.GetType() && ef.EffectSourceIdentityCode == <ApplySkillEffect>c__AnonStorey1A.effect.EffectSourceIdentityCode))
			{
				existing = unit.BattleEffects.FirstOrDefault((BattleEffectBase ef) => ef.EffectSourceIdentityCode == <ApplySkillEffect>c__AnonStorey1A.effect.EffectSourceIdentityCode);
				if (existing != null)
				{
					enumerator3 = unit.LooseSkillEffect(existing, EffectWearsOffType.Duplicate).GetEnumerator();
					num = 4294967293u;
					goto Block_47;
				}
			}
			IL_93C:
			unit.BattleEffects.Add(<ApplySkillEffect>c__AnonStorey1A.effect);
			adventure = unit.CurrentAdventure;
			if (adventure != null)
			{
				if (adventure.BattleEffectsDictionary.ContainsKey(unit.GetId()))
				{
					Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary = adventure.BattleEffectsDictionary[unit.GetId()];
					foreach (AdventureEventType key in <ApplySkillEffect>c__AnonStorey1A.effect.CorrespondingEvents())
					{
						if (dictionary.ContainsKey(key))
						{
							dictionary[key].Add(<ApplySkillEffect>c__AnonStorey1A.effect.Id, <ApplySkillEffect>c__AnonStorey1A.effect);
						}
						else
						{
							dictionary.Add(key, new Dictionary<string, BattleEffectBase>
							{
								{
									<ApplySkillEffect>c__AnonStorey1A.effect.Id,
									<ApplySkillEffect>c__AnonStorey1A.effect
								}
							});
						}
					}
				}
				else
				{
					adventure.BattleEffectsDictionary.Add(unit.GetId(), new Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>());
					Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>> dictionary2 = adventure.BattleEffectsDictionary[unit.GetId()];
					foreach (AdventureEventType key2 in <ApplySkillEffect>c__AnonStorey1A.effect.CorrespondingEvents())
					{
						if (dictionary2.ContainsKey(key2))
						{
							dictionary2[key2].Add(<ApplySkillEffect>c__AnonStorey1A.effect.Id, <ApplySkillEffect>c__AnonStorey1A.effect);
						}
						else
						{
							dictionary2.Add(key2, new Dictionary<string, BattleEffectBase>
							{
								{
									<ApplySkillEffect>c__AnonStorey1A.effect.Id,
									<ApplySkillEffect>c__AnonStorey1A.effect
								}
							});
						}
					}
				}
			}
			enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitReceivesEffect, <ApplySkillEffect>c__AnonStorey1A.effect)).GetEnumerator();
			num = 4294967293u;
			goto Block_53;
			Block_56:
			try
			{
				IL_C9B:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_5 = enumerator7.Current;
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
					if ((disposable5 = (enumerator7 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			IL_D1F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001254 RID: 4692
		// (get) Token: 0x06005700 RID: 22272 RVA: 0x000F0990 File Offset: 0x000EED90
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001255 RID: 4693
		// (get) Token: 0x06005701 RID: 22273 RVA: 0x000F0998 File Offset: 0x000EED98
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005702 RID: 22274 RVA: 0x000F09A0 File Offset: 0x000EEDA0
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator7 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005703 RID: 22275 RVA: 0x000F0B0C File Offset: 0x000EEF0C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005704 RID: 22276 RVA: 0x000F0B13 File Offset: 0x000EEF13
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005705 RID: 22277 RVA: 0x000F0B1C File Offset: 0x000EEF1C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<ApplySkillEffect>c__Iterator7 <ApplySkillEffect>c__Iterator = new BattleUnitExtensions.<ApplySkillEffect>c__Iterator7();
			<ApplySkillEffect>c__Iterator.effect = effect;
			<ApplySkillEffect>c__Iterator.unit = unit;
			<ApplySkillEffect>c__Iterator.ignoreTimeReduction = ignoreTimeReduction;
			return <ApplySkillEffect>c__Iterator;
		}

		// Token: 0x06005706 RID: 22278 RVA: 0x000F0B68 File Offset: 0x000EEF68
		private static double <>m__0(LightningShieldData r)
		{
			return r.NegativeResistance;
		}

		// Token: 0x06005707 RID: 22279 RVA: 0x000F0B70 File Offset: 0x000EEF70
		private static bool <>m__1(ISpecialEffectDataLoad ef)
		{
			return ef is EmeraldOfClearHeartData;
		}

		// Token: 0x06005708 RID: 22280 RVA: 0x000F0B7B File Offset: 0x000EEF7B
		private static double <>m__2(PositiveEffectBoostData s)
		{
			return s.Chance;
		}

		// Token: 0x06005709 RID: 22281 RVA: 0x000F0B83 File Offset: 0x000EEF83
		private static double <>m__3(NegativeEffectBoostData s)
		{
			return s.Chance;
		}

		// Token: 0x0600570A RID: 22282 RVA: 0x000F0B8B File Offset: 0x000EEF8B
		private static double <>m__4(TimeLockResistanceData r)
		{
			return r.Chance;
		}

		// Token: 0x040045D3 RID: 17875
		internal BattleEffectBase effect;

		// Token: 0x040045D4 RID: 17876
		internal bool <effectCanbeImmuned>__0;

		// Token: 0x040045D5 RID: 17877
		internal IBattleUnit unit;

		// Token: 0x040045D6 RID: 17878
		internal bool <tobeResisted>__0;

		// Token: 0x040045D7 RID: 17879
		internal bool ignoreTimeReduction;

		// Token: 0x040045D8 RID: 17880
		internal NegativeEffectSpeedupData <negativeDefenceEffect>__0;

		// Token: 0x040045D9 RID: 17881
		internal IEnumerator $locvar0;

		// Token: 0x040045DA RID: 17882
		internal object <_>__1;

		// Token: 0x040045DB RID: 17883
		internal IDisposable $locvar1;

		// Token: 0x040045DC RID: 17884
		internal int <tauntCollectionRate>__2;

		// Token: 0x040045DD RID: 17885
		internal IEnumerator $locvar2;

		// Token: 0x040045DE RID: 17886
		internal object <_>__3;

		// Token: 0x040045DF RID: 17887
		internal IDisposable $locvar3;

		// Token: 0x040045E0 RID: 17888
		internal BattleEffectBase <existing>__4;

		// Token: 0x040045E1 RID: 17889
		internal IEnumerator $locvar4;

		// Token: 0x040045E2 RID: 17890
		internal object <_>__5;

		// Token: 0x040045E3 RID: 17891
		internal IDisposable $locvar5;

		// Token: 0x040045E4 RID: 17892
		internal Adventure <adventure>__6;

		// Token: 0x040045E5 RID: 17893
		internal IEnumerator $locvar8;

		// Token: 0x040045E6 RID: 17894
		internal object <_>__7;

		// Token: 0x040045E7 RID: 17895
		internal IDisposable $locvar9;

		// Token: 0x040045E8 RID: 17896
		internal IEnumerator $locvarA;

		// Token: 0x040045E9 RID: 17897
		internal object <_>__8;

		// Token: 0x040045EA RID: 17898
		internal IDisposable $locvarB;

		// Token: 0x040045EB RID: 17899
		internal object $current;

		// Token: 0x040045EC RID: 17900
		internal bool $disposing;

		// Token: 0x040045ED RID: 17901
		internal int $PC;

		// Token: 0x040045EE RID: 17902
		private BattleUnitExtensions.<ApplySkillEffect>c__Iterator7.<ApplySkillEffect>c__AnonStorey1A $locvarC;

		// Token: 0x040045EF RID: 17903
		private static Func<LightningShieldData, double> <>f__am$cache0;

		// Token: 0x040045F0 RID: 17904
		private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache1;

		// Token: 0x040045F1 RID: 17905
		private static Func<PositiveEffectBoostData, double> <>f__am$cache2;

		// Token: 0x040045F2 RID: 17906
		private static Func<NegativeEffectBoostData, double> <>f__am$cache3;

		// Token: 0x040045F3 RID: 17907
		private static Func<TimeLockResistanceData, double> <>f__am$cache4;

		// Token: 0x02000D53 RID: 3411
		private sealed class <ApplySkillEffect>c__AnonStorey1A
		{
			// Token: 0x06005722 RID: 22306 RVA: 0x000F0B93 File Offset: 0x000EEF93
			public <ApplySkillEffect>c__AnonStorey1A()
			{
			}

			// Token: 0x06005723 RID: 22307 RVA: 0x000F0B9B File Offset: 0x000EEF9B
			internal bool <>m__0(BattleEffectBase ef)
			{
				return ef.GetType() == this.effect.GetType() && ef.EffectSourceIdentityCode == this.effect.EffectSourceIdentityCode;
			}

			// Token: 0x06005724 RID: 22308 RVA: 0x000F0BCC File Offset: 0x000EEFCC
			internal bool <>m__1(BattleEffectBase ef)
			{
				return ef.EffectSourceIdentityCode == this.effect.EffectSourceIdentityCode;
			}

			// Token: 0x06005725 RID: 22309 RVA: 0x000F0BE4 File Offset: 0x000EEFE4
			internal bool <>m__2(BattleEffectBase ef)
			{
				return ef.EffectSourceIdentityCode == this.effect.EffectSourceIdentityCode;
			}

			// Token: 0x04004618 RID: 17944
			internal BattleEffectBase effect;

			// Token: 0x04004619 RID: 17945
			internal BattleUnitExtensions.<ApplySkillEffect>c__Iterator7 <>f__ref$7;
		}
	}

	// Token: 0x02000D4E RID: 3406
	[CompilerGenerated]
	private sealed class <DisperseEffect>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600570B RID: 22283 RVA: 0x000F0BFC File Offset: 0x000EEFFC
		[DebuggerHidden]
		public <DisperseEffect>c__Iterator8()
		{
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x000F0C04 File Offset: 0x000EF004
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!effect.CanBeDispersed)
				{
					goto IL_19F;
				}
				enumerator = wearingUnit.LooseSkillEffect(effect, EffectWearsOffType.Dispersed).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_11D;
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
			enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(wearingUnit, AdventureEventType.BattleEffectDispersed, new EffectDispersedEvent
			{
				BattleEffect = effect,
				DispersedBy = dispersedByUnit
			})).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_11D:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_19F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001256 RID: 4694
		// (get) Token: 0x0600570D RID: 22285 RVA: 0x000F0DD8 File Offset: 0x000EF1D8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001257 RID: 4695
		// (get) Token: 0x0600570E RID: 22286 RVA: 0x000F0DE0 File Offset: 0x000EF1E0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600570F RID: 22287 RVA: 0x000F0DE8 File Offset: 0x000EF1E8
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005710 RID: 22288 RVA: 0x000F0E98 File Offset: 0x000EF298
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005711 RID: 22289 RVA: 0x000F0E9F File Offset: 0x000EF29F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005712 RID: 22290 RVA: 0x000F0EA8 File Offset: 0x000EF2A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<DisperseEffect>c__Iterator8 <DisperseEffect>c__Iterator = new BattleUnitExtensions.<DisperseEffect>c__Iterator8();
			<DisperseEffect>c__Iterator.effect = effect;
			<DisperseEffect>c__Iterator.wearingUnit = wearingUnit;
			<DisperseEffect>c__Iterator.dispersedByUnit = dispersedByUnit;
			return <DisperseEffect>c__Iterator;
		}

		// Token: 0x040045F4 RID: 17908
		internal BattleEffectBase effect;

		// Token: 0x040045F5 RID: 17909
		internal IBattleUnit wearingUnit;

		// Token: 0x040045F6 RID: 17910
		internal IEnumerator $locvar0;

		// Token: 0x040045F7 RID: 17911
		internal object <_>__1;

		// Token: 0x040045F8 RID: 17912
		internal IDisposable $locvar1;

		// Token: 0x040045F9 RID: 17913
		internal IBattleUnit dispersedByUnit;

		// Token: 0x040045FA RID: 17914
		internal IEnumerator $locvar2;

		// Token: 0x040045FB RID: 17915
		internal object <_>__2;

		// Token: 0x040045FC RID: 17916
		internal IDisposable $locvar3;

		// Token: 0x040045FD RID: 17917
		internal object $current;

		// Token: 0x040045FE RID: 17918
		internal bool $disposing;

		// Token: 0x040045FF RID: 17919
		internal int $PC;
	}

	// Token: 0x02000D4F RID: 3407
	[CompilerGenerated]
	private sealed class <ChangeTurnCounterProgress>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005713 RID: 22291 RVA: 0x000F0EF4 File Offset: 0x000EF2F4
		[DebuggerHidden]
		public <ChangeTurnCounterProgress>c__Iterator9()
		{
		}

		// Token: 0x06005714 RID: 22292 RVA: 0x000F0EFC File Offset: 0x000EF2FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!unit.IsTurnRelevant())
				{
					goto IL_3A9;
				}
				battleEncounter = (unit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null || !battleEncounter.TurnCounter.ContainsKey(unit))
				{
					goto IL_3A9;
				}
				currentProgress = battleEncounter.TurnCounter[unit];
				proposedChange = PlayerProfile.TurnSpeedGauge * change.ChangePercentage;
				if (proposedChange < 0.0 && unit.SpecialEffects.OfType<TurnResistanceData>().Any<TurnResistanceData>())
				{
					double num2 = unit.SpecialEffects.OfType<TurnResistanceData>().Sum((TurnResistanceData r) => r.Rate);
					double num3 = 1.0 - num2;
					if (num3 < 0.0)
					{
						num3 = 0.0;
					}
					proposedChange *= num3;
				}
				finalChange = proposedChange;
				resultedProgress = currentProgress + proposedChange;
				if (resultedProgress < 0.0)
				{
					finalChange = 0.0 - currentProgress;
				}
				else if (resultedProgress > PlayerProfile.TurnSpeedGauge)
				{
					finalChange = PlayerProfile.TurnSpeedGauge - currentProgress;
				}
				finalChangePayload = new UnitTurnProgressUpdateResultEvent
				{
					CausingSkill = change.CausingSource,
					ActualChangePercentage = finalChange,
					BattleUnit = unit,
					CausedByUnit = change.Dealer,
					ProposedChangePercentage = proposedChange
				};
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.PriorUnitTurnProgressChange, finalChangePayload)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_325;
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
			if (battleEncounter.TurnCounter.ContainsKey(unit))
			{
				Dictionary<IBattleUnit, double> turnCounter;
				IBattleUnit key;
				(turnCounter = battleEncounter.TurnCounter)[key = unit] = turnCounter[key] + finalChange;
			}
			enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitTurnProgressAlterred, finalChangePayload)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_325:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_3A9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001258 RID: 4696
		// (get) Token: 0x06005715 RID: 22293 RVA: 0x000F12D8 File Offset: 0x000EF6D8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001259 RID: 4697
		// (get) Token: 0x06005716 RID: 22294 RVA: 0x000F12E0 File Offset: 0x000EF6E0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005717 RID: 22295 RVA: 0x000F12E8 File Offset: 0x000EF6E8
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005718 RID: 22296 RVA: 0x000F1398 File Offset: 0x000EF798
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x000F139F File Offset: 0x000EF79F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600571A RID: 22298 RVA: 0x000F13A8 File Offset: 0x000EF7A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleUnitExtensions.<ChangeTurnCounterProgress>c__Iterator9 <ChangeTurnCounterProgress>c__Iterator = new BattleUnitExtensions.<ChangeTurnCounterProgress>c__Iterator9();
			<ChangeTurnCounterProgress>c__Iterator.unit = unit;
			<ChangeTurnCounterProgress>c__Iterator.change = change;
			return <ChangeTurnCounterProgress>c__Iterator;
		}

		// Token: 0x0600571B RID: 22299 RVA: 0x000F13E8 File Offset: 0x000EF7E8
		private static double <>m__0(TurnResistanceData r)
		{
			return r.Rate;
		}

		// Token: 0x04004600 RID: 17920
		internal IBattleUnit unit;

		// Token: 0x04004601 RID: 17921
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04004602 RID: 17922
		internal double <currentProgress>__2;

		// Token: 0x04004603 RID: 17923
		internal UnitTurnProgressUpdateEvent change;

		// Token: 0x04004604 RID: 17924
		internal double <proposedChange>__2;

		// Token: 0x04004605 RID: 17925
		internal double <finalChange>__2;

		// Token: 0x04004606 RID: 17926
		internal double <resultedProgress>__2;

		// Token: 0x04004607 RID: 17927
		internal UnitTurnProgressUpdateResultEvent <finalChangePayload>__2;

		// Token: 0x04004608 RID: 17928
		internal IEnumerator $locvar0;

		// Token: 0x04004609 RID: 17929
		internal object <_>__3;

		// Token: 0x0400460A RID: 17930
		internal IDisposable $locvar1;

		// Token: 0x0400460B RID: 17931
		internal IEnumerator $locvar2;

		// Token: 0x0400460C RID: 17932
		internal object <_>__4;

		// Token: 0x0400460D RID: 17933
		internal IDisposable $locvar3;

		// Token: 0x0400460E RID: 17934
		internal object $current;

		// Token: 0x0400460F RID: 17935
		internal bool $disposing;

		// Token: 0x04004610 RID: 17936
		internal int $PC;

		// Token: 0x04004611 RID: 17937
		private static Func<TurnResistanceData, double> <>f__am$cache0;
	}
}
