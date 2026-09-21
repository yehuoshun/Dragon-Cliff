using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003A2 RID: 930
public class RequirementControl : MonoBehaviour
{
	// Token: 0x060018D3 RID: 6355 RVA: 0x000BF611 File Offset: 0x000BDA11
	public RequirementControl()
	{
	}

	// Token: 0x060018D4 RID: 6356 RVA: 0x000BF61C File Offset: 0x000BDA1C
	private void Start()
	{
		if (GameWorld.instance != null)
		{
			PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
			playerProfile.GameWorldEventTriggered = (Action<GameWorldEvent, object>)Delegate.Combine(playerProfile.GameWorldEventTriggered, new Action<GameWorldEvent, object>(this.PlayerProfile_GameWorldEventTriggered));
		}
		this.NotCompleted();
	}

	// Token: 0x060018D5 RID: 6357 RVA: 0x000BF66A File Offset: 0x000BDA6A
	private void PlayerProfile_GameWorldEventTriggered(GameWorldEvent arg1, object arg2)
	{
		if (this._requirement != null && !this._isCompleted)
		{
			this.SwitchOnType(this._requirement);
		}
	}

	// Token: 0x060018D6 RID: 6358 RVA: 0x000BF68E File Offset: 0x000BDA8E
	public void SetRequirement(QuestRequirementBase require, Quest quest)
	{
		this._requirement = require;
		this._quest = quest;
		this.SetupImageForRequirement(require);
	}

	// Token: 0x060018D7 RID: 6359 RVA: 0x000BF6A8 File Offset: 0x000BDAA8
	private void SetupImageForRequirement(QuestRequirementBase require)
	{
		switch (require.CorrespondingQuestRequirementType)
		{
		case QuestRequirementType.ObtainResource:
		{
			ObtainResourceRequirementLogic obtain = require as ObtainResourceRequirementLogic;
			this.ObtainRequirementImage(obtain);
			break;
		}
		}
	}

	// Token: 0x060018D8 RID: 6360 RVA: 0x000BF6F8 File Offset: 0x000BDAF8
	private void SwitchOnType(QuestRequirementBase require)
	{
		this.CheckCompletion(require);
		switch (require.CorrespondingQuestRequirementType)
		{
		case QuestRequirementType.ObtainResource:
		{
			ObtainResourceRequirementLogic obtain = require as ObtainResourceRequirementLogic;
			this.UpdateObtainRequirement(obtain);
			break;
		}
		}
	}

	// Token: 0x060018D9 RID: 6361 RVA: 0x000BF74C File Offset: 0x000BDB4C
	private void ObtainRequirementImage(ObtainResourceRequirementLogic obtain)
	{
		this._itemImage.sprite = FilePath.GetRecipeImage(obtain.GetQuestDesiredResourceType());
		this._desc.text = obtain.CorrespondingQuestRequirementType.GetDescription().Title + " : " + obtain.GetQuestDesiredResourceType().GetDescription().Title;
		this.UpdateObtainRequirement(obtain);
	}

	// Token: 0x060018DA RID: 6362 RVA: 0x000BF7AC File Offset: 0x000BDBAC
	private void UpdateObtainRequirement(ObtainResourceRequirementLogic obtain)
	{
		this._aim.text = obtain.ObtainedRelevantResource.Sum((ResourceUpdate c) => c.ChangeAmount) + " / " + obtain.RequiredAmount;
	}

	// Token: 0x060018DB RID: 6363 RVA: 0x000BF806 File Offset: 0x000BDC06
	private void CheckCompletion(QuestRequirementBase requirement)
	{
		if (this._quest != null && requirement.Fullfilled(this._quest))
		{
			this.Completed();
		}
	}

	// Token: 0x060018DC RID: 6364 RVA: 0x000BF82A File Offset: 0x000BDC2A
	private void Completed()
	{
		this._checkImage.color = Color.green;
		this._checkMark.gameObject.SetActive(true);
		this._isCompleted = true;
	}

	// Token: 0x060018DD RID: 6365 RVA: 0x000BF854 File Offset: 0x000BDC54
	private void NotCompleted()
	{
		this._checkImage.color = Color.grey;
		this._checkMark.gameObject.SetActive(false);
		this._isCompleted = false;
	}

	// Token: 0x060018DE RID: 6366 RVA: 0x000BF87E File Offset: 0x000BDC7E
	[CompilerGenerated]
	private static double <UpdateObtainRequirement>m__0(ResourceUpdate c)
	{
		return c.ChangeAmount;
	}

	// Token: 0x040018AA RID: 6314
	private QuestRequirementBase _requirement;

	// Token: 0x040018AB RID: 6315
	private Quest _quest;

	// Token: 0x040018AC RID: 6316
	public Image _itemImage;

	// Token: 0x040018AD RID: 6317
	public Text _desc;

	// Token: 0x040018AE RID: 6318
	public Text _aim;

	// Token: 0x040018AF RID: 6319
	public Image _checkImage;

	// Token: 0x040018B0 RID: 6320
	public Image _checkMark;

	// Token: 0x040018B1 RID: 6321
	private bool _isCompleted;

	// Token: 0x040018B2 RID: 6322
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache0;
}
