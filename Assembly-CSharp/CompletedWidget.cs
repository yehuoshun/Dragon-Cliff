using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000FA RID: 250
public class CompletedWidget : MonoBehaviour
{
	// Token: 0x060006E2 RID: 1762 RVA: 0x0006A622 File Offset: 0x00068A22
	public CompletedWidget()
	{
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x0006A62C File Offset: 0x00068A2C
	public void Init(ResourceType type, bool isSucceeded)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CompletedWidgetPre, base.transform);
		gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ((!isSucceeded) ? FilePath.GetFailedRecipeImage() : FilePath.GetRecipeImage(type));
		UnityEngine.Object.Destroy(gameObject, 2f);
	}

	// Token: 0x040009FA RID: 2554
	public GameObject CompletedWidgetPre;
}
