using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TNBase.Test
{
    [TestClass]
    public class SoundTester
    {
        [TestMethod]
        public void Sound_TestSoundsNoExceptions()
        {
            // Try and play all the sounds, they will all fail but no exceptions should be raised.
            ModuleSounds.PlayBeep();
            ModuleSounds.PlayInvalidBarcode();
            ModuleSounds.PlayNew();
            ModuleSounds.PlayNotInUse();
            ModuleSounds.PlaySecondBeep();
            ModuleSounds.PlayStopped();
            ModuleSounds.PlayExplode();
            ModuleSounds.PlayTwoIn();
            ModuleSounds.PlayTwoOut();
            ModuleSounds.PlayThreeIn();
            ModuleSounds.PlaySound("notexisting.snd");
            ModuleSounds.GetResourcesFolder();
        }
    }
}
