using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class Background : MonoBehaviour
{
	// Token: 0x060016AA RID: 5802 RVA: 0x000B257D File Offset: 0x000B097D
	public Background()
	{
	}

	// Token: 0x060016AB RID: 5803 RVA: 0x000B2585 File Offset: 0x000B0985
	private void Start()
	{
		this._renderer = base.GetComponent<Renderer>();
		this.CalculateTextureSizeAndTill();
	}

	// Token: 0x060016AC RID: 5804 RVA: 0x000B259C File Offset: 0x000B099C
	public void SetMaterial(string matPath)
	{
		if (matPath != string.Empty)
		{
			Material material = Resources.Load(matPath) as Material;
			this._renderer.material = material;
			this.CalculateTextureSizeAndTill();
			base.gameObject.SetActive(true);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x000B25F4 File Offset: 0x000B09F4
	public void CalculateTextureSizeAndTill()
	{
		if (this._renderer.material.mainTexture != null)
		{
			float x = Mathf.Ceil((float)Screen.width / ((float)this._renderer.material.mainTexture.width * CameraUtil.scale));
			this._renderer.material.mainTextureScale = new Vector2(x, 1f);
		}
	}

	// Token: 0x040016BB RID: 5819
	private Renderer _renderer;

	// Token: 0x040016BC RID: 5820
	private const bool scaleHorizontially = true;

	// Token: 0x040016BD RID: 5821
	private const bool scaleVertically = false;
}
