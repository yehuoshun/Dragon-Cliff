using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200037B RID: 891
public class Tuple<T, U>
{
	// Token: 0x06001803 RID: 6147 RVA: 0x000B942B File Offset: 0x000B782B
	public Tuple(T first, U second)
	{
		this.First = first;
		this.Second = second;
	}

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x06001804 RID: 6148 RVA: 0x000B9441 File Offset: 0x000B7841
	// (set) Token: 0x06001805 RID: 6149 RVA: 0x000B9449 File Offset: 0x000B7849
	public T First
	{
		[CompilerGenerated]
		get
		{
			return this.<First>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<First>k__BackingField = value;
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x06001806 RID: 6150 RVA: 0x000B9452 File Offset: 0x000B7852
	// (set) Token: 0x06001807 RID: 6151 RVA: 0x000B945A File Offset: 0x000B785A
	public U Second
	{
		[CompilerGenerated]
		get
		{
			return this.<Second>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Second>k__BackingField = value;
		}
	}

	// Token: 0x040017D0 RID: 6096
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private T <First>k__BackingField;

	// Token: 0x040017D1 RID: 6097
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private U <Second>k__BackingField;
}
