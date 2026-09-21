using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000740 RID: 1856
public class BlackBloodEffect : BattleEffectBase
{
	// Token: 0x060034BC RID: 13500 RVA: 0x0015F3BB File Offset: 0x0015D7BB
	public BlackBloodEffect()
	{
	}

	// Token: 0x060034BD RID: 13501 RVA: 0x0015F3C4 File Offset: 0x0015D7C4
	public static IEnumerable AddBlackBloodEffect(IBattleUnit target, IBattleEffectSource effectSource, double seconds, double initResistanceRate, double resistanceDecayrate, double initdodgeRate, double dodgeDecayrate)
	{
		BlackBloodEffect existing = target.BattleEffects.OfType<BlackBloodEffect>().FirstOrDefault<BlackBloodEffect>();
		if (existing != null)
		{
			double num = seconds * effectSource.SourceUnit.GetEffectTimeRatio(target);
			float? maxNumberOfLastingSeconds = existing.MaxNumberOfLastingSeconds;
			if (num > ((maxNumberOfLastingSeconds == null) ? null : new double?((double)maxNumberOfLastingSeconds.Value)))
			{
				existing.MaxNumberOfLastingSeconds = new float?((float)((int)num));
			}
			existing.Timer = 0f;
			if (dodgeDecayrate > existing._dodgeDecayRate)
			{
				existing._dodgeDecayRate = dodgeDecayrate;
			}
			if (resistanceDecayrate > existing._resistanceDecayrate)
			{
				existing._resistanceDecayrate = resistanceDecayrate;
			}
			if (initResistanceRate > existing._currentResistanceRate)
			{
				existing._currentResistanceRate = initResistanceRate;
			}
			if (initdodgeRate > existing._currentDodgeRate)
			{
				existing._currentDodgeRate = initdodgeRate;
			}
			existing.TurnEventsCollected = new List<AdventureEventType>();
			double num2 = target.SpecialEffects.OfType<LightningShieldData>().Sum((LightningShieldData r) => r.NegativeResistance);
			if ((double)UnityEngine.Random.value <= num2)
			{
				existing.CanBeDispersed = false;
			}
		}
		else
		{
			BlackBloodEffect effect = new BlackBloodEffect
			{
				CanBeDispersed = true,
				_effectSource = effectSource,
				_effectSourceIdentityCode = "blackblood",
				MaxNumberOfLastingSeconds = new float?((float)((int)seconds)),
				NumberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				_isThroughEffect = false,
				_canBeImmuned = true,
				_maxStackableInstances = new int?(1),
				_battleEffectNatureForWearer = BattleEffectNature.Negative,
				_battleEffectType = BattleEffectType.BlackBlood,
				Description = BattleEffectType.BlackBlood.GetDescription(),
				_currentDodgeRate = initdodgeRate,
				_currentResistanceRate = initResistanceRate,
				_dodgeDecayRate = dodgeDecayrate,
				_resistanceDecayrate = resistanceDecayrate
			};
			IEnumerator enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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

	// Token: 0x060034BE RID: 13502 RVA: 0x0015F414 File Offset: 0x0015D814
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		this._currentDodgeRate += this._dodgeDecayRate;
		this._currentResistanceRate += this._resistanceDecayrate;
		yield break;
	}

	// Token: 0x060034BF RID: 13503 RVA: 0x0015F438 File Offset: 0x0015D838
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.Allresistances,
				ModificationType = ModificationType.Multiplication,
				Value = -this._currentResistanceRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			},
			new AttributeModifier
			{
				AttributeType = AttributeType.DodgeRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = this._currentDodgeRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
	}

	// Token: 0x060034C0 RID: 13504 RVA: 0x0015F4C4 File Offset: 0x0015D8C4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700088F RID: 2191
	// (get) Token: 0x060034C1 RID: 13505 RVA: 0x0015F4CB File Offset: 0x0015D8CB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000890 RID: 2192
	// (get) Token: 0x060034C2 RID: 13506 RVA: 0x0015F4D3 File Offset: 0x0015D8D3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000891 RID: 2193
	// (get) Token: 0x060034C3 RID: 13507 RVA: 0x0015F4DB File Offset: 0x0015D8DB
	// (set) Token: 0x060034C4 RID: 13508 RVA: 0x0015F4E3 File Offset: 0x0015D8E3
	public override float? MaxNumberOfLastingSeconds
	{
		[CompilerGenerated]
		get
		{
			return this.<MaxNumberOfLastingSeconds>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MaxNumberOfLastingSeconds>k__BackingField = value;
		}
	}

