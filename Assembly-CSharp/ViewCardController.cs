using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001AA RID: 426
public class ViewCardController : MonoBehaviour
{
	// Token: 0x06000B40 RID: 2880 RVA: 0x00084BD8 File Offset: 0x00082FD8
	public ViewCardController()
	{
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x00084BE0 File Offset: 0x00082FE0
	public virtual void Init(CardUpgrade card)
	{
		this.Card = card;
		this.EffectImage.sprite = FilePath.GetUpgradeCardImage(card.CorrespondingCardType);
		Description description = card.GetDescription();
		this.CardTitle.text = description.Title;
		this.CardDescription.text = description.Details1;
		if (this.CardLevel != null)
		{
			this.CardLevel.text = card.UpgradeLevelIndex.ToLevelText();
		}
	}

	// Token: 0x04000DC3 RID: 3523
	public Image EffectImage;

	// Token: 0x04000DC4 RID: 3524
	public TextMeshProUGUI CardTitle;

	// Token: 0x04000DC5 RID: 3525
	public TextMeshProUGUI CardDescription;

	// Token: 0x04000DC6 RID: 3526
	public TextMeshProUGUI CardLevel;

	// Token: 0x04000DC7 RID: 3527
	public CardUpgrade Card;
}
