using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class WorldMapUiController : MonoBehaviour
{
	// Token: 0x06001508 RID: 5384 RVA: 0x000A952B File Offset: 0x000A792B
	public WorldMapUiController()
	{
	}

	// Token: 0x06001509 RID: 5385 RVA: 0x000A9534 File Offset: 0x000A7934
	public void Init()
	{
		List<DungeonRecord> records = GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords;
		this.Frames.ForEach(delegate(WorldMapFrameController f)
		{
			f.Init(records.First((DungeonRecord r) => r.AdventureType == f.Type));
		});
	}

	// Token: 0x04001515 RID: 5397
	public List<WorldMapFrameController> Frames;

	// Token: 0x04001516 RID: 5398
	public StartBattle Battle;

	// Token: 0x02000C8B RID: 3211
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005337 RID: 21303 RVA: 0x000A9581 File Offset: 0x000A7981
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x06005338 RID: 21304 RVA: 0x000A958C File Offset: 0x000A798C
		internal void <>m__0(WorldMapFrameController f)
		{
			f.Init(this.records.First((DungeonRecord r) => r.AdventureType == f.Type));
		}

		// Token: 0x040040CA RID: 16586
		internal List<DungeonRecord> records;

		// Token: 0x02000C8C RID: 3212
		private sealed class <Init>c__AnonStorey1
		{
			// Token: 0x06005339 RID: 21305 RVA: 0x000A95CF File Offset: 0x000A79CF
			public <Init>c__AnonStorey1()
			{
			}

			// Token: 0x0600533A RID: 21306 RVA: 0x000A95D7 File Offset: 0x000A79D7
			internal bool <>m__0(DungeonRecord r)
			{
				return r.AdventureType == this.f.Type;
			}

			// Token: 0x040040CB RID: 16587
			internal WorldMapFrameController f;

			// Token: 0x040040CC RID: 16588
			internal WorldMapUiController.<Init>c__AnonStorey0 <>f__ref$0;
		}
	}
}
