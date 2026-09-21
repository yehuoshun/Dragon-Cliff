using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000A2C RID: 2604
public class AttributeDisplayValue
{
	// Token: 0x06004717 RID: 18199 RVA: 0x001D137C File Offset: 0x001CF77C
	public AttributeDisplayValue()
	{
	}

	// Token: 0x17000DD1 RID: 3537
	// (get) Token: 0x06004718 RID: 18200 RVA: 0x001D1384 File Offset: 0x001CF784
	// (set) Token: 0x06004719 RID: 18201 RVA: 0x001D138C File Offset: 0x001CF78C
	public AttributeType AttributeType
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeType>k__BackingField = value;
		}
	}

	// Token: 0x17000DD2 RID: 3538
	// (get) Token: 0x0600471A RID: 18202 RVA: 0x001D1395 File Offset: 0x001CF795
	// (set) Token: 0x0600471B RID: 18203 RVA: 0x001D139D File Offset: 0x001CF79D
	public double Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x17000DD3 RID: 3539
	// (get) Token: 0x0600471C RID: 18204 RVA: 0x001D13A6 File Offset: 0x001CF7A6
	// (set) Token: 0x0600471D RID: 18205 RVA: 0x001D13AE File Offset: 0x001CF7AE
	public ModificationType ModificationType
	{
		[CompilerGenerated]
		get
		{
			return this.<ModificationType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ModificationType>k__BackingField = value;
		}
	}

	// Token: 0x17000DD4 RID: 3540
	// (get) Token: 0x0600471E RID: 18206 RVA: 0x001D13B7 File Offset: 0x001CF7B7
	// (set) Token: 0x0600471F RID: 18207 RVA: 0x001D13BF File Offset: 0x001CF7BF
	public AdventurerProfile Profile
	{
		[CompilerGenerated]
		get
		{
			return this.<Profile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Profile>k__BackingField = value;
		}
	}

	// Token: 0x17000DD5 RID: 3541
	// (get) Token: 0x06004720 RID: 18208 RVA: 0x001D13C8 File Offset: 0x001CF7C8
	// (set) Token: 0x06004721 RID: 18209 RVA: 0x001D13D0 File Offset: 0x001CF7D0
	public IBattleUnit Unit
	{
		[CompilerGenerated]
		get
		{
			return this.<Unit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Unit>k__BackingField = value;
		}
	}

	// Token: 0x06004722 RID: 18210 RVA: 0x001D13DC File Offset: 0x001CF7DC
	public Description GetDescription()
	{
		Description description = this.AttributeType.GetDescription();
		if (this.AttributeType.IsResistanceAttribute() && this.Profile != null)
		{
			description.Details1 = description.Details1.ReplaceToBuilder("{rate}", (1.0 - this.Profile.GetDamageMultiplier(BattleUnitExtensions.OutputToResistances[this.AttributeType], this.Profile.GetLevel(), AttributeRetrievalLevel.Skill)).ToExpressionMultiply100()).Replace("{level}", this.Profile.GetLevel().ToString()).ToString();
		}
		if (this.AttributeType == AttributeType.Intelligience || this.AttributeType == AttributeType.Strength || this.AttributeType == AttributeType.Agility)
		{
			if (this.Profile != null)
			{
				if (this.Profile.GetOutputAttributeType() == this.AttributeType)
				{
					description.Details1 = description.Details1.Replace("{rate}", this.Profile.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value.ToExpression());
				}
				else
				{
					description.Details1 = description.Details1.Replace("{rate}", 0.0.ToExpression());
				}
			}
			if (this.Unit != null)
			{
				if (this.Unit.GetOutputAttributeType() == this.AttributeType)
				{
					description.Details1 = description.Details1.Replace("{rate}", this.Unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value.ToExpression());
				}
				else
				{
					description.Details1 = description.Details1.Replace("{rate}", 0.0.ToExpression());
				}
			}
		}
		if (this.AttributeType == AttributeType.Vitality)
		{
			if (this.Profile != null)
			{
				description.Details1 = description.Details1.Replace("{rate}", this.Profile.GetMaxLife(AttributeRetrievalLevel.Skill).ToExpression());
			}
			if (this.Unit != null)
			{
				description.Details1 = description.Details1.Replace("{rate}", this.Unit.GetMaxLife(AttributeRetrievalLevel.Skill).ToExpression());
			}
		}
		if (this.AttributeType == AttributeType.Agility && this.Profile != null)
		{
			double value = this.Profile.GetAttributeValue_Final(AttributeType.DodgeRateAdjustment, AttributeRetrievalLevel.Skill) * this.Profile.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
			double num = this.Profile.GetAttributeValue_Final(AttributeType.HitRateAdjustment, AttributeRetrievalLevel.Skill) * this.Profile.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill);
			List<ISpecialEffectDataLoad> specialEffects = this.Profile.GetSpecialEffects();
			if (specialEffects.OfType<EyeOfPrecisionEffectData>().Any<EyeOfPrecisionEffectData>())
			{
				double rate = specialEffects.OfType<EyeOfPrecisionEffectData>().First<EyeOfPrecisionEffectData>().Rate;
				double num2 = this.Profile.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill) * rate;
				if (num2 > num)
				{
					num2 = num;
				}
				num += num2;
			}
			description.Details1 = description.Details1.ReplaceToBuilder("{hitrating}", num.ToExpression()).Replace("{dodgerating}", value.ToExpression()).ToString();
		}
		return description;
	}

	// Token: 0x06004723 RID: 18211 RVA: 0x001D16E0 File Offset: 0x001CFAE0
	public string ToDisplayValueFormat()
	{
		if (this.AttributeType.IsPercentageValue() || this.ModificationType == ModificationType.Multiplication)
		{
			return this.Value.ToExpressionMultiply100() + "%";
		}
		return this.Value.ToExpression();
	}

	// Token: 0x04003945 RID: 14661
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;

	// Token: 0x04003946 RID: 14662
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;

	// Token: 0x04003947 RID: 14663
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ModificationType <ModificationType>k__BackingField;

	// Token: 0x04003948 RID: 14664
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Profile>k__BackingField;

	// Token: 0x04003949 RID: 14665
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Unit>k__BackingField;
}
