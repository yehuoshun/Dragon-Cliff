using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
public class TownLightController : MonoBehaviour
{
	// Token: 0x060008D6 RID: 2262 RVA: 0x0007853D File Offset: 0x0007693D
	public TownLightController()
	{
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x0007855B File Offset: 0x0007695B
	private void Start()
	{
		this._sprite = base.GetComponent<SpriteRenderer>();
		this._initialColor = this._sprite.color;
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x0007857C File Offset: 0x0007697C
	private void Update()
	{
		this._t += Time.deltaTime;
		float num = UnityEngine.Random.Range(0f, this.FloatRateRange);
		if (this._t >= num)
		{
			this._sprite.color = this._initialColor + new Color(0f, 0f, 0f, UnityEngine.Random.Range(-this.FloatRange / 255f, this.FloatRange / 255f));
		}
		if ((double)this._t >= 1.3 * (double)num)
		{
			this._sprite.color = this._initialColor;
			this._t = 0f;
		}
	}

	// Token: 0x04000B67 RID: 2919
	public float FloatRange = 20f;

	// Token: 0x04000B68 RID: 2920
	public float FloatRateRange = 1f;

	// Token: 0x04000B69 RID: 2921
	private SpriteRenderer _sprite;

	// Token: 0x04000B6A RID: 2922
	private Color _initialColor;

	// Token: 0x04000B6B RID: 2923
	private float _t;
}
