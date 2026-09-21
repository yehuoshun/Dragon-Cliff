using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x0200002A RID: 42
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Mystic_Distortion")]
[Serializable]
public class _2dxFX_AL_Mystic_Distortion : MonoBehaviour
{
	// Token: 0x06000141 RID: 321 RVA: 0x0001EC30 File Offset: 0x0001D030
	public _2dxFX_AL_Mystic_Distortion()
	{
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0001ECE7 File Offset: 0x0001D0E7
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0001ED10 File Offset: 0x0001D110
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0001ED19 File Offset: 0x0001D119
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0001ED24 File Offset: 0x0001D124
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
			if (this.Pitch_Wave)
			{
				this._Pitch_Offset = Mathf.Sin(Time.time * this._Pitch_Speed) * 0.05f;
			}
			else
			{
				this._Pitch_Offset = 0f;
			}
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Pitch", this._Pitch + this._Pitch_Offset);
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
				this.CanvasImage.material.SetFloat("_Pitch", this._Pitch + this._Pitch_Offset);
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

	// Token: 0x06000146 RID: 326 RVA: 0x0001F564 File Offset: 0x0001D964
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

	// Token: 0x06000147 RID: 327 RVA: 0x0001F670 File Offset: 0x0001DA70
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

	// Token: 0x06000148 RID: 328 RVA: 0x0001F74C File Offset: 0x0001DB4C
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

	// Token: 0x04000261 RID: 609
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000262 RID: 610
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000263 RID: 611
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x04000264 RID: 612
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x04000265 RID: 613
	[HideInInspector]
	public int BlendMode;

	// Token: 0x04000266 RID: 614
	private string shader = "2DxFX/AL/Mystic_Distortion";

	// Token: 0x04000267 RID: 615
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000268 RID: 616
	[HideInInspector]
	[Range(0f, 0.45f)]
	public float _Pitch = 0.45f;

	// Token: 0x04000269 RID: 617
	[HideInInspector]
	public bool Pitch_Wave = true;

	// Token: 0x0400026A RID: 618
	[HideInInspector]
	[Range(0f, 16f)]
	public float _Pitch_Speed = 1f;

	// Token: 0x0400026B RID: 619
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Pitch_Offset;

	// Token: 0x0400026C RID: 620
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetX = 56f;

	// Token: 0x0400026D RID: 621
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetY = 28f;

	// Token: 0x0400026E RID: 622
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceX = 0.01f;

	// Token: 0x0400026F RID: 623
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceY = 0.04f;

	// Token: 0x04000270 RID: 624
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeX = 1.16f;

	// Token: 0x04000271 RID: 625
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeY = 5.12f;

	// Token: 0x04000272 RID: 626
	[HideInInspector]
	public bool AutoPlayWaveX;

	// Token: 0x04000273 RID: 627
	[HideInInspector]
	[Range(0f, 5f)]
	public float AutoPlaySpeedX = 5f;

	// Token: 0x04000274 RID: 628
	[HideInInspector]
	public bool AutoPlayWaveY;

	// Token: 0x04000275 RID: 629
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoPlaySpeedY = 5f;

	// Token: 0x04000276 RID: 630
	[HideInInspector]
	public bool AutoRandom;

	// Token: 0x04000277 RID: 631
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoRandomRange = 10f;

	// Token: 0x04000278 RID: 632
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000279 RID: 633
	private Material tempMaterial;

	// Token: 0x0400027A RID: 634
	private Material defaultMaterial;

	// Token: 0x0400027B RID: 635
	private Image CanvasImage;
}
