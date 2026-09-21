using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000075 RID: 117
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Mystic_Distortion")]
[Serializable]
public class _2dxFX_Mystic_Distortion : MonoBehaviour
{
	// Token: 0x06000393 RID: 915 RVA: 0x00047354 File Offset: 0x00045754
	public _2dxFX_Mystic_Distortion()
	{
	}

	// Token: 0x06000394 RID: 916 RVA: 0x00047404 File Offset: 0x00045804
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000395 RID: 917 RVA: 0x0004742D File Offset: 0x0004582D
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00047436 File Offset: 0x00045836
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00047440 File Offset: 0x00045840
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

	// Token: 0x06000398 RID: 920 RVA: 0x000478D8 File Offset: 0x00045CD8
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

	// Token: 0x06000399 RID: 921 RVA: 0x000479E4 File Offset: 0x00045DE4
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

	// Token: 0x0600039A RID: 922 RVA: 0x00047AC0 File Offset: 0x00045EC0
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

	// Token: 0x04000642 RID: 1602
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x04000643 RID: 1603
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x04000644 RID: 1604
	private string shader = "2DxFX/Standard/Mystic_Distortion";

	// Token: 0x04000645 RID: 1605
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x04000646 RID: 1606
	[HideInInspector]
	[Range(0f, 0.45f)]
	public float _Pitch = 0.45f;

	// Token: 0x04000647 RID: 1607
	[HideInInspector]
	public bool Pitch_Wave = true;

	// Token: 0x04000648 RID: 1608
	[HideInInspector]
	[Range(0f, 16f)]
	public float _Pitch_Speed = 1f;

	// Token: 0x04000649 RID: 1609
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Pitch_Offset;

	// Token: 0x0400064A RID: 1610
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetX = 56f;

	// Token: 0x0400064B RID: 1611
	[HideInInspector]
	[Range(0f, 128f)]
	public float _OffsetY = 28f;

	// Token: 0x0400064C RID: 1612
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceX = 0.01f;

	// Token: 0x0400064D RID: 1613
	[HideInInspector]
	[Range(0f, 1f)]
	public float _DistanceY = 0.04f;

	// Token: 0x0400064E RID: 1614
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeX = 1.16f;

	// Token: 0x0400064F RID: 1615
	[HideInInspector]
	[Range(0f, 6.28f)]
	public float _WaveTimeY = 5.12f;

	// Token: 0x04000650 RID: 1616
	[HideInInspector]
	public bool AutoPlayWaveX;

	// Token: 0x04000651 RID: 1617
	[HideInInspector]
	[Range(0f, 5f)]
	public float AutoPlaySpeedX = 5f;

	// Token: 0x04000652 RID: 1618
	[HideInInspector]
	public bool AutoPlayWaveY;

	// Token: 0x04000653 RID: 1619
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoPlaySpeedY = 5f;

	// Token: 0x04000654 RID: 1620
	[HideInInspector]
	public bool AutoRandom;

	// Token: 0x04000655 RID: 1621
	[HideInInspector]
	[Range(0f, 50f)]
	public float AutoRandomRange = 10f;

	// Token: 0x04000656 RID: 1622
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000657 RID: 1623
	private Material tempMaterial;

	// Token: 0x04000658 RID: 1624
	private Material defaultMaterial;

	// Token: 0x04000659 RID: 1625
	private Image CanvasImage;
}
