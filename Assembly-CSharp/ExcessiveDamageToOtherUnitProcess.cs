using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008E0 RID: 2272
public class ExcessiveDamageToOtherUnitProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FAA RID: 16298 RVA: 0x001935C4 File Offset: 0x001919C4
	public ExcessiveDamageToOtherUnitProcess()
	{
	}

	// Token: 0x17000B82 RID: 2946
	// (get) Token: 0x06003FAB RID: 16299 RVA: 0x001935CC File Offset: 0x001919CC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ExcessiveDamageToOtherUnit;
		}
	}

	// Token: 0x17000B83 RID: 2947
	// (get) Token: 0x06003FAC RID: 16300 RVA: 0x001935D0 File Offset: 0x001919D0
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

	// Token: 0x06003FAD RID: 16301 RVA: 0x001935EC File Offset: 0x001919EC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && specialEffectData is ExcessiveDamageToOtherUnitData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			List<BattleDamage> additionalDamages = new List<BattleDamage>();
			foreach (BattleDamage battleDamage in damage.BattleDamages)
			{
				if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && d.ExceededDamageValue > 0.0))
				{
					double valueOrDefault = (from d in battleDamage.Damages
					where d.IsDirectDamage && d.ExceededDamageValue > 0.0
					select d).Sum((DamageComponent d) => d.ExceededDamageValue).GetValueOrDefault();
					if (valueOrDefault > 0.0)
					{
						List<IBattleUnit> liveEnemyTargets = effectCarrier.GetLiveEnemyTargets(false, false);
						if (liveEnemyTargets.Any<IBattleUnit>())
						{
							IBattleUnit target = liveEnemyTargets[UnityEngine.Random.Range(0, liveEnemyTargets.Count)];
							BattleDamage item = new BattleDamage(target, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(target, effectCarrier, OutputType.RealDamage, valueOrDefault)
								}, target, effectCarrier, false, false)
							});
							additionalDamages.Add(item);
						}
					}
				}
			}
			if (additionalDamages.Any<BattleDamage>())
			{
				ReleaseableDamage releaseable = new ReleaseableDamage(additionalDamages, effectCarrier);
				IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000F5E RID: 3934
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006385 RID: 25477 RVA: 0x00193634 File Offset: 0x00191A34
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006386 RID: 25478 RVA: 0x0019363C File Offset: 0x00191A3C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(specialEffectData is ExcessiveDamageToOtherUnitData) || !(evtData is ReleaseableDamage))
				{
					goto IL_2BA;
				}
				damage = (evtData as ReleaseableDamage);
				additionalDamages = new List<BattleDamage>();
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage = enumerator.Current;
						if (battleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && d.ExceededDamageValue > 0.0))
						{
							double valueOrDefault = (from d in battleDamage.Damages
							where d.IsDirectDamage && d.ExceededDamageValue > 0.0
							select d).Sum((DamageComponent d) => d.ExceededDamageValue).GetValueOrDefault();
							if (valueOrDefault > 0.0)
							{
								List<IBattleUnit> liveEnemyTargets = effectCarrier.GetLiveEnemyTargets(false, false);
								if (liveEnemyTargets.Any<IBattleUnit>())
								{
									IBattleUnit target = liveEnemyTargets[UnityEngine.Random.Range(0, liveEnemyTargets.Count)];
									BattleDamage item = new BattleDamage(target, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
									{
										new DamageComponentValue(new List<DamagePotionValue>
										{
											DamagePotionValue.CreateRawValuedDamageComponent(target, effectCarrier, OutputType.RealDamage, valueOrDefault)
										}, target, effectCarrier, false, false)
									});
									additionalDamages.Add(item);
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!additionalDamages.Any<BattleDamage>())
				{
					goto IL_2BA;
				}
				releaseable = new ReleaseableDamage(additionalDamages, effectCarrier);
				enumerator2 = releaseable.Release().GetEnumerator();
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
			IL_2BA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014D7 RID: 5335
		// (get) Token: 0x06006387 RID: 25479 RVA: 0x00193944 File Offset: 0x00191D44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014D8 RID: 5336
		// (get) Token: 0x06006388 RID: 25480 RVA: 0x0019394C File Offset: 0x00191D4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006389 RID: 25481 RVA: 0x00193954 File Offset: 0x00191D54
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600638A RID: 25482 RVA: 0x001939C4 File Offset: 0x00191DC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600638B RID: 25483 RVA: 0x001939CB File Offset: 0x00191DCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600638C RID: 25484 RVA: 0x001939D4 File Offset: 0x00191DD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ExcessiveDamageToOtherUnitProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ExcessiveDamageToOtherUnitProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600638D RID: 25485 RVA: 0x00193A44 File Offset: 0x00191E44
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && d.ExceededDamageValue > 0.0;
		}

		// Token: 0x0600638E RID: 25486 RVA: 0x00193A88 File Offset: 0x00191E88
		private static bool <>m__1(DamageComponent d)
		{
			return d.IsDirectDamage && d.ExceededDamageValue > 0.0;
		}

		// Token: 0x0600638F RID: 25487 RVA: 0x00193ACB File Offset: 0x00191ECB
		private static double? <>m__2(DamageComponent d)
		{
			return d.ExceededDamageValue;
		}

		// Token: 0x04005ACF RID: 23247
		internal AdventureEventType evtType;

		// Token: 0x04005AD0 RID: 23248
		internal IBattleUnit triggerUnit;

		// Token: 0x04005AD1 RID: 23249
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AD2 RID: 23250
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AD3 RID: 23251
		internal object evtData;

		// Token: 0x04005AD4 RID: 23252
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005AD5 RID: 23253
		internal List<BattleDamage> <additionalDamages>__1;

		// Token: 0x04005AD6 RID: 23254
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005AD7 RID: 23255
		internal ReleaseableDamage <releaseable>__2;

		// Token: 0x04005AD8 RID: 23256
		internal IEnumerator $locvar1;

		// Token: 0x04005AD9 RID: 23257
		internal object <_>__3;

		// Token: 0x04005ADA RID: 23258
		internal IDisposable $locvar2;

		// Token: 0x04005ADB RID: 23259
		internal ExcessiveDamageToOtherUnitProcess $this;

		// Token: 0x04005ADC RID: 23260
		internal object $current;

		// Token: 0x04005ADD RID: 23261
		internal bool $disposing;

		// Token: 0x04005ADE RID: 23262
		internal int $PC;

		// Token: 0x04005ADF RID: 23263
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x04005AE0 RID: 23264
		private static Func<DamageComponent, bool> <>f__am$cache1;

		// Token: 0x04005AE1 RID: 23265
		private static Func<DamageComponent, double?> <>f__am$cache2;
	}
}
