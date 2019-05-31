#ifndef DISKTABP_H
#define DISKTABP_H

BOOLEAN EtpDiskPageCallback(
    _In_ struct _PH_MAIN_TAB_PAGE *Page,
    _In_ PH_MAIN_TAB_PAGE_MESSAGE Message,
    _In_opt_ PVOID Parameter1,
    _In_opt_ PVOID Parameter2
    );

BOOLEAN EtpDiskNodeHashtableEqualFunction(
    _In_ PVOID Entry1,
    _In_ PVOID Entry2
    );

ULONG EtpDiskNodeHashtableHashFunction(
    _In_ PVOID Entry
    );

VOID EtInitializeDiskTreeList(
    _In_ HWND hwnd
    );

PET_DISK_NODE EtAddDiskNode(
    _In_ PET_DISK_ITEM DiskItem
    );

PET_DISK_NODE EtFindDiskNode(
    _In_ PET_DISK_ITEM DiskItem
    );

VOID EtRemoveDiskNode(
    _In_ PET_DISK_NODE DiskNode
    );

VOID EtUpdateDiskNode(
    _In_ PET_DISK_NODE DiskNode
    );

BOOLEAN NTAPI EtpDiskTreeNewCallback(
    _In_ HWND hwnd,
    _In_ PH_TREENEW_MESSAGE Message,
    _In_opt_ PVOID Parameter1,
    _In_opt_ PVOID Parameter2,
    _In_opt_ PVOID Context
    );

PPH_STRING EtpGetDiskItemProcessName(
    _In_ PET_DISK_ITEM DiskItem
    );

PET_DISK_ITEM EtGetSelectedDiskItem(
    VOID
    );

VOID EtGetSelectedDiskItems(
    _Out_ PET_DISK_ITEM **DiskItems,
    _Out_ PULONG NumberOfDiskItems
    );

VOID EtDeselectAllDiskNodes(
    VOID
    );

VOID EtSelectAndEnsureVisibleDiskNode(
    _In_ PET_DISK_NODE DiskNode
    );

VOID EtCopyDiskList(
    VOID
    );

VOID EtWriteDiskList(
    _Inout_ PPH_FILE_STREAM FileStream,
    _In_ ULONG Mode
    );

VOID EtHandleDiskCommand(
    _In_ ULONG Id
    );

VOID EtpInitializeDiskMenu(
    _In_ PPH_EMENU Menu,
    _In_ PET_DISK_ITEM *DiskItems,
    _In_ ULONG NumberOfDiskItems
    );

VOID EtShowDiskContextMenu(
    _In_ HWND TreeWindowHandle,
    _In_ PPH_TREENEW_CONTEXT_MENU ContextMenuEvent
    );

VOID NTAPI EtpDiskItemAddedHandler(
    _In_opt_ PVOID Parameter,
    _In_opt_ PVOID Context
    );

VOID NTAPI EtpDiskItemModifiedHandler(
    _In_opt_ PVOID Parameter,
    _In_opt_ PVOID Context
    );

VOID NTAPI EtpDiskItemRemovedHandler(
    _In_opt_ PVOID Parameter,
    _In_opt_ PVOID Context
    );

VOID NTAPI EtpDiskItemsUpdatedHandler(
    _In_opt_ PVOID Parameter,
    _In_opt_ PVOID Context
    );

VOID NTAPI EtpOnDiskItemsUpdated(
    _In_ ULONG RunId
    );

VOID NTAPI EtpSearchChangedHandler(
    _In_opt_ PVOID Parameter,
    _In_opt_ PVOID Context
    );

BOOLEAN NTAPI EtpSearchDiskListFilterCallback(
    _In_ PPH_TREENEW_NODE Node,
    _In_opt_ PVOID Context
    );

VOID NTAPI EtpToolStatusActivateContent(
    _In_ BOOLEAN Select
    );

HWND NTAPI EtpToolStatusGetTreeNewHandle(
    VOID
    );

INT_PTR CALLBACK EtpDiskTabErrorDialogProc(
    _In_ HWND hwndDlg,
    _In_ UINT uMsg,
    _In_ WPARAM wParam,
    _In_ LPARAM lParam
    );

#endif
