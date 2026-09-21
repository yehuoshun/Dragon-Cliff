using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000475 RID: 1141
public class RecipeInfo
{
	// Token: 0x0600205F RID: 8287 RVA: 0x000E14C4 File Offset: 0x000DF8C4
	public RecipeInfo()
	{
	}

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06002060 RID: 8288 RVA: 0x000E14CC File Offset: 0x000DF8CC
	// (set) Token: 0x06002061 RID: 8289 RVA: 0x000E14D4 File Offset: 0x000DF8D4
	public Recipe Recipe
	{
		[CompilerGenerated]
		get
		{
			return this.<Recipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Recipe>k__BackingField = value;
		}
	}

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06002062 RID: 8290 RVA: 0x000E14DD File Offset: 0x000DF8DD
	// (set) Token: 0x06002063 RID: 8291 RVA: 0x000E14E5 File Offset: 0x000DF8E5
	public bool IsQuestRelevant
	{
		[CompilerGenerated]
		get
		{
			return this.<IsQuestRelevant>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsQuestRelevant>k__BackingField = value;
		}
	}

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06002064 RID: 8292 RVA: 0x000E14EE File Offset: 0x000DF8EE
	// (set) Token: 0x06002065 RID: 8293 RVA: 0x000E14F6 File Offset: 0x000DF8F6
	public int ItemTierLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<ItemTierLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ItemTierLevel>k__BackingField = value;
		}
	}

	// Token: 0x04001CD9 RID: 7385
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Recipe <Recipe>k__BackingField;

	// Token: 0x04001CDA RID: 7386
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsQuestRelevant>k__BackingField;

	// Token: 0x04001CDB RID: 7387
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <ItemTierLevel>k__BackingField;
}
