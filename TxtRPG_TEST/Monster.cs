using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public class Monster
    {
        public static void Enter(string monsterType)
        {
            Console.Clear();

            // 초기 연출
            TypeText("부스럭", delay: 20);
            TypeText("당신의 뒤 숲속에서 무언가 다가오는 소리가 들립니다.");
            WaitForSpace();

            TypeText("숲속에서 나온건 중무장한 '인간 모험가'들입니다.");
            WaitForSpace();

            TypeText(" '\"&|^~!%@!@%! \"\n(너는 우리들의 토벌 대상이다!)\n\n(인간들이 무슨 말을 하는 듯 하지만, 당신은 알아들을 수 없습니다.)");
            WaitForSpace();

            TypeText("갑자기 인간 무리가 당신을 공격하기 시작합니다.\n(가장 앞 인간이 휘두른 '검'에 당신은 치명상을 입었습니다.)");
            WaitForSpace();

            TypeText("당신은 살려달라고 말했지만 인간은 당신의 말을 알아들을 수 없습니다.");
            WaitForSpace();

            // 느린 타자 효과
            TypeText("당신은 더 이상 반항할 힘이 남아있지 않습니다.", delay: 70);
            WaitForSpace();

            TypeText("당신은 죽었습니다.", delay: 100);
            WaitForSpace();

            // 재시작 or 종료 선택지
            Console.Clear();
            Console.WriteLine("[당신은 죽었습니다. 다시 태어나시겠습니까?]");
            Console.WriteLine("\n[Y] 예\n[N] 아니오");

            string input = Console.ReadLine().ToUpper();

            if (input == "Y")
            {
                // Main.cs 처음부터 다시 실행
                Console.Clear();
                MainClass.Main(new string[] { });
            }
            else
            {
                Console.Clear();
                TypeText("게임을 종료합니다.", delay: 50);
                WaitForSpace();
                TypeText("다시 뵙겠습니다.");

                Thread.Sleep(3000); // 3초 후 종료
                Environment.Exit(0);
            }
        }

        // 타자 효과 출력 함수
        static void TypeText(string text, int delay = 30)
        {
            Console.Clear();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // 스페이스바 대기
        static void WaitForSpace()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}