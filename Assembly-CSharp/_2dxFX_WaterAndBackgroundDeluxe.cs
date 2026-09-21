using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000095 RID: 149
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/WaterAndBackgroundDeluxe")]
[Serializable]
public class _2dxFX_WaterAndBackgroundDeluxe : MonoBehaviour
{
	// Token: 0x06000493 RID: 1171 RVA: 0x00056564 File Offset: 0x00054964
	public _2dxFX_WaterAndBackgroundDeluxe()
	{
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x000565C0 File Offset: 0x000549C0
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x000565E9 File Offset: 0x000549E9
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x000565F2 File Offset: 0x000549F2
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x000565FC File Offset: 0x000549FC
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Heat);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("EValue", this.EValue);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("Light", this.Light);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Heat);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
				this.CanvasImage.material.SetFloat("EValue", this.EValue);
				this.CanvasImage.material.SetFloat("Light", this.Light);
			}
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x00056900 File Offset: 0x00054D00
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

	// Token: 0x06000499 RID: 1177 RVA: 0x00056A0C File Offset: 0x00054E0C
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

	// Token: 0x0600049A RID: 1178 RVA: 0x00056AE8 File Offset: 0x00054EE8
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

	// Token: 0x040007F4 RID: 2036
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040007F5 RID: 2037
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040007F6 RID: 2038
	private string shader = "2DxFX/Standard/WaterAndBackgroundDeluxe";

	// Token: 0x040007F7 RID: 2039
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040007F8 RID: 2040
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x040007F9 RID: 2041
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x040007FA RID: 2042
	[HideInInspector]
	[Range(0f, 1f)]
	public float EValue = 1f;

	// Token: 0x040007FB RID: 2043
	[HideInInspector]
	[Range(-4f, 4f)]
	public float Light = 3f;

	// Token: 0x040007FC RID: 2044
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040007FD RID: 2045
	private Material tempMaterial;

	// Token: 0x040007FE RID: 2046
	private Material defaultMaterial;

	// Token: 0x040007FF RID: 2047
	private Image CanvasImage;
}
