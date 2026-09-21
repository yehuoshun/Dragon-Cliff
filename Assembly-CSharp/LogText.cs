using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001FC RID: 508
public class LogText
{
	// Token: 0x06000D6C RID: 3436 RVA: 0x0008E66D File Offset: 0x0008CA6D
	public LogText()
	{
		this.TextColor = ColorPicker.White;
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0008E680 File Offset: 0x0008CA80
	// (set) Token: 0x06000D6E RID: 3438 RVA: 0x0008E688 File Offset: 0x0008CA88
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return this.<Text>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Text>k__BackingField = value;
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x06000D6F RID: 3439 RVA: 0x0008E691 File Offset: 0x0008CA91
	// (set) Token: 0x06000D70 RID: 3440 RVA: 0x0008E699 File Offset: 0x0008CA99
	public Color TextColor
	{
		[CompilerGenerated]
		get
		{
			return this.<TextColor>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TextColor>k__BackingField = value;
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x06000D71 RID: 3441 RVA: 0x0008E6A2 File Offset: 0x0008CAA2
	// (set) Token: 0x06000D72 RID: 3442 RVA: 0x0008E6AA File Offset: 0x0008CAAA
	public LogTextType TextType
	{
		[CompilerGenerated]
		get
		{
			return this.<TextType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TextType>k__BackingField = value;
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0008E6B3 File Offset: 0x0008CAB3
	// (set) Token: 0x06000D74 RID: 3444 RVA: 0x0008E6BB File Offset: 0x0008CABB
	public object RelatedObject
	{
		[CompilerGenerated]
		get
		{
			return this.<RelatedObject>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RelatedObject>k__BackingField = value;
		}
	}

	// Token: 0x04000F70 RID: 3952
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Text>k__BackingField;

	// Token: 0x04000F71 RID: 3953
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color <TextColor>k__BackingField;

	// Token: 0x04000F72 RID: 3954
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LogTextType <TextType>k__BackingField;

	// Token: 0x04000F73 RID: 3955
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object <RelatedObject>k__BackingField;
}
