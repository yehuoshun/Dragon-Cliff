using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000047 RID: 71
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Additive")]
[Serializable]
public class _2dxFX_Additive : MonoBehaviour
{
	// Token: 0x06000223 RID: 547 RVA: 0x00031DA2 File Offset: 0x000301A2
	public _2dxFX_Additive()
	{
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00031DC7 File Offset: 0x000301C7
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00031DF0 File Offset: 0x000301F0
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00031DF9 File Offset: 0x000301F9
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00031E04 File Offset: 0x00030204
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
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
			}
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00032030 File Offset: 0x00030430
	private void OnDestroy()
	{
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

	// Token: 0x06000229 RID: 553 RVA: 0x00032104 File Offset: 0x00030504
	private void OnDisable()
	{
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

	// Token: 0x0600022A RID: 554 RVA: 0x000321A8 File Offset: 0x000305A8
	private void OnEnable()
	{
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
				if (this.CanvasImage == null)
				{
					this.CanvasImage = base.gameObject.GetComponent<Image>();
				}
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
				if (this.CanvasImage == null)
				{
					this.CanvasImage = base.gameObject.GetComponent<Image>();
				}
				this.CanvasImage.material = this.ForceMaterial;
			}
		}
	}

	// Token: 0x04000411 RID: 1041
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000412 RID: 1042
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000413 RID: 1043
	private string shader = "2DxFX/Standard/Additive";

	// Token: 0x04000414 RID: 1044
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000415 RID: 1045
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000416 RID: 1046
	private Material tempMaterial;

	// Token: 0x04000417 RID: 1047
	private Material defaultMaterial;

	// Token: 0x04000418 RID: 1048
	private Image CanvasImage;
}
