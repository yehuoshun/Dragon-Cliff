using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000180 RID: 384
public class BreakPanelController : MonoBehaviour
{
	// Token: 0x06000A14 RID: 2580 RVA: 0x0007E059 File Offset: 0x0007C459
	public BreakPanelController()
	{
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x0007E061 File Offset: 0x0007C461
	private void Start()
	{
		this._parent = base.GetComponentInParent<InventoryMenuManager>();
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x0007E06F File Offset: 0x0007C46F
	private void Update()
	{
		this.BreakByPropertyButton.SetActive(this._parent != null && this._parent.SelectedTab == InventoryTabButton.Item);
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x0007E09E File Offset: 0x0007C49E
	private void OnEnable()
	{
		this.Clear();
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x0007E0A6 File Offset: 0x0007C4A6
	public void Init(Item item)
	{
		this.BreakingItem.Init(item);
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0007E0B4 File Offset: 0x0007C4B4
	private void Clear()
	{
		IEnumerator enumerator = this.BreakResultContainer.GetEnumerator();
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
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x0007E120 File Offset: 0x0007C520
	public void PreBreakByProperty()
	{
		this.BreakByLevelPanel.SetActive(false);
		this.BreakByPropertyPanel.SetActive(true);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x0007E13A File Offset: 0x0007C53A
	public void PreBreakByLevel()
	{
		this.BreakByLevelPanel.SetActive(true);
		this.BreakByPropertyPanel.SetActive(false);
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x0007E154 File Offset: 0x0007C554
	public void CloseAllPanel()
	{
		this.BreakByLevelPanel.SetActive(false);
		this.BreakByPropertyPanel.SetActive(false);
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x0007E170 File Offset: 0x0007C570
	public void ShowResult(List<ResourceUpdate> results)
	{
		this.Clear();
		if (results.Count == 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyResultPre);
			gameObject.transform.SetParent(this.BreakResultContainer, false);
		}
		foreach (ResourceUpdate resource in results)
		{
			BreakResultItemController breakResultItemController = UnityEngine.Object.Instantiate<BreakResultItemController>(this.ResultPre);
			breakResultItemController.Init(resource);
			breakResultItemController.transform.SetParent(this.BreakResultContainer, false);
		}
		base.GetComponentInParent<FurnaceMenuController>().UpdateStoragePages();
	}

	// Token: 0x04000CDA RID: 3290
	public BreakingItemController BreakingItem;

	// Token: 0x04000CDB RID: 3291
	public Transform BreakResultContainer;

	// Token: 0x04000CDC RID: 3292
	public BreakResultItemController ResultPre;

	// Token: 0x04000CDD RID: 3293
	public GameObject EmptyResultPre;

	// Token: 0x04000CDE RID: 3294
	public GameObject BreakByLevelPanel;

	// Token: 0x04000CDF RID: 3295
	public GameObject BreakByPropertyButton;

	// Token: 0x04000CE0 RID: 3296
	public GameObject BreakByPropertyPanel;

	// Token: 0x04000CE1 RID: 3297
	private InventoryMenuManager _parent;
}
