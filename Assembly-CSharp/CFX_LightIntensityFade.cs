using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
[RequireComponent(typeof(Light))]
public class CFX_LightIntensityFade : MonoBehaviour
{
	// Token: 0x0600060E RID: 1550 RVA: 0x00061326 File Offset: 0x0005F726
	public CFX_LightIntensityFade()
	{
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x00061339 File Offset: 0x0005F739
	private void Start()
	{
		this.baseIntensity = base.GetComponent<Light>().intensity;
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x0006134C File Offset: 0x0005F74C
	private void OnEnable()
	{
		this.p_lifetime = 0f;
		this.p_delay = this.delay;
		if (this.delay > 0f)
		{
			base.GetComponent<Light>().enabled = false;
		}
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x00061384 File Offset: 0x0005F784
	private void Update()
	{
		if (this.p_delay > 0f)
		{
			this.p_delay -= Time.deltaTime;
			if (this.p_delay <= 0f)
			{
				base.GetComponent<Light>().enabled = true;
			}
			return;
		}
		if (this.p_lifetime / this.duration < 1f)
		{
			base.GetComponent<Light>().intensity = Mathf.Lerp(this.baseIntensity, this.finalIntensity, this.p_lifetime / this.duration);
			this.p_lifetime += Time.deltaTime;
		}
		else if (this.autodestruct)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000910 RID: 2320
	public float duration = 1f;

	// Token: 0x04000911 RID: 2321
	public float delay;

	// Token: 0x04000912 RID: 2322
	public float finalIntensity;

	// Token: 0x04000913 RID: 2323
	private float baseIntensity;

	// Token: 0x04000914 RID: 2324
	public bool autodestruct;

	// Token: 0x04000915 RID: 2325
	private float p_lifetime;

	// Token: 0x04000916 RID: 2326
	private float p_delay;
}
