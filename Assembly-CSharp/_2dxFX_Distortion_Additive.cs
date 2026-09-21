using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000059 RID: 89
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Distortion_Additive")]
[Serializable]
public class _2dxFX_Distortion_Additive : MonoBehaviour
{
	// Token: 0x060002B3 RID: 691 RVA: 0x00039424 File Offset: 0x00037824
	public _2dxFX_Distortion_Additive()
	{
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x000394B7 File Offset: 0x000378B7
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000394E0 File Offset: 0x000378E0
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x000394E9 File Offset: 0x000378E9
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x000394F4 File Offset: 0x000378F4
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceX", this._DistanceX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceY", this._DistanceY);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeX", this._WaveTimeX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeY", this._WaveTimeY);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
				this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				this.CanvasImage.material.SetFloat("_DistanceX", this._DistanceX);
				this.CanvasImage.material.SetFloat("_DistanceY", this._DistanceY);
				this.CanvasImage.material.SetFloat("_WaveTimeX", this._WaveTimeX);
				this.CanvasImage.material.SetFloat("_WaveTimeY", this._WaveTimeY);
			}
			float num;
			if (this.AutoRandom)
			{
				num = UnityEngine.Random.Range(1f, this.AutoRandomRange) / 5f * Time.deltaTime;
			}
			else
			{
				num = Time.deltaTime;
			}
			if (this.AutoPlayWaveX)
			{
				this._WaveTimeX += this.AutoPlaySpeedX * num;
			}
			if (this.AutoPlayWaveY)
			{
				this._WaveTimeY += this.AutoPlaySpeedY * num;
			}
			if (this._WaveTimeX > 6.28f)
			{
				this._WaveTimeX = 0f;
			}
			if (this._WaveTimeY > 6.28f)
			{
				this._WaveTimeY = 0f;
			}
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00039910 File Offset: 0x00037D10
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

	// Token: 0x060002B9 RID: 697 RVA: 0x00039A1C File Offset: 0x00037E1C
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

	// Token: 0x060002BA RID: 698 RVA: 0x00039AF8 File Offset: 0x00037EF8
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

	// Token: 0x040004D1 RID: 1233
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040004D2 RID: 1234
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040004D3 RID: 1235
	private string shader = "2DxFX/Standard/Distortion_Additive";

	// Token: 0x040004D4 RID: 1236
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040004D5 RID: 1237
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetX = 10f;

	// Token: 0x040004D6 RID: 1238
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetY = 10f;

	// Token: 0x040004D7 RID: 1239
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceX = 0.03f;

	// Token: 0x040004D8 RID: 1240
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceY = 0.03f;

	// Token: 0x040004D9 RID: 1241
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeX = 0.16f;

	// Token: 0x040004DA RID: 1242
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeY = 0.12f;

	// Token: 0x040004DB RID: 1243
	[HideInInspector]
	public bool AutoPlayWaveX;

	// Token: 0x040004DC RID: 1244
	[HideInInspector]
	[Range(0f, 5f)]
	public float AutoPlaySpeedX = 5f;

	// Token: 0x040004DD RID: 1245
	[HideInInspector]
	public bool AutoPlayWaveY;

	// Token: 0x040004DE RID: 1246
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoPlaySpeedY = 5f;

	// Token: 0x040004DF RID: 1247
	[HideInInspector]
	public bool AutoRandom;

	// Token: 0x040004E0 RID: 1248
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoRandomRange = 10f;

	// Token: 0x040004E1 RID: 1249
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040004E2 RID: 1250
	private Material tempMaterial;

	// Token: 0x040004E3 RID: 1251
	private Material defaultMaterial;

	// Token: 0x040004E4 RID: 1252
	private Image CanvasImage;
}
