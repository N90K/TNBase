# TNBase: Fixes and Changes Requested: (Not listed in any particular order)
## Fixes:
**F1.**  Check the calculation of the number of scanned in wallets displayed in the 'History' menu item: Number seems to be much too high. However the 'Scanned out' number and the 'Total' numbers look to be reasonable. 

**F7.** Stats: 'Net change of listeners for the year' doesn't always add up correctly: For example:
'Weekly listeners at the start of this year: 199
Weekly listeners as of today: 190
'Net change of listeners for the year': -4   Should be -9 

## Changes:
**C1.** Change 'Wallets' in all the list items in the stats to 'News Wallets' so that News wallets and Magazine wallets can be separately identified.

**C2.** Make the number of News wallets allocated to each listener configurable**. Default = 3.

**C3.** Delete permanently all names and all contact details after a listener is deleted and all wallets returned (or delete manually if necessary), but reserve/keep the wallet numbers for a year, as now. Also remove the  'Restore Deleted Listeners' in the maintenance menu.*

**C4.** A new report to list 'Magazine only listeners'. (List only Wallet numbers and names)

**C5.** Replace the present old system of week numbers with a more widely used system of week numbers or Saturday dates. Provide a method for migrating to the new week numbering system.

**C6.** Browse menu: Either freeze the wallet number column when scrolling sideways, or if difficult to do, repeat the wallet number column next to the 'Stock' column.

**C7.** The previous 8 weeks worth of scanning records in 'Browse' are no longer required. 4 weeks will be sufficient.

**C8.** Printing Menu: All the various lists of listeners except the 'Unsent wallet list' which has already been changed:  Remove all contact details so that the lists only show wallet numbers and names.  The only print out that continues to contain the full details of the listener is to be the 'Print Collector for Listener'. *

Done **C9.** Magazine Wallets: Scan in and Scan out menu buttons: on clicking on either, to give a choice: 'Scan in/out Yellow** News Wallets' or 'Scan in/out Orange** Magazine Wallets' (buttons can be yellow** and orange**). The scanning in/out of the magazine wallets to replicate that of the news wallets except that:
Each listener has 1/2/3**  magazine wallet(s) Default = 1.
Magazine wallets are only scanned out four times a year (Spring, Summer, Autumn, and Winter, date range to be agreed**), but can be scanned in at any time**.
Separate stock records need to be generated for magazine wallets:  The only change needed to the New/Edit listener details will be a new box 'Magazine wallet stock'. The Last in/out boxes continue to refer to the weekly news wallets.   Also a new column in 'Browse' needed: 'Mag. wallet stock' so existing 'Stock' column relabelled: 'News wallet stock'.  Magazine wallet scanning records are not essential.

Done **C10.** New item in the 'Print' menu: Print list of all wallet number with current stock levels of News and Magazine wallets (Magazine wallets aded only after C9 completed).  Three columns, preferably several pairs of columns so to fit everything on one  A4 page.  Stock levels of unused/reserved wallet numbers up to the latest used (or up to 300) can be shown as an 'X'.   

**C11.** Make the usual day of the week when the database is updated configurable**. Default = Saturday.

**C12.** Add to Print menu: List currently Paused wallets, with 'Until' date where known.

* **These changes are required so we can better conform to the new GDPR regulations.**

** **Newly configurable item for TNBase versions for use by other TNs.**


Download TNBase at: www.acdale.plus.com/TNBase/  Note: TNBase requires Windows 7 or higher and .NET v4.5 or higher

Chris D. 05/09/2019
