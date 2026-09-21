using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093C RID: 2364
public class UndeadAshEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004149 RID: 16713 RVA: 0x001ABF26 File Offset: 0x001AA326
	public UndeadAshEffectProcess()
	{
	}

	// Token: 0x17000C37 RID: 3127
	// (get) Token: 0x0600414A RID: 16714 RVA: 0x001ABF2E File Offset: 0x001AA32E
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.UndeadAshEffect;
		}
	}

	// Token: 0x17000C38 RID: 3128
	// (get) Token: 0x0600414B RID: 16715 RVA: 0x001ABF34 File Offset: 0x001AA334
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

	// Token: 0x0600414C RID: 16716 RVA: 0x001ABF58 File Offset: 0x001AA358
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
		{
			UndeadAshData undeadAshData = specialEffectData as UndeadAshData;
			if (undeadAshData != null)
			{
				undeadAshData.DamageSoFar = 0.0;
				undeadAshData.PreviousLossLayers = 0;
			}
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage && triggerUnit == effectCarrier)
		{
			BattleDamage damage = evtData as BattleDamage;
			UndeadAshData data = specialEffectData as UndeadAshData;
			if (damage != null && data != null)
			{
				double totalDamageValue = damage.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
				if (totalDamageValue > 0.0)
				{
					double maxLife = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
					double lossRateRaquired = maxLife * data.PerLossRate;
					data.DamageSoFar += totalDamageValue;
					int lostLayers = (int)Math.Floor(data.DamageSoFar / lossRateRaquired);
					if (lostLayers > data.PreviousLossLayers)
					{
						data.PreviousLossLayers = lostLayers;
						IEnumerator enumerator = effectCarrier.ApplySkillEffect(new UndeadAshEffect(base.GetType().FullName, null, effectCarrier, new int?(2), data.PerIncreaseRate), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000FE3 RID: 4067
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006708 RID: 26376 RVA: 0x001ABFA0 File Offset: 0x001AA3A0
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006709 RID: 26377 RVA: 0x001ABFA8 File Offset: 0x001AA3A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier)
				{
					UndeadAshData undeadAshData = specialEffectData as UndeadAshData;
					if (undeadAshData != null)
					{
						undeadAshData.DamageSoFar = 0.0;
						undeadAshData.PreviousLossLayers = 0;
					}
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage || triggerUnit != effectCarrier)
				{
					goto IL_260;
				}
				damage = (evtData as BattleDamage);
				data = (specialEffectData as UndeadAshData);
				if (damage == null || data == null)
				{
					goto IL_260;
				}
				totalDamageValue = damage.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
				if (totalDamageValue <= 0.0)
				{
					goto IL_260;
				}
				maxLife = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill);
				lossRateRaquired = maxLife * data.PerLossRate;
				data.DamageSoFar += totalDamageValue;
				lostLayers = (int)Math.Floor(data.DamageSoFar / lossRateRaquired);
				if (lostLayers <= data.PreviousLossLayers)
				{
					goto IL_260;
				}
				data.PreviousLossLayers = lostLayers;
				enumerator = effectCarrier.ApplySkillEffect(new UndeadAshEffect(base.GetType().FullName, null, effectCarrier, new int?(2), data.PerIncreaseRate), false).GetEnumerator();
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
			IL_260:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700159D RID: 5533
		// (get) Token: 0x0600670A RID: 26378 RVA: 0x001AC230 File Offset: 0x001AA630
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700159E RID: 5534
		// (get) Token: 0x0600670B RID: 26379 RVA: 0x001AC238 File Offset: 0x001AA638
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600670C RID: 26380 RVA: 0x001AC240 File Offset: 0x001AA640
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

		// Token: 0x0600670D RID: 26381 RVA: 0x001AC2B0 File Offset: 0x001AA6B0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600670E RID: 26382 RVA: 0x001AC2B7 File Offset: 0x001AA6B7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600670F RID: 26383 RVA: 0x001AC2C0 File Offset: 0x001AA6C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UndeadAshEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new UndeadAshEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006710 RID: 26384 RVA: 0x001AC330 File Offset: 0x001AA730
		private static double <>m__0(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x040060BE RID: 24766
		internal AdventureEventType evtType;

		// Token: 0x040060BF RID: 24767
		internal IBattleUnit triggerUnit;

		// Token: 0x040060C0 RID: 24768
		internal IBattleUnit effectCarrier;

		// Token: 0x040060C1 RID: 24769
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040060C2 RID: 24770
		internal object evtData;

		// Token: 0x040060C3 RID: 24771
		internal BattleDamage <damage>__1;

		// Token: 0x040060C4 RID: 24772
		internal UndeadAshData <data>__1;

		// Token: 0x040060C5 RID: 24773
		internal double <totalDamageValue>__2;

		// Token: 0x040060C6 RID: 24774
		internal double <maxLife>__3;

		// Token: 0x040060C7 RID: 24775
		internal double <lossRateRaquired>__3;

		// Token: 0x040060C8 RID: 24776
		internal int <lostLayers>__3;

		// Token: 0x040060C9 RID: 24777
		internal IEnumerator $locvar0;

		// Token: 0x040060CA RID: 24778
		internal object <_>__4;

		// Token: 0x040060CB RID: 24779
		internal IDisposable $locvar1;

		// Token: 0x040060CC RID: 24780
		internal UndeadAshEffectProcess $this;

		// Token: 0x040060CD RID: 24781
		internal object $current;

		// Token: 0x040060CE RID: 24782
		internal bool $disposing;

		// Token: 0x040060CF RID: 24783
		internal int $PC;

		// Token: 0x040060D0 RID: 24784
		private static Func<DamageComponent, double> <>f__am$cache0;
	}
}
