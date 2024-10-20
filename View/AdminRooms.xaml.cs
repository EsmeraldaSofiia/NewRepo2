using course4Hotel.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;

namespace course4Hotel.View;

public partial class AdminRooms : ContentPage
{
    private readonly RoomsViewModel _viewModel;

    public AdminRooms(RoomsViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;

        isRoomFormVisible = false;

        // Set the button text to "������" initially
        buttonText = "������ ������";

        // Update the roomBlock visibility and button text based on isRoomFormVisible
        UpdateRoomFormVisibility();


    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadRoomsAsync();
    }
    private bool isRoomFormVisible = false;

    private string buttonText = "������ ������";

    private void UnfoldFormClicked(object sender, EventArgs e)
    {
        isRoomFormVisible = !isRoomFormVisible;

        UpdateRoomFormVisibility();
    }

    private void UpdateRoomFormVisibility()
    {
        roomBlock.IsVisible = isRoomFormVisible;
        buttonText = isRoomFormVisible ? "��������" : "������ ������";
        RoomFormButton.Text = buttonText;
        RoomFormButton.WidthRequest = 400;
    }
}