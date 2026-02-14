class Bai7
{
    public void Show()
    {
        Console.WriteLine("Bạn đã chọn Bài 7: Loại bỏ ký tự đặc biệt khỏi chuỗi.");
        // Nhập một chuỗi từ người dùng, neu rong thi nhap lai
        string? input;
        do
        {
            Console.Write("Nhập một chuỗi: ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Chuỗi không được để trống. Vui lòng nhập lại.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        // Sử dụng LINQ để loại bỏ ký tự đặc biệt
        string cleanedString = new string(input.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());

        // Hiển thị kết quả
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Chuỗi sau khi loại bỏ ký tự đặc biệt là: " + cleanedString);
        Console.ResetColor();

        
    }
}