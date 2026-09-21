using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000926 RID: 2342
public class SpiritualHeartEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040E4 RID: 16612 RVA: 0x001A4B58 File Offset: 0x001A2F58
	public SpiritualHeartEffectProcess()
	{
	}

	// Token: 0x17000C0B RID: 3083
	// (get) Token: 0x060040E5 RID: 16613 RVA: 0x001A4B60 File Offset: 0x001A2F60
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.SpiritualHeart;
		}
	}

	// Token: 0x17000C0C RID: 3084
	// (get) Token: 0x060040E6 RID: 16614 RVA: 0x001A4B64 File Offset: 0x001A2F64
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x060040E7 RID: 16615 RVA: 0x001A4B80 File Offset: 0x001A2F80
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.EventTriggeringUnit.IsPlayer && evt.AdditionalData is DamageComponent && specialEffectData is SpiritualHeartData)
		{
			DamageComponent damage = evt.AdditionalData as DamageComponent;
			if (!damage.HasFullyNeutralized() && damage.IsDirectDamage)
			{
				SpiritualHeartData data = specialEffectData as SpiritualHeartData;
				if ((double)UnityEngine.Random.value <= data.Chance)
				{
					double totalRemDamage = damage.GetTotalDamageSoFar() * data.ReductionRate;
					double damagePerSecond = totalRemDamage / Convert.ToDouble(data.DamageSeconds);
					damage.UpdateFinalDamageFilter(1.0 - data.ReductionRate);
					if (totalRemDamage > 0.0)
					{
						IEnumerator enumerator = DamageOverTimeEffect.AddDamageOverSecond(evt.EventTriggeringUnit, damage.Dealer, damagePerSecond, data.DamageSeconds, OutputType.RealDamage).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x02000FC1 RID: 4033
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600662E RID: 26158 RVA: 0x001A4BAA File Offset: 0x001A2FAA
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600662F RID: 26159 RVA: 0x001A4BB4 File Offset: 0x001A2FB4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitPostReceivesDamage_Single || !evt.EventTriggeringUnit.IsPlayer || !(evt.AdditionalData is DamageComponent) || !(specialEffectData is SpiritualHeartData))
				{
					goto IL_1F7;
				}
				damage = (evt.AdditionalData as DamageComponent);
				if (damage.HasFullyNeutralized() || !damage.IsDirectDamage)
				{
					goto IL_1F7;
				}
				data = (specialEffectData as SpiritualHeartData);
				if ((double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_1F7;
				}
				totalRemDamage = damage.GetTotalDamageSoFar() * data.ReductionRate;
				damagePerSecond = totalRemDamage / Convert.ToDouble(data.DamageSeconds);
				damage.UpdateFinalDamageFilter(1.0 - data.ReductionRate);
				if (totalRemDamage <= 0.0)
				{
					goto IL_1F7;
				}
				enumerator = DamageOverTimeEffect.AddDamageOverSecond(evt.EventTriggeringUnit, damage.Dealer, damagePerSecond, data.DamageSeconds, OutputType.RealDamage).GetEnumerator();
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
			IL_1F7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700156D RID: 5485
		// (get) Token: 0x06006630 RID: 26160 RVA: 0x001A4DD4 File Offset: 0x001A31D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700156E RID: 5486
		// (get) Token: 0x06006631 RID: 26161 RVA: 0x001A4DDC File Offset: 0x001A31DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006632 RID: 26162 RVA: 0x001A4DE4 File Offset: 0x001A31E4
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

		// Token: 0x06006633 RID: 26163 RVA: 0x001A4E54 File Offset: 0x001A3254
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006634 RID: 26164 RVA: 0x001A4E5B File Offset: 0x001A325B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006635 RID: 26165 RVA: 0x001A4E64 File Offset: 0x001A3264
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpiritualHeartEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new SpiritualHeartEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005F12 RID: 24338
		internal BroadcastEvent evt;

		// Token: 0x04005F13 RID: 24339
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F14 RID: 24340
		internal DamageComponent <damage>__1;

		// Token: 0x04005F15 RID: 24341
		internal SpiritualHeartData <data>__2;

		// Token: 0x04005F16 RID: 24342
		internal double <totalRemDamage>__3;

		// Token: 0x04005F17 RID: 24343
		internal double <damagePerSecond>__3;

		// Token: 0x04005F18 RID: 24344
		internal IEnumerator $locvar0;

		// Token: 0x04005F19 RID: 24345
		internal object <_>__4;

		// Token: 0x04005F1A RID: 24346
		internal IDisposable $locvar1;

		// Token: 0x04005F1B RID: 24347
		internal object $current;

		// Token: 0x04005F1C RID: 24348
		internal bool $disposing;

		// Token: 0x04005F1D RID: 24349
		internal int $PC;
	}
}
