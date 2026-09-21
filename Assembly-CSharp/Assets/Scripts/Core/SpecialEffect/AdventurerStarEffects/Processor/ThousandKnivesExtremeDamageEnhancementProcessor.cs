using System;
using System.Collections.Generic;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A5 RID: 1957
	public class ThousandKnivesExtremeDamageEnhancementProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003974 RID: 14708 RVA: 0x00175AAC File Offset: 0x00173EAC
		public ThousandKnivesExtremeDamageEnhancementProcessor()
		{
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06003975 RID: 14709 RVA: 0x00175ACA File Offset: 0x00173ECA
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06003976 RID: 14710 RVA: 0x00175AD2 File Offset: 0x00173ED2
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x00175ADA File Offset: 0x00173EDA
		public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return itemType.GetResourceCategory().IsWeapon() && itemTierNumber > 35 && grade == QualityGrade.Ancient;
		}

		// Token: 0x06003978 RID: 14712 RVA: 0x00175AFC File Offset: 0x00173EFC
		public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ThousandKnivesExtremeDamageEnhancementData
				{
					ExtraDamageRate = (double)UnityEngine.Random.Range(8f, 16f)
				}
			};
		}

		// Token: 0x06003979 RID: 14713 RVA: 0x00175B33 File Offset: 0x00173F33
		public override int GetPresence()
		{
			return 100;
		}

		// Token: 0x04002C7F RID: 11391
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.ThousandKnivesExtremeDamageEnhancement;

		// Token: 0x04002C80 RID: 11392
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>();
	}
}
