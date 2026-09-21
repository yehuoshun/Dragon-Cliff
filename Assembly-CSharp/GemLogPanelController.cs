using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001B8 RID: 440
public class GemLogPanelController : MonoBehaviour
{
	// Token: 0x06000B7A RID: 2938 RVA: 0x0008669A File Offset: 0x00084A9A
	public GemLogPanelController()
	{
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x000866A2 File Offset: 0x00084AA2
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x000866AC File Offset: 0x00084AAC
	public void Init()
	{
		List<GemSetDescription> allGemDescription = GemGeneratorBase.GetAllGemDescription();
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
		foreach (GemSetDescription gemItem in allGemDescription)
		{
			GemDescriptionItemController gemDescriptionItemController = UnityEngine.Object.Instantiate<GemDescriptionItemController>(this.GemItemPre);
			gemDescriptionItemController.Init(gemItem);
			gemDescriptionItemController.transform.SetParent(this.Container, false);
		}
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x00086788 File Offset: 0x00084B88
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000DEB RID: 3563
	public Transform Container;

	// Token: 0x04000DEC RID: 3564
	public GemDescriptionItemController GemItemPre;
}
