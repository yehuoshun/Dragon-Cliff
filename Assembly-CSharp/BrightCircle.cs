using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006E8 RID: 1768
public class BrightCircle : MainSkillBase
{
	// Token: 0x0600300B RID: 12299 RVA: 0x001478B3 File Offset: 0x00145CB3
	public BrightCircle()
	{
	}

	// Token: 0x0600300C RID: 12300 RVA: 0x001478BC File Offset: 0x00145CBC
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new BrightCircleBoostEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SlotNumber = 1
			},
			new BrightCircleDispelEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new BrightCircleBoostEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SlotNumber = 2
			}
		};
	}

	// Token: 0x0600300D RID: 12301 RVA: 0x00147988 File Offset: 0x00145D88
	private double GetBaseBoostValue(Skill skill)
	{
		return (double)(200 + (skill.Level - 1) * 100);
	}

	// Token: 0x0600300E RID: 12302 RVA: 0x0014799C File Offset: 0x00145D9C
	private double GetAdditionalRate(Skill skill)
	{
		return 0.3;
	}

	// Token: 0x0600300F RID: 12303 RVA: 0x001479A8 File Offset: 0x00145DA8
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.BaseBoostValue, this.GetBaseBoostValue(skill).ToExpression()).Replace(this.AdditionalBoostRate, this.GetAdditionalRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003010 RID: 12304 RVA: 0x001479F5 File Offset: 0x00145DF5
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003011 RID: 12305 RVA: 0x001479FC File Offset: 0x00145DFC
	public override IEnumerable Cast(AdventureUnitSkill skill)
	{
		IBattleUnit caster = skill.SourceUnit;
		List<IBattleUnit> targets = caster.GetAllLiveFriendlyTargetsIncSelf(true);
		double bvalue = this.GetBaseBoostValue(skill.Skill);
		double additionalRate = this.GetAdditionalRate(skill.Skill);
		List<BrightCircleBoostEnhancementTalent> boosts = skill.GetActiveTalents().OfType<BrightCircleBoostEnhancementTalent>().ToList<BrightCircleBoostEnhancementTalent>();
		int totalDispels = (!skill.GetActiveTalents().OfType<BrightCircleDispelEnhancementTalent>().Any<BrightCircleDispelEnhancementTalent>()) ? 0 : BrightCircleDispelEnhancementTalent.NumberOfDispels;
		foreach (IBattleUnit battleUnit in targets)
		{
			IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateBrightCircleEffect(skill, bvalue, additionalRate, base.GetType().FullName), false).GetEnumerator();
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
			foreach (BrightCircleBoostEnhancementTalent brightCircleBoostEnhancementTalent in boosts)
			{
				IEnumerator enumerator4 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = brightCircleBoostEnhancementTalent.GetAttributeType(),
						ModificationType = ((brightCircleBoostEnhancementTalent.GetAttributeType() != AttributeType.Agility) ? ModificationType.Addition : ModificationType.Multiplication),
						Value = brightCircleBoostEnhancementTalent.GetRate(),
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "brightcircleboost", new int?(2), null, new int?(2), false, true, false), false).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			if (totalDispels > 0)
			{
				IEnumerator enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(battleUnit, new int?(totalDispels)).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000660 RID: 1632
	// (get) Token: 0x06003012 RID: 12306 RVA: 0x00147A26 File Offset: 0x00145E26
	public override SkillType SkillType
	{
		get
		{
			return SkillType.BrightCircle;
		}
	}

	// Token: 0x17000661 RID: 1633
	// (get) Token: 0x06003013 RID: 12307 RVA: 0x00147A2D File Offset: 0x00145E2D
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000662 RID: 1634
	// (get) Token: 0x06003014 RID: 12308 RVA: 0x00147A35 File Offset: 0x00145E35
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000663 RID: 1635
	// (get) Token: 0x06003015 RID: 12309 RVA: 0x00147A38 File Offset: 0x00145E38
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000664 RID: 1636
	// (get) Token: 0x06003016 RID: 12310 RVA: 0x00147A3B File Offset: 0x00145E3B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x17000665 RID: 1637
	// (get) Token: 0x06003017 RID: 12311 RVA: 0x00147A3E File Offset: 0x00145E3E
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x0400278A RID: 10122
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E4E RID: 3662
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C06 RID: 23558 RVA: 0x00147A41 File Offset: 0x00145E41
		[DebuggerHidden]
		public <Cast>c__Iterator0()
		{
		}

		// Token: 0x06005C07 RID: 23559 RVA: 0x00147A4C File Offset: 0x00145E4C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				caster = skill.SourceUnit;
				targets = caster.GetAllLiveFriendlyTargetsIncSelf(true);
				bvalue = base.GetBaseBoostValue(skill.Skill);
				additionalRate = base.GetAdditionalRate(skill.Skill);
				boosts = skill.GetActiveTalents().OfType<BrightCircleBoostEnhancementTalent>().ToList<BrightCircleBoostEnhancementTalent>();
				totalDispels = ((!skill.GetActiveTalents().OfType<BrightCircleDispelEnhancementTalent>().Any<BrightCircleDispelEnhancementTalent>()) ? 0 : BrightCircleDispelEnhancementTalent.NumberOfDispels);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_5:
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
					enumerator3 = boosts.GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				case 3u:
					goto IL_395;
				default:
					goto IL_417;
				}
				try
				{
					switch (num)
					{
					case 2u:
						Block_18:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_2 = enumerator4.Current;
								this.$current = _2;
								if (!this.$disposing)
								{
									this.$PC = 2;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator3.MoveNext())
					{
						brightCircleBoostEnhancementTalent = enumerator3.Current;
						enumerator4 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = brightCircleBoostEnhancementTalent.GetAttributeType(),
								ModificationType = ((brightCircleBoostEnhancementTalent.GetAttributeType() != AttributeType.Agility) ? ModificationType.Addition : ModificationType.Multiplication),
								Value = brightCircleBoostEnhancementTalent.GetRate(),
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "brightcircleboost", new int?(2), null, new int?(2), false, true, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_18;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				if (totalDispels <= 0)
				{
					goto IL_417;
				}
				enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(battleUnit, new int?(totalDispels)).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_395:
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_3 = enumerator5.Current;
						this.$current = _3;
						if (!this.$disposing)
						{
							this.$PC = 3;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				IL_417:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateBrightCircleEffect(skill, bvalue, additionalRate, base.GetType().FullName), false).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
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

		// Token: 0x17001332 RID: 4914
		// (get) Token: 0x06005C08 RID: 23560 RVA: 0x00147F24 File Offset: 0x00146324
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001333 RID: 4915
		// (get) Token: 0x06005C09 RID: 23561 RVA: 0x00147F2C File Offset: 0x0014632C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C0A RID: 23562 RVA: 0x00147F34 File Offset: 0x00146334
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					case 1u:
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
						break;
					case 2u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator3).Dispose();
						}
						break;
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005C0B RID: 23563 RVA: 0x00148080 File Offset: 0x00146480
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C0C RID: 23564 RVA: 0x00148087 File Offset: 0x00146487
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C0D RID: 23565 RVA: 0x00148090 File Offset: 0x00146490
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BrightCircle.<Cast>c__Iterator0 <Cast>c__Iterator = new BrightCircle.<Cast>c__Iterator0();
			<Cast>c__Iterator.$this = this;
			<Cast>c__Iterator.skill = skill;
			return <Cast>c__Iterator;
		}

		// Token: 0x04004E31 RID: 20017
		internal AdventureUnitSkill skill;

		// Token: 0x04004E32 RID: 20018
		internal IBattleUnit <caster>__0;

		// Token: 0x04004E33 RID: 20019
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004E34 RID: 20020
		internal double <bvalue>__0;

		// Token: 0x04004E35 RID: 20021
		internal double <additionalRate>__0;

		// Token: 0x04004E36 RID: 20022
		internal List<BrightCircleBoostEnhancementTalent> <boosts>__0;

		// Token: 0x04004E37 RID: 20023
		internal int <totalDispels>__0;

		// Token: 0x04004E38 RID: 20024
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004E39 RID: 20025
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004E3A RID: 20026
		internal IEnumerator $locvar1;

		// Token: 0x04004E3B RID: 20027
		internal object <_>__2;

		// Token: 0x04004E3C RID: 20028
		internal IDisposable $locvar2;

		// Token: 0x04004E3D RID: 20029
		internal List<BrightCircleBoostEnhancementTalent>.Enumerator $locvar3;

		// Token: 0x04004E3E RID: 20030
		internal BrightCircleBoostEnhancementTalent <brightCircleBoostEnhancementTalent>__3;

		// Token: 0x04004E3F RID: 20031
		internal IEnumerator $locvar4;

		// Token: 0x04004E40 RID: 20032
		internal object <_>__4;

		// Token: 0x04004E41 RID: 20033
		internal IDisposable $locvar5;

		// Token: 0x04004E42 RID: 20034
		internal IEnumerator $locvar6;

		// Token: 0x04004E43 RID: 20035
		internal object <_>__5;

		// Token: 0x04004E44 RID: 20036
		internal IDisposable $locvar7;

		// Token: 0x04004E45 RID: 20037
		internal BrightCircle $this;

		// Token: 0x04004E46 RID: 20038
		internal object $current;

		// Token: 0x04004E47 RID: 20039
		internal bool $disposing;

		// Token: 0x04004E48 RID: 20040
		internal int $PC;
	}
}
