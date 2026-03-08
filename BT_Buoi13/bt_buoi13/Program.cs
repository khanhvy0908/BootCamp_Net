public class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.LoadMenuFromFile(); // Load menu từ file khi bắt đầu chương trình
        menu.HienThiMenu();
    }
}
