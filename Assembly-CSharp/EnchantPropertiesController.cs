using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000188 RID: 392
public class EnchantPropertiesController : MonoBehaviour
{
	// Token: 0x06000A4B RID: 2635 RVA: 0x0007EEA1 File Offset: 0x0007D2A1
	public EnchantPropertiesController()
	{
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x0007EEAC File Offset: 0x0007D2AC
	public void Init(List<ItemPropertyPotential> properties)
	{
		IEnumerator enumerator = this.PropertyContainer.GetEnumerator();
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
		foreach (ItemPropertyPotential property in properties)
		{
			EnchantPropertyItemController enchantPropertyItemController = UnityEngine.Object.Instantiate<EnchantPropertyItemController>(this.PropertyPre);
			enchantPropertyItemController.Init(property);
			enchantPropertyItemController.transform.SetParent(this.PropertyContainer, false);
		}
	}

	// Token: 0x04000D07 RID: 3335
	public Transform PropertyContainer;

	// Token: 0x04000D08 RID: 3336
	public EnchantPropertyItemController PropertyPre;
}
