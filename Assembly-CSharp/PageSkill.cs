using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000254 RID: 596
public class PageSkill : PageElement
{
	// Token: 0x06000F77 RID: 3959 RVA: 0x00094A54 File Offset: 0x00092E54
	public PageSkill()
	{
	}

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x06000F78 RID: 3960 RVA: 0x00094A5C File Offset: 0x00092E5C
	// (set) Token: 0x06000F79 RID: 3961 RVA: 0x00094A64 File Offset: 0x00092E64
	public Skill SkillProfile
	{
		[CompilerGenerated]
		get
		{
			return this.<SkillProfile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SkillProfile>k__BackingField = value;
		}
	}

	// Token: 0x1700009B RID: 155
	// (get) Token: 0x06000F7A RID: 3962 RVA: 0x00094A6D File Offset: 0x00092E6D
	// (set) Token: 0x06000F7B RID: 3963 RVA: 0x00094A75 File Offset: 0x00092E75
	public bool IsNew
	{
		[CompilerGenerated]
		get
		{
			return this.<IsNew>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsNew>k__BackingField = value;
		}
	}

	// Token: 0x040010BC RID: 4284
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Skill <SkillProfile>k__BackingField;

	// Token: 0x040010BD RID: 4285
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsNew>k__BackingField;
}
