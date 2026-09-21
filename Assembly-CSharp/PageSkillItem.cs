using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002F3 RID: 755
public class PageSkillItem : PageElement
{
	// Token: 0x06001402 RID: 5122 RVA: 0x000A5468 File Offset: 0x000A3868
	public PageSkillItem()
	{
	}

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x06001403 RID: 5123 RVA: 0x000A5470 File Offset: 0x000A3870
	// (set) Token: 0x06001404 RID: 5124 RVA: 0x000A5478 File Offset: 0x000A3878
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

	// Token: 0x0400145A RID: 5210
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Skill <Skill>k__BackingField;
}
