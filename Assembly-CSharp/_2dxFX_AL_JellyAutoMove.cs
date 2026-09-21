using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000024 RID: 36
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Advanced Lightning/JellyAutoMove")]
[Serializable]
public class _2dxFX_AL_JellyAutoMove : MonoBehaviour
{
	// Token: 0x06000111 RID: 273 RVA: 0x0001A818 File Offset: 0x00018C18
	public _2dxFX_AL_JellyAutoMove()
	{
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0001A886 File Offset: 0x00018C86
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0001A8AF File Offset: 0x00018CAF
	private void Start()
	{
		this.ShaderChange = 0;
		this.Heat = 0f;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x0001A8C3 File Offset: 0x00018CC3
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000115 RID: 277 RVA: 0x0001A8CC File Offset: 0x00018CCC
	private void Update()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		this.SaveMove1 = base.transform.position;
		if (this.SaveMove1.x != this.SaveMove2.x)
		{
			this.Heat += 0.5f;
		}
		if (this.SaveMove1.y != this.SaveMove2.y)
		{
			this.Heat += 0.5f;
		}
		if (this.SaveMove1.z != this.SaveMove2.z)
		{
			this.Heat += 0.5f;
		}
		this.Heat -= Time.deltaTime * this.Stabilisation;
		if (this.Heat > 4f)
		{
			this.Heat = 4f;
		}
		if (this.Heat < 0f)
		{
			this.RandomPos = (float)UnityEngine.Random.Range(0, 256);
			this.Heat = 0f;
		}
		this.SaveMove2 = this.SaveMove1;
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_RandomPos", this.RandomPos);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Inside", this.Inside);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Heat);
				this.CanvasImage.material.SetFloat("_RandomPos", this.RandomPos);
				this.CanvasImage.material.SetFloat("_Inside", this.Inside);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
			}
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0001B080 File Offset: 0x00019480
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

	// Token: 0x06000117 RID: 279 RVA: 0x0001B18C File Offset: 0x0001958C
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

	// Token: 0x06000118 RID: 280 RVA: 0x0001B268 File Offset: 0x00019668
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

	// Token: 0x040001F7 RID: 503
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040001F8 RID: 504
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040001F9 RID: 505
	[HideInInspector]
	public bool AddShadow = true;

	// Token: 0x040001FA RID: 506
	[HideInInspector]
	public bool ReceivedShadow;

	// Token: 0x040001FB RID: 507
	[HideInInspector]
	public int BlendMode;

	// Token: 0x040001FC RID: 508
	private string shader = "2DxFX/AL/Jelly";

	// Token: 0x040001FD RID: 509
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040001FE RID: 510
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x040001FF RID: 511
	[HideInInspector]
	[Range(0f, 4f)]
	public float RandomPos = 1f;

	// Token: 0x04000200 RID: 512
	[HideInInspector]
	[Range(1f, 2f)]
	public float Inside = 1f;

	// Token: 0x04000201 RID: 513
	[HideInInspector]
	[Range(1f, 8f)]
	public float Stabilisation = 4f;

	// Token: 0x04000202 RID: 514
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x04000203 RID: 515
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000204 RID: 516
	private Material tempMaterial;

	// Token: 0x04000205 RID: 517
	private Material defaultMaterial;

	// Token: 0x04000206 RID: 518
	private Image CanvasImage;

	// Token: 0x04000207 RID: 519
	private Vector3 SaveMove1;

	// Token: 0x04000208 RID: 520
	private Vector3 SaveMove2;
}
