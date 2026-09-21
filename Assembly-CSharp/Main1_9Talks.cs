using System;
using System.Collections.Generic;

// Token: 0x02000985 RID: 2437
public class Main1_9Talks : QuestTownRandomTalks
{
	// Token: 0x060042CB RID: 17099 RVA: 0x001B4EFC File Offset: 0x001B32FC
	public Main1_9Talks()
	{
	}

	// Token: 0x17000D30 RID: 3376
	// (get) Token: 0x060042CC RID: 17100 RVA: 0x001B4F45 File Offset: 0x001B3345
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D31 RID: 3377
	// (get) Token: 0x060042CD RID: 17101 RVA: 0x001B4F4D File Offset: 0x001B334D
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040032E4 RID: 13028
	private readonly List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main1_9_c1,
		DialogIdentifier.Main1_9_c2,
		DialogIdentifier.Main1_9_c3
	};

	// Token: 0x040032E5 RID: 13029
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_9;
}
