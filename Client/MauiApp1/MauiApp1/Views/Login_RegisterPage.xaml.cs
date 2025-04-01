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
    private void OnLoginClicked(object sender, EventArgs e)
    {
        LoginRequest req = new LoginRequest
        {
            UserId = usernameEntry.Text,
            Password = passwordEntry.Text
        };
        Task<string> res=authController.LoginAsync(req);
     
         // �α��� ��� ����
    }
    private void OnRegisterClicked(object sender, EventArgs e)
    {
        LoginRequest req = new LoginRequest
        {
            UserId = usernameEntry.Text,
            Password = passwordEntry.Text
        };
        // ���� ��� ����

    }

}