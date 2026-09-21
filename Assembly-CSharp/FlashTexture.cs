using System;
using UnityEngine;

// Token: 0x020000F7 RID: 247
public class FlashTexture : MonoBehaviour
{
	// Token: 0x060006D7 RID: 1751 RVA: 0x0006A406 File Offset: 0x00068806
	public FlashTexture()
	{
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0006A42F File Offset: 0x0006882F
	private void Start()
	{
		this._mat = base.GetComponent<Renderer>().material;
		this._originalColor = this._mat.GetColor("_TintColor");
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0006A458 File Offset: 0x00068858
	private void Update()
	{
		this._mat.SetColor("_TintColor", new Color(this._originalColor.r, this._originalColor.g, this._originalColor.b, Mathf.PingPong(Time.time * (this.FlashSpeed + UnityEngine.Random.Range(-this.FlashThrehold, this.FlashThrehold)), this.MaxColorA) + this.BaseColorA));
	}

	// Token: 0x040009EC RID: 2540
	public float FlashThrehold;

	// Token: 0x040009ED RID: 2541
	public float FlashSpeed = 0.2f;

	// Token: 0x040009EE RID: 2542
	public float MaxColorA = 0.55f;

	// Token: 0x040009EF RID: 2543
	public float BaseColorA = 0.5f;

	// Token: 0x040009F0 RID: 2544
	private Material _mat;

	// Token: 0x040009F1 RID: 2545
	private Color _originalColor;
}
