namespace rfeijooS5Tarea
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepos {  get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new  Views.viewPerson();
            PersonRepos = personRepository;
        }
    }
}
