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
	// 配合 GetMaxLevel 改大上限时不爆 UI：格子数封顶 10。
	// dnSpy Edit Method 本方法，把 for 的循环变量改为封顶值：
	//   int displayMax = Math.Min(maxLevel, 10);
	//   for (int i = 0; i < displayMax; i++)
	// 说明：level 超过 10 后格子全亮（i+1 <= level 恒真），视觉效果=已满；
	//   GetGradientColor(i, maxLevel) 保留原 maxLevel，颜色渐变按真实上限走。
	// 影响面：全游戏只有 PageSkillController（学院技能页）调用本组件，不牵连其他 UI。
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
