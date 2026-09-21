using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004DD RID: 1245
public static class QuestConfigurations
{
	// Token: 0x0600254B RID: 9547 RVA: 0x001103F4 File Offset: 0x0010E7F4
	public static bool IsSpawnableSideQuest(this QuestIdentifier questIdentifier)
	{
		List<QuestIdentifier> source = new List<QuestIdentifier>
		{
			QuestIdentifier.MonsterKill,
			QuestIdentifier.ItemSales,
			QuestIdentifier.HundredBattle
		};
		return source.Any((QuestIdentifier s) => s == questIdentifier);
	}

	// Token: 0x0600254C RID: 9548 RVA: 0x0011043E File Offset: 0x0010E83E
	public static bool IsMainQuest(this QuestIdentifier questIdentifier)
	{
		return questIdentifier.ToString().Contains("Main");
	}

	// Token: 0x0600254D RID: 9549 RVA: 0x00110457 File Offset: 0x0010E857
	// Note: this type is marked as 'beforefieldinit'.
	static QuestConfigurations()
	{
	}

	// Token: 0x04001FE5 RID: 8165
	public static readonly int InitialMainQuestStartingGameDay;

	// Token: 0x02000DB2 RID: 3506
	[CompilerGenerated]
	private sealed class <IsSpawnableSideQuest>c__AnonStorey0
	{
		// Token: 0x06005883 RID: 22659 RVA: 0x00110459 File Offset: 0x0010E859
		public <IsSpawnableSideQuest>c__AnonStorey0()
		{
		}

		// Token: 0x06005884 RID: 22660 RVA: 0x00110461 File Offset: 0x0010E861
		internal bool <>m__0(QuestIdentifier s)
		{
			return s == this.questIdentifier;
		}

		// Token: 0x0400486B RID: 18539
		internal QuestIdentifier questIdentifier;
	}
}
