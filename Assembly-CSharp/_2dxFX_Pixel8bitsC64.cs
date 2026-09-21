using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000082 RID: 130
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Pixel 8 Bits Commodore 64")]
[Serializable]
public class _2dxFX_Pixel8bitsC64 : MonoBehaviour
{
	// Token: 0x060003FB RID: 1019 RVA: 0x0004D844 File Offset: 0x0004BC44
	public _2dxFX_Pixel8bitsC64()
	{
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0004D895 File Offset: 0x0004BC95
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0004D8BE File Offset: 0x0004BCBE
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0004D8C7 File Offset: 0x0004BCC7
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0004D8D0 File Offset: 0x0004BCD0
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
			this.ActiveChange = false;
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Size", this._Size);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset", this._Offset);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset2", this._Offset2);
				base.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = -10f;
				base.GetComponent<SpriteRenderer>().sprite.texture.filterMode = FilterMode.Point;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Size", this._Size);
				this.CanvasImage.material.SetFloat("_Offset", this._Offset);
				this.CanvasImage.material.SetFloat("_Offset2", this._Offset2);
			}
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0004DBD8 File Offset: 0x0004BFD8
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

	// Token: 0x06000401 RID: 1025 RVA: 0x0004DCE4 File Offset: 0x0004C0E4
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

	// Token: 0x06000402 RID: 1026 RVA: 0x0004DDC0 File Offset: 0x0004C1C0
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

	// Token: 0x04000708 RID: 1800
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000709 RID: 1801
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400070A RID: 1802
	private string shader = "2DxFX/Standard/Pixel8bitsC64";

	// Token: 0x0400070B RID: 1803
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400070C RID: 1804
	[HideInInspector]
	[Range(0.01f, 10f)]
	public float _Size = 1f;

	// Token: 0x0400070D RID: 1805
	[HideInInspector]
	[Range(0.01f, 3f)]
	public float _Offset = 1f;

	// Token: 0x0400070E RID: 1806
	[HideInInspector]
	[Range(0f, 3f)]
	public float _Offset2 = 1f;

	// Token: 0x0400070F RID: 1807
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000710 RID: 1808
	private Material tempMaterial;

	// Token: 0x04000711 RID: 1809
	private Material defaultMaterial;

	// Token: 0x04000712 RID: 1810
	private Image CanvasImage;
}
