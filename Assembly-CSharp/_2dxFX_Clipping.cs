using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000051 RID: 81
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Clipping")]
[Serializable]
public class _2dxFX_Clipping : MonoBehaviour
{
	// Token: 0x06000273 RID: 627 RVA: 0x00035D3A File Offset: 0x0003413A
	public _2dxFX_Clipping()
	{
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00035D5F File Offset: 0x0003415F
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00035D88 File Offset: 0x00034188
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00035D91 File Offset: 0x00034191
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00035D9C File Offset: 0x0003419C
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipLeft", 1f - this._ClipLeft);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipRight", 1f - this._ClipRight);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipUp", 1f - this._ClipUp);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipDown", 1f - this._ClipDown);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_ClipLeft", 1f - this._ClipLeft);
				this.CanvasImage.material.SetFloat("_ClipRight", 1f - this._ClipRight);
				this.CanvasImage.material.SetFloat("_ClipUp", 1f - this._ClipUp);
				this.CanvasImage.material.SetFloat("_ClipDown", 1f - this._ClipDown);
			}
		}
	}

	// Token: 0x06000278 RID: 632 RVA: 0x000360D0 File Offset: 0x000344D0
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

	// Token: 0x06000279 RID: 633 RVA: 0x000361DC File Offset: 0x000345DC
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

	// Token: 0x0600027A RID: 634 RVA: 0x000362B8 File Offset: 0x000346B8
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

	// Token: 0x04000472 RID: 1138
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000473 RID: 1139
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000474 RID: 1140
	private string shader = "2DxFX/Standard/Clipping";

	// Token: 0x04000475 RID: 1141
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000476 RID: 1142
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipLeft;

	// Token: 0x04000477 RID: 1143
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipRight;

	// Token: 0x04000478 RID: 1144
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipUp;

	// Token: 0x04000479 RID: 1145
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipDown;

	// Token: 0x0400047A RID: 1146
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400047B RID: 1147
	private Material tempMaterial;

	// Token: 0x0400047C RID: 1148
	private Material defaultMaterial;

	// Token: 0x0400047D RID: 1149
	private Image CanvasImage;
}
