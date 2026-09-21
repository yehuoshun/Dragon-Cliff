using System;
using System.Collections.Generic;

// Token: 0x02000983 RID: 2435
public class Main1_7Talks : QuestTownRandomTalks
{
	// Token: 0x060042C5 RID: 17093 RVA: 0x001B4E3C File Offset: 0x001B323C
	public Main1_7Talks()
	{
	}

	// Token: 0x17000D2C RID: 3372
	// (get) Token: 0x060042C6 RID: 17094 RVA: 0x001B4E9B File Offset: 0x001B329B
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D2D RID: 3373
	// (get) Token: 0x060042C7 RID: 17095 RVA: 0x001B4EA3 File Offset: 0x001B32A3
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032E0 RID: 13024
	private readonly List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main1_7_c1,
		DialogIdentifier.Main1_7_c2,
		DialogIdentifier.Main1_7_c3,
		DialogIdentifier.Main1_7_c4,
		DialogIdentifier.Main1_7_c5
	};

	// Token: 0x040032E1 RID: 13025
	private readonly QuestIdentifier _fromQuest = QuestIdentifier.Main1_7;
}
