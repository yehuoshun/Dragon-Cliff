using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000920 RID: 2336
public class ShiftShieldEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040C1 RID: 16577 RVA: 0x001A39DC File Offset: 0x001A1DDC
	public ShiftShieldEffectProcess()
	{
	}

	// Token: 0x17000C01 RID: 3073
	// (get) Token: 0x060040C2 RID: 16578 RVA: 0x001A39E4 File Offset: 0x001A1DE4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ShiftShield;
		}
	}

	// Token: 0x17000C02 RID: 3074
	// (get) Token: 0x060040C3 RID: 16579 RVA: 0x001A39E8 File Offset: 0x001A1DE8
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

	// Token: 0x060040C4 RID: 16580 RVA: 0x001A3A04 File Offset: 0x001A1E04
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is ShiftShieldData)
		{
			ShiftShieldData data = specialEffectData as ShiftShieldData;
			data.Counter++;
			if (data.Counter >= data.NumberOfSecondsPerShift)
			{
				data.Counter -= data.NumberOfSecondsPerShift;
				List<OutputType> elements = UnitExtensions.GetAllDamageElements();
				elements.Shuffle<OutputType>();
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName, null, new float?((float)data.NumberOfSecondsPerShift), effectCarrier, elements.Take(data.NumberOfElements).ToList<OutputType>(), true, 1), false).GetEnumerator();
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

	// Token: 0x060040C5 RID: 16581 RVA: 0x001A3A38 File Offset: 0x001A1E38
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is ShiftShieldData)
		{
			ShiftShieldData data = specialEffectData as ShiftShieldData;
			data.Counter = 0;
			List<OutputType> elements = UnitExtensions.GetAllDamageElements();
			elements.Shuffle<OutputType>();
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName, null, new float?((float)data.NumberOfSecondsPerShift), effectCarrier, elements.Take(data.NumberOfElements).ToList<OutputType>(), true, 1), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x060040C6 RID: 16582 RVA: 0x001A3A78 File Offset: 0x001A1E78
	public override bool CanBeStarEffects(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x060040C7 RID: 16583 RVA: 0x001A3A7C File Offset: 0x001A1E7C
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ShiftShieldData
			{
				NumberOfSecondsPerShift = 3,
				Counter = 0,
				IsStar = true,
				NumberOfElements = UnityEngine.Random.Range(2, 5)
			}
		};
	}

	// Token: 0x02000FB4 RID: 4020
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065D1 RID: 26065 RVA: 0x001A3ABF File Offset: 0x001A1EBF
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060065D2 RID: 26066 RVA: 0x001A3AC8 File Offset: 0x001A1EC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(specialEffectData is ShiftShieldData))
				{
					goto IL_193;
				}
				data = (specialEffectData as ShiftShieldData);
				data.Counter++;
				if (data.Counter < data.NumberOfSecondsPerShift)
				{
					goto IL_193;
				}
				data.Counter -= data.NumberOfSecondsPerShift;
				elements = UnitExtensions.GetAllDamageElements();
				elements.Shuffle<OutputType>();
				enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName, null, new float?((float)data.NumberOfSecondsPerShift), effectCarrier, elements.Take(data.NumberOfElements).ToList<OutputType>(), true, 1), false).GetEnumerator();
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
			IL_193:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001557 RID: 5463
		// (get) Token: 0x060065D3 RID: 26067 RVA: 0x001A3C84 File Offset: 0x001A2084
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001558 RID: 5464
		// (get) Token: 0x060065D4 RID: 26068 RVA: 0x001A3C8C File Offset: 0x001A208C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065D5 RID: 26069 RVA: 0x001A3C94 File Offset: 0x001A2094
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

		// Token: 0x060065D6 RID: 26070 RVA: 0x001A3D04 File Offset: 0x001A2104
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065D7 RID: 26071 RVA: 0x001A3D0B File Offset: 0x001A210B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065D8 RID: 26072 RVA: 0x001A3D14 File Offset: 0x001A2114
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShiftShieldEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new ShiftShieldEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005EB3 RID: 24243
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005EB4 RID: 24244
		internal ShiftShieldData <data>__1;

		// Token: 0x04005EB5 RID: 24245
		internal List<OutputType> <elements>__2;

		// Token: 0x04005EB6 RID: 24246
		internal IBattleUnit effectCarrier;

		// Token: 0x04005EB7 RID: 24247
		internal IEnumerator $locvar0;

		// Token: 0x04005EB8 RID: 24248
		internal object <_>__3;

		// Token: 0x04005EB9 RID: 24249
		internal IDisposable $locvar1;

		// Token: 0x04005EBA RID: 24250
		internal ShiftShieldEffectProcess $this;

		// Token: 0x04005EBB RID: 24251
		internal object $current;

		// Token: 0x04005EBC RID: 24252
		internal bool $disposing;

		// Token: 0x04005EBD RID: 24253
		internal int $PC;
	}

	// Token: 0x02000FB5 RID: 4021
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065D9 RID: 26073 RVA: 0x001A3D60 File Offset: 0x001A2160
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060065DA RID: 26074 RVA: 0x001A3D68 File Offset: 0x001A2168
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is ShiftShieldData))
				{
					goto IL_172;
				}
				data = (specialEffectData as ShiftShieldData);
				data.Counter = 0;
				elements = UnitExtensions.GetAllDamageElements();
				elements.Shuffle<OutputType>();
				enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName, null, new float?((float)data.NumberOfSecondsPerShift), effectCarrier, elements.Take(data.NumberOfElements).ToList<OutputType>(), true, 1), false).GetEnumerator();
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
			IL_172:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001559 RID: 5465
		// (get) Token: 0x060065DB RID: 26075 RVA: 0x001A3F04 File Offset: 0x001A2304
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700155A RID: 5466
		// (get) Token: 0x060065DC RID: 26076 RVA: 0x001A3F0C File Offset: 0x001A230C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065DD RID: 26077 RVA: 0x001A3F14 File Offset: 0x001A2314
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

		// Token: 0x060065DE RID: 26078 RVA: 0x001A3F84 File Offset: 0x001A2384
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065DF RID: 26079 RVA: 0x001A3F8B File Offset: 0x001A238B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065E0 RID: 26080 RVA: 0x001A3F94 File Offset: 0x001A2394
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ShiftShieldEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new ShiftShieldEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005EBE RID: 24254
		internal AdventureEventType evtType;

		// Token: 0x04005EBF RID: 24255
		internal IBattleUnit triggerUnit;

		// Token: 0x04005EC0 RID: 24256
		internal IBattleUnit effectCarrier;

		// Token: 0x04005EC1 RID: 24257
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005EC2 RID: 24258
		internal ShiftShieldData <data>__1;

		// Token: 0x04005EC3 RID: 24259
		internal List<OutputType> <elements>__1;

		// Token: 0x04005EC4 RID: 24260
		internal IEnumerator $locvar0;

		// Token: 0x04005EC5 RID: 24261
		internal object <_>__2;

		// Token: 0x04005EC6 RID: 24262
		internal IDisposable $locvar1;

		// Token: 0x04005EC7 RID: 24263
		internal ShiftShieldEffectProcess $this;

		// Token: 0x04005EC8 RID: 24264
		internal object $current;

		// Token: 0x04005EC9 RID: 24265
		internal bool $disposing;

		// Token: 0x04005ECA RID: 24266
		internal int $PC;
	}
}
