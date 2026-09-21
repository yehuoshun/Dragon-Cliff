using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000061 RID: 97
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/Ghost")]
[Serializable]
public class _2dxFX_Ghost : MonoBehaviour
{
	// Token: 0x060002F3 RID: 755 RVA: 0x0003D200 File Offset: 0x0003B600
	public _2dxFX_Ghost()
	{
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0003D267 File Offset: 0x0003B667
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0003D290 File Offset: 0x0003B690
	private void Start()
	{
		this.ShaderChange = 0;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0003D299 File Offset: 0x0003B699
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0003D2A4 File Offset: 0x0003B6A4
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipLeft", 1f - this._ClipLeft);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipRight", 1f - this._ClipRight);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipUp", 1f - this._ClipUp);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_ClipDown", 1f - this._ClipDown);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", 1f - this._Alpha);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_offset", this._offset);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_ClipLeft", 1f - this._ClipLeft);
				this.CanvasImage.material.SetFloat("_ClipRight", 1f - this._ClipRight);
				this.CanvasImage.material.SetFloat("_ClipUp", 1f - this._ClipUp);
				this.CanvasImage.material.SetFloat("_ClipDown", 1f - this._ClipDown);
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_offset", this._offset);
			}
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0003D610 File Offset: 0x0003BA10
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

	// Token: 0x060002F9 RID: 761 RVA: 0x0003D71C File Offset: 0x0003BB1C
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

	// Token: 0x060002FA RID: 762 RVA: 0x0003D7F8 File Offset: 0x0003BBF8
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

	// Token: 0x0400054A RID: 1354
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x0400054B RID: 1355
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x0400054C RID: 1356
	private string shader = "2DxFX/Standard/Ghost";

	// Token: 0x0400054D RID: 1357
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x0400054E RID: 1358
	[HideInInspector]
	[Range(0f, 1f)]
	public float _offset = 0.4f;

	// Token: 0x0400054F RID: 1359
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipLeft = 0.4f;

	// Token: 0x04000550 RID: 1360
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipRight = 0.2f;

	// Token: 0x04000551 RID: 1361
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipUp = 0.1f;

	// Token: 0x04000552 RID: 1362
	[HideInInspector]
	[Range(0f, 1f)]
	public float _ClipDown = 0.5f;

	// Token: 0x04000553 RID: 1363
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x04000554 RID: 1364
	private Material tempMaterial;

	// Token: 0x04000555 RID: 1365
	private Material defaultMaterial;

	// Token: 0x04000556 RID: 1366
	private Image CanvasImage;
}
