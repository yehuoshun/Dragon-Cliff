using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200028B RID: 651
public class SLUTextController : MonoBehaviour
{
	// Token: 0x0600115A RID: 4442 RVA: 0x0009AD07 File Offset: 0x00099107
	public SLUTextController()
	{
	}

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x0600115B RID: 4443 RVA: 0x0009AD0F File Offset: 0x0009910F
	// (set) Token: 0x0600115C RID: 4444 RVA: 0x0009AD17 File Offset: 0x00099117
	public SLUTextItem Item
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

	// Token: 0x04001234 RID: 4660
	public Text InfoText;

	// Token: 0x04001235 RID: 4661
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SLUTextItem <Item>k__BackingField;
}
