using System;
using System.Collections.Generic;

// Token: 0x0200097E RID: 2430
public class Main1_1Talks : QuestTownRandomTalks
{
	// Token: 0x060042B6 RID: 17078 RVA: 0x001B4C5C File Offset: 0x001B305C
	public Main1_1Talks()
	{
	}

	// Token: 0x17000D22 RID: 3362
	// (get) Token: 0x060042B7 RID: 17079 RVA: 0x001B4CA3 File Offset: 0x001B30A3
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D23 RID: 3363
	// (get) Token: 0x060042B8 RID: 17080 RVA: 0x001B4CAB File Offset: 0x001B30AB
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032D6 RID: 13014
	private List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main_1_1_c1,
		DialogIdentifier.Main_1_1_c2,
		DialogIdentifier.Main_1_1_c3,
		DialogIdentifier.Main_1_1_c6
	};

	// Token: 0x040032D7 RID: 13015
	private QuestIdentifier _fromQuest = QuestIdentifier.Main1_1;
}
