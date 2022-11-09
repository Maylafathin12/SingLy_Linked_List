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
        }
    }
}
