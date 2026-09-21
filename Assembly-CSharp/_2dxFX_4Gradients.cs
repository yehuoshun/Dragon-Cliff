using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000046 RID: 70
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/4 Gradients")]
[Serializable]
public class _2dxFX_4Gradients : MonoBehaviour
{
	// Token: 0x0600021B RID: 539 RVA: 0x00031694 File Offset: 0x0002FA94
	public _2dxFX_4Gradients()
	{
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00031740 File Offset: 0x0002FB40
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600021D RID: 541 RVA: 0x00031769 File Offset: 0x0002FB69
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00031772 File Offset: 0x0002FB72
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0003177C File Offset: 0x0002FB7C
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color1", this._Color1);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color2", this._Color2);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color3", this._Color3);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color4", this._Color4);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetColor("_Color1", this._Color1);
				this.CanvasImage.material.SetColor("_Color2", this._Color2);
				this.CanvasImage.material.SetColor("_Color3", this._Color3);
				this.CanvasImage.material.SetColor("_Color4", this._Color4);
			}
		}
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00031A80 File Offset: 0x0002FE80
	private void OnDestroy()
	{
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

	// Token: 0x06000221 RID: 545 RVA: 0x00031B54 File Offset: 0x0002FF54
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

	// Token: 0x06000222 RID: 546 RVA: 0x00031C30 File Offset: 0x00030030
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

	// Token: 0x04000405 RID: 1029
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000406 RID: 1030
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000407 RID: 1031
	private string shader = "2DxFX/Standard/4Gradients";

	// Token: 0x04000408 RID: 1032
	[HideInInspector]
	public Color _Color1 = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04000409 RID: 1033
	[HideInInspector]
	public Color _Color2 = new Color(1f, 1f, 0f, 1f);

	// Token: 0x0400040A RID: 1034
	[HideInInspector]
	public Color _Color3 = new Color(0f, 1f, 1f, 1f);

	// Token: 0x0400040B RID: 1035
	[HideInInspector]
	public Color _Color4 = new Color(0f, 1f, 0f, 1f);

	// Token: 0x0400040C RID: 1036
	[Range(0f, 1f)]
	[HideInInspector]
	public float _Alpha = 1f;

	// Token: 0x0400040D RID: 1037
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400040E RID: 1038
	private Material tempMaterial;

	// Token: 0x0400040F RID: 1039
	private Material defaultMaterial;

	// Token: 0x04000410 RID: 1040
	private Image CanvasImage;
}
