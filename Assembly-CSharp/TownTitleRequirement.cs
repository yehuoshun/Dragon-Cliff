using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004F8 RID: 1272
public class TownTitleRequirement
{
	// Token: 0x060025C5 RID: 9669 RVA: 0x00111518 File Offset: 0x0010F918
	public TownTitleRequirement()
	{
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x060025C6 RID: 9670 RVA: 0x00111520 File Offset: 0x0010F920
	// (set) Token: 0x060025C7 RID: 9671 RVA: 0x00111528 File Offset: 0x0010F928
	public TownTitleType Title
	{
		[CompilerGenerated]
		get
		{
			return this.<Title>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Title>k__BackingField = value;
		}
	}

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x060025C8 RID: 9672 RVA: 0x00111531 File Offset: 0x0010F931
	// (set) Token: 0x060025C9 RID: 9673 RVA: 0x00111539 File Offset: 0x0010F939
	public int InclusiveReputationFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<InclusiveReputationFrom>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InclusiveReputationFrom>k__BackingField = value;
		}
	}

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x060025CA RID: 9674 RVA: 0x00111542 File Offset: 0x0010F942
	// (set) Token: 0x060025CB RID: 9675 RVA: 0x0011154A File Offset: 0x0010F94A
	public int ExclusiveReputationTo
	{
		[CompilerGenerated]
		get
		{
			return this.<ExclusiveReputationTo>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ExclusiveReputationTo>k__BackingField = value;
		}
	}

	// Token: 0x060025CC RID: 9676 RVA: 0x00111554 File Offset: 0x0010F954
	// Note: this type is marked as 'beforefieldinit'.
	static TownTitleRequirement()
	{
	}

	// Token: 0x0400207E RID: 8318
	public static List<TownTitleRequirement> Requirements = new List<TownTitleRequirement>
	{
		new TownTitleRequirement
		{
			Title = TownTitleType.None,
			InclusiveReputationFrom = 0,
			ExclusiveReputationTo = 10
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.SilientPursuit,
			InclusiveReputationFrom = 10,
			ExclusiveReputationTo = 100
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.VillagersChat,
			InclusiveReputationFrom = 100,
			ExclusiveReputationTo = 500
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.WindyCrisp,
			InclusiveReputationFrom = 500,
			ExclusiveReputationTo = 1000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.SolidFruit,
			InclusiveReputationFrom = 1000,
			ExclusiveReputationTo = 1500
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.RomaticRumors,
			InclusiveReputationFrom = 1500,
			ExclusiveReputationTo = 2000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.FairysCrooning,
			InclusiveReputationFrom = 2000,
			ExclusiveReputationTo = 2500
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.DevoutBelievers,
			InclusiveReputationFrom = 2500,
			ExclusiveReputationTo = 3000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.WonderlandsWhispers,
			InclusiveReputationFrom = 3000,
			ExclusiveReputationTo = 3500
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.TheHerosExplorations,
			InclusiveReputationFrom = 3500,
			ExclusiveReputationTo = 4000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.ProudAdventures,
			InclusiveReputationFrom = 4000,
			ExclusiveReputationTo = 5000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.WonderfulFuture,
			InclusiveReputationFrom = 5000,
			ExclusiveReputationTo = 6000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.StyleOfTheEmpire,
			InclusiveReputationFrom = 6000,
			ExclusiveReputationTo = 7000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.DragonsBlessing,
			InclusiveReputationFrom = 7000,
			ExclusiveReputationTo = 8000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.TheDragonCliffsTorch,
			InclusiveReputationFrom = 8000,
			ExclusiveReputationTo = 9000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.TheSacredDragonMessenger,
			InclusiveReputationFrom = 9000,
			ExclusiveReputationTo = 10000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.SalvationOfHeaven,
			InclusiveReputationFrom = 10000,
			ExclusiveReputationTo = 13000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.HestitatedHeart,
			InclusiveReputationFrom = 13000,
			ExclusiveReputationTo = 16000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.FormlessHope,
			InclusiveReputationFrom = 16000,
			ExclusiveReputationTo = 19000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.SatedHarmony,
			InclusiveReputationFrom = 19000,
			ExclusiveReputationTo = 22000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.GreenTrace,
			InclusiveReputationFrom = 22000,
			ExclusiveReputationTo = 25000
		},
		new TownTitleRequirement
		{
			Title = TownTitleType.EmptyMind,
			InclusiveReputationFrom = 25000,
			ExclusiveReputationTo = 10000000
		}
	};

	// Token: 0x0400207F RID: 8319
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownTitleType <Title>k__BackingField;

	// Token: 0x04002080 RID: 8320
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <InclusiveReputationFrom>k__BackingField;

	// Token: 0x04002081 RID: 8321
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <ExclusiveReputationTo>k__BackingField;
}
