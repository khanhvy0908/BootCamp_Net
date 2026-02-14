class Bai8
{
        public void Show()
        {
            Console.WriteLine("Bạn đã chọn Bài 8: Tách từ và trả về từ dài nhất có chứa số.");
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

            // Sử dụng LINQ để tách từ và tìm từ dài nhất có chứa số
            string longestWordWithNumber = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.Any(char.IsDigit))
                .OrderByDescending(word => word.Length)
                .FirstOrDefault() ?? string.Empty;

            // Hiển thị kết quả
            Console.ForegroundColor = ConsoleColor.Red;
            if (!string.IsNullOrEmpty(longestWordWithNumber))
            {
                Console.WriteLine("Từ dài nhất có chứa số là: " + longestWordWithNumber);
            }
            else
            {
                Console.WriteLine("Không tìm thấy từ nào chứa số trong chuỗi.");
            }
            Console.ResetColor();
        }
}