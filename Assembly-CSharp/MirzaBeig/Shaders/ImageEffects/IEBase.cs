using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MirzaBeig.Shaders.ImageEffects
{
	// Token: 0x0200039B RID: 923
	[ExecuteInEditMode]
	[Serializable]
	public class IEBase : MonoBehaviour
	{
		// Token: 0x060018A5 RID: 6309 RVA: 0x000BECA4 File Offset: 0x000BD0A4
		public IEBase()
		{
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060018A6 RID: 6310 RVA: 0x000BECAC File Offset: 0x000BD0AC
		protected Material material
		{
			get
			{
				if (!this._material)
				{
					this._material = new Material(this.shader);
					this._material.hideFlags = HideFlags.HideAndDontSave;
				}
				return this._material;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060018A7 RID: 6311 RVA: 0x000BECE2 File Offset: 0x000BD0E2
		// (set) Token: 0x060018A8 RID: 6312 RVA: 0x000BECEA File Offset: 0x000BD0EA
		protected Shader shader
		{
			[CompilerGenerated]
			get
			{
				return this.<shader>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<shader>k__BackingField = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060018A9 RID: 6313 RVA: 0x000BECF3 File Offset: 0x000BD0F3
		protected Camera camera
		{
			get
			{
				if (!this._camera)
				{
					this._camera = base.GetComponent<Camera>();
				}
				return this._camera;
			}
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x000BED17 File Offset: 0x000BD117
		private void Awake()
		{
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x000BED19 File Offset: 0x000BD119
		private void Start()
		{
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x000BED1B File Offset: 0x000BD11B
		private void Update()
		{
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x000BED1D File Offset: 0x000BD11D
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x000BED1F File Offset: 0x000BD11F
		protected void blit(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, this.material);
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x000BED2E File Offset: 0x000BD12E
		private void OnDisable()
		{
			if (this._material)
			{
				UnityEngine.Object.DestroyImmediate(this._material);
			}
		}

		// Token: 0x04001888 RID: 6280
		private Material _material;

		// Token: 0x04001889 RID: 6281
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Shader <shader>k__BackingField;

		// Token: 0x0400188A RID: 6282
		private Camera _camera;
	}
}
