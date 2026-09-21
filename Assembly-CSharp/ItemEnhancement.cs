using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200067D RID: 1661
public class ItemEnhancement
{
	// Token: 0x06002C86 RID: 11398 RVA: 0x00123C50 File Offset: 0x00122050
	public ItemEnhancement()
	{
	}

	// Token: 0x1700058D RID: 1421
	// (get) Token: 0x06002C87 RID: 11399 RVA: 0x00123C58 File Offset: 0x00122058
	// (set) Token: 0x06002C88 RID: 11400 RVA: 0x00123C60 File Offset: 0x00122060
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

	// Token: 0x1700058E RID: 1422
	// (get) Token: 0x06002C89 RID: 11401 RVA: 0x00123C69 File Offset: 0x00122069
	// (set) Token: 0x06002C8A RID: 11402 RVA: 0x00123C71 File Offset: 0x00122071
	public List<AttributeModifier> AttributeModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeModifiers>k__BackingField = value;
		}
	}

	// Token: 0x0400230B RID: 8971
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Item>k__BackingField;

	// Token: 0x0400230C RID: 8972
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <AttributeModifiers>k__BackingField;
}
