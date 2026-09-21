using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000225 RID: 549
public abstract class PageElementController : MonoBehaviour
{
	// Token: 0x06000E5A RID: 3674 RVA: 0x00071B4E File Offset: 0x0006FF4E
	protected PageElementController()
	{
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x06000E5B RID: 3675 RVA: 0x00071B56 File Offset: 0x0006FF56
	// (set) Token: 0x06000E5C RID: 3676 RVA: 0x00071B5E File Offset: 0x0006FF5E
	public PageElement PageElement
	{
		[CompilerGenerated]
		get
		{
			return this.<PageElement>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PageElement>k__BackingField = value;
		}
	}

	// Token: 0x06000E5D RID: 3677
	public abstract void Init(PageElement item);

	// Token: 0x04001000 RID: 4096
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageElement <PageElement>k__BackingField;
}
