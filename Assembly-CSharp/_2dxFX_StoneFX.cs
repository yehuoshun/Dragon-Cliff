using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000090 RID: 144
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/StoneFX")]
[Serializable]
public class _2dxFX_StoneFX : MonoBehaviour
{
	// Token: 0x0600046B RID: 1131 RVA: 0x000544DB File Offset: 0x000528DB
	public _2dxFX_StoneFX()
	{
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00054516 File Offset: 0x00052916
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0005453F File Offset: 0x0005293F
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x00054548 File Offset: 0x00052948
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x00054550 File Offset: 0x00052950
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.IntoStone);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Deep", this.Deep);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.IntoStone);
				this.CanvasImage.material.SetFloat("_Deep", this.Deep);
			}
		}
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x000547E8 File Offset: 0x00052BE8
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

	// Token: 0x06000471 RID: 1137 RVA: 0x000548F4 File Offset: 0x00052CF4
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

	// Token: 0x06000472 RID: 1138 RVA: 0x000549D0 File Offset: 0x00052DD0
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

	// Token: 0x040007C0 RID: 1984
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040007C1 RID: 1985
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040007C2 RID: 1986
	private string shader = "2DxFX/Standard/StoneFX";

	// Token: 0x040007C3 RID: 1987
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040007C4 RID: 1988
	[HideInInspector]
	[Range(0f, 1f)]
	public float IntoStone = 1f;

	// Token: 0x040007C5 RID: 1989
	[HideInInspector]
	[Range(0f, 1f)]
	public float Deep = 1f;

	// Token: 0x040007C6 RID: 1990
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040007C7 RID: 1991
	private Material tempMaterial;

	// Token: 0x040007C8 RID: 1992
	private Material defaultMaterial;

	// Token: 0x040007C9 RID: 1993
	private Image CanvasImage;
}
