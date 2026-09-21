using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F3 RID: 2291
public class HealOutputBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FF9 RID: 16377 RVA: 0x00197B3C File Offset: 0x00195F3C
	public HealOutputBoostEffectProcess()
	{
	}

	// Token: 0x17000BA8 RID: 2984
	// (get) Token: 0x06003FFA RID: 16378 RVA: 0x00197B6F File Offset: 0x00195F6F
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BA9 RID: 2985
	// (get) Token: 0x06003FFB RID: 16379 RVA: 0x00197B77 File Offset: 0x00195F77
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003FFC RID: 16380 RVA: 0x00197B80 File Offset: 0x00195F80
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.PostHealRelease && triggerUnit == effectCarrier && triggerUnit.IsPlayer && evtData is ReleaseableHeal && specialEffectData is HealOutputBoostData && triggerUnit.GetUnitClassStyle() == UnitClassStyle.Healer)
		{
			ReleaseableHeal heal = evtData as ReleaseableHeal;
			HealOutputBoostData data = specialEffectData as HealOutputBoostData;
			foreach (BattleHeal battleHeal in (from h in heal.BattleHeals
			where h.Heals.Any((HealComponent hh) => hh.IsDirectHeal) && h.Target != effectCarrier
			select h).ToList<BattleHeal>())
			{
				double totalExceeded = (from h in battleHeal.Heals
				where h.IsDirectHeal
				select h).Sum((HealComponent h) => h.ExceededHealValue.GetValueOrDefault());
				if (totalExceeded > 0.0)
				{
					IEnumerator enumerator2 = battleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = battleHeal.Target.GetOutputAttributeType(),
							ModificationType = ModificationType.Addition,
							Key = string.Empty,
							Value = totalExceeded * data.BoostRate,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "healoutput", new int?(10), null, null, false, true, false), false).GetEnumerator();
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

	// Token: 0x04002F94 RID: 12180
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.HealOutputBoost;

	// Token: 0x04002F95 RID: 12181
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.PostHealRelease
	};

	// Token: 0x02000F77 RID: 3959
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006426 RID: 25638 RVA: 0x00197BC1 File Offset: 0x00195FC1
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006427 RID: 25639 RVA: 0x00197BCC File Offset: 0x00195FCC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.PostHealRelease || triggerUnit != effectCarrier || !triggerUnit.IsPlayer || !(evtData is ReleaseableHeal) || !(specialEffectData is HealOutputBoostData) || triggerUnit.GetUnitClassStyle() != UnitClassStyle.Healer)
				{
					goto IL_2F7;
				}
				heal = (evtData as ReleaseableHeal);
				data = (specialEffectData as HealOutputBoostData);
				enumerator = (from h in heal.BattleHeals
				where h.Heals.Any((HealComponent hh) => hh.IsDirectHeal) && h.Target != effectCarrier
				select h).ToList<BattleHeal>().GetEnumerator();
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
					Block_13:
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
					battleHeal = enumerator.Current;
					totalExceeded = (from h in battleHeal.Heals
					where h.IsDirectHeal
					select h).Sum((HealComponent h) => h.ExceededHealValue.GetValueOrDefault());
					if (totalExceeded > 0.0)
					{
						enumerator2 = battleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(heal.Healer, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = battleHeal.Target.GetOutputAttributeType(),
								ModificationType = ModificationType.Addition,
								Key = string.Empty,
								Value = totalExceeded * data.BoostRate,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, AttributeModificationEffect.PostDamageReleaseRemovePartial + "healoutput", new int?(10), null, null, false, true, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
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
			IL_2F7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014F9 RID: 5369
		// (get) Token: 0x06006428 RID: 25640 RVA: 0x00197F10 File Offset: 0x00196310
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014FA RID: 5370
		// (get) Token: 0x06006429 RID: 25641 RVA: 0x00197F18 File Offset: 0x00196318
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600642A RID: 25642 RVA: 0x00197F20 File Offset: 0x00196320
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

		// Token: 0x0600642B RID: 25643 RVA: 0x00197FB4 File Offset: 0x001963B4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600642C RID: 25644 RVA: 0x00197FBB File Offset: 0x001963BB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600642D RID: 25645 RVA: 0x00197FC4 File Offset: 0x001963C4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealOutputBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new HealOutputBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600642E RID: 25646 RVA: 0x00198028 File Offset: 0x00196428
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal;
		}

		// Token: 0x0600642F RID: 25647 RVA: 0x00198030 File Offset: 0x00196430
		private static double <>m__1(HealComponent h)
		{
			return h.ExceededHealValue.GetValueOrDefault();
		}

		// Token: 0x04005BD7 RID: 23511
		internal AdventureEventType evtType;

		// Token: 0x04005BD8 RID: 23512
		internal IBattleUnit triggerUnit;

		// Token: 0x04005BD9 RID: 23513
		internal IBattleUnit effectCarrier;

		// Token: 0x04005BDA RID: 23514
		internal object evtData;

		// Token: 0x04005BDB RID: 23515
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BDC RID: 23516
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005BDD RID: 23517
		internal HealOutputBoostData <data>__1;

		// Token: 0x04005BDE RID: 23518
		internal List<BattleHeal>.Enumerator $locvar0;

		// Token: 0x04005BDF RID: 23519
		internal BattleHeal <battleHeal>__2;

		// Token: 0x04005BE0 RID: 23520
		internal double <totalExceeded>__3;

		// Token: 0x04005BE1 RID: 23521
		internal IEnumerator $locvar1;

		// Token: 0x04005BE2 RID: 23522
		internal object <_>__4;

		// Token: 0x04005BE3 RID: 23523
		internal IDisposable $locvar2;

		// Token: 0x04005BE4 RID: 23524
		internal object $current;

		// Token: 0x04005BE5 RID: 23525
		internal bool $disposing;

		// Token: 0x04005BE6 RID: 23526
		internal int $PC;

		// Token: 0x04005BE7 RID: 23527
		private HealOutputBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x04005BE8 RID: 23528
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x04005BE9 RID: 23529
		private static Func<HealComponent, double> <>f__am$cache1;

		// Token: 0x02000F78 RID: 3960
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006430 RID: 25648 RVA: 0x0019804B File Offset: 0x0019644B
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006431 RID: 25649 RVA: 0x00198054 File Offset: 0x00196454
			internal bool <>m__0(BattleHeal h)
			{
				return h.Heals.Any((HealComponent hh) => hh.IsDirectHeal) && h.Target != this.effectCarrier;
			}

			// Token: 0x06006432 RID: 25650 RVA: 0x001980A2 File Offset: 0x001964A2
			private static bool <>m__1(HealComponent hh)
			{
				return hh.IsDirectHeal;
			}

			// Token: 0x04005BEA RID: 23530
			internal IBattleUnit effectCarrier;

			// Token: 0x04005BEB RID: 23531
			internal HealOutputBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005BEC RID: 23532
			private static Func<HealComponent, bool> <>f__am$cache0;
		}
	}
}
