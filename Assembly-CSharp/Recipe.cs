using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000473 RID: 1139
[Serializable]
public class Recipe
{
	// Token: 0x0600204F RID: 8271 RVA: 0x000E0FC1 File Offset: 0x000DF3C1
	public Recipe()
	{
	}

	// Token: 0x06002050 RID: 8272 RVA: 0x000E0FE0 File Offset: 0x000DF3E0
	public double GetWorkload(int itemTierLevel)
	{
		return (double)((!this.ProductType.GetResourceCategory().IsWeapon()) ? ((!this.ProductType.GetResourceCategory().IsArmor()) ? 0 : ItemExtensions.ArmorRoots[itemTierLevel - 1].Workload) : ItemExtensions.WeaponRoots[itemTierLevel - 1].Workload);
	}

	// Token: 0x06002051 RID: 8273 RVA: 0x000E1047 File Offset: 0x000DF447
	public int GetRecipeLevel(int itemTierLevel)
	{
		return this.ProductType.GetCreationTemplate().ItemLevel(itemTierLevel);
	}

	// Token: 0x06002052 RID: 8274 RVA: 0x000E105C File Offset: 0x000DF45C
	public List<ResourceConsumptionRequirement> GetProductionRequirements(int itemTierLevel)
	{
		if (this.ProductType.GetResourceCategory().IsWeapon() || this.ProductType.GetResourceCategory().IsArmor())
		{
			ItemCategoryRootDefault rootDefault = this.ProductType.GetResourceCategory().GetRootDefault();
			return rootDefault.GetRequirements(itemTierLevel);
		}
		return new List<ResourceConsumptionRequirement>();
	}

	// Token: 0x06002053 RID: 8275 RVA: 0x000E10B4 File Offset: 0x000DF4B4
	public bool MetRequirement(int quantity, int itemTierLevel)
	{
		return quantity > 0 && (from r in this.GetProductionRequirements(itemTierLevel)
		select new ResourceConsumptionRequirement
		{
			ResourceType = r.ResourceType,
			AmountRequired = r.AmountRequired * quantity
		}).ToList<ResourceConsumptionRequirement>().MetRequirements();
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x000E1100 File Offset: 0x000DF500
	private bool ItemCanBeAutoSelled(Item item)
	{
		if (item.Type.HasCreationTemplate())
		{
			if (item.Type.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType s) => s == ResourceSourceType.BuildingProduction))
			{
				string text = string.Empty;
				if (item.SlotType == ItemType.Weapon)
				{
					switch (item.ItemGrade)
					{
					case QualityGrade.Normal:
						text = UIAdditionalDataKey.WeaponGradeNormal;
						break;
					case QualityGrade.Rare:
						text = UIAdditionalDataKey.WeaponGradeRare;
						break;
					case QualityGrade.Epic:
						text = UIAdditionalDataKey.WeaponGradeEpic;
						break;
					case QualityGrade.Legendary:
						text = UIAdditionalDataKey.WeaponGradeLegendary;
						break;
					case QualityGrade.Ancient:
						text = UIAdditionalDataKey.WeaponGradeAncient;
						break;
					}
				}
				if (item.SlotType == ItemType.Armor)
				{
					switch (item.ItemGrade)
					{
					case QualityGrade.Normal:
						text = UIAdditionalDataKey.ArmorGradeNormal;
						break;
					case QualityGrade.Rare:
						text = UIAdditionalDataKey.ArmorGradeRare;
						break;
					case QualityGrade.Epic:
						text = UIAdditionalDataKey.ArmorGradeEpic;
						break;
					case QualityGrade.Legendary:
						text = UIAdditionalDataKey.ArmorGradeLegendary;
						break;
					case QualityGrade.Ancient:
						text = UIAdditionalDataKey.ArmorGradeAncient;
						break;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					AdditionalData additionalData = GameWorld.instance.PlayerProfile.AdditionalData;
					if (additionalData.ContainsBool(text))
					{
						return additionalData.GetBool(text);
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x000E1260 File Offset: 0x000DF660
	public Product Produce(int itemTierLevel)
	{
		float num = UnityEngine.Random.Range(0f, 1f);
		if ((double)num <= this.SuccessRate)
		{
			List<Item> list = new List<Item>();
			if (this.ProductType.IsItem())
			{
				for (int i = 0; i < this.AmountToBeProduced; i++)
				{
					DifficultyLevelMeasurement productionDifficultyLevelMeasurement = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
					Item item = this.ProductType.ItemGenerate(ResourceSourceType.BuildingProduction, productionDifficultyLevelMeasurement.GetDefaultItemGenerationQuality(this.ProductType, ResourceSourceType.BuildingProduction), itemTierLevel, 1);
					if (this.ItemCanBeAutoSelled(item))
					{
						GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
						{
							new ResourceUpdate
							{
								ResourceType = ResourceType.Money,
								ChangeAmount = item.GetPrice(),
								RelatedItems = new List<Item>()
							}
						});
					}
					else
					{
						list.Add(item);
					}
				}
			}
			if (list.Any<Item>())
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = this.ProductType,
						ChangeAmount = (double)this.AmountToBeProduced,
						RelatedItems = list
					}
				});
			}
			return new Product
			{
				ProductType = this.ProductType,
				RelatedItems = list,
				SourceRecipe = this,
				Success = true
			};
		}
		return new Product
		{
			ProductType = this.ProductType,
			RelatedItems = new List<Item>(),
			SourceRecipe = this,
			Success = false
		};
	}

