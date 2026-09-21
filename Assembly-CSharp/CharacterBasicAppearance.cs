using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class CharacterBasicAppearance
{
	// Token: 0x060014BC RID: 5308 RVA: 0x000A85B4 File Offset: 0x000A69B4
	public CharacterBasicAppearance(string path, int sl, int sm, int sr, int wl, int wm, int wr, int el, int em, int er, int nl, int nm, int nr)
	{
		this.Path = path;
		this.SouthLeft = sl;
		this.SouthMiddle = sm;
		this.SouthRight = sr;
		this.WestLeft = wl;
		this.WestMiddle = wm;
		this.WestRight = wr;
		this.EastLeft = el;
		this.EastMiddle = em;
		this.EastRight = er;
		this.NorthLeft = el;
		this.NorthMiddle = em;
		this.NorthRight = er;
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000A862C File Offset: 0x000A6A2C
	public CharacterBasicAppearance(string path, int sl)
	{
		this.Path = path;
		switch (sl)
		{
		case 1:
			sl = 0;
			break;
		case 2:
			sl = 3;
			break;
		case 3:
			sl = 6;
			break;
		case 4:
			sl = 9;
			break;
		case 5:
			sl = 48;
			break;
		case 6:
			sl = 51;
			break;
		case 7:
			sl = 54;
			break;
		case 8:
			sl = 57;
			break;
		}
		this.SouthLeft = sl;
		this.SouthMiddle = sl + 1;
		this.SouthRight = sl + 2;
		this.WestLeft = sl + 12;
		this.WestMiddle = sl + 13;
		this.WestRight = sl + 14;
		this.EastLeft = sl + 24;
		this.EastMiddle = sl + 25;
		this.EastRight = sl + 26;
		this.NorthLeft = sl + 36;
		this.NorthMiddle = sl + 37;
		this.NorthRight = sl + 38;
	}

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x060014BE RID: 5310 RVA: 0x000A872B File Offset: 0x000A6B2B
	// (set) Token: 0x060014BF RID: 5311 RVA: 0x000A8733 File Offset: 0x000A6B33
	public string Path
	{
		[CompilerGenerated]
		get
		{
			return this.<Path>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Path>k__BackingField = value;
		}
	}

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x060014C0 RID: 5312 RVA: 0x000A873C File Offset: 0x000A6B3C
	// (set) Token: 0x060014C1 RID: 5313 RVA: 0x000A8744 File Offset: 0x000A6B44
	public int SouthLeft
	{
		[CompilerGenerated]
		get
		{
			return this.<SouthLeft>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SouthLeft>k__BackingField = value;
		}
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x060014C2 RID: 5314 RVA: 0x000A874D File Offset: 0x000A6B4D
	// (set) Token: 0x060014C3 RID: 5315 RVA: 0x000A8755 File Offset: 0x000A6B55
	public int SouthMiddle
	{
		[CompilerGenerated]
		get
		{
			return this.<SouthMiddle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SouthMiddle>k__BackingField = value;
		}
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x060014C4 RID: 5316 RVA: 0x000A875E File Offset: 0x000A6B5E
	// (set) Token: 0x060014C5 RID: 5317 RVA: 0x000A8766 File Offset: 0x000A6B66
	public int SouthRight
	{
		[CompilerGenerated]
		get
		{
			return this.<SouthRight>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SouthRight>k__BackingField = value;
		}
	}

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x060014C6 RID: 5318 RVA: 0x000A876F File Offset: 0x000A6B6F
	// (set) Token: 0x060014C7 RID: 5319 RVA: 0x000A8777 File Offset: 0x000A6B77
	public int WestLeft
	{
		[CompilerGenerated]
		get
		{
			return this.<WestLeft>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<WestLeft>k__BackingField = value;
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x060014C8 RID: 5320 RVA: 0x000A8780 File Offset: 0x000A6B80
	// (set) Token: 0x060014C9 RID: 5321 RVA: 0x000A8788 File Offset: 0x000A6B88
	public int WestMiddle
	{
		[CompilerGenerated]
		get
		{
			return this.<WestMiddle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<WestMiddle>k__BackingField = value;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x060014CA RID: 5322 RVA: 0x000A8791 File Offset: 0x000A6B91
	// (set) Token: 0x060014CB RID: 5323 RVA: 0x000A8799 File Offset: 0x000A6B99
	public int WestRight
	{
		[CompilerGenerated]
		get
		{
			return this.<WestRight>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<WestRight>k__BackingField = value;
		}
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x060014CC RID: 5324 RVA: 0x000A87A2 File Offset: 0x000A6BA2
	// (set) Token: 0x060014CD RID: 5325 RVA: 0x000A87AA File Offset: 0x000A6BAA
	public int EastLeft
	{
		[CompilerGenerated]
		get
		{
			return this.<EastLeft>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EastLeft>k__BackingField = value;
		}
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x060014CE RID: 5326 RVA: 0x000A87B3 File Offset: 0x000A6BB3
	// (set) Token: 0x060014CF RID: 5327 RVA: 0x000A87BB File Offset: 0x000A6BBB
	public int EastMiddle
	{
		[CompilerGenerated]
		get
		{
			return this.<EastMiddle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EastMiddle>k__BackingField = value;
		}
	}

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x060014D0 RID: 5328 RVA: 0x000A87C4 File Offset: 0x000A6BC4
	// (set) Token: 0x060014D1 RID: 5329 RVA: 0x000A87CC File Offset: 0x000A6BCC
	public int EastRight
	{
		[CompilerGenerated]
		get
		{
			return this.<EastRight>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EastRight>k__BackingField = value;
		}
	}

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x060014D2 RID: 5330 RVA: 0x000A87D5 File Offset: 0x000A6BD5
	// (set) Token: 0x060014D3 RID: 5331 RVA: 0x000A87DD File Offset: 0x000A6BDD
	public int NorthLeft
	{
		[CompilerGenerated]
		get
		{
			return this.<NorthLeft>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NorthLeft>k__BackingField = value;
		}
	}

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x060014D4 RID: 5332 RVA: 0x000A87E6 File Offset: 0x000A6BE6
	// (set) Token: 0x060014D5 RID: 5333 RVA: 0x000A87EE File Offset: 0x000A6BEE
	public int NorthMiddle
	{
		[CompilerGenerated]
		get
		{
			return this.<NorthMiddle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NorthMiddle>k__BackingField = value;
		}
	}

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x060014D6 RID: 5334 RVA: 0x000A87F7 File Offset: 0x000A6BF7
	// (set) Token: 0x060014D7 RID: 5335 RVA: 0x000A87FF File Offset: 0x000A6BFF
	public int NorthRight
	{
		[CompilerGenerated]
		get
		{
			return this.<NorthRight>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NorthRight>k__BackingField = value;
		}
	}

	// Token: 0x060014D8 RID: 5336 RVA: 0x000A8808 File Offset: 0x000A6C08
	public Sprite GetStandSprite()
	{
		return Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + this.Path)[this.SouthMiddle];
	}

	// Token: 0x040014D8 RID: 5336
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Path>k__BackingField;

	// Token: 0x040014D9 RID: 5337
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SouthLeft>k__BackingField;

	// Token: 0x040014DA RID: 5338
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SouthMiddle>k__BackingField;

	// Token: 0x040014DB RID: 5339
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SouthRight>k__BackingField;

	// Token: 0x040014DC RID: 5340
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <WestLeft>k__BackingField;

	// Token: 0x040014DD RID: 5341
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <WestMiddle>k__BackingField;

	// Token: 0x040014DE RID: 5342
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <WestRight>k__BackingField;

	// Token: 0x040014DF RID: 5343
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EastLeft>k__BackingField;

	// Token: 0x040014E0 RID: 5344
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EastMiddle>k__BackingField;

	// Token: 0x040014E1 RID: 5345
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EastRight>k__BackingField;

	// Token: 0x040014E2 RID: 5346
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NorthLeft>k__BackingField;

	// Token: 0x040014E3 RID: 5347
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NorthMiddle>k__BackingField;

	// Token: 0x040014E4 RID: 5348
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NorthRight>k__BackingField;
}
