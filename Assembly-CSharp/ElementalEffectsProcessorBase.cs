using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000B41 RID: 2881
public class ElementalEffectsProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CA8 RID: 19624 RVA: 0x001F23E5 File Offset: 0x001F07E5
	public ElementalEffectsProcessorBase()
	{
	}

	// Token: 0x17001082 RID: 4226
	// (get) Token: 0x06004CA9 RID: 19625 RVA: 0x001F23FC File Offset: 0x001F07FC
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CAA RID: 19626 RVA: 0x001F2404 File Offset: 0x001F0804
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CAB RID: 19627 RVA: 0x001F240C File Offset: 0x001F080C
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return profile.GetLevel() >= 12 && this.GetPossibleElements(profile).Any<OutputType>();
	}

	// Token: 0x06004CAC RID: 19628 RVA: 0x001F242C File Offset: 0x001F082C
	private List<OutputType> GetPossibleElements(AdventurerProfile profile)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		return (from e in allDamageElements
		where profile.UpgradedCards.SelectMany((CardUpgrade c) => c.Effects).OfType<ElementEffectData>().All((ElementEffectData d) => d.ElementType != e)
		select e).ToList<OutputType>();
	}

	// Token: 0x06004CAD RID: 19629 RVA: 0x001F2464 File Offset: 0x001F0864
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		List<OutputType> possibleElements = this.GetPossibleElements(profile);
		OutputType elementType = possibleElements[UnityEngine.Random.Range(0, possibleElements.Count)];
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.ElementalEffects,
			Modifiers = new List<AttributeModifier>(),
			Effects = new List<ISpecialEffectDataLoad>
			{
				new ElementEffectData
				{
					ElementType = elementType
				}
			},
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004CAE RID: 19630 RVA: 0x001F24ED File Offset: 0x001F08ED
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CAF RID: 19631 RVA: 0x001F24EF File Offset: 0x001F08EF
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003AFC RID: 15100
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.ElementalEffects;

	// Token: 0x04003AFD RID: 15101
	private readonly int _presence = 100;

	// Token: 0x02001082 RID: 4226
	[CompilerGenerated]
	private sealed class <GetPossibleElements>c__AnonStorey0
	{
		// Token: 0x06006985 RID: 27013 RVA: 0x001F24F1 File Offset: 0x001F08F1
		public <GetPossibleElements>c__AnonStorey0()
		{
		}

		// Token: 0x06006986 RID: 27014 RVA: 0x001F24FC File Offset: 0x001F08FC
		internal bool <>m__0(OutputType e)
		{
			return this.profile.UpgradedCards.SelectMany((CardUpgrade c) => c.Effects).OfType<ElementEffectData>().All((ElementEffectData d) => d.ElementType != e);
		}

		// Token: 0x06006987 RID: 27015 RVA: 0x001F2560 File Offset: 0x001F0960
		private static IEnumerable<ISpecialEffectDataLoad> <>m__1(CardUpgrade c)
		{
			return c.Effects;
		}

		// Token: 0x04006403 RID: 25603
		internal AdventurerProfile profile;

		// Token: 0x04006404 RID: 25604
		private static Func<CardUpgrade, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache0;

		// Token: 0x02001083 RID: 4227
		private sealed class <GetPossibleElements>c__AnonStorey1
		{
			// Token: 0x06006988 RID: 27016 RVA: 0x001F2568 File Offset: 0x001F0968
			public <GetPossibleElements>c__AnonStorey1()
			{
			}

			// Token: 0x06006989 RID: 27017 RVA: 0x001F2570 File Offset: 0x001F0970
			internal bool <>m__0(ElementEffectData d)
			{
				return d.ElementType != this.e;
			}

			// Token: 0x04006405 RID: 25605
			internal OutputType e;

			// Token: 0x04006406 RID: 25606
			internal ElementalEffectsProcessorBase.<GetPossibleElements>c__AnonStorey0 <>f__ref$0;
		}
	}
}
