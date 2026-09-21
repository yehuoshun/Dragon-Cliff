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
	// Token: 0x0200086C RID: 2156
	[Serializable]
	public class SoulLockHighestSpeedData : DeviceSpenderData
	{
		// Token: 0x06003D80 RID: 15744 RVA: 0x001806DC File Offset: 0x0017EADC
		public SoulLockHighestSpeedData()
		{
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06003D81 RID: 15745 RVA: 0x001806E4 File Offset: 0x0017EAE4
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06003D82 RID: 15746 RVA: 0x001806E7 File Offset: 0x0017EAE7
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D83 RID: 15747 RVA: 0x001806EF File Offset: 0x0017EAEF
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SoulLockHighestSpeedEffect;
		}

		// Token: 0x06003D84 RID: 15748 RVA: 0x001806F8 File Offset: 0x0017EAF8
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{time}", this.LockTime.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D85 RID: 15749 RVA: 0x00180751 File Offset: 0x0017EB51
		public override double GetEffectPowerValue()
		{
			return this.LockTime;
		}

		// Token: 0x06003D86 RID: 15750 RVA: 0x0018075C File Offset: 0x0017EB5C
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Speed, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002EB4 RID: 11956
		public int _cost;

		// Token: 0x04002EB5 RID: 11957
		public double LockTime;

		// Token: 0x02000F0B RID: 3851
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600613F RID: 24895 RVA: 0x00180786 File Offset: 0x0017EB86
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006140 RID: 24896 RVA: 0x00180790 File Offset: 0x0017EB90
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Speed, OrderingType.Desc, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_110;
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
				IL_110:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700145C RID: 5212
			// (get) Token: 0x06006141 RID: 24897 RVA: 0x001808C8 File Offset: 0x0017ECC8
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700145D RID: 5213
			// (get) Token: 0x06006142 RID: 24898 RVA: 0x001808D0 File Offset: 0x0017ECD0
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006143 RID: 24899 RVA: 0x001808D8 File Offset: 0x0017ECD8
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

			// Token: 0x06006144 RID: 24900 RVA: 0x00180948 File Offset: 0x0017ED48
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006145 RID: 24901 RVA: 0x0018094F File Offset: 0x0017ED4F
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006146 RID: 24902 RVA: 0x00180958 File Offset: 0x0017ED58
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SoulLockHighestSpeedData.<Process>c__Iterator0 <Process>c__Iterator = new SoulLockHighestSpeedData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056DA RID: 22234
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056DB RID: 22235
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056DC RID: 22236
			internal IBattleUnit <target>__0;

			// Token: 0x040056DD RID: 22237
			internal IEnumerator $locvar0;

			// Token: 0x040056DE RID: 22238
			internal object <_>__1;

			// Token: 0x040056DF RID: 22239
			internal IDisposable $locvar1;

			// Token: 0x040056E0 RID: 22240
			internal SoulLockHighestSpeedData $this;

			// Token: 0x040056E1 RID: 22241
			internal object $current;

			// Token: 0x040056E2 RID: 22242
			internal bool $disposing;

			// Token: 0x040056E3 RID: 22243
			internal int $PC;
		}
	}
}
