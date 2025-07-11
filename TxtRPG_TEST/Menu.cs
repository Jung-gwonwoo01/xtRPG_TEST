using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public static class Menu
    {
        public static void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== 메뉴창 =====");
                Console.WriteLine("[1] 정보");
                Console.WriteLine("[2] 여관");
                Console.WriteLine($"[3] {GetJobLocationName()}");
                Console.WriteLine("[4] 가방");
                Console.WriteLine("[5] 상점");
                Console.WriteLine("[0] 게임 종료");
                Console.WriteLine("==================");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Status.ShowStatus();
                        break;
                    case "2":
                        RestAtInn();
                        break;
                    case "3":
                        EnterJobLocation();
                        break;
                    case "4":
                        Inventory.ShowInventory();
                        break;
                    case "5":
                        Shop.Open();
                        break;
                    case "0":
                        Console.WriteLine("게임을 종료합니다. 감사합니다!");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 엔터를 누르세요.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // 직업 특수 장소 이름 반환
        private static string GetJobLocationName()
        {
            switch (Status.Job)
            {
                case "모험가":
                    return "던전";
                case "마법 견습생":
                    return "마법 학원";
                case "농부":
                    return "농장";
                default:
                    return "알 수 없음";
            }
        }

        // 직업 특수 장소 진입
        private static void EnterJobLocation()
        {
            switch (Status.Job)
            {
                case "모험가":
                    Adventurer.Enter();
                    break;
                case "마법 견습생":
                    Wizard.Enter();
                    break;
                case "농부":
                    Farmer.Enter();
                    break;
                default:
                    Console.WriteLine("직업이 설정되어 있지 않습니다.");
                    Console.ReadLine();
                    break;
            }
        }

        // 여관 기능
        private static void RestAtInn()
        {
            Console.Clear();
            Console.WriteLine("여관에서 체력을 회복하시겠습니까?");
            Console.WriteLine("[Y] 예");
            Console.WriteLine("[N] 아니오");

            string input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                Status.CurrentHealth = Status.MaxHealth;
                Console.WriteLine("당신은 충분한 휴식으로 체력을 회복했습니다.");
            }
            else if (input == "N")
            {
                Console.WriteLine("메뉴로 돌아갑니다.");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            Console.WriteLine("\n(스페이스바를 누르면 메뉴로 돌아갑니다.)");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}
