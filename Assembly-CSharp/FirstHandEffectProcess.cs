using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008EA RID: 2282
public class FirstHandEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FD1 RID: 16337 RVA: 0x00195E18 File Offset: 0x00194218
	public FirstHandEffectProcess()
	{
	}

	// Token: 0x17000B96 RID: 2966
	// (get) Token: 0x06003FD2 RID: 16338 RVA: 0x00195E20 File Offset: 0x00194220
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.FirstHand;
		}
	}

	// Token: 0x17000B97 RID: 2967
	// (get) Token: 0x06003FD3 RID: 16339 RVA: 0x00195E24 File Offset: 0x00194224
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

	// Token: 0x06003FD4 RID: 16340 RVA: 0x00195E40 File Offset: 0x00194240
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.TurnSetupCompleted && effectCarrier == triggerUnit && specialEffectData is FirstHandEffectData)
		{
			FirstHandEffectData data = specialEffectData as FirstHandEffectData;
			IEnumerator enumerator = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, data.StartProgress).GetEnumerator();
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

	// Token: 0x06003FD5 RID: 16341 RVA: 0x00195E79 File Offset: 0x00194279
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003FD6 RID: 16342 RVA: 0x00195E7C File Offset: 0x0019427C
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FirstHandEffectData
			{
				IsStarEf = new bool?(true),
				StartProgress = 0.8 * (double)UnityEngine.Random.Range(0.6f, 1f)
			}
		};
	}

	// Token: 0x02000F6A RID: 3946
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063DC RID: 25564 RVA: 0x00195EC9 File Offset: 0x001942C9
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063DD RID: 25565 RVA: 0x00195ED4 File Offset: 0x001942D4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.TurnSetupCompleted || effectCarrier != triggerUnit || !(specialEffectData is FirstHandEffectData))
				{
					goto IL_10E;
				}
				data = (specialEffectData as FirstHandEffectData);
				enumerator = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, data.StartProgress).GetEnumerator();
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
			IL_10E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014E9 RID: 5353
		// (get) Token: 0x060063DE RID: 25566 RVA: 0x0019600C File Offset: 0x0019440C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014EA RID: 5354
		// (get) Token: 0x060063DF RID: 25567 RVA: 0x00196014 File Offset: 0x00194414
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063E0 RID: 25568 RVA: 0x0019601C File Offset: 0x0019441C
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

		// Token: 0x060063E1 RID: 25569 RVA: 0x0019608C File Offset: 0x0019448C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063E2 RID: 25570 RVA: 0x00196093 File Offset: 0x00194493
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063E3 RID: 25571 RVA: 0x0019609C File Offset: 0x0019449C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FirstHandEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FirstHandEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B70 RID: 23408
		internal AdventureEventType evtType;

		// Token: 0x04005B71 RID: 23409
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B72 RID: 23410
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B73 RID: 23411
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B74 RID: 23412
		internal FirstHandEffectData <data>__1;

		// Token: 0x04005B75 RID: 23413
		internal IEnumerator $locvar0;

		// Token: 0x04005B76 RID: 23414
		internal object <_>__2;

		// Token: 0x04005B77 RID: 23415
		internal IDisposable $locvar1;

		// Token: 0x04005B78 RID: 23416
		internal object $current;

		// Token: 0x04005B79 RID: 23417
		internal bool $disposing;

		// Token: 0x04005B7A RID: 23418
		internal int $PC;
	}
}
