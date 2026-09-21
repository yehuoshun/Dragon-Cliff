using System;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004F9 RID: 1273
public static class TownTitleExtension
{
	// Token: 0x060025CD RID: 9677 RVA: 0x00111908 File Offset: 0x0010FD08
	public static TownTitleType GetTitle(this PlayerProfile profile)
	{
		return TownTitleRequirement.Requirements.First((TownTitleRequirement r) => (double)r.InclusiveReputationFrom <= profile.GetProgress(null).Reputation && (double)r.ExclusiveReputationTo > profile.GetProgress(null).Reputation).Title;
	}

	// Token: 0x02000DB7 RID: 3511
	[CompilerGenerated]
	private sealed class <GetTitle>c__AnonStorey0
	{
		// Token: 0x060058A0 RID: 22688 RVA: 0x0011193D File Offset: 0x0010FD3D
		public <GetTitle>c__AnonStorey0()
		{
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x00111948 File Offset: 0x0010FD48
		internal bool <>m__0(TownTitleRequirement r)
		{
			return (double)r.InclusiveReputationFrom <= this.profile.GetProgress(null).Reputation && (double)r.ExclusiveReputationTo > this.profile.GetProgress(null).Reputation;
		}

		// Token: 0x0400487B RID: 18555
		internal PlayerProfile profile;
	}
}
