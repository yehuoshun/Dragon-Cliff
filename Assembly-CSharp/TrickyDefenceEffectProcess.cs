using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093B RID: 2363
public class TrickyDefenceEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004145 RID: 16709 RVA: 0x001ABB1C File Offset: 0x001A9F1C
	public TrickyDefenceEffectProcess()
	{
	}

	// Token: 0x17000C35 RID: 3125
	// (get) Token: 0x06004146 RID: 16710 RVA: 0x001ABB2C File Offset: 0x001A9F2C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C36 RID: 3126
	// (get) Token: 0x06004147 RID: 16711 RVA: 0x001ABB34 File Offset: 0x001A9F34
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

	// Token: 0x06004148 RID: 16712 RVA: 0x001ABB50 File Offset: 0x001A9F50
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
		{
			DamageComponent damage = evtData as DamageComponent;
			TrickyDefenceEffectData data = specialEffectData as TrickyDefenceEffectData;
			if (damage != null && data != null && damage.IsDirectDamage)
			{
				List<IBattleUnit> targets = (from t in effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true)
				where t != effectCarrier
				select t).ToList<IBattleUnit>();
				ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in targets
				select new BattleHeal(t, effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), effectCarrier);
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
		yield break;
	}

	// Token: 0x040030E8 RID: 12520
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.TrickyDefence;

	// Token: 0x02000FE0 RID: 4064
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066FC RID: 26364 RVA: 0x001ABB91 File Offset: 0x001A9F91
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066FD RID: 26365 RVA: 0x001ABB9C File Offset: 0x001A9F9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitProcess>c__AnonStorey = new TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1();
				<AsActiveUnitProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != <AsActiveUnitProcess>c__AnonStorey.effectCarrier)
				{
					goto IL_1E0;
				}
				damage = (evtData as DamageComponent);
				TrickyDefenceEffectData data = specialEffectData as TrickyDefenceEffectData;
				if (damage == null || data == null || !damage.IsDirectDamage)
				{
					goto IL_1E0;
				}
				targets = (from t in <AsActiveUnitProcess>c__AnonStorey.effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true)
				where t != <AsActiveUnitProcess>c__AnonStorey.effectCarrier
				select t).ToList<IBattleUnit>();
				releaseableHeal = new ReleaseableHeal((from t in targets
				select new BattleHeal(t, <AsActiveUnitProcess>c__AnonStorey.effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), <AsActiveUnitProcess>c__AnonStorey.effectCarrier);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700159B RID: 5531
		// (get) Token: 0x060066FE RID: 26366 RVA: 0x001ABDA4 File Offset: 0x001AA1A4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700159C RID: 5532
		// (get) Token: 0x060066FF RID: 26367 RVA: 0x001ABDAC File Offset: 0x001AA1AC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006700 RID: 26368 RVA: 0x001ABDB4 File Offset: 0x001AA1B4
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

		// Token: 0x06006701 RID: 26369 RVA: 0x001ABE24 File Offset: 0x001AA224
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006702 RID: 26370 RVA: 0x001ABE2B File Offset: 0x001AA22B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006703 RID: 26371 RVA: 0x001ABE34 File Offset: 0x001AA234
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040060AA RID: 24746
		internal AdventureEventType evtType;

		// Token: 0x040060AB RID: 24747
		internal IBattleUnit triggerUnit;

		// Token: 0x040060AC RID: 24748
		internal IBattleUnit effectCarrier;

		// Token: 0x040060AD RID: 24749
		internal object evtData;

		// Token: 0x040060AE RID: 24750
		internal DamageComponent <damage>__1;

		// Token: 0x040060AF RID: 24751
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060B0 RID: 24752
		internal List<IBattleUnit> <targets>__2;

		// Token: 0x040060B1 RID: 24753
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x040060B2 RID: 24754
		internal IEnumerator $locvar0;

		// Token: 0x040060B3 RID: 24755
		internal object <_>__3;

		// Token: 0x040060B4 RID: 24756
		internal IDisposable $locvar1;

		// Token: 0x040060B5 RID: 24757
		internal object $current;

		// Token: 0x040060B6 RID: 24758
		internal bool $disposing;

		// Token: 0x040060B7 RID: 24759
		internal int $PC;

		// Token: 0x040060B8 RID: 24760
		private TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x040060B9 RID: 24761
		private TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000FE1 RID: 4065
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006704 RID: 26372 RVA: 0x001ABE98 File Offset: 0x001AA298
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x040060BA RID: 24762
			internal IBattleUnit effectCarrier;
		}

		// Token: 0x02000FE2 RID: 4066
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x06006705 RID: 26373 RVA: 0x001ABEA0 File Offset: 0x001AA2A0
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06006706 RID: 26374 RVA: 0x001ABEA8 File Offset: 0x001AA2A8
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.<>f__ref$1.effectCarrier;
			}

			// Token: 0x06006707 RID: 26375 RVA: 0x001ABEBC File Offset: 0x001AA2BC
			internal BattleHeal <>m__1(IBattleUnit t)
			{
				return new BattleHeal(t, this.<>f__ref$1.effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.<>f__ref$1.effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * this.data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false);
			}

			// Token: 0x040060BB RID: 24763
			internal TrickyDefenceEffectData data;

			// Token: 0x040060BC RID: 24764
			internal TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x040060BD RID: 24765
			internal TrickyDefenceEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
