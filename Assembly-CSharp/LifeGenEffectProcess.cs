using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008FF RID: 2303
public class LifeGenEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004032 RID: 16434 RVA: 0x0019BEBE File Offset: 0x0019A2BE
	public LifeGenEffectProcess()
	{
	}

	// Token: 0x17000BBE RID: 3006
	// (get) Token: 0x06004033 RID: 16435 RVA: 0x0019BEC6 File Offset: 0x0019A2C6
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.LifeGen;
		}
	}

	// Token: 0x17000BBF RID: 3007
	// (get) Token: 0x06004034 RID: 16436 RVA: 0x0019BECA File Offset: 0x0019A2CA
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>();
		}
	}

	// Token: 0x06004035 RID: 16437 RVA: 0x0019BED4 File Offset: 0x0019A2D4
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is LifeGenData)
		{
			LifeGenData data = specialEffectData as LifeGenData;
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAliveWithoutSelf, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(effectCarrier);
			double healValue = data.HealRate * effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
			ReleaseableHeal heal = new ReleaseableHeal((from t in targets
			select new BattleHeal(t, effectCarrier, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = healValue,
					HealType = OutputType.RealHeal,
					IsDirectHeal = false
				}
			}, false)).ToList<BattleHeal>(), effectCarrier);
			IEnumerator enumerator = heal.Release().GetEnumerator();
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

	// Token: 0x02000F8B RID: 3979
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064B9 RID: 25785 RVA: 0x0019BEFE File Offset: 0x0019A2FE
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060064BA RID: 25786 RVA: 0x0019BF08 File Offset: 0x0019A308
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitPerSecondProcess>c__AnonStorey = new LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1();
				<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (!(specialEffectData is LifeGenData))
				{
					goto IL_1A6;
				}
				data = (specialEffectData as LifeGenData);
				targets = new TargetDefinition(TargetCandidateType.FriendlyAliveWithoutSelf, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
				double healValue = data.HealRate * <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				heal = new ReleaseableHeal((from t in targets
				select new BattleHeal(t, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = healValue,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
				enumerator = heal.Release().GetEnumerator();
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
			IL_1A6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001519 RID: 5401
		// (get) Token: 0x060064BB RID: 25787 RVA: 0x0019C0D8 File Offset: 0x0019A4D8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700151A RID: 5402
		// (get) Token: 0x060064BC RID: 25788 RVA: 0x0019C0E0 File Offset: 0x0019A4E0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064BD RID: 25789 RVA: 0x0019C0E8 File Offset: 0x0019A4E8
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

		// Token: 0x060064BE RID: 25790 RVA: 0x0019C158 File Offset: 0x0019A558
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064BF RID: 25791 RVA: 0x0019C15F File Offset: 0x0019A55F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064C0 RID: 25792 RVA: 0x0019C168 File Offset: 0x0019A568
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005CE0 RID: 23776
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005CE1 RID: 23777
		internal LifeGenData <data>__1;

		// Token: 0x04005CE2 RID: 23778
		internal IBattleUnit effectCarrier;

		// Token: 0x04005CE3 RID: 23779
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005CE4 RID: 23780
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005CE5 RID: 23781
		internal IEnumerator $locvar0;

		// Token: 0x04005CE6 RID: 23782
		internal object <_>__2;

		// Token: 0x04005CE7 RID: 23783
		internal IDisposable $locvar1;

		// Token: 0x04005CE8 RID: 23784
		internal object $current;

		// Token: 0x04005CE9 RID: 23785
		internal bool $disposing;

		// Token: 0x04005CEA RID: 23786
		internal int $PC;

		// Token: 0x04005CEB RID: 23787
		private LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 $locvar2;

		// Token: 0x04005CEC RID: 23788
		private LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvar3;

		// Token: 0x02000F8C RID: 3980
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey1
		{
			// Token: 0x060064C1 RID: 25793 RVA: 0x0019C1A8 File Offset: 0x0019A5A8
			public <AsActiveUnitPerSecondProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04005CED RID: 23789
			internal IBattleUnit effectCarrier;
		}

		// Token: 0x02000F8D RID: 3981
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x060064C2 RID: 25794 RVA: 0x0019C1B0 File Offset: 0x0019A5B0
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060064C3 RID: 25795 RVA: 0x0019C1B8 File Offset: 0x0019A5B8
			internal BattleHeal <>m__0(IBattleUnit t)
			{
				return new BattleHeal(t, this.<>f__ref$1.effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.healValue,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false);
			}

			// Token: 0x04005CEE RID: 23790
			internal double healValue;

			// Token: 0x04005CEF RID: 23791
			internal LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005CF0 RID: 23792
			internal LifeGenEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
