using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B9 RID: 1209
public class ShopRefreshedEvent
{
	// Token: 0x060023C4 RID: 9156 RVA: 0x001031A4 File Offset: 0x001015A4
	public ShopRefreshedEvent()
	{
	}

	// Token: 0x17000269 RID: 617
	// (get) Token: 0x060023C5 RID: 9157 RVA: 0x001031AC File Offset: 0x001015AC
	// (set) Token: 0x060023C6 RID: 9158 RVA: 0x001031B4 File Offset: 0x001015B4
	public Shop Shop
	{
		[CompilerGenerated]
		get
		{
			return this.<Shop>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Shop>k__BackingField = value;
		}
	}

	// Token: 0x1700026A RID: 618
	// (get) Token: 0x060023C7 RID: 9159 RVA: 0x001031BD File Offset: 0x001015BD
	// (set) Token: 0x060023C8 RID: 9160 RVA: 0x001031C5 File Offset: 0x001015C5
	public List<Commodity> UpdatedCommodities
	{
		[CompilerGenerated]
		get
		{
			return this.<UpdatedCommodities>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UpdatedCommodities>k__BackingField = value;
		}
	}

	// Token: 0x04001EF1 RID: 7921
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Shop <Shop>k__BackingField;

	// Token: 0x04001EF2 RID: 7922
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Commodity> <UpdatedCommodities>k__BackingField;
}
