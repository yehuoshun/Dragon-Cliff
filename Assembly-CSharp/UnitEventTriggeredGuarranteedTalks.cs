using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200096F RID: 2415
public class UnitEventTriggeredGuarranteedTalks : GenericBattleSequenceBase
{
	// Token: 0x06004274 RID: 17012 RVA: 0x001B2110 File Offset: 0x001B0510
	public UnitEventTriggeredGuarranteedTalks()
	{
	}

	// Token: 0x06004275 RID: 17013 RVA: 0x001B2218 File Offset: 0x001B0618
	public override bool MetRequirement(BroadcastEvent evt)
	{
		return this.UnitTalkses.ContainsKey(evt.EventType) && this.UnitTalkses[evt.EventType].Any((UnitTalks t) => t.UnitClass == evt.EventTriggeringUnit.GetUnitType() && t.DialogIdentifiers.Any<DialogIdentifier>());
	}

	// Token: 0x06004276 RID: 17014 RVA: 0x001B2278 File Offset: 0x001B0678
	public override IEnumerable Run(BroadcastEvent evt)
	{
		if (this.MetRequirement(evt))
		{
			UnitTalks talk = this.UnitTalkses[evt.EventType].First((UnitTalks t) => t.UnitClass == evt.EventTriggeringUnit.GetUnitType());
			if ((double)UnityEngine.Random.value <= talk.ChanceOfTalk)
			{
				DialogIdentifier selectedDialog = talk.DialogIdentifiers[UnityEngine.Random.Range(0, talk.DialogIdentifiers.Count)];
				IEnumerator enumerator = evt.EventTriggeringUnit.Speaks(selectedDialog).GetEnumerator();
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
		yield break;
	}

	// Token: 0x040031C6 RID: 12742
	public Dictionary<AdventureEventType, List<UnitTalks>> UnitTalkses = new Dictionary<AdventureEventType, List<UnitTalks>>
	{
		{
			AdventureEventType.DemonSoulFullyCharged,
			new List<UnitTalks>
			{
				new UnitTalks
				{
					UnitClass = UnitClass.DemonSkull,
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_2_Boss_t5
					},
					ChanceOfTalk = 1.0
				}
			}
		},
		{
			AdventureEventType.InversedKillPerformed,
			new List<UnitTalks>
			{
				new UnitTalks
				{
					UnitClass = UnitClass.Death,
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_3_2_Boss_t4
					},
					ChanceOfTalk = 1.0
				}
			}
		},
		{
			AdventureEventType.TimeFragmentTriggered,
			new List<UnitTalks>
			{
				new UnitTalks
				{
					UnitClass = UnitClass.Pharmacist,
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Main_2_1_Boss_c1
					},
					ChanceOfTalk = 1.0
				}
			}
		}
	};

	// Token: 0x02000FF7 RID: 4087
	[CompilerGenerated]
	private sealed class <MetRequirement>c__AnonStorey1
	{
		// Token: 0x0600677E RID: 26494 RVA: 0x001B22A2 File Offset: 0x001B06A2
		public <MetRequirement>c__AnonStorey1()
		{
		}

		// Token: 0x0600677F RID: 26495 RVA: 0x001B22AA File Offset: 0x001B06AA
		internal bool <>m__0(UnitTalks t)
		{
			return t.UnitClass == this.evt.EventTriggeringUnit.GetUnitType() && t.DialogIdentifiers.Any<DialogIdentifier>();
		}

		// Token: 0x04006175 RID: 24949
		internal BroadcastEvent evt;
	}

	// Token: 0x02000FF8 RID: 4088
	[CompilerGenerated]
	private sealed class <Run>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006780 RID: 26496 RVA: 0x001B22D5 File Offset: 0x001B06D5
		[DebuggerHidden]
		public <Run>c__Iterator0()
		{
		}

		// Token: 0x06006781 RID: 26497 RVA: 0x001B22E0 File Offset: 0x001B06E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!this.MetRequirement(evt))
				{
					goto IL_18F;
				}
				talk = this.UnitTalkses[evt.EventType].First((UnitTalks t) => t.UnitClass == evt.EventTriggeringUnit.GetUnitType());
				if ((double)UnityEngine.Random.value > talk.ChanceOfTalk)
				{
					goto IL_18F;
				}
				selectedDialog = talk.DialogIdentifiers[UnityEngine.Random.Range(0, talk.DialogIdentifiers.Count)];
				enumerator = evt.EventTriggeringUnit.Speaks(selectedDialog).GetEnumerator();
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
			IL_18F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015B5 RID: 5557
		// (get) Token: 0x06006782 RID: 26498 RVA: 0x001B2498 File Offset: 0x001B0898
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015B6 RID: 5558
		// (get) Token: 0x06006783 RID: 26499 RVA: 0x001B24A0 File Offset: 0x001B08A0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006784 RID: 26500 RVA: 0x001B24A8 File Offset: 0x001B08A8
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

		// Token: 0x06006785 RID: 26501 RVA: 0x001B2518 File Offset: 0x001B0918
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006786 RID: 26502 RVA: 0x001B251F File Offset: 0x001B091F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006787 RID: 26503 RVA: 0x001B2528 File Offset: 0x001B0928
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitEventTriggeredGuarranteedTalks.<Run>c__Iterator0 <Run>c__Iterator = new UnitEventTriggeredGuarranteedTalks.<Run>c__Iterator0();
			<Run>c__Iterator.$this = this;
			<Run>c__Iterator.evt = evt;
			return <Run>c__Iterator;
		}

		// Token: 0x04006176 RID: 24950
		internal BroadcastEvent evt;

		// Token: 0x04006177 RID: 24951
		internal UnitTalks <talk>__1;

		// Token: 0x04006178 RID: 24952
		internal DialogIdentifier <selectedDialog>__2;

		// Token: 0x04006179 RID: 24953
		internal IEnumerator $locvar0;

		// Token: 0x0400617A RID: 24954
		internal object <_>__3;

		// Token: 0x0400617B RID: 24955
		internal IDisposable $locvar1;

		// Token: 0x0400617C RID: 24956
		internal UnitEventTriggeredGuarranteedTalks $this;

		// Token: 0x0400617D RID: 24957
		internal object $current;

		// Token: 0x0400617E RID: 24958
		internal bool $disposing;

		// Token: 0x0400617F RID: 24959
		internal int $PC;

		// Token: 0x04006180 RID: 24960
		private UnitEventTriggeredGuarranteedTalks.<Run>c__Iterator0.<Run>c__AnonStorey2 $locvar2;

		// Token: 0x02000FF9 RID: 4089
		private sealed class <Run>c__AnonStorey2
		{
			// Token: 0x06006788 RID: 26504 RVA: 0x001B2568 File Offset: 0x001B0968
			public <Run>c__AnonStorey2()
			{
			}

			// Token: 0x06006789 RID: 26505 RVA: 0x001B2570 File Offset: 0x001B0970
			internal bool <>m__0(UnitTalks t)
			{
				return t.UnitClass == this.evt.EventTriggeringUnit.GetUnitType();
			}

			// Token: 0x04006181 RID: 24961
			internal BroadcastEvent evt;

			// Token: 0x04006182 RID: 24962
			internal UnitEventTriggeredGuarranteedTalks.<Run>c__Iterator0 <>f__ref$0;
		}
	}
}
