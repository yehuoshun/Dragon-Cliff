using System;
using System.Collections.Generic;

// Token: 0x020009AC RID: 2476
public interface ITraveller
{
	// Token: 0x06004400 RID: 17408
	string GetId();

	// Token: 0x06004401 RID: 17409
	List<JourneyContributionModifier> GetContributions();
}
