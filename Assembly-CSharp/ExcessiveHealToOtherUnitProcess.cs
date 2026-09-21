using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008E1 RID: 2273
public class ExcessiveHealToOtherUnitProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FAE RID: 16302 RVA: 0x00193AD3 File Offset: 0x00191ED3
	public ExcessiveHealToOtherUnitProcess()
	{
	}

	// Token: 0x17000B84 RID: 2948
	// (get) Token: 0x06003FAF RID: 16303 RVA: 0x00193ADB File Offset: 0x00191EDB
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ExcessiveHealToOtherUnit;
		}
	}

	// Token: 0x17000B85 RID: 2949
	// (get) Token: 0x06003FB0 RID: 16304 RVA: 0x00193AE0 File Offset: 0x00191EE0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.PostHealRelease
			};
		}
	}

	// Token: 0x06003FB1 RID: 16305 RVA: 0x00193AFC File Offset: 0x00191EFC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.PostHealRelease && triggerUnit == effectCarrier && specialEffectData is ExcessiveHealToOtherUnitData && evtData is ReleaseableHeal && effectCarrier.GetUnitClassStyle().GetClassCategory() == ClassCategory.Healer)
		{
			List<BattleHeal> extraHeals = new List<BattleHeal>();
			ReleaseableHeal heal = evtData as ReleaseableHeal;
			foreach (BattleHeal battleHeal in heal.BattleHeals)
			{
				if (battleHeal.Heals.Any((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0))
				{
					double valueOrDefault = (from h in battleHeal.Heals
					where h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0
					select h).Sum((HealComponent h) => h.ExceededHealValue).GetValueOrDefault();
					if (valueOrDefault > 0.0)
					{
						List<IBattleUnit> source = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(effectCarrier).Take(1).ToList<IBattleUnit>();
						if (source.Any<IBattleUnit>())
						{
							extraHeals.Add(new BattleHeal(source.First<IBattleUnit>(), effectCarrier, new List<HealComponentValue>
							{
								new HealComponentValue
								{
									RawHeal = valueOrDefault,
									HealType = OutputType.RealHeal,
									IsDirectHeal = false
								}
							}, false));
						}
					}
				}
			}
			if (extraHeals.Any<BattleHeal>())
			{
				ReleaseableHeal releaseable = new ReleaseableHeal(extraHeals, effectCarrier);
				IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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

	// Token: 0x02000F5F RID: 3935
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006390 RID: 25488 RVA: 0x00193B3D File Offset: 0x00191F3D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006391 RID: 25489 RVA: 0x00193B48 File Offset: 0x00191F48
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.PostHealRelease || triggerUnit != effectCarrier || !(specialEffectData is ExcessiveHealToOtherUnitData) || !(evtData is ReleaseableHeal) || effectCarrier.GetUnitClassStyle().GetClassCategory() != ClassCategory.Healer)
				{
					goto IL_2B7;
				}
				extraHeals = new List<BattleHeal>();
				heal = (evtData as ReleaseableHeal);
				enumerator = heal.BattleHeals.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleHeal battleHeal = enumerator.Current;
						if (battleHeal.Heals.Any((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0))
						{
							double valueOrDefault = (from h in battleHeal.Heals
							where h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0
							select h).Sum((HealComponent h) => h.ExceededHealValue).GetValueOrDefault();
							if (valueOrDefault > 0.0)
							{
								List<IBattleUnit> source = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(effectCarrier).Take(1).ToList<IBattleUnit>();
								if (source.Any<IBattleUnit>())
								{
									extraHeals.Add(new BattleHeal(source.First<IBattleUnit>(), effectCarrier, new List<HealComponentValue>
									{
										new HealComponentValue
										{
											RawHeal = valueOrDefault,
											HealType = OutputType.RealHeal,
											IsDirectHeal = false
										}
									}, false));
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!extraHeals.Any<BattleHeal>())
				{
					goto IL_2B7;
				}
				releaseable = new ReleaseableHeal(extraHeals, effectCarrier);
				enumerator2 = releaseable.Release().GetEnumerator();
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
			IL_2B7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014D9 RID: 5337
		// (get) Token: 0x06006392 RID: 25490 RVA: 0x00193E4C File Offset: 0x0019224C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014DA RID: 5338
		// (get) Token: 0x06006393 RID: 25491 RVA: 0x00193E54 File Offset: 0x00192254
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006394 RID: 25492 RVA: 0x00193E5C File Offset: 0x0019225C
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

		// Token: 0x06006395 RID: 25493 RVA: 0x00193ECC File Offset: 0x001922CC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006396 RID: 25494 RVA: 0x00193ED3 File Offset: 0x001922D3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006397 RID: 25495 RVA: 0x00193EDC File Offset: 0x001922DC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ExcessiveHealToOtherUnitProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ExcessiveHealToOtherUnitProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006398 RID: 25496 RVA: 0x00193F40 File Offset: 0x00192340
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0;
		}

		// Token: 0x06006399 RID: 25497 RVA: 0x00193F90 File Offset: 0x00192390
		private static bool <>m__1(HealComponent h)
		{
			return h.IsDirectHeal && !h.IsNeutralized && h.ExceededHealValue > 0.0;
		}

		// Token: 0x0600639A RID: 25498 RVA: 0x00193FDE File Offset: 0x001923DE
		private static double? <>m__2(HealComponent h)
		{
			return h.ExceededHealValue;
		}

		// Token: 0x04005AE2 RID: 23266
		internal AdventureEventType evtType;

		// Token: 0x04005AE3 RID: 23267
		internal IBattleUnit triggerUnit;

		// Token: 0x04005AE4 RID: 23268
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AE5 RID: 23269
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AE6 RID: 23270
		internal object evtData;

		// Token: 0x04005AE7 RID: 23271
		internal List<BattleHeal> <extraHeals>__1;

		// Token: 0x04005AE8 RID: 23272
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005AE9 RID: 23273
		internal List<BattleHeal>.Enumerator $locvar0;

		// Token: 0x04005AEA RID: 23274
		internal ReleaseableHeal <releaseable>__2;

		// Token: 0x04005AEB RID: 23275
		internal IEnumerator $locvar1;

		// Token: 0x04005AEC RID: 23276
		internal object <_>__3;

		// Token: 0x04005AED RID: 23277
		internal IDisposable $locvar2;

		// Token: 0x04005AEE RID: 23278
		internal object $current;

		// Token: 0x04005AEF RID: 23279
		internal bool $disposing;

		// Token: 0x04005AF0 RID: 23280
		internal int $PC;

		// Token: 0x04005AF1 RID: 23281
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x04005AF2 RID: 23282
		private static Func<HealComponent, bool> <>f__am$cache1;

		// Token: 0x04005AF3 RID: 23283
		private static Func<HealComponent, double?> <>f__am$cache2;
	}
}
