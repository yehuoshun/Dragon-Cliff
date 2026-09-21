using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008BD RID: 2237
public class ConjourerPetEnhancementProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F13 RID: 16147 RVA: 0x001894F5 File Offset: 0x001878F5
	public ConjourerPetEnhancementProcess()
	{
	}

	// Token: 0x17000B3C RID: 2876
	// (get) Token: 0x06003F14 RID: 16148 RVA: 0x001894FD File Offset: 0x001878FD
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ConjourerPetEnhancement;
		}
	}

	// Token: 0x17000B3D RID: 2877
	// (get) Token: 0x06003F15 RID: 16149 RVA: 0x00189504 File Offset: 0x00187904
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

	// Token: 0x06003F16 RID: 16150 RVA: 0x00189520 File Offset: 0x00187920
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is ConjourerPetEnhancementData)
		{
			ConjourerPetEnhancementData data = specialEffectData as ConjourerPetEnhancementData;
			AdventureUnitSkill activeSkill = effectCarrier.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.SkillType == SkillType.SpiritOfDemon);
			if (activeSkill != null)
			{
				IEnumerator enumerator = (SkillType.SpiritOfDemon.GetSkillLogic() as SpiritOfDemon).SummonPet(activeSkill, data.Type).GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000F32 RID: 3890
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006248 RID: 25160 RVA: 0x00189559 File Offset: 0x00187959
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006249 RID: 25161 RVA: 0x00189564 File Offset: 0x00187964
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is ConjourerPetEnhancementData))
				{
					goto IL_155;
				}
				data = (specialEffectData as ConjourerPetEnhancementData);
				activeSkill = effectCarrier.Skills.FirstOrDefault((AdventureUnitSkill s) => s.Skill.SkillType == SkillType.SpiritOfDemon);
				if (activeSkill == null)
				{
					goto IL_155;
				}
				enumerator = (SkillType.SpiritOfDemon.GetSkillLogic() as SpiritOfDemon).SummonPet(activeSkill, data.Type).GetEnumerator();
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
			IL_155:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001493 RID: 5267
		// (get) Token: 0x0600624A RID: 25162 RVA: 0x001896E0 File Offset: 0x00187AE0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001494 RID: 5268
		// (get) Token: 0x0600624B RID: 25163 RVA: 0x001896E8 File Offset: 0x00187AE8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600624C RID: 25164 RVA: 0x001896F0 File Offset: 0x00187AF0
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

		// Token: 0x0600624D RID: 25165 RVA: 0x00189760 File Offset: 0x00187B60
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600624E RID: 25166 RVA: 0x00189767 File Offset: 0x00187B67
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600624F RID: 25167 RVA: 0x00189770 File Offset: 0x00187B70
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ConjourerPetEnhancementProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ConjourerPetEnhancementProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006250 RID: 25168 RVA: 0x001897C8 File Offset: 0x00187BC8
		private static bool <>m__0(AdventureUnitSkill s)
		{
			return s.Skill.SkillType == SkillType.SpiritOfDemon;
		}

		// Token: 0x0400588E RID: 22670
		internal AdventureEventType evtType;

		// Token: 0x0400588F RID: 22671
		internal IBattleUnit triggerUnit;

		// Token: 0x04005890 RID: 22672
		internal IBattleUnit effectCarrier;

		// Token: 0x04005891 RID: 22673
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005892 RID: 22674
		internal ConjourerPetEnhancementData <data>__1;

		// Token: 0x04005893 RID: 22675
		internal AdventureUnitSkill <activeSkill>__1;

		// Token: 0x04005894 RID: 22676
		internal IEnumerator $locvar0;

		// Token: 0x04005895 RID: 22677
		internal object <_>__2;

		// Token: 0x04005896 RID: 22678
		internal IDisposable $locvar1;

		// Token: 0x04005897 RID: 22679
		internal object $current;

		// Token: 0x04005898 RID: 22680
		internal bool $disposing;

		// Token: 0x04005899 RID: 22681
		internal int $PC;

		// Token: 0x0400589A RID: 22682
		private static Func<AdventureUnitSkill, bool> <>f__am$cache0;
	}
}
