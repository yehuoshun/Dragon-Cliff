using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class ThreeDimensionSepcialObj : MonoBehaviour
{
	// Token: 0x0600177C RID: 6012 RVA: 0x000B62D9 File Offset: 0x000B46D9
	public ThreeDimensionSepcialObj()
	{
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000B62E4 File Offset: 0x000B46E4
	private void Start()
	{
		Renderer component = base.GetComponent<Renderer>();
		component.sortingLayerName = "UI";
		component.sortingOrder = 1;
	}
}
