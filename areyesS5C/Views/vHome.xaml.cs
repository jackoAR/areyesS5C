using areyesS5C.Models;

namespace areyesS5C.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
			
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personaRepo.AddPersona(txtNombre.Text);
        status.Text = App.personaRepo.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people = App.personaRepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }

    
}