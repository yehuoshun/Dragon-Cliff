using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DA RID: 218
	[CallbackIdentity(1320)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageGetPublishedItemVoteDetailsResult_t
	{
		// Token: 0x0400039A RID: 922
		public const int k_iCallback = 1320;

		// Token: 0x0400039B RID: 923
		public EResult m_eResult;

		// Token: 0x0400039C RID: 924
		public PublishedFileId_t m_unPublishedFileId;

		// Token: 0x0400039D RID: 925
		public int m_nVotesFor;

		// Token: 0x0400039E RID: 926
		public int m_nVotesAgainst;

		// Token: 0x0400039F RID: 927
		public int m_nReports;

		// Token: 0x040003A0 RID: 928
		public float m_fScore;
	}
}
