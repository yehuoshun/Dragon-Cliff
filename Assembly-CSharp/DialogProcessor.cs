using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000487 RID: 1159
public class DialogProcessor : IFactionProcessor
{
	// Token: 0x060020DF RID: 8415 RVA: 0x000E5642 File Offset: 0x000E3A42
	public DialogProcessor()
	{
	}

	// Token: 0x17000228 RID: 552
	// (get) Token: 0x060020E0 RID: 8416 RVA: 0x000E564A File Offset: 0x000E3A4A
	public GameFactionType CorrespondingGameFactionType
	{
		get
		{
			return GameFactionType.DialogProcessor;
		}
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x000E5650 File Offset: 0x000E3A50
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		foreach (GenericTownTalkDefinitionBase genericTownTalkDefinitionBase in DialogProcessor.DialogDefinitions)
		{
			if (genericTownTalkDefinitionBase.MetRequirement(evt, data))
			{
				genericTownTalkDefinitionBase.Run(evt, data);
			}
		}
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x000E56BC File Offset: 0x000E3ABC
	public IEnumerable ProcessBattleEvent(BroadcastEvent evt)
	{
		foreach (GenericBattleSequenceBase genericBattleDefinitionBase in DialogProcessor.BattleDialogueDefinitions)
		{
			if (genericBattleDefinitionBase.MetRequirement(evt))
			{
				IEnumerator enumerator2 = genericBattleDefinitionBase.Run(evt).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x000E56E0 File Offset: 0x000E3AE0
	public List<AdventureEventType> CorrespondingEvents()
	{
		List<AdventureEventType> list = new List<AdventureEventType>
		{
			AdventureEventType.UnitBattleDialogueCompleted,
			AdventureEventType.UnitCastsSkill
		};
		List<AdventureEventType> collection = (from s in DialogProcessor.BattleDialogueDefinitions.OfType<BossFightSequenceBase>()
		select s.TriggeredEventType).ToList<AdventureEventType>();
		List<AdventureEventType> collection2 = DialogProcessor.BattleDialogueDefinitions.OfType<UnitEventTriggeredGuarranteedTalks>().SelectMany((UnitEventTriggeredGuarranteedTalks s) => from t in s.UnitTalkses
		select t.Key).ToList<AdventureEventType>();
		list.AddRange(collection);
		list.AddRange(collection2);
		return list.Distinct<AdventureEventType>().ToList<AdventureEventType>();
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x000E5784 File Offset: 0x000E3B84
	// Note: this type is marked as 'beforefieldinit'.
	static DialogProcessor()
	{
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x000E579A File Offset: 0x000E3B9A
	[CompilerGenerated]
	private static AdventureEventType <CorrespondingEvents>m__0(BossFightSequenceBase s)
	{
		return s.TriggeredEventType;
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x000E57A2 File Offset: 0x000E3BA2
	[CompilerGenerated]
	private static IEnumerable<AdventureEventType> <CorrespondingEvents>m__1(UnitEventTriggeredGuarranteedTalks s)
	{
		return from t in s.UnitTalkses
		select t.Key;
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x000E57CC File Offset: 0x000E3BCC
	[CompilerGenerated]
	private static AdventureEventType <CorrespondingEvents>m__2(KeyValuePair<AdventureEventType, List<UnitTalks>> t)
	{
		return t.Key;
	}

	// Token: 0x04001D16 RID: 7446
	public static List<GenericTownTalkDefinitionBase> DialogDefinitions = GameConfigurations.GetImplementationsOfAbstractClass<GenericTownTalkDefinitionBase>();

	// Token: 0x04001D17 RID: 7447
	public static List<GenericBattleSequenceBase> BattleDialogueDefinitions = GameConfigurations.GetImplementationsOfAbstractClass<GenericBattleSequenceBase>();

	// Token: 0x04001D18 RID: 7448
	[CompilerGenerated]
	private static Func<BossFightSequenceBase, AdventureEventType> <>f__am$cache0;

	// Token: 0x04001D19 RID: 7449
	[CompilerGenerated]
	private static Func<UnitEventTriggeredGuarranteedTalks, IEnumerable<AdventureEventType>> <>f__am$cache1;

	// Token: 0x04001D1A RID: 7450
	[CompilerGenerated]
	private static Func<KeyValuePair<AdventureEventType, List<UnitTalks>>, AdventureEventType> <>f__am$cache2;

	// Token: 0x02000D31 RID: 3377
	[CompilerGenerated]
	private sealed class <ProcessBattleEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600566E RID: 22126 RVA: 0x000E57D5 File Offset: 0x000E3BD5
		[DebuggerHidden]
		public <ProcessBattleEvent>c__Iterator0()
		{
		}

		// Token: 0x0600566F RID: 22127 RVA: 0x000E57E0 File Offset: 0x000E3BE0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = DialogProcessor.BattleDialogueDefinitions.GetEnumerator();
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
				case 1u:
					Block_5:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator.MoveNext())
				{
					genericBattleDefinitionBase = enumerator.Current;
					if (genericBattleDefinitionBase.MetRequirement(evt))
					{
						enumerator2 = genericBattleDefinitionBase.Run(evt).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700123C RID: 4668
		// (get) Token: 0x06005670 RID: 22128 RVA: 0x000E5950 File Offset: 0x000E3D50
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700123D RID: 4669
		// (get) Token: 0x06005671 RID: 22129 RVA: 0x000E5958 File Offset: 0x000E3D58
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005672 RID: 22130 RVA: 0x000E5960 File Offset: 0x000E3D60
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
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005673 RID: 22131 RVA: 0x000E59F4 File Offset: 0x000E3DF4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005674 RID: 22132 RVA: 0x000E59FB File Offset: 0x000E3DFB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005675 RID: 22133 RVA: 0x000E5A04 File Offset: 0x000E3E04
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DialogProcessor.<ProcessBattleEvent>c__Iterator0 <ProcessBattleEvent>c__Iterator = new DialogProcessor.<ProcessBattleEvent>c__Iterator0();
			<ProcessBattleEvent>c__Iterator.evt = evt;
			return <ProcessBattleEvent>c__Iterator;
		}

		// Token: 0x040044FD RID: 17661
		internal List<GenericBattleSequenceBase>.Enumerator $locvar0;

		// Token: 0x040044FE RID: 17662
		internal GenericBattleSequenceBase <genericBattleDefinitionBase>__1;

		// Token: 0x040044FF RID: 17663
		internal BroadcastEvent evt;

		// Token: 0x04004500 RID: 17664
		internal IEnumerator $locvar1;

		// Token: 0x04004501 RID: 17665
		internal object <_>__2;

		// Token: 0x04004502 RID: 17666
		internal IDisposable $locvar2;

		// Token: 0x04004503 RID: 17667
		internal object $current;

		// Token: 0x04004504 RID: 17668
		internal bool $disposing;

		// Token: 0x04004505 RID: 17669
		internal int $PC;
	}
}
