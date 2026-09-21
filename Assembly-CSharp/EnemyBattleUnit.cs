using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000341 RID: 833
public class EnemyBattleUnit : IBattleUnit, IBattleEffectSource
{
	// Token: 0x06001633 RID: 5683 RVA: 0x000AFAB4 File Offset: 0x000ADEB4
	public EnemyBattleUnit(MonsterUnitConfigurationBase unitConfig, List<AdventureUnitSkill> skills, double powerlevel, string id, Adventure adventure, int level)
	{
		this.Skills = skills;
		this.BattleEnemyClass = unitConfig.CorrespondingUnitClass;
		this._style = unitConfig.CorrespondingClassStyle;
		this.BattleEffects = new List<BattleEffectBase>();
		double num = (powerlevel < 1.0) ? powerlevel : 1.0;
		num += (double)Convert.ToSingle(UnitGrowthProfile.GetRandomAttributeValue(0.30000001192092896));
		if (powerlevel > 10.0)
		{
			num += (powerlevel - 10.0) * 0.1;
		}
		this.SlotSelection = ((!(unitConfig is BossUnitConfigurationBase)) ? ((!(unitConfig is MinionUnitConfigurationBase)) ? AdventureEncounterSlotType.MiniBoss : AdventureEncounterSlotType.Minion) : AdventureEncounterSlotType.Boss);
		UnitGrowthProfile monsterGrowthProfile = unitConfig.GetMonsterGrowthProfile(adventure.CorrespondingDifficultyMeasurement);
		this.Attributes = monsterGrowthProfile.GetInitializedAttributes(num);
		this.Status = BattleUnitStatus.Active;
		this.BattleEffects = new List<BattleEffectBase>();
		this.Items = new List<Item>();
		this.PowerLevel = powerlevel;
		this.Level = (double)level;
		this.Id = id;
		this._specialEffects = unitConfig.GetSpecialEffectDataLoads(adventure.CorrespondingDifficultyMeasurement);
		this.OutputType = unitConfig.GetOutputType(adventure.CorrespondingDifficultyMeasurement, adventure.AdventureType);
		if (powerlevel > 1.0)
		{
			UnitLevelUpChange levelUpChange = monsterGrowthProfile.GetLevelUpChange(powerlevel - 1.0, 0.5);
			foreach (LevelUpChangeValue levelUpChangeValue in levelUpChange.ChangedValues)
			{
				this.Attributes.AddValue(levelUpChangeValue.AttributeType, levelUpChangeValue.Value);
			}
		}
		List<AttributeType> list = (from t in ItemExtensions.AllAttributeTypes
		where t != AttributeType.None && t != AttributeType.Allresistances
		select t).ToList<AttributeType>();
		this.NakedAttributeValues = new Dictionary<AttributeType, double>();
		Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> values = this.Attributes.GetValues();
		foreach (AttributeType attributeType in list)
		{
			this.NakedAttributeValues.Add(attributeType, values.RetrieveLeveledValue(AttributeRetrievalLevel.Naked, attributeType));
		}
		this.GearedAttributeValues = new Dictionary<AttributeType, double>();
		foreach (AttributeType attributeType2 in list)
		{
			if (attributeType2 == AttributeType.Intelligience || attributeType2 == AttributeType.Strength)
			{
				double num2 = this.Attributes.GetAttributeValue(attributeType2, AttributeRetrievalLevel.Gear);
				if (num2 > 7000.0 && adventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 3000.0)
				{
					num2 = 7000.0;
				}
				if (num2 > 9500.0 && adventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 4000.0)
				{
					num2 = 9500.0;
				}
				if (num2 > 12000.0 && adventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 5000.0)
				{
					num2 = 12000.0;
				}
				this.GearedAttributeValues.Add(attributeType2, num2);
			}
			else
			{
				this.GearedAttributeValues.Add(attributeType2, this.Attributes.GetAttributeValue(attributeType2, AttributeRetrievalLevel.Gear));
			}
		}
		this.CurrentAdventure = adventure;
	}

