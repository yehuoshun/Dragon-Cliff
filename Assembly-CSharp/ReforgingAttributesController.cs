using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200019C RID: 412
public class ReforgingAttributesController : MonoBehaviour
{
	// Token: 0x06000AF8 RID: 2808 RVA: 0x00083D9F File Offset: 0x0008219F
	public ReforgingAttributesController()
	{
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x00083DA8 File Offset: 0x000821A8
	public void Init(List<AttributeModifier> attributes)
	{
		IEnumerator enumerator = this.AttributesContainer.GetEnumerator();
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
		foreach (AttributeModifier item in attributes)
		{
			EnchantAttributeItemController enchantAttributeItemController = UnityEngine.Object.Instantiate<EnchantAttributeItemController>(this.AttributePre);
			enchantAttributeItemController.Init(new List<AttributeModifier>
			{
				item
			});
			enchantAttributeItemController.transform.SetParent(this.AttributesContainer, false);
		}
	}

	// Token: 0x04000D8F RID: 3471
	public Transform AttributesContainer;

	// Token: 0x04000D90 RID: 3472
	public EnchantAttributeItemController AttributePre;
}
