using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Core.SpecialEffect.Dataload.RuneEnergyCollection;
using Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public static class ItemExtensions
{
	// Token: 0x06002252 RID: 8786 RVA: 0x000F961C File Offset: 0x000F7A1C
	public static GenerationDistribution DefaultAdventurerSpawnDistribution()
	{
		return new GenerationDistribution(0.3, 0.15, 0.05, 0.01);
	}

	// Token: 0x06002253 RID: 8787 RVA: 0x000F9648 File Offset: 0x000F7A48
	public static List<SetItemResult> GetSetBenefits(this List<Item> gears)
	{
		List<SetItemResult> list = new List<SetItemResult>();
		foreach (KeyValuePair<ResourceType, SetItemLogicBase> keyValuePair in ItemExtensions.SetItemLogics)
		{
			SetItemLogicBase value = keyValuePair.Value;
			if (value.SetRequirementMet(gears))
			{
				SetItemResult setItemResult = new SetItemResult
				{
					CorrespondingSetType = value.CorrespondingSetResourceType,
					MajorEffects = new List<ISpecialEffectDataLoad>(),
					MinorEffects = new List<ISpecialEffectDataLoad>(),
					MajorModifiers = new List<AttributeModifier>(),
					MinorModifiers = new List<AttributeModifier>()
				};
				setItemResult.MinorEffects.AddRange(value.GetMinorSetEffectDataLoads(gears));
				setItemResult.MajorEffects.AddRange(value.GetMajorSetEffectDataLoads(gears));
				setItemResult.MajorModifiers.AddRange(value.GetMajorSetAttributeModifiers(gears));
				setItemResult.MinorModifiers.AddRange(value.GetMinorSetAttributeModifiers(gears));
				list.Add(setItemResult);
			}
		}
		return list;
	}

	// Token: 0x06002254 RID: 8788 RVA: 0x000F9754 File Offset: 0x000F7B54
	public static List<SpecialEffectType> GetAllItemEffects()
	{
		List<ResourceType> allItemTypes = (from i in ItemExtensions.AllResourceTypes
		where i.IsGear() || i.GetResourceCategory() == ResourceCategory.Accessory || i.GetResourceCategory() == ResourceCategory.Consumable
		select i).ToList<ResourceType>();
		List<SpecialEffectType> collection = (from s in allItemTypes.SelectMany((ResourceType i) => i.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Ancient))
		select s.GetSpecialEffectType()).ToList<SpecialEffectType>();
		List<SpecialEffectType> collection2 = (from s in ItemExtensions.SpecialEffectProcessors
		select s.Value into p
		where allItemTypes.Any((ResourceType a) => p.CanBeStarEffects(90, a, QualityGrade.Ancient) || p.CanBeRandomSpecialEffects(90, a, QualityGrade.Ancient))
		select p.CorrespondingEffectType).ToList<SpecialEffectType>();
		List<ResourceType> list = (from i in ItemExtensions.AllResourceTypes
		where i.GetResourceCategory() == ResourceCategory.Scrolls
		select i).ToList<ResourceType>();
		IEnumerable<ResourceType> source = list;
		if (ItemExtensions.<>f__mg$cache0 == null)
		{
			ItemExtensions.<>f__mg$cache0 = new Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>>(ItemExtensions.GenerateScrollEffects);
		}
		List<SpecialEffectType> collection3 = (from s in source.SelectMany(ItemExtensions.<>f__mg$cache0)
		select s.GetSpecialEffectType()).ToList<SpecialEffectType>();
		List<ResourceType> source2 = (from i in ItemExtensions.AllResourceTypes
		where i.GetResourceCategory() == ResourceCategory.Amulet
		select i).ToList<ResourceType>();
		List<SpecialEffectType> collection4 = source2.SelectMany((ResourceType a) => a.GetTeamSetBase().GetPotentialEffectTypes(a.GetTeamSetBase().GetItemSuitableClassType(a))).ToList<SpecialEffectType>();
		List<SpecialEffectType> collection5 = (from s in source2.SelectMany((ResourceType a) => a.GetTeamSetBase().GetTeamBonus())
		select s.GetSpecialEffectType()).ToList<SpecialEffectType>();
		List<SpecialEffectType> list2 = new List<SpecialEffectType>();
		list2.AddRange(collection);
		list2.AddRange(collection2);
		list2.AddRange(collection3);
		list2.AddRange(collection4);
		list2.AddRange(collection5);
		list2.AddRange(new List<SpecialEffectType>
		{
			SpecialEffectType.PrismLightAdventurePointsCollection,
			SpecialEffectType.PrismLightTurnCollection,
			SpecialEffectType.PrismLightTacticCollection,
			SpecialEffectType.GhostBreathsDirectDamageReceiveCollection,
			SpecialEffectType.GhostBreathsDisperseNegativeEffectCollection,
			SpecialEffectType.VitalEnergyRebirthCollection,
			SpecialEffectType.VitalEnergyTauntCollection,
			SpecialEffectType.ChaoticSpiritDirectKillCollection,
			SpecialEffectType.CHaoticSpiritReflectionCollection,
			SpecialEffectType.ConeEffect,
			SpecialEffectType.ShieldBreaker,
			SpecialEffectType.SoulLockRandomTargetEffect,
			SpecialEffectType.SoulLockHighestSpeedEffect,
			SpecialEffectType.SoulLockHighestDpsEffect,
			SpecialEffectType.SoulLockHighestLifeEffect,
			SpecialEffectType.PoisonousNeedles,
			SpecialEffectType.SurvivalKit,
			SpecialEffectType.MagicBarrier,
			SpecialEffectType.DeathPrevent,
			SpecialEffectType.EffectCleanserRandomTarget,
			SpecialEffectType.EffectCleanserHighestEffect,
			SpecialEffectType.ArmorBreakerRandom,
			SpecialEffectType.ArmorBreakerHighestArmor,
			SpecialEffectType.ArmorBreakerHighestHealth,
			SpecialEffectType.FlowRandom,
			SpecialEffectType.FlowLowestHealth,
			SpecialEffectType.FlowHighestHealth,
			SpecialEffectType.ReflectionDevice,
			SpecialEffectType.HealDepresser,
			SpecialEffectType.FirePlayerStarDoubleHit,
			SpecialEffectType.YoungWarlockStarIntSteal,
			SpecialEffectType.ConjurerStarTeamBoost,
			SpecialEffectType.ElementalWizardStarHeal,
			SpecialEffectType.CubeStarSkillBoost,
			SpecialEffectType.SoulThiefStarEffectBoost,
			SpecialEffectType.FireAssassinStarImmune,
			SpecialEffectType.NightbladeStarHealReduceBoost,
			SpecialEffectType.WarriorStarTaunt,
			SpecialEffectType.DuelistStarSkillBoost,
			SpecialEffectType.TacticianStarSkillBoost,
			SpecialEffectType.ToughWomanStarAgileBoost,
			SpecialEffectType.StreetManStarHitBoost,
			SpecialEffectType.DrunkReaderStarUndead,
			SpecialEffectType.MissionaryStarReflection,
			SpecialEffectType.KillerStarReflection,
			SpecialEffectType.PaladinStarTauntEnhance,
			SpecialEffectType.ChubbyLadyStarHealerEnhance,
			SpecialEffectType.BunSisterStarMultipleHit,
			SpecialEffectType.FashionBoyStarDoubleDamage,
			SpecialEffectType.IronSoilderStarHitBoost,
			SpecialEffectType.SnowMaidenStarEffect,
			SpecialEffectType.FireChargerStarElement,
			SpecialEffectType.GoldenShamanStarHeal,
			SpecialEffectType.RedHornStarDamageBoost
		});
		return list2.Distinct<SpecialEffectType>().ToList<SpecialEffectType>();
	}

	// Token: 0x06002255 RID: 8789 RVA: 0x000F9C44 File Offset: 0x000F8044
	public static List<SpecialEffectDetails> GetEffectDetails()
	{
		return (from s in ItemExtensions.GetAllItemEffects()
		select LocalizationSession.instance.LocalizationManager.GetSpecialEffectLocalization(s) into s
		select new SpecialEffectDetails
		{
			Type = s.SpecialEffectType,
			IsUnlocked = GameWorld.instance.PlayerProfile.IsEffectUnlocked(s.SpecialEffectType),
			Details = s.GeneralInfo
		}).ToList<SpecialEffectDetails>();
	}

	// Token: 0x06002256 RID: 8790 RVA: 0x000F9CA4 File Offset: 0x000F80A4
	public static TeamSetType GetTeamSetType(this ResourceType rtype)
	{
		ResourceCategory resourceCategory = rtype.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Amulet)
		{
			List<TeamSetBase> source = (from s in TeamSetBase.TeamSetBases
			select s.Value).ToList<TeamSetBase>();
			TeamSetBase teamSetBase = source.FirstOrDefault((TeamSetBase t) => t.TeamSetPieces.Any((ResourceType p) => p == rtype));
			if (teamSetBase != null)
			{
				return teamSetBase.SetType;
			}
		}
		return TeamSetType.None;
	}

	// Token: 0x06002257 RID: 8791 RVA: 0x000F9D20 File Offset: 0x000F8120
	public static TeamSetBase GetTeamSetBase(this ResourceType rtype)
	{
		TeamSetType teamSetType = rtype.GetTeamSetType();
		if (teamSetType != TeamSetType.None)
		{
			return TeamSetBase.TeamSetBases[teamSetType];
		}
		return null;
	}

	// Token: 0x06002258 RID: 8792 RVA: 0x000F9D48 File Offset: 0x000F8148
	public static List<ResourceUpdate> DisambleItems(this List<Item> items)
	{
		List<ResourceUpdate> list = new List<ResourceUpdate>();
		List<ResourceUpdate> list2 = new List<ResourceUpdate>();
		foreach (Item item in items)
		{
			ResourceCategory resourceCategory = item.Type.GetResourceCategory();
			if ((resourceCategory.IsWeapon() || resourceCategory.IsArmor() || resourceCategory == ResourceCategory.Accessory) && item.Level >= 8)
			{
				list2.Add(new ResourceUpdate
				{
					ResourceType = item.Type,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>
					{
						item
					}
				});
				int num = 1;
				if (item.Level >= 10 && item.Level <= 12 && (double)UnityEngine.Random.value <= 0.5)
				{
					num = 2;
				}
				if (item.Level > 12)
				{
					num = 2;
					if ((double)UnityEngine.Random.value <= 0.3)
					{
						num = 3;
					}
				}
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.FragmentOfDemon,
					ChangeAmount = (double)((!item.IsStarItem()) ? num : (10 * num)),
					RelatedItems = new List<Item>()
				});
			}
			if (resourceCategory == ResourceCategory.Gem && item.Level >= 7)
			{
				list2.Add(new ResourceUpdate
				{
					ResourceType = item.Type,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>
					{
						item
					}
				});
				if (item.Level == 7 && (double)UnityEngine.Random.value <= 0.7)
				{
					list.Add(new ResourceUpdate
					{
						ResourceType = ResourceType.InfusedPowder,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					});
				}
				else if (item.Level == 8)
				{
					list.Add(new ResourceUpdate
					{
						ResourceType = ResourceType.InfusedPowder,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					});
				}
				else if (item.Level >= 9)
				{
					int num2 = 1;
					if ((double)UnityEngine.Random.value <= 0.4)
					{
						num2 = 2;
					}
					list.Add(new ResourceUpdate
					{
						ResourceType = ResourceType.InfusedPowder,
						ChangeAmount = (double)num2,
						RelatedItems = new List<Item>()
					});
				}
			}
		}
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
		return list;
	}

	// Token: 0x06002259 RID: 8793 RVA: 0x000FA048 File Offset: 0x000F8448
	public static bool IsResistanceAttribute(this AttributeType type)
	{
		return type >= AttributeType.PhysicalResistance && type <= AttributeType.LightningResistance;
	}

	// Token: 0x0600225A RID: 8794 RVA: 0x000FA069 File Offset: 0x000F8469
	public static bool IsGear(this ResourceType type)
	{
		return type.GetResourceCategory().IsWeapon() || type.GetResourceCategory().IsArmor();
	}

	// Token: 0x0600225B RID: 8795 RVA: 0x000FA089 File Offset: 0x000F8489
	public static bool MetRequirements(this List<ResourceConsumptionRequirement> requirements)
	{
		bool result;
		if (requirements != null && requirements.Count != 0)
		{
			result = requirements.All((ResourceConsumptionRequirement r) => GameWorld.instance.PlayerProfile.GetResourceAmount_AvaliableForProduction(r.ResourceType) >= (double)r.AmountRequired);
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600225C RID: 8796 RVA: 0x000FA0C2 File Offset: 0x000F84C2
	public static void Consume(this List<ResourceConsumptionRequirement> requirements)
	{
		GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in requirements
		select new ResourceUpdate
		{
			ResourceType = r.ResourceType,
			ChangeAmount = (double)(-(double)r.AmountRequired),
			RelatedItems = new List<Item>()
		}).ToList<ResourceUpdate>());
	}

	// Token: 0x0600225D RID: 8797 RVA: 0x000FA0FB File Offset: 0x000F84FB
	public static SpecialEffectProcessBase GetSpecialProcessor(this SpecialEffectType type)
	{
		return ItemExtensions.SpecialEffectProcessors[type];
	}

	// Token: 0x0600225E RID: 8798 RVA: 0x000FA108 File Offset: 0x000F8508
	public static bool HasProcessor(this SpecialEffectType type)
	{
		return ItemExtensions.SpecialEffectProcessors.ContainsKey(type);
	}

	// Token: 0x0600225F RID: 8799 RVA: 0x000FA115 File Offset: 0x000F8515
	public static bool IsSocketBatcher(this ResourceType type)
	{
		return ItemExtensions.SocketBatcherRelatedSocketType.ContainsKey(type);
	}

	// Token: 0x06002260 RID: 8800 RVA: 0x000FA122 File Offset: 0x000F8522
	public static SocketType GetSocketBatcherRelatedSocketType(this ResourceType type)
	{
		return ItemExtensions.SocketBatcherRelatedSocketType[type];
	}

	// Token: 0x06002261 RID: 8801 RVA: 0x000FA130 File Offset: 0x000F8530
	public static Recipe GetRecipeByProductType(this ResourceType productType)
	{
		return BuildingExtensions.Recipes.FirstOrDefault((Recipe r) => r.ProductType == productType);
	}

	// Token: 0x06002262 RID: 8802 RVA: 0x000FA160 File Offset: 0x000F8560
	public static Recipe GetRecipeByRecipeName(this ResourceType recipeName)
	{
		return BuildingExtensions.Recipes.FirstOrDefault((Recipe r) => r.RecipeName == recipeName);
	}

	// Token: 0x06002263 RID: 8803 RVA: 0x000FA190 File Offset: 0x000F8590
	public static Dictionary<T, P> GetDictionaryOfAbastract<T, P>(Func<P, T> selector) where T : struct, IConvertible
	{
		List<P> implementationsOfAbstractClass = GameConfigurations.GetImplementationsOfAbstractClass<P>();
		Dictionary<T, P> dictionary = new Dictionary<T, P>();
		foreach (P p in implementationsOfAbstractClass)
		{
			if (dictionary.ContainsKey(selector(p)))
			{
				T t = selector(p);
				throw new Exception(t.ToString() + " already exists");
			}
			dictionary.Add(selector(p), p);
		}
		return dictionary;
	}

	// Token: 0x06002264 RID: 8804 RVA: 0x000FA234 File Offset: 0x000F8634
	private static List<E> GetEnums<E>() where E : struct, IConvertible
	{
		if (!typeof(E).IsEnum)
		{
			throw new Exception("Invalid enum");
		}
		return (from E a in Enum.GetValues(typeof(E))
		orderby a
		select a).ToList<E>();
	}

	// Token: 0x06002265 RID: 8805 RVA: 0x000FA28A File Offset: 0x000F868A
	public static List<E> GetEnumValues<E>() where E : struct, IConvertible
	{
		if (!typeof(E).IsEnum)
		{
			throw new Exception("Invalid enum");
		}
		return ItemExtensions.GetEnums<E>();
	}

	// Token: 0x06002266 RID: 8806 RVA: 0x000FA2B0 File Offset: 0x000F86B0
	public static bool IsUpgradeableAttribute(this AttributeType type)
	{
		List<AttributeType> source = new List<AttributeType>
		{
			AttributeType.Strength,
			AttributeType.Intelligience,
			AttributeType.PhysicalResistance,
			AttributeType.FireResistanceResistance,
			AttributeType.ShadowResistance,
			AttributeType.IceResistance,
			AttributeType.LightningResistance,
			AttributeType.PoisonResistance,
			AttributeType.DivineResistance,
			AttributeType.Agility,
			AttributeType.Vitality
		};
		return source.Any((AttributeType a) => a == type);
	}

	// Token: 0x06002267 RID: 8807 RVA: 0x000FA338 File Offset: 0x000F8738
	public static bool IsPercentageValue(this AttributeType type)
	{
		return type == AttributeType.CritDamage || type == AttributeType.LifeOnHit || type == AttributeType.TauntOnHit || type == AttributeType.StunOnHit || type == AttributeType.ReflectiveDamage || type == AttributeType.BattleStartHeal || type == AttributeType.TurnStartHeal || type == AttributeType.ReceivedHealEffectivenessChangeRate || type == AttributeType.DealFireDamageEffectivenessChangeRate || type == AttributeType.DealPhysicalDamageEffectivenessChangeRate || type == AttributeType.DealPoisonDamageEffectivenessChangeRate || type == AttributeType.DealDivineDamageEffectivenessChangeRate || type == AttributeType.DealIceDamageEffectivenessChangeRate || type == AttributeType.DealLightningDamageEffectivenessChangeRate || type == AttributeType.DealShadowDamageEffectivenessChangeRate || type == AttributeType.Mining || type == AttributeType.Logging || type == AttributeType.Hunting || type == AttributeType.CritRate || type == AttributeType.SkillRageEfficiencyRate || type == AttributeType.HealingAbsorbRate || type == AttributeType.DamageReduction || type == AttributeType.EffectMastery || type == AttributeType.HitRateAdjustment || type == AttributeType.DodgeRateAdjustment || type == AttributeType.PhysicalPenetration || type == AttributeType.FirePenetration || type == AttributeType.IcePenetration || type == AttributeType.ShadowPenetration || type == AttributeType.PoisonPenetration || type == AttributeType.DivinePenetration || type == AttributeType.LighteningPenetration;
	}

	// Token: 0x06002268 RID: 8808 RVA: 0x000FA49D File Offset: 0x000F889D
	public static ItemCategoryRootDefault GetRootDefault(this ResourceCategory category)
	{
		return ItemExtensions.ItemCategoryRootDefaults[category];
	}

	// Token: 0x06002269 RID: 8809 RVA: 0x000FA4AC File Offset: 0x000F88AC
	public static UnitClass GetInvitationRelatedUnitClass(this ResourceType type)
	{
		return UnitExtensions.UnitConfigurations.First((KeyValuePair<UnitClass, UnitConfigurationBase> u) => u.Value != null && u.Value.CorrespondingInvitationType == type).Value.CorrespondingUnitClass;
	}

	// Token: 0x0600226A RID: 8810 RVA: 0x000FA4E9 File Offset: 0x000F88E9
	public static LevelConfigurationBase GetConfiguration(this AdventureType type)
	{
		return LevelConfigurationExtension.AdventureConfigurations[type];
	}

	// Token: 0x0600226B RID: 8811 RVA: 0x000FA4F6 File Offset: 0x000F88F6
	public static bool IsUniqueResource(this ResourceCategory category)
	{
		return category == ResourceCategory.BuildingPermit || category == ResourceCategory.ProductionRecipe || category == ResourceCategory.AdventurerInvitation || category == ResourceCategory.GameItem;
	}

	// Token: 0x0600226C RID: 8812 RVA: 0x000FA518 File Offset: 0x000F8918
	public static bool HasObtained(this ResourceType type)
	{
		return GameWorld.instance.PlayerProfile.HasResource(type);
	}

	// Token: 0x0600226D RID: 8813 RVA: 0x000FA52C File Offset: 0x000F892C
	private static Item CreateGem(ResourceType type, int level)
	{
		GemGeneratorBase gemGeneratorBase = ItemExtensions.GemGenerators[type];
		return gemGeneratorBase.GenerateGem(level);
	}

	// Token: 0x0600226E RID: 8814 RVA: 0x000FA54C File Offset: 0x000F894C
	public static ItemTemplateBase GetCreationTemplate(this ResourceType type)
	{
		if (!BuildingExtensions.ItemTemplates.ContainsKey(type))
		{
			Debug.Log("Invalid!");
		}
		if (!BuildingExtensions.ItemTemplates.ContainsKey(type))
		{
			throw new Exception(type + " cannot be found in dictionary");
		}
		return BuildingExtensions.ItemTemplates[type];
	}

	// Token: 0x0600226F RID: 8815 RVA: 0x000FA5A4 File Offset: 0x000F89A4
	public static bool HasCreationTemplate(this ResourceType type)
	{
		return BuildingExtensions.ItemTemplates.ContainsKey(type);
	}

	// Token: 0x06002270 RID: 8816 RVA: 0x000FA5B4 File Offset: 0x000F89B4
	public static Item ItemGenerate(this ResourceType type, ResourceSourceType itemSource, ItemGenerationQuality quality, int itemTierLevel, int level = 1)
	{
		ResourceCategory resourceCategory = type.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Gem)
		{
			GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
			Item item = ItemExtensions.CreateGem(type, level);
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			item.CalculateQualityRatingsAndCacheAttributes();
			return item;
		}
		if (resourceCategory == ResourceCategory.Usable)
		{
			return new Item
			{
				Value = (double)(500 + level * 500),
				Level = level,
				Type = type,
				ItemGrade = QualityGrade.Ancient,
				Id = Guid.NewGuid().ToString(),
				ItemStatus = ItemStatus.Reserved,
				AdditionalAttributeModifiers = new List<AttributeModifier>(),
				PrimaryAttributeModifiers = new List<AttributeModifier>(),
				SlotType = ItemType.Normal,
				SpecialEffects = new List<ISpecialEffectDataLoad>(),
				AddedSpecialEffects = new List<ISpecialEffectDataLoad>(),
				PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional,
				Sockets = new List<ItemSocket>(),
				IsStarGear = new bool?(false),
				HasBeenEnchantedForTimes = new int?(0),
				ItemTierLevel = new int?(level * 5 - 4),
				CanBeReforged = new bool?(false)
			};
		}
		if (resourceCategory == ResourceCategory.Device)
		{
			GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
			Item item2 = ItemExtensions.GenerateDevice(type, itemTierLevel);
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			item2.CalculateQualityRatingsAndCacheAttributes();
			return item2;
		}
		if (resourceCategory == ResourceCategory.Scrolls)
		{
			GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
			Item item3 = ItemExtensions.GenerateScroll(type, quality.IsStar, itemTierLevel);
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			item3.CalculateQualityRatingsAndCacheAttributes();
			return item3;
		}
		if (resourceCategory == ResourceCategory.Amulet)
		{
			TeamSetBase teamSetBase = type.GetTeamSetBase();
			GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
			AttributeType attributeType = teamSetBase.GeneratePrimaryAttributeType(type);
			Item item4 = new Item
			{
				ItemGrade = QualityGrade.Normal,
				Value = 1000.0,
				Id = Guid.NewGuid().ToString(),
				ItemStatus = ItemStatus.Reserved,
				Type = type,
				AdditionalAttributeModifiers = new List<AttributeModifier>(),
				PrimaryAttributeModifiers = new List<AttributeModifier>(),
				SlotType = ((!resourceCategory.IsWeapon()) ? ((!resourceCategory.IsArmor()) ? ((resourceCategory != ResourceCategory.Accessory) ? ((resourceCategory != ResourceCategory.Amulet) ? ItemType.None : ItemType.Amulet) : ItemType.Accessory) : ItemType.Armor) : ItemType.Weapon),
				Level = 0,
				SpecialEffects = new List<ISpecialEffectDataLoad>(),
				AddedSpecialEffects = new List<ISpecialEffectDataLoad>(),
				PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional,
				Sockets = new List<ItemSocket>(),
				IsStarGear = new bool?(false),
				HasBeenEnchantedForTimes = new int?(0),
				ItemTierLevel = new int?(0),
				CanBeReforged = new bool?(false),
				PotentialTeamPieceEffects = teamSetBase.GetPotentialEffectTypes(teamSetBase.GetItemSuitableClassType(type)),
				PotentialTeamUpgradeAttributes = new List<AttributeType>(),
				OutputTypeForTeamSet = new AttributeType?((attributeType != AttributeType.Intelligience && attributeType != AttributeType.Strength) ? (((double)UnityEngine.Random.value > 0.5) ? AttributeType.Strength : AttributeType.Intelligience) : attributeType),
				TeamSetUpgradeMarker = string.Empty,
				TeamSetPiecePrimaryAttributeType = new AttributeType?(attributeType),
				TeamSetSeed = new int?(UnityEngine.Random.Range(1, 100000))
			};
			item4.PotentialTeamUpgradeAttributes = teamSetBase.GetPotentialRollAttributeTypes(item4);
			teamSetBase.Upgrade(item4, 0);
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			foreach (ISpecialEffectDataLoad specialEffectDataLoad in teamSetBase.GetTeamBonus())
			{
				GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad.GetSpecialEffectType());
			}
			item4.CalculateQualityRatingsAndCacheAttributes();
			return item4;
		}
		ItemTemplateBase itemTemplateBase = BuildingExtensions.ItemTemplates[type];
		QualityGrade grade = quality.QualityGrade;
		int itemTier = itemTierLevel;
		if (resourceCategory == ResourceCategory.Consumable)
		{
			GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
			itemTier = itemTemplateBase.ItemTierNumber;
			List<ISpecialEffectDataLoad> normalLevelSpecialEffectDataLoads = itemTemplateBase.GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal);
			foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in normalLevelSpecialEffectDataLoads)
			{
				GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad2.GetSpecialEffectType());
			}
			Item result = new Item
			{
				ItemGrade = QualityGrade.Normal,
				Value = (double)itemTemplateBase.GetValueBase(itemTier),
				Id = Guid.NewGuid().ToString(),
				ItemStatus = ItemStatus.Reserved,
				Type = itemTemplateBase.ItemType,
				AdditionalAttributeModifiers = new List<AttributeModifier>(),
				PrimaryAttributeModifiers = new List<AttributeModifier>(),
				SlotType = ((!resourceCategory.IsWeapon()) ? ((!resourceCategory.IsArmor()) ? ((resourceCategory != ResourceCategory.Accessory) ? ItemType.None : ItemType.Accessory) : ItemType.Armor) : ItemType.Weapon),
				Level = itemTemplateBase.ItemLevel(itemTier),
				SpecialEffects = itemTemplateBase.GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal),
				AddedSpecialEffects = new List<ISpecialEffectDataLoad>(),
				PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional,
				Sockets = new List<ItemSocket>(),
				IsStarGear = new bool?(false),
				HasBeenEnchantedForTimes = new int?(0),
				ItemTierLevel = new int?(itemTier),
				CanBeReforged = new bool?(false)
			};
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			return result;
		}
		GameWorld.instance.PlayerProfile.StartGenerationSeedScope(type);
		List<ItemPropertyPotential> potentials = itemTemplateBase.PropertyPotentials(itemTier);
		GenerationIntrimResult generationIntrimResult = ItemExtensions.ProducePrimaryAttributesForItem(grade, potentials, 0);
		if (resourceCategory == ResourceCategory.Accessory)
		{
			List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
			list.AddRange(itemTemplateBase.GetNormalLevelSpecialEffectDataLoads(grade));
			if (quality.IsStar && itemTemplateBase is AccessoryTemplateBase)
			{
				list.AddRange((itemTemplateBase as AccessoryTemplateBase).GenerateStarEffects(grade, itemTier));
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad3 in list)
			{
				GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad3.GetSpecialEffectType());
			}
			Item item5 = new Item
			{
				ItemGrade = grade,
				Value = (double)itemTemplateBase.GetValueBase(itemTier),
				Id = Guid.NewGuid().ToString(),
				ItemStatus = ItemStatus.Reserved,
				Type = itemTemplateBase.ItemType,
				AdditionalAttributeModifiers = new List<AttributeModifier>(),
				PrimaryAttributeModifiers = generationIntrimResult.AttributeModifiers,
				SlotType = ((!resourceCategory.IsWeapon()) ? ((!resourceCategory.IsArmor()) ? ((resourceCategory != ResourceCategory.Accessory) ? ItemType.None : ItemType.Accessory) : ItemType.Armor) : ItemType.Weapon),
				Level = itemTemplateBase.ItemLevel(itemTier),
				SpecialEffects = list,
				PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional,
				Sockets = new List<ItemSocket>(),
				IsStarGear = new bool?(quality.IsStar),
				ItemTierLevel = new int?(itemTier),
				HasBeenEnchantedForTimes = new int?(0),
				AddedSpecialEffects = new List<ISpecialEffectDataLoad>(),
				CanBeReforged = new bool?(false)
			};
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			if (item5.IsStarItem())
			{
				GameWorld.instance.PlayerProfile.UpdateStarItemUnlocked();
			}
			item5.CalculateQualityRatingsAndCacheAttributes();
			return item5;
		}
		int num = ItemExtensions.AdditionalPropertyGradeSetting[grade];
		int num2 = 0;
		if (itemSource == ResourceSourceType.BuildingProduction && ResourceType.CrystalStone.HasObtained())
		{
			num2 = 1;
		}
		if (grade == QualityGrade.Ancient && (itemSource == ResourceSourceType.BuildingProduction || itemSource == ResourceSourceType.Combine))
		{
			List<ArmoryMasteryEffect> list2 = GameWorld.instance.PlayerProfile.GetTownEffects().OfType<ArmoryMasteryEffect>().ToList<ArmoryMasteryEffect>();
			if (list2.Any<ArmoryMasteryEffect>())
			{
				num2 += list2.Sum((ArmoryMasteryEffect a) => a.NumberOfAdditionalAttributes);
				foreach (ArmoryMasteryEffect armoryMasteryEffect in list2)
				{
					armoryMasteryEffect.RemoveTrigger(1);
				}
			}
		}
		int totalPotentialProperties = num + num2;
		GenerationIntrimResult generationIntrimResult2 = ItemExtensions.ProduceAdditionalAttributesForItem(grade, potentials, totalPotentialProperties);
		List<AttributeModifier> attributeModifiers = generationIntrimResult2.AttributeModifiers;
		List<ItemSocket> sockets = ItemExtensions.SocketGenerations(type, grade);
		Item item6;
		if (itemTierLevel > 35)
		{
			List<ISpecialEffectDataLoad> list3 = new List<ISpecialEffectDataLoad>();
			if (type.GetResourceCategory().IsWeapon() || type.GetResourceCategory().IsArmor())
			{
				List<SpecialEffectProcessBase> source = (from p in ItemExtensions.SpecialEffectProcessors
				select p.Value into v
				where v != null
				select v).ToList<SpecialEffectProcessBase>();
				List<SpecialEffectProcessBase> list4 = (from p in source
				where p.CanBeRandomSpecialEffects(itemTier, type, grade)
				select p).ToList<SpecialEffectProcessBase>();
				if (list4.Any<SpecialEffectProcessBase>())
				{
					list3.AddRange(list4.WeightedRandomSelect<SpecialEffectProcessBase>().GenerateRandomEffect(itemTierLevel, type, grade));
				}
				if (quality.IsStar)
				{
					List<SpecialEffectProcessBase> list5 = (from p in source
					where p.CanBeStarEffects(itemTierLevel, type, grade)
					select p).ToList<SpecialEffectProcessBase>();
					if (list5.Any<SpecialEffectProcessBase>())
					{
						list3.AddRange(list5.WeightedRandomSelect<SpecialEffectProcessBase>().GenerateStarEffect(itemTierLevel, type, grade));
					}
				}
			}
			foreach (ISpecialEffectDataLoad specialEffectDataLoad4 in list3)
			{
				GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad4.GetSpecialEffectType());
			}
			item6 = new Item();
			item6.ItemGrade = grade;
			item6.Value = (double)itemTemplateBase.GetValueBase(itemTier);
			item6.Id = Guid.NewGuid().ToString();
			item6.ItemStatus = ItemStatus.Reserved;
			item6.Type = itemTemplateBase.ItemType;
			item6.AdditionalAttributeModifiers = (from a in attributeModifiers
			orderby a.AttributeType
			select a).ToList<AttributeModifier>();
			item6.PrimaryAttributeModifiers = generationIntrimResult.AttributeModifiers;
			item6.SlotType = ((!resourceCategory.IsWeapon()) ? ((!resourceCategory.IsArmor()) ? ((resourceCategory != ResourceCategory.Accessory) ? ItemType.None : ItemType.Accessory) : ItemType.Armor) : ItemType.Weapon);
			item6.Level = itemTemplateBase.ItemLevel(itemTier);
			item6.SpecialEffects = list3;
			item6.PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional;
			item6.Sockets = sockets;
			item6.IsStarGear = new bool?(quality.IsStar);
			item6.ItemTierLevel = new int?(itemTier);
			item6.HasBeenEnchantedForTimes = new int?(0);
			item6.AddedSpecialEffects = new List<ISpecialEffectDataLoad>();
			Item item7 = item6;
			item7.CanBeReforged = new bool?(item7.GetReforgeableAttributes().Any<AttributeModifier>());
			GameWorld.instance.PlayerProfile.RotateSeed(type);
			if (item7.IsStarItem())
			{
				GameWorld.instance.PlayerProfile.UpdateStarItemUnlocked();
			}
			item7.CalculateQualityRatingsAndCacheAttributes();
			return item7;
		}
		List<ISpecialEffectDataLoad> list6 = new List<ISpecialEffectDataLoad>();
		list6.AddRange(itemTemplateBase.GetNormalLevelSpecialEffectDataLoads(grade));
		foreach (ISpecialEffectDataLoad specialEffectDataLoad5 in list6)
		{
			GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad5.GetSpecialEffectType());
		}
		item6 = new Item();
		item6.ItemGrade = grade;
		item6.Value = (double)itemTemplateBase.GetValueBase(itemTier);
		item6.Id = Guid.NewGuid().ToString();
		item6.ItemStatus = ItemStatus.Reserved;
		item6.Type = itemTemplateBase.ItemType;
		item6.AdditionalAttributeModifiers = (from a in attributeModifiers
		orderby a.AttributeType
		select a).ToList<AttributeModifier>();
		item6.PrimaryAttributeModifiers = generationIntrimResult.AttributeModifiers;
		item6.SlotType = ((!resourceCategory.IsWeapon()) ? ((!resourceCategory.IsArmor()) ? ((resourceCategory != ResourceCategory.Accessory) ? ItemType.None : ItemType.Accessory) : ItemType.Armor) : ItemType.Weapon);
		item6.Level = itemTemplateBase.ItemLevel(itemTier);
		item6.SpecialEffects = list6;
		item6.PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional;
		item6.Sockets = sockets;
		item6.IsStarGear = new bool?(false);
		item6.ItemTierLevel = new int?(itemTierLevel);
		item6.HasBeenEnchantedForTimes = new int?(0);
		item6.AddedSpecialEffects = new List<ISpecialEffectDataLoad>();
		Item item8 = item6;
		item8.CanBeReforged = new bool?(item8.GetReforgeableAttributes().Any<AttributeModifier>());
		GameWorld.instance.PlayerProfile.RotateSeed(type);
		item8.CalculateQualityRatingsAndCacheAttributes();
		return item8;
	}

	// Token: 0x06002271 RID: 8817 RVA: 0x000FB46C File Offset: 0x000F986C
	public static int GetConsumableLevel(this ResourceType type)
	{
		ItemTemplateBase creationTemplate = type.GetCreationTemplate();
		return creationTemplate.ItemLevel(creationTemplate.ItemTierNumber);
	}

	// Token: 0x06002272 RID: 8818 RVA: 0x000FB48C File Offset: 0x000F988C
	private static Item GenerateDevice(ResourceType type, int itemTierLevel)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (type == ResourceType.PrismLightCharger)
		{
			float value = UnityEngine.Random.value;
			if ((double)value <= 0.33)
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(1, 4),
					Type = SpecialEffectType.PrismLightAdventurePointsCollection
				});
			}
			else if ((double)value <= 0.67)
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(1, 4),
					Type = SpecialEffectType.PrismLightTurnCollection
				});
			}
			else
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(1, 4),
					Type = SpecialEffectType.PrismLightTacticCollection
				});
			}
		}
		if (type == ResourceType.GhostBreathCollector)
		{
			if ((double)UnityEngine.Random.value <= 0.5)
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(1, 3),
					Type = SpecialEffectType.GhostBreathsDirectDamageReceiveCollection
				});
			}
			else
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(1, 3),
					Type = SpecialEffectType.GhostBreathsDisperseNegativeEffectCollection
				});
			}
		}
		if (type == ResourceType.VitalEnergyContainer)
		{
			if ((double)UnityEngine.Random.value <= 0.5)
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(15, 21),
					Type = SpecialEffectType.VitalEnergyRebirthCollection
				});
			}
			else
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(2, 6),
					Type = SpecialEffectType.VitalEnergyTauntCollection
				});
			}
		}
		if (type == ResourceType.SpiritBox)
		{
			if ((double)UnityEngine.Random.value <= 0.5)
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(3, 7),
					Type = SpecialEffectType.ChaoticSpiritDirectKillCollection
				});
			}
			else
			{
				list.Add(new RuneEnergyCollectorData
				{
					Rate = UnityEngine.Random.Range(4, 8),
					Type = SpecialEffectType.CHaoticSpiritReflectionCollection
				});
			}
		}
		if (type == ResourceType.PrismScope)
		{
			list.Add(new ConeData
			{
				Rate = (double)UnityEngine.Random.Range(0.1f, 0.15f),
				_cost = UnityEngine.Random.Range(30, 36)
			});
		}
		if (type == ResourceType.SoulLocker)
		{
			float value2 = UnityEngine.Random.value;
			if ((double)value2 <= 0.25)
			{
				list.Add(new SoulLockRandomTargetData
				{
					_cost = UnityEngine.Random.Range(30, 36),
					LockTime = (double)UnityEngine.Random.Range(0.5f, 1.5f)
				});
			}
			else if ((double)value2 <= 0.5)
			{
				list.Add(new SoulLockHighestDpsData
				{
					_cost = UnityEngine.Random.Range(30, 36),
					LockTime = (double)UnityEngine.Random.Range(0.5f, 1.5f)
				});
			}
			else if ((double)value2 <= 0.75)
			{
				list.Add(new SoulLockHighestSpeedData
				{
					_cost = UnityEngine.Random.Range(30, 36),
					LockTime = (double)UnityEngine.Random.Range(0.5f, 1.5f)
				});
			}
			else
			{
				list.Add(new SoulLockHighestLifeData
				{
					_cost = UnityEngine.Random.Range(30, 36),
					LockTime = (double)UnityEngine.Random.Range(0.5f, 1.5f)
				});
			}
		}
		if (type == ResourceType.ShieldRemover)
		{
			list.Add(new ShieldBreakerData
			{
				_cost = UnityEngine.Random.Range(70, 91),
				NumberOfDispels = UnityEngine.Random.Range(1, 3),
				NumberOfTargets = UnityEngine.Random.Range(1, 3)
			});
		}
		if (type == ResourceType.PoisonousNeedles)
		{
			list.Add(new PoisonousNeedlesData
			{
				_cost = UnityEngine.Random.Range(30, 36),
				DamageRate = (double)UnityEngine.Random.Range(7f, 10f)
			});
		}
		if (type == ResourceType.FirstAidKit)
		{
			list.Add(new SurvivalData
			{
				_cost = UnityEngine.Random.Range(25, 31),
				HealRate = (double)UnityEngine.Random.Range(0.3f, 0.4f)
			});
		}
		if (type == ResourceType.MagicShield)
		{
			list.Add(new MagicBarrierData
			{
				_cost = UnityEngine.Random.Range(25, 31),
				ResistanceBoostRating = (double)UnityEngine.Random.Range(60, 91)
			});
		}
		if (type == ResourceType.Pacemaker)
		{
			list.Add(new DeathPreventData
			{
				_cost = UnityEngine.Random.Range(40, 46)
			});
		}
		if (type == ResourceType.Dispeller)
		{
			if ((double)UnityEngine.Random.value <= 0.5)
			{
				list.Add(new EffectCleanserRandomData
				{
					_cost = UnityEngine.Random.Range(35, 41),
					Chance = (double)UnityEngine.Random.Range(0.1f, 0.3f)
				});
			}
			else
			{
				list.Add(new EffectCleanserHighestEffectData
				{
					_cost = UnityEngine.Random.Range(35, 41),
					Chance = (double)UnityEngine.Random.Range(0.1f, 0.3f)
				});
			}
		}
		if (type == ResourceType.DefenceBreaker)
		{
			float value3 = UnityEngine.Random.value;
			if ((double)value3 <= 0.33)
			{
				list.Add(new ArmorBreakerRandomData
				{
					_cost = UnityEngine.Random.Range(25, 31),
					LastingSeconds = (double)UnityEngine.Random.Range(0.5f, 1.5f),
					ReductionRate = (double)UnityEngine.Random.Range(0.5f, 0.9f)
				});
			}
			else if ((double)value3 <= 0.67)
			{
				list.Add(new ArmorBreakerHighestArmorData
				{
					_cost = UnityEngine.Random.Range(25, 31),
					LastingSeconds = (double)UnityEngine.Random.Range(0.5f, 1.5f),
					ReductionRate = (double)UnityEngine.Random.Range(0.5f, 0.9f)
				});
			}
			else
			{
				list.Add(new ArmorBreakerHighestHealthData
				{
					_cost = UnityEngine.Random.Range(25, 31),
					LastingSeconds = (double)UnityEngine.Random.Range(0.5f, 1.5f),
					ReductionRate = (double)UnityEngine.Random.Range(0.5f, 0.9f)
				});
			}
		}
		if (type == ResourceType.ChaoticFlowTrigger)
		{
			float value4 = UnityEngine.Random.value;
			if ((double)value4 <= 0.33)
			{
				list.Add(new FlowRandomData
				{
					_cost = UnityEngine.Random.Range(35, 41),
					DamageRate = (double)UnityEngine.Random.Range(2f, 6f),
					RecoveryRate = UnityEngine.Random.Range(10, 21)
				});
			}
			else if ((double)value4 <= 0.67)
			{
				list.Add(new FlowLowestHealthData
				{
					_cost = UnityEngine.Random.Range(35, 41),
					DamageRate = (double)UnityEngine.Random.Range(2f, 6f),
					RecoveryRate = UnityEngine.Random.Range(10, 21)
				});
			}
			else
			{
				list.Add(new FlowHighestHealthData
				{
					_cost = UnityEngine.Random.Range(35, 41),
					DamageRate = (double)UnityEngine.Random.Range(2f, 6f),
					RecoveryRate = UnityEngine.Random.Range(10, 21)
				});
			}
		}
		if (type == ResourceType.ReflectiveShield)
		{
			list.Add(new ReflectionDeviceData
			{
				_cost = UnityEngine.Random.Range(35, 41),
				Rate = (double)UnityEngine.Random.Range(2f, 5f)
			});
		}
		if (type == ResourceType.VitalitySuppressor)
		{
			list.Add(new HealDepresserData
			{
				_cost = UnityEngine.Random.Range(30, 36),
				LastingSeconds = (double)UnityEngine.Random.Range(2f, 4f)
			});
		}
		List<AttributeModifier> list2 = new List<AttributeModifier>();
		List<ItemPropertyPotential> devicePotentialAttributes = ItemExtensions.GetDevicePotentialAttributes(itemTierLevel, type.IsCollectorDevice());
		devicePotentialAttributes.Shuffle<ItemPropertyPotential>();
		DifficultyLevelMeasurement endlessDungeonDf = GameWorld.instance.PlayerProfile.GetEndlessDungeonDf();
		float value5 = UnityEngine.Random.value;
		int count;
		if ((double)value5 <= 0.8)
		{
			count = 2;
		}
		else
		{
			count = 3;
		}
		if (endlessDungeonDf.DifficultyValue >= 500.0)
		{
			if ((double)value5 <= 0.8)
			{
				count = 2;
			}
			else if ((double)value5 <= 0.95)
			{
				count = 3;
			}
			else
			{
				count = 4;
			}
		}
		if (endlessDungeonDf.DifficultyValue >= 1000.0)
		{
			if ((double)value5 <= 0.8)
			{
				count = 3;
			}
			else if ((double)value5 <= 0.95)
			{
				count = 4;
			}
			else
			{
				count = 5;
			}
		}
		if (endlessDungeonDf.DifficultyValue >= 2000.0)
		{
			if ((double)value5 <= 0.8)
			{
				count = 3;
			}
			else if ((double)value5 <= 0.95)
			{
				count = 4;
			}
			else
			{
				count = 6;
			}
		}
		if (endlessDungeonDf.DifficultyValue >= 3000.0)
		{
			if ((double)value5 <= 0.8)
			{
				count = 3;
			}
			else if ((double)value5 <= 0.95)
			{
				count = 4;
			}
			else
			{
				count = 8;
			}
		}
		List<ItemPropertyPotential> list3 = devicePotentialAttributes.Take(count).ToList<ItemPropertyPotential>();
		foreach (ItemPropertyPotential itemPropertyPotential in list3)
		{
			double mean = itemPropertyPotential.Mean;
			double value6 = mean * (double)UnityEngine.Random.Range(0.8f, 1f);
			list2.Add(new AttributeModifier
			{
				AttributeType = itemPropertyPotential.AttributeType,
				ModificationType = ModificationType.Addition,
				Value = value6,
				Key = "generation_Secondary",
				AttributeModifierType = AttributeModifierType.Gear
			});
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in list)
		{
			GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad.GetSpecialEffectType());
		}
		Item item = new Item();
		item.ItemGrade = QualityGrade.Ancient;
		item.Value = 1000.0;
		item.Id = Guid.NewGuid().ToString();
		item.ItemStatus = ItemStatus.Reserved;
		item.Type = type;
		item.AdditionalAttributeModifiers = (from a in list2
		orderby a.AttributeType
		select a).ToList<AttributeModifier>();
		item.PrimaryAttributeModifiers = new List<AttributeModifier>();
		item.SlotType = ItemType.Device;
		item.Level = (int)Math.Ceiling((double)itemTierLevel / 5.0);
		item.SpecialEffects = list;
		item.PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional;
		item.Sockets = new List<ItemSocket>();
		item.IsStarGear = new bool?(false);
		item.ItemTierLevel = new int?(itemTierLevel);
		item.HasBeenEnchantedForTimes = new int?(0);
		item.AddedSpecialEffects = new List<ISpecialEffectDataLoad>();
		item.CanBeReforged = new bool?(true);
		return item;
	}

	// Token: 0x06002273 RID: 8819 RVA: 0x000FC010 File Offset: 0x000FA410
	public static List<ItemPropertyPotential> GetDevicePotentialAttributes(int itemTierLevel, bool isCollector)
	{
		List<AttributeType> source = new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate,
			AttributeType.DealDivineDamageEffectivenessChangeRate,
			AttributeType.DealFireDamageEffectivenessChangeRate,
			AttributeType.DealIceDamageEffectivenessChangeRate,
			AttributeType.DealLightningDamageEffectivenessChangeRate,
			AttributeType.DealPoisonDamageEffectivenessChangeRate,
			AttributeType.DealShadowDamageEffectivenessChangeRate,
			AttributeType.Agility,
			AttributeType.EffectMastery,
			AttributeType.HealingAbsorbRate,
			AttributeType.HitRateAdjustment,
			AttributeType.DodgeRateAdjustment,
			AttributeType.Vitality,
			AttributeType.EffectHitRating,
			AttributeType.EffectResistanceRating,
			AttributeType.CritDamage,
			AttributeType.StunOnHit,
			AttributeType.ReflectiveDamage,
			AttributeType.BattleStartHeal,
			AttributeType.TurnStartHeal,
			AttributeType.Resilience,
			AttributeType.Allresistances
		};
		ItemRoot root = (!isCollector) ? ItemExtensions.WeaponRoots[itemTierLevel - 1] : ItemExtensions.ArmorRoots[itemTierLevel - 1];
		return (from a in source
		select new ItemPropertyPotential
		{
			ModificationType = ModificationType.Addition,
			AttributeType = a,
			IsGuaranteed = false,
			IsPrimary = false,
			Mean = new AttributePotentialDescriptor(a, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial).GetMean(root, AttributeGrade.Primary)
		}).ToList<ItemPropertyPotential>();
	}

	// Token: 0x06002274 RID: 8820 RVA: 0x000FC150 File Offset: 0x000FA550
	public static bool IsCollectorDevice(this ResourceType type)
	{
		List<ResourceType> source = new List<ResourceType>
		{
			ResourceType.PrismLightCharger,
			ResourceType.GhostBreathCollector,
			ResourceType.VitalEnergyContainer,
			ResourceType.SpiritBox
		};
		return source.Any((ResourceType c) => c == type);
	}

	// Token: 0x06002275 RID: 8821 RVA: 0x000FC1B0 File Offset: 0x000FA5B0
	private static Item GenerateScroll(ResourceType type, bool isStar, int itemTierLevel)
	{
		if (isStar)
		{
			GameWorld.instance.PlayerProfile.UpdateStarItemUnlocked();
		}
		List<AttributeType> list = new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate,
			AttributeType.DealDivineDamageEffectivenessChangeRate,
			AttributeType.DealFireDamageEffectivenessChangeRate,
			AttributeType.DealIceDamageEffectivenessChangeRate,
			AttributeType.DealLightningDamageEffectivenessChangeRate,
			AttributeType.DealPoisonDamageEffectivenessChangeRate,
			AttributeType.DealShadowDamageEffectivenessChangeRate,
			AttributeType.Agility,
			AttributeType.EffectMastery,
			AttributeType.HealingAbsorbRate
		};
		if (itemTierLevel > 50)
		{
			list.Add(AttributeType.HitRateAdjustment);
			list.Add(AttributeType.DodgeRateAdjustment);
		}
		if (itemTierLevel > 90)
		{
			list.AddRange(new List<AttributeType>
			{
				AttributeType.PhysicalPenetration,
				AttributeType.FirePenetration,
				AttributeType.IcePenetration,
				AttributeType.ShadowPenetration,
				AttributeType.PoisonPenetration,
				AttributeType.DivinePenetration,
				AttributeType.LighteningPenetration
			});
		}
		list.AddRange(UnitExtensions.GetAllResistances());
		ItemRoot root = ItemExtensions.ArmorRoots[itemTierLevel - 1];
		list.Shuffle<AttributeType>();
		int count = 4;
		if (isStar)
		{
			count = 7;
		}
		List<AttributeType> list2 = new List<AttributeType>
		{
			AttributeType.Vitality
		};
		list2.AddRange(list.Take(count).ToList<AttributeType>());
		List<AttributeModifier> list3 = new List<AttributeModifier>();
		foreach (AttributeType attributeType in list2)
		{
			double num = new AttributePotentialDescriptor(attributeType, AttributePowerLevel.Medium, AttributeStyle.Beneficial).GetMean(root, AttributeGrade.Secondary);
			if (attributeType == AttributeType.EffectMastery)
			{
				num = 0.8;
			}
			double value = num * (double)UnityEngine.Random.Range(0.5f, 1f);
			list3.Add(new AttributeModifier
			{
				AttributeType = attributeType,
				ModificationType = ModificationType.Addition,
				Value = value,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Gear
			});
		}
		List<ItemSocket> sockets = new List<ItemSocket>
		{
			new ItemSocket
			{
				SocketType = SocketType.All,
				Gem = new NullObject(),
				SourceType = SocketSourceType.SystemGenerated
			}
		};
		List<ISpecialEffectDataLoad> list4 = new List<ISpecialEffectDataLoad>();
		if (isStar)
		{
			list4 = ItemExtensions.GenerateScrollEffects(type);
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in list4)
		{
			GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad.GetSpecialEffectType());
		}
		Item item = new Item();
		item.ItemGrade = QualityGrade.Ancient;
		item.Value = 1000.0;
		item.Id = Guid.NewGuid().ToString();
		item.ItemStatus = ItemStatus.Reserved;
		item.Type = type;
		item.AdditionalAttributeModifiers = (from a in list3
		orderby a.AttributeType
		select a).ToList<AttributeModifier>();
		item.PrimaryAttributeModifiers = new List<AttributeModifier>();
		item.SlotType = ItemType.Scroll;
		item.Level = (int)Math.Ceiling((double)itemTierLevel / 5.0);
		item.SpecialEffects = list4;
		item.PurchasedOnTime = GameWorld.instance.PlayerProfile.GameDaysFractional;
		item.Sockets = sockets;
		item.IsStarGear = new bool?(isStar);
		item.ItemTierLevel = new int?(itemTierLevel);
		item.HasBeenEnchantedForTimes = new int?(0);
		item.AddedSpecialEffects = new List<ISpecialEffectDataLoad>();
		item.CanBeReforged = new bool?(false);
		return item;
	}

	// Token: 0x06002276 RID: 8822 RVA: 0x000FC590 File Offset: 0x000FA990
	private static List<ISpecialEffectDataLoad> GenerateScrollEffects(ResourceType type)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (type == ResourceType.ScrollOfBoorishness)
		{
			list.Add(new StrongManData
			{
				IsStar = true,
				Rate = (double)UnityEngine.Random.Range(0.4f, 0.7f)
			});
		}
		if (type == ResourceType.ScrollOfHardenedLife)
		{
			list.Add(new HardLifeData
			{
				IsStar = true,
				DamageRate = (double)UnityEngine.Random.Range(0.1f, 0.3f),
				NumberOfShields = 1
			});
		}
		if (type == ResourceType.ScrollOfElement)
		{
			List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
			list.Add(new ElementReplacementData
			{
				IsStarEf = new bool?(true),
				Type = allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]
			});
		}
		if (type == ResourceType.ScrollOfAffirmation)
		{
			list.Add(new PositiveEffectBoostData
			{
				Chance = (double)UnityEngine.Random.Range(0.6f, 1f),
				IsStar = true
			});
		}
		if (type == ResourceType.ScrollOfMasterfulness)
		{
			list.Add(new NegativeEffectBoostData
			{
				Chance = (double)UnityEngine.Random.Range(0.6f, 1f),
				IsStar = true
			});
		}
		if (type == ResourceType.ScrollOfTaunt)
		{
			list.Add(new StrongGuardData
			{
				IsStar = true,
				Seconds = UnityEngine.Random.Range(2, 5)
			});
		}
		if (type == ResourceType.ScrollOfProtection)
		{
			list.Add(new TrickyDefenceEffectData
			{
				IsStarEf = new bool?(true),
				HealRate = (double)UnityEngine.Random.Range(0.5f, 0.1f)
			});
		}
		if (type == ResourceType.ScrollOfTactics)
		{
			list.Add(new MindlessData
			{
				IsStar = true,
				CostReductionRate = (double)UnityEngine.Random.Range(0.1f, 0.3f),
				CDReductionRate = 1.0
			});
		}
		if (type == ResourceType.ScrollOfSharpness)
		{
			list.Add(new StandingKillerData
			{
				IsStar = true,
				MaxCounter = 1,
				OutputIncrease = (double)UnityEngine.Random.Range(1f, 2f)
			});
		}
		if (type == ResourceType.ScrollOfHealers)
		{
			list.Add(new HealingStrengthData
			{
				IsStar = true,
				BoostRate = (double)UnityEngine.Random.Range(0.2f, 0.4f)
			});
		}
		if (type == ResourceType.ScrollOfMindless)
		{
			list.Add(new StandingGunData
			{
				IsStar = true,
				OutputRate = (double)UnityEngine.Random.Range(0.5f, 1f),
				ResistanceBoost = (double)UnityEngine.Random.Range(0.5f, 1.5f)
			});
		}
		if (type == ResourceType.ScrollOfStrongMan)
		{
			list.Add(new StreetManEnhancementData
			{
				IsStar = true,
				ExtraHits = UnityEngine.Random.Range(2, 4),
				SuckRate = (double)UnityEngine.Random.Range(0.05f, 0.1f)
			});
		}
		if (type == ResourceType.ScrollOfArcane)
		{
			list.Add(new DrunkReaderEnhancementData
			{
				IsStar = true,
				HealRate = (double)UnityEngine.Random.Range(0.1f, 0.6f),
				CritDamageBoost = (double)UnityEngine.Random.Range(1.2f, 2.5f)
			});
		}
		if (type == ResourceType.ScrollOfArrogance)
		{
			list.Add(new ArroganceData
			{
				IsStar = true,
				HitRateBoostRate = (double)UnityEngine.Random.Range(0.2f, 0.5f),
				HitRateDeductionRate = (double)UnityEngine.Random.Range(0.05f, 0.1f)
			});
		}
		if (type == ResourceType.ScrollOfMist)
		{
			list.Add(new KillerEnhancementData
			{
				IsStar = true,
				KillerDodgeRateBoost = (double)UnityEngine.Random.Range(0.2f, 0.5f),
				PartyDodgeRateBoost = (double)UnityEngine.Random.Range(0.1f, 0.2f)
			});
		}
		if (type == ResourceType.ScrollOfFrozenHeart)
		{
			list.Add(new SnowMaideEnhancementData
			{
				IsStar = true,
				Seconds = (double)UnityEngine.Random.Range(2f, 4f)
			});
		}
		if (type == ResourceType.ScrollOfFashion)
		{
			list.Add(new FashionEnhancementData
			{
				IsStar = true,
				Extra = UnityEngine.Random.Range(1, 3)
			});
		}
		if (type == ResourceType.ScrollOfBlade)
		{
			if ((double)UnityEngine.Random.value <= 0.9)
			{
				list.Add(new RedBladeData
				{
					IsStar = true,
					BoostRate = (double)UnityEngine.Random.Range(0.4f, 0.6f)
				});
			}
			else
			{
				list.Add(new RedBladeData
				{
					IsStar = true,
					BoostRate = (double)UnityEngine.Random.Range(0.6f, 0.7f)
				});
			}
		}
		if (type == ResourceType.ScrollOfNightKiller)
		{
			list.Add(new PoisonMistBoostData
			{
				IsStar = true,
				EffectRatingBoostValue = (double)UnityEngine.Random.Range(200, 301),
				DodgeDeductionRate = (double)UnityEngine.Random.Range(0.1f, 0.15f),
				DamageBoost = (double)UnityEngine.Random.Range(1f, 1.5f)
			});
		}
		if (type == ResourceType.ScrollOfTheDead)
		{
			if ((double)UnityEngine.Random.value <= 0.9)
			{
				list.Add(new DeathBoostData
				{
					IsStar = true,
					ReviveRate = (double)UnityEngine.Random.Range(0.2f, 0.4f),
					DamageRatePerLayer = (double)UnityEngine.Random.Range(0.15f, 0.22f),
					NumberOfLayersPerDeath = 1
				});
			}
			else
			{
				list.Add(new DeathBoostData
				{
					IsStar = true,
					ReviveRate = (double)UnityEngine.Random.Range(0.4f, 0.55f),
					DamageRatePerLayer = (double)UnityEngine.Random.Range(0.22f, 0.3f),
					NumberOfLayersPerDeath = 2
				});
			}
		}
		if (type == ResourceType.ScrollOfBun)
		{
			if ((double)UnityEngine.Random.value <= 0.9)
			{
				list.Add(new BunBoostData
				{
					IsStar = true,
					DamageReflectionRate = (double)UnityEngine.Random.Range(0.5f, 0.7f),
					VitalityBoostRate = (double)UnityEngine.Random.Range(0.05f, 0.1f)
				});
			}
			else
			{
				list.Add(new BunBoostData
				{
					IsStar = true,
					DamageReflectionRate = (double)UnityEngine.Random.Range(0.7f, 0.8f),
					VitalityBoostRate = (double)UnityEngine.Random.Range(0.1f, 0.15f)
				});
			}
		}
		if (type == ResourceType.ScrollOfGhost)
		{
			list.Add(new StrengthOfTheGhostData
			{
				NumberOfDeathsSoFar = 0,
				OutputRate = (double)UnityEngine.Random.Range(1.5f, 3f),
				ResistanceRate = (double)UnityEngine.Random.Range(0.3f, 0.6f)
			});
		}
		if (type == ResourceType.ScrollOfExplosion)
		{
			list.Add(new FireChargerDoTBlastData
			{
				Chance = (double)UnityEngine.Random.Range(0.5f, 0.8f),
				AdditionalDamage = (double)UnityEngine.Random.Range(0.2f, 0.6f),
				MaxDamage = (double)(((double)UnityEngine.Random.value > 0.8) ? UnityEngine.Random.Range(55f, 60f) : UnityEngine.Random.Range(25f, 50f))
			});
		}
		if (type == ResourceType.ScrollOfSpellObsorption)
		{
			list.Add(new BurningHeartEnhancementData
			{
				ExtraTarget = UnityEngine.Random.Range(1, 4),
				HitReduction = (double)UnityEngine.Random.Range(0.05f, 0.12f)
			});
		}
		if (type == ResourceType.ScrollOfSwiftness)
		{
			list.Add(new ToughWomanSwiftnessData
			{
				Rate = (double)UnityEngine.Random.Range(0.15f, 0.4f)
			});
		}
		if (type == ResourceType.ScrollOfRage)
		{
			list.Add(new PaladinDecayEnhancementData
			{
				Rate = (double)UnityEngine.Random.Range(0.5f, 1.2f)
			});
		}
		if (type == ResourceType.ScrollOfReflection)
		{
			list.Add(new ReflectiveHealData
			{
				Rate = (double)UnityEngine.Random.Range(1f, 2f)
			});
		}
		return list;
	}

	// Token: 0x06002277 RID: 8823 RVA: 0x000FCDEC File Offset: 0x000FB1EC
	private static List<ItemSocket> SocketGenerations(ResourceType type, QualityGrade grade)
	{
		Dictionary<QualityGrade, List<GemSocketNumberPresentable>> dictionary = new Dictionary<QualityGrade, List<GemSocketNumberPresentable>>
		{
			{
				QualityGrade.Normal,
				new List<GemSocketNumberPresentable>
				{
					new GemSocketNumberPresentable(100, 0)
				}
			},
			{
				QualityGrade.Rare,
				new List<GemSocketNumberPresentable>
				{
					new GemSocketNumberPresentable(80, 0),
					new GemSocketNumberPresentable(20, 1)
				}
			},
			{
				QualityGrade.Epic,
				new List<GemSocketNumberPresentable>
				{
					new GemSocketNumberPresentable(50, 0),
					new GemSocketNumberPresentable(50, 1)
				}
			},
			{
				QualityGrade.Legendary,
				new List<GemSocketNumberPresentable>
				{
					new GemSocketNumberPresentable(80, 1),
					new GemSocketNumberPresentable(20, 2)
				}
			},
			{
				QualityGrade.Ancient,
				new List<GemSocketNumberPresentable>
				{
					new GemSocketNumberPresentable(100, 2)
				}
			}
		};
		List<ItemSocket> list = new List<ItemSocket>();
		int num = (type.GetResourceCategory() == ResourceCategory.Accessory) ? 0 : dictionary[grade].WeightedRandomSelect<GemSocketNumberPresentable>().NumberOfSockets;
		for (int i = 0; i < num; i++)
		{
			if (grade == QualityGrade.Ancient && i == 0)
			{
				list.Add(new ItemSocket
				{
					SocketType = SocketType.All,
					Gem = new NullObject(),
					SourceType = SocketSourceType.SystemGenerated
				});
			}
			else
			{
				list.Add(new ItemSocket
				{
					SocketType = SocketType.All,
					Gem = new NullObject(),
					SourceType = SocketSourceType.SystemGenerated
				});
			}
		}
		return list;
	}

	// Token: 0x06002278 RID: 8824 RVA: 0x000FCF64 File Offset: 0x000FB364
	public static int GetRawResourcePrice(this ResourceType type)
	{
		return ItemExtensions.RawResourcePrice[type];
	}

	// Token: 0x06002279 RID: 8825 RVA: 0x000FCF74 File Offset: 0x000FB374
	public static int GetInvitationPrice(this ResourceType type)
	{
		if (UnitExtensions.UnitConfigurations.Any((KeyValuePair<UnitClass, UnitConfigurationBase> c) => c.Value.CorrespondingInvitationType == type))
		{
			return UnitExtensions.UnitConfigurations.First((KeyValuePair<UnitClass, UnitConfigurationBase> c) => c.Value.CorrespondingInvitationType == type).Value.RecruitmentPriceRaw * 3;
		}
		return 5000;
	}

	// Token: 0x0600227A RID: 8826 RVA: 0x000FCFD4 File Offset: 0x000FB3D4
	public static List<Item> FilterItemsByItemCategory(this List<Item> items, ResourceCategory type)
	{
		return (from i in items
		where i.Type.GetResourceCategory() == type
		select i).ToList<Item>();
	}

	// Token: 0x0600227B RID: 8827 RVA: 0x000FD008 File Offset: 0x000FB408
	public static List<Item> GetGradedItems(this List<Item> items, List<QualityGrade> grades)
	{
		return (from i in items
		where grades.Any((QualityGrade g) => g == i.ItemGrade)
		select i).ToList<Item>();
	}

	// Token: 0x0600227C RID: 8828 RVA: 0x000FD039 File Offset: 0x000FB439
	public static bool IsMatchBuidlingType(this ResourceCategory category, BuildingType type)
	{
		if (type == BuildingType.WeaponShop)
		{
			return category.IsWeapon();
		}
		return type == BuildingType.ArmorShop && category.IsArmor();
	}

	// Token: 0x0600227D RID: 8829 RVA: 0x000FD058 File Offset: 0x000FB458
	public static List<Item> GetLevelItems(this List<Item> items, List<int> levels)
	{
		return (from i in items
		where levels.Any((int lv) => lv == i.Level)
		select i).ToList<Item>();
	}

	// Token: 0x0600227E RID: 8830 RVA: 0x000FD089 File Offset: 0x000FB489
	public static bool IsRawMaterial(this ResourceCategory category)
	{
		return category == ResourceCategory.Ore || category == ResourceCategory.Timber || category == ResourceCategory.Hides;
	}

	// Token: 0x0600227F RID: 8831 RVA: 0x000FD0A4 File Offset: 0x000FB4A4
	public static ResourceCategory GetResourceCategory(this ResourceType resource)
	{
		if (resource <= (ResourceType)0)
		{
			throw new Exception("Invalid resource type");
		}
		if (resource <= (ResourceType)10000)
		{
			return ResourceCategory.Timber;
		}
		if (resource <= (ResourceType)20000)
		{
			return ResourceCategory.Ore;
		}
		if (resource <= (ResourceType)30000)
		{
			return ResourceCategory.Hides;
		}
		if (resource <= (ResourceType)100000)
		{
			return ResourceCategory.None;
		}
		if (resource <= (ResourceType)110000)
		{
			return ResourceCategory.Sword;
		}
		if (resource <= (ResourceType)120000)
		{
			return ResourceCategory.Staff;
		}
		if (resource <= (ResourceType)130000)
		{
			return ResourceCategory.Knife;
		}
		if (resource <= (ResourceType)140000)
		{
			return ResourceCategory.Axe;
		}
		if (resource <= (ResourceType)150000)
		{
			return ResourceCategory.Spear;
		}
		if (resource <= (ResourceType)200000)
		{
			return ResourceCategory.None;
		}
		if (resource <= (ResourceType)210000)
		{
			return ResourceCategory.Robe;
		}
		if (resource <= (ResourceType)220000)
		{
			return ResourceCategory.Leather;
		}
		if (resource <= (ResourceType)230000)
		{
			return ResourceCategory.Plate;
		}
		if (resource <= (ResourceType)300000)
		{
			return ResourceCategory.None;
		}
		if (resource <= (ResourceType)400000)
		{
			return ResourceCategory.Accessory;
		}
		if (resource != ResourceType.NoneGem && resource <= (ResourceType)500000)
		{
			return ResourceCategory.Gem;
		}
		if (resource <= (ResourceType)600000)
		{
			return ResourceCategory.SkillBooks;
		}
		if (resource <= (ResourceType)700000)
		{
			return ResourceCategory.CoreResource;
		}
		if (resource <= (ResourceType)800000)
		{
			return ResourceCategory.ProductionRecipe;
		}
		if (resource <= ResourceType.MonsterInvitation)
		{
			return ResourceCategory.AdventurerInvitation;
		}
		if (resource <= (ResourceType)1000000)
		{
			return ResourceCategory.BuildingPermit;
		}
		if (resource <= (ResourceType)1100000)
		{
			return ResourceCategory.Consumable;
		}
		if (resource <= (ResourceType)1200000)
		{
			return ResourceCategory.GameItem;
		}
		if (resource <= (ResourceType)1300000)
		{
			return ResourceCategory.Usable;
		}
		if (resource <= (ResourceType)1400000)
		{
			return ResourceCategory.Scrolls;
		}
		if (resource <= (ResourceType)1500000)
		{
			return ResourceCategory.Amulet;
		}
		if (resource <= (ResourceType)1600000)
		{
			return ResourceCategory.Device;
		}
		return ResourceCategory.None;
	}

	// Token: 0x06002280 RID: 8832 RVA: 0x000FD240 File Offset: 0x000FB640
	public static bool IsMeleeWeapon(this ResourceCategory category)
	{
		return category == ResourceCategory.Sword || category == ResourceCategory.Knife || category == ResourceCategory.Axe || category == ResourceCategory.Spear;
	}

	// Token: 0x06002281 RID: 8833 RVA: 0x000FD25E File Offset: 0x000FB65E
	public static bool IsCasterWeapon(this ResourceCategory category)
	{
		return category == ResourceCategory.Staff;
	}

	// Token: 0x06002282 RID: 8834 RVA: 0x000FD264 File Offset: 0x000FB664
	public static bool IsMeleeArmor(this ResourceCategory category)
	{
		return category == ResourceCategory.Leather || category == ResourceCategory.Plate;
	}

	// Token: 0x06002283 RID: 8835 RVA: 0x000FD274 File Offset: 0x000FB674
	public static bool IsCasterArmor(this ResourceCategory type)
	{
		return type == ResourceCategory.Robe;
	}

	// Token: 0x06002284 RID: 8836 RVA: 0x000FD27A File Offset: 0x000FB67A
	public static bool IsWeapon(this ResourceCategory product)
	{
		return product == ResourceCategory.Sword || product == ResourceCategory.Knife || product == ResourceCategory.Staff || product == ResourceCategory.Spear || product == ResourceCategory.Axe;
	}

	// Token: 0x06002285 RID: 8837 RVA: 0x000FD29F File Offset: 0x000FB69F
	public static bool IsArmor(this ResourceCategory product)
	{
		return product == ResourceCategory.Robe || product == ResourceCategory.Leather || product == ResourceCategory.Plate;
	}

	// Token: 0x06002286 RID: 8838 RVA: 0x000FD2B8 File Offset: 0x000FB6B8
	public static bool IsItem(this ResourceType type)
	{
		ResourceCategory resourceCategory = type.GetResourceCategory();
		return resourceCategory.IsArmor() || resourceCategory.IsWeapon() || resourceCategory == ResourceCategory.Accessory || resourceCategory == ResourceCategory.Gem || resourceCategory == ResourceCategory.Usable || resourceCategory == ResourceCategory.Scrolls || resourceCategory == ResourceCategory.Amulet || resourceCategory == ResourceCategory.Device;
	}

	// Token: 0x06002287 RID: 8839 RVA: 0x000FD314 File Offset: 0x000FB714
	public static GenerationIntrimResult ProducePrimaryAttributesForItem(QualityGrade grade, List<ItemPropertyPotential> potentials, int totalPotentialProperties)
	{
		List<ItemPropertyPotential> potentials2 = (from p in potentials
		where p.IsPrimary
		select p).ToList<ItemPropertyPotential>();
		return ItemExtensions.GenerateProperties(grade, totalPotentialProperties, potentials2);
	}

	// Token: 0x06002288 RID: 8840 RVA: 0x000FD354 File Offset: 0x000FB754
	public static GenerationIntrimResult ProduceAdditionalAttributesForItem(QualityGrade grade, List<ItemPropertyPotential> potentials, int totalPotentialProperties)
	{
		List<ItemPropertyPotential> potentials2 = (from p in potentials
		where !p.IsPrimary
		select p).ToList<ItemPropertyPotential>();
		return ItemExtensions.GenerateProperties(grade, totalPotentialProperties, potentials2);
	}

	// Token: 0x06002289 RID: 8841 RVA: 0x000FD394 File Offset: 0x000FB794
	private static GenerationIntrimResult GenerateProperties(QualityGrade grade, int totalPotentialProperties, List<ItemPropertyPotential> potentials)
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		foreach (ItemPropertyPotential itemPropertyPotential in from p in potentials
		where p.IsGuaranteed
		select p)
		{
			double gradedAttributeValue = ItemExtensions.GetGradedAttributeValue(itemPropertyPotential.AttributeType, grade, Convert.ToSingle(itemPropertyPotential.Mean));
			AttributeModifier item = ItemExtensions.RandomGenerateAttributeModifier_ItemGeneration(Convert.ToSingle(gradedAttributeValue), itemPropertyPotential.ModificationType, itemPropertyPotential.AttributeType, itemPropertyPotential.AttributeGrade);
			list.Add(item);
		}
		int num = totalPotentialProperties;
		List<ItemPropertyPotential> list2 = (from p in potentials
		where !p.IsGuaranteed
		select p).ToList<ItemPropertyPotential>();
		while (num > 0 && list2.Any<ItemPropertyPotential>())
		{
			list2.Shuffle<ItemPropertyPotential>();
			foreach (ItemPropertyPotential itemPropertyPotential2 in list2)
			{
				if (num > 0)
				{
					double gradedAttributeValue2 = ItemExtensions.GetGradedAttributeValue(itemPropertyPotential2.AttributeType, grade, Convert.ToSingle(itemPropertyPotential2.Mean));
					AttributeModifier item2 = ItemExtensions.RandomGenerateAttributeModifier_ItemGeneration(Convert.ToSingle(gradedAttributeValue2), itemPropertyPotential2.ModificationType, itemPropertyPotential2.AttributeType, itemPropertyPotential2.AttributeGrade);
					list.Add(item2);
					num--;
				}
			}
		}
		return new GenerationIntrimResult
		{
			AttributeModifiers = list,
			UsedPotentialModifiers = totalPotentialProperties
		};
	}

	// Token: 0x0600228A RID: 8842 RVA: 0x000FD544 File Offset: 0x000FB944
	public static AttributeModifier RandomGenerateAttributeModifier_ItemGeneration(float mean, ModificationType modificationType, AttributeType attributeType, AttributeGrade grade)
	{
		if (mean >= 0f)
		{
			return new AttributeModifier
			{
				AttributeType = attributeType,
				ModificationType = modificationType,
				Value = (double)UnityEngine.Random.Range(mean * (1f - ItemExtensions.ItemAttributeRandomness_Generation), mean * (1f + ItemExtensions.ItemAttributeRandomness_Generation)),
				AttributeModifierType = AttributeModifierType.Gear,
				Key = "generation_" + grade
			};
		}
		return new AttributeModifier
		{
			AttributeType = attributeType,
			ModificationType = modificationType,
			Value = (double)UnityEngine.Random.Range(mean * (1f + ItemExtensions.ItemAttributeRandomness_Generation), mean * (1f - ItemExtensions.ItemAttributeRandomness_Generation)),
			AttributeModifierType = AttributeModifierType.Gear,
			Key = "generation_" + grade
		};
	}

	// Token: 0x0600228B RID: 8843 RVA: 0x000FD610 File Offset: 0x000FBA10
	public static AttributeModifier RandomGenerateAttributeModifier_Enchanting(float mean, ModificationType modificationType, AttributeType attributeType)
	{
		if (mean >= 0f)
		{
			return new AttributeModifier
			{
				AttributeType = attributeType,
				ModificationType = modificationType,
				Value = (double)UnityEngine.Random.Range(mean * (1f - ItemExtensions.ItemAttributeRandomness_Enchanting), mean * (1f + ItemExtensions.ItemAttributeRandomness_Enchanting)),
				AttributeModifierType = AttributeModifierType.Gear,
				Key = "enchanted"
			};
		}
		return new AttributeModifier
		{
			AttributeType = attributeType,
			ModificationType = modificationType,
			Value = (double)UnityEngine.Random.Range(mean * (1f + ItemExtensions.ItemAttributeRandomness_Enchanting), mean * (1f - ItemExtensions.ItemAttributeRandomness_Enchanting)),
			AttributeModifierType = AttributeModifierType.Gear,
			Key = "enchanted"
		};
	}

	// Token: 0x0600228C RID: 8844 RVA: 0x000FD6C4 File Offset: 0x000FBAC4
	public static AttributeModifier RandomGenerateAttributeModifier_Reforging(float mean, ModificationType modificationType, AttributeType attributeType)
	{
		if (mean >= 0f)
		{
			return new AttributeModifier
			{
				AttributeType = attributeType,
				ModificationType = modificationType,
				Value = (double)UnityEngine.Random.Range(mean * (1f - ItemExtensions.ItemAttributeRandomness_Enchanting), mean * (1f + ItemExtensions.ItemAttributeRandomness_Enchanting)),
				AttributeModifierType = AttributeModifierType.Gear,
				Key = "reforged"
			};
		}
		return new AttributeModifier
		{
			AttributeType = attributeType,
			ModificationType = modificationType,
			Value = (double)UnityEngine.Random.Range(mean * (1f + ItemExtensions.ItemAttributeRandomness_Enchanting), mean * (1f - ItemExtensions.ItemAttributeRandomness_Enchanting)),
			AttributeModifierType = AttributeModifierType.Gear,
			Key = "reforged"
		};
	}

	// Token: 0x0600228D RID: 8845 RVA: 0x000FD778 File Offset: 0x000FBB78
	public static double GetGradedAttributeValue(AttributeType type, QualityGrade grade, float value)
	{
		if (type == AttributeType.Strength || type == AttributeType.Intelligience)
		{
			if (grade == QualityGrade.Normal)
			{
				return (double)value * 0.3;
			}
			if (grade == QualityGrade.Rare)
			{
				return (double)value * 0.45;
			}
			if (grade == QualityGrade.Epic)
			{
				return (double)value * 0.6;
			}
			if (grade == QualityGrade.Legendary)
			{
				return (double)value * 0.75;
			}
			if (grade == QualityGrade.Ancient)
			{
				return (double)value * 1.0;
			}
		}
		if (type == AttributeType.Vitality || type == AttributeType.PhysicalResistance || type == AttributeType.FireResistanceResistance || type == AttributeType.ShadowResistance || type == AttributeType.IceResistance || type == AttributeType.PoisonResistance || type == AttributeType.DivineResistance || type == AttributeType.LightningResistance || type == AttributeType.Allresistances)
		{
			if (grade == QualityGrade.Normal)
			{
				return (double)value * 0.5;
			}
			if (grade == QualityGrade.Rare)
			{
				return (double)value * 0.6;
			}
			if (grade == QualityGrade.Epic)
			{
				return (double)value * 0.7;
			}
			if (grade == QualityGrade.Legendary)
			{
				return (double)value * 0.8;
			}
			if (grade == QualityGrade.Ancient)
			{
				return (double)value * 1.0;
			}
		}
		if (type == AttributeType.CritRate || type == AttributeType.Agility)
		{
			if (grade == QualityGrade.Normal)
			{
				return (double)value * 0.4;
			}
			if (grade == QualityGrade.Rare)
			{
				return (double)value * 0.55;
			}
			if (grade == QualityGrade.Epic)
			{
				return (double)value * 0.7;
			}
			if (grade == QualityGrade.Legendary)
			{
				return (double)value * 0.85;
			}
			if (grade == QualityGrade.Ancient)
			{
				return (double)value * 1.0;
			}
		}
		if (type == AttributeType.CritDamage)
		{
			if (grade == QualityGrade.Normal)
			{
				return (double)value * 0.4;
			}
			if (grade == QualityGrade.Rare)
			{
				return (double)value * 0.55;
			}
			if (grade == QualityGrade.Epic)
			{
				return (double)value * 0.7;
			}
			if (grade == QualityGrade.Legendary)
			{
				return (double)value * 0.85;
			}
			if (grade == QualityGrade.Ancient)
			{
				return (double)value * 1.0;
			}
		}
		if (!type.IsCoreAttributes())
		{
			if (grade == QualityGrade.Normal)
			{
				return (double)value * 0.4;
			}
			if (grade == QualityGrade.Rare)
			{
				return (double)value * 0.55;
			}
			if (grade == QualityGrade.Epic)
			{
				return (double)value * 0.7;
			}
			if (grade == QualityGrade.Legendary)
			{
				return (double)value * 0.85;
			}
			if (grade == QualityGrade.Ancient)
			{
				return (double)value * 1.0;
			}
		}
		throw new NotImplementedException();
	}

	// Token: 0x0600228E RID: 8846 RVA: 0x000FD9F4 File Offset: 0x000FBDF4
	// Note: this type is marked as 'beforefieldinit'.
	static ItemExtensions()
	{
	}

	// Token: 0x0600228F RID: 8847 RVA: 0x000FE6D5 File Offset: 0x000FCAD5
	[CompilerGenerated]
	private static bool <GetAllItemEffects>m__0(ResourceType i)
	{
		return i.IsGear() || i.GetResourceCategory() == ResourceCategory.Accessory || i.GetResourceCategory() == ResourceCategory.Consumable;
	}

	// Token: 0x06002290 RID: 8848 RVA: 0x000FE6FC File Offset: 0x000FCAFC
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetAllItemEffects>m__1(ResourceType i)
	{
		return i.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Ancient);
	}

	// Token: 0x06002291 RID: 8849 RVA: 0x000FE70A File Offset: 0x000FCB0A
	[CompilerGenerated]
	private static SpecialEffectType <GetAllItemEffects>m__2(ISpecialEffectDataLoad s)
	{
		return s.GetSpecialEffectType();
	}

	// Token: 0x06002292 RID: 8850 RVA: 0x000FE712 File Offset: 0x000FCB12
	[CompilerGenerated]
	private static SpecialEffectProcessBase <GetAllItemEffects>m__3(KeyValuePair<SpecialEffectType, SpecialEffectProcessBase> s)
	{
		return s.Value;
	}

	// Token: 0x06002293 RID: 8851 RVA: 0x000FE71B File Offset: 0x000FCB1B
	[CompilerGenerated]
	private static SpecialEffectType <GetAllItemEffects>m__4(SpecialEffectProcessBase p)
	{
		return p.CorrespondingEffectType;
	}

	// Token: 0x06002294 RID: 8852 RVA: 0x000FE723 File Offset: 0x000FCB23
	[CompilerGenerated]
	private static bool <GetAllItemEffects>m__5(ResourceType i)
	{
		return i.GetResourceCategory() == ResourceCategory.Scrolls;
	}

	// Token: 0x06002295 RID: 8853 RVA: 0x000FE72F File Offset: 0x000FCB2F
	[CompilerGenerated]
	private static SpecialEffectType <GetAllItemEffects>m__6(ISpecialEffectDataLoad s)
	{
		return s.GetSpecialEffectType();
	}

	// Token: 0x06002296 RID: 8854 RVA: 0x000FE737 File Offset: 0x000FCB37
	[CompilerGenerated]
	private static bool <GetAllItemEffects>m__7(ResourceType i)
	{
		return i.GetResourceCategory() == ResourceCategory.Amulet;
	}

	// Token: 0x06002297 RID: 8855 RVA: 0x000FE743 File Offset: 0x000FCB43
	[CompilerGenerated]
	private static IEnumerable<SpecialEffectType> <GetAllItemEffects>m__8(ResourceType a)
	{
		return a.GetTeamSetBase().GetPotentialEffectTypes(a.GetTeamSetBase().GetItemSuitableClassType(a));
	}

	// Token: 0x06002298 RID: 8856 RVA: 0x000FE75C File Offset: 0x000FCB5C
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetAllItemEffects>m__9(ResourceType a)
	{
		return a.GetTeamSetBase().GetTeamBonus();
	}

	// Token: 0x06002299 RID: 8857 RVA: 0x000FE769 File Offset: 0x000FCB69
	[CompilerGenerated]
	private static SpecialEffectType <GetAllItemEffects>m__A(ISpecialEffectDataLoad s)
	{
		return s.GetSpecialEffectType();
	}

	// Token: 0x0600229A RID: 8858 RVA: 0x000FE771 File Offset: 0x000FCB71
	[CompilerGenerated]
	private static SpecialEffectLocalization <GetEffectDetails>m__B(SpecialEffectType s)
	{
		return LocalizationSession.instance.LocalizationManager.GetSpecialEffectLocalization(s);
	}

	// Token: 0x0600229B RID: 8859 RVA: 0x000FE784 File Offset: 0x000FCB84
	[CompilerGenerated]
	private static SpecialEffectDetails <GetEffectDetails>m__C(SpecialEffectLocalization s)
	{
		return new SpecialEffectDetails
		{
			Type = s.SpecialEffectType,
			IsUnlocked = GameWorld.instance.PlayerProfile.IsEffectUnlocked(s.SpecialEffectType),
			Details = s.GeneralInfo
		};
	}

	// Token: 0x0600229C RID: 8860 RVA: 0x000FE7CB File Offset: 0x000FCBCB
	[CompilerGenerated]
	private static TeamSetBase <GetTeamSetType>m__D(KeyValuePair<TeamSetType, TeamSetBase> s)
	{
		return s.Value;
	}

	// Token: 0x0600229D RID: 8861 RVA: 0x000FE7D4 File Offset: 0x000FCBD4
	[CompilerGenerated]
	private static bool <MetRequirements>m__E(ResourceConsumptionRequirement r)
	{
		return GameWorld.instance.PlayerProfile.GetResourceAmount_AvaliableForProduction(r.ResourceType) >= (double)r.AmountRequired;
	}

	// Token: 0x0600229E RID: 8862 RVA: 0x000FE7F8 File Offset: 0x000FCBF8
	[CompilerGenerated]
	private static ResourceUpdate <Consume>m__F(ResourceConsumptionRequirement r)
	{
		return new ResourceUpdate
		{
			ResourceType = r.ResourceType,
			ChangeAmount = (double)(-(double)r.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x0600229F RID: 8863 RVA: 0x000FE831 File Offset: 0x000FCC31
	[CompilerGenerated]
	private static E <GetEnums<E>(E a) where E : struct, IConvertible
	{
		return a;
	}

	// Token: 0x060022A0 RID: 8864 RVA: 0x000FE834 File Offset: 0x000FCC34
	[CompilerGenerated]
	private static int <ItemGenerate>m__11(ArmoryMasteryEffect a)
	{
		return a.NumberOfAdditionalAttributes;
	}

	// Token: 0x060022A1 RID: 8865 RVA: 0x000FE83C File Offset: 0x000FCC3C
	[CompilerGenerated]
	private static SpecialEffectProcessBase <ItemGenerate>m__12(KeyValuePair<SpecialEffectType, SpecialEffectProcessBase> p)
	{
		return p.Value;
	}

	// Token: 0x060022A2 RID: 8866 RVA: 0x000FE845 File Offset: 0x000FCC45
	[CompilerGenerated]
	private static bool <ItemGenerate>m__13(SpecialEffectProcessBase v)
	{
		return v != null;
	}

	// Token: 0x060022A3 RID: 8867 RVA: 0x000FE84E File Offset: 0x000FCC4E
	[CompilerGenerated]
	private static AttributeType <ItemGenerate>m__14(AttributeModifier a)
	{
		return a.AttributeType;
	}

	// Token: 0x060022A4 RID: 8868 RVA: 0x000FE856 File Offset: 0x000FCC56
	[CompilerGenerated]
	private static AttributeType <ItemGenerate>m__15(AttributeModifier a)
	{
		return a.AttributeType;
	}

	// Token: 0x060022A5 RID: 8869 RVA: 0x000FE85E File Offset: 0x000FCC5E
	[CompilerGenerated]
	private static AttributeType <GenerateDevice>m__16(AttributeModifier a)
	{
		return a.AttributeType;
	}

	// Token: 0x060022A6 RID: 8870 RVA: 0x000FE866 File Offset: 0x000FCC66
	[CompilerGenerated]
	private static AttributeType <GenerateScroll>m__17(AttributeModifier a)
	{
		return a.AttributeType;
	}

	// Token: 0x060022A7 RID: 8871 RVA: 0x000FE86E File Offset: 0x000FCC6E
	[CompilerGenerated]
	private static bool <ProducePrimaryAttributesForItem>m__18(ItemPropertyPotential p)
	{
		return p.IsPrimary;
	}

	// Token: 0x060022A8 RID: 8872 RVA: 0x000FE876 File Offset: 0x000FCC76
	[CompilerGenerated]
	private static bool <ProduceAdditionalAttributesForItem>m__19(ItemPropertyPotential p)
	{
		return !p.IsPrimary;
	}

	// Token: 0x060022A9 RID: 8873 RVA: 0x000FE881 File Offset: 0x000FCC81
	[CompilerGenerated]
	private static bool <GenerateProperties>m__1A(ItemPropertyPotential p)
	{
		return p.IsGuaranteed;
	}

	// Token: 0x060022AA RID: 8874 RVA: 0x000FE889 File Offset: 0x000FCC89
	[CompilerGenerated]
	private static bool <GenerateProperties>m__1B(ItemPropertyPotential p)
	{
		return !p.IsGuaranteed;
	}

	// Token: 0x060022AB RID: 8875 RVA: 0x000FE894 File Offset: 0x000FCC94
	[CompilerGenerated]
	private static ResourceCategory <ItemCategoryRootDefaults>m__1C(ItemCategoryRootDefault root)
	{
		return root.Category;
	}

	// Token: 0x060022AC RID: 8876 RVA: 0x000FE89C File Offset: 0x000FCC9C
	[CompilerGenerated]
	private static SpecialEffectType <SpecialEffectProcessors>m__1D(SpecialEffectProcessBase process)
	{
		return process.CorrespondingEffectType;
	}

	// Token: 0x060022AD RID: 8877 RVA: 0x000FE8A4 File Offset: 0x000FCCA4
	[CompilerGenerated]
	private static ResourceType <SetItemLogics>m__1E(SetItemLogicBase set)
	{
		return set.CorrespondingSetResourceType;
	}

	// Token: 0x060022AE RID: 8878 RVA: 0x000FE8AC File Offset: 0x000FCCAC
	[CompilerGenerated]
	private static ResourceType <GemGenerators>m__1F(GemGeneratorBase gem)
	{
		return gem.CorrespondingGemType;
	}

	// Token: 0x04001DFB RID: 7675
	public static readonly float ItemAttributeRandomness_Generation = 0.1f;

	// Token: 0x04001DFC RID: 7676
	public static readonly float ItemAttributeRandomness_Enchanting = 0.25f;

	// Token: 0x04001DFD RID: 7677
	public static readonly int MaxGemLevel = 25;

	// Token: 0x04001DFE RID: 7678
	public static readonly List<AttributeType> AllAttributeTypes = ItemExtensions.GetEnums<AttributeType>();

	// Token: 0x04001DFF RID: 7679
	public static readonly List<ResourceType> AllResourceTypes = ItemExtensions.GetEnums<ResourceType>();

	// Token: 0x04001E00 RID: 7680
	public static readonly Dictionary<QualityGrade, int> AdditionalPropertyGradeSetting = new Dictionary<QualityGrade, int>
	{
		{
			QualityGrade.Normal,
			0
		},
		{
			QualityGrade.Rare,
			0
		},
		{
			QualityGrade.Epic,
			1
		},
		{
			QualityGrade.Legendary,
			2
		},
		{
			QualityGrade.Ancient,
			4
		}
	};

	// Token: 0x04001E01 RID: 7681
	public static readonly Dictionary<ResourceType, int> RawResourcePrice = new Dictionary<ResourceType, int>
	{
		{
			ResourceType.Wood,
			1
		},
		{
			ResourceType.Ore,
			1
		},
		{
			ResourceType.Leather,
			1
		}
	};

	// Token: 0x04001E02 RID: 7682
	public static readonly Dictionary<ResourceType, SocketType> SocketBatcherRelatedSocketType = new Dictionary<ResourceType, SocketType>
	{
		{
			ResourceType.RedSocketBatcher,
			SocketType.Red
		},
		{
			ResourceType.BlueSocketBatcher,
			SocketType.Blue
		},
		{
			ResourceType.YellowSocketBatcher,
			SocketType.Yellow
		},
		{
			ResourceType.GreenSocketBatcher,
			SocketType.Green
		},
		{
			ResourceType.AllSocketBatcher,
			SocketType.All
		}
	};

	// Token: 0x04001E03 RID: 7683
	public static List<double> RootValues = new List<double>
	{
		7.0,
		10.0,
		14.0,
		20.0,
		24.0,
		30.0,
		36.0,
		46.0,
		52.0,
		58.0,
		66.0,
		76.0,
		84.0,
		96.0,
		102.0,
		108.0,
		115.0,
		122.0,
		130.0,
		138.0,
		160.0,
		170.0,
		180.0,
		196.0,
		210.0,
		225.0,
		250.0,
		275.0,
		300.0,
		325.0,
		350.0,
		380.0,
		410.0,
		450.0,
		500.0,
		1500.0,
		1550.0,
		1600.0,
		1650.0,
		1700.0,
		1800.0,
		1850.0,
		1900.0,
		1950.0,
		2000.0,
		2100.0,
		2150.0,
		2200.0,
		2250.0,
		2300.0,
		2400.0,
		2450.0,
		2500.0,
		2550.0,
		2600.0,
		2700.0,
		2750.0,
		2800.0,
		2850.0,
		2900.0,
		3000.0,
		3050.0,
		3100.0,
		3150.0,
		3200.0,
		3300.0,
		3350.0,
		3400.0,
		3450.0,
		3500.0,
		3600.0,
		3650.0,
		3700.0,
		3750.0,
		3800.0,
		3900.0,
		3950.0,
		4000.0,
		4050.0,
		4100.0,
		4200.0,
		4250.0,
		4300.0,
		4350.0,
		4400.0,
		4500.0,
		4550.0,
		4600.0,
		4650.0,
		4700.0,
		5000.0,
		5200.0,
		5400.0,
		5600.0,
		5800.0,
		6500.0,
		6700.0,
		6900.0,
		7100.0,
		7300.0,
		7500.0,
		7700.0,
		7900.0,
		8100.0,
		8300.0,
		9000.0,
		9300.0,
		9600.0,
		9900.0,
		10200.0,
		11000.0,
		11300.0,
		11600.0,
		11900.0,
		12200.0,
		20000.0,
		20500.0,
		21000.0,
		21500.0,
		22000.0,
		24000.0,
		24500.0,
		25000.0,
		25500.0,
		26000.0
	};

	// Token: 0x04001E04 RID: 7684
	public static List<ItemRoot> WeaponRoots = ItemRoot.GenerateRoots(new List<AttributeType>
	{
		AttributeType.Strength,
		AttributeType.Intelligience,
		AttributeType.Agility,
		AttributeType.CritRate,
		AttributeType.CritDamage,
		AttributeType.LifeOnHit,
		AttributeType.TauntOnHit,
		AttributeType.StunOnHit,
		AttributeType.Mining,
		AttributeType.Logging,
		AttributeType.Hunting,
		AttributeType.DealFireDamageEffectivenessChangeRate,
		AttributeType.DealPhysicalDamageEffectivenessChangeRate,
		AttributeType.DealIceDamageEffectivenessChangeRate,
		AttributeType.DealShadowDamageEffectivenessChangeRate,
		AttributeType.DealPoisonDamageEffectivenessChangeRate,
		AttributeType.DealDivineDamageEffectivenessChangeRate,
		AttributeType.DealLightningDamageEffectivenessChangeRate,
		AttributeType.SkillRageEfficiencyRate,
		AttributeType.EffectMastery,
		AttributeType.HitRateAdjustment,
		AttributeType.EffectHitRating,
		AttributeType.PhysicalPenetration,
		AttributeType.FirePenetration,
		AttributeType.IcePenetration,
		AttributeType.ShadowPenetration,
		AttributeType.PoisonPenetration,
		AttributeType.DivinePenetration,
		AttributeType.LighteningPenetration
	}, new List<AttributeType>
	{
		AttributeType.Vitality,
		AttributeType.PhysicalResistance,
		AttributeType.FireResistanceResistance,
		AttributeType.ShadowResistance,
		AttributeType.IceResistance,
		AttributeType.PoisonResistance,
		AttributeType.DivineResistance,
		AttributeType.LightningResistance,
		AttributeType.ReflectiveDamage,
		AttributeType.BattleStartHeal,
		AttributeType.TurnStartHeal,
		AttributeType.ReceivedHealEffectivenessChangeRate,
		AttributeType.Resilience,
		AttributeType.DamageReduction,
		AttributeType.HealingAbsorbRate,
		AttributeType.DodgeRateAdjustment,
		AttributeType.Allresistances,
		AttributeType.EffectResistanceRating
	}, ItemExtensions.RootValues);

	// Token: 0x04001E05 RID: 7685
	public static List<ItemRoot> ArmorRoots = ItemRoot.GenerateRoots(new List<AttributeType>
	{
		AttributeType.Vitality,
		AttributeType.Agility,
		AttributeType.PhysicalResistance,
		AttributeType.FireResistanceResistance,
		AttributeType.ShadowResistance,
		AttributeType.IceResistance,
		AttributeType.PoisonResistance,
		AttributeType.DivineResistance,
		AttributeType.LightningResistance,
		AttributeType.ReflectiveDamage,
		AttributeType.BattleStartHeal,
		AttributeType.TurnStartHeal,
		AttributeType.Resilience,
		AttributeType.DamageReduction,
		AttributeType.HealingAbsorbRate,
		AttributeType.DodgeRateAdjustment,
		AttributeType.Allresistances,
		AttributeType.EffectResistanceRating
	}, new List<AttributeType>
	{
		AttributeType.Strength,
		AttributeType.Intelligience,
		AttributeType.CritRate,
		AttributeType.CritDamage,
		AttributeType.LifeOnHit,
		AttributeType.TauntOnHit,
		AttributeType.StunOnHit,
		AttributeType.Mining,
		AttributeType.Logging,
		AttributeType.Hunting,
		AttributeType.ReceivedHealEffectivenessChangeRate,
		AttributeType.DealFireDamageEffectivenessChangeRate,
		AttributeType.DealPhysicalDamageEffectivenessChangeRate,
		AttributeType.DealIceDamageEffectivenessChangeRate,
		AttributeType.DealShadowDamageEffectivenessChangeRate,
		AttributeType.DealPoisonDamageEffectivenessChangeRate,
		AttributeType.DealDivineDamageEffectivenessChangeRate,
		AttributeType.DealLightningDamageEffectivenessChangeRate,
		AttributeType.SkillRageEfficiencyRate,
		AttributeType.EffectMastery,
		AttributeType.HitRateAdjustment,
		AttributeType.EffectHitRating,
		AttributeType.PhysicalPenetration,
		AttributeType.FirePenetration,
		AttributeType.IcePenetration,
		AttributeType.ShadowPenetration,
		AttributeType.PoisonPenetration,
		AttributeType.DivinePenetration,
		AttributeType.LighteningPenetration
	}, ItemExtensions.RootValues);

	// Token: 0x04001E06 RID: 7686
	public static Dictionary<ResourceCategory, ItemCategoryRootDefault> ItemCategoryRootDefaults = ItemExtensions.GetDictionaryOfAbastract<ResourceCategory, ItemCategoryRootDefault>((ItemCategoryRootDefault root) => root.Category);

	// Token: 0x04001E07 RID: 7687
	public static Dictionary<SpecialEffectType, SpecialEffectProcessBase> SpecialEffectProcessors = ItemExtensions.GetDictionaryOfAbastract<SpecialEffectType, SpecialEffectProcessBase>((SpecialEffectProcessBase process) => process.CorrespondingEffectType);

	// Token: 0x04001E08 RID: 7688
	public static Dictionary<ResourceType, SetItemLogicBase> SetItemLogics = ItemExtensions.GetDictionaryOfAbastract<ResourceType, SetItemLogicBase>((SetItemLogicBase set) => set.CorrespondingSetResourceType);

	// Token: 0x04001E09 RID: 7689
	public static Dictionary<ResourceType, GemGeneratorBase> GemGenerators = ItemExtensions.GetDictionaryOfAbastract<ResourceType, GemGeneratorBase>((GemGeneratorBase gem) => gem.CorrespondingGemType);

	// Token: 0x04001E0A RID: 7690
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>> <>f__mg$cache0;

	// Token: 0x04001E0B RID: 7691
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache0;

	// Token: 0x04001E0C RID: 7692
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache1;

	// Token: 0x04001E0D RID: 7693
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, SpecialEffectType> <>f__am$cache2;

	// Token: 0x04001E0E RID: 7694
	[CompilerGenerated]
	private static Func<KeyValuePair<SpecialEffectType, SpecialEffectProcessBase>, SpecialEffectProcessBase> <>f__am$cache3;

	// Token: 0x04001E0F RID: 7695
	[CompilerGenerated]
	private static Func<SpecialEffectProcessBase, SpecialEffectType> <>f__am$cache4;

	// Token: 0x04001E10 RID: 7696
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache5;

	// Token: 0x04001E11 RID: 7697
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, SpecialEffectType> <>f__am$cache6;

	// Token: 0x04001E12 RID: 7698
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache7;

	// Token: 0x04001E13 RID: 7699
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<SpecialEffectType>> <>f__am$cache8;

	// Token: 0x04001E14 RID: 7700
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache9;

	// Token: 0x04001E15 RID: 7701
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, SpecialEffectType> <>f__am$cacheA;

	// Token: 0x04001E16 RID: 7702
	[CompilerGenerated]
	private static Func<SpecialEffectType, SpecialEffectLocalization> <>f__am$cacheB;

	// Token: 0x04001E17 RID: 7703
	[CompilerGenerated]
	private static Func<SpecialEffectLocalization, SpecialEffectDetails> <>f__am$cacheC;

	// Token: 0x04001E18 RID: 7704
	[CompilerGenerated]
	private static Func<KeyValuePair<TeamSetType, TeamSetBase>, TeamSetBase> <>f__am$cacheD;

	// Token: 0x04001E19 RID: 7705
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, bool> <>f__am$cacheE;

	// Token: 0x04001E1A RID: 7706
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cacheF;

	// Token: 0x04001E1B RID: 7707
	[CompilerGenerated]
	private static Func<ArmoryMasteryEffect, int> <>f__am$cache10;

	// Token: 0x04001E1C RID: 7708
	[CompilerGenerated]
	private static Func<KeyValuePair<SpecialEffectType, SpecialEffectProcessBase>, SpecialEffectProcessBase> <>f__am$cache11;

	// Token: 0x04001E1D RID: 7709
	[CompilerGenerated]
	private static Func<SpecialEffectProcessBase, bool> <>f__am$cache12;

	// Token: 0x04001E1E RID: 7710
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeType> <>f__am$cache13;

	// Token: 0x04001E1F RID: 7711
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeType> <>f__am$cache14;

	// Token: 0x04001E20 RID: 7712
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeType> <>f__am$cache15;

	// Token: 0x04001E21 RID: 7713
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeType> <>f__am$cache16;

	// Token: 0x04001E22 RID: 7714
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, bool> <>f__am$cache17;

	// Token: 0x04001E23 RID: 7715
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, bool> <>f__am$cache18;

	// Token: 0x04001E24 RID: 7716
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, bool> <>f__am$cache19;

	// Token: 0x04001E25 RID: 7717
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, bool> <>f__am$cache1A;

	// Token: 0x02000D6F RID: 3439
	[CompilerGenerated]
	private sealed class <GetAllItemEffects>c__AnonStorey0
	{
		// Token: 0x060057C1 RID: 22465 RVA: 0x000FE8B4 File Offset: 0x000FCCB4
		public <GetAllItemEffects>c__AnonStorey0()
		{
		}

		// Token: 0x060057C2 RID: 22466 RVA: 0x000FE8BC File Offset: 0x000FCCBC
		internal bool <>m__0(SpecialEffectProcessBase p)
		{
			return this.allItemTypes.Any((ResourceType a) => p.CanBeStarEffects(90, a, QualityGrade.Ancient) || p.CanBeRandomSpecialEffects(90, a, QualityGrade.Ancient));
		}

		// Token: 0x0400478E RID: 18318
		internal List<ResourceType> allItemTypes;

		// Token: 0x02000D7C RID: 3452
		private sealed class <GetAllItemEffects>c__AnonStorey1
		{
			// Token: 0x060057DE RID: 22494 RVA: 0x000FE8F4 File Offset: 0x000FCCF4
			public <GetAllItemEffects>c__AnonStorey1()
			{
			}

			// Token: 0x060057DF RID: 22495 RVA: 0x000FE8FC File Offset: 0x000FCCFC
			internal bool <>m__0(ResourceType a)
			{
				return this.p.CanBeStarEffects(90, a, QualityGrade.Ancient) || this.p.CanBeRandomSpecialEffects(90, a, QualityGrade.Ancient);
			}

			// Token: 0x0400479E RID: 18334
			internal SpecialEffectProcessBase p;

			// Token: 0x0400479F RID: 18335
			internal ItemExtensions.<GetAllItemEffects>c__AnonStorey0 <>f__ref$0;
		}
	}

	// Token: 0x02000D70 RID: 3440
	[CompilerGenerated]
	private sealed class <GetTeamSetType>c__AnonStorey2
	{
		// Token: 0x060057C3 RID: 22467 RVA: 0x000FE924 File Offset: 0x000FCD24
		public <GetTeamSetType>c__AnonStorey2()
		{
		}

		// Token: 0x060057C4 RID: 22468 RVA: 0x000FE92C File Offset: 0x000FCD2C
		internal bool <>m__0(TeamSetBase t)
		{
			return t.TeamSetPieces.Any((ResourceType p) => p == this.rtype);
		}

		// Token: 0x060057C5 RID: 22469 RVA: 0x000FE945 File Offset: 0x000FCD45
		internal bool <>m__1(ResourceType p)
		{
			return p == this.rtype;
		}

		// Token: 0x0400478F RID: 18319
		internal ResourceType rtype;
	}

	// Token: 0x02000D71 RID: 3441
	[CompilerGenerated]
	private sealed class <GetRecipeByProductType>c__AnonStorey3
	{
		// Token: 0x060057C6 RID: 22470 RVA: 0x000FE950 File Offset: 0x000FCD50
		public <GetRecipeByProductType>c__AnonStorey3()
		{
		}

		// Token: 0x060057C7 RID: 22471 RVA: 0x000FE958 File Offset: 0x000FCD58
		internal bool <>m__0(Recipe r)
		{
			return r.ProductType == this.productType;
		}

		// Token: 0x04004790 RID: 18320
		internal ResourceType productType;
	}

	// Token: 0x02000D72 RID: 3442
	[CompilerGenerated]
	private sealed class <GetRecipeByRecipeName>c__AnonStorey4
	{
		// Token: 0x060057C8 RID: 22472 RVA: 0x000FE968 File Offset: 0x000FCD68
		public <GetRecipeByRecipeName>c__AnonStorey4()
		{
		}

		// Token: 0x060057C9 RID: 22473 RVA: 0x000FE970 File Offset: 0x000FCD70
		internal bool <>m__0(Recipe r)
		{
			return r.RecipeName == this.recipeName;
		}

		// Token: 0x04004791 RID: 18321
		internal ResourceType recipeName;
	}

	// Token: 0x02000D73 RID: 3443
	[CompilerGenerated]
	private sealed class <IsUpgradeableAttribute>c__AnonStorey5
	{
		// Token: 0x060057CA RID: 22474 RVA: 0x000FE980 File Offset: 0x000FCD80
		public <IsUpgradeableAttribute>c__AnonStorey5()
		{
		}

		// Token: 0x060057CB RID: 22475 RVA: 0x000FE988 File Offset: 0x000FCD88
		internal bool <>m__0(AttributeType a)
		{
			return a == this.type;
		}

		// Token: 0x04004792 RID: 18322
		internal AttributeType type;
	}

	// Token: 0x02000D74 RID: 3444
	[CompilerGenerated]
	private sealed class <GetInvitationRelatedUnitClass>c__AnonStorey6
	{
		// Token: 0x060057CC RID: 22476 RVA: 0x000FE993 File Offset: 0x000FCD93
		public <GetInvitationRelatedUnitClass>c__AnonStorey6()
		{
		}

		// Token: 0x060057CD RID: 22477 RVA: 0x000FE99B File Offset: 0x000FCD9B
		internal bool <>m__0(KeyValuePair<UnitClass, UnitConfigurationBase> u)
		{
			return u.Value != null && u.Value.CorrespondingInvitationType == this.type;
		}

		// Token: 0x04004793 RID: 18323
		internal ResourceType type;
	}

	// Token: 0x02000D75 RID: 3445
	[CompilerGenerated]
	private sealed class <ItemGenerate>c__AnonStorey7
	{
		// Token: 0x060057CE RID: 22478 RVA: 0x000FE9C0 File Offset: 0x000FCDC0
		public <ItemGenerate>c__AnonStorey7()
		{
		}

		// Token: 0x060057CF RID: 22479 RVA: 0x000FE9C8 File Offset: 0x000FCDC8
		internal bool <>m__0(SpecialEffectProcessBase p)
		{
			return p.CanBeRandomSpecialEffects(this.itemTier, this.type, this.grade);
		}

		// Token: 0x060057D0 RID: 22480 RVA: 0x000FE9E2 File Offset: 0x000FCDE2
		internal bool <>m__1(SpecialEffectProcessBase p)
		{
			return p.CanBeStarEffects(this.itemTierLevel, this.type, this.grade);
		}

		// Token: 0x04004794 RID: 18324
		internal int itemTier;

		// Token: 0x04004795 RID: 18325
		internal ResourceType type;

		// Token: 0x04004796 RID: 18326
		internal QualityGrade grade;

		// Token: 0x04004797 RID: 18327
		internal int itemTierLevel;
	}

	// Token: 0x02000D76 RID: 3446
	[CompilerGenerated]
	private sealed class <GetDevicePotentialAttributes>c__AnonStorey8
	{
		// Token: 0x060057D1 RID: 22481 RVA: 0x000FE9FC File Offset: 0x000FCDFC
		public <GetDevicePotentialAttributes>c__AnonStorey8()
		{
		}

		// Token: 0x060057D2 RID: 22482 RVA: 0x000FEA04 File Offset: 0x000FCE04
		internal ItemPropertyPotential <>m__0(AttributeType a)
		{
			return new ItemPropertyPotential
			{
				ModificationType = ModificationType.Addition,
				AttributeType = a,
				IsGuaranteed = false,
				IsPrimary = false,
				Mean = new AttributePotentialDescriptor(a, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial).GetMean(this.root, AttributeGrade.Primary)
			};
		}

		// Token: 0x04004798 RID: 18328
		internal ItemRoot root;
	}

	// Token: 0x02000D77 RID: 3447
	[CompilerGenerated]
	private sealed class <IsCollectorDevice>c__AnonStorey9
	{
		// Token: 0x060057D3 RID: 22483 RVA: 0x000FEA4E File Offset: 0x000FCE4E
		public <IsCollectorDevice>c__AnonStorey9()
		{
		}

		// Token: 0x060057D4 RID: 22484 RVA: 0x000FEA56 File Offset: 0x000FCE56
		internal bool <>m__0(ResourceType c)
		{
			return c == this.type;
		}

		// Token: 0x04004799 RID: 18329
		internal ResourceType type;
	}

	// Token: 0x02000D78 RID: 3448
	[CompilerGenerated]
	private sealed class <GetInvitationPrice>c__AnonStoreyA
	{
		// Token: 0x060057D5 RID: 22485 RVA: 0x000FEA61 File Offset: 0x000FCE61
		public <GetInvitationPrice>c__AnonStoreyA()
		{
		}

		// Token: 0x060057D6 RID: 22486 RVA: 0x000FEA69 File Offset: 0x000FCE69
		internal bool <>m__0(KeyValuePair<UnitClass, UnitConfigurationBase> c)
		{
			return c.Value.CorrespondingInvitationType == this.type;
		}

		// Token: 0x060057D7 RID: 22487 RVA: 0x000FEA7F File Offset: 0x000FCE7F
		internal bool <>m__1(KeyValuePair<UnitClass, UnitConfigurationBase> c)
		{
			return c.Value.CorrespondingInvitationType == this.type;
		}

		// Token: 0x0400479A RID: 18330
		internal ResourceType type;
	}

	// Token: 0x02000D79 RID: 3449
	[CompilerGenerated]
	private sealed class <FilterItemsByItemCategory>c__AnonStoreyB
	{
		// Token: 0x060057D8 RID: 22488 RVA: 0x000FEA95 File Offset: 0x000FCE95
		public <FilterItemsByItemCategory>c__AnonStoreyB()
		{
		}

		// Token: 0x060057D9 RID: 22489 RVA: 0x000FEA9D File Offset: 0x000FCE9D
		internal bool <>m__0(Item i)
		{
			return i.Type.GetResourceCategory() == this.type;
		}

		// Token: 0x0400479B RID: 18331
		internal ResourceCategory type;
	}

	// Token: 0x02000D7A RID: 3450
	[CompilerGenerated]
	private sealed class <GetGradedItems>c__AnonStoreyC
	{
		// Token: 0x060057DA RID: 22490 RVA: 0x000FEAB2 File Offset: 0x000FCEB2
		public <GetGradedItems>c__AnonStoreyC()
		{
		}

		// Token: 0x060057DB RID: 22491 RVA: 0x000FEABC File Offset: 0x000FCEBC
		internal bool <>m__0(Item i)
		{
			return this.grades.Any((QualityGrade g) => g == i.ItemGrade);
		}

		// Token: 0x0400479C RID: 18332
		internal List<QualityGrade> grades;

		// Token: 0x02000D7D RID: 3453
		private sealed class <GetGradedItems>c__AnonStoreyD
		{
			// Token: 0x060057E0 RID: 22496 RVA: 0x000FEAF4 File Offset: 0x000FCEF4
			public <GetGradedItems>c__AnonStoreyD()
			{
			}

			// Token: 0x060057E1 RID: 22497 RVA: 0x000FEAFC File Offset: 0x000FCEFC
			internal bool <>m__0(QualityGrade g)
			{
				return g == this.i.ItemGrade;
			}

			// Token: 0x040047A0 RID: 18336
			internal Item i;

			// Token: 0x040047A1 RID: 18337
			internal ItemExtensions.<GetGradedItems>c__AnonStoreyC <>f__ref$12;
		}
	}

	// Token: 0x02000D7B RID: 3451
	[CompilerGenerated]
	private sealed class <GetLevelItems>c__AnonStoreyE
	{
		// Token: 0x060057DC RID: 22492 RVA: 0x000FEB0C File Offset: 0x000FCF0C
		public <GetLevelItems>c__AnonStoreyE()
		{
		}

		// Token: 0x060057DD RID: 22493 RVA: 0x000FEB14 File Offset: 0x000FCF14
		internal bool <>m__0(Item i)
		{
			return this.levels.Any((int lv) => lv == i.Level);
		}

		// Token: 0x0400479D RID: 18333
		internal List<int> levels;

		// Token: 0x02000D7E RID: 3454
		private sealed class <GetLevelItems>c__AnonStoreyF
		{
			// Token: 0x060057E2 RID: 22498 RVA: 0x000FEB4C File Offset: 0x000FCF4C
			public <GetLevelItems>c__AnonStoreyF()
			{
			}

			// Token: 0x060057E3 RID: 22499 RVA: 0x000FEB54 File Offset: 0x000FCF54
			internal bool <>m__0(int lv)
			{
				return lv == this.i.Level;
			}

			// Token: 0x040047A2 RID: 18338
			internal Item i;

			// Token: 0x040047A3 RID: 18339
			internal ItemExtensions.<GetLevelItems>c__AnonStoreyE <>f__ref$14;
		}
	}
}
