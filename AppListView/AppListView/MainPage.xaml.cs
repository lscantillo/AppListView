using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace AppListView

{
    
	public partial class MainPage : ContentPage


	{
       
        IList<Contact> people = new ObservableCollection<Contact>();
        FirebaseClient firebase;
        bool add;
		public MainPage()
		{
            this.Title = "Pacientes";
            InitializeComponent();
            BindingContext = this;       
            
            firebase = new FirebaseClient("https://xamarinpacientes.firebaseio.com/");
            laLista.ItemsSource = people;

        }
      
        private void Button_Clicked(object sender, System.EventArgs e)
        {

            EnteredName.Text = string.Empty;

            overlay.IsVisible = true;

            EnteredName.Focus();

           
        }

        private void laLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }

            Contact data = e.SelectedItem as Contact;            
            Navigation.PushAsync(new Diagnostico(data.FullName));
            ((ListView)sender).SelectedItem = null;
           
        }

        async void OnOKButtonClicked(object sender, EventArgs args)
        {
            //overlay.IsVisible = false;
            //people.Add(new Contact("Paciente "+ id + " - " +EnteredName.Text , "UN"));
         
            add = true;
           // var item = (Contact)BindingContext;

            if (add)
            {
                await firebase
               .Child("Pacientes")

              .PostAsync(EnteredName.Text);

            }
            else
            {

            }

            await Navigation.PopAsync();



        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }

        public async Task<int> getList()
        {
            var list = (await firebase
                .Child("Pacientes")
                .OnceAsync<Contact>());
            people.Clear();

            Debug.WriteLine("Lista con " + list.Count);

            foreach (var item in list) {
                Contact c = item.Object as Contact;
                c.Uid = item.Key;
                people.Add(c);
            }
            return 0;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await getList();

        }
    }
}
