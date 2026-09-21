using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002F2 RID: 754
public class PageLevelItemController : PageElementController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060013FD RID: 5117 RVA: 0x000A53B5 File Offset: 0x000A37B5
	public PageLevelItemController()
	{
	}

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x060013FE RID: 5118 RVA: 0x000A53BD File Offset: 0x000A37BD
	// (set) Token: 0x060013FF RID: 5119 RVA: 0x000A53C5 File Offset: 0x000A37C5
	public PageLevelItem LevelItem
	{
		[CompilerGenerated]
		get
		{
			return this.<LevelItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LevelItem>k__BackingField = value;
		}
	}

	// Token: 0x06001400 RID: 5120 RVA: 0x000A53D0 File Offset: 0x000A37D0
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.LevelItem = (PageLevelItem)item;
		this.Background.sprite = ((!this.LevelItem.IsChangingLevel) ? this.NormalSprite : this.ChangingLevelSprite);
		this.LevelText.text = this.LevelItem.Dungeon.LevelNumber.ToString();
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x000A5445 File Offset: 0x000A3845
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<WorldMapController>().SelectLevel(this.LevelItem.Dungeon, this.LevelItem.IsChangingLevel);
	}

	// Token: 0x04001455 RID: 5205
	public Image Background;

	// Token: 0x04001456 RID: 5206
	public TextMeshProUGUI LevelText;

	// Token: 0x04001457 RID: 5207
	public Sprite NormalSprite;

	// Token: 0x04001458 RID: 5208
	public Sprite ChangingLevelSprite;

	// Token: 0x04001459 RID: 5209
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageLevelItem <LevelItem>k__BackingField;
}
