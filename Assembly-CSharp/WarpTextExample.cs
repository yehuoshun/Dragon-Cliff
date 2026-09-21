using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020001AB RID: 427
public class WarpTextExample : MonoBehaviour
{
	// Token: 0x06000B42 RID: 2882 RVA: 0x00085024 File Offset: 0x00083424
	public WarpTextExample()
	{
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x000850F0 File Offset: 0x000834F0
	private void Awake()
	{
		this.m_TextComponent = base.gameObject.GetComponent<TextMeshProUGUI>();
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x00085103 File Offset: 0x00083503
	private void Start()
	{
		base.StartCoroutine(this.WarpText());
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x00085114 File Offset: 0x00083514
	private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
	{
		return new AnimationCurve
		{
			keys = curve.keys
		};
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x00085134 File Offset: 0x00083534
	private IEnumerator WarpText()
	{
		this.VertexCurve.preWrapMode = WrapMode.Once;
		this.VertexCurve.postWrapMode = WrapMode.Once;
		Mesh mesh = this.m_TextComponent.textInfo.meshInfo[0].mesh;
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
					float boundsMinX = mesh.bounds.min.x;
					float boundsMaxX = mesh.bounds.max.x;
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

	// Token: 0x04000DC8 RID: 3528
	private TextMeshProUGUI m_TextComponent;

	// Token: 0x04000DC9 RID: 3529
	public AnimationCurve VertexCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(0.25f, 2f),
		new Keyframe(0.5f, 0f),
		new Keyframe(0.75f, 2f),
		new Keyframe(1f, 0f)
	});

	// Token: 0x04000DCA RID: 3530
	public float AngleMultiplier = 1f;

	// Token: 0x04000DCB RID: 3531
	public float SpeedMultiplier = 1f;

	// Token: 0x04000DCC RID: 3532
	public float CurveScale = 1f;

	// Token: 0x02000C2B RID: 3115
	[CompilerGenerated]
	private sealed class <WarpText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005228 RID: 21032 RVA: 0x0008514F File Offset: 0x0008354F
		[DebuggerHidden]
		public <WarpText>c__Iterator0()
		{
		}

		// Token: 0x06005229 RID: 21033 RVA: 0x00085158 File Offset: 0x00083558
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.VertexCurve.preWrapMode = WrapMode.Once;
				this.VertexCurve.postWrapMode = WrapMode.Once;
				mesh = this.m_TextComponent.textInfo.meshInfo[0].mesh;
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
					boundsMinX = mesh.bounds.min.x;
					boundsMaxX = mesh.bounds.max.x;
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

		// Token: 0x17001188 RID: 4488
		// (get) Token: 0x0600522A RID: 21034 RVA: 0x00085788 File Offset: 0x00083B88
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001189 RID: 4489
		// (get) Token: 0x0600522B RID: 21035 RVA: 0x00085790 File Offset: 0x00083B90
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600522C RID: 21036 RVA: 0x00085798 File Offset: 0x00083B98
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600522D RID: 21037 RVA: 0x000857A8 File Offset: 0x00083BA8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004025 RID: 16421
		internal Mesh <mesh>__0;

		// Token: 0x04004026 RID: 16422
		internal float <old_CurveScale>__0;

		// Token: 0x04004027 RID: 16423
		internal AnimationCurve <old_curve>__0;

		// Token: 0x04004028 RID: 16424
		internal TMP_TextInfo <textInfo>__1;

		// Token: 0x04004029 RID: 16425
		internal int <characterCount>__1;

		// Token: 0x0400402A RID: 16426
		internal float <boundsMinX>__1;

		// Token: 0x0400402B RID: 16427
		internal float <boundsMaxX>__1;

		// Token: 0x0400402C RID: 16428
		internal Vector3[] <vertices>__2;

		// Token: 0x0400402D RID: 16429
		internal Matrix4x4 <matrix>__2;

		// Token: 0x0400402E RID: 16430
		internal WarpTextExample $this;

		// Token: 0x0400402F RID: 16431
		internal object $current;

		// Token: 0x04004030 RID: 16432
		internal bool $disposing;

		// Token: 0x04004031 RID: 16433
		internal int $PC;
	}
}
