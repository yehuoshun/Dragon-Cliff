using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200006A RID: 106
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Hologram2")]
[Serializable]
public class _2dxFX_Hologram2 : MonoBehaviour
{
	// Token: 0x0600033B RID: 827 RVA: 0x00042236 File Offset: 0x00040636
	public _2dxFX_Hologram2()
	{
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00042271 File Offset: 0x00040671
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0004229A File Offset: 0x0004069A
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600033E RID: 830 RVA: 0x000422A3 File Offset: 0x000406A3
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600033F RID: 831 RVA: 0x000422AC File Offset: 0x000406AC
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
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Distortion);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_TimeX", 1f + this._TimeX);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				this.CanvasImage.material.SetFloat("_Distortion", this.Distortion);
				this.CanvasImage.material.SetFloat("_TimeX", 1f + this._TimeX);
			}
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x000425B8 File Offset: 0x000409B8
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

	// Token: 0x06000341 RID: 833 RVA: 0x000426C4 File Offset: 0x00040AC4
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

	// Token: 0x06000342 RID: 834 RVA: 0x000427A0 File Offset: 0x00040BA0
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

	// Token: 0x040005AC RID: 1452
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040005AD RID: 1453
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040005AE RID: 1454
	private string shader = "2DxFX/Standard/Hologram2";

	// Token: 0x040005AF RID: 1455
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040005B0 RID: 1456
	[HideInInspector]
	[Range(0f, 4f)]
	public float Distortion = 1f;

	// Token: 0x040005B1 RID: 1457
	[HideInInspector]
	private float _TimeX;

	// Token: 0x040005B2 RID: 1458
	[Range(0f, 3f)]
	[HideInInspector]
	public float Speed = 1f;

	// Token: 0x040005B3 RID: 1459
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040005B4 RID: 1460
	private Material tempMaterial;

	// Token: 0x040005B5 RID: 1461
	private Material defaultMaterial;

	// Token: 0x040005B6 RID: 1462
	private Image CanvasImage;
}
