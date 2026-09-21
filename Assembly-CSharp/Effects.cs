using System;
using System.Runtime.CompilerServices;
using ca.HenrySoftware;
using ca.HenrySoftware.Rage;
using UnityEngine;

// Token: 0x020000A7 RID: 167
[RequireComponent(typeof(Pool))]
public class Effects : MonoBehaviour
{
	// Token: 0x0600055F RID: 1375 RVA: 0x0005E857 File Offset: 0x0005CC57
	public Effects()
	{
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0005E860 File Offset: 0x0005CC60
	private void Awake()
	{
		this._materialNormal = new Material(Shader.Find("Sprites/Default"))
		{
			color = Color.white
		};
		this._materialAdditive = new Material(Shader.Find("Custom/Additive"))
		{
			color = Color.white
		};
		this._pool = base.GetComponent<Pool>();
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0005E8BD File Offset: 0x0005CCBD
	private void Start()
	{
		this.GroupText.alpha = 0f;
		this.Begin();
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0005E8D8 File Offset: 0x0005CCD8
	private void Begin()
	{
		Ease.Go(this, 0f, 1f, 1f, delegate(float p)
		{
			this.GroupText.alpha = p;
		}, new Action(this.Continue0), EaseType.Linear, 0f, 1, false, false);
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0005E91C File Offset: 0x0005CD1C
	private void Continue0()
	{
		Ease.Go(this, 1f, 0f, 1f, delegate(float p)
		{
			this.GroupText.alpha = p;
		}, null, EaseType.Linear, 0f, 1, false, false);
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0005E958 File Offset: 0x0005CD58
	private void Finish()
	{
		base.StopAllCoroutines();
		Ease.GoAlpha(this, 1f, 0f, 1f, null, null, EaseType.Linear, 0f, 1, false, false);
		Ease.Go(this, 1f, 0f, 1f, delegate(float p)
		{
			this.GroupText.alpha = p;
		}, new Action(this.Begin), EaseType.Linear, 0f, 1, false, false);
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0005E9C3 File Offset: 0x0005CDC3
	[ContextMenu("TriggerBlock")]
	public void TriggerBlock()
	{
		this.TriggerBlock(Vector2.zero);
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0005E9D0 File Offset: 0x0005CDD0
	public void TriggerBlock(Vector2 p)
	{
		this.Trigger(this.Block, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0005E9FC File Offset: 0x0005CDFC
	[ContextMenu("TriggerBox")]
	public void TriggerBox(bool alternate = false)
	{
		this.TriggerBox(alternate, Vector2.zero);
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0005EA0C File Offset: 0x0005CE0C
	public void TriggerBox(bool alternate, Vector2 p)
	{
		this.Trigger(this.Box, p, true, alternate, false, 0f, false, null);
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0005EA38 File Offset: 0x0005CE38
	[ContextMenu("TriggerBubble")]
	public void TriggerBubble()
	{
		this.TriggerBubble(Vector2.zero);
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0005EA48 File Offset: 0x0005CE48
	public void TriggerBubble(Vector2 p)
	{
		this.Trigger(this.Bubble, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0005EA74 File Offset: 0x0005CE74
	[ContextMenu("TriggerCircle")]
	public void TriggerCircle()
	{
		this.TriggerCircle(Vector2.zero);
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x0005EA84 File Offset: 0x0005CE84
	public void TriggerCircle(Vector2 p)
	{
		this.Trigger(this.Circle, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x0005EAB0 File Offset: 0x0005CEB0
	[ContextMenu("TriggerClaw")]
	public void TriggerClaw(bool alternate = false)
	{
		this.TriggerClaw(alternate, Vector2.zero);
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x0005EAC0 File Offset: 0x0005CEC0
	public void TriggerClaw(bool alternate, Vector2 p)
	{
		this.Trigger(this.Claw, p, true, alternate, false, 0f, false, null);
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x0005EAEC File Offset: 0x0005CEEC
	[ContextMenu("TriggerConsume")]
	public void TriggerConsume(float type = 0f)
	{
		this.TriggerConsume(type, Vector2.zero);
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x0005EAFC File Offset: 0x0005CEFC
	public void TriggerConsume(float type, Vector2 p)
	{
		this.Trigger(this.Consume, p, false, false, true, type, false, null);
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0005EB24 File Offset: 0x0005CF24
	[ContextMenu("TriggerDark")]
	public void TriggerDark()
	{
		this.TriggerDark(Vector2.zero);
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x0005EB34 File Offset: 0x0005CF34
	public void TriggerDark(Vector2 p)
	{
		this.Trigger(this.Dark, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x0005EB60 File Offset: 0x0005CF60
	[ContextMenu("TriggerEarth")]
	public void TriggerEarth()
	{
		this.TriggerEarth(Vector2.zero);
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x0005EB70 File Offset: 0x0005CF70
	public void TriggerEarth(Vector2 p)
	{
		this.Trigger(this.Earth, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x0005EB9C File Offset: 0x0005CF9C
	[ContextMenu("TriggerElectric")]
	public void TriggerElectric()
	{
		this.TriggerElectric(Vector2.zero);
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x0005EBAC File Offset: 0x0005CFAC
	public void TriggerElectric(Vector2 p)
	{
		this.Trigger(this.Electric, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x0005EBD8 File Offset: 0x0005CFD8
	[ContextMenu("TriggerExplode")]
	public void TriggerExplode(float type = 0f)
	{
		this.TriggerExplode(type, Vector2.zero);
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0005EBE8 File Offset: 0x0005CFE8
	public void TriggerExplode(float type, Vector2 p)
	{
		this.Trigger(this.Explode, p, false, false, true, type, false, null);
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x0005EC10 File Offset: 0x0005D010
	[ContextMenu("TriggerFire")]
	public void TriggerFire()
	{
		this.TriggerFire(Vector2.zero);
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x0005EC20 File Offset: 0x0005D020
	public void TriggerFire(Vector2 p)
	{
		this.Trigger(this.Fire, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x0005EC4C File Offset: 0x0005D04C
	[ContextMenu("TriggerGlint")]
	public void TriggerGlint()
	{
		this.TriggerGlint(Vector2.zero);
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x0005EC5C File Offset: 0x0005D05C
	public void TriggerGlint(Vector2 p)
	{
		this.Trigger(this.Glint, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x0005EC88 File Offset: 0x0005D088
	[ContextMenu("TriggerHeal")]
	public void TriggerHeal(bool alternate = false)
	{
		this.TriggerHeal(alternate, Vector2.zero);
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x0005EC98 File Offset: 0x0005D098
	public void TriggerHeal(bool alternate, Vector2 p)
	{
		this.Trigger(this.Heal, p, true, alternate, false, 0f, false, null);
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x0005ECC4 File Offset: 0x0005D0C4
	[ContextMenu("TriggerIce")]
	public void TriggerIce()
	{
		this.TriggerIce(Vector2.zero);
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x0005ECD4 File Offset: 0x0005D0D4
	public void TriggerIce(Vector2 p)
	{
		this.Trigger(this.Ice, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x0005ED00 File Offset: 0x0005D100
	[ContextMenu("TriggerLightning")]
	public void TriggerLightning()
	{
		this.TriggerLightning(Vector2.zero);
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x0005ED10 File Offset: 0x0005D110
	public void TriggerLightning(Vector2 p)
	{
		this.Trigger(this.Lightning, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x0005ED3C File Offset: 0x0005D13C
	[ContextMenu("TriggerNuclear")]
	public void TriggerNuclear()
	{
		this.TriggerNuclear(Vector2.zero);
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x0005ED4C File Offset: 0x0005D14C
	public void TriggerNuclear(Vector2 p)
	{
		this.Trigger(this.Nuclear, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x0005ED78 File Offset: 0x0005D178
	[ContextMenu("TriggerPoison")]
	public void TriggerPoison()
	{
		this.TriggerPoison(Vector2.zero);
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0005ED88 File Offset: 0x0005D188
	public void TriggerPoison(Vector2 p)
	{
		this.Trigger(this.Poison, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0005EDB4 File Offset: 0x0005D1B4
	[ContextMenu("TriggerPuff")]
	public void TriggerPuff()
	{
		this.TriggerPuff(Vector2.zero);
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x0005EDC4 File Offset: 0x0005D1C4
	public void TriggerPuff(Vector2 p)
	{
		this.Trigger(this.Puff, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x0005EDF0 File Offset: 0x0005D1F0
	[ContextMenu("TriggerShield")]
	public void TriggerShield()
	{
		this.TriggerShield(Vector2.zero);
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x0005EE00 File Offset: 0x0005D200
	public void TriggerShield(Vector2 p)
	{
		this.Trigger(this.Shield, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x0005EE2C File Offset: 0x0005D22C
	[ContextMenu("TriggerSlash")]
	public void TriggerSlash(float type = 0f)
	{
		this.TriggerSlash(type, Vector2.zero);
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x0005EE3C File Offset: 0x0005D23C
	public void TriggerSlash(float type, Vector2 p)
	{
		this.Trigger(this.Slash, p, false, false, true, type, false, null);
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x0005EE64 File Offset: 0x0005D264
	[ContextMenu("TriggerSparks")]
	public void TriggerSparks()
	{
		this.TriggerSparks(Vector2.zero);
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x0005EE74 File Offset: 0x0005D274
	public void TriggerSparks(Vector2 p)
	{
		this.Trigger(this.Sparks, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x0005EEA0 File Offset: 0x0005D2A0
	[ContextMenu("TriggerSplatterBlood")]
	public void TriggerSplatterBlood()
	{
		this.TriggerSplatterBlood(Vector2.zero);
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x0005EEB0 File Offset: 0x0005D2B0
	public void TriggerSplatterBlood(Vector2 p)
	{
		this.Trigger(this.SplatterBlood, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x0005EEDC File Offset: 0x0005D2DC
	[ContextMenu("TriggerSplatterSlime")]
	public void TriggerSplatterSlime(Color? color = null)
	{
		this.TriggerSplatterSlime(color, Vector2.zero);
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x0005EEEC File Offset: 0x0005D2EC
	public void TriggerSplatterSlime(Color? color, Vector2 p)
	{
		this.Trigger(this.SplatterSlime, p, false, false, false, 0f, true, color);
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x0005EF10 File Offset: 0x0005D310
	[ContextMenu("TriggerSquare")]
	public void TriggerSquare(bool alternate = false)
	{
		this.TriggerSquare(alternate, Vector2.zero);
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x0005EF20 File Offset: 0x0005D320
	public void TriggerSquare(bool alternate, Vector2 p)
	{
		this.Trigger(this.Square, p, true, alternate, false, 0f, false, null);
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x0005EF4C File Offset: 0x0005D34C
	[ContextMenu("TriggerStar")]
	public void TriggerStar()
	{
		this.TriggerStar(Vector2.zero);
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x0005EF5C File Offset: 0x0005D35C
	public void TriggerStar(Vector2 p)
	{
		this.Trigger(this.Star, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x0005EF88 File Offset: 0x0005D388
	[ContextMenu("TriggerTeleport")]
	public void TriggerTeleport()
	{
		this.TriggerTeleport(Vector2.zero);
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x0005EF98 File Offset: 0x0005D398
	public void TriggerTeleport(Vector2 p)
	{
		this.Trigger(this.Teleport, p, false, false, false, 0f, false, null);
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x0005EFC4 File Offset: 0x0005D3C4
	[ContextMenu("TriggerTouch")]
	public void TriggerTouch()
	{
		this.TriggerTouch(Vector2.zero, null);
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x0005EFE8 File Offset: 0x0005D3E8
	public void TriggerTouch(Vector2 p, Color? color = null)
	{
		this.Trigger(this.Touch, p, false, false, false, 0f, true, color);
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x0005F00C File Offset: 0x0005D40C
	[ContextMenu("TriggerWarp")]
	public void TriggerWarp()
	{
		this.TriggerWarp(Vector2.zero);
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x0005F01C File Offset: 0x0005D41C
	public void TriggerWarp(Vector2 p)
	{
		this.Trigger(this.Warp, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x0005F048 File Offset: 0x0005D448
	[ContextMenu("TriggerWater")]
	public void TriggerWater()
	{
		this.TriggerWater(Vector2.zero);
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x0005F058 File Offset: 0x0005D458
	public void TriggerWater(Vector2 p)
	{
		this.Trigger(this.Water, p, false, false, false, 0f, false, null);
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x0005F084 File Offset: 0x0005D484
	[ContextMenu("TriggerWeb")]
	public void TriggerWeb()
	{
		this.TriggerWeb(Vector2.zero);
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x0005F094 File Offset: 0x0005D494
	public void TriggerWeb(Vector2 p)
	{
		this.Trigger(this.Web, p, false, false, false, 0f, false, null);
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0005F0C0 File Offset: 0x0005D4C0
	public void Trigger(ModelEffectAnimation model, Vector2 p, bool setAlternate = false, bool alternate = false, bool setType = false, float type = 0f, bool setColor = false, Color? color = null)
	{
		GameObject gameObject = this._pool.Enter();
		gameObject.transform.localPosition = new Vector3(p.x, p.y, base.transform.localPosition.z);
		gameObject.transform.localScale = Vector3.one;
		SpriteRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer spriteRenderer in componentsInChildren)
		{
			spriteRenderer.color = ((!setColor || color == null || color == null) ? Color.white : color.Value);
			spriteRenderer.material = ((!model.Blend) ? this._materialNormal : this._materialAdditive);
		}
		componentsInChildren[1].transform.localPosition = model.BackOffset;
		componentsInChildren[1].sortingOrder = -1;
		componentsInChildren[2].transform.localPosition = model.ForeOffset;
		componentsInChildren[2].sortingOrder = 2;
		componentsInChildren[0].transform.localPosition = model.Offset;
		componentsInChildren[0].sortingOrder = 1;
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		componentInChildren.runtimeAnimatorController = model.Controller;
		if (setAlternate)
		{
			componentInChildren.SetBool(Effects.AnimatorAlternate, alternate);
		}
		if (setType)
		{
			componentInChildren.SetFloat(Effects.AnimatorType, type);
		}
		componentInChildren.SetTrigger(Effects.AnimatorTrigger);
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x0005F248 File Offset: 0x0005D648
	public void Exit(GameObject o)
	{
		this._pool.Exit(o);
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x0005F256 File Offset: 0x0005D656
	// Note: this type is marked as 'beforefieldinit'.
	static Effects()
	{
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x0005F285 File Offset: 0x0005D685
	[CompilerGenerated]
	private void <Begin>m__0(float p)
	{
		this.GroupText.alpha = p;
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x0005F293 File Offset: 0x0005D693
	[CompilerGenerated]
	private void <Continue0>m__1(float p)
	{
		this.GroupText.alpha = p;
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x0005F2A1 File Offset: 0x0005D6A1
	[CompilerGenerated]
	private void <Finish>m__2(float p)
	{
		this.GroupText.alpha = p;
	}

	// Token: 0x04000893 RID: 2195
	public CanvasGroup GroupText;

	// Token: 0x04000894 RID: 2196
	public ModelEffectAnimation Block;

	// Token: 0x04000895 RID: 2197
	public ModelEffectAnimation Box;

	// Token: 0x04000896 RID: 2198
	public ModelEffectAnimation Bubble;

	// Token: 0x04000897 RID: 2199
	public ModelEffectAnimation Circle;

	// Token: 0x04000898 RID: 2200
	public ModelEffectAnimation Claw;

	// Token: 0x04000899 RID: 2201
	public ModelEffectAnimation Consume;

	// Token: 0x0400089A RID: 2202
	public ModelEffectAnimation Dark;

	// Token: 0x0400089B RID: 2203
	public ModelEffectAnimation Earth;

	// Token: 0x0400089C RID: 2204
	public ModelEffectAnimation Electric;

	// Token: 0x0400089D RID: 2205
	public ModelEffectAnimation Explode;

	// Token: 0x0400089E RID: 2206
	public ModelEffectAnimation Fire;

	// Token: 0x0400089F RID: 2207
	public ModelEffectAnimation Footprints;

	// Token: 0x040008A0 RID: 2208
	public ModelEffectAnimation Glint;

	// Token: 0x040008A1 RID: 2209
	public ModelEffectAnimation Heal;

	// Token: 0x040008A2 RID: 2210
	public ModelEffectAnimation Ice;

	// Token: 0x040008A3 RID: 2211
	public ModelEffectAnimation Lightning;

	// Token: 0x040008A4 RID: 2212
	public ModelEffectAnimation Nuclear;

	// Token: 0x040008A5 RID: 2213
	public ModelEffectAnimation Poison;

	// Token: 0x040008A6 RID: 2214
	public ModelEffectAnimation Puff;

	// Token: 0x040008A7 RID: 2215
	public ModelEffectAnimation Shield;

	// Token: 0x040008A8 RID: 2216
	public ModelEffectAnimation Slash;

	// Token: 0x040008A9 RID: 2217
	public ModelEffectAnimation Sparks;

	// Token: 0x040008AA RID: 2218
	public ModelEffectAnimation SplatterBlood;

	// Token: 0x040008AB RID: 2219
	public ModelEffectAnimation SplatterSlime;

	// Token: 0x040008AC RID: 2220
	public ModelEffectAnimation Square;

	// Token: 0x040008AD RID: 2221
	public ModelEffectAnimation Star;

	// Token: 0x040008AE RID: 2222
	public ModelEffectAnimation Teleport;

	// Token: 0x040008AF RID: 2223
	public ModelEffectAnimation Touch;

	// Token: 0x040008B0 RID: 2224
	public ModelEffectAnimation Warp;

	// Token: 0x040008B1 RID: 2225
	public ModelEffectAnimation Water;

	// Token: 0x040008B2 RID: 2226
	public ModelEffectAnimation Web;

	// Token: 0x040008B3 RID: 2227
	private Pool _pool;

	// Token: 0x040008B4 RID: 2228
	private Material _materialNormal;

	// Token: 0x040008B5 RID: 2229
	private Material _materialAdditive;

	// Token: 0x040008B6 RID: 2230
	public static int AnimatorTrigger = Animator.StringToHash("Trigger");

	// Token: 0x040008B7 RID: 2231
	public static int AnimatorAlternate = Animator.StringToHash("Alternate");

	// Token: 0x040008B8 RID: 2232
	public static int AnimatorType = Animator.StringToHash("Type");
}
