using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class ProgressIndicatorController : MonoBehaviour
{
	// Token: 0x0600176B RID: 5995 RVA: 0x000B5E1F File Offset: 0x000B421F
	public ProgressIndicatorController()
	{
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000B5E34 File Offset: 0x000B4234
	public void InitAllUnitSpeedPosition(List<IBattleUnit> units)
	{
		foreach (IBattleUnit battleUnit in units)
		{
			GameObject gameObject = null;
			if (battleUnit is AdventurerBattleUnit)
			{
				gameObject = GameObjectUtil.Instantiate(this.PlayerIndicator, base.transform.position, this.AdventureParent);
			}
			if (battleUnit is EnemyBattleUnit && battleUnit.IsTurnRelevant())
			{
				gameObject = GameObjectUtil.Instantiate(this.EnemyIndicator, base.transform.position, this.AdventureParent);
			}
			if (battleUnit is PetBattleUnit)
			{
				if (battleUnit.IsPlayer)
				{
					gameObject = GameObjectUtil.Instantiate(this.PetIndicator, base.transform.position, this.AdventureParent);
				}
				else if (battleUnit.IsTurnRelevant())
				{
					gameObject = GameObjectUtil.Instantiate(this.EnemyIndicator, base.transform.position, this.AdventureParent);
				}
			}
			if (!(gameObject == null))
			{
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.SetParent(this.AdventureParent.transform);
				IndividualSpeedObj component = gameObject.GetComponent<IndividualSpeedObj>();
				if (!(component == null))
				{
					component.Init(battleUnit);
					this._allUnitsInCalculation.Add(component);
				}
			}
		}
		this.UpdatePosition();
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000B5FB8 File Offset: 0x000B43B8
	public void UpdatePosition()
	{
		List<IndividualSpeedObj> list = new List<IndividualSpeedObj>();
		foreach (IndividualSpeedObj individualSpeedObj in this._allUnitsInCalculation)
		{
			if (individualSpeedObj.BattleUnit.Status == BattleUnitStatus.Dead)
			{
				individualSpeedObj.UnitDead();
				list.Add(individualSpeedObj);
			}
		}
		list.ForEach(delegate(IndividualSpeedObj r)
		{
			this._allUnitsInCalculation.Remove(r);
			GameObjectUtil.RecycleDestroy(r.gameObject);
		});
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000B6044 File Offset: 0x000B4444
	public void EncouterFinished()
	{
		foreach (IndividualSpeedObj individualSpeedObj in this._allUnitsInCalculation)
		{
			individualSpeedObj.EncouterFinished();
		}
		this._allUnitsInCalculation.Clear();
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000B60AC File Offset: 0x000B44AC
	public void EnterTurn(IBattleUnit unit)
	{
		IndividualSpeedObj individualSpeedObj = this._allUnitsInCalculation.FirstOrDefault((IndividualSpeedObj a) => a.BattleUnit.GetId() == unit.GetId());
		if (individualSpeedObj != null)
		{
			individualSpeedObj.EnterTurn();
		}
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000B60F0 File Offset: 0x000B44F0
	public void FinishTurn(IBattleUnit inTurnBattleUnit)
	{
		IndividualSpeedObj individualSpeedObj = this._allUnitsInCalculation.FirstOrDefault((IndividualSpeedObj a) => a.BattleUnit.GetId() == inTurnBattleUnit.GetId());
		if (individualSpeedObj != null)
		{
			individualSpeedObj.CompleteTurn();
		}
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000B6134 File Offset: 0x000B4534
	[CompilerGenerated]
	private void <UpdatePosition>m__0(IndividualSpeedObj r)
	{
		this._allUnitsInCalculation.Remove(r);
		GameObjectUtil.RecycleDestroy(r.gameObject);
	}

	// Token: 0x0400175E RID: 5982
	public GameObject AdventureParent;

	// Token: 0x0400175F RID: 5983
	public GameObject PlayerIndicator;

	// Token: 0x04001760 RID: 5984
	public GameObject EnemyIndicator;

	// Token: 0x04001761 RID: 5985
	public GameObject PetIndicator;

	// Token: 0x04001762 RID: 5986
	private readonly List<IndividualSpeedObj> _allUnitsInCalculation = new List<IndividualSpeedObj>();

	// Token: 0x02000CBB RID: 3259
	[CompilerGenerated]
	private sealed class <EnterTurn>c__AnonStorey0
	{
		// Token: 0x0600543A RID: 21562 RVA: 0x000B614E File Offset: 0x000B454E
		public <EnterTurn>c__AnonStorey0()
		{
		}

		// Token: 0x0600543B RID: 21563 RVA: 0x000B6156 File Offset: 0x000B4556
		internal bool <>m__0(IndividualSpeedObj a)
		{
			return a.BattleUnit.GetId() == this.unit.GetId();
		}

		// Token: 0x040041B9 RID: 16825
		internal IBattleUnit unit;
	}

	// Token: 0x02000CBC RID: 3260
	[CompilerGenerated]
	private sealed class <FinishTurn>c__AnonStorey1
	{
		// Token: 0x0600543C RID: 21564 RVA: 0x000B6173 File Offset: 0x000B4573
		public <FinishTurn>c__AnonStorey1()
		{
		}

		// Token: 0x0600543D RID: 21565 RVA: 0x000B617B File Offset: 0x000B457B
		internal bool <>m__0(IndividualSpeedObj a)
		{
			return a.BattleUnit.GetId() == this.inTurnBattleUnit.GetId();
		}

		// Token: 0x040041BA RID: 16826
		internal IBattleUnit inTurnBattleUnit;
	}
}
