using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GitJobsService.Core.Service;
using GitJobsService.Core.Model;
using System.Collections.Generic;

namespace GitJobsService
{
    [Activity(Label = "GitJobsService", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ResponseListener
    {
        public void OnResult(List<Position> positions)
        {
            foreach(Position p in positions)
            {
                Console.Out.WriteLine(p.title);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Position.Find(this)
                .Description("java")
                .FullTime(true).Execute();
        }
    }
}