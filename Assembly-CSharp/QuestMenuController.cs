using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200023D RID: 573
public class QuestMenuController : MonoBehaviour
{
	// Token: 0x06000EDD RID: 3805 RVA: 0x000923DD File Offset: 0x000907DD
	public QuestMenuController()
	{
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x000923F0 File Offset: 0x000907F0
	public void Init()
	{
		this.Reset();
	}

	// Token: 0x06000EDF RID: 3807 RVA: 0x000923F8 File Offset: 0x000907F8
	public void PlayImportantQuestClip()
	{
		this.PlaySoundClip(this.ImportantQuestClip);
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x00092408 File Offset: 0x00090808
	public void TryUpdate()
	{
		List<Quest> quests = GameWorld.instance.PlayerProfile.GetProgress(null).Quests;
		int num = 0;
		foreach (Quest quest in quests)
		{
			foreach (QuestRequirementBase questRequirement in quest.QuestRequirements)
			{
				if (this._questRequirements.Count > num)
				{
					if (this._questRequirements[num] != questRequirement.GetDescription().Details1)
					{
						this.UpdateQuestList();
					}
					num++;
				}
			}
		}
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x000924FC File Offset: 0x000908FC
	private void OnEnable()
	{
		this.Reset();
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x00092504 File Offset: 0x00090904
	public void UpdateQuestRequirements()
	{
		this.QuestInfo.UpdateRequirement();
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x00092514 File Offset: 0x00090914
	public void UpdateQuestList()
	{
		List<Quest> quests = GameWorld.instance.PlayerProfile.GetProgress(null).Quests;
		this._questRequirements = new List<string>();
		quests.ForEach(delegate(Quest q)
		{
			q.QuestRequirements.ForEach(delegate(QuestRequirementBase r)
			{
				this._questRequirements.Add(r.GetDescription().Details1);
			});
		});
		List<Quest> list = (from q in quests
		where !q.Rewarded && !q.Cancelled && !q.HasExpired()
		select q).ToList<Quest>();
		IEnumerable<PageQuest> source = from q in list
		select new PageQuest
		{
			Id = q.Id,
			Quest = q
		};
		this.QuestPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
		this.BriefPanel.Init(list);
		this.UpdateNewQuestIndicatorStatus();
		if (this._selectedQuest != null)
		{
			this.QuestInfo.Init(this._selectedQuest.Quest);
		}
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x000925F4 File Offset: 0x000909F4
	public void SelecteQuest(PageQuest quest)
	{
		if (quest == null)
		{
			return;
		}
		quest.Quest.IsNew = false;
		this._selectedQuest = quest;
		this.UpdateQuestList();
		this.QuestPage.SelectElement(quest);
		this.QuestInfo.Init(quest.Quest);
		this.QuestInfoSub.SetActive(true);
		this.QuestSlideAnim.SetTrigger("Appear");
		this.UpdateNewQuestIndicatorStatus();
		this.InfoScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x00092670 File Offset: 0x00090A70
	public void CancelQuest()
	{
		if (this._selectedQuest == null)
		{
			return;
		}
		this._selectedQuest.Quest.Cancel();
		this.Reset();
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x00092694 File Offset: 0x00090A94
	public void CompleteQuest()
	{
		if (this._selectedQuest == null)
		{
			return;
		}
		GameWorld.instance.PlayerProfile.CompleteQuest(this._selectedQuest.Quest);
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x000926BC File Offset: 0x00090ABC
	public void Completed(QuestCompletedEvent quest)
	{
		this.CompleteQuestPanel.Init(quest.Quest.Rewards, quest.Quest);
		this.CompleteQuestPanel.gameObject.SetActive(true);
		this.Reset();
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x000926F1 File Offset: 0x00090AF1
	private void Reset()
	{
		this._selectedQuest = null;
		this.QuestInfo.Hide();
		this.QuestInfoSub.SetActive(false);
		this.QuestPage.DiselectAllElement();
		this.UpdateQuestList();
	}

	// Token: 0x06000EE9 RID: 3817 RVA: 0x00092724 File Offset: 0x00090B24
	public void UpdateNewQuestIndicatorStatus()
	{
		this.QuestNotifyPoint.SetActive(this.QuestPage.PageElements.Any((PageElement p) => ((PageQuest)p).Quest.IsNew));
		this.QuestCompletedNotifyPoint.SetActive(this.QuestPage.PageElements.Any((PageElement p) => ((PageQuest)p).Quest.Completed));
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x000927A1 File Offset: 0x00090BA1
	[CompilerGenerated]
	private void <UpdateQuestList>m__0(Quest q)
	{
		q.QuestRequirements.ForEach(delegate(QuestRequirementBase r)
		{
			this._questRequirements.Add(r.GetDescription().Details1);
		});
	}

	// Token: 0x06000EEB RID: 3819 RVA: 0x000927BA File Offset: 0x00090BBA
	[CompilerGenerated]
	private static bool <UpdateQuestList>m__1(Quest q)
	{
		return !q.Rewarded && !q.Cancelled && !q.HasExpired();
	}

	// Token: 0x06000EEC RID: 3820 RVA: 0x000927E0 File Offset: 0x00090BE0
	[CompilerGenerated]
	private static PageQuest <UpdateQuestList>m__2(Quest q)
	{
		return new PageQuest
		{
			Id = q.Id,
			Quest = q
		};
	}

	// Token: 0x06000EED RID: 3821 RVA: 0x00092807 File Offset: 0x00090C07
	[CompilerGenerated]
	private static bool <UpdateNewQuestIndicatorStatus>m__3(PageElement p)
	{
		return ((PageQuest)p).Quest.IsNew;
	}

	// Token: 0x06000EEE RID: 3822 RVA: 0x00092819 File Offset: 0x00090C19
	[CompilerGenerated]
	private static bool <UpdateNewQuestIndicatorStatus>m__4(PageElement p)
	{
		return ((PageQuest)p).Quest.Completed;
	}

	// Token: 0x06000EEF RID: 3823 RVA: 0x0009282B File Offset: 0x00090C2B
	[CompilerGenerated]
	private void <UpdateQuestList>m__5(QuestRequirementBase r)
	{
		this._questRequirements.Add(r.GetDescription().Details1);
	}

	// Token: 0x04001046 RID: 4166
	public QuestPaginationController QuestPage;

	// Token: 0x04001047 RID: 4167
	public QuestInfoController QuestInfo;

	// Token: 0x04001048 RID: 4168
	public GameObject QuestInfoSub;

	// Token: 0x04001049 RID: 4169
	public GameObject QuestNotifyPoint;

	// Token: 0x0400104A RID: 4170
	public GameObject QuestCompletedNotifyPoint;

	// Token: 0x0400104B RID: 4171
	public Animator QuestSlideAnim;

	// Token: 0x0400104C RID: 4172
	public ScrollRect InfoScrollRect;

	// Token: 0x0400104D RID: 4173
	public QuestRewardPanelController CompleteQuestPanel;

	// Token: 0x0400104E RID: 4174
	public QuestBriefPanelController BriefPanel;

	// Token: 0x0400104F RID: 4175
	public AudioClip ImportantQuestClip;

	// Token: 0x04001050 RID: 4176
	private PageQuest _selectedQuest;

	// Token: 0x04001051 RID: 4177
	private List<string> _questRequirements = new List<string>();

	// Token: 0x04001052 RID: 4178
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache0;

	// Token: 0x04001053 RID: 4179
	[CompilerGenerated]
	private static Func<Quest, PageQuest> <>f__am$cache1;

	// Token: 0x04001054 RID: 4180
	[CompilerGenerated]
	private static Func<PageElement, bool> <>f__am$cache2;

	// Token: 0x04001055 RID: 4181
	[CompilerGenerated]
	private static Func<PageElement, bool> <>f__am$cache3;
}
