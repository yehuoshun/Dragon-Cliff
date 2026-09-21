using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200025D RID: 605
public class ALUTextController : MonoBehaviour
{
	// Token: 0x06000FC3 RID: 4035 RVA: 0x00095EDB File Offset: 0x000942DB
	public ALUTextController()
	{
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00095EE3 File Offset: 0x000942E3
	// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x00095EEB File Offset: 0x000942EB
	public ALUTextItem Item
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

	// Token: 0x06000FC6 RID: 4038 RVA: 0x00095EF4 File Offset: 0x000942F4
	private void Awake()
	{
		this.InfoText = base.GetComponent<Text>();
	}

	// Token: 0x040010F7 RID: 4343
	public Text InfoText;

	// Token: 0x040010F8 RID: 4344
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ALUTextItem <Item>k__BackingField;
}
