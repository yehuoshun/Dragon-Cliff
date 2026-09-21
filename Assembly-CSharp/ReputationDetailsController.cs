using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001E0 RID: 480
public class ReputationDetailsController : MonoBehaviour
{
	// Token: 0x06000CD7 RID: 3287 RVA: 0x0008C5D6 File Offset: 0x0008A9D6
	public ReputationDetailsController()
	{
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x0008C5E0 File Offset: 0x0008A9E0
	public void Init()
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
		TownTitleType title = GameWorld.instance.PlayerProfile.GetTitle();
		List<object> list = new List<object>();
		IEnumerator enumerator2 = Enum.GetValues(typeof(TownTitleType)).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object item = enumerator2.Current;
				list.Add(item);
			}
		}
		finally
		{
			IDisposable disposable2;
			if ((disposable2 = (enumerator2 as IDisposable)) != null)
			{
				disposable2.Dispose();
			}
		}
		List<TownTitleType> list2 = (from t in list
		select (TownTitleType)t).ToList<TownTitleType>();
		int num = list2.IndexOf(title);
		for (int i = list2.Count - 1; i >= 0; i--)
		{
			TownTitleType townTitleType = list2[i];
			ReputationItemController reputationItemController = UnityEngine.Object.Instantiate<ReputationItemController>(this.ReputationItemObj);
			reputationItemController.Init(townTitleType, townTitleType == title, num > i);
			reputationItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x0008C754 File Offset: 0x0008AB54
	[CompilerGenerated]
	private static TownTitleType <Init>m__0(object t)
	{
		return (TownTitleType)t;
	}

	// Token: 0x04000EF3 RID: 3827
	public ReputationItemController ReputationItemObj;

	// Token: 0x04000EF4 RID: 3828
	public Transform Container;

	// Token: 0x04000EF5 RID: 3829
	[CompilerGenerated]
	private static Func<object, TownTitleType> <>f__am$cache0;
}
