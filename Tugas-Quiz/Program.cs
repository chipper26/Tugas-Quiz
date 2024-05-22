using System;

namespace Tugas_Quiz
{
    class Menu
    {
        private string[] dataTersedia = {
            "JL PS IK MN TV RD UH QF AE OZ",
            "OY XS DK MP CE KI AA QF BG WB",
            "YS AG GG WD EC IK FQ GB YI ZX",
            "AZ AI JC PG DI JB AB EZ ZY YX"
        };

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                DisplayHeader("Aplikasi Pengurutan Urutan Huruf");

                // Menampilkan data yang tersedia
                Console.WriteLine("\nData yang Tersedia:");
                for (int i = 0; i < dataTersedia.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {dataTersedia[i]}");
                }

                // Meminta pengguna memilih nomor data yang ingin diurutkan
                Console.Write("\nPilih nomor data yang ingin diurutkan: ");
                int selectedDataIndex;
                while (!int.TryParse(Console.ReadLine(), out selectedDataIndex) || selectedDataIndex < 1 || selectedDataIndex > dataTersedia.Length)
                {
                    Console.WriteLine("Nomor data tidak valid. Silakan masukkan nomor data yang benar.");
                    Console.Write("Pilih nomor data yang ingin diurutkan: ");
                }

                string[] selectedData = dataTersedia[selectedDataIndex - 1].Split(' ');

                // Meminta pengguna memilih metode pengurutan
                Console.WriteLine("\nPilih metode pengurutan:");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Selection Sort");
                Console.WriteLine("3. Insertion Sort");
                Console.WriteLine("\nPilih metode pengurutan (1/2/3): ");
                string sortChoice = Console.ReadLine();

                // Memilih jenis sorting
                switch (sortChoice)
                {
                    case "1":
                        BubbleSort(selectedData);
                        break;
                    case "2":
                        SelectionSort(selectedData);
                        break;
                    case "3":
                        InsertionSort(selectedData);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                // Menampilkan data setelah pengurutan
                Console.WriteLine($"\nData Setelah Pengurutan: {string.Join(" ", selectedData)}");
                Console.WriteLine("\nTekan tombol apapun untuk melanjutkan");
                Console.ReadKey();
            }
        }

        // Metode Bubble Sort
        private void BubbleSort(string[] data)
        {
            Console.WriteLine("\nProses Pengurutan dengan Bubble Sort:");

            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (string.Compare(data[j], data[j + 1]) > 0)
                    {
                        // Tukar elemen jika urutan tidak benar
                        string temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;

                        // Tampilkan proses pengurutan
                        Console.WriteLine($"{string.Join(" ", data)}");
                    }
                }
            }
        }

        // Metode Selection Sort
        private void SelectionSort(string[] data)
        {
            Console.WriteLine("\nProses Pengurutan dengan Selection Sort:");

            for (int i = 0; i < data.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (string.Compare(data[j], data[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                string temp = data[minIndex];
                data[minIndex] = data[i];
                data[i] = temp;

                // Tampilkan proses pengurutan
                Console.WriteLine($"{string.Join(" ", data)}");
            }
        }

        // Metode Insertion Sort
        private void InsertionSort(string[] data)
        {
            Console.WriteLine("\nProses Pengurutan dengan Insertion Sort:");

            for (int i = 1; i < data.Length; i++)
            {
                string key = data[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(data[j], key) > 0)
                {
                    data[j + 1] = data[j];
                    j = j - 1;
                }
                data[j + 1] = key;

                // Tampilkan proses pengurutan
                Console.WriteLine($"{string.Join(" ", data)}");
            }
        }

        private void DisplayHeader(string title)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("         " + title);
            Console.WriteLine("==========================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
