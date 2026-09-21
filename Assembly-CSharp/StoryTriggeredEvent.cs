using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004BA RID: 1210
public class StoryTriggeredEvent
{
	// Token: 0x060023C9 RID: 9161 RVA: 0x001031CE File Offset: 0x001015CE
	public StoryTriggeredEvent()
	{
	}

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x060023CA RID: 9162 RVA: 0x001031D6 File Offset: 0x001015D6
	// (set) Token: 0x060023CB RID: 9163 RVA: 0x001031DE File Offset: 0x001015DE
	public StoryDetails StoryDetails
	{
		[CompilerGenerated]
		get
		{
			return this.<StoryDetails>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<StoryDetails>k__BackingField = value;
		}
	}

	// Token: 0x04001EF3 RID: 7923
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StoryDetails <StoryDetails>k__BackingField;
}
