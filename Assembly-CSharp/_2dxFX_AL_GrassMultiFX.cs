using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x0200001A RID: 26
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/GrassMultiFX")]
[Serializable]
public class _2dxFX_AL_GrassMultiFX : MonoBehaviour
{
	// Token: 0x060000C1 RID: 193 RVA: 0x0001338C File Offset: 0x0001178C
	public _2dxFX_AL_GrassMultiFX()
	{
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x000133FA File Offset: 0x000117FA
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00013424 File Offset: 0x00011824
	private void Start()
	{
		this.ShaderChange = 0;
		this.Wind = new AnimationCurve();
		this.Wind.AddKey(0f, 0f);
		this.Wind.keys[0].tangentMode = 0;
		this.Wind.keys[0].inTangent = 0f;
		this.Wind.keys[0].outTangent = 0f;
		this.Wind.AddKey(0.1004994f, 0.06637689f);
		this.Wind.keys[1].tangentMode = 0;
		this.Wind.keys[1].inTangent = 0f;
		this.Wind.keys[1].outTangent = 0f;
		this.Wind.AddKey(0.2430963f, -0.06465532f);
		this.Wind.keys[2].tangentMode = 0;
		this.Wind.keys[2].inTangent = -0.07599592f;
		this.Wind.keys[2].outTangent = -0.07599592f;
		this.Wind.AddKey(0.3425266f, 0.02290122f);
		this.Wind.keys[3].tangentMode = 0;
		this.Wind.keys[3].inTangent = 0.03580004f;
		this.Wind.keys[3].outTangent = 0.03580004f;
		this.Wind.AddKey(0.4246872f, -0.02232522f);
		this.Wind.keys[4].tangentMode = 0;
		this.Wind.keys[4].inTangent = -0.006025657f;
		this.Wind.keys[4].outTangent = -0.006025657f;
		this.Wind.AddKey(0.5104106f, 0.1647801f);
		this.Wind.keys[5].tangentMode = 0;
		this.Wind.keys[5].inTangent = 0.02981164f;
		this.Wind.keys[5].outTangent = 0.02981164f;
		this.Wind.AddKey(0.6082056f, -0.04679203f);
		this.Wind.keys[6].tangentMode = 0;
		this.Wind.keys[6].inTangent = -0.3176928f;
		this.Wind.keys[6].outTangent = -0.3176928f;
		this.Wind.AddKey(0.7794942f, 0.2234365f);
		this.Wind.keys[7].tangentMode = 0;
		this.Wind.keys[7].inTangent = 0.2063811f;
		this.Wind.keys[7].outTangent = 0.2063811f;
		this.Wind.AddKey(0.8546611f, -0.003165513f);
		this.Wind.keys[8].tangentMode = 0;
		this.Wind.keys[8].inTangent = 0.02264977f;
		this.Wind.keys[8].outTangent = 0.02264977f;
		this.Wind.AddKey(1.022495f, -0.07358052f);
		this.Wind.keys[9].tangentMode = 0;
		this.Wind.keys[9].inTangent = 2.450916f;
		this.Wind.keys[9].outTangent = 2.450916f;
		this.Wind.AddKey(1.250894f, -0.1813075f);
		this.Wind.keys[10].tangentMode = 0;
		this.Wind.keys[10].inTangent = 0.02214685f;
		this.Wind.keys[10].outTangent = 0.02214685f;
		this.Wind.AddKey(1.369877f, -0.06861454f);
		this.Wind.keys[11].tangentMode = 0;
		this.Wind.keys[11].inTangent = -1.860534f;
		this.Wind.keys[11].outTangent = -1.860534f;
		this.Wind.AddKey(1.484951f, -0.1543293f);
		this.Wind.keys[12].tangentMode = 0;
		this.Wind.keys[12].inTangent = 0.0602752f;
		this.Wind.keys[12].outTangent = 0.0602752f;
		this.Wind.AddKey(1.583562f, 0.100938f);
		this.Wind.keys[13].tangentMode = 0;
		this.Wind.keys[13].inTangent = 0.08665025f;
		this.Wind.keys[13].outTangent = 0.08665025f;
		this.Wind.AddKey(1.687307f, -0.100769f);
		this.Wind.keys[14].tangentMode = 0;
		this.Wind.keys[14].inTangent = 0.01110137f;
		this.Wind.keys[14].outTangent = 0.01110137f;
		this.Wind.AddKey(1.797593f, 0.04921142f);
		this.Wind.keys[15].tangentMode = 0;
		this.Wind.keys[15].inTangent = 3.407104f;
		this.Wind.keys[15].outTangent = 3.407104f;
		this.Wind.AddKey(1.927248f, -0.1877219f);
		this.Wind.keys[16].tangentMode = 0;
		this.Wind.keys[16].inTangent = -0.001117587f;
		this.Wind.keys[16].outTangent = -0.001117587f;
		this.Wind.AddKey(2.067694f, 0.2742145f);
		this.Wind.keys[17].tangentMode = 0;
		this.Wind.keys[17].inTangent = 4.736587f;
		this.Wind.keys[17].outTangent = 4.736587f;
		this.Wind.AddKey(2.184602f, -0.06127208f);
		this.Wind.keys[18].tangentMode = 0;
		this.Wind.keys[18].inTangent = -0.1308322f;
		this.Wind.keys[18].outTangent = -0.1308322f;
		this.Wind.AddKey(2.305948f, 0.1891117f);
		this.Wind.keys[19].tangentMode = 0;
		this.Wind.keys[19].inTangent = 0.04030764f;
		this.Wind.keys[19].outTangent = 0.04030764f;
		this.Wind.AddKey(2.428946f, -0.1695723f);
		this.Wind.keys[20].tangentMode = 0;
		this.Wind.keys[20].inTangent = -0.2463162f;
		this.Wind.keys[20].outTangent = -0.2463162f;
		this.Wind.AddKey(2.55922f, 0.0359862f);
		this.Wind.keys[21].tangentMode = 0;
		this.Wind.keys[21].inTangent = 0.3967434f;
		this.Wind.keys[21].outTangent = 0.3967434f;
		this.Wind.AddKey(2.785119f, -0.08398628f);
		this.Wind.keys[22].tangentMode = 0;
		this.Wind.keys[22].inTangent = -0.2388284f;
		this.Wind.keys[22].outTangent = -0.2388284f;
		this.Wind.AddKey(3f, 0f);
		this.Wind.keys[23].tangentMode = 0;
		this.Wind.keys[23].inTangent = 0f;
		this.Wind.keys[23].outTangent = 0f;
		this.Wind.postWrapMode = WrapMode.Loop;
		this.Wind.preWrapMode = WrapMode.Loop;
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00013DD0 File Offset: 0x000121D0
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00013DD8 File Offset: 0x000121D8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Heat);
				if (this.Wind != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Wind", this.Wind.Evaluate(this.WindTime1));
				}
				if (this.Wind != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Wind2", this.Wind.Evaluate(this.WindTime2));
				}
				if (this.Wind != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Wind3", this.Wind.Evaluate(this.WindTime3));
				}
				if (this.Wind != null)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Wind4", this.Wind.Evaluate(this.WindTime4));
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Heat);
				if (this.Wind != null)
				{
					this.CanvasImage.material.SetFloat("_Wind", this.Wind.Evaluate(this.WindTime1));
				}
				if (this.Wind != null)
				{
					this.CanvasImage.material.SetFloat("_Wind2", this.Wind.Evaluate(this.WindTime2));
				}
				if (this.Wind != null)
				{
					this.CanvasImage.material.SetFloat("_Wind3", this.Wind.Evaluate(this.WindTime3));
				}
				if (this.Wind != null)
				{
					this.CanvasImage.material.SetFloat("_Wind4", this.Wind.Evaluate(this.WindTime4));
				}
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
			}
			this.WindTime1 += Time.deltaTime / 8f * this.Speed;
			this.WindTime2 += Time.deltaTime / 8f * this.Speed;
			this.WindTime3 += Time.deltaTime / 8f * this.Speed;
			this.WindTime4 += Time.deltaTime / 8f * this.Speed;
		}
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x0001461C File Offset: 0x00012A1C
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

	// Token: 0x060000C7 RID: 199 RVA: 0x00014728 File Offset: 0x00012B28
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

	// Token: 0x060000C8 RID: 200 RVA: 0x00014804 File Offset: 0x00012C04
	private void OnEnable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		this.WindTime1 = 0f;
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

	// Token: 0x04000163 RID: 355
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000164 RID: 356
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000165 RID: 357
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x04000166 RID: 358
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x04000167 RID: 359
	[HideInInspector]
	public int BlendMode;

	// Token: 0x04000168 RID: 360
	private string shader = "2DxFX/AL/GrassMultiFX";

	// Token: 0x04000169 RID: 361
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400016A RID: 362
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x0400016B RID: 363
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x0400016C RID: 364
	private AnimationCurve Wind;

	// Token: 0x0400016D RID: 365
	private float WindTime1;

	// Token: 0x0400016E RID: 366
	private float WindTime2 = 0.015f;

	// Token: 0x0400016F RID: 367
	private float WindTime3 = 0.03f;

	// Token: 0x04000170 RID: 368
	private float WindTime4 = 0.045f;

	// Token: 0x04000171 RID: 369
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000172 RID: 370
	private Material tempMaterial;

	// Token: 0x04000173 RID: 371
	private Material defaultMaterial;

	// Token: 0x04000174 RID: 372
	private Image CanvasImage;
}
