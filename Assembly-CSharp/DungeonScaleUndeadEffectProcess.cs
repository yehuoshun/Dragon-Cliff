using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D6 RID: 2262
public class DungeonScaleUndeadEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F7C RID: 16252 RVA: 0x00191644 File Offset: 0x0018FA44
	public DungeonScaleUndeadEffectProcess()
	{
	}

	// Token: 0x17000B6E RID: 2926
	// (get) Token: 0x06003F7D RID: 16253 RVA: 0x00191654 File Offset: 0x0018FA54
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B6F RID: 2927
	// (get) Token: 0x06003F7E RID: 16254 RVA: 0x0019165C File Offset: 0x0018FA5C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts,
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x06003F7F RID: 16255 RVA: 0x00191680 File Offset: 0x0018FA80
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			DungeonScaleUndeadEffectData dungeonScaleUndeadEffectData = specialEffectData as DungeonScaleUndeadEffectData;
			if (dungeonScaleUndeadEffectData != null)
			{
				dungeonScaleUndeadEffectData.RevivedUnitsInCurrentEncounter = new List<IBattleUnit>();
			}
		}
		if (evt.EventType == AdventureEventType.UnitPreKilled && !evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit.HealthPoints <= 0.0)
		{
			DungeonScaleUndeadEffectData data = specialEffectData as DungeonScaleUndeadEffectData;
			if (data != null && data.RevivedUnitsInCurrentEncounter.All((IBattleUnit u) => u != evt.EventTriggeringUnit))
			{
				data.RevivedUnitsInCurrentEncounter.Add(evt.EventTriggeringUnit);
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, evt.EventTriggeringUnit);
				IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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

	// Token: 0x04002F7F RID: 12159
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DungeonScaleUndeadEffect;

	// Token: 0x02000F54 RID: 3924
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600633D RID: 25405 RVA: 0x001916AA File Offset: 0x0018FAAA
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600633E RID: 25406 RVA: 0x001916B4 File Offset: 0x0018FAB4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType == AdventureEventType.BattleEncounterStarts)
				{
					DungeonScaleUndeadEffectData dungeonScaleUndeadEffectData = specialEffectData as DungeonScaleUndeadEffectData;
					if (dungeonScaleUndeadEffectData != null)
					{
						dungeonScaleUndeadEffectData.RevivedUnitsInCurrentEncounter = new List<IBattleUnit>();
					}
				}
				if (evt.EventType != AdventureEventType.UnitPreKilled || evt.EventTriggeringUnit.IsPlayer || evt.EventTriggeringUnit.HealthPoints > 0.0)
				{
					goto IL_273;
				}
				data = (specialEffectData as DungeonScaleUndeadEffectData);
				if (data == null || !data.RevivedUnitsInCurrentEncounter.All((IBattleUnit u) => u != evt.EventTriggeringUnit))
				{
					goto IL_273;
				}
				data.RevivedUnitsInCurrentEncounter.Add(evt.EventTriggeringUnit);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, evt.EventTriggeringUnit);
				enumerator = releaseableHeal.Release().GetEnumerator();
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
			IL_273:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014C7 RID: 5319
		// (get) Token: 0x0600633F RID: 25407 RVA: 0x00191950 File Offset: 0x0018FD50
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014C8 RID: 5320
		// (get) Token: 0x06006340 RID: 25408 RVA: 0x00191958 File Offset: 0x0018FD58
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006341 RID: 25409 RVA: 0x00191960 File Offset: 0x0018FD60
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

		// Token: 0x06006342 RID: 25410 RVA: 0x001919D0 File Offset: 0x0018FDD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006343 RID: 25411 RVA: 0x001919D7 File Offset: 0x0018FDD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006344 RID: 25412 RVA: 0x001919E0 File Offset: 0x0018FDE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DungeonScaleUndeadEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new DungeonScaleUndeadEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005A63 RID: 23139
		internal BroadcastEvent evt;

		// Token: 0x04005A64 RID: 23140
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A65 RID: 23141
		internal DungeonScaleUndeadEffectData <data>__1;

		// Token: 0x04005A66 RID: 23142
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x04005A67 RID: 23143
		internal IEnumerator $locvar0;

		// Token: 0x04005A68 RID: 23144
		internal object <_>__3;

		// Token: 0x04005A69 RID: 23145
		internal IDisposable $locvar1;

		// Token: 0x04005A6A RID: 23146
		internal object $current;

		// Token: 0x04005A6B RID: 23147
		internal bool $disposing;

		// Token: 0x04005A6C RID: 23148
		internal int $PC;

		// Token: 0x04005A6D RID: 23149
		private DungeonScaleUndeadEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000F55 RID: 3925
		private sealed class <AsAdventureEffectProcess>c__AnonStorey1
		{
			// Token: 0x06006345 RID: 25413 RVA: 0x00191A20 File Offset: 0x0018FE20
			public <AsAdventureEffectProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006346 RID: 25414 RVA: 0x00191A28 File Offset: 0x0018FE28
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.evt.EventTriggeringUnit;
			}

			// Token: 0x04005A6E RID: 23150
			internal BroadcastEvent evt;

			// Token: 0x04005A6F RID: 23151
			internal DungeonScaleUndeadEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
