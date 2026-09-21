using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000190 RID: 400
	public static class SteamUGC
	{
		// Token: 0x06000993 RID: 2451 RVA: 0x00017584 File Offset: 0x00015984
		public static UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryUserUGCRequest(CSteamAPIContext.GetSteamUGC(), unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x000175A4 File Offset: 0x000159A4
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryAllUGCRequest(CSteamAPIContext.GetSteamUGC(), eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x000175C0 File Offset: 0x000159C0
		public static UGCQueryHandle_t CreateQueryUGCDetailsRequest(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryUGCDetailsRequest(CSteamAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x000175D8 File Offset: 0x000159D8
		public static SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SendQueryUGCRequest(CSteamAPIContext.GetSteamUGC(), handle);
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x000175EF File Offset: 0x000159EF
		public static bool GetQueryUGCResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t pDetails)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCResult(CSteamAPIContext.GetSteamUGC(), handle, index, out pDetails);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00017604 File Offset: 0x00015A04
		public static bool GetQueryUGCPreviewURL(UGCQueryHandle_t handle, uint index, out string pchURL, uint cchURLSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchURLSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCPreviewURL(CSteamAPIContext.GetSteamUGC(), handle, index, intPtr, cchURLSize);
			pchURL = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00017648 File Offset: 0x00015A48
		public static bool GetQueryUGCMetadata(UGCQueryHandle_t handle, uint index, out string pchMetadata, uint cchMetadatasize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchMetadatasize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCMetadata(CSteamAPIContext.GetSteamUGC(), handle, index, intPtr, cchMetadatasize);
			pchMetadata = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001768B File Offset: 0x00015A8B
		public static bool GetQueryUGCChildren(UGCQueryHandle_t handle, uint index, PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCChildren(CSteamAPIContext.GetSteamUGC(), handle, index, pvecPublishedFileID, cMaxEntries);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000176A0 File Offset: 0x00015AA0
		public static bool GetQueryUGCStatistic(UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, out ulong pStatValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCStatistic(CSteamAPIContext.GetSteamUGC(), handle, index, eStatType, out pStatValue);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000176B5 File Offset: 0x00015AB5
		public static uint GetQueryUGCNumAdditionalPreviews(UGCQueryHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCNumAdditionalPreviews(CSteamAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000176C8 File Offset: 0x00015AC8
		public static bool GetQueryUGCAdditionalPreview(UGCQueryHandle_t handle, uint index, uint previewIndex, out string pchURLOrVideoID, uint cchURLSize, out string pchOriginalFileName, uint cchOriginalFileNameSize, out EItemPreviewType pPreviewType)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchURLSize);
			IntPtr intPtr2 = Marshal.AllocHGlobal((int)cchOriginalFileNameSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCAdditionalPreview(CSteamAPIContext.GetSteamUGC(), handle, index, previewIndex, intPtr, cchURLSize, intPtr2, cchOriginalFileNameSize, out pPreviewType);
			pchURLOrVideoID = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			pchOriginalFileName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00017736 File Offset: 0x00015B36
		public static uint GetQueryUGCNumKeyValueTags(UGCQueryHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCNumKeyValueTags(CSteamAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0001774C File Offset: 0x00015B4C
		public static bool GetQueryUGCKeyValueTag(UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string pchKey, uint cchKeySize, out string pchValue, uint cchValueSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchKeySize);
			IntPtr intPtr2 = Marshal.AllocHGlobal((int)cchValueSize);
			bool flag = NativeMethods.ISteamUGC_GetQueryUGCKeyValueTag(CSteamAPIContext.GetSteamUGC(), handle, index, keyValueTagIndex, intPtr, cchKeySize, intPtr2, cchValueSize);
			pchKey = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			pchValue = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000177B8 File Offset: 0x00015BB8
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_ReleaseQueryUGCRequest(CSteamAPIContext.GetSteamUGC(), handle);
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000177CC File Offset: 0x00015BCC
		public static bool AddRequiredTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pTagName))
			{
				result = NativeMethods.ISteamUGC_AddRequiredTag(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00017818 File Offset: 0x00015C18
		public static bool AddExcludedTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pTagName))
			{
				result = NativeMethods.ISteamUGC_AddExcludedTag(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x00017864 File Offset: 0x00015C64
		public static bool SetReturnOnlyIDs(UGCQueryHandle_t handle, bool bReturnOnlyIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnOnlyIDs(CSteamAPIContext.GetSteamUGC(), handle, bReturnOnlyIDs);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00017877 File Offset: 0x00015C77
		public static bool SetReturnKeyValueTags(UGCQueryHandle_t handle, bool bReturnKeyValueTags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnKeyValueTags(CSteamAPIContext.GetSteamUGC(), handle, bReturnKeyValueTags);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0001788A File Offset: 0x00015C8A
		public static bool SetReturnLongDescription(UGCQueryHandle_t handle, bool bReturnLongDescription)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnLongDescription(CSteamAPIContext.GetSteamUGC(), handle, bReturnLongDescription);
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0001789D File Offset: 0x00015C9D
		public static bool SetReturnMetadata(UGCQueryHandle_t handle, bool bReturnMetadata)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnMetadata(CSteamAPIContext.GetSteamUGC(), handle, bReturnMetadata);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000178B0 File Offset: 0x00015CB0
		public static bool SetReturnChildren(UGCQueryHandle_t handle, bool bReturnChildren)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnChildren(CSteamAPIContext.GetSteamUGC(), handle, bReturnChildren);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000178C3 File Offset: 0x00015CC3
		public static bool SetReturnAdditionalPreviews(UGCQueryHandle_t handle, bool bReturnAdditionalPreviews)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnAdditionalPreviews(CSteamAPIContext.GetSteamUGC(), handle, bReturnAdditionalPreviews);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x000178D6 File Offset: 0x00015CD6
		public static bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool bReturnTotalOnly)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnTotalOnly(CSteamAPIContext.GetSteamUGC(), handle, bReturnTotalOnly);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000178E9 File Offset: 0x00015CE9
		public static bool SetReturnPlaytimeStats(UGCQueryHandle_t handle, uint unDays)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnPlaytimeStats(CSteamAPIContext.GetSteamUGC(), handle, unDays);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x000178FC File Offset: 0x00015CFC
		public static bool SetLanguage(UGCQueryHandle_t handle, string pchLanguage)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLanguage))
			{
				result = NativeMethods.ISteamUGC_SetLanguage(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00017948 File Offset: 0x00015D48
		public static bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetAllowCachedResponse(CSteamAPIContext.GetSteamUGC(), handle, unMaxAgeSeconds);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0001795C File Offset: 0x00015D5C
		public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string pMatchCloudFileName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pMatchCloudFileName))
			{
				result = NativeMethods.ISteamUGC_SetCloudFileNameFilter(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x000179A8 File Offset: 0x00015DA8
		public static bool SetMatchAnyTag(UGCQueryHandle_t handle, bool bMatchAnyTag)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetMatchAnyTag(CSteamAPIContext.GetSteamUGC(), handle, bMatchAnyTag);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000179BC File Offset: 0x00015DBC
		public static bool SetSearchText(UGCQueryHandle_t handle, string pSearchText)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pSearchText))
			{
				result = NativeMethods.ISteamUGC_SetSearchText(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x00017A08 File Offset: 0x00015E08
		public static bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint unDays)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetRankedByTrendDays(CSteamAPIContext.GetSteamUGC(), handle, unDays);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00017A1C File Offset: 0x00015E1C
		public static bool AddRequiredKeyValueTag(UGCQueryHandle_t handle, string pKey, string pValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pValue))
				{
					result = NativeMethods.ISteamUGC_AddRequiredKeyValueTag(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00017A88 File Offset: 0x00015E88
		public static SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RequestUGCDetails(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, unMaxAgeSeconds);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00017AA0 File Offset: 0x00015EA0
		public static SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_CreateItem(CSteamAPIContext.GetSteamUGC(), nConsumerAppId, eFileType);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00017AB8 File Offset: 0x00015EB8
		public static UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCUpdateHandle_t)NativeMethods.ISteamUGC_StartItemUpdate(CSteamAPIContext.GetSteamUGC(), nConsumerAppId, nPublishedFileID);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00017AD0 File Offset: 0x00015ED0
		public static bool SetItemTitle(UGCUpdateHandle_t handle, string pchTitle)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchTitle))
			{
				result = NativeMethods.ISteamUGC_SetItemTitle(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00017B1C File Offset: 0x00015F1C
		public static bool SetItemDescription(UGCUpdateHandle_t handle, string pchDescription)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchDescription))
			{
				result = NativeMethods.ISteamUGC_SetItemDescription(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00017B68 File Offset: 0x00015F68
		public static bool SetItemUpdateLanguage(UGCUpdateHandle_t handle, string pchLanguage)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLanguage))
			{
				result = NativeMethods.ISteamUGC_SetItemUpdateLanguage(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00017BB4 File Offset: 0x00015FB4
		public static bool SetItemMetadata(UGCUpdateHandle_t handle, string pchMetaData)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchMetaData))
			{
				result = NativeMethods.ISteamUGC_SetItemMetadata(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00017C00 File Offset: 0x00016000
		public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemVisibility(CSteamAPIContext.GetSteamUGC(), handle, eVisibility);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00017C13 File Offset: 0x00016013
		public static bool SetItemTags(UGCUpdateHandle_t updateHandle, IList<string> pTags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemTags(CSteamAPIContext.GetSteamUGC(), updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00017C30 File Offset: 0x00016030
		public static bool SetItemContent(UGCUpdateHandle_t handle, string pszContentFolder)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszContentFolder))
			{
				result = NativeMethods.ISteamUGC_SetItemContent(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00017C7C File Offset: 0x0001607C
		public static bool SetItemPreview(UGCUpdateHandle_t handle, string pszPreviewFile)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_SetItemPreview(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00017CC8 File Offset: 0x000160C8
		public static bool RemoveItemKeyValueTags(UGCUpdateHandle_t handle, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = NativeMethods.ISteamUGC_RemoveItemKeyValueTags(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00017D14 File Offset: 0x00016114
		public static bool AddItemKeyValueTag(UGCUpdateHandle_t handle, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					result = NativeMethods.ISteamUGC_AddItemKeyValueTag(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00017D80 File Offset: 0x00016180
		public static bool AddItemPreviewFile(UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_AddItemPreviewFile(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle, type);
			}
			return result;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00017DCC File Offset: 0x000161CC
		public static bool AddItemPreviewVideo(UGCUpdateHandle_t handle, string pszVideoID)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszVideoID))
			{
				result = NativeMethods.ISteamUGC_AddItemPreviewVideo(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00017E18 File Offset: 0x00016218
		public static bool UpdateItemPreviewFile(UGCUpdateHandle_t handle, uint index, string pszPreviewFile)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszPreviewFile))
			{
				result = NativeMethods.ISteamUGC_UpdateItemPreviewFile(CSteamAPIContext.GetSteamUGC(), handle, index, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00017E64 File Offset: 0x00016264
		public static bool UpdateItemPreviewVideo(UGCUpdateHandle_t handle, uint index, string pszVideoID)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszVideoID))
			{
				result = NativeMethods.ISteamUGC_UpdateItemPreviewVideo(CSteamAPIContext.GetSteamUGC(), handle, index, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00017EB0 File Offset: 0x000162B0
		public static bool RemoveItemPreview(UGCUpdateHandle_t handle, uint index)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_RemoveItemPreview(CSteamAPIContext.GetSteamUGC(), handle, index);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00017EC4 File Offset: 0x000162C4
		public static SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, string pchChangeNote)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchChangeNote))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUGC_SubmitItemUpdate(CSteamAPIContext.GetSteamUGC(), handle, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00017F14 File Offset: 0x00016314
		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemUpdateProgress(CSteamAPIContext.GetSteamUGC(), handle, out punBytesProcessed, out punBytesTotal);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00017F28 File Offset: 0x00016328
		public static SteamAPICall_t SetUserItemVote(PublishedFileId_t nPublishedFileID, bool bVoteUp)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SetUserItemVote(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, bVoteUp);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00017F40 File Offset: 0x00016340
		public static SteamAPICall_t GetUserItemVote(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_GetUserItemVote(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00017F57 File Offset: 0x00016357
		public static SteamAPICall_t AddItemToFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddItemToFavorites(CSteamAPIContext.GetSteamUGC(), nAppId, nPublishedFileID);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00017F6F File Offset: 0x0001636F
		public static SteamAPICall_t RemoveItemFromFavorites(AppId_t nAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveItemFromFavorites(CSteamAPIContext.GetSteamUGC(), nAppId, nPublishedFileID);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00017F87 File Offset: 0x00016387
		public static SteamAPICall_t SubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SubscribeItem(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00017F9E File Offset: 0x0001639E
		public static SteamAPICall_t UnsubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_UnsubscribeItem(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00017FB5 File Offset: 0x000163B5
		public static uint GetNumSubscribedItems()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetNumSubscribedItems(CSteamAPIContext.GetSteamUGC());
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00017FC6 File Offset: 0x000163C6
		public static uint GetSubscribedItems(PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetSubscribedItems(CSteamAPIContext.GetSteamUGC(), pvecPublishedFileID, cMaxEntries);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00017FD9 File Offset: 0x000163D9
		public static uint GetItemState(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemState(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00017FEC File Offset: 0x000163EC
		public static bool GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, out uint punTimeStamp)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderSize);
			bool flag = NativeMethods.ISteamUGC_GetItemInstallInfo(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, out punSizeOnDisk, intPtr, cchFolderSize, out punTimeStamp);
			pchFolder = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00018031 File Offset: 0x00016431
		public static bool GetItemDownloadInfo(PublishedFileId_t nPublishedFileID, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemDownloadInfo(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, out punBytesDownloaded, out punBytesTotal);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00018045 File Offset: 0x00016445
		public static bool DownloadItem(PublishedFileId_t nPublishedFileID, bool bHighPriority)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_DownloadItem(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, bHighPriority);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00018058 File Offset: 0x00016458
		public static bool BInitWorkshopForGameServer(DepotId_t unWorkshopDepotID, string pszFolder)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszFolder))
			{
				result = NativeMethods.ISteamUGC_BInitWorkshopForGameServer(CSteamAPIContext.GetSteamUGC(), unWorkshopDepotID, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x000180A4 File Offset: 0x000164A4
		public static void SuspendDownloads(bool bSuspend)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUGC_SuspendDownloads(CSteamAPIContext.GetSteamUGC(), bSuspend);
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000180B6 File Offset: 0x000164B6
		public static SteamAPICall_t StartPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StartPlaytimeTracking(CSteamAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000180CE File Offset: 0x000164CE
		public static SteamAPICall_t StopPlaytimeTracking(PublishedFileId_t[] pvecPublishedFileID, uint unNumPublishedFileIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StopPlaytimeTracking(CSteamAPIContext.GetSteamUGC(), pvecPublishedFileID, unNumPublishedFileIDs);
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x000180E6 File Offset: 0x000164E6
		public static SteamAPICall_t StopPlaytimeTrackingForAllItems()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_StopPlaytimeTrackingForAllItems(CSteamAPIContext.GetSteamUGC());
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x000180FC File Offset: 0x000164FC
		public static SteamAPICall_t AddDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddDependency(CSteamAPIContext.GetSteamUGC(), nParentPublishedFileID, nChildPublishedFileID);
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00018114 File Offset: 0x00016514
		public static SteamAPICall_t RemoveDependency(PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveDependency(CSteamAPIContext.GetSteamUGC(), nParentPublishedFileID, nChildPublishedFileID);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0001812C File Offset: 0x0001652C
		public static SteamAPICall_t AddAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_AddAppDependency(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, nAppID);
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00018144 File Offset: 0x00016544
		public static SteamAPICall_t RemoveAppDependency(PublishedFileId_t nPublishedFileID, AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RemoveAppDependency(CSteamAPIContext.GetSteamUGC(), nPublishedFileID, nAppID);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0001815C File Offset: 0x0001655C
		public static SteamAPICall_t GetAppDependencies(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_GetAppDependencies(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00018173 File Offset: 0x00016573
		public static SteamAPICall_t DeleteItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_DeleteItem(CSteamAPIContext.GetSteamUGC(), nPublishedFileID);
		}
	}
}
