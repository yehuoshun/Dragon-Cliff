using System;
using System.Collections.Generic;

// Token: 0x02000986 RID: 2438
public class Main2_1Talks : QuestTownRandomTalks
{
	// Token: 0x060042CE RID: 17102 RVA: 0x001B4F58 File Offset: 0x001B3358
	public Main2_1Talks()
	{
	}

	// Token: 0x17000D32 RID: 3378
	// (get) Token: 0x060042CF RID: 17103 RVA: 0x001B4FB7 File Offset: 0x001B33B7
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D33 RID: 3379
	// (get) Token: 0x060042D0 RID: 17104 RVA: 0x001B4FBF File Offset: 0x001B33BF
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040032E6 RID: 13030
	private readonly List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main2_1_c1,
		DialogIdentifier.Main2_1_c2,
		DialogIdentifier.Main2_1_c3,
		DialogIdentifier.Main2_1_c4,
		DialogIdentifier.Main2_1_c5
	};

	// Token: 0x040032E7 RID: 13031
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main2_1;
}
