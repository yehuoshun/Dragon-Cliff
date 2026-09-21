using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200011D RID: 285
public class CombatManager : MonoBehaviour
{
	// Token: 0x060007C3 RID: 1987 RVA: 0x000724D8 File Offset: 0x000708D8
	public CombatManager()
	{
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000724E0 File Offset: 0x000708E0
	public void DisplayBlackBackground(float waitForSeconds)
	{
		this.CombatBlackBackground.Init(waitForSeconds);
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000724EE File Offset: 0x000708EE
	public void SetBattleSelector(BattleSelectorBase Selector)
	{
		this._battleSelector = Selector;
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x000724F8 File Offset: 0x000708F8
	public void SetSelectedBattleOption(IBattleOption battleOp)
	{
		IEnumerator enumerator = this._battleSelector.ResolveOption(battleOp).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
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

	// Token: 0x060007C7 RID: 1991 RVA: 0x00072558 File Offset: 0x00070958
	public void Awake()
	{
		if (CombatManager.Instance == null)
		{
			CombatManager.Instance = this;
		}
		this._source = base.GetComponent<AudioSource>();
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x0007257C File Offset: 0x0007097C
	public void UpdatePlayerVolumeSetting()
	{
		this._playerVolumeSetting = GameWorld.instance.PlayerProfile.MainVolume;
		UnityEngine.Debug.Log("volume   " + this._playerVolumeSetting);
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x000725AD File Offset: 0x000709AD
	public Transform GetSkillCastPoint()
	{
		return this.CombatPointsController.SkillCastPoint;
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000725BA File Offset: 0x000709BA
	public Transform GetAdventureSkillCastPonit()
	{
		return this.CombatPointsController.SkillCastPoint;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000725C8 File Offset: 0x000709C8
	public IEnumerator FinishedEncounter(bool isAdventurePulledOff = false)
	{
		this.CombatPointsController.Collect();
		if (!isAdventurePulledOff)
		{
			this._currentInSelection = null;
			yield return new WaitForSeconds(1.5f);
		}
		yield break;
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x000725EA File Offset: 0x000709EA
	public void SkillCastPopSkillName(string skillName)
	{
		this.AdventureSkillText.ShowSkillName(skillName);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x000725F8 File Offset: 0x000709F8
	public IEnumerable ActiveSkillCast(ActiveSkillCastBattleEvent skillCastEvent)
	{
		BattleManager.instance.ActiveSkillReleased();
		SkillType castedSkillType = skillCastEvent.Skill.Skill.SkillType;
		string directSkillCast = FilePath.GetPreActiveSkill(castedSkillType);
		if (directSkillCast != string.Empty)
		{
			IEnumerator enumerator = this.CastSkillEffectToTransform(this.GetSkillCastPoint(), Resources.Load(directSkillCast) as GameObject, skillCastEvent.Skill.SourceUnit.IsPlayer, false).GetEnumerator();
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
		else
		{
			List<UnitCombatController> enemies = BattleManager.instance.Spawner.GetCurrentEnemeys().Cast<UnitCombatController>().ToList<UnitCombatController>();
			List<UnitCombatController> adventurers = BattleManager.instance.Spawner.GetCurrentAdventurers().Cast<UnitCombatController>().ToList<UnitCombatController>();
			List<IBattleUnit> targets = BattleManager.instance.GetTargets();
			List<UnitCombatController> castToCombatControllers = this.GetCastTransforms((targets.Count != 0) ? targets : skillCastEvent.TargetingStrategy.Selections, adventurers, enemies);
			foreach (UnitCombatController controller in castToCombatControllers)
			{
				UnityEngine.Object prefab = Resources.Load(FilePath.GetSingalTargetableActiveSkillEffect(skillCastEvent.Skill.Skill.SkillType));
				if (prefab == null)
				{
					throw new Exception(skillCastEvent.Skill.Skill.SkillType + " has not been assigned yet");
				}
				IEnumerator enumerator3 = this.CastSkillEffectToTransform(controller.transform, prefab as GameObject, skillCastEvent.Skill.SourceUnit.IsPlayer, false).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x00072624 File Offset: 0x00070A24
	private List<UnitCombatController> GetCastTransforms(List<IBattleUnit> selections, List<UnitCombatController> adventurers, List<UnitCombatController> enemies)
	{
		List<UnitCombatController> list = new List<UnitCombatController>();
		foreach (IBattleUnit battleUnit in selections)
		{
			UnitCombatController castingUnitTransform = this.GetCastingUnitTransform((!battleUnit.IsPlayer) ? enemies : adventurers, battleUnit);
			if (castingUnitTransform != null)
			{
				list.Add(castingUnitTransform);
			}
		}
		return list;
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x000726A8 File Offset: 0x00070AA8
	private IEnumerable CastSkillEffectToTransform(Transform trans, GameObject skillEffect, bool isAdventurer, bool shouldDelay = false)
	{
		GameObject effectObj = UnityEngine.Object.Instantiate<GameObject>(skillEffect);
		if (effectObj == null)
		{
			yield break;
		}
		SkillEffectController skillEffectController = effectObj.GetComponent<SkillEffectController>();
		if (skillEffectController == null)
		{
			UnityEngine.Debug.Log("Please add SkillEffectController to " + effectObj + " first.");
			yield break;
		}
		AudioClip audioClip = skillEffectController.AudioClip;
		if (audioClip != null)
		{
			base.StartCoroutine(this.PlaySoundForSecond(audioClip, skillEffectController.DestroyBy));
		}
		IEnumerable result = skillEffectController.Cast(trans, null);
		IEnumerator enumerator = result.GetEnumerator();
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
		yield break;
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x000726DC File Offset: 0x00070ADC
	public IEnumerator PlaySoundForSecond(AudioClip audiotoplay, float second)
	{
		IEnumerator enumerator = this.PlaySecond(audiotoplay, second).GetEnumerator();
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
		yield break;
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x00072708 File Offset: 0x00070B08
	public IEnumerable PlaySecond(AudioClip audiotoplay, float second)
	{
		this._source.PlayOneShot(audiotoplay, this._playerVolumeSetting);
		yield return new WaitForSeconds(second);
		this._source.Stop();
		yield break;
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x0007273C File Offset: 0x00070B3C
	private UnitCombatController GetCastingUnitTransform(List<UnitCombatController> controllers, IBattleUnit unit)
	{
		UnitCombatController unitCombatController = controllers.FirstOrDefault((UnitCombatController a) => a.BattleUnit.GetId() == unit.GetId());
		if (unitCombatController != null)
		{
			return unitCombatController;
		}
		return null;
	}

	// Token: 0x04000A9D RID: 2717
	public CombatPointsController CombatPointsController;

	// Token: 0x04000A9E RID: 2718
	public static CombatManager Instance;

	// Token: 0x04000A9F RID: 2719
	public BattleBlackBackgroundController CombatBlackBackground;

	// Token: 0x04000AA0 RID: 2720
	private AudioSource _source;

	// Token: 0x04000AA1 RID: 2721
	public AdventureInfoSkillText AdventureSkillText;

	// Token: 0x04000AA2 RID: 2722
	private BattleSelectorBase _battleSelector;

	// Token: 0x04000AA3 RID: 2723
	private float _playerVolumeSetting;

	// Token: 0x04000AA4 RID: 2724
	private IBattleUnit _currentInSelection;

	// Token: 0x04000AA5 RID: 2725
	private EnemyCombatController _currentEnemyCombatController;

	// Token: 0x02000BDE RID: 3038
	[CompilerGenerated]
	private sealed class <FinishedEncounter>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600508E RID: 20622 RVA: 0x00072778 File Offset: 0x00070B78
		[DebuggerHidden]
		public <FinishedEncounter>c__Iterator0()
		{
		}

		// Token: 0x0600508F RID: 20623 RVA: 0x00072780 File Offset: 0x00070B80
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.CombatPointsController.Collect();
				if (!isAdventurePulledOff)
				{
					this._currentInSelection = null;
					this.$current = new WaitForSeconds(1.5f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			default:
				return false;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001126 RID: 4390
		// (get) Token: 0x06005090 RID: 20624 RVA: 0x00072803 File Offset: 0x00070C03
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001127 RID: 4391
		// (get) Token: 0x06005091 RID: 20625 RVA: 0x0007280B File Offset: 0x00070C0B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005092 RID: 20626 RVA: 0x00072813 File Offset: 0x00070C13
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005093 RID: 20627 RVA: 0x00072823 File Offset: 0x00070C23
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E77 RID: 15991
		internal bool isAdventurePulledOff;

		// Token: 0x04003E78 RID: 15992
		internal CombatManager $this;

		// Token: 0x04003E79 RID: 15993
		internal object $current;

		// Token: 0x04003E7A RID: 15994
		internal bool $disposing;

		// Token: 0x04003E7B RID: 15995
		internal int $PC;
	}

	// Token: 0x02000BDF RID: 3039
	[CompilerGenerated]
	private sealed class <ActiveSkillCast>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005094 RID: 20628 RVA: 0x0007282A File Offset: 0x00070C2A
		[DebuggerHidden]
		public <ActiveSkillCast>c__Iterator1()
		{
		}

		// Token: 0x06005095 RID: 20629 RVA: 0x00072834 File Offset: 0x00070C34
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BattleManager.instance.ActiveSkillReleased();
				castedSkillType = skillCastEvent.Skill.Skill.SkillType;
				directSkillCast = FilePath.GetPreActiveSkill(castedSkillType);
				if (!(directSkillCast != string.Empty))
				{
					enemies = BattleManager.instance.Spawner.GetCurrentEnemeys().Cast<UnitCombatController>().ToList<UnitCombatController>();
					adventurers = BattleManager.instance.Spawner.GetCurrentAdventurers().Cast<UnitCombatController>().ToList<UnitCombatController>();
					targets = BattleManager.instance.GetTargets();
					castToCombatControllers = base.GetCastTransforms((targets.Count != 0) ? targets : skillCastEvent.TargetingStrategy.Selections, adventurers, enemies);
					enumerator2 = castToCombatControllers.GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
				enumerator = base.CastSkillEffectToTransform(base.GetSkillCastPoint(), Resources.Load(directSkillCast) as GameObject, skillCastEvent.Skill.SourceUnit.IsPlayer, false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1ED;
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
			goto IL_361;
			Block_5:
			try
			{
				IL_1ED:
				switch (num)
				{
				case 2u:
					Block_14:
					try
					{
						switch (num)
						{
						}
						if (enumerator3.MoveNext())
						{
							_2 = enumerator3.Current;
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
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator2.MoveNext())
				{
					controller = enumerator2.Current;
					prefab = Resources.Load(FilePath.GetSingalTargetableActiveSkillEffect(skillCastEvent.Skill.Skill.SkillType));
					if (prefab == null)
					{
						throw new Exception(skillCastEvent.Skill.Skill.SkillType + " has not been assigned yet");
					}
					enumerator3 = base.CastSkillEffectToTransform(controller.transform, prefab as GameObject, skillCastEvent.Skill.SourceUnit.IsPlayer, false).GetEnumerator();
					num = 4294967293u;
					goto Block_14;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_361:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001128 RID: 4392
		// (get) Token: 0x06005096 RID: 20630 RVA: 0x00072BF8 File Offset: 0x00070FF8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001129 RID: 4393
		// (get) Token: 0x06005097 RID: 20631 RVA: 0x00072C00 File Offset: 0x00071000
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005098 RID: 20632 RVA: 0x00072C08 File Offset: 0x00071008
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005099 RID: 20633 RVA: 0x00072CDC File Offset: 0x000710DC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600509A RID: 20634 RVA: 0x00072CE3 File Offset: 0x000710E3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600509B RID: 20635 RVA: 0x00072CEC File Offset: 0x000710EC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CombatManager.<ActiveSkillCast>c__Iterator1 <ActiveSkillCast>c__Iterator = new CombatManager.<ActiveSkillCast>c__Iterator1();
			<ActiveSkillCast>c__Iterator.$this = this;
			<ActiveSkillCast>c__Iterator.skillCastEvent = skillCastEvent;
			return <ActiveSkillCast>c__Iterator;
		}

		// Token: 0x04003E7C RID: 15996
		internal ActiveSkillCastBattleEvent skillCastEvent;

		// Token: 0x04003E7D RID: 15997
		internal SkillType <castedSkillType>__0;

		// Token: 0x04003E7E RID: 15998
		internal string <directSkillCast>__0;

		// Token: 0x04003E7F RID: 15999
		internal IEnumerator $locvar0;

		// Token: 0x04003E80 RID: 16000
		internal object <_>__1;

		// Token: 0x04003E81 RID: 16001
		internal IDisposable $locvar1;

		// Token: 0x04003E82 RID: 16002
		internal List<UnitCombatController> <enemies>__2;

		// Token: 0x04003E83 RID: 16003
		internal List<UnitCombatController> <adventurers>__2;

		// Token: 0x04003E84 RID: 16004
		internal List<IBattleUnit> <targets>__2;

		// Token: 0x04003E85 RID: 16005
		internal List<UnitCombatController> <castToCombatControllers>__2;

		// Token: 0x04003E86 RID: 16006
		internal List<UnitCombatController>.Enumerator $locvar2;

		// Token: 0x04003E87 RID: 16007
		internal UnitCombatController <controller>__3;

		// Token: 0x04003E88 RID: 16008
		internal UnityEngine.Object <prefab>__4;

		// Token: 0x04003E89 RID: 16009
		internal IEnumerator $locvar3;

		// Token: 0x04003E8A RID: 16010
		internal object <_>__5;

		// Token: 0x04003E8B RID: 16011
		internal IDisposable $locvar4;

		// Token: 0x04003E8C RID: 16012
		internal CombatManager $this;

		// Token: 0x04003E8D RID: 16013
		internal object $current;

		// Token: 0x04003E8E RID: 16014
		internal bool $disposing;

		// Token: 0x04003E8F RID: 16015
		internal int $PC;
	}

	// Token: 0x02000BE0 RID: 3040
	[CompilerGenerated]
	private sealed class <CastSkillEffectToTransform>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600509C RID: 20636 RVA: 0x00072D2C File Offset: 0x0007112C
		[DebuggerHidden]
		public <CastSkillEffectToTransform>c__Iterator2()
		{
		}

		// Token: 0x0600509D RID: 20637 RVA: 0x00072D34 File Offset: 0x00071134
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				effectObj = UnityEngine.Object.Instantiate<GameObject>(skillEffect);
				if (effectObj == null)
				{
					return false;
				}
				skillEffectController = effectObj.GetComponent<SkillEffectController>();
				if (skillEffectController == null)
				{
					UnityEngine.Debug.Log("Please add SkillEffectController to " + effectObj + " first.");
					return false;
				}
				audioClip = skillEffectController.AudioClip;
				if (audioClip != null)
				{
					base.StartCoroutine(base.PlaySoundForSecond(audioClip, skillEffectController.DestroyBy));
				}
				result = skillEffectController.Cast(trans, null);
				enumerator = result.GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700112A RID: 4394
		// (get) Token: 0x0600509E RID: 20638 RVA: 0x00072EE0 File Offset: 0x000712E0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700112B RID: 4395
		// (get) Token: 0x0600509F RID: 20639 RVA: 0x00072EE8 File Offset: 0x000712E8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x00072EF0 File Offset: 0x000712F0
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

		// Token: 0x060050A1 RID: 20641 RVA: 0x00072F60 File Offset: 0x00071360
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050A2 RID: 20642 RVA: 0x00072F67 File Offset: 0x00071367
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050A3 RID: 20643 RVA: 0x00072F70 File Offset: 0x00071370
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CombatManager.<CastSkillEffectToTransform>c__Iterator2 <CastSkillEffectToTransform>c__Iterator = new CombatManager.<CastSkillEffectToTransform>c__Iterator2();
			<CastSkillEffectToTransform>c__Iterator.$this = this;
			<CastSkillEffectToTransform>c__Iterator.skillEffect = skillEffect;
			<CastSkillEffectToTransform>c__Iterator.trans = trans;
			return <CastSkillEffectToTransform>c__Iterator;
		}

		// Token: 0x04003E90 RID: 16016
		internal GameObject skillEffect;

		// Token: 0x04003E91 RID: 16017
		internal GameObject <effectObj>__0;

		// Token: 0x04003E92 RID: 16018
		internal SkillEffectController <skillEffectController>__0;

		// Token: 0x04003E93 RID: 16019
		internal AudioClip <audioClip>__0;

		// Token: 0x04003E94 RID: 16020
		internal Transform trans;

		// Token: 0x04003E95 RID: 16021
		internal IEnumerable <result>__0;

		// Token: 0x04003E96 RID: 16022
		internal IEnumerator $locvar0;

		// Token: 0x04003E97 RID: 16023
		internal object <_>__1;

		// Token: 0x04003E98 RID: 16024
		internal IDisposable $locvar1;

		// Token: 0x04003E99 RID: 16025
		internal CombatManager $this;

		// Token: 0x04003E9A RID: 16026
		internal object $current;

		// Token: 0x04003E9B RID: 16027
		internal bool $disposing;

		// Token: 0x04003E9C RID: 16028
		internal int $PC;
	}

	// Token: 0x02000BE1 RID: 3041
	[CompilerGenerated]
	private sealed class <PlaySoundForSecond>c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050A4 RID: 20644 RVA: 0x00072FBC File Offset: 0x000713BC
		[DebuggerHidden]
		public <PlaySoundForSecond>c__Iterator3()
		{
		}

		// Token: 0x060050A5 RID: 20645 RVA: 0x00072FC4 File Offset: 0x000713C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = base.PlaySecond(audiotoplay, second).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700112C RID: 4396
		// (get) Token: 0x060050A6 RID: 20646 RVA: 0x000730B8 File Offset: 0x000714B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700112D RID: 4397
		// (get) Token: 0x060050A7 RID: 20647 RVA: 0x000730C0 File Offset: 0x000714C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050A8 RID: 20648 RVA: 0x000730C8 File Offset: 0x000714C8
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

		// Token: 0x060050A9 RID: 20649 RVA: 0x00073138 File Offset: 0x00071538
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003E9D RID: 16029
		internal AudioClip audiotoplay;

		// Token: 0x04003E9E RID: 16030
		internal float second;

		// Token: 0x04003E9F RID: 16031
		internal IEnumerator $locvar0;

		// Token: 0x04003EA0 RID: 16032
		internal object <_>__1;

		// Token: 0x04003EA1 RID: 16033
		internal IDisposable $locvar1;

		// Token: 0x04003EA2 RID: 16034
		internal CombatManager $this;

		// Token: 0x04003EA3 RID: 16035
		internal object $current;

		// Token: 0x04003EA4 RID: 16036
		internal bool $disposing;

		// Token: 0x04003EA5 RID: 16037
		internal int $PC;
	}

	// Token: 0x02000BE2 RID: 3042
	[CompilerGenerated]
	private sealed class <PlaySecond>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050AA RID: 20650 RVA: 0x0007313F File Offset: 0x0007153F
		[DebuggerHidden]
		public <PlaySecond>c__Iterator4()
		{
		}

		// Token: 0x060050AB RID: 20651 RVA: 0x00073148 File Offset: 0x00071548
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this._source.PlayOneShot(audiotoplay, this._playerVolumeSetting);
				this.$current = new WaitForSeconds(second);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this._source.Stop();
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700112E RID: 4398
		// (get) Token: 0x060050AC RID: 20652 RVA: 0x000731D6 File Offset: 0x000715D6
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700112F RID: 4399
		// (get) Token: 0x060050AD RID: 20653 RVA: 0x000731DE File Offset: 0x000715DE
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050AE RID: 20654 RVA: 0x000731E6 File Offset: 0x000715E6
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060050AF RID: 20655 RVA: 0x000731F6 File Offset: 0x000715F6
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050B0 RID: 20656 RVA: 0x000731FD File Offset: 0x000715FD
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050B1 RID: 20657 RVA: 0x00073208 File Offset: 0x00071608
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CombatManager.<PlaySecond>c__Iterator4 <PlaySecond>c__Iterator = new CombatManager.<PlaySecond>c__Iterator4();
			<PlaySecond>c__Iterator.$this = this;
			<PlaySecond>c__Iterator.audiotoplay = audiotoplay;
			<PlaySecond>c__Iterator.second = second;
			return <PlaySecond>c__Iterator;
		}

		// Token: 0x04003EA6 RID: 16038
		internal AudioClip audiotoplay;

		// Token: 0x04003EA7 RID: 16039
		internal float second;

		// Token: 0x04003EA8 RID: 16040
		internal CombatManager $this;

		// Token: 0x04003EA9 RID: 16041
		internal object $current;

		// Token: 0x04003EAA RID: 16042
		internal bool $disposing;

		// Token: 0x04003EAB RID: 16043
		internal int $PC;
	}

	// Token: 0x02000BE3 RID: 3043
	[CompilerGenerated]
	private sealed class <GetCastingUnitTransform>c__AnonStorey5
	{
		// Token: 0x060050B2 RID: 20658 RVA: 0x00073254 File Offset: 0x00071654
		public <GetCastingUnitTransform>c__AnonStorey5()
		{
		}

		// Token: 0x060050B3 RID: 20659 RVA: 0x0007325C File Offset: 0x0007165C
		internal bool <>m__0(UnitCombatController a)
		{
			return a.BattleUnit.GetId() == this.unit.GetId();
		}

		// Token: 0x04003EAC RID: 16044
		internal IBattleUnit unit;
	}
}
