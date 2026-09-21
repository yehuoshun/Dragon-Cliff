using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000040 RID: 64
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Smoke")]
[Serializable]
public class _2dxFX_AL_Smoke : MonoBehaviour
{
	// Token: 0x060001F1 RID: 497 RVA: 0x0002E12C File Offset: 0x0002C52C
	public _2dxFX_AL_Smoke()
	{
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0002E1C2 File Offset: 0x0002C5C2
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0002E1EC File Offset: 0x0002C5EC
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
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

	// Token: 0x060001F4 RID: 500 RVA: 0x0002E27C File Offset: 0x0002C67C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0002E284 File Offset: 0x0002C684
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value1", this._Value1);
				if (this._TurnToSmoke == 1f)
				{
					this._TurnToSmoke = 0.995f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", this._TurnToSmoke);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", this._Value3);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this._Value4);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color1", this._Color1);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color2", this._Color2);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Value1", this._Value1);
				if (this._TurnToSmoke == 1f)
				{
					this._TurnToSmoke = 0.995f;
				}
				this.CanvasImage.material.SetFloat("_Value2", this._TurnToSmoke);
				this.CanvasImage.material.SetFloat("_Value3", this._Value3);
				this.CanvasImage.material.SetFloat("_Value4", this._Value4);
				this.CanvasImage.material.SetColor("_Color1", this._Color1);
				this.CanvasImage.material.SetColor("_Color2", this._Color2);
			}
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0002E9D4 File Offset: 0x0002CDD4
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

	// Token: 0x060001F7 RID: 503 RVA: 0x0002EAE0 File Offset: 0x0002CEE0
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

	// Token: 0x060001F8 RID: 504 RVA: 0x0002EBBC File Offset: 0x0002CFBC
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
			this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
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

	// Token: 0x040003B7 RID: 951
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040003B8 RID: 952
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040003B9 RID: 953
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x040003BA RID: 954
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x040003BB RID: 955
	[HideInInspector]
	public int BlendMode;

	// Token: 0x040003BC RID: 956
	private string shader = "2DxFX/AL/Smoke";

	// Token: 0x040003BD RID: 957
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040003BE RID: 958
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x040003BF RID: 959
	[HideInInspector]
	[Range(64f, 256f)]
	public float _Value1 = 64f;

	// Token: 0x040003C0 RID: 960
	[HideInInspector]
	[Range(0f, 1f)]
	public float _TurnToSmoke = 0.75f;

	// Token: 0x040003C1 RID: 961
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value3 = 1f;

	// Token: 0x040003C2 RID: 962
	[HideInInspector]
	public float _Value4;

	// Token: 0x040003C3 RID: 963
	[HideInInspector]
	public Color _Color1 = new Color(1f, 0f, 1f, 1f);

	// Token: 0x040003C4 RID: 964
	[HideInInspector]
	public Color _Color2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040003C5 RID: 965
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040003C6 RID: 966
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040003C7 RID: 967
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040003C8 RID: 968
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040003C9 RID: 969
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040003CA RID: 970
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040003CB RID: 971
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040003CC RID: 972
	private Material tempMaterial;

	// Token: 0x040003CD RID: 973
	private Material defaultMaterial;

	// Token: 0x040003CE RID: 974
	private Image CanvasImage;
}
