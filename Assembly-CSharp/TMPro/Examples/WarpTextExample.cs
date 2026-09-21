using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B7C RID: 2940
	public class WarpTextExample : MonoBehaviour
	{
		// Token: 0x06004DA4 RID: 19876 RVA: 0x001FAE08 File Offset: 0x001F9208
		public WarpTextExample()
		{
		}

		// Token: 0x06004DA5 RID: 19877 RVA: 0x001FAED4 File Offset: 0x001F92D4
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
		}

		// Token: 0x06004DA6 RID: 19878 RVA: 0x001FAEE7 File Offset: 0x001F92E7
		private void Start()
		{
			base.StartCoroutine(this.WarpText());
		}

		// Token: 0x06004DA7 RID: 19879 RVA: 0x001FAEF8 File Offset: 0x001F92F8
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
		{
			return new AnimationCurve
			{
				keys = curve.keys
			};
		}

		// Token: 0x06004DA8 RID: 19880 RVA: 0x001FAF18 File Offset: 0x001F9318
		private IEnumerator WarpText()
		{
			this.VertexCurve.preWrapMode = WrapMode.Once;
			this.VertexCurve.postWrapMode = WrapMode.Once;
			this.m_TextComponent.havePropertiesChanged = true;
			this.CurveScale *= 10f;
			float old_CurveScale = this.CurveScale;
			AnimationCurve old_curve = this.CopyAnimationCurve(this.VertexCurve);
			for (;;)
			{
				if (!this.m_TextComponent.havePropertiesChanged && old_CurveScale == this.CurveScale && old_curve.keys[1].value == this.VertexCurve.keys[1].value)
				{
					yield return null;
				}
				else
				{
					old_CurveScale = this.CurveScale;
					old_curve = this.CopyAnimationCurve(this.VertexCurve);
					this.m_TextComponent.ForceMeshUpdate();
					TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
					int characterCount = textInfo.characterCount;
					if (characterCount != 0)
					{
						float boundsMinX = this.m_TextComponent.bounds.min.x;
						float boundsMaxX = this.m_TextComponent.bounds.max.x;
						for (int i = 0; i < characterCount; i++)
						{
							if (textInfo.characterInfo[i].isVisible)
							{
								int vertexIndex = textInfo.characterInfo[i].vertexIndex;
								int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 vector = new Vector2((vertices[vertexIndex].x + vertices[vertexIndex + 2].x) / 2f, textInfo.characterInfo[i].baseLine);
								vertices[vertexIndex] += -vector;
								vertices[vertexIndex + 1] += -vector;
								vertices[vertexIndex + 2] += -vector;
								vertices[vertexIndex + 3] += -vector;
								float num = (vector.x - boundsMinX) / (boundsMaxX - boundsMinX);
								float num2 = num + 0.0001f;
								float y = this.VertexCurve.Evaluate(num) * this.CurveScale;
								float y2 = this.VertexCurve.Evaluate(num2) * this.CurveScale;
								Vector3 lhs = new Vector3(1f, 0f, 0f);
								Vector3 rhs = new Vector3(num2 * (boundsMaxX - boundsMinX) + boundsMinX, y2) - new Vector3(vector.x, y);
								float num3 = Mathf.Acos(Vector3.Dot(lhs, rhs.normalized)) * 57.29578f;
								float z = (Vector3.Cross(lhs, rhs).z <= 0f) ? (360f - num3) : num3;
								Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0f, y, 0f), Quaternion.Euler(0f, 0f, z), Vector3.one);
								vertices[vertexIndex] = matrix.MultiplyPoint3x4(vertices[vertexIndex]);
								vertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
								vertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
								vertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
								vertices[vertexIndex] += vector;
								vertices[vertexIndex + 1] += vector;
								vertices[vertexIndex + 2] += vector;
								vertices[vertexIndex + 3] += vector;
							}
						}
						this.m_TextComponent.UpdateVertexData();
						yield return new WaitForSeconds(0.025f);
					}
				}
			}
			yield break;
		}

		// Token: 0x04003C23 RID: 15395
		private TMP_Text m_TextComponent;

		// Token: 0x04003C24 RID: 15396
		public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, 2f),
			new Keyframe(0.5f, 0f),
			new Keyframe(0.75f, 2f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04003C25 RID: 15397
		public float AngleMultiplier = 1f;

		// Token: 0x04003C26 RID: 15398
		public float SpeedMultiplier = 1f;

		// Token: 0x04003C27 RID: 15399
		public float CurveScale = 1f;

		// Token: 0x02001096 RID: 4246
		[CompilerGenerated]
		private sealed class <WarpText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069EB RID: 27115 RVA: 0x001FAF33 File Offset: 0x001F9333
			[DebuggerHidden]
			public <WarpText>c__Iterator0()
			{
			}

			// Token: 0x060069EC RID: 27116 RVA: 0x001FAF3C File Offset: 0x001F933C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.VertexCurve.preWrapMode = WrapMode.Once;
					this.VertexCurve.postWrapMode = WrapMode.Once;
					this.m_TextComponent.havePropertiesChanged = true;
					this.CurveScale *= 10f;
					old_CurveScale = this.CurveScale;
					old_curve = base.CopyAnimationCurve(this.VertexCurve);
					break;
				case 1u:
					break;
				case 2u:
					break;
				default:
					return false;
				}
				while (this.m_TextComponent.havePropertiesChanged || old_CurveScale != this.CurveScale || old_curve.keys[1].value != this.VertexCurve.keys[1].value)
				{
					old_CurveScale = this.CurveScale;
					old_curve = base.CopyAnimationCurve(this.VertexCurve);
					this.m_TextComponent.ForceMeshUpdate();
					textInfo = this.m_TextComponent.textInfo;
					characterCount = textInfo.characterCount;
					if (characterCount != 0)
					{
						boundsMinX = this.m_TextComponent.bounds.min.x;
						boundsMaxX = this.m_TextComponent.bounds.max.x;
						for (int i = 0; i < characterCount; i++)
						{
							if (textInfo.characterInfo[i].isVisible)
							{
								int vertexIndex = textInfo.characterInfo[i].vertexIndex;
								int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
								vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 vector = new Vector2((vertices[vertexIndex].x + vertices[vertexIndex + 2].x) / 2f, textInfo.characterInfo[i].baseLine);
								vertices[vertexIndex] += -vector;
								vertices[vertexIndex + 1] += -vector;
								vertices[vertexIndex + 2] += -vector;
								vertices[vertexIndex + 3] += -vector;
								float num2 = (vector.x - boundsMinX) / (boundsMaxX - boundsMinX);
								float num3 = num2 + 0.0001f;
								float y = this.VertexCurve.Evaluate(num2) * this.CurveScale;
								float y2 = this.VertexCurve.Evaluate(num3) * this.CurveScale;
								Vector3 lhs = new Vector3(1f, 0f, 0f);
								Vector3 rhs = new Vector3(num3 * (boundsMaxX - boundsMinX) + boundsMinX, y2) - new Vector3(vector.x, y);
								float num4 = Mathf.Acos(Vector3.Dot(lhs, rhs.normalized)) * 57.29578f;
								float z = (Vector3.Cross(lhs, rhs).z <= 0f) ? (360f - num4) : num4;
								matrix = Matrix4x4.TRS(new Vector3(0f, y, 0f), Quaternion.Euler(0f, 0f, z), Vector3.one);
								vertices[vertexIndex] = matrix.MultiplyPoint3x4(vertices[vertexIndex]);
								vertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
								vertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
								vertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
								vertices[vertexIndex] += vector;
								vertices[vertexIndex + 1] += vector;
								vertices[vertexIndex + 2] += vector;
								vertices[vertexIndex + 3] += vector;
							}
						}
						this.m_TextComponent.UpdateVertexData();
						this.$current = new WaitForSeconds(0.025f);
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						return true;
					}
				}
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x17001621 RID: 5665
			// (get) Token: 0x060069ED RID: 27117 RVA: 0x001FB550 File Offset: 0x001F9950
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001622 RID: 5666
			// (get) Token: 0x060069EE RID: 27118 RVA: 0x001FB558 File Offset: 0x001F9958
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069EF RID: 27119 RVA: 0x001FB560 File Offset: 0x001F9960
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069F0 RID: 27120 RVA: 0x001FB570 File Offset: 0x001F9970
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400648C RID: 25740
			internal float <old_CurveScale>__0;

			// Token: 0x0400648D RID: 25741
			internal AnimationCurve <old_curve>__0;

			// Token: 0x0400648E RID: 25742
			internal TMP_TextInfo <textInfo>__1;

			// Token: 0x0400648F RID: 25743
			internal int <characterCount>__1;

			// Token: 0x04006490 RID: 25744
			internal float <boundsMinX>__1;

			// Token: 0x04006491 RID: 25745
			internal float <boundsMaxX>__1;

			// Token: 0x04006492 RID: 25746
			internal Vector3[] <vertices>__2;

			// Token: 0x04006493 RID: 25747
			internal Matrix4x4 <matrix>__2;

			// Token: 0x04006494 RID: 25748
			internal WarpTextExample $this;

			// Token: 0x04006495 RID: 25749
			internal object $current;

			// Token: 0x04006496 RID: 25750
			internal bool $disposing;

			// Token: 0x04006497 RID: 25751
			internal int $PC;
		}
	}
}
