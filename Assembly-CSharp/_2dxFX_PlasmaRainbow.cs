using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000085 RID: 133
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/PlasmaRainbow")]
[Serializable]
public class _2dxFX_PlasmaRainbow : MonoBehaviour
{
	// Token: 0x06000413 RID: 1043 RVA: 0x0004EDF4 File Offset: 0x0004D1F4
	public _2dxFX_PlasmaRainbow()
	{
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0004EE45 File Offset: 0x0004D245
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0004EE6E File Offset: 0x0004D26E
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0004EE77 File Offset: 0x0004D277
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0004EE80 File Offset: 0x0004D280
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Colors", this._Colors);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset", this._Offset);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_TimeX", this._TimeX);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Colors", this._Colors);
				this.CanvasImage.material.SetFloat("_Offset", this._Offset);
				this._TimeX += Time.deltaTime * this.Speed;
				if (this._TimeX > 100f)
				{
					this._TimeX = 0f;
				}
				this.CanvasImage.material.SetFloat("_TimeX", this._TimeX);
			}
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0004F1C0 File Offset: 0x0004D5C0
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

	// Token: 0x06000419 RID: 1049 RVA: 0x0004F2CC File Offset: 0x0004D6CC
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

	// Token: 0x0600041A RID: 1050 RVA: 0x0004F3A8 File Offset: 0x0004D7A8
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

	// Token: 0x04000730 RID: 1840
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000731 RID: 1841
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000732 RID: 1842
	private string shader = "2DxFX/Standard/PlasmaRainbow";

	// Token: 0x04000733 RID: 1843
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000734 RID: 1844
	[HideInInspector]
	[Range(0.1f, 8f)]
	public float _Colors = 6f;

	// Token: 0x04000735 RID: 1845
	[HideInInspector]
	[Range(0.1f, 4f)]
	public float _Offset = 2.5f;

	// Token: 0x04000736 RID: 1846
	[HideInInspector]
	private float _TimeX;

	// Token: 0x04000737 RID: 1847
	[HideInInspector]
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x04000738 RID: 1848
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000739 RID: 1849
	private Material tempMaterial;

	// Token: 0x0400073A RID: 1850
	private Material defaultMaterial;

	// Token: 0x0400073B RID: 1851
	private Image CanvasImage;
}
