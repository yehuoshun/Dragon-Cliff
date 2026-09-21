using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000216 RID: 534
public class CusItemMenuController : ItemMenuController
{
	// Token: 0x06000E0A RID: 3594 RVA: 0x000906C8 File Offset: 0x0008EAC8
	public CusItemMenuController()
	{
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x000906D0 File Offset: 0x0008EAD0
	public new void AddItems(List<NormalItem> items)
	{
		foreach (NormalItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x06000E0C RID: 3596 RVA: 0x00090728 File Offset: 0x0008EB28
	public new void AddItem(NormalItem item)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ItemPrefab, this.ItemList, false);
		gameObject.GetComponent<CusItemController>().Init(item);
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x00090754 File Offset: 0x0008EB54
	public void RemoveItem(Item item)
	{
		for (int i = 0; i < this.ItemList.transform.childCount; i++)
		{
			Transform child = this.ItemList.GetChild(i);
			if (child.GetComponent<ItemController>().NormalItem.Id == item.Id)
			{
				this.RemoveItemObj(child.gameObject);
			}
		}
	}

	// Token: 0x06000E0E RID: 3598 RVA: 0x000907BC File Offset: 0x0008EBBC
	public new void Reset()
	{
		IEnumerator enumerator = this.ItemList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				this.RemoveItemObj(transform.gameObject);
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

	// Token: 0x06000E0F RID: 3599 RVA: 0x00090828 File Offset: 0x0008EC28
	public new void RemoveItemObj(GameObject itemObj)
	{
		UnityEngine.Object.Destroy(itemObj);
	}

	// Token: 0x04000FE4 RID: 4068
	public GameObject ItemPrefab;
}
