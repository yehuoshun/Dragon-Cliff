using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

// Token: 0x02000306 RID: 774
public class WorldMapNormalColliderController : WorldMapColliderBaseController
{
	// Token: 0x06001491 RID: 5265 RVA: 0x000A7EDC File Offset: 0x000A62DC
	public WorldMapNormalColliderController()
	{
	}

	// Token: 0x06001492 RID: 5266 RVA: 0x000A7EE4 File Offset: 0x000A62E4
	public override void Init(List<DungeonRecord> records, WorldMapController worldMap)
	{
		DungeonRecord dungeonRecord = records.FirstOrDefault((DungeonRecord r) => r.AdventureType == this.AdventureType);
		if (worldMap != null)
		{
			base.IsEnable = (dungeonRecord != null && worldMap.IsEnabledRecord(dungeonRecord));
		}
	}

	// Token: 0x06001493 RID: 5267 RVA: 0x000A7F26 File Offset: 0x000A6326
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.DisplayLocationDetails(this.AdventureType);
	}

	// Token: 0x06001494 RID: 5268 RVA: 0x000A7F45 File Offset: 0x000A6345
	public override void OnPointerExit(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.HideLocationDetails(this.AdventureType);
	}

	// Token: 0x06001495 RID: 5269 RVA: 0x000A7F64 File Offset: 0x000A6364
	public override void OnPointerClick(PointerEventData eventData)
	{
		if (!base.IsEnable)
		{
			return;
		}
		this.WorldMap.SelectMap(this.AdventureType);
	}

	// Token: 0x06001496 RID: 5270 RVA: 0x000A7F83 File Offset: 0x000A6383
	[CompilerGenerated]
	private bool <Init>m__0(DungeonRecord r)
	{
		return r.AdventureType == this.AdventureType;
	}

	// Token: 0x040014CA RID: 5322
	public AdventureType AdventureType;
}
