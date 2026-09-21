using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

// Token: 0x02000427 RID: 1063
public class Adventure
{
	// Token: 0x06001D4F RID: 7503 RVA: 0x000C79EB File Offset: 0x000C5DEB
	public Adventure()
	{
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06001D50 RID: 7504 RVA: 0x000C7A00 File Offset: 0x000C5E00
	// (remove) Token: 0x06001D51 RID: 7505 RVA: 0x000C7A38 File Offset: 0x000C5E38
	public event Func<Adventure, IEnumerable> AdventureInitialized
	{
		add
		{
			Func<Adventure, IEnumerable> func = this.AdventureInitialized;
			Func<Adventure, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<Adventure, IEnumerable>>(ref this.AdventureInitialized, (Func<Adventure, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<Adventure, IEnumerable> func = this.AdventureInitialized;
			Func<Adventure, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<Adventure, IEnumerable>>(ref this.AdventureInitialized, (Func<Adventure, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06001D52 RID: 7506 RVA: 0x000C7A70 File Offset: 0x000C5E70
	// (remove) Token: 0x06001D53 RID: 7507 RVA: 0x000C7AA8 File Offset: 0x000C5EA8
	public event Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> AdventureCompletes
	{
		add
		{
			Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> func = this.AdventureCompletes;
			Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable>>(ref this.AdventureCompletes, (Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> func = this.AdventureCompletes;
			Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable>>(ref this.AdventureCompletes, (Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06001D54 RID: 7508 RVA: 0x000C7AE0 File Offset: 0x000C5EE0
	// (remove) Token: 0x06001D55 RID: 7509 RVA: 0x000C7B18 File Offset: 0x000C5F18
	public event Func<List<AdventurerBattleUnit>, IEnumerable> AdventuresWalking
	{
		add
		{
			Func<List<AdventurerBattleUnit>, IEnumerable> func = this.AdventuresWalking;
			Func<List<AdventurerBattleUnit>, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEnumerable>>(ref this.AdventuresWalking, (Func<List<AdventurerBattleUnit>, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<List<AdventurerBattleUnit>, IEnumerable> func = this.AdventuresWalking;
			Func<List<AdventurerBattleUnit>, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEnumerable>>(ref this.AdventuresWalking, (Func<List<AdventurerBattleUnit>, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06001D56 RID: 7510 RVA: 0x000C7B50 File Offset: 0x000C5F50
	// (remove) Token: 0x06001D57 RID: 7511 RVA: 0x000C7B88 File Offset: 0x000C5F88
	public event Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> AdventuresCompleteCollectChestFinalRewards
	{
		add
		{
			Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> func = this.AdventuresCompleteCollectChestFinalRewards;
			Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable>>(ref this.AdventuresCompleteCollectChestFinalRewards, (Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> func = this.AdventuresCompleteCollectChestFinalRewards;
			Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable>>(ref this.AdventuresCompleteCollectChestFinalRewards, (Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x06001D58 RID: 7512 RVA: 0x000C7BC0 File Offset: 0x000C5FC0
	public static double CalculateMaxActionCounts(double original, List<AdventurerBattleUnit> adventurers)
	{
		double num = 1.0;
		int num2 = adventurers.Count((AdventurerBattleUnit ad) => ad.GetUnitClassStyle() == UnitClassStyle.PhysicalSupporter || ad.GetUnitClassStyle() == UnitClassStyle.SpellSupporter);
		num += (double)num2 * 0.1;
		int num3 = adventurers.Count((AdventurerBattleUnit ad) => ad.GetUnitClassStyle() == UnitClassStyle.Healer);
		num += (double)num3 * 0.15;
		double num4 = original + (from ad in adventurers
		where ad.GetUnitClassStyle() == UnitClassStyle.PhysicalSupporter || ad.GetUnitClassStyle() == UnitClassStyle.SpellSupporter
		select ad).Sum((AdventurerBattleUnit ad) => ad.SpecialEffects.OfType<AdventureEnergyBoostByValueData>().Sum((AdventureEnergyBoostByValueData a) => a.Value * 4.0));
		return num4 * num;
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x000C7C88 File Offset: 0x000C6088
	public void ProcessorInitialize()
	{
		this.FactionProcessorsDictionary = new Dictionary<AdventureEventType, List<IFactionProcessor>>();
		foreach (KeyValuePair<GameFactionType, IFactionProcessor> keyValuePair in FactionExtensions.FactionProcessors)
		{
			foreach (AdventureEventType key in keyValuePair.Value.CorrespondingEvents().Distinct<AdventureEventType>())
			{
				if (this.FactionProcessorsDictionary.ContainsKey(key))
				{
					this.FactionProcessorsDictionary[key].Add(keyValuePair.Value);
				}
				else
				{
					this.FactionProcessorsDictionary.Add(key, new List<IFactionProcessor>
					{
						keyValuePair.Value
					});
				}
			}
		}
		this.QuestRequirementsDictionary = new Dictionary<AdventureEventType, List<QuestRequirementBase>>();
		foreach (Quest quest in GameWorld.instance.PlayerProfile.GetProgress(null).Quests)
		{
			foreach (QuestRequirementBase questRequirementBase in quest.QuestRequirements)
			{
				foreach (AdventureEventType key2 in questRequirementBase.CorrespondingEvents().Distinct<AdventureEventType>())
				{
					if (this.QuestRequirementsDictionary.ContainsKey(key2))
					{
						this.QuestRequirementsDictionary[key2].Add(questRequirementBase);
					}
					else
					{
						this.QuestRequirementsDictionary.Add(key2, new List<QuestRequirementBase>
						{
							questRequirementBase
						});
					}
				}
			}
		}
		this.PlayerEffectsDictionary = new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>();
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in this.PlayerEffects)
		{
			if (specialEffectDataLoad.GetSpecialEffectType().HasProcessor())
			{
				SpecialEffectProcessBase specialProcessor = specialEffectDataLoad.GetSpecialEffectType().GetSpecialProcessor();
				foreach (AdventureEventType key3 in specialProcessor.CorrespondingEvents.Distinct<AdventureEventType>())
				{
					if (this.PlayerEffectsDictionary.ContainsKey(key3))
					{
						this.PlayerEffectsDictionary[key3].Add(specialEffectDataLoad);
					}
					else
					{
						this.PlayerEffectsDictionary.Add(key3, new List<ISpecialEffectDataLoad>
						{
							specialEffectDataLoad
						});
					}
				}
			}
		}
		this.DungeonEffectsDictionary = new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>();
		foreach (ISpecialEffectDataLoad specialEffectDataLoad2 in this.DungeonEffects)
		{
			if (specialEffectDataLoad2.GetSpecialEffectType().HasProcessor())
			{
				SpecialEffectProcessBase specialProcessor2 = specialEffectDataLoad2.GetSpecialEffectType().GetSpecialProcessor();
				foreach (AdventureEventType key4 in specialProcessor2.CorrespondingEvents.Distinct<AdventureEventType>())
				{
					if (this.DungeonEffectsDictionary.ContainsKey(key4))
					{
						this.DungeonEffectsDictionary[key4].Add(specialEffectDataLoad2);
					}
					else
					{
						this.DungeonEffectsDictionary.Add(key4, new List<ISpecialEffectDataLoad>
						{
							specialEffectDataLoad2
						});
					}
				}
			}
		}
		this.BattleEffectsDictionary = new Dictionary<string, Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>>();
		this.BattleUnitSpecialEffectsDictionary = new Dictionary<string, Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>>();
		foreach (AdventurerBattleUnit adventurerBattleUnit in this.Adventurers)
		{
			if (!this.BattleUnitSpecialEffectsDictionary.ContainsKey(adventurerBattleUnit.GetId()))
			{
				this.BattleUnitSpecialEffectsDictionary.Add(adventurerBattleUnit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
			}
			Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary = this.BattleUnitSpecialEffectsDictionary[adventurerBattleUnit.GetId()];
			foreach (ISpecialEffectDataLoad specialEffectDataLoad3 in adventurerBattleUnit.SpecialEffects)
			{
				if (specialEffectDataLoad3.GetSpecialEffectType().HasProcessor())
				{
					SpecialEffectProcessBase specialProcessor3 = specialEffectDataLoad3.GetSpecialEffectType().GetSpecialProcessor();
					foreach (AdventureEventType key5 in specialProcessor3.CorrespondingEvents.Distinct<AdventureEventType>())
					{
						if (dictionary.ContainsKey(key5))
						{
							dictionary[key5].Add(specialEffectDataLoad3);
						}
						else
						{
							dictionary.Add(key5, new List<ISpecialEffectDataLoad>
							{
								specialEffectDataLoad3
							});
						}
					}
				}
			}
		}
		foreach (IBattleUnit battleUnit in this.Encounters.SelectMany((IEncounter e) => e.EnemyUnits))
		{
			if (!this.BattleUnitSpecialEffectsDictionary.ContainsKey(battleUnit.GetId()))
			{
				this.BattleUnitSpecialEffectsDictionary.Add(battleUnit.GetId(), new Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>());
			}
			Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> dictionary2 = this.BattleUnitSpecialEffectsDictionary[battleUnit.GetId()];
			foreach (ISpecialEffectDataLoad specialEffectDataLoad4 in battleUnit.SpecialEffects)
			{
				if (specialEffectDataLoad4.GetSpecialEffectType().HasProcessor())
				{
					SpecialEffectProcessBase specialProcessor4 = specialEffectDataLoad4.GetSpecialEffectType().GetSpecialProcessor();
					foreach (AdventureEventType key6 in specialProcessor4.CorrespondingEvents.Distinct<AdventureEventType>())
					{
						if (dictionary2.ContainsKey(key6))
						{
							dictionary2[key6].Add(specialEffectDataLoad4);
						}
						else
						{
							dictionary2.Add(key6, new List<ISpecialEffectDataLoad>
							{
								specialEffectDataLoad4
							});
						}
					}
				}
			}
		}
		this.AttributeProcessDictionary = new Dictionary<AdventureEventType, List<AttributeProcessBase>>();
		foreach (KeyValuePair<AttributeType, AttributeProcessBase> keyValuePair2 in GameConfigurations.AttributeProcess)
		{
			foreach (AdventureEventType key7 in keyValuePair2.Value.CorrespondingEvents().Distinct<AdventureEventType>())
			{
				if (this.AttributeProcessDictionary.ContainsKey(key7))
				{
					this.AttributeProcessDictionary[key7].Add(keyValuePair2.Value);
				}
				else
				{
					this.AttributeProcessDictionary.Add(key7, new List<AttributeProcessBase>
					{
						keyValuePair2.Value
					});
				}
			}
		}
		this.SkillsDictionary = new Dictionary<string, Dictionary<AdventureEventType, List<AdventureUnitSkill>>>();
		foreach (AdventurerBattleUnit adventurerBattleUnit2 in this.Adventurers)
		{
			if (!this.SkillsDictionary.ContainsKey(adventurerBattleUnit2.GetId()))
			{
				this.SkillsDictionary.Add(adventurerBattleUnit2.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
			}
			Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary3 = this.SkillsDictionary[adventurerBattleUnit2.GetId()];
			foreach (AdventureUnitSkill adventureUnitSkill in adventurerBattleUnit2.Skills)
			{
				foreach (AdventureEventType key8 in adventureUnitSkill.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
				{
					if (dictionary3.ContainsKey(key8))
					{
						dictionary3[key8].Add(adventureUnitSkill);
					}
					else
					{
						dictionary3.Add(key8, new List<AdventureUnitSkill>
						{
							adventureUnitSkill
						});
					}
				}
			}
		}
		foreach (IBattleUnit battleUnit2 in this.Encounters.SelectMany((IEncounter e) => e.EnemyUnits))
		{
			if (!this.SkillsDictionary.ContainsKey(battleUnit2.GetId()))
			{
				this.SkillsDictionary.Add(battleUnit2.GetId(), new Dictionary<AdventureEventType, List<AdventureUnitSkill>>());
			}
			Dictionary<AdventureEventType, List<AdventureUnitSkill>> dictionary4 = this.SkillsDictionary[battleUnit2.GetId()];
			foreach (AdventureUnitSkill adventureUnitSkill2 in battleUnit2.Skills)
			{
				foreach (AdventureEventType key9 in adventureUnitSkill2.GetSkillLogic().CorrespondingEvents().Distinct<AdventureEventType>())
				{
					if (dictionary4.ContainsKey(key9))
					{
						dictionary4[key9].Add(adventureUnitSkill2);
					}
					else
					{
						dictionary4.Add(key9, new List<AdventureUnitSkill>
						{
							adventureUnitSkill2
						});
					}
				}
			}
		}
	}

	// Token: 0x06001D5A RID: 7514 RVA: 0x000C88FC File Offset: 0x000C6CFC
	public double? TimeLeft()
	{
		if (this.ActionCountPossible != null && this.ActionCountSoFar != null)
		{
			return new double?(this.ActionCountPossible.Value - this.ActionCountSoFar.Value);
		}
		return null;
	}

	// Token: 0x06001D5B RID: 7515 RVA: 0x000C8950 File Offset: 0x000C6D50
	public void AddDamageRecord(AdventurerBattleUnit dealer, double value)
	{
		if (this.DamageBoard.ContainsKey(dealer))
		{
			Dictionary<AdventurerBattleUnit, double> damageBoard;
			(damageBoard = this.DamageBoard)[dealer] = damageBoard[dealer] + value;
		}
		else
		{
			this.DamageBoard.Add(dealer, value);
		}
	}

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06001D5C RID: 7516 RVA: 0x000C899C File Offset: 0x000C6D9C
	// (remove) Token: 0x06001D5D RID: 7517 RVA: 0x000C89D4 File Offset: 0x000C6DD4
	public event Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> AdventuresCompleteEncounter
	{
		add
		{
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func = this.AdventuresCompleteEncounter;
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>>(ref this.AdventuresCompleteEncounter, (Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func = this.AdventuresCompleteEncounter;
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>>(ref this.AdventuresCompleteEncounter, (Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x14000008 RID: 8
	// (add) Token: 0x06001D5E RID: 7518 RVA: 0x000C8A0C File Offset: 0x000C6E0C
	// (remove) Token: 0x06001D5F RID: 7519 RVA: 0x000C8A44 File Offset: 0x000C6E44
	public event Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> AdventuresEnterEncounter
	{
		add
		{
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func = this.AdventuresEnterEncounter;
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>>(ref this.AdventuresEnterEncounter, (Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>)Delegate.Combine(func2, value), func);
			}
			while (func != func2);
		}
		remove
		{
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func = this.AdventuresEnterEncounter;
			Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> func2;
			do
			{
				func2 = func;
				func = Interlocked.CompareExchange<Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>>(ref this.AdventuresEnterEncounter, (Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable>)Delegate.Remove(func2, value), func);
			}
			while (func != func2);
		}
	}

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x06001D60 RID: 7520 RVA: 0x000C8A7A File Offset: 0x000C6E7A
	// (set) Token: 0x06001D61 RID: 7521 RVA: 0x000C8A82 File Offset: 0x000C6E82
	public int LevelNumber
	{
		[CompilerGenerated]
		get
		{
			return this.<LevelNumber>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LevelNumber>k__BackingField = value;
		}
	}

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x06001D62 RID: 7522 RVA: 0x000C8A8B File Offset: 0x000C6E8B
	// (set) Token: 0x06001D63 RID: 7523 RVA: 0x000C8A93 File Offset: 0x000C6E93
	public List<IEncounter> Encounters
	{
		[CompilerGenerated]
		get
		{
			return this.<Encounters>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Encounters>k__BackingField = value;
		}
	}

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x06001D64 RID: 7524 RVA: 0x000C8A9C File Offset: 0x000C6E9C
	// (set) Token: 0x06001D65 RID: 7525 RVA: 0x000C8AA4 File Offset: 0x000C6EA4
	public List<ResourceUpdate> CompleteRewardList
	{
		[CompilerGenerated]
		get
		{
			return this.<CompleteRewardList>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CompleteRewardList>k__BackingField = value;
		}
	}

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x06001D66 RID: 7526 RVA: 0x000C8AAD File Offset: 0x000C6EAD
	// (set) Token: 0x06001D67 RID: 7527 RVA: 0x000C8AB5 File Offset: 0x000C6EB5
	public List<AdventurerBattleUnit> Adventurers
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurers>k__BackingField = value;
		}
	}

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x06001D68 RID: 7528 RVA: 0x000C8ABE File Offset: 0x000C6EBE
	// (set) Token: 0x06001D69 RID: 7529 RVA: 0x000C8AC6 File Offset: 0x000C6EC6
	public List<Chest> Chests
	{
		[CompilerGenerated]
		get
		{
			return this.<Chests>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Chests>k__BackingField = value;
		}
	}

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x06001D6A RID: 7530 RVA: 0x000C8ACF File Offset: 0x000C6ECF
	// (set) Token: 0x06001D6B RID: 7531 RVA: 0x000C8AD7 File Offset: 0x000C6ED7
	public AdventureType AdventureType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventureType>k__BackingField = value;
		}
	}

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x06001D6C RID: 7532 RVA: 0x000C8AE0 File Offset: 0x000C6EE0
	// (set) Token: 0x06001D6D RID: 7533 RVA: 0x000C8AE8 File Offset: 0x000C6EE8
	public Adventure.SurvivalStatus Survivied
	{
		[CompilerGenerated]
		get
		{
			return this.<Survivied>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Survivied>k__BackingField = value;
		}
	}

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06001D6E RID: 7534 RVA: 0x000C8AF1 File Offset: 0x000C6EF1
	// (set) Token: 0x06001D6F RID: 7535 RVA: 0x000C8AF9 File Offset: 0x000C6EF9
	public List<ISpecialEffectDataLoad> PlayerEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<PlayerEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PlayerEffects>k__BackingField = value;
		}
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06001D70 RID: 7536 RVA: 0x000C8B02 File Offset: 0x000C6F02
	// (set) Token: 0x06001D71 RID: 7537 RVA: 0x000C8B0A File Offset: 0x000C6F0A
	public List<ISpecialEffectDataLoad> DungeonEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<DungeonEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DungeonEffects>k__BackingField = value;
		}
	}

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x06001D72 RID: 7538 RVA: 0x000C8B13 File Offset: 0x000C6F13
	// (set) Token: 0x06001D73 RID: 7539 RVA: 0x000C8B1B File Offset: 0x000C6F1B
	public DifficultyLevelMeasurement CorrespondingDifficultyMeasurement
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingDifficultyMeasurement>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CorrespondingDifficultyMeasurement>k__BackingField = value;
		}
	}

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x06001D74 RID: 7540 RVA: 0x000C8B24 File Offset: 0x000C6F24
	// (set) Token: 0x06001D75 RID: 7541 RVA: 0x000C8B2C File Offset: 0x000C6F2C
	public AdventureLevelConfiguration CorrespondingLevelConfiguration
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingLevelConfiguration>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CorrespondingLevelConfiguration>k__BackingField = value;
		}
	}

	// Token: 0x06001D76 RID: 7542 RVA: 0x000C8B35 File Offset: 0x000C6F35
	public int GetReleventMonsterLevel()
	{
		return this.CorrespondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion);
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x000C8B44 File Offset: 0x000C6F44
	private IEnumerable<IEncounter> GetEncounters()
	{
		foreach (IEncounter encounter in this.Encounters)
		{
			yield return encounter;
		}
		yield break;
	}

	// Token: 0x06001D78 RID: 7544 RVA: 0x000C8B68 File Offset: 0x000C6F68
	public static Adventure InitializeAdventureBaseOnLevel(AdventureStartParameter paramter, AdventureLevelConfiguration configuration, DifficultyLevelMeasurement correspondingDifficultyMeasurement)
	{
		foreach (ResourceType resourceType in paramter.Consumables)
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = resourceType,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>()
				}
			});
		}
		Adventure adventure = new Adventure
		{
			LevelNumber = configuration.LevelNumber,
			Adventurers = new List<AdventurerBattleUnit>(),
			AdventureType = paramter.AdventureType,
			Encounters = new List<IEncounter>(),
			CompleteRewardList = new List<ResourceUpdate>(),
			CurrentEncounter = null,
			Chests = new List<Chest>(),
			DungeonEffects = configuration.DungeonEffects,
			PlayerEffects = new List<ISpecialEffectDataLoad>(),
			CorrespondingDifficultyMeasurement = correspondingDifficultyMeasurement,
			CorrespondingLevelConfiguration = configuration,
			AdventureCode = configuration.CustomizedIdentityCode
		};
		adventure.Adventurers = (from a in paramter.SelectedAdventurers
		select AdventurerBattleUnit.InitializeAdventurerBattleUnit(a, adventure)).ToList<AdventurerBattleUnit>();
		adventure.Chests = Chest.GenerateChests(5, correspondingDifficultyMeasurement);
		adventure.Encounters.AddRange(configuration.GetEncounters(adventure.Adventurers.Cast<IBattleUnit>().ToList<IBattleUnit>(), adventure));
		adventure.PlayerEffects.AddRange(paramter.Consumables.SelectMany((ResourceType c) => c.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal)));
		adventure.PlayerEffects.AddRange(GameWorld.instance.PlayerProfile.GetTownEffects().SelectMany((TownEffectBase ef) => ef.GetPlayerEffectsForAdventure()));
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurePreInitialization, adventure);
		return adventure;
	}

	// Token: 0x06001D79 RID: 7545 RVA: 0x000C8DA4 File Offset: 0x000C71A4
	public IEnumerable Run()
	{
		this.Survivied = Adventure.SurvivalStatus.Surviving;
		this.ProcessorInitialize();
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventureInitialized, null)).GetEnumerator();
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
		foreach (AdventurerBattleUnit adventurerBattleUnit in this.Adventurers)
		{
			IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit, AdventureEventType.AdventurerPreWalking, null)).GetEnumerator();
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
		this.RunePower = new RunePowerDetails(this.Adventurers);
		IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventurersWalking, this.Adventurers)).GetEnumerator();
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
		foreach (AdventurerBattleUnit adventurerBattleUnit2 in this.Adventurers)
		{
			IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit2, AdventureEventType.AdventurerPostWalking, null)).GetEnumerator();
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
		}
		if (this.Survivied == Adventure.SurvivalStatus.Surviving)
		{
			double previousPlayerGauge = 0.0;
			bool firstStart = true;
			foreach (IEncounter encounter in this.GetEncounters())
			{
				if (this.Survivied == Adventure.SurvivalStatus.Surviving)
				{
					this.CurrentEncounter = encounter;
					foreach (AdventurerBattleUnit adventurerBattleUnit3 in this.Adventurers)
					{
						IEnumerator enumerator9 = adventurerBattleUnit3.EntersEncounter(this.CurrentEncounter).GetEnumerator();
						try
						{
							while (enumerator9.MoveNext())
							{
								object _5 = enumerator9.Current;
								yield return _5;
							}
						}
						finally
						{
							IDisposable disposable5;
							if ((disposable5 = (enumerator9 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					foreach (IBattleUnit currentEncounterEnemyUnit in this.CurrentEncounter.EnemyUnits)
					{
						IEnumerator enumerator11 = currentEncounterEnemyUnit.EntersEncounter(this.CurrentEncounter).GetEnumerator();
						try
						{
							while (enumerator11.MoveNext())
							{
								object _6 = enumerator11.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator11 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
					IEnumerator enumerator12 = this.OnAdventuresEnterEncounter(this.Adventurers, this.CurrentEncounter).GetEnumerator();
					try
					{
						while (enumerator12.MoveNext())
						{
							object _7 = enumerator12.Current;
							yield return _7;
						}
					}
					finally
					{
						IDisposable disposable7;
						if ((disposable7 = (enumerator12 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
					if (this.CurrentEncounter is BattleEncounter)
					{
						BattleEncounter battleEncounter = this.CurrentEncounter as BattleEncounter;
						IEnumerator enumerator13 = battleEncounter.UpdatePlayerGauge(previousPlayerGauge, this.Adventurers.FirstOrDefault<AdventurerBattleUnit>()).GetEnumerator();
						try
						{
							while (enumerator13.MoveNext())
							{
								object _8 = enumerator13.Current;
								yield return _8;
							}
						}
						finally
						{
							IDisposable disposable8;
							if ((disposable8 = (enumerator13 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
					if (firstStart)
					{
						firstStart = false;
						foreach (IBattleUnit player in this.CurrentEncounter.PlayerUnits)
						{
							IEnumerator enumerator15 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(player, AdventureEventType.FirstEncounterStarted, player)).GetEnumerator();
							try
							{
								while (enumerator15.MoveNext())
								{
									object _9 = enumerator15.Current;
									yield return _9;
								}
							}
							finally
							{
								IDisposable disposable9;
								if ((disposable9 = (enumerator15 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						foreach (IBattleUnit player2 in this.CurrentEncounter.EnemyUnits)
						{
							IEnumerator enumerator17 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(player2, AdventureEventType.FirstEncounterStarted, player2)).GetEnumerator();
							try
							{
								while (enumerator17.MoveNext())
								{
									object _10 = enumerator17.Current;
									yield return _10;
								}
							}
							finally
							{
								IDisposable disposable10;
								if ((disposable10 = (enumerator17 as IDisposable)) != null)
								{
									disposable10.Dispose();
								}
							}
						}
					}
					this.InBattle = true;
					IEnumerator enumerator18 = this.CurrentEncounter.Run().GetEnumerator();
					try
					{
						while (enumerator18.MoveNext())
						{
							object _11 = enumerator18.Current;
							yield return _11;
						}
					}
					finally
					{
						IDisposable disposable11;
						if ((disposable11 = (enumerator18 as IDisposable)) != null)
						{
							disposable11.Dispose();
						}
					}
					this.InBattle = false;
					IEncounter recordEncounter = this.CurrentEncounter;
					if (recordEncounter is BattleEncounter)
					{
						previousPlayerGauge = (recordEncounter as BattleEncounter).PlayerGauge;
					}
					foreach (IBattleUnit adventurerBattleUnit4 in this.CurrentEncounter.PlayerUnits)
					{
						IEnumerator enumerator20 = adventurerBattleUnit4.LeavesEncounter().GetEnumerator();
						try
						{
							while (enumerator20.MoveNext())
							{
								object _12 = enumerator20.Current;
								yield return _12;
							}
						}
						finally
						{
							IDisposable disposable12;
							if ((disposable12 = (enumerator20 as IDisposable)) != null)
							{
								disposable12.Dispose();
							}
						}
					}
					foreach (IBattleUnit currentEncounterEnemyUnit2 in recordEncounter.EnemyUnits)
					{
						IEnumerator enumerator22 = currentEncounterEnemyUnit2.LeavesEncounter().GetEnumerator();
						try
						{
							while (enumerator22.MoveNext())
							{
								object _13 = enumerator22.Current;
								yield return _13;
							}
						}
						finally
						{
							IDisposable disposable13;
							if ((disposable13 = (enumerator22 as IDisposable)) != null)
							{
								disposable13.Dispose();
							}
						}
					}
					if (recordEncounter.IsPlayerLost())
					{
						this.Survivied = ((this.Survivied != Adventure.SurvivalStatus.Retreated) ? Adventure.SurvivalStatus.Lost : Adventure.SurvivalStatus.Retreated);
						IEnumerator enumerator23 = this.OnAdventuresCompleteEncounter(this.Adventurers, recordEncounter).GetEnumerator();
						try
						{
							while (enumerator23.MoveNext())
							{
								object _14 = enumerator23.Current;
								yield return _14;
							}
						}
						finally
						{
							IDisposable disposable14;
							if ((disposable14 = (enumerator23 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
						break;
					}
					this.ConfirmRewards(recordEncounter.GetCompletionRewards());
					IEnumerator enumerator24 = this.OnAdventuresCompleteEncounter(this.Adventurers, recordEncounter).GetEnumerator();
					try
					{
						while (enumerator24.MoveNext())
						{
							object _15 = enumerator24.Current;
							yield return _15;
						}
					}
					finally
					{
						IDisposable disposable15;
						if ((disposable15 = (enumerator24 as IDisposable)) != null)
						{
							disposable15.Dispose();
						}
					}
					foreach (AdventurerBattleUnit adventurerBattleUnit5 in this.Adventurers)
					{
						IEnumerator enumerator26 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit5, AdventureEventType.AdventureProgresses, null)).GetEnumerator();
						try
						{
							while (enumerator26.MoveNext())
							{
								object _16 = enumerator26.Current;
								if (this.Survivied != Adventure.SurvivalStatus.Retreated)
								{
									yield return _16;
								}
							}
						}
						finally
						{
							IDisposable disposable16;
							if ((disposable16 = (enumerator26 as IDisposable)) != null)
							{
								disposable16.Dispose();
							}
						}
					}
					IEnumerator enumerator27 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventurersWalking, this.Adventurers)).GetEnumerator();
					try
					{
						while (enumerator27.MoveNext())
						{
							object _17 = enumerator27.Current;
							yield return _17;
						}
					}
					finally
					{
						IDisposable disposable17;
						if ((disposable17 = (enumerator27 as IDisposable)) != null)
						{
							disposable17.Dispose();
						}
					}
				}
			}
		}
		if (this.Survivied == Adventure.SurvivalStatus.Surviving)
		{
			foreach (AdventurerBattleUnit adventurerBattleUnit6 in this.Adventurers)
			{
				IEnumerator enumerator29 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit6, AdventureEventType.AdventureSuccess, null)).GetEnumerator();
				try
				{
					while (enumerator29.MoveNext())
					{
						object _18 = enumerator29.Current;
						yield return _18;
					}
				}
				finally
				{
					IDisposable disposable18;
					if ((disposable18 = (enumerator29 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
			}
			if (this.Chests.Any<Chest>())
			{
				for (;;)
				{
					if (!this.Chests.All((Chest c) => !c.IsSelected))
					{
						break;
					}
					yield return null;
				}
				Chest selectedChest = this.Chests.First((Chest c) => c.IsSelected);
				Chest.RecordChestSelection(selectedChest);
				this.ConfirmRewards(selectedChest.GetDrops(this.CorrespondingDifficultyMeasurement, this));
			}
			else
			{
				this.ConfirmRewards(new List<ResourceUpdate>());
			}
		}
		if (this.Survivied != Adventure.SurvivalStatus.Retreated)
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(this.CompleteRewardList);
		}
		if (this.Survivied == Adventure.SurvivalStatus.Surviving)
		{
			IEnumerator enumerator30 = this.OnAdventuresCompleteCollectChestFinalRewards(AdventureCompleteType.Successful, this.CompleteRewardList).GetEnumerator();
			try
			{
				while (enumerator30.MoveNext())
				{
					object _19 = enumerator30.Current;
					yield return _19;
				}
			}
			finally
			{
				IDisposable disposable19;
				if ((disposable19 = (enumerator30 as IDisposable)) != null)
				{
					disposable19.Dispose();
				}
			}
			IEnumerator enumerator31 = this.OnAdventureCompletes(this.CompleteRewardList, AdventureCompleteType.Successful, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
			try
			{
				while (enumerator31.MoveNext())
				{
					object _20 = enumerator31.Current;
					yield return _20;
				}
			}
			finally
			{
				IDisposable disposable20;
				if ((disposable20 = (enumerator31 as IDisposable)) != null)
				{
					disposable20.Dispose();
				}
			}
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureRewarding, this);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureCompleted, this);
		}
		else if (this.Survivied == Adventure.SurvivalStatus.Lost)
		{
			foreach (AdventurerBattleUnit adventurerBattleUnit7 in this.Adventurers)
			{
				IEnumerator enumerator33 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit7, AdventureEventType.AdventureFailed, null)).GetEnumerator();
				try
				{
					while (enumerator33.MoveNext())
					{
						object _21 = enumerator33.Current;
						yield return _21;
					}
				}
				finally
				{
					IDisposable disposable21;
					if ((disposable21 = (enumerator33 as IDisposable)) != null)
					{
						disposable21.Dispose();
					}
				}
			}
			IEnumerator enumerator34 = this.OnAdventureCompletes(this.CompleteRewardList, AdventureCompleteType.Failure, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
			try
			{
				while (enumerator34.MoveNext())
				{
					object _22 = enumerator34.Current;
					yield return _22;
				}
			}
			finally
			{
				IDisposable disposable22;
				if ((disposable22 = (enumerator34 as IDisposable)) != null)
				{
					disposable22.Dispose();
				}
			}
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureCompleted, this);
		}
		else if (this.Survivied == Adventure.SurvivalStatus.Retreated)
		{
			foreach (AdventurerBattleUnit adventurerBattleUnit8 in this.Adventurers)
			{
				IEnumerator enumerator36 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit8, AdventureEventType.AdventureFailed, null)).GetEnumerator();
				try
				{
					while (enumerator36.MoveNext())
					{
						object _23 = enumerator36.Current;
						yield return _23;
					}
				}
				finally
				{
					IDisposable disposable23;
					if ((disposable23 = (enumerator36 as IDisposable)) != null)
					{
						disposable23.Dispose();
					}
				}
			}
			IEnumerator enumerator37 = this.OnAdventureCompletes(this.CompleteRewardList, AdventureCompleteType.PulledOff, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
			try
			{
				while (enumerator37.MoveNext())
				{
					object _24 = enumerator37.Current;
					yield return _24;
				}
			}
			finally
			{
				IDisposable disposable24;
				if ((disposable24 = (enumerator37 as IDisposable)) != null)
				{
					disposable24.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06001D7A RID: 7546 RVA: 0x000C8DC8 File Offset: 0x000C71C8
	public IEnumerable PullOff()
	{
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(this.CompleteRewardList);
		this.Survivied = Adventure.SurvivalStatus.Retreated;
		yield break;
	}

	// Token: 0x06001D7B RID: 7547 RVA: 0x000C8DEC File Offset: 0x000C71EC
	private void ConfirmRewards(List<ResourceUpdate> updates)
	{
		using (List<ResourceUpdate>.Enumerator enumerator = updates.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ResourceUpdate resourceUpdate = enumerator.Current;
				if (this.CompleteRewardList.Any((ResourceUpdate f) => f.ResourceType == resourceUpdate.ResourceType))
				{
					ResourceUpdate resourceUpdate2 = this.CompleteRewardList.First((ResourceUpdate f) => f.ResourceType == resourceUpdate.ResourceType);
					if (!resourceUpdate.ResourceType.GetResourceCategory().IsUniqueResource())
					{
						resourceUpdate2.ChangeAmount += resourceUpdate.ChangeAmount;
					}
					resourceUpdate2.RelatedItems.AddRange(resourceUpdate.RelatedItems);
				}
				else
				{
					this.CompleteRewardList.Add(resourceUpdate);
				}
			}
		}
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.BattleEncounterRewardsCollected, updates);
	}

	// Token: 0x06001D7C RID: 7548 RVA: 0x000C8EEC File Offset: 0x000C72EC
	public IEnumerable OnAdventuresWalking(List<AdventurerBattleUnit> arg1)
	{
		Func<List<AdventurerBattleUnit>, IEnumerable> handler = this.AdventuresWalking;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x000C8F18 File Offset: 0x000C7318
	protected virtual IEnumerable OnAdventuresCompleteEncounter(List<AdventurerBattleUnit> arg1, IEncounter arg2)
	{
		Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> handler = this.AdventuresCompleteEncounter;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1, arg2).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D7E RID: 7550 RVA: 0x000C8F4C File Offset: 0x000C734C
	protected virtual IEnumerable OnAdventuresEnterEncounter(List<AdventurerBattleUnit> arg1, IEncounter arg2)
	{
		Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> handler = this.AdventuresEnterEncounter;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1, arg2).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D7F RID: 7551 RVA: 0x000C8F80 File Offset: 0x000C7380
	protected virtual IEnumerable OnAdventureCompletes(List<ResourceUpdate> arg1, AdventureCompleteType arg2, Adventure finishedAdventure)
	{
		Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> handler = this.AdventureCompletes;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1, arg2, finishedAdventure).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D80 RID: 7552 RVA: 0x000C8FB8 File Offset: 0x000C73B8
	public IEnumerable OnAdventureInitialized(Adventure arg1)
	{
		Func<Adventure, IEnumerable> handler = this.AdventureInitialized;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D81 RID: 7553 RVA: 0x000C8FE4 File Offset: 0x000C73E4
	protected virtual IEnumerable OnAdventuresCompleteCollectChestFinalRewards(AdventureCompleteType arg1, List<ResourceUpdate> arg2)
	{
		Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> handler = this.AdventuresCompleteCollectChestFinalRewards;
		if (handler != null)
		{
			IEnumerator enumerator = handler(arg1, arg2).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06001D82 RID: 7554 RVA: 0x000C9015 File Offset: 0x000C7415
	// Note: this type is marked as 'beforefieldinit'.
	static Adventure()
	{
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x000C902B File Offset: 0x000C742B
	[CompilerGenerated]
	private static bool <CalculateMaxActionCounts>m__0(AdventurerBattleUnit ad)
	{
		return ad.GetUnitClassStyle() == UnitClassStyle.PhysicalSupporter || ad.GetUnitClassStyle() == UnitClassStyle.SpellSupporter;
	}

	// Token: 0x06001D84 RID: 7556 RVA: 0x000C9047 File Offset: 0x000C7447
	[CompilerGenerated]
	private static bool <CalculateMaxActionCounts>m__1(AdventurerBattleUnit ad)
	{
		return ad.GetUnitClassStyle() == UnitClassStyle.Healer;
	}

	// Token: 0x06001D85 RID: 7557 RVA: 0x000C9053 File Offset: 0x000C7453
	[CompilerGenerated]
	private static bool <CalculateMaxActionCounts>m__2(AdventurerBattleUnit ad)
	{
		return ad.GetUnitClassStyle() == UnitClassStyle.PhysicalSupporter || ad.GetUnitClassStyle() == UnitClassStyle.SpellSupporter;
	}

	// Token: 0x06001D86 RID: 7558 RVA: 0x000C906F File Offset: 0x000C746F
	[CompilerGenerated]
	private static double <CalculateMaxActionCounts>m__3(AdventurerBattleUnit ad)
	{
		return ad.SpecialEffects.OfType<AdventureEnergyBoostByValueData>().Sum((AdventureEnergyBoostByValueData a) => a.Value * 4.0);
	}

	// Token: 0x06001D87 RID: 7559 RVA: 0x000C909E File Offset: 0x000C749E
	[CompilerGenerated]
	private static IEnumerable<IBattleUnit> <ProcessorInitialize>m__4(IEncounter e)
	{
		return e.EnemyUnits;
	}

	// Token: 0x06001D88 RID: 7560 RVA: 0x000C90A6 File Offset: 0x000C74A6
	[CompilerGenerated]
	private static IEnumerable<IBattleUnit> <ProcessorInitialize>m__5(IEncounter e)
	{
		return e.EnemyUnits;
	}

	// Token: 0x06001D89 RID: 7561 RVA: 0x000C90AE File Offset: 0x000C74AE
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <InitializeAdventureBaseOnLevel>m__6(ResourceType c)
	{
		return c.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal);
	}

	// Token: 0x06001D8A RID: 7562 RVA: 0x000C90BC File Offset: 0x000C74BC
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <InitializeAdventureBaseOnLevel>m__7(TownEffectBase ef)
	{
		return ef.GetPlayerEffectsForAdventure();
	}

	// Token: 0x06001D8B RID: 7563 RVA: 0x000C90C4 File Offset: 0x000C74C4
	[CompilerGenerated]
	private static double <CalculateMaxActionCounts>m__8(AdventureEnergyBoostByValueData a)
	{
		return a.Value * 4.0;
	}

	// Token: 0x04001AFF RID: 6911
	public static string EndlessAdventureLevelKey = "endlessadventurelevel";

	// Token: 0x04001B00 RID: 6912
	public static string EndlessAdventurePartial = "endlesslevel_";

	// Token: 0x04001B01 RID: 6913
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<Adventure, IEnumerable> AdventureInitialized;

	// Token: 0x04001B02 RID: 6914
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> AdventureCompletes;

	// Token: 0x04001B03 RID: 6915
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<List<AdventurerBattleUnit>, IEnumerable> AdventuresWalking;

	// Token: 0x04001B04 RID: 6916
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> AdventuresCompleteCollectChestFinalRewards;

	// Token: 0x04001B05 RID: 6917
	public string AdventureCode;

	// Token: 0x04001B06 RID: 6918
	public double? ActionCountPossible;

	// Token: 0x04001B07 RID: 6919
	public double? ActionCountSoFar;

	// Token: 0x04001B08 RID: 6920
	public bool InBattle;

	// Token: 0x04001B09 RID: 6921
	public bool GoForwardLevel;

	// Token: 0x04001B0A RID: 6922
	public bool AutoTacticPause;

	// Token: 0x04001B0B RID: 6923
	public Dictionary<AdventurerBattleUnit, double> DamageBoard = new Dictionary<AdventurerBattleUnit, double>();

	// Token: 0x04001B0C RID: 6924
	public Dictionary<AdventureEventType, List<IFactionProcessor>> FactionProcessorsDictionary;

	// Token: 0x04001B0D RID: 6925
	public Dictionary<AdventureEventType, List<QuestRequirementBase>> QuestRequirementsDictionary;

	// Token: 0x04001B0E RID: 6926
	public Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> PlayerEffectsDictionary;

	// Token: 0x04001B0F RID: 6927
	public Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>> DungeonEffectsDictionary;

	// Token: 0x04001B10 RID: 6928
	public Dictionary<string, Dictionary<AdventureEventType, Dictionary<string, BattleEffectBase>>> BattleEffectsDictionary;

	// Token: 0x04001B11 RID: 6929
	public Dictionary<string, Dictionary<AdventureEventType, List<ISpecialEffectDataLoad>>> BattleUnitSpecialEffectsDictionary;

	// Token: 0x04001B12 RID: 6930
	public Dictionary<AdventureEventType, List<AttributeProcessBase>> AttributeProcessDictionary;

	// Token: 0x04001B13 RID: 6931
	public Dictionary<string, Dictionary<AdventureEventType, List<AdventureUnitSkill>>> SkillsDictionary;

	// Token: 0x04001B14 RID: 6932
	public List<StrategyRule> AutoTacticRules;

	// Token: 0x04001B15 RID: 6933
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> AdventuresCompleteEncounter;

	// Token: 0x04001B16 RID: 6934
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> AdventuresEnterEncounter;

	// Token: 0x04001B17 RID: 6935
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <LevelNumber>k__BackingField;

	// Token: 0x04001B18 RID: 6936
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<IEncounter> <Encounters>k__BackingField;

	// Token: 0x04001B19 RID: 6937
	public IEncounter CurrentEncounter;

	// Token: 0x04001B1A RID: 6938
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceUpdate> <CompleteRewardList>k__BackingField;

	// Token: 0x04001B1B RID: 6939
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventurerBattleUnit> <Adventurers>k__BackingField;

	// Token: 0x04001B1C RID: 6940
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Chest> <Chests>k__BackingField;

	// Token: 0x04001B1D RID: 6941
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureType <AdventureType>k__BackingField;

	// Token: 0x04001B1E RID: 6942
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adventure.SurvivalStatus <Survivied>k__BackingField;

	// Token: 0x04001B1F RID: 6943
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <PlayerEffects>k__BackingField;

	// Token: 0x04001B20 RID: 6944
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <DungeonEffects>k__BackingField;

	// Token: 0x04001B21 RID: 6945
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DifficultyLevelMeasurement <CorrespondingDifficultyMeasurement>k__BackingField;

	// Token: 0x04001B22 RID: 6946
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureLevelConfiguration <CorrespondingLevelConfiguration>k__BackingField;

	// Token: 0x04001B23 RID: 6947
	public RunePowerDetails RunePower;

	// Token: 0x04001B24 RID: 6948
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__am$cache0;

	// Token: 0x04001B25 RID: 6949
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__am$cache1;

	// Token: 0x04001B26 RID: 6950
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__am$cache2;

	// Token: 0x04001B27 RID: 6951
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, double> <>f__am$cache3;

	// Token: 0x04001B28 RID: 6952
	[CompilerGenerated]
	private static Func<IEncounter, IEnumerable<IBattleUnit>> <>f__am$cache4;

	// Token: 0x04001B29 RID: 6953
	[CompilerGenerated]
	private static Func<IEncounter, IEnumerable<IBattleUnit>> <>f__am$cache5;

	// Token: 0x04001B2A RID: 6954
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache6;

	// Token: 0x04001B2B RID: 6955
	[CompilerGenerated]
	private static Func<TownEffectBase, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache7;

	// Token: 0x04001B2C RID: 6956
	[CompilerGenerated]
	private static Func<AdventureEnergyBoostByValueData, double> <>f__am$cache8;

	// Token: 0x02000428 RID: 1064
	public enum SurvivalStatus
	{
		// Token: 0x04001B2E RID: 6958
		Surviving,
		// Token: 0x04001B2F RID: 6959
		Retreated,
		// Token: 0x04001B30 RID: 6960
		Lost
	}

	// Token: 0x02000CCD RID: 3277
	[CompilerGenerated]
	private sealed class <GetEncounters>c__Iterator0 : IEnumerable, IEnumerable<IEncounter>, IEnumerator, IDisposable, IEnumerator<IEncounter>
	{
		// Token: 0x06005494 RID: 21652 RVA: 0x000C90D6 File Offset: 0x000C74D6
		[DebuggerHidden]
		public <GetEncounters>c__Iterator0()
		{
		}

		// Token: 0x06005495 RID: 21653 RVA: 0x000C90E0 File Offset: 0x000C74E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = base.Encounters.GetEnumerator();
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
					encounter = enumerator.Current;
					this.$current = encounter;
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
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011F0 RID: 4592
		// (get) Token: 0x06005496 RID: 21654 RVA: 0x000C91B4 File Offset: 0x000C75B4
		IEncounter IEnumerator<IEncounter>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011F1 RID: 4593
		// (get) Token: 0x06005497 RID: 21655 RVA: 0x000C91BC File Offset: 0x000C75BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005498 RID: 21656 RVA: 0x000C91C4 File Offset: 0x000C75C4
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
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005499 RID: 21657 RVA: 0x000C9220 File Offset: 0x000C7620
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600549A RID: 21658 RVA: 0x000C9227 File Offset: 0x000C7627
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<IEncounter>.GetEnumerator();
		}

		// Token: 0x0600549B RID: 21659 RVA: 0x000C9230 File Offset: 0x000C7630
		[DebuggerHidden]
		IEnumerator<IEncounter> IEnumerable<IEncounter>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<GetEncounters>c__Iterator0 <GetEncounters>c__Iterator = new Adventure.<GetEncounters>c__Iterator0();
			<GetEncounters>c__Iterator.$this = this;
			return <GetEncounters>c__Iterator;
		}

		// Token: 0x040041FC RID: 16892
		internal List<IEncounter>.Enumerator $locvar0;

		// Token: 0x040041FD RID: 16893
		internal IEncounter <encounter>__1;

		// Token: 0x040041FE RID: 16894
		internal Adventure $this;

		// Token: 0x040041FF RID: 16895
		internal IEncounter $current;

		// Token: 0x04004200 RID: 16896
		internal bool $disposing;

		// Token: 0x04004201 RID: 16897
		internal int $PC;
	}

	// Token: 0x02000CCE RID: 3278
	[CompilerGenerated]
	private sealed class <InitializeAdventureBaseOnLevel>c__AnonStorey9
	{
		// Token: 0x0600549C RID: 21660 RVA: 0x000C9264 File Offset: 0x000C7664
		public <InitializeAdventureBaseOnLevel>c__AnonStorey9()
		{
		}

		// Token: 0x0600549D RID: 21661 RVA: 0x000C926C File Offset: 0x000C766C
		internal AdventurerBattleUnit <>m__0(AdventurerProfile a)
		{
			return AdventurerBattleUnit.InitializeAdventurerBattleUnit(a, this.adventure);
		}

		// Token: 0x04004202 RID: 16898
		internal Adventure adventure;
	}

	// Token: 0x02000CCF RID: 3279
	[CompilerGenerated]
	private sealed class <Run>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600549E RID: 21662 RVA: 0x000C927A File Offset: 0x000C767A
		[DebuggerHidden]
		public <Run>c__Iterator1()
		{
		}

		// Token: 0x0600549F RID: 21663 RVA: 0x000C9284 File Offset: 0x000C7684
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				base.Survivied = Adventure.SurvivalStatus.Surviving;
				base.ProcessorInitialize();
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventureInitialized, null)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_155;
			case 3u:
				goto IL_28E;
			case 4u:
				goto IL_329;
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
			case 15u:
			case 16u:
			case 17u:
				goto IL_45C;
			case 18u:
				Block_9:
				try
				{
					switch (num)
					{
					case 18u:
						Block_197:
						try
						{
							switch (num)
							{
							}
							if (enumerator29.MoveNext())
							{
								_18 = enumerator29.Current;
								this.$current = _18;
								if (!this.$disposing)
								{
									this.$PC = 18;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable18 = (enumerator29 as IDisposable)) != null)
								{
									disposable18.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator28.MoveNext())
					{
						adventurerBattleUnit6 = enumerator28.Current;
						enumerator29 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit6, AdventureEventType.AdventureSuccess, null)).GetEnumerator();
						num = 4294967293u;
						goto Block_197;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator28).Dispose();
					}
				}
				if (base.Chests.Any<Chest>())
				{
					goto IL_12C0;
				}
				base.ConfirmRewards(new List<ResourceUpdate>());
				goto IL_136C;
			case 19u:
				goto IL_12C0;
			case 20u:
				Block_17:
				try
				{
					switch (num)
					{
					}
					if (enumerator30.MoveNext())
					{
						_19 = enumerator30.Current;
						this.$current = _19;
						if (!this.$disposing)
						{
							this.$PC = 20;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable19 = (enumerator30 as IDisposable)) != null)
						{
							disposable19.Dispose();
						}
					}
				}
				enumerator31 = this.OnAdventureCompletes(base.CompleteRewardList, AdventureCompleteType.Successful, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			case 21u:
				goto IL_147F;
			case 22u:
				Block_20:
				try
				{
					switch (num)
					{
					case 22u:
						Block_220:
						try
						{
							switch (num)
							{
							}
							if (enumerator33.MoveNext())
							{
								_21 = enumerator33.Current;
								this.$current = _21;
								if (!this.$disposing)
								{
									this.$PC = 22;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable21 = (enumerator33 as IDisposable)) != null)
								{
									disposable21.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator32.MoveNext())
					{
						adventurerBattleUnit7 = enumerator32.Current;
						enumerator33 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit7, AdventureEventType.AdventureFailed, null)).GetEnumerator();
						num = 4294967293u;
						goto Block_220;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator32).Dispose();
					}
				}
				enumerator34 = this.OnAdventureCompletes(base.CompleteRewardList, AdventureCompleteType.Failure, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
				num = 4294967293u;
				goto Block_21;
			case 23u:
				goto IL_1687;
			case 24u:
				Block_23:
				try
				{
					switch (num)
					{
					case 24u:
						Block_237:
						try
						{
							switch (num)
							{
							}
							if (enumerator36.MoveNext())
							{
								_23 = enumerator36.Current;
								this.$current = _23;
								if (!this.$disposing)
								{
									this.$PC = 24;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable23 = (enumerator36 as IDisposable)) != null)
								{
									disposable23.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator35.MoveNext())
					{
						adventurerBattleUnit8 = enumerator35.Current;
						enumerator36 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit8, AdventureEventType.AdventureFailed, null)).GetEnumerator();
						num = 4294967293u;
						goto Block_237;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator35).Dispose();
					}
				}
				enumerator37 = this.OnAdventureCompletes(base.CompleteRewardList, AdventureCompleteType.PulledOff, GameWorld.instance.GetCurrentAdventure()).GetEnumerator();
				num = 4294967293u;
				goto Block_24;
			case 25u:
				goto IL_1878;
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
			enumerator2 = base.Adventurers.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_155:
				switch (num)
				{
				case 2u:
					Block_32:
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
					break;
				}
				if (enumerator2.MoveNext())
				{
					adventurerBattleUnit = enumerator2.Current;
					enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit, AdventureEventType.AdventurerPreWalking, null)).GetEnumerator();
					num = 4294967293u;
					goto Block_32;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			this.RunePower = new RunePowerDetails(base.Adventurers);
			enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventurersWalking, base.Adventurers)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_28E:
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
			enumerator5 = base.Adventurers.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_329:
				switch (num)
				{
				case 4u:
					Block_49:
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
					break;
				}
				if (enumerator5.MoveNext())
				{
					adventurerBattleUnit2 = enumerator5.Current;
					enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit2, AdventureEventType.AdventurerPostWalking, null)).GetEnumerator();
					num = 4294967293u;
					goto Block_49;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			if (base.Survivied != Adventure.SurvivalStatus.Surviving)
			{
				goto IL_1169;
			}
			previousPlayerGauge = 0.0;
			firstStart = true;
			enumerator7 = base.GetEncounters().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_45C:
				switch (num)
				{
				case 5u:
					Block_61:
					try
					{
						switch (num)
						{
						case 5u:
							Block_80:
							try
							{
								switch (num)
								{
								}
								if (enumerator9.MoveNext())
								{
									_5 = enumerator9.Current;
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
									if ((disposable5 = (enumerator9 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator8.MoveNext())
						{
							adventurerBattleUnit3 = enumerator8.Current;
							enumerator9 = adventurerBattleUnit3.EntersEncounter(this.CurrentEncounter).GetEnumerator();
							num = 4294967293u;
							goto Block_80;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator8).Dispose();
						}
					}
					enumerator10 = this.CurrentEncounter.EnemyUnits.GetEnumerator();
					num = 4294967293u;
					goto Block_62;
				case 6u:
					goto IL_5F9;
				case 7u:
					goto IL_71B;
				case 8u:
					goto IL_7F7;
				case 9u:
					Block_67:
					try
					{
						switch (num)
						{
						case 9u:
							Block_114:
							try
							{
								switch (num)
								{
								}
								if (enumerator15.MoveNext())
								{
									_9 = enumerator15.Current;
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
									if ((disposable9 = (enumerator15 as IDisposable)) != null)
									{
										disposable9.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator14.MoveNext())
						{
							player = enumerator14.Current;
							enumerator15 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(player, AdventureEventType.FirstEncounterStarted, player)).GetEnumerator();
							num = 4294967293u;
							goto Block_114;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator14).Dispose();
						}
					}
					enumerator16 = this.CurrentEncounter.EnemyUnits.GetEnumerator();
					num = 4294967293u;
					goto Block_68;
				case 10u:
					goto IL_9C4;
				case 11u:
					Block_69:
					try
					{
						switch (num)
						{
						}
						if (enumerator18.MoveNext())
						{
							_11 = enumerator18.Current;
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
							if ((disposable11 = (enumerator18 as IDisposable)) != null)
							{
								disposable11.Dispose();
							}
						}
					}
					this.InBattle = false;
					recordEncounter = this.CurrentEncounter;
					if (recordEncounter is BattleEncounter)
					{
						previousPlayerGauge = (recordEncounter as BattleEncounter).PlayerGauge;
					}
					enumerator19 = this.CurrentEncounter.PlayerUnits.GetEnumerator();
					num = 4294967293u;
					goto Block_71;
				case 12u:
					goto IL_BD0;
				case 13u:
					goto IL_CD4;
				case 14u:
					goto IL_E1C;
				case 15u:
					goto IL_EE5;
				case 16u:
					goto IL_F82;
				case 17u:
					goto IL_10B5;
				}
				IL_1139:
				while (enumerator7.MoveNext())
				{
					encounter = enumerator7.Current;
					if (base.Survivied == Adventure.SurvivalStatus.Surviving)
					{
						this.CurrentEncounter = encounter;
						enumerator8 = base.Adventurers.GetEnumerator();
						num = 4294967293u;
						goto Block_61;
					}
				}
				goto IL_1149;
				Block_62:
				try
				{
					IL_5F9:
					switch (num)
					{
					case 6u:
						Block_91:
						try
						{
							switch (num)
							{
							}
							if (enumerator11.MoveNext())
							{
								_6 = enumerator11.Current;
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
								if ((disposable6 = (enumerator11 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator10.MoveNext())
					{
						currentEncounterEnemyUnit = enumerator10.Current;
						enumerator11 = currentEncounterEnemyUnit.EntersEncounter(this.CurrentEncounter).GetEnumerator();
						num = 4294967293u;
						goto Block_91;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator10).Dispose();
					}
				}
				enumerator12 = this.OnAdventuresEnterEncounter(base.Adventurers, this.CurrentEncounter).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_71B:
					switch (num)
					{
					}
					if (enumerator12.MoveNext())
					{
						_7 = enumerator12.Current;
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
						if ((disposable7 = (enumerator12 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				if (!(this.CurrentEncounter is BattleEncounter))
				{
					goto IL_879;
				}
				battleEncounter = (this.CurrentEncounter as BattleEncounter);
				enumerator13 = battleEncounter.UpdatePlayerGauge(previousPlayerGauge, base.Adventurers.FirstOrDefault<AdventurerBattleUnit>()).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_7F7:
					switch (num)
					{
					}
					if (enumerator13.MoveNext())
					{
						_8 = enumerator13.Current;
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
						if ((disposable8 = (enumerator13 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				IL_879:
				if (firstStart)
				{
					firstStart = false;
					enumerator14 = this.CurrentEncounter.PlayerUnits.GetEnumerator();
					num = 4294967293u;
					goto Block_67;
				}
				goto IL_AC1;
				Block_68:
				try
				{
					IL_9C4:
					switch (num)
					{
					case 10u:
						Block_125:
						try
						{
							switch (num)
							{
							}
							if (enumerator17.MoveNext())
							{
								_10 = enumerator17.Current;
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
								if ((disposable10 = (enumerator17 as IDisposable)) != null)
								{
									disposable10.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator16.MoveNext())
					{
						player2 = enumerator16.Current;
						enumerator17 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(player2, AdventureEventType.FirstEncounterStarted, player2)).GetEnumerator();
						num = 4294967293u;
						goto Block_125;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator16).Dispose();
					}
				}
				IL_AC1:
				this.InBattle = true;
				enumerator18 = this.CurrentEncounter.Run().GetEnumerator();
				num = 4294967293u;
				goto Block_69;
				Block_71:
				try
				{
					IL_BD0:
					switch (num)
					{
					case 12u:
						Block_142:
						try
						{
							switch (num)
							{
							}
							if (enumerator20.MoveNext())
							{
								_12 = enumerator20.Current;
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
								if ((disposable12 = (enumerator20 as IDisposable)) != null)
								{
									disposable12.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator19.MoveNext())
					{
						adventurerBattleUnit4 = enumerator19.Current;
						enumerator20 = adventurerBattleUnit4.LeavesEncounter().GetEnumerator();
						num = 4294967293u;
						goto Block_142;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator19).Dispose();
					}
				}
				enumerator21 = recordEncounter.EnemyUnits.GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_CD4:
					switch (num)
					{
					case 13u:
						Block_153:
						try
						{
							switch (num)
							{
							}
							if (enumerator22.MoveNext())
							{
								_13 = enumerator22.Current;
								this.$current = _13;
								if (!this.$disposing)
								{
									this.$PC = 13;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable13 = (enumerator22 as IDisposable)) != null)
								{
									disposable13.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator21.MoveNext())
					{
						currentEncounterEnemyUnit2 = enumerator21.Current;
						enumerator22 = currentEncounterEnemyUnit2.LeavesEncounter().GetEnumerator();
						num = 4294967293u;
						goto Block_153;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator21).Dispose();
					}
				}
				if (!recordEncounter.IsPlayerLost())
				{
					base.ConfirmRewards(recordEncounter.GetCompletionRewards());
					enumerator24 = this.OnAdventuresCompleteEncounter(base.Adventurers, recordEncounter).GetEnumerator();
					num = 4294967293u;
					goto Block_76;
				}
				base.Survivied = ((base.Survivied != Adventure.SurvivalStatus.Retreated) ? Adventure.SurvivalStatus.Lost : Adventure.SurvivalStatus.Retreated);
				enumerator23 = this.OnAdventuresCompleteEncounter(base.Adventurers, recordEncounter).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_E1C:
					switch (num)
					{
					}
					if (enumerator23.MoveNext())
					{
						_14 = enumerator23.Current;
						this.$current = _14;
						if (!this.$disposing)
						{
							this.$PC = 14;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable14 = (enumerator23 as IDisposable)) != null)
						{
							disposable14.Dispose();
						}
					}
				}
				goto IL_1149;
				Block_76:
				try
				{
					IL_EE5:
					switch (num)
					{
					}
					if (enumerator24.MoveNext())
					{
						_15 = enumerator24.Current;
						this.$current = _15;
						if (!this.$disposing)
						{
							this.$PC = 15;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable15 = (enumerator24 as IDisposable)) != null)
						{
							disposable15.Dispose();
						}
					}
				}
				enumerator25 = base.Adventurers.GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_F82:
					switch (num)
					{
					case 16u:
						Block_176:
						try
						{
							switch (num)
							{
							}
							while (enumerator26.MoveNext())
							{
								_16 = enumerator26.Current;
								if (base.Survivied != Adventure.SurvivalStatus.Retreated)
								{
									this.$current = _16;
									if (!this.$disposing)
									{
										this.$PC = 16;
									}
									flag = true;
									return true;
								}
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable16 = (enumerator26 as IDisposable)) != null)
								{
									disposable16.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator25.MoveNext())
					{
						adventurerBattleUnit5 = enumerator25.Current;
						enumerator26 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(adventurerBattleUnit5, AdventureEventType.AdventureProgresses, null)).GetEnumerator();
						num = 4294967293u;
						goto Block_176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator25).Dispose();
					}
				}
				enumerator27 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(null, AdventureEventType.AdventurersWalking, base.Adventurers)).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_10B5:
					switch (num)
					{
					}
					if (enumerator27.MoveNext())
					{
						_17 = enumerator27.Current;
						this.$current = _17;
						if (!this.$disposing)
						{
							this.$PC = 17;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable17 = (enumerator27 as IDisposable)) != null)
						{
							disposable17.Dispose();
						}
					}
				}
				goto IL_1139;
				IL_1149:;
			}
			finally
			{
				if (!flag)
				{
					if (enumerator7 != null)
					{
						enumerator7.Dispose();
					}
				}
			}
			IL_1169:
			if (base.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				enumerator28 = base.Adventurers.GetEnumerator();
				num = 4294967293u;
				goto Block_9;
			}
			goto IL_136C;
			IL_12C0:
			if (base.Chests.All((Chest c) => !c.IsSelected))
			{
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 19;
				}
				return true;
			}
			selectedChest = base.Chests.First((Chest c) => c.IsSelected);
			Chest.RecordChestSelection(selectedChest);
			base.ConfirmRewards(selectedChest.GetDrops(base.CorrespondingDifficultyMeasurement, this));
			IL_136C:
			if (base.Survivied != Adventure.SurvivalStatus.Retreated)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(base.CompleteRewardList);
			}
			if (base.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				enumerator30 = this.OnAdventuresCompleteCollectChestFinalRewards(AdventureCompleteType.Successful, base.CompleteRewardList).GetEnumerator();
				num = 4294967293u;
				goto Block_17;
			}
			if (base.Survivied == Adventure.SurvivalStatus.Lost)
			{
				enumerator32 = base.Adventurers.GetEnumerator();
				num = 4294967293u;
				goto Block_20;
			}
			if (base.Survivied == Adventure.SurvivalStatus.Retreated)
			{
				enumerator35 = base.Adventurers.GetEnumerator();
				num = 4294967293u;
				goto Block_23;
			}
			goto IL_18FC;
			Block_18:
			try
			{
				IL_147F:
				switch (num)
				{
				}
				if (enumerator31.MoveNext())
				{
					_20 = enumerator31.Current;
					this.$current = _20;
					if (!this.$disposing)
					{
						this.$PC = 21;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable20 = (enumerator31 as IDisposable)) != null)
					{
						disposable20.Dispose();
					}
				}
			}
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureRewarding, this);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureCompleted, this);
			goto IL_18FC;
			Block_21:
			try
			{
				IL_1687:
				switch (num)
				{
				}
				if (enumerator34.MoveNext())
				{
					_22 = enumerator34.Current;
					this.$current = _22;
					if (!this.$disposing)
					{
						this.$PC = 23;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable22 = (enumerator34 as IDisposable)) != null)
					{
						disposable22.Dispose();
					}
				}
			}
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureCompleted, this);
			goto IL_18FC;
			Block_24:
			try
			{
				IL_1878:
				switch (num)
				{
				}
				if (enumerator37.MoveNext())
				{
					_24 = enumerator37.Current;
					this.$current = _24;
					if (!this.$disposing)
					{
						this.$PC = 25;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable24 = (enumerator37 as IDisposable)) != null)
					{
						disposable24.Dispose();
					}
				}
			}
			IL_18FC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011F2 RID: 4594
		// (get) Token: 0x060054A0 RID: 21664 RVA: 0x000CAF14 File Offset: 0x000C9314
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011F3 RID: 4595
		// (get) Token: 0x060054A1 RID: 21665 RVA: 0x000CAF1C File Offset: 0x000C931C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054A2 RID: 21666 RVA: 0x000CAF24 File Offset: 0x000C9324
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
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
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
					}
					finally
					{
						if ((disposable4 = (enumerator6 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
			case 15u:
			case 16u:
			case 17u:
				try
				{
					switch (num)
					{
					case 5u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable5 = (enumerator9 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator8).Dispose();
						}
						break;
					case 6u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable6 = (enumerator11 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator10).Dispose();
						}
						break;
					case 7u:
						try
						{
						}
						finally
						{
							if ((disposable7 = (enumerator12 as IDisposable)) != null)
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
							if ((disposable8 = (enumerator13 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
						break;
					case 9u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable9 = (enumerator15 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator14).Dispose();
						}
						break;
					case 10u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable10 = (enumerator17 as IDisposable)) != null)
								{
									disposable10.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator16).Dispose();
						}
						break;
					case 11u:
						try
						{
						}
						finally
						{
							if ((disposable11 = (enumerator18 as IDisposable)) != null)
							{
								disposable11.Dispose();
							}
						}
						break;
					case 12u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable12 = (enumerator20 as IDisposable)) != null)
								{
									disposable12.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator19).Dispose();
						}
						break;
					case 13u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable13 = (enumerator22 as IDisposable)) != null)
								{
									disposable13.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator21).Dispose();
						}
						break;
					case 14u:
						try
						{
						}
						finally
						{
							if ((disposable14 = (enumerator23 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
						break;
					case 15u:
						try
						{
						}
						finally
						{
							if ((disposable15 = (enumerator24 as IDisposable)) != null)
							{
								disposable15.Dispose();
							}
						}
						break;
					case 16u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable16 = (enumerator26 as IDisposable)) != null)
								{
									disposable16.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator25).Dispose();
						}
						break;
					case 17u:
						try
						{
						}
						finally
						{
							if ((disposable17 = (enumerator27 as IDisposable)) != null)
							{
								disposable17.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					if (enumerator7 != null)
					{
						enumerator7.Dispose();
					}
				}
				break;
			case 18u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable18 = (enumerator29 as IDisposable)) != null)
						{
							disposable18.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator28).Dispose();
				}
				break;
			case 20u:
				try
				{
				}
				finally
				{
					if ((disposable19 = (enumerator30 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
				break;
			case 21u:
				try
				{
				}
				finally
				{
					if ((disposable20 = (enumerator31 as IDisposable)) != null)
					{
						disposable20.Dispose();
					}
				}
				break;
			case 22u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable21 = (enumerator33 as IDisposable)) != null)
						{
							disposable21.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator32).Dispose();
				}
				break;
			case 23u:
				try
				{
				}
				finally
				{
					if ((disposable22 = (enumerator34 as IDisposable)) != null)
					{
						disposable22.Dispose();
					}
				}
				break;
			case 24u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable23 = (enumerator36 as IDisposable)) != null)
						{
							disposable23.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator35).Dispose();
				}
				break;
			case 25u:
				try
				{
				}
				finally
				{
					if ((disposable24 = (enumerator37 as IDisposable)) != null)
					{
						disposable24.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060054A3 RID: 21667 RVA: 0x000CB90C File Offset: 0x000C9D0C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054A4 RID: 21668 RVA: 0x000CB913 File Offset: 0x000C9D13
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054A5 RID: 21669 RVA: 0x000CB91C File Offset: 0x000C9D1C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<Run>c__Iterator1 <Run>c__Iterator = new Adventure.<Run>c__Iterator1();
			<Run>c__Iterator.$this = this;
			return <Run>c__Iterator;
		}

		// Token: 0x060054A6 RID: 21670 RVA: 0x000CB950 File Offset: 0x000C9D50
		private static bool <>m__0(Chest c)
		{
			return !c.IsSelected;
		}

		// Token: 0x060054A7 RID: 21671 RVA: 0x000CB95B File Offset: 0x000C9D5B
		private static bool <>m__1(Chest c)
		{
			return c.IsSelected;
		}

		// Token: 0x04004203 RID: 16899
		internal IEnumerator $locvar0;

		// Token: 0x04004204 RID: 16900
		internal object <_>__1;

		// Token: 0x04004205 RID: 16901
		internal IDisposable $locvar1;

		// Token: 0x04004206 RID: 16902
		internal List<AdventurerBattleUnit>.Enumerator $locvar2;

		// Token: 0x04004207 RID: 16903
		internal AdventurerBattleUnit <adventurerBattleUnit>__2;

		// Token: 0x04004208 RID: 16904
		internal IEnumerator $locvar3;

		// Token: 0x04004209 RID: 16905
		internal object <_>__3;

		// Token: 0x0400420A RID: 16906
		internal IDisposable $locvar4;

		// Token: 0x0400420B RID: 16907
		internal IEnumerator $locvar5;

		// Token: 0x0400420C RID: 16908
		internal object <_>__4;

		// Token: 0x0400420D RID: 16909
		internal IDisposable $locvar6;

		// Token: 0x0400420E RID: 16910
		internal List<AdventurerBattleUnit>.Enumerator $locvar7;

		// Token: 0x0400420F RID: 16911
		internal AdventurerBattleUnit <adventurerBattleUnit>__5;

		// Token: 0x04004210 RID: 16912
		internal IEnumerator $locvar8;

		// Token: 0x04004211 RID: 16913
		internal object <_>__6;

		// Token: 0x04004212 RID: 16914
		internal IDisposable $locvar9;

		// Token: 0x04004213 RID: 16915
		internal double <previousPlayerGauge>__7;

		// Token: 0x04004214 RID: 16916
		internal bool <firstStart>__7;

		// Token: 0x04004215 RID: 16917
		internal IEnumerator<IEncounter> $locvarA;

		// Token: 0x04004216 RID: 16918
		internal IEncounter <encounter>__8;

		// Token: 0x04004217 RID: 16919
		internal List<AdventurerBattleUnit>.Enumerator $locvarB;

		// Token: 0x04004218 RID: 16920
		internal AdventurerBattleUnit <adventurerBattleUnit>__9;

		// Token: 0x04004219 RID: 16921
		internal IEnumerator $locvarC;

		// Token: 0x0400421A RID: 16922
		internal object <_>__10;

		// Token: 0x0400421B RID: 16923
		internal IDisposable $locvarD;

		// Token: 0x0400421C RID: 16924
		internal List<IBattleUnit>.Enumerator $locvarE;

		// Token: 0x0400421D RID: 16925
		internal IBattleUnit <currentEncounterEnemyUnit>__11;

		// Token: 0x0400421E RID: 16926
		internal IEnumerator $locvarF;

		// Token: 0x0400421F RID: 16927
		internal object <_>__12;

		// Token: 0x04004220 RID: 16928
		internal IDisposable $locvar10;

		// Token: 0x04004221 RID: 16929
		internal IEnumerator $locvar11;

		// Token: 0x04004222 RID: 16930
		internal object <_>__13;

		// Token: 0x04004223 RID: 16931
		internal IDisposable $locvar12;

		// Token: 0x04004224 RID: 16932
		internal BattleEncounter <battleEncounter>__14;

		// Token: 0x04004225 RID: 16933
		internal IEnumerator $locvar13;

		// Token: 0x04004226 RID: 16934
		internal object <_>__15;

		// Token: 0x04004227 RID: 16935
		internal IDisposable $locvar14;

		// Token: 0x04004228 RID: 16936
		internal List<IBattleUnit>.Enumerator $locvar15;

		// Token: 0x04004229 RID: 16937
		internal IBattleUnit <player>__16;

		// Token: 0x0400422A RID: 16938
		internal IEnumerator $locvar16;

		// Token: 0x0400422B RID: 16939
		internal object <_>__17;

		// Token: 0x0400422C RID: 16940
		internal IDisposable $locvar17;

		// Token: 0x0400422D RID: 16941
		internal List<IBattleUnit>.Enumerator $locvar18;

		// Token: 0x0400422E RID: 16942
		internal IBattleUnit <player>__18;

		// Token: 0x0400422F RID: 16943
		internal IEnumerator $locvar19;

		// Token: 0x04004230 RID: 16944
		internal object <_>__19;

		// Token: 0x04004231 RID: 16945
		internal IDisposable $locvar1A;

		// Token: 0x04004232 RID: 16946
		internal IEnumerator $locvar1B;

		// Token: 0x04004233 RID: 16947
		internal object <_>__20;

		// Token: 0x04004234 RID: 16948
		internal IDisposable $locvar1C;

		// Token: 0x04004235 RID: 16949
		internal IEncounter <recordEncounter>__21;

		// Token: 0x04004236 RID: 16950
		internal List<IBattleUnit>.Enumerator $locvar1D;

		// Token: 0x04004237 RID: 16951
		internal IBattleUnit <adventurerBattleUnit>__22;

		// Token: 0x04004238 RID: 16952
		internal IEnumerator $locvar1E;

		// Token: 0x04004239 RID: 16953
		internal object <_>__23;

		// Token: 0x0400423A RID: 16954
		internal IDisposable $locvar1F;

		// Token: 0x0400423B RID: 16955
		internal List<IBattleUnit>.Enumerator $locvar20;

		// Token: 0x0400423C RID: 16956
		internal IBattleUnit <currentEncounterEnemyUnit>__24;

		// Token: 0x0400423D RID: 16957
		internal IEnumerator $locvar21;

		// Token: 0x0400423E RID: 16958
		internal object <_>__25;

		// Token: 0x0400423F RID: 16959
		internal IDisposable $locvar22;

		// Token: 0x04004240 RID: 16960
		internal IEnumerator $locvar23;

		// Token: 0x04004241 RID: 16961
		internal object <_>__26;

		// Token: 0x04004242 RID: 16962
		internal IDisposable $locvar24;

		// Token: 0x04004243 RID: 16963
		internal IEnumerator $locvar25;

		// Token: 0x04004244 RID: 16964
		internal object <_>__27;

		// Token: 0x04004245 RID: 16965
		internal IDisposable $locvar26;

		// Token: 0x04004246 RID: 16966
		internal List<AdventurerBattleUnit>.Enumerator $locvar27;

		// Token: 0x04004247 RID: 16967
		internal AdventurerBattleUnit <adventurerBattleUnit>__28;

		// Token: 0x04004248 RID: 16968
		internal IEnumerator $locvar28;

		// Token: 0x04004249 RID: 16969
		internal object <_>__29;

		// Token: 0x0400424A RID: 16970
		internal IDisposable $locvar29;

		// Token: 0x0400424B RID: 16971
		internal IEnumerator $locvar2A;

		// Token: 0x0400424C RID: 16972
		internal object <_>__30;

		// Token: 0x0400424D RID: 16973
		internal IDisposable $locvar2B;

		// Token: 0x0400424E RID: 16974
		internal List<AdventurerBattleUnit>.Enumerator $locvar2C;

		// Token: 0x0400424F RID: 16975
		internal AdventurerBattleUnit <adventurerBattleUnit>__31;

		// Token: 0x04004250 RID: 16976
		internal IEnumerator $locvar2D;

		// Token: 0x04004251 RID: 16977
		internal object <_>__32;

		// Token: 0x04004252 RID: 16978
		internal IDisposable $locvar2E;

		// Token: 0x04004253 RID: 16979
		internal Chest <selectedChest>__33;

		// Token: 0x04004254 RID: 16980
		internal IEnumerator $locvar2F;

		// Token: 0x04004255 RID: 16981
		internal object <_>__34;

		// Token: 0x04004256 RID: 16982
		internal IDisposable $locvar30;

		// Token: 0x04004257 RID: 16983
		internal IEnumerator $locvar31;

		// Token: 0x04004258 RID: 16984
		internal object <_>__35;

		// Token: 0x04004259 RID: 16985
		internal IDisposable $locvar32;

		// Token: 0x0400425A RID: 16986
		internal List<AdventurerBattleUnit>.Enumerator $locvar33;

		// Token: 0x0400425B RID: 16987
		internal AdventurerBattleUnit <adventurerBattleUnit>__36;

		// Token: 0x0400425C RID: 16988
		internal IEnumerator $locvar34;

		// Token: 0x0400425D RID: 16989
		internal object <_>__37;

		// Token: 0x0400425E RID: 16990
		internal IDisposable $locvar35;

		// Token: 0x0400425F RID: 16991
		internal IEnumerator $locvar36;

		// Token: 0x04004260 RID: 16992
		internal object <_>__38;

		// Token: 0x04004261 RID: 16993
		internal IDisposable $locvar37;

		// Token: 0x04004262 RID: 16994
		internal List<AdventurerBattleUnit>.Enumerator $locvar38;

		// Token: 0x04004263 RID: 16995
		internal AdventurerBattleUnit <adventurerBattleUnit>__39;

		// Token: 0x04004264 RID: 16996
		internal IEnumerator $locvar39;

		// Token: 0x04004265 RID: 16997
		internal object <_>__40;

		// Token: 0x04004266 RID: 16998
		internal IDisposable $locvar3A;

		// Token: 0x04004267 RID: 16999
		internal IEnumerator $locvar3B;

		// Token: 0x04004268 RID: 17000
		internal object <_>__41;

		// Token: 0x04004269 RID: 17001
		internal IDisposable $locvar3C;

		// Token: 0x0400426A RID: 17002
		internal Adventure $this;

		// Token: 0x0400426B RID: 17003
		internal object $current;

		// Token: 0x0400426C RID: 17004
		internal bool $disposing;

		// Token: 0x0400426D RID: 17005
		internal int $PC;

		// Token: 0x0400426E RID: 17006
		private static Func<Chest, bool> <>f__am$cache0;

		// Token: 0x0400426F RID: 17007
		private static Func<Chest, bool> <>f__am$cache1;
	}

	// Token: 0x02000CD0 RID: 3280
	[CompilerGenerated]
	private sealed class <PullOff>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054A8 RID: 21672 RVA: 0x000CB963 File Offset: 0x000C9D63
		[DebuggerHidden]
		public <PullOff>c__Iterator2()
		{
		}

		// Token: 0x060054A9 RID: 21673 RVA: 0x000CB96B File Offset: 0x000C9D6B
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(base.CompleteRewardList);
				base.Survivied = Adventure.SurvivalStatus.Retreated;
			}
			return false;
		}

		// Token: 0x170011F4 RID: 4596
		// (get) Token: 0x060054AA RID: 21674 RVA: 0x000CB9AB File Offset: 0x000C9DAB
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011F5 RID: 4597
		// (get) Token: 0x060054AB RID: 21675 RVA: 0x000CB9B3 File Offset: 0x000C9DB3
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054AC RID: 21676 RVA: 0x000CB9BB File Offset: 0x000C9DBB
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060054AD RID: 21677 RVA: 0x000CB9BD File Offset: 0x000C9DBD
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054AE RID: 21678 RVA: 0x000CB9C4 File Offset: 0x000C9DC4
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054AF RID: 21679 RVA: 0x000CB9CC File Offset: 0x000C9DCC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<PullOff>c__Iterator2 <PullOff>c__Iterator = new Adventure.<PullOff>c__Iterator2();
			<PullOff>c__Iterator.$this = this;
			return <PullOff>c__Iterator;
		}

		// Token: 0x04004270 RID: 17008
		internal Adventure $this;

		// Token: 0x04004271 RID: 17009
		internal object $current;

		// Token: 0x04004272 RID: 17010
		internal bool $disposing;

		// Token: 0x04004273 RID: 17011
		internal int $PC;
	}

	// Token: 0x02000CD1 RID: 3281
	[CompilerGenerated]
	private sealed class <ConfirmRewards>c__AnonStoreyA
	{
		// Token: 0x060054B0 RID: 21680 RVA: 0x000CBA00 File Offset: 0x000C9E00
		public <ConfirmRewards>c__AnonStoreyA()
		{
		}

		// Token: 0x060054B1 RID: 21681 RVA: 0x000CBA08 File Offset: 0x000C9E08
		internal bool <>m__0(ResourceUpdate f)
		{
			return f.ResourceType == this.resourceUpdate.ResourceType;
		}

		// Token: 0x060054B2 RID: 21682 RVA: 0x000CBA1D File Offset: 0x000C9E1D
		internal bool <>m__1(ResourceUpdate f)
		{
			return f.ResourceType == this.resourceUpdate.ResourceType;
		}

		// Token: 0x04004274 RID: 17012
		internal ResourceUpdate resourceUpdate;
	}

	// Token: 0x02000CD2 RID: 3282
	[CompilerGenerated]
	private sealed class <OnAdventuresWalking>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054B3 RID: 21683 RVA: 0x000CBA32 File Offset: 0x000C9E32
		[DebuggerHidden]
		public <OnAdventuresWalking>c__Iterator3()
		{
		}

		// Token: 0x060054B4 RID: 21684 RVA: 0x000CBA3C File Offset: 0x000C9E3C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventuresWalking;
				if (handler == null)
				{
					goto IL_E0;
				}
				enumerator = handler(arg1).GetEnumerator();
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
			IL_E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011F6 RID: 4598
		// (get) Token: 0x060054B5 RID: 21685 RVA: 0x000CBB44 File Offset: 0x000C9F44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011F7 RID: 4599
		// (get) Token: 0x060054B6 RID: 21686 RVA: 0x000CBB4C File Offset: 0x000C9F4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054B7 RID: 21687 RVA: 0x000CBB54 File Offset: 0x000C9F54
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

		// Token: 0x060054B8 RID: 21688 RVA: 0x000CBBC4 File Offset: 0x000C9FC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054B9 RID: 21689 RVA: 0x000CBBCB File Offset: 0x000C9FCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054BA RID: 21690 RVA: 0x000CBBD4 File Offset: 0x000C9FD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventuresWalking>c__Iterator3 <OnAdventuresWalking>c__Iterator = new Adventure.<OnAdventuresWalking>c__Iterator3();
			<OnAdventuresWalking>c__Iterator.$this = this;
			<OnAdventuresWalking>c__Iterator.arg1 = arg1;
			return <OnAdventuresWalking>c__Iterator;
		}

		// Token: 0x04004275 RID: 17013
		internal Func<List<AdventurerBattleUnit>, IEnumerable> <handler>__0;

		// Token: 0x04004276 RID: 17014
		internal List<AdventurerBattleUnit> arg1;

		// Token: 0x04004277 RID: 17015
		internal IEnumerator $locvar0;

		// Token: 0x04004278 RID: 17016
		internal object <_>__1;

		// Token: 0x04004279 RID: 17017
		internal IDisposable $locvar1;

		// Token: 0x0400427A RID: 17018
		internal Adventure $this;

		// Token: 0x0400427B RID: 17019
		internal object $current;

		// Token: 0x0400427C RID: 17020
		internal bool $disposing;

		// Token: 0x0400427D RID: 17021
		internal int $PC;
	}

	// Token: 0x02000CD3 RID: 3283
	[CompilerGenerated]
	private sealed class <OnAdventuresCompleteEncounter>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054BB RID: 21691 RVA: 0x000CBC14 File Offset: 0x000CA014
		[DebuggerHidden]
		public <OnAdventuresCompleteEncounter>c__Iterator4()
		{
		}

		// Token: 0x060054BC RID: 21692 RVA: 0x000CBC1C File Offset: 0x000CA01C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventuresCompleteEncounter;
				if (handler == null)
				{
					goto IL_E6;
				}
				enumerator = handler(arg1, arg2).GetEnumerator();
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
			IL_E6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011F8 RID: 4600
		// (get) Token: 0x060054BD RID: 21693 RVA: 0x000CBD2C File Offset: 0x000CA12C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011F9 RID: 4601
		// (get) Token: 0x060054BE RID: 21694 RVA: 0x000CBD34 File Offset: 0x000CA134
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054BF RID: 21695 RVA: 0x000CBD3C File Offset: 0x000CA13C
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

		// Token: 0x060054C0 RID: 21696 RVA: 0x000CBDAC File Offset: 0x000CA1AC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054C1 RID: 21697 RVA: 0x000CBDB3 File Offset: 0x000CA1B3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054C2 RID: 21698 RVA: 0x000CBDBC File Offset: 0x000CA1BC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventuresCompleteEncounter>c__Iterator4 <OnAdventuresCompleteEncounter>c__Iterator = new Adventure.<OnAdventuresCompleteEncounter>c__Iterator4();
			<OnAdventuresCompleteEncounter>c__Iterator.$this = this;
			<OnAdventuresCompleteEncounter>c__Iterator.arg1 = arg1;
			<OnAdventuresCompleteEncounter>c__Iterator.arg2 = arg2;
			return <OnAdventuresCompleteEncounter>c__Iterator;
		}

		// Token: 0x0400427E RID: 17022
		internal Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> <handler>__0;

		// Token: 0x0400427F RID: 17023
		internal List<AdventurerBattleUnit> arg1;

		// Token: 0x04004280 RID: 17024
		internal IEncounter arg2;

		// Token: 0x04004281 RID: 17025
		internal IEnumerator $locvar0;

		// Token: 0x04004282 RID: 17026
		internal object <_>__1;

		// Token: 0x04004283 RID: 17027
		internal IDisposable $locvar1;

		// Token: 0x04004284 RID: 17028
		internal Adventure $this;

		// Token: 0x04004285 RID: 17029
		internal object $current;

		// Token: 0x04004286 RID: 17030
		internal bool $disposing;

		// Token: 0x04004287 RID: 17031
		internal int $PC;
	}

	// Token: 0x02000CD4 RID: 3284
	[CompilerGenerated]
	private sealed class <OnAdventuresEnterEncounter>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054C3 RID: 21699 RVA: 0x000CBE08 File Offset: 0x000CA208
		[DebuggerHidden]
		public <OnAdventuresEnterEncounter>c__Iterator5()
		{
		}

		// Token: 0x060054C4 RID: 21700 RVA: 0x000CBE10 File Offset: 0x000CA210
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventuresEnterEncounter;
				if (handler == null)
				{
					goto IL_E6;
				}
				enumerator = handler(arg1, arg2).GetEnumerator();
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
			IL_E6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011FA RID: 4602
		// (get) Token: 0x060054C5 RID: 21701 RVA: 0x000CBF20 File Offset: 0x000CA320
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011FB RID: 4603
		// (get) Token: 0x060054C6 RID: 21702 RVA: 0x000CBF28 File Offset: 0x000CA328
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054C7 RID: 21703 RVA: 0x000CBF30 File Offset: 0x000CA330
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

		// Token: 0x060054C8 RID: 21704 RVA: 0x000CBFA0 File Offset: 0x000CA3A0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054C9 RID: 21705 RVA: 0x000CBFA7 File Offset: 0x000CA3A7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054CA RID: 21706 RVA: 0x000CBFB0 File Offset: 0x000CA3B0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventuresEnterEncounter>c__Iterator5 <OnAdventuresEnterEncounter>c__Iterator = new Adventure.<OnAdventuresEnterEncounter>c__Iterator5();
			<OnAdventuresEnterEncounter>c__Iterator.$this = this;
			<OnAdventuresEnterEncounter>c__Iterator.arg1 = arg1;
			<OnAdventuresEnterEncounter>c__Iterator.arg2 = arg2;
			return <OnAdventuresEnterEncounter>c__Iterator;
		}

		// Token: 0x04004288 RID: 17032
		internal Func<List<AdventurerBattleUnit>, IEncounter, IEnumerable> <handler>__0;

		// Token: 0x04004289 RID: 17033
		internal List<AdventurerBattleUnit> arg1;

		// Token: 0x0400428A RID: 17034
		internal IEncounter arg2;

		// Token: 0x0400428B RID: 17035
		internal IEnumerator $locvar0;

		// Token: 0x0400428C RID: 17036
		internal object <_>__1;

		// Token: 0x0400428D RID: 17037
		internal IDisposable $locvar1;

		// Token: 0x0400428E RID: 17038
		internal Adventure $this;

		// Token: 0x0400428F RID: 17039
		internal object $current;

		// Token: 0x04004290 RID: 17040
		internal bool $disposing;

		// Token: 0x04004291 RID: 17041
		internal int $PC;
	}

	// Token: 0x02000CD5 RID: 3285
	[CompilerGenerated]
	private sealed class <OnAdventureCompletes>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054CB RID: 21707 RVA: 0x000CBFFC File Offset: 0x000CA3FC
		[DebuggerHidden]
		public <OnAdventureCompletes>c__Iterator6()
		{
		}

		// Token: 0x060054CC RID: 21708 RVA: 0x000CC004 File Offset: 0x000CA404
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventureCompletes;
				if (handler == null)
				{
					goto IL_EC;
				}
				enumerator = handler(arg1, arg2, finishedAdventure).GetEnumerator();
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
			IL_EC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011FC RID: 4604
		// (get) Token: 0x060054CD RID: 21709 RVA: 0x000CC118 File Offset: 0x000CA518
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011FD RID: 4605
		// (get) Token: 0x060054CE RID: 21710 RVA: 0x000CC120 File Offset: 0x000CA520
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054CF RID: 21711 RVA: 0x000CC128 File Offset: 0x000CA528
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

		// Token: 0x060054D0 RID: 21712 RVA: 0x000CC198 File Offset: 0x000CA598
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054D1 RID: 21713 RVA: 0x000CC19F File Offset: 0x000CA59F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054D2 RID: 21714 RVA: 0x000CC1A8 File Offset: 0x000CA5A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventureCompletes>c__Iterator6 <OnAdventureCompletes>c__Iterator = new Adventure.<OnAdventureCompletes>c__Iterator6();
			<OnAdventureCompletes>c__Iterator.$this = this;
			<OnAdventureCompletes>c__Iterator.arg1 = arg1;
			<OnAdventureCompletes>c__Iterator.arg2 = arg2;
			<OnAdventureCompletes>c__Iterator.finishedAdventure = finishedAdventure;
			return <OnAdventureCompletes>c__Iterator;
		}

		// Token: 0x04004292 RID: 17042
		internal Func<List<ResourceUpdate>, AdventureCompleteType, Adventure, IEnumerable> <handler>__0;

		// Token: 0x04004293 RID: 17043
		internal List<ResourceUpdate> arg1;

		// Token: 0x04004294 RID: 17044
		internal AdventureCompleteType arg2;

		// Token: 0x04004295 RID: 17045
		internal Adventure finishedAdventure;

		// Token: 0x04004296 RID: 17046
		internal IEnumerator $locvar0;

		// Token: 0x04004297 RID: 17047
		internal object <_>__1;

		// Token: 0x04004298 RID: 17048
		internal IDisposable $locvar1;

		// Token: 0x04004299 RID: 17049
		internal Adventure $this;

		// Token: 0x0400429A RID: 17050
		internal object $current;

		// Token: 0x0400429B RID: 17051
		internal bool $disposing;

		// Token: 0x0400429C RID: 17052
		internal int $PC;
	}

	// Token: 0x02000CD6 RID: 3286
	[CompilerGenerated]
	private sealed class <OnAdventureInitialized>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054D3 RID: 21715 RVA: 0x000CC200 File Offset: 0x000CA600
		[DebuggerHidden]
		public <OnAdventureInitialized>c__Iterator7()
		{
		}

		// Token: 0x060054D4 RID: 21716 RVA: 0x000CC208 File Offset: 0x000CA608
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventureInitialized;
				if (handler == null)
				{
					goto IL_E0;
				}
				enumerator = handler(arg1).GetEnumerator();
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
			IL_E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170011FE RID: 4606
		// (get) Token: 0x060054D5 RID: 21717 RVA: 0x000CC310 File Offset: 0x000CA710
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011FF RID: 4607
		// (get) Token: 0x060054D6 RID: 21718 RVA: 0x000CC318 File Offset: 0x000CA718
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054D7 RID: 21719 RVA: 0x000CC320 File Offset: 0x000CA720
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

		// Token: 0x060054D8 RID: 21720 RVA: 0x000CC390 File Offset: 0x000CA790
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054D9 RID: 21721 RVA: 0x000CC397 File Offset: 0x000CA797
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054DA RID: 21722 RVA: 0x000CC3A0 File Offset: 0x000CA7A0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventureInitialized>c__Iterator7 <OnAdventureInitialized>c__Iterator = new Adventure.<OnAdventureInitialized>c__Iterator7();
			<OnAdventureInitialized>c__Iterator.$this = this;
			<OnAdventureInitialized>c__Iterator.arg1 = arg1;
			return <OnAdventureInitialized>c__Iterator;
		}

		// Token: 0x0400429D RID: 17053
		internal Func<Adventure, IEnumerable> <handler>__0;

		// Token: 0x0400429E RID: 17054
		internal Adventure arg1;

		// Token: 0x0400429F RID: 17055
		internal IEnumerator $locvar0;

		// Token: 0x040042A0 RID: 17056
		internal object <_>__1;

		// Token: 0x040042A1 RID: 17057
		internal IDisposable $locvar1;

		// Token: 0x040042A2 RID: 17058
		internal Adventure $this;

		// Token: 0x040042A3 RID: 17059
		internal object $current;

		// Token: 0x040042A4 RID: 17060
		internal bool $disposing;

		// Token: 0x040042A5 RID: 17061
		internal int $PC;
	}

	// Token: 0x02000CD7 RID: 3287
	[CompilerGenerated]
	private sealed class <OnAdventuresCompleteCollectChestFinalRewards>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054DB RID: 21723 RVA: 0x000CC3E0 File Offset: 0x000CA7E0
		[DebuggerHidden]
		public <OnAdventuresCompleteCollectChestFinalRewards>c__Iterator8()
		{
		}

		// Token: 0x060054DC RID: 21724 RVA: 0x000CC3E8 File Offset: 0x000CA7E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				handler = this.AdventuresCompleteCollectChestFinalRewards;
				if (handler == null)
				{
					goto IL_E6;
				}
				enumerator = handler(arg1, arg2).GetEnumerator();
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
			IL_E6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001200 RID: 4608
		// (get) Token: 0x060054DD RID: 21725 RVA: 0x000CC4F8 File Offset: 0x000CA8F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001201 RID: 4609
		// (get) Token: 0x060054DE RID: 21726 RVA: 0x000CC500 File Offset: 0x000CA900
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054DF RID: 21727 RVA: 0x000CC508 File Offset: 0x000CA908
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

		// Token: 0x060054E0 RID: 21728 RVA: 0x000CC578 File Offset: 0x000CA978
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054E1 RID: 21729 RVA: 0x000CC57F File Offset: 0x000CA97F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054E2 RID: 21730 RVA: 0x000CC588 File Offset: 0x000CA988
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Adventure.<OnAdventuresCompleteCollectChestFinalRewards>c__Iterator8 <OnAdventuresCompleteCollectChestFinalRewards>c__Iterator = new Adventure.<OnAdventuresCompleteCollectChestFinalRewards>c__Iterator8();
			<OnAdventuresCompleteCollectChestFinalRewards>c__Iterator.$this = this;
			<OnAdventuresCompleteCollectChestFinalRewards>c__Iterator.arg1 = arg1;
			<OnAdventuresCompleteCollectChestFinalRewards>c__Iterator.arg2 = arg2;
			return <OnAdventuresCompleteCollectChestFinalRewards>c__Iterator;
		}

		// Token: 0x040042A6 RID: 17062
		internal Func<AdventureCompleteType, List<ResourceUpdate>, IEnumerable> <handler>__0;

		// Token: 0x040042A7 RID: 17063
		internal AdventureCompleteType arg1;

		// Token: 0x040042A8 RID: 17064
		internal List<ResourceUpdate> arg2;

		// Token: 0x040042A9 RID: 17065
		internal IEnumerator $locvar0;

		// Token: 0x040042AA RID: 17066
		internal object <_>__1;

		// Token: 0x040042AB RID: 17067
		internal IDisposable $locvar1;

		// Token: 0x040042AC RID: 17068
		internal Adventure $this;

		// Token: 0x040042AD RID: 17069
		internal object $current;

		// Token: 0x040042AE RID: 17070
		internal bool $disposing;

		// Token: 0x040042AF RID: 17071
		internal int $PC;
	}
}
