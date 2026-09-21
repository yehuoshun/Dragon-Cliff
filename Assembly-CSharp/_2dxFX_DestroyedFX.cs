using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000057 RID: 87
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/DestroyedFX")]
[Serializable]
public class _2dxFX_DestroyedFX : MonoBehaviour
{
	// Token: 0x060002A3 RID: 675 RVA: 0x00038572 File Offset: 0x00036972
	public _2dxFX_DestroyedFX()
	{
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x000385AD File Offset: 0x000369AD
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x000385D6 File Offset: 0x000369D6
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x000385DF File Offset: 0x000369DF
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x000385E8 File Offset: 0x000369E8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Destroyed);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Size", this.Seed);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Destroyed);
				this.CanvasImage.material.SetFloat("_Size", this.Seed);
			}
		}
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x00038880 File Offset: 0x00036C80
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

	// Token: 0x060002A9 RID: 681 RVA: 0x0003898C File Offset: 0x00036D8C
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

	// Token: 0x060002AA RID: 682 RVA: 0x00038A68 File Offset: 0x00036E68
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

	// Token: 0x040004B3 RID: 1203
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040004B4 RID: 1204
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040004B5 RID: 1205
	private string shader = "2DxFX/Standard/DestroyedFX";

	// Token: 0x040004B6 RID: 1206
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040004B7 RID: 1207
	[HideInInspector]
	[Range(0.001f, 1f)]
	public float Seed = 1f;

	// Token: 0x040004B8 RID: 1208
	[HideInInspector]
	[Range(0f, 1f)]
	public float Destroyed = 0.5f;

	// Token: 0x040004B9 RID: 1209
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040004BA RID: 1210
	private Material tempMaterial;

	// Token: 0x040004BB RID: 1211
	private Material defaultMaterial;

	// Token: 0x040004BC RID: 1212
	private Image CanvasImage;
}
