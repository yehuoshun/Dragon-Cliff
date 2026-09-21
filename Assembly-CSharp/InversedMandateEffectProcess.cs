using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008FB RID: 2299
public class InversedMandateEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600401D RID: 16413 RVA: 0x00199CD4 File Offset: 0x001980D4
	public InversedMandateEffectProcess()
	{
	}

	// Token: 0x17000BB6 RID: 2998
	// (get) Token: 0x0600401E RID: 16414 RVA: 0x00199CE4 File Offset: 0x001980E4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BB7 RID: 2999
	// (get) Token: 0x0600401F RID: 16415 RVA: 0x00199CEC File Offset: 0x001980EC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitTurnProgressAlterred
			};
		}
	}

	// Token: 0x06004020 RID: 16416 RVA: 0x00199D10 File Offset: 0x00198110
	public IEnumerable TurnChangeProcess(double turnProgressChangedPercentage, ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier)
	{
		InversedMandateData data = specialEffectData as InversedMandateData;
		if (data != null)
		{
			data.Charged += data.ChargeRate * turnProgressChangedPercentage;
			if (data.Charged >= 1.0)
			{
				data.Charged -= 1.0;
				List<IBattleUnit> playerUnits = triggerUnit.GetLiveEnemyTargets(false, true);
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.TimeFragmentTriggered, playerUnits)).GetEnumerator();
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
				foreach (IBattleUnit playerUnit in playerUnits)
				{
					IEnumerator enumerator3 = LockTimeEffect.AddStunSeconds(playerUnit, data.LastingSeconds, effectCarrier, false).GetEnumerator();
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
					IEnumerator enumerator4 = DamageOverTimeEffect.AddDamageOverSecond(playerUnit, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamageRate, (int)Math.Ceiling((double)data.LastingSeconds), data.DamageType).GetEnumerator();
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
				}
			}
		}
		yield break;
	}

	// Token: 0x06004021 RID: 16417 RVA: 0x00199D4C File Offset: 0x0019814C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			InversedMandateData inversedMandateData = specialEffectData as InversedMandateData;
			if (inversedMandateData != null)
			{
				inversedMandateData.Charged = 0.0;
			}
		}
		if (evtType == AdventureEventType.UnitTurnProgressAlterred && triggerUnit == effectCarrier)
		{
			UnitTurnProgressUpdateResultEvent turnUpdate = evtData as UnitTurnProgressUpdateResultEvent;
			if (turnUpdate != null && turnUpdate.ActualChangePercentage > 0.0)
			{
				double changedPercentage = turnUpdate.ActualChangePercentage;
				IEnumerator enumerator = this.TurnChangeProcess(changedPercentage, specialEffectData, triggerUnit, effectCarrier).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x04002F9A RID: 12186
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.InversedMandate;

	// Token: 0x02000F82 RID: 3970
	[CompilerGenerated]
	private sealed class <TurnChangeProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006474 RID: 25716 RVA: 0x00199D94 File Offset: 0x00198194
		[DebuggerHidden]
		public <TurnChangeProcess>c__Iterator0()
		{
		}

		// Token: 0x06006475 RID: 25717 RVA: 0x00199D9C File Offset: 0x0019819C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as InversedMandateData);
				if (data == null)
				{
					goto IL_34C;
				}
				data.Charged += data.ChargeRate * turnProgressChangedPercentage;
				if (data.Charged < 1.0)
				{
					goto IL_34C;
				}
				data.Charged -= 1.0;
				playerUnits = triggerUnit.GetLiveEnemyTargets(false, true);
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.TimeFragmentTriggered, playerUnits)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				goto IL_173;
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
			enumerator2 = playerUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_173:
				switch (num)
				{
				case 2u:
					Block_13:
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
					enumerator4 = DamageOverTimeEffect.AddDamageOverSecond(playerUnit, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamageRate, (int)Math.Ceiling((double)data.LastingSeconds), data.DamageType).GetEnumerator();
					num = 4294967293u;
					break;
				case 3u:
					break;
				default:
					goto IL_321;
				}
				try
				{
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
				IL_321:
				if (enumerator2.MoveNext())
				{
					playerUnit = enumerator2.Current;
					enumerator3 = LockTimeEffect.AddStunSeconds(playerUnit, data.LastingSeconds, effectCarrier, false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_34C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001509 RID: 5385
		// (get) Token: 0x06006476 RID: 25718 RVA: 0x0019A164 File Offset: 0x00198564
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700150A RID: 5386
		// (get) Token: 0x06006477 RID: 25719 RVA: 0x0019A16C File Offset: 0x0019856C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006478 RID: 25720 RVA: 0x0019A174 File Offset: 0x00198574
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
			case 3u:
				try
				{
					switch (num)
					{
					case 2u:
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
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006479 RID: 25721 RVA: 0x0019A29C File Offset: 0x0019869C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600647A RID: 25722 RVA: 0x0019A2A3 File Offset: 0x001986A3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600647B RID: 25723 RVA: 0x0019A2AC File Offset: 0x001986AC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InversedMandateEffectProcess.<TurnChangeProcess>c__Iterator0 <TurnChangeProcess>c__Iterator = new InversedMandateEffectProcess.<TurnChangeProcess>c__Iterator0();
			<TurnChangeProcess>c__Iterator.specialEffectData = specialEffectData;
			<TurnChangeProcess>c__Iterator.turnProgressChangedPercentage = turnProgressChangedPercentage;
			<TurnChangeProcess>c__Iterator.triggerUnit = triggerUnit;
			<TurnChangeProcess>c__Iterator.effectCarrier = effectCarrier;
			return <TurnChangeProcess>c__Iterator;
		}

		// Token: 0x04005C5B RID: 23643
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C5C RID: 23644
		internal InversedMandateData <data>__0;

		// Token: 0x04005C5D RID: 23645
		internal double turnProgressChangedPercentage;

		// Token: 0x04005C5E RID: 23646
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C5F RID: 23647
		internal List<IBattleUnit> <playerUnits>__1;

		// Token: 0x04005C60 RID: 23648
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C61 RID: 23649
		internal IEnumerator $locvar0;

		// Token: 0x04005C62 RID: 23650
		internal object <_>__2;

		// Token: 0x04005C63 RID: 23651
		internal IDisposable $locvar1;

		// Token: 0x04005C64 RID: 23652
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04005C65 RID: 23653
		internal IBattleUnit <playerUnit>__3;

		// Token: 0x04005C66 RID: 23654
		internal IEnumerator $locvar3;

		// Token: 0x04005C67 RID: 23655
		internal object <_>__4;

		// Token: 0x04005C68 RID: 23656
		internal IDisposable $locvar4;

		// Token: 0x04005C69 RID: 23657
		internal IEnumerator $locvar5;

		// Token: 0x04005C6A RID: 23658
		internal object <_>__5;

		// Token: 0x04005C6B RID: 23659
		internal IDisposable $locvar6;

		// Token: 0x04005C6C RID: 23660
		internal object $current;

		// Token: 0x04005C6D RID: 23661
		internal bool $disposing;

		// Token: 0x04005C6E RID: 23662
		internal int $PC;
	}

	// Token: 0x02000F83 RID: 3971
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600647C RID: 25724 RVA: 0x0019A304 File Offset: 0x00198704
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x0600647D RID: 25725 RVA: 0x0019A30C File Offset: 0x0019870C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
				{
					InversedMandateData inversedMandateData = specialEffectData as InversedMandateData;
					if (inversedMandateData != null)
					{
						inversedMandateData.Charged = 0.0;
					}
				}
				if (evtType != AdventureEventType.UnitTurnProgressAlterred || triggerUnit != effectCarrier)
				{
					goto IL_179;
				}
				turnUpdate = (evtData as UnitTurnProgressUpdateResultEvent);
				if (turnUpdate == null || turnUpdate.ActualChangePercentage <= 0.0)
				{
					goto IL_179;
				}
				changedPercentage = turnUpdate.ActualChangePercentage;
				enumerator = base.TurnChangeProcess(changedPercentage, specialEffectData, triggerUnit, effectCarrier).GetEnumerator();
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
			IL_179:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700150B RID: 5387
		// (get) Token: 0x0600647E RID: 25726 RVA: 0x0019A4AC File Offset: 0x001988AC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700150C RID: 5388
		// (get) Token: 0x0600647F RID: 25727 RVA: 0x0019A4B4 File Offset: 0x001988B4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006480 RID: 25728 RVA: 0x0019A4BC File Offset: 0x001988BC
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

		// Token: 0x06006481 RID: 25729 RVA: 0x0019A52C File Offset: 0x0019892C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006482 RID: 25730 RVA: 0x0019A533 File Offset: 0x00198933
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006483 RID: 25731 RVA: 0x0019A53C File Offset: 0x0019893C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InversedMandateEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new InversedMandateEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005C6F RID: 23663
		internal AdventureEventType evtType;

		// Token: 0x04005C70 RID: 23664
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C71 RID: 23665
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C72 RID: 23666
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C73 RID: 23667
		internal object evtData;

		// Token: 0x04005C74 RID: 23668
		internal UnitTurnProgressUpdateResultEvent <turnUpdate>__1;

		// Token: 0x04005C75 RID: 23669
		internal double <changedPercentage>__2;

		// Token: 0x04005C76 RID: 23670
		internal IEnumerator $locvar0;

		// Token: 0x04005C77 RID: 23671
		internal object <_>__3;

		// Token: 0x04005C78 RID: 23672
		internal IDisposable $locvar1;

		// Token: 0x04005C79 RID: 23673
		internal InversedMandateEffectProcess $this;

		// Token: 0x04005C7A RID: 23674
		internal object $current;

		// Token: 0x04005C7B RID: 23675
		internal bool $disposing;

		// Token: 0x04005C7C RID: 23676
		internal int $PC;
	}
}
