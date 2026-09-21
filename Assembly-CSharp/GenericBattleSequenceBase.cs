using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200096A RID: 2410
public abstract class GenericBattleSequenceBase
{
	// Token: 0x0600425C RID: 16988 RVA: 0x001AE60C File Offset: 0x001ACA0C
	protected GenericBattleSequenceBase()
	{
	}

	// Token: 0x0600425D RID: 16989
	public abstract bool MetRequirement(BroadcastEvent evt);

	// Token: 0x0600425E RID: 16990
	public abstract IEnumerable Run(BroadcastEvent evt);

	// Token: 0x0600425F RID: 16991 RVA: 0x001AE614 File Offset: 0x001ACA14
	internal bool QuestIsActive(QuestIdentifier type)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == type && !q.Completed);
	}

	// Token: 0x02000FF3 RID: 4083
	[CompilerGenerated]
	private sealed class <QuestIsActive>c__AnonStorey0
	{
		// Token: 0x0600676F RID: 26479 RVA: 0x001AE65C File Offset: 0x001ACA5C
		public <QuestIsActive>c__AnonStorey0()
		{
		}

		// Token: 0x06006770 RID: 26480 RVA: 0x001AE664 File Offset: 0x001ACA64
		internal bool <>m__0(Quest q)
		{
			return q.QuestIdentifier == this.type && !q.Completed;
		}

		// Token: 0x04006163 RID: 24931
		internal QuestIdentifier type;
	}
}
