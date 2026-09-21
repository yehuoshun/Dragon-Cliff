using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000461 RID: 1121
public class PetBattleUnit : IBattleUnit, IBattleEffectSource
{
	// Token: 0x06001FC2 RID: 8130 RVA: 0x000DEBAD File Offset: 0x000DCFAD
	public PetBattleUnit()
	{
	}

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x000DEBC0 File Offset: 0x000DCFC0
	// (set) Token: 0x06001FC4 RID: 8132 RVA: 0x000DEBC8 File Offset: 0x000DCFC8
	public IBattleUnit OwnerUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<OwnerUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OwnerUnit>k__BackingField = value;
		}
	}

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x06001FC5 RID: 8133 RVA: 0x000DEBD1 File Offset: 0x000DCFD1
	public IEncounter CurrentEncounter
	{
		get
		{
			return this.CurrentAdventure.CurrentEncounter;
		}
	}

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x000DEBDE File Offset: 0x000DCFDE
	// (set) Token: 0x06001FC7 RID: 8135 RVA: 0x000DEBE6 File Offset: 0x000DCFE6
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

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x000DEBEF File Offset: 0x000DCFEF
	// (set) Token: 0x06001FC9 RID: 8137 RVA: 0x000DEBF7 File Offset: 0x000DCFF7
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

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x06001FCA RID: 8138 RVA: 0x000DEC00 File Offset: 0x000DD000
	// (set) Token: 0x06001FCB RID: 8139 RVA: 0x000DEC08 File Offset: 0x000DD008
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

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x06001FCC RID: 8140 RVA: 0x000DEC11 File Offset: 0x000DD011
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

	// Token: 0x06001FCD RID: 8141 RVA: 0x000DEC34 File Offset: 0x000DD034
	public static PetBattleUnit Create(List<AttributeModifier> modifiers, IBattleUnit owner, List<AdventureUnitSkill> skills, UnitClass unitclass, List<ISpecialEffectDataLoad> specialEffects)
	{
		PetBattleUnit petBattleUnit = new PetBattleUnit
		{
			BattleEffects = new List<BattleEffectBase>(),
			_modifiers = modifiers,
			OwnerUnit = owner,
			_skills = skills,
			Status = BattleUnitStatus.Active,
			_id = Guid.NewGuid().ToString(),
			_unitClass = unitclass,
			_specialEffects = specialEffects,
			GearedAttributeValues = new Dictionary<AttributeType, double>(),
			NakedAttributeValues = new Dictionary<AttributeType, double>()
		};
		List<AttributeType> list = (from a in ItemExtensions.AllAttributeTypes
		where a != AttributeType.None && a != AttributeType.Allresistances
		select a).ToList<AttributeType>();
		foreach (AttributeType attributeType in list)
		{
			petBattleUnit.GearedAttributeValues.Add(attributeType, petBattleUnit._modifiers.GetAttributeValue(attributeType, AttributeRetrievalLevel.Gear));
		}
		foreach (AttributeType attributeType2 in list)
		{
			petBattleUnit.NakedAttributeValues.Add(attributeType2, petBattleUnit._modifiers.GetAttributeValue(attributeType2, AttributeRetrievalLevel.Naked));
		}
		petBattleUnit.HealthPoints = petBattleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
		return petBattleUnit;
	}

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x06001FCE RID: 8142 RVA: 0x000DEDA8 File Offset: 0x000DD1A8
	public double Level
	{
		get
		{
			return this.OwnerUnit.Level;
		}
	}

	// Token: 0x06001FCF RID: 8143 RVA: 0x000DEDB8 File Offset: 0x000DD1B8
	public IEnumerable LeavesEncounter()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
		yield break;
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x000DEDDC File Offset: 0x000DD1DC
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

	// Token: 0x06001FD1 RID: 8145 RVA: 0x000DEE14 File Offset: 0x000DD214
	public List<AttributeModifier> GetModifiers()
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		list.AddRange(this.Items.SelectMany((Item i) => i.GetAttributeModifiers()));
		list.AddRange(this._modifiers);
		list.AddRange(this.BattleEffects.SelectMany((BattleEffectBase be) => be.GetAdditionalModifiers(this, this.CurrentEncounter)));
		return list;
	}

	// Token: 0x06001FD2 RID: 8146 RVA: 0x000DEE7F File Offset: 0x000DD27F
	public OutputType GetOutputType()
	{
		return this.OwnerUnit.GetOutputType();
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x000DEE8C File Offset: 0x000DD28C
	public void RegisterEventCallbackFromUiLayer(Func<IBattleUnit, AdventureEventType, object, IEnumerable> callback)
	{
		this._receivesEventCallBacks.Add(callback);
	}

	// Token: 0x06001FD4 RID: 8148 RVA: 0x000DEE9A File Offset: 0x000DD29A
	public void RemoveAllEventCallbackFromUiLayer()
	{
		this._receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();
	}

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x000DEEA8 File Offset: 0x000DD2A8
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

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x06001FD6 RID: 8150 RVA: 0x000DEF49 File Offset: 0x000DD349
	public Adventure CurrentAdventure
	{
		get
		{
			return this.OwnerUnit.CurrentAdventure;
		}
	}

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06001FD7 RID: 8151 RVA: 0x000DEF56 File Offset: 0x000DD356
	public bool IsPlayer
	{
		get
		{
			return this.OwnerUnit.IsPlayer;
		}
	}

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x06001FD8 RID: 8152 RVA: 0x000DEF63 File Offset: 0x000DD363
	public QualityGrade Grade
	{
		get
		{
			return QualityGrade.Normal;
		}
	}

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x06001FD9 RID: 8153 RVA: 0x000DEF66 File Offset: 0x000DD366
	public List<Item> Items
	{
		get
		{
			return new List<Item>();
		}
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x000DEF6D File Offset: 0x000DD36D
	public string GetId()
	{
		return this._id;
	}

	// Token: 0x06001FDB RID: 8155 RVA: 0x000DEF75 File Offset: 0x000DD375
	public UnitClass GetUnitType()
	{
		return this._unitClass;
	}

	// Token: 0x06001FDC RID: 8156 RVA: 0x000DEF7D File Offset: 0x000DD37D
	public UnitClassStyle GetUnitClassStyle()
	{
		return this.GetUnitType().GetConfiguration().CorrespondingClassStyle;
	}

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x06001FDD RID: 8157 RVA: 0x000DEF8F File Offset: 0x000DD38F
	// (set) Token: 0x06001FDE RID: 8158 RVA: 0x000DEF97 File Offset: 0x000DD397
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

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x06001FDF RID: 8159 RVA: 0x000DEFA0 File Offset: 0x000DD3A0
	// (set) Token: 0x06001FE0 RID: 8160 RVA: 0x000DEFA8 File Offset: 0x000DD3A8
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

	// Token: 0x06001FE1 RID: 8161 RVA: 0x000DEFB1 File Offset: 0x000DD3B1
	public bool IsBoss()
	{
		return false;
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x06001FE2 RID: 8162 RVA: 0x000DEFB4 File Offset: 0x000DD3B4
	public List<AdventureUnitSkill> Skills
	{
		get
		{
			return this._skills;
		}
	}

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x06001FE3 RID: 8163 RVA: 0x000DEFBC File Offset: 0x000DD3BC
	public IBattleUnit SourceUnit
	{
		get
		{
			return this;
		}
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x000DEFBF File Offset: 0x000DD3BF
	[CompilerGenerated]
	private static bool <Create>m__0(AttributeType a)
	{
		return a != AttributeType.None && a != AttributeType.Allresistances;
	}

	// Token: 0x06001FE5 RID: 8165 RVA: 0x000DEFD2 File Offset: 0x000DD3D2
	[CompilerGenerated]
	private static IEnumerable<AttributeModifier> <GetModifiers>m__1(Item i)
	{
		return i.GetAttributeModifiers();
	}

	// Token: 0x06001FE6 RID: 8166 RVA: 0x000DEFDA File Offset: 0x000DD3DA
	[CompilerGenerated]
	private IEnumerable<AttributeModifier> <GetModifiers>m__2(BattleEffectBase be)
	{
		return be.GetAdditionalModifiers(this, this.CurrentEncounter);
	}

	// Token: 0x04001C74 RID: 7284
	private List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>> _receivesEventCallBacks = new List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>();

	// Token: 0x04001C75 RID: 7285
	private List<AttributeModifier> _modifiers;

	// Token: 0x04001C76 RID: 7286
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <OwnerUnit>k__BackingField;

	// Token: 0x04001C77 RID: 7287
	public List<AdventureUnitSkill> _skills;

	// Token: 0x04001C78 RID: 7288
	private string _id;

	// Token: 0x04001C79 RID: 7289
	private UnitClass _unitClass;

	// Token: 0x04001C7A RID: 7290
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <HealthPoints>k__BackingField;

	// Token: 0x04001C7B RID: 7291
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<BattleEffectBase> <BattleEffects>k__BackingField;

	// Token: 0x04001C7C RID: 7292
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleUnitStatus <Status>k__BackingField;

	// Token: 0x04001C7D RID: 7293
	private List<ISpecialEffectDataLoad> _specialEffects;

	// Token: 0x04001C7E RID: 7294
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <NakedAttributeValues>k__BackingField;

	// Token: 0x04001C7F RID: 7295
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<AttributeType, double> <GearedAttributeValues>k__BackingField;

	// Token: 0x04001C80 RID: 7296
	[CompilerGenerated]
	private static Func<AttributeType, bool> <>f__am$cache0;

	// Token: 0x04001C81 RID: 7297
	[CompilerGenerated]
	private static Func<Item, IEnumerable<AttributeModifier>> <>f__am$cache1;

	// Token: 0x02000D1A RID: 3354
	[CompilerGenerated]
	private sealed class <LeavesEncounter>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005600 RID: 22016 RVA: 0x000DEFE9 File Offset: 0x000DD3E9
		[DebuggerHidden]
		public <LeavesEncounter>c__Iterator0()
		{
		}

		// Token: 0x06005601 RID: 22017 RVA: 0x000DEFF1 File Offset: 0x000DD3F1
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

		// Token: 0x1700122A RID: 4650
		// (get) Token: 0x06005602 RID: 22018 RVA: 0x000DF01B File Offset: 0x000DD41B
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700122B RID: 4651
		// (get) Token: 0x06005603 RID: 22019 RVA: 0x000DF023 File Offset: 0x000DD423
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005604 RID: 22020 RVA: 0x000DF02B File Offset: 0x000DD42B
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005605 RID: 22021 RVA: 0x000DF02D File Offset: 0x000DD42D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005606 RID: 22022 RVA: 0x000DF034 File Offset: 0x000DD434
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005607 RID: 22023 RVA: 0x000DF03C File Offset: 0x000DD43C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PetBattleUnit.<LeavesEncounter>c__Iterator0 <LeavesEncounter>c__Iterator = new PetBattleUnit.<LeavesEncounter>c__Iterator0();
			<LeavesEncounter>c__Iterator.$this = this;
			return <LeavesEncounter>c__Iterator;
		}

		// Token: 0x04004483 RID: 17539
		internal PetBattleUnit $this;

		// Token: 0x04004484 RID: 17540
		internal object $current;

		// Token: 0x04004485 RID: 17541
		internal bool $disposing;

		// Token: 0x04004486 RID: 17542
		internal int $PC;
	}

	// Token: 0x02000D1B RID: 3355
	[CompilerGenerated]
	private sealed class <SelfEventCallback>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005608 RID: 22024 RVA: 0x000DF070 File Offset: 0x000DD470
		[DebuggerHidden]
		public <SelfEventCallback>c__Iterator1()
		{
		}

		// Token: 0x06005609 RID: 22025 RVA: 0x000DF078 File Offset: 0x000DD478
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

		// Token: 0x1700122C RID: 4652
		// (get) Token: 0x0600560A RID: 22026 RVA: 0x000DF1E4 File Offset: 0x000DD5E4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700122D RID: 4653
		// (get) Token: 0x0600560B RID: 22027 RVA: 0x000DF1EC File Offset: 0x000DD5EC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600560C RID: 22028 RVA: 0x000DF1F4 File Offset: 0x000DD5F4
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

		// Token: 0x0600560D RID: 22029 RVA: 0x000DF288 File Offset: 0x000DD688
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600560E RID: 22030 RVA: 0x000DF28F File Offset: 0x000DD68F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600560F RID: 22031 RVA: 0x000DF298 File Offset: 0x000DD698
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PetBattleUnit.<SelfEventCallback>c__Iterator1 <SelfEventCallback>c__Iterator = new PetBattleUnit.<SelfEventCallback>c__Iterator1();
			<SelfEventCallback>c__Iterator.$this = this;
			<SelfEventCallback>c__Iterator.battleUnit = battleUnit;
			<SelfEventCallback>c__Iterator.arg1 = arg1;
			<SelfEventCallback>c__Iterator.arg2 = arg2;
			return <SelfEventCallback>c__Iterator;
		}

		// Token: 0x04004487 RID: 17543
		internal List<Func<IBattleUnit, AdventureEventType, object, IEnumerable>>.Enumerator $locvar0;

		// Token: 0x04004488 RID: 17544
		internal Func<IBattleUnit, AdventureEventType, object, IEnumerable> <receivesEventCallBack>__1;

		// Token: 0x04004489 RID: 17545
		internal IBattleUnit battleUnit;

		// Token: 0x0400448A RID: 17546
		internal AdventureEventType arg1;

		// Token: 0x0400448B RID: 17547
		internal object arg2;

		// Token: 0x0400448C RID: 17548
		internal IEnumerator $locvar1;

		// Token: 0x0400448D RID: 17549
		internal object <_>__2;

		// Token: 0x0400448E RID: 17550
		internal IDisposable $locvar2;

		// Token: 0x0400448F RID: 17551
		internal PetBattleUnit $this;

		// Token: 0x04004490 RID: 17552
		internal object $current;

		// Token: 0x04004491 RID: 17553
		internal bool $disposing;

		// Token: 0x04004492 RID: 17554
		internal int $PC;
	}
}
