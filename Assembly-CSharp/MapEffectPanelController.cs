using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EE RID: 750
public class MapEffectPanelController : MonoBehaviour
{
	// Token: 0x060013E5 RID: 5093 RVA: 0x000A5024 File Offset: 0x000A3424
	public MapEffectPanelController()
	{
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x000A502C File Offset: 0x000A342C
	public void Init(List<ISpecialEffectDataLoad> effects)
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
		foreach (ISpecialEffectDataLoad specialEffect in effects)
		{
			AdventureSpecialEffectController adventureSpecialEffectController = UnityEngine.Object.Instantiate<AdventureSpecialEffectController>(this.SpecialEffectPre);
			adventureSpecialEffectController.Init(specialEffect);
			adventureSpecialEffectController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x0400144B RID: 5195
	public Transform Container;

	// Token: 0x0400144C RID: 5196
	public AdventureSpecialEffectController SpecialEffectPre;
}
