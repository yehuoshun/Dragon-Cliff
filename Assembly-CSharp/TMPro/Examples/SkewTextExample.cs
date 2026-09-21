using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B5F RID: 2911
	public class SkewTextExample : MonoBehaviour
	{
		// Token: 0x06004D2D RID: 19757 RVA: 0x001F4FA0 File Offset: 0x001F33A0
		public SkewTextExample()
		{
		}

		// Token: 0x06004D2E RID: 19758 RVA: 0x001F5061 File Offset: 0x001F3461
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D2F RID: 19759 RVA: 0x001F5074 File Offset: 0x001F3474
		private void Start()
		{
			base.StartCoroutine(this.WarpText());
		}

		// Token: 0x06004D30 RID: 19760 RVA: 0x001F5084 File Offset: 0x001F3484
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
		{
			return new AnimationCurve
			{
				keys = curve.keys
			};
		}

		// Token: 0x06004D31 RID: 19761 RVA: 0x001F50A4 File Offset: 0x001F34A4
		private IEnumerator WarpText()
		{
			this.VertexCurve.preWrapMode = WrapMode.Once;
			this.VertexCurve.postWrapMode = WrapMode.Once;
			this.m_TextComponent.havePropertiesChanged = true;
			this.CurveScale *= 10f;
			float old_CurveScale = this.CurveScale;
			float old_ShearValue = this.ShearAmount;
			AnimationCurve old_curve = this.CopyAnimationCurve(this.VertexCurve);
			for (;;)
			{
				if (!this.m_TextComponent.havePropertiesChanged && old_CurveScale == this.CurveScale && old_curve.keys[1].value == this.VertexCurve.keys[1].value && old_ShearValue == this.ShearAmount)
				{
					yield return null;
				}
				else
				{
					old_CurveScale = this.CurveScale;
					old_curve = this.CopyAnimationCurve(this.VertexCurve);
					old_ShearValue = this.ShearAmount;
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
								float num = this.ShearAmount * 0.01f;
								Vector3 b = new Vector3(num * (textInfo.characterInfo[i].topRight.y - textInfo.characterInfo[i].baseLine), 0f, 0f);
								Vector3 a = new Vector3(num * (textInfo.characterInfo[i].baseLine - textInfo.characterInfo[i].bottomRight.y), 0f, 0f);
								vertices[vertexIndex] += -a;
								vertices[vertexIndex + 1] += b;
								vertices[vertexIndex + 2] += b;
								vertices[vertexIndex + 3] += -a;
								float num2 = (vector.x - boundsMinX) / (boundsMaxX - boundsMinX);
								float num3 = num2 + 0.0001f;
								float y = this.VertexCurve.Evaluate(num2) * this.CurveScale;
								float y2 = this.VertexCurve.Evaluate(num3) * this.CurveScale;
								Vector3 lhs = new Vector3(1f, 0f, 0f);
								Vector3 rhs = new Vector3(num3 * (boundsMaxX - boundsMinX) + boundsMinX, y2) - new Vector3(vector.x, y);
								float num4 = Mathf.Acos(Vector3.Dot(lhs, rhs.normalized)) * 57.29578f;
								float z = (Vector3.Cross(lhs, rhs).z <= 0f) ? (360f - num4) : num4;
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
						yield return null;
					}
				}
			}
			yield break;
		}

		// Token: 0x04003B9A RID: 15258
		private TMP_Text m_TextComponent;

		// Token: 0x04003B9B RID: 15259
		public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, 2f),
			new Keyframe(0.5f, 0f),
			new Keyframe(0.75f, 2f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04003B9C RID: 15260
		public float CurveScale = 1f;

		// Token: 0x04003B9D RID: 15261
		public float ShearAmount = 1f;

		// Token: 0x0200108A RID: 4234
		[CompilerGenerated]
		private sealed class <WarpText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069A7 RID: 27047 RVA: 0x001F50BF File Offset: 0x001F34BF
			[DebuggerHidden]
			public <WarpText>c__Iterator0()
			{
			}

			// Token: 0x060069A8 RID: 27048 RVA: 0x001F50C8 File Offset: 0x001F34C8
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
					old_ShearValue = this.ShearAmount;
					old_curve = base.CopyAnimationCurve(this.VertexCurve);
					break;
				case 1u:
					break;
				case 2u:
					break;
				default:
					return false;
				}
				while (this.m_TextComponent.havePropertiesChanged || old_CurveScale != this.CurveScale || old_curve.keys[1].value != this.VertexCurve.keys[1].value || old_ShearValue != this.ShearAmount)
				{
					old_CurveScale = this.CurveScale;
					old_curve = base.CopyAnimationCurve(this.VertexCurve);
					old_ShearValue = this.ShearAmount;
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
								float num2 = this.ShearAmount * 0.01f;
								Vector3 b = new Vector3(num2 * (textInfo.characterInfo[i].topRight.y - textInfo.characterInfo[i].baseLine), 0f, 0f);
								Vector3 a = new Vector3(num2 * (textInfo.characterInfo[i].baseLine - textInfo.characterInfo[i].bottomRight.y), 0f, 0f);
								vertices[vertexIndex] += -a;
								vertices[vertexIndex + 1] += b;
								vertices[vertexIndex + 2] += b;
								vertices[vertexIndex + 3] += -a;
								float num3 = (vector.x - boundsMinX) / (boundsMaxX - boundsMinX);
								float num4 = num3 + 0.0001f;
								float y = this.VertexCurve.Evaluate(num3) * this.CurveScale;
								float y2 = this.VertexCurve.Evaluate(num4) * this.CurveScale;
								Vector3 lhs = new Vector3(1f, 0f, 0f);
								Vector3 rhs = new Vector3(num4 * (boundsMaxX - boundsMinX) + boundsMinX, y2) - new Vector3(vector.x, y);
								float num5 = Mathf.Acos(Vector3.Dot(lhs, rhs.normalized)) * 57.29578f;
								float z = (Vector3.Cross(lhs, rhs).z <= 0f) ? (360f - num5) : num5;
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
						this.$current = null;
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

			// Token: 0x1700160B RID: 5643
			// (get) Token: 0x060069A9 RID: 27049 RVA: 0x001F583A File Offset: 0x001F3C3A
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700160C RID: 5644
			// (get) Token: 0x060069AA RID: 27050 RVA: 0x001F5842 File Offset: 0x001F3C42
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069AB RID: 27051 RVA: 0x001F584A File Offset: 0x001F3C4A
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069AC RID: 27052 RVA: 0x001F585A File Offset: 0x001F3C5A
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400641D RID: 25629
			internal float <old_CurveScale>__0;

			// Token: 0x0400641E RID: 25630
			internal float <old_ShearValue>__0;

			// Token: 0x0400641F RID: 25631
			internal AnimationCurve <old_curve>__0;

			// Token: 0x04006420 RID: 25632
			internal TMP_TextInfo <textInfo>__1;

			// Token: 0x04006421 RID: 25633
			internal int <characterCount>__1;

			// Token: 0x04006422 RID: 25634
			internal float <boundsMinX>__1;

			// Token: 0x04006423 RID: 25635
			internal float <boundsMaxX>__1;

			// Token: 0x04006424 RID: 25636
			internal Vector3[] <vertices>__2;

			// Token: 0x04006425 RID: 25637
			internal Matrix4x4 <matrix>__2;

			// Token: 0x04006426 RID: 25638
			internal SkewTextExample $this;

			// Token: 0x04006427 RID: 25639
			internal object $current;

			// Token: 0x04006428 RID: 25640
			internal bool $disposing;

			// Token: 0x04006429 RID: 25641
			internal int $PC;
		}
	}
}
