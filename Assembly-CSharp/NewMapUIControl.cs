using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000335 RID: 821
public class NewMapUIControl : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060015CB RID: 5579 RVA: 0x000ACD0E File Offset: 0x000AB10E
	public NewMapUIControl()
	{
	}

	// Token: 0x060015CC RID: 5580 RVA: 0x000ACD16 File Offset: 0x000AB116
	private void Start()
	{
		this.CloseButton.onClick.AddListener(new UnityAction(this.CloseMap));
	}

	// Token: 0x060015CD RID: 5581 RVA: 0x000ACD34 File Offset: 0x000AB134
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.CloseMap();
		}
	}

	// Token: 0x060015CE RID: 5582 RVA: 0x000ACD48 File Offset: 0x000AB148
	private void CloseMap()
	{
	}

	// Token: 0x040015E7 RID: 5607
	public Button CloseButton;
}
