using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000159 RID: 345
public class MonsterInfoTooltipController : MonoBehaviour
{
	// Token: 0x0600094C RID: 2380 RVA: 0x0007A5FE File Offset: 0x000789FE
	public MonsterInfoTooltipController()
	{
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x0007A608 File Offset: 0x00078A08
	public void Init(List<ISpecialEffectDataLoad> specialEffects)
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
		if (specialEffects.Count == 0)
		{
		}
		foreach (ISpecialEffectDataLoad specialEffect in specialEffects)
		{
			MonsterInfoItemController monsterInfoItemController = UnityEngine.Object.Instantiate<MonsterInfoItemController>(this.InfoItemPre);
			monsterInfoItemController.Init(specialEffect);
			monsterInfoItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x04000BFC RID: 3068
	public Transform Container;

	// Token: 0x04000BFD RID: 3069
	public MonsterInfoItemController InfoItemPre;
}
