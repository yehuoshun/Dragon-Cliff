using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000477 RID: 1143
[Serializable]
public class RateModifier
{
	// Token: 0x0600206D RID: 8301 RVA: 0x000E153A File Offset: 0x000DF93A
	public RateModifier()
	{
	}

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x0600206E RID: 8302 RVA: 0x000E1542 File Offset: 0x000DF942
	// (set) Token: 0x0600206F RID: 8303 RVA: 0x000E154A File Offset: 0x000DF94A
	public ModificationType RecipeModificationType
	{
		[CompilerGenerated]
		get
		{
			return this.<RecipeModificationType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RecipeModificationType>k__BackingField = value;
		}
	}

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06002070 RID: 8304 RVA: 0x000E1553 File Offset: 0x000DF953
	// (set) Token: 0x06002071 RID: 8305 RVA: 0x000E155B File Offset: 0x000DF95B
	public double Value
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

	// Token: 0x04001CDF RID: 7391
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ModificationType <RecipeModificationType>k__BackingField;

	// Token: 0x04001CE0 RID: 7392
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;
}
