using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000184 RID: 388
public class EnchantAttributeItemController : MonoBehaviour
{
	// Token: 0x06000A35 RID: 2613 RVA: 0x0007E867 File Offset: 0x0007CC67
	public EnchantAttributeItemController()
	{
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x0007E870 File Offset: 0x0007CC70
	public void Init(List<AttributeModifier> attributes)
	{
		this._modifiers = attributes;
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
		foreach (AttributeModifier attributeModifier in attributes)
		{
			TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.TextPre);
			textMeshProUGUI.text = "+" + attributeModifier.GetDisplayValue().ToDisplayValueFormat() + " " + attributeModifier.AttributeType.GetDescription().Title;
			textMeshProUGUI.transform.SetParent(this.AttributeContainer, false);
		}
	}

	// Token: 0x06000A37 RID: 2615 RVA: 0x0007E974 File Offset: 0x0007CD74
	public void SelectAttribute()
	{
		EnchantPanelController componentInParent = base.GetComponentInParent<EnchantPanelController>();
		if (componentInParent != null)
		{
			componentInParent.SelectAttributes(this._modifiers);
		}
		ReforgePanelController componentInParent2 = base.GetComponentInParent<ReforgePanelController>();
		if (componentInParent2 != null && this._modifiers.Count > 0)
		{
			componentInParent2.SelectAttributes(this._modifiers[0]);
		}
	}

	// Token: 0x04000CF5 RID: 3317
	public Transform AttributeContainer;

	// Token: 0x04000CF6 RID: 3318
	public TextMeshProUGUI TextPre;

	// Token: 0x04000CF7 RID: 3319
	private List<AttributeModifier> _modifiers;
}
