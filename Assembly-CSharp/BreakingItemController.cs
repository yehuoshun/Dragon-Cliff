using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000182 RID: 386
public class BreakingItemController : MonoBehaviour
{
	// Token: 0x06000A22 RID: 2594 RVA: 0x0007E304 File Offset: 0x0007C704
	public BreakingItemController()
	{
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x0007E30C File Offset: 0x0007C70C
	private void Start()
	{
		this.GradeImage.gameObject.SetActive(false);
		this.EquipmentImage.gameObject.SetActive(false);
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x0007E330 File Offset: 0x0007C730
	private void Update()
	{
		if (this._breaking)
		{
			this._timer += Time.deltaTime * 2f;
			this.NoiceFx.Noise = Mathf.Lerp(this.NoiceFx.Noise, 1f, this._timer);
			this.NoiceFx._Alpha = Mathf.Lerp(this.NoiceFx.Noise, 0f, this._timer);
			this.GradeImage.color = Color.Lerp(this.GradeImage.color, ColorPicker.Transparent, this._timer);
		}
		if ((double)this._timer >= 0.5)
		{
			this.Break();
		}
		if (this._timer >= 1f)
		{
			this._timer = 0f;
			this._breaking = false;
		}
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x0007E40F File Offset: 0x0007C80F
	public void Init(Item item)
	{
		if (this._breakingItem == item)
		{
			return;
		}
		this._breakingItem = item;
		this.Break();
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x0007E42C File Offset: 0x0007C82C
	public void Break()
	{
		if (this._breakingItem == null)
		{
			return;
		}
		List<ResourceUpdate> results = new List<Item>
		{
			this._breakingItem
		}.DisambleItems();
		base.GetComponentInParent<BreakPanelController>().ShowResult(results);
		this._breakingItem = null;
	}

	// Token: 0x04000CE6 RID: 3302
	public Image GradeImage;

	// Token: 0x04000CE7 RID: 3303
	public Image EquipmentImage;

	// Token: 0x04000CE8 RID: 3304
	public _2dxFX_NoiseAnimated NoiceFx;

	// Token: 0x04000CE9 RID: 3305
	public AudioClip CraftSound;

	// Token: 0x04000CEA RID: 3306
	private bool _breaking;

	// Token: 0x04000CEB RID: 3307
	private float _timer;

	// Token: 0x04000CEC RID: 3308
	private Item _breakingItem;
}
