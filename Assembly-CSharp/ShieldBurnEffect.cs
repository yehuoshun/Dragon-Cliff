using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200074A RID: 1866
public class ShieldBurnEffect : BattleEffectBase, IDamageInstantlyReleaseable, ISpreadableDamageOverTime
{
	// Token: 0x06003570 RID: 13680 RVA: 0x00165B60 File Offset: 0x00163F60
	public ShieldBurnEffect(float maxNumberOfSeconds, double penetrationRate, List<DamageHitDefinition> hits, IBattleEffectSource effectSource, string sourceIdentityCode, IBattleUnit effectCarrier)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._maxNumberOfLastingSeconds = new float?(maxNumberOfSeconds);
		this._hits = hits;
		this._effectSource = effectSource;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.ShieldBurn.GetDescription();
		this._penetrationRate = -penetrationRate;
		this._effectCarrier = effectCarrier;
		this._numberOfLastingTurns = null;
		this.CanBeDispersed = true;
	}

	// Token: 0x06003571 RID: 13681 RVA: 0x00165BD4 File Offset: 0x00163FD4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170008F3 RID: 2291
	// (get) Token: 0x06003572 RID: 13682 RVA: 0x00165BDB File Offset: 0x00163FDB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008F4 RID: 2292
	// (get) Token: 0x06003573 RID: 13683 RVA: 0x00165BE3 File Offset: 0x00163FE3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.ShieldBurn;
		}
	}

	// Token: 0x170008F5 RID: 2293
	// (get) Token: 0x06003574 RID: 13684 RVA: 0x00165BE7 File Offset: 0x00163FE7
	// (set) Token: 0x06003575 RID: 13685 RVA: 0x00165BEF File Offset: 0x00163FEF
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x170008F6 RID: 2294
	// (get) Token: 0x06003576 RID: 13686 RVA: 0x00165BF8 File Offset: 0x00163FF8
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003577 RID: 13687 RVA: 0x00165C00 File Offset: 0x00164000
	public override IEnumerable PosWearsOffProcess_ActiveUnit(IBattleUnit wearer, EffectWearsOffType wearsOffType)
	{
		if (wearsOffType == EffectWearsOffType.Expiration)
		{
			IEnumerator enumerator = wearer.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(this.EffectSource, base.GetType().FullName, new int?(2), null, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.PhysicalResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.FireResistanceResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.PoisonResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.DivineResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.LightningResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.IceResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.ShadowResistance,
					ModificationType = ModificationType.Multiplication,
					Value = this._penetrationRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}), false).GetEnumerator();
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

	// Token: 0x170008F7 RID: 2295
	// (get) Token: 0x06003578 RID: 13688 RVA: 0x00165C31 File Offset: 0x00164031
	// (set) Token: 0x06003579 RID: 13689 RVA: 0x00165C39 File Offset: 0x00164039
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x0600357A RID: 13690 RVA: 0x00165C42 File Offset: 0x00164042
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x170008F8 RID: 2296
	// (get) Token: 0x0600357B RID: 13691 RVA: 0x00165C49 File Offset: 0x00164049
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170008F9 RID: 2297
	// (get) Token: 0x0600357C RID: 13692 RVA: 0x00165C4C File Offset: 0x0016404C
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170008FA RID: 2298
	// (get) Token: 0x0600357D RID: 13693 RVA: 0x00165C4F File Offset: 0x0016404F
	// (set) Token: 0x0600357E RID: 13694 RVA: 0x00165C57 File Offset: 0x00164057
	public sealed override bool CanBeDispersed
	{
		[CompilerGenerated]
		get
		{
			return this.<CanBeDispersed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CanBeDispersed>k__BackingField = value;
		}
	}

	// Token: 0x170008FB RID: 2299
	// (get) Token: 0x0600357F RID: 13695 RVA: 0x00165C60 File Offset: 0x00164060
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(3);
		}
	}

	// Token: 0x170008FC RID: 2300
	// (get) Token: 0x06003580 RID: 13696 RVA: 0x00165C68 File Offset: 0x00164068
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x06003581 RID: 13697 RVA: 0x00165C6C File Offset: 0x0016406C
	public double FilterDamageValue(double value, double maxRate)
	{
		double num = base.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * maxRate;
		if (value < num)
		{
			return value;
		}
		return num;
	}

	// Token: 0x06003582 RID: 13698 RVA: 0x00165C98 File Offset: 0x00164098
	public IEnumerable Spread(IBattleUnit fromUnit, List<IBattleUnit> tounits)
	{
		string code = "spreadedshieldburn";
		if (this._effectSourceIdentityCode != code)
		{
			foreach (IBattleUnit battleUnit in tounits)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new ShieldBurnEffect(3f, this._penetrationRate, this._hits, this.EffectSource, code, battleUnit), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x170008FD RID: 2301
	// (get) Token: 0x06003583 RID: 13699 RVA: 0x00165CC4 File Offset: 0x001640C4
	public OutputType? DamageOutputType
	{
		get
		{
			return null;
		}
	}

	// Token: 0x040029B9 RID: 10681
	private int? _numberOfLastingTurns;

	// Token: 0x040029BA RID: 10682
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x040029BB RID: 10683
	public List<DamageHitDefinition> _hits;

	// Token: 0x040029BC RID: 10684
	private double _penetrationRate;

	// Token: 0x040029BD RID: 10685
	private string _effectSourceIdentityCode;

	// Token: 0x040029BE RID: 10686
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040029BF RID: 10687
	private IBattleEffectSource _effectSource;

	// Token: 0x040029C0 RID: 10688
	public IBattleUnit _effectCarrier;

	// Token: 0x02000EB2 RID: 3762
	[CompilerGenerated]
	private sealed class <PosWearsOffProcess_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EBB RID: 24251 RVA: 0x00165CDA File Offset: 0x001640DA
		[DebuggerHidden]
		public <PosWearsOffProcess_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005EBC RID: 24252 RVA: 0x00165CE4 File Offset: 0x001640E4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (wearsOffType != EffectWearsOffType.Expiration)
				{
					goto IL_2EB;
				}
				enumerator = wearer.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(this.EffectSource, base.GetType().FullName, new int?(2), null, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.PhysicalResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.FireResistanceResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.PoisonResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.DivineResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.LightningResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.IceResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.ShadowResistance,
						ModificationType = ModificationType.Multiplication,
						Value = this._penetrationRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}), false).GetEnumerator();
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
			IL_2EB:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013CA RID: 5066
		// (get) Token: 0x06005EBD RID: 24253 RVA: 0x00165FF8 File Offset: 0x001643F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013CB RID: 5067
		// (get) Token: 0x06005EBE RID: 24254 RVA: 0x00166000 File Offset: 0x00164400
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EBF RID: 24255 RVA: 0x00166008 File Offset: 0x00164408
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

		// Token: 0x06005EC0 RID: 24256 RVA: 0x00166078 File Offset: 0x00164478
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EC1 RID: 24257 RVA: 0x0016607F File Offset: 0x0016447F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EC2 RID: 24258 RVA: 0x00166088 File Offset: 0x00164488
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShieldBurnEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0 <PosWearsOffProcess_ActiveUnit>c__Iterator = new ShieldBurnEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0();
			<PosWearsOffProcess_ActiveUnit>c__Iterator.$this = this;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.wearsOffType = wearsOffType;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.wearer = wearer;
			return <PosWearsOffProcess_ActiveUnit>c__Iterator;
		}

		// Token: 0x040052B0 RID: 21168
		internal EffectWearsOffType wearsOffType;

		// Token: 0x040052B1 RID: 21169
		internal IBattleUnit wearer;

		// Token: 0x040052B2 RID: 21170
		internal IEnumerator $locvar0;

		// Token: 0x040052B3 RID: 21171
		internal object <_>__1;

		// Token: 0x040052B4 RID: 21172
		internal IDisposable $locvar1;

		// Token: 0x040052B5 RID: 21173
		internal ShieldBurnEffect $this;

		// Token: 0x040052B6 RID: 21174
		internal object $current;

		// Token: 0x040052B7 RID: 21175
		internal bool $disposing;

		// Token: 0x040052B8 RID: 21176
		internal int $PC;
	}

	// Token: 0x02000EB3 RID: 3763
	[CompilerGenerated]
	private sealed class <Spread>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EC3 RID: 24259 RVA: 0x001660D4 File Offset: 0x001644D4
		[DebuggerHidden]
		public <Spread>c__Iterator1()
		{
		}

		// Token: 0x06005EC4 RID: 24260 RVA: 0x001660DC File Offset: 0x001644DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				code = "spreadedshieldburn";
				if (!(this._effectSourceIdentityCode != code))
				{
					goto IL_17D;
				}
				enumerator = tounits.GetEnumerator();
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
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new ShieldBurnEffect(3f, this._penetrationRate, this._hits, this.EffectSource, code, battleUnit), false).GetEnumerator();
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
			IL_17D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013CC RID: 5068
		// (get) Token: 0x06005EC5 RID: 24261 RVA: 0x001662A4 File Offset: 0x001646A4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013CD RID: 5069
		// (get) Token: 0x06005EC6 RID: 24262 RVA: 0x001662AC File Offset: 0x001646AC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EC7 RID: 24263 RVA: 0x001662B4 File Offset: 0x001646B4
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

		// Token: 0x06005EC8 RID: 24264 RVA: 0x00166348 File Offset: 0x00164748
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EC9 RID: 24265 RVA: 0x0016634F File Offset: 0x0016474F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005ECA RID: 24266 RVA: 0x00166358 File Offset: 0x00164758
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShieldBurnEffect.<Spread>c__Iterator1 <Spread>c__Iterator = new ShieldBurnEffect.<Spread>c__Iterator1();
			<Spread>c__Iterator.$this = this;
			<Spread>c__Iterator.tounits = tounits;
			return <Spread>c__Iterator;
		}

		// Token: 0x040052B9 RID: 21177
		internal string <code>__0;

		// Token: 0x040052BA RID: 21178
		internal List<IBattleUnit> tounits;

		// Token: 0x040052BB RID: 21179
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040052BC RID: 21180
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x040052BD RID: 21181
		internal IEnumerator $locvar1;

		// Token: 0x040052BE RID: 21182
		internal object <_>__2;

		// Token: 0x040052BF RID: 21183
		internal IDisposable $locvar2;

		// Token: 0x040052C0 RID: 21184
		internal ShieldBurnEffect $this;

		// Token: 0x040052C1 RID: 21185
		internal object $current;

		// Token: 0x040052C2 RID: 21186
		internal bool $disposing;

		// Token: 0x040052C3 RID: 21187
		internal int $PC;
	}
}
