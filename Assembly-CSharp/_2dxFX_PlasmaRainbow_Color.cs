using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/PlasmaRainbow_Color")]
[Serializable]
public class _2dxFX_PlasmaRainbow_Color : MonoBehaviour
{
	// Token: 0x0600041B RID: 1051 RVA: 0x0004F51C File Offset: 0x0004D91C
	public _2dxFX_PlasmaRainbow_Color()
	{
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0004F56D File Offset: 0x0004D96D
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0004F596 File Offset: 0x0004D996
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0004F59F File Offset: 0x0004D99F
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0004F5A8 File Offset: 0x0004D9A8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Colors", this._Colors);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset", this._Offset);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_TimeX", this._TimeX);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Colors", this._Colors);
				this.CanvasImage.material.SetFloat("_Offset", this._Offset);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				this.CanvasImage.material.SetFloat("_TimeX", this._TimeX);
			}
		}
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0004F8E8 File Offset: 0x0004DCE8
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

	// Token: 0x06000421 RID: 1057 RVA: 0x0004F9F4 File Offset: 0x0004DDF4
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

	// Token: 0x06000422 RID: 1058 RVA: 0x0004FAD0 File Offset: 0x0004DED0
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

	// Token: 0x0400073C RID: 1852
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400073D RID: 1853
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400073E RID: 1854
	private string shader = "2DxFX/Standard/PlasmaRainbow_Color";

	// Token: 0x0400073F RID: 1855
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000740 RID: 1856
	[HideInInspector]
	[Range(0.1f, 8f)]
	public float _Colors = 6f;

	// Token: 0x04000741 RID: 1857
	[HideInInspector]
	[Range(0.1f, 4f)]
	public float _Offset = 2.5f;

	// Token: 0x04000742 RID: 1858
	[HideInInspector]
	private float _TimeX;

	// Token: 0x04000743 RID: 1859
	[HideInInspector]
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x04000744 RID: 1860
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000745 RID: 1861
	private Material tempMaterial;

	// Token: 0x04000746 RID: 1862
	private Material defaultMaterial;

	// Token: 0x04000747 RID: 1863
	private Image CanvasImage;
}
