using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000093 RID: 147
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Twist")]
[Serializable]
public class _2dxFX_Twist : MonoBehaviour
{
	// Token: 0x06000483 RID: 1155 RVA: 0x00055794 File Offset: 0x00053B94
	public _2dxFX_Twist()
	{
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00055804 File Offset: 0x00053C04
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0005582D File Offset: 0x00053C2D
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00055836 File Offset: 0x00053C36
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x00055840 File Offset: 0x00053C40
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_PosX", this._PosX);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_PosY", this._PosY);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Distortion);
				this.CanvasImage.material.SetFloat("_PosX", this._PosX);
				this.CanvasImage.material.SetFloat("_PosY", this._PosY);
			}
		}
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x00055B10 File Offset: 0x00053F10
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

	// Token: 0x06000489 RID: 1161 RVA: 0x00055C1C File Offset: 0x0005401C
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

	// Token: 0x0600048A RID: 1162 RVA: 0x00055CF8 File Offset: 0x000540F8
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

	// Token: 0x040007DC RID: 2012
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040007DD RID: 2013
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040007DE RID: 2014
	private string shader = "2DxFX/Standard/Twist";

	// Token: 0x040007DF RID: 2015
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040007E0 RID: 2016
	[HideInInspector]
	[Range(-1f, 1f)]
	public float Distortion = 1.6f;

	// Token: 0x040007E1 RID: 2017
	[HideInInspector]
	[Range(-1f, 2f)]
	public float _PosX = 0.5f;

	// Token: 0x040007E2 RID: 2018
	[HideInInspector]
	[Range(-1f, 2f)]
	public float _PosY = 0.5f;

	// Token: 0x040007E3 RID: 2019
	[HideInInspector]
	public Color _ColorX = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040007E4 RID: 2020
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040007E5 RID: 2021
	private Material tempMaterial;

	// Token: 0x040007E6 RID: 2022
	private Material defaultMaterial;

	// Token: 0x040007E7 RID: 2023
	private Image CanvasImage;
}
