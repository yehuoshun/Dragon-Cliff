using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200092E RID: 2350
[Serializable]
public class StrongGuardEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004106 RID: 16646 RVA: 0x001A692C File Offset: 0x001A4D2C
	public StrongGuardEffectProcess()
	{
	}

	// Token: 0x17000C1B RID: 3099
	// (get) Token: 0x06004107 RID: 16647 RVA: 0x001A6934 File Offset: 0x001A4D34
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.StrongGuard;
		}
	}

	// Token: 0x17000C1C RID: 3100
	// (get) Token: 0x06004108 RID: 16648 RVA: 0x001A6938 File Offset: 0x001A4D38
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.TurnSetupCompleted
			};
		}
	}

	// Token: 0x06004109 RID: 16649 RVA: 0x001A6954 File Offset: 0x001A4D54
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.TurnSetupCompleted && triggerUnit == effectCarrier && specialEffectData is StrongGuardData)
		{
			StrongGuardData data = specialEffectData as StrongGuardData;
			List<IBattleUnit> targets = effectCarrier.GetLiveEnemyTargets(false, false);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new TauntEffect(effectCarrier, battleUnit, effectCarrier, new int?(data.Seconds), true), false).GetEnumerator();
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

	// Token: 0x02000FCB RID: 4043
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006673 RID: 26227 RVA: 0x001A698D File Offset: 0x001A4D8D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006674 RID: 26228 RVA: 0x001A6998 File Offset: 0x001A4D98
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.TurnSetupCompleted || triggerUnit != effectCarrier || !(specialEffectData is StrongGuardData))
				{
					goto IL_19A;
				}
				data = (specialEffectData as StrongGuardData);
				targets = effectCarrier.GetLiveEnemyTargets(false, false);
				enumerator = targets.GetEnumerator();
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
					Block_7:
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
					enumerator2 = battleUnit.ApplySkillEffect(new TauntEffect(effectCarrier, battleUnit, effectCarrier, new int?(data.Seconds), true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_19A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700157D RID: 5501
		// (get) Token: 0x06006675 RID: 26229 RVA: 0x001A6B68 File Offset: 0x001A4F68
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700157E RID: 5502
		// (get) Token: 0x06006676 RID: 26230 RVA: 0x001A6B70 File Offset: 0x001A4F70
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006677 RID: 26231 RVA: 0x001A6B78 File Offset: 0x001A4F78
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

		// Token: 0x06006678 RID: 26232 RVA: 0x001A6C0C File Offset: 0x001A500C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006679 RID: 26233 RVA: 0x001A6C13 File Offset: 0x001A5013
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600667A RID: 26234 RVA: 0x001A6C1C File Offset: 0x001A501C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StrongGuardEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StrongGuardEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F7C RID: 24444
		internal AdventureEventType evtType;

		// Token: 0x04005F7D RID: 24445
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F7E RID: 24446
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F7F RID: 24447
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F80 RID: 24448
		internal StrongGuardData <data>__1;

		// Token: 0x04005F81 RID: 24449
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005F82 RID: 24450
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005F83 RID: 24451
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005F84 RID: 24452
		internal IEnumerator $locvar1;

		// Token: 0x04005F85 RID: 24453
		internal object <_>__3;

		// Token: 0x04005F86 RID: 24454
		internal IDisposable $locvar2;

		// Token: 0x04005F87 RID: 24455
		internal object $current;

		// Token: 0x04005F88 RID: 24456
		internal bool $disposing;

		// Token: 0x04005F89 RID: 24457
		internal int $PC;
	}
}
