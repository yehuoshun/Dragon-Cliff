using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000379 RID: 889
public class Spawner : MonoBehaviour, IWalkingBattleUnit
{
	// Token: 0x060017CC RID: 6092 RVA: 0x000B774C File Offset: 0x000B5B4C
	public Spawner()
	{
	}

	// Token: 0x060017CD RID: 6093 RVA: 0x000B77AC File Offset: 0x000B5BAC
	public List<AdventurerCombatController> GetCurrentAdventurers()
	{
		return (from a in this._adventurerCombatControllers
		where a != null
		select a).ToList<AdventurerCombatController>();
	}

	// Token: 0x060017CE RID: 6094 RVA: 0x000B77DB File Offset: 0x000B5BDB
	public List<EnemyCombatController> GetCurrentEnemeys()
	{
		return (from a in this._enemyCombatControllers
		where a != null
		select a).ToList<EnemyCombatController>();
	}

	// Token: 0x060017CF RID: 6095 RVA: 0x000B780C File Offset: 0x000B5C0C
	public float GetEncounterGapTime()
	{
		float num = Math.Abs(this.InitPointTran.position.x - this.BattlePointTran.position.x);
		float backgroundMovingSpeed = this.Background.GetBackgroundMovingSpeed();
		return num / backgroundMovingSpeed;
	}

	// Token: 0x060017D0 RID: 6096 RVA: 0x000B7858 File Offset: 0x000B5C58
	public UnitCombatController GetControllerByBattleUnit(IBattleUnit selected)
	{
		AdventurerCombatController adventurerCombatController = this.GetCurrentAdventurers().FirstOrDefault((AdventurerCombatController a) => a.BattleUnit == selected);
		if (adventurerCombatController != null)
		{
			return adventurerCombatController;
		}
		EnemyCombatController enemyCombatController = this.GetCurrentEnemeys().FirstOrDefault((EnemyCombatController e) => e.BattleUnit == selected);
		if (enemyCombatController != null)
		{
			return enemyCombatController;
		}
		return null;
	}

	// Token: 0x060017D1 RID: 6097 RVA: 0x000B78C0 File Offset: 0x000B5CC0
	public void SetAdventure(Adventure adventure, AdventureType adventureType)
	{
		this.SetupAdventurers(adventure);
		List<GameObject> predefinedLayoutsByBattleLevel = FilePath.GetPredefinedLayoutsByBattleLevel(adventure);
		this.PreDefinedLayouts = predefinedLayoutsByBattleLevel;
		this.Background.Init(adventureType);
	}

	// Token: 0x060017D2 RID: 6098 RVA: 0x000B78F0 File Offset: 0x000B5CF0
	public void HighLightSelection(List<IBattleUnit> units, bool isFriendlystrategy)
	{
		this.GetCurrentEnemeys().ForEach(delegate(EnemyCombatController e)
		{
			e.HighlightCorresponseUnit(units);
		});
		foreach (AdventurerCombatController adventurerCombatController in this.GetCurrentAdventurers())
		{
			adventurerCombatController.HighlightCorresponseUnit(units);
		}
	}

	// Token: 0x060017D3 RID: 6099 RVA: 0x000B7978 File Offset: 0x000B5D78
	public void ActiveSkillCasted()
	{
		this.GetCurrentEnemeys().ForEach(delegate(EnemyCombatController e)
		{
			e.ActiveSkillReleased();
		});
		foreach (AdventurerCombatController adventurerCombatController in this.GetCurrentAdventurers())
		{
			adventurerCombatController.ActiveSkillReleased();
		}
	}

