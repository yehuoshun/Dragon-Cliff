using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000277 RID: 631
public class ItemMenuController : MonoBehaviour
{
	// Token: 0x06001092 RID: 4242 RVA: 0x0009055F File Offset: 0x0008E95F
	public ItemMenuController()
	{
	}

	// Token: 0x06001093 RID: 4243 RVA: 0x00090567 File Offset: 0x0008E967
	public void Init(List<NormalItem> items)
	{
		this.Reset();
		this.AddItems(items);
	}

	// Token: 0x06001094 RID: 4244 RVA: 0x00090578 File Offset: 0x0008E978
	public void AddItems(List<NormalItem> items)
	{
		foreach (NormalItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x06001095 RID: 4245 RVA: 0x000905D0 File Offset: 0x0008E9D0
	public void AddItem(NormalItem item)
	{
		GameObjectCreator.CreateUiItem(item, this.ItemList);
	}

	// Token: 0x06001096 RID: 4246 RVA: 0x000905E0 File Offset: 0x0008E9E0
	public void RemoveItem(string id)
	{
		for (int i = 0; i < this.ItemList.transform.childCount; i++)
		{
			Transform child = this.ItemList.GetChild(i);
			if (child.GetComponent<ItemController>().NormalItem.Id == id)
			{
				this.RemoveItemObj(child.gameObject);
			}
		}
	}

	// Token: 0x06001097 RID: 4247 RVA: 0x00090642 File Offset: 0x0008EA42
	public void RemoveItemObj(GameObject itemObj)
	{
		GameObjectCreator.DestroyUiItem(itemObj);
	}

	// Token: 0x06001098 RID: 4248 RVA: 0x0009064C File Offset: 0x0008EA4C
	public void Reset()
	{
		IEnumerator enumerator = this.ItemList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				if (transform.gameObject.activeSelf)
				{
					this.RemoveItemObj(transform.gameObject);
				}
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

	// Token: 0x040011BB RID: 4539
	public Transform ItemList;
}
