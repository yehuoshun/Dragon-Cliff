using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008BE RID: 2238
public class CorruptedHornEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F17 RID: 16151 RVA: 0x001897DC File Offset: 0x00187BDC
	public CorruptedHornEffectProcess()
	{
	}

	// Token: 0x17000B3E RID: 2878
	// (get) Token: 0x06003F18 RID: 16152 RVA: 0x001897EC File Offset: 0x00187BEC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B3F RID: 2879
	// (get) Token: 0x06003F19 RID: 16153 RVA: 0x001897F4 File Offset: 0x00187BF4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.DamageReleased
			};
		}
	}

	// Token: 0x06003F1A RID: 16154 RVA: 0x00189810 File Offset: 0x00187C10
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && effectCarrier.GetLiveEnemyTargets(false, false).Any<IBattleUnit>() && evtData is ReleaseableDamage)
		{
			if ((evtData as ReleaseableDamage).BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.Target.Status == BattleUnitStatus.Dead)))
			{
				IEnumerator enumerator = effectCarrier.DoTurn().GetEnumerator();
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

	// Token: 0x04002F6E RID: 12142
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.CorruptedHornEffect;

	// Token: 0x02000F33 RID: 3891
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006251 RID: 25169 RVA: 0x00189843 File Offset: 0x00187C43
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006252 RID: 25170 RVA: 0x0018984C File Offset: 0x00187C4C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || !effectCarrier.GetLiveEnemyTargets(false, false).Any<IBattleUnit>() || !(evtData is ReleaseableDamage))
				{
					goto IL_129;
				}
				if (!(evtData as ReleaseableDamage).BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.Target.Status == BattleUnitStatus.Dead)))
				{
					goto IL_129;
				}
				enumerator = effectCarrier.DoTurn().GetEnumerator();
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
			IL_129:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001495 RID: 5269
		// (get) Token: 0x06006253 RID: 25171 RVA: 0x0018999C File Offset: 0x00187D9C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001496 RID: 5270
		// (get) Token: 0x06006254 RID: 25172 RVA: 0x001899A4 File Offset: 0x00187DA4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006255 RID: 25173 RVA: 0x001899AC File Offset: 0x00187DAC
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

		// Token: 0x06006256 RID: 25174 RVA: 0x00189A1C File Offset: 0x00187E1C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006257 RID: 25175 RVA: 0x00189A23 File Offset: 0x00187E23
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006258 RID: 25176 RVA: 0x00189A2C File Offset: 0x00187E2C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CorruptedHornEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new CorruptedHornEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006259 RID: 25177 RVA: 0x00189A78 File Offset: 0x00187E78
		private static bool <>m__0(BattleDamage d)
		{
			return d.Damages.Any((DamageComponent dd) => dd.Target.Status == BattleUnitStatus.Dead);
		}

		// Token: 0x0600625A RID: 25178 RVA: 0x00189AA2 File Offset: 0x00187EA2
		private static bool <>m__1(DamageComponent dd)
		{
			return dd.Target.Status == BattleUnitStatus.Dead;
		}

		// Token: 0x0400589B RID: 22683
		internal AdventureEventType evtType;

		// Token: 0x0400589C RID: 22684
		internal IBattleUnit effectCarrier;

		// Token: 0x0400589D RID: 22685
		internal object evtData;

		// Token: 0x0400589E RID: 22686
		internal IEnumerator $locvar0;

		// Token: 0x0400589F RID: 22687
		internal object <_>__1;

		// Token: 0x040058A0 RID: 22688
		internal IDisposable $locvar1;

		// Token: 0x040058A1 RID: 22689
		internal object $current;

		// Token: 0x040058A2 RID: 22690
		internal bool $disposing;

		// Token: 0x040058A3 RID: 22691
		internal int $PC;

		// Token: 0x040058A4 RID: 22692
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x040058A5 RID: 22693
		private static Func<DamageComponent, bool> <>f__am$cache1;
	}
}
