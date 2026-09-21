using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200019E RID: 414
public class TransferAttributePanelController : MonoBehaviour
{
	// Token: 0x06000AFD RID: 2813 RVA: 0x00083FDB File Offset: 0x000823DB
	public TransferAttributePanelController()
	{
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x00083FE4 File Offset: 0x000823E4
	public void Init(List<List<ISpecialEffectDataLoad>> specialEffectsList, bool canTransfer)
	{
		this.ClearAttributes();
		foreach (List<ISpecialEffectDataLoad> specialEffects in specialEffectsList)
		{
			TransferAttributeItemController transferAttributeItemController = UnityEngine.Object.Instantiate<TransferAttributeItemController>(this.AttributeItemPre);
			transferAttributeItemController.Init(specialEffects, canTransfer);
			transferAttributeItemController.transform.SetParent(this.Container, false);
		}
		this.AvaialbePropertyText.SetActive(!canTransfer);
		this.SelectPropertyText.SetActive(canTransfer);
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x0008407C File Offset: 0x0008247C
	public void ClearAttributes()
	{
		IEnumerator enumerator = this.Container.GetEnumerator();
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
	}

	// Token: 0x04000D98 RID: 3480
	public Transform Container;

	// Token: 0x04000D99 RID: 3481
	public TransferAttributeItemController AttributeItemPre;

	// Token: 0x04000D9A RID: 3482
	public GameObject AvaialbePropertyText;

	// Token: 0x04000D9B RID: 3483
	public GameObject SelectPropertyText;
}
