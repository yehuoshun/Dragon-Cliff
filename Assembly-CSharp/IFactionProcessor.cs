using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000488 RID: 1160
public interface IFactionProcessor
{
	// Token: 0x17000229 RID: 553
	// (get) Token: 0x060020E8 RID: 8424
	GameFactionType CorrespondingGameFactionType { get; }

	// Token: 0x060020E9 RID: 8425
	void ProcessGameEvent(GameWorldEvent evt, object data);

	// Token: 0x060020EA RID: 8426
	IEnumerable ProcessBattleEvent(BroadcastEvent evt);

	// Token: 0x060020EB RID: 8427
	List<AdventureEventType> CorrespondingEvents();
}
