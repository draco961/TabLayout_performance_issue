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
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using TabLayoutError.Core.ViewModels;

namespace TabLayoutError.Droid.Views
{
    
    [Register("tablayouterror.droid.views.mainviewfragment")]
    public class MainViewFragment: MvxFragment<MainViewFragmentViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.MainViewFragment, null);
        }
    }
}