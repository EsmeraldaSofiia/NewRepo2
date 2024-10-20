using course4Hotel.ViewModels;
using course4Hotel.Models;
using course4Hotel.Data;
namespace course4Hotel.View;


public partial class AdminServices : ContentPage
{
    private readonly OfServicesViewModel _viewModel;

    // ��������� ��� ���������� ����� �������� �����
    private bool isServiceFormVisible = false;

    public AdminServices(OfServicesViewModel viewModel)
    {
        InitializeComponent();

        // ����'���� ��������� ������� �� ViewModel
        BindingContext = viewModel;
        _viewModel = viewModel;

        // ���������� ���� ����� � ���������
        UpdateServiceFormVisibility();
    }

    // �����, ���� �����������, ���� ������� �'��������� �� �����
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        // ������������ ������ �� ���� �����
        await _viewModel.LoadOfServicesAsync();
    }

    // ���� ��� ������/������������ ����� ���������/����������� ������
    private void UnfoldFormClicked(object sender, EventArgs e)
    {
        // ���� ����� �������� �����
        isServiceFormVisible = !isServiceFormVisible;

        // ��������� ������� ����� �� ����� ������ �����
        UpdateServiceFormVisibility();
    }

    // ��������� �������� ����� �� ������
    private void UpdateServiceFormVisibility()
    {
        serviceBlock.IsVisible = isServiceFormVisible;
        ServiceFormButton.Text = isServiceFormVisible ? "��������" : "������ �����";
    }
}