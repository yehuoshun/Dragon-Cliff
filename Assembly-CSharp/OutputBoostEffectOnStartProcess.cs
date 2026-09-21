using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000909 RID: 2313
public class OutputBoostEffectOnStartProcess : SpecialEffectProcessBase
{
	// Token: 0x0600405B RID: 16475 RVA: 0x0019DE84 File Offset: 0x0019C284
	public OutputBoostEffectOnStartProcess()
	{
	}

	// Token: 0x17000BD2 RID: 3026
	// (get) Token: 0x0600405C RID: 16476 RVA: 0x0019DE8C File Offset: 0x0019C28C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.OutputBoostOnStart;
		}
	}

	// Token: 0x17000BD3 RID: 3027
	// (get) Token: 0x0600405D RID: 16477 RVA: 0x0019DE90 File Offset: 0x0019C290
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x0600405E RID: 16478 RVA: 0x0019DEAC File Offset: 0x0019C2AC
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit.IsAliveInBattle() && specialEffectData is OutputBoostOnStartData)
		{
			OutputBoostOnStartData data = specialEffectData as OutputBoostOnStartData;
			IEnumerator enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = evt.EventTriggeringUnit.GetOutputAttributeType(),
					ModificationType = data.ModificationType,
					Value = data.Value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "outputboostonstart", new int?(1), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x02000F96 RID: 3990
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600650A RID: 25866 RVA: 0x0019DED6 File Offset: 0x0019C2D6
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600650B RID: 25867 RVA: 0x0019DEE0 File Offset: 0x0019C2E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitReadyInBattle || !evt.EventTriggeringUnit.IsPlayer || !evt.EventTriggeringUnit.IsAliveInBattle() || !(specialEffectData is OutputBoostOnStartData))
				{
					goto IL_1B3;
				}
				data = (specialEffectData as OutputBoostOnStartData);
				enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = evt.EventTriggeringUnit.GetOutputAttributeType(),
						ModificationType = data.ModificationType,
						Value = data.Value,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "outputboostonstart", new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			IL_1B3:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700152B RID: 5419
		// (get) Token: 0x0600650C RID: 25868 RVA: 0x0019E0BC File Offset: 0x0019C4BC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700152C RID: 5420
		// (get) Token: 0x0600650D RID: 25869 RVA: 0x0019E0C4 File Offset: 0x0019C4C4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600650E RID: 25870 RVA: 0x0019E0CC File Offset: 0x0019C4CC
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

		// Token: 0x0600650F RID: 25871 RVA: 0x0019E13C File Offset: 0x0019C53C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006510 RID: 25872 RVA: 0x0019E143 File Offset: 0x0019C543
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006511 RID: 25873 RVA: 0x0019E14C File Offset: 0x0019C54C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			OutputBoostEffectOnStartProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new OutputBoostEffectOnStartProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005D59 RID: 23897
		internal BroadcastEvent evt;

		// Token: 0x04005D5A RID: 23898
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D5B RID: 23899
		internal OutputBoostOnStartData <data>__1;

		// Token: 0x04005D5C RID: 23900
		internal IEnumerator $locvar0;

		// Token: 0x04005D5D RID: 23901
		internal object <_>__2;

		// Token: 0x04005D5E RID: 23902
		internal IDisposable $locvar1;

		// Token: 0x04005D5F RID: 23903
		internal object $current;

		// Token: 0x04005D60 RID: 23904
		internal bool $disposing;

		// Token: 0x04005D61 RID: 23905
		internal int $PC;
	}
}
