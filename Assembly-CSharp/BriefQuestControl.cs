using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200039E RID: 926
public class BriefQuestControl : MonoBehaviour
{
	// Token: 0x060018B7 RID: 6327 RVA: 0x000BEF0A File Offset: 0x000BD30A
	public BriefQuestControl()
	{
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x000BEF14 File Offset: 0x000BD314
	private void Awake()
	{
		this._background = base.GetComponent<Image>();
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.ClickedOn));
		this._text = base.transform.GetChild(0).GetComponent<Text>();
		this._checkImage = base.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
		this._questStatus = base.transform.GetChild(2).GetComponent<Text>();
		this._checkBoxBackgroundImage = base.transform.GetChild(1).GetComponent<Image>();
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x000BEFBC File Offset: 0x000BD3BC
	private void Update()
	{
		if (this._quest != null && !this._onCompleted && this._quest.Completed)
		{
			this.QuestCompleted();
		}
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x000BEFEA File Offset: 0x000BD3EA
	public Quest GetQuest()
	{
		return this._quest;
	}

	// Token: 0x060018BB RID: 6331 RVA: 0x000BEFF2 File Offset: 0x000BD3F2
	public void ClickedOn()
	{
		this._background.color = Color.yellow;
		this._controller.SetSelectedQuest(this);
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x000BF010 File Offset: 0x000BD410
	public void UnClick()
	{
		this._background.color = Color.white;
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x000BF024 File Offset: 0x000BD424
	public void SetQuest(Quest quest, QuestPanelController controller)
	{
		this._quest = quest;
		this._controller = controller;
		this._text.text = this._quest.GetDescription().Title;
		if (this._quest.Completed)
		{
			this.QuestCompleted();
		}
		else
		{
			this.QuestNotFulfilled();
		}
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x000BF07C File Offset: 0x000BD47C
	private void QuestCompleted()
	{
		this._onCompleted = this._quest.Completed;
		this._checkImage.gameObject.SetActive(true);
		this._checkBoxBackgroundImage.color = Color.green;
		this._questStatus.text = "已完成";
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x000BF0CB File Offset: 0x000BD4CB
	private void QuestNotFulfilled()
	{
		this._checkImage.gameObject.SetActive(false);
		this._checkBoxBackgroundImage.color = Color.yellow;
		this._questStatus.text = "已接受";
	}

	// Token: 0x060018C0 RID: 6336 RVA: 0x000BF0FE File Offset: 0x000BD4FE
	public void QuestRemoved()
	{
		this._checkBoxBackgroundImage.color = Color.red;
		this._questStatus.text = "已取消";
	}

	// Token: 0x04001890 RID: 6288
	private Text _questStatus;

	// Token: 0x04001891 RID: 6289
	private Quest _quest;

	// Token: 0x04001892 RID: 6290
	private Image _checkImage;

	// Token: 0x04001893 RID: 6291
	private Image _checkBoxBackgroundImage;

	// Token: 0x04001894 RID: 6292
	private Image _background;

	// Token: 0x04001895 RID: 6293
	private Button _button;

	// Token: 0x04001896 RID: 6294
	private Text _text;

	// Token: 0x04001897 RID: 6295
	private bool _onCompleted;

	// Token: 0x04001898 RID: 6296
	private QuestPanelController _controller;
}
