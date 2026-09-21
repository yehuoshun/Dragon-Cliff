using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091E RID: 2334
public class SavageHeartProcess : SpecialEffectProcessBase
{
	// Token: 0x060040B9 RID: 16569 RVA: 0x001A3313 File Offset: 0x001A1713
	public SavageHeartProcess()
	{
	}

	// Token: 0x17000BFD RID: 3069
	// (get) Token: 0x060040BA RID: 16570 RVA: 0x001A3323 File Offset: 0x001A1723
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BFE RID: 3070
	// (get) Token: 0x060040BB RID: 16571 RVA: 0x001A332C File Offset: 0x001A172C
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

	// Token: 0x060040BC RID: 16572 RVA: 0x001A3348 File Offset: 0x001A1748
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && effectCarrier == triggerUnit)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			if (damage != null && damage.Dealer == effectCarrier)
			{
				Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> instances = new Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>>();
				foreach (BattleDamage battleDamage in damage.BattleDamages)
				{
					if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed) && battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>().Any<IDamageInstantlyReleaseable>() && !instances.ContainsKey(battleDamage.Target))
					{
						instances.Add(battleDamage.Target, battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>().ToList<IDamageInstantlyReleaseable>());
					}
				}
				if (instances.Any<KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>>>())
				{
					IEnumerator enumerator2 = DamageOverTimeEffect.InstantRun_Batch(instances, 1.0, 30.0).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002FAE RID: 12206
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.SavageHeartEffect;

	// Token: 0x02000FB2 RID: 4018
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065C0 RID: 26048 RVA: 0x001A3382 File Offset: 0x001A1782
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065C1 RID: 26049 RVA: 0x001A338C File Offset: 0x001A178C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || effectCarrier != triggerUnit)
				{
					goto IL_20C;
				}
				damage = (evtData as ReleaseableDamage);
				if (damage == null || damage.Dealer != effectCarrier)
				{
					goto IL_20C;
				}
				instances = new Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>>();
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage = enumerator.Current;
						if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed) && battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>().Any<IDamageInstantlyReleaseable>() && !instances.ContainsKey(battleDamage.Target))
						{
							instances.Add(battleDamage.Target, battleDamage.Target.BattleEffects.OfType<IDamageInstantlyReleaseable>().ToList<IDamageInstantlyReleaseable>());
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!instances.Any<KeyValuePair<IBattleUnit, List<IDamageInstantlyReleaseable>>>())
				{
					goto IL_20C;
				}
				enumerator2 = DamageOverTimeEffect.InstantRun_Batch(instances, 1.0, 30.0).GetEnumerator();
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
			IL_20C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001553 RID: 5459
		// (get) Token: 0x060065C2 RID: 26050 RVA: 0x001A35CC File Offset: 0x001A19CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001554 RID: 5460
		// (get) Token: 0x060065C3 RID: 26051 RVA: 0x001A35D4 File Offset: 0x001A19D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065C4 RID: 26052 RVA: 0x001A35DC File Offset: 0x001A19DC
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060065C5 RID: 26053 RVA: 0x001A364C File Offset: 0x001A1A4C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065C6 RID: 26054 RVA: 0x001A3653 File Offset: 0x001A1A53
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065C7 RID: 26055 RVA: 0x001A365C File Offset: 0x001A1A5C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SavageHeartProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new SavageHeartProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060065C8 RID: 26056 RVA: 0x001A36B4 File Offset: 0x001A1AB4
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005E98 RID: 24216
		internal AdventureEventType evtType;

		// Token: 0x04005E99 RID: 24217
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E9A RID: 24218
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E9B RID: 24219
		internal object evtData;

		// Token: 0x04005E9C RID: 24220
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005E9D RID: 24221
		internal Dictionary<IBattleUnit, List<IDamageInstantlyReleaseable>> <instances>__2;

		// Token: 0x04005E9E RID: 24222
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005E9F RID: 24223
		internal IEnumerator $locvar1;

		// Token: 0x04005EA0 RID: 24224
		internal object <_>__3;

		// Token: 0x04005EA1 RID: 24225
		internal IDisposable $locvar2;

		// Token: 0x04005EA2 RID: 24226
		internal object $current;

		// Token: 0x04005EA3 RID: 24227
		internal bool $disposing;

		// Token: 0x04005EA4 RID: 24228
		internal int $PC;

		// Token: 0x04005EA5 RID: 24229
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
