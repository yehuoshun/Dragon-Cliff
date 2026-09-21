using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000080 RID: 128
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Pixel")]
[Serializable]
public class _2dxFX_Pixel : MonoBehaviour
{
	// Token: 0x060003EB RID: 1003 RVA: 0x0004CAF8 File Offset: 0x0004AEF8
	public _2dxFX_Pixel()
	{
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0004CB28 File Offset: 0x0004AF28
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0004CB51 File Offset: 0x0004AF51
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0004CB5A File Offset: 0x0004AF5A
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x0004CB64 File Offset: 0x0004AF64
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset", this._Offset);
				base.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = -10f;
				base.GetComponent<SpriteRenderer>().sprite.texture.filterMode = FilterMode.Point;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Offset", this._Offset);
			}
		}
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0004CDF8 File Offset: 0x0004B1F8
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

	// Token: 0x060003F1 RID: 1009 RVA: 0x0004CF04 File Offset: 0x0004B304
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

	// Token: 0x060003F2 RID: 1010 RVA: 0x0004CFE0 File Offset: 0x0004B3E0
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

	// Token: 0x040006F4 RID: 1780
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006F5 RID: 1781
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006F6 RID: 1782
	private string shader = "2DxFX/Standard/Pixel";

	// Token: 0x040006F7 RID: 1783
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040006F8 RID: 1784
	[HideInInspector]
	[Range(4f, 128f)]
	public float _Offset = 32f;

	// Token: 0x040006F9 RID: 1785
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006FA RID: 1786
	private Material tempMaterial;

	// Token: 0x040006FB RID: 1787
	private Material defaultMaterial;

	// Token: 0x040006FC RID: 1788
	private Image CanvasImage;
}
