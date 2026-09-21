using System;
using System.Collections.Generic;

// Token: 0x02000984 RID: 2436
public class Main1_8Talks : QuestTownRandomTalks
{
	// Token: 0x060042C8 RID: 17096 RVA: 0x001B4EAC File Offset: 0x001B32AC
	public Main1_8Talks()
	{
	}

	// Token: 0x17000D2E RID: 3374
	// (get) Token: 0x060042C9 RID: 17097 RVA: 0x001B4EEA File Offset: 0x001B32EA
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D2F RID: 3375
	// (get) Token: 0x060042CA RID: 17098 RVA: 0x001B4EF2 File Offset: 0x001B32F2
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032E2 RID: 13026
	private readonly List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main1_8_c1,
		DialogIdentifier.Main1_8_c2
	};

	// Token: 0x040032E3 RID: 13027
	private readonly QuestIdentifier _fromQuest = QuestIdentifier.Main1_8;
}
