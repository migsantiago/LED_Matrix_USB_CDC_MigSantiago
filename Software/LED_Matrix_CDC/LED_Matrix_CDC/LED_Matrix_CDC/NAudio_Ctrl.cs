﻿using System;
using NAudio.Wave;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace LED_Matrix_CDC
{
    class NAudio_Ctrl
    {
        /**********************************************************************************************************************************************/
        /* Objects */

        /* Audio capturing object */
        private IWaveIn waveIn { get; set; }
        private object lockWaveIn = new object();

        /* Audio samples */
        private Double[] Audio_Samples { get; set; }
        private object lockAudioSamples = new object();

        /* Data is available (atomic bool) */
        private Boolean Data_Available { get; set; }

        /**********************************************************************************************************************************************/
        /* Types */

        public enum WaveFormatEncoding : ushort
        {
            Unknown = 0,
            Pcm = 1,
            Adpcm = 2,
            IeeeFloat = 3,
            Vselp = 4,
            IbmCvsd = 5,
            ALaw = 6,
            MuLaw = 7,
            Dts = 8,
            Drm = 9,
            OkiAdpcm = 16,
            DviAdpcm = 17,
            ImaAdpcm = 17,
            MediaspaceAdpcm = 18,
            SierraAdpcm = 19,
            G723Adpcm = 20,
            DigiStd = 21,
            DigiFix = 22,
            DialogicOkiAdpcm = 23,
            MediaVisionAdpcm = 24,
            CUCodec = 25,
            YamahaAdpcm = 32,
            SonarC = 33,
            DspGroupTrueSpeech = 34,
            EchoSpeechCorporation1 = 35,
            AudioFileAf36 = 36,
            Aptx = 37,
            AudioFileAf10 = 38,
            Prosody1612 = 39,
            Lrc = 40,
            DolbyAc2 = 48,
            Gsm610 = 49,
            MsnAudio = 50,
            AntexAdpcme = 51,
            ControlResVqlpc = 52,
            DigiReal = 53,
            DigiAdpcm = 54,
            ControlResCr10 = 55,
            WAVE_FORMAT_NMS_VBXADPCM = 56,
            WAVE_FORMAT_CS_IMAADPCM = 57,
            WAVE_FORMAT_ECHOSC3 = 58,
            WAVE_FORMAT_ROCKWELL_ADPCM = 59,
            WAVE_FORMAT_ROCKWELL_DIGITALK = 60,
            WAVE_FORMAT_XEBEC = 61,
            WAVE_FORMAT_G721_ADPCM = 64,
            WAVE_FORMAT_G728_CELP = 65,
            WAVE_FORMAT_MSG723 = 66,
            Mpeg = 80,
            WAVE_FORMAT_RT24 = 82,
            WAVE_FORMAT_PAC = 83,
            MpegLayer3 = 85,
            WAVE_FORMAT_LUCENT_G723 = 89,
            WAVE_FORMAT_CIRRUS = 96,
            WAVE_FORMAT_ESPCM = 97,
            WAVE_FORMAT_VOXWARE = 98,
            WAVE_FORMAT_CANOPUS_ATRAC = 99,
            WAVE_FORMAT_G726_ADPCM = 100,
            WAVE_FORMAT_G722_ADPCM = 101,
            WAVE_FORMAT_DSAT_DISPLAY = 103,
            WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = 105,
            WAVE_FORMAT_VOXWARE_AC8 = 112,
            WAVE_FORMAT_VOXWARE_AC10 = 113,
            WAVE_FORMAT_VOXWARE_AC16 = 114,
            WAVE_FORMAT_VOXWARE_AC20 = 115,
            WAVE_FORMAT_VOXWARE_RT24 = 116,
            WAVE_FORMAT_VOXWARE_RT29 = 117,
            WAVE_FORMAT_VOXWARE_RT29HW = 118,
            WAVE_FORMAT_VOXWARE_VR12 = 119,
            WAVE_FORMAT_VOXWARE_VR18 = 120,
            WAVE_FORMAT_VOXWARE_TQ40 = 121,
            WAVE_FORMAT_SOFTSOUND = 128,
            WAVE_FORMAT_VOXWARE_TQ60 = 129,
            WAVE_FORMAT_MSRT24 = 130,
            WAVE_FORMAT_G729A = 131,
            WAVE_FORMAT_MVI_MVI2 = 132,
            WAVE_FORMAT_DF_G726 = 133,
            WAVE_FORMAT_DF_GSM610 = 134,
            WAVE_FORMAT_ISIAUDIO = 136,
            WAVE_FORMAT_ONLIVE = 137,
            WAVE_FORMAT_SBC24 = 145,
            WAVE_FORMAT_DOLBY_AC3_SPDIF = 146,
            WAVE_FORMAT_MEDIASONIC_G723 = 147,
            WAVE_FORMAT_PROSODY_8KBPS = 148,
            WAVE_FORMAT_ZYXEL_ADPCM = 151,
            WAVE_FORMAT_PHILIPS_LPCBB = 152,
            WAVE_FORMAT_PACKED = 153,
            WAVE_FORMAT_MALDEN_PHONYTALK = 160,
            Gsm = 161,
            G729 = 162,
            G723 = 163,
            Acelp = 164,
            WAVE_FORMAT_RHETOREX_ADPCM = 256,
            WAVE_FORMAT_IRAT = 257,
            WAVE_FORMAT_VIVO_G723 = 273,
            WAVE_FORMAT_VIVO_SIREN = 274,
            WAVE_FORMAT_DIGITAL_G723 = 291,
            WAVE_FORMAT_SANYO_LD_ADPCM = 293,
            WAVE_FORMAT_SIPROLAB_ACEPLNET = 304,
            WAVE_FORMAT_SIPROLAB_ACELP4800 = 305,
            WAVE_FORMAT_SIPROLAB_ACELP8V3 = 306,
            WAVE_FORMAT_SIPROLAB_G729 = 307,
            WAVE_FORMAT_SIPROLAB_G729A = 308,
            WAVE_FORMAT_SIPROLAB_KELVIN = 309,
            WAVE_FORMAT_G726ADPCM = 320,
            WAVE_FORMAT_QUALCOMM_PUREVOICE = 336,
            WAVE_FORMAT_QUALCOMM_HALFRATE = 337,
            WAVE_FORMAT_TUBGSM = 341,
            WAVE_FORMAT_MSAUDIO1 = 352,
            WAVE_FORMAT_WMAUDIO2 = 353,
            WAVE_FORMAT_WMAUDIO3 = 354,
            WAVE_FORMAT_UNISYS_NAP_ADPCM = 368,
            WAVE_FORMAT_UNISYS_NAP_ULAW = 369,
            WAVE_FORMAT_UNISYS_NAP_ALAW = 370,
            WAVE_FORMAT_UNISYS_NAP_16K = 371,
            WAVE_FORMAT_CREATIVE_ADPCM = 512,
            WAVE_FORMAT_CREATIVE_FASTSPEECH8 = 514,
            WAVE_FORMAT_CREATIVE_FASTSPEECH10 = 515,
            WAVE_FORMAT_UHER_ADPCM = 528,
            WAVE_FORMAT_QUARTERDECK = 544,
            WAVE_FORMAT_ILINK_VC = 560,
            WAVE_FORMAT_RAW_SPORT = 576,
            WAVE_FORMAT_ESST_AC3 = 577,
            WAVE_FORMAT_IPI_HSX = 592,
            WAVE_FORMAT_IPI_RPELP = 593,
            WAVE_FORMAT_CS2 = 608,
            WAVE_FORMAT_SONY_SCX = 624,
            WAVE_FORMAT_FM_TOWNS_SND = 768,
            WAVE_FORMAT_BTV_DIGITAL = 1024,
            WAVE_FORMAT_QDESIGN_MUSIC = 1104,
            WAVE_FORMAT_VME_VMPCM = 1664,
            WAVE_FORMAT_TPC = 1665,
            WAVE_FORMAT_OLIGSM = 4096,
            WAVE_FORMAT_OLIADPCM = 4097,
            WAVE_FORMAT_OLICELP = 4098,
            WAVE_FORMAT_OLISBC = 4099,
            WAVE_FORMAT_OLIOPR = 4100,
            WAVE_FORMAT_LH_CODEC = 4352,
            WAVE_FORMAT_NORRIS = 5120,
            WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 5376,
            WAVE_FORMAT_DVM = 8192,
            Vorbis1 = 26447,
            Vorbis2 = 26448,
            Vorbis3 = 26449,
            Vorbis1P = 26479,
            Vorbis2P = 26480,
            Vorbis3P = 26481,
            Extensible = 65534,
            WAVE_FORMAT_DEVELOPMENT = ushort.MaxValue
        }

        /// <summary>
        /// Copy of WaveFormat
        /// </summary>
        public struct DataInfo
        {
            public int BitsPerSample;
            public int AverageBytesPerSecond;
            public int Channels;
            public int SampleRate;
            public WaveFormatEncoding Encoding;
        };

        /**********************************************************************************************************************************************/
        /* Methods */

        /// <summary>
        /// Constructor
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public NAudio_Ctrl()
        {
            Data_Available = false;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        ~NAudio_Ctrl()
        {
            Stop_Audio_Capture();
        }

        /// <summary>
        /// Initialize the waveIn object and start recording audio
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Start_Audio_Capture()
        {
            lock (lockWaveIn)
            {
                if (null == waveIn)
                {
                    /* Start capturing audio */
                    waveIn = new WasapiLoopbackCapture();

                    if (waveIn != null)
                    {
                        waveIn.DataAvailable += OnDataAvailable;
                        waveIn.RecordingStopped += OnRecordingStopped;
                        waveIn.StartRecording();

                        /* Debug info */
                        Console.WriteLine("waveIn.WaveFormat.BitsPerSample " + waveIn.WaveFormat.BitsPerSample);
                        Console.WriteLine("waveIn.WaveFormat.AverageBytesPerSecond " + waveIn.WaveFormat.AverageBytesPerSecond);
                        Console.WriteLine("waveIn.WaveFormat.Channels " + waveIn.WaveFormat.Channels);
                        Console.WriteLine("waveIn.WaveFormat.SampleRate " + waveIn.WaveFormat.SampleRate);
                        Console.WriteLine("waveIn.WaveFormat.Encoding " + waveIn.WaveFormat.Encoding);
                    }
                }
                else
                {
                    Console.WriteLine("waveIn is NOT null");
                }
            }
        }

        /// <summary>
        /// Stop the recording
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Stop_Audio_Capture()
        {
            lock (lockWaveIn)
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    waveIn = null;
                }
            }
            Data_Available = false;
        }

        /// <summary>
        /// This is called when audio samples are ready
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            Int32 sample_count;
            if (e.BytesRecorded > 0)
            {
                lock (lockWaveIn)
                {
                    sample_count = e.BytesRecorded / (waveIn.WaveFormat.BitsPerSample / 8);
                }
                Single[] data = new Single[sample_count];

                for (int i = 0; i < sample_count; ++i)
                {
                    data[i] = BitConverter.ToSingle(e.Buffer, i * 4);
                }

                int j = 0;
                Double[] localAudio_Samples = new Double[sample_count / 2];
                for (int sample = 0; sample < data.Length; sample += 2)
                {
                    localAudio_Samples[j] = (Double)data[sample];
                    localAudio_Samples[j] += (Double)data[sample + 1];
                    ++j;
                }

                lock (lockAudioSamples)
                {
                    Audio_Samples = new double[localAudio_Samples.Length];
                    Array.Copy(localAudio_Samples, Audio_Samples, localAudio_Samples.Length);
                }

                Data_Available = true;
            }
        }

        /// <summary>
        /// This is called whenever the audio sampled is canceled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                e.Exception.Message));
            }
        }

        /// <summary>
        /// Get audio samples
        /// </summary>
        /// <param name="audioSamples"></param>
        /// <returns>True if the samples were retrieved</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Boolean getAudioSamples(out Double[] audioSamples)
        {
            Boolean result = false;

            audioSamples = new double[0];

            if (Data_Available)
            {
                lock (lockAudioSamples)
                {
                    audioSamples = new double[Audio_Samples.Length];
                    Array.Copy(Audio_Samples, audioSamples, Audio_Samples.Length);
                }
                result = true;
                Data_Available = false;
            }

            return result;
        }

        /// <summary>
        /// Indicate if there's a recording in progress
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Boolean isRecording()
        {
            Boolean result = false;

            lock (lockWaveIn)
            {
                result = (waveIn != null);
            }

            return result;
        }

        /// <summary>
        /// Get the wave recording details
        /// </summary>
        /// <param name="waveFormat">A struct to write data to</param>
        /// <returns>True if the recording is in progress</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Boolean getWaveFormat(out DataInfo waveFormat)
        {
            Boolean result = false;

            waveFormat = new DataInfo();

            lock (lockWaveIn)
            {
                if (waveIn != null)
                {
                    waveFormat.AverageBytesPerSecond = waveIn.WaveFormat.AverageBytesPerSecond;
                    waveFormat.BitsPerSample = waveIn.WaveFormat.BitsPerSample;
                    waveFormat.Channels = waveIn.WaveFormat.Channels;
                    waveFormat.Encoding = (WaveFormatEncoding)waveIn.WaveFormat.Encoding;
                    waveFormat.SampleRate = waveIn.WaveFormat.SampleRate;

                    result = true;
                }
            }

            return result;
        }
    }
}
