using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Android.Provider;
using Android.Hardware;
using Android.Content.PM;

namespace Test.Droid
{
    [Activity(Label = "videoRecord", Theme = "@android:style/Theme.Black.NoTitleBar", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Landscape)]
    public class videoRecord : Activity
    {
        MediaRecorder recorder;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VideoRecord);

            var record = FindViewById<Button>(Resource.Id.Record);
            var stop = FindViewById<Button>(Resource.Id.Stop);
            var play = FindViewById<Button>(Resource.Id.Play);
            var video = FindViewById<VideoView>(Resource.Id.SampleVideoView);

            //displaying from camera
            /*Intent intent = new Intent(MediaStore.ActionVideoCapture);
            StartActivityForResult(intent, 0);*/
            //displaying from camera ENDED

            String timeStamp = GetTimestamp(DateTime.Now);

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/" + timeStamp + "test.mp4";

            record.Click += delegate
            {
                video.StopPlayback();

                recorder = new MediaRecorder();
                recorder.SetVideoSource(VideoSource.Camera);
                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Default);
                recorder.SetVideoEncoder(VideoEncoder.Default);
                recorder.SetAudioEncoder(AudioEncoder.Default);
                recorder.SetOutputFile(path);
                recorder.SetPreviewDisplay(video.Holder.Surface);
                recorder.Prepare();

                recorder.Start();
            };

            stop.Click += delegate
            {
                if (recorder != null)
                {
                    recorder.Stop();
                    recorder.Release();
                }
            };

            play.Click += delegate
            {
                var uri = Android.Net.Uri.Parse(path);
                video.SetVideoURI(uri);
                video.Start();
            };
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (recorder != null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}