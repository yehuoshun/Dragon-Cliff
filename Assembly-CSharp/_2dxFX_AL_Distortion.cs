using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000010 RID: 16
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Distortion")]
[Serializable]
public class _2dxFX_AL_Distortion : MonoBehaviour
{
	// Token: 0x06000071 RID: 113 RVA: 0x0000BC44 File Offset: 0x0000A044
	public _2dxFX_AL_Distortion()
	{
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000BCDE File Offset: 0x0000A0DE
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x0000BD07 File Offset: 0x0000A107
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0000BD10 File Offset: 0x0000A110
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000075 RID: 117 RVA: 0x0000BD18 File Offset: 0x0000A118
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceX", this._DistanceX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceY", this._DistanceY);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeX", this._WaveTimeX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeY", this._WaveTimeY);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
				this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				this.CanvasImage.material.SetFloat("_DistanceX", this._DistanceX);
				this.CanvasImage.material.SetFloat("_DistanceY", this._DistanceY);
				this.CanvasImage.material.SetFloat("_WaveTimeX", this._WaveTimeX);
				this.CanvasImage.material.SetFloat("_WaveTimeY", this._WaveTimeY);
			}
			float num;
			if (this.AutoRandom)
			{
				num = UnityEngine.Random.Range(1f, this.AutoRandomRange) / 5f * Time.deltaTime;
			}
			else
			{
				num = Time.deltaTime;
			}
			if (this.AutoPlayWaveX)
			{
				this._WaveTimeX += this.AutoPlaySpeedX * num;
			}
			if (this.AutoPlayWaveY)
			{
				this._WaveTimeY += this.AutoPlaySpeedY * num;
			}
			if (this._WaveTimeX > 6.28f)
			{
				this._WaveTimeX = 0f;
			}
			if (this._WaveTimeY > 6.28f)
			{
				this._WaveTimeY = 0f;
			}
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x0000C4DC File Offset: 0x0000A8DC
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

	// Token: 0x06000077 RID: 119 RVA: 0x0000C5E8 File Offset: 0x0000A9E8
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

	// Token: 0x06000078 RID: 120 RVA: 0x0000C6C4 File Offset: 0x0000AAC4
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

	// Token: 0x040000BF RID: 191
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040000C0 RID: 192
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040000C1 RID: 193
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x040000C2 RID: 194
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x040000C3 RID: 195
	[HideInInspector]
	public int BlendMode;

	// Token: 0x040000C4 RID: 196
	private string shader = "2DxFX/AL/Distortion";

	// Token: 0x040000C5 RID: 197
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040000C6 RID: 198
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetX = 10f;

	// Token: 0x040000C7 RID: 199
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetY = 10f;

	// Token: 0x040000C8 RID: 200
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceX = 0.03f;

	// Token: 0x040000C9 RID: 201
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceY = 0.03f;

	// Token: 0x040000CA RID: 202
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeX = 0.16f;

	// Token: 0x040000CB RID: 203
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeY = 0.12f;

	// Token: 0x040000CC RID: 204
	[HideInInspector]
	public bool AutoPlayWaveX;

	// Token: 0x040000CD RID: 205
	[HideInInspector]
	[Range(0f, 5f)]
	public float AutoPlaySpeedX = 5f;

	// Token: 0x040000CE RID: 206
	[HideInInspector]
	public bool AutoPlayWaveY;

	// Token: 0x040000CF RID: 207
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoPlaySpeedY = 5f;

	// Token: 0x040000D0 RID: 208
	[HideInInspector]
	public bool AutoRandom;

	// Token: 0x040000D1 RID: 209
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoRandomRange = 10f;

	// Token: 0x040000D2 RID: 210
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040000D3 RID: 211
	private Material tempMaterial;

	// Token: 0x040000D4 RID: 212
	private Material defaultMaterial;

	// Token: 0x040000D5 RID: 213
	private Image CanvasImage;
}
