using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectDBView : ContentPage
	{
		public SelectDBView ()
		{
			InitializeComponent ();
            BindingContext = new SelectViewModel();
		}
	}
}