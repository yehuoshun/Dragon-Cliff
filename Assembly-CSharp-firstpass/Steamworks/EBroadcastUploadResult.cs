using System;

namespace Steamworks
{
	// Token: 0x02000165 RID: 357
	public enum EBroadcastUploadResult
	{
		// Token: 0x040008A0 RID: 2208
		k_EBroadcastUploadResultNone,
		// Token: 0x040008A1 RID: 2209
		k_EBroadcastUploadResultOK,
		// Token: 0x040008A2 RID: 2210
		k_EBroadcastUploadResultInitFailed,
		// Token: 0x040008A3 RID: 2211
		k_EBroadcastUploadResultFrameFailed,
		// Token: 0x040008A4 RID: 2212
		k_EBroadcastUploadResultTimeout,
		// Token: 0x040008A5 RID: 2213
		k_EBroadcastUploadResultBandwidthExceeded,
		// Token: 0x040008A6 RID: 2214
		k_EBroadcastUploadResultLowFPS,
		// Token: 0x040008A7 RID: 2215
		k_EBroadcastUploadResultMissingKeyFrames,
		// Token: 0x040008A8 RID: 2216
		k_EBroadcastUploadResultNoConnection,
		// Token: 0x040008A9 RID: 2217
		k_EBroadcastUploadResultRelayFailed,
		// Token: 0x040008AA RID: 2218
		k_EBroadcastUploadResultSettingsChanged,
		// Token: 0x040008AB RID: 2219
		k_EBroadcastUploadResultMissingAudio,
		// Token: 0x040008AC RID: 2220
		k_EBroadcastUploadResultTooFarBehind,
		// Token: 0x040008AD RID: 2221
		k_EBroadcastUploadResultTranscodeBehind
	}
}
