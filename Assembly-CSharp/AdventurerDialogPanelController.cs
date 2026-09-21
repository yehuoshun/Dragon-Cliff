using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200016B RID: 363
public class AdventurerDialogPanelController : MonoBehaviour
{
	// Token: 0x06000991 RID: 2449 RVA: 0x0007BAD9 File Offset: 0x00079ED9
	public AdventurerDialogPanelController()
	{
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0007BAEC File Offset: 0x00079EEC
	public void NewDialog(AdventurerSpeaksEvent speaksEvent)
	{
		if (this.DialogContainer.childCount > 3)
		{
			UnityEngine.Object.Destroy(this.DialogContainer.GetChild(3).gameObject);
		}
		AdventurerDialogController component = UnityEngine.Object.Instantiate<GameObject>(this.DialogFramePrefab).GetComponent<AdventurerDialogController>();
		component.Init(speaksEvent);
		component.gameObject.SetActive(false);
		this._dialogs.Add(component.gameObject);
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x0007BB55 File Offset: 0x00079F55
	public void DeleteLastDialog(GameObject dialogGameObject)
	{
		this._dialogs.Remove(dialogGameObject);
		UnityEngine.Object.Destroy(dialogGameObject);
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0007BB6C File Offset: 0x00079F6C
	private void Update()
	{
		if (this._dialogs.Count > 0 && this._lastObject != this._dialogs[0])
		{
			RectTransform component = this._dialogs[0].GetComponent<RectTransform>();
			component.SetParent(this.DialogContainer, false);
			component.localScale = Vector3.one;
			this._dialogs[0].SetActive(true);
			this._dialogs[0].GetComponent<AdventurerDialogController>().Display();
			this._lastObject = this._dialogs[0];
		}
	}

	// Token: 0x04000C4C RID: 3148
	public Transform DialogContainer;

	// Token: 0x04000C4D RID: 3149
	public GameObject DialogFramePrefab;

	// Token: 0x04000C4E RID: 3150
	private List<GameObject> _dialogs = new List<GameObject>();

	// Token: 0x04000C4F RID: 3151
	private GameObject _lastObject;
}
