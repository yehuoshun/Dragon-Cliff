using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008CE RID: 2254
public class DispelOnHealEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F5A RID: 16218 RVA: 0x0018F628 File Offset: 0x0018DA28
	public DispelOnHealEffectProcess()
	{
	}

	// Token: 0x17000B5E RID: 2910
	// (get) Token: 0x06003F5B RID: 16219 RVA: 0x0018F630 File Offset: 0x0018DA30
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DispelOnHeal;
		}
	}

	// Token: 0x17000B5F RID: 2911
	// (get) Token: 0x06003F5C RID: 16220 RVA: 0x0018F634 File Offset: 0x0018DA34
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesHeal
			};
		}
	}

	// Token: 0x06003F5D RID: 16221 RVA: 0x0018F650 File Offset: 0x0018DA50
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesHeal && evtData is BattleHeal && specialEffectData is DispelOnHealData)
		{
			BattleHeal heal = evtData as BattleHeal;
			int numberOfDirectheals = heal.Heals.Count((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized);
			if (numberOfDirectheals > 0)
			{
				DispelOnHealData data = specialEffectData as DispelOnHealData;
				int totalNumberOfDispels = numberOfDirectheals * data.NumberOfDispels;
				IEnumerator enumerator = UnitStyleConfigurationBase.DispelNegativeEffects(effectCarrier, new int?(totalNumberOfDispels)).GetEnumerator();
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

	// Token: 0x02000F4C RID: 3916
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062F5 RID: 25333 RVA: 0x0018F68A File Offset: 0x0018DA8A
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062F6 RID: 25334 RVA: 0x0018F694 File Offset: 0x0018DA94
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesHeal || !(evtData is BattleHeal) || !(specialEffectData is DispelOnHealData))
				{
					goto IL_16F;
				}
				heal = (evtData as BattleHeal);
				numberOfDirectheals = heal.Heals.Count((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized);
				if (numberOfDirectheals <= 0)
				{
					goto IL_16F;
				}
				data = (specialEffectData as DispelOnHealData);
				totalNumberOfDispels = numberOfDirectheals * data.NumberOfDispels;
				enumerator = UnitStyleConfigurationBase.DispelNegativeEffects(effectCarrier, new int?(totalNumberOfDispels)).GetEnumerator();
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
			IL_16F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014B7 RID: 5303
		// (get) Token: 0x060062F7 RID: 25335 RVA: 0x0018F82C File Offset: 0x0018DC2C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014B8 RID: 5304
		// (get) Token: 0x060062F8 RID: 25336 RVA: 0x0018F834 File Offset: 0x0018DC34
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062F9 RID: 25337 RVA: 0x0018F83C File Offset: 0x0018DC3C
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

		// Token: 0x060062FA RID: 25338 RVA: 0x0018F8AC File Offset: 0x0018DCAC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062FB RID: 25339 RVA: 0x0018F8B3 File Offset: 0x0018DCB3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062FC RID: 25340 RVA: 0x0018F8BC File Offset: 0x0018DCBC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DispelOnHealEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DispelOnHealEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060062FD RID: 25341 RVA: 0x0018F914 File Offset: 0x0018DD14
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal && !h.IsNeutralized;
		}

		// Token: 0x040059ED RID: 23021
		internal AdventureEventType evtType;

		// Token: 0x040059EE RID: 23022
		internal object evtData;

		// Token: 0x040059EF RID: 23023
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040059F0 RID: 23024
		internal BattleHeal <heal>__1;

		// Token: 0x040059F1 RID: 23025
		internal int <numberOfDirectheals>__1;

		// Token: 0x040059F2 RID: 23026
		internal DispelOnHealData <data>__2;

		// Token: 0x040059F3 RID: 23027
		internal int <totalNumberOfDispels>__2;

		// Token: 0x040059F4 RID: 23028
		internal IBattleUnit effectCarrier;

		// Token: 0x040059F5 RID: 23029
		internal IEnumerator $locvar0;

		// Token: 0x040059F6 RID: 23030
		internal object <_>__3;

		// Token: 0x040059F7 RID: 23031
		internal IDisposable $locvar1;

		// Token: 0x040059F8 RID: 23032
		internal object $current;

		// Token: 0x040059F9 RID: 23033
		internal bool $disposing;

		// Token: 0x040059FA RID: 23034
		internal int $PC;

		// Token: 0x040059FB RID: 23035
		private static Func<HealComponent, bool> <>f__am$cache0;
	}
}
