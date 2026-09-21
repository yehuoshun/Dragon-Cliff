using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000098 RID: 152
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/WoodFX")]
[Serializable]
public class _2dxFX_WoodFX : MonoBehaviour
{
	// Token: 0x060004AB RID: 1195 RVA: 0x00057D56 File Offset: 0x00056156
	public _2dxFX_WoodFX()
	{
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00057D91 File Offset: 0x00056191
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x00057DBA File Offset: 0x000561BA
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x00057DC3 File Offset: 0x000561C3
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x00057DCC File Offset: 0x000561CC
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.IntoWood);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Deep", this.Deep);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.IntoWood);
				this.CanvasImage.material.SetFloat("_Deep", this.Deep);
			}
		}
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x00058064 File Offset: 0x00056464
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

	// Token: 0x060004B1 RID: 1201 RVA: 0x00058170 File Offset: 0x00056570
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

	// Token: 0x060004B2 RID: 1202 RVA: 0x0005824C File Offset: 0x0005664C
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

	// Token: 0x04000823 RID: 2083
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000824 RID: 2084
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000825 RID: 2085
	private string shader = "2DxFX/Standard/WoodFX";

	// Token: 0x04000826 RID: 2086
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000827 RID: 2087
	[HideInInspector]
	[Range(0f, 1f)]
	public float IntoWood = 1f;

	// Token: 0x04000828 RID: 2088
	[HideInInspector]
	[Range(0f, 1f)]
	public float Deep = 1f;

	// Token: 0x04000829 RID: 2089
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400082A RID: 2090
	private Material tempMaterial;

	// Token: 0x0400082B RID: 2091
	private Material defaultMaterial;

	// Token: 0x0400082C RID: 2092
	private Image CanvasImage;
}
