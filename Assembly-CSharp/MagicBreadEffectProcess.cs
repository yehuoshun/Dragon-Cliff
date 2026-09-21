using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000905 RID: 2309
public class MagicBreadEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600404B RID: 16459 RVA: 0x0019D434 File Offset: 0x0019B834
	public MagicBreadEffectProcess()
	{
	}

	// Token: 0x17000BCA RID: 3018
	// (get) Token: 0x0600404C RID: 16460 RVA: 0x0019D444 File Offset: 0x0019B844
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BCB RID: 3019
	// (get) Token: 0x0600404D RID: 16461 RVA: 0x0019D44C File Offset: 0x0019B84C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x0600404E RID: 16462 RVA: 0x0019D468 File Offset: 0x0019B868
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
			MagicBreadEffectdata data = specialEffectData as MagicBreadEffectdata;
			if (battleEncounter != null && data != null)
			{
				IEnumerator enumerator = battleEncounter.UpdatePlayerGauge(data.RageOnStart, evt.EventTriggeringUnit).GetEnumerator();
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
				foreach (IBattleUnit battleUnit in battleEncounter.PlayerUnits)
				{
					AdventureUnitSkill adventureUnitSkill = battleUnit.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.CommandType == SkillCommandType.Active);
					if (adventureUnitSkill != null && adventureUnitSkill.RemainingCoolingDownSeconds != null)
					{
						adventureUnitSkill.RemainingCoolingDownSeconds = new float?(adventureUnitSkill.RemainingCoolingDownSeconds.Value - Convert.ToSingle(data.CoolingDownReductionOnStart));
						if (adventureUnitSkill.RemainingCoolingDownSeconds < 0f)
						{
							adventureUnitSkill.RemainingCoolingDownSeconds = new float?(0f);
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F9E RID: 12190
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.MagicBreadEffect;

	// Token: 0x02000F92 RID: 3986
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060064E8 RID: 25832 RVA: 0x0019D492 File Offset: 0x0019B892
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060064E9 RID: 25833 RVA: 0x0019D49C File Offset: 0x0019B89C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.BattleEncounterStarts)
				{
					goto IL_21D;
				}
				battleEncounter = (evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter);
				data = (specialEffectData as MagicBreadEffectdata);
				if (battleEncounter == null || data == null)
				{
					goto IL_21D;
				}
				enumerator = battleEncounter.UpdatePlayerGauge(data.RageOnStart, evt.EventTriggeringUnit).GetEnumerator();
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
			enumerator2 = battleEncounter.PlayerUnits.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					IBattleUnit battleUnit = enumerator2.Current;
					AdventureUnitSkill adventureUnitSkill = battleUnit.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.CommandType == SkillCommandType.Active);
					if (adventureUnitSkill != null && adventureUnitSkill.RemainingCoolingDownSeconds != null)
					{
						adventureUnitSkill.RemainingCoolingDownSeconds = new float?(adventureUnitSkill.RemainingCoolingDownSeconds.Value - Convert.ToSingle(data.CoolingDownReductionOnStart));
						if (adventureUnitSkill.RemainingCoolingDownSeconds < 0f)
						{
							adventureUnitSkill.RemainingCoolingDownSeconds = new float?(0f);
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			IL_21D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001523 RID: 5411
		// (get) Token: 0x060064EA RID: 25834 RVA: 0x0019D6EC File Offset: 0x0019BAEC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001524 RID: 5412
		// (get) Token: 0x060064EB RID: 25835 RVA: 0x0019D6F4 File Offset: 0x0019BAF4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060064EC RID: 25836 RVA: 0x0019D6FC File Offset: 0x0019BAFC
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

		// Token: 0x060064ED RID: 25837 RVA: 0x0019D76C File Offset: 0x0019BB6C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064EE RID: 25838 RVA: 0x0019D773 File Offset: 0x0019BB73
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060064EF RID: 25839 RVA: 0x0019D77C File Offset: 0x0019BB7C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MagicBreadEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new MagicBreadEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060064F0 RID: 25840 RVA: 0x0019D7BC File Offset: 0x0019BBBC
		private static bool <>m__0(AdventureUnitSkill s)
		{
			return s.Skill.CommandType == SkillCommandType.Active;
		}

		// Token: 0x04005D2F RID: 23855
		internal BroadcastEvent evt;

		// Token: 0x04005D30 RID: 23856
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04005D31 RID: 23857
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D32 RID: 23858
		internal MagicBreadEffectdata <data>__1;

		// Token: 0x04005D33 RID: 23859
		internal IEnumerator $locvar0;

		// Token: 0x04005D34 RID: 23860
		internal object <_>__2;

		// Token: 0x04005D35 RID: 23861
		internal IDisposable $locvar1;

		// Token: 0x04005D36 RID: 23862
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04005D37 RID: 23863
		internal object $current;

		// Token: 0x04005D38 RID: 23864
		internal bool $disposing;

		// Token: 0x04005D39 RID: 23865
		internal int $PC;

		// Token: 0x04005D3A RID: 23866
		private static Func<AdventureUnitSkill, bool> <>f__am$cache0;
	}
}
