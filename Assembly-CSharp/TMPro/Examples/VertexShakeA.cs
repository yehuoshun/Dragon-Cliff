using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B79 RID: 2937
	public class VertexShakeA : MonoBehaviour
	{
		// Token: 0x06004D8F RID: 19855 RVA: 0x001F96FF File Offset: 0x001F7AFF
		public VertexShakeA()
		{
		}

		// Token: 0x06004D90 RID: 19856 RVA: 0x001F9733 File Offset: 0x001F7B33
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D91 RID: 19857 RVA: 0x001F9741 File Offset: 0x001F7B41
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D92 RID: 19858 RVA: 0x001F9759 File Offset: 0x001F7B59
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D93 RID: 19859 RVA: 0x001F9771 File Offset: 0x001F7B71
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x06004D94 RID: 19860 RVA: 0x001F9780 File Offset: 0x001F7B80
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			if (this.m_TextComponent)
			{
				this.hasTextChanged = true;
			}
		}

		// Token: 0x06004D95 RID: 19861 RVA: 0x001F979C File Offset: 0x001F7B9C
		private IEnumerator AnimateVertexColors()
		{
			this.m_TextComponent.ForceMeshUpdate();
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			Vector3[][] copyOfVertices = new Vector3[0][];
			this.hasTextChanged = true;
			for (;;)
			{
				if (this.hasTextChanged)
				{
					if (copyOfVertices.Length < textInfo.meshInfo.Length)
					{
						copyOfVertices = new Vector3[textInfo.meshInfo.Length][];
					}
					for (int i = 0; i < textInfo.meshInfo.Length; i++)
					{
						int num = textInfo.meshInfo[i].vertices.Length;
						copyOfVertices[i] = new Vector3[num];
					}
					this.hasTextChanged = false;
				}
				if (textInfo.characterCount == 0)
				{
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					int lineCount = textInfo.lineCount;
					for (int j = 0; j < lineCount; j++)
					{
						int firstCharacterIndex = textInfo.lineInfo[j].firstCharacterIndex;
						int lastCharacterIndex = textInfo.lineInfo[j].lastCharacterIndex;
						Vector3 b = (textInfo.characterInfo[firstCharacterIndex].bottomLeft + textInfo.characterInfo[lastCharacterIndex].topRight) / 2f;
						Quaternion q = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-0.25f, 0.25f) * this.RotationMultiplier);
						for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
						{
							if (textInfo.characterInfo[k].isVisible)
							{
								int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
								int vertexIndex = textInfo.characterInfo[k].vertexIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - b;
								float d = UnityEngine.Random.Range(0.995f - 0.001f * this.ScaleMultiplier, 1.005f + 0.001f * this.ScaleMultiplier);
								Matrix4x4 matrix = Matrix4x4.TRS(Vector3.one, q, Vector3.one * d);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b;
							}
						}
					}
					for (int l = 0; l < textInfo.meshInfo.Length; l++)
					{
						textInfo.meshInfo[l].mesh.vertices = copyOfVertices[l];
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
					}
					yield return new WaitForSeconds(0.1f);
				}
			}
			yield break;
		}

		// Token: 0x04003C13 RID: 15379
		public float AngleMultiplier = 1f;

		// Token: 0x04003C14 RID: 15380
		public float SpeedMultiplier = 1f;

		// Token: 0x04003C15 RID: 15381
		public float ScaleMultiplier = 1f;

		// Token: 0x04003C16 RID: 15382
		public float RotationMultiplier = 1f;

		// Token: 0x04003C17 RID: 15383
		private TMP_Text m_TextComponent;

		// Token: 0x04003C18 RID: 15384
		private bool hasTextChanged;

		// Token: 0x02001092 RID: 4242
		[CompilerGenerated]
		private sealed class <AnimateVertexColors>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069D7 RID: 27095 RVA: 0x001F97B7 File Offset: 0x001F7BB7
			[DebuggerHidden]
			public <AnimateVertexColors>c__Iterator0()
			{
			}

			// Token: 0x060069D8 RID: 27096 RVA: 0x001F97C0 File Offset: 0x001F7BC0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.m_TextComponent.ForceMeshUpdate();
					textInfo = this.m_TextComponent.textInfo;
					copyOfVertices = new Vector3[0][];
					this.hasTextChanged = true;
					break;
				case 1u:
					break;
				case 2u:
					break;
				default:
					return false;
				}
				if (this.hasTextChanged)
				{
					if (copyOfVertices.Length < textInfo.meshInfo.Length)
					{
						copyOfVertices = new Vector3[textInfo.meshInfo.Length][];
					}
					for (int i = 0; i < textInfo.meshInfo.Length; i++)
					{
						int num2 = textInfo.meshInfo[i].vertices.Length;
						copyOfVertices[i] = new Vector3[num2];
					}
					this.hasTextChanged = false;
				}
				int characterCount = textInfo.characterCount;
				if (characterCount == 0)
				{
					this.$current = new WaitForSeconds(0.25f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				else
				{
					lineCount = textInfo.lineCount;
					for (int j = 0; j < lineCount; j++)
					{
						int firstCharacterIndex = textInfo.lineInfo[j].firstCharacterIndex;
						int lastCharacterIndex = textInfo.lineInfo[j].lastCharacterIndex;
						Vector3 b = (textInfo.characterInfo[firstCharacterIndex].bottomLeft + textInfo.characterInfo[lastCharacterIndex].topRight) / 2f;
						Quaternion q = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-0.25f, 0.25f) * this.RotationMultiplier);
						for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
						{
							if (textInfo.characterInfo[k].isVisible)
							{
								int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
								int vertexIndex = textInfo.characterInfo[k].vertexIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - b;
								float d = UnityEngine.Random.Range(0.995f - 0.001f * this.ScaleMultiplier, 1.005f + 0.001f * this.ScaleMultiplier);
								matrix = Matrix4x4.TRS(Vector3.one, q, Vector3.one * d);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b;
							}
						}
					}
					for (int l = 0; l < textInfo.meshInfo.Length; l++)
					{
						textInfo.meshInfo[l].mesh.vertices = copyOfVertices[l];
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
					}
					this.$current = new WaitForSeconds(0.1f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				return true;
			}

			// Token: 0x1700161B RID: 5659
			// (get) Token: 0x060069D9 RID: 27097 RVA: 0x001F9D67 File Offset: 0x001F8167
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700161C RID: 5660
			// (get) Token: 0x060069DA RID: 27098 RVA: 0x001F9D6F File Offset: 0x001F816F
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069DB RID: 27099 RVA: 0x001F9D77 File Offset: 0x001F8177
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069DC RID: 27100 RVA: 0x001F9D87 File Offset: 0x001F8187
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400646E RID: 25710
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x0400646F RID: 25711
			internal Vector3[][] <copyOfVertices>__0;

			// Token: 0x04006470 RID: 25712
			internal int <characterCount>__1;

			// Token: 0x04006471 RID: 25713
			internal int <lineCount>__1;

			// Token: 0x04006472 RID: 25714
			internal Matrix4x4 <matrix>__2;

			// Token: 0x04006473 RID: 25715
			internal VertexShakeA $this;

			// Token: 0x04006474 RID: 25716
			internal object $current;

			// Token: 0x04006475 RID: 25717
			internal bool $disposing;

			// Token: 0x04006476 RID: 25718
			internal int $PC;
		}
	}
}