	// Token: 0x17000892 RID: 2194
	// (get) Token: 0x060034C5 RID: 13509 RVA: 0x0015F4EC File Offset: 0x0015D8EC
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000893 RID: 2195
	// (get) Token: 0x060034C6 RID: 13510 RVA: 0x0015F4F4 File Offset: 0x0015D8F4
	// (set) Token: 0x060034C7 RID: 13511 RVA: 0x0015F4FC File Offset: 0x0015D8FC
	public override int? NumberOfLastingTurns
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfLastingTurns>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfLastingTurns>k__BackingField = value;
		}
	}

	// Token: 0x17000894 RID: 2196
	// (get) Token: 0x060034C8 RID: 13512 RVA: 0x0015F505 File Offset: 0x0015D905
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000895 RID: 2197
	// (get) Token: 0x060034C9 RID: 13513 RVA: 0x0015F50D File Offset: 0x0015D90D
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000896 RID: 2198
	// (get) Token: 0x060034CA RID: 13514 RVA: 0x0015F515 File Offset: 0x0015D915
	// (set) Token: 0x060034CB RID: 13515 RVA: 0x0015F51D File Offset: 0x0015D91D
	public override bool CanBeDispersed
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

	// Token: 0x17000897 RID: 2199
	// (get) Token: 0x060034CC RID: 13516 RVA: 0x0015F526 File Offset: 0x0015D926
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000898 RID: 2200
	// (get) Token: 0x060034CD RID: 13517 RVA: 0x0015F52E File Offset: 0x0015D92E
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002941 RID: 10561
	private string _effectSourceIdentityCode;

	// Token: 0x04002942 RID: 10562
	private BattleEffectType _battleEffectType;

	// Token: 0x04002943 RID: 10563
	private IBattleEffectSource _effectSource;

	// Token: 0x04002944 RID: 10564
	private bool _isThroughEffect;

	// Token: 0x04002945 RID: 10565
	private bool _canBeImmuned;

	// Token: 0x04002946 RID: 10566
	private int? _maxStackableInstances;

	// Token: 0x04002947 RID: 10567
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002948 RID: 10568
	private double _currentResistanceRate;

	// Token: 0x04002949 RID: 10569
	private double _resistanceDecayrate;

	// Token: 0x0400294A RID: 10570
	private double _currentDodgeRate;

	// Token: 0x0400294B RID: 10571
	private double _dodgeDecayRate;

	// Token: 0x0400294C RID: 10572
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x0400294D RID: 10573
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x0400294E RID: 10574
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000E9A RID: 3738
	[CompilerGenerated]
	private sealed class <AddBlackBloodEffect>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E28 RID: 24104 RVA: 0x0015F536 File Offset: 0x0015D936
		[DebuggerHidden]
		public <AddBlackBloodEffect>c__Iterator0()
		{
		}

		// Token: 0x06005E29 RID: 24105 RVA: 0x0015F540 File Offset: 0x0015D940
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				existing = target.BattleEffects.OfType<BlackBloodEffect>().FirstOrDefault<BlackBloodEffect>();
				if (existing != null)
				{
					double num2 = seconds * effectSource.SourceUnit.GetEffectTimeRatio(target);
					float? maxNumberOfLastingSeconds = existing.MaxNumberOfLastingSeconds;
					if (num2 > ((maxNumberOfLastingSeconds == null) ? null : new double?((double)maxNumberOfLastingSeconds.Value)))
					{
						existing.MaxNumberOfLastingSeconds = new float?((float)((int)num2));
					}
					existing.Timer = 0f;
					if (dodgeDecayrate > existing._dodgeDecayRate)
					{
						existing._dodgeDecayRate = dodgeDecayrate;
					}
					if (resistanceDecayrate > existing._resistanceDecayrate)
					{
						existing._resistanceDecayrate = resistanceDecayrate;
					}
					if (initResistanceRate > existing._currentResistanceRate)
					{
						existing._currentResistanceRate = initResistanceRate;
					}
					if (initdodgeRate > existing._currentDodgeRate)
					{
						existing._currentDodgeRate = initdodgeRate;
					}
					existing.TurnEventsCollected = new List<AdventureEventType>();
					double num3 = target.SpecialEffects.OfType<LightningShieldData>().Sum((LightningShieldData r) => r.NegativeResistance);
					if ((double)UnityEngine.Random.value <= num3)
					{
						existing.CanBeDispersed = false;
					}
					goto IL_351;
				}
				effect = new BlackBloodEffect
				{
					CanBeDispersed = true,
					_effectSource = effectSource,
					_effectSourceIdentityCode = "blackblood",
					MaxNumberOfLastingSeconds = new float?((float)((int)seconds)),
					NumberOfLastingTurns = null,
					TurnEventsCollected = new List<AdventureEventType>(),
					_isThroughEffect = false,
					_canBeImmuned = true,
					_maxStackableInstances = new int?(1),
					_battleEffectNatureForWearer = BattleEffectNature.Negative,
					_battleEffectType = BattleEffectType.BlackBlood,
					Description = BattleEffectType.BlackBlood.GetDescription(),
					_currentDodgeRate = initdodgeRate,
					_currentResistanceRate = initResistanceRate,
					_dodgeDecayRate = dodgeDecayrate,
					_resistanceDecayrate = resistanceDecayrate
				};
				enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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
			IL_351:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013AC RID: 5036
		// (get) Token: 0x06005E2A RID: 24106 RVA: 0x0015F8B8 File Offset: 0x0015DCB8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013AD RID: 5037
		// (get) Token: 0x06005E2B RID: 24107 RVA: 0x0015F8C0 File Offset: 0x0015DCC0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E2C RID: 24108 RVA: 0x0015F8C8 File Offset: 0x0015DCC8
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

		// Token: 0x06005E2D RID: 24109 RVA: 0x0015F938 File Offset: 0x0015DD38
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E2E RID: 24110 RVA: 0x0015F93F File Offset: 0x0015DD3F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E2F RID: 24111 RVA: 0x0015F948 File Offset: 0x0015DD48
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BlackBloodEffect.<AddBlackBloodEffect>c__Iterator0 <AddBlackBloodEffect>c__Iterator = new BlackBloodEffect.<AddBlackBloodEffect>c__Iterator0();
			<AddBlackBloodEffect>c__Iterator.target = target;
			<AddBlackBloodEffect>c__Iterator.seconds = seconds;
			<AddBlackBloodEffect>c__Iterator.effectSource = effectSource;
			<AddBlackBloodEffect>c__Iterator.dodgeDecayrate = dodgeDecayrate;
			<AddBlackBloodEffect>c__Iterator.resistanceDecayrate = resistanceDecayrate;
			<AddBlackBloodEffect>c__Iterator.initResistanceRate = initResistanceRate;
			<AddBlackBloodEffect>c__Iterator.initdodgeRate = initdodgeRate;
			return <AddBlackBloodEffect>c__Iterator;
		}

		// Token: 0x06005E30 RID: 24112 RVA: 0x0015F9C4 File Offset: 0x0015DDC4
		private static double <>m__0(LightningShieldData r)
		{
			return r.NegativeResistance;
		}

		// Token: 0x0400519A RID: 20890
		internal IBattleUnit target;

		// Token: 0x0400519B RID: 20891
		internal BlackBloodEffect <existing>__0;

		// Token: 0x0400519C RID: 20892
		internal double seconds;

		// Token: 0x0400519D RID: 20893
		internal IBattleEffectSource effectSource;

		// Token: 0x0400519E RID: 20894
		internal double dodgeDecayrate;

		// Token: 0x0400519F RID: 20895
		internal double resistanceDecayrate;

		// Token: 0x040051A0 RID: 20896
		internal double initResistanceRate;

		// Token: 0x040051A1 RID: 20897
		internal double initdodgeRate;

		// Token: 0x040051A2 RID: 20898
		internal BlackBloodEffect <effect>__1;

		// Token: 0x040051A3 RID: 20899
		internal IEnumerator $locvar0;

		// Token: 0x040051A4 RID: 20900
		internal object <_>__2;

		// Token: 0x040051A5 RID: 20901
		internal IDisposable $locvar1;

		// Token: 0x040051A6 RID: 20902
		internal object $current;

		// Token: 0x040051A7 RID: 20903
		internal bool $disposing;

		// Token: 0x040051A8 RID: 20904
		internal int $PC;

		// Token: 0x040051A9 RID: 20905
		private static Func<LightningShieldData, double> <>f__am$cache0;
	}

	// Token: 0x02000E9B RID: 3739
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E31 RID: 24113 RVA: 0x0015F9CC File Offset: 0x0015DDCC
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator1()
		{
		}

		// Token: 0x06005E32 RID: 24114 RVA: 0x0015F9D4 File Offset: 0x0015DDD4
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				this._currentDodgeRate += this._dodgeDecayRate;
				this._currentResistanceRate += this._resistanceDecayrate;
			}
			return false;
		}

		// Token: 0x170013AE RID: 5038
		// (get) Token: 0x06005E33 RID: 24115 RVA: 0x0015FA33 File Offset: 0x0015DE33
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013AF RID: 5039
		// (get) Token: 0x06005E34 RID: 24116 RVA: 0x0015FA3B File Offset: 0x0015DE3B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E35 RID: 24117 RVA: 0x0015FA43 File Offset: 0x0015DE43
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005E36 RID: 24118 RVA: 0x0015FA45 File Offset: 0x0015DE45
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E37 RID: 24119 RVA: 0x0015FA4C File Offset: 0x0015DE4C
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E38 RID: 24120 RVA: 0x0015FA54 File Offset: 0x0015DE54
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BlackBloodEffect.<PerSecondLogic_ActiveUnit>c__Iterator1 <PerSecondLogic_ActiveUnit>c__Iterator = new BlackBloodEffect.<PerSecondLogic_ActiveUnit>c__Iterator1();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040051AA RID: 20906
		internal BlackBloodEffect $this;

		// Token: 0x040051AB RID: 20907
		internal object $current;

		// Token: 0x040051AC RID: 20908
		internal bool $disposing;

		// Token: 0x040051AD RID: 20909
		internal int $PC;
	}
}
