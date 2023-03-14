using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

// This file was created by the VB to C# converter (SharpDevelop 4.4.2.9749).
// It contains classes for supporting the VB "My" namespace in C#.
// If the VB application does not use the "My" namespace, or if you removed the usage
// after the conversion to C#, you can delete this file.

namespace TNBase.My
{
    sealed partial class MyProject
	{		
		[ThreadStatic] static MyComputer computer;
		
		public static MyComputer Computer {
			[DebuggerStepThrough]
			get {
				if (computer == null)
					computer = new MyComputer();
				return computer;
			}
		}
		
		[ThreadStatic] static User user;
		
		public static User User {
			[DebuggerStepThrough]
			get {
				if (user == null)
					user = new User();
				return user;
			}
		}
		
		[ThreadStatic] static MyForms forms;
		
		public static MyForms Forms {
			[DebuggerStepThrough]
			get {
				if (forms == null)
					forms = new MyForms();
				return forms;
			}
		}
		
		internal sealed class MyForms
		{
			global::TNBase.FormAddCollectors formAddCollectors_instance;
			bool formAddCollectors_isCreating;
			public global::TNBase.FormAddCollectors formAddCollectors {
				[DebuggerStepThrough] get { return GetForm(ref formAddCollectors_instance, ref formAddCollectors_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formAddCollectors_instance, value); }
			}
			
			global::TNBase.FormBrowseCollectors formBrowseCollectors_instance;
			bool formBrowseCollectors_isCreating;
			public global::TNBase.FormBrowseCollectors formBrowseCollectors {
				[DebuggerStepThrough] get { return GetForm(ref formBrowseCollectors_instance, ref formBrowseCollectors_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formBrowseCollectors_instance, value); }
			}
			
			global::TNBase.FormHistory formHistory_instance;
			bool formHistory_isCreating;
			public global::TNBase.FormHistory formHistory {
				[DebuggerStepThrough] get { return GetForm(ref formHistory_instance, ref formHistory_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formHistory_instance, value); }
			}
			
			global::TNBase.FormPrintAlphabeticList formPrintAlphabeticList_instance;
			bool formPrintAlphabeticList_isCreating;
			public global::TNBase.FormPrintAlphabeticList formPrintAlphabeticList {
				[DebuggerStepThrough] get { return GetForm(ref formPrintAlphabeticList_instance, ref formPrintAlphabeticList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintAlphabeticList_instance, value); }
			}
			
			global::TNBase.FormPrintAllLabels formPrintAllLabels_instance;
			bool formPrintAllLabels_isCreating;
			public global::TNBase.FormPrintAllLabels formPrintAllLabels {
				[DebuggerStepThrough] get { return GetForm(ref formPrintAllLabels_instance, ref formPrintAllLabels_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintAllLabels_instance, value); }
			}
			
			global::TNBase.FormPrintStoppedWalletsAll formPrintStoppedWalletsAll_instance;
			bool formPrintStoppedWalletsAll_isCreating;
			public global::TNBase.FormPrintStoppedWalletsAll formPrintStoppedWalletsAll {
				[DebuggerStepThrough] get { return GetForm(ref formPrintStoppedWalletsAll_instance, ref formPrintStoppedWalletsAll_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintStoppedWalletsAll_instance, value); }
			}
			
			global::TNBase.FormPrintUnreturnedSpeakers formPrintUnreturnedSpeakers_instance;
			bool formPrintUnreturnedSpeakers_isCreating;
			public global::TNBase.FormPrintUnreturnedSpeakers formPrintUnreturnedSpeakers {
				[DebuggerStepThrough] get { return GetForm(ref formPrintUnreturnedSpeakers_instance, ref formPrintUnreturnedSpeakers_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintUnreturnedSpeakers_instance, value); }
			}
			
			global::TNBase.FormPrintGPOLabels formPrintGPOLabels_instance;
			bool formPrintGPOLabels_isCreating;
			public global::TNBase.FormPrintGPOLabels formPrintGPOLabels {
				[DebuggerStepThrough] get { return GetForm(ref formPrintGPOLabels_instance, ref formPrintGPOLabels_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintGPOLabels_instance, value); }
			}
			
			global::TNBase.FormPrintDormantListeners formPrintDormantListeners_instance;
			bool formPrintDormantListeners_isCreating;
			public global::TNBase.FormPrintDormantListeners formPrintDormantListeners {
				[DebuggerStepThrough] get { return GetForm(ref formPrintDormantListeners_instance, ref formPrintDormantListeners_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintDormantListeners_instance, value); }
			}
			
