using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000076 RID: 118
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Mystic_Distortion_Additive")]
[Serializable]
public class _2dxFX_Mystic_Distortion_Additive : MonoBehaviour
{
	// Token: 0x0600039B RID: 923 RVA: 0x00047C34 File Offset: 0x00046034
	public _2dxFX_Mystic_Distortion_Additive()
	{
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00047CE4 File Offset: 0x000460E4
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00047D0D File Offset: 0x0004610D
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00047D16 File Offset: 0x00046116
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00047D20 File Offset: 0x00046120
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
			if (this.Pitch_Wave)
			{
				this._Pitch_Offset = Mathf.Sin(Time.time * this._Pitch_Speed) * 0.05f;
			}
			else
			{
				this._Pitch_Offset = 0f;
			}
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", 1f - this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Pitch", this._Pitch + this._Pitch_Offset);
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
				this.CanvasImage.material.SetFloat("_Pitch", this._Pitch + this._Pitch_Offset);
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

	// Token: 0x060003A0 RID: 928 RVA: 0x000481B8 File Offset: 0x000465B8
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

	// Token: 0x060003A1 RID: 929 RVA: 0x000482C4 File Offset: 0x000466C4
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

	// Token: 0x060003A2 RID: 930 RVA: 0x000483A0 File Offset: 0x000467A0
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

	// Token: 0x0400065A RID: 1626
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400065B RID: 1627
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400065C RID: 1628
	private string shader = "2DxFX/Standard/Mystic_Distortion_Additive";

	// Token: 0x0400065D RID: 1629
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400065E RID: 1630
	[HideInInspector]
	[Range(0f, 0.45f)]
	public float _Pitch = 0.45f;

	// Token: 0x0400065F RID: 1631
	[HideInInspector]
	public bool Pitch_Wave = true;

	// Token: 0x04000660 RID: 1632
	[HideInInspector]
	[Range(0f, 16f)]
	public float _Pitch_Speed = 1f;

	// Token: 0x04000661 RID: 1633
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Pitch_Offset;

	// Token: 0x04000662 RID: 1634
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetX = 56f;

	// Token: 0x04000663 RID: 1635
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetY = 28f;

	// Token: 0x04000664 RID: 1636
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceX = 0.01f;

	// Token: 0x04000665 RID: 1637
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceY = 0.04f;

	// Token: 0x04000666 RID: 1638
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeX = 1.16f;

	// Token: 0x04000667 RID: 1639
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeY = 5.12f;

	// Token: 0x04000668 RID: 1640
	[HideInInspector]
	public bool AutoPlayWaveX;

	// Token: 0x04000669 RID: 1641
	[HideInInspector]
	[Range(0f, 5f)]
	public float AutoPlaySpeedX = 5f;

	// Token: 0x0400066A RID: 1642
	[HideInInspector]
	public bool AutoPlayWaveY;

	// Token: 0x0400066B RID: 1643
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoPlaySpeedY = 5f;

	// Token: 0x0400066C RID: 1644
	[HideInInspector]
	public bool AutoRandom;

	// Token: 0x0400066D RID: 1645
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoRandomRange = 10f;

	// Token: 0x0400066E RID: 1646
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400066F RID: 1647
	private Material tempMaterial;

	// Token: 0x04000670 RID: 1648
	private Material defaultMaterial;

	// Token: 0x04000671 RID: 1649
	private Image CanvasImage;
}
