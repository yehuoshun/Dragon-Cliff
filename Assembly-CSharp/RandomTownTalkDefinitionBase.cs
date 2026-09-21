using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000988 RID: 2440
public abstract class RandomTownTalkDefinitionBase : GenericTownTalkDefinitionBase
{
	// Token: 0x060042D7 RID: 17111 RVA: 0x001B49CA File Offset: 0x001B2DCA
	protected RandomTownTalkDefinitionBase()
	{
	}

	// Token: 0x17000D37 RID: 3383
	// (get) Token: 0x060042D8 RID: 17112
	public abstract List<DialogPresence> DialogCollections { get; }

	// Token: 0x060042D9 RID: 17113 RVA: 0x001B49D2 File Offset: 0x001B2DD2
	internal bool IsWithinStoryPeriod(StoryIdentifier from, StoryIdentifier to)
	{
		return from.HasBeenTriggerredFor(1) && !to.HasBeenTriggerredFor(1);
	}

	// Token: 0x060042DA RID: 17114 RVA: 0x001B49ED File Offset: 0x001B2DED
	internal bool IsWithinQuestPeriod(QuestIdentifier from, QuestIdentifier to)
	{
		return from.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()) && !to.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating());
	}

	// Token: 0x060042DB RID: 17115 RVA: 0x001B4A24 File Offset: 0x001B2E24
	internal bool QuestIsActive(QuestIdentifier type)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == type && !q.Completed);
	}

	// Token: 0x060042DC RID: 17116 RVA: 0x001B4A6C File Offset: 0x001B2E6C
	public override void Run(GameWorldEvent evt, object additionalData)
	{
		List<AdventurerProfile> adventurerProfiles = GameWorld.instance.PlayerProfile.AdventurerProfiles;
		List<DialogPresence> list = (from d in this.DialogCollections
		where !d.DialogIdentifier.HasBeenSpokenFor(1)
		select d).ToList<DialogPresence>();
		if (list.Any<DialogPresence>())
		{
			DialogPresence dialogPresence = list.WeightedRandomSelect<DialogPresence>();
			if (dialogPresence.SpecificUnit != null)
			{
				dialogPresence.SpecificUnit.Value.Speaks(dialogPresence.DialogIdentifier);
			}
			else if (adventurerProfiles.Any<AdventurerProfile>())
			{
				AdventurerProfile adventurerProfile = adventurerProfiles[UnityEngine.Random.Range(0, adventurerProfiles.Count)];
				adventurerProfile.UnitClass.Speaks(dialogPresence.DialogIdentifier);
			}
		}
		else
		{
			DialogPresence dialogPresence2 = this.DialogCollections.WeightedRandomSelect<DialogPresence>();
			if (dialogPresence2.SpecificUnit != null)
			{
				dialogPresence2.SpecificUnit.Value.Speaks(dialogPresence2.DialogIdentifier);
			}
			else if (adventurerProfiles.Any<AdventurerProfile>())
			{
				AdventurerProfile adventurer = adventurerProfiles[UnityEngine.Random.Range(0, adventurerProfiles.Count)];
				adventurer.GuarranteeTownSpeakAndRandomLater(this.DialogCollections.WeightedRandomSelect<DialogPresence>().DialogIdentifier, 0.05f);
			}
		}
	}

	// Token: 0x060042DD RID: 17117 RVA: 0x001B4B9E File Offset: 0x001B2F9E
	[CompilerGenerated]
	private static bool <Run>m__0(DialogPresence d)
	{
		return !d.DialogIdentifier.HasBeenSpokenFor(1);
	}

	// Token: 0x040032E9 RID: 13033
	[CompilerGenerated]
	private static Func<DialogPresence, bool> <>f__am$cache0;

	// Token: 0x02001003 RID: 4099
	[CompilerGenerated]
	private sealed class <QuestIsActive>c__AnonStorey0
	{
		// Token: 0x060067C6 RID: 26566 RVA: 0x001B4BAF File Offset: 0x001B2FAF
		public <QuestIsActive>c__AnonStorey0()
		{
		}

		// Token: 0x060067C7 RID: 26567 RVA: 0x001B4BB7 File Offset: 0x001B2FB7
		internal bool <>m__0(Quest q)
		{
			return q.QuestIdentifier == this.type && !q.Completed;
		}

		// Token: 0x040061CC RID: 25036
		internal QuestIdentifier type;
	}
}
