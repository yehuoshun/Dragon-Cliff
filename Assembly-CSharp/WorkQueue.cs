using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200047E RID: 1150
[Serializable]
public class WorkQueue
{
	// Token: 0x060020C3 RID: 8387 RVA: 0x000E2DEE File Offset: 0x000E11EE
	public WorkQueue()
	{
	}

	// Token: 0x17000224 RID: 548
	// (get) Token: 0x060020C4 RID: 8388 RVA: 0x000E2DF6 File Offset: 0x000E11F6
	// (set) Token: 0x060020C5 RID: 8389 RVA: 0x000E2DFE File Offset: 0x000E11FE
	public ResourceType ProductType
	{
		[CompilerGenerated]
		get
		{
			return this.<ProductType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ProductType>k__BackingField = value;
		}
	}

	// Token: 0x17000225 RID: 549
	// (get) Token: 0x060020C6 RID: 8390 RVA: 0x000E2E07 File Offset: 0x000E1207
	// (set) Token: 0x060020C7 RID: 8391 RVA: 0x000E2E0F File Offset: 0x000E120F
	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return this.<Quantity>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Quantity>k__BackingField = value;
		}
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x000E2E18 File Offset: 0x000E1218
	private DifficultyLevelMeasurement GetDifficultyLevelMeasurement()
	{
		if (this.RelatedDifficultyValue != null)
		{
			return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this.RelatedDifficultyValue.Value, 1);
		}
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(90.0, 1);
	}

	// Token: 0x060020C9 RID: 8393 RVA: 0x000E2E4C File Offset: 0x000E124C
	public int GetItemTierLevel()
	{
		int? itemTierLevel = this.ItemTierLevel;
		return (itemTierLevel == null) ? this.GetDifficultyLevelMeasurement().GetCorrespondingItemTierLevel(this.ProductType) : itemTierLevel.Value;
	}

	// Token: 0x04001D07 RID: 7431
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ProductType>k__BackingField;

	// Token: 0x04001D08 RID: 7432
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Quantity>k__BackingField;

	// Token: 0x04001D09 RID: 7433
	public double? RelatedDifficultyValue;

	// Token: 0x04001D0A RID: 7434
	public int? ItemTierLevel;
}
