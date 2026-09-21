using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000053 RID: 83
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/ColorChange")]
[Serializable]
public class _2dxFX_ColorChange : MonoBehaviour
{
	// Token: 0x06000283 RID: 643 RVA: 0x00036A78 File Offset: 0x00034E78
	public _2dxFX_ColorChange()
	{
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00036AF3 File Offset: 0x00034EF3
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00036B1C File Offset: 0x00034F1C
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00036B25 File Offset: 0x00034F25
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00036B30 File Offset: 0x00034F30
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._Color);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Tolerance", this._Tolerance);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_HueShift", this._HueShift);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Sat", this._Saturation);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Val", this._ValueBrightness);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetColor("_ColorX", this._Color);
				this.CanvasImage.material.SetFloat("_Tolerance", this._Tolerance);
				this.CanvasImage.material.SetFloat("_HueShift", this._HueShift);
				this.CanvasImage.material.SetFloat("_Sat", this._Saturation);
				this.CanvasImage.material.SetFloat("_Val", this._ValueBrightness);
			}
		}
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00036E6C File Offset: 0x0003526C
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

	// Token: 0x06000289 RID: 649 RVA: 0x00036F78 File Offset: 0x00035378
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

	// Token: 0x0600028A RID: 650 RVA: 0x00037054 File Offset: 0x00035454
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

	// Token: 0x04000487 RID: 1159
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000488 RID: 1160
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000489 RID: 1161
	private string shader = "2DxFX/Standard/ColorChange";

	// Token: 0x0400048A RID: 1162
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400048B RID: 1163
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Tolerance = 1f;

	// Token: 0x0400048C RID: 1164
	[HideInInspector]
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x0400048D RID: 1165
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _Saturation = 1f;

	// Token: 0x0400048E RID: 1166
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _ValueBrightness = 1f;

	// Token: 0x0400048F RID: 1167
	[HideInInspector]
	public Color _Color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x04000490 RID: 1168
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000491 RID: 1169
	private Material tempMaterial;

	// Token: 0x04000492 RID: 1170
	private Material defaultMaterial;

	// Token: 0x04000493 RID: 1171
	private Image CanvasImage;
}
