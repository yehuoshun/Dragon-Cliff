using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200091F RID: 2335
public class ShadowOfGhostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040BD RID: 16573 RVA: 0x001A36CD File Offset: 0x001A1ACD
	public ShadowOfGhostEffectProcess()
	{
	}

	// Token: 0x17000BFF RID: 3071
	// (get) Token: 0x060040BE RID: 16574 RVA: 0x001A36D5 File Offset: 0x001A1AD5
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ShadowOfGhost;
		}
	}

	// Token: 0x17000C00 RID: 3072
	// (get) Token: 0x060040BF RID: 16575 RVA: 0x001A36DC File Offset: 0x001A1ADC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x060040C0 RID: 16576 RVA: 0x001A36F8 File Offset: 0x001A1AF8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is ShadowOfGhostData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && damage.IsMissed)
			{
				ShadowOfGhostData data = specialEffectData as ShadowOfGhostData;
				IEnumerator enumerator = DamageOverTimeEffect.AddDamageOverSecond(damage.Dealer, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamageRate, data.Seconds, effectCarrier.GetOutputType()).GetEnumerator();
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

	// Token: 0x02000FB3 RID: 4019
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065C9 RID: 26057 RVA: 0x001A3739 File Offset: 0x001A1B39
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065CA RID: 26058 RVA: 0x001A3744 File Offset: 0x001A1B44
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is ShadowOfGhostData))
				{
					goto IL_17C;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || !damage.IsMissed)
				{
					goto IL_17C;
				}
				data = (specialEffectData as ShadowOfGhostData);
				enumerator = DamageOverTimeEffect.AddDamageOverSecond(damage.Dealer, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data.DamageRate, data.Seconds, effectCarrier.GetOutputType()).GetEnumerator();
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
			IL_17C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001555 RID: 5461
		// (get) Token: 0x060065CB RID: 26059 RVA: 0x001A38E8 File Offset: 0x001A1CE8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001556 RID: 5462
		// (get) Token: 0x060065CC RID: 26060 RVA: 0x001A38F0 File Offset: 0x001A1CF0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065CD RID: 26061 RVA: 0x001A38F8 File Offset: 0x001A1CF8
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

		// Token: 0x060065CE RID: 26062 RVA: 0x001A3968 File Offset: 0x001A1D68
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065CF RID: 26063 RVA: 0x001A396F File Offset: 0x001A1D6F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065D0 RID: 26064 RVA: 0x001A3978 File Offset: 0x001A1D78
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShadowOfGhostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ShadowOfGhostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005EA6 RID: 24230
		internal AdventureEventType evtType;

		// Token: 0x04005EA7 RID: 24231
		internal IBattleUnit triggerUnit;

		// Token: 0x04005EA8 RID: 24232
		internal IBattleUnit effectCarrier;

		// Token: 0x04005EA9 RID: 24233
		internal object evtData;

		// Token: 0x04005EAA RID: 24234
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005EAB RID: 24235
		internal DamageComponent <damage>__1;

		// Token: 0x04005EAC RID: 24236
		internal ShadowOfGhostData <data>__2;

		// Token: 0x04005EAD RID: 24237
		internal IEnumerator $locvar0;

		// Token: 0x04005EAE RID: 24238
		internal object <_>__3;

		// Token: 0x04005EAF RID: 24239
		internal IDisposable $locvar1;

		// Token: 0x04005EB0 RID: 24240
		internal object $current;

		// Token: 0x04005EB1 RID: 24241
		internal bool $disposing;

		// Token: 0x04005EB2 RID: 24242
		internal int $PC;
	}
}
