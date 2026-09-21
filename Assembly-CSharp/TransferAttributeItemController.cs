using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200019D RID: 413
public class TransferAttributeItemController : MonoBehaviour
{
	// Token: 0x06000AFA RID: 2810 RVA: 0x00083E8C File Offset: 0x0008228C
	public TransferAttributeItemController()
	{
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x00083E94 File Offset: 0x00082294
	public void Init(List<ISpecialEffectDataLoad> specialEffects, bool canTransfer)
	{
		this._specialEffects = specialEffects;
		IEnumerator enumerator = this.AttributeContainer.GetEnumerator();
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
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in specialEffects)
		{
			TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.AttributeTextPre);
			textMeshProUGUI.text = specialEffectDataLoad.GetDescription().Details1;
			textMeshProUGUI.color = ((!specialEffectDataLoad.IsStarEffect()) ? ColorPicker.Legendary : ColorPicker.Yellow);
			textMeshProUGUI.transform.SetParent(this.AttributeContainer, false);
			this.Background.color = ((!canTransfer) ? this.AvailablePropertyColor : this.SelectablePropertyColor);
			this.AttributeButton.interactable = canTransfer;
		}
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x00083FC8 File Offset: 0x000823C8
	public void SelectAttribute()
	{
		base.GetComponentInParent<EffectTransferPanelController>().SelectEffects(this._specialEffects);
	}

	// Token: 0x04000D91 RID: 3473
	public Transform AttributeContainer;

	// Token: 0x04000D92 RID: 3474
	public TextMeshProUGUI AttributeTextPre;

	// Token: 0x04000D93 RID: 3475
	public Image Background;

	// Token: 0x04000D94 RID: 3476
	public Button AttributeButton;

	// Token: 0x04000D95 RID: 3477
	public Color AvailablePropertyColor;

	// Token: 0x04000D96 RID: 3478
	public Color SelectablePropertyColor;

	// Token: 0x04000D97 RID: 3479
	public List<ISpecialEffectDataLoad> _specialEffects;
}
