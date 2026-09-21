using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002E9 RID: 745
public class HeroMenuEquipmentItem
{
	// Token: 0x060013D0 RID: 5072 RVA: 0x000A4B8A File Offset: 0x000A2F8A
	public HeroMenuEquipmentItem()
	{
	}

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x060013D1 RID: 5073 RVA: 0x000A4B92 File Offset: 0x000A2F92
	// (set) Token: 0x060013D2 RID: 5074 RVA: 0x000A4B9A File Offset: 0x000A2F9A
	public UiSlotType SlotType
	{
		[CompilerGenerated]
		get
		{
			return this.<SlotType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SlotType>k__BackingField = value;
		}
	}

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x060013D3 RID: 5075 RVA: 0x000A4BA3 File Offset: 0x000A2FA3
	// (set) Token: 0x060013D4 RID: 5076 RVA: 0x000A4BAB File Offset: 0x000A2FAB
	public Item Equipment
	{
		[CompilerGenerated]
		get
		{
			return this.<Equipment>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Equipment>k__BackingField = value;
		}
	}

	// Token: 0x0400143C RID: 5180
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UiSlotType <SlotType>k__BackingField;

	// Token: 0x0400143D RID: 5181
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Equipment>k__BackingField;
}
