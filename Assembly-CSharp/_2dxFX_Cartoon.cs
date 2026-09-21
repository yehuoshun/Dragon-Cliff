using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200004F RID: 79
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Cartoon")]
[Serializable]
public class _2dxFX_Cartoon : MonoBehaviour
{
	// Token: 0x06000263 RID: 611 RVA: 0x00035076 File Offset: 0x00033476
	public _2dxFX_Cartoon()
	{
	}

	// Token: 0x06000264 RID: 612 RVA: 0x000350B1 File Offset: 0x000334B1
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000265 RID: 613 RVA: 0x000350DA File Offset: 0x000334DA
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000266 RID: 614 RVA: 0x000350E3 File Offset: 0x000334E3
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000267 RID: 615 RVA: 0x000350EC File Offset: 0x000334EC
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ColorLevel", this._ColorLevel);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_EdgeSize", this._EdgeSize);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_ColorLevel", this._ColorLevel);
				this.CanvasImage.material.SetFloat("_EdgeSize", this._EdgeSize);
			}
		}
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00035384 File Offset: 0x00033784
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

	// Token: 0x06000269 RID: 617 RVA: 0x00035490 File Offset: 0x00033890
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

	// Token: 0x0600026A RID: 618 RVA: 0x0003556C File Offset: 0x0003396C
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

	// Token: 0x0400045E RID: 1118
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400045F RID: 1119
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000460 RID: 1120
	private string shader = "2DxFX/Standard/Cartoon";

	// Token: 0x04000461 RID: 1121
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000462 RID: 1122
	[HideInInspector]
	[Range(0f, 6f)]
	public float _ColorLevel = 6f;

	// Token: 0x04000463 RID: 1123
	[HideInInspector]
	[Range(0f, 1f)]
	public float _EdgeSize = 0.08f;

	// Token: 0x04000464 RID: 1124
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000465 RID: 1125
	private Material tempMaterial;

	// Token: 0x04000466 RID: 1126
	private Material defaultMaterial;

	// Token: 0x04000467 RID: 1127
	private Image CanvasImage;
}
