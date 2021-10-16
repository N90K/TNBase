using System.Media;
using TNBase.DataStorage;

namespace TNBase
{
    //
    // Many sounds taken from Text-to-Speech engine from:
    //   http://www2.research.att.com/~ttsweb/tts/demo.php
    // or
    //   http://www.soundjay.com/
    //
    public static class ModuleSounds
	{
		private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private static readonly string RESOURCES_FOLDER = "\\resource\\sound\\";

		// Get the resouces folder.
		public static string GetResourcesFolder()
		{
			return ModuleGeneric.getStartPath() + RESOURCES_FOLDER;
		}

		// Check sounds exist.
		public static bool CheckResourcesFolder()
		{
			var dir = new System.IO.DirectoryInfo(GetResourcesFolder());

            bool result = dir.Exists;
			if (!result) {
				log.Error("Resources folder does not exist! '" + GetResourcesFolder() + ".");
			}

			return result;
		}

		public static void PlaySound(string sound)
		{
			// Catch any errors gracefully.
			if (!My.MyProject.Computer.FileSystem.FileExists(sound)) {
				log.Error("Could not find sound file: '" + sound + "'");
			} else {
				new SoundPlayer(sound).Play();
			}
		}

		// Play three in sound.
		public static void PlayThreeIn()
		{
			string sound = GetResourcesFolder() + "Threein.WAV";
			PlaySound(sound);
		}

		// Play beep sound.
		public static void PlayBeep()
		{
			string sound = GetResourcesFolder() + "beep.wav";
			PlaySound(sound);
		}

		public static void DoubleBeep()
		{
			string sound = GetResourcesFolder() + "doublebeep.wav";
			PlaySound(sound);
		}

		// Play another beep sound.
		public static void PlaySecondBeep()
		{
			string sound = GetResourcesFolder() + "beep2.wav";
			PlaySound(sound);
		}

		// Play duplicate sound.
		public static void PlayTwoIn()
		{
			string sound = GetResourcesFolder() + "duplicate.wav";
			PlaySound(sound);
		}

		// Play two out sound.
		public static void PlayTwoOut()
		{
			string sound = GetResourcesFolder() + "twoout.WAV";
			PlaySound(sound);
		}

		// Play stopped sound.
		public static void PlayStopped()
		{
			string sound = GetResourcesFolder() + "stopped.wav";
			PlaySound(sound);
		}

		// Play not in use sound.
		public static void PlayNotInUse()
		{
			string sound = GetResourcesFolder() + "notinuse.wav";
			PlaySound(sound);
		}

        // Play the explode sound
        public static void PlayExplode()
        {
            string sound = GetResourcesFolder() + "EXPLODE.WAV";
            PlaySound(sound);
        }

		// Play new listener sound.
		public static void PlayNew()
		{
			string sound = GetResourcesFolder() + "newlist.WAV";
			PlaySound(sound);
		}

		// Play error
		public static void PlayInvalidBarcode()
		{
			string sound = GetResourcesFolder() + "invalid.wav";
			PlaySound(sound);
		}

		public static void BeepInvalid()
		{
			string sound = GetResourcesFolder() + "beep-invalid.wav";
			PlaySound(sound);
		}
	}
}
