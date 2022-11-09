using System;

namespace SingLy_Linked_List
{
    class Node
    {
        public int noMhs;
        public string nama;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.Write("\nMasukkan nomor mahasiswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama mahasiswa : ");
            nm = Console.ReadLine();
            Node nodebaru = new Node();
            nodebaru.noMhs = nim;
            nodebaru.nama = nm;

            if (START == null || nim <= START.noMhs)
            {
                if ((START == null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomor mahasiswa sama tidak diizinkan");
                    return;
                }
                nodebaru.next = START;
                START = nodebaru;
                return;
            }
                //menemukan lokasi node baru di dalam list
                Node previous, current;
                previous = START;
                current = START;

             while ((current != null) && (nim >= current.noMhs))
             {
                 if (nim == current.noMhs)
                 {
                    Console.WriteLine("\nNo mahasiswa sama tidak diizinkan\n");
                    return;
                 }
                previous = current;
                current = current.next;
             }
            //node baru akan ditempatkan diantara previous dan current

            nodebaru.next = current;
            previous.next = nodebaru;
        }
        //method untuk mmenghapus node tertentu didaalam list
        public bool delNode(int nim)
        {

            Node previous, current;
            previous = current = null;
            //chek apakah node yang dimaksud ada didalam list  atau tidak
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
    public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList Kosong. \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah : \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                Console.WriteLine(currentNode.noMhs + "" + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambah data kedalam List");
                    Console.WriteLine("2. Menghapus data dari dalam List");
                    Console.WriteLine("3. Melihat semua data dari dalam List");
                    Console.WriteLine("4. Mencari sebuah data dari dalam List");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("\nMasukkan Pilihan Anda (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan nomer mahasiswa yang akan dihapus: ");
                                int nim = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(nim) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                    Console.WriteLine("\nData tdengan nomor mahasiswa " + nim + "dihapus");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan nomor mahasiswa yang akan dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\n Data tidak ditemukan. ");
                                else
                                {
                                    Console.WriteLine("\nData Ketemu ");
                                    Console.WriteLine("\nNomor maasiswa " + current.noMhs);
                                    Console.WriteLine("\nNama maasiswa " + current.nama);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("\n Check nilai yang anda masukkan.");
                }
            }
        }
    }
}
