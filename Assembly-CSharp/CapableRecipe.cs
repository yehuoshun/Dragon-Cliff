using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000214 RID: 532
public class CapableRecipe : PageItem
{
	// Token: 0x06000E03 RID: 3587 RVA: 0x00090524 File Offset: 0x0008E924
	public CapableRecipe()
	{
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0009052C File Offset: 0x0008E92C
	// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00090534 File Offset: 0x0008E934
	public RecipeInfo Recipe
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

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0009053D File Offset: 0x0008E93D
	// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00090545 File Offset: 0x0008E945
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

	// Token: 0x04000FE2 RID: 4066
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RecipeInfo <Recipe>k__BackingField;

	// Token: 0x04000FE3 RID: 4067
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsNew>k__BackingField;
}
