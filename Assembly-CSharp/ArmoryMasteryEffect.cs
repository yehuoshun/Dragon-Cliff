using System;

// Token: 0x0200098B RID: 2443
[Serializable]
public class ArmoryMasteryEffect : TownEffectBase
{
	// Token: 0x060042ED RID: 17133 RVA: 0x001B53A8 File Offset: 0x001B37A8
	public ArmoryMasteryEffect(int? lastingNumberOfDays, int startingOnGameDays, int numberOfAdditionalAttributes, int numberOfTriggersLeft) : base(lastingNumberOfDays, startingOnGameDays)
	{
		this.NumberOfAdditionalAttributes = numberOfAdditionalAttributes;
		this.NumberOfTriggersLeft = numberOfTriggersLeft;
	}

	// Token: 0x17000D3D RID: 3389
	// (get) Token: 0x060042EE RID: 17134 RVA: 0x001B53C1 File Offset: 0x001B37C1
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.ArmoryMasteryEffect;
		}
	}

	// Token: 0x060042EF RID: 17135 RVA: 0x001B53C4 File Offset: 0x001B37C4
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is ArmoryMasteryEffect;
	}

	// Token: 0x060042F0 RID: 17136 RVA: 0x001B53D0 File Offset: 0x001B37D0
	public override void Merge(TownEffectBase effect)
	{
		ArmoryMasteryEffect armoryMasteryEffect = effect as ArmoryMasteryEffect;
		if (armoryMasteryEffect.NumberOfAdditionalAttributes > this.NumberOfAdditionalAttributes)
		{
			this.NumberOfAdditionalAttributes = armoryMasteryEffect.NumberOfAdditionalAttributes;
		}
		this.NumberOfTriggersLeft += armoryMasteryEffect.NumberOfTriggersLeft;
	}

	// Token: 0x060042F1 RID: 17137 RVA: 0x001B5414 File Offset: 0x001B3814
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{extra}", this.NumberOfAdditionalAttributes.ToString()).Replace("{total}", this.NumberOfTriggersLeft.ToString());
		return localization;
	}

	// Token: 0x060042F2 RID: 17138 RVA: 0x001B546B File Offset: 0x001B386B
	public void RemoveTrigger(int count)
	{
		this.NumberOfTriggersLeft -= count;
		if (this.NumberOfTriggersLeft <= 0)
		{
			GameWorld.instance.PlayerProfile.RemoveTownEffect(this);
		}
	}

	// Token: 0x040032F1 RID: 13041
	public int NumberOfAdditionalAttributes;

	// Token: 0x040032F2 RID: 13042
	public int NumberOfTriggersLeft;
}
