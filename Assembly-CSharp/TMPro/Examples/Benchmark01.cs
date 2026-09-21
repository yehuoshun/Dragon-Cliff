using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B52 RID: 2898
	public class Benchmark01 : MonoBehaviour
	{
		// Token: 0x06004D0C RID: 19724 RVA: 0x001F344B File Offset: 0x001F184B
		public Benchmark01()
		{
		}

		// Token: 0x06004D0D RID: 19725 RVA: 0x001F3454 File Offset: 0x001F1854
		private IEnumerator Start()
		{
			if (this.BenchmarkType == 0)
			{
				this.m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
				this.m_textMeshPro.autoSizeTextContainer = true;
				if (this.TMProFont != null)
				{
					this.m_textMeshPro.font = this.TMProFont;
				}
				this.m_textMeshPro.fontSize = 48f;
				this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
				this.m_textMeshPro.extraPadding = true;
				this.m_textMeshPro.enableWordWrapping = false;
				this.m_material01 = this.m_textMeshPro.font.material;
				this.m_material02 = (Resources.Load("Fonts & Materials/LiberationSans SDF - Drop Shadow", typeof(Material)) as Material);
			}
			else if (this.BenchmarkType == 1)
			{
				this.m_textMesh = base.gameObject.AddComponent<TextMesh>();
				if (this.TextMeshFont != null)
				{
					this.m_textMesh.font = this.TextMeshFont;
					this.m_textMesh.GetComponent<Renderer>().sharedMaterial = this.m_textMesh.font.material;
				}
				else
				{
					this.m_textMesh.font = (Resources.Load("Fonts/ARIAL", typeof(Font)) as Font);
					this.m_textMesh.GetComponent<Renderer>().sharedMaterial = this.m_textMesh.font.material;
				}
				this.m_textMesh.fontSize = 48;
				this.m_textMesh.anchor = TextAnchor.MiddleCenter;
			}
			for (int i = 0; i <= 1000000; i++)
			{
				if (this.BenchmarkType == 0)
				{
					this.m_textMeshPro.SetText("The <#0050FF>count is: </color>{0}", (float)(i % 1000));
					if (i % 1000 == 999)
					{
						TMP_Text textMeshPro = this.m_textMeshPro;
						Material fontSharedMaterial;
						if (this.m_textMeshPro.fontSharedMaterial == this.m_material01)
						{
							Material material = this.m_material02;
							this.m_textMeshPro.fontSharedMaterial = material;
							fontSharedMaterial = material;
						}
						else
						{
							Material material = this.m_material01;
							this.m_textMeshPro.fontSharedMaterial = material;
							fontSharedMaterial = material;
						}
						textMeshPro.fontSharedMaterial = fontSharedMaterial;
					}
				}
				else if (this.BenchmarkType == 1)
				{
					this.m_textMesh.text = "The <color=#0050FF>count is: </color>" + (i % 1000).ToString();
				}
				yield return null;
			}
			yield return null;
			yield break;
		}

		// Token: 0x04003B43 RID: 15171
		public int BenchmarkType;

		// Token: 0x04003B44 RID: 15172
		public TMP_FontAsset TMProFont;

		// Token: 0x04003B45 RID: 15173
		public Font TextMeshFont;

		// Token: 0x04003B46 RID: 15174
		private TextMeshPro m_textMeshPro;

		// Token: 0x04003B47 RID: 15175
		private TextContainer m_textContainer;

		// Token: 0x04003B48 RID: 15176
		private TextMesh m_textMesh;

		// Token: 0x04003B49 RID: 15177
		private const string label01 = "The <#0050FF>count is: </color>{0}";

		// Token: 0x04003B4A RID: 15178
		private const string label02 = "The <color=#0050FF>count is: </color>";

		// Token: 0x04003B4B RID: 15179
		private Material m_material01;

		// Token: 0x04003B4C RID: 15180
		private Material m_material02;

		// Token: 0x02001086 RID: 4230
		[CompilerGenerated]
		private sealed class <Start>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600698F RID: 27023 RVA: 0x001F346F File Offset: 0x001F186F
			[DebuggerHidden]
			public <Start>c__Iterator0()
			{
			}

			// Token: 0x06006990 RID: 27024 RVA: 0x001F3478 File Offset: 0x001F1878
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					if (this.BenchmarkType == 0)
					{
						this.m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
						this.m_textMeshPro.autoSizeTextContainer = true;
						if (this.TMProFont != null)
						{
							this.m_textMeshPro.font = this.TMProFont;
						}
						this.m_textMeshPro.fontSize = 48f;
						this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
						this.m_textMeshPro.extraPadding = true;
						this.m_textMeshPro.enableWordWrapping = false;
						this.m_material01 = this.m_textMeshPro.font.material;
						this.m_material02 = (Resources.Load("Fonts & Materials/LiberationSans SDF - Drop Shadow", typeof(Material)) as Material);
					}
					else if (this.BenchmarkType == 1)
					{
						this.m_textMesh = base.gameObject.AddComponent<TextMesh>();
						if (this.TextMeshFont != null)
						{
							this.m_textMesh.font = this.TextMeshFont;
							this.m_textMesh.GetComponent<Renderer>().sharedMaterial = this.m_textMesh.font.material;
						}
						else
						{
							this.m_textMesh.font = (Resources.Load("Fonts/ARIAL", typeof(Font)) as Font);
							this.m_textMesh.GetComponent<Renderer>().sharedMaterial = this.m_textMesh.font.material;
						}
						this.m_textMesh.fontSize = 48;
						this.m_textMesh.anchor = TextAnchor.MiddleCenter;
					}
					i = 0;
					break;
				case 1u:
					i++;
					break;
				case 2u:
					this.$PC = -1;
					return false;
				default:
					return false;
				}
				if (i > 1000000)
				{
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				else
				{
					if (this.BenchmarkType == 0)
					{
						this.m_textMeshPro.SetText("The <#0050FF>count is: </color>{0}", (float)(i % 1000));
						if (i % 1000 == 999)
						{
							TMP_Text textMeshPro = this.m_textMeshPro;
							Material fontSharedMaterial;
							if (this.m_textMeshPro.fontSharedMaterial == this.m_material01)
							{
								Material material = this.m_material02;
								this.m_textMeshPro.fontSharedMaterial = material;
								fontSharedMaterial = material;
							}
							else
							{
								Material material = this.m_material01;
								this.m_textMeshPro.fontSharedMaterial = material;
								fontSharedMaterial = material;
							}
							textMeshPro.fontSharedMaterial = fontSharedMaterial;
						}
					}
					else if (this.BenchmarkType == 1)
					{
						this.m_textMesh.text = "The <color=#0050FF>count is: </color>" + (i % 1000).ToString();
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				return true;
			}

			// Token: 0x17001603 RID: 5635
			// (get) Token: 0x06006991 RID: 27025 RVA: 0x001F3820 File Offset: 0x001F1C20
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001604 RID: 5636
			// (get) Token: 0x06006992 RID: 27026 RVA: 0x001F3828 File Offset: 0x001F1C28
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006993 RID: 27027 RVA: 0x001F3830 File Offset: 0x001F1C30
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06006994 RID: 27028 RVA: 0x001F3840 File Offset: 0x001F1C40
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006409 RID: 25609
			internal int <i>__1;

			// Token: 0x0400640A RID: 25610
			internal Benchmark01 $this;

			// Token: 0x0400640B RID: 25611
			internal object $current;

			// Token: 0x0400640C RID: 25612
			internal bool $disposing;

			// Token: 0x0400640D RID: 25613
			internal int $PC;
		}
	}
}
