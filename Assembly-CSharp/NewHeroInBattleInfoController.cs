using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class NewHeroInBattleInfoController : MonoBehaviour
{
	// Token: 0x0600175C RID: 5980 RVA: 0x000B58B3 File Offset: 0x000B3CB3
	public NewHeroInBattleInfoController()
	{
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x000B58BC File Offset: 0x000B3CBC
	private void Update()
	{
		bool flag = true;
		if (Input.GetKeyDown(PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic1).ToLower()) && this.ActiveSkills.Count > 0 && this.ActiveSkills[0].gameObject.activeSelf)
		{
			this.ActiveSkills[0].TrigerActiveSkill();
			flag = false;
		}
		if (Input.GetKeyDown(PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic2).ToLower()) && flag && this.ActiveSkills.Count > 1 && this.ActiveSkills[1].gameObject.activeSelf)
		{
			this.ActiveSkills[1].TrigerActiveSkill();
			flag = false;
		}
		if (Input.GetKeyDown(PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic3).ToLower()) && flag && this.ActiveSkills.Count > 2 && this.ActiveSkills[2].gameObject.activeSelf)
		{
			this.ActiveSkills[2].TrigerActiveSkill();
			flag = false;
		}
		if (Input.GetKeyDown(PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic4).ToLower()) && flag && this.ActiveSkills.Count > 3 && this.ActiveSkills[3].gameObject.activeSelf)
		{
			this.ActiveSkills[3].TrigerActiveSkill();
			flag = false;
		}
		if (Input.GetKeyDown(PlayerPrefs.GetString(PlayerPrefsAttribute.Tactic5).ToLower()) && flag && this.ActiveSkills.Count > 4 && this.ActiveSkills[4].gameObject.activeSelf)
		{
			this.ActiveSkills[4].TrigerActiveSkill();
		}
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x000B5A9B File Offset: 0x000B3E9B
	public void SetAdventure(Adventure adventure)
	{
		this._adventure = adventure;
		this.Setup();
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x000B5AAC File Offset: 0x000B3EAC
	private void Setup()
	{
		int count = this._adventure.Adventurers.Count;
		for (int i = 0; i < this.AdventurerInBattleAsCardControllers.Length; i++)
		{
			if (i < count)
			{
				this.AdventurerInBattleAsCardControllers[i].SetBattleUnit(this._adventure.Adventurers[i], null);
				this.AdventurerInBattleAsCardControllers[i].gameObject.SetActive(true);
			}
			else
			{
				this.AdventurerInBattleAsCardControllers[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x000B5B34 File Offset: 0x000B3F34
	public void SetUpListener(BattleEncounter encounter)
	{
		this._currentBattleEncounter = encounter;
		foreach (IBattleUnit battleUnit2 in from u in encounter.PlayerUnits
		where u.Status == BattleUnitStatus.Active
		select u)
		{
			AdventurerBattleUnit battleUnit = battleUnit2 as AdventurerBattleUnit;
			if (battleUnit != null)
			{
				AdventurerInBattleAsCardController adventurerInBattleAsCardController = this.AdventurerInBattleAsCardControllers.FirstOrDefault((AdventurerInBattleAsCardController h) => h.BattleUnit.GetId() == battleUnit.AdventurerId);
				if (adventurerInBattleAsCardController != null)
				{
					adventurerInBattleAsCardController.BindListener(battleUnit);
					if (battleUnit.Status != BattleUnitStatus.Dead)
					{
						adventurerInBattleAsCardController.ResetAvatar();
					}
				}
			}
		}
		this.SetupProgressIndicator();
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x000B5C1C File Offset: 0x000B401C
	public void SetSelectedUnit(IBattleUnit SelectedEnemy, Sprite normalStandingSprite)
	{
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000B5C20 File Offset: 0x000B4020
	public void LeavesEncounter()
	{
		this._indicatorInitialized = false;
		this.ProgressIndicator.EncouterFinished();
		foreach (AdventurerInBattleAsCardController adventurerInBattleAsCardController in this.AdventurerInBattleAsCardControllers)
		{
			adventurerInBattleAsCardController.LeavesEncounter();
		}
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000B5C64 File Offset: 0x000B4064
	public void SetupProgressIndicator()
	{
		if (!this._indicatorInitialized)
		{
			List<IBattleUnit> currentOrder = this.GetCurrentOrder();
			if (currentOrder != null)
			{
				this._indicatorInitialized = true;
				this.ProgressIndicator.InitAllUnitSpeedPosition(currentOrder);
			}
		}
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000B5C9C File Offset: 0x000B409C
	public void AddUnitProgressIndicator(IBattleUnit unit)
	{
		if (unit != null)
		{
			this.ProgressIndicator.InitAllUnitSpeedPosition(new List<IBattleUnit>
			{
				unit
			});
		}
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000B5CC8 File Offset: 0x000B40C8
	private List<IBattleUnit> GetCurrentOrder()
	{
		if (this._currentBattleEncounter == null)
		{
			return null;
		}
		List<IBattleUnit> list = new List<IBattleUnit>();
		list.AddRange((from p in this._currentBattleEncounter.PlayerUnits
		where p.Status == BattleUnitStatus.Active
		select p).ToList<IBattleUnit>());
		list.AddRange((from e in this._currentBattleEncounter.EnemyUnits
		where e.Status == BattleUnitStatus.Active
		select e).ToList<IBattleUnit>());
		return (from k in list
		orderby k.TurnProgress
		select k).ToList<IBattleUnit>();
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000B5D80 File Offset: 0x000B4180
	public void AdventureFinished()
	{
		this._currentBattleEncounter = null;
		foreach (AdventurerInBattleAsCardController adventurerInBattleAsCardController in this.AdventurerInBattleAsCardControllers)
		{
			adventurerInBattleAsCardController.gameObject.SetActive(false);
		}
		this.ProgressIndicator.EncouterFinished();
		this._indicatorInitialized = false;
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000B5DD1 File Offset: 0x000B41D1
	[CompilerGenerated]
	private static bool <SetUpListener>m__0(IBattleUnit u)
	{
		return u.Status == BattleUnitStatus.Active;
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000B5DDC File Offset: 0x000B41DC
	[CompilerGenerated]
	private static bool <GetCurrentOrder>m__1(IBattleUnit p)
	{
		return p.Status == BattleUnitStatus.Active;
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000B5DE7 File Offset: 0x000B41E7
	[CompilerGenerated]
	private static bool <GetCurrentOrder>m__2(IBattleUnit e)
	{
		return e.Status == BattleUnitStatus.Active;
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000B5DF2 File Offset: 0x000B41F2
	[CompilerGenerated]
	private static double <GetCurrentOrder>m__3(IBattleUnit k)
	{
		return k.TurnProgress;
	}

	// Token: 0x04001754 RID: 5972
	public AdventurerInBattleAsCardController[] AdventurerInBattleAsCardControllers;

	// Token: 0x04001755 RID: 5973
	public List<ActiveSkillObj> ActiveSkills;

	// Token: 0x04001756 RID: 5974
	private Adventure _adventure;

	// Token: 0x04001757 RID: 5975
	private BattleEncounter _currentBattleEncounter;

	// Token: 0x04001758 RID: 5976
	private bool _indicatorInitialized;

	// Token: 0x04001759 RID: 5977
	public ProgressIndicatorController ProgressIndicator;

	// Token: 0x0400175A RID: 5978
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache0;

	// Token: 0x0400175B RID: 5979
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache1;

	// Token: 0x0400175C RID: 5980
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache2;

	// Token: 0x0400175D RID: 5981
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache3;

	// Token: 0x02000CBA RID: 3258
	[CompilerGenerated]
	private sealed class <SetUpListener>c__AnonStorey0
	{
		// Token: 0x06005438 RID: 21560 RVA: 0x000B5DFA File Offset: 0x000B41FA
		public <SetUpListener>c__AnonStorey0()
		{
		}

		// Token: 0x06005439 RID: 21561 RVA: 0x000B5E02 File Offset: 0x000B4202
		internal bool <>m__0(AdventurerInBattleAsCardController h)
		{
			return h.BattleUnit.GetId() == this.battleUnit.AdventurerId;
		}

		// Token: 0x040041B8 RID: 16824
		internal AdventurerBattleUnit battleUnit;
	}
}
