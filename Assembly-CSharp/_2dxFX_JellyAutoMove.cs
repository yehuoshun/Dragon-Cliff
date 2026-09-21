using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200006F RID: 111
[ExecuteInEditMode]
[AddComponentMenu("2DxFX/Standard/JellyAutoMove")]
[Serializable]
public class _2dxFX_JellyAutoMove : MonoBehaviour
{
	// Token: 0x06000363 RID: 867 RVA: 0x00044558 File Offset: 0x00042958
	public _2dxFX_JellyAutoMove()
	{
	}

	// Token: 0x06000364 RID: 868 RVA: 0x000445BF File Offset: 0x000429BF
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000445E8 File Offset: 0x000429E8
	private void Start()
	{
		this.ShaderChange = 0;
		this.Heat = 0f;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x000445FC File Offset: 0x000429FC
	public void CallUpdate()
	{
		this.Update();
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00044604 File Offset: 0x00042A04
	private void Update()
	{
		if (base.gameObject.GetComponent<Image>() != null && this.CanvasImage == null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		this.SaveMove1 = base.transform.position;
		if (this.SaveMove1.x != this.SaveMove2.x)
		{
			this.Heat += 0.5f;
		}
		if (this.SaveMove1.y != this.SaveMove2.y)
		{
			this.Heat += 0.5f;
		}
		if (this.SaveMove1.z != this.SaveMove2.z)
		{
			this.Heat += 0.5f;
		}
		this.Heat -= Time.deltaTime * this.Stabilisation;
		if (this.Heat > 4f)
		{
			this.Heat = 4f;
		}
		if (this.Heat < 0f)
		{
			this.RandomPos = (float)UnityEngine.Random.Range(0, 256);
			this.Heat = 0f;
		}
		this.SaveMove2 = this.SaveMove1;
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
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Distortion", this.Heat);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_RandomPos", this.RandomPos);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Inside", this.Inside);
				base.GetComponent<Renderer>().sharedMaterial.SetFloat("_Speed", this.Speed);
			}
			else if (base.gameObject.GetComponent<Image>() != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Distortion", this.Heat);
				this.CanvasImage.material.SetFloat("_RandomPos", this.RandomPos);
				this.CanvasImage.material.SetFloat("_Inside", this.Inside);
				this.CanvasImage.material.SetFloat("_Speed", this.Speed);
			}
		}
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00044A10 File Offset: 0x00042E10
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

	// Token: 0x06000369 RID: 873 RVA: 0x00044B1C File Offset: 0x00042F1C
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

	// Token: 0x0600036A RID: 874 RVA: 0x00044BF8 File Offset: 0x00042FF8
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

	// Token: 0x040005EA RID: 1514
	[HideInInspector]
	public Material ForceMaterial;

	// Token: 0x040005EB RID: 1515
	[HideInInspector]
	public bool ActiveChange = true;

	// Token: 0x040005EC RID: 1516
	private string shader = "2DxFX/Standard/Jelly";

	// Token: 0x040005ED RID: 1517
	[HideInInspector]
	[Range(0f, 1f)]
	public float _Alpha = 1f;

	// Token: 0x040005EE RID: 1518
	[HideInInspector]
	[Range(0f, 4f)]
	public float Heat = 1f;

	// Token: 0x040005EF RID: 1519
	[HideInInspector]
	[Range(0f, 4f)]
	public float RandomPos = 1f;

	// Token: 0x040005F0 RID: 1520
	[HideInInspector]
	[Range(1f, 2f)]
	public float Inside = 1f;

	// Token: 0x040005F1 RID: 1521
	[HideInInspector]
	[Range(1f, 8f)]
	public float Stabilisation = 4f;

	// Token: 0x040005F2 RID: 1522
	[HideInInspector]
	[Range(0f, 4f)]
	public float Speed = 1f;

	// Token: 0x040005F3 RID: 1523
	[HideInInspector]
	public int ShaderChange;

	// Token: 0x040005F4 RID: 1524
	private Material tempMaterial;

	// Token: 0x040005F5 RID: 1525
	private Material defaultMaterial;

	// Token: 0x040005F6 RID: 1526
	private Image CanvasImage;

	// Token: 0x040005F7 RID: 1527
	private Vector3 SaveMove1;

	// Token: 0x040005F8 RID: 1528
	private Vector3 SaveMove2;
}
