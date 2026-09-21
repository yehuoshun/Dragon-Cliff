using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002CB RID: 715
public class RecipeCraftRequirement
{
	// Token: 0x06001316 RID: 4886 RVA: 0x000A16C4 File Offset: 0x0009FAC4
	public RecipeCraftRequirement()
	{
	}

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06001317 RID: 4887 RVA: 0x000A16CC File Offset: 0x0009FACC
	// (set) Token: 0x06001318 RID: 4888 RVA: 0x000A16D4 File Offset: 0x0009FAD4
	public ResourceType CraftingRecipe
	{
		[CompilerGenerated]
		get
		{
			return this.<CraftingRecipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CraftingRecipe>k__BackingField = value;
		}
	}

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06001319 RID: 4889 RVA: 0x000A16DD File Offset: 0x0009FADD
	// (set) Token: 0x0600131A RID: 4890 RVA: 0x000A16E5 File Offset: 0x0009FAE5
	public int Amount
	{
		[CompilerGenerated]
		get
		{
			return this.<Amount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Amount>k__BackingField = value;
		}
	}

	// Token: 0x040013B5 RID: 5045
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <CraftingRecipe>k__BackingField;

	// Token: 0x040013B6 RID: 5046
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Amount>k__BackingField;
}
