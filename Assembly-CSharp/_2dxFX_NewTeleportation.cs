using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000078 RID: 120
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/NewTeleportation")]
[Serializable]
public class _2dxFX_NewTeleportation : MonoBehaviour
{
	// Token: 0x060003AB RID: 939 RVA: 0x00048B44 File Offset: 0x00046F44
	public _2dxFX_NewTeleportation()
	{
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00048BAF File Offset: 0x00046FAF
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00048BD8 File Offset: 0x00046FD8
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportationTXT") as Texture2D);
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

	// Token: 0x060003AE RID: 942 RVA: 0x00048C68 File Offset: 0x00047068
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00048C70 File Offset: 0x00047070
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

	// Token: 0x060003B0 RID: 944 RVA: 0x00048F74 File Offset: 0x00047374
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

	// Token: 0x060003B1 RID: 945 RVA: 0x00049080 File Offset: 0x00047480
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

	// Token: 0x060003B2 RID: 946 RVA: 0x0004915C File Offset: 0x0004755C
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
			this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportationTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_NewTeleportationTXT") as Texture2D);
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

	// Token: 0x0400067B RID: 1659
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400067C RID: 1660
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400067D RID: 1661
	private string shader = "2DxFX/Standard/NewTeleportation";

	// Token: 0x0400067E RID: 1662
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400067F RID: 1663
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000680 RID: 1664
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Fade = 0.5f;

	// Token: 0x04000681 RID: 1665
	[HideInInspector]
	[Range(1f, 16f)]
	public float _HDR_Intensity = 1f;

	// Token: 0x04000682 RID: 1666
	[HideInInspector]
	public Color TeleportationColor = new Color(0f, 0.5f, 1f);

	// Token: 0x04000683 RID: 1667
	[HideInInspector]
	[Range(0.1f, 2f)]
	public float _Distortion = 1f;

	// Token: 0x04000684 RID: 1668
	[HideInInspector]
	public float _Value4;

	// Token: 0x04000685 RID: 1669
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x04000686 RID: 1670
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x04000687 RID: 1671
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x04000688 RID: 1672
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x04000689 RID: 1673
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x0400068A RID: 1674
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x0400068B RID: 1675
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400068C RID: 1676
	private Material tempMaterial;

	// Token: 0x0400068D RID: 1677
	private Material defaultMaterial;

	// Token: 0x0400068E RID: 1678
	private Image CanvasImage;
}
