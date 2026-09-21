using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000193 RID: 403
public class FurnaceSlotController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000AB5 RID: 2741 RVA: 0x00082ADD File Offset: 0x00080EDD
	public FurnaceSlotController()
	{
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00082AE5 File Offset: 0x00080EE5
	// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x00082AED File Offset: 0x00080EED
	public int Index
	{
		[CompilerGenerated]
		get
		{
			return this.<Index>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Index>k__BackingField = value;
		}
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x00082AF6 File Offset: 0x00080EF6
	private void Start()
	{
		this.Reset();
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x00082B00 File Offset: 0x00080F00
	public void Init(NormalItem item, int index)
	{
		this.Index = index;
		this.Reset();
		if (item != null)
		{
			this.Grade.sprite = FilePath.GetItemGradeBackground(item.ItemGrade, item.Item.IsStarItem());
			this.RecipeImage.sprite = FilePath.GetRecipeImage(item.Item.Type);
			this.LockObj.SetActive(item.Item.Locked);
			this.RemoveButton.SetActive(true);
			this._item = item;
		}
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x00082B85 File Offset: 0x00080F85
	public void HideRemoveButton()
	{
		this.RemoveButton.SetActive(false);
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x00082B94 File Offset: 0x00080F94
	private void Reset()
	{
		this.RemoveButton.SetActive(false);
		Sprite itemGradeBackground = FilePath.GetItemGradeBackground(QualityGrade.Normal, false);
		this.Grade.sprite = itemGradeBackground;
		this.RecipeImage.sprite = itemGradeBackground;
		this.LockObj.SetActive(false);
		this._item = null;
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x00082BE0 File Offset: 0x00080FE0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.RemoveItem();
		}
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x00082BF4 File Offset: 0x00080FF4
	public void RemoveItem()
	{
		if (this._item != null)
		{
			this.CloseTooltip();
		}
	}

	// Token: 0x04000D50 RID: 3408
	public Image Grade;

	// Token: 0x04000D51 RID: 3409
	public Image RecipeImage;

	// Token: 0x04000D52 RID: 3410
	public GameObject RemoveButton;

	// Token: 0x04000D53 RID: 3411
	public GameObject LockObj;

	// Token: 0x04000D54 RID: 3412
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Index>k__BackingField;

	// Token: 0x04000D55 RID: 3413
	private NormalItem _item;
}
