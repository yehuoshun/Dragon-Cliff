using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004AC RID: 1196
public class ItemStatusUpdateEvent
{
	// Token: 0x0600237A RID: 9082 RVA: 0x00102F35 File Offset: 0x00101335
	public ItemStatusUpdateEvent()
	{
	}

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x0600237B RID: 9083 RVA: 0x00102F3D File Offset: 0x0010133D
	// (set) Token: 0x0600237C RID: 9084 RVA: 0x00102F45 File Offset: 0x00101345
	public ItemStatus PreviousStatus
	{
		[CompilerGenerated]
		get
		{
			return this.<PreviousStatus>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PreviousStatus>k__BackingField = value;
		}
	}

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x0600237D RID: 9085 RVA: 0x00102F4E File Offset: 0x0010134E
	// (set) Token: 0x0600237E RID: 9086 RVA: 0x00102F56 File Offset: 0x00101356
	public ItemStatus CurrentStatus
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentStatus>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentStatus>k__BackingField = value;
		}
	}

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x0600237F RID: 9087 RVA: 0x00102F5F File Offset: 0x0010135F
	// (set) Token: 0x06002380 RID: 9088 RVA: 0x00102F67 File Offset: 0x00101367
	public Item Item
	{
		[CompilerGenerated]
		get
		{
			return this.<Item>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Item>k__BackingField = value;
		}
	}

	// Token: 0x04001ECB RID: 7883
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ItemStatus <PreviousStatus>k__BackingField;

	// Token: 0x04001ECC RID: 7884
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ItemStatus <CurrentStatus>k__BackingField;

	// Token: 0x04001ECD RID: 7885
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Item>k__BackingField;
}
