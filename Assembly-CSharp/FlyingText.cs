using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200020C RID: 524
public class FlyingText
{
	// Token: 0x06000DDB RID: 3547 RVA: 0x000900F0 File Offset: 0x0008E4F0
	public FlyingText()
	{
		this.Textcolor = ColorPicker.White;
	}

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00090103 File Offset: 0x0008E503
	// (set) Token: 0x06000DDD RID: 3549 RVA: 0x0009010B File Offset: 0x0008E50B
	public string DisplyingText
	{
		[CompilerGenerated]
		get
		{
			return this.<DisplyingText>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DisplyingText>k__BackingField = value;
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000DDE RID: 3550 RVA: 0x00090114 File Offset: 0x0008E514
	// (set) Token: 0x06000DDF RID: 3551 RVA: 0x0009011C File Offset: 0x0008E51C
	public Color Textcolor
	{
		[CompilerGenerated]
		get
		{
			return this.<Textcolor>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Textcolor>k__BackingField = value;
		}
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x00090125 File Offset: 0x0008E525
	// (set) Token: 0x06000DE1 RID: 3553 RVA: 0x0009012D File Offset: 0x0008E52D
	public string LinkText
	{
		[CompilerGenerated]
		get
		{
			return this.<LinkText>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LinkText>k__BackingField = value;
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00090136 File Offset: 0x0008E536
	// (set) Token: 0x06000DE3 RID: 3555 RVA: 0x0009013E File Offset: 0x0008E53E
	public object RelatedObj
	{
		[CompilerGenerated]
		get
		{
			return this.<RelatedObj>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RelatedObj>k__BackingField = value;
		}
	}

	// Token: 0x04000FCB RID: 4043
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <DisplyingText>k__BackingField;

	// Token: 0x04000FCC RID: 4044
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color <Textcolor>k__BackingField;

	// Token: 0x04000FCD RID: 4045
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <LinkText>k__BackingField;

	// Token: 0x04000FCE RID: 4046
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object <RelatedObj>k__BackingField;
}
