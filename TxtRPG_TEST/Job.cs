using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public class Job
    {
        public static void Start()
        {
            TypeText("당신은 극심한 피로감에 못이겨 정신을 잃게 됩니다.\n(멀리서 사람들의 말소리가 들린다. 너무 졸리다..)", true);
            WaitForSpace();

            TypeText("눈을 떴습니다. 낯선 천장이 보입니다. 당신은 체력을 회복한 것 같습니다.\n(아래에서 말소리가 들린다. 내려가서 확인해 봐야겠다.)");
            WaitForSpace();

            TypeText("여관주인: 어? 일어났어요? 저희 여관 너무 좋죠?ㅎ 잠깐만 자고 일어나도 체력을 금방 채울 수 있답니다.\n(여기가 어디인지 물어봐야겠다.)");
            WaitForSpace();

            TypeText("여관주인: 저희 마을에 처음 오셨었나요? 죄송해요 위화감이 없어 몰랐어요ㅎ\n여기는 르탄마을이에요. 옛날 르탄이라는 용사가 용으로부터 지켜낸 땅에 지어진 마을이라 그렇게 부르게 되었답니다.");
            WaitForSpace();

            TypeText("여관주인: 혹시 '직업'과 '돈'은 있으신가요? 돈이 없다면 저희 여관 옆에 있는 길드에 가서 퀘스트나 던전 토벌로 벌 수 있을 거예요.\n필요한 '아이템'은 건너편에 있는 상점에서 구매하실 수 있으실 거예요.\n(돈이 없다.. 우선 길드에 가서 무엇을 해야 할지 선택해봐야겠다.)");
            WaitForSpace();

            TypeText("여관 옆 길드 건물이 보입니다. 나무로 만들어졌지만 전체적으로는 하얀 건물이다. 날붙이에 긁힌 벽과 알 수 없는 얼룩이 보입니다.");
            WaitForSpace();

            TypeText("당신은 길드로 들어가 접수처에 왔습니다.");
            WaitForSpace();

            TypeText("접수원: 어서오세요! 어쩐일로 오셨을까요?\n(나는 돈을 벌고 싶다고 했다.)");
            WaitForSpace();

            TypeText("접수원: 돈 버는 방법은 다양한데 어떤 일을 하고 싶으신가요?");
            WaitForSpace();

            // 직업 선택지
            Console.Clear();
            Console.WriteLine("당신의 직업이 정해집니다.");
            Console.WriteLine("[1] 던전과 마물 토벌 (모험가)");
            Console.WriteLine("[2] 마법 공부 (마법 견습생)");
            Console.WriteLine("[3] 작물을 키워 유통 (농부)");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Status.SetJob("모험가");
                    break;
                case "2":
                    Status.SetJob("마법 견습생");
                    break;
                case "3":
                    Status.SetJob("농부");
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 프로그램을 종료합니다.");
                    Environment.Exit(0);
                    return;
            }

            // 직업 선택 후 상태창 보여주기
            Console.Clear();
            Console.WriteLine($"접수원: '{Status.Job}'가 어울릴 것 같네요!");
            Console.WriteLine("내가 알려줄 건 여기까지야! 혹시 나중에 '피곤'하거나 '체력'이 없으면");
            Console.WriteLine("'길드' 건물 옆에 있는 '여관'에서 체력을 회복하도록 해!");
            Console.WriteLine("\n(스페이스바를 누르면 상태창을 확인합니다.)");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            // 상태창 출력
            Status.ShowStatus();

            // 상태창 이후 메뉴창으로 진입
            Console.Clear();
            Console.WriteLine("당신은 길드 밖을 나왔습니다. '메뉴창'이 활성화됩니다.");
            Console.WriteLine("\n(스페이스바를 누르면 메뉴창으로 이동합니다.)");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            Menu.Open();
        }

        // 타자 효과 출력
        static void TypeText(string text, bool showHint = false, int delay = 30)
        {
            Console.Clear();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            if (showHint)
            {
                Console.WriteLine("\n(스페이스바를 누르면 스토리가 진행됩니다.)");
            }
        }

        // 스페이스바 대기
        static void WaitForSpace()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}
