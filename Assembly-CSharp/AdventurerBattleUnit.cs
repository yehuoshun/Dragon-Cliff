using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.Dataload;

// Token: 0x0200042D RID: 1069
public class AdventurerBattleUnit : IBattleUnit, IBattleEffectSource
{
	// Token: 0x06001D9F RID: 7583 RVA: 0x000CC7AA File Offset: 0x000CABAA
	public AdventurerBattleUnit()
	{
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x06001DA0 RID: 7584 RVA: 0x000CC7BD File Offset: 0x000CABBD
	public IEncounter CurrentEncounter
	{
		get
		{
			return this.CurrentAdventure.CurrentEncounter;
		}
	}

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x06001DA1 RID: 7585 RVA: 0x000CC7CA File Offset: 0x000CABCA
	// (set) Token: 0x06001DA2 RID: 7586 RVA: 0x000CC7D2 File Offset: 0x000CABD2
	public string AdventurerId
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerId>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdventurerId>k__BackingField = value;
		}
	}

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x06001DA3 RID: 7587 RVA: 0x000CC7DB File Offset: 0x000CABDB
	// (set) Token: 0x06001DA4 RID: 7588 RVA: 0x000CC7E3 File Offset: 0x000CABE3
	public double HealthPoints
	{
		[CompilerGenerated]
		get
		{
			return this.<HealthPoints>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HealthPoints>k__BackingField = value;
		}
	}

	// Token: 0x06001DA5 RID: 7589 RVA: 0x000CC7EC File Offset: 0x000CABEC
	public UnitClassStyle GetUnitClassStyle()
	{
		return this.GetUnitType().GetConfiguration().CorrespondingClassStyle;
	}

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x06001DA6 RID: 7590 RVA: 0x000CC7FE File Offset: 0x000CABFE
	// (set) Token: 0x06001DA7 RID: 7591 RVA: 0x000CC806 File Offset: 0x000CAC06
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

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x06001DA8 RID: 7592 RVA: 0x000CC80F File Offset: 0x000CAC0F
	// (set) Token: 0x06001DA9 RID: 7593 RVA: 0x000CC817 File Offset: 0x000CAC17
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

	// Token: 0x06001DAA RID: 7594 RVA: 0x000CC820 File Offset: 0x000CAC20
	public bool IsBoss()
	{
		return false;
	}

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06001DAB RID: 7595 RVA: 0x000CC823 File Offset: 0x000CAC23
	// (set) Token: 0x06001DAC RID: 7596 RVA: 0x000CC82B File Offset: 0x000CAC2B
	public List<AdventureUnitSkill> Skills
	{
		[CompilerGenerated]
		get
		{
			return this.<Skills>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Skills>k__BackingField = value;
		}
	}

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06001DAD RID: 7597 RVA: 0x000CC834 File Offset: 0x000CAC34
	// (set) Token: 0x06001DAE RID: 7598 RVA: 0x000CC83C File Offset: 0x000CAC3C
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

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06001DAF RID: 7599 RVA: 0x000CC845 File Offset: 0x000CAC45
	// (set) Token: 0x06001DB0 RID: 7600 RVA: 0x000CC84D File Offset: 0x000CAC4D
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

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x06001DB1 RID: 7601 RVA: 0x000CC856 File Offset: 0x000CAC56
	// (set) Token: 0x06001DB2 RID: 7602 RVA: 0x000CC85E File Offset: 0x000CAC5E
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

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x06001DB3 RID: 7603 RVA: 0x000CC867 File Offset: 0x000CAC67
	// (set) Token: 0x06001DB4 RID: 7604 RVA: 0x000CC86F File Offset: 0x000CAC6F
	public AdventurerProfile AdventurerProfile
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerProfile>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdventurerProfile>k__BackingField = value;
		}
	}

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x06001DB5 RID: 7605 RVA: 0x000CC878 File Offset: 0x000CAC78
	// (set) Token: 0x06001DB6 RID: 7606 RVA: 0x000CC880 File Offset: 0x000CAC80
	public List<Item> Items
	{
		[CompilerGenerated]
		get
		{
			return this.<Items>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Items>k__BackingField = value;
		}
	}

	// Token: 0x06001DB7 RID: 7607 RVA: 0x000CC88C File Offset: 0x000CAC8C
	public static AdventurerBattleUnit InitializeAdventurerBattleUnit(AdventurerProfile profile, Adventure adventure)
	{
		AdventurerBattleUnit unit = new AdventurerBattleUnit
		{
			HealthPoints = profile.GetMaxLife(AttributeRetrievalLevel.Skill),
			Skills = new List<AdventureUnitSkill>(),
			BattleEffects = new List<BattleEffectBase>(),
			AdventurerId = profile.Id,
			Status = BattleUnitStatus.Active,
			AdventurerProfile = profile,
			CurrentAdventure = adventure,
			Items = profile.GetEquipments(),
			_specialEffects = new List<ISpecialEffectDataLoad>()
		};
		unit._modifiers = (from a in profile.GetAllAttributes_Complete(null)
		select new AttributeModifier
		{
			AttributeType = a.AttributeType,
			ModificationType = a.ModificationType,
			Value = a.Value,
			Key = a.Key,
			AttributeModifierType = a.AttributeModifierType
		}).ToList<AttributeModifier>();
		unit.NakedAttributeValues = new Dictionary<AttributeType, double>();
		unit.GearedAttributeValues = new Dictionary<AttributeType, double>();
		List<AttributeType> list = (from a in ItemExtensions.AllAttributeTypes
		where a != AttributeType.None && a != AttributeType.Allresistances
		select a).ToList<AttributeType>();
		foreach (AttributeType attributeType in list)
		{
			unit.NakedAttributeValues.Add(attributeType, unit._modifiers.GetAttributeValue(attributeType, AttributeRetrievalLevel.Naked));
		}
		foreach (AttributeType attributeType2 in list)
		{
			unit.GearedAttributeValues.Add(attributeType2, unit._modifiers.GetAttributeValue(attributeType2, AttributeRetrievalLevel.Gear));
		}
		if (TestingProcessor.InTesting)
		{
			unit._specialEffects.Add(new EdgelessData
			{
				BoostRate = 1.0,
				PenetrationRate = 1.0
			});
		}
		unit._specialEffects.AddRange(profile.GetSpecialEffects());
		unit.Skills = (from sk in profile.GetSkills()
		where sk.IsEnabled
		select sk.InitializeBattleUnitSkill(unit)).ToList<AdventureUnitSkill>();
		return unit;
	}

	// Token: 0x06001DB8 RID: 7608 RVA: 0x000CCB04 File Offset: 0x000CAF04
	public void ResetLife()
	{
		this.HealthPoints = this.AdventurerProfile.GetMaxLife(AttributeRetrievalLevel.Skill);
		this.BattleEffects = new List<BattleEffectBase>();
		this.Status = BattleUnitStatus.Active;
	}

	// Token: 0x06001DB9 RID: 7609 RVA: 0x000CCB2C File Offset: 0x000CAF2C
	public IEnumerable SelfEventCallback(IBattleUnit battleUnit, AdventureEventType arg1, object arg2)
	{
		foreach (Func<IBattleUnit, AdventureEventType, object, IEnumerable> receivesEventCallBack in this._receivesEventCallBacks)
		{
			IEnumerator enumerator2 = receivesEventCallBack(battleUnit, arg1, arg2).GetEnumerator();
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

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x06001DBA RID: 7610 RVA: 0x000CCB64 File Offset: 0x000CAF64
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

	// Token: 0x06001DBB RID: 7611 RVA: 0x000CCB88 File Offset: 0x000CAF88
	public List<AttributeModifier> GetModifiers()
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		list.AddRange(this._modifiers);
		list.AddRange(this.BattleEffects.SelectMany((BattleEffectBase ef) => ef.GetAdditionalModifiers(this, this.CurrentEncounter)));
		return list;
	}

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x06001DBC RID: 7612 RVA: 0x000CCBC5 File Offset: 0x000CAFC5
	public bool IsPlayer
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06001DBD RID: 7613 RVA: 0x000CCBC8 File Offset: 0x000CAFC8
	public string GetId()
	{
		return this.AdventurerId;
	}

	// Token: 0x06001DBE RID: 7614 RVA: 0x000CCBD0 File Offset: 0x000CAFD0
	public UnitClass GetUnitType()
	{
		return this.AdventurerProfile.UnitClass;
	}

	// Token: 0x06001DBF RID: 7615 RVA: 0x000CCBE0 File Offset: 0x000CAFE0
	public IEnumerable LeavesEncounter()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
		yield break;
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x000CCC03 File Offset: 0x000CB003
	public double Level
	{
		get
		{
			return (double)this.AdventurerProfile.GetLevel();
		}
	}

	// Token: 0x06001DC1 RID: 7617 RVA: 0x000CCC11 File Offset: 0x000CB011
	public void RemoveAllEventCallbackFromUiLayer()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
	}

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x06001DC2 RID: 7618 RVA: 0x000CCC20 File Offset: 0x000CB020
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

	// Token: 0x06001DC3 RID: 7619 RVA: 0x000CCCC4 File Offset: 0x000CB0C4
	public OutputType GetOutputType()
	{
		List<ElementReplacementData> source = this.SpecialEffects.OfType<ElementReplacementData>().ToList<ElementReplacementData>();
		if (source.Any<ElementReplacementData>())
		{
			return source.Last<ElementReplacementData>().Type;
		}
		return this.AdventurerProfile.OutputType;
	}

	// Token: 0x06001DC4 RID: 7620 RVA: 0x000CCD04 File Offset: 0x000CB104
	public void RegisterEventCallbackFromUiLayer(Func<IBattleUnit, AdventureEventType, object, IEnumerable> callback)
	{
		this._receivesEventCallBacks.Add(callback);
	}

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06001DC5 RID: 7621 RVA: 0x000CCD12 File Offset: 0x000CB112
	public IBattleUnit SourceUnit
	{
		get
		{
			return this;
		}
	}

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x06001DC6 RID: 7622 RVA: 0x000CCD15 File Offset: 0x000CB115
	public QualityGrade Grade
	{
		get
		{
			return this.AdventurerProfile.Grade;
		}
	}

	// Token: 0x06001DC7 RID: 7623 RVA: 0x000CCD24 File Offset: 0x000CB124
	[CompilerGenerated]
	private static AttributeModifier <InitializeAdventurerBattleUnit>m__0(AttributeModifier a)
	{
		return new AttributeModifier
		{
			AttributeType = a.AttributeType,
			ModificationType = a.ModificationType,
			Value = a.Value,
			Key = a.Key,
			AttributeModifierType = a.AttributeModifierType
		};
	}

	// Token: 0x06001DC8 RID: 7624 RVA: 0x000CCD74 File Offset: 0x000CB174
	[CompilerGenerated]
	private static bool <InitializeAdventurerBattleUnit>m__1(AttributeType a)
	{
		return a != AttributeType.None && a != AttributeType.Allresistances;
	}

	// Token: 0x06001DC9 RID: 7625 RVA: 0x000CCD87 File Offset: 0x000CB187
	[CompilerGenerated]
	private static bool <InitializeAdventurerBattleUnit>m__2(Skill sk)
	{
		return sk.IsEnabled;
	}

	// Token: 0x06001DCA RID: 7626 RVA: 0x000CCD8F File Offset: 0x000CB18F
	[CompilerGenerated]
	private IEnumerable<AttributeModifier> <GetModifiers>m__3(BattleEffectBase ef)
	{
		return ef.GetAdditionalModifiers(this, this.CurrentEncounter);
	}

	// Token: 0x04001B9B RID: 7067
	private List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>> _receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();

	// Token: 0x04001B9C RID: 7068
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <AdventurerId>k__BackingField;

	// Token: 0x04001B9D RID: 7069
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <HealthPoints>k__BackingField;

	// Token: 0x04001B9E RID: 7070
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <NakedAttributeValues>k__BackingField;

	// Token: 0x04001B9F RID: 7071
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <GearedAttributeValues>k__BackingField;

	// Token: 0x04001BA0 RID: 7072
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventureUnitSkill> <Skills>k__BackingField;

	// Token: 0x04001BA1 RID: 7073
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<BattleEffectBase> <BattleEffects>k__BackingField;

	// Token: 0x04001BA2 RID: 7074
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleUnitStatus <Status>k__BackingField;

	// Token: 0x04001BA3 RID: 7075
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adventure <CurrentAdventure>k__BackingField;

	// Token: 0x04001BA4 RID: 7076
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <AdventurerProfile>k__BackingField;

	// Token: 0x04001BA5 RID: 7077
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Item> <Items>k__BackingField;

	// Token: 0x04001BA6 RID: 7078
	private List<ISpecialEffectDataLoad> _specialEffects;

	// Token: 0x04001BA7 RID: 7079
	private List<AttributeModifier> _modifiers;

	// Token: 0x04001BA8 RID: 7080
	[CompilerGenerated]
	private static Func<AttributeModifier, AttributeModifier> <>f__am$cache0;

	// Token: 0x04001BA9 RID: 7081
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache1;

	// Token: 0x04001BAA RID: 7082
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache2;

	// Token: 0x02000CD8 RID: 3288
	[CompilerGenerated]
	private sealed class <InitializeAdventurerBattleUnit>c__AnonStorey2
	{
		// Token: 0x060054E3 RID: 21731 RVA: 0x000CCD9E File Offset: 0x000CB19E
		public <InitializeAdventurerBattleUnit>c__AnonStorey2()
		{
		}

		// Token: 0x060054E4 RID: 21732 RVA: 0x000CCDA6 File Offset: 0x000CB1A6
		internal AdventureUnitSkill <>m__0(Skill sk)
		{
			return sk.InitializeBattleUnitSkill(this.unit);
		}

		// Token: 0x040042B0 RID: 17072
		internal AdventurerBattleUnit unit;
	}

	// Token: 0x02000CD9 RID: 3289
	[CompilerGenerated]
	private sealed class <SelfEventCallback>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054E5 RID: 21733 RVA: 0x000CCDB4 File Offset: 0x000CB1B4
		[DebuggerHidden]
		public <SelfEventCallback>c__Iterator0()
		{
		}

		// Token: 0x060054E6 RID: 21734 RVA: 0x000CCDBC File Offset: 0x000CB1BC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = this._receivesEventCallBacks.GetEnumerator();
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
					Block_4:
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
					enumerator2 = receivesEventCallBack(battleUnit, arg1, arg2).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
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

		// Token: 0x17001202 RID: 4610
		// (get) Token: 0x060054E7 RID: 21735 RVA: 0x000CCF28 File Offset: 0x000CB328
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001203 RID: 4611
		// (get) Token: 0x060054E8 RID: 21736 RVA: 0x000CCF30 File Offset: 0x000CB330
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054E9 RID: 21737 RVA: 0x000CCF38 File Offset: 0x000CB338
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

		// Token: 0x060054EA RID: 21738 RVA: 0x000CCFCC File Offset: 0x000CB3CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054EB RID: 21739 RVA: 0x000CCFD3 File Offset: 0x000CB3D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054EC RID: 21740 RVA: 0x000CCFDC File Offset: 0x000CB3DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerBattleUnit.<SelfEventCallback>c__Iterator0 <SelfEventCallback>c__Iterator = new AdventurerBattleUnit.<SelfEventCallback>c__Iterator0();
			<SelfEventCallback>c__Iterator.$this = this;
			<SelfEventCallback>c__Iterator.battleUnit = battleUnit;
			<SelfEventCallback>c__Iterator.arg1 = arg1;
			<SelfEventCallback>c__Iterator.arg2 = arg2;
			return <SelfEventCallback>c__Iterator;
		}

		// Token: 0x040042B1 RID: 17073
		internal List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>.Enumerator $locvar0;

		// Token: 0x040042B2 RID: 17074
		internal Func<IBattleUnit, AdventureEventType, object, IEnumerable> <receivesEventCallBack>__1;

		// Token: 0x040042B3 RID: 17075
		internal IBattleUnit battleUnit;

		// Token: 0x040042B4 RID: 17076
		internal AdventureEventType arg1;

		// Token: 0x040042B5 RID: 17077
		internal object arg2;

		// Token: 0x040042B6 RID: 17078
		internal IEnumerator $locvar1;

		// Token: 0x040042B7 RID: 17079
		internal object <_>__2;

		// Token: 0x040042B8 RID: 17080
		internal IDisposable $locvar2;

		// Token: 0x040042B9 RID: 17081
		internal AdventurerBattleUnit $this;

		// Token: 0x040042BA RID: 17082
		internal object $current;

		// Token: 0x040042BB RID: 17083
		internal bool $disposing;

		// Token: 0x040042BC RID: 17084
		internal int $PC;
	}

	// Token: 0x02000CDA RID: 3290
	[CompilerGenerated]
	private sealed class <LeavesEncounter>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060054ED RID: 21741 RVA: 0x000CD034 File Offset: 0x000CB434
		[DebuggerHidden]
		public <LeavesEncounter>c__Iterator1()
		{
		}

		// Token: 0x060054EE RID: 21742 RVA: 0x000CD03C File Offset: 0x000CB43C
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

		// Token: 0x17001204 RID: 4612
		// (get) Token: 0x060054EF RID: 21743 RVA: 0x000CD066 File Offset: 0x000CB466
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001205 RID: 4613
		// (get) Token: 0x060054F0 RID: 21744 RVA: 0x000CD06E File Offset: 0x000CB46E
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060054F1 RID: 21745 RVA: 0x000CD076 File Offset: 0x000CB476
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060054F2 RID: 21746 RVA: 0x000CD078 File Offset: 0x000CB478
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060054F3 RID: 21747 RVA: 0x000CD07F File Offset: 0x000CB47F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060054F4 RID: 21748 RVA: 0x000CD088 File Offset: 0x000CB488
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventurerBattleUnit.<LeavesEncounter>c__Iterator1 <LeavesEncounter>c__Iterator = new AdventurerBattleUnit.<LeavesEncounter>c__Iterator1();
			<LeavesEncounter>c__Iterator.$this = this;
			return <LeavesEncounter>c__Iterator;
		}

		// Token: 0x040042BD RID: 17085
		internal AdventurerBattleUnit $this;

		// Token: 0x040042BE RID: 17086
		internal object $current;

		// Token: 0x040042BF RID: 17087
		internal bool $disposing;

		// Token: 0x040042C0 RID: 17088
		internal int $PC;
	}
}
