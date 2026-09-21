using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000523 RID: 1315
public class BattleStartHealProcessor : AttributeProcessBase
{
	// Token: 0x060026AA RID: 9898 RVA: 0x00113E1E File Offset: 0x0011221E
	public BattleStartHealProcessor()
	{
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x060026AB RID: 9899 RVA: 0x00113E26 File Offset: 0x00112226
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.BattleStartHeal;
		}
	}

	// Token: 0x060026AC RID: 9900 RVA: 0x00113E30 File Offset: 0x00112230
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};
	}

	// Token: 0x060026AD RID: 9901 RVA: 0x00113E4C File Offset: 0x0011224C
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && listener == eventTriggerUnit)
		{
			double rate = listener.GetAttributeValue_Final(AttributeType.BattleStartHeal, AttributeRetrievalLevel.Skill);
			double heal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * rate;
			if (heal > 0.0)
			{
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							HealType = OutputType.RealHeal,
							RawHeal = heal,
							IsDirectHeal = false
						}
					}, false)
				}, listener);
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

	// Token: 0x02000DB9 RID: 3513
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058AA RID: 22698 RVA: 0x00113E7D File Offset: 0x0011227D
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058AB RID: 22699 RVA: 0x00113E88 File Offset: 0x00112288
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReadyInBattle || listener != eventTriggerUnit)
				{
					goto IL_186;
				}
				rate = listener.GetAttributeValue_Final(AttributeType.BattleStartHeal, AttributeRetrievalLevel.Skill);
				heal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * rate;
				if (heal <= 0.0)
				{
					goto IL_186;
				}
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							HealType = OutputType.RealHeal,
							RawHeal = heal,
							IsDirectHeal = false
						}
					}, false)
				}, listener);
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
			IL_186:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700128C RID: 4748
		// (get) Token: 0x060058AC RID: 22700 RVA: 0x00114038 File Offset: 0x00112438
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700128D RID: 4749
		// (get) Token: 0x060058AD RID: 22701 RVA: 0x00114040 File Offset: 0x00112440
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058AE RID: 22702 RVA: 0x00114048 File Offset: 0x00112448
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

		// Token: 0x060058AF RID: 22703 RVA: 0x001140B8 File Offset: 0x001124B8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058B0 RID: 22704 RVA: 0x001140BF File Offset: 0x001124BF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058B1 RID: 22705 RVA: 0x001140C8 File Offset: 0x001124C8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleStartHealProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new BattleStartHealProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x0400487F RID: 18559
		internal AdventureEventType eventType;

		// Token: 0x04004880 RID: 18560
		internal IBattleUnit listener;

		// Token: 0x04004881 RID: 18561
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004882 RID: 18562
		internal double <rate>__1;

		// Token: 0x04004883 RID: 18563
		internal double <heal>__1;

		// Token: 0x04004884 RID: 18564
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04004885 RID: 18565
		internal IEnumerator $locvar0;

		// Token: 0x04004886 RID: 18566
		internal object <_>__3;

		// Token: 0x04004887 RID: 18567
		internal IDisposable $locvar1;

		// Token: 0x04004888 RID: 18568
		internal object $current;

		// Token: 0x04004889 RID: 18569
		internal bool $disposing;

		// Token: 0x0400488A RID: 18570
		internal int $PC;
	}
}
