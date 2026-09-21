using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000054 RID: 84
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/ColorRGB")]
[Serializable]
public class _2dxFX_ColorRGB : MonoBehaviour
{
	// Token: 0x0600028B RID: 651 RVA: 0x000371C8 File Offset: 0x000355C8
	public _2dxFX_ColorRGB()
	{
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00037219 File Offset: 0x00035619
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00037242 File Offset: 0x00035642
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0003724B File Offset: 0x0003564B
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00037254 File Offset: 0x00035654
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ColorR", this._ColorR);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ColorG", this._ColorG);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ColorB", this._ColorB);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_ColorR", this._ColorR);
				this.CanvasImage.material.SetFloat("_ColorG", this._ColorG);
				this.CanvasImage.material.SetFloat("_ColorB", this._ColorB);
			}
		}
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00037524 File Offset: 0x00035924
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

	// Token: 0x06000291 RID: 657 RVA: 0x00037630 File Offset: 0x00035A30
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

	// Token: 0x06000292 RID: 658 RVA: 0x0003770C File Offset: 0x00035B0C
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

	// Token: 0x04000494 RID: 1172
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000495 RID: 1173
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000496 RID: 1174
	private string shader = "2DxFX/Standard/ColorRGB";

	// Token: 0x04000497 RID: 1175
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000498 RID: 1176
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _ColorR = -0.5f;

	// Token: 0x04000499 RID: 1177
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _ColorG = 0.5f;

	// Token: 0x0400049A RID: 1178
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _ColorB = 0.5f;

	// Token: 0x0400049B RID: 1179
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400049C RID: 1180
	private Material tempMaterial;

	// Token: 0x0400049D RID: 1181
	private Material defaultMaterial;

	// Token: 0x0400049E RID: 1182
	private Image CanvasImage;
}
