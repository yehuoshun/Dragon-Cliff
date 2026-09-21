using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000212 RID: 530
public class BuildingUpgradeItem : PageItem
{
	// Token: 0x06000DFA RID: 3578 RVA: 0x000904E7 File Offset: 0x0008E8E7
	public BuildingUpgradeItem()
	{
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000DFB RID: 3579 RVA: 0x000904EF File Offset: 0x0008E8EF
	// (set) Token: 0x06000DFC RID: 3580 RVA: 0x000904F7 File Offset: 0x0008E8F7
	public ProductionBuildingController BelongsToBuilding
	{
		[CompilerGenerated]
		get
		{
			return this.<BelongsToBuilding>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BelongsToBuilding>k__BackingField = value;
		}
	}

	// Token: 0x04000FDF RID: 4063
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingController <BelongsToBuilding>k__BackingField;
}