	// Token: 0x06002056 RID: 8278 RVA: 0x000E1403 File Offset: 0x000DF803
	public bool IsLocked()
	{
		return GameWorld.instance.PlayerProfile.UnlockedResourceRecipes.All((ResourceType t) => t != this.ProductType);
	}

	// Token: 0x06002057 RID: 8279 RVA: 0x000E1425 File Offset: 0x000DF825
	[CompilerGenerated]
	private static bool <ItemCanBeAutoSelled>m__0(ResourceSourceType s)
	{
		return s == ResourceSourceType.BuildingProduction;
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x000E142B File Offset: 0x000DF82B
	[CompilerGenerated]
	private bool <IsLocked>m__1(ResourceType t)
	{
		return t != this.ProductType;
	}

	// Token: 0x04001CCF RID: 7375
	public ResourceType RecipeName;

	// Token: 0x04001CD0 RID: 7376
	public BuildingType BuildingType;

	// Token: 0x04001CD1 RID: 7377
	public ResourceType ProductType;

	// Token: 0x04001CD2 RID: 7378
	public int AmountToBeProduced = 1;

	// Token: 0x04001CD3 RID: 7379
	public double SuccessRate = 1.0;

	// Token: 0x04001CD4 RID: 7380
	public double RequiredWorkload;

	// Token: 0x04001CD5 RID: 7381
	public int RecipeLevel;

	// Token: 0x04001CD6 RID: 7382
	[CompilerGenerated]
	private static Func<ResourceSourceType, bool> <>f__am$cache0;

	// Token: 0x02000D24 RID: 3364
	[CompilerGenerated]
	private sealed class <MetRequirement>c__AnonStorey0
	{
		// Token: 0x0600563B RID: 22075 RVA: 0x000E1439 File Offset: 0x000DF839
		public <MetRequirement>c__AnonStorey0()
		{
		}

		// Token: 0x0600563C RID: 22076 RVA: 0x000E1444 File Offset: 0x000DF844
		internal ResourceConsumptionRequirement <>m__0(ResourceConsumptionRequirement r)
		{
			return new ResourceConsumptionRequirement
			{
				ResourceType = r.ResourceType,
				AmountRequired = r.AmountRequired * this.quantity
			};
		}

		// Token: 0x040044C8 RID: 17608
		internal int quantity;
	}
}
