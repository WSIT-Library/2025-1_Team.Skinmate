using MauiApp1.Controller;
using MauiApp1.Model;

namespace MauiApp1.Views;

public partial class Login_RegisterPage : ContentPage
{
    private readonly AuthController authController;
        //<Entry x:Name="usernameEntry" Placeholder="���̵� �Է�" />
        //<Entry x:Name="passwordEntry" Placeholder="��й�ȣ �Է�" IsPassword="True" />
	public Login_RegisterPage()
	{
		InitializeComponent();
        authController = new AuthController();  

    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            LoginRequest req = new LoginRequest
            {
                UserId = usernameEntry.Text,
                Password = passwordEntry.Text
            };
            string res = await authController.LoginAsync(req); 
            if (res.Trim().ToLower() == "ok") await DisplayAlert("�α���", res, "Ȯ��");
        }
        catch (Exception ex)
        {
            await DisplayAlert("����", ex.Message, "Ȯ��");
        }
        // �α��� ��� ����
    }
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        try
        {
            RegisterRequest req = new RegisterRequest
            {
                UserId = usernameEntry.Text,
                Password = passwordEntry.Text
                ,Name = usernameEntry.Text  
            };
            string res = await authController.RegisterAsync(req);
            if (res.Trim().ToLower() == "ok") await DisplayAlert("����", res, "Ȯ��");
        }
        catch (Exception ex)
        {
            await DisplayAlert("����", ex.Message, "Ȯ��");
        }
        // ���� ��� ����

    }

}