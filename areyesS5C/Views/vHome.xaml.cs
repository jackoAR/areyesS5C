using areyesS5C.Models;

namespace areyesS5C.Views;

public partial class vHome : ContentPage
{
    private Persona selectedPerson;
    public vHome()
	{
		InitializeComponent();
			
	}

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedPerson = e.CurrentSelection.FirstOrDefault() as Persona;
        if (selectedPerson != null)
        {
            txtNombre.Text = selectedPerson.Nombre;
        }
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

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        if (selectedPerson != null)
        {
            App.personaRepo.DeletePersona(selectedPerson.Id);
            status.Text = App.personaRepo.StatusMessage;
            ListaPersonas.ItemsSource = App.personaRepo.GetAllPeople();
            selectedPerson = null; // Clear the selection
            selectedPerson = null;
            txtNombre.Text = string.Empty;
        }
        else
        {
            status.Text = "Seleccione una persona para eliminar";
        }

    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";

        if (selectedPerson != null)
        {
            selectedPerson.Nombre = txtNombre.Text;
            App.personaRepo.UpdatePerson(selectedPerson);
            status.Text = App.personaRepo.StatusMessage;
            ListaPersonas.ItemsSource = App.personaRepo.GetAllPeople();
            selectedPerson = null;
            txtNombre.Text = string.Empty;
        }
        else
        {
            status.Text = "Seleccione una persona para modificar";
        }
    }
}