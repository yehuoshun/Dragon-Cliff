using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000050 RID: 80
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/CircleFade")]
[Serializable]
public class _2dxFX_CircleFade : MonoBehaviour
{
	// Token: 0x0600026B RID: 619 RVA: 0x000356DE File Offset: 0x00033ADE
	public _2dxFX_CircleFade()
	{
	}

	// Token: 0x0600026C RID: 620 RVA: 0x0003570E File Offset: 0x00033B0E
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00035737 File Offset: 0x00033B37
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00035740 File Offset: 0x00033B40
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00035748 File Offset: 0x00033B48
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Offset", this._Offset);
				base.GetComponent<Renderer>().sharedMaterial.SetInt("_InOut", this._InOut);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Offset", this._Offset);
				this.CanvasImage.material.SetInt("_InOut", this._InOut);
			}
		}
	}

	// Token: 0x06000270 RID: 624 RVA: 0x000359E0 File Offset: 0x00033DE0
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

	// Token: 0x06000271 RID: 625 RVA: 0x00035AEC File Offset: 0x00033EEC
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

	// Token: 0x06000272 RID: 626 RVA: 0x00035BC8 File Offset: 0x00033FC8
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

	// Token: 0x04000468 RID: 1128
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000469 RID: 1129
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400046A RID: 1130
	private string shader = "2DxFX/Standard/CircleFade";

	// Token: 0x0400046B RID: 1131
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400046C RID: 1132
	[HideInInspector]
	[Range(-0.2f, 1f)]
	public float _Offset = 0.2f;

	// Token: 0x0400046D RID: 1133
	[HideInInspector]
	[Range(0f, 1f)]
	public int _InOut;

	// Token: 0x0400046E RID: 1134
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400046F RID: 1135
	private Material tempMaterial;

	// Token: 0x04000470 RID: 1136
	private Material defaultMaterial;

	// Token: 0x04000471 RID: 1137
	private Image CanvasImage;
}
