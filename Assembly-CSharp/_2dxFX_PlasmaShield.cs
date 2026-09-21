using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000087 RID: 135
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/PlasmaShield")]
[Serializable]
public class _2dxFX_PlasmaShield : MonoBehaviour
{
	// Token: 0x06000423 RID: 1059 RVA: 0x0004FC44 File Offset: 0x0004E044
	public _2dxFX_PlasmaShield()
	{
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0004FCA9 File Offset: 0x0004E0A9
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0004FCD2 File Offset: 0x0004E0D2
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0004FCDB File Offset: 0x0004E0DB
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0004FCE4 File Offset: 0x0004E0E4
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
				base.GetComponent<Renderer>().sharedMaterial.SetColor("_ColorX", this._ColorX);
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
				this.CanvasImage.material.SetColor("_ColorX", this._ColorX);
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

	// Token: 0x06000428 RID: 1064 RVA: 0x00050024 File Offset: 0x0004E424
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

	// Token: 0x06000429 RID: 1065 RVA: 0x00050130 File Offset: 0x0004E530
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

	// Token: 0x0600042A RID: 1066 RVA: 0x0005020C File Offset: 0x0004E60C
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

	// Token: 0x04000748 RID: 1864
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000749 RID: 1865
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400074A RID: 1866
	private string shader = "2DxFX/Standard/PlasmaShield";

	// Token: 0x0400074B RID: 1867
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400074C RID: 1868
	[HideInInspector]
	public Color _ColorX = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400074D RID: 1869
	[HideInInspector]
	[Range(0.1f, 4f)]
	public float _Offset = 2.5f;

	// Token: 0x0400074E RID: 1870
	[HideInInspector]
	private float _TimeX;

	// Token: 0x0400074F RID: 1871
	[HideInInspector]
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x04000750 RID: 1872
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000751 RID: 1873
	private Material tempMaterial;

	// Token: 0x04000752 RID: 1874
	private Material defaultMaterial;

	// Token: 0x04000753 RID: 1875
	private Image CanvasImage;
}
