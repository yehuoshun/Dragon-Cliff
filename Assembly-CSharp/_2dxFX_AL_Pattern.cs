using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000031 RID: 49
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Pattern")]
[Serializable]
public class _2dxFX_AL_Pattern : MonoBehaviour
{
	// Token: 0x06000179 RID: 377 RVA: 0x00023666 File Offset: 0x00021A66
	public _2dxFX_AL_Pattern()
	{
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00023692 File Offset: 0x00021A92
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x000236BB File Offset: 0x00021ABB
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x000236C4 File Offset: 0x00021AC4
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600017D RID: 381 RVA: 0x000236CC File Offset: 0x00021ACC
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
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					base.GetComponent<Renderer>().material.SetFloat("_OffsetX", this._AutoScrollCountX);
					base.GetComponent<Renderer>().material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			if (this._AutoScrollCountX > 1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountX < -1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountY > 1f)
			{
				this._AutoScrollCountY = 0f;
			}
			if (this._AutoScrollCountY < -1f)
			{
				this._AutoScrollCountY = 0f;
			}
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0002403C File Offset: 0x0002243C
	private void OnDestroy()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (!Application.isPlaying && Application.isEditor)
		{
			if (this.ForceMaterial != null && this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (base.gameObject.activeSelf)
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

	// Token: 0x0600017F RID: 383 RVA: 0x00024148 File Offset: 0x00022548
	private void OnDisable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.ForceMaterial != null && this.tempMaterial != null)
		{
			UnityEngine.Object.DestroyImmediate(this.tempMaterial);
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

	// Token: 0x06000180 RID: 384 RVA: 0x00024230 File Offset: 0x00022630
	private void OnEnable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		this.defaultMaterial = new Material(Shader.Find("Sprites/Default"));
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
		if (this.__MainTex2)
		{
			this.__MainTex2.wrapMode = TextureWrapMode.Repeat;
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
	}

	// Token: 0x040002CE RID: 718
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040002CF RID: 719
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040002D0 RID: 720
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x040002D1 RID: 721
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x040002D2 RID: 722
	[HideInInspector]
	public int BlendMode;

	// Token: 0x040002D3 RID: 723
	private string shader = "2DxFX/AL/Pattern";

	// Token: 0x040002D4 RID: 724
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040002D5 RID: 725
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x040002D6 RID: 726
	[HideInInspector]
	public float _OffsetX;

	// Token: 0x040002D7 RID: 727
	[HideInInspector]
	public float _OffsetY;

	// Token: 0x040002D8 RID: 728
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040002D9 RID: 729
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040002DA RID: 730
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040002DB RID: 731
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040002DC RID: 732
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040002DD RID: 733
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040002DE RID: 734
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040002DF RID: 735
	private Material tempMaterial;

	// Token: 0x040002E0 RID: 736
	private Material defaultMaterial;

	// Token: 0x040002E1 RID: 737
	private Image CanvasImage;
}