			global::TNBase.FormPrintCollectionForm formPrintCollectionForm_instance;
			bool formPrintCollectionForm_isCreating;
			public global::TNBase.FormPrintCollectionForm formPrintCollectionForm {
				[DebuggerStepThrough] get { return GetForm(ref formPrintCollectionForm_instance, ref formPrintCollectionForm_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintCollectionForm_instance, value); }
			}
			
			global::TNBase.FormPrintNotSentWallets formPrintNotSentWallets_instance;
			bool formPrintNotSentWallets_isCreating;
			public global::TNBase.FormPrintNotSentWallets formPrintNotSentWallets {
				[DebuggerStepThrough] get { return GetForm(ref formPrintNotSentWallets_instance, ref formPrintNotSentWallets_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintNotSentWallets_instance, value); }
			}
			
			global::TNBase.FormPrintStoppedWallets formPrintStoppedWallets_instance;
			bool formPrintStoppedWallets_isCreating;
			public global::TNBase.FormPrintStoppedWallets formPrintStoppedWallets {
				[DebuggerStepThrough] get { return GetForm(ref formPrintStoppedWallets_instance, ref formPrintStoppedWallets_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintStoppedWallets_instance, value); }
			}
			
			global::TNBase.PrintPreviewDialogSelectPrinter PrintPreviewDialogSelectPrinter_instance;
			bool PrintPreviewDialogSelectPrinter_isCreating;
			public global::TNBase.PrintPreviewDialogSelectPrinter PrintPreviewDialogSelectPrinter {
				[DebuggerStepThrough] get { return GetForm(ref PrintPreviewDialogSelectPrinter_instance, ref PrintPreviewDialogSelectPrinter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref PrintPreviewDialogSelectPrinter_instance, value); }
			}
			
			global::TNBase.FormBrowse formBrowse_instance;
			bool formBrowse_isCreating;
			public global::TNBase.FormBrowse formBrowse {
				[DebuggerStepThrough] get { return GetForm(ref formBrowse_instance, ref formBrowse_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formBrowse_instance, value); }
			}
			
			global::TNBase.FormDuplicateFound formDuplicateFound_instance;
			bool formDuplicateFound_isCreating;
			public global::TNBase.FormDuplicateFound formDuplicateFound {
				[DebuggerStepThrough] get { return GetForm(ref formDuplicateFound_instance, ref formDuplicateFound_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formDuplicateFound_instance, value); }
			}
			
			global::TNBase.FormPrintBirthdays formPrintBirthdays_instance;
			bool formPrintBirthdays_isCreating;
			public global::TNBase.FormPrintBirthdays formPrintBirthdays {
				[DebuggerStepThrough] get { return GetForm(ref formPrintBirthdays_instance, ref formPrintBirthdays_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintBirthdays_instance, value); }
			}
			
			global::TNBase.FormAbout formAbout_instance;
			bool formAbout_isCreating;
			public global::TNBase.FormAbout formAbout {
				[DebuggerStepThrough] get { return GetForm(ref formAbout_instance, ref formAbout_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formAbout_instance, value); }
			}
			
			global::TNBase.FormAddFull formAddFull_instance;
			bool formAddFull_isCreating;
			public global::TNBase.FormAddFull formAddFull {
				[DebuggerStepThrough] get { return GetForm(ref formAddFull_instance, ref formAddFull_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formAddFull_instance, value); }
			}
			
			global::TNBase.FormAddMini formAddMini_instance;
			bool formAddMini_isCreating;
			public global::TNBase.FormAddMini formAddMini {
				[DebuggerStepThrough] get { return GetForm(ref formAddMini_instance, ref formAddMini_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formAddMini_instance, value); }
			}
			
			global::TNBase.FormDuplicates formDuplicates_instance;
			bool formDuplicates_isCreating;
			public global::TNBase.FormDuplicates formDuplicates {
				[DebuggerStepThrough] get { return GetForm(ref formDuplicates_instance, ref formDuplicates_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formDuplicates_instance, value); }
			}
			
			global::TNBase.FormScanIn formScanIn_instance;
			bool formScanIn_isCreating;
			public global::TNBase.FormScanIn formScanIn {
				[DebuggerStepThrough] get { return GetForm(ref formScanIn_instance, ref formScanIn_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formScanIn_instance, value); }
			}
			
			global::TNBase.FormScannedInTotal formScannedInTotal_instance;
			bool formScannedInTotal_isCreating;
			public global::TNBase.FormScannedInTotal formScannedInTotal {
				[DebuggerStepThrough] get { return GetForm(ref formScannedInTotal_instance, ref formScannedInTotal_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formScannedInTotal_instance, value); }
			}
			
			global::TNBase.FormScannedOutTotal formScannedOutTotal_instance;
			bool formScannedOutTotal_isCreating;
			public global::TNBase.FormScannedOutTotal formScannedOutTotal {
				[DebuggerStepThrough] get { return GetForm(ref formScannedOutTotal_instance, ref formScannedOutTotal_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formScannedOutTotal_instance, value); }
			}
			
