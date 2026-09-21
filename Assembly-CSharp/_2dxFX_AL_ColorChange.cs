using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x0200000B RID: 11
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/ColorChange")]
[Serializable]
public class _2dxFX_AL_ColorChange : MonoBehaviour
{
	// Token: 0x06000049 RID: 73 RVA: 0x00008868 File Offset: 0x00006C68
	public _2dxFX_AL_ColorChange()
	{
	}

	// Token: 0x0600004A RID: 74 RVA: 0x000088EA File Offset: 0x00006CEA
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00008913 File Offset: 0x00006D13
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x0000891C File Offset: 0x00006D1C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00008924 File Offset: 0x00006D24
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._Color);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Tolerance", this._Tolerance);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_HueShift", this._HueShift);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Sat", this._Saturation);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Val", this._ValueBrightness);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetColor("_ColorX", this._Color);
				this.CanvasImage.material.SetFloat("_Tolerance", this._Tolerance);
				this.CanvasImage.material.SetFloat("_HueShift", this._HueShift);
				this.CanvasImage.material.SetFloat("_Sat", this._Saturation);
				this.CanvasImage.material.SetFloat("_Val", this._ValueBrightness);
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00009008 File Offset: 0x00007408
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

	// Token: 0x0600004F RID: 79 RVA: 0x00009114 File Offset: 0x00007514
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

	// Token: 0x06000050 RID: 80 RVA: 0x000091F0 File Offset: 0x000075F0
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

	// Token: 0x0400007A RID: 122
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400007B RID: 123
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400007C RID: 124
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x0400007D RID: 125
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x0400007E RID: 126
	[HideInInspector]
	public int BlendMode;

	// Token: 0x0400007F RID: 127
	private string shader = "2DxFX/AL/ColorChange";

	// Token: 0x04000080 RID: 128
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000081 RID: 129
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Tolerance = 1f;

	// Token: 0x04000082 RID: 130
	[HideInInspector]
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x04000083 RID: 131
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _Saturation = 1f;

	// Token: 0x04000084 RID: 132
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _ValueBrightness = 1f;

	// Token: 0x04000085 RID: 133
	[HideInInspector]
	public Color _Color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x04000086 RID: 134
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000087 RID: 135
	private Material tempMaterial;

	// Token: 0x04000088 RID: 136
	private Material defaultMaterial;

	// Token: 0x04000089 RID: 137
	private Image CanvasImage;
}
