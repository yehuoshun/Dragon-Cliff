using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008E8 RID: 2280
public class FieryTaleEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FC9 RID: 16329 RVA: 0x001954E9 File Offset: 0x001938E9
	public FieryTaleEffectProcess()
	{
	}

	// Token: 0x17000B92 RID: 2962
	// (get) Token: 0x06003FCA RID: 16330 RVA: 0x001954F9 File Offset: 0x001938F9
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B93 RID: 2963
	// (get) Token: 0x06003FCB RID: 16331 RVA: 0x00195504 File Offset: 0x00193904
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.ElementDamageProcessCompleted
			};
		}
	}

	// Token: 0x06003FCC RID: 16332 RVA: 0x00195528 File Offset: 0x00193928
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && specialEffectData is FieryTaleEffectData)
		{
			List<IBattleUnit> enemies = effectCarrier.GetLiveEnemyTargets(false, false);
			FieryTaleEffectData data = specialEffectData as FieryTaleEffectData;
			foreach (IBattleUnit battleUnit in enemies)
			{
				for (int i = 0; i < data.StartFires; i++)
				{
					IEnumerator enumerator2 = FireSeedEffect.AddFireSeed(battleUnit, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
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
		}
		if (evtType == AdventureEventType.ElementDamageProcessCompleted && evtData is BattleDamage)
		{
			BattleDamage bdamage = evtData as BattleDamage;
			foreach (DamageComponent damage in bdamage.Damages)
			{
				if (damage != null && damage.IsDirectDamage && !damage.IsMissed && damage.Dealer == effectCarrier && specialEffectData is FieryTaleEffectData && damage.Target.IsAliveInBattle())
				{
					FieryTaleEffectData data2 = specialEffectData as FieryTaleEffectData;
					for (int j = 0; j < data2.FiresPerHit; j++)
					{
						IEnumerator enumerator4 = FireSeedEffect.AddFireSeed(damage.Target, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
						try
						{
							while (enumerator4.MoveNext())
							{
								object _2 = enumerator4.Current;
								yield return _2;
							}
						}
						finally
						{
							IDisposable disposable2;
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F8B RID: 12171
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.FieryTaleEffect;

	// Token: 0x02000F68 RID: 3944
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063CC RID: 25548 RVA: 0x00195569 File Offset: 0x00193969
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063CD RID: 25549 RVA: 0x00195574 File Offset: 0x00193974
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || !(specialEffectData is FieryTaleEffectData))
				{
					goto IL_1BC;
				}
				enemies = effectCarrier.GetLiveEnemyTargets(false, false);
				data = (specialEffectData as FieryTaleEffectData);
				enumerator = enemies.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_8:
				try
				{
					switch (num)
					{
					case 2u:
						Block_27:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_2 = enumerator4.Current;
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
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						j++;
						goto IL_36D;
					}
					IL_383:
					while (enumerator3.MoveNext())
					{
						damage = enumerator3.Current;
						if (damage != null && damage.IsDirectDamage && !damage.IsMissed && damage.Dealer == effectCarrier && specialEffectData is FieryTaleEffectData && damage.Target.IsAliveInBattle())
						{
							data2 = (specialEffectData as FieryTaleEffectData);
							j = 0;
							goto IL_36D;
						}
					}
					goto IL_3AE;
					IL_36D:
					if (j >= data2.FiresPerHit)
					{
						goto IL_383;
					}
					enumerator4 = FireSeedEffect.AddFireSeed(damage.Target, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
					num = 4294967293u;
					goto Block_27;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_3AE;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_10:
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
					i++;
					break;
				default:
					goto IL_191;
				}
				IL_17B:
				if (i < data.StartFires)
				{
					enumerator2 = FireSeedEffect.AddFireSeed(battleUnit, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, effectCarrier).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
				IL_191:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					i = 0;
					goto IL_17B;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1BC:
			if (evtType == AdventureEventType.ElementDamageProcessCompleted && evtData is BattleDamage)
			{
				bdamage = (evtData as BattleDamage);
				enumerator3 = bdamage.Damages.GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			}
			IL_3AE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014E5 RID: 5349
		// (get) Token: 0x060063CE RID: 25550 RVA: 0x001959A0 File Offset: 0x00193DA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014E6 RID: 5350
		// (get) Token: 0x060063CF RID: 25551 RVA: 0x001959A8 File Offset: 0x00193DA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063D0 RID: 25552 RVA: 0x001959B0 File Offset: 0x00193DB0
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x060063D1 RID: 25553 RVA: 0x00195AA4 File Offset: 0x00193EA4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063D2 RID: 25554 RVA: 0x00195AAB File Offset: 0x00193EAB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063D3 RID: 25555 RVA: 0x00195AB4 File Offset: 0x00193EB4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FieryTaleEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FieryTaleEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B4B RID: 23371
		internal AdventureEventType evtType;

		// Token: 0x04005B4C RID: 23372
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B4D RID: 23373
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B4E RID: 23374
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B4F RID: 23375
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04005B50 RID: 23376
		internal FieryTaleEffectData <data>__1;

		// Token: 0x04005B51 RID: 23377
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005B52 RID: 23378
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005B53 RID: 23379
		internal int <i>__3;

		// Token: 0x04005B54 RID: 23380
		internal IEnumerator $locvar1;

		// Token: 0x04005B55 RID: 23381
		internal object <_>__4;

		// Token: 0x04005B56 RID: 23382
		internal IDisposable $locvar2;

		// Token: 0x04005B57 RID: 23383
		internal object evtData;

		// Token: 0x04005B58 RID: 23384
		internal BattleDamage <bdamage>__5;

		// Token: 0x04005B59 RID: 23385
		internal List<DamageComponent>.Enumerator $locvar3;

		// Token: 0x04005B5A RID: 23386
		internal DamageComponent <damage>__6;

		// Token: 0x04005B5B RID: 23387
		internal FieryTaleEffectData <data>__7;

		// Token: 0x04005B5C RID: 23388
		internal int <i>__8;

		// Token: 0x04005B5D RID: 23389
		internal IEnumerator $locvar4;

		// Token: 0x04005B5E RID: 23390
		internal object <_>__9;

		// Token: 0x04005B5F RID: 23391
		internal IDisposable $locvar5;

		// Token: 0x04005B60 RID: 23392
		internal object $current;

		// Token: 0x04005B61 RID: 23393
		internal bool $disposing;

		// Token: 0x04005B62 RID: 23394
		internal int $PC;
	}
}
