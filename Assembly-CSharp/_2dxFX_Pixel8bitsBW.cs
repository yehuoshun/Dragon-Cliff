using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000081 RID: 129
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Pixel 8 Bits Black & White")]
[Serializable]
public class _2dxFX_Pixel8bitsBW : MonoBehaviour
{
	// Token: 0x060003F3 RID: 1011 RVA: 0x0004D154 File Offset: 0x0004B554
	public _2dxFX_Pixel8bitsBW()
	{
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0004D1A5 File Offset: 0x0004B5A5
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0004D1CE File Offset: 0x0004B5CE
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0004D1D7 File Offset: 0x0004B5D7
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0004D1E0 File Offset: 0x0004B5E0
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

	// Token: 0x060003F8 RID: 1016 RVA: 0x0004D4E8 File Offset: 0x0004B8E8
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

	// Token: 0x060003F9 RID: 1017 RVA: 0x0004D5F4 File Offset: 0x0004B9F4
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

	// Token: 0x060003FA RID: 1018 RVA: 0x0004D6D0 File Offset: 0x0004BAD0
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

	// Token: 0x040006FD RID: 1789
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006FE RID: 1790
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006FF RID: 1791
	private string shader = "2DxFX/Standard/Pixel8bitsBW";

	// Token: 0x04000700 RID: 1792
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000701 RID: 1793
	[HideInInspector]
	[Range(0.01f, 10f)]
	public float _Size = 1f;

	// Token: 0x04000702 RID: 1794
	[HideInInspector]
	[Range(0.01f, 10f)]
	public float _Offset = 1f;

	// Token: 0x04000703 RID: 1795
	[HideInInspector]
	[Range(0f, 10f)]
	public float _Offset2 = 1f;

	// Token: 0x04000704 RID: 1796
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000705 RID: 1797
	private Material tempMaterial;

	// Token: 0x04000706 RID: 1798
	private Material defaultMaterial;

	// Token: 0x04000707 RID: 1799
	private Image CanvasImage;
}
