using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007F RID: 127
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/PatternAdditive")]
[Serializable]
public class _2dxFX_PatternAdditive : MonoBehaviour
{
	// Token: 0x060003E3 RID: 995 RVA: 0x0004C144 File Offset: 0x0004A544
	public _2dxFX_PatternAdditive()
	{
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0004C169 File Offset: 0x0004A569
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0004C192 File Offset: 0x0004A592
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0004C19B File Offset: 0x0004A59B
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0004C1A4 File Offset: 0x0004A5A4
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
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
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

	// Token: 0x060003E8 RID: 1000 RVA: 0x0004C76C File Offset: 0x0004AB6C
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

	// Token: 0x060003E9 RID: 1001 RVA: 0x0004C878 File Offset: 0x0004AC78
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

	// Token: 0x060003EA RID: 1002 RVA: 0x0004C960 File Offset: 0x0004AD60
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

	// Token: 0x040006E3 RID: 1763
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006E4 RID: 1764
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006E5 RID: 1765
	private string shader = "2DxFX/Standard/PatternAdditive";

	// Token: 0x040006E6 RID: 1766
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040006E7 RID: 1767
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x040006E8 RID: 1768
	[HideInInspector]
	public float _OffsetX;

	// Token: 0x040006E9 RID: 1769
	[HideInInspector]
	public float _OffsetY;

	// Token: 0x040006EA RID: 1770
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040006EB RID: 1771
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040006EC RID: 1772
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040006ED RID: 1773
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040006EE RID: 1774
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040006EF RID: 1775
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040006F0 RID: 1776
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006F1 RID: 1777
	private Material tempMaterial;

	// Token: 0x040006F2 RID: 1778
	private Material defaultMaterial;

	// Token: 0x040006F3 RID: 1779
	private Image CanvasImage;
}
