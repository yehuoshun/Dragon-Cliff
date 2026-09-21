using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200067C RID: 1660
[Serializable]
public class Item : NullableObject
{
	// Token: 0x06002C2C RID: 11308 RVA: 0x001217B3 File Offset: 0x0011FBB3
	public Item()
	{
	}

	// Token: 0x06002C2D RID: 11309 RVA: 0x001217BC File Offset: 0x0011FBBC
	public AdventurerProfile GetOwner()
	{
		if (string.IsNullOrEmpty(this.OwnerId))
		{
			return null;
		}
		if (Item.CachedItemOwnerDictionary.ContainsKey(this.Id))
		{
			return Item.CachedItemOwnerDictionary[this.Id];
		}
		AdventurerProfile adventurerProfile = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.Id == this.OwnerId);
		if (adventurerProfile != null)
		{
			Item.CachedItemOwnerDictionary[this.Id] = adventurerProfile;
		}
		return adventurerProfile;
	}

	// Token: 0x06002C2E RID: 11310 RVA: 0x0012183C File Offset: 0x0011FC3C
	public void SetOwner(AdventurerProfile profile)
	{
		if (profile == null)
		{
			this.OwnerId = null;
			Item.CachedItemOwnerDictionary.Remove(this.Id);
		}
		else
		{
			this.OwnerId = profile.Id;
			Item.CachedItemOwnerDictionary[this.Id] = profile;
		}
	}

	// Token: 0x06002C2F RID: 11311 RVA: 0x00121889 File Offset: 0x0011FC89
	public void StartEnchantingGenerationScope()
	{
		if (this.EnchantingSeed == null)
		{
			this.EnchantingSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
		}
		UnityEngine.Random.InitState(this.EnchantingSeed.Value);
	}

	// Token: 0x06002C30 RID: 11312 RVA: 0x001218C1 File Offset: 0x0011FCC1
	public void RotateEnchantingGeneration()
	{
		UnityEngine.Random.InitState(this.EnchantingSeed.Value);
		this.EnchantingSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
	}

	// Token: 0x06002C31 RID: 11313 RVA: 0x001218E9 File Offset: 0x0011FCE9
	public void StartReforgeGenerationScope()
	{
		if (this.ReforgeSeed == null)
		{
			this.ReforgeSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
		}
		UnityEngine.Random.InitState(this.ReforgeSeed.Value);
	}

	// Token: 0x06002C32 RID: 11314 RVA: 0x00121921 File Offset: 0x0011FD21
	public void RotateReforgeGeneration()
	{
		UnityEngine.Random.InitState(this.ReforgeSeed.Value);
		this.ReforgeSeed = new int?(UnityEngine.Random.Range(0, int.MaxValue));
	}

	// Token: 0x06002C33 RID: 11315 RVA: 0x0012194C File Offset: 0x0011FD4C
	public List<List<ISpecialEffectDataLoad>> GetEnchantableEffects()
	{
		ResourceCategory resourceCategory = this.Type.GetResourceCategory();
		if (resourceCategory.IsWeapon() || resourceCategory.IsArmor())
		{
			List<List<ISpecialEffectDataLoad>> list = new List<List<ISpecialEffectDataLoad>>();
			if ((from s in this.GetSpecialEffects()
			where s.IsStarEffect()
			select s).Any<ISpecialEffectDataLoad>())
			{
				list.Add((from s in this.GetSpecialEffects()
				where s.IsStarEffect()
				select s).ToList<ISpecialEffectDataLoad>());
			}
			if ((from s in this.GetSpecialEffects()
			where !s.IsStarEffect()
			select s).Any<ISpecialEffectDataLoad>())
			{
				list.Add((from s in this.GetSpecialEffects()
				where !s.IsStarEffect()
				select s).ToList<ISpecialEffectDataLoad>());
			}
			return list;
		}
		return new List<List<ISpecialEffectDataLoad>>();
	}

	// Token: 0x06002C34 RID: 11316 RVA: 0x00121A54 File Offset: 0x0011FE54
	public List<ResourceConsumptionRequirement> GetEffectEnchantingCost()
	{
		if (this.Type.GetResourceCategory() == ResourceCategory.Scrolls)
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.BookFragments,
					AmountRequired = 50
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.FragmentOfDemon,
					AmountRequired = 20
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.InfusedPowder,
					AmountRequired = 20
				}
			};
		}
		if ((this.Type.GetResourceCategory().IsWeapon() || this.Type.GetResourceCategory().IsArmor()) && this.Level > 7)
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.BookFragments,
					AmountRequired = 100 * (this.Level - 7)
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.FragmentOfDemon,
					AmountRequired = 5 * (this.Level - 7)
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.InfusedPowder,
					AmountRequired = 10 * (this.Level - 7)
				}
			};
		}
		return new List<ResourceConsumptionRequirement>();
	}

	// Token: 0x06002C35 RID: 11317 RVA: 0x00121B98 File Offset: 0x0011FF98
	public bool IsEffectReplacementUsable()
	{
		return (this.Type.GetResourceCategory().IsWeapon() || this.Type.GetResourceCategory().IsArmor()) && this.Level > 7;
	}

	// Token: 0x06002C36 RID: 11318 RVA: 0x00121BD0 File Offset: 0x0011FFD0
	public void EnchantEffectForScroll(Item anotherItem, List<ISpecialEffectDataLoad> effects)
	{
		if (this.Type.GetResourceCategory() == ResourceCategory.Scrolls && anotherItem.Level >= 8 && (anotherItem.Type.GetResourceCategory().IsWeapon() || anotherItem.Type.GetResourceCategory().IsArmor()) && this.GetEffectEnchantingCost().MetRequirements())
		{
			if (effects.All((ISpecialEffectDataLoad ef) => anotherItem.GetSpecialEffects().Any((ISpecialEffectDataLoad ane) => ane == ef)))
			{
				List<ResourceUpdate> list = (from c in this.GetEffectEnchantingCost()
				select new ResourceUpdate
				{
					ResourceType = c.ResourceType,
					ChangeAmount = (double)(-(double)c.AmountRequired),
					RelatedItems = new List<Item>()
				}).ToList<ResourceUpdate>();
				list.Add(new ResourceUpdate
				{
					ResourceType = anotherItem.Type,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>
					{
						anotherItem
					}
				});
				this.AddedSpecialEffects = effects;
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
			}
		}
		else if (this.IsEffectReplacementUsable() && anotherItem.IsEffectReplacementUsable() && this.GetEffectEnchantingCost().MetRequirements() && effects.All((ISpecialEffectDataLoad ef) => anotherItem.GetSpecialEffects().Any((ISpecialEffectDataLoad ane) => ane == ef)))
		{
			List<ResourceUpdate> list2 = (from c in this.GetEffectEnchantingCost()
			select new ResourceUpdate
			{
				ResourceType = c.ResourceType,
				ChangeAmount = (double)(-(double)c.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			list2.Add(new ResourceUpdate
			{
				ResourceType = anotherItem.Type,
				ChangeAmount = -1.0,
				RelatedItems = new List<Item>
				{
					anotherItem
				}
			});
			if (effects.Any((ISpecialEffectDataLoad e) => e.IsStarEffect()))
			{
				this.SpecialEffects.RemoveAll((ISpecialEffectDataLoad e) => e.IsStarEffect());
				this.IsStarGear = new bool?(true);
			}
			else
			{
				this.SpecialEffects.RemoveAll((ISpecialEffectDataLoad e) => !e.IsStarEffect());
			}
			this.SpecialEffects.AddRange(effects);
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
		}
	}

	// Token: 0x06002C37 RID: 11319 RVA: 0x00121E58 File Offset: 0x00120258
	public List<ISpecialEffectDataLoad> GetSpecialEffects()
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (this.SpecialEffects != null)
		{
			list.AddRange(this.SpecialEffects);
		}
		if (this.AddedSpecialEffects != null && this.AddedSpecialEffects.Any<ISpecialEffectDataLoad>())
		{
			list.AddRange(this.AddedSpecialEffects);
		}
		return list;
	}

	// Token: 0x06002C38 RID: 11320 RVA: 0x00121EAA File Offset: 0x001202AA
	public int GetItemTierLevel()
	{
		if (this.ItemTierLevel == null)
		{
			this.ItemTierLevel = new int?(this.Level * 5 - 4);
		}
		return this.ItemTierLevel.Value;
	}

	// Token: 0x06002C39 RID: 11321 RVA: 0x00121EDC File Offset: 0x001202DC
	public DifficultyLevelMeasurement GetProducedDifficultyMeasurement()
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.ProducedOnDifficultyValue.GetValueOrDefault(), this.GetGeneratedOnStarRating());
	}

	// Token: 0x06002C3A RID: 11322 RVA: 0x00121EF4 File Offset: 0x001202F4
	public List<ItemPropertyPotential> GetEnchantableAttributes()
	{
		ResourceCategory resourceCategory = this.Type.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Device)
		{
			return ItemExtensions.GetDevicePotentialAttributes(this.GetItemTierLevel(), this.Type.IsCollectorDevice());
		}
		return this.Type.GetCreationTemplate().GetEnchantableAttributePotentials(this.GetItemTierLevel());
	}

	// Token: 0x06002C3B RID: 11323 RVA: 0x00121F44 File Offset: 0x00120344
	public List<ItemPropertyPotential> GetReforgePotentialAttributes()
	{
		ResourceCategory resourceCategory = this.Type.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Device)
		{
			return ItemExtensions.GetDevicePotentialAttributes(this.GetItemTierLevel(), this.Type.IsCollectorDevice());
		}
		return this.Type.GetCreationTemplate().GetEnchantableAttributePotentials(this.GetItemTierLevel());
	}

	// Token: 0x06002C3C RID: 11324 RVA: 0x00121F94 File Offset: 0x00120394
	public List<AttributeModifier> GetReforgeableAttributes()
	{
		if (this.AdditionalAttributeModifiers.Any((AttributeModifier a) => a.IsReforged()))
		{
			return (from a in this.AdditionalAttributeModifiers
			where a.IsReforged()
			select a).ToList<AttributeModifier>();
		}
		return (from a in this.AdditionalAttributeModifiers
		where a.Key == "generation_Secondary"
		select a).ToList<AttributeModifier>();
	}

	// Token: 0x06002C3D RID: 11325 RVA: 0x0012202C File Offset: 0x0012042C
	public List<AttributeModifier> Reforging()
	{
		if (this.IsReforgeable() && this.GetReforgingCost().MetRequirements())
		{
			this.StartReforgeGenerationScope();
			List<ResourceUpdate> changes = (from s in this.GetReforgingCost()
			select new ResourceUpdate
			{
				ResourceType = s.ResourceType,
				ChangeAmount = (double)(-(double)s.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			List<ItemPropertyPotential> reforgePotentialAttributes = this.GetReforgePotentialAttributes();
			this.HasBeenReforgedForTimes = new int?(this.GetNumberOfReforgedTimes() + 1);
			List<AttributeModifier> list = new List<AttributeModifier>();
			for (int i = 0; i < 3; i++)
			{
				ItemPropertyPotential itemPropertyPotential = reforgePotentialAttributes[UnityEngine.Random.Range(0, reforgePotentialAttributes.Count)];
				list.Add(ItemExtensions.RandomGenerateAttributeModifier_Reforging(Convert.ToSingle(itemPropertyPotential.Mean), itemPropertyPotential.ModificationType, itemPropertyPotential.AttributeType));
			}
			this.CurrentReforgeAttributeSelections = list;
			this.RotateReforgeGeneration();
			return list;
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x06002C3E RID: 11326 RVA: 0x00122118 File Offset: 0x00120518
	public List<List<AttributeModifier>> Enchanting()
	{
		if (this.IsEnchantable() && this.GetEnchantingCost().MetRequirements())
		{
			this.StartEnchantingGenerationScope();
			List<ResourceUpdate> changes = (from c in this.GetEnchantingCost()
			select new ResourceUpdate
			{
				ResourceType = c.ResourceType,
				ChangeAmount = (double)(-(double)c.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			List<ItemPropertyPotential> enchantableAttributes = this.GetEnchantableAttributes();
			this.HasBeenEnchantedForTimes = new int?(this.GetNumberOfEnchantedTimes() + 1);
			int count = (!this.IsStarItem()) ? 1 : 2;
			List<List<AttributeModifier>> list = new List<List<AttributeModifier>>();
			for (int i = 0; i < 3; i++)
			{
				enchantableAttributes.Shuffle<ItemPropertyPotential>();
				List<ItemPropertyPotential> source = enchantableAttributes.Take(count).ToList<ItemPropertyPotential>();
				list.Add((from p in source
				select ItemExtensions.RandomGenerateAttributeModifier_Enchanting(Convert.ToSingle(p.Mean), p.ModificationType, p.AttributeType)).ToList<AttributeModifier>());
			}
			this.CurrentEnchantedAttributeSelections = list;
			this.RotateEnchantingGeneration();
			return list;
		}
		return new List<List<AttributeModifier>>();
	}

	// Token: 0x06002C3F RID: 11327 RVA: 0x00122224 File Offset: 0x00120624
	public bool IsReforgeable()
	{
		return (this.Type.GetResourceCategory().IsWeapon() || this.Type.GetResourceCategory().IsArmor() || this.Type.GetResourceCategory() == ResourceCategory.Device) && this.GetReforgePotentialAttributes().Any<ItemPropertyPotential>();
	}

	// Token: 0x06002C40 RID: 11328 RVA: 0x0012227B File Offset: 0x0012067B
	public bool IsReforgeable_quick()
	{
		return this.CanBeReforged != null && this.CanBeReforged.Value;
	}

	// Token: 0x06002C41 RID: 11329 RVA: 0x0012229C File Offset: 0x0012069C
	public void SelectAttributesForEnchanting(List<AttributeModifier> selected, bool recalculateRating)
	{
		if (this.CurrentEnchantedAttributeSelections != null && this.CurrentEnchantedAttributeSelections.Any((List<AttributeModifier> s) => s == selected))
		{
			List<AttributeModifier> list = (from a in this.AdditionalAttributeModifiers
			where a.Key == "enchanted"
			select a).ToList<AttributeModifier>();
			foreach (AttributeModifier item in list)
			{
				this.AdditionalAttributeModifiers.Remove(item);
			}
			this.AdditionalAttributeModifiers.AddRange(selected);
			if (recalculateRating)
			{
				this.CalculateQualityRatingsAndCacheAttributes();
			}
		}
	}

	// Token: 0x06002C42 RID: 11330 RVA: 0x00122378 File Offset: 0x00120778
	public void SelectAttributeForReforging(AttributeModifier selected, AttributeModifier toreplace, bool recalculateRating)
	{
		if (this.CurrentReforgeAttributeSelections != null && this.CurrentReforgeAttributeSelections.Any((AttributeModifier s) => s == selected) && this.GetReforgeableAttributes().Any((AttributeModifier s) => s == toreplace))
		{
			this.AdditionalAttributeModifiers.RemoveAll((AttributeModifier r) => r == toreplace);
			this.AdditionalAttributeModifiers.Add(selected);
			if (recalculateRating)
			{
				this.CalculateQualityRatingsAndCacheAttributes();
			}
		}
	}

	// Token: 0x06002C43 RID: 11331 RVA: 0x00122411 File Offset: 0x00120811
	public int GetNumberOfEnchantedTimes()
	{
		if (this.HasBeenEnchantedForTimes == null)
		{
			this.HasBeenEnchantedForTimes = new int?(0);
		}
		return this.HasBeenEnchantedForTimes.Value;
	}

	// Token: 0x06002C44 RID: 11332 RVA: 0x0012243A File Offset: 0x0012083A
	public int GetNumberOfReforgedTimes()
	{
		if (this.HasBeenReforgedForTimes == null)
		{
			this.HasBeenReforgedForTimes = new int?(0);
		}
		return this.HasBeenReforgedForTimes.Value;
	}

	// Token: 0x06002C45 RID: 11333 RVA: 0x00122464 File Offset: 0x00120864
	public List<ResourceConsumptionRequirement> GetEnchantingCost()
	{
		if (this.Level >= 8)
		{
			int num = this.GetNumberOfEnchantedTimes() + 1;
			int num2 = 10;
			if (num > num2)
			{
				num = num2;
			}
			int num3 = 50000;
			int num4 = 3;
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = num3 * num
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.FragmentOfDemon,
					AmountRequired = num4 * num
				}
			};
		}
		int num5 = this.GetNumberOfEnchantedTimes() + 1;
		int num6 = 10;
		if (num5 > num6)
		{
			num5 = num6;
		}
		int num7 = 10000;
		return new List<ResourceConsumptionRequirement>
		{
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.Money,
				AmountRequired = num7 * num5
			}
		};
	}

	// Token: 0x06002C46 RID: 11334 RVA: 0x00122544 File Offset: 0x00120944
	public List<ResourceConsumptionRequirement> GetReforgingCost()
	{
		if (this.Level >= 8)
		{
			int num = this.GetNumberOfReforgedTimes() + 1;
			int num2 = 10;
			if (num > num2)
			{
				num = num2;
			}
			int num3 = 25000;
			int num4 = 50;
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = num3 * num
				},
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.BookFragments,
					AmountRequired = num4 * num
				}
			};
		}
		return new List<ResourceConsumptionRequirement>
		{
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.Money,
				AmountRequired = 2500 * this.Level
			}
		};
	}

	// Token: 0x06002C47 RID: 11335 RVA: 0x00122609 File Offset: 0x00120A09
	public int GetGeneratedOnStarRating()
	{
		if (this.ProducedOnStarRating != null)
		{
			return this.ProducedOnStarRating.Value;
		}
		this.ProducedOnStarRating = new int?(1);
		return this.ProducedOnStarRating.Value;
	}

	// Token: 0x06002C48 RID: 11336 RVA: 0x0012263E File Offset: 0x00120A3E
	public bool IsStarItem()
	{
		return this.IsStarGear != null && this.IsStarGear.Value;
	}

	// Token: 0x06002C49 RID: 11337 RVA: 0x00122660 File Offset: 0x00120A60
	public bool CanAddMoreManualSockets()
	{
		if (this.Type.GetResourceCategory().IsWeapon())
		{
			return this.Sockets.Count < 4;
		}
		return this.Type.GetResourceCategory().IsArmor() && this.Sockets.Count < 3;
	}

	// Token: 0x06002C4A RID: 11338 RVA: 0x001226B8 File Offset: 0x00120AB8
	public bool ExpandItemSockets(Item socketBatcher)
	{
		if (!this.CanAddMoreManualSockets())
		{
			return false;
		}
		if (socketBatcher.Type.IsSocketBatcher())
		{
			this.Sockets.Add(new ItemSocket
			{
				SocketType = socketBatcher.Type.GetSocketBatcherRelatedSocketType(),
				Gem = new NullObject(),
				SourceType = SocketSourceType.Added
			});
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = socketBatcher.Type,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>
					{
						socketBatcher
					}
				}
			});
			return true;
		}
		return false;
	}

	// Token: 0x06002C4B RID: 11339 RVA: 0x0012276C File Offset: 0x00120B6C
	public bool HasGemToExtract()
	{
		bool result;
		if (this.Sockets.Any<ItemSocket>())
		{
			result = this.Sockets.Any((ItemSocket s) => !s.IsEmptySocket());
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06002C4C RID: 11340 RVA: 0x001227A9 File Offset: 0x00120BA9
	public int ExtractGemCost()
	{
		if (this.Level <= 7)
		{
			return this.Level * 500;
		}
		return 10000 + 5000 * this.Level;
	}

	// Token: 0x06002C4D RID: 11341 RVA: 0x001227D6 File Offset: 0x00120BD6
	public bool CanExtract()
	{
		return this.HasGemToExtract() && GameWorld.instance.PlayerProfile.CanAfford((double)this.ExtractGemCost());
	}

	// Token: 0x06002C4E RID: 11342 RVA: 0x001227FC File Offset: 0x00120BFC
	public void ExtractGems()
	{
		if (this.CanExtract())
		{
			GameWorld.instance.PlayerProfile.SpendMoney((double)this.ExtractGemCost());
			List<ResourceUpdate> changes = (from i in (from s in this.Sockets
			select s.Gem).OfType<Item>()
			select new ResourceUpdate
			{
				ResourceType = i.Type,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>
				{
					i
				}
			}).ToList<ResourceUpdate>();
			foreach (ItemSocket itemSocket in this.Sockets)
			{
				itemSocket.Gem = new NullObject();
			}
			this.CalculateQualityRatingsAndCacheAttributes();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
		}
	}

	// Token: 0x06002C4F RID: 11343 RVA: 0x001228E8 File Offset: 0x00120CE8
	public List<ResourceConsumptionRequirement> TeamSetUpgradeRequirements()
	{
		return new List<ResourceConsumptionRequirement>
		{
			new ResourceConsumptionRequirement
			{
				AmountRequired = 1500000,
				ResourceType = ResourceType.Money
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.PracticePoints,
				AmountRequired = 500000
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.FragmentOfDemon,
				AmountRequired = 100
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.InfusedPowder,
				AmountRequired = 100
			}
		};
	}

	// Token: 0x06002C50 RID: 11344 RVA: 0x00122982 File Offset: 0x00120D82
	public bool CanTeamSetUpgrade()
	{
		return this.Type.GetResourceCategory() == ResourceCategory.Amulet && this.TeamSetUpgradeRequirements().MetRequirements() && this.Level < 100;
	}

	// Token: 0x06002C51 RID: 11345 RVA: 0x001229B4 File Offset: 0x00120DB4
	public double GetTeamSetUpgradeSuccessChance()
	{
		int length = this.TeamSetUpgradeMarker.Length;
		double num = Convert.ToDouble(100 - length) / 100.0;
		if (num < 0.5)
		{
			num = 0.5;
		}
		return num;
	}

	// Token: 0x06002C52 RID: 11346 RVA: 0x001229FC File Offset: 0x00120DFC
	public TeamSetItemUpgradeResult UpgradeTeamSetPiece()
	{
		if (this.CanTeamSetUpgrade())
		{
			this.TeamSetUpgradeRequirements().Consume();
			if ((double)UnityEngine.Random.value <= this.GetTeamSetUpgradeSuccessChance())
			{
				return this.Type.GetTeamSetBase().Upgrade(this, this.Level + 1);
			}
		}
		return null;
	}

	// Token: 0x06002C53 RID: 11347 RVA: 0x00122A4C File Offset: 0x00120E4C
	public SocketType? GetGemSocketType()
	{
		if (this.Type.GetResourceCategory() == ResourceCategory.Gem)
		{
			return new SocketType?(GemGeneratorBase.GemSocketTypeDictionary[this.Type]);
		}
		return null;
	}

	// Token: 0x06002C54 RID: 11348 RVA: 0x00122A8C File Offset: 0x00120E8C
	public bool CanBeSocketedWith(Item gem)
	{
		bool result;
		if (gem.Type.GetResourceCategory() == ResourceCategory.Gem)
		{
			if (!(from s in this.Sockets
			where s.IsEmptySocket()
			select s).Any((ItemSocket s) => s.SocketType == SocketType.All))
			{
				result = (from s in this.Sockets
				where s.IsEmptySocket()
				select s).Any((ItemSocket s) => gem.GetGemSocketType() != null && s.SocketType == gem.GetGemSocketType().Value);
			}
			else
			{
				result = true;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06002C55 RID: 11349 RVA: 0x00122B4C File Offset: 0x00120F4C
	public List<Item> GetSocketableGems()
	{
		ResourceCategory resourceCategory = this.Type.GetResourceCategory();
		if (resourceCategory.IsWeapon() || resourceCategory.IsArmor())
		{
			if (this.Sockets.Any((ItemSocket s) => s.Gem == null))
			{
				return (from i in GameWorld.instance.PlayerProfile.Items
				where i.Type.GetResourceCategory() == ResourceCategory.Gem
				select i into g
				where g.GetGemSocketType() != null && this.Sockets.Any((ItemSocket s) => s.Gem == null && (s.SocketType == SocketType.All || s.SocketType == g.GetGemSocketType().Value))
				select g).ToList<Item>();
			}
		}
		return new List<Item>();
	}

	// Token: 0x06002C56 RID: 11350 RVA: 0x00122BF8 File Offset: 0x00120FF8
	public void Socket(Item gem)
	{
		SocketType? gemSocketType = gem.GetGemSocketType();
		if (gem.Type.GetResourceCategory() == ResourceCategory.Gem && gemSocketType != null && this.CanBeSocketedWith(gem))
		{
			ItemSocket itemSocket = this.Sockets.FirstOrDefault((ItemSocket s) => s.SocketType == gemSocketType.Value && s.IsEmptySocket());
			if (itemSocket != null)
			{
				itemSocket.Gem = gem;
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = gem.Type,
						ChangeAmount = -1.0,
						RelatedItems = new List<Item>
						{
							gem
						}
					}
				});
			}
			else
			{
				ItemSocket itemSocket2 = this.Sockets.FirstOrDefault((ItemSocket s) => s.SocketType == SocketType.All && s.IsEmptySocket());
				if (itemSocket2 != null)
				{
					itemSocket2.Gem = gem;
					GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = gem.Type,
							ChangeAmount = -1.0,
							RelatedItems = new List<Item>
							{
								gem
							}
						}
					});
				}
			}
			this.CalculateQualityRatingsAndCacheAttributes();
		}
	}

	// Token: 0x06002C57 RID: 11351 RVA: 0x00122D58 File Offset: 0x00121158
	public double GetMainAttributeValue()
	{
		if (this.Type.GetResourceCategory().IsMeleeWeapon())
		{
			return this.GetAttributeModifiers().GetAttributeValue(AttributeType.Strength, AttributeRetrievalLevel.Skill);
		}
		if (this.Type.GetResourceCategory().IsCasterWeapon())
		{
			return this.GetAttributeModifiers().GetAttributeValue(AttributeType.Intelligience, AttributeRetrievalLevel.Skill);
		}
		if (this.Type.GetResourceCategory().IsArmor())
		{
			return this.GetAttributeModifiers().GetAttributeValue(AttributeType.Vitality, AttributeRetrievalLevel.Skill);
		}
		return 0.0;
	}

	// Token: 0x06002C58 RID: 11352 RVA: 0x00122DDC File Offset: 0x001211DC
	public List<AttributeModifier> GetAttributeModifiers()
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		if (this.Type.GetResourceCategory() == ResourceCategory.Robe)
		{
			list.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Intelligience,
				ModificationType = ModificationType.Multiplication,
				Value = 0.1,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Gear
			});
		}
		if (this.Type.GetResourceCategory() == ResourceCategory.Leather)
		{
			list.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Strength,
				ModificationType = ModificationType.Multiplication,
				Value = 0.1,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Gear
			});
		}
		using (List<AttributeModifier>.Enumerator enumerator = this.PrimaryAttributeModifiers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AttributeModifier att = enumerator.Current;
				AttributeModifier attributeModifier = list.FirstOrDefault((AttributeModifier r) => r.AttributeType == att.AttributeType && r.ModificationType == att.ModificationType);
				if (attributeModifier != null)
				{
					attributeModifier.Value += att.Value;
				}
				else
				{
					list.Add(new AttributeModifier
					{
						AttributeType = att.AttributeType,
						ModificationType = att.ModificationType,
						Value = att.Value,
						Key = string.Empty,
						AttributeModifierType = att.AttributeModifierType
					});
				}
			}
		}
		using (IEnumerator<AttributeModifier> enumerator2 = (from a in this.AdditionalAttributeModifiers
		where a.AttributeModifierType != AttributeModifierType.Growth
		select a).GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				AttributeModifier att = enumerator2.Current;
				AttributeModifier attributeModifier2 = list.FirstOrDefault((AttributeModifier r) => r.AttributeType == att.AttributeType && r.ModificationType == att.ModificationType && !att.IsReforged() && !att.IsEnchanted());
				if (attributeModifier2 != null)
				{
					attributeModifier2.Value += att.Value;
				}
				else
				{
					list.Add(new AttributeModifier
					{
						AttributeType = att.AttributeType,
						ModificationType = att.ModificationType,
						Value = att.Value,
						Key = att.Key,
						AttributeModifierType = att.AttributeModifierType
					});
				}
			}
		}
		list.AddRange(from a in this.AdditionalAttributeModifiers
		where a.AttributeModifierType == AttributeModifierType.Growth
		select a);
		list.AddRange((from s in this.Sockets
		where s.Gem is Item
		select s).SelectMany((ItemSocket s) => (s.Gem as Item).PrimaryAttributeModifiers));
		return list;
	}

	// Token: 0x06002C59 RID: 11353 RVA: 0x00123108 File Offset: 0x00121508
	private double GetRatingForAttribute(AttributeType type, List<AttributeModifier> modifiers)
	{
		double num = modifiers.GetAttributeValue(type, AttributeRetrievalLevel.Skill);
		if (num > 0.0)
		{
			if (type.IsPercentageValue())
			{
				if (type == AttributeType.CritDamage)
				{
					num *= 150.0;
				}
				if (type == AttributeType.CritRate)
				{
					num *= 400.0;
				}
				else
				{
					num *= 50.0;
				}
			}
			return 1.0 + num / (num + 1000.0);
		}
		return 1.0;
	}

	// Token: 0x06002C5A RID: 11354 RVA: 0x00123190 File Offset: 0x00121590
	public void CalculateQualityRatingsAndCacheAttributes()
	{
		Dictionary<AttributeValueCategory, List<AttributeType>> dictionary = new Dictionary<AttributeValueCategory, List<AttributeType>>
		{
			{
				AttributeValueCategory.Output,
				new List<AttributeType>
				{
					AttributeType.Strength,
					AttributeType.Intelligience,
					AttributeType.CritDamage,
					AttributeType.CritDamage,
					AttributeType.DealFireDamageEffectivenessChangeRate,
					AttributeType.DealPhysicalDamageEffectivenessChangeRate,
					AttributeType.DealIceDamageEffectivenessChangeRate,
					AttributeType.DealShadowDamageEffectivenessChangeRate,
					AttributeType.DealPoisonDamageEffectivenessChangeRate,
					AttributeType.DealDivineDamageEffectivenessChangeRate,
					AttributeType.DealLightningDamageEffectivenessChangeRate,
					AttributeType.HitRateAdjustment,
					AttributeType.PhysicalPenetration,
					AttributeType.FirePenetration,
					AttributeType.IcePenetration,
					AttributeType.ShadowPenetration,
					AttributeType.PoisonPenetration,
					AttributeType.DivinePenetration,
					AttributeType.LighteningPenetration
				}
			},
			{
				AttributeValueCategory.Survival,
				new List<AttributeType>
				{
					AttributeType.Vitality,
					AttributeType.PhysicalResistance,
					AttributeType.FireResistanceResistance,
					AttributeType.ShadowResistance,
					AttributeType.IceResistance,
					AttributeType.PoisonResistance,
					AttributeType.DivineResistance,
					AttributeType.LightningResistance,
					AttributeType.LifeOnHit,
					AttributeType.ReflectiveDamage,
					AttributeType.BattleStartHeal,
					AttributeType.TurnStartHeal,
					AttributeType.ReceivedHealEffectivenessChangeRate,
					AttributeType.Resilience,
					AttributeType.DamageReduction,
					AttributeType.HealingAbsorbRate,
					AttributeType.DodgeRateAdjustment,
					AttributeType.EffectResistanceRating
				}
			},
			{
				AttributeValueCategory.Mobility,
				new List<AttributeType>
				{
					AttributeType.Agility
				}
			},
			{
				AttributeValueCategory.Mastery,
				new List<AttributeType>
				{
					AttributeType.TauntOnHit,
					AttributeType.StunOnHit,
					AttributeType.SkillRageEfficiencyRate,
					AttributeType.EffectMastery,
					AttributeType.EffectHitRating
				}
			}
		};
		List<AttributeModifier> attributeModifiers = this.GetAttributeModifiers();
		this.QualityRatings = new Dictionary<AttributeValueCategory, double>();
		foreach (KeyValuePair<AttributeValueCategory, List<AttributeType>> keyValuePair in dictionary)
		{
			double num = 0.0;
			foreach (AttributeType type in keyValuePair.Value)
			{
				num += this.GetRatingForAttribute(type, attributeModifiers);
			}
			this.QualityRatings[keyValuePair.Key] = num;
		}
		this.TotalQualityRating = new double?(this.QualityRatings.Sum((KeyValuePair<AttributeValueCategory, double> q) => q.Value));
		this.CachedAttributeValues = new Dictionary<AttributeType, double>();
		foreach (AttributeType attributeType in ItemExtensions.AllAttributeTypes)
		{
			this.CachedAttributeValues[attributeType] = attributeModifiers.GetAttributeValue(attributeType, AttributeRetrievalLevel.Skill);
		}
		AdventurerProfile owner = this.GetOwner();
		if (owner != null)
		{
			owner.CalculateCachedAttributeValues();
		}
	}

	// Token: 0x06002C5B RID: 11355 RVA: 0x00123504 File Offset: 0x00121904
	public Dictionary<AttributeType, double> GetCachedAttributeValues()
	{
		if (this.CachedAttributeValues == null)
		{
			this.CalculateQualityRatingsAndCacheAttributes();
		}
		return this.CachedAttributeValues;
	}

	// Token: 0x06002C5C RID: 11356 RVA: 0x00123520 File Offset: 0x00121920
	public double GetTotalQualityRating()
	{
		if (this.TotalQualityRating == null)
		{
			Dictionary<AttributeValueCategory, double> qualityRatings = this.GetQualityRatings();
			this.TotalQualityRating = new double?(qualityRatings.Sum((KeyValuePair<AttributeValueCategory, double> q) => q.Value));
		}
		return this.TotalQualityRating.Value;
	}

	// Token: 0x06002C5D RID: 11357 RVA: 0x0012357D File Offset: 0x0012197D
	public Dictionary<AttributeValueCategory, double> GetQualityRatings()
	{
		if (this.QualityRatings == null)
		{
			this.CalculateQualityRatingsAndCacheAttributes();
		}
		return this.QualityRatings;
	}

	// Token: 0x06002C5E RID: 11358 RVA: 0x00123596 File Offset: 0x00121996
	public AttributeModifier GetPrimaryAttribute()
	{
		return this.PrimaryAttributeModifiers.FirstOrDefault<AttributeModifier>();
	}

	// Token: 0x06002C5F RID: 11359 RVA: 0x001235A4 File Offset: 0x001219A4
	public bool IsEnchantable()
	{
		ResourceCategory resourceCategory = this.Type.GetResourceCategory();
		return ((resourceCategory.IsWeapon() || resourceCategory.IsArmor()) && this.ItemGrade == QualityGrade.Ancient) || resourceCategory == ResourceCategory.Device;
	}

	// Token: 0x06002C60 RID: 11360 RVA: 0x001235E7 File Offset: 0x001219E7
	public bool IsEquipment()
	{
		return this.SlotType == ItemType.Armor || this.SlotType == ItemType.Accessory || this.SlotType == ItemType.Weapon;
	}

	// Token: 0x06002C61 RID: 11361 RVA: 0x00123610 File Offset: 0x00121A10
	public bool IsUiEquipment()
	{
		return this.SlotType == ItemType.Armor || this.SlotType == ItemType.Accessory || this.SlotType == ItemType.Weapon || this.SlotType == ItemType.Amulet || this.SlotType == ItemType.Scroll || this.SlotType == ItemType.Device;
	}

	// Token: 0x06002C62 RID: 11362 RVA: 0x00123668 File Offset: 0x00121A68
	public double GetPrice()
	{
		double value = this.Value;
		double num = 1.0;
		if (this.Type.GetResourceCategory().IsWeapon())
		{
			num += GameWorld.instance.PlayerProfile.GetTownStats().WeaponPriceBoost;
		}
		if (this.Type.GetResourceCategory().IsArmor())
		{
			num += GameWorld.instance.PlayerProfile.GetTownStats().ArmorPriceBoost;
		}
		return value * num;
	}

	// Token: 0x06002C63 RID: 11363 RVA: 0x001236E4 File Offset: 0x00121AE4
	public NormalItem ConvertToUiNormalItem()
	{
		return new NormalItem
		{
			Id = this.Id,
			ResourceType = this.Type,
			Item = this,
			Price = this.GetPrice(),
			ItemGrade = this.ItemGrade
		};
	}

	// Token: 0x06002C64 RID: 11364 RVA: 0x0012372F File Offset: 0x00121B2F
	// Note: this type is marked as 'beforefieldinit'.
	static Item()
	{
	}

	// Token: 0x06002C65 RID: 11365 RVA: 0x0012373B File Offset: 0x00121B3B
	[CompilerGenerated]
	private bool <GetOwner>m__0(AdventurerProfile a)
	{
		return a.Id == this.OwnerId;
	}

	// Token: 0x06002C66 RID: 11366 RVA: 0x0012374E File Offset: 0x00121B4E
	[CompilerGenerated]
	private static bool <GetEnchantableEffects>m__1(ISpecialEffectDataLoad s)
	{
		return s.IsStarEffect();
	}

	// Token: 0x06002C67 RID: 11367 RVA: 0x00123756 File Offset: 0x00121B56
	[CompilerGenerated]
	private static bool <GetEnchantableEffects>m__2(ISpecialEffectDataLoad s)
	{
		return s.IsStarEffect();
	}

	// Token: 0x06002C68 RID: 11368 RVA: 0x0012375E File Offset: 0x00121B5E
	[CompilerGenerated]
	private static bool <GetEnchantableEffects>m__3(ISpecialEffectDataLoad s)
	{
		return !s.IsStarEffect();
	}

	// Token: 0x06002C69 RID: 11369 RVA: 0x00123769 File Offset: 0x00121B69
	[CompilerGenerated]
	private static bool <GetEnchantableEffects>m__4(ISpecialEffectDataLoad s)
	{
		return !s.IsStarEffect();
	}

	// Token: 0x06002C6A RID: 11370 RVA: 0x00123774 File Offset: 0x00121B74
	[CompilerGenerated]
	private static ResourceUpdate <EnchantEffectForScroll>m__5(ResourceConsumptionRequirement c)
	{
		return new ResourceUpdate
		{
			ResourceType = c.ResourceType,
			ChangeAmount = (double)(-(double)c.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x06002C6B RID: 11371 RVA: 0x001237B0 File Offset: 0x00121BB0
	[CompilerGenerated]
	private static ResourceUpdate <EnchantEffectForScroll>m__6(ResourceConsumptionRequirement c)
	{
		return new ResourceUpdate
		{
			ResourceType = c.ResourceType,
			ChangeAmount = (double)(-(double)c.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x06002C6C RID: 11372 RVA: 0x001237E9 File Offset: 0x00121BE9
	[CompilerGenerated]
	private static bool <EnchantEffectForScroll>m__7(ISpecialEffectDataLoad e)
	{
		return e.IsStarEffect();
	}

	// Token: 0x06002C6D RID: 11373 RVA: 0x001237F1 File Offset: 0x00121BF1
	[CompilerGenerated]
	private static bool <EnchantEffectForScroll>m__8(ISpecialEffectDataLoad e)
	{
		return e.IsStarEffect();
	}

	// Token: 0x06002C6E RID: 11374 RVA: 0x001237F9 File Offset: 0x00121BF9
	[CompilerGenerated]
	private static bool <EnchantEffectForScroll>m__9(ISpecialEffectDataLoad e)
	{
		return !e.IsStarEffect();
	}

	// Token: 0x06002C6F RID: 11375 RVA: 0x00123804 File Offset: 0x00121C04
	[CompilerGenerated]
	private static bool <GetReforgeableAttributes>m__A(AttributeModifier a)
	{
		return a.IsReforged();
	}

	// Token: 0x06002C70 RID: 11376 RVA: 0x0012380C File Offset: 0x00121C0C
	[CompilerGenerated]
	private static bool <GetReforgeableAttributes>m__B(AttributeModifier a)
	{
		return a.IsReforged();
	}

	// Token: 0x06002C71 RID: 11377 RVA: 0x00123814 File Offset: 0x00121C14
	[CompilerGenerated]
	private static bool <GetReforgeableAttributes>m__C(AttributeModifier a)
	{
		return a.Key == "generation_Secondary";
	}

	// Token: 0x06002C72 RID: 11378 RVA: 0x00123828 File Offset: 0x00121C28
	[CompilerGenerated]
	private static ResourceUpdate <Reforging>m__D(ResourceConsumptionRequirement s)
	{
		return new ResourceUpdate
		{
			ResourceType = s.ResourceType,
			ChangeAmount = (double)(-(double)s.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x06002C73 RID: 11379 RVA: 0x00123864 File Offset: 0x00121C64
	[CompilerGenerated]
	private static ResourceUpdate <Enchanting>m__E(ResourceConsumptionRequirement c)
	{
		return new ResourceUpdate
		{
			ResourceType = c.ResourceType,
			ChangeAmount = (double)(-(double)c.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x06002C74 RID: 11380 RVA: 0x0012389D File Offset: 0x00121C9D
	[CompilerGenerated]
	private static AttributeModifier <Enchanting>m__F(ItemPropertyPotential p)
	{
		return ItemExtensions.RandomGenerateAttributeModifier_Enchanting(Convert.ToSingle(p.Mean), p.ModificationType, p.AttributeType);
	}

	// Token: 0x06002C75 RID: 11381 RVA: 0x001238BB File Offset: 0x00121CBB
	[CompilerGenerated]
	private static bool <SelectAttributesForEnchanting>m__10(AttributeModifier a)
	{
		return a.Key == "enchanted";
	}

	// Token: 0x06002C76 RID: 11382 RVA: 0x001238CD File Offset: 0x00121CCD
	[CompilerGenerated]
	private static bool <HasGemToExtract>m__11(ItemSocket s)
	{
		return !s.IsEmptySocket();
	}

	// Token: 0x06002C77 RID: 11383 RVA: 0x001238D8 File Offset: 0x00121CD8
	[CompilerGenerated]
	private static NullableObject <ExtractGems>m__12(ItemSocket s)
	{
		return s.Gem;
	}

	// Token: 0x06002C78 RID: 11384 RVA: 0x001238E0 File Offset: 0x00121CE0
	[CompilerGenerated]
	private static ResourceUpdate <ExtractGems>m__13(Item i)
	{
		return new ResourceUpdate
		{
			ResourceType = i.Type,
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>
			{
				i
			}
		};
	}

	// Token: 0x06002C79 RID: 11385 RVA: 0x00123923 File Offset: 0x00121D23
	[CompilerGenerated]
	private static bool <CanBeSocketedWith>m__14(ItemSocket s)
	{
		return s.IsEmptySocket();
	}

	// Token: 0x06002C7A RID: 11386 RVA: 0x0012392B File Offset: 0x00121D2B
	[CompilerGenerated]
	private static bool <CanBeSocketedWith>m__15(ItemSocket s)
	{
		return s.SocketType == SocketType.All;
	}

	// Token: 0x06002C7B RID: 11387 RVA: 0x00123936 File Offset: 0x00121D36
	[CompilerGenerated]
	private static bool <CanBeSocketedWith>m__16(ItemSocket s)
	{
		return s.IsEmptySocket();
	}

	// Token: 0x06002C7C RID: 11388 RVA: 0x0012393E File Offset: 0x00121D3E
	[CompilerGenerated]
	private static bool <GetSocketableGems>m__17(ItemSocket s)
	{
		return s.Gem == null;
	}

	// Token: 0x06002C7D RID: 11389 RVA: 0x00123949 File Offset: 0x00121D49
	[CompilerGenerated]
	private static bool <GetSocketableGems>m__18(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06002C7E RID: 11390 RVA: 0x0012395C File Offset: 0x00121D5C
	[CompilerGenerated]
	private bool <GetSocketableGems>m__19(Item g)
	{
		return g.GetGemSocketType() != null && this.Sockets.Any((ItemSocket s) => s.Gem == null && (s.SocketType == SocketType.All || s.SocketType == g.GetGemSocketType().Value));
	}

	// Token: 0x06002C7F RID: 11391 RVA: 0x001239A8 File Offset: 0x00121DA8
	[CompilerGenerated]
	private static bool <Socket>m__1A(ItemSocket s)
	{
		return s.SocketType == SocketType.All && s.IsEmptySocket();
	}

	// Token: 0x06002C80 RID: 11392 RVA: 0x001239BE File Offset: 0x00121DBE
	[CompilerGenerated]
	private static bool <GetAttributeModifiers>m__1B(AttributeModifier a)
	{
		return a.AttributeModifierType != AttributeModifierType.Growth;
	}

	// Token: 0x06002C81 RID: 11393 RVA: 0x001239CC File Offset: 0x00121DCC
	[CompilerGenerated]
	private static bool <GetAttributeModifiers>m__1C(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Growth;
	}

	// Token: 0x06002C82 RID: 11394 RVA: 0x001239D7 File Offset: 0x00121DD7
	[CompilerGenerated]
	private static bool <GetAttributeModifiers>m__1D(ItemSocket s)
	{
		return s.Gem is Item;
	}

	// Token: 0x06002C83 RID: 11395 RVA: 0x001239E7 File Offset: 0x00121DE7
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetAttributeModifiers>m__1E(ItemSocket s)
	{
		return (s.Gem as Item).PrimaryAttributeModifiers;
	}

	// Token: 0x06002C84 RID: 11396 RVA: 0x001239F9 File Offset: 0x00121DF9
	[CompilerGenerated]
	private static double <CalculateQualityRatingsAndCacheAttributes>m__1F(KeyValuePair<AttributeValueCategory, double> q)
	{
		return q.Value;
	}

	// Token: 0x06002C85 RID: 11397 RVA: 0x00123A02 File Offset: 0x00121E02
	[CompilerGenerated]
	private static double <GetTotalQualityRating>m__20(KeyValuePair<AttributeValueCategory, double> q)
	{
		return q.Value;
	}

	// Token: 0x040022C7 RID: 8903
	public static Dictionary<string, AdventurerProfile> CachedItemOwnerDictionary = new Dictionary<string, AdventurerProfile>();

	// Token: 0x040022C8 RID: 8904
	public ResourceType Type;

	// Token: 0x040022C9 RID: 8905
	public string Id;

	// Token: 0x040022CA RID: 8906
	public bool? IsStarGear;

	// Token: 0x040022CB RID: 8907
	public int TeamSetVersion;

	// Token: 0x040022CC RID: 8908
	public double PurchasedOnTime;

	// Token: 0x040022CD RID: 8909
	public ItemType SlotType;

	// Token: 0x040022CE RID: 8910
	public QualityGrade ItemGrade;

	// Token: 0x040022CF RID: 8911
	public int Level;

	// Token: 0x040022D0 RID: 8912
	public List<ISpecialEffectDataLoad> SpecialEffects;

	// Token: 0x040022D1 RID: 8913
	public List<ISpecialEffectDataLoad> AddedSpecialEffects;

	// Token: 0x040022D2 RID: 8914
	public List<ItemSocket> Sockets;

	// Token: 0x040022D3 RID: 8915
	public double? ProducedOnDifficultyValue;

	// Token: 0x040022D4 RID: 8916
	public int? ProducedOnStarRating;

	// Token: 0x040022D5 RID: 8917
	public int? ItemTierLevel;

	// Token: 0x040022D6 RID: 8918
	public List<AttributeModifier> PrimaryAttributeModifiers;

	// Token: 0x040022D7 RID: 8919
	public List<AttributeModifier> AdditionalAttributeModifiers;

	// Token: 0x040022D8 RID: 8920
	public bool Locked;

	// Token: 0x040022D9 RID: 8921
	public double Value;

	// Token: 0x040022DA RID: 8922
	public ItemStatus ItemStatus;

	// Token: 0x040022DB RID: 8923
	public int? HasBeenEnchantedForTimes;

	// Token: 0x040022DC RID: 8924
	public int? HasBeenReforgedForTimes;

	// Token: 0x040022DD RID: 8925
	[NonSerialized]
	public List<List<AttributeModifier>> CurrentEnchantedAttributeSelections;

	// Token: 0x040022DE RID: 8926
	[NonSerialized]
	public List<AttributeModifier> CurrentReforgeAttributeSelections;

	// Token: 0x040022DF RID: 8927
	public int? EnchantingSeed;

	// Token: 0x040022E0 RID: 8928
	public int? ReforgeSeed;

	// Token: 0x040022E1 RID: 8929
	public bool? CanBeReforged;

	// Token: 0x040022E2 RID: 8930
	public int? TeamSetSeed;

	// Token: 0x040022E3 RID: 8931
	public AttributeType? OutputTypeForTeamSet;

	// Token: 0x040022E4 RID: 8932
	public string TeamSetUpgradeMarker;

	// Token: 0x040022E5 RID: 8933
	public List<SpecialEffectType> PotentialTeamPieceEffects;

	// Token: 0x040022E6 RID: 8934
	public List<AttributeType> PotentialTeamUpgradeAttributes;

	// Token: 0x040022E7 RID: 8935
	public AttributeType? TeamSetPiecePrimaryAttributeType;

	// Token: 0x040022E8 RID: 8936
	public string OwnerId;

	// Token: 0x040022E9 RID: 8937
	public Dictionary<AttributeValueCategory, double> QualityRatings;

	// Token: 0x040022EA RID: 8938
	public double? TotalQualityRating;

	// Token: 0x040022EB RID: 8939
	public Dictionary<AttributeType, double> CachedAttributeValues;

	// Token: 0x040022EC RID: 8940
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache0;

	// Token: 0x040022ED RID: 8941
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache1;

	// Token: 0x040022EE RID: 8942
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache2;

	// Token: 0x040022EF RID: 8943
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache3;

	// Token: 0x040022F0 RID: 8944
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cache4;

	// Token: 0x040022F1 RID: 8945
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cache5;

	// Token: 0x040022F2 RID: 8946
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache6;

	// Token: 0x040022F3 RID: 8947
	[CompilerGenerated]
	private static Predicate<ISpecialEffectDataLoad> <>f__am$cache7;

	// Token: 0x040022F4 RID: 8948
	[CompilerGenerated]
	private static Predicate<ISpecialEffectDataLoad> <>f__am$cache8;

	// Token: 0x040022F5 RID: 8949
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache9;

	// Token: 0x040022F6 RID: 8950
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheA;

	// Token: 0x040022F7 RID: 8951
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheB;

	// Token: 0x040022F8 RID: 8952
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cacheC;

	// Token: 0x040022F9 RID: 8953
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cacheD;

	// Token: 0x040022FA RID: 8954
	[CompilerGenerated]
	private static Func<ItemPropertyPotential, AttributeModifier> <>f__am$cacheE;

	// Token: 0x040022FB RID: 8955
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheF;

	// Token: 0x040022FC RID: 8956
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache10;

	// Token: 0x040022FD RID: 8957
	[CompilerGenerated]
	private static Func<ItemSocket, NullableObject> <>f__am$cache11;

	// Token: 0x040022FE RID: 8958
	[CompilerGenerated]
	private static Func<Item, ResourceUpdate> <>f__am$cache12;

	// Token: 0x040022FF RID: 8959
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache13;

	// Token: 0x04002300 RID: 8960
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache14;

	// Token: 0x04002301 RID: 8961
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache15;

	// Token: 0x04002302 RID: 8962
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache16;

	// Token: 0x04002303 RID: 8963
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache17;

	// Token: 0x04002304 RID: 8964
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache18;

	// Token: 0x04002305 RID: 8965
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache19;

	// Token: 0x04002306 RID: 8966
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1A;

	// Token: 0x04002307 RID: 8967
	[CompilerGenerated]
	private static Func<ItemSocket, bool> <>f__am$cache1B;

	// Token: 0x04002308 RID: 8968
	[CompilerGenerated]
	private static Func<ItemSocket, IEnumerable<AttributeModifier>> <>f__am$cache1C;

	// Token: 0x04002309 RID: 8969
	[CompilerGenerated]
	private static Func<KeyValuePair<AttributeValueCategory, double>, double> <>f__am$cache1D;

	// Token: 0x0400230A RID: 8970
	[CompilerGenerated]
	private static Func<KeyValuePair<AttributeValueCategory, double>, double> <>f__am$cache1E;

	// Token: 0x02000DD9 RID: 3545
	[CompilerGenerated]
	private sealed class <EnchantEffectForScroll>c__AnonStorey0
	{
		// Token: 0x0600591C RID: 22812 RVA: 0x00123A0B File Offset: 0x00121E0B
		public <EnchantEffectForScroll>c__AnonStorey0()
		{
		}

		// Token: 0x0600591D RID: 22813 RVA: 0x00123A14 File Offset: 0x00121E14
		internal bool <>m__0(ISpecialEffectDataLoad ef)
		{
			return this.anotherItem.GetSpecialEffects().Any((ISpecialEffectDataLoad ane) => ane == ef);
		}

		// Token: 0x0600591E RID: 22814 RVA: 0x00123A54 File Offset: 0x00121E54
		internal bool <>m__1(ISpecialEffectDataLoad ef)
		{
			return this.anotherItem.GetSpecialEffects().Any((ISpecialEffectDataLoad ane) => ane == ef);
		}

		// Token: 0x040048F5 RID: 18677
		internal Item anotherItem;

		// Token: 0x02000DE0 RID: 3552
		private sealed class <EnchantEffectForScroll>c__AnonStorey1
		{
			// Token: 0x0600592D RID: 22829 RVA: 0x00123A91 File Offset: 0x00121E91
			public <EnchantEffectForScroll>c__AnonStorey1()
			{
			}

			// Token: 0x0600592E RID: 22830 RVA: 0x00123A99 File Offset: 0x00121E99
			internal bool <>m__0(ISpecialEffectDataLoad ane)
			{
				return ane == this.ef;
			}

			// Token: 0x040048FD RID: 18685
			internal ISpecialEffectDataLoad ef;

			// Token: 0x040048FE RID: 18686
			internal Item.<EnchantEffectForScroll>c__AnonStorey0 <>f__ref$0;
		}

		// Token: 0x02000DE1 RID: 3553
		private sealed class <EnchantEffectForScroll>c__AnonStorey2
		{
			// Token: 0x0600592F RID: 22831 RVA: 0x00123AA4 File Offset: 0x00121EA4
			public <EnchantEffectForScroll>c__AnonStorey2()
			{
			}

			// Token: 0x06005930 RID: 22832 RVA: 0x00123AAC File Offset: 0x00121EAC
			internal bool <>m__0(ISpecialEffectDataLoad ane)
			{
				return ane == this.ef;
			}

			// Token: 0x040048FF RID: 18687
			internal ISpecialEffectDataLoad ef;

			// Token: 0x04004900 RID: 18688
			internal Item.<EnchantEffectForScroll>c__AnonStorey0 <>f__ref$0;
		}
	}

	// Token: 0x02000DDA RID: 3546
	[CompilerGenerated]
	private sealed class <SelectAttributesForEnchanting>c__AnonStorey3
	{
		// Token: 0x0600591F RID: 22815 RVA: 0x00123AB7 File Offset: 0x00121EB7
		public <SelectAttributesForEnchanting>c__AnonStorey3()
		{
		}

		// Token: 0x06005920 RID: 22816 RVA: 0x00123ABF File Offset: 0x00121EBF
		internal bool <>m__0(List<AttributeModifier> s)
		{
			return s == this.selected;
		}

		// Token: 0x040048F6 RID: 18678
		internal List<AttributeModifier> selected;
	}

	// Token: 0x02000DDB RID: 3547
	[CompilerGenerated]
	private sealed class <SelectAttributeForReforging>c__AnonStorey4
	{
		// Token: 0x06005921 RID: 22817 RVA: 0x00123ACA File Offset: 0x00121ECA
		public <SelectAttributeForReforging>c__AnonStorey4()
		{
		}

		// Token: 0x06005922 RID: 22818 RVA: 0x00123AD2 File Offset: 0x00121ED2
		internal bool <>m__0(AttributeModifier s)
		{
			return s == this.selected;
		}

		// Token: 0x06005923 RID: 22819 RVA: 0x00123ADD File Offset: 0x00121EDD
		internal bool <>m__1(AttributeModifier s)
		{
			return s == this.toreplace;
		}

		// Token: 0x06005924 RID: 22820 RVA: 0x00123AE8 File Offset: 0x00121EE8
		internal bool <>m__2(AttributeModifier r)
		{
			return r == this.toreplace;
		}

		// Token: 0x040048F7 RID: 18679
		internal AttributeModifier selected;

		// Token: 0x040048F8 RID: 18680
		internal AttributeModifier toreplace;
	}

	// Token: 0x02000DDC RID: 3548
	[CompilerGenerated]
	private sealed class <CanBeSocketedWith>c__AnonStorey5
	{
		// Token: 0x06005925 RID: 22821 RVA: 0x00123AF3 File Offset: 0x00121EF3
		public <CanBeSocketedWith>c__AnonStorey5()
		{
		}

		// Token: 0x06005926 RID: 22822 RVA: 0x00123AFC File Offset: 0x00121EFC
		internal bool <>m__0(ItemSocket s)
		{
			return this.gem.GetGemSocketType() != null && s.SocketType == this.gem.GetGemSocketType().Value;
		}

		// Token: 0x040048F9 RID: 18681
		internal Item gem;
	}

	// Token: 0x02000DDD RID: 3549
	[CompilerGenerated]
	private sealed class <Socket>c__AnonStorey7
	{
		// Token: 0x06005927 RID: 22823 RVA: 0x00123B3F File Offset: 0x00121F3F
		public <Socket>c__AnonStorey7()
		{
		}

		// Token: 0x06005928 RID: 22824 RVA: 0x00123B47 File Offset: 0x00121F47
		internal bool <>m__0(ItemSocket s)
		{
			return s.SocketType == this.gemSocketType.Value && s.IsEmptySocket();
		}

		// Token: 0x040048FA RID: 18682
		internal SocketType? gemSocketType;
	}

	// Token: 0x02000DDE RID: 3550
	[CompilerGenerated]
	private sealed class <GetAttributeModifiers>c__AnonStorey8
	{
		// Token: 0x06005929 RID: 22825 RVA: 0x00123B68 File Offset: 0x00121F68
		public <GetAttributeModifiers>c__AnonStorey8()
		{
		}

		// Token: 0x0600592A RID: 22826 RVA: 0x00123B70 File Offset: 0x00121F70
		internal bool <>m__0(AttributeModifier r)
		{
			return r.AttributeType == this.att.AttributeType && r.ModificationType == this.att.ModificationType;
		}

		// Token: 0x040048FB RID: 18683
		internal AttributeModifier att;
	}

	// Token: 0x02000DDF RID: 3551
	[CompilerGenerated]
	private sealed class <GetAttributeModifiers>c__AnonStorey9
	{
		// Token: 0x0600592B RID: 22827 RVA: 0x00123B9E File Offset: 0x00121F9E
		public <GetAttributeModifiers>c__AnonStorey9()
		{
		}

		// Token: 0x0600592C RID: 22828 RVA: 0x00123BA8 File Offset: 0x00121FA8
		internal bool <>m__0(AttributeModifier r)
		{
			return r.AttributeType == this.att.AttributeType && r.ModificationType == this.att.ModificationType && !this.att.IsReforged() && !this.att.IsEnchanted();
		}

		// Token: 0x040048FC RID: 18684
		internal AttributeModifier att;
	}

	// Token: 0x02000DE2 RID: 3554
	[CompilerGenerated]
	private sealed class <GetSocketableGems>c__AnonStorey6
	{
		// Token: 0x06005931 RID: 22833 RVA: 0x00123C02 File Offset: 0x00122002
		public <GetSocketableGems>c__AnonStorey6()
		{
		}

		// Token: 0x06005932 RID: 22834 RVA: 0x00123C0C File Offset: 0x0012200C
		internal bool <>m__0(ItemSocket s)
		{
			return s.Gem == null && (s.SocketType == SocketType.All || s.SocketType == this.g.GetGemSocketType().Value);
		}

		// Token: 0x04004901 RID: 18689
		internal Item g;
	}
}
