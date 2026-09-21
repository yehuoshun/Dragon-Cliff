using System;
using System.Collections.Generic;

// Token: 0x0200097B RID: 2427
public class QuestCompleteDialogues : OnQuestCompletedBatchTalkDifinitionBase
{
	// Token: 0x060042AD RID: 17069 RVA: 0x001B4218 File Offset: 0x001B2618
	public QuestCompleteDialogues()
	{
	}

	// Token: 0x17000D1E RID: 3358
	// (get) Token: 0x060042AE RID: 17070 RVA: 0x001B4388 File Offset: 0x001B2788
	public override Dictionary<QuestIdentifier, List<TownTalkModule>> QuestTalks
	{
		get
		{
			return this._questTalks;
		}
	}

	// Token: 0x040032D2 RID: 13010
	private readonly Dictionary<QuestIdentifier, List<TownTalkModule>> _questTalks = new Dictionary<QuestIdentifier, List<TownTalkModule>>
	{
		{
			QuestIdentifier.Main1_9,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_9_4,
						DialogIdentifier.Main_1_9_5
					},
					Talker = GenericTownTalkDefinitionBase._weaponShopManager
				}
			}
		},
		{
			QuestIdentifier.Main2_1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_1_3
					},
					Talker = GenericTownTalkDefinitionBase._oldManClass
				}
			}
		},
		{
			QuestIdentifier.Main2_2,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_2_1,
						DialogIdentifier.Main_2_2_2
					},
					Talker = GenericTownTalkDefinitionBase._oldManClass
				}
			}
		},
		{
			QuestIdentifier.Main3_1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_3_1_1
					},
					Talker = GenericTownTalkDefinitionBase._oldManClass
				}
			}
		},
		{
			QuestIdentifier.Main3_2,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_3_2_1,
						DialogIdentifier.Main_3_2_2
					},
					Talker = GenericTownTalkDefinitionBase._oldManClass
				}
			}
		}
	};
}
