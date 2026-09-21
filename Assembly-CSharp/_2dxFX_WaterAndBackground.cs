using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000094 RID: 148
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/WaterAndBackground")]
[Serializable]
public class _2dxFX_WaterAndBackground : MonoBehaviour
{
	// Token: 0x0600048B RID: 1163 RVA: 0x00055E6C File Offset: 0x0005426C
	public _2dxFX_WaterAndBackground()
	{
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x00055EC8 File Offset: 0x000542C8
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x00055EF1 File Offset: 0x000542F1
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00055EFA File Offset: 0x000542FA
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00055F04 File Offset: 0x00054304
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

	// Token: 0x06000490 RID: 1168 RVA: 0x00056208 File Offset: 0x00054608
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

	// Token: 0x06000491 RID: 1169 RVA: 0x00056314 File Offset: 0x00054714
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

	// Token: 0x06000492 RID: 1170 RVA: 0x000563F0 File Offset: 0x000547F0
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

	// Token: 0x040007E8 RID: 2024
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040007E9 RID: 2025
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040007EA RID: 2026
	private string shader = "2DxFX/Standard/WaterAndBackground";

	// Token: 0x040007EB RID: 2027
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040007EC RID: 2028
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x040007ED RID: 2029
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x040007EE RID: 2030
	[HideInInspector]
	[Range(0f, 1f)]
	public float EValue = 1f;

	// Token: 0x040007EF RID: 2031
	[HideInInspector]
	[Range(-4f, 4f)]
	public float Light = 3f;

	// Token: 0x040007F0 RID: 2032
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040007F1 RID: 2033
	private Material tempMaterial;

	// Token: 0x040007F2 RID: 2034
	private Material defaultMaterial;

	// Token: 0x040007F3 RID: 2035
	private Image CanvasImage;
}
