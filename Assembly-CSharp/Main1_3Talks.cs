using System;
using System.Collections.Generic;

// Token: 0x02000981 RID: 2433
public class Main1_3Talks : QuestTownRandomTalks
{
	// Token: 0x060042BF RID: 17087 RVA: 0x001B4D6C File Offset: 0x001B316C
	public Main1_3Talks()
	{
	}

	// Token: 0x17000D28 RID: 3368
	// (get) Token: 0x060042C0 RID: 17088 RVA: 0x001B4DCB File Offset: 0x001B31CB
	public override List<DialogIdentifier> Talks
	{
		get
		{
			return this._talks;
		}
	}

	// Token: 0x17000D29 RID: 3369
	// (get) Token: 0x060042C1 RID: 17089 RVA: 0x001B4DD3 File Offset: 0x001B31D3
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._fromQuest;
		}
	}

	// Token: 0x040032DC RID: 13020
	private List<DialogIdentifier> _talks = new List<DialogIdentifier>
	{
		DialogIdentifier.Main_1_3_c1,
		DialogIdentifier.Main_1_3_c2,
		DialogIdentifier.Main_1_3_c3,
		DialogIdentifier.Main_1_3_c4,
		DialogIdentifier.Main_1_3_c5,
		DialogIdentifier.Main_1_3_c6,
		DialogIdentifier.Main_1_3_c7
	};

	// Token: 0x040032DD RID: 13021
	private QuestIdentifier _fromQuest = QuestIdentifier.Main1_3;
}
