using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008D1 RID: 2257
public class DivineHeartEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F67 RID: 16231 RVA: 0x001901B8 File Offset: 0x0018E5B8
	public DivineHeartEffectProcess()
	{
	}

	// Token: 0x17000B64 RID: 2916
	// (get) Token: 0x06003F68 RID: 16232 RVA: 0x001901C0 File Offset: 0x0018E5C0
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DivineHeart;
		}
	}

	// Token: 0x17000B65 RID: 2917
	// (get) Token: 0x06003F69 RID: 16233 RVA: 0x001901C8 File Offset: 0x0018E5C8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesHeal
			};
		}
	}

	// Token: 0x06003F6A RID: 16234 RVA: 0x001901E4 File Offset: 0x0018E5E4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesHeal && evtData is BattleHeal && specialEffectData is DivineHeartData)
		{
			BattleHeal heal = evtData as BattleHeal;
			if (heal.Healer == effectCarrier && effectCarrier.GetUnitType().GetConfiguration().CorrespondingClassStyle == UnitClassStyle.Healer)
			{
				if (heal.Heals.Any((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized))
				{
					DivineHeartData data = specialEffectData as DivineHeartData;
					bool cast = false;
					foreach (HealComponent healComponent in heal.Heals)
					{
						if (healComponent.IsDirectHeal && (double)UnityEngine.Random.value <= data.Chance)
						{
							cast = true;
						}
					}
					if (cast)
					{
						foreach (AdventureUnitSkill adventureUnitSkill in (from s in heal.Target.Skills
						where s.Skill.CommandType == SkillCommandType.Active
						select s).ToList<AdventureUnitSkill>())
						{
							adventureUnitSkill.RemainingCoolingDownSeconds = new float?(0f);
						}
						IEnumerator enumerator3 = heal.Target.ApplySkillEffect(new FreeCastEffect(effectCarrier, null, null, 1, "freecast"), false).GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								object _ = enumerator3.Current;
								yield return _;
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F50 RID: 3920
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006318 RID: 25368 RVA: 0x0019021E File Offset: 0x0018E61E
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006319 RID: 25369 RVA: 0x00190228 File Offset: 0x0018E628
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesHeal || !(evtData is BattleHeal) || !(specialEffectData is DivineHeartData))
				{
					goto IL_2B0;
				}
				heal = (evtData as BattleHeal);
				if (heal.Healer != effectCarrier || effectCarrier.GetUnitType().GetConfiguration().CorrespondingClassStyle != UnitClassStyle.Healer)
				{
					goto IL_2B0;
				}
				if (!heal.Heals.Any((HealComponent h) => h.IsDirectHeal && !h.IsNeutralized))
				{
					goto IL_2B0;
				}
				data = (specialEffectData as DivineHeartData);
				cast = false;
				enumerator = heal.Heals.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						HealComponent healComponent = enumerator.Current;
						if (healComponent.IsDirectHeal && (double)UnityEngine.Random.value <= data.Chance)
						{
							cast = true;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (!cast)
				{
					goto IL_2B0;
				}
				enumerator2 = (from s in heal.Target.Skills
				where s.Skill.CommandType == SkillCommandType.Active
				select s).ToList<AdventureUnitSkill>().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						AdventureUnitSkill adventureUnitSkill = enumerator2.Current;
						adventureUnitSkill.RemainingCoolingDownSeconds = new float?(0f);
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				enumerator3 = heal.Target.ApplySkillEffect(new FreeCastEffect(effectCarrier, null, null, 1, "freecast"), false).GetEnumerator();
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
				if (enumerator3.MoveNext())
				{
					_ = enumerator3.Current;
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_2B0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014BF RID: 5311
		// (get) Token: 0x0600631A RID: 25370 RVA: 0x00190518 File Offset: 0x0018E918
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014C0 RID: 5312
		// (get) Token: 0x0600631B RID: 25371 RVA: 0x00190520 File Offset: 0x0018E920
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600631C RID: 25372 RVA: 0x00190528 File Offset: 0x0018E928
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600631D RID: 25373 RVA: 0x00190598 File Offset: 0x0018E998
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600631E RID: 25374 RVA: 0x0019059F File Offset: 0x0018E99F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600631F RID: 25375 RVA: 0x001905A8 File Offset: 0x0018E9A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DivineHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DivineHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006320 RID: 25376 RVA: 0x00190600 File Offset: 0x0018EA00
		private static bool <>m__0(HealComponent h)
		{
			return h.IsDirectHeal && !h.IsNeutralized;
		}

		// Token: 0x06006321 RID: 25377 RVA: 0x00190619 File Offset: 0x0018EA19
		private static bool <>m__1(AdventureUnitSkill s)
		{
			return s.Skill.CommandType == SkillCommandType.Active;
		}

		// Token: 0x04005A20 RID: 23072
		internal AdventureEventType evtType;

		// Token: 0x04005A21 RID: 23073
		internal object evtData;

		// Token: 0x04005A22 RID: 23074
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A23 RID: 23075
		internal BattleHeal <heal>__1;

		// Token: 0x04005A24 RID: 23076
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A25 RID: 23077
		internal DivineHeartData <data>__2;

		// Token: 0x04005A26 RID: 23078
		internal bool <cast>__2;

		// Token: 0x04005A27 RID: 23079
		internal List<HealComponent>.Enumerator $locvar0;

		// Token: 0x04005A28 RID: 23080
		internal List<AdventureUnitSkill>.Enumerator $locvar1;

		// Token: 0x04005A29 RID: 23081
		internal IEnumerator $locvar2;

		// Token: 0x04005A2A RID: 23082
		internal object <_>__3;

		// Token: 0x04005A2B RID: 23083
		internal IDisposable $locvar3;

		// Token: 0x04005A2C RID: 23084
		internal object $current;

		// Token: 0x04005A2D RID: 23085
		internal bool $disposing;

		// Token: 0x04005A2E RID: 23086
		internal int $PC;

		// Token: 0x04005A2F RID: 23087
		private static Func<HealComponent, bool> <>f__am$cache0;

		// Token: 0x04005A30 RID: 23088
		private static Func<AdventureUnitSkill, bool> <>f__am$cache1;
	}
}
