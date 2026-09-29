using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000253 RID: 595
public class LevelBarController : MonoBehaviour
{
	// Token: 0x06000F74 RID: 3956 RVA: 0x00094980 File Offset: 0x00092D80
	public LevelBarController()
	{
	}

	// Token: 0x06000F75 RID: 3957 RVA: 0x00094988 File Offset: 0x00092D88
	// ==================== MOD 标记 2026-09-29 ====================
	// 配合 GetMaxLevel 改大上限时不爆 UI：格子数封顶。
	// ⚠️ 双 9 坑（必看）：ColorPicker.GetGradientColor 只认 listSize 3 和 9，
	//   其他值直接 throw Exception（GetMaxLevel 改 99 后传 99 → 学院打开即崩）；
	//   颜色表 Gradients 只有 9 色（索引 0~8），循环超 9 会数组越界。
	// dnSpy Edit Method 本方法，改成：
	//   int displayMax = Math.Min(maxLevel, 9);
	//   for (int i = 0; i < displayMax; i++)
	//   ... component.Init(i + 1 <= level, ColorPicker.GetGradientColor(i, 9));
	// 影响面：全游戏只有 PageSkillController（学院技能页）调用本组件。
	// =============================================================
	public void Init(int level, int maxLevel)
	{
		this.ResetBar();
		for (int i = 0; i < maxLevel; i++)
		{
			SkillColorBlockController component = UnityEngine.Object.Instantiate<GameObject>(this.ColorBlockPre).GetComponent<SkillColorBlockController>();
			component.transform.SetParent(base.transform, false);
			component.Init(i + 1 <= level, ColorPicker.GetGradientColor(i, maxLevel));
		}
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x000949E8 File Offset: 0x00092DE8
	public void ResetBar()
	{
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
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

	// Token: 0x040010BB RID: 4283
	public GameObject ColorBlockPre;
}
