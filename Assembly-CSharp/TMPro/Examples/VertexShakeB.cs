using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B7A RID: 2938
	public class VertexShakeB : MonoBehaviour
	{
		// Token: 0x06004D96 RID: 19862 RVA: 0x001F9D8E File Offset: 0x001F818E
		public VertexShakeB()
		{
		}

		// Token: 0x06004D97 RID: 19863 RVA: 0x001F9DB7 File Offset: 0x001F81B7
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D98 RID: 19864 RVA: 0x001F9DC5 File Offset: 0x001F81C5
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D99 RID: 19865 RVA: 0x001F9DDD File Offset: 0x001F81DD
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D9A RID: 19866 RVA: 0x001F9DF5 File Offset: 0x001F81F5
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x06004D9B RID: 19867 RVA: 0x001F9E04 File Offset: 0x001F8204
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			if (this.m_TextComponent)
			{
				this.hasTextChanged = true;
			}
		}

		// Token: 0x06004D9C RID: 19868 RVA: 0x001F9E20 File Offset: 0x001F8220
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
						Quaternion q = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-0.25f, 0.25f));
						for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
						{
							if (textInfo.characterInfo[k].isVisible)
							{
								int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
								int vertexIndex = textInfo.characterInfo[k].vertexIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 b2 = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
								copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - b2;
								float d = UnityEngine.Random.Range(0.95f, 1.05f);
								Matrix4x4 matrix = Matrix4x4.TRS(Vector3.one, Quaternion.identity, Vector3.one * d);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] -= b;
								matrix = Matrix4x4.TRS(Vector3.one, q, Vector3.one);
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

		// Token: 0x04003C19 RID: 15385
		public float AngleMultiplier = 1f;

		// Token: 0x04003C1A RID: 15386
		public float SpeedMultiplier = 1f;

		// Token: 0x04003C1B RID: 15387
		public float CurveScale = 1f;

		// Token: 0x04003C1C RID: 15388
		private TMP_Text m_TextComponent;

		// Token: 0x04003C1D RID: 15389
		private bool hasTextChanged;

		// Token: 0x02001093 RID: 4243
		[CompilerGenerated]
		private sealed class <AnimateVertexColors>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069DD RID: 27101 RVA: 0x001F9E3B File Offset: 0x001F823B
			[DebuggerHidden]
			public <AnimateVertexColors>c__Iterator0()
			{
			}

			// Token: 0x060069DE RID: 27102 RVA: 0x001F9E44 File Offset: 0x001F8244
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
						Quaternion q = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-0.25f, 0.25f));
						for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
						{
							if (textInfo.characterInfo[k].isVisible)
							{
								int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
								int vertexIndex = textInfo.characterInfo[k].vertexIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 b2 = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
								copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - b2;
								float d = UnityEngine.Random.Range(0.95f, 1.05f);
								matrix = Matrix4x4.TRS(Vector3.one, Quaternion.identity, Vector3.one * d);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] -= b;
								matrix = Matrix4x4.TRS(Vector3.one, q, Vector3.one);
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

			// Token: 0x1700161D RID: 5661
			// (get) Token: 0x060069DF RID: 27103 RVA: 0x001FA600 File Offset: 0x001F8A00
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700161E RID: 5662
			// (get) Token: 0x060069E0 RID: 27104 RVA: 0x001FA608 File Offset: 0x001F8A08
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069E1 RID: 27105 RVA: 0x001FA610 File Offset: 0x001F8A10
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069E2 RID: 27106 RVA: 0x001FA620 File Offset: 0x001F8A20
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006477 RID: 25719
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x04006478 RID: 25720
			internal Vector3[][] <copyOfVertices>__0;

			// Token: 0x04006479 RID: 25721
			internal int <characterCount>__1;

			// Token: 0x0400647A RID: 25722
			internal int <lineCount>__1;

			// Token: 0x0400647B RID: 25723
			internal Matrix4x4 <matrix>__2;

			// Token: 0x0400647C RID: 25724
			internal VertexShakeB $this;

			// Token: 0x0400647D RID: 25725
			internal object $current;

			// Token: 0x0400647E RID: 25726
			internal bool $disposing;

			// Token: 0x0400647F RID: 25727
			internal int $PC;
		}
	}
}
