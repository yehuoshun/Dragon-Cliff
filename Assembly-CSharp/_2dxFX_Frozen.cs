using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000060 RID: 96
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Frozen")]
[Serializable]
public class _2dxFX_Frozen : MonoBehaviour
{
	// Token: 0x060002EB RID: 747 RVA: 0x0003C9E0 File Offset: 0x0003ADE0
	public _2dxFX_Frozen()
	{
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0003CA31 File Offset: 0x0003AE31
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0003CA5C File Offset: 0x0003AE5C
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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

	// Token: 0x060002EE RID: 750 RVA: 0x0003CAEC File Offset: 0x0003AEEC
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0003CAF4 File Offset: 0x0003AEF4
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

	// Token: 0x060002F0 RID: 752 RVA: 0x0003CDF8 File Offset: 0x0003B1F8
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

	// Token: 0x060002F1 RID: 753 RVA: 0x0003CF04 File Offset: 0x0003B304
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

	// Token: 0x060002F2 RID: 754 RVA: 0x0003CFE0 File Offset: 0x0003B3E0
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FrozenTXT") as Texture2D);
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

	// Token: 0x04000537 RID: 1335
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000538 RID: 1336
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000539 RID: 1337
	private string shader = "2DxFX/Standard/Frozen";

	// Token: 0x0400053A RID: 1338
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400053B RID: 1339
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x0400053C RID: 1340
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value1 = 0.5f;

	// Token: 0x0400053D RID: 1341
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value2 = 1f;

	// Token: 0x0400053E RID: 1342
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Value3 = 1f;

	// Token: 0x0400053F RID: 1343
	[HideInInspector]
	public float _Value4;

	// Token: 0x04000540 RID: 1344
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x04000541 RID: 1345
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedX;

	// Token: 0x04000542 RID: 1346
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x04000543 RID: 1347
	[HideInInspector]
	[Range(0f, 10f)]
	public float _AutoScrollSpeedY;

	// Token: 0x04000544 RID: 1348
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x04000545 RID: 1349
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x04000546 RID: 1350
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000547 RID: 1351
	private Material tempMaterial;

	// Token: 0x04000548 RID: 1352
	private Material defaultMaterial;

	// Token: 0x04000549 RID: 1353
	private Image CanvasImage;
}
