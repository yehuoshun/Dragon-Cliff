using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200020B RID: 523
public class ManualQuestionItemController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000DD7 RID: 3543 RVA: 0x000900A0 File Offset: 0x0008E4A0
	public ManualQuestionItemController()
	{
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x000900A8 File Offset: 0x0008E4A8
	public void Init(ManualType manualType)
	{
		this._manualType = manualType;
		this.QuestionTitle.text = manualType.GetDescription().Title;
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x000900C7 File Offset: 0x0008E4C7
	public void Select(ManualType selectedType)
	{
		this.SelectedFrame.SetActive(this._manualType == selectedType);
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x000900DD File Offset: 0x0008E4DD
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<ManualMenuController>().SelectQuestion(this._manualType);
	}

	// Token: 0x04000FC8 RID: 4040
	public GameObject SelectedFrame;

	// Token: 0x04000FC9 RID: 4041
	public TextMeshProUGUI QuestionTitle;

	// Token: 0x04000FCA RID: 4042
	private ManualType _manualType;
}
