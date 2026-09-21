using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000977 RID: 2423
public static class StoryUtilities
{
	// Token: 0x0600428F RID: 17039 RVA: 0x001B2EEF File Offset: 0x001B12EF
	public static StoryDetails GetDetails(this StoryIdentifier identifier)
	{
		return LocalizationSession.instance.LocalizationManager.GetStoryLocalizedDetails(identifier);
	}

	// Token: 0x06004290 RID: 17040 RVA: 0x001B2F01 File Offset: 0x001B1301
	public static DialogDetails GetDetails(this DialogIdentifier identifier)
	{
		return LocalizationSession.instance.LocalizationManager.GetLocalizedDialog(identifier);
	}

	// Token: 0x06004291 RID: 17041 RVA: 0x001B2F14 File Offset: 0x001B1314
	public static void TriggerStory(this StoryIdentifier identifier)
	{
		StoryDetails details = identifier.GetDetails();
		GameWorld.instance.PlayerProfile.RecordStory(identifier);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.StoryEventTriggerred, new StoryTriggeredEvent
		{
			StoryDetails = details
		});
	}

	// Token: 0x06004292 RID: 17042 RVA: 0x001B2F58 File Offset: 0x001B1358
	public static void TriggerCriticalStory(this StoryIdentifier identifier)
	{
		StoryDetails details = identifier.GetDetails();
		GameWorld.instance.PlayerProfile.RecordStory(identifier);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.CriticalStoryEventTriggerred, new StoryTriggeredEvent
		{
			StoryDetails = details
		});
	}

	// Token: 0x06004293 RID: 17043 RVA: 0x001B2F9C File Offset: 0x001B139C
	public static void BatchSpeak(List<AdventureSpeaksContent> contents)
	{
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerTriggersDialog, new AdventurerSpeaksEvent
		{
			AdventureSpeaksContents = contents
		});
	}

	// Token: 0x06004294 RID: 17044 RVA: 0x001B2FC8 File Offset: 0x001B13C8
	public static void GuarranteeTownSpeakAndRandomLater(this AdventurerProfile adventurer, DialogIdentifier dialog, float possibility = 0.3f)
	{
		if (dialog.HasBeenSpokenFor(1))
		{
			if (UnityEngine.Random.value <= possibility)
			{
				adventurer.UnitClass.Speaks(dialog);
			}
		}
		else
		{
			adventurer.UnitClass.Speaks(dialog);
		}
	}

	// Token: 0x06004295 RID: 17045 RVA: 0x001B3000 File Offset: 0x001B1400
	public static AdventurerProfile GetAdventurerProfile(this UnitClass unitClass)
	{
		return GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.UnitClass == unitClass);
	}

	// Token: 0x06004296 RID: 17046 RVA: 0x001B303C File Offset: 0x001B143C
	public static IEnumerable Speaks(this UnitClass unitClass, List<IBattleUnit> units, DialogIdentifier identifier)
	{
		IBattleUnit unit = units.FirstOrDefault((IBattleUnit u) => u.GetUnitType() == unitClass);
		if (unit != null)
		{
			IEnumerator enumerator = unit.Speaks(identifier).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06004297 RID: 17047 RVA: 0x001B3070 File Offset: 0x001B1470
	public static void Speaks(this UnitClass adventure, DialogIdentifier dialog)
	{
		GameWorld.instance.PlayerProfile.RecordDialog(dialog);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerTriggersDialog, new AdventurerSpeaksEvent
		{
			AdventureSpeaksContents = new List<AdventureSpeaksContent>
			{
				new AdventureSpeaksContent
				{
					AdventurerUnitType = adventure,
					DialogDetailses = new List<DialogDetails>
					{
						dialog.GetDetails()
					}
				}
			}
		});
	}

	// Token: 0x06004298 RID: 17048 RVA: 0x001B30E0 File Offset: 0x001B14E0
	public static void Speaks(this List<TownTalkModule> talks)
	{
		List<AdventureSpeaksContent> list = new List<AdventureSpeaksContent>();
		foreach (TownTalkModule townTalkModule in talks)
		{
			List<AdventureSpeaksContent> list2 = list;
			AdventureSpeaksContent adventureSpeaksContent = new AdventureSpeaksContent();
			adventureSpeaksContent.AdventurerUnitType = townTalkModule.Talker;
			AdventureSpeaksContent adventureSpeaksContent2 = adventureSpeaksContent;
			IEnumerable<DialogIdentifier> dialogs = townTalkModule.Dialogs;
			if (StoryUtilities.<>f__mg$cache0 == null)
			{
				StoryUtilities.<>f__mg$cache0 = new Func<DialogIdentifier, DialogDetails>(StoryUtilities.GetDetails);
			}
			adventureSpeaksContent2.DialogDetailses = dialogs.Select(StoryUtilities.<>f__mg$cache0).ToList<DialogDetails>();
			list2.Add(adventureSpeaksContent);
			foreach (DialogIdentifier dialogIdentifier in townTalkModule.Dialogs)
			{
				GameWorld.instance.PlayerProfile.RecordDialog(dialogIdentifier);
			}
		}
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerTriggersDialog, new AdventurerSpeaksEvent
		{
			AdventureSpeaksContents = list
		});
	}

	// Token: 0x06004299 RID: 17049 RVA: 0x001B31FC File Offset: 0x001B15FC
	public static List<DialogActualContent> GetContents(this List<DialogDetails> details)
	{
		List<DialogActualContent> list = new List<DialogActualContent>();
		foreach (DialogDetails dialogDetails in details)
		{
			foreach (string content in dialogDetails.Dialog.Split(new char[]
			{
				';'
			}))
			{
				list.Add(new DialogActualContent
				{
					Content = content,
					IsCritical = dialogDetails.IsCriticalDialog
				});
			}
		}
		return list;
	}

	// Token: 0x0600429A RID: 17050 RVA: 0x001B32B0 File Offset: 0x001B16B0
	public static IEnumerable GuarranteeBattleSpeakAndRandomLater(this IBattleUnit unit, DialogIdentifier dialog, float possibility = 0.2f)
	{
		if (dialog.HasBeenSpokenFor(1))
		{
			if (UnityEngine.Random.value <= possibility)
			{
				IEnumerator enumerator = unit.Speaks(dialog).GetEnumerator();
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
		}
		else
		{
			IEnumerator enumerator2 = unit.Speaks(dialog).GetEnumerator();
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

	// Token: 0x0600429B RID: 17051 RVA: 0x001B32E4 File Offset: 0x001B16E4
	public static IEnumerable RandomBattleTalk(this IBattleUnit unit, DialogIdentifier dialog, float possibility = 0.4f)
	{
		if (UnityEngine.Random.value <= possibility)
		{
			IEnumerator enumerator = unit.Speaks(dialog).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600429C RID: 17052 RVA: 0x001B3318 File Offset: 0x001B1718
	public static IEnumerable TriggersAdventureStory(this StoryIdentifier story)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(GameWorld.instance.GetCurrentAdventure().Adventurers.FirstOrDefault<AdventurerBattleUnit>(), AdventureEventType.AdventureStoryTriggered, story)).GetEnumerator();
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

	// Token: 0x0600429D RID: 17053 RVA: 0x001B333C File Offset: 0x001B173C
	public static IEnumerable Speaks(this IBattleUnit unit, DialogIdentifier dialog)
	{
		GameWorld.instance.PlayerProfile.RecordDialog(dialog);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.BattleUnitTriggersDialog, new BattleUnitSpeaksEvent
		{
			DialogDetails = new List<DialogDetails>
			{
				dialog.GetDetails()
			},
			BattleUnit = unit
		});
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitTriggersDialog, new BattleUnitSpeaksEvent
		{
			DialogDetails = new List<DialogDetails>
			{
				dialog.GetDetails()
			},
			BattleUnit = unit
		})).GetEnumerator();
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
		IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitBattleDialogueCompleted, new BattleUnitSpeaksEvent
		{
			DialogDetails = new List<DialogDetails>
			{
				dialog.GetDetails()
			},
			BattleUnit = unit
		})).GetEnumerator();
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
		yield break;
	}

	// Token: 0x0600429E RID: 17054 RVA: 0x001B3368 File Offset: 0x001B1768
	public static bool HasBeenTriggerredFor(this StoryIdentifier story, int numberOfTimes)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).StoryTriggeredRecords.ContainsKey(story) && GameWorld.instance.PlayerProfile.GetProgress(null).StoryTriggeredRecords[story] >= numberOfTimes;
	}

	// Token: 0x0600429F RID: 17055 RVA: 0x001B33CC File Offset: 0x001B17CC
	public static bool HasBeenSpokenFor(this DialogIdentifier dialog, int numberOftimes)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).DialogSpokenRecords.ContainsKey(dialog) && GameWorld.instance.PlayerProfile.GetProgress(null).DialogSpokenRecords[dialog] >= numberOftimes;
	}

	// Token: 0x060042A0 RID: 17056 RVA: 0x001B342D File Offset: 0x001B182D
	public static void RandomTownTalk(this DialogIdentifier dialog)
	{
		GameWorld.instance.PlayerProfile.RandomTownTalk(dialog);
	}

	// Token: 0x040032CC RID: 13004
	[CompilerGenerated]
	private static Func<DialogIdentifier, DialogDetails> <>f__mg$cache0;

	// Token: 0x02000FFC RID: 4092
	[CompilerGenerated]
	private sealed class <GetAdventurerProfile>c__AnonStorey5
	{
		// Token: 0x0600679A RID: 26522 RVA: 0x001B343F File Offset: 0x001B183F
		public <GetAdventurerProfile>c__AnonStorey5()
		{
		}

		// Token: 0x0600679B RID: 26523 RVA: 0x001B3447 File Offset: 0x001B1847
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.UnitClass == this.unitClass;
		}

		// Token: 0x04006197 RID: 24983
		internal UnitClass unitClass;
	}

	// Token: 0x02000FFD RID: 4093
	[CompilerGenerated]
	private sealed class <Speaks>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600679C RID: 26524 RVA: 0x001B3457 File Offset: 0x001B1857
		[DebuggerHidden]
		public <Speaks>c__Iterator0()
		{
		}

		// Token: 0x0600679D RID: 26525 RVA: 0x001B3460 File Offset: 0x001B1860
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				unit = units.FirstOrDefault((IBattleUnit u) => u.GetUnitType() == unitClass);
				if (unit == null)
				{
					goto IL_119;
				}
				enumerator = unit.Speaks(identifier).GetEnumerator();
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
			IL_119:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015BB RID: 5563
		// (get) Token: 0x0600679E RID: 26526 RVA: 0x001B35A0 File Offset: 0x001B19A0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015BC RID: 5564
		// (get) Token: 0x0600679F RID: 26527 RVA: 0x001B35A8 File Offset: 0x001B19A8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060067A0 RID: 26528 RVA: 0x001B35B0 File Offset: 0x001B19B0
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

		// Token: 0x060067A1 RID: 26529 RVA: 0x001B3620 File Offset: 0x001B1A20
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060067A2 RID: 26530 RVA: 0x001B3627 File Offset: 0x001B1A27
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060067A3 RID: 26531 RVA: 0x001B3630 File Offset: 0x001B1A30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoryUtilities.<Speaks>c__Iterator0 <Speaks>c__Iterator = new StoryUtilities.<Speaks>c__Iterator0();
			<Speaks>c__Iterator.units = units;
			<Speaks>c__Iterator.unitClass = unitClass;
			<Speaks>c__Iterator.identifier = identifier;
			return <Speaks>c__Iterator;
		}

		// Token: 0x04006198 RID: 24984
		internal List<IBattleUnit> units;

		// Token: 0x04006199 RID: 24985
		internal UnitClass unitClass;

		// Token: 0x0400619A RID: 24986
		internal IBattleUnit <unit>__0;

		// Token: 0x0400619B RID: 24987
		internal DialogIdentifier identifier;

		// Token: 0x0400619C RID: 24988
		internal IEnumerator $locvar0;

		// Token: 0x0400619D RID: 24989
		internal object <_>__1;

		// Token: 0x0400619E RID: 24990
		internal IDisposable $locvar1;

		// Token: 0x0400619F RID: 24991
		internal object $current;

		// Token: 0x040061A0 RID: 24992
		internal bool $disposing;

		// Token: 0x040061A1 RID: 24993
		internal int $PC;

		// Token: 0x040061A2 RID: 24994
		private StoryUtilities.<Speaks>c__Iterator0.<Speaks>c__AnonStorey6 $locvar2;

		// Token: 0x02001002 RID: 4098
		private sealed class <Speaks>c__AnonStorey6
		{
			// Token: 0x060067C4 RID: 26564 RVA: 0x001B367C File Offset: 0x001B1A7C
			public <Speaks>c__AnonStorey6()
			{
			}

			// Token: 0x060067C5 RID: 26565 RVA: 0x001B3684 File Offset: 0x001B1A84
			internal bool <>m__0(IBattleUnit u)
			{
				return u.GetUnitType() == this.unitClass;
			}

			// Token: 0x040061CA RID: 25034
			internal UnitClass unitClass;

			// Token: 0x040061CB RID: 25035
			internal StoryUtilities.<Speaks>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000FFE RID: 4094
	[CompilerGenerated]
	private sealed class <GuarranteeBattleSpeakAndRandomLater>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060067A4 RID: 26532 RVA: 0x001B3694 File Offset: 0x001B1A94
		[DebuggerHidden]
		public <GuarranteeBattleSpeakAndRandomLater>c__Iterator1()
		{
		}

		// Token: 0x060067A5 RID: 26533 RVA: 0x001B369C File Offset: 0x001B1A9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!dialog.HasBeenSpokenFor(1))
				{
					enumerator2 = unit.Speaks(dialog).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
				if (UnityEngine.Random.value > possibility)
				{
					goto IL_E9;
				}
				enumerator = unit.Speaks(dialog).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_10D;
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
			IL_E9:
			goto IL_18F;
			Block_5:
			try
			{
				IL_10D:
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
			IL_18F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015BD RID: 5565
		// (get) Token: 0x060067A6 RID: 26534 RVA: 0x001B3860 File Offset: 0x001B1C60
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015BE RID: 5566
		// (get) Token: 0x060067A7 RID: 26535 RVA: 0x001B3868 File Offset: 0x001B1C68
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060067A8 RID: 26536 RVA: 0x001B3870 File Offset: 0x001B1C70
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

		// Token: 0x060067A9 RID: 26537 RVA: 0x001B3920 File Offset: 0x001B1D20
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060067AA RID: 26538 RVA: 0x001B3927 File Offset: 0x001B1D27
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060067AB RID: 26539 RVA: 0x001B3930 File Offset: 0x001B1D30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoryUtilities.<GuarranteeBattleSpeakAndRandomLater>c__Iterator1 <GuarranteeBattleSpeakAndRandomLater>c__Iterator = new StoryUtilities.<GuarranteeBattleSpeakAndRandomLater>c__Iterator1();
			<GuarranteeBattleSpeakAndRandomLater>c__Iterator.dialog = dialog;
			<GuarranteeBattleSpeakAndRandomLater>c__Iterator.possibility = possibility;
			<GuarranteeBattleSpeakAndRandomLater>c__Iterator.unit = unit;
			return <GuarranteeBattleSpeakAndRandomLater>c__Iterator;
		}

		// Token: 0x040061A3 RID: 24995
		internal DialogIdentifier dialog;

		// Token: 0x040061A4 RID: 24996
		internal float possibility;

		// Token: 0x040061A5 RID: 24997
		internal IBattleUnit unit;

		// Token: 0x040061A6 RID: 24998
		internal IEnumerator $locvar0;

		// Token: 0x040061A7 RID: 24999
		internal object <_>__1;

		// Token: 0x040061A8 RID: 25000
		internal IDisposable $locvar1;

		// Token: 0x040061A9 RID: 25001
		internal IEnumerator $locvar2;

		// Token: 0x040061AA RID: 25002
		internal object <_>__2;

		// Token: 0x040061AB RID: 25003
		internal IDisposable $locvar3;

		// Token: 0x040061AC RID: 25004
		internal object $current;

		// Token: 0x040061AD RID: 25005
		internal bool $disposing;

		// Token: 0x040061AE RID: 25006
		internal int $PC;
	}

	// Token: 0x02000FFF RID: 4095
	[CompilerGenerated]
	private sealed class <RandomBattleTalk>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060067AC RID: 26540 RVA: 0x001B397C File Offset: 0x001B1D7C
		[DebuggerHidden]
		public <RandomBattleTalk>c__Iterator2()
		{
		}

		// Token: 0x060067AD RID: 26541 RVA: 0x001B3984 File Offset: 0x001B1D84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (UnityEngine.Random.value > possibility)
				{
					goto IL_D4;
				}
				enumerator = unit.Speaks(dialog).GetEnumerator();
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
			IL_D4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015BF RID: 5567
		// (get) Token: 0x060067AE RID: 26542 RVA: 0x001B3A80 File Offset: 0x001B1E80
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015C0 RID: 5568
		// (get) Token: 0x060067AF RID: 26543 RVA: 0x001B3A88 File Offset: 0x001B1E88
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060067B0 RID: 26544 RVA: 0x001B3A90 File Offset: 0x001B1E90
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

		// Token: 0x060067B1 RID: 26545 RVA: 0x001B3B00 File Offset: 0x001B1F00
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060067B2 RID: 26546 RVA: 0x001B3B07 File Offset: 0x001B1F07
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060067B3 RID: 26547 RVA: 0x001B3B10 File Offset: 0x001B1F10
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoryUtilities.<RandomBattleTalk>c__Iterator2 <RandomBattleTalk>c__Iterator = new StoryUtilities.<RandomBattleTalk>c__Iterator2();
			<RandomBattleTalk>c__Iterator.possibility = possibility;
			<RandomBattleTalk>c__Iterator.unit = unit;
			<RandomBattleTalk>c__Iterator.dialog = dialog;
			return <RandomBattleTalk>c__Iterator;
		}

		// Token: 0x040061AF RID: 25007
		internal float possibility;

		// Token: 0x040061B0 RID: 25008
		internal IBattleUnit unit;

		// Token: 0x040061B1 RID: 25009
		internal DialogIdentifier dialog;

		// Token: 0x040061B2 RID: 25010
		internal IEnumerator $locvar0;

		// Token: 0x040061B3 RID: 25011
		internal object <_>__1;

		// Token: 0x040061B4 RID: 25012
		internal IDisposable $locvar1;

		// Token: 0x040061B5 RID: 25013
		internal object $current;

		// Token: 0x040061B6 RID: 25014
		internal bool $disposing;

		// Token: 0x040061B7 RID: 25015
		internal int $PC;
	}

	// Token: 0x02001000 RID: 4096
	[CompilerGenerated]
	private sealed class <TriggersAdventureStory>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060067B4 RID: 26548 RVA: 0x001B3B5C File Offset: 0x001B1F5C
		[DebuggerHidden]
		public <TriggersAdventureStory>c__Iterator3()
		{
		}

		// Token: 0x060067B5 RID: 26549 RVA: 0x001B3B64 File Offset: 0x001B1F64
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(GameWorld.instance.GetCurrentAdventure().Adventurers.FirstOrDefault<AdventurerBattleUnit>(), AdventureEventType.AdventureStoryTriggered, story)).GetEnumerator();
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

		// Token: 0x170015C1 RID: 5569
		// (get) Token: 0x060067B6 RID: 26550 RVA: 0x001B3C70 File Offset: 0x001B2070
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015C2 RID: 5570
		// (get) Token: 0x060067B7 RID: 26551 RVA: 0x001B3C78 File Offset: 0x001B2078
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060067B8 RID: 26552 RVA: 0x001B3C80 File Offset: 0x001B2080
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

		// Token: 0x060067B9 RID: 26553 RVA: 0x001B3CF0 File Offset: 0x001B20F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060067BA RID: 26554 RVA: 0x001B3CF7 File Offset: 0x001B20F7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060067BB RID: 26555 RVA: 0x001B3D00 File Offset: 0x001B2100
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoryUtilities.<TriggersAdventureStory>c__Iterator3 <TriggersAdventureStory>c__Iterator = new StoryUtilities.<TriggersAdventureStory>c__Iterator3();
			<TriggersAdventureStory>c__Iterator.story = story;
			return <TriggersAdventureStory>c__Iterator;
		}

		// Token: 0x040061B8 RID: 25016
		internal StoryIdentifier story;

		// Token: 0x040061B9 RID: 25017
		internal IEnumerator $locvar0;

		// Token: 0x040061BA RID: 25018
		internal object <_>__1;

		// Token: 0x040061BB RID: 25019
		internal IDisposable $locvar1;

		// Token: 0x040061BC RID: 25020
		internal object $current;

		// Token: 0x040061BD RID: 25021
		internal bool $disposing;

		// Token: 0x040061BE RID: 25022
		internal int $PC;
	}

	// Token: 0x02001001 RID: 4097
	[CompilerGenerated]
	private sealed class <Speaks>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060067BC RID: 26556 RVA: 0x001B3D34 File Offset: 0x001B2134
		[DebuggerHidden]
		public <Speaks>c__Iterator4()
		{
		}

		// Token: 0x060067BD RID: 26557 RVA: 0x001B3D3C File Offset: 0x001B213C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				GameWorld.instance.PlayerProfile.RecordDialog(dialog);
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.BattleUnitTriggersDialog, new BattleUnitSpeaksEvent
				{
					DialogDetails = new List<DialogDetails>
					{
						dialog.GetDetails()
					},
					BattleUnit = unit
				});
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitTriggersDialog, new BattleUnitSpeaksEvent
				{
					DialogDetails = new List<DialogDetails>
					{
						dialog.GetDetails()
					},
					BattleUnit = unit
				})).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1AE;
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
			enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(unit, AdventureEventType.UnitBattleDialogueCompleted, new BattleUnitSpeaksEvent
			{
				DialogDetails = new List<DialogDetails>
				{
					dialog.GetDetails()
				},
				BattleUnit = unit
			})).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1AE:
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015C3 RID: 5571
		// (get) Token: 0x060067BE RID: 26558 RVA: 0x001B3FA4 File Offset: 0x001B23A4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015C4 RID: 5572
		// (get) Token: 0x060067BF RID: 26559 RVA: 0x001B3FAC File Offset: 0x001B23AC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060067C0 RID: 26560 RVA: 0x001B3FB4 File Offset: 0x001B23B4
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

		// Token: 0x060067C1 RID: 26561 RVA: 0x001B4064 File Offset: 0x001B2464
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060067C2 RID: 26562 RVA: 0x001B406B File Offset: 0x001B246B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060067C3 RID: 26563 RVA: 0x001B4074 File Offset: 0x001B2474
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StoryUtilities.<Speaks>c__Iterator4 <Speaks>c__Iterator = new StoryUtilities.<Speaks>c__Iterator4();
			<Speaks>c__Iterator.dialog = dialog;
			<Speaks>c__Iterator.unit = unit;
			return <Speaks>c__Iterator;
		}

		// Token: 0x040061BF RID: 25023
		internal DialogIdentifier dialog;

		// Token: 0x040061C0 RID: 25024
		internal IBattleUnit unit;

		// Token: 0x040061C1 RID: 25025
		internal IEnumerator $locvar0;

		// Token: 0x040061C2 RID: 25026
		internal object <_>__1;

		// Token: 0x040061C3 RID: 25027
		internal IDisposable $locvar1;

		// Token: 0x040061C4 RID: 25028
		internal IEnumerator $locvar2;

		// Token: 0x040061C5 RID: 25029
		internal object <_>__2;

		// Token: 0x040061C6 RID: 25030
		internal IDisposable $locvar3;

		// Token: 0x040061C7 RID: 25031
		internal object $current;

		// Token: 0x040061C8 RID: 25032
		internal bool $disposing;

		// Token: 0x040061C9 RID: 25033
		internal int $PC;
	}
}
