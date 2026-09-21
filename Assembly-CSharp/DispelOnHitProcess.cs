using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008CF RID: 2255
public class DispelOnHitProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F5E RID: 16222 RVA: 0x0018F92D File Offset: 0x0018DD2D
	public DispelOnHitProcess()
	{
	}

	// Token: 0x17000B60 RID: 2912
	// (get) Token: 0x06003F5F RID: 16223 RVA: 0x0018F935 File Offset: 0x0018DD35
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DispelOnHit;
		}
	}

	// Token: 0x17000B61 RID: 2913
	// (get) Token: 0x06003F60 RID: 16224 RVA: 0x0018F93C File Offset: 0x0018DD3C
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

	// Token: 0x06003F61 RID: 16225 RVA: 0x0018F958 File Offset: 0x0018DD58
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && specialEffectData is DispelOnHitData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			DispelOnHitData data = specialEffectData as DispelOnHitData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				IEnumerable<DamageComponent> effectiveDamages = from d in damageBattleDamage.Damages
				where !d.IsMissed && d.IsDirectDamage
				select d;
				if (effectiveDamages.Any<DamageComponent>() && (double)UnityEngine.Random.value <= data.Chance)
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(damageBattleDamage.Target, new int?(data.NumberOfDispels)).GetEnumerator();
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

	// Token: 0x02000F4D RID: 3917
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062FE RID: 25342 RVA: 0x0018F999 File Offset: 0x0018DD99
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062FF RID: 25343 RVA: 0x0018F9A4 File Offset: 0x0018DDA4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(specialEffectData is DispelOnHitData) || !(evtData is ReleaseableDamage))
				{
					goto IL_1F2;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as DispelOnHitData);
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
					effectiveDamages = from d in damageBattleDamage.Damages
					where !d.IsMissed && d.IsDirectDamage
					select d;
					if (effectiveDamages.Any<DamageComponent>() && (double)UnityEngine.Random.value <= data.Chance)
					{
						enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(damageBattleDamage.Target, new int?(data.NumberOfDispels)).GetEnumerator();
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
			IL_1F2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014B9 RID: 5305
		// (get) Token: 0x06006300 RID: 25344 RVA: 0x0018FBE4 File Offset: 0x0018DFE4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014BA RID: 5306
		// (get) Token: 0x06006301 RID: 25345 RVA: 0x0018FBEC File Offset: 0x0018DFEC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006302 RID: 25346 RVA: 0x0018FBF4 File Offset: 0x0018DFF4
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

		// Token: 0x06006303 RID: 25347 RVA: 0x0018FC88 File Offset: 0x0018E088
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006304 RID: 25348 RVA: 0x0018FC8F File Offset: 0x0018E08F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006305 RID: 25349 RVA: 0x0018FC98 File Offset: 0x0018E098
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DispelOnHitProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DispelOnHitProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006306 RID: 25350 RVA: 0x0018FCFC File Offset: 0x0018E0FC
		private static bool <>m__0(DamageComponent d)
		{
			return !d.IsMissed && d.IsDirectDamage;
		}

		// Token: 0x040059FC RID: 23036
		internal AdventureEventType evtType;

		// Token: 0x040059FD RID: 23037
		internal IBattleUnit triggerUnit;

		// Token: 0x040059FE RID: 23038
		internal IBattleUnit effectCarrier;

		// Token: 0x040059FF RID: 23039
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A00 RID: 23040
		internal object evtData;

		// Token: 0x04005A01 RID: 23041
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005A02 RID: 23042
		internal DispelOnHitData <data>__1;

		// Token: 0x04005A03 RID: 23043
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005A04 RID: 23044
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005A05 RID: 23045
		internal IEnumerable<DamageComponent> <effectiveDamages>__3;

		// Token: 0x04005A06 RID: 23046
		internal IEnumerator $locvar1;

		// Token: 0x04005A07 RID: 23047
		internal object <_>__4;

		// Token: 0x04005A08 RID: 23048
		internal IDisposable $locvar2;

		// Token: 0x04005A09 RID: 23049
		internal object $current;

		// Token: 0x04005A0A RID: 23050
		internal bool $disposing;

		// Token: 0x04005A0B RID: 23051
		internal int $PC;

		// Token: 0x04005A0C RID: 23052
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
