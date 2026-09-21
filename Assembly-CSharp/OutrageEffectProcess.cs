using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200090B RID: 2315
public class OutrageEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004063 RID: 16483 RVA: 0x0019E49C File Offset: 0x0019C89C
	public OutrageEffectProcess()
	{
	}

	// Token: 0x17000BD6 RID: 3030
	// (get) Token: 0x06004064 RID: 16484 RVA: 0x0019E4A4 File Offset: 0x0019C8A4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Outrage;
		}
	}

	// Token: 0x17000BD7 RID: 3031
	// (get) Token: 0x06004065 RID: 16485 RVA: 0x0019E4A8 File Offset: 0x0019C8A8
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

	// Token: 0x06004066 RID: 16486 RVA: 0x0019E4C4 File Offset: 0x0019C8C4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage && specialEffectData is OutrageData)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			OutrageData data = specialEffectData as OutrageData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				bool hit = false;
				foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
				{
					if (damageComponent.IsDirectDamage && !damageComponent.IsMissed && (double)UnityEngine.Random.value <= data.Chance)
					{
						hit = true;
					}
				}
				if (hit)
				{
					IEnumerator enumerator3 = damageBattleDamage.Target.ApplySkillEffect(new SiliencedEffect(new int?(2), null, effectCarrier), false).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F98 RID: 3992
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600651A RID: 25882 RVA: 0x0019E505 File Offset: 0x0019C905
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600651B RID: 25883 RVA: 0x0019E510 File Offset: 0x0019C910
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(evtData is ReleaseableDamage) || !(specialEffectData is OutrageData))
				{
					goto IL_239;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as OutrageData);
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
						if (enumerator3.MoveNext())
						{
							_ = enumerator3.Current;
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
							if ((disposable = (enumerator3 as IDisposable)) != null)
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
					hit = false;
					enumerator2 = damageBattleDamage.Damages.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							DamageComponent damageComponent = enumerator2.Current;
							if (damageComponent.IsDirectDamage && !damageComponent.IsMissed && (double)UnityEngine.Random.value <= data.Chance)
							{
								hit = true;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (hit)
					{
						enumerator3 = damageBattleDamage.Target.ApplySkillEffect(new SiliencedEffect(new int?(2), null, effectCarrier), false).GetEnumerator();
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
			IL_239:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700152F RID: 5423
		// (get) Token: 0x0600651C RID: 25884 RVA: 0x0019E7AC File Offset: 0x0019CBAC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001530 RID: 5424
		// (get) Token: 0x0600651D RID: 25885 RVA: 0x0019E7B4 File Offset: 0x0019CBB4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600651E RID: 25886 RVA: 0x0019E7BC File Offset: 0x0019CBBC
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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

		// Token: 0x0600651F RID: 25887 RVA: 0x0019E850 File Offset: 0x0019CC50
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006520 RID: 25888 RVA: 0x0019E857 File Offset: 0x0019CC57
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006521 RID: 25889 RVA: 0x0019E860 File Offset: 0x0019CC60
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			OutrageEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new OutrageEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D6E RID: 23918
		internal AdventureEventType evtType;

		// Token: 0x04005D6F RID: 23919
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D70 RID: 23920
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D71 RID: 23921
		internal object evtData;

		// Token: 0x04005D72 RID: 23922
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D73 RID: 23923
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005D74 RID: 23924
		internal OutrageData <data>__1;

		// Token: 0x04005D75 RID: 23925
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005D76 RID: 23926
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005D77 RID: 23927
		internal bool <hit>__3;

		// Token: 0x04005D78 RID: 23928
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04005D79 RID: 23929
		internal IEnumerator $locvar2;

		// Token: 0x04005D7A RID: 23930
		internal object <_>__4;

		// Token: 0x04005D7B RID: 23931
		internal IDisposable $locvar3;

		// Token: 0x04005D7C RID: 23932
		internal object $current;

		// Token: 0x04005D7D RID: 23933
		internal bool $disposing;

		// Token: 0x04005D7E RID: 23934
		internal int $PC;
	}
}
