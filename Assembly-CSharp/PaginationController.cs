using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x0200022E RID: 558
public abstract class PaginationController<T> : MonoBehaviour where T : PageElementController
{
	// Token: 0x06000E7E RID: 3710 RVA: 0x0008819F File Offset: 0x0008659F
	protected PaginationController()
	{
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x06000E7F RID: 3711 RVA: 0x000881A7 File Offset: 0x000865A7
	// (set) Token: 0x06000E80 RID: 3712 RVA: 0x000881AF File Offset: 0x000865AF
	public int CurrentPage
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentPage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentPage>k__BackingField = value;
		}
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x06000E81 RID: 3713 RVA: 0x000881B8 File Offset: 0x000865B8
	// (set) Token: 0x06000E82 RID: 3714 RVA: 0x000881E0 File Offset: 0x000865E0
	public List<PageElement> PageElements
	{
		get
		{
			List<PageElement> result;
			if ((result = this._pageElements) == null)
			{
				result = (this._pageElements = new List<PageElement>());
			}
			return result;
		}
		set
		{
			this._pageElements = value;
		}
	}

	// Token: 0x17000090 RID: 144
	// (get) Token: 0x06000E83 RID: 3715 RVA: 0x000881E9 File Offset: 0x000865E9
	// (set) Token: 0x06000E84 RID: 3716 RVA: 0x0008821D File Offset: 0x0008661D
	public List<T> ItemHolders
	{
		get
		{
			if (this._itemHolders == null)
			{
				this._itemHolders = new List<T>();
			}
			if (this._itemHolders.Count == 0)
			{
				this.InitItemHolders();
			}
			return this._itemHolders;
		}
		set
		{
			this._itemHolders = value;
		}
	}

	// Token: 0x06000E85 RID: 3717 RVA: 0x00088228 File Offset: 0x00086628
	public void InitItemHolders()
	{
		List<T> list = new List<T>();
		for (int k = 0; k < this.MaxItemPerPage; k++)
		{
			list.Add(UnityEngine.Object.Instantiate<GameObject>(this.PageElementPrefab).GetComponent<T>());
		}
		this.ItemHolders = list;
		this.ItemHolders.ForEach(delegate(T i)
		{
			i.transform.SetParent(this.Viewport, false);
			i.gameObject.SetActive(false);
		});
		for (int j = 0; j < ((this.PageElements.Count >= this.ItemHolders.Count) ? this.ItemHolders.Count : this.PageElements.Count); j++)
		{
			T t = this.ItemHolders[j];
			t.Init(this.PageElements[j]);
		}
	}

