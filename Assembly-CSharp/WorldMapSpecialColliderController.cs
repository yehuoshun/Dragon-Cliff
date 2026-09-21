using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

// Token: 0x02000307 RID: 775
public class WorldMapSpecialColliderController : WorldMapColliderBaseController
{
	// Token: 0x06001497 RID: 5271 RVA: 0x000A7F93 File Offset: 0x000A6393
	public WorldMapSpecialColliderController()
	{
	}

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x06001498 RID: 5272 RVA: 0x000A7F9B File Offset: 0x000A639B
	// (set) Token: 0x06001499 RID: 5273 RVA: 0x000A7FA3 File Offset: 0x000A63A3
	public AdventureType AdventureType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventureType>k__BackingField = value;
		}
	}

	// Token: 0x0600149A RID: 5274 RVA: 0x000A7FAC File Offset: 0x000A63AC
	public override void Init(List<DungeonRecord> records, WorldMapController worldMap)
	{
		this.Init();
	}

	// Token: 0x0600149B RID: 5275 RVA: 0x000A7FB4 File Offset: 0x000A63B4
	private void Init()
	{
		base.IsEnable = GameWorld.instance.PlayerProfile.HasSpecialAdventureOpen();
		this.AdventureType = AdventureType.Special;
	}

	// Token: 0x0600149C RID: 5276 RVA: 0x000A7FD3 File Offset: 0x000A63D3
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.DisplayLocationDetails(this.AdventureType);
	}

	// Token: 0x0600149D RID: 5277 RVA: 0x000A7FF2 File Offset: 0x000A63F2
	public override void OnPointerExit(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.HideLocationDetails(this.AdventureType);
	}

	// Token: 0x0600149E RID: 5278 RVA: 0x000A8011 File Offset: 0x000A6411
	public override void OnPointerClick(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.SelectMap(this.AdventureType);
	}

	// Token: 0x040014CB RID: 5323
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureType <AdventureType>k__BackingField;
}
