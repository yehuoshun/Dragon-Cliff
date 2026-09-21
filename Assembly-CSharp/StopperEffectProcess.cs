using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200092C RID: 2348
public class StopperEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040FE RID: 16638 RVA: 0x001A629C File Offset: 0x001A469C
	public StopperEffectProcess()
	{
	}

	// Token: 0x17000C17 RID: 3095
	// (get) Token: 0x060040FF RID: 16639 RVA: 0x001A62A4 File Offset: 0x001A46A4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Stopper;
		}
	}

	// Token: 0x17000C18 RID: 3096
	// (get) Token: 0x06004100 RID: 16640 RVA: 0x001A62A8 File Offset: 0x001A46A8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitCompletesTurn
			};
		}
	}

	// Token: 0x06004101 RID: 16641 RVA: 0x001A62C4 File Offset: 0x001A46C4
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitCompletesTurn && !evt.EventTriggeringUnit.IsPlayer && specialEffectData is StopperEffectData && evt.EventTriggeringUnit.IsAliveInBattle())
		{
			StopperEffectData data = specialEffectData as StopperEffectData;
			if ((double)UnityEngine.Random.value <= data.Chance)
			{
				IEnumerator enumerator = LockTimeEffect.AddStunSeconds(evt.EventTriggeringUnit, (float)data.LastingSeconds, evt.EventTriggeringUnit, false).GetEnumerator();
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

	// Token: 0x02000FC9 RID: 4041
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006663 RID: 26211 RVA: 0x001A62EE File Offset: 0x001A46EE
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006664 RID: 26212 RVA: 0x001A62F8 File Offset: 0x001A46F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitCompletesTurn || evt.EventTriggeringUnit.IsPlayer || !(specialEffectData is StopperEffectData) || !evt.EventTriggeringUnit.IsAliveInBattle())
				{
					goto IL_14E;
				}
				data = (specialEffectData as StopperEffectData);
				if ((double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_14E;
				}
				enumerator = LockTimeEffect.AddStunSeconds(evt.EventTriggeringUnit, (float)data.LastingSeconds, evt.EventTriggeringUnit, false).GetEnumerator();
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
			IL_14E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001579 RID: 5497
		// (get) Token: 0x06006665 RID: 26213 RVA: 0x001A6470 File Offset: 0x001A4870
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700157A RID: 5498
		// (get) Token: 0x06006666 RID: 26214 RVA: 0x001A6478 File Offset: 0x001A4878
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006667 RID: 26215 RVA: 0x001A6480 File Offset: 0x001A4880
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

		// Token: 0x06006668 RID: 26216 RVA: 0x001A64F0 File Offset: 0x001A48F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006669 RID: 26217 RVA: 0x001A64F7 File Offset: 0x001A48F7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600666A RID: 26218 RVA: 0x001A6500 File Offset: 0x001A4900
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StopperEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new StopperEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005F68 RID: 24424
		internal BroadcastEvent evt;

		// Token: 0x04005F69 RID: 24425
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F6A RID: 24426
		internal StopperEffectData <data>__1;

		// Token: 0x04005F6B RID: 24427
		internal IEnumerator $locvar0;

		// Token: 0x04005F6C RID: 24428
		internal object <_>__2;

		// Token: 0x04005F6D RID: 24429
		internal IDisposable $locvar1;

		// Token: 0x04005F6E RID: 24430
		internal object $current;

		// Token: 0x04005F6F RID: 24431
		internal bool $disposing;

		// Token: 0x04005F70 RID: 24432
		internal int $PC;
	}
}
