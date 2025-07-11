using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public class Player
    {
        public static void Enter()
        {
            Console.Clear();
            Console.WriteLine("당신은 인간으로서 모험을 시작합니다.");
            Console.WriteLine("\n(스페이스바를 누르면 계속 진행됩니다.)");

            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            Job.Start(); // Job.cs로 이동!
        }
    }
}
