using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200006B RID: 107
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Hologram3")]
[Serializable]
public class _2dxFX_Hologram3 : MonoBehaviour
{
	// Token: 0x06000343 RID: 835 RVA: 0x00042914 File Offset: 0x00040D14
	public _2dxFX_Hologram3()
	{
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00042979 File Offset: 0x00040D79
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000345 RID: 837 RVA: 0x000429A2 File Offset: 0x00040DA2
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x000429AB File Offset: 0x00040DAB
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000347 RID: 839 RVA: 0x000429B4 File Offset: 0x00040DB4
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
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Distortion);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_TimeX", 1f + this._TimeX);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._ColorX);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				this.CanvasImage.material.SetFloat("_Distortion", this.Distortion);
				this.CanvasImage.material.SetFloat("_TimeX", 1f + this._TimeX);
				this.CanvasImage.material.SetColor("_ColorX", this._ColorX);
			}
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00042CF8 File Offset: 0x000410F8
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

	// Token: 0x06000349 RID: 841 RVA: 0x00042E04 File Offset: 0x00041204
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

	// Token: 0x0600034A RID: 842 RVA: 0x00042EE0 File Offset: 0x000412E0
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

	// Token: 0x040005B7 RID: 1463
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040005B8 RID: 1464
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040005B9 RID: 1465
	private string shader = "2DxFX/Standard/Hologram3";

	// Token: 0x040005BA RID: 1466
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040005BB RID: 1467
	[HideInInspector]
	[Range(0f, 4f)]
	public float Distortion = 1f;

	// Token: 0x040005BC RID: 1468
	[HideInInspector]
	private float _TimeX;

	// Token: 0x040005BD RID: 1469
	[Range(0f, 3f)]
	[HideInInspector]
	public float Speed = 1f;

	// Token: 0x040005BE RID: 1470
	[HideInInspector]
	public Color _ColorX = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040005BF RID: 1471
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040005C0 RID: 1472
	private Material tempMaterial;

	// Token: 0x040005C1 RID: 1473
	private Material defaultMaterial;

	// Token: 0x040005C2 RID: 1474
	private Image CanvasImage;
}
