using System;
using UnityEngine;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A6 RID: 166
	public class WaitForSecondsRealtime : CustomYieldInstruction
	{
		// Token: 0x0600055D RID: 1373 RVA: 0x0005E833 File Offset: 0x0005CC33
		public WaitForSecondsRealtime(float time)
		{
			this._time = Time.unscaledTime + time;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0005E848 File Offset: 0x0005CC48
		public override bool keepWaiting
		{
			get
			{
				return Time.unscaledTime < this._time;
			}
		}

		// Token: 0x04000892 RID: 2194
		private float _time;
	}
}
