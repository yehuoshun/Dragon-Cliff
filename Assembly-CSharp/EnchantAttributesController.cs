using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000185 RID: 389
public class EnchantAttributesController : MonoBehaviour
{
	// Token: 0x06000A38 RID: 2616 RVA: 0x0007E9D6 File Offset: 0x0007CDD6
	public EnchantAttributesController()
	{
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x0007E9E0 File Offset: 0x0007CDE0
	public void Init(List<List<AttributeModifier>> attributes)
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
		foreach (List<AttributeModifier> attributes2 in attributes)
		{
			EnchantAttributeItemController enchantAttributeItemController = UnityEngine.Object.Instantiate<EnchantAttributeItemController>(this.AttributePre);
			enchantAttributeItemController.Init(attributes2);
			enchantAttributeItemController.transform.SetParent(this.AttributesContainer, false);
		}
	}

	// Token: 0x04000CF8 RID: 3320
	public Transform AttributesContainer;

	// Token: 0x04000CF9 RID: 3321
	public EnchantAttributeItemController AttributePre;
}
