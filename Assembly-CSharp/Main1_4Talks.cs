using System;
using System.Collections.Generic;

// Token: 0x02000982 RID: 2434
public class Main1_4Talks : QuestTownRandomTalks
{
	// Token: 0x060042C2 RID: 17090 RVA: 0x001B4DDC File Offset: 0x001B31DC
	public Main1_4Talks()
	{
	}

	// Token: 0x17000D2A RID: 3370
	// (get) Token: 0x060042C3 RID: 17091 RVA: 0x001B4E2B File Offset: 0x001B322B
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D2B RID: 3371
	// (get) Token: 0x060042C4 RID: 17092 RVA: 0x001B4E33 File Offset: 0x001B3233
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032DE RID: 13022
	private List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main_1_4_c1,
		DialogIdentifier.Main_1_4_c2,
		DialogIdentifier.Main_1_4_c3,
		DialogIdentifier.Main_1_4_c4,
		DialogIdentifier.Main_1_4_c5
	};

	// Token: 0x040032DF RID: 13023
	private QuestIdentifier _fromQuest = QuestIdentifier.Main1_4;
}
