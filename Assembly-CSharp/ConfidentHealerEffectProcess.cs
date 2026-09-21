using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008BC RID: 2236
public class ConfidentHealerEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F0D RID: 16141 RVA: 0x00188FEB File Offset: 0x001873EB
	public ConfidentHealerEffectProcess()
	{
	}

	// Token: 0x17000B3A RID: 2874
	// (get) Token: 0x06003F0E RID: 16142 RVA: 0x00188FF3 File Offset: 0x001873F3
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ConfidentHealer;
		}
	}

	// Token: 0x17000B3B RID: 2875
	// (get) Token: 0x06003F0F RID: 16143 RVA: 0x00188FF8 File Offset: 0x001873F8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.PostHealRelease
			};
		}
	}

	// Token: 0x06003F10 RID: 16144 RVA: 0x00189014 File Offset: 0x00187414
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.PostHealRelease && triggerUnit == effectCarrier && specialEffectData is ConfidentHealerData && evtData is ReleaseableHeal)
		{
			ReleaseableHeal heal = evtData as ReleaseableHeal;
			if (heal.Healer == effectCarrier)
			{
				ConfidentHealerData data = specialEffectData as ConfidentHealerData;
				foreach (BattleHeal healBattleHeal in heal.BattleHeals)
				{
					double total = (from h in healBattleHeal.Heals
					where h.IsDirectHeal && !h.IsNeutralized
					select h).Sum((HealComponent h) => h.RawHeal);
					if (total > 0.0)
					{
						IEnumerator enumerator2 = healBattleHeal.Target.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(total * data.AfterHealRate), null, OutputType.RealHeal, healBattleHeal.Target, effectCarrier, base.GetType().FullName, new int?(data.AfterHealSeconds), false, false, true, new int?(3)), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06003F11 RID: 16145 RVA: 0x0018905C File Offset: 0x0018745C
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return itemType.GetResourceCategory() == ResourceCategory.Staff || itemType.GetResourceCategory() == ResourceCategory.Robe;
	}

	// Token: 0x06003F12 RID: 16146 RVA: 0x00189078 File Offset: 0x00187478
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ConfidentHealerData
			{
				IsStar = true,
				AfterHealSeconds = UnityEngine.Random.Range(3, 5),
				AfterHealRate = 0.4 * (double)UnityEngine.Random.Range(0.8f, 1f),
				HealBoostRate = 0.4 * (double)UnityEngine.Random.Range(0.8f, 1f)
			}
		};
	}

	// Token: 0x02000F31 RID: 3889
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600623E RID: 25150 RVA: 0x001890ED File Offset: 0x001874ED
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600623F RID: 25151 RVA: 0x001890F8 File Offset: 0x001874F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.PostHealRelease || triggerUnit != effectCarrier || !(specialEffectData is ConfidentHealerData) || !(evtData is ReleaseableHeal))
				{
					goto IL_26A;
				}
				heal = (evtData as ReleaseableHeal);
				if (heal.Healer != effectCarrier)
				{
					goto IL_26A;
				}
				data = (specialEffectData as ConfidentHealerData);
				enumerator = heal.BattleHeals.GetEnumerator();
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
					Block_12:
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
					healBattleHeal = enumerator.Current;
					total = (from h in healBattleHeal.Heals
					where h.IsDirectHeal && !h.IsNeutralized
					select h).Sum((HealComponent h) => h.RawHeal);
					if (total > 0.0)
					{
						enumerator2 = healBattleHeal.Target.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(new double?(total * data.AfterHealRate), null, OutputType.RealHeal, healBattleHeal.Target, effectCarrier, base.GetType().FullName, new int?(data.AfterHealSeconds), false, false, true, new int?(3)), false).GetEnumerator();
						num = 4294967293u;
						goto Block_12;
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
			IL_26A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001491 RID: 5265
		// (get) Token: 0x06006240 RID: 25152 RVA: 0x001893B0 File Offset: 0x001877B0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001492 RID: 5266
		// (get) Token: 0x06006241 RID: 25153 RVA: 0x001893B8 File Offset: 0x001877B8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006242 RID: 25154 RVA: 0x001893C0 File Offset: 0x001877C0
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

		// Token: 0x06006243 RID: 25155 RVA: 0x00189454 File Offset: 0x00187854
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006244 RID: 25156 RVA: 0x0018945B File Offset: 0x0018785B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006245 RID: 25157 RVA: 0x00189464 File Offset: 0x00187864
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ConfidentHealerEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ConfidentHealerEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006246 RID: 25158 RVA: 0x001894D4 File Offset: 0x001878D4
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal && !h.IsNeutralized;
		}

		// Token: 0x06006247 RID: 25159 RVA: 0x001894ED File Offset: 0x001878ED
		private static double <>m__1(HealComponent h)
		{
			return h.RawHeal;
		}

		// Token: 0x0400587B RID: 22651
		internal AdventureEventType evtType;

		// Token: 0x0400587C RID: 22652
		internal IBattleUnit triggerUnit;

		// Token: 0x0400587D RID: 22653
		internal IBattleUnit effectCarrier;

		// Token: 0x0400587E RID: 22654
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400587F RID: 22655
		internal object evtData;

		// Token: 0x04005880 RID: 22656
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005881 RID: 22657
		internal ConfidentHealerData <data>__2;

		// Token: 0x04005882 RID: 22658
		internal List<BattleHeal>.Enumerator $locvar0;

		// Token: 0x04005883 RID: 22659
		internal BattleHeal <healBattleHeal>__3;

		// Token: 0x04005884 RID: 22660
		internal double <total>__4;

		// Token: 0x04005885 RID: 22661
		internal IEnumerator $locvar1;

		// Token: 0x04005886 RID: 22662
		internal object <_>__5;

		// Token: 0x04005887 RID: 22663
		internal IDisposable $locvar2;

		// Token: 0x04005888 RID: 22664
		internal ConfidentHealerEffectProcess $this;

		// Token: 0x04005889 RID: 22665
		internal object $current;

		// Token: 0x0400588A RID: 22666
		internal bool $disposing;

		// Token: 0x0400588B RID: 22667
		internal int $PC;

		// Token: 0x0400588C RID: 22668
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x0400588D RID: 22669
		private static Func<HealComponent, double> <>f__am$cache1;
	}
}
