using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A1 RID: 1185
public class AdventurerListUpdatedEvent
{
	// Token: 0x0600234D RID: 9037 RVA: 0x00102DBB File Offset: 0x001011BB
	public AdventurerListUpdatedEvent()
	{
	}

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x0600234E RID: 9038 RVA: 0x00102DC3 File Offset: 0x001011C3
	// (set) Token: 0x0600234F RID: 9039 RVA: 0x00102DCB File Offset: 0x001011CB
	public List<AdventurerProfile> ChangedProfiles
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangedProfiles>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangedProfiles>k__BackingField = value;
		}
	}

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06002350 RID: 9040 RVA: 0x00102DD4 File Offset: 0x001011D4
	// (set) Token: 0x06002351 RID: 9041 RVA: 0x00102DDC File Offset: 0x001011DC
	public AdventurerListUpdateType AdventurerListUpdateType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerListUpdateType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventurerListUpdateType>k__BackingField = value;
		}
	}

	// Token: 0x1700023A RID: 570
	// (get) Token: 0x06002352 RID: 9042 RVA: 0x00102DE5 File Offset: 0x001011E5
	// (set) Token: 0x06002353 RID: 9043 RVA: 0x00102DED File Offset: 0x001011ED
	public List<ResourceUpdate> RelatedResourceUpdates
	{
		[CompilerGenerated]
		get
		{
			return this.<RelatedResourceUpdates>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RelatedResourceUpdates>k__BackingField = value;
		}
	}

	// Token: 0x04001E58 RID: 7768
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventurerProfile> <ChangedProfiles>k__BackingField;

	// Token: 0x04001E59 RID: 7769
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerListUpdateType <AdventurerListUpdateType>k__BackingField;

	// Token: 0x04001E5A RID: 7770
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceUpdate> <RelatedResourceUpdates>k__BackingField;
}
