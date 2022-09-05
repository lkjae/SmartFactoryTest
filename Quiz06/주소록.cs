using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace Quiz6
{

    class Student
    {
       

       
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pnumber { get; set; }

        public Student(int id, string name, string pnumber)
        {
            ID = id;
            Name = name;
            Pnumber = pnumber;
        }
    }

    class Crud
    {
        private static string strCon = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe))); User Id = hr; Password = hr;";
        OracleConnection conn = new OracleConnection(strCon);
        
        static List<Student> students = new List<Student>();
        public void Insert()
        {
            Console.WriteLine("id 입력");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("이름 입력");
            string name = Console.ReadLine();
            Console.WriteLine("연락처 입력");
            string pnumber = Console.ReadLine();
            Student st = new Student(id, name, pnumber);
            st.ID = id;
            st.Name = name;
            st.Pnumber = pnumber;
            students.Add(st);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO AndongTest02 (ADDR_ID, NAME, HP) VALUES(id, 'name', 'pnumber')";
            conn.Close();

        }

        public void Select()
        {
            Console.WriteLine($"{"ID",-10}{"NAME",-15}{"PNUMBER",-15}");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].ID,-10} {students[i].Name,-15} {students[i].Pnumber,-15}");
            }
        }

        public void Update()
        {
            Console.WriteLine("수정할 ID를 입력하세요.");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == num)
                {
                    Console.WriteLine("이름 입력");
                    string newname = Console.ReadLine();
                    Console.WriteLine("번호 입력");
                    string newPnumber = Console.ReadLine();
                    students[i].Name = newname;
                    students[i].Pnumber = newPnumber;

                }

            }
            Console.WriteLine("데이터가 수정되었습니다.");
            Console.WriteLine("-------------------------");
        }

        public void Delete()
        {
            Console.WriteLine("삭제할 ID를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < students.Count; i++)
            {
                if (num == students[i].ID)
                {
                    students.RemoveAt(i);
                }
            }

            Console.WriteLine("데이터가 삭제되었습니다.");
            Console.WriteLine("-------------------------");
        }
    }
    internal class Program
    {
        static void Loop()

        {

            int btn;

            while (true)

            {

                Console.WriteLine("1.데이터 삽입");

                Console.WriteLine("2.데이터 삭제");

                Console.WriteLine("3.데이터 조회");

                Console.WriteLine("4.데이터 수정");

                Console.WriteLine("5.프로그램 종료");

                btn = Int32.Parse(Console.ReadLine());

                Crud crud = new Crud();



                switch (btn)

                {

                    case 1:

                        crud.Insert();

                        Console.WriteLine("데이터가 입력되었습니다.");

                        Console.WriteLine("-------------------------");

                        break;

                    case 2:

                        crud.Delete();

                        break;

                    case 3:

                        crud.Select();

                        Console.WriteLine("데이터가 조회되었습니다.");

                        Console.WriteLine("-------------------------");

                        break;

                    case 4:

                        crud.Update();

                        break;

                    case 5:

                        Environment.Exit(1);

                        break;

                }

            }

        }
        static void Main(string[] args)
        {
            Loop();
        }
    }
}
