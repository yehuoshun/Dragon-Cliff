using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class UsableItemMenuController : MonoBehaviour
{
	// Token: 0x06001374 RID: 4980 RVA: 0x000A3558 File Offset: 0x000A1958
	public UsableItemMenuController()
	{
	}

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x06001375 RID: 4981 RVA: 0x000A3560 File Offset: 0x000A1960
	// (set) Token: 0x06001376 RID: 4982 RVA: 0x000A3568 File Offset: 0x000A1968
	public Item SelectedItem
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedItem>k__BackingField = value;
		}
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x000A3571 File Offset: 0x000A1971
	public void RightClickItem(Item item)
	{
		this.SelectedItem = item;
	}

	// Token: 0x040013FF RID: 5119
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <SelectedItem>k__BackingField;
}
