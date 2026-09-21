using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020003A0 RID: 928
public class QuestDetailController : MonoBehaviour
{
	// Token: 0x060018C4 RID: 6340 RVA: 0x000BF154 File Offset: 0x000BD554
	public QuestDetailController()
	{
	}

	// Token: 0x060018C5 RID: 6341 RVA: 0x000BF15C File Offset: 0x000BD55C
	private void Start()
	{
		this.CancelThisQuestButton.onClick.AddListener(new UnityAction(this.CancelQuest));
	}

	// Token: 0x060018C6 RID: 6342 RVA: 0x000BF17C File Offset: 0x000BD57C
	public void SetQuest(Quest quest)
	{
		if (this._quest != quest)
		{
			Description description = quest.GetDescription();
			this.Title.text = description.Title;
			this.DetailDesc.text = description.Details1;
			this._quest = quest;
			for (int i = 0; i < this.Requirements.Length; i++)
			{
				if (i < quest.QuestRequirements.Count && quest.QuestRequirements.Count != 0)
				{
					this.Requirements[i].SetRequirement(quest.QuestRequirements[i], quest);
					this.Requirements[i].gameObject.SetActive(true);
				}
				else
				{
					this.Requirements[i].gameObject.SetActive(false);
				}
			}
			for (int j = 0; j < this.Rewards.Length; j++)
			{
			}
		}
	}

	// Token: 0x060018C7 RID: 6343 RVA: 0x000BF25D File Offset: 0x000BD65D
	private void CancelQuest()
	{
		this._quest.Cancel();
		this.DetailDesc.text = this._quest.GetDescription().Details1 + "   Quest Canceled";
	}

	// Token: 0x060018C8 RID: 6344 RVA: 0x000BF290 File Offset: 0x000BD690
	public void EmptyQuest(bool hasQuest)
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			base.transform.GetChild(i).gameObject.SetActive(!hasQuest);
		}
		if (!hasQuest)
		{
			this.Title.gameObject.SetActive(true);
			this.Title.text = "No quest";
		}
	}

	// Token: 0x0400189B RID: 6299
	public Text Title;

	// Token: 0x0400189C RID: 6300
	public Text DetailDesc;

	// Token: 0x0400189D RID: 6301
	public RequirementControl[] Requirements;

	// Token: 0x0400189E RID: 6302
	public RewardsObj[] Rewards;

	// Token: 0x0400189F RID: 6303
	public Button CompleteButton;

	// Token: 0x040018A0 RID: 6304
	private Quest _quest;

	// Token: 0x040018A1 RID: 6305
	public Button CancelThisQuestButton;
}
