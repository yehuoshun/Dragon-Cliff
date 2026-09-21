using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D3 RID: 2259
public class DomineeringEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F6F RID: 16239 RVA: 0x0019094C File Offset: 0x0018ED4C
	public DomineeringEffectProcess()
	{
	}

	// Token: 0x17000B68 RID: 2920
	// (get) Token: 0x06003F70 RID: 16240 RVA: 0x00190992 File Offset: 0x0018ED92
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B69 RID: 2921
	// (get) Token: 0x06003F71 RID: 16241 RVA: 0x0019099A File Offset: 0x0018ED9A
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003F72 RID: 16242 RVA: 0x001909A4 File Offset: 0x0018EDA4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && specialEffectData is DomineeringData)
		{
			foreach (IBattleUnit battleUnit in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false))
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new EffectImmuneEffect(triggerUnit, null, null, this.Key, 0.7), false).GetEnumerator();
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
		}
		if (evtType == AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime && triggerUnit == effectCarrier)
		{
			foreach (IBattleUnit battleUnit2 in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false))
			{
				List<EffectImmuneEffect> toremove = (from ef in battleUnit2.BattleEffects.OfType<EffectImmuneEffect>()
				where ef.EffectSourceIdentityCode == this.Key
				select ef).ToList<EffectImmuneEffect>();
				foreach (EffectImmuneEffect effectImmuneEffect in toremove)
				{
					IEnumerator enumerator5 = battleUnit2.LooseSkillEffect(effectImmuneEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _2 = enumerator5.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IEnumerator enumerator6 = battleUnit2.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Allresistances,
						Value = 0.0,
						Key = string.Empty,
						ModificationType = ModificationType.Replacement,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						Value = 0.0,
						Key = string.Empty,
						ModificationType = ModificationType.Replacement,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						Value = 0.0,
						ModificationType = ModificationType.Replacement,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Strength,
						Value = 0.0,
						ModificationType = ModificationType.Replacement,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "domineeringdebuff", new int?(1), null, null, false, false), false).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _3 = enumerator6.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator6 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F7C RID: 12156
	private string Key = "domineeringimmunekey";

	// Token: 0x04002F7D RID: 12157
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Domineering;

	// Token: 0x04002F7E RID: 12158
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitReadyInBattle,
		AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime
	};

	// Token: 0x02000F52 RID: 3922
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600632A RID: 25386 RVA: 0x001909E4 File Offset: 0x0018EDE4
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600632B RID: 25387 RVA: 0x001909EC File Offset: 0x0018EDEC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || !(specialEffectData is DomineeringData))
				{
					goto IL_18F;
				}
				enumerator = triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				Block_8:
				try
				{
					switch (num)
					{
					case 2u:
						Block_21:
						try
						{
							switch (num)
							{
							case 2u:
								Block_25:
								try
								{
									switch (num)
									{
									}
									if (enumerator5.MoveNext())
									{
										_2 = enumerator5.Current;
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
										if ((disposable2 = (enumerator5 as IDisposable)) != null)
										{
											disposable2.Dispose();
										}
									}
								}
								break;
							}
							if (enumerator4.MoveNext())
							{
								effectImmuneEffect = enumerator4.Current;
								enumerator5 = battleUnit2.LooseSkillEffect(effectImmuneEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
								num = 4294967293u;
								goto Block_25;
							}
						}
						finally
						{
							if (!flag)
							{
								((IDisposable)enumerator4).Dispose();
							}
						}
						enumerator6 = battleUnit2.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.Allresistances,
								Value = 0.0,
								Key = string.Empty,
								ModificationType = ModificationType.Replacement,
								AttributeModifierType = AttributeModifierType.Skill
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.Resilience,
								Value = 0.0,
								Key = string.Empty,
								ModificationType = ModificationType.Replacement,
								AttributeModifierType = AttributeModifierType.Skill
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.Intelligience,
								Value = 0.0,
								ModificationType = ModificationType.Replacement,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.Strength,
								Value = 0.0,
								ModificationType = ModificationType.Replacement,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "domineeringdebuff", new int?(1), null, null, false, false), false).GetEnumerator();
						num = 4294967293u;
						break;
					case 3u:
						break;
					default:
						goto IL_504;
					}
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_3 = enumerator6.Current;
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
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					IL_504:
					if (enumerator3.MoveNext())
					{
						battleUnit2 = enumerator3.Current;
						toremove = (from ef in battleUnit2.BattleEffects.OfType<EffectImmuneEffect>()
						where ef.EffectSourceIdentityCode == this.Key
						select ef).ToList<EffectImmuneEffect>();
						enumerator4 = toremove.GetEnumerator();
						num = 4294967293u;
						goto Block_21;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_52F;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_10:
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
					enumerator2 = battleUnit.ApplySkillEffect(new EffectImmuneEffect(triggerUnit, null, null, this.Key, 0.7), false).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_18F:
			if (evtType == AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime && triggerUnit == effectCarrier)
			{
				enumerator3 = triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false).GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			}
			IL_52F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014C3 RID: 5315
		// (get) Token: 0x0600632C RID: 25388 RVA: 0x00190FC8 File Offset: 0x0018F3C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014C4 RID: 5316
		// (get) Token: 0x0600632D RID: 25389 RVA: 0x00190FD0 File Offset: 0x0018F3D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600632E RID: 25390 RVA: 0x00190FD8 File Offset: 0x0018F3D8
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
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					case 2u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable2 = (enumerator5 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator4).Dispose();
						}
						break;
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600632F RID: 25391 RVA: 0x00191144 File Offset: 0x0018F544
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006330 RID: 25392 RVA: 0x0019114B File Offset: 0x0018F54B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006331 RID: 25393 RVA: 0x00191154 File Offset: 0x0018F554
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DomineeringEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DomineeringEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006332 RID: 25394 RVA: 0x001911B8 File Offset: 0x0018F5B8
		internal bool <>m__0(EffectImmuneEffect ef)
		{
			return ef.EffectSourceIdentityCode == this.Key;
		}

		// Token: 0x04005A3C RID: 23100
		internal AdventureEventType evtType;

		// Token: 0x04005A3D RID: 23101
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A3E RID: 23102
		internal IBattleUnit triggerUnit;

		// Token: 0x04005A3F RID: 23103
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A40 RID: 23104
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005A41 RID: 23105
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04005A42 RID: 23106
		internal IEnumerator $locvar1;

		// Token: 0x04005A43 RID: 23107
		internal object <_>__2;

		// Token: 0x04005A44 RID: 23108
		internal IDisposable $locvar2;

		// Token: 0x04005A45 RID: 23109
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x04005A46 RID: 23110
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x04005A47 RID: 23111
		internal List<EffectImmuneEffect> <toremove>__4;

		// Token: 0x04005A48 RID: 23112
		internal List<EffectImmuneEffect>.Enumerator $locvar4;

		// Token: 0x04005A49 RID: 23113
		internal EffectImmuneEffect <effectImmuneEffect>__5;

		// Token: 0x04005A4A RID: 23114
		internal IEnumerator $locvar5;

		// Token: 0x04005A4B RID: 23115
		internal object <_>__6;

		// Token: 0x04005A4C RID: 23116
		internal IDisposable $locvar6;

		// Token: 0x04005A4D RID: 23117
		internal IEnumerator $locvar7;

		// Token: 0x04005A4E RID: 23118
		internal object <_>__7;

		// Token: 0x04005A4F RID: 23119
		internal IDisposable $locvar8;

		// Token: 0x04005A50 RID: 23120
		internal DomineeringEffectProcess $this;

		// Token: 0x04005A51 RID: 23121
		internal object $current;

		// Token: 0x04005A52 RID: 23122
		internal bool $disposing;

		// Token: 0x04005A53 RID: 23123
		internal int $PC;
	}
}
