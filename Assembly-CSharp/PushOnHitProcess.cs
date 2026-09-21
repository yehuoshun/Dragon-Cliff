using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000912 RID: 2322
public class PushOnHitProcess : SpecialEffectProcessBase
{
	// Token: 0x06004087 RID: 16519 RVA: 0x001A028C File Offset: 0x0019E68C
	public PushOnHitProcess()
	{
	}

	// Token: 0x17000BE5 RID: 3045
	// (get) Token: 0x06004088 RID: 16520 RVA: 0x001A0294 File Offset: 0x0019E694
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.PushOnHit;
		}
	}

	// Token: 0x17000BE6 RID: 3046
	// (get) Token: 0x06004089 RID: 16521 RVA: 0x001A0298 File Offset: 0x0019E698
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

	// Token: 0x0600408A RID: 16522 RVA: 0x001A02B4 File Offset: 0x0019E6B4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && specialEffectData is PushOnHitData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			PushOnHitData data = specialEffectData as PushOnHitData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(damageBattleDamage.Target, effectCarrier, -data.PushBackRate).GetEnumerator();
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

	// Token: 0x02000F9F RID: 3999
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006550 RID: 25936 RVA: 0x001A02F5 File Offset: 0x0019E6F5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006551 RID: 25937 RVA: 0x001A0300 File Offset: 0x0019E700
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(specialEffectData is PushOnHitData) || !(evtData is ReleaseableDamage))
				{
					goto IL_1CD;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as PushOnHitData);
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
					Block_10:
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
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
					{
						enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(damageBattleDamage.Target, effectCarrier, -data.PushBackRate).GetEnumerator();
						num = 4294967293u;
						goto Block_10;
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
			IL_1CD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700153B RID: 5435
		// (get) Token: 0x06006552 RID: 25938 RVA: 0x001A0518 File Offset: 0x0019E918
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700153C RID: 5436
		// (get) Token: 0x06006553 RID: 25939 RVA: 0x001A0520 File Offset: 0x0019E920
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006554 RID: 25940 RVA: 0x001A0528 File Offset: 0x0019E928
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

		// Token: 0x06006555 RID: 25941 RVA: 0x001A05BC File Offset: 0x0019E9BC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006556 RID: 25942 RVA: 0x001A05C3 File Offset: 0x0019E9C3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006557 RID: 25943 RVA: 0x001A05CC File Offset: 0x0019E9CC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PushOnHitProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new PushOnHitProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006558 RID: 25944 RVA: 0x001A0630 File Offset: 0x0019EA30
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005DD9 RID: 24025
		internal AdventureEventType evtType;

		// Token: 0x04005DDA RID: 24026
		internal IBattleUnit triggerUnit;

		// Token: 0x04005DDB RID: 24027
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DDC RID: 24028
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DDD RID: 24029
		internal object evtData;

		// Token: 0x04005DDE RID: 24030
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005DDF RID: 24031
		internal PushOnHitData <data>__1;

		// Token: 0x04005DE0 RID: 24032
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005DE1 RID: 24033
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005DE2 RID: 24034
		internal IEnumerator $locvar1;

		// Token: 0x04005DE3 RID: 24035
		internal object <_>__3;

		// Token: 0x04005DE4 RID: 24036
		internal IDisposable $locvar2;

		// Token: 0x04005DE5 RID: 24037
		internal object $current;

		// Token: 0x04005DE6 RID: 24038
		internal bool $disposing;

		// Token: 0x04005DE7 RID: 24039
		internal int $PC;

		// Token: 0x04005DE8 RID: 24040
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
