using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200008F RID: 143
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Smoke")]
[Serializable]
public class _2dxFX_Smoke : MonoBehaviour
{
	// Token: 0x06000463 RID: 1123 RVA: 0x00053BDC File Offset: 0x00051FDC
	public _2dxFX_Smoke()
	{
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00053C6B File Offset: 0x0005206B
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x00053C94 File Offset: 0x00052094
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
		this.ShaderChange = 0;
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
		else if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
		}
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00053D24 File Offset: 0x00052124
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00053D2C File Offset: 0x0005212C
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value1", this._Value1);
				if (this._Value2 == 1f)
				{
					this._Value2 = 0.995f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", this._Value2);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", this._Value3);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this._Value4);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color1", this._Color1);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_Color2", this._Color2);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Value1", this._Value1);
				if (this._Value2 == 1f)
				{
					this._Value2 = 0.995f;
				}
				this.CanvasImage.material.SetFloat("_Value2", this._Value2);
				this.CanvasImage.material.SetFloat("_Value3", this._Value3);
				this.CanvasImage.material.SetFloat("_Value4", this._Value4);
				this.CanvasImage.material.SetColor("_Color1", this._Color1);
				this.CanvasImage.material.SetColor("_Color2", this._Color2);
			}
		}
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x000540D4 File Offset: 0x000524D4
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

	// Token: 0x06000469 RID: 1129 RVA: 0x000541E0 File Offset: 0x000525E0
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

	// Token: 0x0600046A RID: 1130 RVA: 0x000542BC File Offset: 0x000526BC
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
			this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_SmokeTXT") as Texture2D);
		}
		if (this.__MainTex2)
		{
			this.__MainTex2.wrapMode = TextureWrapMode.Repeat;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
			}
		}
	}

	// Token: 0x040007AB RID: 1963
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040007AC RID: 1964
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040007AD RID: 1965
	private string shader = "2DxFX/Standard/Smoke";

	// Token: 0x040007AE RID: 1966
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040007AF RID: 1967
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x040007B0 RID: 1968
	[HideInInspector]
	[Range(64f, 256f)]
	public float _Value1 = 64f;

	// Token: 0x040007B1 RID: 1969
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value2 = 1f;

	// Token: 0x040007B2 RID: 1970
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value3 = 1f;

	// Token: 0x040007B3 RID: 1971
	[HideInInspector]
	public float _Value4;

	// Token: 0x040007B4 RID: 1972
	[HideInInspector]
	public Color _Color1 = new Color(1f, 0f, 1f, 1f);

	// Token: 0x040007B5 RID: 1973
	[HideInInspector]
	public Color _Color2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040007B6 RID: 1974
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x040007B7 RID: 1975
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x040007B8 RID: 1976
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x040007B9 RID: 1977
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x040007BA RID: 1978
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x040007BB RID: 1979
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x040007BC RID: 1980
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040007BD RID: 1981
	private Material tempMaterial;

	// Token: 0x040007BE RID: 1982
	private Material defaultMaterial;

	// Token: 0x040007BF RID: 1983
	private Image CanvasImage;
}
