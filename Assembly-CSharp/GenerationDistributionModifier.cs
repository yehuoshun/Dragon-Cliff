using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000476 RID: 1142
[Serializable]
public class GenerationDistributionModifier
{
	// Token: 0x06002066 RID: 8294 RVA: 0x000E14FF File Offset: 0x000DF8FF
	public GenerationDistributionModifier()
	{
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06002067 RID: 8295 RVA: 0x000E1507 File Offset: 0x000DF907
	// (set) Token: 0x06002068 RID: 8296 RVA: 0x000E150F File Offset: 0x000DF90F
	public QualityGrade ItemGrade
	{
		[CompilerGenerated]
		get
		{
			return this.<ItemGrade>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ItemGrade>k__BackingField = value;
		}
	}

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06002069 RID: 8297 RVA: 0x000E1518 File Offset: 0x000DF918
	// (set) Token: 0x0600206A RID: 8298 RVA: 0x000E1520 File Offset: 0x000DF920
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

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x0600206B RID: 8299 RVA: 0x000E1529 File Offset: 0x000DF929
	// (set) Token: 0x0600206C RID: 8300 RVA: 0x000E1531 File Offset: 0x000DF931
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

	// Token: 0x04001CDC RID: 7388
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <ItemGrade>k__BackingField;

	// Token: 0x04001CDD RID: 7389
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ModificationType <RecipeModificationType>k__BackingField;

	// Token: 0x04001CDE RID: 7390
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;
}
