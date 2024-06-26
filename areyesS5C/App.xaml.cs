using areyesS5C.Utils;

namespace areyesS5C
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepo {  get; set; }
        public App( PersonaRepository person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personaRepo = person;
        }
    }
}
