using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000161 RID: 353
public class PreviewAdventuererController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000967 RID: 2407 RVA: 0x0007ABE5 File Offset: 0x00078FE5
	public PreviewAdventuererController()
	{
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x0007ABED File Offset: 0x00078FED
	private void Update()
	{
		if (GameWorld.instance.GetCurrentAdventure() == null)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x0007AC0C File Offset: 0x0007900C
	public void UpdateBar(AdventureSnapshot snapShot)
	{
		if (snapShot.CurrentEncounterIndex == 1)
		{
			this.WonPanel.SetActive(false);
			this.LostPanel.SetActive(false);
			this.ClearMonsterPoints();
			if (snapShot.Adventurers.Count > 0)
			{
				this.BattleProgressObj.SetActive(true);
				int count = snapShot.Adventurers[0].CorrespondingUnit.CurrentAdventure.Encounters.Count;
				float width = this.BattleProgressBar.GetComponent<RectTransform>().rect.width;
				float num = width / (float)count;
				for (int i = 1; i < count; i++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MonsterPointPre);
					gameObject.transform.SetParent(this.BattleProgressBar.transform, false);
					gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0.5f);
					gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 0.5f);
					gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(num * (float)i, 0f, 0f);
				}
			}
			for (int j = 0; j < snapShot.Adventurers.Count; j++)
			{
				this.AdventurersCon[j].Init(snapShot.Adventurers[j].CorrespondingUnit.GetUnitType(), snapShot.Adventurers[j].CurrentLife);
				this.AdventurersCon[j].gameObject.SetActive(true);
			}
			for (int k = snapShot.Adventurers.Count; k < this.AdventurersCon.Count; k++)
			{
				this.AdventurersCon[k].gameObject.SetActive(false);
			}
			this._inited = true;
		}
		switch (snapShot.Status)
		{
		case AdventureStatus.Walking:
			break;
		case AdventureStatus.InBattle:
			this.InBattle(snapShot);
			break;
		case AdventureStatus.Won:
			this.Won();
			break;
		case AdventureStatus.Lost:
			this.Lost();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x0007AE44 File Offset: 0x00079244
	private void ClearMonsterPoints()
	{
		IEnumerator enumerator = this.BattleProgressBar.transform.GetEnumerator();
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

	// Token: 0x0600096B RID: 2411 RVA: 0x0007AEB4 File Offset: 0x000792B4
	private void Won()
	{
		this.WonPanel.SetActive(true);
		this.WonPanel.GetComponent<Animator>().SetTrigger("Run");
		this.BattleProgressObj.gameObject.SetActive(false);
		this._inited = false;
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0007AEEF File Offset: 0x000792EF
	private void Lost()
	{
		this.LostPanel.SetActive(true);
		this.LostPanel.GetComponent<Animator>().SetTrigger("Run");
		this.BattleProgressObj.gameObject.SetActive(false);
		this._inited = false;
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x0007AF2C File Offset: 0x0007932C
	public void InBattle(AdventureSnapshot snapShot)
	{
		float fillAmount = (float)snapShot.CurrentEncounterIndex * 1f / (float)snapShot.TotalNumberOfEncounters * 1f;
		this.ProgressBar.fillAmount = fillAmount;
		this.BattleProgressBar.fillAmount = fillAmount;
		for (int i = 0; i < snapShot.Adventurers.Count; i++)
		{
			this.AdventurersCon[i].UpdateDetails(snapShot.Adventurers[i].CurrentLife, snapShot.Adventurers[i].MaxLife);
		}
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x0007AFBC File Offset: 0x000793BC
	public void OnPointerClick(PointerEventData eventData)
	{
		if (BattleManager.instance.IsInCombat || BattleManager.instance.BattleStarted)
		{
			TownManager.Instance.Ui.ShowBattle();
			UIMiscGenerator.Instance.ClearHealthDetails();
		}
	}

	// Token: 0x04000C15 RID: 3093
	public Image ProgressBar;

	// Token: 0x04000C16 RID: 3094
	public Image BattleProgressBar;

	// Token: 0x04000C17 RID: 3095
	public GameObject BattleProgressObj;

	// Token: 0x04000C18 RID: 3096
	public GameObject WonPanel;

	// Token: 0x04000C19 RID: 3097
	public GameObject LostPanel;

	// Token: 0x04000C1A RID: 3098
	public GameObject MonsterPointPre;

	// Token: 0x04000C1B RID: 3099
	public List<BattlePreviewAdventurerController> AdventurersCon;

	// Token: 0x04000C1C RID: 3100
	private bool _inited;
}
