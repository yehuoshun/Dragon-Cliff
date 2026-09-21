using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008DD RID: 2269
public class EnlightmentEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F9B RID: 16283 RVA: 0x00192982 File Offset: 0x00190D82
	public EnlightmentEffectProcess()
	{
	}

	// Token: 0x17000B7C RID: 2940
	// (get) Token: 0x06003F9C RID: 16284 RVA: 0x00192992 File Offset: 0x00190D92
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B7D RID: 2941
	// (get) Token: 0x06003F9D RID: 16285 RVA: 0x0019299C File Offset: 0x00190D9C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06003F9E RID: 16286 RVA: 0x001929B8 File Offset: 0x00190DB8
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is EnlightmentEffectData)
		{
			EnlightmentEffectData data = specialEffectData as EnlightmentEffectData;
			data.NumberOfSecondsSoFar++;
			if (data.NumberOfSecondsSoFar >= data.NumberOfSeconds)
			{
				AdventureUnitSkill activeSkill = effectCarrier.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.SkillType == data.SkillType);
				if (activeSkill != null)
				{
					ActiveSkillLogicBase logic = activeSkill.Skill.GetSkillLogic() as ActiveSkillLogicBase;
					if (logic != null)
					{
						ActiveSkillTargetingStrategyBase stratregy = logic.InitiatingTargetingStrategy(activeSkill);
						if (stratregy.IsResolved)
						{
							IEnumerator enumerator = logic.Cast(activeSkill, stratregy, true).GetEnumerator();
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
					}
				}
				data.NumberOfSecondsSoFar = 0;
			}
		}
		yield break;
	}

	// Token: 0x06003F9F RID: 16287 RVA: 0x001929E4 File Offset: 0x00190DE4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is EnlightmentEffectData)
		{
			EnlightmentEffectData enlightmentEffectData = specialEffectData as EnlightmentEffectData;
			enlightmentEffectData.NumberOfSecondsSoFar = 0;
			effectCarrier.Skills.Add(enlightmentEffectData.SkillType.CreateMonsterSkill(enlightmentEffectData.Level).InitializeBattleUnitSkill(effectCarrier));
		}
		yield break;
	}

	// Token: 0x04002F87 RID: 12167
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.Enlightment;

	// Token: 0x02000F59 RID: 3929
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006361 RID: 25441 RVA: 0x00192A1D File Offset: 0x00190E1D
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006362 RID: 25442 RVA: 0x00192A28 File Offset: 0x00190E28
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (!(specialEffectData is EnlightmentEffectData))
				{
					goto IL_1D5;
				}
				EnlightmentEffectData data = specialEffectData as EnlightmentEffectData;
				data.NumberOfSecondsSoFar++;
				if (data.NumberOfSecondsSoFar < data.NumberOfSeconds)
				{
					goto IL_1D5;
				}
				activeSkill = effectCarrier.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.SkillType == data.SkillType);
				if (activeSkill == null)
				{
					goto IL_1C4;
				}
				logic = (activeSkill.Skill.GetSkillLogic() as ActiveSkillLogicBase);
				if (logic == null)
				{
					goto IL_1C4;
				}
				stratregy = logic.InitiatingTargetingStrategy(activeSkill);
				if (!stratregy.IsResolved)
				{
					goto IL_1C4;
				}
				enumerator = logic.Cast(activeSkill, stratregy, true).GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1C4:
			<AsActiveUnitPerSecondProcess>c__AnonStorey.data.NumberOfSecondsSoFar = 0;
			IL_1D5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014CF RID: 5327
		// (get) Token: 0x06006363 RID: 25443 RVA: 0x00192C24 File Offset: 0x00191024
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014D0 RID: 5328
		// (get) Token: 0x06006364 RID: 25444 RVA: 0x00192C2C File Offset: 0x0019102C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006365 RID: 25445 RVA: 0x00192C34 File Offset: 0x00191034
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

		// Token: 0x06006366 RID: 25446 RVA: 0x00192CA4 File Offset: 0x001910A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006367 RID: 25447 RVA: 0x00192CAB File Offset: 0x001910AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006368 RID: 25448 RVA: 0x00192CB4 File Offset: 0x001910B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnlightmentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new EnlightmentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005A9C RID: 23196
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A9D RID: 23197
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A9E RID: 23198
		internal AdventureUnitSkill <activeSkill>__2;

		// Token: 0x04005A9F RID: 23199
		internal ActiveSkillLogicBase <logic>__3;

		// Token: 0x04005AA0 RID: 23200
		internal ActiveSkillTargetingStrategyBase <stratregy>__4;

		// Token: 0x04005AA1 RID: 23201
		internal IEnumerator $locvar0;

		// Token: 0x04005AA2 RID: 23202
		internal object <_>__5;

		// Token: 0x04005AA3 RID: 23203
		internal IDisposable $locvar1;

		// Token: 0x04005AA4 RID: 23204
		internal object $current;

		// Token: 0x04005AA5 RID: 23205
		internal bool $disposing;

		// Token: 0x04005AA6 RID: 23206
		internal int $PC;

		// Token: 0x04005AA7 RID: 23207
		private EnlightmentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvar2;

		// Token: 0x02000F5B RID: 3931
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x06006371 RID: 25457 RVA: 0x00192CF4 File Offset: 0x001910F4
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06006372 RID: 25458 RVA: 0x00192CFC File Offset: 0x001910FC
			internal bool <>m__0(AdventureUnitSkill s)
			{
				return s.Skill.SkillType == this.data.SkillType;
			}

			// Token: 0x04005AAF RID: 23215
			internal EnlightmentEffectData data;

			// Token: 0x04005AB0 RID: 23216
			internal EnlightmentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000F5A RID: 3930
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006369 RID: 25449 RVA: 0x00192D16 File Offset: 0x00191116
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x0600636A RID: 25450 RVA: 0x00192D20 File Offset: 0x00191120
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is EnlightmentEffectData)
				{
					EnlightmentEffectData enlightmentEffectData = specialEffectData as EnlightmentEffectData;
					enlightmentEffectData.NumberOfSecondsSoFar = 0;
					effectCarrier.Skills.Add(enlightmentEffectData.SkillType.CreateMonsterSkill(enlightmentEffectData.Level).InitializeBattleUnitSkill(effectCarrier));
				}
			}
			return false;
		}

		// Token: 0x170014D1 RID: 5329
		// (get) Token: 0x0600636B RID: 25451 RVA: 0x00192DB2 File Offset: 0x001911B2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014D2 RID: 5330
		// (get) Token: 0x0600636C RID: 25452 RVA: 0x00192DBA File Offset: 0x001911BA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600636D RID: 25453 RVA: 0x00192DC2 File Offset: 0x001911C2
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600636E RID: 25454 RVA: 0x00192DC4 File Offset: 0x001911C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600636F RID: 25455 RVA: 0x00192DCB File Offset: 0x001911CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006370 RID: 25456 RVA: 0x00192DD4 File Offset: 0x001911D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EnlightmentEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new EnlightmentEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005AA8 RID: 23208
		internal AdventureEventType evtType;

		// Token: 0x04005AA9 RID: 23209
		internal IBattleUnit triggerUnit;

		// Token: 0x04005AAA RID: 23210
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AAB RID: 23211
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AAC RID: 23212
		internal object $current;

		// Token: 0x04005AAD RID: 23213
		internal bool $disposing;

		// Token: 0x04005AAE RID: 23214
		internal int $PC;
	}
}
