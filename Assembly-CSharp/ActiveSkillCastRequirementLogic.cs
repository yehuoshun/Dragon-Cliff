using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020004E5 RID: 1253
[Serializable]
public class ActiveSkillCastRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002561 RID: 9569 RVA: 0x001107B0 File Offset: 0x0010EBB0
	public ActiveSkillCastRequirementLogic()
	{
	}

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06002562 RID: 9570 RVA: 0x001107B8 File Offset: 0x0010EBB8
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ActiveSkillUseRequirement;
		}
	}

	// Token: 0x06002563 RID: 9571 RVA: 0x001107BC File Offset: 0x0010EBBC
	public override bool Fullfilled(Quest quest)
	{
		return this.FFilled;
	}

	// Token: 0x06002564 RID: 9572 RVA: 0x001107C4 File Offset: 0x0010EBC4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitCompleteActiveSkill
		};
	}

	// Token: 0x06002565 RID: 9573 RVA: 0x001107E0 File Offset: 0x0010EBE0
	public override IEnumerable ProcessAdventureEvent(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitCompleteActiveSkill && evt.EventTriggeringUnit.IsPlayer && !this.FFilled)
		{
			this.CurrentCount++;
			if (this.CurrentCount >= this.NumberOfRequired)
			{
				this.FFilled = true;
			}
		}
		yield break;
	}

	// Token: 0x04002032 RID: 8242
	public bool FFilled;

	// Token: 0x04002033 RID: 8243
	public int NumberOfRequired;

	// Token: 0x04002034 RID: 8244
	public int CurrentCount;

	// Token: 0x02000DB4 RID: 3508
	[CompilerGenerated]
	private sealed class <ProcessAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600588D RID: 22669 RVA: 0x0011080A File Offset: 0x0010EC0A
		[DebuggerHidden]
		public <ProcessAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x0600588E RID: 22670 RVA: 0x00110814 File Offset: 0x0010EC14
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evt.EventType == AdventureEventType.UnitCompleteActiveSkill && evt.EventTriggeringUnit.IsPlayer && !this.FFilled)
				{
					this.CurrentCount++;
					if (this.CurrentCount >= this.NumberOfRequired)
					{
						this.FFilled = true;
					}
				}
			}
			return false;
		}

		// Token: 0x17001286 RID: 4742
		// (get) Token: 0x0600588F RID: 22671 RVA: 0x001108AA File Offset: 0x0010ECAA
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001287 RID: 4743
		// (get) Token: 0x06005890 RID: 22672 RVA: 0x001108B2 File Offset: 0x0010ECB2
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005891 RID: 22673 RVA: 0x001108BA File Offset: 0x0010ECBA
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005892 RID: 22674 RVA: 0x001108BC File Offset: 0x0010ECBC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005893 RID: 22675 RVA: 0x001108C3 File Offset: 0x0010ECC3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005894 RID: 22676 RVA: 0x001108CC File Offset: 0x0010ECCC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ActiveSkillCastRequirementLogic.<ProcessAdventureEvent>c__Iterator0 <ProcessAdventureEvent>c__Iterator = new ActiveSkillCastRequirementLogic.<ProcessAdventureEvent>c__Iterator0();
			<ProcessAdventureEvent>c__Iterator.$this = this;
			<ProcessAdventureEvent>c__Iterator.evt = evt;
			return <ProcessAdventureEvent>c__Iterator;
		}

		// Token: 0x0400486F RID: 18543
		internal BroadcastEvent evt;

		// Token: 0x04004870 RID: 18544
		internal ActiveSkillCastRequirementLogic $this;

		// Token: 0x04004871 RID: 18545
		internal object $current;

		// Token: 0x04004872 RID: 18546
		internal bool $disposing;

		// Token: 0x04004873 RID: 18547
		internal int $PC;
	}
}
