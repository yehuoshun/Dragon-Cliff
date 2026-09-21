using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class TooltipItem
{
	// Token: 0x060010B1 RID: 4273 RVA: 0x0009876F File Offset: 0x00096B6F
	public TooltipItem()
	{
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x060010B2 RID: 4274 RVA: 0x00098777 File Offset: 0x00096B77
	// (set) Token: 0x060010B3 RID: 4275 RVA: 0x0009877F File Offset: 0x00096B7F
	public string Title
	{
		[CompilerGenerated]
		get
		{
			return this.<Title>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Title>k__BackingField = value;
		}
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x060010B4 RID: 4276 RVA: 0x00098788 File Offset: 0x00096B88
	// (set) Token: 0x060010B5 RID: 4277 RVA: 0x00098790 File Offset: 0x00096B90
	public string Type
	{
		[CompilerGenerated]
		get
		{
			return this.<Type>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Type>k__BackingField = value;
		}
	}

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x060010B6 RID: 4278 RVA: 0x00098799 File Offset: 0x00096B99
	// (set) Token: 0x060010B7 RID: 4279 RVA: 0x000987A1 File Offset: 0x00096BA1
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return this.<Description>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Description>k__BackingField = value;
		}
	}

	// Token: 0x170000AF RID: 175
	// (get) Token: 0x060010B8 RID: 4280 RVA: 0x000987AA File Offset: 0x00096BAA
	// (set) Token: 0x060010B9 RID: 4281 RVA: 0x000987B2 File Offset: 0x00096BB2
	public string Description2
	{
		[CompilerGenerated]
		get
		{
			return this.<Description2>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Description2>k__BackingField = value;
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x060010BA RID: 4282 RVA: 0x000987BB File Offset: 0x00096BBB
	// (set) Token: 0x060010BB RID: 4283 RVA: 0x000987C3 File Offset: 0x00096BC3
	public string Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x060010BC RID: 4284 RVA: 0x000987CC File Offset: 0x00096BCC
	// (set) Token: 0x060010BD RID: 4285 RVA: 0x000987D4 File Offset: 0x00096BD4
	public string PrimaryNumber
	{
		[CompilerGenerated]
		get
		{
			return this.<PrimaryNumber>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PrimaryNumber>k__BackingField = value;
		}
	}

	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x060010BE RID: 4286 RVA: 0x000987DD File Offset: 0x00096BDD
	// (set) Token: 0x060010BF RID: 4287 RVA: 0x000987E5 File Offset: 0x00096BE5
	public Sprite BackgroundImage
	{
		[CompilerGenerated]
		get
		{
			return this.<BackgroundImage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BackgroundImage>k__BackingField = value;
		}
	}

	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x060010C0 RID: 4288 RVA: 0x000987EE File Offset: 0x00096BEE
	// (set) Token: 0x060010C1 RID: 4289 RVA: 0x000987F6 File Offset: 0x00096BF6
	public string Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x060010C2 RID: 4290 RVA: 0x000987FF File Offset: 0x00096BFF
	// (set) Token: 0x060010C3 RID: 4291 RVA: 0x00098807 File Offset: 0x00096C07
	public Color TitleColor
	{
		[CompilerGenerated]
		get
		{
			return this.<TitleColor>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TitleColor>k__BackingField = value;
		}
	}

	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00098810 File Offset: 0x00096C10
	// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00098818 File Offset: 0x00096C18
	public Vector3 Position
	{
		[CompilerGenerated]
		get
		{
			return this.<Position>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Position>k__BackingField = value;
		}
	}

	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x060010C6 RID: 4294 RVA: 0x00098821 File Offset: 0x00096C21
	// (set) Token: 0x060010C7 RID: 4295 RVA: 0x00098829 File Offset: 0x00096C29
	public Sprite Image
	{
		[CompilerGenerated]
		get
		{
			return this.<Image>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Image>k__BackingField = value;
		}
	}

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x060010C8 RID: 4296 RVA: 0x00098832 File Offset: 0x00096C32
	// (set) Token: 0x060010C9 RID: 4297 RVA: 0x0009883A File Offset: 0x00096C3A
	public List<Sprite> Icons
	{
		[CompilerGenerated]
		get
		{
			return this.<Icons>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Icons>k__BackingField = value;
		}
	}

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x060010CA RID: 4298 RVA: 0x00098843 File Offset: 0x00096C43
	// (set) Token: 0x060010CB RID: 4299 RVA: 0x0009884B File Offset: 0x00096C4B
	public List<Sprite> InnerIcons
	{
		[CompilerGenerated]
		get
		{
			return this.<InnerIcons>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InnerIcons>k__BackingField = value;
		}
	}

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x060010CC RID: 4300 RVA: 0x00098854 File Offset: 0x00096C54
	// (set) Token: 0x060010CD RID: 4301 RVA: 0x0009885C File Offset: 0x00096C5C
	public bool ShowTypeIcon
	{
		[CompilerGenerated]
		get
		{
			return this.<ShowTypeIcon>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ShowTypeIcon>k__BackingField = value;
		}
	}

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x060010CE RID: 4302 RVA: 0x00098865 File Offset: 0x00096C65
	// (set) Token: 0x060010CF RID: 4303 RVA: 0x0009886D File Offset: 0x00096C6D
	public string PowerLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<PowerLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PowerLevel>k__BackingField = value;
		}
	}

	// Token: 0x040011D2 RID: 4562
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Title>k__BackingField;

	// Token: 0x040011D3 RID: 4563
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Type>k__BackingField;

	// Token: 0x040011D4 RID: 4564
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Description>k__BackingField;

	// Token: 0x040011D5 RID: 4565
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Description2>k__BackingField;

	// Token: 0x040011D6 RID: 4566
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Value>k__BackingField;

	// Token: 0x040011D7 RID: 4567
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <PrimaryNumber>k__BackingField;

	// Token: 0x040011D8 RID: 4568
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Sprite <BackgroundImage>k__BackingField;

	// Token: 0x040011D9 RID: 4569
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Level>k__BackingField;

	// Token: 0x040011DA RID: 4570
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color <TitleColor>k__BackingField;

	// Token: 0x040011DB RID: 4571
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3 <Position>k__BackingField;

	// Token: 0x040011DC RID: 4572
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Sprite <Image>k__BackingField;

	// Token: 0x040011DD RID: 4573
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Sprite> <Icons>k__BackingField;

	// Token: 0x040011DE RID: 4574
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Sprite> <InnerIcons>k__BackingField;

	// Token: 0x040011DF RID: 4575
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <ShowTypeIcon>k__BackingField;

	// Token: 0x040011E0 RID: 4576
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <PowerLevel>k__BackingField;
}
