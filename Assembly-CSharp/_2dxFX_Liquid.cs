using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000072 RID: 114
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Liquid")]
[Serializable]
public class _2dxFX_Liquid : MonoBehaviour
{
	// Token: 0x0600037B RID: 891 RVA: 0x00045DAC File Offset: 0x000441AC
	public _2dxFX_Liquid()
	{
	}

	// Token: 0x0600037C RID: 892 RVA: 0x00045E08 File Offset: 0x00044208
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00045E31 File Offset: 0x00044231
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00045E3A File Offset: 0x0004423A
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00045E44 File Offset: 0x00044244
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

	// Token: 0x06000380 RID: 896 RVA: 0x00046150 File Offset: 0x00044550
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

	// Token: 0x06000381 RID: 897 RVA: 0x0004625C File Offset: 0x0004465C
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

	// Token: 0x06000382 RID: 898 RVA: 0x00046338 File Offset: 0x00044738
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

	// Token: 0x0400061F RID: 1567
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000620 RID: 1568
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000621 RID: 1569
	private string shader = "2DxFX/Standard/Liquid";

	// Token: 0x04000622 RID: 1570
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000623 RID: 1571
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x04000624 RID: 1572
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x04000625 RID: 1573
	[HideInInspector]
	[Range(0f, 1f)]
	public float EValue = 1f;

	// Token: 0x04000626 RID: 1574
	[HideInInspector]
	[Range(-4f, 4f)]
	public float Light = 3f;

	// Token: 0x04000627 RID: 1575
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000628 RID: 1576
	private Material tempMaterial;

	// Token: 0x04000629 RID: 1577
	private Material defaultMaterial;

	// Token: 0x0400062A RID: 1578
	private Image CanvasImage;
}
