using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000096 RID: 150
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Waterfall")]
[Serializable]
public class _2dxFX_Waterfall : MonoBehaviour
{
	// Token: 0x0600049B RID: 1179 RVA: 0x00056C5C File Offset: 0x0005505C
	public _2dxFX_Waterfall()
	{
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x00056CE2 File Offset: 0x000550E2
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00056D0C File Offset: 0x0005510C
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_WaterfallTXT") as Texture2D);
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

	// Token: 0x0600049E RID: 1182 RVA: 0x00056D9C File Offset: 0x0005519C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x00056DA4 File Offset: 0x000551A4
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Liquid);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("EValue", this.EValue);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("TValue", this.TValue);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("Light", this.Light);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("Lightcolor", this.LightColor);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Liquid);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
				this.CanvasImage.material.SetFloat("EValue", this.EValue);
				this.CanvasImage.material.SetFloat("TValue", this.TValue);
				this.CanvasImage.material.SetFloat("Light", this.Light);
				this.CanvasImage.material.SetColor("Lightcolor", this.LightColor);
			}
		}
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00057108 File Offset: 0x00055508
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

	// Token: 0x060004A1 RID: 1185 RVA: 0x00057214 File Offset: 0x00055614
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

	// Token: 0x060004A2 RID: 1186 RVA: 0x000572F0 File Offset: 0x000556F0
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
			this.__MainTex2 = (Resources.Load("_2dxFX_WaterfallTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_WaterfallTXT") as Texture2D);
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

	// Token: 0x04000800 RID: 2048
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000801 RID: 2049
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000802 RID: 2050
	private string shader = "2DxFX/Standard/Waterfall";

	// Token: 0x04000803 RID: 2051
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000804 RID: 2052
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000805 RID: 2053
	[HideInInspector]
	[Range(0f, 2f)]
	public float Liquid = 1f;

	// Token: 0x04000806 RID: 2054
	[HideInInspector]
	[Range(-2f, 4f)]
	public float Speed = 1f;

	// Token: 0x04000807 RID: 2055
	[HideInInspector]
	[Range(-2f, 2f)]
	public float EValue = -0.65f;

	// Token: 0x04000808 RID: 2056
	[HideInInspector]
	[Range(-2f, 2f)]
	public float TValue = 0.6f;

	// Token: 0x04000809 RID: 2057
	[HideInInspector]
	public Color LightColor = new Color(0.2f, 0.5f, 1f, 1f);

	// Token: 0x0400080A RID: 2058
	[HideInInspector]
	[Range(-1f, 1f)]
	public float Light = 0.5f;

	// Token: 0x0400080B RID: 2059
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400080C RID: 2060
	private Material tempMaterial;

	// Token: 0x0400080D RID: 2061
	private Material defaultMaterial;

	// Token: 0x0400080E RID: 2062
	private Image CanvasImage;
}
