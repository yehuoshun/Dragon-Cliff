using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200018B RID: 395
public class EnchantRequirementPanelController : MonoBehaviour
{
	// Token: 0x06000A52 RID: 2642 RVA: 0x0007EFF8 File Offset: 0x0007D3F8
	public EnchantRequirementPanelController()
	{
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x0007F000 File Offset: 0x0007D400
	public void Init(List<ResourceConsumptionRequirement> requirements)
	{
		IEnumerator enumerator = this.RequirementContainer.GetEnumerator();
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
		foreach (ResourceConsumptionRequirement requirement in requirements)
		{
			ShipResourceItemController shipResourceItemController = UnityEngine.Object.Instantiate<ShipResourceItemController>(this.RequiredItemPre);
			shipResourceItemController.Init(requirement);
			shipResourceItemController.transform.SetParent(this.RequirementContainer, false);
		}
	}

	// Token: 0x04000D0A RID: 3338
	public Transform RequirementContainer;

	// Token: 0x04000D0B RID: 3339
	public ShipResourceItemController RequiredItemPre;
}
