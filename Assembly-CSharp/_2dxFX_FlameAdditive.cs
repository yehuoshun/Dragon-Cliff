using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005F RID: 95
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Flame Additive")]
[Serializable]
public class _2dxFX_FlameAdditive : MonoBehaviour
{
	// Token: 0x060002E3 RID: 739 RVA: 0x0003C247 File Offset: 0x0003A647
	public _2dxFX_FlameAdditive()
	{
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0003C282 File Offset: 0x0003A682
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x0003C2AC File Offset: 0x0003A6AC
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_FlameTXT") as Texture2D);
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

	// Token: 0x060002E6 RID: 742 RVA: 0x0003C33C File Offset: 0x0003A73C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0003C344 File Offset: 0x0003A744
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this._Speed);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Intensity", this._Intensity);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", this._Alpha);
				this.CanvasImage.material.SetFloat("_Intensity", this._Intensity);
				this.CanvasImage.material.SetFloat("_Speed", this._Speed);
			}
		}
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0003C5D8 File Offset: 0x0003A9D8
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

	// Token: 0x060002E9 RID: 745 RVA: 0x0003C6E4 File Offset: 0x0003AAE4
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

	// Token: 0x060002EA RID: 746 RVA: 0x0003C7C0 File Offset: 0x0003ABC0
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FlameTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_FlameTXT") as Texture2D);
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

	// Token: 0x0400052C RID: 1324
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400052D RID: 1325
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400052E RID: 1326
	private string shader = "2DxFX/Standard/FlameAdditive";

	// Token: 0x0400052F RID: 1327
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x04000530 RID: 1328
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000531 RID: 1329
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _Speed = 1f;

	// Token: 0x04000532 RID: 1330
	[HideInInspector]
	[Range(0f, 2f)]
	public float _Intensity = 1f;

	// Token: 0x04000533 RID: 1331
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000534 RID: 1332
	private Material tempMaterial;

	// Token: 0x04000535 RID: 1333
	private Material defaultMaterial;

	// Token: 0x04000536 RID: 1334
	private Image CanvasImage;
}
