using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000056 RID: 86
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/DesintegrationFX")]
[Serializable]
public class _2dxFX_DesintegrationFX : MonoBehaviour
{
	// Token: 0x0600029B RID: 667 RVA: 0x00037EA8 File Offset: 0x000362A8
	public _2dxFX_DesintegrationFX()
	{
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00037F0D File Offset: 0x0003630D
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00037F36 File Offset: 0x00036336
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x00037F3F File Offset: 0x0003633F
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00037F48 File Offset: 0x00036348
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Desintegration);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._Color);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Size", this.Seed);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Desintegration);
				this.CanvasImage.material.SetColor("_ColorX", this._Color);
				this.CanvasImage.material.SetFloat("_Size", this.Seed);
			}
		}
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00038218 File Offset: 0x00036618
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

	// Token: 0x060002A1 RID: 673 RVA: 0x00038324 File Offset: 0x00036724
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

	// Token: 0x060002A2 RID: 674 RVA: 0x00038400 File Offset: 0x00036800
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

	// Token: 0x040004A8 RID: 1192
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040004A9 RID: 1193
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040004AA RID: 1194
	private string shader = "2DxFX/Standard/DesintegrationFX";

	// Token: 0x040004AB RID: 1195
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040004AC RID: 1196
	[HideInInspector]
	public Color _Color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x040004AD RID: 1197
	[HideInInspector]
	[Range(0f, 1f)]
	public float Seed = 1f;

	// Token: 0x040004AE RID: 1198
	[HideInInspector]
	[Range(0f, 1f)]
	public float Desintegration = 0.5f;

	// Token: 0x040004AF RID: 1199
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040004B0 RID: 1200
	private Material tempMaterial;

	// Token: 0x040004B1 RID: 1201
	private Material defaultMaterial;

	// Token: 0x040004B2 RID: 1202
	private Image CanvasImage;
}
