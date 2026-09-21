using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x0200079E RID: 1950
	public class DrunkReaderReviveProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003956 RID: 14678 RVA: 0x00173A3C File Offset: 0x00171E3C
		public DrunkReaderReviveProcessor()
		{
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06003957 RID: 14679 RVA: 0x00173A6F File Offset: 0x00171E6F
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x06003958 RID: 14680 RVA: 0x00173A77 File Offset: 0x00171E77
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x00173A80 File Offset: 0x00171E80
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitRevived && effectCarrier == triggerUnit && effectCarrier.GetUnitType() == UnitClass.DrunkReader && specialEffectData is DrunkReaderReviveData)
			{
				DrunkReaderReviveData data = specialEffectData as DrunkReaderReviveData;
				IEnumerator enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Multiplication,
						Value = data.BoostRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "drunkreaderreviveboost", new int?(10), null, null, false, false, true), false).GetEnumerator();
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

		// Token: 0x0600395A RID: 14682 RVA: 0x00173AB9 File Offset: 0x00171EB9
		public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return grade == QualityGrade.Ancient && itemTierNumber > 35 && itemType.GetResourceCategory() == ResourceCategory.Robe;
		}

		// Token: 0x0600395B RID: 14683 RVA: 0x00173AD8 File Offset: 0x00171ED8
		public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DrunkReaderReviveData
				{
					BoostRate = (double)UnityEngine.Random.Range(0.5f, 2f)
				}
			};
		}

		// Token: 0x04002C71 RID: 11377
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.DrunkReaderRevive;

		// Token: 0x04002C72 RID: 11378
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitRevived
		};

		// Token: 0x02000EEA RID: 3818
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006050 RID: 24656 RVA: 0x00173B0F File Offset: 0x00171F0F
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x06006051 RID: 24657 RVA: 0x00173B18 File Offset: 0x00171F18
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitRevived || effectCarrier != triggerUnit || effectCarrier.GetUnitType() != UnitClass.DrunkReader || !(specialEffectData is DrunkReaderReviveData))
					{
						goto IL_188;
					}
					data = (specialEffectData as DrunkReaderReviveData);
					enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Intelligience,
							ModificationType = ModificationType.Multiplication,
							Value = data.BoostRate,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "drunkreaderreviveboost", new int?(10), null, null, false, false, true), false).GetEnumerator();
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
				IL_188:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001424 RID: 5156
			// (get) Token: 0x06006052 RID: 24658 RVA: 0x00173CC8 File Offset: 0x001720C8
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001425 RID: 5157
			// (get) Token: 0x06006053 RID: 24659 RVA: 0x00173CD0 File Offset: 0x001720D0
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006054 RID: 24660 RVA: 0x00173CD8 File Offset: 0x001720D8
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

			// Token: 0x06006055 RID: 24661 RVA: 0x00173D48 File Offset: 0x00172148
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006056 RID: 24662 RVA: 0x00173D4F File Offset: 0x0017214F
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006057 RID: 24663 RVA: 0x00173D58 File Offset: 0x00172158
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				DrunkReaderReviveProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DrunkReaderReviveProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x04005566 RID: 21862
			internal AdventureEventType evtType;

			// Token: 0x04005567 RID: 21863
			internal IBattleUnit effectCarrier;

			// Token: 0x04005568 RID: 21864
			internal IBattleUnit triggerUnit;

			// Token: 0x04005569 RID: 21865
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x0400556A RID: 21866
			internal DrunkReaderReviveData <data>__1;

			// Token: 0x0400556B RID: 21867
			internal IEnumerator $locvar0;

			// Token: 0x0400556C RID: 21868
			internal object <_>__2;

			// Token: 0x0400556D RID: 21869
			internal IDisposable $locvar1;

			// Token: 0x0400556E RID: 21870
			internal object $current;

			// Token: 0x0400556F RID: 21871
			internal bool $disposing;

			// Token: 0x04005570 RID: 21872
			internal int $PC;
		}
	}
}
