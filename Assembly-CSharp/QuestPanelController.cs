using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020003A1 RID: 929
public class QuestPanelController : MonoBehaviour
{
	// Token: 0x060018C9 RID: 6345 RVA: 0x000BF2FA File Offset: 0x000BD6FA
	public QuestPanelController()
	{
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x000BF310 File Offset: 0x000BD710
	private void Awake()
	{
		this.CloseButton.onClick.AddListener(new UnityAction(this.Deactive));
		if (GameWorld.instance != null)
		{
			this._gameWorld = GameWorld.instance;
			List<Quest> quests = this._gameWorld.PlayerProfile.GetProgress(null).Quests;
			if (quests.Count > 0)
			{
				foreach (Quest quest in quests)
				{
					this.InitQuests(quest);
				}
			}
			if (this._breBriefQuestControls.Count > 0)
			{
				this.SetSelectedQuest(this._breBriefQuestControls[0]);
				this._breBriefQuestControls[0].ClickedOn();
			}
		}
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x000BF400 File Offset: 0x000BD800
	public void SetSelectedQuest(BriefQuestControl quest)
	{
		if (this._currentSelectedQuest != quest)
		{
			if (this._currentSelectedQuest != null)
			{
				this._currentSelectedQuest.UnClick();
			}
			this._currentSelectedQuest = quest;
			this.questDetailController.SetQuest(quest.GetQuest());
		}
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000BF454 File Offset: 0x000BD854
	public void LinkUpWithMainUI(Button button)
	{
		GameObject gameObject = button.gameObject;
		this._buttonAnimator = gameObject.GetComponent<Animator>();
	}

	// Token: 0x060018CD RID: 6349 RVA: 0x000BF474 File Offset: 0x000BD874
	public void InitQuests(Quest quest)
	{
		if (quest != null && (from a in this._breBriefQuestControls
		where a.GetQuest().Id == quest.Id
		select a).ToList<BriefQuestControl>().Count == 0)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/Quests/Pieces/BriefQuest") as GameObject, this.BriefQuestsPanel.transform.position, this.BriefQuestsPanel);
			gameObject.transform.localScale = Vector3.one;
			BriefQuestControl component = gameObject.GetComponent<BriefQuestControl>();
			if (component != null)
			{
				component.SetQuest(quest, this);
				this._breBriefQuestControls.Add(component);
			}
		}
		this.CheckEmpty();
	}

	// Token: 0x060018CE RID: 6350 RVA: 0x000BF52C File Offset: 0x000BD92C
	private void CheckEmpty()
	{
		this.EmptyQuest.SetActive(this._breBriefQuestControls.Count == 0);
	}

	// Token: 0x060018CF RID: 6351 RVA: 0x000BF547 File Offset: 0x000BD947
	public void NewQuestArrived()
	{
		this._buttonAnimator.SetBool("NeedToClickOn", true);
	}

	// Token: 0x060018D0 RID: 6352 RVA: 0x000BF55C File Offset: 0x000BD95C
	public void QuestExpireOrCanceled(Quest quest)
	{
		BriefQuestControl briefQuestControl = this._breBriefQuestControls.FirstOrDefault((BriefQuestControl b) => b.GetQuest().Id == quest.Id);
		if (briefQuestControl != null)
		{
			briefQuestControl.QuestRemoved();
		}
		this.CheckEmpty();
	}

	// Token: 0x060018D1 RID: 6353 RVA: 0x000BF5A6 File Offset: 0x000BD9A6
	public void AlreadyReadTheQuest()
	{
		this._buttonAnimator.SetBool("NeedToClickOn", false);
	}

	// Token: 0x060018D2 RID: 6354 RVA: 0x000BF5B9 File Offset: 0x000BD9B9
	private void Deactive()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x040018A2 RID: 6306
	private GameWorld _gameWorld;

	// Token: 0x040018A3 RID: 6307
	public QuestDetailController questDetailController;

	// Token: 0x040018A4 RID: 6308
	public GameObject BriefQuestsPanel;

	// Token: 0x040018A5 RID: 6309
	public Button CloseButton;

	// Token: 0x040018A6 RID: 6310
	public GameObject EmptyQuest;

	// Token: 0x040018A7 RID: 6311
	private Animator _buttonAnimator;

	// Token: 0x040018A8 RID: 6312
	private readonly List<BriefQuestControl> _breBriefQuestControls = new List<BriefQuestControl>();

	// Token: 0x040018A9 RID: 6313
	private BriefQuestControl _currentSelectedQuest;

	// Token: 0x02000CCB RID: 3275
	[CompilerGenerated]
	private sealed class <InitQuests>c__AnonStorey0
	{
		// Token: 0x06005490 RID: 21648 RVA: 0x000BF5C7 File Offset: 0x000BD9C7
		public <InitQuests>c__AnonStorey0()
		{
		}

		// Token: 0x06005491 RID: 21649 RVA: 0x000BF5CF File Offset: 0x000BD9CF
		internal bool <>m__0(BriefQuestControl a)
		{
			return a.GetQuest().Id == this.quest.Id;
		}

		// Token: 0x040041FA RID: 16890
		internal Quest quest;
	}

	// Token: 0x02000CCC RID: 3276
	[CompilerGenerated]
	private sealed class <QuestExpireOrCanceled>c__AnonStorey1
	{
		// Token: 0x06005492 RID: 21650 RVA: 0x000BF5EC File Offset: 0x000BD9EC
		public <QuestExpireOrCanceled>c__AnonStorey1()
		{
		}

		// Token: 0x06005493 RID: 21651 RVA: 0x000BF5F4 File Offset: 0x000BD9F4
		internal bool <>m__0(BriefQuestControl b)
		{
			return b.GetQuest().Id == this.quest.Id;
		}

		// Token: 0x040041FB RID: 16891
		internal Quest quest;
	}
}
