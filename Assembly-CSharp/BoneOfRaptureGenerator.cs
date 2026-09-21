using System;
using System.Collections.Generic;

// Token: 0x0200068A RID: 1674
public class BoneOfRaptureGenerator : GemGeneratorBase
{
	// Token: 0x06002CA8 RID: 11432 RVA: 0x00125EE0 File Offset: 0x001242E0
	public BoneOfRaptureGenerator()
	{
	}

	// Token: 0x17000592 RID: 1426
	// (get) Token: 0x06002CA9 RID: 11433 RVA: 0x00125F79 File Offset: 0x00124379
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CAA RID: 11434 RVA: 0x00125F81 File Offset: 0x00124381
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x04002688 RID: 9864
	private ResourceType _correspondingGemType = ResourceType.BoneOfRapture;

	// Token: 0x04002689 RID: 9865
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.TurnStartHeal),
		new AttributePresentable(100, AttributeType.BattleStartHeal),
		new AttributePresentable(100, AttributeType.Vitality),
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Intelligience),
		new AttributePresentable(100, AttributeType.EffectResistanceRating)
	};
}
