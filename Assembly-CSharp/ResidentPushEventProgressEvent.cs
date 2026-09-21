using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B3 RID: 1203
public class ResidentPushEventProgressEvent
{
	// Token: 0x060023A5 RID: 9125 RVA: 0x0010309F File Offset: 0x0010149F
	public ResidentPushEventProgressEvent()
	{
	}

	// Token: 0x1700025C RID: 604
	// (get) Token: 0x060023A6 RID: 9126 RVA: 0x001030A7 File Offset: 0x001014A7
	// (set) Token: 0x060023A7 RID: 9127 RVA: 0x001030AF File Offset: 0x001014AF
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x1700025D RID: 605
	// (get) Token: 0x060023A8 RID: 9128 RVA: 0x001030B8 File Offset: 0x001014B8
	// (set) Token: 0x060023A9 RID: 9129 RVA: 0x001030C0 File Offset: 0x001014C0
	public TownEventProcessorBase Event
	{
		[CompilerGenerated]
		get
		{
			return this.<Event>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Event>k__BackingField = value;
		}
	}

	// Token: 0x04001EDD RID: 7901
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;

	// Token: 0x04001EDE RID: 7902
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownEventProcessorBase <Event>k__BackingField;
}
