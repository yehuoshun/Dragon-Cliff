using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class SLUTextItem : MonoBehaviour
{
	// Token: 0x060010A8 RID: 4264 RVA: 0x00098723 File Offset: 0x00096B23
	public SLUTextItem()
	{
	}

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x060010A9 RID: 4265 RVA: 0x0009872B File Offset: 0x00096B2B
	// (set) Token: 0x060010AA RID: 4266 RVA: 0x00098733 File Offset: 0x00096B33
	public AdventurerProfile Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x060010AB RID: 4267 RVA: 0x0009873C File Offset: 0x00096B3C
	// (set) Token: 0x060010AC RID: 4268 RVA: 0x00098744 File Offset: 0x00096B44
	public Skill Skill
	{
		[CompilerGenerated]
		get
		{
			return this.<Skill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Skill>k__BackingField = value;
		}
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x060010AD RID: 4269 RVA: 0x0009874D File Offset: 0x00096B4D
	// (set) Token: 0x060010AE RID: 4270 RVA: 0x00098755 File Offset: 0x00096B55
	public int PreivousLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<PreivousLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PreivousLevel>k__BackingField = value;
		}
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x060010AF RID: 4271 RVA: 0x0009875E File Offset: 0x00096B5E
	// (set) Token: 0x060010B0 RID: 4272 RVA: 0x00098766 File Offset: 0x00096B66
	public int NewLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<NewLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NewLevel>k__BackingField = value;
		}
	}

	// Token: 0x040011CE RID: 4558
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Adventurer>k__BackingField;

	// Token: 0x040011CF RID: 4559
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Skill <Skill>k__BackingField;

	// Token: 0x040011D0 RID: 4560
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <PreivousLevel>k__BackingField;

	// Token: 0x040011D1 RID: 4561
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NewLevel>k__BackingField;
}
