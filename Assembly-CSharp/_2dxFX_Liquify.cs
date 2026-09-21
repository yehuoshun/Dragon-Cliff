using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000073 RID: 115
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Liquify")]
[Serializable]
public class _2dxFX_Liquify : MonoBehaviour
{
	// Token: 0x06000383 RID: 899 RVA: 0x000464AC File Offset: 0x000448AC
	public _2dxFX_Liquify()
	{
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00046513 File Offset: 0x00044913
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000385 RID: 901 RVA: 0x0004653C File Offset: 0x0004493C
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_WaterTXT") as Texture2D);
		this.ShaderChange = 0;
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
		else if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x000465CC File Offset: 0x000449CC
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000387 RID: 903 RVA: 0x000465D4 File Offset: 0x000449D4
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Heat);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("EValue", this.EValue);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("Light", this.Light);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("TurnToLiquid", this.TurnToLiquid);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Heat);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
				this.CanvasImage.material.SetFloat("EValue", this.EValue);
				this.CanvasImage.material.SetFloat("Light", this.Light);
				this.CanvasImage.material.SetFloat("TurnToLiquid", this.TurnToLiquid);
			}
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00046918 File Offset: 0x00044D18
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

	// Token: 0x06000389 RID: 905 RVA: 0x00046A24 File Offset: 0x00044E24
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

	// Token: 0x0600038A RID: 906 RVA: 0x00046B00 File Offset: 0x00044F00
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
			this.__MainTex2 = (Resources.Load("_2dxFX_WaterTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_WaterTXT") as Texture2D);
		}
		if (this.__MainTex2)
		{
			this.__MainTex2.wrapMode = TextureWrapMode.Repeat;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
			}
		}
	}

	// Token: 0x0400062B RID: 1579
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400062C RID: 1580
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400062D RID: 1581
	private string shader = "2DxFX/Standard/Liquify";

	// Token: 0x0400062E RID: 1582
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400062F RID: 1583
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000630 RID: 1584
	[HideInInspector]
	[Range(0f, 1f)]
	public float TurnToLiquid = 0.052f;

	// Token: 0x04000631 RID: 1585
	[HideInInspector]
	[Range(0f, 32f)]
	public float Heat = 4f;

	// Token: 0x04000632 RID: 1586
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x04000633 RID: 1587
	[HideInInspector]
	[Range(0f, 1f)]
	public float EValue = 1f;

	// Token: 0x04000634 RID: 1588
	[HideInInspector]
	[Range(-4f, 4f)]
	public float Light = 3f;

	// Token: 0x04000635 RID: 1589
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000636 RID: 1590
	private Material tempMaterial;

	// Token: 0x04000637 RID: 1591
	private Material defaultMaterial;

	// Token: 0x04000638 RID: 1592
	private Image CanvasImage;
}
