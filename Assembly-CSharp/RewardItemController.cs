using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000240 RID: 576
public class RewardItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000EF9 RID: 3833 RVA: 0x00092A02 File Offset: 0x00090E02
	public RewardItemController()
	{
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x00092A0C File Offset: 0x00090E0C
	public void Init(QuestRewardBase reward, Quest quest)
	{
		this._reward = reward;
		this._belongsToQuest = quest;
		GuaranteedDirectResourceReward guaranteedDirectResourceReward = (GuaranteedDirectResourceReward)reward;
		this.ItemImage.sprite = FilePath.GetRecipeImage(guaranteedDirectResourceReward.ResourceType);
		this.ItemTitle.text = guaranteedDirectResourceReward.GetDescription(quest).Details1;
		this.Amount.text = guaranteedDirectResourceReward.Amount.DoubleToString();
		this.HeroImage.gameObject.SetActive(false);
		this.ItemImage.gameObject.SetActive(true);
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x00092A94 File Offset: 0x00090E94
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._reward == null)
		{
			return;
		}
		Description description = null;
		GuaranteedDirectResourceReward guaranteedDirectResourceReward = this._reward as GuaranteedDirectResourceReward;
		if (guaranteedDirectResourceReward != null)
		{
			description = guaranteedDirectResourceReward.ResourceType.GetDescription();
		}
		if (description != null)
		{
			this.OpenTooltip(new TooltipItem
			{
				Title = description.Title,
				Image = FilePath.GetRecipeImage((this._reward as GuaranteedDirectResourceReward).ResourceType),
				Description = description.Details1,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x00092B30 File Offset: 0x00090F30
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x0400105C RID: 4188
	public Image ItemImage;

	// Token: 0x0400105D RID: 4189
	public Image HeroImage;

	// Token: 0x0400105E RID: 4190
	public TextMeshProUGUI ItemTitle;

	// Token: 0x0400105F RID: 4191
	public TextMeshProUGUI Amount;

	// Token: 0x04001060 RID: 4192
	private QuestRewardBase _reward;

	// Token: 0x04001061 RID: 4193
	private Quest _belongsToQuest;
}
