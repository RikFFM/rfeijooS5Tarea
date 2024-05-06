using rfeijooS5Tarea.Models;
namespace rfeijooS5Tarea.Views;

public partial class viewPerson : ContentPage
{
    int id = 0;
	public viewPerson()
	{
		InitializeComponent();
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        lblStatusMssge.Text = "";
        
        App.PersonRepos.AddNewPersona(txtName.Text);
        lblStatusMssge.Text = App.PersonRepos.StatusMessage;

    }

    private void btnObtain_Clicked(object sender, EventArgs e)
    {
        lblStatusMssge.Text = "";

        List<Person> person = App.PersonRepos.GetAllPeople();
        listPersons.ItemsSource = person;
    }

    private void listPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string nameselected  = (e.CurrentSelection.FirstOrDefault()as Person)?.Name;
        int idselected = (int)((e.CurrentSelection.FirstOrDefault() as Person)?.Id);
        id=idselected;
        txtUpdateName.Text = nameselected;
        txtNameDelete.Text = nameselected; 
    }

    private void btnUpdt_Clicked(object sender, EventArgs e)
    {
        if (id != 0)
        {
            lblStatusMssge.Text = "";

            App.PersonRepos.UpdatePerson(id, txtUpdateName.Text);
            lblStatusMssge.Text = App.PersonRepos.StatusMessage;
            txtUpdateName.Text = "";
            txtNameDelete.Text = "";
            id = 0;
            DisplayAlert("Alerta", "Registro Actualizado!", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Debe escoger un nombre", "Cerrar");
        }
    }

    private void btnDlt_Clicked(object sender, EventArgs e)
    {
        if(id != 0)
        {
            lblStatusMssge.Text = "";

            App.PersonRepos.DeletePerson(id);
            lblStatusMssge.Text= App.PersonRepos.StatusMessage;
            txtUpdateName.Text = "";
            txtNameDelete.Text = "";
            id = 0;
            DisplayAlert("Alerta", "Registro eliminado", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Debe escoger un nombre", "Cerrar");
        }
    }

}