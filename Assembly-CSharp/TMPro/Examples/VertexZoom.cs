using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B7B RID: 2939
	public class VertexZoom : MonoBehaviour
	{
		// Token: 0x06004D9D RID: 19869 RVA: 0x001FA627 File Offset: 0x001F8A27
		public VertexZoom()
		{
		}

		// Token: 0x06004D9E RID: 19870 RVA: 0x001FA650 File Offset: 0x001F8A50
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D9F RID: 19871 RVA: 0x001FA65E File Offset: 0x001F8A5E
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004DA0 RID: 19872 RVA: 0x001FA676 File Offset: 0x001F8A76
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004DA1 RID: 19873 RVA: 0x001FA68E File Offset: 0x001F8A8E
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x06004DA2 RID: 19874 RVA: 0x001FA69D File Offset: 0x001F8A9D
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			if (obj == this.m_TextComponent)
			{
				this.hasTextChanged = true;
			}
		}

		// Token: 0x06004DA3 RID: 19875 RVA: 0x001FA6B8 File Offset: 0x001F8AB8
		private IEnumerator AnimateVertexColors()
		{
			this.m_TextComponent.ForceMeshUpdate();
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			TMP_MeshInfo[] cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
			List<float> modifiedCharScale = new List<float>();
			List<int> scaleSortingOrder = new List<int>();
			this.hasTextChanged = true;
			for (;;)
			{
				if (this.hasTextChanged)
				{
					cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
					this.hasTextChanged = false;
				}
				int characterCount = textInfo.characterCount;
				if (characterCount == 0)
				{
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					modifiedCharScale.Clear();
					scaleSortingOrder.Clear();
					for (int i = 0; i < characterCount; i++)
					{
						TMP_CharacterInfo tmp_CharacterInfo = textInfo.characterInfo[i];
						if (tmp_CharacterInfo.isVisible)
						{
							int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
							int vertexIndex = textInfo.characterInfo[i].vertexIndex;
							Vector3[] vertices = cachedMeshInfoVertexData[materialReferenceIndex].vertices;
							Vector2 v = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
							Vector3 b2 = v;
							Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
							vertices2[vertexIndex] = vertices[vertexIndex] - b2;
							vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - b2;
							vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - b2;
							vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - b2;
							float num = UnityEngine.Random.Range(1f, 1.5f);
							modifiedCharScale.Add(num);
							scaleSortingOrder.Add(modifiedCharScale.Count - 1);
							Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, Vector3.one * num);
							vertices2[vertexIndex] = matrix.MultiplyPoint3x4(vertices2[vertexIndex]);
							vertices2[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 1]);
							vertices2[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 2]);
							vertices2[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 3]);
							vertices2[vertexIndex] += b2;
							vertices2[vertexIndex + 1] += b2;
							vertices2[vertexIndex + 2] += b2;
							vertices2[vertexIndex + 3] += b2;
							Vector2[] uvs = cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
							Vector2[] uvs2 = textInfo.meshInfo[materialReferenceIndex].uvs0;
							uvs2[vertexIndex] = uvs[vertexIndex];
							uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
							uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
							uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
							Color32[] colors = cachedMeshInfoVertexData[materialReferenceIndex].colors32;
							Color32[] colors2 = textInfo.meshInfo[materialReferenceIndex].colors32;
							colors2[vertexIndex] = colors[vertexIndex];
							colors2[vertexIndex + 1] = colors[vertexIndex + 1];
							colors2[vertexIndex + 2] = colors[vertexIndex + 2];
							colors2[vertexIndex + 3] = colors[vertexIndex + 3];
						}
					}
					for (int j = 0; j < textInfo.meshInfo.Length; j++)
					{
						scaleSortingOrder.Sort((int a, int b) => modifiedCharScale[a].CompareTo(modifiedCharScale[b]));
						textInfo.meshInfo[j].SortGeometry(scaleSortingOrder);
						textInfo.meshInfo[j].mesh.vertices = textInfo.meshInfo[j].vertices;
						textInfo.meshInfo[j].mesh.uv = textInfo.meshInfo[j].uvs0;
						textInfo.meshInfo[j].mesh.colors32 = textInfo.meshInfo[j].colors32;
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[j].mesh, j);
					}
					yield return new WaitForSeconds(0.1f);
				}
			}
			yield break;
		}

		// Token: 0x04003C1E RID: 15390
		public float AngleMultiplier = 1f;

		// Token: 0x04003C1F RID: 15391
		public float SpeedMultiplier = 1f;

		// Token: 0x04003C20 RID: 15392
		public float CurveScale = 1f;

		// Token: 0x04003C21 RID: 15393
		private TMP_Text m_TextComponent;

		// Token: 0x04003C22 RID: 15394
		private bool hasTextChanged;

		// Token: 0x02001094 RID: 4244
		[CompilerGenerated]
		private sealed class <AnimateVertexColors>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069E3 RID: 27107 RVA: 0x001FA6D3 File Offset: 0x001F8AD3
			[DebuggerHidden]
			public <AnimateVertexColors>c__Iterator0()
			{
			}

			// Token: 0x060069E4 RID: 27108 RVA: 0x001FA6DC File Offset: 0x001F8ADC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
				{
					this.m_TextComponent.ForceMeshUpdate();
					textInfo = this.m_TextComponent.textInfo;
					cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
					List<float> modifiedCharScale = new List<float>();
					scaleSortingOrder = new List<int>();
					this.hasTextChanged = true;
					break;
				}
				case 1u:
					break;
				case 2u:
					break;
				default:
					return false;
				}
				if (this.hasTextChanged)
				{
					cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
					this.hasTextChanged = false;
				}
				characterCount = textInfo.characterCount;
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
					<AnimateVertexColors>c__AnonStorey.modifiedCharScale.Clear();
					scaleSortingOrder.Clear();
					for (int i = 0; i < characterCount; i++)
					{
						TMP_CharacterInfo tmp_CharacterInfo = textInfo.characterInfo[i];
						if (tmp_CharacterInfo.isVisible)
						{
							int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
							int vertexIndex = textInfo.characterInfo[i].vertexIndex;
							Vector3[] vertices = cachedMeshInfoVertexData[materialReferenceIndex].vertices;
							Vector2 v = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
							Vector3 b2 = v;
							Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
							vertices2[vertexIndex] = vertices[vertexIndex] - b2;
							vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - b2;
							vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - b2;
							vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - b2;
							float num2 = UnityEngine.Random.Range(1f, 1.5f);
							<AnimateVertexColors>c__AnonStorey.modifiedCharScale.Add(num2);
							scaleSortingOrder.Add(<AnimateVertexColors>c__AnonStorey.modifiedCharScale.Count - 1);
							matrix = Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, Vector3.one * num2);
							vertices2[vertexIndex] = matrix.MultiplyPoint3x4(vertices2[vertexIndex]);
							vertices2[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 1]);
							vertices2[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 2]);
							vertices2[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 3]);
							vertices2[vertexIndex] += b2;
							vertices2[vertexIndex + 1] += b2;
							vertices2[vertexIndex + 2] += b2;
							vertices2[vertexIndex + 3] += b2;
							Vector2[] uvs = cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
							Vector2[] uvs2 = textInfo.meshInfo[materialReferenceIndex].uvs0;
							uvs2[vertexIndex] = uvs[vertexIndex];
							uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
							uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
							uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
							Color32[] colors = cachedMeshInfoVertexData[materialReferenceIndex].colors32;
							Color32[] colors2 = textInfo.meshInfo[materialReferenceIndex].colors32;
							colors2[vertexIndex] = colors[vertexIndex];
							colors2[vertexIndex + 1] = colors[vertexIndex + 1];
							colors2[vertexIndex + 2] = colors[vertexIndex + 2];
							colors2[vertexIndex + 3] = colors[vertexIndex + 3];
						}
					}
					for (int j = 0; j < textInfo.meshInfo.Length; j++)
					{
						scaleSortingOrder.Sort((int a, int b) => <AnimateVertexColors>c__AnonStorey.modifiedCharScale[a].CompareTo(<AnimateVertexColors>c__AnonStorey.modifiedCharScale[b]));
						textInfo.meshInfo[j].SortGeometry(scaleSortingOrder);
						textInfo.meshInfo[j].mesh.vertices = textInfo.meshInfo[j].vertices;
						textInfo.meshInfo[j].mesh.uv = textInfo.meshInfo[j].uvs0;
						textInfo.meshInfo[j].mesh.colors32 = textInfo.meshInfo[j].colors32;
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[j].mesh, j);
					}
					this.$current = new WaitForSeconds(0.1f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				return true;
			}

			// Token: 0x1700161F RID: 5663
			// (get) Token: 0x060069E5 RID: 27109 RVA: 0x001FADA6 File Offset: 0x001F91A6
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001620 RID: 5664
			// (get) Token: 0x060069E6 RID: 27110 RVA: 0x001FADAE File Offset: 0x001F91AE
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069E7 RID: 27111 RVA: 0x001FADB6 File Offset: 0x001F91B6
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069E8 RID: 27112 RVA: 0x001FADC6 File Offset: 0x001F91C6
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006480 RID: 25728
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x04006481 RID: 25729
			internal TMP_MeshInfo[] <cachedMeshInfoVertexData>__0;

			// Token: 0x04006482 RID: 25730
			internal List<int> <scaleSortingOrder>__0;

			// Token: 0x04006483 RID: 25731
			internal int <characterCount>__1;

			// Token: 0x04006484 RID: 25732
			internal Matrix4x4 <matrix>__2;

			// Token: 0x04006485 RID: 25733
			internal VertexZoom $this;

			// Token: 0x04006486 RID: 25734
			internal object $current;

			// Token: 0x04006487 RID: 25735
			internal bool $disposing;

			// Token: 0x04006488 RID: 25736
			internal int $PC;

			// Token: 0x04006489 RID: 25737
			private VertexZoom.<AnimateVertexColors>c__Iterator0.<AnimateVertexColors>c__AnonStorey1 $locvar0;

			// Token: 0x02001095 RID: 4245
			private sealed class <AnimateVertexColors>c__AnonStorey1
			{
				// Token: 0x060069E9 RID: 27113 RVA: 0x001FADCD File Offset: 0x001F91CD
				public <AnimateVertexColors>c__AnonStorey1()
				{
				}

				// Token: 0x060069EA RID: 27114 RVA: 0x001FADD8 File Offset: 0x001F91D8
				internal int <>m__0(int a, int b)
				{
					return this.modifiedCharScale[a].CompareTo(this.modifiedCharScale[b]);
				}

				// Token: 0x0400648A RID: 25738
				internal List<float> modifiedCharScale;

				// Token: 0x0400648B RID: 25739
				internal VertexZoom.<AnimateVertexColors>c__Iterator0 <>f__ref$0;
			}
		}
	}
}
