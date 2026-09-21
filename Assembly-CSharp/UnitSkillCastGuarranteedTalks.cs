using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000971 RID: 2417
public class UnitSkillCastGuarranteedTalks : GenericBattleSequenceBase
{
	// Token: 0x0600427E RID: 17022 RVA: 0x001B25C5 File Offset: 0x001B09C5
	public UnitSkillCastGuarranteedTalks()
	{
	}

	// Token: 0x17000D17 RID: 3351
	// (get) Token: 0x0600427F RID: 17023 RVA: 0x001B25D0 File Offset: 0x001B09D0
	public Dictionary<UnitClass, AdventurerSkillTalk> AdventurerSkillTalks
	{
		get
		{
			return new Dictionary<UnitClass, AdventurerSkillTalk>
			{
				{
					UnitClass.Death,
					new AdventurerSkillTalk
					{
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.DeathShadowSacrifice_c1,
							DialogIdentifier.DeathShadowSacrifice_c2,
							DialogIdentifier.DeathShadowSacrifice_c3
						},
						SkillType = new SkillType?(SkillType.ShadowSacrifice),
						RequiredLevel = null
					}
				},
				{
					UnitClass.LavaBeast,
					new AdventurerSkillTalk
					{
						SkillType = null,
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.Lava_Boss_c1,
							DialogIdentifier.Lava_Boss_c2,
							DialogIdentifier.Lava_Boss_c3
						},
						RequiredLevel = null
					}
				},
				{
					UnitClass.PurpleOrc,
					new AdventurerSkillTalk
					{
						SkillType = null,
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.Main_1_6_Boss_c1,
							DialogIdentifier.Main_1_6_Boss_c2
						},
						RequiredLevel = null
					}
				},
				{
					UnitClass.Pharmacist,
					new AdventurerSkillTalk
					{
						SkillType = null,
						DialogIdentifiers = new List<DialogIdentifier>
						{
							DialogIdentifier.Main_2_1_Boss_c2,
							DialogIdentifier.Main_2_1_Boss_c3
						},
						RequiredLevel = null
					}
				}
			};
		}
	}

	// Token: 0x06004280 RID: 17024 RVA: 0x001B274C File Offset: 0x001B0B4C
	public override bool MetRequirement(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitCastsSkill && this.AdventurerSkillTalks.ContainsKey(evt.EventTriggeringUnit.GetUnitType()))
		{
			SkillCastBattleEvent skillCastBattleEvent = evt.AdditionalData as SkillCastBattleEvent;
			AdventurerSkillTalk adventurerSkillTalk = this.AdventurerSkillTalks[evt.EventTriggeringUnit.GetUnitType()];
			if (skillCastBattleEvent != null && (adventurerSkillTalk.SkillType == null || skillCastBattleEvent.Skill.Skill.SkillType == adventurerSkillTalk.SkillType) && (adventurerSkillTalk.RequiredLevel == null || skillCastBattleEvent.Skill.Skill.Level == adventurerSkillTalk.RequiredLevel.Value))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004281 RID: 17025 RVA: 0x001B2828 File Offset: 0x001B0C28
	public override IEnumerable Run(BroadcastEvent evt)
	{
		AdventurerSkillTalk dialogs = this.AdventurerSkillTalks[evt.EventTriggeringUnit.GetUnitType()];
		DialogIdentifier selected = dialogs.DialogIdentifiers[UnityEngine.Random.Range(0, dialogs.DialogIdentifiers.Count)];
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
		yield break;
	}

	// Token: 0x02000FFA RID: 4090
	[CompilerGenerated]
	private sealed class <Run>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600678A RID: 26506 RVA: 0x001B2852 File Offset: 0x001B0C52
		[DebuggerHidden]
		public <Run>c__Iterator0()
		{
		}

		// Token: 0x0600678B RID: 26507 RVA: 0x001B285C File Offset: 0x001B0C5C
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015B7 RID: 5559
		// (get) Token: 0x0600678C RID: 26508 RVA: 0x001B29A0 File Offset: 0x001B0DA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015B8 RID: 5560
		// (get) Token: 0x0600678D RID: 26509 RVA: 0x001B29A8 File Offset: 0x001B0DA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600678E RID: 26510 RVA: 0x001B29B0 File Offset: 0x001B0DB0
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

		// Token: 0x0600678F RID: 26511 RVA: 0x001B2A20 File Offset: 0x001B0E20
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006790 RID: 26512 RVA: 0x001B2A27 File Offset: 0x001B0E27
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006791 RID: 26513 RVA: 0x001B2A30 File Offset: 0x001B0E30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitSkillCastGuarranteedTalks.<Run>c__Iterator0 <Run>c__Iterator = new UnitSkillCastGuarranteedTalks.<Run>c__Iterator0();
			<Run>c__Iterator.$this = this;
			<Run>c__Iterator.evt = evt;
			return <Run>c__Iterator;
		}

		// Token: 0x04006183 RID: 24963
		internal BroadcastEvent evt;

		// Token: 0x04006184 RID: 24964
		internal AdventurerSkillTalk <dialogs>__0;

		// Token: 0x04006185 RID: 24965
		internal DialogIdentifier <selected>__0;

		// Token: 0x04006186 RID: 24966
		internal IEnumerator $locvar0;

		// Token: 0x04006187 RID: 24967
		internal object <_>__1;

		// Token: 0x04006188 RID: 24968
		internal IDisposable $locvar1;

		// Token: 0x04006189 RID: 24969
		internal UnitSkillCastGuarranteedTalks $this;

		// Token: 0x0400618A RID: 24970
		internal object $current;

		// Token: 0x0400618B RID: 24971
		internal bool $disposing;

		// Token: 0x0400618C RID: 24972
		internal int $PC;
	}
}
