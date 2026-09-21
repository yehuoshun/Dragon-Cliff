using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008C7 RID: 2247
public class DeadMatchSpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F3B RID: 16187 RVA: 0x0018C2EB File Offset: 0x0018A6EB
	public DeadMatchSpecialEffectProcess()
	{
	}

	// Token: 0x17000B50 RID: 2896
	// (get) Token: 0x06003F3C RID: 16188 RVA: 0x0018C2FA File Offset: 0x0018A6FA
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B51 RID: 2897
	// (get) Token: 0x06003F3D RID: 16189 RVA: 0x0018C304 File Offset: 0x0018A704
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003F3E RID: 16190 RVA: 0x0018C320 File Offset: 0x0018A720
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single)
		{
			DamageComponent battleDamage = evtData as DamageComponent;
			DeadMatchEffectData data = specialEffectData as DeadMatchEffectData;
			if (battleDamage != null && battleDamage.Dealer == effectCarrier && battleDamage.IsDirectDamage && battleDamage.Target == triggerUnit && battleDamage.Target.HealthPoints / battleDamage.Target.GetMaxLife(AttributeRetrievalLevel.Skill) <= data.KillLifePercentage && !battleDamage.Target.IsBoss() && (double)UnityEngine.Random.value <= data.KillPossibility)
			{
				double killOffDamage = battleDamage.Target.GetMaxLife(AttributeRetrievalLevel.Skill);
				ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(battleDamage.Target, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Target, effectCarrier, OutputType.RealDamage, killOffDamage)
						}, battleDamage.Target, effectCarrier, false, false)
					})
				}, effectCarrier);
				IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F77 RID: 12151
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.DeadMatch;

	// Token: 0x02000F41 RID: 3905
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062AF RID: 25263 RVA: 0x0018C368 File Offset: 0x0018A768
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062B0 RID: 25264 RVA: 0x0018C370 File Offset: 0x0018A770
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single)
				{
					goto IL_240;
				}
				battleDamage = (evtData as DamageComponent);
				data = (specialEffectData as DeadMatchEffectData);
				if (battleDamage == null || battleDamage.Dealer != effectCarrier || !battleDamage.IsDirectDamage || battleDamage.Target != triggerUnit || battleDamage.Target.HealthPoints / battleDamage.Target.GetMaxLife(AttributeRetrievalLevel.Skill) > data.KillLifePercentage || battleDamage.Target.IsBoss() || (double)UnityEngine.Random.value > data.KillPossibility)
				{
					goto IL_240;
				}
				killOffDamage = battleDamage.Target.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(battleDamage.Target, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Target, effectCarrier, OutputType.RealDamage, killOffDamage)
						}, battleDamage.Target, effectCarrier, false, false)
					})
				}, effectCarrier);
				enumerator = releaseableDamage.Release().GetEnumerator();
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
			IL_240:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014A7 RID: 5287
		// (get) Token: 0x060062B1 RID: 25265 RVA: 0x0018C5D8 File Offset: 0x0018A9D8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014A8 RID: 5288
		// (get) Token: 0x060062B2 RID: 25266 RVA: 0x0018C5E0 File Offset: 0x0018A9E0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062B3 RID: 25267 RVA: 0x0018C5E8 File Offset: 0x0018A9E8
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

		// Token: 0x060062B4 RID: 25268 RVA: 0x0018C658 File Offset: 0x0018AA58
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062B5 RID: 25269 RVA: 0x0018C65F File Offset: 0x0018AA5F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062B6 RID: 25270 RVA: 0x0018C668 File Offset: 0x0018AA68
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DeadMatchSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DeadMatchSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005940 RID: 22848
		internal AdventureEventType evtType;

		// Token: 0x04005941 RID: 22849
		internal object evtData;

		// Token: 0x04005942 RID: 22850
		internal DamageComponent <battleDamage>__1;

		// Token: 0x04005943 RID: 22851
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005944 RID: 22852
		internal DeadMatchEffectData <data>__1;

		// Token: 0x04005945 RID: 22853
		internal IBattleUnit effectCarrier;

		// Token: 0x04005946 RID: 22854
		internal IBattleUnit triggerUnit;

		// Token: 0x04005947 RID: 22855
		internal double <killOffDamage>__2;

		// Token: 0x04005948 RID: 22856
		internal ReleaseableDamage <releaseableDamage>__2;

		// Token: 0x04005949 RID: 22857
		internal IEnumerator $locvar0;

		// Token: 0x0400594A RID: 22858
		internal object <_>__3;

		// Token: 0x0400594B RID: 22859
		internal IDisposable $locvar1;

		// Token: 0x0400594C RID: 22860
		internal DeadMatchSpecialEffectProcess $this;

		// Token: 0x0400594D RID: 22861
		internal object $current;

		// Token: 0x0400594E RID: 22862
		internal bool $disposing;

		// Token: 0x0400594F RID: 22863
		internal int $PC;
	}
}
