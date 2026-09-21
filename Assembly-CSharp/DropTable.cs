using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class DropTable
{
	// Token: 0x06001F1D RID: 7965 RVA: 0x000DB52D File Offset: 0x000D992D
	public DropTable(List<DropTableParameter> drops)
	{
		this.DropTableParameters = drops;
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x06001F1E RID: 7966 RVA: 0x000DB53C File Offset: 0x000D993C
	// (set) Token: 0x06001F1F RID: 7967 RVA: 0x000DB544 File Offset: 0x000D9944
	public List<DropTableParameter> DropTableParameters
	{
		[CompilerGenerated]
		get
		{
			return this.<DropTableParameters>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DropTableParameters>k__BackingField = value;
		}
	}

	// Token: 0x06001F20 RID: 7968 RVA: 0x000DB550 File Offset: 0x000D9950
	private DropType GetDropType(ResourceType resourceType)
	{
		return DropTable.DropTypeCategoryDictionary.ToList<KeyValuePair<DropType, Func<ResourceType, bool>>>().FirstOrDefault((KeyValuePair<DropType, Func<ResourceType, bool>> d) => d.Value(resourceType)).Key;
	}

	// Token: 0x06001F21 RID: 7969 RVA: 0x000DB58D File Offset: 0x000D998D
	public void CombineWith(DropTable table)
	{
		if (table.DropTableParameters.Any<DropTableParameter>())
		{
			this.DropTableParameters.AddRange(table.DropTableParameters);
		}
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x000DB5B0 File Offset: 0x000D99B0
	private List<DropTableParameter> GetPotentialDrops()
	{
		return this.DropTableParameters;
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x000DB5B8 File Offset: 0x000D99B8
	private List<ResourceUpdate> Drop(List<DropTypePresence> dropTypePresences, GenerationDistribution generationDistribution, DifficultyLevelMeasurement df)
	{
		if (dropTypePresences.Count == 0)
		{
			return new List<ResourceUpdate>();
		}
		DropTypePresence dropTypePresence = dropTypePresences.WeightedRandomSelect<DropTypePresence>();
		if (!DropTable.DropTypeCategoryDictionary.ContainsKey(dropTypePresence.DropType))
		{
			UnityEngine.Debug.Log(dropTypePresence.DropType + " not present");
		}
		Func<ResourceType, bool> selectionFunc = DropTable.DropTypeCategoryDictionary[dropTypePresence.DropType];
		List<DropTableParameter> list = (from p in this.GetPotentialDrops()
		where !p.ResourceType.GetResourceCategory().IsUniqueResource() || !p.ResourceType.HasObtained()
		select p into pt
		where selectionFunc(pt.ResourceType)
		select pt).ToList<DropTableParameter>();
		if (list.Any<DropTableParameter>())
		{
			return new List<ResourceUpdate>
			{
				list.WeightedRandomSelect<DropTableParameter>().GetDrop(generationDistribution, df)
			};
		}
		return new List<ResourceUpdate>();
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x000DB694 File Offset: 0x000D9A94
	public List<ResourceUpdate> GetDrops_LuckRelevance(List<double> possibilities, DropConfiguration dropConfiguration, DifficultyLevelMeasurement df)
	{
		List<ResourceUpdate> list = new List<ResourceUpdate>();
		double totalItemDropBoostRate = GameWorld.instance.PlayerProfile.GetTownStats().TotalItemDropBoostRate;
		GenerationDistribution generationDistribution = dropConfiguration.GenerationDistribution.Duplicate().BoostDrop(totalItemDropBoostRate);
		List<DropTableParameter> list2 = (from p in this.DropTableParameters
		where dropConfiguration.GuarranteedDrops.Any((ResourceType g) => g == p.ResourceType)
		select p).ToList<DropTableParameter>();
		foreach (DropTableParameter dropTableParameter in list2)
		{
			list.Add(dropTableParameter.GetDrop(generationDistribution, df));
		}
		foreach (DropType dt2 in dropConfiguration.GuarranteedDropTypes)
		{
			DropType dt = dt2;
			List<DropTableParameter> list3 = (from p in this.DropTableParameters
			where DropTable.DropTypeCategoryDictionary[dt](p.ResourceType)
			select p).ToList<DropTableParameter>();
			if (list3.Any<DropTableParameter>())
			{
				DropTableParameter dropTableParameter2 = list3.WeightedRandomSelect<DropTableParameter>();
				list.Add(dropTableParameter2.GetDrop(generationDistribution, df));
			}
		}
		Dictionary<DropType, double> droptypeRecords = new Dictionary<DropType, double>();
		Dictionary<DropType, double> limits = dropConfiguration.MaximumDropTypeLimits;
		foreach (KeyValuePair<DropType, double> keyValuePair in limits)
		{
			if (!droptypeRecords.ContainsKey(keyValuePair.Key))
			{
				droptypeRecords.Add(keyValuePair.Key, 0.0);
			}
		}
		foreach (double num in possibilities)
		{
			double num2 = num;
			float value = UnityEngine.Random.value;
			if ((double)value <= num2)
			{
				List<DropTypePresence> dropTypePresences = dropConfiguration.DropTypePresences.Where(delegate(DropTypePresence p)
				{
					bool result;
					if (!droptypeRecords.ContainsKey(p.DropType) || droptypeRecords[p.DropType] < limits[p.DropType])
					{
						result = (from pt in this.GetPotentialDrops()
						where !pt.ResourceType.GetResourceCategory().IsUniqueResource() || !pt.ResourceType.HasObtained()
						select pt).Any((DropTableParameter pt) => DropTable.DropTypeCategoryDictionary[p.DropType](pt.ResourceType));
					}
					else
					{
						result = false;
					}
					return result;
				}).ToList<DropTypePresence>();
				List<ResourceUpdate> list4 = this.Drop(dropTypePresences, generationDistribution, df);
				foreach (ResourceUpdate resourceUpdate in list4)
				{
					DropType dropType = this.GetDropType(resourceUpdate.ResourceType);
					if (droptypeRecords.ContainsKey(dropType))
					{
						double num3 = limits[dropType] - droptypeRecords[dropType];
						if (resourceUpdate.ChangeAmount > num3)
						{
							double num4 = resourceUpdate.ChangeAmount - num3;
							List<Item> list5 = (!resourceUpdate.RelatedItems.Any<Item>()) ? new List<Item>() : resourceUpdate.RelatedItems.Take((int)num4).ToList<Item>();
							resourceUpdate.ChangeAmount = num3;
							if (list5.Any<Item>())
							{
								foreach (Item item in list5)
								{
									resourceUpdate.RelatedItems.Remove(item);
								}
							}
							Dictionary<DropType, double> droptypeRecords2;
							DropType key;
							(droptypeRecords2 = droptypeRecords)[key = dropType] = droptypeRecords2[key] + resourceUpdate.ChangeAmount;
						}
					}
				}
				list.AddRange(from d in list4
				where d.ChangeAmount > 0.0
				select d);
			}
		}
		return list;
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x000DBADC File Offset: 0x000D9EDC
	// Note: this type is marked as 'beforefieldinit'.
	static DropTable()
	{
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x000DBB7B File Offset: 0x000D9F7B
	[CompilerGenerated]
	private static bool <Drop>m__0(DropTableParameter p)
	{
		return !p.ResourceType.GetResourceCategory().IsUniqueResource() || !p.ResourceType.HasObtained();
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x000DBBA3 File Offset: 0x000D9FA3
	[CompilerGenerated]
	private static bool <GetDrops_LuckRelevance>m__1(ResourceUpdate d)
	{
		return d.ChangeAmount > 0.0;
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x000DBBB8 File Offset: 0x000D9FB8
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__2(ResourceType resourceType)
	{
		ResourceCategory resourceCategory = resourceType.GetResourceCategory();
		return resourceCategory == ResourceCategory.Timber || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.Hides;
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x000DBBE4 File Offset: 0x000D9FE4
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__3(ResourceType resource)
	{
		return resource.GetResourceCategory() == ResourceCategory.ProductionRecipe;
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x000DBBF0 File Offset: 0x000D9FF0
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__4(ResourceType resource)
	{
		return resource.GetResourceCategory() == ResourceCategory.Accessory;
	}

	// Token: 0x06001F2B RID: 7979 RVA: 0x000DBBFC File Offset: 0x000D9FFC
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__5(ResourceType resource)
	{
		return resource.GetResourceCategory() == ResourceCategory.AdventurerInvitation;
	}

	// Token: 0x06001F2C RID: 7980 RVA: 0x000DBC08 File Offset: 0x000DA008
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__6(ResourceType resouce)
	{
		return resouce.GetResourceCategory() == ResourceCategory.Consumable;
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x000DBC14 File Offset: 0x000DA014
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__7(ResourceType resource)
	{
		return resource.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x000DBC20 File Offset: 0x000DA020
	[CompilerGenerated]
	private static bool <DropTypeCategoryDictionary>m__8(ResourceType resource)
	{
		ResourceCategory resourceCategory = resource.GetResourceCategory();
		return resourceCategory.IsArmor() || resourceCategory.IsWeapon();
	}

	// Token: 0x04001C3D RID: 7229
	public static Dictionary<DropType, Func<ResourceType, bool>> DropTypeCategoryDictionary = new Dictionary<DropType, Func<ResourceType, bool>>
	{
		{
			DropType.RawResources,
			delegate(ResourceType resourceType)
			{
				ResourceCategory resourceCategory = resourceType.GetResourceCategory();
				return resourceCategory == ResourceCategory.Timber || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.Hides;
			}
		},
		{
			DropType.Recipes,
			(ResourceType resource) => resource.GetResourceCategory() == ResourceCategory.ProductionRecipe
		},
		{
			DropType.Accessories,
			(ResourceType resource) => resource.GetResourceCategory() == ResourceCategory.Accessory
		},
		{
			DropType.Invitations,
			(ResourceType resource) => resource.GetResourceCategory() == ResourceCategory.AdventurerInvitation
		},
		{
			DropType.Consumables,
			(ResourceType resouce) => resouce.GetResourceCategory() == ResourceCategory.Consumable
		},
		{
			DropType.Gem,
			(ResourceType resource) => resource.GetResourceCategory() == ResourceCategory.Gem
		},
		{
			DropType.Gears,
			delegate(ResourceType resource)
			{
				ResourceCategory resourceCategory = resource.GetResourceCategory();
				return resourceCategory.IsArmor() || resourceCategory.IsWeapon();
			}
		}
	};

	// Token: 0x04001C3E RID: 7230
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DropTableParameter> <DropTableParameters>k__BackingField;

	// Token: 0x04001C3F RID: 7231
	[CompilerGenerated]
	private static Func<DropTableParameter, bool> <>f__am$cache0;

	// Token: 0x04001C40 RID: 7232
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache1;

	// Token: 0x02000D0A RID: 3338
	[CompilerGenerated]
	private sealed class <GetDropType>c__AnonStorey0
	{
		// Token: 0x060055DA RID: 21978 RVA: 0x000DBC48 File Offset: 0x000DA048
		public <GetDropType>c__AnonStorey0()
		{
		}

		// Token: 0x060055DB RID: 21979 RVA: 0x000DBC50 File Offset: 0x000DA050
		internal bool <>m__0(KeyValuePair<DropType, Func<ResourceType, bool>> d)
		{
			return d.Value(this.resourceType);
		}

		// Token: 0x0400446A RID: 17514
		internal ResourceType resourceType;
	}

	// Token: 0x02000D0B RID: 3339
	[CompilerGenerated]
	private sealed class <Drop>c__AnonStorey1
	{
		// Token: 0x060055DC RID: 21980 RVA: 0x000DBC64 File Offset: 0x000DA064
		public <Drop>c__AnonStorey1()
		{
		}

		// Token: 0x060055DD RID: 21981 RVA: 0x000DBC6C File Offset: 0x000DA06C
		internal bool <>m__0(DropTableParameter pt)
		{
			return this.selectionFunc(pt.ResourceType);
		}

		// Token: 0x0400446B RID: 17515
		internal Func<ResourceType, bool> selectionFunc;
	}

	// Token: 0x02000D0C RID: 3340
	[CompilerGenerated]
	private sealed class <GetDrops_LuckRelevance>c__AnonStorey2
	{
		// Token: 0x060055DE RID: 21982 RVA: 0x000DBC7F File Offset: 0x000DA07F
		public <GetDrops_LuckRelevance>c__AnonStorey2()
		{
		}

		// Token: 0x060055DF RID: 21983 RVA: 0x000DBC88 File Offset: 0x000DA088
		internal bool <>m__0(DropTableParameter p)
		{
			return this.dropConfiguration.GuarranteedDrops.Any((ResourceType g) => g == p.ResourceType);
		}

		// Token: 0x060055E0 RID: 21984 RVA: 0x000DBCC8 File Offset: 0x000DA0C8
		internal bool <>m__1(DropTypePresence p)
		{
			bool result;
			if (!this.droptypeRecords.ContainsKey(p.DropType) || this.droptypeRecords[p.DropType] < this.limits[p.DropType])
			{
				result = (from pt in this.$this.GetPotentialDrops()
				where !pt.ResourceType.GetResourceCategory().IsUniqueResource() || !pt.ResourceType.HasObtained()
				select pt).Any((DropTableParameter pt) => DropTable.DropTypeCategoryDictionary[p.DropType](pt.ResourceType));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060055E1 RID: 21985 RVA: 0x000DBD76 File Offset: 0x000DA176
		private static bool <>m__2(DropTableParameter pt)
		{
			return !pt.ResourceType.GetResourceCategory().IsUniqueResource() || !pt.ResourceType.HasObtained();
		}

		// Token: 0x0400446C RID: 17516
		internal DropConfiguration dropConfiguration;

		// Token: 0x0400446D RID: 17517
		internal Dictionary<DropType, double> droptypeRecords;

		// Token: 0x0400446E RID: 17518
		internal Dictionary<DropType, double> limits;

		// Token: 0x0400446F RID: 17519
		internal DropTable $this;

		// Token: 0x04004470 RID: 17520
		private static Func<DropTableParameter, bool> <>f__am$cache0;

		// Token: 0x02000D0E RID: 3342
		private sealed class <GetDrops_LuckRelevance>c__AnonStorey3
		{
			// Token: 0x060055E4 RID: 21988 RVA: 0x000DBD9E File Offset: 0x000DA19E
			public <GetDrops_LuckRelevance>c__AnonStorey3()
			{
			}

			// Token: 0x060055E5 RID: 21989 RVA: 0x000DBDA6 File Offset: 0x000DA1A6
			internal bool <>m__0(ResourceType g)
			{
				return g == this.p.ResourceType;
			}

			// Token: 0x04004472 RID: 17522
			internal DropTableParameter p;

			// Token: 0x04004473 RID: 17523
			internal DropTable.<GetDrops_LuckRelevance>c__AnonStorey2 <>f__ref$2;
		}

		// Token: 0x02000D0F RID: 3343
		private sealed class <GetDrops_LuckRelevance>c__AnonStorey5
		{
			// Token: 0x060055E6 RID: 21990 RVA: 0x000DBDB6 File Offset: 0x000DA1B6
			public <GetDrops_LuckRelevance>c__AnonStorey5()
			{
			}

			// Token: 0x060055E7 RID: 21991 RVA: 0x000DBDBE File Offset: 0x000DA1BE
			internal bool <>m__0(DropTableParameter pt)
			{
				return DropTable.DropTypeCategoryDictionary[this.p.DropType](pt.ResourceType);
			}

			// Token: 0x04004474 RID: 17524
			internal DropTypePresence p;

			// Token: 0x04004475 RID: 17525
			internal DropTable.<GetDrops_LuckRelevance>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000D0D RID: 3341
	[CompilerGenerated]
	private sealed class <GetDrops_LuckRelevance>c__AnonStorey4
	{
		// Token: 0x060055E2 RID: 21986 RVA: 0x000DBDE0 File Offset: 0x000DA1E0
		public <GetDrops_LuckRelevance>c__AnonStorey4()
		{
		}

		// Token: 0x060055E3 RID: 21987 RVA: 0x000DBDE8 File Offset: 0x000DA1E8
		internal bool <>m__0(DropTableParameter p)
		{
			return DropTable.DropTypeCategoryDictionary[this.dt](p.ResourceType);
		}

		// Token: 0x04004471 RID: 17521
		internal DropType dt;
	}
}
