using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002DF RID: 735
public class AutoSelectableAdventurerPanelController : MonoBehaviour
{
	// Token: 0x0600137F RID: 4991 RVA: 0x000A3679 File Offset: 0x000A1A79
	public AutoSelectableAdventurerPanelController()
	{
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x000A3684 File Offset: 0x000A1A84
	public void Init(List<AdventurerProfile> adventurers)
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
		foreach (AdventurerProfile adventurer in adventurers)
		{
			AutoSelectableAdventuerItemController autoSelectableAdventuerItemController = UnityEngine.Object.Instantiate<AutoSelectableAdventuerItemController>(this.SelectablePre);
			autoSelectableAdventuerItemController.Init(adventurer);
			autoSelectableAdventuerItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x04001406 RID: 5126
	public Transform Container;

	// Token: 0x04001407 RID: 5127
	public AutoSelectableAdventuerItemController SelectablePre;
}
