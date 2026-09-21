using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020004ED RID: 1261
[Serializable]
public class MonsterKillRequirementLogic : QuestRequirementBase
{
	// Token: 0x0600258A RID: 9610 RVA: 0x00110CA2 File Offset: 0x0010F0A2
	public MonsterKillRequirementLogic()
	{
	}

	// Token: 0x17000294 RID: 660
	// (get) Token: 0x0600258B RID: 9611 RVA: 0x00110CAA File Offset: 0x0010F0AA
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.MonsterKill;
		}
	}

	// Token: 0x0600258C RID: 9612 RVA: 0x00110CAD File Offset: 0x0010F0AD
	public override bool Fullfilled(Quest quest)
	{
		return this.fullfilled;
	}

	// Token: 0x0600258D RID: 9613 RVA: 0x00110CB8 File Offset: 0x0010F0B8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled
		};
	}

	// Token: 0x0600258E RID: 9614 RVA: 0x00110CD4 File Offset: 0x0010F0D4
	public override IEnumerable ProcessAdventureEvent(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitKilled && this.RequiredDungeons.Any((AdventureType d) => evt.EventTriggeringUnit.CurrentAdventure.AdventureType == d) && this.RequiredLevels.Any((int l) => evt.EventTriggeringUnit.CurrentAdventure.LevelNumber == l) && !evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit is EnemyBattleUnit)
		{
			EnemyBattleUnit enemyBattleUnit = evt.EventTriggeringUnit as EnemyBattleUnit;
			if (evt.EventTriggeringUnit.GetUnitType() == this.MonsterClass && enemyBattleUnit.SlotSelection == this.MonsterSlotType)
			{
				this.KilledAmount++;
				if (this.KilledAmount >= this.RequiredKills)
				{
					this.fullfilled = true;
				}
			}
		}
		yield break;
	}

	// Token: 0x04002052 RID: 8274
	public UnitClass MonsterClass;

	// Token: 0x04002053 RID: 8275
	public int RequiredKills;

	// Token: 0x04002054 RID: 8276
	public int KilledAmount;

	// Token: 0x04002055 RID: 8277
	public bool fullfilled;

	// Token: 0x04002056 RID: 8278
	public List<int> RequiredLevels;

	// Token: 0x04002057 RID: 8279
	public List<AdventureType> RequiredDungeons;

	// Token: 0x04002058 RID: 8280
	public AdventureEncounterSlotType MonsterSlotType;

	// Token: 0x04002059 RID: 8281
	public bool IsGurranteedSpawn;

	// Token: 0x02000DB5 RID: 3509
	[CompilerGenerated]
	private sealed class <ProcessAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005895 RID: 22677 RVA: 0x00110CFE File Offset: 0x0010F0FE
		[DebuggerHidden]
		public <ProcessAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x06005896 RID: 22678 RVA: 0x00110D08 File Offset: 0x0010F108
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evt.EventType == AdventureEventType.UnitKilled && this.RequiredDungeons.Any((AdventureType d) => evt.EventTriggeringUnit.CurrentAdventure.AdventureType == d) && this.RequiredLevels.Any((int l) => evt.EventTriggeringUnit.CurrentAdventure.LevelNumber == l) && !evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit is EnemyBattleUnit)
				{
					EnemyBattleUnit enemyBattleUnit = evt.EventTriggeringUnit as EnemyBattleUnit;
					if (evt.EventTriggeringUnit.GetUnitType() == this.MonsterClass && enemyBattleUnit.SlotSelection == this.MonsterSlotType)
					{
						this.KilledAmount++;
						if (this.KilledAmount >= this.RequiredKills)
						{
							this.fullfilled = true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x17001288 RID: 4744
		// (get) Token: 0x06005897 RID: 22679 RVA: 0x00110E45 File Offset: 0x0010F245
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001289 RID: 4745
		// (get) Token: 0x06005898 RID: 22680 RVA: 0x00110E4D File Offset: 0x0010F24D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005899 RID: 22681 RVA: 0x00110E55 File Offset: 0x0010F255
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x00110E57 File Offset: 0x0010F257
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600589B RID: 22683 RVA: 0x00110E5E File Offset: 0x0010F25E
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600589C RID: 22684 RVA: 0x00110E68 File Offset: 0x0010F268
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MonsterKillRequirementLogic.<ProcessAdventureEvent>c__Iterator0 <ProcessAdventureEvent>c__Iterator = new MonsterKillRequirementLogic.<ProcessAdventureEvent>c__Iterator0();
			<ProcessAdventureEvent>c__Iterator.$this = this;
			<ProcessAdventureEvent>c__Iterator.evt = evt;
			return <ProcessAdventureEvent>c__Iterator;
		}

		// Token: 0x04004874 RID: 18548
		internal BroadcastEvent evt;

		// Token: 0x04004875 RID: 18549
		internal MonsterKillRequirementLogic $this;

		// Token: 0x04004876 RID: 18550
		internal object $current;

		// Token: 0x04004877 RID: 18551
		internal bool $disposing;

		// Token: 0x04004878 RID: 18552
		internal int $PC;

		// Token: 0x02000DB6 RID: 3510
		private sealed class <ProcessAdventureEvent>c__AnonStorey1
		{
			// Token: 0x0600589D RID: 22685 RVA: 0x00110EA8 File Offset: 0x0010F2A8
			public <ProcessAdventureEvent>c__AnonStorey1()
			{
			}

			// Token: 0x0600589E RID: 22686 RVA: 0x00110EB0 File Offset: 0x0010F2B0
			internal bool <>m__0(AdventureType d)
			{
				return this.evt.EventTriggeringUnit.CurrentAdventure.AdventureType == d;
			}

			// Token: 0x0600589F RID: 22687 RVA: 0x00110ECA File Offset: 0x0010F2CA
			internal bool <>m__1(int l)
			{
				return this.evt.EventTriggeringUnit.CurrentAdventure.LevelNumber == l;
			}

			// Token: 0x04004879 RID: 18553
			internal BroadcastEvent evt;

			// Token: 0x0400487A RID: 18554
			internal MonsterKillRequirementLogic.<ProcessAdventureEvent>c__Iterator0 <>f__ref$0;
		}
	}
}
