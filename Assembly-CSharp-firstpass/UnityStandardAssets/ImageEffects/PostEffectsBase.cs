using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x020001C5 RID: 453
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class PostEffectsBase : MonoBehaviour
	{
		// Token: 0x06000C22 RID: 3106 RVA: 0x0001B6E2 File Offset: 0x00019AE2
		public PostEffectsBase()
		{
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0001B6F8 File Offset: 0x00019AF8
		protected Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
		{
			if (!s)
			{
				Debug.Log("Missing shader in " + this.ToString());
				base.enabled = false;
				return null;
			}
			if (s.isSupported && m2Create && m2Create.shader == s)
			{
				return m2Create;
			}
			if (!s.isSupported)
			{
				this.NotSupported();
				Debug.Log(string.Concat(new string[]
				{
					"The shader ",
					s.ToString(),
					" on effect ",
					this.ToString(),
					" is not supported on this platform!"
				}));
				return null;
			}
			m2Create = new Material(s);
			m2Create.hideFlags = HideFlags.DontSave;
			if (m2Create)
			{
				return m2Create;
			}
			return null;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0001B7C4 File Offset: 0x00019BC4
		protected Material CreateMaterial(Shader s, Material m2Create)
		{
			if (!s)
			{
				Debug.Log("Missing shader in " + this.ToString());
				return null;
			}
			if (m2Create && m2Create.shader == s && s.isSupported)
			{
				return m2Create;
			}
			if (!s.isSupported)
			{
				return null;
			}
			m2Create = new Material(s);
			m2Create.hideFlags = HideFlags.DontSave;
			if (m2Create)
			{
				return m2Create;
			}
			return null;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0001B847 File Offset: 0x00019C47
		private void OnEnable()
		{
			this.isSupported = true;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x0001B850 File Offset: 0x00019C50
		protected bool CheckSupport()
		{
			return this.CheckSupport(false);
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x0001B859 File Offset: 0x00019C59
		public virtual bool CheckResources()
		{
			Debug.LogWarning("CheckResources () for " + this.ToString() + " should be overwritten.");
			return this.isSupported;
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x0001B87B File Offset: 0x00019C7B
		protected void Start()
		{
			this.CheckResources();
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0001B884 File Offset: 0x00019C84
		protected bool CheckSupport(bool needDepth)
		{
			this.isSupported = true;
			this.supportHDRTextures = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
			this.supportDX11 = (SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders);
			if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
			{
				this.NotSupported();
				return false;
			}
			if (needDepth && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				this.NotSupported();
				return false;
			}
			if (needDepth)
			{
				base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
			}
			return true;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0001B90D File Offset: 0x00019D0D
		protected bool CheckSupport(bool needDepth, bool needHdr)
		{
			if (!this.CheckSupport(needDepth))
			{
				return false;
			}
			if (needHdr && !this.supportHDRTextures)
			{
				this.NotSupported();
				return false;
			}
			return true;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0001B937 File Offset: 0x00019D37
		public bool Dx11Support()
		{
			return this.supportDX11;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0001B93F File Offset: 0x00019D3F
		protected void ReportAutoDisable()
		{
			Debug.LogWarning("The image effect " + this.ToString() + " has been disabled as it's not supported on the current platform.");
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0001B95C File Offset: 0x00019D5C
		private bool CheckShader(Shader s)
		{
			Debug.Log(string.Concat(new string[]
			{
				"The shader ",
				s.ToString(),
				" on effect ",
				this.ToString(),
				" is not part of the Unity 3.2+ effects suite anymore. For best performance and quality, please ensure you are using the latest Standard Assets Image Effects (Pro only) package."
			}));
			if (!s.isSupported)
			{
				this.NotSupported();
				return false;
			}
			return false;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0001B9B7 File Offset: 0x00019DB7
		protected void NotSupported()
		{
			base.enabled = false;
			this.isSupported = false;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0001B9C8 File Offset: 0x00019DC8
		protected void DrawBorder(RenderTexture dest, Material material)
		{
			RenderTexture.active = dest;
			bool flag = true;
			GL.PushMatrix();
			GL.LoadOrtho();
			for (int i = 0; i < material.passCount; i++)
			{
				material.SetPass(i);
				float y;
				float y2;
				if (flag)
				{
					y = 1f;
					y2 = 0f;
				}
				else
				{
					y = 0f;
					y2 = 1f;
				}
				float x = 0f;
				float x2 = 1f / ((float)dest.width * 1f);
				float y3 = 0f;
				float y4 = 1f;
				GL.Begin(7);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 1f - 1f / ((float)dest.width * 1f);
				x2 = 1f;
				y3 = 0f;
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 0f;
				y4 = 1f / ((float)dest.height * 1f);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 1f - 1f / ((float)dest.height * 1f);
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				GL.End();
			}
			GL.PopMatrix();
		}

		// Token: 0x040009DC RID: 2524
		protected bool supportHDRTextures = true;

		// Token: 0x040009DD RID: 2525
		protected bool supportDX11;

		// Token: 0x040009DE RID: 2526
		protected bool isSupported = true;
	}
}
