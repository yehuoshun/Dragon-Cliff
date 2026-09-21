using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x0200086D RID: 2157
	[Serializable]
	public class SoulLockRandomTargetData : DeviceSpenderData
	{
		// Token: 0x06003D87 RID: 15751 RVA: 0x00180998 File Offset: 0x0017ED98
		public SoulLockRandomTargetData()
		{
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x06003D88 RID: 15752 RVA: 0x001809A0 File Offset: 0x0017EDA0
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06003D89 RID: 15753 RVA: 0x001809A3 File Offset: 0x0017EDA3
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D8A RID: 15754 RVA: 0x001809AB File Offset: 0x0017EDAB
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SoulLockRandomTargetEffect;
		}

		// Token: 0x06003D8B RID: 15755 RVA: 0x001809B4 File Offset: 0x0017EDB4
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{time}", this.LockTime.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D8C RID: 15756 RVA: 0x00180A0D File Offset: 0x0017EE0D
		public override double GetEffectPowerValue()
		{
			return this.LockTime;
		}

		// Token: 0x06003D8D RID: 15757 RVA: 0x00180A18 File Offset: 0x0017EE18
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				IEnumerator enumerator = LockTimeEffect.AddSoulLockSeconds(target, Convert.ToSingle(this.LockTime), wearer).GetEnumerator();
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
			yield break;
		}

		// Token: 0x04002EB6 RID: 11958
		public int _cost;

		// Token: 0x04002EB7 RID: 11959
		public double LockTime;

		// Token: 0x02000F0C RID: 3852
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006147 RID: 24903 RVA: 0x00180A42 File Offset: 0x0017EE42
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006148 RID: 24904 RVA: 0x00180A4C File Offset: 0x0017EE4C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_10F;
					}
					enumerator = LockTimeEffect.AddSoulLockSeconds(target, Convert.ToSingle(this.LockTime), wearer).GetEnumerator();
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
				IL_10F:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700145E RID: 5214
			// (get) Token: 0x06006149 RID: 24905 RVA: 0x00180B84 File Offset: 0x0017EF84
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700145F RID: 5215
			// (get) Token: 0x0600614A RID: 24906 RVA: 0x00180B8C File Offset: 0x0017EF8C
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600614B RID: 24907 RVA: 0x00180B94 File Offset: 0x0017EF94
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

			// Token: 0x0600614C RID: 24908 RVA: 0x00180C04 File Offset: 0x0017F004
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600614D RID: 24909 RVA: 0x00180C0B File Offset: 0x0017F00B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600614E RID: 24910 RVA: 0x00180C14 File Offset: 0x0017F014
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SoulLockRandomTargetData.<Process>c__Iterator0 <Process>c__Iterator = new SoulLockRandomTargetData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056E4 RID: 22244
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056E5 RID: 22245
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056E6 RID: 22246
			internal IBattleUnit <target>__0;

			// Token: 0x040056E7 RID: 22247
			internal IEnumerator $locvar0;

			// Token: 0x040056E8 RID: 22248
			internal object <_>__1;

			// Token: 0x040056E9 RID: 22249
			internal IDisposable $locvar1;

			// Token: 0x040056EA RID: 22250
			internal SoulLockRandomTargetData $this;

			// Token: 0x040056EB RID: 22251
			internal object $current;

			// Token: 0x040056EC RID: 22252
			internal bool $disposing;

			// Token: 0x040056ED RID: 22253
			internal int $PC;
		}
	}
}
