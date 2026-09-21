using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020005EA RID: 1514
public abstract class ItemTemplateBase
{
	// Token: 0x060029C8 RID: 10696 RVA: 0x0011668A File Offset: 0x00114A8A
	protected ItemTemplateBase()
	{
	}

	// Token: 0x060029C9 RID: 10697 RVA: 0x00116694 File Offset: 0x00114A94
	public Recipe GetRecipe()
	{
		return new Recipe
		{
			BuildingType = ((!this.ItemType.GetResourceCategory().IsWeapon()) ? ((!this.ItemType.GetResourceCategory().IsArmor()) ? BuildingType.None : BuildingType.ArmorShop) : BuildingType.WeaponShop),
			RecipeName = (ResourceType)Enum.Parse(typeof(ResourceType), this.ItemType.ToString() + "Recipe"),
			ProductType = this.ItemType,
			AmountToBeProduced = 1,
			SuccessRate = 1.0
		};
	}

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x060029CA RID: 10698
	public abstract ResourceType ItemType { get; }

	// Token: 0x060029CB RID: 10699 RVA: 0x0011673F File Offset: 0x00114B3F
	public int ItemLevel(int itemTier)
	{
		return (int)Math.Ceiling((double)itemTier / 5.0);
	}

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x060029CC RID: 10700
	public abstract int ItemTierNumber { get; }

	// Token: 0x060029CD RID: 10701 RVA: 0x00116753 File Offset: 0x00114B53
	public virtual List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060029CE RID: 10702 RVA: 0x0011675A File Offset: 0x00114B5A
	public virtual List<AttributeType> GetPrimaryAttributes(int itemTierNumber)
	{
		return this.ItemType.GetResourceCategory().GetRootDefault().GetDefaultPrimaryAttributes(itemTierNumber);
	}

