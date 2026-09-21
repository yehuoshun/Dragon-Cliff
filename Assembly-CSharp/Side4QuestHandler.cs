using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020004D5 RID: 1237
public class Side4QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x06002525 RID: 9509 RVA: 0x0010EC94 File Offset: 0x0010D094
	public Side4QuestHandler()
	{
	}

	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06002526 RID: 9510 RVA: 0x0010ECAF File Offset: 0x0010D0AF
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x06002527 RID: 9511 RVA: 0x0010ECB8 File Offset: 0x0010D0B8
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		Side4QuestHandler.Part1Issue(evt, data);
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_4_p2)
			{
				GameWorld.instance.PlayerProfile.SetChainCompletionStatus(QuestChainIdentifier.ImmortalCult, true);
			}
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_4_p1 && !QuestIdentifier.Side_4_p2.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()) && this.GetSoulCollected() >= 20)
			{
				Side4QuestHandler.AddP2();
			}
		}
		if (evt == GameWorldEvent.GameSessionInitializationCompleted && ResourceType.BlackBead.HasObtained() && GameWorld.instance.PlayerProfile.GetStarRating() == 2 && GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Side_4_p1, GameWorld.instance.PlayerProfile.GetStarRating()) && !QuestIdentifier.Side_4_p2.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			Side4QuestHandler.AddP2();
		}
	}

	// Token: 0x06002528 RID: 9512 RVA: 0x0010EDBC File Offset: 0x0010D1BC
	public override IEnumerable ProcessAdventureEvent(BroadcastEvent evt)
	{
		IEnumerator enumerator = this.Part2Issue(evt).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object p = enumerator.Current;
				yield return p;
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

	// Token: 0x06002529 RID: 9513 RVA: 0x0010EDE8 File Offset: 0x0010D1E8
	private IEnumerable Part2Issue(BroadcastEvent evt)
	{
		int maxSoul = 20;
		if (evt.EventType == AdventureEventType.UnitKilled && !evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit.IsBoss() && !GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.ImmortalCult, GameWorld.instance.PlayerProfile.GetStarRating()) && ResourceType.BlackBead.HasObtained() && this.GetSoulCollected() < maxSoul && !QuestIdentifier.Side_4_p2.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			int numberOfSouls = this.GetSoulCollected() + 1;
			this.UpdateSoulCollected(numberOfSouls);
			IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(evt.EventTriggeringUnit, AdventureEventType.BlackBeadSoulCollected, numberOfSouls)).GetEnumerator();
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
			if (numberOfSouls == maxSoul)
			{
				Side4QuestHandler.AddP2();
			}
		}
		yield break;
	}

	// Token: 0x0600252A RID: 9514 RVA: 0x0010EE14 File Offset: 0x0010D214
	private static void AddP2()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.SnowMountain.GetAdventureLevelConfiguration(5).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.RedImmortalSeeker)
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 25.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_4_p2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(6000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.SnowMountain,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x0600252B RID: 9515 RVA: 0x0010EF00 File Offset: 0x0010D300
	private int GetSoulCollected()
	{
		if (GameWorld.instance.PlayerProfile.AdditionalData.ContainsInt(this._blackSoulKey))
		{
			return GameWorld.instance.PlayerProfile.AdditionalData.GetInt(this._blackSoulKey);
		}
		return 0;
	}

	// Token: 0x0600252C RID: 9516 RVA: 0x0010EF3D File Offset: 0x0010D33D
	private void UpdateSoulCollected(int numberOfSouls)
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(this._blackSoulKey, numberOfSouls);
	}

	// Token: 0x0600252D RID: 9517 RVA: 0x0010EF5C File Offset: 0x0010D35C
	private static void Part1Issue(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ItemGrowthCompleted && !GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.ImmortalCult, GameWorld.instance.PlayerProfile.GetStarRating()) && data is Item)
		{
			Item item = data as Item;
			if (item.Type == ResourceType.HiddenWood && !QuestIdentifier.Side_4_p1.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
			{
				Side4QuestHandler.AddPart1();
			}
		}
		if ((evt == GameWorldEvent.ReputationIncreased || evt == GameWorldEvent.GameSessionInitializationCompleted) && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation > 1100.0 && !QuestIdentifier.Side_4_p1.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			Side4QuestHandler.AddPart1();
		}
	}

	// Token: 0x0600252E RID: 9518 RVA: 0x0010F034 File Offset: 0x0010D434
	private static void AddPart1()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.MistForest.GetAdventureLevelConfiguration(7).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.ImmortalSeeker)
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 17.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_4_p1, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(3500.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.MistForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x04001FBE RID: 8126
	private readonly QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.ImmortalCult;

	// Token: 0x04001FBF RID: 8127
	private string _blackSoulKey = "blackbeadcollectedsoul";

	// Token: 0x02000DB0 RID: 3504
	[CompilerGenerated]
	private sealed class <ProcessAdventureEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005873 RID: 22643 RVA: 0x0010F120 File Offset: 0x0010D520
		[DebuggerHidden]
		public <ProcessAdventureEvent>c__Iterator0()
		{
		}

		// Token: 0x06005874 RID: 22644 RVA: 0x0010F128 File Offset: 0x0010D528
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = base.Part2Issue(evt).GetEnumerator();
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
					p = enumerator.Current;
					this.$current = p;
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

		// Token: 0x17001280 RID: 4736
		// (get) Token: 0x06005875 RID: 22645 RVA: 0x0010F214 File Offset: 0x0010D614
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001281 RID: 4737
		// (get) Token: 0x06005876 RID: 22646 RVA: 0x0010F21C File Offset: 0x0010D61C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005877 RID: 22647 RVA: 0x0010F224 File Offset: 0x0010D624
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

		// Token: 0x06005878 RID: 22648 RVA: 0x0010F294 File Offset: 0x0010D694
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005879 RID: 22649 RVA: 0x0010F29B File Offset: 0x0010D69B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600587A RID: 22650 RVA: 0x0010F2A4 File Offset: 0x0010D6A4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Side4QuestHandler.<ProcessAdventureEvent>c__Iterator0 <ProcessAdventureEvent>c__Iterator = new Side4QuestHandler.<ProcessAdventureEvent>c__Iterator0();
			<ProcessAdventureEvent>c__Iterator.$this = this;
			<ProcessAdventureEvent>c__Iterator.evt = evt;
			return <ProcessAdventureEvent>c__Iterator;
		}

		// Token: 0x04004859 RID: 18521
		internal BroadcastEvent evt;

		// Token: 0x0400485A RID: 18522
		internal IEnumerator $locvar0;

		// Token: 0x0400485B RID: 18523
		internal object <p>__1;

		// Token: 0x0400485C RID: 18524
		internal IDisposable $locvar1;

		// Token: 0x0400485D RID: 18525
		internal Side4QuestHandler $this;

		// Token: 0x0400485E RID: 18526
		internal object $current;

		// Token: 0x0400485F RID: 18527
		internal bool $disposing;

		// Token: 0x04004860 RID: 18528
		internal int $PC;
	}

	// Token: 0x02000DB1 RID: 3505
	[CompilerGenerated]
	private sealed class <Part2Issue>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600587B RID: 22651 RVA: 0x0010F2E4 File Offset: 0x0010D6E4
		[DebuggerHidden]
		public <Part2Issue>c__Iterator1()
		{
		}

		// Token: 0x0600587C RID: 22652 RVA: 0x0010F2EC File Offset: 0x0010D6EC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				maxSoul = 20;
				if (evt.EventType != AdventureEventType.UnitKilled || evt.EventTriggeringUnit.IsPlayer || !evt.EventTriggeringUnit.IsBoss() || GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.ImmortalCult, GameWorld.instance.PlayerProfile.GetStarRating()) || !ResourceType.BlackBead.HasObtained() || base.GetSoulCollected() >= maxSoul || QuestIdentifier.Side_4_p2.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
				{
					goto IL_1BD;
				}
				numberOfSouls = base.GetSoulCollected() + 1;
				base.UpdateSoulCollected(numberOfSouls);
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(evt.EventTriggeringUnit, AdventureEventType.BlackBeadSoulCollected, numberOfSouls)).GetEnumerator();
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
			if (numberOfSouls == maxSoul)
			{
				Side4QuestHandler.AddP2();
			}
			IL_1BD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001282 RID: 4738
		// (get) Token: 0x0600587D RID: 22653 RVA: 0x0010F4D0 File Offset: 0x0010D8D0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001283 RID: 4739
		// (get) Token: 0x0600587E RID: 22654 RVA: 0x0010F4D8 File Offset: 0x0010D8D8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600587F RID: 22655 RVA: 0x0010F4E0 File Offset: 0x0010D8E0
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

		// Token: 0x06005880 RID: 22656 RVA: 0x0010F550 File Offset: 0x0010D950
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005881 RID: 22657 RVA: 0x0010F557 File Offset: 0x0010D957
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005882 RID: 22658 RVA: 0x0010F560 File Offset: 0x0010D960
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Side4QuestHandler.<Part2Issue>c__Iterator1 <Part2Issue>c__Iterator = new Side4QuestHandler.<Part2Issue>c__Iterator1();
			<Part2Issue>c__Iterator.$this = this;
			<Part2Issue>c__Iterator.evt = evt;
			return <Part2Issue>c__Iterator;
		}

		// Token: 0x04004861 RID: 18529
		internal int <maxSoul>__0;

		// Token: 0x04004862 RID: 18530
		internal BroadcastEvent evt;

		// Token: 0x04004863 RID: 18531
		internal int <numberOfSouls>__1;

		// Token: 0x04004864 RID: 18532
		internal IEnumerator $locvar0;

		// Token: 0x04004865 RID: 18533
		internal object <_>__2;

		// Token: 0x04004866 RID: 18534
		internal IDisposable $locvar1;

		// Token: 0x04004867 RID: 18535
		internal Side4QuestHandler $this;

		// Token: 0x04004868 RID: 18536
		internal object $current;

		// Token: 0x04004869 RID: 18537
		internal bool $disposing;

		// Token: 0x0400486A RID: 18538
		internal int $PC;
	}
}
