using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007E RID: 126
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Pattern")]
[Serializable]
public class _2dxFX_Pattern : MonoBehaviour
{
	// Token: 0x060003DB RID: 987 RVA: 0x0004B78E File Offset: 0x00049B8E
	public _2dxFX_Pattern()
	{
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0004B7B3 File Offset: 0x00049BB3
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0004B7DC File Offset: 0x00049BDC
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0004B7E5 File Offset: 0x00049BE5
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0004B7F0 File Offset: 0x00049BF0
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

	// Token: 0x060003E0 RID: 992 RVA: 0x0004BDB8 File Offset: 0x0004A1B8
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

	// Token: 0x060003E1 RID: 993 RVA: 0x0004BEC4 File Offset: 0x0004A2C4
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

	// Token: 0x060003E2 RID: 994 RVA: 0x0004BFAC File Offset: 0x0004A3AC
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

	// Token: 0x040006D2 RID: 1746
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006D3 RID: 1747
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006D4 RID: 1748
	private string shader = "2DxFX/Standard/Pattern";

	// Token: 0x040006D5 RID: 1749
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040006D6 RID: 1750
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x040006D7 RID: 1751
	[HideInInspector]
	public float _OffsetX;

	// Token: 0x040006D8 RID: 1752
	[HideInInspector]
	public float _OffsetY;

	// Token: 0x040006D9 RID: 1753
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040006DA RID: 1754
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040006DB RID: 1755
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040006DC RID: 1756
	[HideInInspector]
	[Range(-3f, 3f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040006DD RID: 1757
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040006DE RID: 1758
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040006DF RID: 1759
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006E0 RID: 1760
	private Material tempMaterial;

	// Token: 0x040006E1 RID: 1761
	private Material defaultMaterial;

	// Token: 0x040006E2 RID: 1762
	private Image CanvasImage;
}
