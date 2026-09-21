using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200090D RID: 2317
public class PoisonSeedEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600406B RID: 16491 RVA: 0x0019EC6E File Offset: 0x0019D06E
	public PoisonSeedEffectProcess()
	{
	}

	// Token: 0x17000BDA RID: 3034
	// (get) Token: 0x0600406C RID: 16492 RVA: 0x0019EC76 File Offset: 0x0019D076
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.PoisonSeed;
		}
	}

	// Token: 0x17000BDB RID: 3035
	// (get) Token: 0x0600406D RID: 16493 RVA: 0x0019EC7C File Offset: 0x0019D07C
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

	// Token: 0x0600406E RID: 16494 RVA: 0x0019EC98 File Offset: 0x0019D098
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && specialEffectData is PoisonSeedEffectData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			PoisonSeedEffectData data = specialEffectData as PoisonSeedEffectData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
				{
					IEnumerator enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new PoisonSeedEffect(data.HealDecayPerSecond, data.ResistanceDecayValuePerSecond, data.StablizeSeconds, effectCarrier, "poisonseed"), false).GetEnumerator();
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

	// Token: 0x02000F9A RID: 3994
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600652C RID: 25900 RVA: 0x0019ECD9 File Offset: 0x0019D0D9
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600652D RID: 25901 RVA: 0x0019ECE4 File Offset: 0x0019D0E4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(specialEffectData is PoisonSeedEffectData) || !(evtData is ReleaseableDamage))
				{
					goto IL_1ED;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as PoisonSeedEffectData);
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
						enumerator2 = damageBattleDamage.Target.ApplySkillEffect(new PoisonSeedEffect(data.HealDecayPerSecond, data.ResistanceDecayValuePerSecond, data.StablizeSeconds, effectCarrier, "poisonseed"), false).GetEnumerator();
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
			IL_1ED:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001533 RID: 5427
		// (get) Token: 0x0600652E RID: 25902 RVA: 0x0019EF1C File Offset: 0x0019D31C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001534 RID: 5428
		// (get) Token: 0x0600652F RID: 25903 RVA: 0x0019EF24 File Offset: 0x0019D324
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006530 RID: 25904 RVA: 0x0019EF2C File Offset: 0x0019D32C
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

		// Token: 0x06006531 RID: 25905 RVA: 0x0019EFC0 File Offset: 0x0019D3C0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006532 RID: 25906 RVA: 0x0019EFC7 File Offset: 0x0019D3C7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006533 RID: 25907 RVA: 0x0019EFD0 File Offset: 0x0019D3D0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonSeedEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new PoisonSeedEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006534 RID: 25908 RVA: 0x0019F034 File Offset: 0x0019D434
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005D90 RID: 23952
		internal AdventureEventType evtType;

		// Token: 0x04005D91 RID: 23953
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D92 RID: 23954
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D93 RID: 23955
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D94 RID: 23956
		internal object evtData;

		// Token: 0x04005D95 RID: 23957
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005D96 RID: 23958
		internal PoisonSeedEffectData <data>__1;

		// Token: 0x04005D97 RID: 23959
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005D98 RID: 23960
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005D99 RID: 23961
		internal IEnumerator $locvar1;

		// Token: 0x04005D9A RID: 23962
		internal object <_>__3;

		// Token: 0x04005D9B RID: 23963
		internal IDisposable $locvar2;

		// Token: 0x04005D9C RID: 23964
		internal object $current;

		// Token: 0x04005D9D RID: 23965
		internal bool $disposing;

		// Token: 0x04005D9E RID: 23966
		internal int $PC;

		// Token: 0x04005D9F RID: 23967
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
