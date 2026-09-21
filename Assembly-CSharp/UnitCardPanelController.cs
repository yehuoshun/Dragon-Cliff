using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001A8 RID: 424
public class UnitCardPanelController : MonoBehaviour
{
	// Token: 0x06000B31 RID: 2865 RVA: 0x00084D32 File Offset: 0x00083132
	public UnitCardPanelController()
	{
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x00084D3C File Offset: 0x0008313C
	public void Init(List<CardUpgrade> cards, List<CardUpgrade> unAssingedCards = null)
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		IEnumerator enumerator = this.CardContainer.GetEnumerator();
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
		if (unAssingedCards != null)
		{
			UnassignedCardController unassignedCardController = UnityEngine.Object.Instantiate<UnassignedCardController>(this.UnassignedCardPre);
			unassignedCardController.Init(unAssingedCards[0]);
			unassignedCardController.transform.SetParent(this.CardContainer, false);
		}
		cards = (from c in cards
		orderby c.UpgradeLevelIndex
		select c).ToList<CardUpgrade>();
		foreach (CardUpgrade card in cards)
		{
			UpgradeCardController upgradeCardController = UnityEngine.Object.Instantiate<UpgradeCardController>(this.CardPre);
			upgradeCardController.Init(card, componentInParent.SelectedHero.AdventurerProfile);
			upgradeCardController.transform.SetParent(this.CardContainer, false);
		}
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x00084E80 File Offset: 0x00083280
	public void ShowRerollCardComfirmPanel(double price)
	{
		this.RerollCardComfirmPanel.Init(UIComponentType.HeroMenuRerollCardComfirmText.GetName().ReplaceToBuilder(UIComponentKey.Money, price.ToGameCurrency()).ToString());
		this.RerollCardComfirmPanel.gameObject.SetActive(true);
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x00084EBD File Offset: 0x000832BD
	public void HideRerollCardComfirmPanel()
	{
		this.RerollCardComfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x00084ED0 File Offset: 0x000832D0
	public void DisplayCard(CardUpgrade card)
	{
		this.ViewCard.Init(card);
		this.ViewCard.gameObject.SetActive(true);
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x00084EEF File Offset: 0x000832EF
	public void HideDisplayCard()
	{
		this.ViewCard.gameObject.SetActive(false);
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x00084F02 File Offset: 0x00083302
	[CompilerGenerated]
	private static int <Init>m__0(CardUpgrade c)
	{
		return c.UpgradeLevelIndex;
	}

	// Token: 0x04000DB6 RID: 3510
	public Transform CardContainer;

	// Token: 0x04000DB7 RID: 3511
	public UpgradeCardController CardPre;

	// Token: 0x04000DB8 RID: 3512
	public UnassignedCardController UnassignedCardPre;

	// Token: 0x04000DB9 RID: 3513
	public ViewCardController ViewCard;

	// Token: 0x04000DBA RID: 3514
	public RerollCardComfirmPanelController RerollCardComfirmPanel;

	// Token: 0x04000DBB RID: 3515
	[CompilerGenerated]
	private static Func<CardUpgrade, int> <>f__am$cache0;
}
