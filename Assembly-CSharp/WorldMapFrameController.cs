using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000313 RID: 787
public class WorldMapFrameController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001505 RID: 5381 RVA: 0x000A949F File Offset: 0x000A789F
	public WorldMapFrameController()
	{
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x000A94A8 File Offset: 0x000A78A8
	public void Init(DungeonRecord record)
	{
		bool flag = record.IsEnabledRecord();
		this._originalColor = this.Cover.color;
		if (flag)
		{
			Color color = new Color
			{
				a = 0f
			};
			this.Cover.color = color;
		}
		this._isEnable = flag;
		base.GetComponent<Animator>().enabled = flag;
	}

	// Token: 0x06001507 RID: 5383 RVA: 0x000A9508 File Offset: 0x000A7908
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._isEnable)
		{
			base.GetComponentInParent<WorldMapUiController>().Battle.StartToSelectLevels(this.Type);
		}
	}

	// Token: 0x04001511 RID: 5393
	public AdventureType Type;

	// Token: 0x04001512 RID: 5394
	public Image Cover;

	// Token: 0x04001513 RID: 5395
	private Color _originalColor;

	// Token: 0x04001514 RID: 5396
	private bool _isEnable;
}
