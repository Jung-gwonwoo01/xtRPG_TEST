using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public static class Adventurer
    {
        public static void Enter()
        {
            Console.Clear();
            Console.WriteLine("던전에 입장합니다. (아직 구현되지 않았습니다.)");
            Console.WriteLine("\n(스페이스바를 누르면 메뉴로 돌아갑니다.)");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}
