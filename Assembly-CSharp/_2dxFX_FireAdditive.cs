using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005D RID: 93
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/FireAdditive")]
[Serializable]
public class _2dxFX_FireAdditive : MonoBehaviour
{
	// Token: 0x060002D3 RID: 723 RVA: 0x0003B254 File Offset: 0x00039654
	public _2dxFX_FireAdditive()
	{
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0003B2A5 File Offset: 0x000396A5
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0003B2D0 File Offset: 0x000396D0
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_FireTXT") as Texture2D);
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

	// Token: 0x060002D6 RID: 726 RVA: 0x0003B360 File Offset: 0x00039760
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0003B368 File Offset: 0x00039768
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value2", this._Value2);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value3", this._Value3);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value4", this._Value4);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Value1", this._Value1);
				this.CanvasImage.material.SetFloat("_Value2", this._Value2);
				this.CanvasImage.material.SetFloat("_Value3", this._Value3);
				this.CanvasImage.material.SetFloat("_Value4", this._Value4);
			}
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0003B66C File Offset: 0x00039A6C
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

	// Token: 0x060002D9 RID: 729 RVA: 0x0003B778 File Offset: 0x00039B78
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

	// Token: 0x060002DA RID: 730 RVA: 0x0003B854 File Offset: 0x00039C54
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FireTXT") as Texture2D);
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
				Image component = base.gameObject.GetComponent<Image>();
				if (component.material == null)
				{
					this.CanvasImage.material = this.ForceMaterial;
				}
			}
			this.__MainTex2 = (Resources.Load("_2dxFX_FireTXT") as Texture2D);
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
				Image component2 = base.gameObject.GetComponent<Image>();
				if (component2.material == null)
				{
					this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
				}
			}
		}
	}

	// Token: 0x0400050E RID: 1294
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400050F RID: 1295
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000510 RID: 1296
	private string shader = "2DxFX/Standard/FireAdditive";

	// Token: 0x04000511 RID: 1297
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000512 RID: 1298
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000513 RID: 1299
	[HideInInspector]
	[Range(64f, 256f)]
	public float _Value1 = 64f;

	// Token: 0x04000514 RID: 1300
	[HideInInspector]
	[Range(0f, 2f)]
	public float _Value2 = 1f;

	// Token: 0x04000515 RID: 1301
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value3 = 1f;

	// Token: 0x04000516 RID: 1302
	[HideInInspector]
	public float _Value4;

	// Token: 0x04000517 RID: 1303
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x04000518 RID: 1304
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x04000519 RID: 1305
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x0400051A RID: 1306
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x0400051B RID: 1307
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x0400051C RID: 1308
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x0400051D RID: 1309
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400051E RID: 1310
	private Material tempMaterial;

	// Token: 0x0400051F RID: 1311
	private Material defaultMaterial;

	// Token: 0x04000520 RID: 1312
	private Image CanvasImage;
}
