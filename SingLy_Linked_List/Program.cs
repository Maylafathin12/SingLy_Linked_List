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

        }
    }
}
