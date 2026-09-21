using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000067 RID: 103
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/HSV")]
[Serializable]
public class _2dxFX_HSV : MonoBehaviour
{
	// Token: 0x06000323 RID: 803 RVA: 0x00040EE4 File Offset: 0x0003F2E4
	public _2dxFX_HSV()
	{
	}

	// Token: 0x06000324 RID: 804 RVA: 0x00040F35 File Offset: 0x0003F335
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x00040F5E File Offset: 0x0003F35E
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00040F67 File Offset: 0x0003F367
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00040F70 File Offset: 0x0003F370
	private void Update()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.ShaderChange == 0 && this.ForceMaterial != null)
		{
			this.ShaderChange = 1;
			if (this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial = this.ForceMaterial;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material = this.ForceMaterial;
			}
			this.ForceMaterial.hideFlags = HideFlags.None;
			this.ForceMaterial.shader = Shader.Find(this.shader);
		}
		if (this.ForceMaterial == null && this.ShaderChange == 1)
		{
			if (this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			this.tempMaterial = new Material(Shader.Find(this.shader));
			this.tempMaterial.hideFlags = HideFlags.None;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial = this.tempMaterial;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material = this.tempMaterial;
			}
			this.ShaderChange = 0;
		}
		if (this.ActiveChange)
		{
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", 1f - this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_HueShift", this._HueShift);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Sat", this._Saturation);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Val", this._ValueBrightness);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_HueShift", this._HueShift);
				this.CanvasImage.material.SetFloat("_Sat", this._Saturation);
				this.CanvasImage.material.SetFloat("_Val", this._ValueBrightness);
			}
		}
	}

	// Token: 0x06000328 RID: 808 RVA: 0x00041240 File Offset: 0x0003F640
	private void OnDestroy()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (!Application.isPlaying && Application.isEditor)
		{
			if (this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (base.gameObject.activeSelf && this.defaultMaterial != null)
			{
				if (base.gameObject.GetComponent<SpriteRenderer>() != null)
				{
					base.GetComponent<Renderer>().sharedMaterial = this.defaultMaterial;
					base.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
				}
				else if (base.gameObject.GetComponent<Image>() != null)
				{
					this.CanvasImage.material = this.defaultMaterial;
					this.CanvasImage.material.hideFlags = HideFlags.None;
				}
			}
		}
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0004134C File Offset: 0x0003F74C
	private void OnDisable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (base.gameObject.activeSelf && this.defaultMaterial != null)
		{
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial = this.defaultMaterial;
				base.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material = this.defaultMaterial;
				this.CanvasImage.material.hideFlags = HideFlags.None;
			}
		}
	}

	// Token: 0x0600032A RID: 810 RVA: 0x00041428 File Offset: 0x0003F828
	private void OnEnable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.defaultMaterial == null)
		{
			this.defaultMaterial = new Material(Shader.Find("Sprites/Default"));
		}
		if (this.ForceMaterial == null)
		{
			this.ActiveChange = true;
			this.tempMaterial = new Material(Shader.Find(this.shader));
			this.tempMaterial.hideFlags = HideFlags.None;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial = this.tempMaterial;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material = this.tempMaterial;
			}
		}
		else
		{
			this.ForceMaterial.shader = Shader.Find(this.shader);
			this.ForceMaterial.hideFlags = HideFlags.None;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial = this.ForceMaterial;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material = this.ForceMaterial;
			}
		}
	}

	// Token: 0x0400058D RID: 1421
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400058E RID: 1422
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400058F RID: 1423
	private string shader = "2DxFX/Standard/HSV";

	// Token: 0x04000590 RID: 1424
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000591 RID: 1425
	[HideInInspector]
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x04000592 RID: 1426
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _Saturation = 1f;

	// Token: 0x04000593 RID: 1427
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _ValueBrightness = 1f;

	// Token: 0x04000594 RID: 1428
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000595 RID: 1429
	private Material tempMaterial;

	// Token: 0x04000596 RID: 1430
	private Material defaultMaterial;

	// Token: 0x04000597 RID: 1431
	private Image CanvasImage;
}
