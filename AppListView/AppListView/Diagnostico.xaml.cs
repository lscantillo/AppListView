using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Diagnostico : ContentPage
	{
        int id = 0;
        IList<Diagnostic> diag = new ObservableCollection<Diagnostic>();
        public Diagnostico (String nom)
		{
            this.Title = "Paciente" + nom ;
            BindingContext = diag;
            InitializeComponent ();
		}

        private void laListadiagnostico_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }

             Diagnostic data2 = e.SelectedItem as Diagnostic;
         
            ((ListView)sender).SelectedItem = null;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            EnteredDiagnostico.Text = string.Empty;

            overlay2.IsVisible = true;

            EnteredDiagnostico.Focus();
        }

        private void Button_ClickedOK(object sender, EventArgs e)
        {
            overlay2.IsVisible = false;
            diag.Add(new Diagnostic("Diagnostico " + id + " - " + EnteredDiagnostico.Text));
            id++;
        }

       

        void OnCancelButtonClicked2(object sender, EventArgs args)
        {
            overlay2.IsVisible = false;
        }
    }
}