	// Token: 0x06001634 RID: 5684 RVA: 0x000AFE90 File Offset: 0x000AE290
	private EnemyBattleUnit()
	{
	}

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000AFEA3 File Offset: 0x000AE2A3
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000AFEAB File Offset: 0x000AE2AB
	public List<AttributeModifier> Attributes
	{
		[CompilerGenerated]
		get
		{
			return this.<Attributes>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Attributes>k__BackingField = value;
		}
	}

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000AFEB4 File Offset: 0x000AE2B4
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000AFEBC File Offset: 0x000AE2BC
	public string Id
	{
		[CompilerGenerated]
		get
		{
			return this.<Id>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Id>k__BackingField = value;
		}
	}

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000AFEC5 File Offset: 0x000AE2C5
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000AFECD File Offset: 0x000AE2CD
	public AdventureEncounterSlotType SlotSelection
	{
		[CompilerGenerated]
		get
		{
			return this.<SlotSelection>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SlotSelection>k__BackingField = value;
		}
	}

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000AFED6 File Offset: 0x000AE2D6
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000AFEDE File Offset: 0x000AE2DE
	public UnitClass BattleEnemyClass
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleEnemyClass>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleEnemyClass>k__BackingField = value;
		}
	}

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000AFEE7 File Offset: 0x000AE2E7
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000AFEEF File Offset: 0x000AE2EF
	public double PowerLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<PowerLevel>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<PowerLevel>k__BackingField = value;
		}
	}

	// Token: 0x0600163F RID: 5695 RVA: 0x000AFEF8 File Offset: 0x000AE2F8
	public double GetPropertyValue(AttributeType type)
	{
		AttributeModifier attributeModifier = this.Attributes.FirstOrDefault((AttributeModifier a) => a.AttributeType == type);
		if (attributeModifier == null)
		{
			attributeModifier = new AttributeModifier
			{
				AttributeType = type,
				Value = 0.0,
				ModificationType = ModificationType.Addition,
				AttributeModifierType = AttributeModifierType.Normal
			};
			this.Attributes.Add(attributeModifier);
		}
		return attributeModifier.Value;
	}

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x06001640 RID: 5696 RVA: 0x000AFF75 File Offset: 0x000AE375
	// (set) Token: 0x06001641 RID: 5697 RVA: 0x000AFF7D File Offset: 0x000AE37D
	public double HealthPoints
	{
		get
		{
			return this._healthPoints;
		}
		set
		{
			if (value < 0.0)
			{
				this._healthPoints = 0.0;
			}
			else
			{
				this._healthPoints = value;
			}
		}
	}

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x06001642 RID: 5698 RVA: 0x000AFFA9 File Offset: 0x000AE3A9
	// (set) Token: 0x06001643 RID: 5699 RVA: 0x000AFFB1 File Offset: 0x000AE3B1
	public List<BattleEffectBase> BattleEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleEffects>k__BackingField = value;
		}
	}

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x06001644 RID: 5700 RVA: 0x000AFFBA File Offset: 0x000AE3BA
	// (set) Token: 0x06001645 RID: 5701 RVA: 0x000AFFC2 File Offset: 0x000AE3C2
	public BattleUnitStatus Status
	{
		[CompilerGenerated]
		get
		{
			return this.<Status>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Status>k__BackingField = value;
		}
	}

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x06001646 RID: 5702 RVA: 0x000AFFCB File Offset: 0x000AE3CB
	public bool IsPlayer
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06001647 RID: 5703 RVA: 0x000AFFCE File Offset: 0x000AE3CE
	public UnitClassStyle GetUnitClassStyle()
	{
		return this._style;
	}

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x06001648 RID: 5704 RVA: 0x000AFFD6 File Offset: 0x000AE3D6
	// (set) Token: 0x06001649 RID: 5705 RVA: 0x000AFFDE File Offset: 0x000AE3DE
	public Dictionary<AttributeType, double> NakedAttributeValues
	{
		[CompilerGenerated]
		get
		{
			return this.<NakedAttributeValues>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<NakedAttributeValues>k__BackingField = value;
		}
	}

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x0600164A RID: 5706 RVA: 0x000AFFE7 File Offset: 0x000AE3E7
	// (set) Token: 0x0600164B RID: 5707 RVA: 0x000AFFEF File Offset: 0x000AE3EF
	public Dictionary<AttributeType, double> GearedAttributeValues
	{
		[CompilerGenerated]
		get
		{
			return this.<GearedAttributeValues>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<GearedAttributeValues>k__BackingField = value;
		}
	}

	// Token: 0x0600164C RID: 5708 RVA: 0x000AFFF8 File Offset: 0x000AE3F8
	public bool IsBoss()
	{
		return this.SlotSelection == AdventureEncounterSlotType.Boss || this.SlotSelection == AdventureEncounterSlotType.MiniBoss;
	}

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000B0012 File Offset: 0x000AE412
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000B001A File Offset: 0x000AE41A
	public List<AdventureUnitSkill> Skills
	{
		[CompilerGenerated]
		get
		{
			return this.<Skills>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Skills>k__BackingField = value;
		}
	}

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x0600164F RID: 5711 RVA: 0x000B0023 File Offset: 0x000AE423
	// (set) Token: 0x06001650 RID: 5712 RVA: 0x000B002B File Offset: 0x000AE42B
	public Adventure CurrentAdventure
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentAdventure>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CurrentAdventure>k__BackingField = value;
		}
	}

	// Token: 0x06001651 RID: 5713 RVA: 0x000B0034 File Offset: 0x000AE434
	public virtual IEnumerable SelfEventCallback(IBattleUnit unit, AdventureEventType arg1, object arg2)
	{
		foreach (Func<IBattleUnit, AdventureEventType, object, IEnumerable> receivesEventCallBack in (from b in this._receivesEventCallBacks
		select b).ToList<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>())
		{
			IEnumerator enumerator2 = receivesEventCallBack(unit, arg1, arg2).GetEnumerator();
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
		yield break;
	}

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x06001652 RID: 5714 RVA: 0x000B006C File Offset: 0x000AE46C
	public List<ISpecialEffectDataLoad> SpecialEffects
	{
		get
		{
			if (this.BattleEffects.OfType<SealedEffect>().Any<SealedEffect>())
			{
				return new List<ISpecialEffectDataLoad>();
			}
			return this._specialEffects;
		}
	}

	// Token: 0x06001653 RID: 5715 RVA: 0x000B0090 File Offset: 0x000AE490
	public List<AttributeModifier> GetModifiers()
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		list.AddRange(this.Items.SelectMany((Item i) => i.GetAttributeModifiers()));
		list.AddRange(this.Attributes);
		list.AddRange(this.BattleEffects.SelectMany((BattleEffectBase be) => be.GetAdditionalModifiers(this, this.CurrentEncounter)));
		return list;
	}

	// Token: 0x06001654 RID: 5716 RVA: 0x000B00FB File Offset: 0x000AE4FB
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001655 RID: 5717 RVA: 0x000B0103 File Offset: 0x000AE503
	public UnitClass GetUnitType()
	{
		return this.BattleEnemyClass;
	}

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x06001656 RID: 5718 RVA: 0x000B010B File Offset: 0x000AE50B
	// (set) Token: 0x06001657 RID: 5719 RVA: 0x000B0113 File Offset: 0x000AE513
	public List<Item> Items
	{
		[CompilerGenerated]
		get
		{
			return this.<Items>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Items>k__BackingField = value;
		}
	}

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x06001658 RID: 5720 RVA: 0x000B011C File Offset: 0x000AE51C
	public IEncounter CurrentEncounter
	{
		get
		{
			return this.CurrentAdventure.CurrentEncounter;
		}
	}

	// Token: 0x06001659 RID: 5721 RVA: 0x000B012C File Offset: 0x000AE52C
	public IEnumerable LeavesEncounter()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
		yield break;
	}

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x0600165A RID: 5722 RVA: 0x000B014F File Offset: 0x000AE54F
	// (set) Token: 0x0600165B RID: 5723 RVA: 0x000B0157 File Offset: 0x000AE557
	public OutputType OutputType
	{
		[CompilerGenerated]
		get
		{
			return this.<OutputType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<OutputType>k__BackingField = value;
		}
	}

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x0600165C RID: 5724 RVA: 0x000B0160 File Offset: 0x000AE560
	// (set) Token: 0x0600165D RID: 5725 RVA: 0x000B0168 File Offset: 0x000AE568
	public double Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x0600165E RID: 5726 RVA: 0x000B0171 File Offset: 0x000AE571
	public void RemoveAllEventCallbackFromUiLayer()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
	}

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x0600165F RID: 5727 RVA: 0x000B0180 File Offset: 0x000AE580
	public double TurnProgress
	{
		get
		{
			if (this.CurrentEncounter == null)
			{
				return 0.0;
			}
			if (!(this.CurrentEncounter as BattleEncounter).TurnCounter.ContainsKey(this))
			{
				return 0.0;
			}
			double num = (this.CurrentEncounter as BattleEncounter).TurnCounter[this] / PlayerProfile.TurnSpeedGauge;
			return (num < 1.0) ? ((num > 0.0) ? num : 0.0) : 1.0;
		}
	}

	// Token: 0x06001660 RID: 5728 RVA: 0x000B0224 File Offset: 0x000AE624
	public OutputType GetOutputType()
	{
		List<ElementReplacementData> source = this.SpecialEffects.OfType<ElementReplacementData>().ToList<ElementReplacementData>();
		if (source.Any<ElementReplacementData>())
		{
			return source.Last<ElementReplacementData>().Type;
		}
		return this.OutputType;
	}

	// Token: 0x06001661 RID: 5729 RVA: 0x000B025F File Offset: 0x000AE65F
	public void RegisterEventCallbackFromUiLayer(Func<IBattleUnit, AdventureEventType, object, IEnumerable> callback)
	{
		this._receivesEventCallBacks.Add(callback);
	}

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06001662 RID: 5730 RVA: 0x000B026D File Offset: 0x000AE66D
	public IBattleUnit SourceUnit
	{
		get
		{
			return this;
		}
	}

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x06001663 RID: 5731 RVA: 0x000B0270 File Offset: 0x000AE670
	public QualityGrade Grade
	{
		get
		{
			return QualityGrade.Normal;
		}
	}

	// Token: 0x06001664 RID: 5732 RVA: 0x000B0273 File Offset: 0x000AE673
	[CompilerGenerated]
	private static bool <EnemyBattleUnit>m__0(AttributeType t)
	{
		return t != AttributeType.None && t != AttributeType.Allresistances;
	}

	// Token: 0x06001665 RID: 5733 RVA: 0x000B0286 File Offset: 0x000AE686
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetModifiers>m__1(Item i)
	{
		return i.GetAttributeModifiers();
	}

	// Token: 0x06001666 RID: 5734 RVA: 0x000B028E File Offset: 0x000AE68E
	[CompilerGenerated]
	private IEnumerable<AttributeModifier> <GetModifiers>m__2(BattleEffectBase be)
	{
		return be.GetAdditionalModifiers(this, this.CurrentEncounter);
	}

	// Token: 0x04001668 RID: 5736
	private List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>> _receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();

	// Token: 0x04001669 RID: 5737
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <Attributes>k__BackingField;

	// Token: 0x0400166A RID: 5738
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Id>k__BackingField;

	// Token: 0x0400166B RID: 5739
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureEncounterSlotType <SlotSelection>k__BackingField;

	// Token: 0x0400166C RID: 5740
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <BattleEnemyClass>k__BackingField;

	// Token: 0x0400166D RID: 5741
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <PowerLevel>k__BackingField;

	// Token: 0x0400166E RID: 5742
	private double _healthPoints;

	// Token: 0x0400166F RID: 5743
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<BattleEffectBase> <BattleEffects>k__BackingField;

	// Token: 0x04001670 RID: 5744
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleUnitStatus <Status>k__BackingField;

	// Token: 0x04001671 RID: 5745
	private UnitClassStyle _style;

	// Token: 0x04001672 RID: 5746
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <NakedAttributeValues>k__BackingField;

	// Token: 0x04001673 RID: 5747
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <GearedAttributeValues>k__BackingField;

	// Token: 0x04001674 RID: 5748
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventureUnitSkill> <Skills>k__BackingField;

	// Token: 0x04001675 RID: 5749
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adventure <CurrentAdventure>k__BackingField;

	// Token: 0x04001676 RID: 5750
	private List<ISpecialEffectDataLoad> _specialEffects;

	// Token: 0x04001677 RID: 5751
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Item> <Items>k__BackingField;

	// Token: 0x04001678 RID: 5752
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <OutputType>k__BackingField;

	// Token: 0x04001679 RID: 5753
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Level>k__BackingField;

	// Token: 0x0400167A RID: 5754
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache0;

	// Token: 0x0400167B RID: 5755
	[CompilerGenerated]
	private static Func<Item, IEnumerable<AttributeModifier>> <>f__am$cache1;

	// Token: 0x02000CA1 RID: 3233
	[CompilerGenerated]
	private sealed class <GetPropertyValue>c__AnonStorey2
	{
		// Token: 0x060053AA RID: 21418 RVA: 0x000B029D File Offset: 0x000AE69D
		public <GetPropertyValue>c__AnonStorey2()
		{
		}

		// Token: 0x060053AB RID: 21419 RVA: 0x000B02A5 File Offset: 0x000AE6A5
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.type;
		}

		// Token: 0x0400413C RID: 16700
		internal AttributeType type;
	}

	// Token: 0x02000CA2 RID: 3234
	[CompilerGenerated]
	private sealed class <SelfEventCallback>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053AC RID: 21420 RVA: 0x000B02B5 File Offset: 0x000AE6B5
		[DebuggerHidden]
		public <SelfEventCallback>c__Iterator0()
		{
		}

		// Token: 0x060053AD RID: 21421 RVA: 0x000B02C0 File Offset: 0x000AE6C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = (from b in this._receivesEventCallBacks
				select b).ToList<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>().GetEnumerator();
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
				case 1u:
					Block_5:
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
					receivesEventCallBack = enumerator.Current;
					enumerator2 = receivesEventCallBack(unit, arg1, arg2).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
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

		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x060053AE RID: 21422 RVA: 0x000B0450 File Offset: 0x000AE850
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x060053AF RID: 21423 RVA: 0x000B0458 File Offset: 0x000AE858
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053B0 RID: 21424 RVA: 0x000B0460 File Offset: 0x000AE860
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
			}
		}

		// Token: 0x060053B1 RID: 21425 RVA: 0x000B04F4 File Offset: 0x000AE8F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053B2 RID: 21426 RVA: 0x000B04FB File Offset: 0x000AE8FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053B3 RID: 21427 RVA: 0x000B0504 File Offset: 0x000AE904
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyBattleUnit.<SelfEventCallback>c__Iterator0 <SelfEventCallback>c__Iterator = new EnemyBattleUnit.<SelfEventCallback>c__Iterator0();
			<SelfEventCallback>c__Iterator.$this = this;
			<SelfEventCallback>c__Iterator.unit = unit;
			<SelfEventCallback>c__Iterator.arg1 = arg1;
			<SelfEventCallback>c__Iterator.arg2 = arg2;
			return <SelfEventCallback>c__Iterator;
		}

		// Token: 0x060053B4 RID: 21428 RVA: 0x000B055C File Offset: 0x000AE95C
		private static Func<IBattleUnit, AdventureEventType, object, IEnumerable> <>m__0(Func<IBattleUnit, AdventureEventType, object, IEnumerable> b)
		{
			return b;
		}

		// Token: 0x0400413D RID: 16701
		internal List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>.Enumerator $locvar0;

		// Token: 0x0400413E RID: 16702
		internal Func<IBattleUnit, AdventureEventType, object, IEnumerable> <receivesEventCallBack>__1;

		// Token: 0x0400413F RID: 16703
		internal IBattleUnit unit;

		// Token: 0x04004140 RID: 16704
		internal AdventureEventType arg1;

		// Token: 0x04004141 RID: 16705
		internal object arg2;

		// Token: 0x04004142 RID: 16706
		internal IEnumerator $locvar1;

		// Token: 0x04004143 RID: 16707
		internal object <_>__2;

		// Token: 0x04004144 RID: 16708
		internal IDisposable $locvar2;

		// Token: 0x04004145 RID: 16709
		internal EnemyBattleUnit $this;

		// Token: 0x04004146 RID: 16710
		internal object $current;

		// Token: 0x04004147 RID: 16711
		internal bool $disposing;

		// Token: 0x04004148 RID: 16712
		internal int $PC;

		// Token: 0x04004149 RID: 16713
		private static Func<Func<IBattleUnit, AdventureEventType, object, IEnumerable>, Func<IBattleUnit, AdventureEventType, object, IEnumerable>> <>f__am$cache0;
	}

	// Token: 0x02000CA3 RID: 3235
	[CompilerGenerated]
	private sealed class <LeavesEncounter>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060053B5 RID: 21429 RVA: 0x000B055F File Offset: 0x000AE95F
		[DebuggerHidden]
		public <LeavesEncounter>c__Iterator1()
		{
		}

		// Token: 0x060053B6 RID: 21430 RVA: 0x000B0567 File Offset: 0x000AE967
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
			}
			return false;
		}

		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x060053B7 RID: 21431 RVA: 0x000B0591 File Offset: 0x000AE991
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x060053B8 RID: 21432 RVA: 0x000B0599 File Offset: 0x000AE999
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060053B9 RID: 21433 RVA: 0x000B05A1 File Offset: 0x000AE9A1
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060053BA RID: 21434 RVA: 0x000B05A3 File Offset: 0x000AE9A3
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060053BB RID: 21435 RVA: 0x000B05AA File Offset: 0x000AE9AA
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060053BC RID: 21436 RVA: 0x000B05B4 File Offset: 0x000AE9B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnemyBattleUnit.<LeavesEncounter>c__Iterator1 <LeavesEncounter>c__Iterator = new EnemyBattleUnit.<LeavesEncounter>c__Iterator1();
			<LeavesEncounter>c__Iterator.$this = this;
			return <LeavesEncounter>c__Iterator;
		}

		// Token: 0x0400414A RID: 16714
		internal EnemyBattleUnit $this;

		// Token: 0x0400414B RID: 16715
		internal object $current;

		// Token: 0x0400414C RID: 16716
		internal bool $disposing;

		// Token: 0x0400414D RID: 16717
		internal int $PC;
	}
}
