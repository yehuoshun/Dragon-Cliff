using System;
using System.Collections.Generic;

// Token: 0x0200097F RID: 2431
public class Main1_2Talks : QuestTownRandomTalks
{
	// Token: 0x060042B9 RID: 17081 RVA: 0x001B4CB4 File Offset: 0x001B30B4
	public Main1_2Talks()
	{
	}

	// Token: 0x17000D24 RID: 3364
	// (get) Token: 0x060042BA RID: 17082 RVA: 0x001B4D0B File Offset: 0x001B310B
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D25 RID: 3365
	// (get) Token: 0x060042BB RID: 17083 RVA: 0x001B4D13 File Offset: 0x001B3113
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032D8 RID: 13016
	private List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main_1_2_c1,
		DialogIdentifier.Main_1_2_c2,
		DialogIdentifier.Main_1_2_c3,
		DialogIdentifier.Main_1_2_c4,
		DialogIdentifier.Main_1_2_c5,
		DialogIdentifier.Main_1_2_c6
	};

	// Token: 0x040032D9 RID: 13017
	private QuestIdentifier _fromQuest = QuestIdentifier.Main1_2;
}
