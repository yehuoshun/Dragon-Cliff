using System;
using UnityEngine;

// Token: 0x0200037A RID: 890
public class TiledBackground : MonoBehaviour
{
	// Token: 0x060017FF RID: 6143 RVA: 0x000B9344 File Offset: 0x000B7744
	public TiledBackground()
	{
	}

	// Token: 0x06001800 RID: 6144 RVA: 0x000B9362 File Offset: 0x000B7762
	private void Start()
	{
		this.CalculateTile();
	}

	// Token: 0x06001801 RID: 6145 RVA: 0x000B936A File Offset: 0x000B776A
	public void SerMaterial(Material mat)
	{
		base.GetComponent<MeshRenderer>().material = mat;
		this.CalculateTile();
	}

	// Token: 0x06001802 RID: 6146 RVA: 0x000B9380 File Offset: 0x000B7780
	public void CalculateTile()
	{
		float x = this.scaleHorizontially ? Mathf.Ceil((float)Screen.width / ((float)this.textureSize * CameraUtil.scale)) : 1f;
		float y = this.scaleVertically ? Mathf.Ceil((float)Screen.height / ((float)this.textureSize * CameraUtil.scale)) : 1f;
		base.transform.localScale = new Vector3(150f, 8f, 1f);
		base.GetComponent<Renderer>().material.mainTextureScale = new Vector3(x, y, 1f);
	}

	// Token: 0x040017CD RID: 6093
	public int textureSize = 16;

	// Token: 0x040017CE RID: 6094
	public bool scaleHorizontially = true;

	// Token: 0x040017CF RID: 6095
	public bool scaleVertically = true;
}
