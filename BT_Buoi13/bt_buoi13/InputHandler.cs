public static class InputHandler
{
    public static int NhapSoNguyen(int min, int max)
    {
        int value;
        bool checkValid;

        while (true)
        {
            Console.Write("Nhap lua chon: ");

            checkValid = int.TryParse(Console.ReadLine(), out value);

            if (!checkValid || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lua chon khong hop le. Vui long nhap tu {min} den {max}.");
                Console.ResetColor();
                continue;
            }

            return value;
        }
    }
}
