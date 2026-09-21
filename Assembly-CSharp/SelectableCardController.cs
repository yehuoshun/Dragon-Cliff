using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001A6 RID: 422
public class SelectableCardController : ViewCardController, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B26 RID: 2854 RVA: 0x00084C5A File Offset: 0x0008305A
	public SelectableCardController()
	{
	}

	// Token: 0x06000B27 RID: 2855 RVA: 0x00084C62 File Offset: 0x00083062
	private void Start()
	{
		this._originalColor = this.GlowImage.color;
	}

	// Token: 0x06000B28 RID: 2856 RVA: 0x00084C75 File Offset: 0x00083075
	public void Appear()
	{
		base.GetComponent<Animator>().SetTrigger("Appear");
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x00084C87 File Offset: 0x00083087
	public void Disappear()
	{
		base.GetComponent<Animator>().SetTrigger("Disappear");
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x00084C99 File Offset: 0x00083099
	public void Selected()
	{
		base.GetComponent<Animator>().SetTrigger("Selected");
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x00084CAB File Offset: 0x000830AB
	public virtual void Select()
	{
		base.GetComponentInParent<ChooseCardPanelController>().SelectCard(this.Card);
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x00084CBE File Offset: 0x000830BE
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.GlowImage.color = Color.green;
		base.GetComponent<Animator>().SetBool("MouseOver", true);
	}

	// Token: 0x06000B2D RID: 2861 RVA: 0x00084CE1 File Offset: 0x000830E1
	public void OnPointerExit(PointerEventData eventData)
	{
		this.GlowImage.color = this._originalColor;
		base.GetComponent<Animator>().SetBool("MouseOver", false);
	}

	// Token: 0x04000DB3 RID: 3507
	public Image GlowImage;

	// Token: 0x04000DB4 RID: 3508
	private Color _originalColor;
}
