using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000972 RID: 2418
public class UnitSkillCastRandomTalks : GenericBattleSequenceBase
{
	// Token: 0x06004282 RID: 17026 RVA: 0x001B2A70 File Offset: 0x001B0E70
	public UnitSkillCastRandomTalks()
	{
	}

	// Token: 0x17000D18 RID: 3352
	// (get) Token: 0x06004283 RID: 17027 RVA: 0x001B2A78 File Offset: 0x001B0E78
	public Dictionary<UnitClass, AdventurerSkillTalk> AdventurerSkillTalks
	{
		get
		{
			return new Dictionary<UnitClass, AdventurerSkillTalk>
			{
				{
					UnitClass.FirePlayer,
					new AdventurerSkillTalk
					{
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.FirePlayerTactic_c1,
							DialogIdentifier.FirePlayerTactic_c2,
							DialogIdentifier.FirePlayerTactic_c3
						},
						SkillType = new SkillType?(SkillType.HeartlessFire),
						RequiredLevel = null
					}
				},
				{
					UnitClass.ElementalWizard,
					new AdventurerSkillTalk
					{
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.ElementWizardTactic_c1,
							DialogIdentifier.ElementWizardTactic_c2,
							DialogIdentifier.ElementWizardTactic_c3
						},
						SkillType = new SkillType?(SkillType.ArmorOfWind),
						RequiredLevel = null
					}
				}
			};
		}
	}

	// Token: 0x06004284 RID: 17028 RVA: 0x001B2B4C File Offset: 0x001B0F4C
	public override bool MetRequirement(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitCastsSkill && this.AdventurerSkillTalks.ContainsKey(evt.EventTriggeringUnit.GetUnitType()))
		{
			SkillCastBattleEvent skillCastBattleEvent = evt.AdditionalData as SkillCastBattleEvent;
			AdventurerSkillTalk adventurerSkillTalk = this.AdventurerSkillTalks[evt.EventTriggeringUnit.GetUnitType()];
			if (skillCastBattleEvent != null && (adventurerSkillTalk.SkillType == null || skillCastBattleEvent.Skill.Skill.SkillType == adventurerSkillTalk.SkillType) && (adventurerSkillTalk.RequiredLevel == null || skillCastBattleEvent.Skill.Skill.Level == adventurerSkillTalk.RequiredLevel.Value))
			{
				bool result = !this.HasRecentlyApplied;
				this.HasRecentlyApplied = false;
				return result;
			}
		}
		return false;
	}

	// Token: 0x06004285 RID: 17029 RVA: 0x001B2C3C File Offset: 0x001B103C
	public override IEnumerable Run(BroadcastEvent evt)
	{
		AdventurerSkillTalk dialogs = this.AdventurerSkillTalks[evt.EventTriggeringUnit.GetUnitType()];
		DialogIdentifier selected = dialogs.DialogIdentifiers[UnityEngine.Random.Range(0, dialogs.DialogIdentifiers.Count)];
		if ((double)UnityEngine.Random.value <= 0.4)
		{
			this.HasRecentlyApplied = true;
			IEnumerator enumerator = evt.EventTriggeringUnit.Speaks(selected).GetEnumerator();
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

	// Token: 0x040031CA RID: 12746
	private bool HasRecentlyApplied;

	// Token: 0x02000FFB RID: 4091
	[CompilerGenerated]
	private sealed class <Run>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006792 RID: 26514 RVA: 0x001B2C66 File Offset: 0x001B1066
		[DebuggerHidden]
		public <Run>c__Iterator0()
		{
		}

		// Token: 0x06006793 RID: 26515 RVA: 0x001B2C70 File Offset: 0x001B1070
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				dialogs = base.AdventurerSkillTalks[evt.EventTriggeringUnit.GetUnitType()];
				selected = dialogs.DialogIdentifiers[UnityEngine.Random.Range(0, dialogs.DialogIdentifiers.Count)];
				if ((double)UnityEngine.Random.value > 0.4)
				{
					goto IL_13B;
				}
				this.HasRecentlyApplied = true;
				enumerator = evt.EventTriggeringUnit.Speaks(selected).GetEnumerator();
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
			IL_13B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015B9 RID: 5561
		// (get) Token: 0x06006794 RID: 26516 RVA: 0x001B2DD4 File Offset: 0x001B11D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015BA RID: 5562
		// (get) Token: 0x06006795 RID: 26517 RVA: 0x001B2DDC File Offset: 0x001B11DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006796 RID: 26518 RVA: 0x001B2DE4 File Offset: 0x001B11E4
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

		// Token: 0x06006797 RID: 26519 RVA: 0x001B2E54 File Offset: 0x001B1254
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006798 RID: 26520 RVA: 0x001B2E5B File Offset: 0x001B125B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006799 RID: 26521 RVA: 0x001B2E64 File Offset: 0x001B1264
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitSkillCastRandomTalks.<Run>c__Iterator0 <Run>c__Iterator = new UnitSkillCastRandomTalks.<Run>c__Iterator0();
			<Run>c__Iterator.$this = this;
			<Run>c__Iterator.evt = evt;
			return <Run>c__Iterator;
		}

		// Token: 0x0400618D RID: 24973
		internal BroadcastEvent evt;

		// Token: 0x0400618E RID: 24974
		internal AdventurerSkillTalk <dialogs>__0;

		// Token: 0x0400618F RID: 24975
		internal DialogIdentifier <selected>__0;

		// Token: 0x04006190 RID: 24976
		internal IEnumerator $locvar0;

		// Token: 0x04006191 RID: 24977
		internal object <_>__1;

		// Token: 0x04006192 RID: 24978
		internal IDisposable $locvar1;

		// Token: 0x04006193 RID: 24979
		internal UnitSkillCastRandomTalks $this;

		// Token: 0x04006194 RID: 24980
		internal object $current;

		// Token: 0x04006195 RID: 24981
		internal bool $disposing;

		// Token: 0x04006196 RID: 24982
		internal int $PC;
	}
}
