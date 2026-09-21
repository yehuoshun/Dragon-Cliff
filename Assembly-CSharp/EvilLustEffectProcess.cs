using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008DF RID: 2271
public class EvilLustEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FA4 RID: 16292 RVA: 0x00193188 File Offset: 0x00191588
	public EvilLustEffectProcess()
	{
	}

	// Token: 0x17000B80 RID: 2944
	// (get) Token: 0x06003FA5 RID: 16293 RVA: 0x00193190 File Offset: 0x00191590
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.EvilLust;
		}
	}

	// Token: 0x17000B81 RID: 2945
	// (get) Token: 0x06003FA6 RID: 16294 RVA: 0x00193198 File Offset: 0x00191598
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

	// Token: 0x06003FA7 RID: 16295 RVA: 0x001931B4 File Offset: 0x001915B4
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003FA8 RID: 16296 RVA: 0x001931B8 File Offset: 0x001915B8
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EvilLustData
			{
				IsStar = false,
				Rate = (double)UnityEngine.Random.Range(0.1f, 0.3f),
				Seconds = UnityEngine.Random.Range(3, 6)
			}
		};
	}

	// Token: 0x06003FA9 RID: 16297 RVA: 0x00193204 File Offset: 0x00191604
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier)
		{
			EvilLustData data = specialEffectData as EvilLustData;
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				double totalDamage = (from d in damageBattleDamage.Damages
				where d.IsDirectDamage
				select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar());
				if (totalDamage > 0.0)
				{
					IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(damageBattleDamage.Target, effectCarrier, data.Rate * totalDamage, data.Seconds, effectCarrier.GetOutputType()).GetEnumerator();
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

	// Token: 0x02000F5D RID: 3933
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600637B RID: 25467 RVA: 0x00193245 File Offset: 0x00191645
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600637C RID: 25468 RVA: 0x00193250 File Offset: 0x00191650
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier)
				{
					goto IL_200;
				}
				data = (specialEffectData as EvilLustData);
				damage = (evtData as ReleaseableDamage);
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
					Block_9:
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
					totalDamage = (from d in damageBattleDamage.Damages
					where d.IsDirectDamage
					select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar());
					if (totalDamage > 0.0)
					{
						enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(damageBattleDamage.Target, effectCarrier, data.Rate * totalDamage, data.Seconds, effectCarrier.GetOutputType()).GetEnumerator();
						num = 4294967293u;
						goto Block_9;
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
			IL_200:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014D5 RID: 5333
		// (get) Token: 0x0600637D RID: 25469 RVA: 0x0019349C File Offset: 0x0019189C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014D6 RID: 5334
		// (get) Token: 0x0600637E RID: 25470 RVA: 0x001934A4 File Offset: 0x001918A4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600637F RID: 25471 RVA: 0x001934AC File Offset: 0x001918AC
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

		// Token: 0x06006380 RID: 25472 RVA: 0x00193540 File Offset: 0x00191940
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006381 RID: 25473 RVA: 0x00193547 File Offset: 0x00191947
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006382 RID: 25474 RVA: 0x00193550 File Offset: 0x00191950
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EvilLustEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new EvilLustEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006383 RID: 25475 RVA: 0x001935B4 File Offset: 0x001919B4
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x06006384 RID: 25476 RVA: 0x001935BC File Offset: 0x001919BC
		private static double <>m__1(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x04005ABD RID: 23229
		internal AdventureEventType evtType;

		// Token: 0x04005ABE RID: 23230
		internal IBattleUnit triggerUnit;

		// Token: 0x04005ABF RID: 23231
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AC0 RID: 23232
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AC1 RID: 23233
		internal EvilLustData <data>__1;

		// Token: 0x04005AC2 RID: 23234
		internal object evtData;

		// Token: 0x04005AC3 RID: 23235
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005AC4 RID: 23236
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005AC5 RID: 23237
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005AC6 RID: 23238
		internal double <totalDamage>__3;

		// Token: 0x04005AC7 RID: 23239
		internal IEnumerator $locvar1;

		// Token: 0x04005AC8 RID: 23240
		internal object <_>__4;

		// Token: 0x04005AC9 RID: 23241
		internal IDisposable $locvar2;

		// Token: 0x04005ACA RID: 23242
		internal object $current;

		// Token: 0x04005ACB RID: 23243
		internal bool $disposing;

		// Token: 0x04005ACC RID: 23244
		internal int $PC;

		// Token: 0x04005ACD RID: 23245
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x04005ACE RID: 23246
		private static Func<DamageComponent, double> <>f__am$cache1;
	}
}
