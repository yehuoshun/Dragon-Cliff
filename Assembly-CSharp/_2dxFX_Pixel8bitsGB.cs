using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000083 RID: 131
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Pixel 8 Bits Gameboy")]
[Serializable]
public class _2dxFX_Pixel8bitsGB : MonoBehaviour
{
	// Token: 0x06000403 RID: 1027 RVA: 0x0004DF32 File Offset: 0x0004C332
	public _2dxFX_Pixel8bitsGB()
	{
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0004DF6D File Offset: 0x0004C36D
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0004DF96 File Offset: 0x0004C396
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0004DF9F File Offset: 0x0004C39F
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0004DFA8 File Offset: 0x0004C3A8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Size", this._Size);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset2", this._Offset);
				base.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = -10f;
				base.GetComponent<SpriteRenderer>().sprite.texture.filterMode = FilterMode.Point;
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Size", this._Size);
				this.CanvasImage.material.SetFloat("_Offset2", this._Offset);
			}
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0004E278 File Offset: 0x0004C678
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

	// Token: 0x06000409 RID: 1033 RVA: 0x0004E384 File Offset: 0x0004C784
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

	// Token: 0x0600040A RID: 1034 RVA: 0x0004E460 File Offset: 0x0004C860
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

	// Token: 0x04000713 RID: 1811
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000714 RID: 1812
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000715 RID: 1813
	private string shader = "2DxFX/Standard/Pixel8bitsGB";

	// Token: 0x04000716 RID: 1814
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000717 RID: 1815
	[HideInInspector]
	[Range(0.01f, 10f)]
	public float _Size = 1f;

	// Token: 0x04000718 RID: 1816
	[HideInInspector]
	[Range(0f, 3f)]
	public float _Offset = 1f;

	// Token: 0x04000719 RID: 1817
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400071A RID: 1818
	private Material tempMaterial;

	// Token: 0x0400071B RID: 1819
	private Material defaultMaterial;

	// Token: 0x0400071C RID: 1820
	private Image CanvasImage;
}
