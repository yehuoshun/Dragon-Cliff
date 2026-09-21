using System;
using System.Collections.Generic;

// Token: 0x02000980 RID: 2432
public class Main1_2_2_2Talks : QuestTownRandomTalks
{
	// Token: 0x060042BC RID: 17084 RVA: 0x001B4D1C File Offset: 0x001B311C
	public Main1_2_2_2Talks()
	{
	}

	// Token: 0x17000D26 RID: 3366
	// (get) Token: 0x060042BD RID: 17085 RVA: 0x001B4D5C File Offset: 0x001B315C
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D27 RID: 3367
	// (get) Token: 0x060042BE RID: 17086 RVA: 0x001B4D64 File Offset: 0x001B3164
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032DA RID: 13018
	private List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main_1_2_2_1_c1,
		DialogIdentifier.Main_1_2_2_1_c2,
		DialogIdentifier.Main_1_2_2_1_c3
	};

	// Token: 0x040032DB RID: 13019
	private QuestIdentifier _fromQuest = QuestIdentifier.Main1_2_2_2;
}
