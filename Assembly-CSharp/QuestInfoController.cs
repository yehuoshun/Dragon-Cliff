using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200023C RID: 572
public class QuestInfoController : MonoBehaviour
{
	// Token: 0x06000ED5 RID: 3797 RVA: 0x00091FC0 File Offset: 0x000903C0
	public QuestInfoController()
	{
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x00091FC8 File Offset: 0x000903C8
	public void Init(Quest quest)
	{
		this.Reset();
		this._quest = quest;
		Description description = quest.GetDescription();
		string text = description.Title;
		if (quest.QuestIdentifier.IsMainQuest())
		{
			text = ColorPicker.GetNegativeColoredString("[" + UIComponentType.QuestInfoMainQuestTitle.GetName() + "]") + text;
		}
		this.Title.text = text;
		this.Description.text = description.Details1;
		this.ResetRequirements();
		foreach (QuestRequirementBase questRequirementBase in quest.QuestRequirements)
		{
			QuestRequirementController questRequirementController = UnityEngine.Object.Instantiate<QuestRequirementController>(this.RequirementItemPre);
			questRequirementController.Init(questRequirementBase.Fullfilled(quest), questRequirementBase.GetDescription().Details1);
			questRequirementController.transform.SetParent(this.RequirementsTran, false);
		}
		this.Grade.text = quest.Grade.GetDescription().Title;
		this.Grade.color = ColorPicker.GetGradeColor(quest.Grade, false);
		quest.Rewards.ForEach(delegate(QuestRewardBase r)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.RewardItemPre);
			gameObject.GetComponent<RewardItemController>().Init(r, this._quest);
			gameObject.transform.SetParent(this.RewardsTransform, false);
		});
		this.CompleteButton.gameObject.SetActive(quest.Completed);
		int? endingGameDay = quest.EndingGameDay;
		int? num = (endingGameDay == null) ? null : new int?(endingGameDay.GetValueOrDefault() - GameWorld.instance.PlayerProfile.GameDays);
		if (num != null)
		{
			TMP_Text timeRemaining = this.TimeRemaining;
			string name = UIComponentType.QuestInfoTimeRemaining.GetName();
			string remainingDays = UIComponentKey.RemainingDays;
			int? endingGameDay2 = quest.EndingGameDay;
			timeRemaining.text = name.ReplaceToBuilder(remainingDays, ((endingGameDay2 == null) ? null : new int?(endingGameDay2.GetValueOrDefault() - GameWorld.instance.PlayerProfile.GameDays)).ToString()).ToString();
		}
		else
		{
			this.TimeRemaining.text = UIComponentType.QuestInfoNoLimitedTime.GetName();
		}
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x000921FC File Offset: 0x000905FC
	public void UpdateSelectedQuest()
	{
		if (this._quest != null)
		{
			this.Init(this._quest);
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x00092218 File Offset: 0x00090618
	public void UpdateRequirement()
	{
		this.ResetRequirements();
		foreach (QuestRequirementBase questRequirementBase in this._quest.QuestRequirements)
		{
			QuestRequirementController questRequirementController = UnityEngine.Object.Instantiate<QuestRequirementController>(this.RequirementItemPre);
			questRequirementController.Init(questRequirementBase.Fullfilled(this._quest), questRequirementBase.GetDescription().Details1);
			questRequirementController.transform.SetParent(this.RequirementsTran, false);
		}
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x000922B4 File Offset: 0x000906B4
	private void ResetRequirements()
	{
		IEnumerator enumerator = this.RequirementsTran.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x00092320 File Offset: 0x00090720
	public void Hide()
	{
		this.CompleteButton.gameObject.SetActive(false);
	}

	// Token: 0x06000EDB RID: 3803 RVA: 0x00092334 File Offset: 0x00090734
	public void Reset()
	{
		IEnumerator enumerator = this.RewardsTransform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x000923A0 File Offset: 0x000907A0
	[CompilerGenerated]
	private void <Init>m__0(QuestRewardBase r)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.RewardItemPre);
		gameObject.GetComponent<RewardItemController>().Init(r, this._quest);
		gameObject.transform.SetParent(this.RewardsTransform, false);
	}

	// Token: 0x0400103B RID: 4155
	public TextMeshProUGUI Title;

	// Token: 0x0400103C RID: 4156
	public TextMeshProUGUI Grade;

	// Token: 0x0400103D RID: 4157
	public TextMeshProUGUI TimeRemaining;

	// Token: 0x0400103E RID: 4158
	public TextMeshProUGUI Description;

	// Token: 0x0400103F RID: 4159
	public Transform RequirementsTran;

	// Token: 0x04001040 RID: 4160
	public Button CompleteButton;

	// Token: 0x04001041 RID: 4161
	public TextMeshProUGUI CancelButtonText;

	// Token: 0x04001042 RID: 4162
	public Transform RewardsTransform;

	// Token: 0x04001043 RID: 4163
	public GameObject RewardItemPre;

	// Token: 0x04001044 RID: 4164
	public QuestRequirementController RequirementItemPre;

	// Token: 0x04001045 RID: 4165
	private Quest _quest;
}
