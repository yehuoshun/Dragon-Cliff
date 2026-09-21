using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200008C RID: 140
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Shiny Reflect")]
[Serializable]
public class _2dxFX_Shiny_Reflect : MonoBehaviour
{
	// Token: 0x0600044B RID: 1099 RVA: 0x00051C58 File Offset: 0x00050058
	public _2dxFX_Shiny_Reflect()
	{
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00051CC6 File Offset: 0x000500C6
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x00051CF0 File Offset: 0x000500F0
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_Gradient") as Texture2D);
		this.ShaderChange = 0;
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
		else if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
		}
		if (this.ShinyLightCurve == null)
		{
			this.ShinyLightCurve = new AnimationCurve();
		}
		if (this.ShinyLightCurve.length == 0)
		{
			this.ShinyLightCurve.AddKey(7.780734E-06f, -0.4416301f);
			this.ShinyLightCurve.keys[0].tangentMode = 0;
			this.ShinyLightCurve.keys[0].inTangent = 0f;
			this.ShinyLightCurve.keys[0].outTangent = 0f;
			this.ShinyLightCurve.AddKey(0.4310643f, 1.113406f);
			this.ShinyLightCurve.keys[1].tangentMode = 0;
			this.ShinyLightCurve.keys[1].inTangent = 0.2280953f;
			this.ShinyLightCurve.keys[1].outTangent = 0.2280953f;
			this.ShinyLightCurve.AddKey(0.5258899f, 1.229086f);
			this.ShinyLightCurve.keys[2].tangentMode = 0;
			this.ShinyLightCurve.keys[2].inTangent = -0.1474274f;
			this.ShinyLightCurve.keys[2].outTangent = -0.1474274f;
			this.ShinyLightCurve.AddKey(0.6136486f, 1.113075f);
			this.ShinyLightCurve.keys[3].tangentMode = 0;
			this.ShinyLightCurve.keys[3].inTangent = 0.005268873f;
			this.ShinyLightCurve.keys[3].outTangent = 0.005268873f;
			this.ShinyLightCurve.AddKey(0.9367767f, -0.4775873f);
			this.ShinyLightCurve.keys[4].tangentMode = 0;
			this.ShinyLightCurve.keys[4].inTangent = -3.890693f;
			this.ShinyLightCurve.keys[4].outTangent = -3.890693f;
			this.ShinyLightCurve.AddKey(1.144408f, -0.4976555f);
			this.ShinyLightCurve.keys[5].tangentMode = 0;
			this.ShinyLightCurve.keys[5].inTangent = 0f;
			this.ShinyLightCurve.keys[5].outTangent = 0f;
			this.ShinyLightCurve.postWrapMode = WrapMode.Loop;
			this.ShinyLightCurve.preWrapMode = WrapMode.Loop;
		}
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x00052010 File Offset: 0x00050410
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x00052018 File Offset: 0x00050418
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
				if (this.UseShinyCurve)
				{
					if (this.ShinyLightCurve != null)
					{
						base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.ShinyLightCurve.Evaluate(this.ShinyLightCurveTime));
					}
					this.ShinyLightCurveTime += Time.deltaTime / 8f * this.AnimationSpeedReduction;
				}
				else
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Light);
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", this.LightSize);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", this.Intensity);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this.OnlyLight);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value5", this.LightBump);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				if (this.UseShinyCurve)
				{
					this.CanvasImage.material.SetFloat("_Distortion", this.ShinyLightCurve.Evaluate(this.ShinyLightCurveTime));
					this.ShinyLightCurveTime += Time.deltaTime / 8f * this.AnimationSpeedReduction;
				}
				else
				{
					this.CanvasImage.material.SetFloat("_Distortion", this.Light);
				}
				this.CanvasImage.material.SetFloat("_Value2", this.LightSize);
				this.CanvasImage.material.SetFloat("_Value3", this.Intensity);
				this.CanvasImage.material.SetFloat("_Value4", this.OnlyLight);
				this.CanvasImage.material.SetFloat("_Value5", this.LightBump);
			}
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x00052408 File Offset: 0x00050808
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

	// Token: 0x06000451 RID: 1105 RVA: 0x00052514 File Offset: 0x00050914
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

	// Token: 0x06000452 RID: 1106 RVA: 0x000525F0 File Offset: 0x000509F0
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
			this.__MainTex2 = (Resources.Load("_2dxFX_Gradient") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_Gradient") as Texture2D);
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

	// Token: 0x04000778 RID: 1912
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000779 RID: 1913
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400077A RID: 1914
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x0400077B RID: 1915
	private string shader = "2DxFX/Standard/Shiny_Reflect";

	// Token: 0x0400077C RID: 1916
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400077D RID: 1917
	[HideInInspector]
	[Range(-0.5f, 1.5f)]
	public float Light = 1f;

	// Token: 0x0400077E RID: 1918
	[HideInInspector]
	[Range(0.05f, 1f)]
	public float LightSize = 0.5f;

	// Token: 0x0400077F RID: 1919
	[HideInInspector]
	public bool UseShinyCurve = true;

	// Token: 0x04000780 RID: 1920
	[HideInInspector]
	public AnimationCurve ShinyLightCurve;

	// Token: 0x04000781 RID: 1921
	[HideInInspector]
	[Range(0f, 32f)]
	public float AnimationSpeedReduction = 3f;

	// Token: 0x04000782 RID: 1922
	[HideInInspector]
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000783 RID: 1923
	[HideInInspector]
	[Range(0f, 1f)]
	public float OnlyLight;

	// Token: 0x04000784 RID: 1924
	[HideInInspector]
	[Range(-1f, 1f)]
	public float LightBump = 0.05f;

	// Token: 0x04000785 RID: 1925
	private float ShinyLightCurveTime;

	// Token: 0x04000786 RID: 1926
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000787 RID: 1927
	private Material tempMaterial;

	// Token: 0x04000788 RID: 1928
	private Material defaultMaterial;

	// Token: 0x04000789 RID: 1929
	private Image CanvasImage;
}
