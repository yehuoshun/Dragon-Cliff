using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200012D RID: 301
public class NewEnemyCombatController : EnemyCombatController
{
	// Token: 0x0600087D RID: 2173 RVA: 0x000764E4 File Offset: 0x000748E4
	public NewEnemyCombatController()
	{
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000764F8 File Offset: 0x000748F8
	private void SetAnimationTime()
	{
		Animator component = base.GetComponent<Animator>();
		RuntimeAnimatorController runtimeAnimatorController = component.runtimeAnimatorController;
		for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
		{
			if (runtimeAnimatorController.animationClips[i].name == "Attack")
			{
				this.Attack1AnimationTime = runtimeAnimatorController.animationClips[i].length;
			}
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x0007655C File Offset: 0x0007495C
	public override IEnumerable UnitKilled(object obj)
	{
		base.Animator.Play("death");
		IEnumerator enumerator = base.UnitKilled(obj).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object _ = enumerator.Current;
				yield return _;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00076588 File Offset: 0x00074988
	public override IEnumerable UnitCastsSkill(SkillCastBattleEvent skillEvent, float animationWaitTime = 0.5f)
	{
		if (this.IsStillAttackUnit)
		{
			base.Animator.Play("Attack");
			IEnumerator enumerator = base.PlayCastSkillEffect(skillEvent).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		else
		{
			IEnumerator enumerator2 = base.UnitCastsSkill(skillEvent, this.Attack1AnimationTime).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000765B4 File Offset: 0x000749B4
	public override IEnumerable UnitNormalAttack(IBattleUnit unit, float animationWaitTime = 0.5f)
	{
		if (this.IsStillAttackUnit)
		{
			base.Animator.Play("Attack");
			yield return new WaitForSeconds(this.Attack1AnimationTime);
		}
		else
		{
			if (base.Animator == null)
			{
				UnityEngine.Debug.Log(unit + " does not have Animator!!!");
				yield break;
			}
			IEnumerator enumerator = base.UnitNormalAttack(unit, this.Attack1AnimationTime).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			base.Animator.SetTrigger("idle_1");
		}
		yield break;
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000765DE File Offset: 0x000749DE
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitKilled>__BaseCallProxy0(object obj)
	{
		return base.UnitKilled(obj);
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000765E7 File Offset: 0x000749E7
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitCastsSkill>__BaseCallProxy1(SkillCastBattleEvent skillEvent, float animationWaitTime)
	{
		return base.UnitCastsSkill(skillEvent, animationWaitTime);
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x000765F1 File Offset: 0x000749F1
	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerable <UnitNormalAttack>__BaseCallProxy2(IBattleUnit unit, float animationWaitTime)
	{
		return base.UnitNormalAttack(unit, animationWaitTime);
	}

	// Token: 0x04000B0D RID: 2829
	public float Attack1AnimationTime = 1.5f;

	// Token: 0x04000B0E RID: 2830
	public bool IsStillAttackUnit;

	// Token: 0x02000C0A RID: 3082
	[CompilerGenerated]
	private sealed class <UnitKilled>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051A0 RID: 20896 RVA: 0x000765FB File Offset: 0x000749FB
		[DebuggerHidden]
		public <UnitKilled>c__Iterator0()
		{
		}

		// Token: 0x060051A1 RID: 20897 RVA: 0x00076604 File Offset: 0x00074A04
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				base.Animator.Play("death");
				enumerator = base.<UnitKilled>__BaseCallProxy0(obj).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700116A RID: 4458
		// (get) Token: 0x060051A2 RID: 20898 RVA: 0x00076704 File Offset: 0x00074B04
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700116B RID: 4459
		// (get) Token: 0x060051A3 RID: 20899 RVA: 0x0007670C File Offset: 0x00074B0C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051A4 RID: 20900 RVA: 0x00076714 File Offset: 0x00074B14
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060051A5 RID: 20901 RVA: 0x00076784 File Offset: 0x00074B84
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060051A6 RID: 20902 RVA: 0x0007678B File Offset: 0x00074B8B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060051A7 RID: 20903 RVA: 0x00076794 File Offset: 0x00074B94
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			NewEnemyCombatController.<UnitKilled>c__Iterator0 <UnitKilled>c__Iterator = new NewEnemyCombatController.<UnitKilled>c__Iterator0();
			<UnitKilled>c__Iterator.$this = this;
			<UnitKilled>c__Iterator.obj = obj;
			return <UnitKilled>c__Iterator;
		}

		// Token: 0x04003FB9 RID: 16313
		internal object obj;

		// Token: 0x04003FBA RID: 16314
		internal IEnumerator $locvar0;

		// Token: 0x04003FBB RID: 16315
		internal object <_>__1;

		// Token: 0x04003FBC RID: 16316
		internal IDisposable $locvar1;

		// Token: 0x04003FBD RID: 16317
		internal NewEnemyCombatController $this;

		// Token: 0x04003FBE RID: 16318
		internal object $current;

		// Token: 0x04003FBF RID: 16319
		internal bool $disposing;

		// Token: 0x04003FC0 RID: 16320
		internal int $PC;
	}

	// Token: 0x02000C0B RID: 3083
	[CompilerGenerated]
	private sealed class <UnitCastsSkill>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051A8 RID: 20904 RVA: 0x000767D4 File Offset: 0x00074BD4
		[DebuggerHidden]
		public <UnitCastsSkill>c__Iterator1()
		{
		}

		// Token: 0x060051A9 RID: 20905 RVA: 0x000767DC File Offset: 0x00074BDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!this.IsStillAttackUnit)
				{
					enumerator2 = base.<UnitCastsSkill>__BaseCallProxy1(skillEvent, this.Attack1AnimationTime).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				base.Animator.Play("Attack");
				enumerator = base.PlayCastSkillEffect(skillEvent).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_11C;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			goto IL_19E;
			Block_4:
			try
			{
				IL_11C:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_19E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700116C RID: 4460
		// (get) Token: 0x060051AA RID: 20906 RVA: 0x000769B0 File Offset: 0x00074DB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700116D RID: 4461
		// (get) Token: 0x060051AB RID: 20907 RVA: 0x000769B8 File Offset: 0x00074DB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051AC RID: 20908 RVA: 0x000769C0 File Offset: 0x00074DC0
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060051AD RID: 20909 RVA: 0x00076A70 File Offset: 0x00074E70
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060051AE RID: 20910 RVA: 0x00076A77 File Offset: 0x00074E77
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060051AF RID: 20911 RVA: 0x00076A80 File Offset: 0x00074E80
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			NewEnemyCombatController.<UnitCastsSkill>c__Iterator1 <UnitCastsSkill>c__Iterator = new NewEnemyCombatController.<UnitCastsSkill>c__Iterator1();
			<UnitCastsSkill>c__Iterator.$this = this;
			<UnitCastsSkill>c__Iterator.skillEvent = skillEvent;
			return <UnitCastsSkill>c__Iterator;
		}

		// Token: 0x04003FC1 RID: 16321
		internal SkillCastBattleEvent skillEvent;

		// Token: 0x04003FC2 RID: 16322
		internal IEnumerator $locvar0;

		// Token: 0x04003FC3 RID: 16323
		internal object <_>__1;

		// Token: 0x04003FC4 RID: 16324
		internal IDisposable $locvar1;

		// Token: 0x04003FC5 RID: 16325
		internal IEnumerator $locvar2;

		// Token: 0x04003FC6 RID: 16326
		internal object <_>__2;

		// Token: 0x04003FC7 RID: 16327
		internal IDisposable $locvar3;

		// Token: 0x04003FC8 RID: 16328
		internal NewEnemyCombatController $this;

		// Token: 0x04003FC9 RID: 16329
		internal object $current;

		// Token: 0x04003FCA RID: 16330
		internal bool $disposing;

		// Token: 0x04003FCB RID: 16331
		internal int $PC;
	}

	// Token: 0x02000C0C RID: 3084
	[CompilerGenerated]
	private sealed class <UnitNormalAttack>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051B0 RID: 20912 RVA: 0x00076AC0 File Offset: 0x00074EC0
		[DebuggerHidden]
		public <UnitNormalAttack>c__Iterator2()
		{
		}

		// Token: 0x060051B1 RID: 20913 RVA: 0x00076AC8 File Offset: 0x00074EC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (this.IsStillAttackUnit)
				{
					base.Animator.Play("Attack");
					this.$current = new WaitForSeconds(this.Attack1AnimationTime);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				if (base.Animator == null)
				{
					UnityEngine.Debug.Log(unit + " does not have Animator!!!");
					return false;
				}
				enumerator = base.<UnitNormalAttack>__BaseCallProxy2(unit, this.Attack1AnimationTime).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				goto IL_16C;
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			base.Animator.SetTrigger("idle_1");
			IL_16C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700116E RID: 4462
		// (get) Token: 0x060051B2 RID: 20914 RVA: 0x00076C5C File Offset: 0x0007505C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700116F RID: 4463
		// (get) Token: 0x060051B3 RID: 20915 RVA: 0x00076C64 File Offset: 0x00075064
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051B4 RID: 20916 RVA: 0x00076C6C File Offset: 0x0007506C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060051B5 RID: 20917 RVA: 0x00076CE0 File Offset: 0x000750E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060051B6 RID: 20918 RVA: 0x00076CE7 File Offset: 0x000750E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060051B7 RID: 20919 RVA: 0x00076CF0 File Offset: 0x000750F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			NewEnemyCombatController.<UnitNormalAttack>c__Iterator2 <UnitNormalAttack>c__Iterator = new NewEnemyCombatController.<UnitNormalAttack>c__Iterator2();
			<UnitNormalAttack>c__Iterator.$this = this;
			<UnitNormalAttack>c__Iterator.unit = unit;
			return <UnitNormalAttack>c__Iterator;
		}

		// Token: 0x04003FCC RID: 16332
		internal IBattleUnit unit;

		// Token: 0x04003FCD RID: 16333
		internal IEnumerator $locvar0;

		// Token: 0x04003FCE RID: 16334
		internal object <_>__1;

		// Token: 0x04003FCF RID: 16335
		internal IDisposable $locvar1;

		// Token: 0x04003FD0 RID: 16336
		internal NewEnemyCombatController $this;

		// Token: 0x04003FD1 RID: 16337
		internal object $current;

		// Token: 0x04003FD2 RID: 16338
		internal bool $disposing;

		// Token: 0x04003FD3 RID: 16339
		internal int $PC;
	}
}
