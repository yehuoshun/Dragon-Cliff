using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008EF RID: 2287
public class GodsMoralEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FE8 RID: 16360 RVA: 0x00196B50 File Offset: 0x00194F50
	public GodsMoralEffectProcess()
	{
	}

	// Token: 0x17000BA0 RID: 2976
	// (get) Token: 0x06003FE9 RID: 16361 RVA: 0x00196B60 File Offset: 0x00194F60
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BA1 RID: 2977
	// (get) Token: 0x06003FEA RID: 16362 RVA: 0x00196B68 File Offset: 0x00194F68
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitEntersTurn
			};
		}
	}

	// Token: 0x06003FEB RID: 16363 RVA: 0x00196B84 File Offset: 0x00194F84
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitEntersTurn)
		{
			List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			if (friendlyUnits.Any((IBattleUnit f) => f == triggerUnit))
			{
				GodsMoralData data = specialEffectData as GodsMoralData;
				if (data != null)
				{
					double healValue = data.HealRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
					ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = healValue,
								HealType = OutputType.RealHeal,
								IsDirectHeal = false
							}
						}, false)
					}, effectCarrier);
					IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F90 RID: 12176
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.GodsMoralEffect;

	// Token: 0x02000F70 RID: 3952
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063FF RID: 25599 RVA: 0x00196BBD File Offset: 0x00194FBD
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006400 RID: 25600 RVA: 0x00196BC8 File Offset: 0x00194FC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitEntersTurn)
				{
					goto IL_1CA;
				}
				friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				if (!friendlyUnits.Any((IBattleUnit f) => f == triggerUnit))
				{
					goto IL_1CA;
				}
				data = (specialEffectData as GodsMoralData);
				if (data == null)
				{
					goto IL_1CA;
				}
				healValue = data.HealRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(triggerUnit, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = healValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
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
			IL_1CA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014F1 RID: 5361
		// (get) Token: 0x06006401 RID: 25601 RVA: 0x00196DBC File Offset: 0x001951BC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014F2 RID: 5362
		// (get) Token: 0x06006402 RID: 25602 RVA: 0x00196DC4 File Offset: 0x001951C4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006403 RID: 25603 RVA: 0x00196DCC File Offset: 0x001951CC
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

		// Token: 0x06006404 RID: 25604 RVA: 0x00196E3C File Offset: 0x0019523C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006405 RID: 25605 RVA: 0x00196E43 File Offset: 0x00195243
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006406 RID: 25606 RVA: 0x00196E4C File Offset: 0x0019524C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GodsMoralEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new GodsMoralEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005BA0 RID: 23456
		internal AdventureEventType evtType;

		// Token: 0x04005BA1 RID: 23457
		internal IBattleUnit effectCarrier;

		// Token: 0x04005BA2 RID: 23458
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04005BA3 RID: 23459
		internal IBattleUnit triggerUnit;

		// Token: 0x04005BA4 RID: 23460
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BA5 RID: 23461
		internal GodsMoralData <data>__2;

		// Token: 0x04005BA6 RID: 23462
		internal double <healValue>__3;

		// Token: 0x04005BA7 RID: 23463
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04005BA8 RID: 23464
		internal IEnumerator $locvar0;

		// Token: 0x04005BA9 RID: 23465
		internal object <_>__4;

		// Token: 0x04005BAA RID: 23466
		internal IDisposable $locvar1;

		// Token: 0x04005BAB RID: 23467
		internal object $current;

		// Token: 0x04005BAC RID: 23468
		internal bool $disposing;

		// Token: 0x04005BAD RID: 23469
		internal int $PC;

		// Token: 0x04005BAE RID: 23470
		private GodsMoralEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000F71 RID: 3953
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006407 RID: 25607 RVA: 0x00196EA4 File Offset: 0x001952A4
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006408 RID: 25608 RVA: 0x00196EAC File Offset: 0x001952AC
			internal bool <>m__0(IBattleUnit f)
			{
				return f == this.triggerUnit;
			}

			// Token: 0x04005BAF RID: 23471
			internal IBattleUnit triggerUnit;

			// Token: 0x04005BB0 RID: 23472
			internal GodsMoralEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
