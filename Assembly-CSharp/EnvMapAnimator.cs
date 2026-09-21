using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x02000B5A RID: 2906
public class EnvMapAnimator : MonoBehaviour
{
	// Token: 0x06004D20 RID: 19744 RVA: 0x001F4AA7 File Offset: 0x001F2EA7
	public EnvMapAnimator()
	{
	}

	// Token: 0x06004D21 RID: 19745 RVA: 0x001F4AAF File Offset: 0x001F2EAF
	private void Awake()
	{
		this.m_textMeshPro = base.GetComponent<TMP_Text>();
		this.m_material = this.m_textMeshPro.fontSharedMaterial;
	}

	// Token: 0x06004D22 RID: 19746 RVA: 0x001F4AD0 File Offset: 0x001F2ED0
	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		for (;;)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003B82 RID: 15234
	public Vector3 RotationSpeeds;

	// Token: 0x04003B83 RID: 15235
	private TMP_Text m_textMeshPro;

	// Token: 0x04003B84 RID: 15236
	private Material m_material;

	// Token: 0x02001088 RID: 4232
	[CompilerGenerated]
	private sealed class <Start>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600699B RID: 27035 RVA: 0x001F4AEB File Offset: 0x001F2EEB
		[DebuggerHidden]
		public <Start>c__Iterator0()
		{
		}

		// Token: 0x0600699C RID: 27036 RVA: 0x001F4AF4 File Offset: 0x001F2EF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				matrix = default(Matrix4x4);
				break;
			case 1u:
				break;
			default:
				return false;
			}
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			this.$current = null;
			if (!this.$disposing)
			{
				this.$PC = 1;
			}
			return true;
		}

		// Token: 0x17001607 RID: 5639
		// (get) Token: 0x0600699D RID: 27037 RVA: 0x001F4BD2 File Offset: 0x001F2FD2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001608 RID: 5640
		// (get) Token: 0x0600699E RID: 27038 RVA: 0x001F4BDA File Offset: 0x001F2FDA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600699F RID: 27039 RVA: 0x001F4BE2 File Offset: 0x001F2FE2
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060069A0 RID: 27040 RVA: 0x001F4BF2 File Offset: 0x001F2FF2
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04006413 RID: 25619
		internal Matrix4x4 <matrix>__0;

		// Token: 0x04006414 RID: 25620
		internal EnvMapAnimator $this;

		// Token: 0x04006415 RID: 25621
		internal object $current;

		// Token: 0x04006416 RID: 25622
		internal bool $disposing;

		// Token: 0x04006417 RID: 25623
		internal int $PC;
	}
}
