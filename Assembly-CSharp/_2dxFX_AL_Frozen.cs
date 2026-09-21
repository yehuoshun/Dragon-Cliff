using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000015 RID: 21
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Frozen")]
[Serializable]
public class _2dxFX_AL_Frozen : MonoBehaviour
{
	// Token: 0x06000099 RID: 153 RVA: 0x0000F480 File Offset: 0x0000D880
	public _2dxFX_AL_Frozen()
	{
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000F4D8 File Offset: 0x0000D8D8
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000F504 File Offset: 0x0000D904
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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

	// Token: 0x0600009C RID: 156 RVA: 0x0000F594 File Offset: 0x0000D994
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000F59C File Offset: 0x0000D99C
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", this._Value2);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", this._Value3);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this._Value4);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Value1", this._Value1);
				this.CanvasImage.material.SetFloat("_Value2", this._Value2);
				this.CanvasImage.material.SetFloat("_Value3", this._Value3);
				this.CanvasImage.material.SetFloat("_Value4", this._Value4);
			}
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000FC48 File Offset: 0x0000E048
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

	// Token: 0x0600009F RID: 159 RVA: 0x0000FD54 File Offset: 0x0000E154
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

	// Token: 0x060000A0 RID: 160 RVA: 0x0000FE30 File Offset: 0x0000E230
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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

	// Token: 0x04000116 RID: 278
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000117 RID: 279
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000118 RID: 280
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x04000119 RID: 281
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x0400011A RID: 282
	[HideInInspector]
	public int BlendMode;

	// Token: 0x0400011B RID: 283
	private string shader = "2DxFX/AL/Frozen";

	// Token: 0x0400011C RID: 284
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400011D RID: 285
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x0400011E RID: 286
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value1 = 0.5f;

	// Token: 0x0400011F RID: 287
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value2 = 1f;

	// Token: 0x04000120 RID: 288
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value3 = 1f;

	// Token: 0x04000121 RID: 289
	[HideInInspector]
	public float _Value4;

	// Token: 0x04000122 RID: 290
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x04000123 RID: 291
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x04000124 RID: 292
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x04000125 RID: 293
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x04000126 RID: 294
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x04000127 RID: 295
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x04000128 RID: 296
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000129 RID: 297
	private Material tempMaterial;

	// Token: 0x0400012A RID: 298
	private Material defaultMaterial;

	// Token: 0x0400012B RID: 299
	private Image CanvasImage;
}
