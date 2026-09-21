using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000907 RID: 2311
public class MissHasteEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004053 RID: 16467 RVA: 0x0019D9B4 File Offset: 0x0019BDB4
	public MissHasteEffectProcess()
	{
	}

	// Token: 0x17000BCE RID: 3022
	// (get) Token: 0x06004054 RID: 16468 RVA: 0x0019D9BC File Offset: 0x0019BDBC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.MissHaste;
		}
	}

	// Token: 0x17000BCF RID: 3023
	// (get) Token: 0x06004055 RID: 16469 RVA: 0x0019D9C0 File Offset: 0x0019BDC0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage
			};
		}
	}

	// Token: 0x06004056 RID: 16470 RVA: 0x0019D9DC File Offset: 0x0019BDDC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage && triggerUnit == effectCarrier && specialEffectData is MissHasteData && evtData is BattleDamage)
		{
			BattleDamage damage = evtData as BattleDamage;
			MissHasteData data = specialEffectData as MissHasteData;
			int totalHaste = damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && d.IsMissed);
			if (totalHaste > 0)
			{
				double totalPush = (double)totalHaste * data.HasteRate;
				IEnumerator enumerator = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, totalPush).GetEnumerator();
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

	// Token: 0x02000F94 RID: 3988
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064F9 RID: 25849 RVA: 0x0019DA1D File Offset: 0x0019BE1D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060064FA RID: 25850 RVA: 0x0019DA28 File Offset: 0x0019BE28
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage || triggerUnit != effectCarrier || !(specialEffectData is MissHasteData) || !(evtData is BattleDamage))
				{
					goto IL_182;
				}
				damage = (evtData as BattleDamage);
				data = (specialEffectData as MissHasteData);
				totalHaste = damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && d.IsMissed);
				if (totalHaste <= 0)
				{
					goto IL_182;
				}
				totalPush = (double)totalHaste * data.HasteRate;
				enumerator = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, totalPush).GetEnumerator();
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
			IL_182:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001527 RID: 5415
		// (get) Token: 0x060064FB RID: 25851 RVA: 0x0019DBD4 File Offset: 0x0019BFD4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001528 RID: 5416
		// (get) Token: 0x060064FC RID: 25852 RVA: 0x0019DBDC File Offset: 0x0019BFDC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064FD RID: 25853 RVA: 0x0019DBE4 File Offset: 0x0019BFE4
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

		// Token: 0x060064FE RID: 25854 RVA: 0x0019DC54 File Offset: 0x0019C054
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064FF RID: 25855 RVA: 0x0019DC5B File Offset: 0x0019C05B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006500 RID: 25856 RVA: 0x0019DC64 File Offset: 0x0019C064
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MissHasteEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new MissHasteEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006501 RID: 25857 RVA: 0x0019DCC8 File Offset: 0x0019C0C8
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && d.IsMissed;
		}

		// Token: 0x04005D42 RID: 23874
		internal AdventureEventType evtType;

		// Token: 0x04005D43 RID: 23875
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D44 RID: 23876
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D45 RID: 23877
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D46 RID: 23878
		internal object evtData;

		// Token: 0x04005D47 RID: 23879
		internal BattleDamage <damage>__1;

		// Token: 0x04005D48 RID: 23880
		internal MissHasteData <data>__1;

		// Token: 0x04005D49 RID: 23881
		internal int <totalHaste>__1;

		// Token: 0x04005D4A RID: 23882
		internal double <totalPush>__2;

		// Token: 0x04005D4B RID: 23883
		internal IEnumerator $locvar0;

		// Token: 0x04005D4C RID: 23884
		internal object <_>__3;

		// Token: 0x04005D4D RID: 23885
		internal IDisposable $locvar1;

		// Token: 0x04005D4E RID: 23886
		internal object $current;

		// Token: 0x04005D4F RID: 23887
		internal bool $disposing;

		// Token: 0x04005D50 RID: 23888
		internal int $PC;

		// Token: 0x04005D51 RID: 23889
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
