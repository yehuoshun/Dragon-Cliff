using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008A8 RID: 2216
public class AdventureEnergyRecollectionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EAE RID: 16046 RVA: 0x00182B68 File Offset: 0x00180F68
	public AdventureEnergyRecollectionEffectProcess()
	{
	}

	// Token: 0x17000B12 RID: 2834
	// (get) Token: 0x06003EAF RID: 16047 RVA: 0x00182B9B File Offset: 0x00180F9B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B13 RID: 2835
	// (get) Token: 0x06003EB0 RID: 16048 RVA: 0x00182BA3 File Offset: 0x00180FA3
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003EB1 RID: 16049 RVA: 0x00182BAC File Offset: 0x00180FAC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType != AdventureEventType.UnitKilled)
		{
			yield break;
		}
		if (triggerUnit.IsPlayer)
		{
			yield break;
		}
		if (effectCarrier.GetUnitClassStyle() != UnitClassStyle.PhysicalWarrior)
		{
			if (effectCarrier.GetUnitClassStyle() != UnitClassStyle.SpellWarrior)
			{
				yield break;
			}
		}
		if (!(evtData is BattleDamage))
		{
			yield break;
		}
		if (!(specialEffectData is AdventureEnergyRecollectionData))
		{
			yield break;
		}
		BattleDamage battleDamage = evtData as BattleDamage;
		if (battleDamage.Dealer.IsPlayer)
		{
			AdventureEnergyRecollectionData adventureEnergyRecollectionData = specialEffectData as AdventureEnergyRecollectionData;
			Adventure currentAdventure = triggerUnit.CurrentAdventure;
			double? actionCountSoFar = currentAdventure.ActionCountSoFar;
			currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() - (double)adventureEnergyRecollectionData.NumberOfRecollection));
			yield break;
		}
		yield break;
	}

	// Token: 0x04002F62 RID: 12130
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.AdventureEnergyRecollection;

	// Token: 0x04002F63 RID: 12131
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitKilled
	};

	// Token: 0x02000F0E RID: 3854
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006157 RID: 24919 RVA: 0x00182BED File Offset: 0x00180FED
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006158 RID: 24920 RVA: 0x00182BF8 File Offset: 0x00180FF8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag && evtType == AdventureEventType.UnitKilled && !triggerUnit.IsPlayer && (effectCarrier.GetUnitClassStyle() == UnitClassStyle.PhysicalWarrior || effectCarrier.GetUnitClassStyle() == UnitClassStyle.SpellWarrior) && evtData is BattleDamage && specialEffectData is AdventureEnergyRecollectionData)
			{
				BattleDamage battleDamage = evtData as BattleDamage;
				if (battleDamage.Dealer.IsPlayer)
				{
					AdventureEnergyRecollectionData adventureEnergyRecollectionData = specialEffectData as AdventureEnergyRecollectionData;
					Adventure currentAdventure = triggerUnit.CurrentAdventure;
					double? actionCountSoFar = currentAdventure.ActionCountSoFar;
					currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() - (double)adventureEnergyRecollectionData.NumberOfRecollection));
				}
			}
			return false;
		}

		// Token: 0x17001462 RID: 5218
		// (get) Token: 0x06006159 RID: 24921 RVA: 0x00182CE6 File Offset: 0x001810E6
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001463 RID: 5219
		// (get) Token: 0x0600615A RID: 24922 RVA: 0x00182CEE File Offset: 0x001810EE
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600615B RID: 24923 RVA: 0x00182CF6 File Offset: 0x001810F6
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600615C RID: 24924 RVA: 0x00182CF8 File Offset: 0x001810F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600615D RID: 24925 RVA: 0x00182CFF File Offset: 0x001810FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600615E RID: 24926 RVA: 0x00182D08 File Offset: 0x00181108
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AdventureEnergyRecollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new AdventureEnergyRecollectionEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040056F9 RID: 22265
		internal AdventureEventType evtType;

		// Token: 0x040056FA RID: 22266
		internal IBattleUnit triggerUnit;

		// Token: 0x040056FB RID: 22267
		internal IBattleUnit effectCarrier;

		// Token: 0x040056FC RID: 22268
		internal object evtData;

		// Token: 0x040056FD RID: 22269
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040056FE RID: 22270
		internal object $current;

		// Token: 0x040056FF RID: 22271
		internal bool $disposing;

		// Token: 0x04005700 RID: 22272
		internal int $PC;
	}
}
