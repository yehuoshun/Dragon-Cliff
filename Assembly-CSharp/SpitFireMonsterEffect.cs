using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200076F RID: 1903
public class SpitFireMonsterEffect : BattleEffectBase
{
	// Token: 0x060037C0 RID: 14272 RVA: 0x0016FBE8 File Offset: 0x0016DFE8
	public SpitFireMonsterEffect(string effectSourceIdentityCode, float? maxNumberOfLastingSeconds, double damageRate, double fireseedRate, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._maxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this._damageRate = damageRate;
		this._fireseedRate = fireseedRate;
		base.Description = this._battleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = effectSource;
	}

	// Token: 0x060037C1 RID: 14273 RVA: 0x0016FC50 File Offset: 0x0016E050
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		SpitFireProtectionEnhancementData protection = this.EffectSource.SourceUnit.SpecialEffects.OfType<SpitFireProtectionEnhancementData>().FirstOrDefault<SpitFireProtectionEnhancementData>();
		SpitFireDispelData dispel = this.EffectSource.SourceUnit.SpecialEffects.OfType<SpitFireDispelData>().FirstOrDefault<SpitFireDispelData>();
		if (protection == null)
		{
			List<IBattleUnit> enemies = listener.GetLiveEnemyTargets(true, true);
			if (enemies.Any<IBattleUnit>())
			{
				IBattleUnit selectedTarget = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selectedTarget, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(listener, selectedTarget, OutputType.Physical, this._damageRate)
						}, selectedTarget, listener, true, false)
					})
				}, listener);
				IEnumerator enumerator = this.Triggered(listener).GetEnumerator();
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
				IEnumerator enumerator2 = releaseableDamage.Release().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				if (selectedTarget.IsAliveInBattle())
				{
					double damageValue = listener.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * this._fireseedRate;
					IEnumerator enumerator3 = FireSeedEffect.AddFireSeed(selectedTarget, damageValue, listener).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _3 = enumerator3.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
		}
		if (dispel != null)
		{
			List<IBattleUnit> targets = listener.GetAllLiveFriendlyTargetsIncSelf(true);
			if (targets.Any<IBattleUnit>())
			{
				IBattleUnit target = targets[UnityEngine.Random.Range(0, targets.Count)];
				IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelNegativeEffects(target, new int?(dispel.NumberOfDispels)).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _4 = enumerator4.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060037C2 RID: 14274 RVA: 0x0016FC7C File Offset: 0x0016E07C
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		SpitFireProtectionEnhancementData spitFireProtectionEnhancementData = this.EffectSource.SourceUnit.SpecialEffects.OfType<SpitFireProtectionEnhancementData>().FirstOrDefault<SpitFireProtectionEnhancementData>();
		if (spitFireProtectionEnhancementData != null)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DamageReduction,
					ModificationType = ModificationType.Addition,
					Value = spitFireProtectionEnhancementData.DamageReductionRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Strength,
					ModificationType = ModificationType.Multiplication,
					Value = spitFireProtectionEnhancementData.StrengthBoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x17000A5C RID: 2652
	// (get) Token: 0x060037C3 RID: 14275 RVA: 0x0016FD2D File Offset: 0x0016E12D
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x060037C4 RID: 14276 RVA: 0x0016FD35 File Offset: 0x0016E135
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A5D RID: 2653
	// (get) Token: 0x060037C5 RID: 14277 RVA: 0x0016FD3C File Offset: 0x0016E13C
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A5E RID: 2654
	// (get) Token: 0x060037C6 RID: 14278 RVA: 0x0016FD44 File Offset: 0x0016E144
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A5F RID: 2655
	// (get) Token: 0x060037C7 RID: 14279 RVA: 0x0016FD4C File Offset: 0x0016E14C
	// (set) Token: 0x060037C8 RID: 14280 RVA: 0x0016FD54 File Offset: 0x0016E154
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

	// Token: 0x17000A60 RID: 2656
	// (get) Token: 0x060037C9 RID: 14281 RVA: 0x0016FD5D File Offset: 0x0016E15D
	// (set) Token: 0x060037CA RID: 14282 RVA: 0x0016FD65 File Offset: 0x0016E165
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

	// Token: 0x17000A61 RID: 2657
	// (get) Token: 0x060037CB RID: 14283 RVA: 0x0016FD6E File Offset: 0x0016E16E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A62 RID: 2658
	// (get) Token: 0x060037CC RID: 14284 RVA: 0x0016FD76 File Offset: 0x0016E176
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A63 RID: 2659
	// (get) Token: 0x060037CD RID: 14285 RVA: 0x0016FD7E File Offset: 0x0016E17E
	// (set) Token: 0x060037CE RID: 14286 RVA: 0x0016FD86 File Offset: 0x0016E186
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x17000A64 RID: 2660
	// (get) Token: 0x060037CF RID: 14287 RVA: 0x0016FD8F File Offset: 0x0016E18F
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A65 RID: 2661
	// (get) Token: 0x060037D0 RID: 14288 RVA: 0x0016FD97 File Offset: 0x0016E197
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B28 RID: 11048
	private string _effectSourceIdentityCode;

	// Token: 0x04002B29 RID: 11049
	private BattleEffectType _battleEffectType = BattleEffectType.FireSpiritEffect;

	// Token: 0x04002B2A RID: 11050
	private int? _numberOfLastingTurns;

	// Token: 0x04002B2B RID: 11051
	private bool _isThroughEffect;

	// Token: 0x04002B2C RID: 11052
	private bool _canBeImmuned;

	// Token: 0x04002B2D RID: 11053
	private bool _canBeDispersed;

	// Token: 0x04002B2E RID: 11054
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x04002B2F RID: 11055
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B30 RID: 11056
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B31 RID: 11057
	private double _damageRate;

	// Token: 0x04002B32 RID: 11058
	private double _fireseedRate;

	// Token: 0x04002B33 RID: 11059
	private IBattleEffectSource _effectSource;

	// Token: 0x02000ED3 RID: 3795
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FA7 RID: 24487 RVA: 0x0016FD9F File Offset: 0x0016E19F
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FA8 RID: 24488 RVA: 0x0016FDA8 File Offset: 0x0016E1A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				protection = this.EffectSource.SourceUnit.SpecialEffects.OfType<SpitFireProtectionEnhancementData>().FirstOrDefault<SpitFireProtectionEnhancementData>();
				dispel = this.EffectSource.SourceUnit.SpecialEffects.OfType<SpitFireDispelData>().FirstOrDefault<SpitFireDispelData>();
				if (protection != null)
				{
					goto IL_361;
				}
				enemies = listener.GetLiveEnemyTargets(true, true);
				if (!enemies.Any<IBattleUnit>())
				{
					goto IL_361;
				}
				selectedTarget = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selectedTarget, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(listener, selectedTarget, OutputType.Physical, this._damageRate)
						}, selectedTarget, listener, true, false)
					})
				}, listener);
				enumerator = this.Triggered(listener).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_201;
			case 3u:
				goto IL_2DD;
			case 4u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_4 = enumerator4.Current;
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
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				goto IL_45D;
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
			enumerator2 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_201:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (!selectedTarget.IsAliveInBattle())
			{
				goto IL_361;
			}
			damageValue = listener.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * this._fireseedRate;
			enumerator3 = FireSeedEffect.AddFireSeed(selectedTarget, damageValue, listener).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2DD:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_361:
			if (dispel != null)
			{
				targets = listener.GetAllLiveFriendlyTargetsIncSelf(true);
				if (targets.Any<IBattleUnit>())
				{
					target = targets[UnityEngine.Random.Range(0, targets.Count)];
					enumerator4 = UnitStyleConfigurationBase.DispelNegativeEffects(target, new int?(dispel.NumberOfDispels)).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			IL_45D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001400 RID: 5120
		// (get) Token: 0x06005FA9 RID: 24489 RVA: 0x00170250 File Offset: 0x0016E650
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001401 RID: 5121
		// (get) Token: 0x06005FAA RID: 24490 RVA: 0x00170258 File Offset: 0x0016E658
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FAB RID: 24491 RVA: 0x00170260 File Offset: 0x0016E660
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005FAC RID: 24492 RVA: 0x0017038C File Offset: 0x0016E78C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FAD RID: 24493 RVA: 0x00170393 File Offset: 0x0016E793
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FAE RID: 24494 RVA: 0x0017039C File Offset: 0x0016E79C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpitFireMonsterEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new SpitFireMonsterEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.listener = listener;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400545F RID: 21599
		internal SpitFireProtectionEnhancementData <protection>__0;

		// Token: 0x04005460 RID: 21600
		internal SpitFireDispelData <dispel>__0;

		// Token: 0x04005461 RID: 21601
		internal IBattleUnit listener;

		// Token: 0x04005462 RID: 21602
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04005463 RID: 21603
		internal IBattleUnit <selectedTarget>__2;

		// Token: 0x04005464 RID: 21604
		internal ReleaseableDamage <releaseableDamage>__2;

		// Token: 0x04005465 RID: 21605
		internal IEnumerator $locvar0;

		// Token: 0x04005466 RID: 21606
		internal object <_>__3;

		// Token: 0x04005467 RID: 21607
		internal IDisposable $locvar1;

		// Token: 0x04005468 RID: 21608
		internal IEnumerator $locvar2;

		// Token: 0x04005469 RID: 21609
		internal object <_>__4;

		// Token: 0x0400546A RID: 21610
		internal IDisposable $locvar3;

		// Token: 0x0400546B RID: 21611
		internal double <damageValue>__5;

		// Token: 0x0400546C RID: 21612
		internal IEnumerator $locvar4;

		// Token: 0x0400546D RID: 21613
		internal object <_>__6;

		// Token: 0x0400546E RID: 21614
		internal IDisposable $locvar5;

		// Token: 0x0400546F RID: 21615
		internal List<IBattleUnit> <targets>__7;

		// Token: 0x04005470 RID: 21616
		internal IBattleUnit <target>__8;

		// Token: 0x04005471 RID: 21617
		internal IEnumerator $locvar6;

		// Token: 0x04005472 RID: 21618
		internal object <_>__9;

		// Token: 0x04005473 RID: 21619
		internal IDisposable $locvar7;

		// Token: 0x04005474 RID: 21620
		internal SpitFireMonsterEffect $this;

		// Token: 0x04005475 RID: 21621
		internal object $current;

		// Token: 0x04005476 RID: 21622
		internal bool $disposing;

		// Token: 0x04005477 RID: 21623
		internal int $PC;
	}
}
