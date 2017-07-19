//using System.Collections.Generic;
//using System.Threading;
//using Android.App;
//using Android.Bluetooth;
//using Android.OS;
//using Android.Support.Design.Widget;
//using Android.Support.V4.View;
//using MvvmCross.Droid.Support.V4;
//using MvvmCross.Droid.Support.V7.AppCompat;
//using MvvmCross.Droid.Views;
//using TabLayoutError.Core.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using TabLayoutError.Core.ViewModels;

namespace TabLayoutError.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            Mvx.Trace("BEFORE LOADING");
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            //var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            //TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            new Thread(() =>
            {
                if (viewPager == null) return;

                var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>();
                for (var i = 0; i < 500; i++)
                    fragments.Add(new MvxCachingFragmentStatePagerAdapter.FragmentInfo(
                        $"Ceci est du text : {i}",
                        typeof(MainViewFragment),
                        typeof(MainViewFragmentViewModel)//,
                                                 //new BluetoothClass.Device() { Date = $"index from frag: {i}" }
                    ));

                RunOnUiThread(() => viewPager.Adapter =
                    new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, fragments));

                viewPager.OffscreenPageLimit = 1;
                
                //tabLayout.SetupWithViewPager(viewPager);

                Mvx.Trace("AFTER LOADING");
            }).Start();
        }
    }
}
