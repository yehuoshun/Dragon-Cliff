using System;
using System.Collections.Generic;
using Assets.Scripts.Core.SpecialEffect.Dataload;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.Processors
{
	// Token: 0x020008D8 RID: 2264
	public class EdgelessProcess : SpecialEffectProcessBase
	{
		// Token: 0x06003F84 RID: 16260 RVA: 0x00191F7C File Offset: 0x0019037C
		public EdgelessProcess()
		{
		}

		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x06003F85 RID: 16261 RVA: 0x00191F9A File Offset: 0x0019039A
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x06003F86 RID: 16262 RVA: 0x00191FA2 File Offset: 0x001903A2
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003F87 RID: 16263 RVA: 0x00191FAA File Offset: 0x001903AA
		public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return itemTierNumber >= 86 && itemType.GetResourceCategory() == ResourceCategory.Staff && grade == QualityGrade.Ancient;
		}

		// Token: 0x06003F88 RID: 16264 RVA: 0x00191FC8 File Offset: 0x001903C8
		public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new EdgelessData
				{
					BoostRate = (double)UnityEngine.Random.Range(0.7f, 1.3f),
					PenetrationRate = (double)UnityEngine.Random.Range(0.2f, 0.4f)
				}
			};
		}

		// Token: 0x04002F81 RID: 12161
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.Edgeless;

		// Token: 0x04002F82 RID: 12162
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>();
	}
}
