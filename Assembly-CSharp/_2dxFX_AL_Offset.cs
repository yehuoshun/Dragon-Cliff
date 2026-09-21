using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x0200002F RID: 47
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/Offset")]
[Serializable]
public class _2dxFX_AL_Offset : MonoBehaviour
{
	// Token: 0x06000169 RID: 361 RVA: 0x00021FAC File Offset: 0x000203AC
	public _2dxFX_AL_Offset()
	{
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00022004 File Offset: 0x00020404
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0002202D File Offset: 0x0002042D
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00022036 File Offset: 0x00020436
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00022040 File Offset: 0x00020440
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
				if (this._AutoScrollX)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * 0.01f * Time.deltaTime;
					if (this._AutoScrollCountX < 0f)
					{
						this._AutoScrollCountX = 1f;
					}
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", 1f + this._AutoScrollCountX);
				}
				else
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", 1f + this._OffsetX);
				}
				if (this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * 0.01f * Time.deltaTime;
					if (this._AutoScrollCountY < 0f)
					{
						this._AutoScrollCountY = 1f;
					}
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", 1f + this._AutoScrollCountY);
				}
				else
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", 1f + this._OffsetY);
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ZoomX", this._ZoomX * this._ZoomXY);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ZoomY", this._ZoomY * this._ZoomXY);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				if (this._AutoScrollX)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * 0.01f * Time.deltaTime;
					if (this._AutoScrollCountX < 0f)
					{
						this._AutoScrollCountX = 1f;
					}
					this.CanvasImage.material.SetFloat("_OffsetX", 1f + this._AutoScrollCountX);
				}
				else
				{
					this.CanvasImage.material.SetFloat("_OffsetX", 1f + this._OffsetX);
				}
				if (this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * 0.01f * Time.deltaTime;
					if (this._AutoScrollCountY < 0f)
					{
						this._AutoScrollCountY = 1f;
					}
					this.CanvasImage.material.SetFloat("_OffsetY", 1f + this._AutoScrollCountY);
				}
				else
				{
					this.CanvasImage.material.SetFloat("_OffsetY", 1f + this._OffsetY);
				}
				this.CanvasImage.material.SetFloat("_ZoomX", this._ZoomX * this._ZoomXY);
				this.CanvasImage.material.SetFloat("_ZoomY", this._ZoomY * this._ZoomXY);
			}
		}
	}

	// Token: 0x0600016E RID: 366 RVA: 0x000228CC File Offset: 0x00020CCC
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

	// Token: 0x0600016F RID: 367 RVA: 0x000229D8 File Offset: 0x00020DD8
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

	// Token: 0x06000170 RID: 368 RVA: 0x00022AB4 File Offset: 0x00020EB4
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

	// Token: 0x040002AB RID: 683
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040002AC RID: 684
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040002AD RID: 685
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x040002AE RID: 686
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x040002AF RID: 687
	[HideInInspector]
	public int BlendMode;

	// Token: 0x040002B0 RID: 688
	private string shader = "2DxFX/AL/Offset";

	// Token: 0x040002B1 RID: 689
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040002B2 RID: 690
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _OffsetX;

	// Token: 0x040002B3 RID: 691
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _OffsetY;

	// Token: 0x040002B4 RID: 692
	[HideInInspector]
	[Range(0.001f, 8f)]
	public float _ZoomX = 1f;

	// Token: 0x040002B5 RID: 693
	[HideInInspector]
	[Range(0.001f, 8f)]
	public float _ZoomY = 1f;

	// Token: 0x040002B6 RID: 694
	[HideInInspector]
	[Range(0.001f, 64f)]
	public float _ZoomXY = 1f;

	// Token: 0x040002B7 RID: 695
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040002B8 RID: 696
	[HideInInspector]
	[Range(-100f, 100f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040002B9 RID: 697
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040002BA RID: 698
	[HideInInspector]
	[Range(-100f, 100f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040002BB RID: 699
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040002BC RID: 700
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040002BD RID: 701
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040002BE RID: 702
	private Material tempMaterial;

	// Token: 0x040002BF RID: 703
	private Material defaultMaterial;

	// Token: 0x040002C0 RID: 704
	private Image CanvasImage;
}
