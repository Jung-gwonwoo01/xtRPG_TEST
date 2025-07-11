using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public static class Status
    {
        // 기본 능력치
        public static string Name = "플레이어";
        public static string Job = "없음";
        public static int Level = 1;
        public static int CurrentExp = 0;
        public static int MaxExp = 3;

        public static int MaxHealth = 100;
        public static int CurrentHealth = 100;
        public static int Money = 3000;

        public static int BaseAttack = 5;
        public static int BaseDefense = 5;

        // 장비
        public static Item EquippedWeapon = null;
        public static Item EquippedArmor = null;

        // 직업 설정 함수
        public static void SetJob(string jobName)
        {
            Job = jobName;
            Console.WriteLine($"[시스템] 직업이 '{jobName}'으로 설정되었습니다.");
        }

        // 이름 설정 함수 (추후 도입)
        public static void SetName(string name)
        {
            Name = name;
        }

        // 공격력 계산 (기본 + 무기)
        public static int GetTotalAttack()
        {
            return BaseAttack + (EquippedWeapon?.Power ?? 0);
        }

        // 방어력 계산 (기본 + 방어구)
        public static int GetTotalDefense()
        {
            return BaseDefense + (EquippedArmor?.Power ?? 0);
        }

        // 상태 정보 출력
        public static void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("===== 유저 정보 =====");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"직업: {Job}");
            Console.WriteLine($"레벨: {Level} ({CurrentExp}/{MaxExp})");
            Console.WriteLine($"체력: {CurrentHealth}/{MaxHealth}");
            Console.WriteLine($"보유 금액: {Money}원");

            // 공격력 표시
            int atk = GetTotalAttack();
            string atkText = EquippedWeapon != null ? $" ({BaseAttack} + {EquippedWeapon.Power})" : "";
            Console.WriteLine($"공격력: {atk}{atkText}");

            // 방어력 표시
            int def = GetTotalDefense();
            string defText = EquippedArmor != null ? $" ({BaseDefense} + {EquippedArmor.Power})" : "";
            Console.WriteLine($"방어력: {def}{defText}");

            Console.WriteLine("=====================");
            Console.WriteLine("\n(스페이스바를 누르면 메뉴로 돌아갑니다.)");

            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }

        // 레벨업 처리 (추후 던전 클리어 수 반영)
        public static void GainExp(int amount)
        {
            CurrentExp += amount;
            if (CurrentExp >= MaxExp)
            {
                Level++;
                CurrentExp = 0;
                MaxExp += 1;
                MaxHealth += 20;
                CurrentHealth = MaxHealth;
                Console.WriteLine("레벨업! 체력이 증가했습니다.");
            }
        }
    }
}
