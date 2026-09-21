using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x0200012A RID: 298
public abstract class UnitCombatController : CombatUnit
{
	// Token: 0x0600082A RID: 2090 RVA: 0x0006B724 File Offset: 0x00069B24
	protected UnitCombatController()
	{
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x0600082B RID: 2091 RVA: 0x0006B772 File Offset: 0x00069B72
	// (set) Token: 0x0600082C RID: 2092 RVA: 0x0006B77A File Offset: 0x00069B7A
	public IBattleUnit BattleUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600082D RID: 2093 RVA: 0x0006B783 File Offset: 0x00069B83
	// (set) Token: 0x0600082E RID: 2094 RVA: 0x0006B78B File Offset: 0x00069B8B
	public bool IsBoxColliderEnabled
	{
		[CompilerGenerated]
		get
		{
			return this.<IsBoxColliderEnabled>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsBoxColliderEnabled>k__BackingField = value;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600082F RID: 2095 RVA: 0x0006B794 File Offset: 0x00069B94
	// (set) Token: 0x06000830 RID: 2096 RVA: 0x0006B79C File Offset: 0x00069B9C
	public GameObject CameFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<CameFrom>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CameFrom>k__BackingField = value;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x06000831 RID: 2097 RVA: 0x0006B7A5 File Offset: 0x00069BA5
	// (set) Token: 0x06000832 RID: 2098 RVA: 0x0006B7C4 File Offset: 0x00069BC4
	protected CombatUnitHealthController HealthController
	{
		get
		{
			if (this._healthController == null)
			{
				this.InitHealthBar();
			}
			return this._healthController;
		}
		set
		{
			this._healthController = value;
		}
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0006B7D0 File Offset: 0x00069BD0
	public void LeavesEncounter()
	{
		this.RemoveSelfPet();
		base.GetComponentInChildren<EffectContainnerController>().ClearAllEffects();
		(from c in this._currentPassiveEffectObjs
		where c != null
		select c).ToList<PassiveEffectController>().ForEach(delegate(PassiveEffectController c)
		{
			UnityEngine.Object.Destroy(c.gameObject);
		});
		this._currentPassiveEffectObjs.Clear();
		(from c in this._currentBattleEffects
		where c != null
		select c).ToList<SkillEffectController>().ForEach(delegate(SkillEffectController c)
		{
			UnityEngine.Object.Destroy(c.gameObject);
		});
		this._currentBattleEffects.Clear();
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x0006B8A2 File Offset: 0x00069CA2
	private void OnEnable()
	{
		this.LeavesEncounter();
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0006B8AC File Offset: 0x00069CAC
	public virtual void FixedUpdate()
	{
		if (this._isMovingForward)
		{
			float maxDistanceDelta = this.MovingSpeed * Time.fixedDeltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, this._destination, maxDistanceDelta);
			if (Vector3.Distance(base.transform.position, this._destination) < 0.01f)
			{
				this._isMovingForward = false;
				base.transform.position = this._destination;
			}
		}
		if (this._isMovingBack)
		{
			float maxDistanceDelta2 = this.MovingSpeed * Time.fixedDeltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, this._originStandPoint, maxDistanceDelta2);
			if (Vector3.Distance(base.transform.position, this._originStandPoint) < 0.01f)
			{
				this._isMovingBack = false;
				base.transform.position = this._originStandPoint;
				base.transform.localPosition = Vector3.zero;
			}
		}
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x0006B9B0 File Offset: 0x00069DB0
	public void InitHealthBar()
	{
		this.HealthController = base.GetComponentInChildren<CombatUnitHealthController>();
		if (this.HealthController != null)
		{
			RectTransform component = this.HealthController.GetComponent<RectTransform>();
			float width = component.rect.width;
			float height = component.rect.height;
			Vector3 localPosition = component.localPosition;
			UnityEngine.Object.Destroy(this.HealthController.gameObject);
			this.HealthController = this.PoolObject(PoolType.HealthBar, default(Vector3)).GetComponent<CombatUnitHealthController>();
			this.HealthController.RectTrans.sizeDelta = new Vector2(width, height);
			this.HealthController.transform.SetParent(base.transform, false);
			this.HealthController.RectTrans.localPosition = Vector3.zero;
			this.HealthController.RectTrans.localScale = Vector3.one * 0.025f;
			this.HealthController.transform.localScale = Vector3.one;
			this.HealthController.transform.localPosition = localPosition;
		}
		else
		{
			this.HealthController = this.PoolObject(PoolType.HealthBar, default(Vector3)).GetComponent<CombatUnitHealthController>();
			this.HealthController.RectTrans.sizeDelta = new Vector2(0f, 0f);
			this.HealthController.transform.SetParent(base.transform, false);
			this.HealthController.RectTrans.localPosition = Vector3.zero;
			this.HealthController.RectTrans.localScale = Vector3.one * 0.025f;
			this.HealthController.transform.localScale = Vector3.one;
		}
		TownManager.Instance.Ui.AddHealthBar(this.HealthController.gameObject);
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x0006BB80 File Offset: 0x00069F80
	public virtual void Init(IBattleUnit battleUnit, Vector3 attackMoveToDestination, bool reverseHealthbar = false)
	{
		this.BattleUnit = battleUnit;
		this._destination = attackMoveToDestination;
		this._originStandPoint = base.transform.position;
		this.HealthController.SetbattleUnit(battleUnit);
		base.GetComponentInChildren<EffectContainnerController>().ClearAllEffects();
		if (battleUnit.IsBoss())
		{
			if (battleUnit.SpecialEffects.Any((ISpecialEffectDataLoad e) => e is InversedMandateData))
			{
				ISpecialEffectDataLoad effect = battleUnit.SpecialEffects.Single((ISpecialEffectDataLoad e) => e is InversedMandateData);
				BattleManager.instance.AdventureUi.ShowBossSkillBar(effect);
			}
		}
		if (battleUnit.IsBoss())
		{
			if (battleUnit.SpecialEffects.Any((ISpecialEffectDataLoad e) => e is DemonSkullData))
			{
				ISpecialEffectDataLoad effect2 = battleUnit.SpecialEffects.Single((ISpecialEffectDataLoad e) => e is DemonSkullData);
				BattleManager.instance.AdventureUi.ShowBossSkillBar(effect2);
			}
		}
		battleUnit.RegisterEventCallbackFromUiLayer(new Func<IBattleUnit, AdventureEventType, object, IEnumerable>(this.Adventurer_ReceivesEventCallBack));
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x0006BCB8 File Offset: 0x0006A0B8
	public IEnumerable Adventurer_ReceivesEventCallBack(IBattleUnit unit, AdventureEventType type, object obj)
	{
		if (this != null && base.gameObject != null)
		{
			switch (type)
			{
			case AdventureEventType.AdventureInitialized:
				goto IL_F85;
			case AdventureEventType.AdventurerPreWalking:
				goto IL_F85;
			case AdventureEventType.AdventurersWalking:
				goto IL_F85;
			case AdventureEventType.AdventurerPostWalking:
				goto IL_F85;
			case AdventureEventType.UnitRegularTurnStarts:
				goto IL_F85;
			case AdventureEventType.UnitRegularTurnEnds:
				goto IL_F85;
			case AdventureEventType.UnitEntersTurn:
				goto IL_F85;
			case AdventureEventType.UnitSelectsSkill:
				goto IL_F85;
			case AdventureEventType.UnitSelectedSkill:
				goto IL_F85;
			case AdventureEventType.UnitCastsSkill:
			{
				IEnumerator enumerator = this.UnitCastsSkill(obj as SkillCastBattleEvent, 0.5f).GetEnumerator();
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
				goto IL_F85;
			}
			case AdventureEventType.UnitPostCastSkill:
				goto IL_F85;
			case AdventureEventType.UnitCompletesTurn:
				goto IL_F85;
			case AdventureEventType.UnitCompletesAction:
				yield return new WaitForSeconds(1f);
				goto IL_F85;
			case AdventureEventType.UnitCompletesSkillCast:
				goto IL_F85;
			case AdventureEventType.UnitEffectTriggered:
				goto IL_F85;
			case AdventureEventType.UnitReceivesDamage_CompleteSet:
				goto IL_F85;
			case AdventureEventType.UnitReceivesDamage_Single:
				goto IL_F85;
			case AdventureEventType.UnitPostReceivesDamage_Single:
				goto IL_F85;
			case AdventureEventType.UnitDamageNeutralized:
			{
				IEnumerator enumerator2 = this.DamageNeutralized().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitReleasesDamage:
				goto IL_F85;
			case AdventureEventType.UnitReleasesHeal:
				goto IL_F85;
			case AdventureEventType.UnitReceivesHeal:
			{
				IEnumerator enumerator3 = this.UnitReceivesHeal(obj as BattleHeal).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _3 = enumerator3.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitPostReceivesDamage:
			{
				IEnumerator enumerator4 = this.UnitReceivesDamage(obj as BattleDamage).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _4 = enumerator4.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				this.UpdateHealthBar();
				goto IL_F85;
			}
			case AdventureEventType.UnitPostReceivesHeal:
				this.UpdateHealthBar();
				goto IL_F85;
			case AdventureEventType.UnitKilled:
			{
				IEnumerator enumerator5 = this.UnitKilled(obj).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _5 = enumerator5.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitPreKilled:
				goto IL_F85;
			case AdventureEventType.UnitRevived:
				goto IL_F85;
			case AdventureEventType.UnitReceivesEffect:
			{
				IEnumerator enumerator6 = this.UnitReceivesEffect(obj as BattleEffectBase, base.gameObject.transform).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _6 = enumerator6.Current;
						yield return _6;
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitLoosesEffect:
			{
				IEnumerator enumerator7 = this.UnitLoosesEffect(obj).GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _7 = enumerator7.Current;
						yield return _7;
					}
				}
				finally
				{
					IDisposable disposable7;
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitNormalAttack:
			{
				IEnumerator enumerator8 = this.UnitNormalAttack(unit, 0.5f).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _8 = enumerator8.Current;
						yield return _8;
					}
				}
				finally
				{
					IDisposable disposable8;
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.BattleEffectDispersed:
				goto IL_F85;
			case AdventureEventType.BattleEffectResisted:
				base.StartCoroutine(this.PopupResistanceText(obj as BattleEffectBase));
				goto IL_F85;
			case AdventureEventType.UnitPreEntersBattle:
				goto IL_F85;
			case AdventureEventType.UnitReadyInBattle:
				this.UnitReadyInBattle();
				this.UpdateHealthBar();
				goto IL_F85;
			case AdventureEventType.PriorUnitTurnProgressChange:
				goto IL_F85;
			case AdventureEventType.UnitTurnProgressAlterred:
				goto IL_F85;
			case AdventureEventType.UnitTriggersDialog:
			{
				IEnumerator enumerator9 = this.UnitTriggersDialog(obj as BattleUnitSpeaksEvent).GetEnumerator();
				try
				{
					while (enumerator9.MoveNext())
					{
						object _9 = enumerator9.Current;
						yield return _9;
					}
				}
				finally
				{
					IDisposable disposable9;
					if ((disposable9 = (enumerator9 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.EnemyUnitDropsLoot:
			{
				IEnumerator enumerator10 = this.EnemyUnitDropsLoot(obj as List<ResourceUpdate>).GetEnumerator();
				try
				{
					while (enumerator10.MoveNext())
					{
						object _10 = enumerator10.Current;
						yield return _10;
					}
				}
				finally
				{
					IDisposable disposable10;
					if ((disposable10 = (enumerator10 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitEscaped:
				if (unit.GetId() == this.BattleUnit.GetId())
				{
					IEnumerator enumerator11 = this.EscapeFromBattle().GetEnumerator();
					try
					{
						while (enumerator11.MoveNext())
						{
							object _11 = enumerator11.Current;
							yield return _11;
						}
					}
					finally
					{
						IDisposable disposable11;
						if ((disposable11 = (enumerator11 as IDisposable)) != null)
						{
							disposable11.Dispose();
						}
					}
				}
				goto IL_F85;
			case AdventureEventType.BattleEncounterPlayerGaugeUpdated:
			case AdventureEventType.BattleEncounterEnemyGaugeUpdated:
			case AdventureEventType.BattleEncounterPlayerGaugeFullyCharged:
			case AdventureEventType.BattleEncounterPlayerGaugeReleased:
			case AdventureEventType.BattleEncounterEnemyGaugeFullyCharged:
			case AdventureEventType.BattleEncounterEnemyGaugeReleased:
			{
				IEnumerator enumerator12 = BattleManager.instance.GaugeUpdated(unit, type, obj).GetEnumerator();
				try
				{
					while (enumerator12.MoveNext())
					{
						object _12 = enumerator12.Current;
						yield return _12;
					}
				}
				finally
				{
					IDisposable disposable12;
					if ((disposable12 = (enumerator12 as IDisposable)) != null)
					{
						disposable12.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.ActiveBattleSkillEntersCoolingDowns:
				goto IL_F85;
			case AdventureEventType.ActiveBattleSkillCompletesCoolingDowns:
				goto IL_F85;
			case AdventureEventType.BattleEffectTurnProgresses:
				goto IL_F85;
			case AdventureEventType.ActiveSkillPassiveBecomesAlive:
			{
				IEnumerator enumerator13 = this.PassiveEffectBecomeActive(unit, obj).GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						object _13 = enumerator13.Current;
						yield return _13;
					}
				}
				finally
				{
					IDisposable disposable13;
					if ((disposable13 = (enumerator13 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.ActiveSkillPassiveBecomesFades:
			{
				IEnumerator enumerator14 = this.PassiveSkillFades(unit, obj).GetEnumerator();
				try
				{
					while (enumerator14.MoveNext())
					{
						object _14 = enumerator14.Current;
						yield return _14;
					}
				}
				finally
				{
					IDisposable disposable14;
					if ((disposable14 = (enumerator14 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.AdventureProgresses:
				goto IL_F85;
			case AdventureEventType.AdventureSuccess:
				goto IL_F85;
			case AdventureEventType.AdventureFailed:
				goto IL_F85;
			case AdventureEventType.UnitPreRealKilled:
				goto IL_F85;
			case AdventureEventType.AdventureStoryTriggered:
				this.AdventureStoryTriggered((StoryIdentifier)obj);
				goto IL_F85;
			case AdventureEventType.BattleEncounterStarts:
				goto IL_F85;
			case AdventureEventType.AttributeCheckup:
				goto IL_F85;
			case AdventureEventType.BattleUnitPreDrops:
				goto IL_F85;
			case AdventureEventType.AdventureEffectTriggered:
				goto IL_F85;
			case AdventureEventType.UnitCastActiveSkill:
			{
				IEnumerator enumerator15 = this.UnitCastsActiveSkill(obj as ActiveSkillCastBattleEvent).GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						object _15 = enumerator15.Current;
						yield return _15;
					}
				}
				finally
				{
					IDisposable disposable15;
					if ((disposable15 = (enumerator15 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.UnitPostCastActiveSkill:
				goto IL_F85;
			case AdventureEventType.UnitCompleteActiveSkill:
				goto IL_F85;
			case AdventureEventType.BattleEncounterOptionsTriggered:
			{
				BattleSelectorBase battleSelector = obj as BattleSelectorBase;
				if (battleSelector == null)
				{
					yield break;
				}
				CombatManager.Instance.SetBattleSelector(battleSelector);
				goto IL_F85;
			}
			case AdventureEventType.BattleUnitSequenceCompleted:
				goto IL_F85;
			case AdventureEventType.BattleEffectCapStackReached:
				goto IL_F85;
			case AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime:
				goto IL_F85;
			case AdventureEventType.DemonSoulFullyCharged:
				goto IL_F85;
			case AdventureEventType.InversedKillPerformed:
			{
				IEnumerator enumerator16 = this.InversedKillPerformed(obj as IBattleUnit).GetEnumerator();
				try
				{
					while (enumerator16.MoveNext())
					{
						object _16 = enumerator16.Current;
						yield return _16;
					}
				}
				finally
				{
					IDisposable disposable16;
					if ((disposable16 = (enumerator16 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.DragonChargeReleased:
				goto IL_F85;
			case AdventureEventType.UnitBattleDialogueCompleted:
				goto IL_F85;
			case AdventureEventType.ElementDamageProcessCompleted:
				goto IL_F85;
			case AdventureEventType.BlackBeadSoulCollected:
				goto IL_F85;
			case AdventureEventType.TimeFragmentTriggered:
			{
				IEnumerator enumerator17 = this.TimeFragmentTriggered(obj as List<IBattleUnit>).GetEnumerator();
				try
				{
					while (enumerator17.MoveNext())
					{
						object _17 = enumerator17.Current;
						yield return _17;
					}
				}
				finally
				{
					IDisposable disposable17;
					if ((disposable17 = (enumerator17 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
				goto IL_F85;
			}
			case AdventureEventType.DamageReleased:
				goto IL_F85;
			case AdventureEventType.TurnSetupCompleted:
				goto IL_F85;
			case AdventureEventType.PostHealRelease:
				goto IL_F85;
			case AdventureEventType.ChargeUpdated:
				goto IL_F85;
			case AdventureEventType.FirstEncounterStarted:
				goto IL_F85;
			case AdventureEventType.PetSummoned:
				this.PetSummoned(obj as PetBattleUnit);
				goto IL_F85;
			case AdventureEventType.PetRemoving:
				this.PetRemoving();
				goto IL_F85;
			case AdventureEventType.DamageReleaseProcessCompleted:
				goto IL_F85;
			}
			yield break;
		}
		IL_F85:
		yield break;
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x0006BCF0 File Offset: 0x0006A0F0
	private void PetSummoned(PetBattleUnit unit)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load(FilePath.GetCombatUnit(unit.GetUnitType())) as GameObject);
		if (unit.IsPlayer)
		{
			CombatManager.Instance.CombatPointsController.SpawnFriendlyPet(gameObject);
		}
		else
		{
			Vector3 localScale = gameObject.transform.localScale;
			gameObject.transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
			CombatManager.Instance.CombatPointsController.SpawnEnemyPet(gameObject);
		}
		BattleManager.instance.AdventureUi.NewHeroesPanel.AddUnitProgressIndicator(unit);
		gameObject.GetComponent<EnemyCombatController>().Init(unit, this._destination, false);
		this._pet = gameObject;
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x0006BDAC File Offset: 0x0006A1AC
	protected void PetRemoving()
	{
		if (!(this is NewEnemyCombatController))
		{
			base.gameObject.transform.localScale = Vector3.zero;
		}
		this.BattleUnit.Status = BattleUnitStatus.Dead;
		this.BattleUnit.RemoveAllEventCallbackFromUiLayer();
		this.LeavesEncounter();
		base.StartCoroutine(GameObjectUtil.WaitToRecycle(base.gameObject));
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x0006BE08 File Offset: 0x0006A208
	private void RemoveSelfPet()
	{
		if (this._pet != null)
		{
			this._pet.GetComponent<EnemyCombatController>().PetRemoving();
			this._pet = null;
		}
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x0006BE34 File Offset: 0x0006A234
	private void UnitReadyInBattle()
	{
		EffectContainnerController componentInChildren = base.GetComponentInChildren<EffectContainnerController>();
		componentInChildren.RefreshEffectIcons(this.BattleUnit.BattleEffects, this.BattleUnit.IsPlayer);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0006BE64 File Offset: 0x0006A264
	private IEnumerable TimeFragmentTriggered(List<IBattleUnit> targets)
	{
		GameObject skillObj = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Skill Effects/BossSkills/InversedMandate/InversedMandate") as GameObject);
		if (skillObj != null)
		{
			Transform casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
			SkillEffectController effectController = skillObj.GetComponent<SkillEffectController>();
			IEnumerator enumerator = effectController.Cast(casTransform, null).GetEnumerator();
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

	// Token: 0x0600083E RID: 2110 RVA: 0x0006BE80 File Offset: 0x0006A280
	public virtual IEnumerable UnitReceivesDamage(BattleDamage damageEvent)
	{
		if (base.isActiveAndEnabled)
		{
			base.StartCoroutine(this.PopupDamageText(damageEvent.Damages, damageEvent.DamageSource));
		}
		yield break;
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x0006BEAC File Offset: 0x0006A2AC
	private void DisplayOutputEffect(OutputType outputType, IBattleEffectSource source)
	{
		UnityEngine.Object @object = Resources.Load(FilePath.GetOutputTypeRepresentations(outputType));
		if (@object == null)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
		if (gameObject == null)
		{
			return;
		}
		SkillEffectController component = gameObject.GetComponent<SkillEffectController>();
		Transform spawnPoint = base.CreateEeffect(gameObject, false);
		base.StartCoroutine(component.Cast(spawnPoint, null).GetEnumerator());
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x0006BF10 File Offset: 0x0006A310
	private IEnumerator PopupResistanceText(BattleEffectBase effect)
	{
		UIMiscGenerator.Instance.CreateMissPopupText(new PopupTextElement
		{
			Text = UIComponentType.Resisted.GetName(),
			IsCriticle = false,
			IsMagical = false,
			Position = base.transform.position,
			IsAdventurer = false
		});
		yield return new WaitForSeconds(0.2f);
		yield break;
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x0006BF2C File Offset: 0x0006A32C
	private IEnumerator PopupDamageText(List<DamageComponent> damages, IBattleEffectSource source)
	{
		foreach (DamageComponent damageComponent in (from d in damages
		where d.GetTotalDamageSoFar() > 0.0 || d.IsMissed
		select d).ToList<DamageComponent>())
		{
			if (damageComponent.GetElementalTotal(OutputType.Fire) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Fire, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Divine) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Divine, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Ice) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Ice, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Lightening) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Lightening, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Physical) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Physical, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Poison) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Poison, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.Shadow) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.Shadow, source);
			}
			if (damageComponent.GetElementalTotal(OutputType.RealDamage) > 0.0)
			{
				this.DisplayOutputEffect(OutputType.RealDamage, source);
			}
			if (damageComponent.IsMissed)
			{
				UIMiscGenerator.Instance.CreateMissPopupText(new PopupTextElement
				{
					Text = "Miss",
					IsCriticle = false,
					IsMagical = false,
					Position = base.transform.position,
					IsAdventurer = false
				});
			}
			else
			{
				UIMiscGenerator.Instance.CreateDamagePopupText(new PopupTextElement
				{
					Text = "-" + damageComponent.GetTotalDamageSoFar().DoubleToShortNumber(),
					IsCriticle = damageComponent.IsCritDamage(),
					IsMagical = false,
					Position = base.transform.position,
					IsAdventurer = false
				});
			}
			yield return new WaitForSeconds(0.2f);
		}
		yield break;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x0006BF58 File Offset: 0x0006A358
	public virtual IEnumerable UnitReceivesHeal(BattleHeal heal)
	{
		if (base.isActiveAndEnabled)
		{
			base.StartCoroutine(this.PopupHealingText(heal.Heals));
		}
		yield break;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x0006BF84 File Offset: 0x0006A384
	private IEnumerator PopupHealingText(List<HealComponent> heals)
	{
		foreach (HealComponent healComponent in heals)
		{
			UIMiscGenerator.Instance.CreateHealPopupText(new PopupTextElement
			{
				Text = "+" + healComponent.GetFinalHealSoFar().DoubleToShortNumber() + ((healComponent.ExceededHealValue == null || healComponent.ExceededHealValue.Value <= 0.0) ? string.Empty : ("(" + (int)healComponent.ExceededHealValue.Value + ")")),
				IsCriticle = healComponent.IsCrit,
				Position = base.transform.position
			});
			yield return new WaitForSeconds(0.2f);
		}
		yield break;
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x0006BFA8 File Offset: 0x0006A3A8
	private IEnumerator PopupEffectText(List<string> effectDescs)
	{
		List<PopupTextElement> list = new List<PopupTextElement>();
		foreach (string text in effectDescs)
		{
			PopupTextElement item = new PopupTextElement
			{
				Text = text,
				Position = base.transform.position
			};
			list.Add(item);
		}
		UIMiscGenerator.Instance.AddPopupTexts(list);
		yield break;
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x0006BFCC File Offset: 0x0006A3CC
	public virtual void PopupBattleEffectsText(BattleEffectBase effect)
	{
		if (base.isActiveAndEnabled && effect != null)
		{
			base.StartCoroutine(this.PopupEffectText((from d in effect.EffectBattlePopupDetails
			where d != string.Empty
			select d).ToList<string>()));
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x0006C024 File Offset: 0x0006A424
	public virtual void PopupMissText()
	{
		if (base.isActiveAndEnabled)
		{
			base.StartCoroutine(this.PopupEffectText(new List<string>
			{
				"MISS"
			}));
		}
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x0006C05C File Offset: 0x0006A45C
	public virtual void PopupSkillNameWhenCastsSkill(SkillType CastedSkillType)
	{
		try
		{
			if (base.isActiveAndEnabled)
			{
				CombatManager.Instance.SkillCastPopSkillName(CastedSkillType.GetDescription().Title);
			}
		}
		catch (Exception exception)
		{
			SteamExceptionHandle.Handle(exception, 0u);
		}
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x0006C0AC File Offset: 0x0006A4AC
	public virtual IEnumerator DisplayEffect(IBattleEffectSource source, bool isAdventurer, bool isDirectEffect = true, bool isDirectTarget = true)
	{
		if (source is BattleEffectBase)
		{
			BattleEffectBase battleEffect = source as BattleEffectBase;
			if (battleEffect.EffectSource is AdventureUnitSkill)
			{
				AdventureUnitSkill skill = battleEffect.EffectSource as AdventureUnitSkill;
				SkillLogicBase skillLogic = skill.GetSkillLogic();
				if (skillLogic is ActiveSkillLogicBase && skillLogic is SpitFire)
				{
					IEnumerator enumerator = this.DisplayActiveSkillDamageEffectOnSingalTarget(skill).GetEnumerator();
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
		if (source is NormalAttackSource)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load(FilePath.GetNormalAttackPre()) as GameObject);
			if (gameObject != null)
			{
				base.CreateEeffect(gameObject, false);
			}
		}
		if (source is AdventureUnitSkill)
		{
			AdventureUnitSkill skill2 = source as AdventureUnitSkill;
			SkillLogicBase skillLogic2 = skill2.GetSkillLogic();
			if (skillLogic2 is ActiveSkillLogicBase)
			{
				if (skillLogic2 is Formless)
				{
					IEnumerator enumerator2 = this.DisplayActiveSkillDamageEffectOnSingalTarget(skill2).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				ActiveSkillLogicBase activeSkillLogic = skillLogic2 as ActiveSkillLogicBase;
				if (activeSkillLogic.PassiveIsActive(skill2))
				{
					IEnumerator enumerator3 = this.DisplayActiveSkillDamageEffectOnSingalTarget(skill2).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _3 = enumerator3.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
			else
			{
				UnityEngine.Object prefab = Resources.Load(FilePath.GetRegularSkillEffect(skill2.Skill.SkillType));
				if (prefab == null)
				{
					yield break;
				}
				GameObject effectObj = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject);
				if (isAdventurer)
				{
					Vector3 eulerAngles = effectObj.transform.rotation.eulerAngles;
					effectObj.transform.rotation = Quaternion.Euler(new Vector3(eulerAngles.x, eulerAngles.y - 180f, eulerAngles.z));
				}
				SkillEffectController skillEffect = effectObj.GetComponent<SkillEffectController>();
				if (skillEffect == null)
				{
					throw new Exception("Please add SkillEffectController to " + effectObj + " first.");
				}
				Transform castPos = base.CreateEeffect(effectObj, false);
				IEnumerator enumerator4 = skillEffect.Cast(castPos, null).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _4 = enumerator4.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x0006C0D8 File Offset: 0x0006A4D8
	public IEnumerable DisplayActiveSkillDamageEffectOnSingalTarget(AdventureUnitSkill skill)
	{
		string filepath = FilePath.GetSingalTargetableActiveSkillEffect(skill.Skill.SkillType);
		if (filepath == string.Empty)
		{
			yield break;
		}
		GameObject prefab = UnityEngine.Object.Instantiate(Resources.Load(filepath)) as GameObject;
		if (prefab != null)
		{
			SkillEffectController effectcontroller = prefab.GetComponent<SkillEffectController>();
			if (effectcontroller != null)
			{
				Transform castpos = base.CreateEeffect(prefab, false);
				IEnumerator enumerator = effectcontroller.Cast(castpos, null).GetEnumerator();
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

	// Token: 0x0600084A RID: 2122 RVA: 0x0006C104 File Offset: 0x0006A504
	public virtual IEnumerable UnitKilled(object obj)
	{
		if (!(this is NewEnemyCombatController))
		{
			base.gameObject.transform.localScale = Vector3.zero;
		}
		this.BattleUnit.RemoveAllEventCallbackFromUiLayer();
		this.LeavesEncounter();
		base.StartCoroutine(GameObjectUtil.WaitToRecycle(base.gameObject));
		yield break;
	}

	// Token: 0x0600084B RID: 2123
	public abstract IEnumerable UnitCastsSkill(SkillCastBattleEvent skillEvent, float animationWaitTime = 0.5f);

	// Token: 0x0600084C RID: 2124
	public abstract IEnumerable UnitNormalAttack(IBattleUnit unit, float animationWaitTime = 0.5f);

	// Token: 0x0600084D RID: 2125 RVA: 0x0006C128 File Offset: 0x0006A528
	public virtual IEnumerable UnitTriggersDialog(BattleUnitSpeaksEvent speakEvent)
	{
		if (speakEvent.DialogDetails.Count > 0 && !speakEvent.DialogDetails[0].IsCriticalDialog)
		{
			BattleDialogController component = UnityEngine.Object.Instantiate<GameObject>(FilePath.GetBattleDialogPre()).GetComponent<BattleDialogController>();
			Transform transform = base.GetComponentInChildren<CombatUnitHealthController>().transform;
			component.transform.SetParent(transform, false);
			component.Init(speakEvent.DialogDetails, speakEvent.BattleUnit.IsPlayer);
		}
		else
		{
			UIController ui = TownManager.Instance.Ui;
			if (ui.IsInTown)
			{
				ui.ShowBackToBattlePanel();
			}
			ui.AdventureDialog.gameObject.SetActive(true);
			ui.AdventureDialog.Init(new List<DialogItem>
			{
				new DialogItem
				{
					Dialogs = speakEvent.DialogDetails.GetContents(),
					UnitType = speakEvent.BattleUnit.GetUnitType(),
					OnLeftSide = speakEvent.BattleUnit.IsPlayer,
					UnitObj = base.gameObject
				}
			});
		}
		yield break;
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x0006C154 File Offset: 0x0006A554
	public virtual IEnumerable EnemyUnitDropsLoot(List<ResourceUpdate> resources)
	{
		foreach (ResourceUpdate resource in resources)
		{
			CombatDropController combatDropController = UnityEngine.Object.Instantiate<CombatDropController>(Resources.Load<CombatDropController>("Prefabs/CombatScene/CombatDrops/Resource"));
			combatDropController.Init(resource);
			combatDropController.transform.position = base.transform.position;
			CombatManager.Instance.CombatPointsController.AddDrop(combatDropController);
		}
		yield break;
	}

	// Token: 0x0600084F RID: 2127
	public abstract IEnumerable UnitCastsActiveSkill(ActiveSkillCastBattleEvent activeSkillEvent);

	// Token: 0x06000850 RID: 2128 RVA: 0x0006C180 File Offset: 0x0006A580
	public virtual IEnumerable UnitReceivesEffect(BattleEffectBase effect, Transform parent)
	{
		if (effect is FadeEffect && this.BattleUnit is AdventurerBattleUnit)
		{
			base.GetComponent<GenericAdventurer>().Transparent();
		}
		this.PopupBattleEffectsText(effect);
		this.AddEffectIcon(effect);
		if (effect != null)
		{
			SkillEffectController skillEffectController = this._currentBattleEffects.FirstOrDefault((SkillEffectController c) => c.BattleEffect.BattleEffectType == effect.BattleEffectType);
			if (skillEffectController != null)
			{
				skillEffectController.SetBattleEffect(effect);
			}
			else
			{
				UnityEngine.Object @object = Resources.Load(FilePath.GetBattleEffectsByBattleEffectType(effect.BattleEffectType));
				if (@object == null)
				{
					yield break;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
				SkillEffectController component = gameObject.GetComponent<SkillEffectController>();
				if (component == null)
				{
					throw new Exception(gameObject + " does not contain SkillEffectController");
				}
				if (component.AudioClip != null)
				{
					base.StartCoroutine(CombatManager.Instance.PlaySecond(component.AudioClip, component.DestroyBy).GetEnumerator());
				}
				AdjustableImageEffectFx component2 = gameObject.GetComponent<AdjustableImageEffectFx>();
				if (component2 != null)
				{
					UnitCombatController controllerByBattleUnit = BattleManager.instance.Spawner.GetControllerByBattleUnit(effect.EffectSource.SourceUnit);
					if (controllerByBattleUnit is AdventurerCombatController)
					{
						GenericAdventurer componentInChildren = ((AdventurerCombatController)controllerByBattleUnit).GetComponentInChildren<GenericAdventurer>();
						if (componentInChildren != null)
						{
							component2.SetImageForSkillEffect(componentInChildren.EastMiddle.sprite);
						}
					}
					else
					{
						Sprite enemyAvatarByUnitType = FilePath.GetEnemyAvatarByUnitType(effect.EffectSource.SourceUnit.GetUnitType());
						component2.SetImageForSkillEffect(enemyAvatarByUnitType);
					}
				}
				component.SetBattleEffect(effect);
				if (effect.BattleEffectType == BattleEffectType.Taunt)
				{
					gameObject.transform.SetParent(this.HealthController.transform, false);
					gameObject.transform.localPosition = Vector3.down * 3f;
				}
				else
				{
					gameObject.transform.SetParent(parent, false);
				}
				this._currentBattleEffects.Add(component);
			}
		}
		this.UpdateHealthBar();
		yield break;
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x0006C1B4 File Offset: 0x0006A5B4
	public virtual IEnumerable UnitLoosesEffect(object obj)
	{
		if (obj is FadeEffect && this.BattleUnit is AdventurerBattleUnit)
		{
			base.GetComponent<GenericAdventurer>().ResetColor();
		}
		if (this.BattleUnit.Status != BattleUnitStatus.Dead)
		{
			BattleEffectBase effect = obj as BattleEffectBase;
			if (effect == null)
			{
				throw new Exception(obj + " is not a BattleEffectBase");
			}
			this.RemoveEffectIcon(effect);
			SkillEffectController skillEffectController = this._currentBattleEffects.FirstOrDefault((SkillEffectController c) => c.BattleEffect == effect);
			if (skillEffectController != null)
			{
				UnityEngine.Object.Destroy(skillEffectController.gameObject);
				this._currentBattleEffects.Remove(skillEffectController);
			}
		}
		yield break;
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x0006C1DE File Offset: 0x0006A5DE
	public void UpdateHealthBar()
	{
		if (this.BattleUnit != null && this.BattleUnit.IsAliveInBattle() && base.isActiveAndEnabled)
		{
			this.HealthController.UpdateHealth();
		}
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x0006C214 File Offset: 0x0006A614
	public virtual IEnumerable PassiveEffectBecomeActive(IBattleUnit unit, object obj)
	{
		if (unit.GetId() != this.BattleUnit.GetId())
		{
			yield break;
		}
		AdventureUnitSkill skill = obj as AdventureUnitSkill;
		if (skill == null)
		{
			yield break;
		}
		PassiveEffectController x = this._currentPassiveEffectObjs.FirstOrDefault((PassiveEffectController c) => c.AdventureUnitSkill == skill);
		if (!(x == null))
		{
			yield break;
		}
		GameObject gameObject = Resources.Load(FilePath.GetBattlePassiveEffectPathAndBattleEffectOn(skill.Skill, unit.GetOutputAttributeType() == AttributeType.Intelligience)) as GameObject;
		if (gameObject != null)
		{
			GameObject gameObject2 = GameObjectUtil.Instantiate(gameObject, base.gameObject.transform.position, base.gameObject);
			gameObject2.transform.SetParent(base.gameObject.transform);
			gameObject2.transform.localScale = Vector3.one;
			PassiveEffectController component = gameObject2.GetComponent<PassiveEffectController>();
			component.AdventureUnitSkill = skill;
			this._currentPassiveEffectObjs.Add(component);
			yield break;
		}
		yield break;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x0006C248 File Offset: 0x0006A648
	private IEnumerable DamageNeutralized()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(FilePath.GetDamageNeutralizedEffectIndication())) as GameObject;
		if (gameObject == null)
		{
			yield break;
		}
		gameObject.transform.SetParent(base.gameObject.transform, false);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		yield break;
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x0006C26C File Offset: 0x0006A66C
	private void OnDestroy()
	{
		if (this.BattleUnit != null)
		{
			this.BattleUnit.RemoveAllEventCallbackFromUiLayer();
		}
		if (this.HealthController != null)
		{
			this.HealthController.transform.SetParent(null, false);
			this.HealthController.gameObject.PoolDestroy(PoolType.HealthBar);
		}
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x0006C2C4 File Offset: 0x0006A6C4
	private IEnumerable InversedKillPerformed(IBattleUnit target)
	{
		GameObject skillObj = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Skill Effects/BossSkills/DeathSkill/DeathSkill") as GameObject);
		if (!(skillObj != null))
		{
			throw new Exception("DeathSkill not found");
		}
		UnitCombatController unit = BattleManager.instance.Spawner.GetControllerByBattleUnit(target);
		if (unit == null)
		{
			yield break;
		}
		unit.CreateEeffect(skillObj, false);
		yield return new WaitForSeconds(3f);
		yield break;
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x0006C2E7 File Offset: 0x0006A6E7
	private void AdventureStoryTriggered(StoryIdentifier story)
	{
		TownManager.Instance.CreateAdventureStory(story.GetDetails().Details);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x0006C300 File Offset: 0x0006A700
	public virtual IEnumerable PassiveSkillFades(IBattleUnit unit, object obj)
	{
		if (unit.GetId() != this.BattleUnit.GetId())
		{
			yield break;
		}
		AdventureUnitSkill skill = obj as AdventureUnitSkill;
		PassiveEffectController passiveEffectController = this._currentPassiveEffectObjs.FirstOrDefault((PassiveEffectController c) => c.AdventureUnitSkill == skill);
		if (passiveEffectController != null)
		{
			this._currentPassiveEffectObjs.Remove(passiveEffectController);
			UnityEngine.Object.Destroy(passiveEffectController.gameObject);
			yield break;
		}
		yield break;
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x0006C334 File Offset: 0x0006A734
	public IEnumerator MoveForward()
	{
		this._isMovingForward = true;
		yield return new WaitForSeconds(0.2f);
		yield break;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x0006C350 File Offset: 0x0006A750
	public IEnumerator MoveBack()
	{
		this._isMovingBack = true;
		yield return new WaitForSeconds(0.2f);
		yield break;
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x0006C36C File Offset: 0x0006A76C
	public IEnumerable EscapeFromBattle()
	{
		if (this.CameFrom != null)
		{
			base.gameObject.transform.localScale = new Vector3(-base.gameObject.transform.localScale.x, base.gameObject.transform.localScale.y, base.gameObject.transform.localScale.z);
			yield return new WaitForSeconds(0.5f);
			Vector3 currentPos = base.transform.position;
			Vector3 targetPos = this.CameFrom.transform.position;
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / 1f;
				base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
				yield return null;
			}
		}
		yield break;
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x0006C390 File Offset: 0x0006A790
	private void RemoveEffectIcon(BattleEffectBase battleEffect)
	{
		EffectContainnerController componentInChildren = base.GetComponentInChildren<EffectContainnerController>();
		if (componentInChildren != null)
		{
			componentInChildren.RefreshEffectIcons(this.BattleUnit.BattleEffects, this.BattleUnit.IsPlayer);
		}
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x0006C3CC File Offset: 0x0006A7CC
	private void AddEffectIcon(BattleEffectBase battleEffect)
	{
		EffectContainnerController componentInChildren = base.GetComponentInChildren<EffectContainnerController>();
		if (componentInChildren != null)
		{
			componentInChildren.RefreshEffectIcons(this.BattleUnit.BattleEffects, this.BattleUnit.IsPlayer);
		}
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x0006C408 File Offset: 0x0006A808
	[CompilerGenerated]
	private static bool <LeavesEncounter>m__0(PassiveEffectController c)
	{
		return c != null;
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x0006C411 File Offset: 0x0006A811
	[CompilerGenerated]
	private static void <LeavesEncounter>m__1(PassiveEffectController c)
	{
		UnityEngine.Object.Destroy(c.gameObject);
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x0006C41E File Offset: 0x0006A81E
	[CompilerGenerated]
	private static bool <LeavesEncounter>m__2(SkillEffectController c)
	{
		return c != null;
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x0006C427 File Offset: 0x0006A827
	[CompilerGenerated]
	private static void <LeavesEncounter>m__3(SkillEffectController c)
	{
		UnityEngine.Object.Destroy(c.gameObject);
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x0006C434 File Offset: 0x0006A834
	[CompilerGenerated]
	private static bool <Init>m__4(ISpecialEffectDataLoad e)
	{
		return e is InversedMandateData;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x0006C43F File Offset: 0x0006A83F
	[CompilerGenerated]
	private static bool <Init>m__5(ISpecialEffectDataLoad e)
	{
		return e is InversedMandateData;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x0006C44A File Offset: 0x0006A84A
	[CompilerGenerated]
	private static bool <Init>m__6(ISpecialEffectDataLoad e)
	{
		return e is DemonSkullData;
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x0006C455 File Offset: 0x0006A855
	[CompilerGenerated]
	private static bool <Init>m__7(ISpecialEffectDataLoad e)
	{
		return e is DemonSkullData;
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x0006C460 File Offset: 0x0006A860
	[CompilerGenerated]
	private static bool <PopupBattleEffectsText>m__8(string d)
	{
		return d != string.Empty;
	}

	// Token: 0x04000AF2 RID: 2802
	protected float MovingSpeed = 80f;

	// Token: 0x04000AF3 RID: 2803
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x04000AF4 RID: 2804
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsBoxColliderEnabled>k__BackingField;

	// Token: 0x04000AF5 RID: 2805
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GameObject <CameFrom>k__BackingField;

	// Token: 0x04000AF6 RID: 2806
	private CombatUnitHealthController _healthController;

	// Token: 0x04000AF7 RID: 2807
	private GameObject _pet;

	// Token: 0x04000AF8 RID: 2808
	private readonly List<PassiveEffectController> _currentPassiveEffectObjs = new List<PassiveEffectController>();

	// Token: 0x04000AF9 RID: 2809
	private bool _isMovingForward;

	// Token: 0x04000AFA RID: 2810
	private bool _isMovingBack;

	// Token: 0x04000AFB RID: 2811
	private Vector3 _originStandPoint;

	// Token: 0x04000AFC RID: 2812
	private Vector3 _destination = new Vector3(100f, 2f, 0f);

	// Token: 0x04000AFD RID: 2813
	private readonly List<SkillEffectController> _currentBattleEffects = new List<SkillEffectController>();

	// Token: 0x04000AFE RID: 2814
	[CompilerGenerated]
	private static Func<PassiveEffectController, bool> <>f__am$cache0;

	// Token: 0x04000AFF RID: 2815
	[CompilerGenerated]
	private static Action<PassiveEffectController> <>f__am$cache1;

	// Token: 0x04000B00 RID: 2816
	[CompilerGenerated]
	private static Func<SkillEffectController, bool> <>f__am$cache2;

	// Token: 0x04000B01 RID: 2817
	[CompilerGenerated]
	private static Action<SkillEffectController> <>f__am$cache3;

	// Token: 0x04000B02 RID: 2818
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache4;

	// Token: 0x04000B03 RID: 2819
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache5;

	// Token: 0x04000B04 RID: 2820
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache6;

	// Token: 0x04000B05 RID: 2821
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, bool> <>f__am$cache7;

	// Token: 0x04000B06 RID: 2822
	[CompilerGenerated]
	private static Func<string, bool> <>f__am$cache8;

	// Token: 0x02000BEA RID: 3050
	[CompilerGenerated]
	private sealed class <Adventurer_ReceivesEventCallBack>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050C5 RID: 20677 RVA: 0x0006C46D File Offset: 0x0006A86D
		[DebuggerHidden]
		public <Adventurer_ReceivesEventCallBack>c__Iterator0()
		{
		}

		// Token: 0x060050C6 RID: 20678 RVA: 0x0006C478 File Offset: 0x0006A878
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (this != null && base.gameObject != null)
				{
					switch (type)
					{
					case AdventureEventType.AdventureInitialized:
						goto IL_F85;
					case AdventureEventType.AdventurerPreWalking:
						goto IL_F85;
					case AdventureEventType.AdventurersWalking:
						goto IL_F85;
					case AdventureEventType.AdventurerPostWalking:
						goto IL_F85;
					case AdventureEventType.UnitRegularTurnStarts:
						goto IL_F85;
					case AdventureEventType.UnitRegularTurnEnds:
						goto IL_F85;
					case AdventureEventType.UnitEntersTurn:
						goto IL_F85;
					case AdventureEventType.UnitSelectsSkill:
						goto IL_F85;
					case AdventureEventType.UnitSelectedSkill:
						goto IL_F85;
					case AdventureEventType.UnitCastsSkill:
						enumerator = this.UnitCastsSkill(obj as SkillCastBattleEvent, 0.5f).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					case AdventureEventType.UnitPostCastSkill:
						goto IL_F85;
					case AdventureEventType.UnitCompletesTurn:
						goto IL_F85;
					case AdventureEventType.UnitCompletesAction:
						this.$current = new WaitForSeconds(1f);
						if (!this.$disposing)
						{
							this.$PC = 8;
						}
						return true;
					case AdventureEventType.UnitCompletesSkillCast:
						goto IL_F85;
					case AdventureEventType.UnitEffectTriggered:
						goto IL_F85;
					case AdventureEventType.UnitReceivesDamage_CompleteSet:
						goto IL_F85;
					case AdventureEventType.UnitReceivesDamage_Single:
						goto IL_F85;
					case AdventureEventType.UnitPostReceivesDamage_Single:
						goto IL_F85;
					case AdventureEventType.UnitDamageNeutralized:
						enumerator2 = base.DamageNeutralized().GetEnumerator();
						num = 4294967293u;
						goto Block_20;
					case AdventureEventType.UnitReleasesDamage:
						goto IL_F85;
					case AdventureEventType.UnitReleasesHeal:
						goto IL_F85;
					case AdventureEventType.UnitReceivesHeal:
						enumerator3 = this.UnitReceivesHeal(obj as BattleHeal).GetEnumerator();
						num = 4294967293u;
						goto Block_7;
					case AdventureEventType.UnitPostReceivesDamage:
						enumerator4 = this.UnitReceivesDamage(obj as BattleDamage).GetEnumerator();
						num = 4294967293u;
						goto Block_6;
					case AdventureEventType.UnitPostReceivesHeal:
						base.UpdateHealthBar();
						goto IL_F85;
					case AdventureEventType.UnitKilled:
						enumerator5 = this.UnitKilled(obj).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					case AdventureEventType.UnitPreKilled:
						goto IL_F85;
					case AdventureEventType.UnitRevived:
						goto IL_F85;
					case AdventureEventType.UnitReceivesEffect:
						enumerator6 = this.UnitReceivesEffect(obj as BattleEffectBase, base.gameObject.transform).GetEnumerator();
						num = 4294967293u;
						goto Block_9;
					case AdventureEventType.UnitLoosesEffect:
						enumerator7 = this.UnitLoosesEffect(obj).GetEnumerator();
						num = 4294967293u;
						goto Block_10;
					case AdventureEventType.UnitNormalAttack:
						enumerator8 = this.UnitNormalAttack(unit, 0.5f).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					case AdventureEventType.BattleEffectDispersed:
						goto IL_F85;
					case AdventureEventType.BattleEffectResisted:
						base.StartCoroutine(base.PopupResistanceText(obj as BattleEffectBase));
						goto IL_F85;
					case AdventureEventType.UnitPreEntersBattle:
						goto IL_F85;
					case AdventureEventType.UnitReadyInBattle:
						base.UnitReadyInBattle();
						base.UpdateHealthBar();
						goto IL_F85;
					case AdventureEventType.PriorUnitTurnProgressChange:
						goto IL_F85;
					case AdventureEventType.UnitTurnProgressAlterred:
						goto IL_F85;
					case AdventureEventType.UnitTriggersDialog:
						enumerator9 = this.UnitTriggersDialog(obj as BattleUnitSpeaksEvent).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					case AdventureEventType.EnemyUnitDropsLoot:
						enumerator10 = this.EnemyUnitDropsLoot(obj as List<ResourceUpdate>).GetEnumerator();
						num = 4294967293u;
						goto Block_14;
					case AdventureEventType.UnitEscaped:
						if (unit.GetId() == base.BattleUnit.GetId())
						{
							enumerator11 = base.EscapeFromBattle().GetEnumerator();
							num = 4294967293u;
							goto Block_16;
						}
						goto IL_985;
					case AdventureEventType.BattleEncounterPlayerGaugeUpdated:
					case AdventureEventType.BattleEncounterEnemyGaugeUpdated:
					case AdventureEventType.BattleEncounterPlayerGaugeFullyCharged:
					case AdventureEventType.BattleEncounterPlayerGaugeReleased:
					case AdventureEventType.BattleEncounterEnemyGaugeFullyCharged:
					case AdventureEventType.BattleEncounterEnemyGaugeReleased:
						enumerator12 = BattleManager.instance.GaugeUpdated(unit, type, obj).GetEnumerator();
						num = 4294967293u;
						goto Block_17;
					case AdventureEventType.ActiveBattleSkillEntersCoolingDowns:
						goto IL_F85;
					case AdventureEventType.ActiveBattleSkillCompletesCoolingDowns:
						goto IL_F85;
					case AdventureEventType.BattleEffectTurnProgresses:
						goto IL_F85;
					case AdventureEventType.ActiveSkillPassiveBecomesAlive:
						enumerator13 = this.PassiveEffectBecomeActive(unit, obj).GetEnumerator();
						num = 4294967293u;
						goto Block_18;
					case AdventureEventType.ActiveSkillPassiveBecomesFades:
						enumerator14 = this.PassiveSkillFades(unit, obj).GetEnumerator();
						num = 4294967293u;
						goto Block_19;
					case AdventureEventType.AdventureProgresses:
						goto IL_F85;
					case AdventureEventType.AdventureSuccess:
						goto IL_F85;
					case AdventureEventType.AdventureFailed:
						goto IL_F85;
					case AdventureEventType.UnitPreRealKilled:
						goto IL_F85;
					case AdventureEventType.AdventureStoryTriggered:
						base.AdventureStoryTriggered((StoryIdentifier)obj);
						goto IL_F85;
					case AdventureEventType.BattleEncounterStarts:
						goto IL_F85;
					case AdventureEventType.AttributeCheckup:
						goto IL_F85;
					case AdventureEventType.BattleUnitPreDrops:
						goto IL_F85;
					case AdventureEventType.AdventureEffectTriggered:
						goto IL_F85;
					case AdventureEventType.UnitCastActiveSkill:
						enumerator15 = this.UnitCastsActiveSkill(obj as ActiveSkillCastBattleEvent).GetEnumerator();
						num = 4294967293u;
						goto Block_21;
					case AdventureEventType.UnitPostCastActiveSkill:
						goto IL_F85;
					case AdventureEventType.UnitCompleteActiveSkill:
						goto IL_F85;
					case AdventureEventType.BattleEncounterOptionsTriggered:
						battleSelector = (obj as BattleSelectorBase);
						if (battleSelector != null)
						{
							CombatManager.Instance.SetBattleSelector(battleSelector);
							goto IL_F85;
						}
						break;
					case AdventureEventType.BattleUnitSequenceCompleted:
						goto IL_F85;
					case AdventureEventType.BattleEffectCapStackReached:
						goto IL_F85;
					case AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime:
						goto IL_F85;
					case AdventureEventType.DemonSoulFullyCharged:
						goto IL_F85;
					case AdventureEventType.InversedKillPerformed:
						enumerator16 = base.InversedKillPerformed(obj as IBattleUnit).GetEnumerator();
						num = 4294967293u;
						goto Block_23;
					case AdventureEventType.DragonChargeReleased:
						goto IL_F85;
					case AdventureEventType.UnitBattleDialogueCompleted:
						goto IL_F85;
					case AdventureEventType.ElementDamageProcessCompleted:
						goto IL_F85;
					case AdventureEventType.BlackBeadSoulCollected:
						goto IL_F85;
					case AdventureEventType.TimeFragmentTriggered:
						enumerator17 = base.TimeFragmentTriggered(obj as List<IBattleUnit>).GetEnumerator();
						num = 4294967293u;
						goto Block_24;
					case AdventureEventType.DamageReleased:
						goto IL_F85;
					case AdventureEventType.TurnSetupCompleted:
						goto IL_F85;
					case AdventureEventType.PostHealRelease:
						goto IL_F85;
					case AdventureEventType.ChargeUpdated:
						goto IL_F85;
					case AdventureEventType.FirstEncounterStarted:
						goto IL_F85;
					case AdventureEventType.PetSummoned:
						base.PetSummoned(obj as PetBattleUnit);
						goto IL_F85;
					case AdventureEventType.PetRemoving:
						base.PetRemoving();
						goto IL_F85;
					case AdventureEventType.DamageReleaseProcessCompleted:
						goto IL_F85;
					}
					return false;
				}
				goto IL_F85;
			case 1u:
				break;
			case 2u:
				goto IL_2DB;
			case 3u:
				goto IL_391;
			case 4u:
				goto IL_437;
			case 5u:
				goto IL_4F7;
			case 6u:
				goto IL_59D;
			case 7u:
				goto IL_668;
			case 8u:
				goto IL_F85;
			case 9u:
				goto IL_765;
			case 10u:
				goto IL_812;
			case 11u:
				goto IL_901;
			case 12u:
				goto IL_9B4;
			case 13u:
				goto IL_A85;
			case 14u:
				goto IL_B33;
			case 15u:
				goto IL_BFC;
			case 16u:
				goto IL_CE2;
			case 17u:
				goto IL_DD4;
			case 18u:
				goto IL_EA9;
			default:
				return false;
			}
			Block_5:
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
			goto IL_F85;
			Block_6:
			try
			{
				IL_2DB:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
					this.$current = _4;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			base.UpdateHealthBar();
			goto IL_F85;
			Block_7:
			try
			{
				IL_391:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_8:
			try
			{
				IL_437:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_5 = enumerator5.Current;
					this.$current = _5;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_9:
			try
			{
				IL_4F7:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_6 = enumerator6.Current;
					this.$current = _6;
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_10:
			try
			{
				IL_59D:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_7 = enumerator7.Current;
					this.$current = _7;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_11:
			try
			{
				IL_668:
				switch (num)
				{
				}
				if (enumerator8.MoveNext())
				{
					_8 = enumerator8.Current;
					this.$current = _8;
					if (!this.$disposing)
					{
						this.$PC = 7;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_13:
			try
			{
				IL_765:
				switch (num)
				{
				}
				if (enumerator9.MoveNext())
				{
					_9 = enumerator9.Current;
					this.$current = _9;
					if (!this.$disposing)
					{
						this.$PC = 9;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable9 = (enumerator9 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_14:
			try
			{
				IL_812:
				switch (num)
				{
				}
				if (enumerator10.MoveNext())
				{
					_10 = enumerator10.Current;
					this.$current = _10;
					if (!this.$disposing)
					{
						this.$PC = 10;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable10 = (enumerator10 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_16:
			try
			{
				IL_901:
				switch (num)
				{
				}
				if (enumerator11.MoveNext())
				{
					_11 = enumerator11.Current;
					this.$current = _11;
					if (!this.$disposing)
					{
						this.$PC = 11;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable11 = (enumerator11 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
			}
			IL_985:
			goto IL_F85;
			Block_17:
			try
			{
				IL_9B4:
				switch (num)
				{
				}
				if (enumerator12.MoveNext())
				{
					_12 = enumerator12.Current;
					this.$current = _12;
					if (!this.$disposing)
					{
						this.$PC = 12;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable12 = (enumerator12 as IDisposable)) != null)
					{
						disposable12.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_18:
			try
			{
				IL_A85:
				switch (num)
				{
				}
				if (enumerator13.MoveNext())
				{
					_13 = enumerator13.Current;
					this.$current = _13;
					if (!this.$disposing)
					{
						this.$PC = 13;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable13 = (enumerator13 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_19:
			try
			{
				IL_B33:
				switch (num)
				{
				}
				if (enumerator14.MoveNext())
				{
					_14 = enumerator14.Current;
					this.$current = _14;
					if (!this.$disposing)
					{
						this.$PC = 14;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable14 = (enumerator14 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_20:
			try
			{
				IL_BFC:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 15;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_21:
			try
			{
				IL_CE2:
				switch (num)
				{
				}
				if (enumerator15.MoveNext())
				{
					_15 = enumerator15.Current;
					this.$current = _15;
					if (!this.$disposing)
					{
						this.$PC = 16;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable15 = (enumerator15 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_23:
			try
			{
				IL_DD4:
				switch (num)
				{
				}
				if (enumerator16.MoveNext())
				{
					_16 = enumerator16.Current;
					this.$current = _16;
					if (!this.$disposing)
					{
						this.$PC = 17;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable16 = (enumerator16 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
			}
			goto IL_F85;
			Block_24:
			try
			{
				IL_EA9:
				switch (num)
				{
				}
				if (enumerator17.MoveNext())
				{
					_17 = enumerator17.Current;
					this.$current = _17;
					if (!this.$disposing)
					{
						this.$PC = 18;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable17 = (enumerator17 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
			}
			IL_F85:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001132 RID: 4402
		// (get) Token: 0x060050C7 RID: 20679 RVA: 0x0006D4E4 File Offset: 0x0006B8E4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001133 RID: 4403
		// (get) Token: 0x060050C8 RID: 20680 RVA: 0x0006D4EC File Offset: 0x0006B8EC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050C9 RID: 20681 RVA: 0x0006D4F4 File Offset: 0x0006B8F4
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
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			case 7u:
				try
				{
				}
				finally
				{
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				break;
			case 9u:
				try
				{
				}
				finally
				{
					if ((disposable9 = (enumerator9 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				break;
			case 10u:
				try
				{
				}
				finally
				{
					if ((disposable10 = (enumerator10 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				break;
			case 11u:
				try
				{
				}
				finally
				{
					if ((disposable11 = (enumerator11 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
				break;
			case 12u:
				try
				{
				}
				finally
				{
					if ((disposable12 = (enumerator12 as IDisposable)) != null)
					{
						disposable12.Dispose();
					}
				}
				break;
			case 13u:
				try
				{
				}
				finally
				{
					if ((disposable13 = (enumerator13 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
				break;
			case 14u:
				try
				{
				}
				finally
				{
					if ((disposable14 = (enumerator14 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
				break;
			case 15u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 16u:
				try
				{
				}
				finally
				{
					if ((disposable15 = (enumerator15 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
				break;
			case 17u:
				try
				{
				}
				finally
				{
					if ((disposable16 = (enumerator16 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
				break;
			case 18u:
				try
				{
				}
				finally
				{
					if ((disposable17 = (enumerator17 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060050CA RID: 20682 RVA: 0x0006D958 File Offset: 0x0006BD58
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050CB RID: 20683 RVA: 0x0006D95F File Offset: 0x0006BD5F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050CC RID: 20684 RVA: 0x0006D968 File Offset: 0x0006BD68
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<Adventurer_ReceivesEventCallBack>c__Iterator0 <Adventurer_ReceivesEventCallBack>c__Iterator = new UnitCombatController.<Adventurer_ReceivesEventCallBack>c__Iterator0();
			<Adventurer_ReceivesEventCallBack>c__Iterator.$this = this;
			<Adventurer_ReceivesEventCallBack>c__Iterator.type = type;
			<Adventurer_ReceivesEventCallBack>c__Iterator.obj = obj;
			<Adventurer_ReceivesEventCallBack>c__Iterator.unit = unit;
			return <Adventurer_ReceivesEventCallBack>c__Iterator;
		}

		// Token: 0x04003EB7 RID: 16055
		internal AdventureEventType type;

		// Token: 0x04003EB8 RID: 16056
		internal object obj;

		// Token: 0x04003EB9 RID: 16057
		internal IEnumerator $locvar0;

		// Token: 0x04003EBA RID: 16058
		internal object <_>__1;

		// Token: 0x04003EBB RID: 16059
		internal IDisposable $locvar1;

		// Token: 0x04003EBC RID: 16060
		internal IEnumerator $locvar2;

		// Token: 0x04003EBD RID: 16061
		internal object <_>__2;

		// Token: 0x04003EBE RID: 16062
		internal IDisposable $locvar3;

		// Token: 0x04003EBF RID: 16063
		internal IEnumerator $locvar4;

		// Token: 0x04003EC0 RID: 16064
		internal object <_>__3;

		// Token: 0x04003EC1 RID: 16065
		internal IDisposable $locvar5;

		// Token: 0x04003EC2 RID: 16066
		internal IEnumerator $locvar6;

		// Token: 0x04003EC3 RID: 16067
		internal object <_>__4;

		// Token: 0x04003EC4 RID: 16068
		internal IDisposable $locvar7;

		// Token: 0x04003EC5 RID: 16069
		internal IEnumerator $locvar8;

		// Token: 0x04003EC6 RID: 16070
		internal object <_>__5;

		// Token: 0x04003EC7 RID: 16071
		internal IDisposable $locvar9;

		// Token: 0x04003EC8 RID: 16072
		internal IEnumerator $locvarA;

		// Token: 0x04003EC9 RID: 16073
		internal object <_>__6;

		// Token: 0x04003ECA RID: 16074
		internal IDisposable $locvarB;

		// Token: 0x04003ECB RID: 16075
		internal IBattleUnit unit;

		// Token: 0x04003ECC RID: 16076
		internal IEnumerator $locvarC;

		// Token: 0x04003ECD RID: 16077
		internal object <_>__7;

		// Token: 0x04003ECE RID: 16078
		internal IDisposable $locvarD;

		// Token: 0x04003ECF RID: 16079
		internal IEnumerator $locvarE;

		// Token: 0x04003ED0 RID: 16080
		internal object <_>__8;

		// Token: 0x04003ED1 RID: 16081
		internal IDisposable $locvarF;

		// Token: 0x04003ED2 RID: 16082
		internal IEnumerator $locvar10;

		// Token: 0x04003ED3 RID: 16083
		internal object <_>__9;

		// Token: 0x04003ED4 RID: 16084
		internal IDisposable $locvar11;

		// Token: 0x04003ED5 RID: 16085
		internal IEnumerator $locvar12;

		// Token: 0x04003ED6 RID: 16086
		internal object <_>__10;

		// Token: 0x04003ED7 RID: 16087
		internal IDisposable $locvar13;

		// Token: 0x04003ED8 RID: 16088
		internal IEnumerator $locvar14;

		// Token: 0x04003ED9 RID: 16089
		internal object <_>__11;

		// Token: 0x04003EDA RID: 16090
		internal IDisposable $locvar15;

		// Token: 0x04003EDB RID: 16091
		internal IEnumerator $locvar16;

		// Token: 0x04003EDC RID: 16092
		internal object <_>__12;

		// Token: 0x04003EDD RID: 16093
		internal IDisposable $locvar17;

		// Token: 0x04003EDE RID: 16094
		internal IEnumerator $locvar18;

		// Token: 0x04003EDF RID: 16095
		internal object <_>__13;

		// Token: 0x04003EE0 RID: 16096
		internal IDisposable $locvar19;

		// Token: 0x04003EE1 RID: 16097
		internal IEnumerator $locvar1A;

		// Token: 0x04003EE2 RID: 16098
		internal object <_>__14;

		// Token: 0x04003EE3 RID: 16099
		internal IDisposable $locvar1B;

		// Token: 0x04003EE4 RID: 16100
		internal IEnumerator $locvar1C;

		// Token: 0x04003EE5 RID: 16101
		internal object <_>__15;

		// Token: 0x04003EE6 RID: 16102
		internal IDisposable $locvar1D;

		// Token: 0x04003EE7 RID: 16103
		internal BattleSelectorBase <battleSelector>__16;

		// Token: 0x04003EE8 RID: 16104
		internal IEnumerator $locvar1E;

		// Token: 0x04003EE9 RID: 16105
		internal object <_>__17;

		// Token: 0x04003EEA RID: 16106
		internal IDisposable $locvar1F;

		// Token: 0x04003EEB RID: 16107
		internal IEnumerator $locvar20;

		// Token: 0x04003EEC RID: 16108
		internal object <_>__18;

		// Token: 0x04003EED RID: 16109
		internal IDisposable $locvar21;

		// Token: 0x04003EEE RID: 16110
		internal UnitCombatController $this;

		// Token: 0x04003EEF RID: 16111
		internal object $current;

		// Token: 0x04003EF0 RID: 16112
		internal bool $disposing;

		// Token: 0x04003EF1 RID: 16113
		internal int $PC;
	}

	// Token: 0x02000BEB RID: 3051
	[CompilerGenerated]
	private sealed class <TimeFragmentTriggered>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050CD RID: 20685 RVA: 0x0006D9C0 File Offset: 0x0006BDC0
		[DebuggerHidden]
		public <TimeFragmentTriggered>c__Iterator1()
		{
		}

		// Token: 0x060050CE RID: 20686 RVA: 0x0006D9C8 File Offset: 0x0006BDC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				skillObj = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Skill Effects/BossSkills/InversedMandate/InversedMandate") as GameObject);
				if (!(skillObj != null))
				{
					goto IL_111;
				}
				casTransform = CombatManager.Instance.GetAdventureSkillCastPonit();
				effectController = skillObj.GetComponent<SkillEffectController>();
				enumerator = effectController.Cast(casTransform, null).GetEnumerator();
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
			IL_111:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001134 RID: 4404
		// (get) Token: 0x060050CF RID: 20687 RVA: 0x0006DB00 File Offset: 0x0006BF00
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001135 RID: 4405
		// (get) Token: 0x060050D0 RID: 20688 RVA: 0x0006DB08 File Offset: 0x0006BF08
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050D1 RID: 20689 RVA: 0x0006DB10 File Offset: 0x0006BF10
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

		// Token: 0x060050D2 RID: 20690 RVA: 0x0006DB80 File Offset: 0x0006BF80
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050D3 RID: 20691 RVA: 0x0006DB87 File Offset: 0x0006BF87
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050D4 RID: 20692 RVA: 0x0006DB8F File Offset: 0x0006BF8F
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new UnitCombatController.<TimeFragmentTriggered>c__Iterator1();
		}

		// Token: 0x04003EF2 RID: 16114
		internal GameObject <skillObj>__0;

		// Token: 0x04003EF3 RID: 16115
		internal Transform <casTransform>__1;

		// Token: 0x04003EF4 RID: 16116
		internal SkillEffectController <effectController>__1;

		// Token: 0x04003EF5 RID: 16117
		internal IEnumerator $locvar0;

		// Token: 0x04003EF6 RID: 16118
		internal object <_>__2;

		// Token: 0x04003EF7 RID: 16119
		internal IDisposable $locvar1;

		// Token: 0x04003EF8 RID: 16120
		internal object $current;

		// Token: 0x04003EF9 RID: 16121
		internal bool $disposing;

		// Token: 0x04003EFA RID: 16122
		internal int $PC;
	}

	// Token: 0x02000BEC RID: 3052
	[CompilerGenerated]
	private sealed class <UnitReceivesDamage>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050D5 RID: 20693 RVA: 0x0006DBAA File Offset: 0x0006BFAA
		[DebuggerHidden]
		public <UnitReceivesDamage>c__Iterator2()
		{
		}

		// Token: 0x060050D6 RID: 20694 RVA: 0x0006DBB4 File Offset: 0x0006BFB4
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(base.PopupDamageText(damageEvent.Damages, damageEvent.DamageSource));
				}
			}
			return false;
		}

		// Token: 0x17001136 RID: 4406
		// (get) Token: 0x060050D7 RID: 20695 RVA: 0x0006DC16 File Offset: 0x0006C016
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001137 RID: 4407
		// (get) Token: 0x060050D8 RID: 20696 RVA: 0x0006DC1E File Offset: 0x0006C01E
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050D9 RID: 20697 RVA: 0x0006DC26 File Offset: 0x0006C026
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060050DA RID: 20698 RVA: 0x0006DC28 File Offset: 0x0006C028
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050DB RID: 20699 RVA: 0x0006DC2F File Offset: 0x0006C02F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050DC RID: 20700 RVA: 0x0006DC38 File Offset: 0x0006C038
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitReceivesDamage>c__Iterator2 <UnitReceivesDamage>c__Iterator = new UnitCombatController.<UnitReceivesDamage>c__Iterator2();
			<UnitReceivesDamage>c__Iterator.$this = this;
			<UnitReceivesDamage>c__Iterator.damageEvent = damageEvent;
			return <UnitReceivesDamage>c__Iterator;
		}

		// Token: 0x04003EFB RID: 16123
		internal BattleDamage damageEvent;

		// Token: 0x04003EFC RID: 16124
		internal UnitCombatController $this;

		// Token: 0x04003EFD RID: 16125
		internal object $current;

		// Token: 0x04003EFE RID: 16126
		internal bool $disposing;

		// Token: 0x04003EFF RID: 16127
		internal int $PC;
	}

	// Token: 0x02000BED RID: 3053
	[CompilerGenerated]
	private sealed class <PopupResistanceText>c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050DD RID: 20701 RVA: 0x0006DC78 File Offset: 0x0006C078
		[DebuggerHidden]
		public <PopupResistanceText>c__Iterator3()
		{
		}

		// Token: 0x060050DE RID: 20702 RVA: 0x0006DC80 File Offset: 0x0006C080
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				UIMiscGenerator.Instance.CreateMissPopupText(new PopupTextElement
				{
					Text = UIComponentType.Resisted.GetName(),
					IsCriticle = false,
					IsMagical = false,
					Position = base.transform.position,
					IsAdventurer = false
				});
				this.$current = new WaitForSeconds(0.2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001138 RID: 4408
		// (get) Token: 0x060050DF RID: 20703 RVA: 0x0006DD28 File Offset: 0x0006C128
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x060050E0 RID: 20704 RVA: 0x0006DD30 File Offset: 0x0006C130
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050E1 RID: 20705 RVA: 0x0006DD38 File Offset: 0x0006C138
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060050E2 RID: 20706 RVA: 0x0006DD48 File Offset: 0x0006C148
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F00 RID: 16128
		internal UnitCombatController $this;

		// Token: 0x04003F01 RID: 16129
		internal object $current;

		// Token: 0x04003F02 RID: 16130
		internal bool $disposing;

		// Token: 0x04003F03 RID: 16131
		internal int $PC;
	}

	// Token: 0x02000BEE RID: 3054
	[CompilerGenerated]
	private sealed class <PopupDamageText>c__Iterator4 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050E3 RID: 20707 RVA: 0x0006DD4F File Offset: 0x0006C14F
		[DebuggerHidden]
		public <PopupDamageText>c__Iterator4()
		{
		}

		// Token: 0x060050E4 RID: 20708 RVA: 0x0006DD58 File Offset: 0x0006C158
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = (from d in damages
				where d.GetTotalDamageSoFar() > 0.0 || d.IsMissed
				select d).ToList<DamageComponent>().GetEnumerator();
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
					damageComponent = enumerator.Current;
					if (damageComponent.GetElementalTotal(OutputType.Fire) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Fire, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Divine) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Divine, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Ice) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Ice, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Lightening) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Lightening, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Physical) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Physical, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Poison) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Poison, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.Shadow) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.Shadow, source);
					}
					if (damageComponent.GetElementalTotal(OutputType.RealDamage) > 0.0)
					{
						base.DisplayOutputEffect(OutputType.RealDamage, source);
					}
					if (damageComponent.IsMissed)
					{
						UIMiscGenerator.Instance.CreateMissPopupText(new PopupTextElement
						{
							Text = "Miss",
							IsCriticle = false,
							IsMagical = false,
							Position = base.transform.position,
							IsAdventurer = false
						});
					}
					else
					{
						UIMiscGenerator.Instance.CreateDamagePopupText(new PopupTextElement
						{
							Text = "-" + damageComponent.GetTotalDamageSoFar().DoubleToShortNumber(),
							IsCriticle = damageComponent.IsCritDamage(),
							IsMagical = false,
							Position = base.transform.position,
							IsAdventurer = false
						});
					}
					this.$current = new WaitForSeconds(0.2f);
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
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x060050E5 RID: 20709 RVA: 0x0006E080 File Offset: 0x0006C480
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x060050E6 RID: 20710 RVA: 0x0006E088 File Offset: 0x0006C488
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050E7 RID: 20711 RVA: 0x0006E090 File Offset: 0x0006C490
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
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060050E8 RID: 20712 RVA: 0x0006E0EC File Offset: 0x0006C4EC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050E9 RID: 20713 RVA: 0x0006E0F3 File Offset: 0x0006C4F3
		private static bool <>m__0(DamageComponent d)
		{
			return d.GetTotalDamageSoFar() > 0.0 || d.IsMissed;
		}

		// Token: 0x04003F04 RID: 16132
		internal List<DamageComponent> damages;

		// Token: 0x04003F05 RID: 16133
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x04003F06 RID: 16134
		internal DamageComponent <damageComponent>__1;

		// Token: 0x04003F07 RID: 16135
		internal IBattleEffectSource source;

		// Token: 0x04003F08 RID: 16136
		internal UnitCombatController $this;

		// Token: 0x04003F09 RID: 16137
		internal object $current;

		// Token: 0x04003F0A RID: 16138
		internal bool $disposing;

		// Token: 0x04003F0B RID: 16139
		internal int $PC;

		// Token: 0x04003F0C RID: 16140
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}

	// Token: 0x02000BEF RID: 3055
	[CompilerGenerated]
	private sealed class <UnitReceivesHeal>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050EA RID: 20714 RVA: 0x0006E112 File Offset: 0x0006C512
		[DebuggerHidden]
		public <UnitReceivesHeal>c__Iterator5()
		{
		}

		// Token: 0x060050EB RID: 20715 RVA: 0x0006E11C File Offset: 0x0006C51C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (base.isActiveAndEnabled)
				{
					base.StartCoroutine(base.PopupHealingText(heal.Heals));
				}
			}
			return false;
		}

		// Token: 0x1700113C RID: 4412
		// (get) Token: 0x060050EC RID: 20716 RVA: 0x0006E173 File Offset: 0x0006C573
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700113D RID: 4413
		// (get) Token: 0x060050ED RID: 20717 RVA: 0x0006E17B File Offset: 0x0006C57B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050EE RID: 20718 RVA: 0x0006E183 File Offset: 0x0006C583
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060050EF RID: 20719 RVA: 0x0006E185 File Offset: 0x0006C585
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060050F0 RID: 20720 RVA: 0x0006E18C File Offset: 0x0006C58C
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060050F1 RID: 20721 RVA: 0x0006E194 File Offset: 0x0006C594
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitReceivesHeal>c__Iterator5 <UnitReceivesHeal>c__Iterator = new UnitCombatController.<UnitReceivesHeal>c__Iterator5();
			<UnitReceivesHeal>c__Iterator.$this = this;
			<UnitReceivesHeal>c__Iterator.heal = heal;
			return <UnitReceivesHeal>c__Iterator;
		}

		// Token: 0x04003F0D RID: 16141
		internal BattleHeal heal;

		// Token: 0x04003F0E RID: 16142
		internal UnitCombatController $this;

		// Token: 0x04003F0F RID: 16143
		internal object $current;

		// Token: 0x04003F10 RID: 16144
		internal bool $disposing;

		// Token: 0x04003F11 RID: 16145
		internal int $PC;
	}

	// Token: 0x02000BF0 RID: 3056
	[CompilerGenerated]
	private sealed class <PopupHealingText>c__Iterator6 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050F2 RID: 20722 RVA: 0x0006E1D4 File Offset: 0x0006C5D4
		[DebuggerHidden]
		public <PopupHealingText>c__Iterator6()
		{
		}

		// Token: 0x060050F3 RID: 20723 RVA: 0x0006E1DC File Offset: 0x0006C5DC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = heals.GetEnumerator();
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
					healComponent = enumerator.Current;
					UIMiscGenerator.Instance.CreateHealPopupText(new PopupTextElement
					{
						Text = "+" + healComponent.GetFinalHealSoFar().DoubleToShortNumber() + ((healComponent.ExceededHealValue == null || healComponent.ExceededHealValue.Value <= 0.0) ? string.Empty : ("(" + (int)healComponent.ExceededHealValue.Value + ")")),
						IsCriticle = healComponent.IsCrit,
						Position = base.transform.position
					});
					this.$current = new WaitForSeconds(0.2f);
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
					((IDisposable)enumerator).Dispose();
				}
			}
			return false;
		}

		// Token: 0x1700113E RID: 4414
		// (get) Token: 0x060050F4 RID: 20724 RVA: 0x0006E384 File Offset: 0x0006C784
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700113F RID: 4415
		// (get) Token: 0x060050F5 RID: 20725 RVA: 0x0006E38C File Offset: 0x0006C78C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050F6 RID: 20726 RVA: 0x0006E394 File Offset: 0x0006C794
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
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060050F7 RID: 20727 RVA: 0x0006E3F0 File Offset: 0x0006C7F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F12 RID: 16146
		internal List<HealComponent> heals;

		// Token: 0x04003F13 RID: 16147
		internal List<HealComponent>.Enumerator $locvar0;

		// Token: 0x04003F14 RID: 16148
		internal HealComponent <healComponent>__1;

		// Token: 0x04003F15 RID: 16149
		internal UnitCombatController $this;

		// Token: 0x04003F16 RID: 16150
		internal object $current;

		// Token: 0x04003F17 RID: 16151
		internal bool $disposing;

		// Token: 0x04003F18 RID: 16152
		internal int $PC;
	}

	// Token: 0x02000BF1 RID: 3057
	[CompilerGenerated]
	private sealed class <PopupEffectText>c__Iterator7 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050F8 RID: 20728 RVA: 0x0006E3F7 File Offset: 0x0006C7F7
		[DebuggerHidden]
		public <PopupEffectText>c__Iterator7()
		{
		}

		// Token: 0x060050F9 RID: 20729 RVA: 0x0006E400 File Offset: 0x0006C800
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				List<PopupTextElement> list = new List<PopupTextElement>();
				foreach (string text in effectDescs)
				{
					PopupTextElement item = new PopupTextElement
					{
						Text = text,
						Position = base.transform.position
					};
					list.Add(item);
				}
				UIMiscGenerator.Instance.AddPopupTexts(list);
			}
			return false;
		}

		// Token: 0x17001140 RID: 4416
		// (get) Token: 0x060050FA RID: 20730 RVA: 0x0006E4B0 File Offset: 0x0006C8B0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001141 RID: 4417
		// (get) Token: 0x060050FB RID: 20731 RVA: 0x0006E4B8 File Offset: 0x0006C8B8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050FC RID: 20732 RVA: 0x0006E4C0 File Offset: 0x0006C8C0
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060050FD RID: 20733 RVA: 0x0006E4C2 File Offset: 0x0006C8C2
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F19 RID: 16153
		internal List<string> effectDescs;

		// Token: 0x04003F1A RID: 16154
		internal UnitCombatController $this;

		// Token: 0x04003F1B RID: 16155
		internal object $current;

		// Token: 0x04003F1C RID: 16156
		internal bool $disposing;

		// Token: 0x04003F1D RID: 16157
		internal int $PC;
	}

	// Token: 0x02000BF2 RID: 3058
	[CompilerGenerated]
	private sealed class <DisplayEffect>c__Iterator8 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050FE RID: 20734 RVA: 0x0006E4C9 File Offset: 0x0006C8C9
		[DebuggerHidden]
		public <DisplayEffect>c__Iterator8()
		{
		}

		// Token: 0x060050FF RID: 20735 RVA: 0x0006E4D4 File Offset: 0x0006C8D4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(source is BattleEffectBase))
				{
					goto IL_14D;
				}
				battleEffect = (source as BattleEffectBase);
				if (!(battleEffect.EffectSource is AdventureUnitSkill))
				{
					goto IL_14D;
				}
				skill = (battleEffect.EffectSource as AdventureUnitSkill);
				skillLogic = skill.GetSkillLogic();
				if (!(skillLogic is ActiveSkillLogicBase) || !(skillLogic is SpitFire))
				{
					goto IL_14D;
				}
				enumerator = base.DisplayActiveSkillDamageEffectOnSingalTarget(skill).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_12:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
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
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_27F;
			case 3u:
				Block_14:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_347;
			case 4u:
				Block_18:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_4 = enumerator4.Current;
						this.$current = _4;
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				goto IL_4EA;
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
			IL_14D:
			if (source is NormalAttackSource)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load(FilePath.GetNormalAttackPre()) as GameObject);
				if (gameObject != null)
				{
					base.CreateEeffect(gameObject, false);
				}
			}
			if (!(source is AdventureUnitSkill))
			{
				goto IL_4EA;
			}
			skill2 = (source as AdventureUnitSkill);
			skillLogic2 = skill2.GetSkillLogic();
			if (skillLogic2 is ActiveSkillLogicBase)
			{
				if (skillLogic2 is Formless)
				{
					enumerator2 = base.DisplayActiveSkillDamageEffectOnSingalTarget(skill2).GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
			}
			else
			{
				prefab = Resources.Load(FilePath.GetRegularSkillEffect(skill2.Skill.SkillType));
				if (prefab == null)
				{
					return false;
				}
				effectObj = UnityEngine.Object.Instantiate<GameObject>(prefab as GameObject);
				if (isAdventurer)
				{
					Vector3 eulerAngles = effectObj.transform.rotation.eulerAngles;
					effectObj.transform.rotation = Quaternion.Euler(new Vector3(eulerAngles.x, eulerAngles.y - 180f, eulerAngles.z));
				}
				skillEffect = effectObj.GetComponent<SkillEffectController>();
				if (skillEffect == null)
				{
					throw new Exception("Please add SkillEffectController to " + effectObj + " first.");
				}
				castPos = base.CreateEeffect(effectObj, false);
				enumerator4 = skillEffect.Cast(castPos, null).GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			}
			IL_27F:
			activeSkillLogic = (skillLogic2 as ActiveSkillLogicBase);
			if (activeSkillLogic.PassiveIsActive(skill2))
			{
				enumerator3 = base.DisplayActiveSkillDamageEffectOnSingalTarget(skill2).GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			}
			IL_347:
			IL_4EA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001142 RID: 4418
		// (get) Token: 0x06005100 RID: 20736 RVA: 0x0006EA0C File Offset: 0x0006CE0C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001143 RID: 4419
		// (get) Token: 0x06005101 RID: 20737 RVA: 0x0006EA14 File Offset: 0x0006CE14
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005102 RID: 20738 RVA: 0x0006EA1C File Offset: 0x0006CE1C
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
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005103 RID: 20739 RVA: 0x0006EB48 File Offset: 0x0006CF48
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F1E RID: 16158
		internal IBattleEffectSource source;

		// Token: 0x04003F1F RID: 16159
		internal BattleEffectBase <battleEffect>__1;

		// Token: 0x04003F20 RID: 16160
		internal AdventureUnitSkill <skill>__2;

		// Token: 0x04003F21 RID: 16161
		internal SkillLogicBase <skillLogic>__2;

		// Token: 0x04003F22 RID: 16162
		internal IEnumerator $locvar0;

		// Token: 0x04003F23 RID: 16163
		internal object <_>__3;

		// Token: 0x04003F24 RID: 16164
		internal IDisposable $locvar1;

		// Token: 0x04003F25 RID: 16165
		internal AdventureUnitSkill <skill>__4;

		// Token: 0x04003F26 RID: 16166
		internal SkillLogicBase <skillLogic>__4;

		// Token: 0x04003F27 RID: 16167
		internal IEnumerator $locvar2;

		// Token: 0x04003F28 RID: 16168
		internal object <_>__5;

		// Token: 0x04003F29 RID: 16169
		internal IDisposable $locvar3;

		// Token: 0x04003F2A RID: 16170
		internal ActiveSkillLogicBase <activeSkillLogic>__6;

		// Token: 0x04003F2B RID: 16171
		internal IEnumerator $locvar4;

		// Token: 0x04003F2C RID: 16172
		internal object <_>__7;

		// Token: 0x04003F2D RID: 16173
		internal IDisposable $locvar5;

		// Token: 0x04003F2E RID: 16174
		internal UnityEngine.Object <prefab>__8;

		// Token: 0x04003F2F RID: 16175
		internal GameObject <effectObj>__8;

		// Token: 0x04003F30 RID: 16176
		internal bool isAdventurer;

		// Token: 0x04003F31 RID: 16177
		internal SkillEffectController <skillEffect>__8;

		// Token: 0x04003F32 RID: 16178
		internal Transform <castPos>__8;

		// Token: 0x04003F33 RID: 16179
		internal IEnumerator $locvar6;

		// Token: 0x04003F34 RID: 16180
		internal object <_>__9;

		// Token: 0x04003F35 RID: 16181
		internal IDisposable $locvar7;

		// Token: 0x04003F36 RID: 16182
		internal UnitCombatController $this;

		// Token: 0x04003F37 RID: 16183
		internal object $current;

		// Token: 0x04003F38 RID: 16184
		internal bool $disposing;

		// Token: 0x04003F39 RID: 16185
		internal int $PC;
	}

	// Token: 0x02000BF3 RID: 3059
	[CompilerGenerated]
	private sealed class <DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005104 RID: 20740 RVA: 0x0006EB4F File Offset: 0x0006CF4F
		[DebuggerHidden]
		public <DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator9()
		{
		}

		// Token: 0x06005105 RID: 20741 RVA: 0x0006EB58 File Offset: 0x0006CF58
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				filepath = FilePath.GetSingalTargetableActiveSkillEffect(skill.Skill.SkillType);
				if (filepath == string.Empty)
				{
					return false;
				}
				prefab = (UnityEngine.Object.Instantiate(Resources.Load(filepath)) as GameObject);
				if (!(prefab != null))
				{
					goto IL_160;
				}
				effectcontroller = prefab.GetComponent<SkillEffectController>();
				if (!(effectcontroller != null))
				{
					goto IL_160;
				}
				castpos = base.CreateEeffect(prefab, false);
				enumerator = effectcontroller.Cast(castpos, null).GetEnumerator();
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
			IL_160:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001144 RID: 4420
		// (get) Token: 0x06005106 RID: 20742 RVA: 0x0006ECE0 File Offset: 0x0006D0E0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001145 RID: 4421
		// (get) Token: 0x06005107 RID: 20743 RVA: 0x0006ECE8 File Offset: 0x0006D0E8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005108 RID: 20744 RVA: 0x0006ECF0 File Offset: 0x0006D0F0
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

		// Token: 0x06005109 RID: 20745 RVA: 0x0006ED60 File Offset: 0x0006D160
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600510A RID: 20746 RVA: 0x0006ED67 File Offset: 0x0006D167
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600510B RID: 20747 RVA: 0x0006ED70 File Offset: 0x0006D170
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator9 <DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator = new UnitCombatController.<DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator9();
			<DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator.$this = this;
			<DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator.skill = skill;
			return <DisplayActiveSkillDamageEffectOnSingalTarget>c__Iterator;
		}

		// Token: 0x04003F3A RID: 16186
		internal AdventureUnitSkill skill;

		// Token: 0x04003F3B RID: 16187
		internal string <filepath>__0;

		// Token: 0x04003F3C RID: 16188
		internal GameObject <prefab>__0;

		// Token: 0x04003F3D RID: 16189
		internal SkillEffectController <effectcontroller>__1;

		// Token: 0x04003F3E RID: 16190
		internal Transform <castpos>__2;

		// Token: 0x04003F3F RID: 16191
		internal IEnumerator $locvar0;

		// Token: 0x04003F40 RID: 16192
		internal object <_>__3;

		// Token: 0x04003F41 RID: 16193
		internal IDisposable $locvar1;

		// Token: 0x04003F42 RID: 16194
		internal UnitCombatController $this;

		// Token: 0x04003F43 RID: 16195
		internal object $current;

		// Token: 0x04003F44 RID: 16196
		internal bool $disposing;

		// Token: 0x04003F45 RID: 16197
		internal int $PC;
	}

	// Token: 0x02000BF4 RID: 3060
	[CompilerGenerated]
	private sealed class <UnitKilled>c__IteratorA : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600510C RID: 20748 RVA: 0x0006EDB0 File Offset: 0x0006D1B0
		[DebuggerHidden]
		public <UnitKilled>c__IteratorA()
		{
		}

		// Token: 0x0600510D RID: 20749 RVA: 0x0006EDB8 File Offset: 0x0006D1B8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (!(this is NewEnemyCombatController))
				{
					base.gameObject.transform.localScale = Vector3.zero;
				}
				base.BattleUnit.RemoveAllEventCallbackFromUiLayer();
				base.LeavesEncounter();
				base.StartCoroutine(GameObjectUtil.WaitToRecycle(base.gameObject));
			}
			return false;
		}

		// Token: 0x17001146 RID: 4422
		// (get) Token: 0x0600510E RID: 20750 RVA: 0x0006EE3E File Offset: 0x0006D23E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001147 RID: 4423
		// (get) Token: 0x0600510F RID: 20751 RVA: 0x0006EE46 File Offset: 0x0006D246
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005110 RID: 20752 RVA: 0x0006EE4E File Offset: 0x0006D24E
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005111 RID: 20753 RVA: 0x0006EE50 File Offset: 0x0006D250
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005112 RID: 20754 RVA: 0x0006EE57 File Offset: 0x0006D257
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005113 RID: 20755 RVA: 0x0006EE60 File Offset: 0x0006D260
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitKilled>c__IteratorA <UnitKilled>c__IteratorA = new UnitCombatController.<UnitKilled>c__IteratorA();
			<UnitKilled>c__IteratorA.$this = this;
			return <UnitKilled>c__IteratorA;
		}

		// Token: 0x04003F46 RID: 16198
		internal UnitCombatController $this;

		// Token: 0x04003F47 RID: 16199
		internal object $current;

		// Token: 0x04003F48 RID: 16200
		internal bool $disposing;

		// Token: 0x04003F49 RID: 16201
		internal int $PC;
	}

	// Token: 0x02000BF5 RID: 3061
	[CompilerGenerated]
	private sealed class <UnitTriggersDialog>c__IteratorB : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005114 RID: 20756 RVA: 0x0006EE94 File Offset: 0x0006D294
		[DebuggerHidden]
		public <UnitTriggersDialog>c__IteratorB()
		{
		}

		// Token: 0x06005115 RID: 20757 RVA: 0x0006EE9C File Offset: 0x0006D29C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (speakEvent.DialogDetails.Count > 0 && !speakEvent.DialogDetails[0].IsCriticalDialog)
				{
					BattleDialogController component = UnityEngine.Object.Instantiate<GameObject>(FilePath.GetBattleDialogPre()).GetComponent<BattleDialogController>();
					Transform transform = base.GetComponentInChildren<CombatUnitHealthController>().transform;
					component.transform.SetParent(transform, false);
					component.Init(speakEvent.DialogDetails, speakEvent.BattleUnit.IsPlayer);
				}
				else
				{
					UIController ui = TownManager.Instance.Ui;
					if (ui.IsInTown)
					{
						ui.ShowBackToBattlePanel();
					}
					ui.AdventureDialog.gameObject.SetActive(true);
					ui.AdventureDialog.Init(new List<DialogItem>
					{
						new DialogItem
						{
							Dialogs = speakEvent.DialogDetails.GetContents(),
							UnitType = speakEvent.BattleUnit.GetUnitType(),
							OnLeftSide = speakEvent.BattleUnit.IsPlayer,
							UnitObj = base.gameObject
						}
					});
				}
			}
			return false;
		}

		// Token: 0x17001148 RID: 4424
		// (get) Token: 0x06005116 RID: 20758 RVA: 0x0006EFEB File Offset: 0x0006D3EB
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001149 RID: 4425
		// (get) Token: 0x06005117 RID: 20759 RVA: 0x0006EFF3 File Offset: 0x0006D3F3
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005118 RID: 20760 RVA: 0x0006EFFB File Offset: 0x0006D3FB
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005119 RID: 20761 RVA: 0x0006EFFD File Offset: 0x0006D3FD
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600511A RID: 20762 RVA: 0x0006F004 File Offset: 0x0006D404
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600511B RID: 20763 RVA: 0x0006F00C File Offset: 0x0006D40C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitTriggersDialog>c__IteratorB <UnitTriggersDialog>c__IteratorB = new UnitCombatController.<UnitTriggersDialog>c__IteratorB();
			<UnitTriggersDialog>c__IteratorB.$this = this;
			<UnitTriggersDialog>c__IteratorB.speakEvent = speakEvent;
			return <UnitTriggersDialog>c__IteratorB;
		}

		// Token: 0x04003F4A RID: 16202
		internal BattleUnitSpeaksEvent speakEvent;

		// Token: 0x04003F4B RID: 16203
		internal UnitCombatController $this;

		// Token: 0x04003F4C RID: 16204
		internal object $current;

		// Token: 0x04003F4D RID: 16205
		internal bool $disposing;

		// Token: 0x04003F4E RID: 16206
		internal int $PC;
	}

	// Token: 0x02000BF6 RID: 3062
	[CompilerGenerated]
	private sealed class <EnemyUnitDropsLoot>c__IteratorC : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600511C RID: 20764 RVA: 0x0006F04C File Offset: 0x0006D44C
		[DebuggerHidden]
		public <EnemyUnitDropsLoot>c__IteratorC()
		{
		}

		// Token: 0x0600511D RID: 20765 RVA: 0x0006F054 File Offset: 0x0006D454
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				foreach (ResourceUpdate resource in resources)
				{
					CombatDropController combatDropController = UnityEngine.Object.Instantiate<CombatDropController>(Resources.Load<CombatDropController>("Prefabs/CombatScene/CombatDrops/Resource"));
					combatDropController.Init(resource);
					combatDropController.transform.position = base.transform.position;
					CombatManager.Instance.CombatPointsController.AddDrop(combatDropController);
				}
			}
			return false;
		}

		// Token: 0x1700114A RID: 4426
		// (get) Token: 0x0600511E RID: 20766 RVA: 0x0006F104 File Offset: 0x0006D504
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700114B RID: 4427
		// (get) Token: 0x0600511F RID: 20767 RVA: 0x0006F10C File Offset: 0x0006D50C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005120 RID: 20768 RVA: 0x0006F114 File Offset: 0x0006D514
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005121 RID: 20769 RVA: 0x0006F116 File Offset: 0x0006D516
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005122 RID: 20770 RVA: 0x0006F11D File Offset: 0x0006D51D
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005123 RID: 20771 RVA: 0x0006F128 File Offset: 0x0006D528
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<EnemyUnitDropsLoot>c__IteratorC <EnemyUnitDropsLoot>c__IteratorC = new UnitCombatController.<EnemyUnitDropsLoot>c__IteratorC();
			<EnemyUnitDropsLoot>c__IteratorC.$this = this;
			<EnemyUnitDropsLoot>c__IteratorC.resources = resources;
			return <EnemyUnitDropsLoot>c__IteratorC;
		}

		// Token: 0x04003F4F RID: 16207
		internal List<ResourceUpdate> resources;

		// Token: 0x04003F50 RID: 16208
		internal UnitCombatController $this;

		// Token: 0x04003F51 RID: 16209
		internal object $current;

		// Token: 0x04003F52 RID: 16210
		internal bool $disposing;

		// Token: 0x04003F53 RID: 16211
		internal int $PC;
	}

	// Token: 0x02000BF7 RID: 3063
	[CompilerGenerated]
	private sealed class <UnitReceivesEffect>c__IteratorD : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005124 RID: 20772 RVA: 0x0006F168 File Offset: 0x0006D568
		[DebuggerHidden]
		public <UnitReceivesEffect>c__IteratorD()
		{
		}

		// Token: 0x06005125 RID: 20773 RVA: 0x0006F170 File Offset: 0x0006D570
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (effect is FadeEffect && base.BattleUnit is AdventurerBattleUnit)
				{
					base.GetComponent<GenericAdventurer>().Transparent();
				}
				this.PopupBattleEffectsText(effect);
				base.AddEffectIcon(effect);
				if (effect != null)
				{
					SkillEffectController skillEffectController = this._currentBattleEffects.FirstOrDefault((SkillEffectController c) => c.BattleEffect.BattleEffectType == effect.BattleEffectType);
					if (skillEffectController != null)
					{
						skillEffectController.SetBattleEffect(effect);
					}
					else
					{
						UnityEngine.Object @object = Resources.Load(FilePath.GetBattleEffectsByBattleEffectType(effect.BattleEffectType));
						if (@object == null)
						{
							return false;
						}
						GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
						SkillEffectController component = gameObject.GetComponent<SkillEffectController>();
						if (component == null)
						{
							throw new Exception(gameObject + " does not contain SkillEffectController");
						}
						if (component.AudioClip != null)
						{
							base.StartCoroutine(CombatManager.Instance.PlaySecond(component.AudioClip, component.DestroyBy).GetEnumerator());
						}
						AdjustableImageEffectFx component2 = gameObject.GetComponent<AdjustableImageEffectFx>();
						if (component2 != null)
						{
							UnitCombatController controllerByBattleUnit = BattleManager.instance.Spawner.GetControllerByBattleUnit(effect.EffectSource.SourceUnit);
							if (controllerByBattleUnit is AdventurerCombatController)
							{
								GenericAdventurer componentInChildren = ((AdventurerCombatController)controllerByBattleUnit).GetComponentInChildren<GenericAdventurer>();
								if (componentInChildren != null)
								{
									component2.SetImageForSkillEffect(componentInChildren.EastMiddle.sprite);
								}
							}
							else
							{
								Sprite enemyAvatarByUnitType = FilePath.GetEnemyAvatarByUnitType(effect.EffectSource.SourceUnit.GetUnitType());
								component2.SetImageForSkillEffect(enemyAvatarByUnitType);
							}
						}
						component.SetBattleEffect(effect);
						if (effect.BattleEffectType == BattleEffectType.Taunt)
						{
							gameObject.transform.SetParent(base.HealthController.transform, false);
							gameObject.transform.localPosition = Vector3.down * 3f;
						}
						else
						{
							gameObject.transform.SetParent(parent, false);
						}
						this._currentBattleEffects.Add(component);
					}
				}
				base.UpdateHealthBar();
			}
			return false;
		}

		// Token: 0x1700114C RID: 4428
		// (get) Token: 0x06005126 RID: 20774 RVA: 0x0006F3FC File Offset: 0x0006D7FC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700114D RID: 4429
		// (get) Token: 0x06005127 RID: 20775 RVA: 0x0006F404 File Offset: 0x0006D804
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005128 RID: 20776 RVA: 0x0006F40C File Offset: 0x0006D80C
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005129 RID: 20777 RVA: 0x0006F40E File Offset: 0x0006D80E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600512A RID: 20778 RVA: 0x0006F415 File Offset: 0x0006D815
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600512B RID: 20779 RVA: 0x0006F420 File Offset: 0x0006D820
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitReceivesEffect>c__IteratorD <UnitReceivesEffect>c__IteratorD = new UnitCombatController.<UnitReceivesEffect>c__IteratorD();
			<UnitReceivesEffect>c__IteratorD.$this = this;
			<UnitReceivesEffect>c__IteratorD.effect = effect;
			<UnitReceivesEffect>c__IteratorD.parent = parent;
			return <UnitReceivesEffect>c__IteratorD;
		}

		// Token: 0x04003F54 RID: 16212
		internal BattleEffectBase effect;

		// Token: 0x04003F55 RID: 16213
		internal Transform parent;

		// Token: 0x04003F56 RID: 16214
		internal UnitCombatController $this;

		// Token: 0x04003F57 RID: 16215
		internal object $current;

		// Token: 0x04003F58 RID: 16216
		internal bool $disposing;

		// Token: 0x04003F59 RID: 16217
		internal int $PC;

		// Token: 0x02000C00 RID: 3072
		private sealed class <UnitReceivesEffect>c__AnonStorey16
		{
			// Token: 0x06005168 RID: 20840 RVA: 0x0006F46C File Offset: 0x0006D86C
			public <UnitReceivesEffect>c__AnonStorey16()
			{
			}

			// Token: 0x06005169 RID: 20841 RVA: 0x0006F474 File Offset: 0x0006D874
			internal bool <>m__0(SkillEffectController c)
			{
				return c.BattleEffect.BattleEffectType == this.effect.BattleEffectType;
			}

			// Token: 0x04003F84 RID: 16260
			internal BattleEffectBase effect;

			// Token: 0x04003F85 RID: 16261
			internal UnitCombatController.<UnitReceivesEffect>c__IteratorD <>f__ref$13;
		}
	}

	// Token: 0x02000BF8 RID: 3064
	[CompilerGenerated]
	private sealed class <UnitLoosesEffect>c__IteratorE : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600512C RID: 20780 RVA: 0x0006F48E File Offset: 0x0006D88E
		[DebuggerHidden]
		public <UnitLoosesEffect>c__IteratorE()
		{
		}

		// Token: 0x0600512D RID: 20781 RVA: 0x0006F498 File Offset: 0x0006D898
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (obj is FadeEffect && base.BattleUnit is AdventurerBattleUnit)
				{
					base.GetComponent<GenericAdventurer>().ResetColor();
				}
				if (base.BattleUnit.Status != BattleUnitStatus.Dead)
				{
					BattleEffectBase effect = obj as BattleEffectBase;
					if (effect == null)
					{
						throw new Exception(obj + " is not a BattleEffectBase");
					}
					base.RemoveEffectIcon(effect);
					SkillEffectController skillEffectController = this._currentBattleEffects.FirstOrDefault((SkillEffectController c) => c.BattleEffect == effect);
					if (skillEffectController != null)
					{
						UnityEngine.Object.Destroy(skillEffectController.gameObject);
						this._currentBattleEffects.Remove(skillEffectController);
					}
				}
			}
			return false;
		}

		// Token: 0x1700114E RID: 4430
		// (get) Token: 0x0600512E RID: 20782 RVA: 0x0006F59E File Offset: 0x0006D99E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700114F RID: 4431
		// (get) Token: 0x0600512F RID: 20783 RVA: 0x0006F5A6 File Offset: 0x0006D9A6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005130 RID: 20784 RVA: 0x0006F5AE File Offset: 0x0006D9AE
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005131 RID: 20785 RVA: 0x0006F5B0 File Offset: 0x0006D9B0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005132 RID: 20786 RVA: 0x0006F5B7 File Offset: 0x0006D9B7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005133 RID: 20787 RVA: 0x0006F5C0 File Offset: 0x0006D9C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<UnitLoosesEffect>c__IteratorE <UnitLoosesEffect>c__IteratorE = new UnitCombatController.<UnitLoosesEffect>c__IteratorE();
			<UnitLoosesEffect>c__IteratorE.$this = this;
			<UnitLoosesEffect>c__IteratorE.obj = obj;
			return <UnitLoosesEffect>c__IteratorE;
		}

		// Token: 0x04003F5A RID: 16218
		internal object obj;

		// Token: 0x04003F5B RID: 16219
		internal UnitCombatController $this;

		// Token: 0x04003F5C RID: 16220
		internal object $current;

		// Token: 0x04003F5D RID: 16221
		internal bool $disposing;

		// Token: 0x04003F5E RID: 16222
		internal int $PC;

		// Token: 0x02000C01 RID: 3073
		private sealed class <UnitLoosesEffect>c__AnonStorey17
		{
			// Token: 0x0600516A RID: 20842 RVA: 0x0006F600 File Offset: 0x0006DA00
			public <UnitLoosesEffect>c__AnonStorey17()
			{
			}

			// Token: 0x0600516B RID: 20843 RVA: 0x0006F608 File Offset: 0x0006DA08
			internal bool <>m__0(SkillEffectController c)
			{
				return c.BattleEffect == this.effect;
			}

			// Token: 0x04003F86 RID: 16262
			internal BattleEffectBase effect;

			// Token: 0x04003F87 RID: 16263
			internal UnitCombatController.<UnitLoosesEffect>c__IteratorE <>f__ref$14;
		}
	}

	// Token: 0x02000BF9 RID: 3065
	[CompilerGenerated]
	private sealed class <PassiveEffectBecomeActive>c__IteratorF : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005134 RID: 20788 RVA: 0x0006F618 File Offset: 0x0006DA18
		[DebuggerHidden]
		public <PassiveEffectBecomeActive>c__IteratorF()
		{
		}

		// Token: 0x06005135 RID: 20789 RVA: 0x0006F620 File Offset: 0x0006DA20
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (!(unit.GetId() != base.BattleUnit.GetId()))
				{
					AdventureUnitSkill skill = obj as AdventureUnitSkill;
					if (skill != null)
					{
						PassiveEffectController x = this._currentPassiveEffectObjs.FirstOrDefault((PassiveEffectController c) => c.AdventureUnitSkill == skill);
						if (x == null)
						{
							GameObject gameObject = Resources.Load(FilePath.GetBattlePassiveEffectPathAndBattleEffectOn(skill.Skill, unit.GetOutputAttributeType() == AttributeType.Intelligience)) as GameObject;
							if (gameObject != null)
							{
								GameObject gameObject2 = GameObjectUtil.Instantiate(gameObject, base.gameObject.transform.position, base.gameObject);
								gameObject2.transform.SetParent(base.gameObject.transform);
								gameObject2.transform.localScale = Vector3.one;
								PassiveEffectController component = gameObject2.GetComponent<PassiveEffectController>();
								component.AdventureUnitSkill = skill;
								this._currentPassiveEffectObjs.Add(component);
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x17001150 RID: 4432
		// (get) Token: 0x06005136 RID: 20790 RVA: 0x0006F76A File Offset: 0x0006DB6A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001151 RID: 4433
		// (get) Token: 0x06005137 RID: 20791 RVA: 0x0006F772 File Offset: 0x0006DB72
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005138 RID: 20792 RVA: 0x0006F77A File Offset: 0x0006DB7A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005139 RID: 20793 RVA: 0x0006F77C File Offset: 0x0006DB7C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600513A RID: 20794 RVA: 0x0006F783 File Offset: 0x0006DB83
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600513B RID: 20795 RVA: 0x0006F78C File Offset: 0x0006DB8C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<PassiveEffectBecomeActive>c__IteratorF <PassiveEffectBecomeActive>c__IteratorF = new UnitCombatController.<PassiveEffectBecomeActive>c__IteratorF();
			<PassiveEffectBecomeActive>c__IteratorF.$this = this;
			<PassiveEffectBecomeActive>c__IteratorF.unit = unit;
			<PassiveEffectBecomeActive>c__IteratorF.obj = obj;
			return <PassiveEffectBecomeActive>c__IteratorF;
		}

		// Token: 0x04003F5F RID: 16223
		internal IBattleUnit unit;

		// Token: 0x04003F60 RID: 16224
		internal object obj;

		// Token: 0x04003F61 RID: 16225
		internal UnitCombatController $this;

		// Token: 0x04003F62 RID: 16226
		internal object $current;

		// Token: 0x04003F63 RID: 16227
		internal bool $disposing;

		// Token: 0x04003F64 RID: 16228
		internal int $PC;

		// Token: 0x02000C02 RID: 3074
		private sealed class <PassiveEffectBecomeActive>c__AnonStorey18
		{
			// Token: 0x0600516C RID: 20844 RVA: 0x0006F7D8 File Offset: 0x0006DBD8
			public <PassiveEffectBecomeActive>c__AnonStorey18()
			{
			}

			// Token: 0x0600516D RID: 20845 RVA: 0x0006F7E0 File Offset: 0x0006DBE0
			internal bool <>m__0(PassiveEffectController c)
			{
				return c.AdventureUnitSkill == this.skill;
			}

			// Token: 0x04003F88 RID: 16264
			internal AdventureUnitSkill skill;

			// Token: 0x04003F89 RID: 16265
			internal UnitCombatController.<PassiveEffectBecomeActive>c__IteratorF <>f__ref$15;
		}
	}

	// Token: 0x02000BFA RID: 3066
	[CompilerGenerated]
	private sealed class <DamageNeutralized>c__Iterator10 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600513C RID: 20796 RVA: 0x0006F7F0 File Offset: 0x0006DBF0
		[DebuggerHidden]
		public <DamageNeutralized>c__Iterator10()
		{
		}

		// Token: 0x0600513D RID: 20797 RVA: 0x0006F7F8 File Offset: 0x0006DBF8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(FilePath.GetDamageNeutralizedEffectIndication())) as GameObject;
				if (!(gameObject == null))
				{
					gameObject.transform.SetParent(base.gameObject.transform, false);
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localScale = Vector3.one;
				}
			}
			return false;
		}

		// Token: 0x17001152 RID: 4434
		// (get) Token: 0x0600513E RID: 20798 RVA: 0x0006F87A File Offset: 0x0006DC7A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001153 RID: 4435
		// (get) Token: 0x0600513F RID: 20799 RVA: 0x0006F882 File Offset: 0x0006DC82
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005140 RID: 20800 RVA: 0x0006F88A File Offset: 0x0006DC8A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005141 RID: 20801 RVA: 0x0006F88C File Offset: 0x0006DC8C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005142 RID: 20802 RVA: 0x0006F893 File Offset: 0x0006DC93
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005143 RID: 20803 RVA: 0x0006F89C File Offset: 0x0006DC9C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<DamageNeutralized>c__Iterator10 <DamageNeutralized>c__Iterator = new UnitCombatController.<DamageNeutralized>c__Iterator10();
			<DamageNeutralized>c__Iterator.$this = this;
			return <DamageNeutralized>c__Iterator;
		}

		// Token: 0x04003F65 RID: 16229
		internal UnitCombatController $this;

		// Token: 0x04003F66 RID: 16230
		internal object $current;

		// Token: 0x04003F67 RID: 16231
		internal bool $disposing;

		// Token: 0x04003F68 RID: 16232
		internal int $PC;
	}

	// Token: 0x02000BFB RID: 3067
	[CompilerGenerated]
	private sealed class <InversedKillPerformed>c__Iterator11 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005144 RID: 20804 RVA: 0x0006F8D0 File Offset: 0x0006DCD0
		[DebuggerHidden]
		public <InversedKillPerformed>c__Iterator11()
		{
		}

		// Token: 0x06005145 RID: 20805 RVA: 0x0006F8D8 File Offset: 0x0006DCD8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				skillObj = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Skill Effects/BossSkills/DeathSkill/DeathSkill") as GameObject);
				if (!(skillObj != null))
				{
					throw new Exception("DeathSkill not found");
				}
				unit = BattleManager.instance.Spawner.GetControllerByBattleUnit(target);
				if (!(unit == null))
				{
					unit.CreateEeffect(skillObj, false);
					this.$current = new WaitForSeconds(3f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001154 RID: 4436
		// (get) Token: 0x06005146 RID: 20806 RVA: 0x0006F9B3 File Offset: 0x0006DDB3
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001155 RID: 4437
		// (get) Token: 0x06005147 RID: 20807 RVA: 0x0006F9BB File Offset: 0x0006DDBB
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005148 RID: 20808 RVA: 0x0006F9C3 File Offset: 0x0006DDC3
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005149 RID: 20809 RVA: 0x0006F9D3 File Offset: 0x0006DDD3
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600514A RID: 20810 RVA: 0x0006F9DA File Offset: 0x0006DDDA
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600514B RID: 20811 RVA: 0x0006F9E4 File Offset: 0x0006DDE4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<InversedKillPerformed>c__Iterator11 <InversedKillPerformed>c__Iterator = new UnitCombatController.<InversedKillPerformed>c__Iterator11();
			<InversedKillPerformed>c__Iterator.target = target;
			return <InversedKillPerformed>c__Iterator;
		}

		// Token: 0x04003F69 RID: 16233
		internal GameObject <skillObj>__0;

		// Token: 0x04003F6A RID: 16234
		internal IBattleUnit target;

		// Token: 0x04003F6B RID: 16235
		internal UnitCombatController <unit>__1;

		// Token: 0x04003F6C RID: 16236
		internal object $current;

		// Token: 0x04003F6D RID: 16237
		internal bool $disposing;

		// Token: 0x04003F6E RID: 16238
		internal int $PC;
	}

	// Token: 0x02000BFC RID: 3068
	[CompilerGenerated]
	private sealed class <PassiveSkillFades>c__Iterator12 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600514C RID: 20812 RVA: 0x0006FA18 File Offset: 0x0006DE18
		[DebuggerHidden]
		public <PassiveSkillFades>c__Iterator12()
		{
		}

		// Token: 0x0600514D RID: 20813 RVA: 0x0006FA20 File Offset: 0x0006DE20
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (!(unit.GetId() != base.BattleUnit.GetId()))
				{
					AdventureUnitSkill skill = obj as AdventureUnitSkill;
					PassiveEffectController passiveEffectController = this._currentPassiveEffectObjs.FirstOrDefault((PassiveEffectController c) => c.AdventureUnitSkill == skill);
					if (passiveEffectController != null)
					{
						this._currentPassiveEffectObjs.Remove(passiveEffectController);
						UnityEngine.Object.Destroy(passiveEffectController.gameObject);
					}
				}
			}
			return false;
		}

		// Token: 0x17001156 RID: 4438
		// (get) Token: 0x0600514E RID: 20814 RVA: 0x0006FACE File Offset: 0x0006DECE
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001157 RID: 4439
		// (get) Token: 0x0600514F RID: 20815 RVA: 0x0006FAD6 File Offset: 0x0006DED6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005150 RID: 20816 RVA: 0x0006FADE File Offset: 0x0006DEDE
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005151 RID: 20817 RVA: 0x0006FAE0 File Offset: 0x0006DEE0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005152 RID: 20818 RVA: 0x0006FAE7 File Offset: 0x0006DEE7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005153 RID: 20819 RVA: 0x0006FAF0 File Offset: 0x0006DEF0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<PassiveSkillFades>c__Iterator12 <PassiveSkillFades>c__Iterator = new UnitCombatController.<PassiveSkillFades>c__Iterator12();
			<PassiveSkillFades>c__Iterator.$this = this;
			<PassiveSkillFades>c__Iterator.unit = unit;
			<PassiveSkillFades>c__Iterator.obj = obj;
			return <PassiveSkillFades>c__Iterator;
		}

		// Token: 0x04003F6F RID: 16239
		internal IBattleUnit unit;

		// Token: 0x04003F70 RID: 16240
		internal object obj;

		// Token: 0x04003F71 RID: 16241
		internal UnitCombatController $this;

		// Token: 0x04003F72 RID: 16242
		internal object $current;

		// Token: 0x04003F73 RID: 16243
		internal bool $disposing;

		// Token: 0x04003F74 RID: 16244
		internal int $PC;

		// Token: 0x02000C03 RID: 3075
		private sealed class <PassiveSkillFades>c__AnonStorey19
		{
			// Token: 0x0600516E RID: 20846 RVA: 0x0006FB3C File Offset: 0x0006DF3C
			public <PassiveSkillFades>c__AnonStorey19()
			{
			}

			// Token: 0x0600516F RID: 20847 RVA: 0x0006FB44 File Offset: 0x0006DF44
			internal bool <>m__0(PassiveEffectController c)
			{
				return c.AdventureUnitSkill == this.skill;
			}

			// Token: 0x04003F8A RID: 16266
			internal AdventureUnitSkill skill;

			// Token: 0x04003F8B RID: 16267
			internal UnitCombatController.<PassiveSkillFades>c__Iterator12 <>f__ref$18;
		}
	}

	// Token: 0x02000BFD RID: 3069
	[CompilerGenerated]
	private sealed class <MoveForward>c__Iterator13 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005154 RID: 20820 RVA: 0x0006FB54 File Offset: 0x0006DF54
		[DebuggerHidden]
		public <MoveForward>c__Iterator13()
		{
		}

		// Token: 0x06005155 RID: 20821 RVA: 0x0006FB5C File Offset: 0x0006DF5C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this._isMovingForward = true;
				this.$current = new WaitForSeconds(0.2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001158 RID: 4440
		// (get) Token: 0x06005156 RID: 20822 RVA: 0x0006FBC4 File Offset: 0x0006DFC4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001159 RID: 4441
		// (get) Token: 0x06005157 RID: 20823 RVA: 0x0006FBCC File Offset: 0x0006DFCC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005158 RID: 20824 RVA: 0x0006FBD4 File Offset: 0x0006DFD4
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005159 RID: 20825 RVA: 0x0006FBE4 File Offset: 0x0006DFE4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F75 RID: 16245
		internal UnitCombatController $this;

		// Token: 0x04003F76 RID: 16246
		internal object $current;

		// Token: 0x04003F77 RID: 16247
		internal bool $disposing;

		// Token: 0x04003F78 RID: 16248
		internal int $PC;
	}

	// Token: 0x02000BFE RID: 3070
	[CompilerGenerated]
	private sealed class <MoveBack>c__Iterator14 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600515A RID: 20826 RVA: 0x0006FBEB File Offset: 0x0006DFEB
		[DebuggerHidden]
		public <MoveBack>c__Iterator14()
		{
		}

		// Token: 0x0600515B RID: 20827 RVA: 0x0006FBF4 File Offset: 0x0006DFF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this._isMovingBack = true;
				this.$current = new WaitForSeconds(0.2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700115A RID: 4442
		// (get) Token: 0x0600515C RID: 20828 RVA: 0x0006FC5C File Offset: 0x0006E05C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700115B RID: 4443
		// (get) Token: 0x0600515D RID: 20829 RVA: 0x0006FC64 File Offset: 0x0006E064
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600515E RID: 20830 RVA: 0x0006FC6C File Offset: 0x0006E06C
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600515F RID: 20831 RVA: 0x0006FC7C File Offset: 0x0006E07C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003F79 RID: 16249
		internal UnitCombatController $this;

		// Token: 0x04003F7A RID: 16250
		internal object $current;

		// Token: 0x04003F7B RID: 16251
		internal bool $disposing;

		// Token: 0x04003F7C RID: 16252
		internal int $PC;
	}

	// Token: 0x02000BFF RID: 3071
	[CompilerGenerated]
	private sealed class <EscapeFromBattle>c__Iterator15 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005160 RID: 20832 RVA: 0x0006FC83 File Offset: 0x0006E083
		[DebuggerHidden]
		public <EscapeFromBattle>c__Iterator15()
		{
		}

		// Token: 0x06005161 RID: 20833 RVA: 0x0006FC8C File Offset: 0x0006E08C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				if (base.CameFrom != null)
				{
					base.gameObject.transform.localScale = new Vector3(-base.gameObject.transform.localScale.x, base.gameObject.transform.localScale.y, base.gameObject.transform.localScale.z);
					this.$current = new WaitForSeconds(0.5f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				goto IL_17C;
			case 1u:
				currentPos = base.transform.position;
				targetPos = base.CameFrom.transform.position;
				t = 0f;
				break;
			case 2u:
				break;
			default:
				return false;
			}
			if (t < 1f)
			{
				t += Time.deltaTime / 1f;
				base.transform.position = Vector3.Lerp(currentPos, targetPos, t);
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			}
			IL_17C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700115C RID: 4444
		// (get) Token: 0x06005162 RID: 20834 RVA: 0x0006FE1F File Offset: 0x0006E21F
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700115D RID: 4445
		// (get) Token: 0x06005163 RID: 20835 RVA: 0x0006FE27 File Offset: 0x0006E227
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005164 RID: 20836 RVA: 0x0006FE2F File Offset: 0x0006E22F
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005165 RID: 20837 RVA: 0x0006FE3F File Offset: 0x0006E23F
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005166 RID: 20838 RVA: 0x0006FE46 File Offset: 0x0006E246
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005167 RID: 20839 RVA: 0x0006FE50 File Offset: 0x0006E250
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitCombatController.<EscapeFromBattle>c__Iterator15 <EscapeFromBattle>c__Iterator = new UnitCombatController.<EscapeFromBattle>c__Iterator15();
			<EscapeFromBattle>c__Iterator.$this = this;
			return <EscapeFromBattle>c__Iterator;
		}

		// Token: 0x04003F7D RID: 16253
		internal Vector3 <currentPos>__1;

		// Token: 0x04003F7E RID: 16254
		internal Vector3 <targetPos>__1;

		// Token: 0x04003F7F RID: 16255
		internal float <t>__1;

		// Token: 0x04003F80 RID: 16256
		internal UnitCombatController $this;

		// Token: 0x04003F81 RID: 16257
		internal object $current;

		// Token: 0x04003F82 RID: 16258
		internal bool $disposing;

		// Token: 0x04003F83 RID: 16259
		internal int $PC;
	}
}
