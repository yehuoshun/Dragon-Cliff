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
	// Token: 0x0200086B RID: 2155
	[Serializable]
	public class SoulLockHighestLifeData : DeviceSpenderData
	{
		// Token: 0x06003D79 RID: 15737 RVA: 0x00180420 File Offset: 0x0017E820
		public SoulLockHighestLifeData()
		{
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06003D7A RID: 15738 RVA: 0x00180428 File Offset: 0x0017E828
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06003D7B RID: 15739 RVA: 0x0018042B File Offset: 0x0017E82B
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D7C RID: 15740 RVA: 0x00180433 File Offset: 0x0017E833
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SoulLockHighestLifeEffect;
		}

		// Token: 0x06003D7D RID: 15741 RVA: 0x0018043C File Offset: 0x0017E83C
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{time}", this.LockTime.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D7E RID: 15742 RVA: 0x00180495 File Offset: 0x0017E895
		public override double GetEffectPowerValue()
		{
			return this.LockTime;
		}

		// Token: 0x06003D7F RID: 15743 RVA: 0x001804A0 File Offset: 0x0017E8A0
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002EB2 RID: 11954
		public int _cost;

		// Token: 0x04002EB3 RID: 11955
		public double LockTime;

		// Token: 0x02000F0A RID: 3850
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006137 RID: 24887 RVA: 0x001804CA File Offset: 0x0017E8CA
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006138 RID: 24888 RVA: 0x001804D4 File Offset: 0x0017E8D4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

			// Token: 0x1700145A RID: 5210
			// (get) Token: 0x06006139 RID: 24889 RVA: 0x0018060C File Offset: 0x0017EA0C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700145B RID: 5211
			// (get) Token: 0x0600613A RID: 24890 RVA: 0x00180614 File Offset: 0x0017EA14
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600613B RID: 24891 RVA: 0x0018061C File Offset: 0x0017EA1C
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

			// Token: 0x0600613C RID: 24892 RVA: 0x0018068C File Offset: 0x0017EA8C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600613D RID: 24893 RVA: 0x00180693 File Offset: 0x0017EA93
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600613E RID: 24894 RVA: 0x0018069C File Offset: 0x0017EA9C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SoulLockHighestLifeData.<Process>c__Iterator0 <Process>c__Iterator = new SoulLockHighestLifeData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056D0 RID: 22224
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056D1 RID: 22225
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056D2 RID: 22226
			internal IBattleUnit <target>__0;

			// Token: 0x040056D3 RID: 22227
			internal IEnumerator $locvar0;

			// Token: 0x040056D4 RID: 22228
			internal object <_>__1;

			// Token: 0x040056D5 RID: 22229
			internal IDisposable $locvar1;

			// Token: 0x040056D6 RID: 22230
			internal SoulLockHighestLifeData $this;

			// Token: 0x040056D7 RID: 22231
			internal object $current;

			// Token: 0x040056D8 RID: 22232
			internal bool $disposing;

			// Token: 0x040056D9 RID: 22233
			internal int $PC;
		}
	}
}
