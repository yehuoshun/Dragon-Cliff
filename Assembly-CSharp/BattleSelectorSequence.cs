using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000948 RID: 2376
public class BattleSelectorSequence : ISequence
{
	// Token: 0x0600416F RID: 16751 RVA: 0x001AE3F7 File Offset: 0x001AC7F7
	public BattleSelectorSequence()
	{
	}

	// Token: 0x17000C46 RID: 3142
	// (get) Token: 0x06004170 RID: 16752 RVA: 0x001AE3FF File Offset: 0x001AC7FF
	// (set) Token: 0x06004171 RID: 16753 RVA: 0x001AE407 File Offset: 0x001AC807
	public BattleSelectorBase Selector
	{
		[CompilerGenerated]
		get
		{
			return this.<Selector>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Selector>k__BackingField = value;
		}
	}

	// Token: 0x06004172 RID: 16754 RVA: 0x001AE410 File Offset: 0x001AC810
	public IEnumerable RunSequence(BroadcastEvent evt, GenericBattleSequenceBase sequenceRunner)
	{
		IEnumerator enumerator = this.Selector.Start(evt.EventTriggeringUnit).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0400311D RID: 12573
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleSelectorBase <Selector>k__BackingField;

	// Token: 0x02000FF0 RID: 4080
	[CompilerGenerated]
	private sealed class <RunSequence>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600675D RID: 26461 RVA: 0x001AE43A File Offset: 0x001AC83A
		[DebuggerHidden]
		public <RunSequence>c__Iterator0()
		{
		}

		// Token: 0x0600675E RID: 26462 RVA: 0x001AE444 File Offset: 0x001AC844
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = base.Selector.Start(evt.EventTriggeringUnit).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015AF RID: 5551
		// (get) Token: 0x0600675F RID: 26463 RVA: 0x001AE53C File Offset: 0x001AC93C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015B0 RID: 5552
		// (get) Token: 0x06006760 RID: 26464 RVA: 0x001AE544 File Offset: 0x001AC944
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006761 RID: 26465 RVA: 0x001AE54C File Offset: 0x001AC94C
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

		// Token: 0x06006762 RID: 26466 RVA: 0x001AE5BC File Offset: 0x001AC9BC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006763 RID: 26467 RVA: 0x001AE5C3 File Offset: 0x001AC9C3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006764 RID: 26468 RVA: 0x001AE5CC File Offset: 0x001AC9CC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleSelectorSequence.<RunSequence>c__Iterator0 <RunSequence>c__Iterator = new BattleSelectorSequence.<RunSequence>c__Iterator0();
			<RunSequence>c__Iterator.$this = this;
			<RunSequence>c__Iterator.evt = evt;
			return <RunSequence>c__Iterator;
		}

		// Token: 0x0400614D RID: 24909
		internal BroadcastEvent evt;

		// Token: 0x0400614E RID: 24910
		internal IEnumerator $locvar0;

		// Token: 0x0400614F RID: 24911
		internal object <_>__1;

		// Token: 0x04006150 RID: 24912
		internal IDisposable $locvar1;

		// Token: 0x04006151 RID: 24913
		internal BattleSelectorSequence $this;

		// Token: 0x04006152 RID: 24914
		internal object $current;

		// Token: 0x04006153 RID: 24915
		internal bool $disposing;

		// Token: 0x04006154 RID: 24916
		internal int $PC;
	}
}
