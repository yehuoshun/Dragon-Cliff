using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007D RID: 125
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Outline")]
[Serializable]
public class _2dxFX_Outline : MonoBehaviour
{
	// Token: 0x060003D3 RID: 979 RVA: 0x0004B100 File Offset: 0x00049500
	public _2dxFX_Outline()
	{
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0004B15A File Offset: 0x0004955A
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0004B183 File Offset: 0x00049583
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0004B18C File Offset: 0x0004958C
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0004B194 File Offset: 0x00049594
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._ColorX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OutLineSpread", this._OutLineSpread);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetColor("_ColorX", this._ColorX);
				this.CanvasImage.material.SetFloat("_OutLineSpread", this._OutLineSpread);
			}
		}
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0004B434 File Offset: 0x00049834
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

	// Token: 0x060003D9 RID: 985 RVA: 0x0004B540 File Offset: 0x00049940
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

	// Token: 0x060003DA RID: 986 RVA: 0x0004B61C File Offset: 0x00049A1C
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

	// Token: 0x040006C8 RID: 1736
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040006C9 RID: 1737
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040006CA RID: 1738
	private string shader = "2DxFX/Standard/Outline";

	// Token: 0x040006CB RID: 1739
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040006CC RID: 1740
	[HideInInspector]
	public Color _ColorX = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040006CD RID: 1741
	[HideInInspector]
	[Range(0f, 0.02f)]
	public float _OutLineSpread = 0.007f;

	// Token: 0x040006CE RID: 1742
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040006CF RID: 1743
	private Material tempMaterial;

	// Token: 0x040006D0 RID: 1744
	private Material defaultMaterial;

	// Token: 0x040006D1 RID: 1745
	private Image CanvasImage;
}
