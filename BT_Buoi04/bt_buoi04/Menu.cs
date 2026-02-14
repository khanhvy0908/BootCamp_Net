class Menu
{
    public void Show()
    {
        int choice;
        bool checkValid;
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ===== MENU CHAM BAI ======");            
            Console.WriteLine("6. Bài 6: Tìm từ dài nhất trong chuỗi");
            Console.WriteLine("7. Bài 7: Loại bỏ ký tự đặc biệt khỏi chuỗi");
            Console.WriteLine("8. Bài 8: Tách từ và trả về từ dài nhất có chứa số");
            Console.WriteLine("9. Thoát");
            Console.Write("Chọn một tùy chọn từ 6 -> 9: ");
            Console.ResetColor();

            checkValid = int.TryParse(Console.ReadLine(), out choice);
            if (!checkValid || choice < 6 || choice > 9)
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                continue;
            }
            switch (choice)
            {
                case 6:
                    Bai6 bai6 = new Bai6();
                    bai6.Show();
                    break;
                case 7:
                    Bai7 bai7 = new Bai7();
                    bai7.Show();
                    break;
                case 8:
                    Bai8 bai8 = new Bai8();
                    bai8.Show();
                    break;
                case 9:
                    Console.WriteLine("Thoát chương trình. Tạm biệt!\n");
                    return; // Kết thúc chương trình
            }
        } while (true);
    }
}