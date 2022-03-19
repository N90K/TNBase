namespace TNBase.Infrastructure
{
    public static class ModuleScanning
	{
		static int scannedIn = 0;

		static int scannedOut = 0;
		// How many docs have we scanned in?
		public static int getScannedIn()
		{
			return scannedIn;
		}

		// Set the number of scanned in.
		public static void setScannedIn(int inScan)
		{
			if ((inScan < 0)) {
				scannedIn = 0;
			} else {
				scannedIn = inScan;
			}
		}

		// Set the number of scanned out.
		public static void setScannedOut(int outScan)
		{
			if ((outScan < 0)) {
				scannedOut = 0;
			} else {
				scannedOut = outScan;
			}
		}

		// How many docs have we scanned out?
		public static int getScannedOut()
		{
			return scannedOut;
		}
	}
}
