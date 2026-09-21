using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x0200003D RID: 61
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Shiny Reflect")]
[Serializable]
public class _2dxFX_AL_Shiny_Reflect : MonoBehaviour
{
	// Token: 0x060001D9 RID: 473 RVA: 0x0002B69C File Offset: 0x00029A9C
	public _2dxFX_AL_Shiny_Reflect()
	{
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0002B711 File Offset: 0x00029B11
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0002B73C File Offset: 0x00029B3C
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

	// Token: 0x060001DC RID: 476 RVA: 0x0002BA5C File Offset: 0x00029E5C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0002BA64 File Offset: 0x00029E64
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
				if (_2DxFX.ActiveShadow && this.AddShadow)
				{
					base.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.On;
					if (this.ReceivedShadow)
					{
						base.GetComponent<Renderer>().receiveShadows = true;
						base.GetComponent<Renderer>().sharedMaterial.renderQueue = 2450;
						base.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 1);
					}
					else
					{
						base.GetComponent<Renderer>().receiveShadows = false;
						base.GetComponent<Renderer>().sharedMaterial.renderQueue = 3000;
						base.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 0);
					}
				}
				else
				{
					base.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
					base.GetComponent<Renderer>().receiveShadows = false;
					base.GetComponent<Renderer>().sharedMaterial.renderQueue = 3000;
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 0);
				}
				if (this.BlendMode == 0)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 0);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 1);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 10);
				}
				if (this.BlendMode == 1)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 0);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 1);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 1);
				}
				if (this.BlendMode == 2)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 2);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 1);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 2);
				}
				if (this.BlendMode == 3)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 4);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 1);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 1);
				}
				if (this.BlendMode == 4)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 2);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 1);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 1);
				}
				if (this.BlendMode == 5)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 4);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 10);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 10);
				}
				if (this.BlendMode == 6)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 0);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 2);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 10);
				}
				if (this.BlendMode == 7)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 0);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 4);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 1);
				}
				if (this.BlendMode == 8)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", 2);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", 7);
					base.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", 2);
				}
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

	// Token: 0x060001DE RID: 478 RVA: 0x0002C1FC File Offset: 0x0002A5FC
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

	// Token: 0x060001DF RID: 479 RVA: 0x0002C308 File Offset: 0x0002A708
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

	// Token: 0x060001E0 RID: 480 RVA: 0x0002C3E4 File Offset: 0x0002A7E4
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

	// Token: 0x0400037B RID: 891
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400037C RID: 892
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400037D RID: 893
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x0400037E RID: 894
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x0400037F RID: 895
	[HideInInspector]
	public int BlendMode;

	// Token: 0x04000380 RID: 896
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000381 RID: 897
	private string shader = "2DxFX/AL/Shiny_Reflect";

	// Token: 0x04000382 RID: 898
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000383 RID: 899
	[HideInInspector]
	[Range(-0.5f, 1.5f)]
	public float Light = 1f;

	// Token: 0x04000384 RID: 900
	[HideInInspector]
	[Range(0.05f, 1f)]
	public float LightSize = 0.5f;

	// Token: 0x04000385 RID: 901
	[HideInInspector]
	public bool UseShinyCurve = true;

	// Token: 0x04000386 RID: 902
	[HideInInspector]
	public AnimationCurve ShinyLightCurve;

	// Token: 0x04000387 RID: 903
	[HideInInspector]
	[Range(0f, 32f)]
	public float AnimationSpeedReduction = 3f;

	// Token: 0x04000388 RID: 904
	[HideInInspector]
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000389 RID: 905
	[HideInInspector]
	[Range(0f, 1f)]
	public float OnlyLight;

	// Token: 0x0400038A RID: 906
	[HideInInspector]
	[Range(-1f, 1f)]
	public float LightBump = 0.05f;

	// Token: 0x0400038B RID: 907
	private float ShinyLightCurveTime;

	// Token: 0x0400038C RID: 908
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400038D RID: 909
	private Material tempMaterial;

	// Token: 0x0400038E RID: 910
	private Material defaultMaterial;

	// Token: 0x0400038F RID: 911
	private Image CanvasImage;
}
