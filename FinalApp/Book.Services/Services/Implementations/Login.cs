

using System.ComponentModel.Design;

namespace Book.Services.Services.Implementations
{
    public class LoginService
    {
        public async Task FinishApp()
        {
             MenuService menuService = new MenuService();

            Console.WriteLine("1. As Admin");
            Console.WriteLine("2. As User");

            string Request = Console.ReadLine();

            if (Request == "1")
            {
                bool result = await menuService.Login();

                while (!result)
                {
                    result = await menuService.Login();
                    if (!result)
                    {

                        Console.WriteLine("2.Return  As User");
                        Request = Console.ReadLine();
                        if (Request == "2")
                        {
                            result = true;
                        }
                    }
                }
            }

            if (menuService.IsAdmin)
            {
                menuService.ShowAdmin();
            }
            else
            {
                menuService.ShowUser();
            }

        }
    }
}