			global::TNBase.FormScanOut formScanOut_instance;
			bool formScanOut_isCreating;
			public global::TNBase.FormScanOut formScanOut {
				[DebuggerStepThrough] get { return GetForm(ref formScanOut_instance, ref formScanOut_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formScanOut_instance, value); }
			}
			
			global::TNBase.FormScanOutInitial formScanOutInitial_instance;
			bool formScanOutInitial_isCreating;
			public global::TNBase.FormScanOutInitial formScanOutInitial {
				[DebuggerStepThrough] get { return GetForm(ref formScanOutInitial_instance, ref formScanOutInitial_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formScanOutInitial_instance, value); }
			}
			
			global::TNBase.FormSplash formSplash_instance;
			bool formSplash_isCreating;
			public global::TNBase.FormSplash formSplash {
				[DebuggerStepThrough] get { return GetForm(ref formSplash_instance, ref formSplash_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formSplash_instance, value); }
			}
			
			global::TNBase.FormEdit formEdit_instance;
			bool formEdit_isCreating;
			public global::TNBase.FormEdit formEdit {
				[DebuggerStepThrough] get { return GetForm(ref formEdit_instance, ref formEdit_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formEdit_instance, value); }
			}
			
			global::TNBase.FormStopSending formStopSending_instance;
			bool formStopSending_isCreating;
			public global::TNBase.FormStopSending formStopSending {
				[DebuggerStepThrough] get { return GetForm(ref formStopSending_instance, ref formStopSending_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formStopSending_instance, value); }
			}
			
			global::TNBase.FormTempShowNewListener formTempShowNewListener_instance;
			bool formTempShowNewListener_isCreating;
			public global::TNBase.FormTempShowNewListener formTempShowNewListener {
				[DebuggerStepThrough] get { return GetForm(ref formTempShowNewListener_instance, ref formTempShowNewListener_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formTempShowNewListener_instance, value); }
			}
			
			global::TNBase.FormMain formMain_instance;
			bool formMain_isCreating;
			public global::TNBase.FormMain formMain {
				[DebuggerStepThrough] get { return GetForm(ref formMain_instance, ref formMain_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formMain_instance, value); }
			}
			
			global::TNBase.FormStats formStats_instance;
			bool formStats_isCreating;
			public global::TNBase.FormStats formStats {
				[DebuggerStepThrough] get { return GetForm(ref formStats_instance, ref formStats_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formStats_instance, value); }
			}
			
			global::TNBase.FormFinished formFinished_instance;
			bool formFinished_isCreating;
			public global::TNBase.FormFinished formFinished {
				[DebuggerStepThrough] get { return GetForm(ref formFinished_instance, ref formFinished_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formFinished_instance, value); }
			}
			
			global::TNBase.FormPrintLabels formPrintLabels_instance;
			bool formPrintLabels_isCreating;
			public global::TNBase.FormPrintLabels formPrintLabels {
				[DebuggerStepThrough] get { return GetForm(ref formPrintLabels_instance, ref formPrintLabels_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintLabels_instance, value); }
			}
			
			global::TNBase.FormPrintRecentListeners formPrintRecentListeners_instance;
			bool formPrintRecentListeners_isCreating;
			public global::TNBase.FormPrintRecentListeners formPrintRecentListeners {
				[DebuggerStepThrough] get { return GetForm(ref formPrintRecentListeners_instance, ref formPrintRecentListeners_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formPrintRecentListeners_instance, value); }
			}
			
			global::TNBase.FormResumeSending formResumeSending_instance;
			bool formResumeSending_isCreating;
			public global::TNBase.FormResumeSending formResumeSending {
				[DebuggerStepThrough] get { return GetForm(ref formResumeSending_instance, ref formResumeSending_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref formResumeSending_instance, value); }
			}
			
			[DebuggerStepThrough]
			static T GetForm<T>(ref T instance, ref bool isCreating) where T : Form, new()
			{
				if (instance == null || instance.IsDisposed) {
					if (isCreating) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
					isCreating = true;
					try {
						instance = new T();
					} catch (System.Reflection.TargetInvocationException ex) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { ex.InnerException.Message }), ex.InnerException);
					} finally {
						isCreating = false;
					}
				}
				return instance;
			}
			
			[DebuggerStepThrough]
			static void SetForm<T>(ref T instance, T value) where T : Form
			{
				if (instance != value) {
					if (value == null) {
						instance.Dispose();
						instance = null;
					} else {
						throw new ArgumentException("Property can only be set to null");
					}
				}
			}
		}
	}
		
	partial class MyComputer : Computer
	{
	}
}
