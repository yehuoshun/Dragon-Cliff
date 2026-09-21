using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000101 RID: 257
public class ShopController : BuildingController
{
	// Token: 0x06000723 RID: 1827 RVA: 0x0006B491 File Offset: 0x00069891
	public ShopController()
	{
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000724 RID: 1828 RVA: 0x0006B499 File Offset: 0x00069899
	// (set) Token: 0x06000725 RID: 1829 RVA: 0x0006B4A1 File Offset: 0x000698A1
	public Shop Shop
	{
		[CompilerGenerated]
		get
		{
			return this.<Shop>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Shop>k__BackingField = value;
		}
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0006B4AA File Offset: 0x000698AA
	public void Init(Shop shop)
	{
		this.Shop = shop;
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x0006B4B3 File Offset: 0x000698B3
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.S) && TownManager.Instance.Ui.CanUseHotKey())
		{
			this.OpenMenu();
		}
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x0006B4DB File Offset: 0x000698DB
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		this.OpenMenu();
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x0006B4F3 File Offset: 0x000698F3
	private void OpenMenu()
	{
		TownManager.Instance.Ui.MyShopMenu.Init(this.Shop);
		TownManager.Instance.Ui.OpenMyShopMenu();
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x0006B51E File Offset: 0x0006991E
	public void ShowWidget()
	{
		if (!TownManager.Instance.Ui.MyShopMenu.gameObject.activeSelf)
		{
			this.NewArrivalWidget.SetActive(true);
		}
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x0006B54A File Offset: 0x0006994A
	public void HideWidget()
	{
		this.NewArrivalWidget.SetActive(false);
	}

	// Token: 0x04000A10 RID: 2576
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Shop <Shop>k__BackingField;

	// Token: 0x04000A11 RID: 2577
	public GameObject NewArrivalWidget;
}
