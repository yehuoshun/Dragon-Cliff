using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005B RID: 91
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/EnergyBar")]
[Serializable]
public class _2dxFX_EnergyBar : MonoBehaviour
{
	// Token: 0x060002C3 RID: 707 RVA: 0x0003A2B8 File Offset: 0x000386B8
	public _2dxFX_EnergyBar()
	{
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0003A314 File Offset: 0x00038714
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0003A33D File Offset: 0x0003873D
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0003A346 File Offset: 0x00038746
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x0003A350 File Offset: 0x00038750
	private void Update()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.BarProgress > 1f)
		{
			this.BarProgress = 1f;
		}
		if (this.BarProgress < 0f)
		{
			this.BarProgress = 0f;
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value1", this.BarProgress);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", 1f - this._Value2);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", 1f - this._Value3);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this._Value4);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value5", this._Value5);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Value1", this.BarProgress);
				this.CanvasImage.material.SetFloat("_Value2", 1f - this._Value2);
				this.CanvasImage.material.SetFloat("_Value3", 1f - this._Value3);
				this.CanvasImage.material.SetFloat("_Value4", this._Value4);
				this.CanvasImage.material.SetFloat("_Value5", this._Value5);
			}
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0003A6D8 File Offset: 0x00038AD8
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

	// Token: 0x060002C9 RID: 713 RVA: 0x0003A7E4 File Offset: 0x00038BE4
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

	// Token: 0x060002CA RID: 714 RVA: 0x0003A8C0 File Offset: 0x00038CC0
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

	// Token: 0x040004EE RID: 1262
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040004EF RID: 1263
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040004F0 RID: 1264
	private string shader = "2DxFX/Standard/EnergyBar";

	// Token: 0x040004F1 RID: 1265
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040004F2 RID: 1266
	[HideInInspector]
	[Range(0f, 1f)]
	public float BarProgress = 0.5f;

	// Token: 0x040004F3 RID: 1267
	[HideInInspector]
	[Range(0.9f, 1f)]
	public float _Value2 = 0.975f;

	// Token: 0x040004F4 RID: 1268
	[HideInInspector]
	[Range(0f, 0.5f)]
	public float _Value3 = 0.5f;

	// Token: 0x040004F5 RID: 1269
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value4 = 1f;

	// Token: 0x040004F6 RID: 1270
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value5;

	// Token: 0x040004F7 RID: 1271
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040004F8 RID: 1272
	private Material tempMaterial;

	// Token: 0x040004F9 RID: 1273
	private Material defaultMaterial;

	// Token: 0x040004FA RID: 1274
	private Image CanvasImage;
}
