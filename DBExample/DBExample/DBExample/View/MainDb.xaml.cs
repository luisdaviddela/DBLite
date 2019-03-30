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
	public partial class MainDb : ContentPage
	{
		public MainDb ()
		{
			InitializeComponent ();
		}

        private void insert_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertDBView());
        }

        private void select_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectDBView());
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new DeleteDBView());
        }
    }
}