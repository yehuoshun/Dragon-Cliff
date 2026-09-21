using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000048 RID: 72
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Black Hole")]
[Serializable]
public class _2dxFX_BlackHole : MonoBehaviour
{
	// Token: 0x0600022B RID: 555 RVA: 0x00032328 File Offset: 0x00030728
	public _2dxFX_BlackHole()
	{
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0003238D File Offset: 0x0003078D
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600022D RID: 557 RVA: 0x000323B6 File Offset: 0x000307B6
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x000323BF File Offset: 0x000307BF
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600022F RID: 559 RVA: 0x000323C8 File Offset: 0x000307C8
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Distortion);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Hole", this._Hole);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._Color);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Distortion);
				this.CanvasImage.material.SetFloat("_Hole", this._Hole);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
				this.CanvasImage.material.SetColor("_ColorX", this._Color);
			}
		}
	}

	// Token: 0x06000230 RID: 560 RVA: 0x000326CC File Offset: 0x00030ACC
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

	// Token: 0x06000231 RID: 561 RVA: 0x000327D8 File Offset: 0x00030BD8
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

	// Token: 0x06000232 RID: 562 RVA: 0x000328B4 File Offset: 0x00030CB4
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

	// Token: 0x04000419 RID: 1049
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400041A RID: 1050
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400041B RID: 1051
	private string shader = "2DxFX/Standard/BlackHole";

	// Token: 0x0400041C RID: 1052
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400041D RID: 1053
	[HideInInspector]
	public Color _Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400041E RID: 1054
	[HideInInspector]
	[Range(-1f, 1f)]
	public float Distortion = 1.6f;

	// Token: 0x0400041F RID: 1055
	[HideInInspector]
	[Range(0f, 0.5f)]
	public float _Hole;

	// Token: 0x04000420 RID: 1056
	[HideInInspector]
	[Range(-10f, 10f)]
	public float Speed = 4f;

	// Token: 0x04000421 RID: 1057
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000422 RID: 1058
	private Material tempMaterial;

	// Token: 0x04000423 RID: 1059
	private Material defaultMaterial;

	// Token: 0x04000424 RID: 1060
	private Image CanvasImage;
}
