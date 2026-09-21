using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F9 RID: 2297
public class IceHeartEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004012 RID: 16402 RVA: 0x00199550 File Offset: 0x00197950
	public IceHeartEffectProcess()
	{
	}

	// Token: 0x17000BB2 RID: 2994
	// (get) Token: 0x06004013 RID: 16403 RVA: 0x00199558 File Offset: 0x00197958
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.IceHeart;
		}
	}

	// Token: 0x17000BB3 RID: 2995
	// (get) Token: 0x06004014 RID: 16404 RVA: 0x0019955C File Offset: 0x0019795C
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

	// Token: 0x06004015 RID: 16405 RVA: 0x00199578 File Offset: 0x00197978
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage && specialEffectData is IceHeartData)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
				{
					IEnumerator enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new FrozenHeartEffect(null, null, effectCarrier), false).GetEnumerator();
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

	// Token: 0x02000F80 RID: 3968
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006463 RID: 25699 RVA: 0x001995B9 File Offset: 0x001979B9
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006464 RID: 25700 RVA: 0x001995C4 File Offset: 0x001979C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(evtData is ReleaseableDamage) || !(specialEffectData is IceHeartData))
				{
					goto IL_1C8;
				}
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
						enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new FrozenHeartEffect(null, null, effectCarrier), false).GetEnumerator();
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
			IL_1C8:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001505 RID: 5381
		// (get) Token: 0x06006465 RID: 25701 RVA: 0x001997D8 File Offset: 0x00197BD8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001506 RID: 5382
		// (get) Token: 0x06006466 RID: 25702 RVA: 0x001997E0 File Offset: 0x00197BE0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006467 RID: 25703 RVA: 0x001997E8 File Offset: 0x00197BE8
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

		// Token: 0x06006468 RID: 25704 RVA: 0x0019987C File Offset: 0x00197C7C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006469 RID: 25705 RVA: 0x00199883 File Offset: 0x00197C83
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600646A RID: 25706 RVA: 0x0019988C File Offset: 0x00197C8C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			IceHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new IceHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600646B RID: 25707 RVA: 0x001998F0 File Offset: 0x00197CF0
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005C3D RID: 23613
		internal AdventureEventType evtType;

		// Token: 0x04005C3E RID: 23614
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C3F RID: 23615
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C40 RID: 23616
		internal object evtData;

		// Token: 0x04005C41 RID: 23617
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C42 RID: 23618
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005C43 RID: 23619
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005C44 RID: 23620
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005C45 RID: 23621
		internal IEnumerator $locvar1;

		// Token: 0x04005C46 RID: 23622
		internal object <_>__3;

		// Token: 0x04005C47 RID: 23623
		internal IDisposable $locvar2;

		// Token: 0x04005C48 RID: 23624
		internal object $current;

		// Token: 0x04005C49 RID: 23625
		internal bool $disposing;

		// Token: 0x04005C4A RID: 23626
		internal int $PC;

		// Token: 0x04005C4B RID: 23627
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
