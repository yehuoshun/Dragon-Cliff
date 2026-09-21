using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200015E RID: 350
public class SpecialEffectsController : MonoBehaviour
{
	// Token: 0x0600095D RID: 2397 RVA: 0x0007A96C File Offset: 0x00078D6C
	public SpecialEffectsController()
	{
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x0007A974 File Offset: 0x00078D74
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
		foreach (ISpecialEffectDataLoad specialEffect in from s in specialEffects
		where !(s is ElementEffectData)
		select s)
		{
			AdventureSpecialEffectController adventureSpecialEffectController = UnityEngine.Object.Instantiate<AdventureSpecialEffectController>(this.SpecialEffectPre);
			adventureSpecialEffectController.Init(specialEffect);
			adventureSpecialEffectController.transform.SetParent(this.Container, false);
			adventureSpecialEffectController.transform.localScale = Vector3.one;
		}
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x0007AA7C File Offset: 0x00078E7C
	[CompilerGenerated]
	private static bool <Init>m__0(ISpecialEffectDataLoad s)
	{
		return !(s is ElementEffectData);
	}

	// Token: 0x04000C0C RID: 3084
	public AdventureSpecialEffectController SpecialEffectPre;

	// Token: 0x04000C0D RID: 3085
	public Transform Container;

	// Token: 0x04000C0E RID: 3086
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache0;
}
