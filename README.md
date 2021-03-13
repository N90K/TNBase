# **TNBase**

## **Introduction:**
TNBase is a database application used to keep the records of listeners and the postal pouches for talking newspapers. Talking newspapers provide an audio service in a local area for sight impaired people who want to keep up to date with the local news and to listen to some locally produced magazine items. The postal pouches also known at postal wallets, are used to send the media to the listeners. The media can be compact discs or cassette tapes but are usually USB memory sticks. Talking newspaper organisations typically send out local news recordings weekly for 50 weeks of the year. Separate magazine recordings can be sent out less frequently.

Some talking newspapers also upload their recordings to a web site so that suitably equipped listeners can download them or listen on-line.

As a charity, we are looking for assistance to update our database software so that:
* It better complies with recent changes to the GDPR regulations
* Meets our changed requirements
* It can be made more configurable so that it can meet the differing requirements of other Talking Newspaper groups.

See also: [Developer Notes](docs/DevNotes.md) 
and [Requested Fixed and Changes](https://github.com/achrisdale/TNBase/docs/FixesAndChanges.md).

## **Recording, Editing, and Viewing of Listeners' Details:**
Listeners' names, addresses, 'phone numbers, any other useful information they provide, and if they wish, their day and month of birth, are recorded. Listeners' details also include whether they have been lent a USB memory stick player, whether they take the separate magazine recordings as well as the weekly news, and their current 'status'. This can be 'Active', 'Paused' or 'Deleted'. Additional information shows the listener's quantities of wallets scanned in and out over the last eight weeks, Each listener's postal wallets are allocated a serial number. Each listener will have three addressed wallets allocated to them so that if they do not return their first wallet by the end of the week, two more wallets are available for sending on a second and third week.

The data base can be searched for a listener's name or for the listener's wallet serial number. Listeners' details can edited or deleted as required and new listeners' details added. When a listener's details are deleted, the wallet number is reserved for one year. This ensures that if the deleted listener's wallets are returned later, for example because they have been mislaid for up to a year, then that wallet will not be sent out again to the deleted listener's address. This happens because the address labels on the wallets include a bar code which is scanned into the  database programme when wallets are returned from listeners. Deleted listener's returned wallets are flagged up so that they aren't returned to stock.
Wallets may also be temporarily stopped ('Paused') and not sent out if a listener advises that they will be absent for a period. 

Clicking on the 'Browse' button displays a list of all listeners in either wallet number order or in alphabetical name order. Deleted listeners' wallets numbers are shown highlighted in brown.   

Reports can be printed when required, but note that certain reports are also presented for printing when 'Finished' is clicked on if the day is Saturday.

## **Updating The Database:**
The data base is updated weekly on Saturday mornings. The sequence is: 
1. Any changes such as adding new listeners, and deleting listeners no longer requiring the service, changes of address etc. are made first.  This may require address labels for new listeners' wallets to be printed and deleted listeners' wallets to be removed from stock.
1. **Scanning In.** 
All the  returned wallets are scanned in using the bar codes printed on the address labels. Duplicate numbered and paused listeners' wallets are returned to stock and deleted listeners' wallets are put to one side.  The rest are packed with the new recording memory sticks ready for dispatch to the listeners.

 Audio announcements and sounds are inserted to assist the operator: 
'Beep': Successfully scanned in and OK to go out again.
'2nd wallet received': A second wallet with the same number has been scanned in and needs to be put back into stock.
'3rd wallet received': A third wallet with the same number has been scanned in and needs to be put back into stock.
'Explosion sound': A consecutive scan with the same number has occured. This can be due to either the operator unintentionally scanning the same wallet twice or to a second wallet with the same number being scanned in consecutively. An on-screen window opens for the operator to select which has occurred so that the second scan can be either ignored or treated the same as 2nd wallet received. 
'This wallet is no longer in use'. The wallet was for a listener who's details have been deleted. 
'Incorrect bar code'. Wallet bar code not recognised.
'This wallet is stopped.' The wallet is to be returned to stock because the listener has asked not to be sent a wallet until a specified date or until further notice.

3. Any further amendments which have come to light can be made.
4. **Scanning Out.** 
Scanning out is in two stages: The numbers of the wallets to be scanned out are displayed in number order so that they can be removed from stock ready for scanning out. The wallets to be scanned out are calculated as  all the active listeners' wallets that haven't been scanned in.

The barcodes on the wallets that have been removed from stock are scanned and these wallets are then also packed with the new recording memory sticks ready  for dispatch to the listeners.

Audio announcements and sounds are inserted to assist the operator: 
'New listener, insert introductory memory stick.' As well as the current weekly news recording, the new listener is to be sent a second memory stick containing information for new listeners.
'Second wallet outwards.'  Each listener should only receive one news recording wallet per week, so an error has occurred in this case.  

5. **Finishing and Report Printing:**
When 'Finished' at the bottom of the main menu window is clicked on, certain reports are presented for printing:  
List of upcoming birthdays for the following week. (This is used by the recording teams to wish listeners a 'happy birthday' ).
List of active unsent wallets: Where necessary, this is used to contact listeners who haven't returned any of the three wallets that have been sent to them and also to check for any stock errors where there should be stock of active listeners' wallets but the wallet can't be found for any reason.
Recently Added Listeners.
For all printing a choice of printers is offered so that labels can be printed on a printer which has been loaded with label stationery.
6. **Finishing:** Before shutting down, the listener data base is backed up to a specified location such as a memory stick. If needed, the backed up data base file can be restored.
 
##  Drop-down menues at the top of the main window:

1. **Listeners:**
The options are the same as main menu items:
Add; Delete; Edit; Stop Sending; Cancel a stop; Browse
1. **Maintenance:**
Backup
Restore
Print All Listener Labels
Enable Scan In
Enable Scan Out
Log View
Open Log Directory
Adjust Stock Levels

**Printing:**
* Upcoming Birthdays
* Recently Added Listeners
* Listeners Inactive for 30 Days
* Print Sack Labels (These are post code area labels for the Royal Mail sacks) 
* Recently Deleted Listeners.
* Inactive listeners this week.
* Wallets Not Sent Out this Week
* Unreturned memory Stick Players
* Print Alphabetic (Surname) list
* Stopped Listener List
* Print Collector For Listener
* Magazine Wallets
* A choice of printers is offered so that if required, labels can be printed on a printer which has been loaded with label stationery.
  
**Printing:**
* The Statistics report for the calendar year to date lists: 
* Number of weekly listeners at start of the year.
* Number of weekly today
* Number of new listeners this year
* Number of lost listeners this year
* Net change in the number of listeners for the year
* Average number of listeners for the year
* Number of inactive wallets (wallets numbers deleted less than a year ago)
* Average number of wallets dispatched each week.
* Number of wallets dispatched this year.
* Number of memory stick players on loan.
* Number of stopped (Paused) wallets.
* Average number of stopped (paused) wallets during the year.
* Number of listeners stopped (paused) for 3 months.

**History:** Weekly statistics for numbers of wallets scanned in and out 

**Collectors:**
Add Collectors: Add contact details for volunteers delivering and collecting memory stick players to/from listeners. Browse: view collectors details and the post codes they cover.

**Download TNBase at: www.acdale.plus.com/TNBase/  Note: TNBase requires Windows 7 or higher and .NET v4.5 or higher**

**We need help to update 'TBBase'. If you can assist us, please contact: cd@acdale.plus.com**  
