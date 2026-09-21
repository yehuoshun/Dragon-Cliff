using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020006B0 RID: 1712
public abstract class TeamSetBase
{
	// Token: 0x06002D6E RID: 11630 RVA: 0x00127AB1 File Offset: 0x00125EB1
	protected TeamSetBase()
	{
	}

	// Token: 0x170005C1 RID: 1473
	// (get) Token: 0x06002D6F RID: 11631
	public abstract TeamSetType SetType { get; }

	// Token: 0x170005C2 RID: 1474
	// (get) Token: 0x06002D70 RID: 11632
	public abstract List<ResourceType> TeamSetPieces { get; }

	// Token: 0x06002D71 RID: 11633
	public abstract AttributeType GeneratePrimaryAttributeType(ResourceType pieceType);

	// Token: 0x06002D72 RID: 11634 RVA: 0x00127ABC File Offset: 0x00125EBC
	public List<AttributeType> GetPotentialRollAttributeTypes(Item item)
	{
		ItemSuitableClassType itemSuitableClassType = this.GetItemSuitableClassType(item.Type);
		AttributeType item2 = (item.OutputTypeForTeamSet == null) ? AttributeType.Strength : item.OutputTypeForTeamSet.Value;
		if (itemSuitableClassType == ItemSuitableClassType.Tank)
		{
			return new List<AttributeType>
			{
				AttributeType.Vitality,
				AttributeType.ReflectiveDamage,
				AttributeType.Agility,
				AttributeType.Allresistances,
				AttributeType.Resilience,
				AttributeType.EffectResistanceRating,
				AttributeType.ReceivedHealEffectivenessChangeRate
			};
		}
		if (itemSuitableClassType == ItemSuitableClassType.Balanced)
		{
			return new List<AttributeType>
			{
				AttributeType.ReflectiveDamage,
				AttributeType.Agility,
				AttributeType.Allresistances,
				AttributeType.Resilience,
				item2,
				AttributeType.CritDamage,
				AttributeType.SkillRageEfficiencyRate
			};
		}
		if (itemSuitableClassType == ItemSuitableClassType.Support)
		{
			return new List<AttributeType>
			{
				AttributeType.Agility,
				AttributeType.Allresistances,
				AttributeType.Resilience,
				item2,
				AttributeType.EffectResistanceRating,
				AttributeType.EffectHitRating,
				AttributeType.SkillRageEfficiencyRate
			};
		}
		if (itemSuitableClassType == ItemSuitableClassType.Assassin)
		{
			return new List<AttributeType>
			{
				AttributeType.Agility,
				item2,
				AttributeType.CritDamage,
				AttributeType.EffectResistanceRating,
				AttributeType.Vitality,
				AttributeType.ReflectiveDamage,
				AttributeType.ReceivedHealEffectivenessChangeRate
			};
		}
		if (itemSuitableClassType == ItemSuitableClassType.Healer)
		{
			return new List<AttributeType>
			{
				AttributeType.ReflectiveDamage,
				AttributeType.Agility,
				AttributeType.Allresistances,
				AttributeType.Resilience,
				AttributeType.Intelligience,
				AttributeType.CritDamage,
				AttributeType.EffectHitRating
			};
		}
		return new List<AttributeType>();
	}

	// Token: 0x06002D73 RID: 11635 RVA: 0x00127C88 File Offset: 0x00126088
	public List<SpecialEffectType> GetPotentialEffectTypes(ItemSuitableClassType suitable)
	{
		List<SpecialEffectType> list = new List<SpecialEffectType>
		{
			SpecialEffectType.TurnResistance,
			SpecialEffectType.NegativeEffectSpeedup
		};
		if (suitable == ItemSuitableClassType.Healer)
		{
			list.Add(SpecialEffectType.HealResistanceBoost);
			list.Add(SpecialEffectType.HealOutputBoost);
		}
		if (suitable == ItemSuitableClassType.Balanced)
		{
			list.Add(SpecialEffectType.DamageAttributeReductionByValue);
			list.Add(SpecialEffectType.AdventureEnergyRecollection);
		}
		if (suitable == ItemSuitableClassType.Assassin)
		{
			list.Add(SpecialEffectType.TauntResistanceBoost);
			list.Add(SpecialEffectType.OffensiveDamageIgnoreByAttacker);
		}
		if (suitable == ItemSuitableClassType.Tank)
		{
			list.Add(SpecialEffectType.TauntBoost);
			list.Add(SpecialEffectType.DamageReductionByHealth);
		}
		if (suitable == ItemSuitableClassType.Support)
		{
			list.Add(SpecialEffectType.AdventureEnergyBoostByValue);
		}
		return list;
	}

