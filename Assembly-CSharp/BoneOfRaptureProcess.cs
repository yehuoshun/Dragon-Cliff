using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008B3 RID: 2227
public class BoneOfRaptureProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EDF RID: 16095 RVA: 0x001863FD File Offset: 0x001847FD
	public BoneOfRaptureProcess()
	{
	}

	// Token: 0x17000B28 RID: 2856
	// (get) Token: 0x06003EE0 RID: 16096 RVA: 0x0018640D File Offset: 0x0018480D
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B29 RID: 2857
	// (get) Token: 0x06003EE1 RID: 16097 RVA: 0x00186418 File Offset: 0x00184818
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06003EE2 RID: 16098 RVA: 0x00186434 File Offset: 0x00184834
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		BoneOfRaptureData processData = specialEffectData as BoneOfRaptureData;
		if (processData != null && (double)UnityEngine.Random.value <= processData.Chance)
		{
			UnitTurnProgressUpdateEvent pushEffect = new UnitTurnProgressUpdateEvent
			{
				CausingSource = effectCarrier,
				Dealer = effectCarrier,
				ChangePercentage = processData.SpeedUpRate
			};
			IEnumerator enumerator = effectCarrier.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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

	// Token: 0x06003EE3 RID: 16099 RVA: 0x00186460 File Offset: 0x00184860
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			BoneOfRaptureData boneOfRaptureData = specialEffectData as BoneOfRaptureData;
			if (boneOfRaptureData != null)
			{
				boneOfRaptureData.Timer = 0f;
			}
		}
		yield break;
	}

	// Token: 0x04002F6B RID: 12139
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.BoneOfRaptureEffect;

	// Token: 0x02000F21 RID: 3873
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061DC RID: 25052 RVA: 0x00186499 File Offset: 0x00184899
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060061DD RID: 25053 RVA: 0x001864A4 File Offset: 0x001848A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				processData = (specialEffectData as BoneOfRaptureData);
				if (processData == null || (double)UnityEngine.Random.value > processData.Chance)
				{
					goto IL_12C;
				}
				pushEffect = new UnitTurnProgressUpdateEvent
				{
					CausingSource = effectCarrier,
					Dealer = effectCarrier,
					ChangePercentage = processData.SpeedUpRate
				};
				enumerator = effectCarrier.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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
			IL_12C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700147D RID: 5245
		// (get) Token: 0x060061DE RID: 25054 RVA: 0x001865F8 File Offset: 0x001849F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700147E RID: 5246
		// (get) Token: 0x060061DF RID: 25055 RVA: 0x00186600 File Offset: 0x00184A00
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061E0 RID: 25056 RVA: 0x00186608 File Offset: 0x00184A08
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

		// Token: 0x060061E1 RID: 25057 RVA: 0x00186678 File Offset: 0x00184A78
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061E2 RID: 25058 RVA: 0x0018667F File Offset: 0x00184A7F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061E3 RID: 25059 RVA: 0x00186688 File Offset: 0x00184A88
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BoneOfRaptureProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new BoneOfRaptureProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x040057CE RID: 22478
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040057CF RID: 22479
		internal BoneOfRaptureData <processData>__0;

		// Token: 0x040057D0 RID: 22480
		internal IBattleUnit effectCarrier;

		// Token: 0x040057D1 RID: 22481
		internal UnitTurnProgressUpdateEvent <pushEffect>__1;

		// Token: 0x040057D2 RID: 22482
		internal IEnumerator $locvar0;

		// Token: 0x040057D3 RID: 22483
		internal object <_>__2;

		// Token: 0x040057D4 RID: 22484
		internal IDisposable $locvar1;

		// Token: 0x040057D5 RID: 22485
		internal object $current;

		// Token: 0x040057D6 RID: 22486
		internal bool $disposing;

		// Token: 0x040057D7 RID: 22487
		internal int $PC;
	}

	// Token: 0x02000F22 RID: 3874
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061E4 RID: 25060 RVA: 0x001866C8 File Offset: 0x00184AC8
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060061E5 RID: 25061 RVA: 0x001866D0 File Offset: 0x00184AD0
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
				{
					BoneOfRaptureData boneOfRaptureData = specialEffectData as BoneOfRaptureData;
					if (boneOfRaptureData != null)
					{
						boneOfRaptureData.Timer = 0f;
					}
				}
			}
			return false;
		}

		// Token: 0x1700147F RID: 5247
		// (get) Token: 0x060061E6 RID: 25062 RVA: 0x00186730 File Offset: 0x00184B30
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001480 RID: 5248
		// (get) Token: 0x060061E7 RID: 25063 RVA: 0x00186738 File Offset: 0x00184B38
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061E8 RID: 25064 RVA: 0x00186740 File Offset: 0x00184B40
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060061E9 RID: 25065 RVA: 0x00186742 File Offset: 0x00184B42
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061EA RID: 25066 RVA: 0x00186749 File Offset: 0x00184B49
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061EB RID: 25067 RVA: 0x00186754 File Offset: 0x00184B54
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BoneOfRaptureProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new BoneOfRaptureProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040057D8 RID: 22488
		internal AdventureEventType evtType;

		// Token: 0x040057D9 RID: 22489
		internal IBattleUnit triggerUnit;

		// Token: 0x040057DA RID: 22490
		internal IBattleUnit effectCarrier;

		// Token: 0x040057DB RID: 22491
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040057DC RID: 22492
		internal object $current;

		// Token: 0x040057DD RID: 22493
		internal bool $disposing;

		// Token: 0x040057DE RID: 22494
		internal int $PC;
	}
}
