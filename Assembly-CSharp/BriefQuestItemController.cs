using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class BriefQuestItemController : MonoBehaviour
{
	// Token: 0x06000ECD RID: 3789 RVA: 0x00091D83 File Offset: 0x00090183
	public BriefQuestItemController()
	{
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x00091D8B File Offset: 0x0009018B
	public void Init(Quest quest)
	{
		this._quest = quest;
		this.QuestTitle.text = quest.GetDescription().Title;
		this.UpdateRequirement();
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x00091DB0 File Offset: 0x000901B0
	public void UpdateRequirement()
	{
		this.ResetRequirements();
		foreach (QuestRequirementBase questRequirementBase in this._quest.QuestRequirements)
		{
			QuestRequirementController questRequirementController = UnityEngine.Object.Instantiate<QuestRequirementController>(this.BriefRequirementItemPre);
			questRequirementController.Init(questRequirementBase.Fullfilled(this._quest), questRequirementBase.GetDescription().Details1);
			questRequirementController.transform.SetParent(this.RequirementContainer, false);
		}
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x00091E4C File Offset: 0x0009024C
	private void ResetRequirements()
	{
		IEnumerator enumerator = this.RequirementContainer.GetEnumerator();
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

	// Token: 0x04001035 RID: 4149
	public TextMeshProUGUI QuestTitle;

	// Token: 0x04001036 RID: 4150
	public Transform RequirementContainer;

	// Token: 0x04001037 RID: 4151
	public QuestRequirementController BriefRequirementItemPre;

	// Token: 0x04001038 RID: 4152
	private Quest _quest;
}