	// Token: 0x06002D74 RID: 11636
	public abstract ItemSuitableClassType GetItemSuitableClassType(ResourceType type);

	// Token: 0x06002D75 RID: 11637
	public abstract List<ISpecialEffectDataLoad> GetTeamBonus();

	// Token: 0x06002D76 RID: 11638 RVA: 0x00127D34 File Offset: 0x00126134
	public static List<ISpecialEffectDataLoad> GetAdventureTeamBonus(List<AdventurerProfile> members)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		foreach (TeamSetBase teamSetBase in (from s in TeamSetBase.TeamSetBases
		select s.Value).ToList<TeamSetBase>())
		{
			if (teamSetBase.TeamSetPieces.All((ResourceType t) => members.Any((AdventurerProfile a) => a.GetEquipments().Any((Item i) => i.Type == t))))
			{
				list.AddRange(teamSetBase.GetTeamBonus());
			}
		}
		return list;
	}

	// Token: 0x06002D77 RID: 11639 RVA: 0x00127DEC File Offset: 0x001261EC
	protected ISpecialEffectDataLoad GenerateEffect(SpecialEffectType type, int numberOfUpgrades, int seedNumber)
	{
		UnityEngine.Random.InitState(seedNumber);
		if (type == SpecialEffectType.TurnResistance)
		{
			double num = 0.0;
			for (int i = 0; i < numberOfUpgrades; i++)
			{
				num += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.08;
			}
			return new TurnResistanceData
			{
				IsStar = false,
				Rate = num
			};
		}
		if (type == SpecialEffectType.NegativeEffectSpeedup)
		{
			double num2 = 0.0;
			for (int j = 0; j < numberOfUpgrades; j++)
			{
				num2 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.06;
			}
			return new NegativeEffectSpeedupData
			{
				DecreaseRate = num2,
				IsStarEf = new bool?(false)
			};
		}
		if (type == SpecialEffectType.HealResistanceBoost)
		{
			double num3 = 0.0;
			for (int k = 0; k < numberOfUpgrades; k++)
			{
				num3 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
			}
			return new HealResistanceData
			{
				BoostRate = num3
			};
		}
		if (type == SpecialEffectType.DamageAttributeReductionByValue)
		{
			double num4 = 0.0;
			for (int l = 0; l < numberOfUpgrades; l++)
			{
				num4 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
			}
			return new DamageAttributeReductionByValueData
			{
				AttributeType = AttributeType.CritRate,
				ReductionRate = num4
			};
		}
		if (type == SpecialEffectType.HealOutputBoost)
		{
			double num5 = 0.0;
			for (int m = 0; m < numberOfUpgrades; m++)
			{
				num5 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
			}
			return new HealOutputBoostData
			{
				BoostRate = num5
			};
		}
		if (type == SpecialEffectType.TauntResistanceBoost)
		{
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			for (int n = 0; n < numberOfUpgrades; n++)
			{
				num6 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
				num7 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
				num8 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
			}
			return new TauntResistanceBoostData
			{
				AgilityBoostRate = num7,
				PushRate = num8,
				OutputBoostRate = num6
			};
		}
		if (type == SpecialEffectType.AdventureEnergyBoostByValue)
		{
			int num9 = 0;
			for (int num10 = 0; num10 < numberOfUpgrades; num10++)
			{
				num9 += UnityEngine.Random.Range(8, 11);
			}
			return new AdventureEnergyBoostByValueData
			{
				Value = (double)num9
			};
		}
		if (type == SpecialEffectType.OffensiveDamageIgnoreByAttacker)
		{
			double num11 = 0.0;
			double num12 = 0.0;
			for (int num13 = 0; num13 < numberOfUpgrades; num13++)
			{
				num11 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.5;
				num12 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.7;
			}
			return new OffensiveDamageIgnoreByAttackerData
			{
				ResilienceRate = num12,
				ResistanceRate = num11
			};
		}
		if (type == SpecialEffectType.TauntBoost)
		{
			double num14 = 0.0;
			double num15 = 0.0;
			for (int num16 = 0; num16 < numberOfUpgrades; num16++)
			{
				num14 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.1;
				num15 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.05;
			}
			return new TauntBoostData
			{
				DamageReflectionBoost = num14,
				OutputCapacityBoost = num15
			};
		}
		if (type == SpecialEffectType.DamageReductionByHealth)
		{
			double num17 = 0.0;
			for (int num18 = 0; num18 < numberOfUpgrades; num18++)
			{
				num17 += (double)UnityEngine.Random.Range(0.8f, 1f) * 0.02;
			}
			return new DamageReductionByValueData
			{
				Percentage = num17
			};
		}
		if (type == SpecialEffectType.AdventureEnergyRecollection)
		{
			int num19 = 0;
			for (int num20 = 0; num20 < numberOfUpgrades; num20++)
			{
				num19 += UnityEngine.Random.Range(1, 3);
			}
			return new AdventureEnergyRecollectionData
			{
				NumberOfRecollection = num19
			};
		}
		throw new NotImplementedException();
	}

	// Token: 0x06002D78 RID: 11640 RVA: 0x001282B0 File Offset: 0x001266B0
	protected AttributeModifier GenerateExtraAttribute(AttributeType type, int numberOfupgrades, int seedNumber)
	{
		UnityEngine.Random.InitState(seedNumber);
		double num = 0.01;
		ModificationType modificationType = ModificationType.Multiplication;
		switch (type)
		{
		case AttributeType.LifeOnHit:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.TauntOnHit:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.StunOnHit:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.ReflectiveDamage:
			num = 0.05;
			modificationType = ModificationType.Addition;
			break;
		default:
			switch (type)
			{
			case AttributeType.None:
				break;
			case AttributeType.Strength:
				num = 0.01;
				break;
			case AttributeType.Intelligience:
				num = 0.01;
				break;
			case AttributeType.Agility:
				num = 0.01;
				break;
			case AttributeType.CritRate:
				num = 0.02;
				modificationType = ModificationType.Addition;
				break;
			case AttributeType.Vitality:
				num = 0.01;
				break;
			case AttributeType.CritDamage:
				num = 0.1;
				modificationType = ModificationType.Addition;
				break;
			case AttributeType.PhysicalResistance:
			case AttributeType.FireResistanceResistance:
			case AttributeType.ShadowResistance:
			case AttributeType.IceResistance:
			case AttributeType.PoisonResistance:
			case AttributeType.DivineResistance:
			case AttributeType.LightningResistance:
			case AttributeType.Allresistances:
				num = 0.02;
				break;
			default:
				throw new ArgumentOutOfRangeException("type", type, null);
			}
			break;
		case AttributeType.BattleStartHeal:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.TurnStartHeal:
			num = 0.01;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.Mining:
			num = 0.1;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.Logging:
			num = 0.1;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.Hunting:
			num = 0.1;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.ReceivedHealEffectivenessChangeRate:
		case AttributeType.DealFireDamageEffectivenessChangeRate:
		case AttributeType.DealPhysicalDamageEffectivenessChangeRate:
		case AttributeType.DealIceDamageEffectivenessChangeRate:
		case AttributeType.DealShadowDamageEffectivenessChangeRate:
		case AttributeType.DealPoisonDamageEffectivenessChangeRate:
		case AttributeType.DealDivineDamageEffectivenessChangeRate:
		case AttributeType.DealLightningDamageEffectivenessChangeRate:
			num = 0.01;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.Resilience:
			num = 0.02;
			break;
		case AttributeType.DamageReduction:
			num = 0.01;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.SkillRageEfficiencyRate:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.HealingAbsorbRate:
			num = 0.02;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.EffectMastery:
			num = 0.03;
			break;
		case AttributeType.HitRateAdjustment:
			num = 0.01;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.DodgeRateAdjustment:
			num = 0.01;
			modificationType = ModificationType.Addition;
			break;
		case AttributeType.EffectHitRating:
			num = 0.01;
			break;
		case AttributeType.EffectResistanceRating:
			num = 0.01;
			break;
		}
		double num2 = 0.0;
		for (int i = 0; i < numberOfupgrades; i++)
		{
			num2 += num * (double)UnityEngine.Random.Range(0.8f, 1f);
		}
		return new AttributeModifier
		{
			AttributeType = type,
			ModificationType = modificationType,
			Value = num2,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Gear
		};
	}

	// Token: 0x06002D79 RID: 11641 RVA: 0x001285C4 File Offset: 0x001269C4
	protected AttributeModifier GeneratePrimaryAttribute(AttributeType type, int numberOfUpgrades)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (type == AttributeType.Resilience || type == AttributeType.Allresistances || type == AttributeType.Vitality || type == AttributeType.Agility)
		{
			num = (double)UnityEngine.Random.Range(0.1f, 0.2f);
			num2 = 0.01;
		}
		if (type == AttributeType.Strength || type == AttributeType.Intelligience)
		{
			num = (double)UnityEngine.Random.Range(0.05f, 0.1f);
			num2 = 0.005;
		}
		if (type == AttributeType.CritDamage)
		{
			num = (double)UnityEngine.Random.Range(0.2f, 0.4f);
			num2 = 0.02;
		}
		double num3 = num;
		for (int i = 0; i < numberOfUpgrades; i++)
		{
			num3 += num2 * (double)UnityEngine.Random.Range(0.8f, 1f);
		}
		return new AttributeModifier
		{
			AttributeType = type,
			ModificationType = ((type != AttributeType.CritDamage) ? ModificationType.Multiplication : ModificationType.Addition),
			Value = num3,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Gear
		};
	}

	// Token: 0x06002D7A RID: 11642 RVA: 0x001286D8 File Offset: 0x00126AD8
	public TeamSetItemUpgradeResult Upgrade(Item item, int level)
	{
		TeamSetItemUpgradeResult teamSetItemUpgradeResult = new TeamSetItemUpgradeResult
		{
			BoostedAttributes = new List<AttributeModifier>(),
			BoostedEffects = new List<ISpecialEffectDataLoad>()
		};
		UnityEngine.Random.InitState(item.TeamSetSeed.GetValueOrDefault());
		Dictionary<AttributeType, int> attributeSeeds = new Dictionary<AttributeType, int>();
		Dictionary<SpecialEffectType, int> effectSeeds = new Dictionary<SpecialEffectType, int>();
		foreach (AttributeType key in item.PotentialTeamUpgradeAttributes)
		{
			attributeSeeds.Add(key, UnityEngine.Random.Range(1, 10000000));
		}
		foreach (SpecialEffectType key2 in item.PotentialTeamPieceEffects)
		{
			effectSeeds.Add(key2, UnityEngine.Random.Range(1, 10000000));
		}
		int seed = UnityEngine.Random.Range(1, 10000000);
		int seed2 = UnityEngine.Random.Range(1, 10000000);
		int seed3 = UnityEngine.Random.Range(1, 10000000);
		AttributeType valueOrDefault = item.TeamSetPiecePrimaryAttributeType.GetValueOrDefault();
		if (level > 0)
		{
			int num = item.TeamSetUpgradeMarker.Length + 1;
			if (level != num && level != num - 1)
			{
				level = 1;
			}
		}
		item.TeamSetUpgradeMarker = string.Empty;
		for (int i = 0; i < level; i++)
		{
			item.TeamSetUpgradeMarker += ".";
		}
		UnityEngine.Random.InitState(seed);
		AttributeModifier item2 = this.GeneratePrimaryAttribute(valueOrDefault, level);
		item.PrimaryAttributeModifiers = new List<AttributeModifier>
		{
			item2
		};
		item.AdditionalAttributeModifiers = new List<AttributeModifier>();
		item.SpecialEffects = new List<ISpecialEffectDataLoad>();
		item.AddedSpecialEffects = new List<ISpecialEffectDataLoad>();
		item.Level = level;
		teamSetItemUpgradeResult.BoostedAttributes.Add(item2);
		List<AttributeType> list = new List<AttributeType>();
		List<AttributeType> potentialTeamUpgradeAttributes = item.PotentialTeamUpgradeAttributes;
		UnityEngine.Random.InitState(seed2);
		bool flag = false;
		for (int j = 0; j < level; j++)
		{
			if ((double)UnityEngine.Random.value <= 0.5)
			{
				AttributeType item3 = potentialTeamUpgradeAttributes[UnityEngine.Random.Range(0, potentialTeamUpgradeAttributes.Count)];
				list.Add(item3);
				if (j == level - 1)
				{
					flag = true;
				}
			}
		}
		if (list.Any<AttributeType>())
		{
			IEnumerable<IGrouping<AttributeType, AttributeType>> source = from a in list
			group a by a;
			item.AdditionalAttributeModifiers = (from g in source
			select this.GenerateExtraAttribute(g.Key, g.Count<AttributeType>(), attributeSeeds[g.Key])).ToList<AttributeModifier>();
			if (flag)
			{
				AttributeType finaleffectedAttribute = list.Last<AttributeType>();
				AttributeModifier item4 = item.AdditionalAttributeModifiers.FirstOrDefault((AttributeModifier a) => a.AttributeType == finaleffectedAttribute);
				teamSetItemUpgradeResult.BoostedAttributes.Add(item4);
			}
		}
		int num2 = level / 10;
		List<SpecialEffectType> additionalEffects = new List<SpecialEffectType>();
		List<SpecialEffectType> potentialTeamPieceEffects = item.PotentialTeamPieceEffects;
		UnityEngine.Random.InitState(seed3);
		for (int k = 0; k < num2; k++)
		{
			additionalEffects.Add(potentialTeamPieceEffects[UnityEngine.Random.Range(0, potentialTeamPieceEffects.Count)]);
		}
		if (additionalEffects.Any<SpecialEffectType>())
		{
			IEnumerable<IGrouping<SpecialEffectType, SpecialEffectType>> source2 = from e in additionalEffects
			group e by e;
			item.SpecialEffects = (from g in source2
			select this.GenerateEffect(g.Key, g.Count<SpecialEffectType>(), effectSeeds[g.Key])).ToList<ISpecialEffectDataLoad>();
			if (level % 10 == 0)
			{
				ISpecialEffectDataLoad item5 = item.SpecialEffects.FirstOrDefault((ISpecialEffectDataLoad ef) => ef.GetSpecialEffectType() == additionalEffects.Last<SpecialEffectType>());
				teamSetItemUpgradeResult.BoostedEffects.Add(item5);
			}
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in item.SpecialEffects)
		{
			GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad.GetSpecialEffectType());
		}
		return teamSetItemUpgradeResult;
	}

	// Token: 0x06002D7B RID: 11643 RVA: 0x00128B28 File Offset: 0x00126F28
	// Note: this type is marked as 'beforefieldinit'.
	static TeamSetBase()
	{
	}

	// Token: 0x06002D7C RID: 11644 RVA: 0x00128B40 File Offset: 0x00126F40
	[CompilerGenerated]
	private static TeamSetBase <GetAdventureTeamBonus>m__0(KeyValuePair<TeamSetType, TeamSetBase> s)
	{
		return s.Value;
	}

	// Token: 0x06002D7D RID: 11645 RVA: 0x00128B49 File Offset: 0x00126F49
	[CompilerGenerated]
	private static AttributeType <Upgrade>m__1(AttributeType a)
	{
		return a;
	}

	// Token: 0x06002D7E RID: 11646 RVA: 0x00128B4C File Offset: 0x00126F4C
	[CompilerGenerated]
	private static SpecialEffectType <Upgrade>m__2(SpecialEffectType e)
	{
		return e;
	}

	// Token: 0x06002D7F RID: 11647 RVA: 0x00128B4F File Offset: 0x00126F4F
	[CompilerGenerated]
	private static TeamSetType <TeamSetBases>m__3(TeamSetBase set)
	{
		return set.SetType;
	}

	// Token: 0x040026BE RID: 9918
	public static Dictionary<TeamSetType, TeamSetBase> TeamSetBases = ItemExtensions.GetDictionaryOfAbastract<TeamSetType, TeamSetBase>((TeamSetBase set) => set.SetType);

	// Token: 0x040026BF RID: 9919
	[CompilerGenerated]
	private static Func<KeyValuePair<TeamSetType, TeamSetBase>, TeamSetBase> <>f__am$cache0;

	// Token: 0x040026C0 RID: 9920
	[CompilerGenerated]
	private static Func<AttributeType, AttributeType> <>f__am$cache1;

	// Token: 0x040026C1 RID: 9921
	[CompilerGenerated]
	private static Func<SpecialEffectType, SpecialEffectType> <>f__am$cache2;

	// Token: 0x02000DE4 RID: 3556
	[CompilerGenerated]
	private sealed class <GetAdventureTeamBonus>c__AnonStorey0
	{
		// Token: 0x06005935 RID: 22837 RVA: 0x00128B57 File Offset: 0x00126F57
		public <GetAdventureTeamBonus>c__AnonStorey0()
		{
		}

		// Token: 0x06005936 RID: 22838 RVA: 0x00128B60 File Offset: 0x00126F60
		internal bool <>m__0(ResourceType t)
		{
			return this.members.Any((AdventurerProfile a) => a.GetEquipments().Any((Item i) => i.Type == t));
		}

		// Token: 0x04004903 RID: 18691
		internal List<AdventurerProfile> members;

		// Token: 0x02000DE7 RID: 3559
		private sealed class <GetAdventureTeamBonus>c__AnonStorey1
		{
			// Token: 0x0600593D RID: 22845 RVA: 0x00128B98 File Offset: 0x00126F98
			public <GetAdventureTeamBonus>c__AnonStorey1()
			{
			}

			// Token: 0x0600593E RID: 22846 RVA: 0x00128BA0 File Offset: 0x00126FA0
			internal bool <>m__0(AdventurerProfile a)
			{
				return a.GetEquipments().Any((Item i) => i.Type == this.t);
			}

			// Token: 0x0600593F RID: 22847 RVA: 0x00128BB9 File Offset: 0x00126FB9
			internal bool <>m__1(Item i)
			{
				return i.Type == this.t;
			}

			// Token: 0x04004909 RID: 18697
			internal ResourceType t;

			// Token: 0x0400490A RID: 18698
			internal TeamSetBase.<GetAdventureTeamBonus>c__AnonStorey0 <>f__ref$0;
		}
	}

	// Token: 0x02000DE5 RID: 3557
	[CompilerGenerated]
	private sealed class <Upgrade>c__AnonStorey2
	{
		// Token: 0x06005937 RID: 22839 RVA: 0x00128BC9 File Offset: 0x00126FC9
		public <Upgrade>c__AnonStorey2()
		{
		}

		// Token: 0x06005938 RID: 22840 RVA: 0x00128BD1 File Offset: 0x00126FD1
		internal AttributeModifier <>m__0(IGrouping<AttributeType, AttributeType> g)
		{
			return this.$this.GenerateExtraAttribute(g.Key, g.Count<AttributeType>(), this.attributeSeeds[g.Key]);
		}

		// Token: 0x06005939 RID: 22841 RVA: 0x00128BFB File Offset: 0x00126FFB
		internal ISpecialEffectDataLoad <>m__1(IGrouping<SpecialEffectType, SpecialEffectType> g)
		{
			return this.$this.GenerateEffect(g.Key, g.Count<SpecialEffectType>(), this.effectSeeds[g.Key]);
		}

		// Token: 0x0600593A RID: 22842 RVA: 0x00128C25 File Offset: 0x00127025
		internal bool <>m__2(ISpecialEffectDataLoad ef)
		{
			return ef.GetSpecialEffectType() == this.additionalEffects.Last<SpecialEffectType>();
		}

		// Token: 0x04004904 RID: 18692
		internal Dictionary<AttributeType, int> attributeSeeds;

		// Token: 0x04004905 RID: 18693
		internal Dictionary<SpecialEffectType, int> effectSeeds;

		// Token: 0x04004906 RID: 18694
		internal List<SpecialEffectType> additionalEffects;

		// Token: 0x04004907 RID: 18695
		internal TeamSetBase $this;
	}

	// Token: 0x02000DE6 RID: 3558
	[CompilerGenerated]
	private sealed class <Upgrade>c__AnonStorey3
	{
		// Token: 0x0600593B RID: 22843 RVA: 0x00128C3A File Offset: 0x0012703A
		public <Upgrade>c__AnonStorey3()
		{
		}

		// Token: 0x0600593C RID: 22844 RVA: 0x00128C42 File Offset: 0x00127042
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.finaleffectedAttribute;
		}

		// Token: 0x04004908 RID: 18696
		internal AttributeType finaleffectedAttribute;
	}
}
