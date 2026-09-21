using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000079 RID: 121
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/NewTeleportation2")]
[Serializable]
public class _2dxFX_NewTeleportation2 : MonoBehaviour
{
	// Token: 0x060003B3 RID: 947 RVA: 0x0004937C File Offset: 0x0004777C
	public _2dxFX_NewTeleportation2()
	{
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x000493E7 File Offset: 0x000477E7
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x00049410 File Offset: 0x00047810
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportation2TXT") as Texture2D);
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

	// Token: 0x060003B6 RID: 950 RVA: 0x000494A0 File Offset: 0x000478A0
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x000494A8 File Offset: 0x000478A8
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("TeleportationColor", this.TeleportationColor);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this._Distortion);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Fade", this._Fade);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_HDR_Intensity", this._HDR_Intensity);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetColor("TeleportationColor", this.TeleportationColor);
				this.CanvasImage.material.SetFloat("_Distortion", this._Distortion);
				this.CanvasImage.material.SetFloat("_Fade", this._Fade);
				this.CanvasImage.material.SetFloat("_HDR_Intensity", this._HDR_Intensity);
			}
		}
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x000497AC File Offset: 0x00047BAC
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

	// Token: 0x060003B9 RID: 953 RVA: 0x000498B8 File Offset: 0x00047CB8
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

	// Token: 0x060003BA RID: 954 RVA: 0x00049994 File Offset: 0x00047D94
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
			this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportation2TXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportation2TXT") as Texture2D);
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

	// Token: 0x0400068F RID: 1679
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000690 RID: 1680
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000691 RID: 1681
	private string shader = "2DxFX/Standard/NewTeleportation2";

	// Token: 0x04000692 RID: 1682
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000693 RID: 1683
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000694 RID: 1684
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Fade = 0.5f;

	// Token: 0x04000695 RID: 1685
	[HideInInspector]
	[Range(1f, 16f)]
	public float _HDR_Intensity = 1f;

	// Token: 0x04000696 RID: 1686
	[HideInInspector]
	public Color TeleportationColor = new Color(0f, 0.5f, 1f);

	// Token: 0x04000697 RID: 1687
	[HideInInspector]
	[Range(0.1f, 2f)]
	public float _Distortion = 1f;

	// Token: 0x04000698 RID: 1688
	[HideInInspector]
	public float _Value4;

	// Token: 0x04000699 RID: 1689
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x0400069A RID: 1690
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x0400069B RID: 1691
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x0400069C RID: 1692
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x0400069D RID: 1693
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x0400069E RID: 1694
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x0400069F RID: 1695
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006A0 RID: 1696
	private Material tempMaterial;

	// Token: 0x040006A1 RID: 1697
	private Material defaultMaterial;

	// Token: 0x040006A2 RID: 1698
	private Image CanvasImage;
}