	// Token: 0x060029CF RID: 10703 RVA: 0x00116774 File Offset: 0x00114B74
	public virtual List<AttributeType> GuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		List<AttributeType> defaultGurranteedAttributes = this.ItemType.GetResourceCategory().GetRootDefault().GetDefaultGurranteedAttributes(itemTierNumber);
		defaultGurranteedAttributes.AddRange(this.AdditionalGuarranteedPrimaryGradedAttributes(itemTierNumber));
		return defaultGurranteedAttributes;
	}

	// Token: 0x060029D0 RID: 10704 RVA: 0x001167A6 File Offset: 0x00114BA6
	public virtual List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x060029D1 RID: 10705 RVA: 0x001167AD File Offset: 0x00114BAD
	public virtual List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x060029D2 RID: 10706 RVA: 0x001167B4 File Offset: 0x00114BB4
	public virtual float GetValueBase(int itemTier)
	{
		if (this.ItemType.GetResourceCategory().IsWeapon())
		{
			return (float)ItemExtensions.WeaponRoots[itemTier - 1].PriceBase;
		}
		if (this.ItemType.GetResourceCategory().IsArmor())
		{
			return (float)ItemExtensions.ArmorRoots[itemTier - 1].PriceBase;
		}
		return 0f;
	}

	// Token: 0x060029D3 RID: 10707 RVA: 0x00116818 File Offset: 0x00114C18
	public virtual List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		if (this.ItemType.GetResourceCategory().IsWeapon() || this.ItemType.GetResourceCategory().IsArmor())
		{
			List<ItemPropertyPotential> list = new List<ItemPropertyPotential>();
			ItemRoot root = (!this.ItemType.GetResourceCategory().IsWeapon()) ? ItemExtensions.ArmorRoots[itemTierNumber - 1] : ItemExtensions.WeaponRoots[itemTierNumber - 1];
			ItemCategoryRootDefault rootDefault = this.ItemType.GetResourceCategory().GetRootDefault();
			using (List<AttributeType>.Enumerator enumerator = this.GetPrimaryAttributes(itemTierNumber).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AttributeType primaryAttribute = enumerator.Current;
					if (rootDefault.Descriptors.Any((AttributePotentialDescriptor d) => d.AttributeType == primaryAttribute))
					{
						ItemPropertyPotential itemPropertyPotential = list.FirstOrDefault((ItemPropertyPotential p) => p.IsGuaranteed && p.IsPrimary && p.AttributeType == primaryAttribute);
						if (itemPropertyPotential != null)
						{
							itemPropertyPotential.Mean += rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == primaryAttribute).GetMean(root, AttributeGrade.Primary);
						}
						else
						{
							list.Add(new ItemPropertyPotential
							{
								AttributeType = primaryAttribute,
								ModificationType = ModificationType.Addition,
								Mean = rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == primaryAttribute).GetMean(root, AttributeGrade.Primary),
								IsPrimary = true,
								IsGuaranteed = true,
								AttributeGrade = AttributeGrade.Primary
							});
						}
					}
				}
			}
			using (List<AttributeType>.Enumerator enumerator2 = this.GuarranteedPrimaryGradedAttributes(itemTierNumber).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					AttributeType guarranteedAttribute = enumerator2.Current;
					if (rootDefault.Descriptors.Any((AttributePotentialDescriptor d) => d.AttributeType == guarranteedAttribute))
					{
						ItemPropertyPotential itemPropertyPotential2 = list.FirstOrDefault((ItemPropertyPotential p) => p.AttributeType == guarranteedAttribute && !p.IsPrimary && p.IsGuaranteed);
						if (itemPropertyPotential2 == null)
						{
							list.Add(new ItemPropertyPotential
							{
								AttributeType = guarranteedAttribute,
								ModificationType = ModificationType.Addition,
								Mean = rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == guarranteedAttribute).GetMean(root, AttributeGrade.Primary),
								IsPrimary = false,
								IsGuaranteed = true,
								AttributeGrade = AttributeGrade.Primary
							});
						}
						else
						{
							itemPropertyPotential2.Mean += rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == guarranteedAttribute).GetMean(root, AttributeGrade.Primary);
						}
					}
				}
			}
			using (List<AttributeType>.Enumerator enumerator3 = this.ExtraGuarranteedSecondaryGradedAttributes(itemTierNumber).GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					AttributeType guarranteedSecondaryGradedAttribute = enumerator3.Current;
					if (rootDefault.Descriptors.Any((AttributePotentialDescriptor d) => d.AttributeType == guarranteedSecondaryGradedAttribute))
					{
						ItemPropertyPotential itemPropertyPotential3 = list.FirstOrDefault((ItemPropertyPotential p) => p.AttributeType == guarranteedSecondaryGradedAttribute && p.IsGuaranteed && !p.IsPrimary);
						if (itemPropertyPotential3 != null)
						{
							itemPropertyPotential3.Mean += rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == guarranteedSecondaryGradedAttribute).GetMean(root, AttributeGrade.Secondary);
						}
						else
						{
							list.Add(new ItemPropertyPotential
							{
								AttributeType = guarranteedSecondaryGradedAttribute,
								ModificationType = ModificationType.Addition,
								Mean = rootDefault.Descriptors.First((AttributePotentialDescriptor d) => d.AttributeType == guarranteedSecondaryGradedAttribute).GetMean(root, AttributeGrade.Secondary),
								IsPrimary = false,
								IsGuaranteed = true,
								AttributeGrade = AttributeGrade.Secondary
							});
						}
					}
				}
			}
			List<AttributeType> possibleAttributes = this.GetPossibleRandomAttributes(itemTierNumber).Distinct<AttributeType>().ToList<AttributeType>();
			foreach (AttributePotentialDescriptor attributePotentialDescriptor in (from a in rootDefault.Descriptors
			where possibleAttributes.Any((AttributeType pa) => pa == a.AttributeType)
			select a).ToList<AttributePotentialDescriptor>())
			{
				list.Add(new ItemPropertyPotential
				{
					AttributeType = attributePotentialDescriptor.AttributeType,
					ModificationType = ModificationType.Addition,
					Mean = attributePotentialDescriptor.GetMean(root, AttributeGrade.Secondary),
					IsPrimary = false,
					IsGuaranteed = false,
					AttributeGrade = AttributeGrade.Secondary
				});
			}
			return list;
		}
		return new List<ItemPropertyPotential>();
	}

	// Token: 0x060029D4 RID: 10708 RVA: 0x00116CD0 File Offset: 0x001150D0
	public List<ItemPropertyPotential> GetEnchantableAttributePotentials(int itemTierLevel)
	{
		ItemCategoryRootDefault rootDefault = this.ItemType.GetResourceCategory().GetRootDefault();
		List<ItemPropertyPotential> list = new List<ItemPropertyPotential>();
		ItemRoot root = (!this.ItemType.GetResourceCategory().IsWeapon()) ? ItemExtensions.ArmorRoots[itemTierLevel - 1] : ItemExtensions.WeaponRoots[itemTierLevel - 1];
		List<AttributeType> possibleAttributes = this.GetEnchantableAttributes(itemTierLevel).Distinct<AttributeType>().ToList<AttributeType>();
		foreach (AttributePotentialDescriptor attributePotentialDescriptor in (from a in rootDefault.Descriptors
		where possibleAttributes.Any((AttributeType pa) => pa == a.AttributeType)
		select a).ToList<AttributePotentialDescriptor>())
		{
			list.Add(new ItemPropertyPotential
			{
				AttributeType = attributePotentialDescriptor.AttributeType,
				ModificationType = ModificationType.Addition,
				Mean = attributePotentialDescriptor.GetMean(root, AttributeGrade.Secondary),
				IsPrimary = false,
				IsGuaranteed = false
			});
		}
		return list;
	}

	// Token: 0x060029D5 RID: 10709 RVA: 0x00116DEC File Offset: 0x001151EC
	private List<AttributeType> GetEnchantableAttributes(int itemtierLevel)
	{
		if (this.ItemType.GetResourceCategory().IsWeapon())
		{
			List<AttributeType> list = new List<AttributeType>
			{
				AttributeType.CritRate,
				AttributeType.CritDamage,
				AttributeType.DealPhysicalDamageEffectivenessChangeRate,
				AttributeType.DealPoisonDamageEffectivenessChangeRate,
				AttributeType.DealDivineDamageEffectivenessChangeRate,
				AttributeType.DealFireDamageEffectivenessChangeRate,
				AttributeType.DealIceDamageEffectivenessChangeRate,
				AttributeType.DealLightningDamageEffectivenessChangeRate,
				AttributeType.DealShadowDamageEffectivenessChangeRate,
				AttributeType.SkillRageEfficiencyRate,
				AttributeType.LifeOnHit,
				AttributeType.StunOnHit
			};
			if (this.ItemType.GetResourceCategory().IsCasterWeapon())
			{
				list.Add(AttributeType.Intelligience);
			}
			if (this.ItemType.GetResourceCategory().IsMeleeWeapon())
			{
				list.Add(AttributeType.Strength);
			}
			if (itemtierLevel >= 55)
			{
				list.Add(AttributeType.HitRateAdjustment);
				list.Add(AttributeType.DodgeRateAdjustment);
				list.Add(AttributeType.EffectMastery);
				list.Add(AttributeType.EffectHitRating);
			}
			if (itemtierLevel > 90)
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
			return list;
		}
		List<AttributeType> list2 = new List<AttributeType>
		{
			AttributeType.Vitality,
			AttributeType.PhysicalResistance,
			AttributeType.FireResistanceResistance,
			AttributeType.ShadowResistance,
			AttributeType.IceResistance,
			AttributeType.PoisonResistance,
			AttributeType.DivineResistance,
			AttributeType.LightningResistance,
			AttributeType.Resilience,
			AttributeType.TurnStartHeal,
			AttributeType.BattleStartHeal,
			AttributeType.ReceivedHealEffectivenessChangeRate,
			AttributeType.HealingAbsorbRate,
			AttributeType.Resilience,
			AttributeType.ReflectiveDamage,
			AttributeType.Agility
		};
		if (itemtierLevel >= 55)
		{
			list2.Add(AttributeType.HitRateAdjustment);
			list2.Add(AttributeType.DodgeRateAdjustment);
			list2.Add(AttributeType.EffectResistanceRating);
		}
		if (itemtierLevel > 90 && this.ItemType.GetResourceCategory() == ResourceCategory.Scrolls)
		{
			list2.AddRange(new List<AttributeType>
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
		return list2;
	}

	// Token: 0x060029D6 RID: 10710 RVA: 0x0011709C File Offset: 0x0011549C
	public virtual List<AttributeType> GetPossibleRandomAttributes(int itemTierNumber)
	{
		List<AttributeType> list = new List<AttributeType>();
		if (this.ItemType.GetResourceCategory().IsWeapon())
		{
			if (this.ItemType.GetResourceCategory().IsCasterWeapon())
			{
				list.Add(AttributeType.Intelligience);
			}
			else
			{
				list.Add(AttributeType.Strength);
			}
			list.AddRange(new List<AttributeType>
			{
				AttributeType.Agility
			});
			if (itemTierNumber < 50)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.Mining,
					AttributeType.Hunting
				});
			}
			if (itemTierNumber > 7)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.CritRate,
					AttributeType.CritDamage,
					AttributeType.DealPhysicalDamageEffectivenessChangeRate,
					AttributeType.DealPoisonDamageEffectivenessChangeRate
				});
			}
			if (itemTierNumber > 10)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.DealDivineDamageEffectivenessChangeRate,
					AttributeType.DealFireDamageEffectivenessChangeRate,
					AttributeType.DealIceDamageEffectivenessChangeRate,
					AttributeType.DealLightningDamageEffectivenessChangeRate,
					AttributeType.DealShadowDamageEffectivenessChangeRate
				});
			}
			if (itemTierNumber > 14)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.SkillRageEfficiencyRate
				});
			}
			if (itemTierNumber > 45)
			{
				list.Add(AttributeType.EffectHitRating);
			}
			if (itemTierNumber >= 80)
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
		}
		else if (this.ItemType.GetResourceCategory().IsArmor())
		{
			list.AddRange(new List<AttributeType>
			{
				AttributeType.Vitality,
				AttributeType.PhysicalResistance,
				AttributeType.FireResistanceResistance,
				AttributeType.ShadowResistance,
				AttributeType.IceResistance,
				AttributeType.PoisonResistance,
				AttributeType.DivineResistance,
				AttributeType.LightningResistance
			});
			if (itemTierNumber > 10)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.Resilience,
					AttributeType.TurnStartHeal,
					AttributeType.BattleStartHeal
				});
			}
			if (itemTierNumber > 15)
			{
				list.AddRange(new List<AttributeType>
				{
					AttributeType.ReceivedHealEffectivenessChangeRate,
					AttributeType.HealingAbsorbRate
				});
			}
		}
		else
		{
			list.AddRange(new List<AttributeType>
			{
				AttributeType.Vitality,
				AttributeType.PhysicalResistance,
				AttributeType.FireResistanceResistance,
				AttributeType.ShadowResistance,
				AttributeType.IceResistance,
				AttributeType.PoisonResistance,
				AttributeType.DivineResistance,
				AttributeType.LightningResistance,
				AttributeType.Resilience,
				AttributeType.TurnStartHeal,
				AttributeType.BattleStartHeal,
				AttributeType.ReceivedHealEffectivenessChangeRate,
				AttributeType.HealingAbsorbRate
			});
		}
		return list;
	}

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x060029D7 RID: 10711 RVA: 0x00117390 File Offset: 0x00115790
	public virtual int DefaultRecipeDropPresences
	{
		get
		{
			return (5 - DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(90.0, 1).GetCorrespondingItemTierLevel(this.ItemType) % 5) * 20;
		}
	}

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x060029D8 RID: 10712 RVA: 0x001173B3 File Offset: 0x001157B3
	public virtual int DefaultItemDropPresences
	{
		get
		{
			return 100;
		}
	}

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x060029D9 RID: 10713
	public abstract List<ResourceSourceType> ItemSourceTypes { get; }

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x060029DA RID: 10714
	public abstract List<ResourceSourceType> RecipeSourceTypes { get; }

	// Token: 0x02000DCD RID: 3533
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey3
	{
		// Token: 0x060058F7 RID: 22775 RVA: 0x001173B7 File Offset: 0x001157B7
		public <PropertyPotentials>c__AnonStorey3()
		{
		}

		// Token: 0x060058F8 RID: 22776 RVA: 0x001173C0 File Offset: 0x001157C0
		internal bool <>m__0(AttributePotentialDescriptor a)
		{
			return this.possibleAttributes.Any((AttributeType pa) => pa == a.AttributeType);
		}

		// Token: 0x040048E3 RID: 18659
		internal List<AttributeType> possibleAttributes;

		// Token: 0x02000DD2 RID: 3538
		private sealed class <PropertyPotentials>c__AnonStorey4
		{
			// Token: 0x0600590A RID: 22794 RVA: 0x001173F8 File Offset: 0x001157F8
			public <PropertyPotentials>c__AnonStorey4()
			{
			}

			// Token: 0x0600590B RID: 22795 RVA: 0x00117400 File Offset: 0x00115800
			internal bool <>m__0(AttributeType pa)
			{
				return pa == this.a.AttributeType;
			}

			// Token: 0x040048E8 RID: 18664
			internal AttributePotentialDescriptor a;

			// Token: 0x040048E9 RID: 18665
			internal ItemTemplateBase.<PropertyPotentials>c__AnonStorey3 <>f__ref$3;
		}
	}

	// Token: 0x02000DCE RID: 3534
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058F9 RID: 22777 RVA: 0x00117410 File Offset: 0x00115810
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058FA RID: 22778 RVA: 0x00117418 File Offset: 0x00115818
		internal bool <>m__0(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.primaryAttribute;
		}

		// Token: 0x060058FB RID: 22779 RVA: 0x00117428 File Offset: 0x00115828
		internal bool <>m__1(ItemPropertyPotential p)
		{
			return p.IsGuaranteed && p.IsPrimary && p.AttributeType == this.primaryAttribute;
		}

		// Token: 0x060058FC RID: 22780 RVA: 0x00117451 File Offset: 0x00115851
		internal bool <>m__2(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.primaryAttribute;
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x00117461 File Offset: 0x00115861
		internal bool <>m__3(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.primaryAttribute;
		}

		// Token: 0x040048E4 RID: 18660
		internal AttributeType primaryAttribute;
	}

	// Token: 0x02000DCF RID: 3535
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey1
	{
		// Token: 0x060058FE RID: 22782 RVA: 0x00117471 File Offset: 0x00115871
		public <PropertyPotentials>c__AnonStorey1()
		{
		}

		// Token: 0x060058FF RID: 22783 RVA: 0x00117479 File Offset: 0x00115879
		internal bool <>m__0(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedAttribute;
		}

		// Token: 0x06005900 RID: 22784 RVA: 0x00117489 File Offset: 0x00115889
		internal bool <>m__1(ItemPropertyPotential p)
		{
			return p.AttributeType == this.guarranteedAttribute && !p.IsPrimary && p.IsGuaranteed;
		}

		// Token: 0x06005901 RID: 22785 RVA: 0x001174B0 File Offset: 0x001158B0
		internal bool <>m__2(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedAttribute;
		}

		// Token: 0x06005902 RID: 22786 RVA: 0x001174C0 File Offset: 0x001158C0
		internal bool <>m__3(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedAttribute;
		}

		// Token: 0x040048E5 RID: 18661
		internal AttributeType guarranteedAttribute;
	}

	// Token: 0x02000DD0 RID: 3536
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey2
	{
		// Token: 0x06005903 RID: 22787 RVA: 0x001174D0 File Offset: 0x001158D0
		public <PropertyPotentials>c__AnonStorey2()
		{
		}

		// Token: 0x06005904 RID: 22788 RVA: 0x001174D8 File Offset: 0x001158D8
		internal bool <>m__0(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedSecondaryGradedAttribute;
		}

		// Token: 0x06005905 RID: 22789 RVA: 0x001174E8 File Offset: 0x001158E8
		internal bool <>m__1(ItemPropertyPotential p)
		{
			return p.AttributeType == this.guarranteedSecondaryGradedAttribute && p.IsGuaranteed && !p.IsPrimary;
		}

		// Token: 0x06005906 RID: 22790 RVA: 0x00117512 File Offset: 0x00115912
		internal bool <>m__2(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedSecondaryGradedAttribute;
		}

		// Token: 0x06005907 RID: 22791 RVA: 0x00117522 File Offset: 0x00115922
		internal bool <>m__3(AttributePotentialDescriptor d)
		{
			return d.AttributeType == this.guarranteedSecondaryGradedAttribute;
		}

		// Token: 0x040048E6 RID: 18662
		internal AttributeType guarranteedSecondaryGradedAttribute;
	}

	// Token: 0x02000DD1 RID: 3537
	[CompilerGenerated]
	private sealed class <GetEnchantableAttributePotentials>c__AnonStorey5
	{
		// Token: 0x06005908 RID: 22792 RVA: 0x00117532 File Offset: 0x00115932
		public <GetEnchantableAttributePotentials>c__AnonStorey5()
		{
		}

		// Token: 0x06005909 RID: 22793 RVA: 0x0011753C File Offset: 0x0011593C
		internal bool <>m__0(AttributePotentialDescriptor a)
		{
			return this.possibleAttributes.Any((AttributeType pa) => pa == a.AttributeType);
		}

		// Token: 0x040048E7 RID: 18663
		internal List<AttributeType> possibleAttributes;

		// Token: 0x02000DD3 RID: 3539
		private sealed class <GetEnchantableAttributePotentials>c__AnonStorey6
		{
			// Token: 0x0600590C RID: 22796 RVA: 0x00117574 File Offset: 0x00115974
			public <GetEnchantableAttributePotentials>c__AnonStorey6()
			{
			}

			// Token: 0x0600590D RID: 22797 RVA: 0x0011757C File Offset: 0x0011597C
			internal bool <>m__0(AttributeType pa)
			{
				return pa == this.a.AttributeType;
			}

			// Token: 0x040048EA RID: 18666
			internal AttributePotentialDescriptor a;

			// Token: 0x040048EB RID: 18667
			internal ItemTemplateBase.<GetEnchantableAttributePotentials>c__AnonStorey5 <>f__ref$5;
		}
	}
}
