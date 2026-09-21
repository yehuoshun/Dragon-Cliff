using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200015F RID: 351
public class SpeedBarMovingController : MonoBehaviour
{
	// Token: 0x06000960 RID: 2400 RVA: 0x0007AA8A File Offset: 0x00078E8A
	public SpeedBarMovingController()
	{
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x0007AAA8 File Offset: 0x00078EA8
	private void OnApplicationQuit()
	{
		this.Reset();
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x0007AAB0 File Offset: 0x00078EB0
	public void Reset()
	{
		this.Image.material.SetTextureOffset("_MainTex", Vector2.zero);
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x0007AACC File Offset: 0x00078ECC
	private void FixedUpdate()
	{
		this.Offset += this.Speed * Time.fixedDeltaTime;
		this.Image.material.SetTextureOffset("_MainTex", this.Offset);
	}

	// Token: 0x04000C0F RID: 3087
	public Vector2 Speed = Vector2.zero;

	// Token: 0x04000C10 RID: 3088
	public Vector2 Offset = Vector2.zero;

	// Token: 0x04000C11 RID: 3089
	public Image Image;
}
