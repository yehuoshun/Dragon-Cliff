using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
	// Token: 0x02000B53 RID: 2899
	public class Benchmark01_UGUI : MonoBehaviour
	{
		// Token: 0x06004D0E RID: 19726 RVA: 0x001F3847 File Offset: 0x001F1C47
		public Benchmark01_UGUI()
		{
		}

		// Token: 0x06004D0F RID: 19727 RVA: 0x001F3850 File Offset: 0x001F1C50
		private IEnumerator Start()
		{
			if (this.BenchmarkType == 0)
			{
				this.m_textMeshPro = base.gameObject.AddComponent<TextMeshProUGUI>();
				if (this.TMProFont != null)
				{
					this.m_textMeshPro.font = this.TMProFont;
				}
				this.m_textMeshPro.fontSize = 48f;
				this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
				this.m_textMeshPro.extraPadding = true;
				this.m_material01 = this.m_textMeshPro.font.material;
				this.m_material02 = (Resources.Load("Fonts & Materials/LiberationSans SDF - BEVEL", typeof(Material)) as Material);
			}
			else if (this.BenchmarkType == 1)
			{
				this.m_textMesh = base.gameObject.AddComponent<Text>();
				if (this.TextMeshFont != null)
				{
					this.m_textMesh.font = this.TextMeshFont;
				}
				this.m_textMesh.fontSize = 48;
				this.m_textMesh.alignment = TextAnchor.MiddleCenter;
			}
			for (int i = 0; i <= 1000000; i++)
			{
				if (this.BenchmarkType == 0)
				{
					this.m_textMeshPro.text = "The <#0050FF>count is: </color>" + i % 1000;
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

		// Token: 0x04003B4D RID: 15181
		public int BenchmarkType;

		// Token: 0x04003B4E RID: 15182
		public Canvas canvas;

		// Token: 0x04003B4F RID: 15183
		public TMP_FontAsset TMProFont;

		// Token: 0x04003B50 RID: 15184
		public Font TextMeshFont;

		// Token: 0x04003B51 RID: 15185
		private TextMeshProUGUI m_textMeshPro;

		// Token: 0x04003B52 RID: 15186
		private Text m_textMesh;

		// Token: 0x04003B53 RID: 15187
		private const string label01 = "The <#0050FF>count is: </color>";

		// Token: 0x04003B54 RID: 15188
		private const string label02 = "The <color=#0050FF>count is: </color>";

		// Token: 0x04003B55 RID: 15189
		private Material m_material01;

		// Token: 0x04003B56 RID: 15190
		private Material m_material02;

		// Token: 0x02001087 RID: 4231
		[CompilerGenerated]
		private sealed class <Start>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006995 RID: 27029 RVA: 0x001F386B File Offset: 0x001F1C6B
			[DebuggerHidden]
			public <Start>c__Iterator0()
			{
			}

			// Token: 0x06006996 RID: 27030 RVA: 0x001F3874 File Offset: 0x001F1C74
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					if (this.BenchmarkType == 0)
					{
						this.m_textMeshPro = base.gameObject.AddComponent<TextMeshProUGUI>();
						if (this.TMProFont != null)
						{
							this.m_textMeshPro.font = this.TMProFont;
						}
						this.m_textMeshPro.fontSize = 48f;
						this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
						this.m_textMeshPro.extraPadding = true;
						this.m_material01 = this.m_textMeshPro.font.material;
						this.m_material02 = (Resources.Load("Fonts & Materials/LiberationSans SDF - BEVEL", typeof(Material)) as Material);
					}
					else if (this.BenchmarkType == 1)
					{
						this.m_textMesh = base.gameObject.AddComponent<Text>();
						if (this.TextMeshFont != null)
						{
							this.m_textMesh.font = this.TextMeshFont;
						}
						this.m_textMesh.fontSize = 48;
						this.m_textMesh.alignment = TextAnchor.MiddleCenter;
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
						this.m_textMeshPro.text = "The <#0050FF>count is: </color>" + i % 1000;
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

			// Token: 0x17001605 RID: 5637
			// (get) Token: 0x06006997 RID: 27031 RVA: 0x001F3B86 File Offset: 0x001F1F86
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001606 RID: 5638
			// (get) Token: 0x06006998 RID: 27032 RVA: 0x001F3B8E File Offset: 0x001F1F8E
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006999 RID: 27033 RVA: 0x001F3B96 File Offset: 0x001F1F96
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x0600699A RID: 27034 RVA: 0x001F3BA6 File Offset: 0x001F1FA6
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400640E RID: 25614
			internal int <i>__1;

			// Token: 0x0400640F RID: 25615
			internal Benchmark01_UGUI $this;

			// Token: 0x04006410 RID: 25616
			internal object $current;

			// Token: 0x04006411 RID: 25617
			internal bool $disposing;

			// Token: 0x04006412 RID: 25618
			internal int $PC;
		}
	}
}
