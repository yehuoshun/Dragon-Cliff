using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007C RID: 124
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Offset")]
[Serializable]
public class _2dxFX_Offset : MonoBehaviour
{
	// Token: 0x060003CB RID: 971 RVA: 0x0004A834 File Offset: 0x00048C34
	public _2dxFX_Offset()
	{
	}

	// Token: 0x060003CC RID: 972 RVA: 0x0004A885 File Offset: 0x00048C85
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0004A8AE File Offset: 0x00048CAE
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0004A8B7 File Offset: 0x00048CB7
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0004A8C0 File Offset: 0x00048CC0
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

	// Token: 0x060003D0 RID: 976 RVA: 0x0004ADA4 File Offset: 0x000491A4
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

	// Token: 0x060003D1 RID: 977 RVA: 0x0004AEB0 File Offset: 0x000492B0
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

	// Token: 0x060003D2 RID: 978 RVA: 0x0004AF8C File Offset: 0x0004938C
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

	// Token: 0x040006B5 RID: 1717
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006B6 RID: 1718
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006B7 RID: 1719
	private string shader = "2DxFX/Standard/Offset";

	// Token: 0x040006B8 RID: 1720
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040006B9 RID: 1721
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _OffsetX;

	// Token: 0x040006BA RID: 1722
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _OffsetY;

	// Token: 0x040006BB RID: 1723
	[HideInInspector]
	[Range(0.001f, 8f)]
	public float _ZoomX = 1f;

	// Token: 0x040006BC RID: 1724
	[HideInInspector]
	[Range(0.001f, 8f)]
	public float _ZoomY = 1f;

	// Token: 0x040006BD RID: 1725
	[HideInInspector]
	[Range(0.001f, 64f)]
	public float _ZoomXY = 1f;

	// Token: 0x040006BE RID: 1726
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040006BF RID: 1727
	[HideInInspector]
	[Range(-100f, 100f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040006C0 RID: 1728
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040006C1 RID: 1729
	[HideInInspector]
	[Range(-100f, 100f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040006C2 RID: 1730
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040006C3 RID: 1731
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040006C4 RID: 1732
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006C5 RID: 1733
	private Material tempMaterial;

	// Token: 0x040006C6 RID: 1734
	private Material defaultMaterial;

	// Token: 0x040006C7 RID: 1735
	private Image CanvasImage;
}
