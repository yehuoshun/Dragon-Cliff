using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000108 RID: 264
public class EffectsDisplayManager : MonoBehaviour
{
	// Token: 0x06000759 RID: 1881 RVA: 0x00070E9A File Offset: 0x0006F29A
	public EffectsDisplayManager()
	{
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00070EA2 File Offset: 0x0006F2A2
	private void Start()
	{
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00070EA4 File Offset: 0x0006F2A4
	public IEnumerable DisplayDamageEffect(BattleDamage Damage)
	{
		yield break;
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00070EC0 File Offset: 0x0006F2C0
	public IEnumerable DisplayHealEffect(BattleHeal Heal)
	{
		yield break;
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00070EDC File Offset: 0x0006F2DC
	public IEnumerable SetSkillEventToDisplay(SkillCastBattleEvent SkillCastEvent)
	{
		if (SkillCastEvent.SkillLogic is ActiveSkillLogicBase)
		{
			yield return this.CastedActiveSkill(SkillCastEvent);
		}
		yield break;
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00070F08 File Offset: 0x0006F308
	public IEnumerable CastedActiveSkill(SkillCastBattleEvent ActiveSkillEvent)
	{
		ActiveSkillLogicBase activeSkillLogicBase = (ActiveSkillLogicBase)ActiveSkillEvent.SkillLogic;
		ActiveSkillTargetingStrategyBase activeSkillTargetingStrategyBase = activeSkillLogicBase.InitiatingTargetingStrategy(ActiveSkillEvent.Skill);
		List<IBattleUnit> selections = activeSkillTargetingStrategyBase.Selections;
		yield break;
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00070F2C File Offset: 0x0006F32C
	public IEnumerable Cast()
	{
		yield break;
	}

	// Token: 0x04000A35 RID: 2613
	public static EffectsDisplayManager instance;

	// Token: 0x02000BD8 RID: 3032
	[CompilerGenerated]
	private sealed class <DisplayDamageEffect>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600505E RID: 20574 RVA: 0x00070F48 File Offset: 0x0006F348
		[DebuggerHidden]
		public <DisplayDamageEffect>c__Iterator0()
		{
		}

		// Token: 0x0600505F RID: 20575 RVA: 0x00070F50 File Offset: 0x0006F350
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700111A RID: 4378
		// (get) Token: 0x06005060 RID: 20576 RVA: 0x00070F6A File Offset: 0x0006F36A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700111B RID: 4379
		// (get) Token: 0x06005061 RID: 20577 RVA: 0x00070F72 File Offset: 0x0006F372
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005062 RID: 20578 RVA: 0x00070F7A File Offset: 0x0006F37A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005063 RID: 20579 RVA: 0x00070F7C File Offset: 0x0006F37C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005064 RID: 20580 RVA: 0x00070F83 File Offset: 0x0006F383
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005065 RID: 20581 RVA: 0x00070F8B File Offset: 0x0006F38B
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new EffectsDisplayManager.<DisplayDamageEffect>c__Iterator0();
		}

		// Token: 0x04003E60 RID: 15968
		internal object $current;

		// Token: 0x04003E61 RID: 15969
		internal bool $disposing;

		// Token: 0x04003E62 RID: 15970
		internal int $PC;
	}

	// Token: 0x02000BD9 RID: 3033
	[CompilerGenerated]
	private sealed class <DisplayHealEffect>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005066 RID: 20582 RVA: 0x00070FA6 File Offset: 0x0006F3A6
		[DebuggerHidden]
		public <DisplayHealEffect>c__Iterator1()
		{
		}

		// Token: 0x06005067 RID: 20583 RVA: 0x00070FAE File Offset: 0x0006F3AE
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700111C RID: 4380
		// (get) Token: 0x06005068 RID: 20584 RVA: 0x00070FC8 File Offset: 0x0006F3C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700111D RID: 4381
		// (get) Token: 0x06005069 RID: 20585 RVA: 0x00070FD0 File Offset: 0x0006F3D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x00070FD8 File Offset: 0x0006F3D8
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600506B RID: 20587 RVA: 0x00070FDA File Offset: 0x0006F3DA
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600506C RID: 20588 RVA: 0x00070FE1 File Offset: 0x0006F3E1
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600506D RID: 20589 RVA: 0x00070FE9 File Offset: 0x0006F3E9
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new EffectsDisplayManager.<DisplayHealEffect>c__Iterator1();
		}

		// Token: 0x04003E63 RID: 15971
		internal object $current;

		// Token: 0x04003E64 RID: 15972
		internal bool $disposing;

		// Token: 0x04003E65 RID: 15973
		internal int $PC;
	}

	// Token: 0x02000BDA RID: 3034
	[CompilerGenerated]
	private sealed class <SetSkillEventToDisplay>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600506E RID: 20590 RVA: 0x00071004 File Offset: 0x0006F404
		[DebuggerHidden]
		public <SetSkillEventToDisplay>c__Iterator2()
		{
		}

		// Token: 0x0600506F RID: 20591 RVA: 0x0007100C File Offset: 0x0006F40C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				if (SkillCastEvent.SkillLogic is ActiveSkillLogicBase)
				{
					this.$current = base.CastedActiveSkill(SkillCastEvent);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			default:
				return false;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700111E RID: 4382
		// (get) Token: 0x06005070 RID: 20592 RVA: 0x00071084 File Offset: 0x0006F484
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700111F RID: 4383
		// (get) Token: 0x06005071 RID: 20593 RVA: 0x0007108C File Offset: 0x0006F48C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005072 RID: 20594 RVA: 0x00071094 File Offset: 0x0006F494
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005073 RID: 20595 RVA: 0x000710A4 File Offset: 0x0006F4A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005074 RID: 20596 RVA: 0x000710AB File Offset: 0x0006F4AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005075 RID: 20597 RVA: 0x000710B4 File Offset: 0x0006F4B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EffectsDisplayManager.<SetSkillEventToDisplay>c__Iterator2 <SetSkillEventToDisplay>c__Iterator = new EffectsDisplayManager.<SetSkillEventToDisplay>c__Iterator2();
			<SetSkillEventToDisplay>c__Iterator.$this = this;
			<SetSkillEventToDisplay>c__Iterator.SkillCastEvent = SkillCastEvent;
			return <SetSkillEventToDisplay>c__Iterator;
		}

		// Token: 0x04003E66 RID: 15974
		internal SkillCastBattleEvent SkillCastEvent;

		// Token: 0x04003E67 RID: 15975
		internal EffectsDisplayManager $this;

		// Token: 0x04003E68 RID: 15976
		internal object $current;

		// Token: 0x04003E69 RID: 15977
		internal bool $disposing;

		// Token: 0x04003E6A RID: 15978
		internal int $PC;
	}

	// Token: 0x02000BDB RID: 3035
	[CompilerGenerated]
	private sealed class <CastedActiveSkill>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005076 RID: 20598 RVA: 0x000710F4 File Offset: 0x0006F4F4
		[DebuggerHidden]
		public <CastedActiveSkill>c__Iterator3()
		{
		}

		// Token: 0x06005077 RID: 20599 RVA: 0x000710FC File Offset: 0x0006F4FC
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				ActiveSkillLogicBase activeSkillLogicBase = (ActiveSkillLogicBase)ActiveSkillEvent.SkillLogic;
				ActiveSkillTargetingStrategyBase activeSkillTargetingStrategyBase = activeSkillLogicBase.InitiatingTargetingStrategy(ActiveSkillEvent.Skill);
				List<IBattleUnit> selections = activeSkillTargetingStrategyBase.Selections;
			}
			return false;
		}

		// Token: 0x17001120 RID: 4384
		// (get) Token: 0x06005078 RID: 20600 RVA: 0x0007114B File Offset: 0x0006F54B
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001121 RID: 4385
		// (get) Token: 0x06005079 RID: 20601 RVA: 0x00071153 File Offset: 0x0006F553
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600507A RID: 20602 RVA: 0x0007115B File Offset: 0x0006F55B
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600507B RID: 20603 RVA: 0x0007115D File Offset: 0x0006F55D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600507C RID: 20604 RVA: 0x00071164 File Offset: 0x0006F564
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600507D RID: 20605 RVA: 0x0007116C File Offset: 0x0006F56C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EffectsDisplayManager.<CastedActiveSkill>c__Iterator3 <CastedActiveSkill>c__Iterator = new EffectsDisplayManager.<CastedActiveSkill>c__Iterator3();
			<CastedActiveSkill>c__Iterator.ActiveSkillEvent = ActiveSkillEvent;
			return <CastedActiveSkill>c__Iterator;
		}

		// Token: 0x04003E6B RID: 15979
		internal SkillCastBattleEvent ActiveSkillEvent;

		// Token: 0x04003E6C RID: 15980
		internal object $current;

		// Token: 0x04003E6D RID: 15981
		internal bool $disposing;

		// Token: 0x04003E6E RID: 15982
		internal int $PC;
	}

	// Token: 0x02000BDC RID: 3036
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600507E RID: 20606 RVA: 0x000711A0 File Offset: 0x0006F5A0
		[DebuggerHidden]
		public <Cast>c__Iterator4()
		{
		}

		// Token: 0x0600507F RID: 20607 RVA: 0x000711A8 File Offset: 0x0006F5A8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001122 RID: 4386
		// (get) Token: 0x06005080 RID: 20608 RVA: 0x000711C2 File Offset: 0x0006F5C2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001123 RID: 4387
		// (get) Token: 0x06005081 RID: 20609 RVA: 0x000711CA File Offset: 0x0006F5CA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005082 RID: 20610 RVA: 0x000711D2 File Offset: 0x0006F5D2
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005083 RID: 20611 RVA: 0x000711D4 File Offset: 0x0006F5D4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005084 RID: 20612 RVA: 0x000711DB File Offset: 0x0006F5DB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005085 RID: 20613 RVA: 0x000711E3 File Offset: 0x0006F5E3
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new EffectsDisplayManager.<Cast>c__Iterator4();
		}

		// Token: 0x04003E6F RID: 15983
		internal object $current;

		// Token: 0x04003E70 RID: 15984
		internal bool $disposing;

		// Token: 0x04003E71 RID: 15985
		internal int $PC;
	}
}
