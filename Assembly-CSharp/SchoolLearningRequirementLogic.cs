using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004F5 RID: 1269
[Serializable]
public class SchoolLearningRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025B4 RID: 9652 RVA: 0x001112D4 File Offset: 0x0010F6D4
	public SchoolLearningRequirementLogic()
	{
	}

	// Token: 0x1700029C RID: 668
	// (get) Token: 0x060025B5 RID: 9653 RVA: 0x001112E4 File Offset: 0x0010F6E4
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x060025B6 RID: 9654 RVA: 0x001112EC File Offset: 0x0010F6EC
	public override bool Fullfilled(Quest quest)
	{
		return this.FFilled;
	}

	// Token: 0x060025B7 RID: 9655 RVA: 0x001112F4 File Offset: 0x0010F6F4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025B8 RID: 9656 RVA: 0x001112FC File Offset: 0x0010F6FC
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventurerSkillLevelsUp && !this.FFilled)
		{
			this.CurrentCount++;
			if (this.RequiredAmount <= this.CurrentCount)
			{
				this.FFilled = true;
			}
		}
		if (evt == GameWorldEvent.GameDaysChanged && !this.FFilled && GameWorld.instance.PlayerProfile.SkillLevels != null && GameWorld.instance.PlayerProfile.SkillLevels.Any<KeyValuePair<SkillType, int>>())
		{
			int num = (from s in GameWorld.instance.PlayerProfile.SkillLevels
			select s.Value).Sum((int s) => s - 1);
			if (num > 0 && this.CurrentCount < num)
			{
				this.CurrentCount = num;
				if (this.RequiredAmount <= this.CurrentCount)
				{
					this.FFilled = true;
				}
			}
		}
	}

	// Token: 0x060025B9 RID: 9657 RVA: 0x00111408 File Offset: 0x0010F808
	[CompilerGenerated]
	private static int <ProcessGameEvent>m__0(KeyValuePair<SkillType, int> s)
	{
		return s.Value;
	}

	// Token: 0x060025BA RID: 9658 RVA: 0x00111411 File Offset: 0x0010F811
	[CompilerGenerated]
	private static int <ProcessGameEvent>m__1(int s)
	{
		return s - 1;
	}

	// Token: 0x04002071 RID: 8305
	private readonly QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.SchoolLearningRequirement;

	// Token: 0x04002072 RID: 8306
	public bool FFilled;

	// Token: 0x04002073 RID: 8307
	public int CurrentCount;

	// Token: 0x04002074 RID: 8308
	public int RequiredAmount;

	// Token: 0x04002075 RID: 8309
	[CompilerGenerated]
	private static Func<KeyValuePair<SkillType, int>, int> <>f__am$cache0;

	// Token: 0x04002076 RID: 8310
	[CompilerGenerated]
	private static Func<int, int> <>f__am$cache1;
}
