using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008B RID: 139
	[CallbackIdentity(211)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ComputeNewPlayerCompatibilityResult_t
	{
		// Token: 0x04000267 RID: 615
		public const int k_iCallback = 211;

		// Token: 0x04000268 RID: 616
		public EResult m_eResult;

		// Token: 0x04000269 RID: 617
		public int m_cPlayersThatDontLikeCandidate;

		// Token: 0x0400026A RID: 618
		public int m_cPlayersThatCandidateDoesntLike;

		// Token: 0x0400026B RID: 619
		public int m_cClanPlayersThatDontLikeCandidate;

		// Token: 0x0400026C RID: 620
		public CSteamID m_SteamIDCandidate;
	}
}
