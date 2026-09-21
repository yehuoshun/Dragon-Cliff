using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200031B RID: 795
public class BattleLog
{
	// Token: 0x06001517 RID: 5399 RVA: 0x000A97C8 File Offset: 0x000A7BC8
	public BattleLog()
	{
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06001518 RID: 5400 RVA: 0x000A97D0 File Offset: 0x000A7BD0
	// (remove) Token: 0x06001519 RID: 5401 RVA: 0x000A9808 File Offset: 0x000A7C08
	public event Action<string> LogAdded
	{
		add
		{
			Action<string> action = this.LogAdded;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<string>>(ref this.LogAdded, (Action<string>)Delegate.Combine(action2, value), action);
			}
			while (action != action2);
		}
		remove
		{
			Action<string> action = this.LogAdded;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<string>>(ref this.LogAdded, (Action<string>)Delegate.Remove(action2, value), action);
			}
			while (action != action2);
		}
	}

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x0600151A RID: 5402 RVA: 0x000A983E File Offset: 0x000A7C3E
	// (set) Token: 0x0600151B RID: 5403 RVA: 0x000A9846 File Offset: 0x000A7C46
	public Queue<string> Logs
	{
		[CompilerGenerated]
		get
		{
			return this.<Logs>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Logs>k__BackingField = value;
		}
	}

	// Token: 0x0600151C RID: 5404 RVA: 0x000A984F File Offset: 0x000A7C4F
	public void AddLog(string log)
	{
		if (this.Logs.Count > 1000)
		{
			this.Logs.Dequeue();
		}
		this.Logs.Enqueue(log);
		this.OnLogAdded(log);
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x000A9888 File Offset: 0x000A7C88
	protected virtual void OnLogAdded(string obj)
	{
		Action<string> logAdded = this.LogAdded;
		if (logAdded != null)
		{
			logAdded(obj);
		}
	}

	// Token: 0x04001530 RID: 5424
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<string> LogAdded;

	// Token: 0x04001531 RID: 5425
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Queue<string> <Logs>k__BackingField;
}
