class Bai6
{
    public void Show()
    {
        // nhap chuoi khong hop le thi nhap lai
        Console.WriteLine("Bạn đã chọn Bài 6: Tìm từ dài nhất trong chuỗi.");
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

        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string longestWord = "";

        foreach (var item in words)
        {
            if (item.Length > longestWord.Length)
            {
                longestWord = item;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Từ dài nhất trong chuỗi là: {longestWord}");
        Console.ResetColor();
    }
}