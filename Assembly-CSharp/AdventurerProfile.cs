using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000A29 RID: 2601
[Serializable]
public class AdventurerProfile : ITraveller
{
	// Token: 0x060046D5 RID: 18133 RVA: 0x001CFE11 File Offset: 0x001CE211
	public AdventurerProfile()
	{
	}

	// Token: 0x060046D6 RID: 18134 RVA: 0x001CFE2F File Offset: 0x001CE22F
	public bool IsStar()
	{
		return this.QualityCoefficient >= 2.5;
	}

	// Token: 0x060046D7 RID: 18135 RVA: 0x001CFE45 File Offset: 0x001CE245
	public List<ISpecialEffectDataLoad> GetAdventurerStarEffects()
	{
		if (this.SpecialEffects == null)
		{
			return new List<ISpecialEffectDataLoad>();
		}
		return (from e in this.SpecialEffects
		where e.GetSpecialEffectType().IsStarAdventurerEffect()
		select e).ToList<ISpecialEffectDataLoad>();
	}

	// Token: 0x060046D8 RID: 18136 RVA: 0x001CFE85 File Offset: 0x001CE285
	public int GetLevel()
	{
		return UnitExtensions.GetAdventurerLevelConfig(this.Experience).Level;
	}

	// Token: 0x060046D9 RID: 18137 RVA: 0x001CFE97 File Offset: 0x001CE297
	public Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> GetAttributeValues()
	{
		if (this.AttributeValues == null)
		{
			this.CalculateCachedAttributeValues();
		}
		return this.AttributeValues;
	}

	// Token: 0x060046DA RID: 18138 RVA: 0x001CFEB0 File Offset: 0x001CE2B0
	public void CalculateCachedAttributeValues()
	{
		List<AttributeModifier> allAttributes_Complete = this.GetAllAttributes_Complete(null);
		this.AttributeValues = allAttributes_Complete.GetValues();
	}

	// Token: 0x060046DB RID: 18139 RVA: 0x001CFED4 File Offset: 0x001CE2D4
	public OutputType GetOutputType()
	{
		List<ElementReplacementData> source = this.GetSpecialEffects().OfType<ElementReplacementData>().ToList<ElementReplacementData>();
		if (source.Any<ElementReplacementData>())
		{
			return source.Last<ElementReplacementData>().Type;
		}
		return this.OutputType;
	}

	// Token: 0x060046DC RID: 18140 RVA: 0x001CFF0F File Offset: 0x001CE30F
	public List<AttributeModifier> GetNakedAttributes()
	{
		if (this.NakedAttributes == null)
		{
			this.NakedAttributes = new List<AttributeModifier>();
		}
		return this.NakedAttributes;
	}

