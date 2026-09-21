using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000366 RID: 870
public class PassiveEffectController : SkillEffectController
{
	// Token: 0x06001779 RID: 6009 RVA: 0x000B62C0 File Offset: 0x000B46C0
	public PassiveEffectController()
	{
	}

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x0600177A RID: 6010 RVA: 0x000B62C8 File Offset: 0x000B46C8
	// (set) Token: 0x0600177B RID: 6011 RVA: 0x000B62D0 File Offset: 0x000B46D0
	public AdventureUnitSkill AdventureUnitSkill
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureUnitSkill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventureUnitSkill>k__BackingField = value;
		}
	}

	// Token: 0x04001769 RID: 5993
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <AdventureUnitSkill>k__BackingField;
}
