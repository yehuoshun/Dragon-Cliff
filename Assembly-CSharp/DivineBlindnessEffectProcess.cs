using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D0 RID: 2256
public class DivineBlindnessEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F62 RID: 16226 RVA: 0x0018FD12 File Offset: 0x0018E112
	public DivineBlindnessEffectProcess()
	{
	}

	// Token: 0x17000B62 RID: 2914
	// (get) Token: 0x06003F63 RID: 16227 RVA: 0x0018FD22 File Offset: 0x0018E122
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B63 RID: 2915
	// (get) Token: 0x06003F64 RID: 16228 RVA: 0x0018FD2C File Offset: 0x0018E12C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x06003F65 RID: 16229 RVA: 0x0018FD48 File Offset: 0x0018E148
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		DivineBlindnessData data = specialEffectData as DivineBlindnessData;
		if (data != null)
		{
			data.ChargeCounter++;
			if (data.ChargeCounter >= data.ChargeCap)
			{
				data.ChargeCounter -= data.ChargeCap;
				BattleEncounter battleEncounter = effectCarrier.CurrentEncounter as BattleEncounter;
				if (battleEncounter != null)
				{
					foreach (IBattleUnit battleEncounterPlayerUnit in (from u in battleEncounter.PlayerUnits
					where u.Status == BattleUnitStatus.Active
					select u).ToList<IBattleUnit>())
					{
						UnitTurnProgressUpdateEvent change = new UnitTurnProgressUpdateEvent
						{
							Dealer = effectCarrier,
							ChangePercentage = -data.PushPercentage,
							CausingSource = effectCarrier
						};
						IEnumerator enumerator2 = battleEncounterPlayerUnit.ChangeTurnCounterProgress(change).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06003F66 RID: 16230 RVA: 0x0018FD74 File Offset: 0x0018E174
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterStarts)
		{
			DivineBlindnessData divineBlindnessData = specialEffectData as DivineBlindnessData;
			if (divineBlindnessData != null)
			{
				divineBlindnessData.ChargeCounter = 0;
			}
		}
		yield break;
	}

	// Token: 0x04002F7B RID: 12155
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DivineBlindnessEffect;

	// Token: 0x02000F4E RID: 3918
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006307 RID: 25351 RVA: 0x0018FD9F File Offset: 0x0018E19F
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006308 RID: 25352 RVA: 0x0018FDA8 File Offset: 0x0018E1A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as DivineBlindnessData);
				if (data == null)
				{
					goto IL_210;
				}
				data.ChargeCounter++;
				if (data.ChargeCounter < data.ChargeCap)
				{
					goto IL_210;
				}
				data.ChargeCounter -= data.ChargeCap;
				battleEncounter = (effectCarrier.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_210;
				}
				enumerator = (from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>().GetEnumerator();
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
					Block_8:
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
					battleEncounterPlayerUnit = enumerator.Current;
					change = new UnitTurnProgressUpdateEvent
					{
						Dealer = effectCarrier,
						ChangePercentage = -data.PushPercentage,
						CausingSource = effectCarrier
					};
					enumerator2 = battleEncounterPlayerUnit.ChangeTurnCounterProgress(change).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_210:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014BB RID: 5307
		// (get) Token: 0x06006309 RID: 25353 RVA: 0x00190004 File Offset: 0x0018E404
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014BC RID: 5308
		// (get) Token: 0x0600630A RID: 25354 RVA: 0x0019000C File Offset: 0x0018E40C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600630B RID: 25355 RVA: 0x00190014 File Offset: 0x0018E414
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

		// Token: 0x0600630C RID: 25356 RVA: 0x001900A8 File Offset: 0x0018E4A8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600630D RID: 25357 RVA: 0x001900AF File Offset: 0x0018E4AF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600630E RID: 25358 RVA: 0x001900B8 File Offset: 0x0018E4B8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DivineBlindnessEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new DivineBlindnessEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x0600630F RID: 25359 RVA: 0x001900F8 File Offset: 0x0018E4F8
		private static bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04005A0D RID: 23053
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A0E RID: 23054
		internal DivineBlindnessData <data>__0;

		// Token: 0x04005A0F RID: 23055
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A10 RID: 23056
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04005A11 RID: 23057
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005A12 RID: 23058
		internal IBattleUnit <battleEncounterPlayerUnit>__2;

		// Token: 0x04005A13 RID: 23059
		internal UnitTurnProgressUpdateEvent <change>__3;

		// Token: 0x04005A14 RID: 23060
		internal IEnumerator $locvar1;

		// Token: 0x04005A15 RID: 23061
		internal object <_>__4;

		// Token: 0x04005A16 RID: 23062
		internal IDisposable $locvar2;

		// Token: 0x04005A17 RID: 23063
		internal object $current;

		// Token: 0x04005A18 RID: 23064
		internal bool $disposing;

		// Token: 0x04005A19 RID: 23065
		internal int $PC;

		// Token: 0x04005A1A RID: 23066
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000F4F RID: 3919
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006310 RID: 25360 RVA: 0x00190103 File Offset: 0x0018E503
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x06006311 RID: 25361 RVA: 0x0019010C File Offset: 0x0018E50C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evtType == AdventureEventType.BattleEncounterStarts)
				{
					DivineBlindnessData divineBlindnessData = specialEffectData as DivineBlindnessData;
					if (divineBlindnessData != null)
					{
						divineBlindnessData.ChargeCounter = 0;
					}
				}
			}
			return false;
		}

		// Token: 0x170014BD RID: 5309
		// (get) Token: 0x06006312 RID: 25362 RVA: 0x00190157 File Offset: 0x0018E557
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014BE RID: 5310
		// (get) Token: 0x06006313 RID: 25363 RVA: 0x0019015F File Offset: 0x0018E55F
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006314 RID: 25364 RVA: 0x00190167 File Offset: 0x0018E567
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006315 RID: 25365 RVA: 0x00190169 File Offset: 0x0018E569
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006316 RID: 25366 RVA: 0x00190170 File Offset: 0x0018E570
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006317 RID: 25367 RVA: 0x00190178 File Offset: 0x0018E578
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DivineBlindnessEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new DivineBlindnessEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005A1B RID: 23067
		internal AdventureEventType evtType;

		// Token: 0x04005A1C RID: 23068
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A1D RID: 23069
		internal object $current;

		// Token: 0x04005A1E RID: 23070
		internal bool $disposing;

		// Token: 0x04005A1F RID: 23071
		internal int $PC;
	}
}
