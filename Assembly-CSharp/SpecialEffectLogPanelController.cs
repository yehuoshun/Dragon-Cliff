using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001D8 RID: 472
public class SpecialEffectLogPanelController : MonoBehaviour
{
	// Token: 0x06000CB4 RID: 3252 RVA: 0x0008AFE5 File Offset: 0x000893E5
	public SpecialEffectLogPanelController()
	{
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x0008AFED File Offset: 0x000893ED
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x0008AFF8 File Offset: 0x000893F8
	public void Init()
	{
		List<SpecialEffectDetails> effectDetails = ItemExtensions.GetEffectDetails();
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
		foreach (SpecialEffectDetails effect in effectDetails)
		{
			SpecialEffectLogItemController specialEffectLogItemController = UnityEngine.Object.Instantiate<SpecialEffectLogItemController>(this.EffectItemPre);
			specialEffectLogItemController.Init(effect);
			specialEffectLogItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x04000ECD RID: 3789
	public Transform Container;

	// Token: 0x04000ECE RID: 3790
	public SpecialEffectLogItemController EffectItemPre;
}
