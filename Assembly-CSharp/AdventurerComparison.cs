using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200031E RID: 798
public class AdventurerComparison
{
	// Token: 0x0600153D RID: 5437 RVA: 0x000AA1E6 File Offset: 0x000A85E6
	public AdventurerComparison(AdventurerProfile Id, float percentage)
	{
		this.AdventurerId = Id;
		this.Percentage = percentage;
	}

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x0600153E RID: 5438 RVA: 0x000AA1FC File Offset: 0x000A85FC
	// (set) Token: 0x0600153F RID: 5439 RVA: 0x000AA204 File Offset: 0x000A8604
	public AdventurerProfile AdventurerId
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerId>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<AdventurerId>k__BackingField = value;
		}
	}

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x06001540 RID: 5440 RVA: 0x000AA20D File Offset: 0x000A860D
	// (set) Token: 0x06001541 RID: 5441 RVA: 0x000AA215 File Offset: 0x000A8615
	public float Percentage
	{
		[CompilerGenerated]
		get
		{
			return this.<Percentage>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Percentage>k__BackingField = value;
		}
	}

	// Token: 0x06001542 RID: 5442 RVA: 0x000AA220 File Offset: 0x000A8620
	public static Tuple<AdventurerProfile, float> GetMaxUnitByQuery(List<AdventurerProfile> profiles, Func<AdventurerProfile, float> filter)
	{
		AdventurerProfile first = profiles.OrderByDescending(filter).FirstOrDefault<AdventurerProfile>();
		float second = profiles.Max(filter);
		return new Tuple<AdventurerProfile, float>(first, second);
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x000AA24C File Offset: 0x000A864C
	public static List<AdventurerComparison> GetComparisonresult(List<AdventurerProfile> profiles, Func<AdventurerProfile, float> filter)
	{
		List<AdventurerComparison> list = new List<AdventurerComparison>();
		float num = profiles.Max(filter);
		foreach (AdventurerProfile adventurerProfile in profiles)
		{
			list.Add(new AdventurerComparison(adventurerProfile, filter(adventurerProfile) / num));
		}
		return list;
	}

	// Token: 0x04001557 RID: 5463
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <AdventurerId>k__BackingField;

	// Token: 0x04001558 RID: 5464
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float <Percentage>k__BackingField;
}
