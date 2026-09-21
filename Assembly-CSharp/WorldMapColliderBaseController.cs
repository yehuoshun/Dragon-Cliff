using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002FD RID: 765
public abstract class WorldMapColliderBaseController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001425 RID: 5157 RVA: 0x000A5722 File Offset: 0x000A3B22
	protected WorldMapColliderBaseController()
	{
	}

	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x06001426 RID: 5158 RVA: 0x000A572A File Offset: 0x000A3B2A
	// (set) Token: 0x06001427 RID: 5159 RVA: 0x000A5732 File Offset: 0x000A3B32
	public bool IsEnable
	{
		[CompilerGenerated]
		get
		{
			return this.<IsEnable>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsEnable>k__BackingField = value;
		}
	}

	// Token: 0x06001428 RID: 5160
	public abstract void Init(List<DungeonRecord> records, WorldMapController worldMap);

	// Token: 0x06001429 RID: 5161
	public abstract void OnPointerEnter(PointerEventData eventData);

	// Token: 0x0600142A RID: 5162
	public abstract void OnPointerExit(PointerEventData eventData);

	// Token: 0x0600142B RID: 5163
	public abstract void OnPointerClick(PointerEventData eventData);

	// Token: 0x0400146A RID: 5226
	public WorldMapController WorldMap;

	// Token: 0x0400146B RID: 5227
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsEnable>k__BackingField;
}
