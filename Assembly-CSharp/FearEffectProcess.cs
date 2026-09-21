using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008E7 RID: 2279
public class FearEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FC5 RID: 16325 RVA: 0x00195113 File Offset: 0x00193513
	public FearEffectProcess()
	{
	}

	// Token: 0x17000B90 RID: 2960
	// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x0019511B File Offset: 0x0019351B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Fear;
		}
	}

	// Token: 0x17000B91 RID: 2961
	// (get) Token: 0x06003FC7 RID: 16327 RVA: 0x00195120 File Offset: 0x00193520
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.DamageReleased
			};
		}
	}

	// Token: 0x06003FC8 RID: 16328 RVA: 0x0019513C File Offset: 0x0019353C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage && specialEffectData is FearData)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			FearData data = specialEffectData as FearData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed) && (double)UnityEngine.Random.value <= data.Chance)
				{
					IEnumerator enumerator2 = LockTimeEffect.AddFearSeconds(damageBattleDamage.Target, (float)data.NumberOfSeconds, effectCarrier, false).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _ = enumerator2.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F67 RID: 3943
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063C3 RID: 25539 RVA: 0x0019517D File Offset: 0x0019357D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063C4 RID: 25540 RVA: 0x00195188 File Offset: 0x00193588
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(evtData is ReleaseableDamage) || !(specialEffectData is FearData))
				{
					goto IL_1E4;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as FearData);
				enumerator = damage.BattleDamages.GetEnumerator();
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
				case 1u:
					Block_11:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed) && (double)UnityEngine.Random.value <= data.Chance)
					{
						enumerator2 = LockTimeEffect.AddFearSeconds(damageBattleDamage.Target, (float)data.NumberOfSeconds, effectCarrier, false).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1E4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014E3 RID: 5347
		// (get) Token: 0x060063C5 RID: 25541 RVA: 0x001953B8 File Offset: 0x001937B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014E4 RID: 5348
		// (get) Token: 0x060063C6 RID: 25542 RVA: 0x001953C0 File Offset: 0x001937C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063C7 RID: 25543 RVA: 0x001953C8 File Offset: 0x001937C8
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
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060063C8 RID: 25544 RVA: 0x0019545C File Offset: 0x0019385C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063C9 RID: 25545 RVA: 0x00195463 File Offset: 0x00193863
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063CA RID: 25546 RVA: 0x0019546C File Offset: 0x0019386C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FearEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FearEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060063CB RID: 25547 RVA: 0x001954D0 File Offset: 0x001938D0
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005B3B RID: 23355
		internal AdventureEventType evtType;

		// Token: 0x04005B3C RID: 23356
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B3D RID: 23357
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B3E RID: 23358
		internal object evtData;

		// Token: 0x04005B3F RID: 23359
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B40 RID: 23360
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005B41 RID: 23361
		internal FearData <data>__1;

		// Token: 0x04005B42 RID: 23362
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005B43 RID: 23363
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005B44 RID: 23364
		internal IEnumerator $locvar1;

		// Token: 0x04005B45 RID: 23365
		internal object <_>__3;

		// Token: 0x04005B46 RID: 23366
		internal IDisposable $locvar2;

		// Token: 0x04005B47 RID: 23367
		internal object $current;

		// Token: 0x04005B48 RID: 23368
		internal bool $disposing;

		// Token: 0x04005B49 RID: 23369
		internal int $PC;

		// Token: 0x04005B4A RID: 23370
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
