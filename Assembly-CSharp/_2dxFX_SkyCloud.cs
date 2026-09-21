using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200008D RID: 141
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/SkyCloud")]
[Serializable]
public class _2dxFX_SkyCloud : MonoBehaviour
{
	// Token: 0x06000453 RID: 1107 RVA: 0x00052810 File Offset: 0x00050C10
	public _2dxFX_SkyCloud()
	{
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0005286C File Offset: 0x00050C6C
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x00052898 File Offset: 0x00050C98
	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
		this.ShaderChange = 0;
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
		else if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
		}
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x00052928 File Offset: 0x00050D28
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x00052930 File Offset: 0x00050D30
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Zoom", this._Zoom);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Intensity", this._Intensity);
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					base.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Zoom", this._Zoom);
				this.CanvasImage.material.SetFloat("_Intensity", this._Intensity);
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			if (this._AutoScrollCountX > 1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountX < -1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountY > 1f)
			{
				this._AutoScrollCountY = 0f;
			}
			if (this._AutoScrollCountY < -1f)
			{
				this._AutoScrollCountY = 0f;
			}
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x00052F5C File Offset: 0x0005135C
	private void OnDestroy()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (!Application.isPlaying && Application.isEditor)
		{
			if (this.ForceMaterial != null && this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (base.gameObject.activeSelf)
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

	// Token: 0x06000459 RID: 1113 RVA: 0x00053068 File Offset: 0x00051468
	private void OnDisable()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.ForceMaterial != null && this.tempMaterial != null)
		{
			UnityEngine.Object.DestroyImmediate(this.tempMaterial);
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

	// Token: 0x0600045A RID: 1114 RVA: 0x00053150 File Offset: 0x00051550
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
			this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
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
			this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
		}
		if (this.__MainTex2)
		{
			this.__MainTex2.wrapMode = TextureWrapMode.Repeat;
			if (base.gameObject.GetComponent<SpriteRenderer>() != null)
			{
				base.GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
			}
		}
	}

	// Token: 0x0400078A RID: 1930
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400078B RID: 1931
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400078C RID: 1932
	private string shader = "2DxFX/Standard/SkyCloud";

	// Token: 0x0400078D RID: 1933
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400078E RID: 1934
	[HideInInspector]
	public Texture2D __MainTex2;

	// Token: 0x0400078F RID: 1935
	[HideInInspector]
	public float _OffsetX;

	// Token: 0x04000790 RID: 1936
	[HideInInspector]
	public float _OffsetY;

	// Token: 0x04000791 RID: 1937
	[HideInInspector]
	[Range(0.1f, 2f)]
	public float _Zoom = 0.2f;

	// Token: 0x04000792 RID: 1938
	[HideInInspector]
	[Range(-1f, 1f)]
	public float _Intensity = 0.3f;

	// Token: 0x04000793 RID: 1939
	[HideInInspector]
	public bool _AutoScrollX;

	// Token: 0x04000794 RID: 1940
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _AutoScrollSpeedX = 0.08f;

	// Token: 0x04000795 RID: 1941
	[HideInInspector]
	public bool _AutoScrollY;

	// Token: 0x04000796 RID: 1942
	[HideInInspector]
	[Range(-2f, 2f)]
	public float _AutoScrollSpeedY = 0.02f;

	// Token: 0x04000797 RID: 1943
	[HideInInspector]
	private float _AutoScrollCountX;

	// Token: 0x04000798 RID: 1944
	[HideInInspector]
	private float _AutoScrollCountY;

	// Token: 0x04000799 RID: 1945
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x0400079A RID: 1946
	private Material tempMaterial;

	// Token: 0x0400079B RID: 1947
	private Material defaultMaterial;

	// Token: 0x0400079C RID: 1948
	private Image CanvasImage;
}