	// Token: 0x06000E86 RID: 3718 RVA: 0x000882F3 File Offset: 0x000866F3
	public void Awake()
	{
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E87 RID: 3719 RVA: 0x000882FC File Offset: 0x000866FC
	public void SelectElement(PageElement element)
	{
		if (element != null && this.PageElements.Any((PageElement e) => e.Id == element.Id))
		{
			this.SelectedElement = element;
			this.UpdateSelectedFrame();
		}
	}

	// Token: 0x06000E88 RID: 3720 RVA: 0x00088350 File Offset: 0x00086750
	public void SelectElement(string elementId)
	{
		PageElement pageElement = this.PageElements.FirstOrDefault((PageElement i) => i != null && i.Id == elementId);
		if (pageElement != null)
		{
			this.SelectElement(pageElement);
		}
	}

	// Token: 0x06000E89 RID: 3721 RVA: 0x00088390 File Offset: 0x00086790
	public int GetPageNumberOfItem(PageElement element)
	{
		if (element != null && this.PageElements.Any((PageElement e) => e.Id == element.Id))
		{
			int num = this.PageElements.IndexOf(element);
			return num / this.MaxItemPerPage + 1;
		}
		return 1;
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x000883F0 File Offset: 0x000867F0
	public virtual void UpdateSelectedFrame()
	{
		if (this.SelectedElement == null || this.Frames.Count <= 0)
		{
			return;
		}
		int num = this.ItemHolders.FindIndex((T i) => i.PageElement != null && i.PageElement.Id == this.SelectedElement.Id);
		if (num != -1)
		{
			foreach (GameObject gameObject in this.Frames)
			{
				if (gameObject.activeSelf)
				{
					gameObject.SetActive(false);
				}
			}
			if (!this.Frames[num].activeSelf)
			{
				this.Frames[num].SetActive(true);
			}
		}
		else
		{
			foreach (GameObject gameObject2 in this.Frames)
			{
				if (gameObject2.activeSelf)
				{
					gameObject2.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06000E8B RID: 3723 RVA: 0x00088518 File Offset: 0x00086918
	public void DiselectAllElement()
	{
		this.SelectedElement = null;
		foreach (GameObject gameObject in this.Frames)
		{
			if (gameObject.activeSelf)
			{
				gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000E8C RID: 3724 RVA: 0x00088588 File Offset: 0x00086988
	public void AddItems(List<PageElement> elements)
	{
		this.PageElements.AddRange(elements);
	}

	// Token: 0x06000E8D RID: 3725 RVA: 0x00088598 File Offset: 0x00086998
	public PageElement GetPageElement(string id)
	{
		return this.PageElements.FirstOrDefault((PageElement p) => p.Id == id);
	}

	// Token: 0x06000E8E RID: 3726 RVA: 0x000885CC File Offset: 0x000869CC
	public void UpdatePageText()
	{
		int maxPageNumber = this.GetMaxPageNumber();
		this.PageText.text = this.CurrentPage + 1 + "/" + (maxPageNumber + 1);
	}

	// Token: 0x06000E8F RID: 3727 RVA: 0x0008860A File Offset: 0x00086A0A
	public int GetMaxPageNumber()
	{
		return (this.PageElements.Count != 0) ? ((this.PageElements.Count - 1) / this.MaxItemPerPage) : 0;
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x00088636 File Offset: 0x00086A36
	public void ResetPage()
	{
		this.CurrentPage = 0;
		this.PageElements = new List<PageElement>();
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E91 RID: 3729 RVA: 0x00088650 File Offset: 0x00086A50
	public virtual void AddNewItems(List<PageElement> elements)
	{
		this.AddItems(elements);
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E92 RID: 3730 RVA: 0x0008865F File Offset: 0x00086A5F
	public virtual void AddNewItem(PageElement element)
	{
		this.PageElements.Add(element);
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x00088674 File Offset: 0x00086A74
	public virtual void UpdateItems(List<PageElement> elements)
	{
		int currentPage = this.CurrentPage;
		this.ResetPage();
		this.AddItems(elements);
		this.CurrentPage = currentPage;
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x000886A4 File Offset: 0x00086AA4
	public virtual void TryRemoveItem(List<string> ids)
	{
		using (List<string>.Enumerator enumerator = ids.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string id = enumerator.Current;
				PageElement pageElement = this.PageElements.FirstOrDefault((PageElement p) => p.Id == id);
				if (pageElement != null)
				{
					this.PageElements.Remove(pageElement);
				}
			}
		}
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E95 RID: 3733 RVA: 0x00088730 File Offset: 0x00086B30
	public virtual void NextPage()
	{
		int maxPageNumber = this.GetMaxPageNumber();
		if (this.CurrentPage >= maxPageNumber)
		{
			return;
		}
		this.CurrentPage++;
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x00088765 File Offset: 0x00086B65
	public virtual void PreviousPage()
	{
		if (this.CurrentPage == 0)
		{
			return;
		}
		this.CurrentPage--;
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E97 RID: 3735 RVA: 0x00088788 File Offset: 0x00086B88
	public virtual void NextTenPage()
	{
		int maxPageNumber = this.GetMaxPageNumber();
		if (this.CurrentPage >= maxPageNumber)
		{
			return;
		}
		if (this.CurrentPage + 10 >= maxPageNumber)
		{
			this.CurrentPage = maxPageNumber;
		}
		else
		{
			this.CurrentPage += 10;
		}
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x000887D9 File Offset: 0x00086BD9
	public virtual void PreviousTenPage()
	{
		if (this.CurrentPage == 0)
		{
			return;
		}
		if (this.CurrentPage - 10 <= 0)
		{
			this.CurrentPage = 0;
		}
		else
		{
			this.CurrentPage -= 10;
		}
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x00088817 File Offset: 0x00086C17
	public virtual void FirstPage()
	{
		this.CurrentPage = 0;
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x00088826 File Offset: 0x00086C26
	public virtual void LastPage()
	{
		this.CurrentPage = this.GetMaxPageNumber();
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x0008883A File Offset: 0x00086C3A
	public void JumpToPage(int pageNumber)
	{
		if (pageNumber > this.GetMaxPageNumber() || pageNumber < 0)
		{
			return;
		}
		this.CurrentPage = pageNumber;
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x00088860 File Offset: 0x00086C60
	public void GoToSelectedItemPage()
	{
		if (this.SelectedElement == null)
		{
			return;
		}
		PageElement pageElement = this.PageElements.FirstOrDefault((PageElement e) => e.Id == this.SelectedElement.Id);
		if (pageElement != null)
		{
			int num = this.PageElements.IndexOf(pageElement);
			int pageNumber = num / this.MaxItemPerPage;
			this.JumpToPage(pageNumber);
		}
	}

	// Token: 0x06000E9D RID: 3741 RVA: 0x000888B4 File Offset: 0x00086CB4
	public virtual void DisplayCurrentPage()
	{
		int maxPageNumber = this.GetMaxPageNumber();
		if (this.CurrentPage > maxPageNumber)
		{
			this.CurrentPage = maxPageNumber;
		}
		List<PageElement> list = this.PageElements.Skip(this.CurrentPage * this.MaxItemPerPage).Take(this.MaxItemPerPage).ToList<PageElement>();
		for (int i = 0; i < list.Count; i++)
		{
			T t = this.ItemHolders[i];
			t.Init(list[i]);
			T t2 = this.ItemHolders[i];
			t2.gameObject.SetActive(true);
		}
		if (list.Count < this.ItemHolders.Count)
		{
			for (int j = 0; j < this.ItemHolders.Count - list.Count; j++)
			{
				T t3 = this.ItemHolders[list.Count + j];
				t3.PageElement = null;
				T t4 = this.ItemHolders[list.Count + j];
				t4.gameObject.SetActive(false);
			}
		}
		this.UpdatePageText();
		this.UpdateSelectedFrame();
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x000889F3 File Offset: 0x00086DF3
	[CompilerGenerated]
	private void <InitItemHolders>m__0(T i)
	{
		i.transform.SetParent(this.Viewport, false);
		i.gameObject.SetActive(false);
	}

	// Token: 0x06000E9F RID: 3743 RVA: 0x00088A21 File Offset: 0x00086E21
	[CompilerGenerated]
	private bool <UpdateSelectedFrame>m__1(T i)
	{
		return i.PageElement != null && i.PageElement.Id == this.SelectedElement.Id;
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x00088A5A File Offset: 0x00086E5A
	[CompilerGenerated]
	private bool <GoToSelectedItemPage>m__2(PageElement e)
	{
		return e.Id == this.SelectedElement.Id;
	}

	// Token: 0x04001012 RID: 4114
	public Transform Viewport;

	// Token: 0x04001013 RID: 4115
	public TextMeshProUGUI PageText;

	// Token: 0x04001014 RID: 4116
	public int MaxItemPerPage;

	// Token: 0x04001015 RID: 4117
	public GameObject PageElementPrefab;

	// Token: 0x04001016 RID: 4118
	public List<GameObject> Frames;

	// Token: 0x04001017 RID: 4119
	protected PageElement SelectedElement;

	// Token: 0x04001018 RID: 4120
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <CurrentPage>k__BackingField;

	// Token: 0x04001019 RID: 4121
	private List<T> _itemHolders;

	// Token: 0x0400101A RID: 4122
	private List<PageElement> _pageElements;

	// Token: 0x02000C49 RID: 3145
	[CompilerGenerated]
	private sealed class <SelectElement>c__AnonStorey0
	{
		// Token: 0x06005281 RID: 21121 RVA: 0x00088A72 File Offset: 0x00086E72
		public <SelectElement>c__AnonStorey0()
		{
		}

		// Token: 0x06005282 RID: 21122 RVA: 0x00088A7A File Offset: 0x00086E7A
		internal bool <>m__0(PageElement e)
		{
			return e.Id == this.element.Id;
		}

		// Token: 0x04004066 RID: 16486
		internal PageElement element;
	}

	// Token: 0x02000C4A RID: 3146
	[CompilerGenerated]
	private sealed class <SelectElement>c__AnonStorey1
	{
		// Token: 0x06005283 RID: 21123 RVA: 0x00088A92 File Offset: 0x00086E92
		public <SelectElement>c__AnonStorey1()
		{
		}

		// Token: 0x06005284 RID: 21124 RVA: 0x00088A9A File Offset: 0x00086E9A
		internal bool <>m__0(PageElement i)
		{
			return i != null && i.Id == this.elementId;
		}

		// Token: 0x04004067 RID: 16487
		internal string elementId;
	}

	// Token: 0x02000C4B RID: 3147
	[CompilerGenerated]
	private sealed class <GetPageNumberOfItem>c__AnonStorey2
	{
		// Token: 0x06005285 RID: 21125 RVA: 0x00088AB6 File Offset: 0x00086EB6
		public <GetPageNumberOfItem>c__AnonStorey2()
		{
		}

		// Token: 0x06005286 RID: 21126 RVA: 0x00088ABE File Offset: 0x00086EBE
		internal bool <>m__0(PageElement e)
		{
			return e.Id == this.element.Id;
		}

		// Token: 0x04004068 RID: 16488
		internal PageElement element;
	}

	// Token: 0x02000C4C RID: 3148
	[CompilerGenerated]
	private sealed class <GetPageElement>c__AnonStorey3
	{
		// Token: 0x06005287 RID: 21127 RVA: 0x00088AD6 File Offset: 0x00086ED6
		public <GetPageElement>c__AnonStorey3()
		{
		}

		// Token: 0x06005288 RID: 21128 RVA: 0x00088ADE File Offset: 0x00086EDE
		internal bool <>m__0(PageElement p)
		{
			return p.Id == this.id;
		}

		// Token: 0x04004069 RID: 16489
		internal string id;
	}

	// Token: 0x02000C4D RID: 3149
	[CompilerGenerated]
	private sealed class <TryRemoveItem>c__AnonStorey4
	{
		// Token: 0x06005289 RID: 21129 RVA: 0x00088AF1 File Offset: 0x00086EF1
		public <TryRemoveItem>c__AnonStorey4()
		{
		}

		// Token: 0x0600528A RID: 21130 RVA: 0x00088AF9 File Offset: 0x00086EF9
		internal bool <>m__0(PageElement p)
		{
			return p.Id == this.id;
		}

		// Token: 0x0400406A RID: 16490
		internal string id;
	}
}
