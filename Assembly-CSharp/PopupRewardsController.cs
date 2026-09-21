using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class PopupRewardsController : MonoBehaviour
{
	// Token: 0x060018B4 RID: 6324 RVA: 0x000BEE49 File Offset: 0x000BD249
	public PopupRewardsController()
	{
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x000BEE51 File Offset: 0x000BD251
	private void Awake()
	{
		if (PopupRewardsController.Instance == null)
		{
			PopupRewardsController.Instance = this;
		}
	}

	// Token: 0x060018B6 RID: 6326 RVA: 0x000BEE6C File Offset: 0x000BD26C
	public static PopingUpRewards CreateNewRewardPopup(Transform location, int index, Chest chest, bool isFading)
	{
		if (PopupRewardsController._popingUpRewards == null)
		{
			PopupRewardsController._popingUpRewards = (Resources.Load("Prefabs/Eric/Battle/Chest/PopupItems/FadingReward") as GameObject);
			PopupRewardsController._canvas = location.GetComponentInChildren<Canvas>().gameObject;
		}
		GameObject gameObject = GameObjectUtil.Instantiate(PopupRewardsController._popingUpRewards, location.position, PopupRewardsController._canvas);
		gameObject.transform.SetParent(PopupRewardsController._canvas.transform, false);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.position = location.position;
		PopingUpRewards component = gameObject.GetComponent<PopingUpRewards>();
		component.SetupImage(chest, isFading);
		return component;
	}

	// Token: 0x0400188D RID: 6285
	public static PopupRewardsController Instance;

	// Token: 0x0400188E RID: 6286
	private static GameObject _popingUpRewards;

	// Token: 0x0400188F RID: 6287
	private static GameObject _canvas;
}
