using System;
using System.Collections.Generic;

// Token: 0x0200097C RID: 2428
public class QuestReleaseDialogues : OnQuestReleaseBatchTalkDifinitionBase
{
	// Token: 0x060042AF RID: 17071 RVA: 0x001B4390 File Offset: 0x001B2790
	public QuestReleaseDialogues()
	{
	}

	// Token: 0x17000D1F RID: 3359
	// (get) Token: 0x060042B0 RID: 17072 RVA: 0x001B4998 File Offset: 0x001B2D98
	public override Dictionary<QuestIdentifier, List<TownTalkModule>> QuestTalks
	{
		get
		{
			return this._questTalks;
		}
	}

	// Token: 0x040032D3 RID: 13011
	private Dictionary<QuestIdentifier, List<TownTalkModule>> _questTalks = new Dictionary<QuestIdentifier, List<TownTalkModule>>
	{
		{
			QuestIdentifier.Main1_1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_1_1,
						DialogIdentifier.Main_1_1_2
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_2,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_2_1
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_2_2_2,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_2_2
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_2_2_3,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._townGuard,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_2_2_3_1
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_2_2_5,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._schoolManager,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_2_2_5_1
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_3,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_3_1,
						DialogIdentifier.Main_1_3_2
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_4,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_4_1,
						DialogIdentifier.Main_1_4_2,
						DialogIdentifier.Main_1_4_3
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_5,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_5_1,
						DialogIdentifier.Main_1_5_2,
						DialogIdentifier.Main_1_5_3
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_6,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_6_1,
						DialogIdentifier.Main_1_6_2
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_7,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_7_1,
						DialogIdentifier.Main_1_7_2,
						DialogIdentifier.Main_1_7_3
					}
				}
			}
		},
		{
			QuestIdentifier.Main1_9,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._weaponShopManager,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_1_9_1,
						DialogIdentifier.Main_1_9_2,
						DialogIdentifier.Main_1_9_3
					}
				}
			}
		},
		{
			QuestIdentifier.Main2_1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._oldManClass,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_1_1,
						DialogIdentifier.Main_2_1_2
					}
				}
			}
		},
		{
			QuestIdentifier.Main2_4,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._forgeManager,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_4_1
					}
				}
			}
		},
		{
			QuestIdentifier.Main2_5,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._forgeManager,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_5_1
					}
				}
			}
		},
		{
			QuestIdentifier.Main5_1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Talker = GenericTownTalkDefinitionBase._townGuard,
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_5_1_1,
						DialogIdentifier.Main_5_1_2
					}
				}
			}
		},
		{
			QuestIdentifier.Side_1_p1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p1_t1
					},
					Talker = GameWorld.instance.PlayerProfile.GetRandomAdventurer()
				}
			}
		},
		{
			QuestIdentifier.Side_1_p2,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p2_t1
					},
					Talker = GameWorld.instance.PlayerProfile.GetRandomAdventurer()
				}
			}
		},
		{
			QuestIdentifier.Side_1_p3,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p3_t1
					},
					Talker = GameWorld.instance.PlayerProfile.GetRandomAdventurer()
				}
			}
		},
		{
			QuestIdentifier.Side_5,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_5_t1
					},
					Talker = GameWorld.instance.PlayerProfile.GetRandomAdventurer()
				}
			}
		},
		{
			QuestIdentifier.Side_6,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_6_t1
					},
					Talker = GenericTownTalkDefinitionBase._townGuard
				},
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_6_t2
					},
					Talker = GenericTownTalkDefinitionBase._schoolManager
				}
			}
		},
		{
			QuestIdentifier.Side_8_p1,
			new List<TownTalkModule>
			{
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_8_p1_t1
					},
					Talker = GenericTownTalkDefinitionBase._townGuard
				},
				new TownTalkModule
				{
					Dialogs = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_8_p1_t2
					},
					Talker = GenericTownTalkDefinitionBase._townGuard
				}
			}
		}
	};
}
