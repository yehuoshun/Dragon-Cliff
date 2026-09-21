using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class NotificationPanelController : MonoBehaviour
{
	// Token: 0x06001103 RID: 4355 RVA: 0x000997C3 File Offset: 0x00097BC3
	public NotificationPanelController()
	{
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x000997D6 File Offset: 0x00097BD6
	private void Awake()
	{
		if (NotificationPanelController.Instance == null)
		{
			NotificationPanelController.Instance = this;
		}
		this._rectTran = base.GetComponent<RectTransform>();
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x000997FC File Offset: 0x00097BFC
	private void Update()
	{
		if (this._completedQuests.Count > 0 && this._canAppear)
		{
			if (this._rectTran.anchoredPosition == Vector2.zero)
			{
				this._appearTimer = 0f;
				this._canAppear = false;
			}
			else
			{
				this._appearTimer += Time.deltaTime;
				this._rectTran.anchoredPosition = Vector3.Lerp(this._hidePosition, Vector3.zero, this._appearTimer);
			}
		}
		if (this._canHide)
		{
			if (this._rectTran.anchoredPosition == this._hidePosition)
			{
				this._hideTimer = 0f;
				this._canHide = false;
				this._completedQuests.RemoveAt(0);
				if (this._completedQuests.Count > 0)
				{
					this.DisplayQuest(this._completedQuests[0]);
				}
			}
			else
			{
				this._hideTimer += Time.deltaTime;
				this._rectTran.anchoredPosition = Vector3.Lerp(Vector3.zero, this._hidePosition, this._hideTimer);
			}
		}
	}

	// Token: 0x06001106 RID: 4358 RVA: 0x0009993C File Offset: 0x00097D3C
	public void CompleteQuest()
	{
		if (this._completedQuests.Count > 0)
		{
			GameWorld.instance.PlayerProfile.CompleteQuest(this._completedQuests[0]);
		}
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x0009996C File Offset: 0x00097D6C
	private void DisplayQuest(Quest quest)
	{
		this.Description.text = UIComponentType.TownManagerQuestCompleted.GetName().ReplaceToBuilder(UIComponentKey.QuestTitle, quest.GetDescription().Title).ToString();
		this.ClaimButton.SetActive(true);
		this._hidePosition = new Vector3(0f, this._rectTran.rect.height * base.GetComponentInParent<Canvas>().scaleFactor);
		this._canAppear = true;
	}

	// Token: 0x06001108 RID: 4360 RVA: 0x000999EF File Offset: 0x00097DEF
	public void AddDisplayQuest(Quest quest)
	{
		this._completedQuests.Add(quest);
		if (this._completedQuests.Count == 1)
		{
			this.DisplayQuest(quest);
		}
	}

	// Token: 0x06001109 RID: 4361 RVA: 0x00099A15 File Offset: 0x00097E15
	public void Init(string description)
	{
		this.Description.text = description;
		this.Animator.SetTrigger("Appear");
	}

	// Token: 0x0600110A RID: 4362 RVA: 0x00099A34 File Offset: 0x00097E34
	public void QuestCompleted(Quest quest)
	{
		if (this._completedQuests.IndexOf(quest) == 0)
		{
			this._canHide = true;
		}
	}

	// Token: 0x040011F9 RID: 4601
	public static NotificationPanelController Instance;

	// Token: 0x040011FA RID: 4602
	public Animator Animator;

	// Token: 0x040011FB RID: 4603
	public TextMeshProUGUI Description;

	// Token: 0x040011FC RID: 4604
	public GameObject ClaimButton;

	// Token: 0x040011FD RID: 4605
	private readonly List<Quest> _completedQuests = new List<Quest>();

	// Token: 0x040011FE RID: 4606
	private float _appearTimer;

	// Token: 0x040011FF RID: 4607
	private float _hideTimer;

	// Token: 0x04001200 RID: 4608
	private RectTransform _rectTran;

	// Token: 0x04001201 RID: 4609
	private Vector2 _hidePosition;

	// Token: 0x04001202 RID: 4610
	private bool _canAppear;

	// Token: 0x04001203 RID: 4611
	private bool _canHide;
}
