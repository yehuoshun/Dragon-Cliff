using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200004E RID: 78
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/BurningFX")]
[Serializable]
public class _2dxFX_BurningFX : MonoBehaviour
{
	// Token: 0x0600025B RID: 603 RVA: 0x00034A4E File Offset: 0x00032E4E
	public _2dxFX_BurningFX()
	{
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00034A7E File Offset: 0x00032E7E
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00034AA7 File Offset: 0x00032EA7
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00034AB0 File Offset: 0x00032EB0
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00034AB8 File Offset: 0x00032EB8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Colors);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Colors);
			}
		}
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00034D1C File Offset: 0x0003311C
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

	// Token: 0x06000261 RID: 609 RVA: 0x00034E28 File Offset: 0x00033228
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

	// Token: 0x06000262 RID: 610 RVA: 0x00034F04 File Offset: 0x00033304
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

	// Token: 0x04000455 RID: 1109
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000456 RID: 1110
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000457 RID: 1111
	private string shader = "2DxFX/Standard/BurningFX";

	// Token: 0x04000458 RID: 1112
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000459 RID: 1113
	[HideInInspector]
	[Range(0f, 4f)]
	public float Colors = 1f;

	// Token: 0x0400045A RID: 1114
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400045B RID: 1115
	private Material tempMaterial;

	// Token: 0x0400045C RID: 1116
	private Material defaultMaterial;

	// Token: 0x0400045D RID: 1117
	private Image CanvasImage;
}
