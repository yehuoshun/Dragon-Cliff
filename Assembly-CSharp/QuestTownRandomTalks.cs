using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000987 RID: 2439
public abstract class QuestTownRandomTalks : RandomTownTalkDefinitionBase
{
	// Token: 0x060042D1 RID: 17105 RVA: 0x001B4BD6 File Offset: 0x001B2FD6
	protected QuestTownRandomTalks()
	{
	}

	// Token: 0x17000D34 RID: 3380
	// (get) Token: 0x060042D2 RID: 17106
	public abstract List<DialogIdentifier> Talks { get; }

	// Token: 0x17000D35 RID: 3381
	// (get) Token: 0x060042D3 RID: 17107
	public abstract QuestIdentifier ActiveQuest { get; }

	// Token: 0x060042D4 RID: 17108 RVA: 0x001B4BDE File Offset: 0x001B2FDE
	public override bool MetRequirement(GameWorldEvent evt, object additionalData)
	{
		return base.QuestIsActive(this.ActiveQuest) && evt == GameWorldEvent.TownAutoDialogTriggers;
	}

	// Token: 0x17000D36 RID: 3382
	// (get) Token: 0x060042D5 RID: 17109 RVA: 0x001B4BF9 File Offset: 0x001B2FF9
	public override List<DialogPresence> DialogCollections
	{
		get
		{
			return (from t in this.Talks
			select new DialogPresence
			{
				Presence = 100,
				DialogIdentifier = t,
				SpecificUnit = null
			}).ToList<DialogPresence>();
		}
	}

	// Token: 0x060042D6 RID: 17110 RVA: 0x001B4C28 File Offset: 0x001B3028
	[CompilerGenerated]
	private static DialogPresence <get_DialogCollections>m__0(DialogIdentifier t)
	{
		return new DialogPresence
		{
			Presence = 100,
			DialogIdentifier = t,
			SpecificUnit = null
		};
	}

	// Token: 0x040032E8 RID: 13032
	[CompilerGenerated]
	private static Func<DialogIdentifier, DialogPresence> <>f__am$cache0;
}
