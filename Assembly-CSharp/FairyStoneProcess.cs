using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008E5 RID: 2277
public class FairyStoneProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FBD RID: 16317 RVA: 0x001945B8 File Offset: 0x001929B8
	public FairyStoneProcess()
	{
	}

	// Token: 0x17000B8C RID: 2956
	// (get) Token: 0x06003FBE RID: 16318 RVA: 0x001945C8 File Offset: 0x001929C8
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B8D RID: 2957
	// (get) Token: 0x06003FBF RID: 16319 RVA: 0x001945D0 File Offset: 0x001929D0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.DamageReleaseProcessCompleted
			};
		}
	}

	// Token: 0x06003FC0 RID: 16320 RVA: 0x001945EC File Offset: 0x001929EC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleaseProcessCompleted)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			FairyStoneData data = specialEffectData as FairyStoneData;
			if (damage != null && data != null)
			{
				List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				if (damage.BattleDamages.Any(delegate(BattleDamage bd)
				{
					bool result;
					if (friendlyUnits.Any((IBattleUnit f) => f == bd.Target))
					{
						result = bd.Damages.Any((DamageComponent d) => d.IsDirectDamage);
					}
					else
					{
						result = false;
					}
					return result;
				}) && (double)UnityEngine.Random.value <= data.Chance && effectCarrier.CanAct() && effectCarrier.CanCast() && !effectCarrier.CurrentEncounter.IsWinningConditionMet())
				{
					IEnumerator enumerator = effectCarrier.DoTurn().GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F8A RID: 12170
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.FairyStoneEffect;

	// Token: 0x02000F62 RID: 3938
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063AB RID: 25515 RVA: 0x00194626 File Offset: 0x00192A26
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063AC RID: 25516 RVA: 0x00194630 File Offset: 0x00192A30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.DamageReleaseProcessCompleted)
				{
					goto IL_1A2;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as FairyStoneData);
				if (damage == null || data == null)
				{
					goto IL_1A2;
				}
				List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				if (!damage.BattleDamages.Any(delegate(BattleDamage bd)
				{
					bool result;
					if (friendlyUnits.Any((IBattleUnit f) => f == bd.Target))
					{
						result = bd.Damages.Any((DamageComponent d) => d.IsDirectDamage);
					}
					else
					{
						result = false;
					}
					return result;
				}) || (double)UnityEngine.Random.value > data.Chance || !effectCarrier.CanAct() || !effectCarrier.CanCast() || effectCarrier.CurrentEncounter.IsWinningConditionMet())
				{
					goto IL_1A2;
				}
				enumerator = effectCarrier.DoTurn().GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1A2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014DF RID: 5343
		// (get) Token: 0x060063AD RID: 25517 RVA: 0x001947FC File Offset: 0x00192BFC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014E0 RID: 5344
		// (get) Token: 0x060063AE RID: 25518 RVA: 0x00194804 File Offset: 0x00192C04
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063AF RID: 25519 RVA: 0x0019480C File Offset: 0x00192C0C
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

		// Token: 0x060063B0 RID: 25520 RVA: 0x0019487C File Offset: 0x00192C7C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063B1 RID: 25521 RVA: 0x00194883 File Offset: 0x00192C83
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063B2 RID: 25522 RVA: 0x0019488C File Offset: 0x00192C8C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FairyStoneProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FairyStoneProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B0D RID: 23309
		internal AdventureEventType evtType;

		// Token: 0x04005B0E RID: 23310
		internal object evtData;

		// Token: 0x04005B0F RID: 23311
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005B10 RID: 23312
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B11 RID: 23313
		internal FairyStoneData <data>__1;

		// Token: 0x04005B12 RID: 23314
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B13 RID: 23315
		internal IEnumerator $locvar0;

		// Token: 0x04005B14 RID: 23316
		internal object <_>__3;

		// Token: 0x04005B15 RID: 23317
		internal IDisposable $locvar1;

		// Token: 0x04005B16 RID: 23318
		internal object $current;

		// Token: 0x04005B17 RID: 23319
		internal bool $disposing;

		// Token: 0x04005B18 RID: 23320
		internal int $PC;

		// Token: 0x04005B19 RID: 23321
		private FairyStoneProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000F63 RID: 3939
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060063B3 RID: 25523 RVA: 0x001948E4 File Offset: 0x00192CE4
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060063B4 RID: 25524 RVA: 0x001948EC File Offset: 0x00192CEC
			internal bool <>m__0(BattleDamage bd)
			{
				bool result;
				if (this.friendlyUnits.Any((IBattleUnit f) => f == bd.Target))
				{
					result = bd.Damages.Any((DamageComponent d) => d.IsDirectDamage);
				}
				else
				{
					result = false;
				}
				return result;
			}

			// Token: 0x060063B5 RID: 25525 RVA: 0x00194959 File Offset: 0x00192D59
			private static bool <>m__1(DamageComponent d)
			{
				return d.IsDirectDamage;
			}

			// Token: 0x04005B1A RID: 23322
			internal List<IBattleUnit> friendlyUnits;

			// Token: 0x04005B1B RID: 23323
			internal FairyStoneProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005B1C RID: 23324
			private static Func<DamageComponent, bool> <>f__am$cache0;

			// Token: 0x02000F64 RID: 3940
			private sealed class <AsActiveUnitProcess>c__AnonStorey2
			{
				// Token: 0x060063B6 RID: 25526 RVA: 0x00194961 File Offset: 0x00192D61
				public <AsActiveUnitProcess>c__AnonStorey2()
				{
				}

				// Token: 0x060063B7 RID: 25527 RVA: 0x00194969 File Offset: 0x00192D69
				internal bool <>m__0(IBattleUnit f)
				{
					return f == this.bd.Target;
				}

				// Token: 0x04005B1D RID: 23325
				internal BattleDamage bd;

				// Token: 0x04005B1E RID: 23326
				internal FairyStoneProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 <>f__ref$1;
			}
		}
	}
}
