using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020004DF RID: 1247
[Serializable]
public abstract class QuestRequirementBase
{
	// Token: 0x0600254E RID: 9550 RVA: 0x0011046C File Offset: 0x0010E86C
	protected QuestRequirementBase()
	{
	}

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x0600254F RID: 9551
	public abstract QuestRequirementType CorrespondingQuestRequirementType { get; }

	// Token: 0x06002550 RID: 9552
	public abstract bool Fullfilled(Quest quest);

	// Token: 0x06002551 RID: 9553
	public abstract List<AdventureEventType> CorrespondingEvents();

	// Token: 0x06002552 RID: 9554 RVA: 0x00110474 File Offset: 0x0010E874
	public virtual void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
	}

	// Token: 0x06002553 RID: 9555 RVA: 0x00110478 File Offset: 0x0010E878
	public virtual IEnumerable ProcessAdventureEvent(BroadcastEvent evt)
	{
		yield break;
	}

	// Token: 0x02000DB3 RID: 3507
	[CompilerGenerated]
	private sealed class <ProcessAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005885 RID: 22661 RVA: 0x00110494 File Offset: 0x0010E894
		[DebuggerHidden]
		public <ProcessAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x06005886 RID: 22662 RVA: 0x0011049C File Offset: 0x0010E89C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001284 RID: 4740
		// (get) Token: 0x06005887 RID: 22663 RVA: 0x001104B6 File Offset: 0x0010E8B6
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001285 RID: 4741
		// (get) Token: 0x06005888 RID: 22664 RVA: 0x001104BE File Offset: 0x0010E8BE
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005889 RID: 22665 RVA: 0x001104C6 File Offset: 0x0010E8C6
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600588A RID: 22666 RVA: 0x001104C8 File Offset: 0x0010E8C8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600588B RID: 22667 RVA: 0x001104CF File Offset: 0x0010E8CF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600588C RID: 22668 RVA: 0x001104D7 File Offset: 0x0010E8D7
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new QuestRequirementBase.<ProcessAdventureEvent>c__Iterator0();
		}

		// Token: 0x0400486C RID: 18540
		internal object $current;

		// Token: 0x0400486D RID: 18541
		internal bool $disposing;

		// Token: 0x0400486E RID: 18542
		internal int $PC;
	}
}
