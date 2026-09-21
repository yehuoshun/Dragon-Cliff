using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000522 RID: 1314
public abstract class AttributeProcessBase
{
	// Token: 0x060026A5 RID: 9893 RVA: 0x00113D9C File Offset: 0x0011219C
	protected AttributeProcessBase()
	{
	}

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x060026A6 RID: 9894
	public abstract AttributeType CorrespondingAttributeType { get; }

	// Token: 0x060026A7 RID: 9895
	public abstract List<AdventureEventType> CorrespondingEvents();

	// Token: 0x060026A8 RID: 9896
	public abstract IEnumerable ActiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data);

	// Token: 0x060026A9 RID: 9897 RVA: 0x00113DA4 File Offset: 0x001121A4
	public virtual IEnumerable InactiveListenerProcess(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x02000DB8 RID: 3512
	[CompilerGenerated]
	private sealed class <InactiveListenerProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060058A2 RID: 22690 RVA: 0x00113DC0 File Offset: 0x001121C0
		[DebuggerHidden]
		public <InactiveListenerProcess>c__Iterator0()
		{
		}

		// Token: 0x060058A3 RID: 22691 RVA: 0x00113DC8 File Offset: 0x001121C8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700128A RID: 4746
		// (get) Token: 0x060058A4 RID: 22692 RVA: 0x00113DE2 File Offset: 0x001121E2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700128B RID: 4747
		// (get) Token: 0x060058A5 RID: 22693 RVA: 0x00113DEA File Offset: 0x001121EA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060058A6 RID: 22694 RVA: 0x00113DF2 File Offset: 0x001121F2
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x00113DF4 File Offset: 0x001121F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060058A8 RID: 22696 RVA: 0x00113DFB File Offset: 0x001121FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060058A9 RID: 22697 RVA: 0x00113E03 File Offset: 0x00112203
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new AttributeProcessBase.<InactiveListenerProcess>c__Iterator0();
		}

		// Token: 0x0400487C RID: 18556
		internal object $current;

		// Token: 0x0400487D RID: 18557
		internal bool $disposing;

		// Token: 0x0400487E RID: 18558
		internal int $PC;
	}
}
