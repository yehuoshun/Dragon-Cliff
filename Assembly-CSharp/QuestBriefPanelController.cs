using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class QuestBriefPanelController : MonoBehaviour
{
	// Token: 0x06000ED1 RID: 3793 RVA: 0x00091EB8 File Offset: 0x000902B8
	public QuestBriefPanelController()
	{
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x00091EC0 File Offset: 0x000902C0
	private void Update()
	{
		TownManager.Instance.Ui.QuestMenu.TryUpdate();
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x00091ED8 File Offset: 0x000902D8
	public void Init(List<Quest> quests)
	{
		this.ResetContainer();
		foreach (Quest quest in quests)
		{
			BriefQuestItemController briefQuestItemController = UnityEngine.Object.Instantiate<BriefQuestItemController>(this.BriefQuestPre);
			briefQuestItemController.Init(quest);
			briefQuestItemController.transform.SetParent(this.QuestContainer, false);
		}
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x00091F54 File Offset: 0x00090354
	private void ResetContainer()
	{
		IEnumerator enumerator = this.QuestContainer.GetEnumerator();
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

	// Token: 0x04001039 RID: 4153
	public Transform QuestContainer;

	// Token: 0x0400103A RID: 4154
	public BriefQuestItemController BriefQuestPre;
}