	// Token: 0x060046DD RID: 18141 RVA: 0x001CFF30 File Offset: 0x001CE330
	public List<ISpecialEffectDataLoad> GetSpecialEffects()
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		list.AddRange(this.SpecialEffects);
		list.AddRange(this.GetEquipments().SelectMany((Item i) => i.GetSpecialEffects()));
		list.AddRange(this.GetEquipments().GetSetBenefits().SelectMany((SetItemResult b) => b.MajorEffects));
		list.AddRange(this.GetEquipments().GetSetBenefits().SelectMany((SetItemResult b) => b.MinorEffects));
		list.AddRange((from t in this.Talents
		where t.GetCurrentLevel() > 0
		select t).SelectMany((IAdventurerTalent c) => c.GetSpecialEffects(this)));
		return list;
	}

	// Token: 0x060046DE RID: 18142 RVA: 0x001D0023 File Offset: 0x001CE423
	public int GetTalentResetCost()
	{
		return 10000;
	}

	// Token: 0x060046DF RID: 18143 RVA: 0x001D002C File Offset: 0x001CE42C
	public bool CanAssignAutoTactic()
	{
		Skill skill = this.GetSkills().FirstOrDefault((Skill sk) => sk.CommandType == SkillCommandType.Active);
		if (skill != null)
		{
			ActiveSkillLogicBase activeSkillLogicBase = skill.GetSkillLogic() as ActiveSkillLogicBase;
			if (activeSkillLogicBase != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060046E0 RID: 18144 RVA: 0x001D0080 File Offset: 0x001CE480
	public bool TacticCanbeAutoResolved()
	{
		Skill skill = this.GetSkills().FirstOrDefault((Skill sk) => sk.CommandType == SkillCommandType.Active);
		if (skill != null)
		{
			ActiveSkillLogicBase activeSkillLogicBase = skill.GetSkillLogic() as ActiveSkillLogicBase;
			if (activeSkillLogicBase != null)
			{
				return activeSkillLogicBase.IsSelfResolvable(this);
			}
		}
		return false;
	}

	// Token: 0x060046E1 RID: 18145 RVA: 0x001D00D8 File Offset: 0x001CE4D8
	public List<CandidateOrderringMetric> GetCandidateOrderringMetrics()
	{
		return new List<CandidateOrderringMetric>
		{
			CandidateOrderringMetric.Random,
			CandidateOrderringMetric.HealthPoints,
			CandidateOrderringMetric.HealthPointPercentage,
			CandidateOrderringMetric.MaxHealth,
			CandidateOrderringMetric.Strength,
			CandidateOrderringMetric.Intelligience,
			CandidateOrderringMetric.OutputCapacity,
			CandidateOrderringMetric.PositiveEffectCounts,
			CandidateOrderringMetric.NegativeEffectCounts,
			CandidateOrderringMetric.Speed,
			CandidateOrderringMetric.MonsterType
		};
	}

	// Token: 0x060046E2 RID: 18146 RVA: 0x001D013C File Offset: 0x001CE53C
	public List<OrderingType> GetOrderingTypes()
	{
		return new List<OrderingType>
		{
			OrderingType.Asc,
			OrderingType.Desc
		};
	}

	// Token: 0x060046E3 RID: 18147 RVA: 0x001D0160 File Offset: 0x001CE560
	public void ResetTalent()
	{
		if (GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints) >= (double)this.GetTalentResetCost())
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.PracticePoints,
					ChangeAmount = (double)(-(double)this.GetTalentResetCost()),
					RelatedItems = new List<Item>()
				}
			});
			foreach (IAdventurerTalent talent in this.Talents)
			{
				talent.Reset(this);
			}
			this.TalentPoints = this.GetLevel() / 5;
			if (this.TalentPoints > 17)
			{
				this.TalentPoints = 17;
			}
		}
	}

	// Token: 0x060046E4 RID: 18148 RVA: 0x001D0248 File Offset: 0x001CE648
	public void Equip(Item item)
	{
		if (GameWorld.instance.PlayerProfile.Items.Any((Item i) => i == item))
		{
			Item item2 = null;
			if (item.Type.GetResourceCategory() == ResourceCategory.Accessory)
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Accessory);
			}
			if (item.Type.GetResourceCategory() == ResourceCategory.Scrolls)
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Scrolls);
			}
			if (item.Type.GetResourceCategory() == ResourceCategory.Amulet)
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Amulet);
			}
			if (item.Type.GetResourceCategory() == ResourceCategory.Device)
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Device);
			}
			if (item.Type.GetResourceCategory().IsWeapon())
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory().IsWeapon());
			}
			if (item.Type.GetResourceCategory().IsArmor())
			{
				item2 = this.EquippedItems.FirstOrDefault((Item i) => i.Type.GetResourceCategory().IsArmor());
			}
			if (item2 != null)
			{
				this.Disrobe(item2, false);
			}
			ItemStatus itemStatus = item.ItemStatus;
			this.EquippedItems.Add(item);
			item.SetOwner(this);
			GameWorld.instance.PlayerProfile.Items.Remove(item);
			item.ItemStatus = ItemStatus.Equipped;
			ItemStatus itemStatus2 = item.ItemStatus;
			ItemStatusUpdateEvent data = new ItemStatusUpdateEvent
			{
				Item = item,
				CurrentStatus = itemStatus2,
				PreviousStatus = itemStatus
			};
			this.CalculateCachedAttributeValues();
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ItemEquipped, data);
			this.OnItemEquipped(item);
		}
	}

	// Token: 0x060046E5 RID: 18149 RVA: 0x001D04C8 File Offset: 0x001CE8C8
	public void Disrobe(Item equipment, bool needsRecache)
	{
		ItemStatus itemStatus = equipment.ItemStatus;
		equipment.ItemStatus = ItemStatus.Reserved;
		ItemStatus itemStatus2 = equipment.ItemStatus;
		ItemStatusUpdateEvent data = new ItemStatusUpdateEvent
		{
			Item = equipment,
			CurrentStatus = itemStatus2,
			PreviousStatus = itemStatus
		};
		if (this.EquippedItems.Any((Item i) => i == equipment))
		{
			this.EquippedItems.Remove(equipment);
			equipment.SetOwner(null);
			if (GameWorld.instance.PlayerProfile.Items.All((Item i) => i != equipment))
			{
				GameWorld.instance.PlayerProfile.Items.Add(equipment);
			}
		}
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ItemReserved, data);
		if (needsRecache)
		{
			this.CalculateCachedAttributeValues();
		}
		this.OnItemDisrobed(equipment);
	}

	// Token: 0x060046E6 RID: 18150 RVA: 0x001D05D0 File Offset: 0x001CE9D0
	private void CollectsExp(long expPoints)
	{
		if (this.CurrentExperienceAdd35 == null)
		{
			this.CurrentExperienceAdd35 = new long?(this.Experience + 35L);
		}
		if (this.CurrentExperienceMultiply3 == null)
		{
			this.CurrentExperienceMultiply3 = new long?(this.Experience * 3L);
		}
		long experience = this.Experience;
		long? currentExperienceAdd = this.CurrentExperienceAdd35;
		if (experience == ((currentExperienceAdd == null) ? null : new long?(currentExperienceAdd.GetValueOrDefault() - 35L)))
		{
			long experience2 = this.Experience;
			long? currentExperienceMultiply = this.CurrentExperienceMultiply3;
			if (experience2 == ((currentExperienceMultiply == null) ? null : new long?(currentExperienceMultiply.GetValueOrDefault() / 3L)))
			{
				long experience3 = this.Experience;
				long num = this.Experience + expPoints;
				UnitLevelConfiguration adventurerLevelConfig = UnitExtensions.GetAdventurerLevelConfig(experience3);
				this.OnReceivesExp(adventurerLevelConfig, experience3, num);
				bool flag = UnitExtensions.CanAdventurerLevelUp(experience3, num);
				this.Experience = num;
				this.CurrentExperienceAdd35 = new long?(num + 35L);
				this.CurrentExperienceMultiply3 = new long?(num * 3L);
				if (flag)
				{
					this.LevelUpLogic(experience3, num);
				}
				List<ResourceUpdate> changes = new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.PracticePoints,
						ChangeAmount = (double)(-(double)expPoints),
						RelatedItems = new List<Item>()
					}
				};
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			}
		}
	}

	// Token: 0x060046E7 RID: 18151 RVA: 0x001D077C File Offset: 0x001CEB7C
	public int GetMaxPossibleCardOptions()
	{
		int num = 3;
		if (GameWorld.instance.PlayerProfile.GetResidentEffects<DeterminationResidentEffect>().Any<DeterminationResidentEffect>())
		{
			num++;
		}
		return num;
	}

	// Token: 0x060046E8 RID: 18152 RVA: 0x001D07AC File Offset: 0x001CEBAC
	public List<ElementEffectDetails> GetOutputElementDetails()
	{
		List<ElementEffectDetails> list = new List<ElementEffectDetails>();
		OutputType outputtype = this.GetOutputType();
		if (this.GetSpecialEffects().OfType<ElementEffectData>().Any((ElementEffectData e) => e.ElementType == outputtype))
		{
			list.Add(new ElementEffectDetails
			{
				Description = outputtype.GetDescription().Details1,
				Unlocked = true,
				Type = outputtype
			});
		}
		else
		{
			list.Add(new ElementEffectDetails
			{
				Description = outputtype.GetDescription().Details1,
				Unlocked = false,
				Type = outputtype
			});
		}
		return list;
	}

	// Token: 0x060046E9 RID: 18153 RVA: 0x001D0864 File Offset: 0x001CEC64
	public void TryUpgrade10Level()
	{
		long num = 0L;
		int level = this.GetLevel();
		long num2 = this.Experience;
		for (int i = 0; i < 10; i++)
		{
			UnitLevelConfiguration unitLevelConfiguration = UnitExtensions.LevelConfigs[level + i];
			long num3 = (long)unitLevelConfiguration.FromExp - num2;
			num2 = (long)unitLevelConfiguration.FromExp;
			if (level + i + 1 > UnitExtensions.MaxAdventurerLevel || GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints) < (double)(num + num3))
			{
				break;
			}
			num += num3;
		}
		if (num > 0L)
		{
			this.CollectsExp(num);
		}
	}

	// Token: 0x060046EA RID: 18154 RVA: 0x001D0904 File Offset: 0x001CED04
	public void UpgradeLevel()
	{
		if (this.CanUpgradeLevel())
		{
			UnitLevelConfiguration unitLevelConfiguration = UnitExtensions.LevelConfigs[this.GetLevel()];
			long expPoints = (long)unitLevelConfiguration.FromExp - this.Experience;
			this.CollectsExp(expPoints);
			this.CalculateCachedAttributeValues();
		}
	}

	// Token: 0x060046EB RID: 18155 RVA: 0x001D0949 File Offset: 0x001CED49
	public int GetLevelUpRequiredExp()
	{
		return (int)((long)UnitExtensions.LevelConfigs[this.GetLevel()].FromExp - this.Experience);
	}

	// Token: 0x060046EC RID: 18156 RVA: 0x001D096C File Offset: 0x001CED6C
	public List<Skill> GetSkills()
	{
		IEnumerable<SkillType> skills = this.Skills;
		if (AdventurerProfile.<>f__mg$cache0 == null)
		{
			AdventurerProfile.<>f__mg$cache0 = new Func<SkillType, Skill>(SkillExtensions.CreatePlayerSkill);
		}
		List<Skill> list = skills.Select(AdventurerProfile.<>f__mg$cache0).ToList<Skill>();
		foreach (Skill skill in list)
		{
			skill.IsEnabled = true;
		}
		IEnumerable<Skill> enumerable = from r in list
		where r.CommandType == SkillCommandType.Active
		select r;
		foreach (Skill skill2 in enumerable)
		{
			skill2.IsEnabled = true;
		}
		if (GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.School))
		{
			IEnumerable<SkillType> acquiredPassives = GameWorld.instance.PlayerProfile.AcquiredPassives;
			if (AdventurerProfile.<>f__mg$cache1 == null)
			{
				AdventurerProfile.<>f__mg$cache1 = new Func<SkillType, Skill>(SkillExtensions.CreatePlayerSkill);
			}
			List<Skill> list2 = acquiredPassives.Select(AdventurerProfile.<>f__mg$cache1).ToList<Skill>();
			using (List<Skill>.Enumerator enumerator3 = list2.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					Skill passive = enumerator3.Current;
					if (list.All((Skill s) => s.SkillType != passive.SkillType))
					{
						list.Add(passive);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x060046ED RID: 18157 RVA: 0x001D0B20 File Offset: 0x001CEF20
	public bool IsInBattle()
	{
		return GameWorld.instance.GetCurrentAdventure() != null && GameWorld.instance.GetCurrentAdventure().Adventurers.Any((AdventurerBattleUnit ad) => ad.AdventurerId == this.Id);
	}

	// Token: 0x060046EE RID: 18158 RVA: 0x001D0B64 File Offset: 0x001CEF64
	public bool CanUpgradeLevel()
	{
		UnitLevelConfiguration unitLevelConfiguration = UnitExtensions.LevelConfigs[this.GetLevel()];
		long num = (long)unitLevelConfiguration.FromExp - this.Experience;
		return this.GetLevel() < UnitExtensions.MaxAdventurerLevel && GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints) >= (double)num;
	}

	// Token: 0x060046EF RID: 18159 RVA: 0x001D0BC0 File Offset: 0x001CEFC0
	public void DirectlyEnableSkill(Skill skill)
	{
		this.Skills = (from sk in this.Skills
		where sk.GetSkillLogic().SkillCommandType != skill.CommandType
		select sk).ToList<SkillType>();
		this.Skills.Add(skill.SkillType);
	}

	// Token: 0x060046F0 RID: 18160 RVA: 0x001D0C14 File Offset: 0x001CF014
	public double GetRating()
	{
		double num = this.QualityCoefficient;
		if (num >= 2.5)
		{
			num = 2.5 + (num - 2.5) * 0.2;
		}
		return (double)((int)(num * 100.0 / (num * 100.0 + 500.0) * 1000.0));
	}

	// Token: 0x060046F1 RID: 18161 RVA: 0x001D0C84 File Offset: 0x001CF084
	private void LevelUpLogic(long fromExp, long toExp)
	{
		UnitLevelConfiguration adventurerLevelConfig = UnitExtensions.GetAdventurerLevelConfig(fromExp);
		UnitLevelConfiguration adventurerLevelConfig2 = UnitExtensions.GetAdventurerLevelConfig(toExp);
		int num = adventurerLevelConfig2.Level - adventurerLevelConfig.Level;
		AdventurerUnitConfigurationBase adventurerUnitConfigurationBase = this.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase;
		for (int i = 1; i <= num; i++)
		{
			int num2 = adventurerLevelConfig.Level + i;
			if (num2 % 5 == 0 && num2 <= 85)
			{
				this.TalentPoints++;
			}
		}
		if (adventurerLevelConfig.Level < 15 && adventurerLevelConfig2.Level >= 15)
		{
			this.SpecialEffects.Add(new ElementEffectData
			{
				IsStarEf = new bool?(false),
				ElementType = this.OutputType
			});
		}
		if (adventurerLevelConfig.Level < 30 && adventurerLevelConfig2.Level >= 30)
		{
			this.SpecialEffects.AddRange((from o in UnitExtensions.GetAllDamageElements()
			where o != this.OutputType
			select new ElementEffectData
			{
				IsStarEf = new bool?(false),
				ElementType = o
			}).Cast<ISpecialEffectDataLoad>());
		}
		for (int j = 0; j < num; j++)
		{
			UnitLevelUpChange levelUpChange = adventurerUnitConfigurationBase.AdventurerGrowthProfile.GetLevelUpChange(1.0 + this.QualityCoefficient, 1.2);
			foreach (LevelUpChangeValue levelUpChangeValue in levelUpChange.ChangedValues)
			{
				this.NakedAttributes = this.GetNakedAttributes().AddValue(levelUpChangeValue.AttributeType, levelUpChangeValue.Value);
			}
			this.CalculateCachedAttributeValues();
			if (num <= 1)
			{
				this.OnLevelUp(this.GetLevel(), adventurerLevelConfig.Level + j + 1, levelUpChange);
			}
		}
	}

	// Token: 0x060046F2 RID: 18162 RVA: 0x001D0E78 File Offset: 0x001CF278
	public IBuildingProfile GetWorkingBuilding()
	{
		if (this.WorkingBuilding != (TownSlot)0)
		{
			return GameWorld.instance.PlayerProfile.Buildings[this.WorkingBuilding];
		}
		return null;
	}

	// Token: 0x060046F3 RID: 18163 RVA: 0x001D0EA4 File Offset: 0x001CF2A4
	public List<Item> GetEquipments()
	{
		if (this.EquippedItems == null)
		{
			this.EquippedItems = new List<Item>();
			if (this.Equipments != null)
			{
				using (List<string>.Enumerator enumerator = this.Equipments.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string equipment = enumerator.Current;
						Item item = GameWorld.instance.PlayerProfile.Items.FirstOrDefault((Item i) => i.Id == equipment);
						if (item != null)
						{
							this.EquippedItems.Add(item);
							item.SetOwner(this);
						}
					}
				}
			}
		}
		return this.EquippedItems;
	}

	// Token: 0x060046F4 RID: 18164 RVA: 0x001D0F68 File Offset: 0x001CF368
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
		this.UnitClass.GetUnitGameWorldEventLogic()(this, evt, data);
	}

	// Token: 0x060046F5 RID: 18165 RVA: 0x001D0F80 File Offset: 0x001CF380
	protected virtual void OnReceivesExp(UnitLevelConfiguration arg1, long arg2, long arg3)
	{
		Action<UnitLevelConfiguration, long, long> receivesExp = this.ReceivesExp;
		if (receivesExp != null)
		{
			receivesExp(arg1, arg2, arg3);
		}
	}

	// Token: 0x060046F6 RID: 18166 RVA: 0x001D0FA4 File Offset: 0x001CF3A4
	protected virtual void OnLevelUp(int arg1, int arg2, UnitLevelUpChange change)
	{
		Action<int, int, UnitLevelUpChange> levelUp = this.LevelUp;
		if (levelUp != null)
		{
			levelUp(arg1, arg2, change);
		}
	}

	// Token: 0x060046F7 RID: 18167 RVA: 0x001D0FC8 File Offset: 0x001CF3C8
	protected virtual void OnItemEquipped(Item item)
	{
		Action<Item> itemEquipped = this.ItemEquipped;
		if (itemEquipped != null)
		{
			itemEquipped(item);
		}
	}

	// Token: 0x060046F8 RID: 18168 RVA: 0x001D0FEC File Offset: 0x001CF3EC
	protected virtual void OnItemDisrobed(Item equipment)
	{
		Action<Item> itemDisrobed = this.ItemDisrobed;
		if (itemDisrobed != null)
		{
			itemDisrobed(equipment);
		}
	}

	// Token: 0x060046F9 RID: 18169 RVA: 0x001D100D File Offset: 0x001CF40D
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060046FA RID: 18170 RVA: 0x001D1015 File Offset: 0x001CF415
	public string GetUnitName()
	{
		if (string.IsNullOrEmpty(this._unitName))
		{
			return this.UnitClass.GetDescription().Title;
		}
		return this._unitName;
	}

	// Token: 0x060046FB RID: 18171 RVA: 0x001D103E File Offset: 0x001CF43E
	public void SetUnitName(string name)
	{
		if (name.Length <= 15)
		{
			this._unitName = name;
		}
	}

	// Token: 0x060046FC RID: 18172 RVA: 0x001D1054 File Offset: 0x001CF454
	public List<JourneyContributionModifier> GetContributions()
	{
		double num = this.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
		double num2 = this.GetAttributeValue_Final(AttributeType.CritRate, AttributeRetrievalLevel.Skill);
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		double attributeValue_Final = this.GetAttributeValue_Final(AttributeType.CritDamage, AttributeRetrievalLevel.Skill);
		num = num * (1.0 + num2) * attributeValue_Final;
		double num3 = num / (num + 4000.0);
		double num4 = UnitExtensions.GetAllResistances().Sum((AttributeType r) => this.GetAttributeValue_Final(r, AttributeRetrievalLevel.Skill)) / Convert.ToDouble(UnitExtensions.GetAllResistances().Count);
		double num5 = num4 / (num4 + 3000.0);
		double attributeValue_Final2 = this.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill);
		double num6 = attributeValue_Final2 / (attributeValue_Final2 + 3000.0);
		double num7 = (num5 + num6) / 2.0;
		double attributeValue_Final3 = this.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
		double num8 = attributeValue_Final3 / (attributeValue_Final3 + 3000.0);
		double value = (num3 + num7 + num8) * 100.0;
		return new List<JourneyContributionModifier>
		{
			new JourneyContributionModifier
			{
				Value = value,
				Key = string.Empty,
				Type = JourneyContributeType.BattleSkill
			}
		};
	}

	// Token: 0x060046FD RID: 18173 RVA: 0x001D1180 File Offset: 0x001CF580
	[CompilerGenerated]
	private static bool <GetAdventurerStarEffects>m__0(ISpecialEffectDataLoad e)
	{
		return e.GetSpecialEffectType().IsStarAdventurerEffect();
	}

	// Token: 0x060046FE RID: 18174 RVA: 0x001D118D File Offset: 0x001CF58D
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetSpecialEffects>m__1(Item i)
	{
		return i.GetSpecialEffects();
	}

	// Token: 0x060046FF RID: 18175 RVA: 0x001D1195 File Offset: 0x001CF595
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetSpecialEffects>m__2(SetItemResult b)
	{
		return b.MajorEffects;
	}

	// Token: 0x06004700 RID: 18176 RVA: 0x001D119D File Offset: 0x001CF59D
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <GetSpecialEffects>m__3(SetItemResult b)
	{
		return b.MinorEffects;
	}

	// Token: 0x06004701 RID: 18177 RVA: 0x001D11A5 File Offset: 0x001CF5A5
	[CompilerGenerated]
	private static bool <GetSpecialEffects>m__4(IAdventurerTalent t)
	{
		return t.GetCurrentLevel() > 0;
	}

	// Token: 0x06004702 RID: 18178 RVA: 0x001D11B0 File Offset: 0x001CF5B0
	[CompilerGenerated]
	private IEnumerable<ISpecialEffectDataLoad> <GetSpecialEffects>m__5(IAdventurerTalent c)
	{
		return c.GetSpecialEffects(this);
	}

	// Token: 0x06004703 RID: 18179 RVA: 0x001D11B9 File Offset: 0x001CF5B9
	[CompilerGenerated]
	private static bool <CanAssignAutoTactic>m__6(Skill sk)
	{
		return sk.CommandType == SkillCommandType.Active;
	}

	// Token: 0x06004704 RID: 18180 RVA: 0x001D11C4 File Offset: 0x001CF5C4
	[CompilerGenerated]
	private static bool <TacticCanbeAutoResolved>m__7(Skill sk)
	{
		return sk.CommandType == SkillCommandType.Active;
	}

	// Token: 0x06004705 RID: 18181 RVA: 0x001D11CF File Offset: 0x001CF5CF
	[CompilerGenerated]
	private static bool <Equip>m__8(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Accessory;
	}

	// Token: 0x06004706 RID: 18182 RVA: 0x001D11E0 File Offset: 0x001CF5E0
	[CompilerGenerated]
	private static bool <Equip>m__9(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Scrolls;
	}

	// Token: 0x06004707 RID: 18183 RVA: 0x001D11F1 File Offset: 0x001CF5F1
	[CompilerGenerated]
	private static bool <Equip>m__A(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Amulet;
	}

	// Token: 0x06004708 RID: 18184 RVA: 0x001D1202 File Offset: 0x001CF602
	[CompilerGenerated]
	private static bool <Equip>m__B(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06004709 RID: 18185 RVA: 0x001D1213 File Offset: 0x001CF613
	[CompilerGenerated]
	private static bool <Equip>m__C(Item i)
	{
		return i.Type.GetResourceCategory().IsWeapon();
	}

	// Token: 0x0600470A RID: 18186 RVA: 0x001D1225 File Offset: 0x001CF625
	[CompilerGenerated]
	private static bool <Equip>m__D(Item i)
	{
		return i.Type.GetResourceCategory().IsArmor();
	}

	// Token: 0x0600470B RID: 18187 RVA: 0x001D1237 File Offset: 0x001CF637
	[CompilerGenerated]
	private static bool <GetSkills>m__E(Skill r)
	{
		return r.CommandType == SkillCommandType.Active;
	}

	// Token: 0x0600470C RID: 18188 RVA: 0x001D1242 File Offset: 0x001CF642
	[CompilerGenerated]
	private bool <IsInBattle>m__F(AdventurerBattleUnit ad)
	{
		return ad.AdventurerId == this.Id;
	}

	// Token: 0x0600470D RID: 18189 RVA: 0x001D1255 File Offset: 0x001CF655
	[CompilerGenerated]
	private bool <LevelUpLogic>m__10(OutputType o)
	{
		return o != this.OutputType;
	}

	// Token: 0x0600470E RID: 18190 RVA: 0x001D1264 File Offset: 0x001CF664
	[CompilerGenerated]
	private static ElementEffectData <LevelUpLogic>m__11(OutputType o)
	{
		return new ElementEffectData
		{
			IsStarEf = new bool?(false),
			ElementType = o
		};
	}

	// Token: 0x0600470F RID: 18191 RVA: 0x001D128B File Offset: 0x001CF68B
	[CompilerGenerated]
	private double <GetContributions>m__12(AttributeType r)
	{
		return this.GetAttributeValue_Final(r, AttributeRetrievalLevel.Skill);
	}

	// Token: 0x04003910 RID: 14608
	[NonSerialized]
	public Action<UnitLevelConfiguration, long, long> ReceivesExp;

	// Token: 0x04003911 RID: 14609
	[NonSerialized]
	public Action<int, int, UnitLevelUpChange> LevelUp;

	// Token: 0x04003912 RID: 14610
	[NonSerialized]
	public Action<Item> ItemEquipped;

	// Token: 0x04003913 RID: 14611
	[NonSerialized]
	public Action<Item> ItemDisrobed;

	// Token: 0x04003914 RID: 14612
	public QualityGrade Grade;

	// Token: 0x04003915 RID: 14613
	public TownSlot WorkingBuilding;

	// Token: 0x04003916 RID: 14614
	public OutputType OutputType;

	// Token: 0x04003917 RID: 14615
	public int Level;

	// Token: 0x04003918 RID: 14616
	public long Experience;

	// Token: 0x04003919 RID: 14617
	public long? CurrentExperienceAdd35;

	// Token: 0x0400391A RID: 14618
	public long? CurrentExperienceMultiply3;

	// Token: 0x0400391B RID: 14619
	public UnitClass UnitClass;

	// Token: 0x0400391C RID: 14620
	public List<ISpecialEffectDataLoad> SpecialEffects;

	// Token: 0x0400391D RID: 14621
	public double QualityCoefficient;

	// Token: 0x0400391E RID: 14622
	public string Id;

	// Token: 0x0400391F RID: 14623
	private string _unitName;

	// Token: 0x04003920 RID: 14624
	public List<AttributeModifier> Attributes = new List<AttributeModifier>();

	// Token: 0x04003921 RID: 14625
	public List<AttributeModifier> NakedAttributes = new List<AttributeModifier>();

	// Token: 0x04003922 RID: 14626
	public int SkillSlots;

	// Token: 0x04003923 RID: 14627
	public List<SkillType> Skills;

	// Token: 0x04003924 RID: 14628
	public List<CardUpgrade> AvaliableUpgradeOptions;

	// Token: 0x04003925 RID: 14629
	public List<CardUpgrade> UpgradedCards;

	// Token: 0x04003926 RID: 14630
	public double RecentReRollPrice;

	// Token: 0x04003927 RID: 14631
	public List<string> Equipments;

	// Token: 0x04003928 RID: 14632
	public List<Item> EquippedItems;

	// Token: 0x04003929 RID: 14633
	public List<IAdventurerTalent> Talents;

	// Token: 0x0400392A RID: 14634
	public int TalentPoints;

	// Token: 0x0400392B RID: 14635
	public string TalentVersionDetails;

	// Token: 0x0400392C RID: 14636
	[NonSerialized]
	public Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> AttributeValues;

	// Token: 0x0400392D RID: 14637
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache0;

	// Token: 0x0400392E RID: 14638
	[CompilerGenerated]
	private static Func<Item, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache1;

	// Token: 0x0400392F RID: 14639
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache2;

	// Token: 0x04003930 RID: 14640
	[CompilerGenerated]
	private static Func<SetItemResult, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache3;

	// Token: 0x04003931 RID: 14641
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache4;

	// Token: 0x04003932 RID: 14642
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache5;

	// Token: 0x04003933 RID: 14643
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache6;

	// Token: 0x04003934 RID: 14644
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache7;

	// Token: 0x04003935 RID: 14645
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache8;

	// Token: 0x04003936 RID: 14646
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache9;

	// Token: 0x04003937 RID: 14647
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheA;

	// Token: 0x04003938 RID: 14648
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheB;

	// Token: 0x04003939 RID: 14649
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheC;

	// Token: 0x0400393A RID: 14650
	[CompilerGenerated]
	private static Func<SkillType, Skill> <>f__mg$cache0;

	// Token: 0x0400393B RID: 14651
	[CompilerGenerated]
	private static Func<SkillType, Skill> <>f__mg$cache1;

	// Token: 0x0400393C RID: 14652
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cacheD;

	// Token: 0x0400393D RID: 14653
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cacheE;

	// Token: 0x02001041 RID: 4161
	[CompilerGenerated]
	private sealed class <Equip>c__AnonStorey0
	{
		// Token: 0x0600685D RID: 26717 RVA: 0x001D1295 File Offset: 0x001CF695
		public <Equip>c__AnonStorey0()
		{
		}

		// Token: 0x0600685E RID: 26718 RVA: 0x001D129D File Offset: 0x001CF69D
		internal bool <>m__0(Item i)
		{
			return i == this.item;
		}

		// Token: 0x0400621D RID: 25117
		internal Item item;
	}

	// Token: 0x02001042 RID: 4162
	[CompilerGenerated]
	private sealed class <Disrobe>c__AnonStorey1
	{
		// Token: 0x0600685F RID: 26719 RVA: 0x001D12A8 File Offset: 0x001CF6A8
		public <Disrobe>c__AnonStorey1()
		{
		}

		// Token: 0x06006860 RID: 26720 RVA: 0x001D12B0 File Offset: 0x001CF6B0
		internal bool <>m__0(Item i)
		{
			return i == this.equipment;
		}

		// Token: 0x06006861 RID: 26721 RVA: 0x001D12BB File Offset: 0x001CF6BB
		internal bool <>m__1(Item i)
		{
			return i != this.equipment;
		}

		// Token: 0x0400621E RID: 25118
		internal Item equipment;
	}

	// Token: 0x02001043 RID: 4163
	[CompilerGenerated]
	private sealed class <GetOutputElementDetails>c__AnonStorey2
	{
		// Token: 0x06006862 RID: 26722 RVA: 0x001D12C9 File Offset: 0x001CF6C9
		public <GetOutputElementDetails>c__AnonStorey2()
		{
		}

		// Token: 0x06006863 RID: 26723 RVA: 0x001D12D1 File Offset: 0x001CF6D1
		internal bool <>m__0(ElementEffectData e)
		{
			return e.ElementType == this.outputtype;
		}

		// Token: 0x0400621F RID: 25119
		internal OutputType outputtype;
	}

	// Token: 0x02001044 RID: 4164
	[CompilerGenerated]
	private sealed class <GetSkills>c__AnonStorey3
	{
		// Token: 0x06006864 RID: 26724 RVA: 0x001D12E1 File Offset: 0x001CF6E1
		public <GetSkills>c__AnonStorey3()
		{
		}

		// Token: 0x06006865 RID: 26725 RVA: 0x001D12E9 File Offset: 0x001CF6E9
		internal bool <>m__0(Skill s)
		{
			return s.SkillType != this.passive.SkillType;
		}

		// Token: 0x04006220 RID: 25120
		internal Skill passive;
	}

	// Token: 0x02001045 RID: 4165
	[CompilerGenerated]
	private sealed class <DirectlyEnableSkill>c__AnonStorey4
	{
		// Token: 0x06006866 RID: 26726 RVA: 0x001D1301 File Offset: 0x001CF701
		public <DirectlyEnableSkill>c__AnonStorey4()
		{
		}

		// Token: 0x06006867 RID: 26727 RVA: 0x001D1309 File Offset: 0x001CF709
		internal bool <>m__0(SkillType sk)
		{
			return sk.GetSkillLogic().SkillCommandType != this.skill.CommandType;
		}

		// Token: 0x04006221 RID: 25121
		internal Skill skill;
	}

	// Token: 0x02001046 RID: 4166
	[CompilerGenerated]
	private sealed class <GetEquipments>c__AnonStorey5
	{
		// Token: 0x06006868 RID: 26728 RVA: 0x001D1326 File Offset: 0x001CF726
		public <GetEquipments>c__AnonStorey5()
		{
		}

		// Token: 0x06006869 RID: 26729 RVA: 0x001D132E File Offset: 0x001CF72E
		internal bool <>m__0(Item i)
		{
			return i.Id == this.equipment;
		}

		// Token: 0x04006222 RID: 25122
		internal string equipment;
	}
}