	// Token: 0x060017D4 RID: 6100 RVA: 0x000B79FC File Offset: 0x000B5DFC
	public IEnumerable EntersEncounterAndSetsUpListeners(IEncounter encounter, List<AdventurerBattleUnit> adventurerBattleUnits)
	{
		foreach (AdventurerCombatController adventurerCombatController in this.GetCurrentAdventurers())
		{
			foreach (IBattleUnit battleUnit in from e in encounter.PlayerUnits
			where e.Status != BattleUnitStatus.Dead
			select e)
			{
				if (adventurerCombatController.Adventurer.AdventurerId == battleUnit.GetId())
				{
					adventurerCombatController.Init(battleUnit, CombatManager.Instance.CombatPointsController.AttackPoint.transform.position, false);
				}
			}
		}
		List<EnemyCombatController> currentEnemeys = this.GetCurrentEnemeys();
		using (List<IBattleUnit>.Enumerator enumerator3 = encounter.EnemyUnits.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				IBattleUnit encounterEnemyUnit = enumerator3.Current;
				EnemyCombatController enemyCombatController = currentEnemeys.FirstOrDefault((EnemyCombatController e) => e.BattleUnit.GetId() == encounterEnemyUnit.GetId());
				if (enemyCombatController != null && enemyCombatController.BattleUnit.GetId() == encounterEnemyUnit.GetId())
				{
					enemyCombatController.Init(encounterEnemyUnit, CombatManager.Instance.CombatPointsController.AttackPoint.transform.position, false);
				}
			}
		}
		foreach (InstantVelocity instantVelocity in this._currentInitedEnemy)
		{
			instantVelocity.EncountersPlayer();
		}
		List<EnemyCombatController> source = this.GetCurrentEnemeys();
		EnemyCombatController enemyCombatController2 = source.FirstOrDefault((EnemyCombatController e) => e.BattleUnit.IsBoss());
		source = (from e in source
		where !e.BattleUnit.IsBoss()
		select e).ToList<EnemyCombatController>();
		CombatManager.Instance.CombatPointsController.Init((from a in this._adventurerCombatControllers
		select (!(a != null)) ? null : a.gameObject).ToList<GameObject>(), (from e in source
		select e.gameObject).ToList<GameObject>(), (!(enemyCombatController2 != null)) ? null : enemyCombatController2.gameObject);
		yield break;
	}

	// Token: 0x060017D5 RID: 6101 RVA: 0x000B7A28 File Offset: 0x000B5E28
	private void SetupAdventurers(Adventure adventure)
	{
		List<GameObject> list = new List<GameObject>();
		List<GameObject> list2 = new List<GameObject>();
		if (adventure.Adventurers.Count == 1)
		{
			list.Add(this.PlayerInitPoint[1]);
			list2.Add(this.PlayerBattlePoints[1]);
		}
		else if (adventure.Adventurers.Count == 2)
		{
			list.Add(this.PlayerInitPoint[0]);
			list.Add(this.PlayerInitPoint[2]);
			list2.Add(this.PlayerBattlePoints[0]);
			list2.Add(this.PlayerBattlePoints[2]);
		}
		else if (adventure.Adventurers.Count == 3)
		{
			list.Add(this.PlayerInitPoint[0]);
			list.Add(this.PlayerInitPoint[1]);
			list.Add(this.PlayerInitPoint[2]);
			list2.Add(this.PlayerBattlePoints[0]);
			list2.Add(this.PlayerBattlePoints[1]);
			list2.Add(this.PlayerBattlePoints[2]);
		}
		else if (adventure.Adventurers.Count == 4)
		{
			list.Add(this.PlayerInitPoint[0]);
			list.Add(this.PlayerInitPoint[1]);
			list.Add(this.PlayerInitPoint[2]);
			list.Add(this.PlayerInitPoint[3]);
			list2.Add(this.PlayerBattlePoints[0]);
			list2.Add(this.PlayerBattlePoints[1]);
			list2.Add(this.PlayerBattlePoints[2]);
			list2.Add(this.PlayerBattlePoints[3]);
		}
		else
		{
			list.Add(this.PlayerInitPoint[0]);
			list.Add(this.PlayerInitPoint[1]);
			list.Add(this.PlayerInitPoint[2]);
			list.Add(this.PlayerInitPoint[3]);
			list.Add(this.PlayerInitPoint[4]);
			list2.Add(this.PlayerBattlePoints[0]);
			list2.Add(this.PlayerBattlePoints[1]);
			list2.Add(this.PlayerBattlePoints[2]);
			list2.Add(this.PlayerBattlePoints[3]);
			list2.Add(this.PlayerBattlePoints[4]);
		}
		for (int i = 0; i < adventure.Adventurers.Count; i++)
		{
			AdventurerBattleUnit adventurerBattleUnit = adventure.Adventurers[i];
			GameObject prefab = Resources.Load(FilePath.GetCombatUnit(adventurerBattleUnit.GetUnitType())) as GameObject;
			GameObject gameObject = GameObjectUtil.Instantiate(prefab, list[i].transform.position, this.PlayerGroup);
			gameObject.gameObject.transform.localScale = Vector3.one;
			gameObject.transform.SetParent(this.PlayerGroup.transform);
			GenericAdventurer componentInChildren = gameObject.GetComponentInChildren<GenericAdventurer>();
			componentInChildren.Init(adventurerBattleUnit.AdventurerProfile);
			AdventruerInBattle component = gameObject.GetComponent<AdventruerInBattle>();
			component.BattleUnit = adventurerBattleUnit;
			component.SetSpawner(this);
			component.SetWalkTo(list2[i]);
			this._adventruerInBattles.Add(component);
			AdventurerCombatController component2 = gameObject.GetComponent<AdventurerCombatController>();
			component2.Adventurer = adventurerBattleUnit;
			this._adventurerCombatControllers.Add(component2);
			component2.CameFrom = list2[i];
		}
	}

	// Token: 0x060017D6 RID: 6102 RVA: 0x000B7D40 File Offset: 0x000B6140
	public void MoveChests()
	{
		foreach (ChestLayout chestLayout in this._chests)
		{
			chestLayout.GetComponent<InstantVelocity>().ContinueMoving();
		}
	}

	// Token: 0x060017D7 RID: 6103 RVA: 0x000B7DA0 File Offset: 0x000B61A0
	public void InitEnemy(IEncounter encounter)
	{
		if (encounter == null)
		{
			UnityEngine.Debug.LogError("Encounter null");
		}
		if (encounter.EnemyUnits == null)
		{
			UnityEngine.Debug.LogError("Encounter enemies bnull");
		}
		List<IBattleUnit> list = (from e in encounter.EnemyUnits
		where !e.IsBoss()
		select e).ToList<IBattleUnit>();
		IBattleUnit battleUnit = encounter.EnemyUnits.FirstOrDefault((IBattleUnit e) => e.IsBoss());
		if (battleUnit != null)
		{
			GameObject gameObject = this.PrepareEnemyUnits(battleUnit);
			gameObject.transform.position = this.BossInitPoint.transform.position;
		}
		List<GameObject> list2 = new List<GameObject>();
		foreach (IBattleUnit unit in list)
		{
			list2.Add(this.PrepareEnemyUnits(unit));
		}
		this.PositEnemyUnits(list2);
	}

	// Token: 0x060017D8 RID: 6104 RVA: 0x000B7EB4 File Offset: 0x000B62B4
	private GameObject PrepareEnemyUnits(IBattleUnit unit)
	{
		GameObject gameObject = Resources.Load(FilePath.GetCombatUnit(unit.GetUnitType())) as GameObject;
		if (gameObject == null)
		{
			throw new Exception(unit.GetUnitType() + " has no prefab");
		}
		GameObject gameObject2 = GameObjectUtil.Instantiate(gameObject, Vector3.zero, this.EnemyGroup);
		gameObject2.transform.SetParent(this.EnemyGroup.transform, false);
		gameObject2.transform.localScale = Vector3.one;
		InstantVelocity component = gameObject2.GetComponent<InstantVelocity>();
		if (component == null)
		{
			throw new Exception(unit.GetUnitType() + " has no instanct velocity");
		}
		component.SetSpeed(this.Background.GetBackgroundMovingSpeed());
		component.StopMoving();
		this._currentInitedEnemy.Add(component);
		EnemyCombatController enemyCombatController = gameObject2.GetComponent<NewEnemyCombatController>() ?? gameObject2.GetComponent<EnemyCombatController>();
		enemyCombatController.FirstInit(unit);
		enemyCombatController.IsBoxColliderEnabled = true;
		this._enemyCombatControllers.Add(enemyCombatController);
		return gameObject2;
	}

	// Token: 0x060017D9 RID: 6105 RVA: 0x000B7FB8 File Offset: 0x000B63B8
	public IEnumerable WaitingForOpenChest(float chestGapTime)
	{
		yield return new WaitForSeconds(chestGapTime);
		this.StopMoving();
		foreach (ChestLayout chestLayout in this._chests)
		{
			chestLayout.isBoxColliderEnabled = true;
		}
		AutoAdventureController.Instance.WaitToOpenChest();
		yield break;
	}

	// Token: 0x060017DA RID: 6106 RVA: 0x000B7FE4 File Offset: 0x000B63E4
	public void SetClickedChest(Chest OpenedChest)
	{
		foreach (ChestLayout chestLayout in this._chests)
		{
			if (chestLayout.GetChest() != OpenedChest)
			{
				chestLayout.isBoxColliderEnabled = false;
			}
		}
	}

	// Token: 0x060017DB RID: 6107 RVA: 0x000B804C File Offset: 0x000B644C
	public void AutoSelectChest()
	{
		if (this._chests != null && this._chests.Count > 0)
		{
			this._chests[UnityEngine.Random.Range(0, 5)].SelectChest();
		}
	}

	// Token: 0x060017DC RID: 6108 RVA: 0x000B8084 File Offset: 0x000B6484
	public IEnumerable InitRewardsChest(List<Chest> chests, float chestGapTime)
	{
		if (chests == null || chests.Count == 0)
		{
			yield break;
		}
		yield return new WaitForSeconds(chestGapTime);
		for (int i = 0; i < chests.Count; i++)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(this.PreDefinedLayouts[0], this.EnemyInitPoint[i + 1].transform.position, null);
			InstantVelocity component = gameObject.GetComponent<InstantVelocity>();
			component.SetSpeed(this.Background.GetBackgroundMovingSpeed());
			ChestLayout component2 = component.GetComponent<ChestLayout>();
			if (component2 != null)
			{
				component2.SetChest(chests[i], this);
				this._chests.Add(component2);
			}
		}
		foreach (ChestLayout chestLayout in this._chests)
		{
			chestLayout.GetComponent<InstantVelocity>().ContinueMoving();
		}
		yield break;
	}

	// Token: 0x060017DD RID: 6109 RVA: 0x000B80B8 File Offset: 0x000B64B8
	public IEnumerable OpenAllChests()
	{
		yield return new WaitForSeconds(2f);
		List<ChestLayout> rest = (from c in this._chests
		where !c.GetChest().IsSelected
		select c).ToList<ChestLayout>();
		rest.ForEach(delegate(ChestLayout r)
		{
			r.ShowReward();
		});
		yield return new WaitForSeconds(3f);
		yield break;
	}

	// Token: 0x060017DE RID: 6110 RVA: 0x000B80DC File Offset: 0x000B64DC
	public void DefeatedEncounter(IEncounter encounter, Adventure CurrentAdventure)
	{
		(from c in this._currentInitedEnemy
		where c != null && c.gameObject != null
		select c).ToList<InstantVelocity>().ForEach(delegate(InstantVelocity e)
		{
			GameObjectUtil.RecycleDestroy(e.gameObject);
		});
		this._currentInitedEnemy.Clear();
		this.GetCurrentEnemeys().ToList<EnemyCombatController>().ForEach(delegate(EnemyCombatController e)
		{
			GameObjectUtil.RecycleDestroy(e.gameObject);
		});
		this._enemyCombatControllers.Clear();
		this.GetCurrentAdventurers().ForEach(delegate(AdventurerCombatController a)
		{
			a.LeavesEncounter();
		});
	}

	// Token: 0x060017DF RID: 6111 RVA: 0x000B81A4 File Offset: 0x000B65A4
	public void AllUnitsLeaveEncounter()
	{
		this.GetCurrentAdventurers().ForEach(delegate(AdventurerCombatController a)
		{
			a.LeavesEncounter();
		});
		this.GetCurrentEnemeys().ForEach(delegate(EnemyCombatController e)
		{
			e.LeavesEncounter();
		});
	}

	// Token: 0x060017E0 RID: 6112 RVA: 0x000B8204 File Offset: 0x000B6604
	public void StopMoving()
	{
		this.Background.StopMoving();
		(from a in this._adventruerInBattles
		where a != null
		select a).ToList<AdventruerInBattle>().ForEach(delegate(AdventruerInBattle a)
		{
			a.Encountered();
		});
		(from a in this._currentInitedEnemy
		where a != null
		select a).ToList<InstantVelocity>().ForEach(delegate(InstantVelocity e)
		{
			e.StopMoving();
		});
		(from a in this._chests
		where a != null
		select a).ToList<ChestLayout>().ForEach(delegate(ChestLayout c)
		{
			c.GetComponent<InstantVelocity>().StopMoving();
		});
	}

	// Token: 0x060017E1 RID: 6113 RVA: 0x000B830C File Offset: 0x000B670C
	public void ContinueMoving()
	{
		this.Background.ContinueMoving();
		(from a in this._currentInitedEnemy
		where a != null
		select a).ToList<InstantVelocity>().ForEach(delegate(InstantVelocity c)
		{
			c.ContinueMoving();
		});
		(from a in this._adventruerInBattles
		where a != null
		select a).ToList<AdventruerInBattle>().ForEach(delegate(AdventruerInBattle a)
		{
			a.MoveToNextTarget();
		});
	}

	// Token: 0x060017E2 RID: 6114 RVA: 0x000B83C4 File Offset: 0x000B67C4
	public void ClearAllSpawner()
	{
		this.AllUnitsLeaveEncounter();
		if (this._adventruerInBattles.Count != 0)
		{
			foreach (AdventruerInBattle adventruerInBattle in this._adventruerInBattles)
			{
				if (adventruerInBattle != null)
				{
					UnityEngine.Object.Destroy(adventruerInBattle.gameObject);
				}
			}
			this._adventruerInBattles.Clear();
		}
		if (this._adventurerCombatControllers.Count != 0)
		{
			this.GetCurrentAdventurers().ForEach(delegate(AdventurerCombatController a)
			{
				if (a.BattleUnit != null)
				{
					a.BattleUnit.RemoveAllEventCallbackFromUiLayer();
				}
				GameObjectUtil.RecycleDestroy(a.gameObject);
			});
			this._adventurerCombatControllers.Clear();
		}
		if (this._enemyCombatControllers.Count != 0)
		{
			this.GetCurrentEnemeys().ForEach(delegate(EnemyCombatController e)
			{
				GameObjectUtil.RecycleDestroy(e.gameObject);
			});
			this._enemyCombatControllers.Clear();
		}
		this.PreDefinedLayouts.Clear();
		this.EnemyPrefabs.Clear();
		this.Finish();
	}

	// Token: 0x060017E3 RID: 6115 RVA: 0x000B84F4 File Offset: 0x000B68F4
	public void Finish()
	{
		(from c in this._currentInitedEnemy
		where c != null
		select c).ToList<InstantVelocity>().ForEach(delegate(InstantVelocity c)
		{
			c.Finish();
		});
		this._currentInitedEnemy.Clear();
	}

	// Token: 0x060017E4 RID: 6116 RVA: 0x000B855C File Offset: 0x000B695C
	public void ChestCollected()
	{
		if (this._chests.Count != 0)
		{
			foreach (ChestLayout chestLayout in this._chests)
			{
				if (chestLayout != null)
				{
					chestLayout.ResetRewardsPosition();
					GameObjectUtil.RecycleDestroy(chestLayout.gameObject);
				}
			}
		}
		this._chests.Clear();
	}

	// Token: 0x060017E5 RID: 6117 RVA: 0x000B85EC File Offset: 0x000B69EC
	private void PositEnemyUnits(List<GameObject> monsters)
	{
		switch (monsters.Count)
		{
		case 1:
			monsters[0].transform.position = this.EnemyInitPoint[3].transform.position;
			break;
		case 2:
			monsters[0].transform.position = this.EnemyInitPoint[4].transform.position;
			monsters[1].transform.position = this.EnemyInitPoint[5].transform.position;
			break;
		case 3:
			monsters[0].transform.position = this.EnemyInitPoint[3].transform.position;
			monsters[1].transform.position = this.EnemyInitPoint[4].transform.position;
			monsters[2].transform.position = this.EnemyInitPoint[5].transform.position;
			break;
		case 4:
			monsters[0].transform.position = this.EnemyInitPoint[3].transform.position;
			monsters[1].transform.position = this.EnemyInitPoint[2].transform.position;
			monsters[2].transform.position = this.EnemyInitPoint[1].transform.position;
			monsters[3].transform.position = this.EnemyInitPoint[0].transform.position;
			break;
		case 5:
			monsters[0].transform.position = this.EnemyInitPoint[5].transform.position;
			monsters[1].transform.position = this.EnemyInitPoint[4].transform.position;
			monsters[2].transform.position = this.EnemyInitPoint[3].transform.position;
			monsters[3].transform.position = this.EnemyInitPoint[2].transform.position;
			monsters[4].transform.position = this.EnemyInitPoint[1].transform.position;
			break;
		case 6:
			monsters[0].transform.position = this.EnemyInitPoint[5].transform.position;
			monsters[1].transform.position = this.EnemyInitPoint[4].transform.position;
			monsters[2].transform.position = this.EnemyInitPoint[3].transform.position;
			monsters[3].transform.position = this.EnemyInitPoint[2].transform.position;
			monsters[4].transform.position = this.EnemyInitPoint[1].transform.position;
			monsters[5].transform.position = this.EnemyInitPoint[0].transform.position;
			break;
		}
	}

	// Token: 0x060017E6 RID: 6118 RVA: 0x000B8922 File Offset: 0x000B6D22
	[CompilerGenerated]
	private static bool <GetCurrentAdventurers>m__0(AdventurerCombatController a)
	{
		return a != null;
	}

	// Token: 0x060017E7 RID: 6119 RVA: 0x000B892B File Offset: 0x000B6D2B
	[CompilerGenerated]
	private static bool <GetCurrentEnemeys>m__1(EnemyCombatController a)
	{
		return a != null;
	}

	// Token: 0x060017E8 RID: 6120 RVA: 0x000B8934 File Offset: 0x000B6D34
	[CompilerGenerated]
	private static void <ActiveSkillCasted>m__2(EnemyCombatController e)
	{
		e.ActiveSkillReleased();
	}

	// Token: 0x060017E9 RID: 6121 RVA: 0x000B893C File Offset: 0x000B6D3C
	[CompilerGenerated]
	private static bool <InitEnemy>m__3(IBattleUnit e)
	{
		return !e.IsBoss();
	}

	// Token: 0x060017EA RID: 6122 RVA: 0x000B8947 File Offset: 0x000B6D47
	[CompilerGenerated]
	private static bool <InitEnemy>m__4(IBattleUnit e)
	{
		return e.IsBoss();
	}

	// Token: 0x060017EB RID: 6123 RVA: 0x000B894F File Offset: 0x000B6D4F
	[CompilerGenerated]
	private static bool <DefeatedEncounter>m__5(InstantVelocity c)
	{
		return c != null && c.gameObject != null;
	}

	// Token: 0x060017EC RID: 6124 RVA: 0x000B896C File Offset: 0x000B6D6C
	[CompilerGenerated]
	private static void <DefeatedEncounter>m__6(InstantVelocity e)
	{
		GameObjectUtil.RecycleDestroy(e.gameObject);
	}

	// Token: 0x060017ED RID: 6125 RVA: 0x000B8979 File Offset: 0x000B6D79
	[CompilerGenerated]
	private static void <DefeatedEncounter>m__7(EnemyCombatController e)
	{
		GameObjectUtil.RecycleDestroy(e.gameObject);
	}

	// Token: 0x060017EE RID: 6126 RVA: 0x000B8986 File Offset: 0x000B6D86
	[CompilerGenerated]
	private static void <DefeatedEncounter>m__8(AdventurerCombatController a)
	{
		a.LeavesEncounter();
	}

	// Token: 0x060017EF RID: 6127 RVA: 0x000B898E File Offset: 0x000B6D8E
	[CompilerGenerated]
	private static void <AllUnitsLeaveEncounter>m__9(AdventurerCombatController a)
	{
		a.LeavesEncounter();
	}

	// Token: 0x060017F0 RID: 6128 RVA: 0x000B8996 File Offset: 0x000B6D96
	[CompilerGenerated]
	private static void <AllUnitsLeaveEncounter>m__A(EnemyCombatController e)
	{
		e.LeavesEncounter();
	}

	// Token: 0x060017F1 RID: 6129 RVA: 0x000B899E File Offset: 0x000B6D9E
	[CompilerGenerated]
	private static bool <StopMoving>m__B(AdventruerInBattle a)
	{
		return a != null;
	}

	// Token: 0x060017F2 RID: 6130 RVA: 0x000B89A7 File Offset: 0x000B6DA7
	[CompilerGenerated]
	private static void <StopMoving>m__C(AdventruerInBattle a)
	{
		a.Encountered();
	}

	// Token: 0x060017F3 RID: 6131 RVA: 0x000B89AF File Offset: 0x000B6DAF
	[CompilerGenerated]
	private static bool <StopMoving>m__D(InstantVelocity a)
	{
		return a != null;
	}

	// Token: 0x060017F4 RID: 6132 RVA: 0x000B89B8 File Offset: 0x000B6DB8
	[CompilerGenerated]
	private static void <StopMoving>m__E(InstantVelocity e)
	{
		e.StopMoving();
	}

	// Token: 0x060017F5 RID: 6133 RVA: 0x000B89C0 File Offset: 0x000B6DC0
	[CompilerGenerated]
	private static bool <StopMoving>m__F(ChestLayout a)
	{
		return a != null;
	}

	// Token: 0x060017F6 RID: 6134 RVA: 0x000B89C9 File Offset: 0x000B6DC9
	[CompilerGenerated]
	private static void <StopMoving>m__10(ChestLayout c)
	{
		c.GetComponent<InstantVelocity>().StopMoving();
	}

	// Token: 0x060017F7 RID: 6135 RVA: 0x000B89D6 File Offset: 0x000B6DD6
	[CompilerGenerated]
	private static bool <ContinueMoving>m__11(InstantVelocity a)
	{
		return a != null;
	}

	// Token: 0x060017F8 RID: 6136 RVA: 0x000B89DF File Offset: 0x000B6DDF
	[CompilerGenerated]
	private static void <ContinueMoving>m__12(InstantVelocity c)
	{
		c.ContinueMoving();
	}

	// Token: 0x060017F9 RID: 6137 RVA: 0x000B89E7 File Offset: 0x000B6DE7
	[CompilerGenerated]
	private static bool <ContinueMoving>m__13(AdventruerInBattle a)
	{
		return a != null;
	}

	// Token: 0x060017FA RID: 6138 RVA: 0x000B89F0 File Offset: 0x000B6DF0
	[CompilerGenerated]
	private static void <ContinueMoving>m__14(AdventruerInBattle a)
	{
		a.MoveToNextTarget();
	}

	// Token: 0x060017FB RID: 6139 RVA: 0x000B89F8 File Offset: 0x000B6DF8
	[CompilerGenerated]
	private static void <ClearAllSpawner>m__15(AdventurerCombatController a)
	{
		if (a.BattleUnit != null)
		{
			a.BattleUnit.RemoveAllEventCallbackFromUiLayer();
		}
		GameObjectUtil.RecycleDestroy(a.gameObject);
	}

	// Token: 0x060017FC RID: 6140 RVA: 0x000B8A1B File Offset: 0x000B6E1B
	[CompilerGenerated]
	private static void <ClearAllSpawner>m__16(EnemyCombatController e)
	{
		GameObjectUtil.RecycleDestroy(e.gameObject);
	}

	// Token: 0x060017FD RID: 6141 RVA: 0x000B8A28 File Offset: 0x000B6E28
	[CompilerGenerated]
	private static bool <Finish>m__17(InstantVelocity c)
	{
		return c != null;
	}

	// Token: 0x060017FE RID: 6142 RVA: 0x000B8A31 File Offset: 0x000B6E31
	[CompilerGenerated]
	private static void <Finish>m__18(InstantVelocity c)
	{
		c.Finish();
	}

	// Token: 0x040017A4 RID: 6052
	public GameObject[] PlayerInitPoint;

	// Token: 0x040017A5 RID: 6053
	public GameObject[] EnemyInitPoint;

	// Token: 0x040017A6 RID: 6054
	public GameObject BossInitPoint;

	// Token: 0x040017A7 RID: 6055
	public GameObject[] PlayerBattlePoints;

	// Token: 0x040017A8 RID: 6056
	public GameObject PlayerGroup;

	// Token: 0x040017A9 RID: 6057
	public GameObject EnemyGroup;

	// Token: 0x040017AA RID: 6058
	public BattleBackgroundController Background;

	// Token: 0x040017AB RID: 6059
	public Transform InitPointTran;

	// Token: 0x040017AC RID: 6060
	public Transform BattlePointTran;

	// Token: 0x040017AD RID: 6061
	private List<GameObject> PreDefinedLayouts = new List<GameObject>();

	// Token: 0x040017AE RID: 6062
	private List<GameObject> EnemyPrefabs = new List<GameObject>();

	// Token: 0x040017AF RID: 6063
	private readonly List<AdventruerInBattle> _adventruerInBattles = new List<AdventruerInBattle>();

	// Token: 0x040017B0 RID: 6064
	private readonly List<AdventurerCombatController> _adventurerCombatControllers = new List<AdventurerCombatController>();

	// Token: 0x040017B1 RID: 6065
	private readonly List<InstantVelocity> _currentInitedEnemy = new List<InstantVelocity>();

	// Token: 0x040017B2 RID: 6066
	private readonly List<EnemyCombatController> _enemyCombatControllers = new List<EnemyCombatController>();

	// Token: 0x040017B3 RID: 6067
	private List<ChestLayout> _chests = new List<ChestLayout>();

	// Token: 0x040017B4 RID: 6068
	[CompilerGenerated]
	private static Func<AdventurerCombatController, bool> <>f__am$cache0;

	// Token: 0x040017B5 RID: 6069
	[CompilerGenerated]
	private static Func<EnemyCombatController, bool> <>f__am$cache1;

	// Token: 0x040017B6 RID: 6070
	[CompilerGenerated]
	private static Action<EnemyCombatController> <>f__am$cache2;

	// Token: 0x040017B7 RID: 6071
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache3;

	// Token: 0x040017B8 RID: 6072
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache4;

	// Token: 0x040017B9 RID: 6073
	[CompilerGenerated]
	private static Func<InstantVelocity, bool> <>f__am$cache5;

	// Token: 0x040017BA RID: 6074
	[CompilerGenerated]
	private static Action<InstantVelocity> <>f__am$cache6;

	// Token: 0x040017BB RID: 6075
	[CompilerGenerated]
	private static Action<EnemyCombatController> <>f__am$cache7;

	// Token: 0x040017BC RID: 6076
	[CompilerGenerated]
	private static Action<AdventurerCombatController> <>f__am$cache8;

	// Token: 0x040017BD RID: 6077
	[CompilerGenerated]
	private static Action<AdventurerCombatController> <>f__am$cache9;

	// Token: 0x040017BE RID: 6078
	[CompilerGenerated]
	private static Action<EnemyCombatController> <>f__am$cacheA;

	// Token: 0x040017BF RID: 6079
	[CompilerGenerated]
	private static Func<AdventruerInBattle, bool> <>f__am$cacheB;

	// Token: 0x040017C0 RID: 6080
	[CompilerGenerated]
	private static Action<AdventruerInBattle> <>f__am$cacheC;

	// Token: 0x040017C1 RID: 6081
	[CompilerGenerated]
	private static Func<InstantVelocity, bool> <>f__am$cacheD;

	// Token: 0x040017C2 RID: 6082
	[CompilerGenerated]
	private static Action<InstantVelocity> <>f__am$cacheE;

	// Token: 0x040017C3 RID: 6083
	[CompilerGenerated]
	private static Func<ChestLayout, bool> <>f__am$cacheF;

	// Token: 0x040017C4 RID: 6084
	[CompilerGenerated]
	private static Action<ChestLayout> <>f__am$cache10;

	// Token: 0x040017C5 RID: 6085
	[CompilerGenerated]
	private static Func<InstantVelocity, bool> <>f__am$cache11;

	// Token: 0x040017C6 RID: 6086
	[CompilerGenerated]
	private static Action<InstantVelocity> <>f__am$cache12;

	// Token: 0x040017C7 RID: 6087
	[CompilerGenerated]
	private static Func<AdventruerInBattle, bool> <>f__am$cache13;

	// Token: 0x040017C8 RID: 6088
	[CompilerGenerated]
	private static Action<AdventruerInBattle> <>f__am$cache14;

	// Token: 0x040017C9 RID: 6089
	[CompilerGenerated]
	private static Action<AdventurerCombatController> <>f__am$cache15;

	// Token: 0x040017CA RID: 6090
	[CompilerGenerated]
	private static Action<EnemyCombatController> <>f__am$cache16;

	// Token: 0x040017CB RID: 6091
	[CompilerGenerated]
	private static Func<InstantVelocity, bool> <>f__am$cache17;

	// Token: 0x040017CC RID: 6092
	[CompilerGenerated]
	private static Action<InstantVelocity> <>f__am$cache18;

	// Token: 0x02000CC2 RID: 3266
	[CompilerGenerated]
	private sealed class <GetControllerByBattleUnit>c__AnonStorey4
	{
		// Token: 0x06005462 RID: 21602 RVA: 0x000B8A39 File Offset: 0x000B6E39
		public <GetControllerByBattleUnit>c__AnonStorey4()
		{
		}

		// Token: 0x06005463 RID: 21603 RVA: 0x000B8A41 File Offset: 0x000B6E41
		internal bool <>m__0(AdventurerCombatController a)
		{
			return a.BattleUnit == this.selected;
		}

		// Token: 0x06005464 RID: 21604 RVA: 0x000B8A51 File Offset: 0x000B6E51
		internal bool <>m__1(EnemyCombatController e)
		{
			return e.BattleUnit == this.selected;
		}

		// Token: 0x040041D6 RID: 16854
		internal IBattleUnit selected;
	}

	// Token: 0x02000CC3 RID: 3267
	[CompilerGenerated]
	private sealed class <HighLightSelection>c__AnonStorey5
	{
		// Token: 0x06005465 RID: 21605 RVA: 0x000B8A61 File Offset: 0x000B6E61
		public <HighLightSelection>c__AnonStorey5()
		{
		}

		// Token: 0x06005466 RID: 21606 RVA: 0x000B8A69 File Offset: 0x000B6E69
		internal void <>m__0(EnemyCombatController e)
		{
			e.HighlightCorresponseUnit(this.units);
		}

		// Token: 0x040041D7 RID: 16855
		internal List<IBattleUnit> units;
	}

	// Token: 0x02000CC4 RID: 3268
	[CompilerGenerated]
	private sealed class <EntersEncounterAndSetsUpListeners>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005467 RID: 21607 RVA: 0x000B8A77 File Offset: 0x000B6E77
		[DebuggerHidden]
		public <EntersEncounterAndSetsUpListeners>c__Iterator0()
		{
		}

		// Token: 0x06005468 RID: 21608 RVA: 0x000B8A80 File Offset: 0x000B6E80
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				foreach (AdventurerCombatController adventurerCombatController in base.GetCurrentAdventurers())
				{
					foreach (IBattleUnit battleUnit in from e in encounter.PlayerUnits
					where e.Status != BattleUnitStatus.Dead
					select e)
					{
						if (adventurerCombatController.Adventurer.AdventurerId == battleUnit.GetId())
						{
							adventurerCombatController.Init(battleUnit, CombatManager.Instance.CombatPointsController.AttackPoint.transform.position, false);
						}
					}
				}
				List<EnemyCombatController> currentEnemeys = base.GetCurrentEnemeys();
				using (List<IBattleUnit>.Enumerator enumerator3 = encounter.EnemyUnits.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						IBattleUnit encounterEnemyUnit = enumerator3.Current;
						EnemyCombatController enemyCombatController = currentEnemeys.FirstOrDefault((EnemyCombatController e) => e.BattleUnit.GetId() == encounterEnemyUnit.GetId());
						if (enemyCombatController != null && enemyCombatController.BattleUnit.GetId() == encounterEnemyUnit.GetId())
						{
							enemyCombatController.Init(encounterEnemyUnit, CombatManager.Instance.CombatPointsController.AttackPoint.transform.position, false);
						}
					}
				}
				foreach (InstantVelocity instantVelocity in this._currentInitedEnemy)
				{
					instantVelocity.EncountersPlayer();
				}
				List<EnemyCombatController> source = base.GetCurrentEnemeys();
				EnemyCombatController enemyCombatController2 = source.FirstOrDefault((EnemyCombatController e) => e.BattleUnit.IsBoss());
				source = (from e in source
				where !e.BattleUnit.IsBoss()
				select e).ToList<EnemyCombatController>();
				CombatManager.Instance.CombatPointsController.Init((from a in this._adventurerCombatControllers
				select (!(a != null)) ? null : a.gameObject).ToList<GameObject>(), (from e in source
				select e.gameObject).ToList<GameObject>(), (!(enemyCombatController2 != null)) ? null : enemyCombatController2.gameObject);
			}
			return false;
		}

		// Token: 0x170011E8 RID: 4584
		// (get) Token: 0x06005469 RID: 21609 RVA: 0x000B8D9C File Offset: 0x000B719C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011E9 RID: 4585
		// (get) Token: 0x0600546A RID: 21610 RVA: 0x000B8DA4 File Offset: 0x000B71A4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600546B RID: 21611 RVA: 0x000B8DAC File Offset: 0x000B71AC
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600546C RID: 21612 RVA: 0x000B8DAE File Offset: 0x000B71AE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600546D RID: 21613 RVA: 0x000B8DB5 File Offset: 0x000B71B5
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600546E RID: 21614 RVA: 0x000B8DC0 File Offset: 0x000B71C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Spawner.<EntersEncounterAndSetsUpListeners>c__Iterator0 <EntersEncounterAndSetsUpListeners>c__Iterator = new Spawner.<EntersEncounterAndSetsUpListeners>c__Iterator0();
			<EntersEncounterAndSetsUpListeners>c__Iterator.$this = this;
			<EntersEncounterAndSetsUpListeners>c__Iterator.encounter = encounter;
			return <EntersEncounterAndSetsUpListeners>c__Iterator;
		}

		// Token: 0x0600546F RID: 21615 RVA: 0x000B8E00 File Offset: 0x000B7200
		private static bool <>m__0(IBattleUnit e)
		{
			return e.Status != BattleUnitStatus.Dead;
		}

		// Token: 0x06005470 RID: 21616 RVA: 0x000B8E0E File Offset: 0x000B720E
		private static bool <>m__1(EnemyCombatController e)
		{
			return e.BattleUnit.IsBoss();
		}

		// Token: 0x06005471 RID: 21617 RVA: 0x000B8E1B File Offset: 0x000B721B
		private static bool <>m__2(EnemyCombatController e)
		{
			return !e.BattleUnit.IsBoss();
		}

		// Token: 0x06005472 RID: 21618 RVA: 0x000B8E2B File Offset: 0x000B722B
		private static GameObject <>m__3(AdventurerCombatController a)
		{
			return (!(a != null)) ? null : a.gameObject;
		}

		// Token: 0x06005473 RID: 21619 RVA: 0x000B8E45 File Offset: 0x000B7245
		private static GameObject <>m__4(EnemyCombatController e)
		{
			return e.gameObject;
		}

		// Token: 0x040041D8 RID: 16856
		internal IEncounter encounter;

		// Token: 0x040041D9 RID: 16857
		internal Spawner $this;

		// Token: 0x040041DA RID: 16858
		internal object $current;

		// Token: 0x040041DB RID: 16859
		internal bool $disposing;

		// Token: 0x040041DC RID: 16860
		internal int $PC;

		// Token: 0x040041DD RID: 16861
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x040041DE RID: 16862
		private static Func<EnemyCombatController, bool> <>f__am$cache1;

		// Token: 0x040041DF RID: 16863
		private static Func<EnemyCombatController, bool> <>f__am$cache2;

		// Token: 0x040041E0 RID: 16864
		private static Func<AdventurerCombatController, GameObject> <>f__am$cache3;

		// Token: 0x040041E1 RID: 16865
		private static Func<EnemyCombatController, GameObject> <>f__am$cache4;

		// Token: 0x02000CC8 RID: 3272
		private sealed class <EntersEncounterAndSetsUpListeners>c__AnonStorey6
		{
			// Token: 0x0600548E RID: 21646 RVA: 0x000B8E4D File Offset: 0x000B724D
			public <EntersEncounterAndSetsUpListeners>c__AnonStorey6()
			{
			}

			// Token: 0x0600548F RID: 21647 RVA: 0x000B8E55 File Offset: 0x000B7255
			internal bool <>m__0(EnemyCombatController e)
			{
				return e.BattleUnit.GetId() == this.encounterEnemyUnit.GetId();
			}

			// Token: 0x040041F6 RID: 16886
			internal IBattleUnit encounterEnemyUnit;
		}
	}

	// Token: 0x02000CC5 RID: 3269
	[CompilerGenerated]
	private sealed class <WaitingForOpenChest>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005474 RID: 21620 RVA: 0x000B8E72 File Offset: 0x000B7272
		[DebuggerHidden]
		public <WaitingForOpenChest>c__Iterator1()
		{
		}

		// Token: 0x06005475 RID: 21621 RVA: 0x000B8E7C File Offset: 0x000B727C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(chestGapTime);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.StopMoving();
				enumerator = this._chests.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ChestLayout chestLayout = enumerator.Current;
						chestLayout.isBoxColliderEnabled = true;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				AutoAdventureController.Instance.WaitToOpenChest();
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011EA RID: 4586
		// (get) Token: 0x06005476 RID: 21622 RVA: 0x000B8F54 File Offset: 0x000B7354
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011EB RID: 4587
		// (get) Token: 0x06005477 RID: 21623 RVA: 0x000B8F5C File Offset: 0x000B735C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005478 RID: 21624 RVA: 0x000B8F64 File Offset: 0x000B7364
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005479 RID: 21625 RVA: 0x000B8F74 File Offset: 0x000B7374
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600547A RID: 21626 RVA: 0x000B8F7B File Offset: 0x000B737B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600547B RID: 21627 RVA: 0x000B8F84 File Offset: 0x000B7384
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Spawner.<WaitingForOpenChest>c__Iterator1 <WaitingForOpenChest>c__Iterator = new Spawner.<WaitingForOpenChest>c__Iterator1();
			<WaitingForOpenChest>c__Iterator.$this = this;
			<WaitingForOpenChest>c__Iterator.chestGapTime = chestGapTime;
			return <WaitingForOpenChest>c__Iterator;
		}

		// Token: 0x040041E2 RID: 16866
		internal float chestGapTime;

		// Token: 0x040041E3 RID: 16867
		internal List<ChestLayout>.Enumerator $locvar0;

		// Token: 0x040041E4 RID: 16868
		internal Spawner $this;

		// Token: 0x040041E5 RID: 16869
		internal object $current;

		// Token: 0x040041E6 RID: 16870
		internal bool $disposing;

		// Token: 0x040041E7 RID: 16871
		internal int $PC;
	}

	// Token: 0x02000CC6 RID: 3270
	[CompilerGenerated]
	private sealed class <InitRewardsChest>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600547C RID: 21628 RVA: 0x000B8FC4 File Offset: 0x000B73C4
		[DebuggerHidden]
		public <InitRewardsChest>c__Iterator2()
		{
		}

		// Token: 0x0600547D RID: 21629 RVA: 0x000B8FCC File Offset: 0x000B73CC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				if (chests != null && chests.Count != 0)
				{
					this.$current = new WaitForSeconds(chestGapTime);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				for (int i = 0; i < chests.Count; i++)
				{
					GameObject gameObject = GameObjectUtil.Instantiate(this.PreDefinedLayouts[0], this.EnemyInitPoint[i + 1].transform.position, null);
					InstantVelocity component = gameObject.GetComponent<InstantVelocity>();
					component.SetSpeed(this.Background.GetBackgroundMovingSpeed());
					ChestLayout component2 = component.GetComponent<ChestLayout>();
					if (component2 != null)
					{
						component2.SetChest(chests[i], this);
						this._chests.Add(component2);
					}
				}
				enumerator = this._chests.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ChestLayout chestLayout = enumerator.Current;
						chestLayout.GetComponent<InstantVelocity>().ContinueMoving();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011EC RID: 4588
		// (get) Token: 0x0600547E RID: 21630 RVA: 0x000B9160 File Offset: 0x000B7560
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011ED RID: 4589
		// (get) Token: 0x0600547F RID: 21631 RVA: 0x000B9168 File Offset: 0x000B7568
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005480 RID: 21632 RVA: 0x000B9170 File Offset: 0x000B7570
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005481 RID: 21633 RVA: 0x000B9180 File Offset: 0x000B7580
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005482 RID: 21634 RVA: 0x000B9187 File Offset: 0x000B7587
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005483 RID: 21635 RVA: 0x000B9190 File Offset: 0x000B7590
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Spawner.<InitRewardsChest>c__Iterator2 <InitRewardsChest>c__Iterator = new Spawner.<InitRewardsChest>c__Iterator2();
			<InitRewardsChest>c__Iterator.$this = this;
			<InitRewardsChest>c__Iterator.chests = chests;
			<InitRewardsChest>c__Iterator.chestGapTime = chestGapTime;
			return <InitRewardsChest>c__Iterator;
		}

		// Token: 0x040041E8 RID: 16872
		internal List<Chest> chests;

		// Token: 0x040041E9 RID: 16873
		internal float chestGapTime;

		// Token: 0x040041EA RID: 16874
		internal List<ChestLayout>.Enumerator $locvar0;

		// Token: 0x040041EB RID: 16875
		internal Spawner $this;

		// Token: 0x040041EC RID: 16876
		internal object $current;

		// Token: 0x040041ED RID: 16877
		internal bool $disposing;

		// Token: 0x040041EE RID: 16878
		internal int $PC;
	}

	// Token: 0x02000CC7 RID: 3271
	[CompilerGenerated]
	private sealed class <OpenAllChests>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005484 RID: 21636 RVA: 0x000B91DC File Offset: 0x000B75DC
		[DebuggerHidden]
		public <OpenAllChests>c__Iterator3()
		{
		}

		// Token: 0x06005485 RID: 21637 RVA: 0x000B91E4 File Offset: 0x000B75E4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				rest = (from c in this._chests
				where !c.GetChest().IsSelected
				select c).ToList<ChestLayout>();
				rest.ForEach(delegate(ChestLayout r)
				{
					r.ShowReward();
				});
				this.$current = new WaitForSeconds(3f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			case 2u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011EE RID: 4590
		// (get) Token: 0x06005486 RID: 21638 RVA: 0x000B92C8 File Offset: 0x000B76C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011EF RID: 4591
		// (get) Token: 0x06005487 RID: 21639 RVA: 0x000B92D0 File Offset: 0x000B76D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005488 RID: 21640 RVA: 0x000B92D8 File Offset: 0x000B76D8
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005489 RID: 21641 RVA: 0x000B92E8 File Offset: 0x000B76E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600548A RID: 21642 RVA: 0x000B92EF File Offset: 0x000B76EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600548B RID: 21643 RVA: 0x000B92F8 File Offset: 0x000B76F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Spawner.<OpenAllChests>c__Iterator3 <OpenAllChests>c__Iterator = new Spawner.<OpenAllChests>c__Iterator3();
			<OpenAllChests>c__Iterator.$this = this;
			return <OpenAllChests>c__Iterator;
		}

		// Token: 0x0600548C RID: 21644 RVA: 0x000B932C File Offset: 0x000B772C
		private static bool <>m__0(ChestLayout c)
		{
			return !c.GetChest().IsSelected;
		}

		// Token: 0x0600548D RID: 21645 RVA: 0x000B933C File Offset: 0x000B773C
		private static void <>m__1(ChestLayout r)
		{
			r.ShowReward();
		}

		// Token: 0x040041EF RID: 16879
		internal List<ChestLayout> <rest>__0;

		// Token: 0x040041F0 RID: 16880
		internal Spawner $this;

		// Token: 0x040041F1 RID: 16881
		internal object $current;

		// Token: 0x040041F2 RID: 16882
		internal bool $disposing;

		// Token: 0x040041F3 RID: 16883
		internal int $PC;

		// Token: 0x040041F4 RID: 16884
		private static Func<ChestLayout, bool> <>f__am$cache0;

		// Token: 0x040041F5 RID: 16885
		private static Action<ChestLayout> <>f__am$cache1;
	}
}
