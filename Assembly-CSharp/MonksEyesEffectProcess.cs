using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000908 RID: 2312
public class MonksEyesEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004057 RID: 16471 RVA: 0x0019DCDE File Offset: 0x0019C0DE
	public MonksEyesEffectProcess()
	{
	}

	// Token: 0x17000BD0 RID: 3024
	// (get) Token: 0x06004058 RID: 16472 RVA: 0x0019DCEE File Offset: 0x0019C0EE
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BD1 RID: 3025
	// (get) Token: 0x06004059 RID: 16473 RVA: 0x0019DCF8 File Offset: 0x0019C0F8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReceivesDamage_Single
			};
		}
	}

	// Token: 0x0600405A RID: 16474 RVA: 0x0019DD14 File Offset: 0x0019C114
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType != AdventureEventType.UnitReceivesDamage_Single)
		{
			yield break;
		}
		DamageComponent damageComponent = evtData as DamageComponent;
		MonksEyesData monksEyesData = specialEffectData as MonksEyesData;
		if (damageComponent == null)
		{
			yield break;
		}
		if (damageComponent.Target != effectCarrier)
		{
			yield break;
		}
		if (damageComponent.HasFullyNeutralized())
		{
			yield break;
		}
		if (monksEyesData == null)
		{
			yield break;
		}
		if (damageComponent.Dealer.BattleEffects.OfType<FocusEffect>().Any<FocusEffect>())
		{
			yield break;
		}
		double num = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * monksEyesData.MaxLoss;
		if (damageComponent.GetTotalDamageSoFar() > num)
		{
			damageComponent.UpdateMaximumPossibleDamage(num);
			yield break;
		}
		yield break;
	}

	// Token: 0x04002FA1 RID: 12193
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.MonksEyesEffect;

	// Token: 0x02000F95 RID: 3989
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006502 RID: 25858 RVA: 0x0019DD4E File Offset: 0x0019C14E
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006503 RID: 25859 RVA: 0x0019DD58 File Offset: 0x0019C158
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag && evtType == AdventureEventType.UnitReceivesDamage_Single)
			{
				DamageComponent damageComponent = evtData as DamageComponent;
				MonksEyesData monksEyesData = specialEffectData as MonksEyesData;
				if (damageComponent != null && damageComponent.Target == effectCarrier && !damageComponent.HasFullyNeutralized() && monksEyesData != null && !damageComponent.Dealer.BattleEffects.OfType<FocusEffect>().Any<FocusEffect>())
				{
					double num = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * monksEyesData.MaxLoss;
					if (damageComponent.GetTotalDamageSoFar() > num)
					{
						damageComponent.UpdateMaximumPossibleDamage(num);
					}
				}
			}
			return false;
		}

		// Token: 0x17001529 RID: 5417
		// (get) Token: 0x06006504 RID: 25860 RVA: 0x0019DE0B File Offset: 0x0019C20B
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700152A RID: 5418
		// (get) Token: 0x06006505 RID: 25861 RVA: 0x0019DE13 File Offset: 0x0019C213
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006506 RID: 25862 RVA: 0x0019DE1B File Offset: 0x0019C21B
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006507 RID: 25863 RVA: 0x0019DE1D File Offset: 0x0019C21D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006508 RID: 25864 RVA: 0x0019DE24 File Offset: 0x0019C224
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006509 RID: 25865 RVA: 0x0019DE2C File Offset: 0x0019C22C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			MonksEyesEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new MonksEyesEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D52 RID: 23890
		internal AdventureEventType evtType;

		// Token: 0x04005D53 RID: 23891
		internal object evtData;

		// Token: 0x04005D54 RID: 23892
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D55 RID: 23893
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D56 RID: 23894
		internal object $current;

		// Token: 0x04005D57 RID: 23895
		internal bool $disposing;

		// Token: 0x04005D58 RID: 23896
		internal int $PC;
	}
}
