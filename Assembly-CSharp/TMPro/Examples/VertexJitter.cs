using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B77 RID: 2935
	public class VertexJitter : MonoBehaviour
	{
		// Token: 0x06004D88 RID: 19848 RVA: 0x001F90AD File Offset: 0x001F74AD
		public VertexJitter()
		{
		}

		// Token: 0x06004D89 RID: 19849 RVA: 0x001F90D6 File Offset: 0x001F74D6
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D8A RID: 19850 RVA: 0x001F90E4 File Offset: 0x001F74E4
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D8B RID: 19851 RVA: 0x001F90FC File Offset: 0x001F74FC
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D8C RID: 19852 RVA: 0x001F9114 File Offset: 0x001F7514
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x06004D8D RID: 19853 RVA: 0x001F9123 File Offset: 0x001F7523
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			if (obj == this.m_TextComponent)
			{
				this.hasTextChanged = true;
			}
		}

		// Token: 0x06004D8E RID: 19854 RVA: 0x001F9140 File Offset: 0x001F7540
		private IEnumerator AnimateVertexColors()
		{
			this.m_TextComponent.ForceMeshUpdate();
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			int loopCount = 0;
			this.hasTextChanged = true;
			VertexJitter.VertexAnim[] vertexAnim = new VertexJitter.VertexAnim[1024];
			for (int i = 0; i < 1024; i++)
			{
				vertexAnim[i].angleRange = UnityEngine.Random.Range(10f, 25f);
				vertexAnim[i].speed = UnityEngine.Random.Range(1f, 3f);
			}
			TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
			for (;;)
			{
				if (this.hasTextChanged)
				{
					cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
					this.hasTextChanged = false;
				}
				int characterCount = textInfo.characterCount;
				if (characterCount == 0)
				{
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					for (int j = 0; j < characterCount; j++)
					{
						TMP_CharacterInfo tmp_CharacterInfo = textInfo.characterInfo[j];
						if (tmp_CharacterInfo.isVisible)
						{
							VertexJitter.VertexAnim vertexAnim2 = vertexAnim[j];
							int materialReferenceIndex = textInfo.characterInfo[j].materialReferenceIndex;
							int vertexIndex = textInfo.characterInfo[j].vertexIndex;
							Vector3[] vertices = cachedMeshInfo[materialReferenceIndex].vertices;
							Vector2 v = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
							Vector3 b = v;
							Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
							vertices2[vertexIndex] = vertices[vertexIndex] - b;
							vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - b;
							vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - b;
							vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - b;
							vertexAnim2.angle = Mathf.SmoothStep(-vertexAnim2.angleRange, vertexAnim2.angleRange, Mathf.PingPong((float)loopCount / 25f * vertexAnim2.speed, 1f));
							Vector3 a = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), UnityEngine.Random.Range(-0.25f, 0.25f), 0f);
							Matrix4x4 matrix = Matrix4x4.TRS(a * this.CurveScale, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-5f, 5f) * this.AngleMultiplier), Vector3.one);
							vertices2[vertexIndex] = matrix.MultiplyPoint3x4(vertices2[vertexIndex]);
							vertices2[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 1]);
							vertices2[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 2]);
							vertices2[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 3]);
							vertices2[vertexIndex] += b;
							vertices2[vertexIndex + 1] += b;
							vertices2[vertexIndex + 2] += b;
							vertices2[vertexIndex + 3] += b;
							vertexAnim[j] = vertexAnim2;
						}
					}
					for (int k = 0; k < textInfo.meshInfo.Length; k++)
					{
						textInfo.meshInfo[k].mesh.vertices = textInfo.meshInfo[k].vertices;
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[k].mesh, k);
					}
					loopCount++;
					yield return new WaitForSeconds(0.1f);
				}
			}
			yield break;
		}

		// Token: 0x04003C0B RID: 15371
		public float AngleMultiplier = 1f;

		// Token: 0x04003C0C RID: 15372
		public float SpeedMultiplier = 1f;

		// Token: 0x04003C0D RID: 15373
		public float CurveScale = 1f;

		// Token: 0x04003C0E RID: 15374
		private TMP_Text m_TextComponent;

		// Token: 0x04003C0F RID: 15375
		private bool hasTextChanged;

		// Token: 0x02000B78 RID: 2936
		private struct VertexAnim
		{
			// Token: 0x04003C10 RID: 15376
			public float angleRange;

			// Token: 0x04003C11 RID: 15377
			public float angle;

			// Token: 0x04003C12 RID: 15378
			public float speed;
		}

		// Token: 0x02001091 RID: 4241
		[CompilerGenerated]
		private sealed class <AnimateVertexColors>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069D1 RID: 27089 RVA: 0x001F915B File Offset: 0x001F755B
			[DebuggerHidden]
			public <AnimateVertexColors>c__Iterator0()
			{
			}

			// Token: 0x060069D2 RID: 27090 RVA: 0x001F9164 File Offset: 0x001F7564
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.m_TextComponent.ForceMeshUpdate();
					textInfo = this.m_TextComponent.textInfo;
					loopCount = 0;
					this.hasTextChanged = true;
					vertexAnim = new VertexJitter.VertexAnim[1024];
					for (int i = 0; i < 1024; i++)
					{
						vertexAnim[i].angleRange = UnityEngine.Random.Range(10f, 25f);
						vertexAnim[i].speed = UnityEngine.Random.Range(1f, 3f);
					}
					cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
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
					cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
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
					for (int j = 0; j < characterCount; j++)
					{
						TMP_CharacterInfo tmp_CharacterInfo = textInfo.characterInfo[j];
						if (tmp_CharacterInfo.isVisible)
						{
							VertexJitter.VertexAnim vertexAnim2 = vertexAnim[j];
							int materialReferenceIndex = textInfo.characterInfo[j].materialReferenceIndex;
							int vertexIndex = textInfo.characterInfo[j].vertexIndex;
							Vector3[] vertices = cachedMeshInfo[materialReferenceIndex].vertices;
							Vector2 v = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
							Vector3 b = v;
							Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
							vertices2[vertexIndex] = vertices[vertexIndex] - b;
							vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - b;
							vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - b;
							vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - b;
							vertexAnim2.angle = Mathf.SmoothStep(-vertexAnim2.angleRange, vertexAnim2.angleRange, Mathf.PingPong((float)loopCount / 25f * vertexAnim2.speed, 1f));
							Vector3 a = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), UnityEngine.Random.Range(-0.25f, 0.25f), 0f);
							matrix = Matrix4x4.TRS(a * this.CurveScale, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-5f, 5f) * this.AngleMultiplier), Vector3.one);
							vertices2[vertexIndex] = matrix.MultiplyPoint3x4(vertices2[vertexIndex]);
							vertices2[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 1]);
							vertices2[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 2]);
							vertices2[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices2[vertexIndex + 3]);
							vertices2[vertexIndex] += b;
							vertices2[vertexIndex + 1] += b;
							vertices2[vertexIndex + 2] += b;
							vertices2[vertexIndex + 3] += b;
							vertexAnim[j] = vertexAnim2;
						}
					}
					for (int k = 0; k < textInfo.meshInfo.Length; k++)
					{
						textInfo.meshInfo[k].mesh.vertices = textInfo.meshInfo[k].vertices;
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[k].mesh, k);
					}
					loopCount++;
					this.$current = new WaitForSeconds(0.1f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				return true;
			}

			// Token: 0x17001619 RID: 5657
			// (get) Token: 0x060069D3 RID: 27091 RVA: 0x001F96D8 File Offset: 0x001F7AD8
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700161A RID: 5658
			// (get) Token: 0x060069D4 RID: 27092 RVA: 0x001F96E0 File Offset: 0x001F7AE0
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069D5 RID: 27093 RVA: 0x001F96E8 File Offset: 0x001F7AE8
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069D6 RID: 27094 RVA: 0x001F96F8 File Offset: 0x001F7AF8
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006464 RID: 25700
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x04006465 RID: 25701
			internal int <loopCount>__0;

			// Token: 0x04006466 RID: 25702
			internal VertexJitter.VertexAnim[] <vertexAnim>__0;

			// Token: 0x04006467 RID: 25703
			internal TMP_MeshInfo[] <cachedMeshInfo>__0;

			// Token: 0x04006468 RID: 25704
			internal int <characterCount>__1;

			// Token: 0x04006469 RID: 25705
			internal Matrix4x4 <matrix>__2;

			// Token: 0x0400646A RID: 25706
			internal VertexJitter $this;

			// Token: 0x0400646B RID: 25707
			internal object $current;

			// Token: 0x0400646C RID: 25708
			internal bool $disposing;

			// Token: 0x0400646D RID: 25709
			internal int $PC;
		}
	}
}
