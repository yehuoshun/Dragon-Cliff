using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x020002FA RID: 762
public class SpecialLevelItemController : PageElementController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600141A RID: 5146 RVA: 0x000A560E File Offset: 0x000A3A0E
	public SpecialLevelItemController()
	{
	}

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x0600141B RID: 5147 RVA: 0x000A5616 File Offset: 0x000A3A16
	// (set) Token: 0x0600141C RID: 5148 RVA: 0x000A561E File Offset: 0x000A3A1E
	public SpecialLevelItem LevelItem
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

	// Token: 0x0600141D RID: 5149 RVA: 0x000A5627 File Offset: 0x000A3A27
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.LevelItem = (SpecialLevelItem)item;
		this.LevelText.text = this.LevelItem.DungeonText;
	}

	// Token: 0x0600141E RID: 5150 RVA: 0x000A5652 File Offset: 0x000A3A52
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<WorldMapController>().UpdateSpecialLevelSelectionPanel(this.LevelItem.Level);
	}

	// Token: 0x04001462 RID: 5218
	public TextMeshProUGUI LevelText;

	// Token: 0x04001463 RID: 5219
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SpecialLevelItem <LevelItem>k__BackingField;
}
