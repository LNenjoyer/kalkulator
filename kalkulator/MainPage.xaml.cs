namespace kalkulator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        void OnWybranaLiczba(object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            string pressed = button.Text;
        }
        void OnWybranyOperator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
        }
        void OnWynik(object sender, EventArgs e) { }



    }
    

}
