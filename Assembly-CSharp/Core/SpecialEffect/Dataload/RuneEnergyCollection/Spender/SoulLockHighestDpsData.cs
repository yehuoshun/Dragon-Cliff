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
	// Token: 0x0200086A RID: 2154
	[Serializable]
	public class SoulLockHighestDpsData : DeviceSpenderData
	{
		// Token: 0x06003D72 RID: 15730 RVA: 0x00180163 File Offset: 0x0017E563
		public SoulLockHighestDpsData()
		{
		}

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x06003D73 RID: 15731 RVA: 0x0018016B File Offset: 0x0017E56B
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x06003D74 RID: 15732 RVA: 0x0018016E File Offset: 0x0017E56E
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D75 RID: 15733 RVA: 0x00180176 File Offset: 0x0017E576
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SoulLockHighestDpsEffect;
		}

		// Token: 0x06003D76 RID: 15734 RVA: 0x00180180 File Offset: 0x0017E580
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{time}", this.LockTime.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D77 RID: 15735 RVA: 0x001801D9 File Offset: 0x0017E5D9
		public override double GetEffectPowerValue()
		{
			return this.LockTime;
		}

		// Token: 0x06003D78 RID: 15736 RVA: 0x001801E4 File Offset: 0x0017E5E4
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.OutputCapacity, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002EB0 RID: 11952
		public int _cost;

		// Token: 0x04002EB1 RID: 11953
		public double LockTime;

		// Token: 0x02000F09 RID: 3849
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600612F RID: 24879 RVA: 0x0018020E File Offset: 0x0017E60E
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006130 RID: 24880 RVA: 0x00180218 File Offset: 0x0017E618
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.OutputCapacity, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

			// Token: 0x17001458 RID: 5208
			// (get) Token: 0x06006131 RID: 24881 RVA: 0x00180350 File Offset: 0x0017E750
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001459 RID: 5209
			// (get) Token: 0x06006132 RID: 24882 RVA: 0x00180358 File Offset: 0x0017E758
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006133 RID: 24883 RVA: 0x00180360 File Offset: 0x0017E760
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

			// Token: 0x06006134 RID: 24884 RVA: 0x001803D0 File Offset: 0x0017E7D0
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006135 RID: 24885 RVA: 0x001803D7 File Offset: 0x0017E7D7
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006136 RID: 24886 RVA: 0x001803E0 File Offset: 0x0017E7E0
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SoulLockHighestDpsData.<Process>c__Iterator0 <Process>c__Iterator = new SoulLockHighestDpsData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056C6 RID: 22214
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056C7 RID: 22215
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056C8 RID: 22216
			internal IBattleUnit <target>__0;

			// Token: 0x040056C9 RID: 22217
			internal IEnumerator $locvar0;

			// Token: 0x040056CA RID: 22218
			internal object <_>__1;

			// Token: 0x040056CB RID: 22219
			internal IDisposable $locvar1;

			// Token: 0x040056CC RID: 22220
			internal SoulLockHighestDpsData $this;

			// Token: 0x040056CD RID: 22221
			internal object $current;

			// Token: 0x040056CE RID: 22222
			internal bool $disposing;

			// Token: 0x040056CF RID: 22223
			internal int $PC;
		}
	}
}
