using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x0200085F RID: 2143
	[Serializable]
	public class DeathPreventData : DeviceSpenderData
	{
		// Token: 0x06003D25 RID: 15653 RVA: 0x0017D31C File Offset: 0x0017B71C
		public DeathPreventData()
		{
		}

		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x06003D26 RID: 15654 RVA: 0x0017D324 File Offset: 0x0017B724
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06003D27 RID: 15655 RVA: 0x0017D327 File Offset: 0x0017B727
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D28 RID: 15656 RVA: 0x0017D32F File Offset: 0x0017B72F
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.DeathPrevent;
		}

		// Token: 0x06003D29 RID: 15657 RVA: 0x0017D338 File Offset: 0x0017B738
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString());
			return description;
		}

		// Token: 0x06003D2A RID: 15658 RVA: 0x0017D37C File Offset: 0x0017B77C
		public override double GetEffectPowerValue()
		{
			return 1.0 / (1.0 + (double)Math.Abs(this.Cost));
		}

		// Token: 0x06003D2B RID: 15659 RVA: 0x0017D3A0 File Offset: 0x0017B7A0
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			this.CurrentReviveables++;
			if (this.CurrentReviveables > 5)
			{
				this.CurrentReviveables = 5;
			}
			yield break;
		}

		// Token: 0x04002E96 RID: 11926
		public int _cost;

		// Token: 0x04002E97 RID: 11927
		public int CurrentReviveables;

		// Token: 0x02000EFD RID: 3837
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060D0 RID: 24784 RVA: 0x0017D3C3 File Offset: 0x0017B7C3
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060D1 RID: 24785 RVA: 0x0017D3CC File Offset: 0x0017B7CC
			public bool MoveNext()
			{
				bool flag = this.$PC != 0;
				this.$PC = -1;
				if (!flag)
				{
					this.CurrentReviveables++;
					if (this.CurrentReviveables > 5)
					{
						this.CurrentReviveables = 5;
					}
				}
				return false;
			}

			// Token: 0x17001442 RID: 5186
			// (get) Token: 0x060060D2 RID: 24786 RVA: 0x0017D421 File Offset: 0x0017B821
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001443 RID: 5187
			// (get) Token: 0x060060D3 RID: 24787 RVA: 0x0017D429 File Offset: 0x0017B829
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060D4 RID: 24788 RVA: 0x0017D431 File Offset: 0x0017B831
			[DebuggerHidden]
			public void Dispose()
			{
			}

			// Token: 0x060060D5 RID: 24789 RVA: 0x0017D433 File Offset: 0x0017B833
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060D6 RID: 24790 RVA: 0x0017D43A File Offset: 0x0017B83A
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060D7 RID: 24791 RVA: 0x0017D444 File Offset: 0x0017B844
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				DeathPreventData.<Process>c__Iterator0 <Process>c__Iterator = new DeathPreventData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				return <Process>c__Iterator;
			}

			// Token: 0x04005635 RID: 22069
			internal DeathPreventData $this;

			// Token: 0x04005636 RID: 22070
			internal object $current;

			// Token: 0x04005637 RID: 22071
			internal bool $disposing;

			// Token: 0x04005638 RID: 22072
			internal int $PC;
		}
	}
}
