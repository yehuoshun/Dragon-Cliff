using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A2 RID: 162
	public static class Ease3
	{
		// Token: 0x060004FE RID: 1278 RVA: 0x0005AAF4 File Offset: 0x00058EF4
		public static IEnumerator Go(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease3.GoCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0005AB24 File Offset: 0x00058F24
		private static IEnumerator GoCoroutine(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease3.Types[type](from, to, Mathf.Clamp01(t)));
					yield return null;
				}
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						update(Ease3.Types[type](to, from, Mathf.Clamp01(t)));
						yield return null;
					}
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0005AB88 File Offset: 0x00058F88
		public static IEnumerator GoPositionTo(MonoBehaviour m, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease3.GoPosition(m, m.transform.localPosition, to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0005ABB8 File Offset: 0x00058FB8
		public static IEnumerator GoPositionBy(MonoBehaviour m, Vector3 by, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			Vector3 localPosition = m.transform.localPosition;
			return Ease3.GoPosition(m, localPosition, localPosition + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0005ABF0 File Offset: 0x00058FF0
		public static IEnumerator GoPosition(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease3.GoPositionCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0005AC20 File Offset: 0x00059020
		private static IEnumerator GoPositionCoroutine(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					Vector3 p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localPosition = p;
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				m.transform.localPosition = to;
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						Vector3 p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
						m.transform.localPosition = p2;
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					m.transform.localPosition = from;
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0005AC88 File Offset: 0x00059088
		public static IEnumerator GoRotationTo(MonoBehaviour m, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease3.GoRotation(m, m.transform.localEulerAngles, to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0005ACB8 File Offset: 0x000590B8
		public static IEnumerator GoRotationBy(MonoBehaviour m, Vector3 by, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			Vector3 localEulerAngles = m.transform.localEulerAngles;
			return Ease3.GoRotation(m, localEulerAngles, localEulerAngles + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0005ACF0 File Offset: 0x000590F0
		public static IEnumerator GoRotation(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease3.GoRotationCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0005AD20 File Offset: 0x00059120
		private static IEnumerator GoRotationCoroutine(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					Vector3 p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localEulerAngles = p;
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				m.transform.localEulerAngles = to;
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						Vector3 p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
						m.transform.localEulerAngles = p2;
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					m.transform.localEulerAngles = from;
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0005AD88 File Offset: 0x00059188
		public static IEnumerator GoScaleTo(MonoBehaviour m, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease3.GoScale(m, m.transform.localScale, to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0005ADB8 File Offset: 0x000591B8
		public static IEnumerator GoScaleBy(MonoBehaviour m, Vector3 by, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			Vector3 localScale = m.transform.localScale;
			return Ease3.GoScale(m, localScale, localScale + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0005ADF0 File Offset: 0x000591F0
		public static IEnumerator GoScale(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease3.GoScaleCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0005AE20 File Offset: 0x00059220
		private static IEnumerator GoScaleCoroutine(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			float last = Time.unscaledTime;
			Func<float> deltaTime = delegate()
			{
				float unscaledTime = Time.unscaledTime;
				float result = unscaledTime - last;
				last = unscaledTime;
				return result;
			};
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : deltaTime()) / time;
					Vector3 p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localScale = p;
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				m.transform.localScale = to;
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : deltaTime()) / time;
						Vector3 p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
						m.transform.localScale = p2;
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					m.transform.localScale = from;
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0005AE88 File Offset: 0x00059288
		private static Color GetColor(MonoBehaviour m)
		{
			Image component = m.GetComponent<Image>();
			return (!(component == null)) ? component.color : Camera.main.backgroundColor;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0005AEC0 File Offset: 0x000592C0
		public static IEnumerator GoColorTo(MonoBehaviour m, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			return Ease3.GoColor(m, Ease3.GetColor(m).GetVector3(), to, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0005AEF0 File Offset: 0x000592F0
		public static IEnumerator GoColorBy(MonoBehaviour m, Vector3 by, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			Vector3 vector = Ease3.GetColor(m).GetVector3();
			return Ease3.GoColor(m, vector, vector + by, time, update, complete, type, delay, repeat, pingPong, realTime);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0005AF28 File Offset: 0x00059328
		public static IEnumerator GoColor(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update = null, Action complete = null, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false)
		{
			IEnumerator enumerator = Ease3.GoColorCoroutine(m, from, to, time, update, complete, type, delay, repeat, pingPong, realTime);
			m.StartCoroutine(enumerator);
			return enumerator;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0005AF58 File Offset: 0x00059358
		private static IEnumerator GoColorCoroutine(MonoBehaviour m, Vector3 from, Vector3 to, float time, Action<Vector3> update, Action complete, EaseType type, float delay, int repeat, bool pingPong, bool realTime)
		{
			Image image = m.GetComponent<Image>();
			Camera camera = Camera.main;
			Action<Vector3> setColor = delegate(Vector3 value)
			{
				if (image == null)
				{
					camera.backgroundColor = value.GetColor().SetAlpha(camera.backgroundColor.a);
				}
				else
				{
					image.color = value.GetColor().SetAlpha(image.color.a);
				}
			};
			int counter = repeat;
			while (repeat == 0 || repeat == -1 || counter > 0)
			{
				if (delay > 0f)
				{
					if (realTime)
					{
						yield return new WaitForSecondsRealtime(delay);
					}
					else
					{
						yield return new WaitForSeconds(delay);
					}
				}
				float t = 0f;
				while (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					Vector3 p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					setColor(p);
					if (update != null)
					{
						update(p);
					}
					yield return null;
				}
				setColor(to);
				if (pingPong)
				{
					if (delay > 0f)
					{
						if (realTime)
						{
							yield return new WaitForSecondsRealtime(delay);
						}
						else
						{
							yield return new WaitForSeconds(delay);
						}
					}
					t = 0f;
					while (t <= 1f)
					{
						t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
						Vector3 p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
						setColor(p2);
						if (update != null)
						{
							update(p2);
						}
						yield return null;
					}
					setColor(from);
				}
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
			}
			if (repeat != 0 && complete != null)
			{
				complete();
			}
			yield break;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0005AFC0 File Offset: 0x000593C0
		// Note: this type is marked as 'beforefieldinit'.
		static Ease3()
		{
			Dictionary<EaseType, Func<Vector3, Vector3, float, Vector3>> dictionary = new Dictionary<EaseType, Func<Vector3, Vector3, float, Vector3>>();
			Dictionary<EaseType, Func<Vector3, Vector3, float, Vector3>> dictionary2 = dictionary;
			EaseType key = EaseType.Linear;
			if (Ease3.<>f__mg$cache0 == null)
			{
				Ease3.<>f__mg$cache0 = new Func<Vector3, Vector3, float, Vector3>(Vector3.Lerp);
			}
			dictionary2.Add(key, Ease3.<>f__mg$cache0);
			dictionary.Add(EaseType.SineIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.SineIn(from.x, to.x, time), Ease.SineIn(from.y, to.y, time), Ease.SineIn(from.z, to.z, time)));
			dictionary.Add(EaseType.SineOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.SineOut(from.x, to.x, time), Ease.SineOut(from.y, to.y, time), Ease.SineOut(from.z, to.z, time)));
			dictionary.Add(EaseType.SineInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.SineInOut(from.x, to.x, time), Ease.SineInOut(from.y, to.y, time), Ease.SineInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuadIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuadIn(from.x, to.x, time), Ease.QuadIn(from.y, to.y, time), Ease.QuadIn(from.z, to.z, time)));
			dictionary.Add(EaseType.QuadOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuadOut(from.x, to.x, time), Ease.QuadOut(from.y, to.y, time), Ease.QuadOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuadInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuadInOut(from.x, to.x, time), Ease.QuadInOut(from.y, to.y, time), Ease.QuadInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.CubicIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CubicIn(from.x, to.x, time), Ease.CubicIn(from.y, to.y, time), Ease.CubicIn(from.z, to.z, time)));
			dictionary.Add(EaseType.CubicOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CubicOut(from.x, to.x, time), Ease.CubicOut(from.y, to.y, time), Ease.CubicOut(from.z, to.z, time)));
			dictionary.Add(EaseType.CubicInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CubicInOut(from.x, to.x, time), Ease.CubicInOut(from.y, to.y, time), Ease.CubicInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuartIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuartIn(from.x, to.x, time), Ease.QuartIn(from.y, to.y, time), Ease.QuartIn(from.z, to.z, time)));
			dictionary.Add(EaseType.QuartOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuartOut(from.x, to.x, time), Ease.QuartOut(from.y, to.y, time), Ease.QuartOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuartInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuartInOut(from.x, to.x, time), Ease.QuartInOut(from.y, to.y, time), Ease.QuartInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuintIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuintIn(from.x, to.x, time), Ease.QuintIn(from.y, to.y, time), Ease.QuintIn(from.z, to.z, time)));
			dictionary.Add(EaseType.QuintOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuintOut(from.x, to.x, time), Ease.QuintOut(from.y, to.y, time), Ease.QuintOut(from.z, to.z, time)));
			dictionary.Add(EaseType.QuintInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.QuintInOut(from.x, to.x, time), Ease.QuintInOut(from.y, to.y, time), Ease.QuintInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.ExpoIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ExpoIn(from.x, to.x, time), Ease.ExpoIn(from.y, to.y, time), Ease.ExpoIn(from.z, to.z, time)));
			dictionary.Add(EaseType.ExpoOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ExpoOut(from.x, to.x, time), Ease.ExpoOut(from.y, to.y, time), Ease.ExpoOut(from.z, to.z, time)));
			dictionary.Add(EaseType.ExpoInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ExpoInOut(from.x, to.x, time), Ease.ExpoInOut(from.y, to.y, time), Ease.ExpoInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.CircIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CircIn(from.x, to.x, time), Ease.CircIn(from.y, to.y, time), Ease.CircIn(from.z, to.z, time)));
			dictionary.Add(EaseType.CircOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CircOut(from.x, to.x, time), Ease.CircOut(from.y, to.y, time), Ease.CircOut(from.z, to.z, time)));
			dictionary.Add(EaseType.CircInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.CircInOut(from.x, to.x, time), Ease.CircInOut(from.y, to.y, time), Ease.CircInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.BackIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BackIn(from.x, to.x, time), Ease.BackIn(from.y, to.y, time), Ease.BackIn(from.z, to.z, time)));
			dictionary.Add(EaseType.BackOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BackOut(from.x, to.x, time), Ease.BackOut(from.y, to.y, time), Ease.BackOut(from.z, to.z, time)));
			dictionary.Add(EaseType.BackInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BackInOut(from.x, to.x, time), Ease.BackInOut(from.y, to.y, time), Ease.BackInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.ElasticIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ElasticIn(from.x, to.x, time), Ease.ElasticIn(from.y, to.y, time), Ease.ElasticIn(from.z, to.z, time)));
			dictionary.Add(EaseType.ElasticOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ElasticOut(from.x, to.x, time), Ease.ElasticOut(from.y, to.y, time), Ease.ElasticOut(from.z, to.z, time)));
			dictionary.Add(EaseType.ElasticInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.ElasticInOut(from.x, to.x, time), Ease.ElasticInOut(from.y, to.y, time), Ease.ElasticInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.BounceIn, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BounceIn(from.x, to.x, time), Ease.BounceIn(from.y, to.y, time), Ease.BounceIn(from.z, to.z, time)));
			dictionary.Add(EaseType.BounceOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BounceOut(from.x, to.x, time), Ease.BounceOut(from.y, to.y, time), Ease.BounceOut(from.z, to.z, time)));
			dictionary.Add(EaseType.BounceInOut, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.BounceInOut(from.x, to.x, time), Ease.BounceInOut(from.y, to.y, time), Ease.BounceInOut(from.z, to.z, time)));
			dictionary.Add(EaseType.Spring, (Vector3 from, Vector3 to, float time) => new Vector3(Ease.Spring(from.x, to.x, time), Ease.Spring(from.y, to.y, time), Ease.Spring(from.z, to.z, time)));
			Ease3.Types = dictionary;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0005B264 File Offset: 0x00059664
		[CompilerGenerated]
		private static Vector3 <Types>m__0(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.SineIn(from.x, to.x, time), Ease.SineIn(from.y, to.y, time), Ease.SineIn(from.z, to.z, time));
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0005B2B4 File Offset: 0x000596B4
		[CompilerGenerated]
		private static Vector3 <Types>m__1(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.SineOut(from.x, to.x, time), Ease.SineOut(from.y, to.y, time), Ease.SineOut(from.z, to.z, time));
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0005B304 File Offset: 0x00059704
		[CompilerGenerated]
		private static Vector3 <Types>m__2(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.SineInOut(from.x, to.x, time), Ease.SineInOut(from.y, to.y, time), Ease.SineInOut(from.z, to.z, time));
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0005B354 File Offset: 0x00059754
		[CompilerGenerated]
		private static Vector3 <Types>m__3(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuadIn(from.x, to.x, time), Ease.QuadIn(from.y, to.y, time), Ease.QuadIn(from.z, to.z, time));
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0005B3A4 File Offset: 0x000597A4
		[CompilerGenerated]
		private static Vector3 <Types>m__4(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuadOut(from.x, to.x, time), Ease.QuadOut(from.y, to.y, time), Ease.QuadOut(from.z, to.z, time));
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0005B3F4 File Offset: 0x000597F4
		[CompilerGenerated]
		private static Vector3 <Types>m__5(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuadInOut(from.x, to.x, time), Ease.QuadInOut(from.y, to.y, time), Ease.QuadInOut(from.z, to.z, time));
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0005B444 File Offset: 0x00059844
		[CompilerGenerated]
		private static Vector3 <Types>m__6(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CubicIn(from.x, to.x, time), Ease.CubicIn(from.y, to.y, time), Ease.CubicIn(from.z, to.z, time));
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0005B494 File Offset: 0x00059894
		[CompilerGenerated]
		private static Vector3 <Types>m__7(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CubicOut(from.x, to.x, time), Ease.CubicOut(from.y, to.y, time), Ease.CubicOut(from.z, to.z, time));
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0005B4E4 File Offset: 0x000598E4
		[CompilerGenerated]
		private static Vector3 <Types>m__8(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CubicInOut(from.x, to.x, time), Ease.CubicInOut(from.y, to.y, time), Ease.CubicInOut(from.z, to.z, time));
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0005B534 File Offset: 0x00059934
		[CompilerGenerated]
		private static Vector3 <Types>m__9(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuartIn(from.x, to.x, time), Ease.QuartIn(from.y, to.y, time), Ease.QuartIn(from.z, to.z, time));
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0005B584 File Offset: 0x00059984
		[CompilerGenerated]
		private static Vector3 <Types>m__A(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuartOut(from.x, to.x, time), Ease.QuartOut(from.y, to.y, time), Ease.QuartOut(from.z, to.z, time));
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0005B5D4 File Offset: 0x000599D4
		[CompilerGenerated]
		private static Vector3 <Types>m__B(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuartInOut(from.x, to.x, time), Ease.QuartInOut(from.y, to.y, time), Ease.QuartInOut(from.z, to.z, time));
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0005B624 File Offset: 0x00059A24
		[CompilerGenerated]
		private static Vector3 <Types>m__C(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuintIn(from.x, to.x, time), Ease.QuintIn(from.y, to.y, time), Ease.QuintIn(from.z, to.z, time));
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0005B674 File Offset: 0x00059A74
		[CompilerGenerated]
		private static Vector3 <Types>m__D(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuintOut(from.x, to.x, time), Ease.QuintOut(from.y, to.y, time), Ease.QuintOut(from.z, to.z, time));
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0005B6C4 File Offset: 0x00059AC4
		[CompilerGenerated]
		private static Vector3 <Types>m__E(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.QuintInOut(from.x, to.x, time), Ease.QuintInOut(from.y, to.y, time), Ease.QuintInOut(from.z, to.z, time));
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0005B714 File Offset: 0x00059B14
		[CompilerGenerated]
		private static Vector3 <Types>m__F(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ExpoIn(from.x, to.x, time), Ease.ExpoIn(from.y, to.y, time), Ease.ExpoIn(from.z, to.z, time));
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0005B764 File Offset: 0x00059B64
		[CompilerGenerated]
		private static Vector3 <Types>m__10(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ExpoOut(from.x, to.x, time), Ease.ExpoOut(from.y, to.y, time), Ease.ExpoOut(from.z, to.z, time));
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0005B7B4 File Offset: 0x00059BB4
		[CompilerGenerated]
		private static Vector3 <Types>m__11(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ExpoInOut(from.x, to.x, time), Ease.ExpoInOut(from.y, to.y, time), Ease.ExpoInOut(from.z, to.z, time));
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0005B804 File Offset: 0x00059C04
		[CompilerGenerated]
		private static Vector3 <Types>m__12(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CircIn(from.x, to.x, time), Ease.CircIn(from.y, to.y, time), Ease.CircIn(from.z, to.z, time));
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0005B854 File Offset: 0x00059C54
		[CompilerGenerated]
		private static Vector3 <Types>m__13(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CircOut(from.x, to.x, time), Ease.CircOut(from.y, to.y, time), Ease.CircOut(from.z, to.z, time));
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0005B8A4 File Offset: 0x00059CA4
		[CompilerGenerated]
		private static Vector3 <Types>m__14(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.CircInOut(from.x, to.x, time), Ease.CircInOut(from.y, to.y, time), Ease.CircInOut(from.z, to.z, time));
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0005B8F4 File Offset: 0x00059CF4
		[CompilerGenerated]
		private static Vector3 <Types>m__15(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BackIn(from.x, to.x, time), Ease.BackIn(from.y, to.y, time), Ease.BackIn(from.z, to.z, time));
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0005B944 File Offset: 0x00059D44
		[CompilerGenerated]
		private static Vector3 <Types>m__16(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BackOut(from.x, to.x, time), Ease.BackOut(from.y, to.y, time), Ease.BackOut(from.z, to.z, time));
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0005B994 File Offset: 0x00059D94
		[CompilerGenerated]
		private static Vector3 <Types>m__17(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BackInOut(from.x, to.x, time), Ease.BackInOut(from.y, to.y, time), Ease.BackInOut(from.z, to.z, time));
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0005B9E4 File Offset: 0x00059DE4
		[CompilerGenerated]
		private static Vector3 <Types>m__18(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ElasticIn(from.x, to.x, time), Ease.ElasticIn(from.y, to.y, time), Ease.ElasticIn(from.z, to.z, time));
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0005BA34 File Offset: 0x00059E34
		[CompilerGenerated]
		private static Vector3 <Types>m__19(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ElasticOut(from.x, to.x, time), Ease.ElasticOut(from.y, to.y, time), Ease.ElasticOut(from.z, to.z, time));
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0005BA84 File Offset: 0x00059E84
		[CompilerGenerated]
		private static Vector3 <Types>m__1A(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.ElasticInOut(from.x, to.x, time), Ease.ElasticInOut(from.y, to.y, time), Ease.ElasticInOut(from.z, to.z, time));
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0005BAD4 File Offset: 0x00059ED4
		[CompilerGenerated]
		private static Vector3 <Types>m__1B(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BounceIn(from.x, to.x, time), Ease.BounceIn(from.y, to.y, time), Ease.BounceIn(from.z, to.z, time));
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0005BB24 File Offset: 0x00059F24
		[CompilerGenerated]
		private static Vector3 <Types>m__1C(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BounceOut(from.x, to.x, time), Ease.BounceOut(from.y, to.y, time), Ease.BounceOut(from.z, to.z, time));
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0005BB74 File Offset: 0x00059F74
		[CompilerGenerated]
		private static Vector3 <Types>m__1D(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.BounceInOut(from.x, to.x, time), Ease.BounceInOut(from.y, to.y, time), Ease.BounceInOut(from.z, to.z, time));
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0005BBC4 File Offset: 0x00059FC4
		[CompilerGenerated]
		private static Vector3 <Types>m__1E(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(Ease.Spring(from.x, to.x, time), Ease.Spring(from.y, to.y, time), Ease.Spring(from.z, to.z, time));
		}

		// Token: 0x0400088E RID: 2190
		private static readonly Dictionary<EaseType, Func<Vector3, Vector3, float, Vector3>> Types;

		// Token: 0x0400088F RID: 2191
		[CompilerGenerated]
		private static Func<Vector3, Vector3, float, Vector3> <>f__mg$cache0;

		// Token: 0x02000BB9 RID: 3001
		[CompilerGenerated]
		private sealed class <GoCoroutine>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FA6 RID: 20390 RVA: 0x0005BC12 File Offset: 0x0005A012
			[DebuggerHidden]
			public <GoCoroutine>c__Iterator0()
			{
			}

			// Token: 0x06004FA7 RID: 20391 RVA: 0x0005BC1C File Offset: 0x0005A01C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					counter = repeat;
					goto IL_2AB;
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_140;
				case 4u:
					goto IL_1C5;
				case 5u:
					goto IL_1C5;
				case 6u:
					goto IL_255;
				default:
					return false;
				}
				IL_B0:
				t = 0f;
				IL_140:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease3.Types[type](from, to, Mathf.Clamp01(t)));
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				if (!pingPong)
				{
					goto IL_265;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_1C5:
				t = 0f;
				IL_255:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					update(Ease3.Types[type](to, from, Mathf.Clamp01(t)));
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				IL_265:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_2AB:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_B0;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010E2 RID: 4322
			// (get) Token: 0x06004FA8 RID: 20392 RVA: 0x0005BF22 File Offset: 0x0005A322
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010E3 RID: 4323
			// (get) Token: 0x06004FA9 RID: 20393 RVA: 0x0005BF2A File Offset: 0x0005A32A
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FAA RID: 20394 RVA: 0x0005BF32 File Offset: 0x0005A332
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FAB RID: 20395 RVA: 0x0005BF42 File Offset: 0x0005A342
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D66 RID: 15718
			internal int repeat;

			// Token: 0x04003D67 RID: 15719
			internal int <counter>__0;

			// Token: 0x04003D68 RID: 15720
			internal float delay;

			// Token: 0x04003D69 RID: 15721
			internal bool realTime;

			// Token: 0x04003D6A RID: 15722
			internal float <t>__1;

			// Token: 0x04003D6B RID: 15723
			internal float time;

			// Token: 0x04003D6C RID: 15724
			internal Action<Vector3> update;

			// Token: 0x04003D6D RID: 15725
			internal EaseType type;

			// Token: 0x04003D6E RID: 15726
			internal Vector3 from;

			// Token: 0x04003D6F RID: 15727
			internal Vector3 to;

			// Token: 0x04003D70 RID: 15728
			internal bool pingPong;

			// Token: 0x04003D71 RID: 15729
			internal Action complete;

			// Token: 0x04003D72 RID: 15730
			internal object $current;

			// Token: 0x04003D73 RID: 15731
			internal bool $disposing;

			// Token: 0x04003D74 RID: 15732
			internal int $PC;
		}

		// Token: 0x02000BBA RID: 3002
		[CompilerGenerated]
		private sealed class <GoPositionCoroutine>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FAC RID: 20396 RVA: 0x0005BF49 File Offset: 0x0005A349
			[DebuggerHidden]
			public <GoPositionCoroutine>c__Iterator1()
			{
			}

			// Token: 0x06004FAD RID: 20397 RVA: 0x0005BF54 File Offset: 0x0005A354
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					counter = repeat;
					goto IL_331;
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_16D;
				case 4u:
					goto IL_208;
				case 5u:
					goto IL_208;
				case 6u:
					goto IL_2C5;
				default:
					return false;
				}
				IL_B0:
				t = 0f;
				IL_16D:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localPosition = p;
					if (update != null)
					{
						update(p);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				m.transform.localPosition = to;
				if (!pingPong)
				{
					goto IL_2EB;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_208:
				t = 0f;
				IL_2C5:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
					m.transform.localPosition = p2;
					if (update != null)
					{
						update(p2);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				m.transform.localPosition = from;
				IL_2EB:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_331:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_B0;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010E4 RID: 4324
			// (get) Token: 0x06004FAE RID: 20398 RVA: 0x0005C2E0 File Offset: 0x0005A6E0
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010E5 RID: 4325
			// (get) Token: 0x06004FAF RID: 20399 RVA: 0x0005C2E8 File Offset: 0x0005A6E8
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FB0 RID: 20400 RVA: 0x0005C2F0 File Offset: 0x0005A6F0
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FB1 RID: 20401 RVA: 0x0005C300 File Offset: 0x0005A700
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D75 RID: 15733
			internal int repeat;

			// Token: 0x04003D76 RID: 15734
			internal int <counter>__0;

			// Token: 0x04003D77 RID: 15735
			internal float delay;

			// Token: 0x04003D78 RID: 15736
			internal bool realTime;

			// Token: 0x04003D79 RID: 15737
			internal float <t>__1;

			// Token: 0x04003D7A RID: 15738
			internal float time;

			// Token: 0x04003D7B RID: 15739
			internal EaseType type;

			// Token: 0x04003D7C RID: 15740
			internal Vector3 from;

			// Token: 0x04003D7D RID: 15741
			internal Vector3 to;

			// Token: 0x04003D7E RID: 15742
			internal Vector3 <p>__2;

			// Token: 0x04003D7F RID: 15743
			internal MonoBehaviour m;

			// Token: 0x04003D80 RID: 15744
			internal Action<Vector3> update;

			// Token: 0x04003D81 RID: 15745
			internal bool pingPong;

			// Token: 0x04003D82 RID: 15746
			internal Vector3 <p>__3;

			// Token: 0x04003D83 RID: 15747
			internal Action complete;

			// Token: 0x04003D84 RID: 15748
			internal object $current;

			// Token: 0x04003D85 RID: 15749
			internal bool $disposing;

			// Token: 0x04003D86 RID: 15750
			internal int $PC;
		}

		// Token: 0x02000BBB RID: 3003
		[CompilerGenerated]
		private sealed class <GoRotationCoroutine>c__Iterator2 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FB2 RID: 20402 RVA: 0x0005C307 File Offset: 0x0005A707
			[DebuggerHidden]
			public <GoRotationCoroutine>c__Iterator2()
			{
			}

			// Token: 0x06004FB3 RID: 20403 RVA: 0x0005C310 File Offset: 0x0005A710
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					counter = repeat;
					goto IL_331;
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_16D;
				case 4u:
					goto IL_208;
				case 5u:
					goto IL_208;
				case 6u:
					goto IL_2C5;
				default:
					return false;
				}
				IL_B0:
				t = 0f;
				IL_16D:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localEulerAngles = p;
					if (update != null)
					{
						update(p);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				m.transform.localEulerAngles = to;
				if (!pingPong)
				{
					goto IL_2EB;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_208:
				t = 0f;
				IL_2C5:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
					m.transform.localEulerAngles = p2;
					if (update != null)
					{
						update(p2);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				m.transform.localEulerAngles = from;
				IL_2EB:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_331:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_B0;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010E6 RID: 4326
			// (get) Token: 0x06004FB4 RID: 20404 RVA: 0x0005C69C File Offset: 0x0005AA9C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010E7 RID: 4327
			// (get) Token: 0x06004FB5 RID: 20405 RVA: 0x0005C6A4 File Offset: 0x0005AAA4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FB6 RID: 20406 RVA: 0x0005C6AC File Offset: 0x0005AAAC
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FB7 RID: 20407 RVA: 0x0005C6BC File Offset: 0x0005AABC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D87 RID: 15751
			internal int repeat;

			// Token: 0x04003D88 RID: 15752
			internal int <counter>__0;

			// Token: 0x04003D89 RID: 15753
			internal float delay;

			// Token: 0x04003D8A RID: 15754
			internal bool realTime;

			// Token: 0x04003D8B RID: 15755
			internal float <t>__1;

			// Token: 0x04003D8C RID: 15756
			internal float time;

			// Token: 0x04003D8D RID: 15757
			internal EaseType type;

			// Token: 0x04003D8E RID: 15758
			internal Vector3 from;

			// Token: 0x04003D8F RID: 15759
			internal Vector3 to;

			// Token: 0x04003D90 RID: 15760
			internal Vector3 <p>__2;

			// Token: 0x04003D91 RID: 15761
			internal MonoBehaviour m;

			// Token: 0x04003D92 RID: 15762
			internal Action<Vector3> update;

			// Token: 0x04003D93 RID: 15763
			internal bool pingPong;

			// Token: 0x04003D94 RID: 15764
			internal Vector3 <p>__3;

			// Token: 0x04003D95 RID: 15765
			internal Action complete;

			// Token: 0x04003D96 RID: 15766
			internal object $current;

			// Token: 0x04003D97 RID: 15767
			internal bool $disposing;

			// Token: 0x04003D98 RID: 15768
			internal int $PC;
		}

		// Token: 0x02000BBC RID: 3004
		[CompilerGenerated]
		private sealed class <GoScaleCoroutine>c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FB8 RID: 20408 RVA: 0x0005C6C3 File Offset: 0x0005AAC3
			[DebuggerHidden]
			public <GoScaleCoroutine>c__Iterator3()
			{
			}

			// Token: 0x06004FB9 RID: 20409 RVA: 0x0005C6CC File Offset: 0x0005AACC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
				{
					float last = Time.unscaledTime;
					deltaTime = delegate()
					{
						float unscaledTime = Time.unscaledTime;
						float result = unscaledTime - last;
						last = unscaledTime;
						return result;
					};
					counter = repeat;
					goto IL_37B;
				}
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_1B1;
				case 4u:
					goto IL_24C;
				case 5u:
					goto IL_24C;
				case 6u:
					goto IL_30F;
				default:
					return false;
				}
				IL_EE:
				t = 0f;
				IL_1B1:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : deltaTime()) / time;
					p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					m.transform.localScale = p;
					if (update != null)
					{
						update(p);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				m.transform.localScale = to;
				if (!pingPong)
				{
					goto IL_335;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_24C:
				t = 0f;
				IL_30F:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : deltaTime()) / time;
					p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
					m.transform.localScale = p2;
					if (update != null)
					{
						update(p2);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				m.transform.localScale = from;
				IL_335:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_37B:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_EE;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010E8 RID: 4328
			// (get) Token: 0x06004FBA RID: 20410 RVA: 0x0005CAA2 File Offset: 0x0005AEA2
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010E9 RID: 4329
			// (get) Token: 0x06004FBB RID: 20411 RVA: 0x0005CAAA File Offset: 0x0005AEAA
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FBC RID: 20412 RVA: 0x0005CAB2 File Offset: 0x0005AEB2
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FBD RID: 20413 RVA: 0x0005CAC2 File Offset: 0x0005AEC2
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D99 RID: 15769
			internal Func<float> <deltaTime>__0;

			// Token: 0x04003D9A RID: 15770
			internal int repeat;

			// Token: 0x04003D9B RID: 15771
			internal int <counter>__0;

			// Token: 0x04003D9C RID: 15772
			internal float delay;

			// Token: 0x04003D9D RID: 15773
			internal bool realTime;

			// Token: 0x04003D9E RID: 15774
			internal float <t>__1;

			// Token: 0x04003D9F RID: 15775
			internal float time;

			// Token: 0x04003DA0 RID: 15776
			internal EaseType type;

			// Token: 0x04003DA1 RID: 15777
			internal Vector3 from;

			// Token: 0x04003DA2 RID: 15778
			internal Vector3 to;

			// Token: 0x04003DA3 RID: 15779
			internal Vector3 <p>__2;

			// Token: 0x04003DA4 RID: 15780
			internal MonoBehaviour m;

			// Token: 0x04003DA5 RID: 15781
			internal Action<Vector3> update;

			// Token: 0x04003DA6 RID: 15782
			internal bool pingPong;

			// Token: 0x04003DA7 RID: 15783
			internal Vector3 <p>__3;

			// Token: 0x04003DA8 RID: 15784
			internal Action complete;

			// Token: 0x04003DA9 RID: 15785
			internal object $current;

			// Token: 0x04003DAA RID: 15786
			internal bool $disposing;

			// Token: 0x04003DAB RID: 15787
			internal int $PC;

			// Token: 0x04003DAC RID: 15788
			private Ease3.<GoScaleCoroutine>c__Iterator3.<GoScaleCoroutine>c__AnonStorey5 $locvar0;

			// Token: 0x02000BBE RID: 3006
			private sealed class <GoScaleCoroutine>c__AnonStorey5
			{
				// Token: 0x06004FC4 RID: 20420 RVA: 0x0005CAC9 File Offset: 0x0005AEC9
				public <GoScaleCoroutine>c__AnonStorey5()
				{
				}

				// Token: 0x06004FC5 RID: 20421 RVA: 0x0005CAD4 File Offset: 0x0005AED4
				internal float <>m__0()
				{
					float unscaledTime = Time.unscaledTime;
					float result = unscaledTime - this.last;
					this.last = unscaledTime;
					return result;
				}

				// Token: 0x04003DC1 RID: 15809
				internal float last;

				// Token: 0x04003DC2 RID: 15810
				internal Ease3.<GoScaleCoroutine>c__Iterator3 <>f__ref$3;
			}
		}

		// Token: 0x02000BBD RID: 3005
		[CompilerGenerated]
		private sealed class <GoColorCoroutine>c__Iterator4 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004FBE RID: 20414 RVA: 0x0005CAF8 File Offset: 0x0005AEF8
			[DebuggerHidden]
			public <GoColorCoroutine>c__Iterator4()
			{
			}

			// Token: 0x06004FBF RID: 20415 RVA: 0x0005CB00 File Offset: 0x0005AF00
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
				{
					Image image = m.GetComponent<Image>();
					Camera camera = Camera.main;
					setColor = delegate(Vector3 value)
					{
						if (image == null)
						{
							camera.backgroundColor = value.GetColor().SetAlpha(camera.backgroundColor.a);
						}
						else
						{
							image.color = value.GetColor().SetAlpha(image.color.a);
						}
					};
					counter = repeat;
					goto IL_371;
				}
				case 1u:
					break;
				case 2u:
					break;
				case 3u:
					goto IL_1BC;
				case 4u:
					goto IL_252;
				case 5u:
					goto IL_252;
				case 6u:
					goto IL_30A;
				default:
					return false;
				}
				IL_104:
				t = 0f;
				IL_1BC:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p = Ease3.Types[type](from, to, Mathf.Clamp01(t));
					setColor(p);
					if (update != null)
					{
						update(p);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				setColor(to);
				if (!pingPong)
				{
					goto IL_32B;
				}
				if (delay > 0f)
				{
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					return true;
				}
				IL_252:
				t = 0f;
				IL_30A:
				if (t <= 1f)
				{
					t += ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime) / time;
					p2 = Ease3.Types[type](to, from, Mathf.Clamp01(t));
					setColor(p2);
					if (update != null)
					{
						update(p2);
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 6;
					}
					return true;
				}
				setColor(from);
				IL_32B:
				if (repeat != 0)
				{
					counter--;
				}
				if ((repeat == 0 || repeat == -1) && complete != null)
				{
					complete();
				}
				IL_371:
				if (repeat != 0 && repeat != -1 && counter <= 0)
				{
					if (repeat != 0 && complete != null)
					{
						complete();
					}
					this.$PC = -1;
				}
				else
				{
					if (delay <= 0f)
					{
						goto IL_104;
					}
					if (realTime)
					{
						this.$current = new WaitForSecondsRealtime(delay);
						if (!this.$disposing)
						{
							this.$PC = 1;
						}
						return true;
					}
					this.$current = new WaitForSeconds(delay);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				return false;
			}

			// Token: 0x170010EA RID: 4330
			// (get) Token: 0x06004FC0 RID: 20416 RVA: 0x0005CECC File Offset: 0x0005B2CC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010EB RID: 4331
			// (get) Token: 0x06004FC1 RID: 20417 RVA: 0x0005CED4 File Offset: 0x0005B2D4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004FC2 RID: 20418 RVA: 0x0005CEDC File Offset: 0x0005B2DC
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004FC3 RID: 20419 RVA: 0x0005CEEC File Offset: 0x0005B2EC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003DAD RID: 15789
			internal MonoBehaviour m;

			// Token: 0x04003DAE RID: 15790
			internal Action<Vector3> <setColor>__0;

			// Token: 0x04003DAF RID: 15791
			internal int repeat;

			// Token: 0x04003DB0 RID: 15792
			internal int <counter>__0;

			// Token: 0x04003DB1 RID: 15793
			internal float delay;

			// Token: 0x04003DB2 RID: 15794
			internal bool realTime;

			// Token: 0x04003DB3 RID: 15795
			internal float <t>__1;

			// Token: 0x04003DB4 RID: 15796
			internal float time;

			// Token: 0x04003DB5 RID: 15797
			internal EaseType type;

			// Token: 0x04003DB6 RID: 15798
			internal Vector3 from;

			// Token: 0x04003DB7 RID: 15799
			internal Vector3 to;

			// Token: 0x04003DB8 RID: 15800
			internal Vector3 <p>__2;

			// Token: 0x04003DB9 RID: 15801
			internal Action<Vector3> update;

			// Token: 0x04003DBA RID: 15802
			internal bool pingPong;

			// Token: 0x04003DBB RID: 15803
			internal Vector3 <p>__3;

			// Token: 0x04003DBC RID: 15804
			internal Action complete;

			// Token: 0x04003DBD RID: 15805
			internal object $current;

			// Token: 0x04003DBE RID: 15806
			internal bool $disposing;

			// Token: 0x04003DBF RID: 15807
			internal int $PC;

			// Token: 0x04003DC0 RID: 15808
			private Ease3.<GoColorCoroutine>c__Iterator4.<GoColorCoroutine>c__AnonStorey6 $locvar0;

			// Token: 0x02000BBF RID: 3007
			private sealed class <GoColorCoroutine>c__AnonStorey6
			{
				// Token: 0x06004FC6 RID: 20422 RVA: 0x0005CEF3 File Offset: 0x0005B2F3
				public <GoColorCoroutine>c__AnonStorey6()
				{
				}

				// Token: 0x06004FC7 RID: 20423 RVA: 0x0005CEFC File Offset: 0x0005B2FC
				internal void <>m__0(Vector3 value)
				{
					if (this.image == null)
					{
						this.camera.backgroundColor = value.GetColor().SetAlpha(this.camera.backgroundColor.a);
					}
					else
					{
						this.image.color = value.GetColor().SetAlpha(this.image.color.a);
					}
				}

				// Token: 0x04003DC3 RID: 15811
				internal Image image;

				// Token: 0x04003DC4 RID: 15812
				internal Camera camera;

				// Token: 0x04003DC5 RID: 15813
				internal Ease3.<GoColorCoroutine>c__Iterator4 <>f__ref$4;
			}
		}
	}
}
