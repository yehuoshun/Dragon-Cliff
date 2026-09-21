using System;
using System.Collections.Generic;

// Token: 0x0200044D RID: 1101
public interface IAdventureConfiguration
{
	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06001F3E RID: 7998
	AdventureType CorrespondingAdventureType { get; }

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06001F3F RID: 7999
	List<double> BaseDropHits { get; }

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06001F40 RID: 8000
	DropTable BaseDropTable { get; }

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06001F41 RID: 8001
	List<AdventureLevelConfiguration> Levels { get; }
}
