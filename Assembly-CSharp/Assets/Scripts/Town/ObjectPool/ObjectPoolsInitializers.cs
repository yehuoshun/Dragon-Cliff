using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Town.ObjectPool
{
	// Token: 0x02000A18 RID: 2584
	public class ObjectPoolsInitializers : MonoBehaviour
	{
		// Token: 0x06004696 RID: 18070 RVA: 0x001CEC64 File Offset: 0x001CD064
		public ObjectPoolsInitializers()
		{
		}

		// Token: 0x06004697 RID: 18071 RVA: 0x001CED1B File Offset: 0x001CD11B
		private void Awake()
		{
			ObjectPoolsInitializers.Instance = this;
			this.InitializeObjectPools();
		}

		// Token: 0x06004698 RID: 18072 RVA: 0x001CED2C File Offset: 0x001CD12C
		private void InitializeObjectPools()
		{
			ObjectPoolManager.Instance.CreatePool(PoolType.CapableRecipe, this.GetPool(this.CapableRecipe, this.CapableRecipePoolSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.Item, this.GetPool(this.Item, this.CapableRecipePoolSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.HealthDetails, this.GetPool(this.HealthDetails, this.CapableRecipePoolSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.Resident, this.GetPool(this.VisitorPeasant, this.CapableRecipePoolSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.QueueItem, this.GetPool(this.QueueItem, this.QueueItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.RainDrop, this.GetPool(this.RainDrop, this.RainDropSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.DamagePopupText, this.GetPool(this.DamgePopupText, this.DamgePopupTextSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.MissPopupText, this.GetPool(this.MissPopupText, this.MissPopupTextSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.HealingPopupText, this.GetPool(this.HealingPopupText, this.HealingPopupTextSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.TextPopupText, this.GetPool(this.TextPopupText, this.TextPopupTextSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.HealthBar, this.GetPool(this.HealthBar, this.HealthBarSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.HealthBar, this.GetPool(this.HealthBar, this.HealthBarSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.ResidentEffectItem, this.GetPool(this.ResidentEffectItem, this.ResidentEffectItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.TravellerContributionItem, this.GetPool(this.TravellerContributionItem, this.TravellerContributionItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.ResidentItem, this.GetPool(this.ResidentItem, this.ResidentItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.CandidateItem, this.GetPool(this.CandidateItem, this.CandidateItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.StoredCandidateItem, this.GetPool(this.StoredCandidateItem, this.StoredCandidateItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.BattleEffectIcon, this.GetPool(this.BattleEffectIcon, this.BattleEffectIconSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.TownEffectItem, this.GetPool(this.TownEffectItem, this.TownEffectItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.TalentAttributeItem, this.GetPool(this.TalentAttributeItem, this.TalentAttributeItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.TalentSkillItem, this.GetPool(this.TalentSkillItem, this.TalentSkillItemSize));
			ObjectPoolManager.Instance.CreatePool(PoolType.LevelSelectionIcon, this.GetPool(this.LevelSelectionIcon, this.LevelSelectionIconSize));
		}

		// Token: 0x06004699 RID: 18073 RVA: 0x001CEFC4 File Offset: 0x001CD3C4
		public ObjectPool GetPool(GameObject poolGameObject, int poolSize)
		{
			return new ObjectPool(poolGameObject, poolSize, delegate(GameObject go)
			{
			});
		}

		// Token: 0x0600469A RID: 18074 RVA: 0x001CEFF7 File Offset: 0x001CD3F7
		[CompilerGenerated]
		private static void <GetPool>m__0(GameObject go)
		{
		}

		// Token: 0x04003577 RID: 13687
		public GameObject CapableRecipe;

		// Token: 0x04003578 RID: 13688
		public int CapableRecipePoolSize = 1;

		// Token: 0x04003579 RID: 13689
		public GameObject QueueItem;

		// Token: 0x0400357A RID: 13690
		public int QueueItemSize = 10;

		// Token: 0x0400357B RID: 13691
		public GameObject Item;

		// Token: 0x0400357C RID: 13692
		public int ItemPoolSize = 1;

		// Token: 0x0400357D RID: 13693
		public GameObject HealthDetails;

		// Token: 0x0400357E RID: 13694
		public int HealthDetailsSize = 2;

		// Token: 0x0400357F RID: 13695
		public GameObject VisitorPeasant;

		// Token: 0x04003580 RID: 13696
		public int VisitorPeasantSize = 2;

		// Token: 0x04003581 RID: 13697
		public GameObject RainDrop;

		// Token: 0x04003582 RID: 13698
		public int RainDropSize = 50;

		// Token: 0x04003583 RID: 13699
		public GameObject DamgePopupText;

		// Token: 0x04003584 RID: 13700
		public int DamgePopupTextSize = 20;

		// Token: 0x04003585 RID: 13701
		public GameObject HealingPopupText;

		// Token: 0x04003586 RID: 13702
		public int HealingPopupTextSize = 20;

		// Token: 0x04003587 RID: 13703
		public GameObject MissPopupText;

		// Token: 0x04003588 RID: 13704
		public int MissPopupTextSize = 20;

		// Token: 0x04003589 RID: 13705
		public GameObject TextPopupText;

		// Token: 0x0400358A RID: 13706
		public int TextPopupTextSize = 20;

		// Token: 0x0400358B RID: 13707
		public GameObject HealthBar;

		// Token: 0x0400358C RID: 13708
		public int HealthBarSize = 20;

		// Token: 0x0400358D RID: 13709
		public GameObject ResidentEffectItem;

		// Token: 0x0400358E RID: 13710
		public int ResidentEffectItemSize = 30;

		// Token: 0x0400358F RID: 13711
		public GameObject TravellerContributionItem;

		// Token: 0x04003590 RID: 13712
		public int TravellerContributionItemSize = 30;

		// Token: 0x04003591 RID: 13713
		public GameObject ResidentItem;

		// Token: 0x04003592 RID: 13714
		public int ResidentItemSize = 30;

		// Token: 0x04003593 RID: 13715
		public GameObject CandidateItem;

		// Token: 0x04003594 RID: 13716
		public int CandidateItemSize = 3;

		// Token: 0x04003595 RID: 13717
		public GameObject StoredCandidateItem;

		// Token: 0x04003596 RID: 13718
		public int StoredCandidateItemSize = 5;

		// Token: 0x04003597 RID: 13719
		public GameObject BattleEffectIcon;

		// Token: 0x04003598 RID: 13720
		public int BattleEffectIconSize = 20;

		// Token: 0x04003599 RID: 13721
		public GameObject TownEffectItem;

		// Token: 0x0400359A RID: 13722
		public int TownEffectItemSize = 15;

		// Token: 0x0400359B RID: 13723
		public GameObject TalentAttributeItem;

		// Token: 0x0400359C RID: 13724
		public int TalentAttributeItemSize = 10;

		// Token: 0x0400359D RID: 13725
		public GameObject TalentSkillItem;

		// Token: 0x0400359E RID: 13726
		public int TalentSkillItemSize = 6;

		// Token: 0x0400359F RID: 13727
		public GameObject LevelSelectionIcon;

		// Token: 0x040035A0 RID: 13728
		public int LevelSelectionIconSize = 200;

		// Token: 0x040035A1 RID: 13729
		public static ObjectPoolsInitializers Instance;

		// Token: 0x040035A2 RID: 13730
		[CompilerGenerated]
		private static Action<GameObject> <>f__am$cache0;
	}
}
