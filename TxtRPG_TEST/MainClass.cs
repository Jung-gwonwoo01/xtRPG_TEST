using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = "텍스트 RPG: 낯선 숲의 시작";

            // 첫 문장: 안내 문구 포함
            TypeText("당신은 가본 적이 없는 낯선 숲속에서 눈을 떴습니다.", showHint: true);
            WaitForSpace();

            // 두 번째 문장부터는 안내 문구 없이
            TypeText("당신의 눈앞에는 연못이 있습니다. 당신은 물결에 비친 자신의 모습을 마주합니다.");
            WaitForSpace();

            // 선택지 출력 (바로 한 번에 출력)
            Console.Clear();
            Console.WriteLine("당신의 모습을 선택해 주세요");
            Console.WriteLine("[1] 고블린");
            Console.WriteLine("[2] 엘프");
            Console.WriteLine("[3] 마족");
            Console.WriteLine("[4] 인간");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                    Monster.Enter(choice);
                    break;
                case "4":
                    Player.Enter();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 프로그램을 종료합니다.");
                    break;
            }
        }

        // 타자 효과 출력 함수
        static void TypeText(string text, bool showHint = false)
        {
            Console.Clear();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            if (showHint)
            {
                Console.WriteLine("\n(스페이스바를 누르면 스토리가 진행됩니다.)");
            }
        }

        // 스페이스바 입력 대기 함수
        static void WaitForSpace()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}