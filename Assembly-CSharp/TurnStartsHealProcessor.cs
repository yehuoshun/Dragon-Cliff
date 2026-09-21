using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000528 RID: 1320
public class TurnStartsHealProcessor : AttributeProcessBase
{
	// Token: 0x060026BE RID: 9918 RVA: 0x00115258 File Offset: 0x00113658
	public TurnStartsHealProcessor()
	{
	}

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x060026BF RID: 9919 RVA: 0x00115260 File Offset: 0x00113660
	public override AttributeType CorrespondingAttributeType
	{
		get
		{
			return AttributeType.TurnStartHeal;
		}
	}

	// Token: 0x060026C0 RID: 9920 RVA: 0x00115268 File Offset: 0x00113668
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x060026C1 RID: 9921 RVA: 0x00115284 File Offset: 0x00113684
	public override IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && listener == eventTriggerUnit)
		{
			double rate = listener.GetAttributeValue_Final(AttributeType.TurnStartHeal, AttributeRetrievalLevel.Skill);
			double heal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * rate;
			if (heal > 0.0)
			{
				ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, listener);
				IEnumerator enumerator = releaseable.Release().GetEnumerator();
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

	// Token: 0x02000DBE RID: 3518
	[CompilerGenerated]
	private sealed class <ActiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058D3 RID: 22739 RVA: 0x001152B5 File Offset: 0x001136B5
		[DebuggerHidden]
		public <ActiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058D4 RID: 22740 RVA: 0x001152C0 File Offset: 0x001136C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || listener != eventTriggerUnit)
				{
					goto IL_185;
				}
				rate = listener.GetAttributeValue_Final(AttributeType.TurnStartHeal, AttributeRetrievalLevel.Skill);
				heal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * rate;
				if (heal <= 0.0)
				{
					goto IL_185;
				}
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, listener);
				enumerator = releaseable.Release().GetEnumerator();
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
			IL_185:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001296 RID: 4758
		// (get) Token: 0x060058D5 RID: 22741 RVA: 0x0011546C File Offset: 0x0011386C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001297 RID: 4759
		// (get) Token: 0x060058D6 RID: 22742 RVA: 0x00115474 File Offset: 0x00113874
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058D7 RID: 22743 RVA: 0x0011547C File Offset: 0x0011387C
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

		// Token: 0x060058D8 RID: 22744 RVA: 0x001154EC File Offset: 0x001138EC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058D9 RID: 22745 RVA: 0x001154F3 File Offset: 0x001138F3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058DA RID: 22746 RVA: 0x001154FC File Offset: 0x001138FC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TurnStartsHealProcessor.<ActiveListenerProcess>c__Iterator0 <ActiveListenerProcess>c__Iterator = new TurnStartsHealProcessor.<ActiveListenerProcess>c__Iterator0();
			<ActiveListenerProcess>c__Iterator.eventType = eventType;
			<ActiveListenerProcess>c__Iterator.listener = listener;
			<ActiveListenerProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ActiveListenerProcess>c__Iterator;
		}

		// Token: 0x040048C9 RID: 18633
		internal AdventureEventType eventType;

		// Token: 0x040048CA RID: 18634
		internal IBattleUnit listener;

		// Token: 0x040048CB RID: 18635
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040048CC RID: 18636
		internal double <rate>__1;

		// Token: 0x040048CD RID: 18637
		internal double <heal>__1;

		// Token: 0x040048CE RID: 18638
		internal ReleaseableHeal <releaseable>__2;

		// Token: 0x040048CF RID: 18639
		internal IEnumerator $locvar0;

		// Token: 0x040048D0 RID: 18640
		internal object <_>__3;

		// Token: 0x040048D1 RID: 18641
		internal IDisposable $locvar1;

		// Token: 0x040048D2 RID: 18642
		internal object $current;

		// Token: 0x040048D3 RID: 18643
		internal bool $disposing;

		// Token: 0x040048D4 RID: 18644
		internal int $PC;
	}
}
