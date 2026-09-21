using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002F9 RID: 761
public class SpecialLevelItem : PageElement
{
	// Token: 0x06001415 RID: 5141 RVA: 0x000A55E4 File Offset: 0x000A39E4
	public SpecialLevelItem()
	{
	}

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06001416 RID: 5142 RVA: 0x000A55EC File Offset: 0x000A39EC
	// (set) Token: 0x06001417 RID: 5143 RVA: 0x000A55F4 File Offset: 0x000A39F4
	public string DungeonText
	{
		[CompilerGenerated]
		get
		{
			return this.<DungeonText>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DungeonText>k__BackingField = value;
		}
	}

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06001418 RID: 5144 RVA: 0x000A55FD File Offset: 0x000A39FD
	// (set) Token: 0x06001419 RID: 5145 RVA: 0x000A5605 File Offset: 0x000A3A05
	public int Level
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

	// Token: 0x04001460 RID: 5216
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <DungeonText>k__BackingField;

	// Token: 0x04001461 RID: 5217
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;
}
