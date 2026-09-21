using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PreviewResourceTypePanel : MonoBehaviour
{
	// Token: 0x060018F6 RID: 6390 RVA: 0x000BFB65 File Offset: 0x000BDF65
	public PreviewResourceTypePanel()
	{
	}

	// Token: 0x060018F7 RID: 6391 RVA: 0x000BFB70 File Offset: 0x000BDF70
	private void Start()
	{
		foreach (ResourceType reourceType in ItemExtensions.AllResourceTypes)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Eric/bugfix/pre") as GameObject);
			gameObject.transform.SetParent(this.Container.transform, false);
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<TestReousceType>().SetReourceType(reourceType);
		}
	}

	// Token: 0x040018C0 RID: 6336
	public GameObject Container;
}
