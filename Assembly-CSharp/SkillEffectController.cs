using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000111 RID: 273
public class SkillEffectController : MonoBehaviour
{
	// Token: 0x06000779 RID: 1913 RVA: 0x000712C6 File Offset: 0x0006F6C6
	public SkillEffectController()
	{
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x0600077A RID: 1914 RVA: 0x000712D9 File Offset: 0x0006F6D9
	// (set) Token: 0x0600077B RID: 1915 RVA: 0x000712E1 File Offset: 0x0006F6E1
	public BattleEffectBase BattleEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleEffect>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BattleEffect>k__BackingField = value;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x0600077C RID: 1916 RVA: 0x000712EA File Offset: 0x0006F6EA
	// (set) Token: 0x0600077D RID: 1917 RVA: 0x000712F2 File Offset: 0x0006F6F2
	public ParticleSystemRenderer[] ParticleRenderer
	{
		[CompilerGenerated]
		get
		{
			return this.<ParticleRenderer>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<ParticleRenderer>k__BackingField = value;
		}
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x000712FB File Offset: 0x0006F6FB
	public virtual void Start()
	{
		this.ParticleRenderer = base.GetComponentsInChildren<ParticleSystemRenderer>();
		if (Math.Abs(this.DestroyBy) > 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject, this.DestroyBy);
		}
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x00071330 File Offset: 0x0006F730
	public virtual IEnumerable Cast(Transform spawnPoint, Transform sourceUnit = null)
	{
		base.transform.SetParent(spawnPoint, false);
		if (this.AudioClip != null)
		{
			this.PlaySoundClipInBattle(this.AudioClip);
		}
		yield return new WaitForSeconds(this.SkillDuration);
		yield break;
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x0007135A File Offset: 0x0006F75A
	public void SetBattleEffect(BattleEffectBase battleEffect)
	{
		this.BattleEffect = battleEffect;
	}

	// Token: 0x04000A50 RID: 2640
	public float SkillDuration;

	// Token: 0x04000A51 RID: 2641
	[Tooltip("Destroy after seconds. (If it is 0, it will never be destroyed)")]
	public float DestroyBy = 5f;

	// Token: 0x04000A52 RID: 2642
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleEffectBase <BattleEffect>k__BackingField;

	// Token: 0x04000A53 RID: 2643
	public AudioClip AudioClip;

	// Token: 0x04000A54 RID: 2644
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ParticleSystemRenderer[] <ParticleRenderer>k__BackingField;

	// Token: 0x02000BDD RID: 3037
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005086 RID: 20614 RVA: 0x00071363 File Offset: 0x0006F763
		[DebuggerHidden]
		public <Cast>c__Iterator0()
		{
		}

		// Token: 0x06005087 RID: 20615 RVA: 0x0007136C File Offset: 0x0006F76C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				base.transform.SetParent(spawnPoint, false);
				if (this.AudioClip != null)
				{
					this.PlaySoundClipInBattle(this.AudioClip);
				}
				this.$current = new WaitForSeconds(this.SkillDuration);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001124 RID: 4388
		// (get) Token: 0x06005088 RID: 20616 RVA: 0x00071411 File Offset: 0x0006F811
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001125 RID: 4389
		// (get) Token: 0x06005089 RID: 20617 RVA: 0x00071419 File Offset: 0x0006F819
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600508A RID: 20618 RVA: 0x00071421 File Offset: 0x0006F821
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600508B RID: 20619 RVA: 0x00071431 File Offset: 0x0006F831
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600508C RID: 20620 RVA: 0x00071438 File Offset: 0x0006F838
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600508D RID: 20621 RVA: 0x00071440 File Offset: 0x0006F840
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SkillEffectController.<Cast>c__Iterator0 <Cast>c__Iterator = new SkillEffectController.<Cast>c__Iterator0();
			<Cast>c__Iterator.$this = this;
			<Cast>c__Iterator.spawnPoint = spawnPoint;
			return <Cast>c__Iterator;
		}

		// Token: 0x04003E72 RID: 15986
		internal Transform spawnPoint;

		// Token: 0x04003E73 RID: 15987
		internal SkillEffectController $this;

		// Token: 0x04003E74 RID: 15988
		internal object $current;

		// Token: 0x04003E75 RID: 15989
		internal bool $disposing;

		// Token: 0x04003E76 RID: 15990
		internal int $PC;
	}
}
