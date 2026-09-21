using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x02000866 RID: 2150
	[Serializable]
	public class MagicBarrierData : DeviceSpenderData
	{
		// Token: 0x06003D56 RID: 15702 RVA: 0x0017EF9C File Offset: 0x0017D39C
		public MagicBarrierData()
		{
		}

		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x06003D57 RID: 15703 RVA: 0x0017EFA4 File Offset: 0x0017D3A4
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.GhostBreaths;
			}
		}

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06003D58 RID: 15704 RVA: 0x0017EFA7 File Offset: 0x0017D3A7
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D59 RID: 15705 RVA: 0x0017EFAF File Offset: 0x0017D3AF
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.MagicBarrier;
		}

		// Token: 0x06003D5A RID: 15706 RVA: 0x0017EFB8 File Offset: 0x0017D3B8
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.ResistanceBoostRating * 3.0).ToExpression());
			return description;
		}

		// Token: 0x06003D5B RID: 15707 RVA: 0x0017F01B File Offset: 0x0017D41B
		public override double GetEffectPowerValue()
		{
			return this.ResistanceBoostRating;
		}

		// Token: 0x06003D5C RID: 15708 RVA: 0x0017F024 File Offset: 0x0017D424
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = wearer.GetAllLiveFriendlyTargetsIncSelf(false);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectResistanceRating,
						Value = this.ResistanceBoostRating * 3.0,
						ModificationType = ModificationType.Addition,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "magicbarriereffect", new int?(10), new float?(3f), null, false, false, false), false).GetEnumerator();
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
			yield break;
		}

		// Token: 0x04002EA7 RID: 11943
		public int _cost;

		// Token: 0x04002EA8 RID: 11944
		public double ResistanceBoostRating;

		// Token: 0x02000F04 RID: 3844
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600610A RID: 24842 RVA: 0x0017F04E File Offset: 0x0017D44E
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x0600610B RID: 24843 RVA: 0x0017F058 File Offset: 0x0017D458
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = wearer.GetAllLiveFriendlyTargetsIncSelf(false);
					enumerator = targets.GetEnumerator();
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
						Block_4:
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
					if (enumerator.MoveNext())
					{
						battleUnit = enumerator.Current;
						enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectResistanceRating,
								Value = this.ResistanceBoostRating * 3.0,
								ModificationType = ModificationType.Addition,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "magicbarriereffect", new int?(10), new float?(3f), null, false, false, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_4;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001450 RID: 5200
			// (get) Token: 0x0600610C RID: 24844 RVA: 0x0017F258 File Offset: 0x0017D658
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001451 RID: 5201
			// (get) Token: 0x0600610D RID: 24845 RVA: 0x0017F260 File Offset: 0x0017D660
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600610E RID: 24846 RVA: 0x0017F268 File Offset: 0x0017D668
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

			// Token: 0x0600610F RID: 24847 RVA: 0x0017F2FC File Offset: 0x0017D6FC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006110 RID: 24848 RVA: 0x0017F303 File Offset: 0x0017D703
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006111 RID: 24849 RVA: 0x0017F30C File Offset: 0x0017D70C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				MagicBarrierData.<Process>c__Iterator0 <Process>c__Iterator = new MagicBarrierData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0400568C RID: 22156
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400568D RID: 22157
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x0400568E RID: 22158
			internal List<IBattleUnit>.Enumerator $locvar0;

			// Token: 0x0400568F RID: 22159
			internal IBattleUnit <battleUnit>__1;

			// Token: 0x04005690 RID: 22160
			internal IEnumerator $locvar1;

			// Token: 0x04005691 RID: 22161
			internal object <_>__2;

			// Token: 0x04005692 RID: 22162
			internal IDisposable $locvar2;

			// Token: 0x04005693 RID: 22163
			internal MagicBarrierData $this;

			// Token: 0x04005694 RID: 22164
			internal object $current;

			// Token: 0x04005695 RID: 22165
			internal bool $disposing;

			// Token: 0x04005696 RID: 22166
			internal int $PC;
		}
	}
}
