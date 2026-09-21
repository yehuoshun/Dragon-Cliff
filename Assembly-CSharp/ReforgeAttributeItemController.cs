using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000199 RID: 409
public class ReforgeAttributeItemController : MonoBehaviour
{
	// Token: 0x06000AE2 RID: 2786 RVA: 0x0008376B File Offset: 0x00081B6B
	public ReforgeAttributeItemController()
	{
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x00083774 File Offset: 0x00081B74
	public void Init(AttributeModifier attribute)
	{
		this._modifier = attribute;
		this.Background.sprite = this.NormalSprite;
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
		TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.TextPre);
		textMeshProUGUI.text = "+" + attribute.GetDisplayValue().ToDisplayValueFormat() + " " + attribute.AttributeType.GetDescription().Title;
		textMeshProUGUI.transform.SetParent(this.AttributeContainer, false);
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x00083844 File Offset: 0x00081C44
	public void SelectAttribute()
	{
		if (this._modifier == null)
		{
			return;
		}
		ReforgePanelController componentInParent = base.GetComponentInParent<ReforgePanelController>();
		componentInParent.SelectReplacingAttribute(this._modifier);
		ReforgePreSelectAttributeController componentInParent2 = base.GetComponentInParent<ReforgePreSelectAttributeController>();
		if (componentInParent2 != null)
		{
			componentInParent2.SelectAttributes(this._modifier);
		}
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x0008388F File Offset: 0x00081C8F
	public void ChangeFrame(AttributeModifier attribute)
	{
		this.Background.sprite = ((this._modifier != attribute) ? this.NormalSprite : this.SelectedSprite);
	}

	// Token: 0x04000D7B RID: 3451
	public Transform AttributeContainer;

	// Token: 0x04000D7C RID: 3452
	public TextMeshProUGUI TextPre;

	// Token: 0x04000D7D RID: 3453
	public Image Background;

	// Token: 0x04000D7E RID: 3454
	public Sprite NormalSprite;

	// Token: 0x04000D7F RID: 3455
	public Sprite SelectedSprite;

	// Token: 0x04000D80 RID: 3456
	private AttributeModifier _modifier;
}
