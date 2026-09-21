using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000911 RID: 2321
public class ProtectorsPrideEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004083 RID: 16515 RVA: 0x0019FDD9 File Offset: 0x0019E1D9
	public ProtectorsPrideEffectProcess()
	{
	}

	// Token: 0x17000BE3 RID: 3043
	// (get) Token: 0x06004084 RID: 16516 RVA: 0x0019FDE1 File Offset: 0x0019E1E1
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ProtectorsPride;
		}
	}

	// Token: 0x17000BE4 RID: 3044
	// (get) Token: 0x06004085 RID: 16517 RVA: 0x0019FDE8 File Offset: 0x0019E1E8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage
			};
		}
	}

	// Token: 0x06004086 RID: 16518 RVA: 0x0019FE0C File Offset: 0x0019E20C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit)
		{
			ProtectorsPrideEffectData data = specialEffectData as ProtectorsPrideEffectData;
			if (data != null)
			{
				for (int i = 0; i < data.ShieldCount; i++)
				{
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), effectCarrier, true), false).GetEnumerator();
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
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage && evtData is BattleDamage && specialEffectData is ProtectorsPrideEffectData)
		{
			BattleDamage damage = evtData as BattleDamage;
			ProtectorsPrideEffectData data2 = specialEffectData as ProtectorsPrideEffectData;
			if (damage.Target == effectCarrier)
			{
				if (damage.Damages.Any((DamageComponent d) => d.IsDirectDamage) && damage.Dealer.IsAliveInBattle() && (double)UnityEngine.Random.value <= data2.TauntChance)
				{
					IEnumerator enumerator2 = damage.Dealer.ApplySkillEffect(new TauntEffect(effectCarrier, damage.Dealer, effectCarrier, new int?(2), true), false).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F9E RID: 3998
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006547 RID: 25927 RVA: 0x0019FE4D File Offset: 0x0019E24D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006548 RID: 25928 RVA: 0x0019FE58 File Offset: 0x0019E258
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit)
				{
					goto IL_13F;
				}
				data = (specialEffectData as ProtectorsPrideEffectData);
				if (data == null)
				{
					goto IL_13F;
				}
				i = 0;
				break;
			case 1u:
				Block_5:
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
				i++;
				break;
			case 2u:
				Block_14:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_2C5;
			default:
				return false;
			}
			if (i < data.ShieldCount)
			{
				enumerator = effectCarrier.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), effectCarrier, true), false).GetEnumerator();
				num = 4294967293u;
				goto Block_5;
			}
			IL_13F:
			if (evtType == AdventureEventType.UnitPostReceivesDamage && evtData is BattleDamage && specialEffectData is ProtectorsPrideEffectData)
			{
				damage = (evtData as BattleDamage);
				data2 = (specialEffectData as ProtectorsPrideEffectData);
				if (damage.Target == effectCarrier)
				{
					if (damage.Damages.Any((DamageComponent d) => d.IsDirectDamage) && damage.Dealer.IsAliveInBattle() && (double)UnityEngine.Random.value <= data2.TauntChance)
					{
						enumerator2 = damage.Dealer.ApplySkillEffect(new TauntEffect(effectCarrier, damage.Dealer, effectCarrier, new int?(2), true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_14;
					}
				}
			}
			IL_2C5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001539 RID: 5433
		// (get) Token: 0x06006549 RID: 25929 RVA: 0x001A0150 File Offset: 0x0019E550
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700153A RID: 5434
		// (get) Token: 0x0600654A RID: 25930 RVA: 0x001A0158 File Offset: 0x0019E558
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600654B RID: 25931 RVA: 0x001A0160 File Offset: 0x0019E560
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600654C RID: 25932 RVA: 0x001A0210 File Offset: 0x0019E610
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600654D RID: 25933 RVA: 0x001A0217 File Offset: 0x0019E617
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600654E RID: 25934 RVA: 0x001A0220 File Offset: 0x0019E620
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectorsPrideEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ProtectorsPrideEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600654F RID: 25935 RVA: 0x001A0284 File Offset: 0x0019E684
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x04005DC6 RID: 24006
		internal AdventureEventType evtType;

		// Token: 0x04005DC7 RID: 24007
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DC8 RID: 24008
		internal IBattleUnit triggerUnit;

		// Token: 0x04005DC9 RID: 24009
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DCA RID: 24010
		internal ProtectorsPrideEffectData <data>__1;

		// Token: 0x04005DCB RID: 24011
		internal int <i>__2;

		// Token: 0x04005DCC RID: 24012
		internal IEnumerator $locvar0;

		// Token: 0x04005DCD RID: 24013
		internal object <_>__3;

		// Token: 0x04005DCE RID: 24014
		internal IDisposable $locvar1;

		// Token: 0x04005DCF RID: 24015
		internal object evtData;

		// Token: 0x04005DD0 RID: 24016
		internal BattleDamage <damage>__4;

		// Token: 0x04005DD1 RID: 24017
		internal ProtectorsPrideEffectData <data>__4;

		// Token: 0x04005DD2 RID: 24018
		internal IEnumerator $locvar2;

		// Token: 0x04005DD3 RID: 24019
		internal object <_>__5;

		// Token: 0x04005DD4 RID: 24020
		internal IDisposable $locvar3;

		// Token: 0x04005DD5 RID: 24021
		internal object $current;

		// Token: 0x04005DD6 RID: 24022
		internal bool $disposing;

		// Token: 0x04005DD7 RID: 24023
		internal int $PC;

		// Token: 0x04005DD8 RID: 24024
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
