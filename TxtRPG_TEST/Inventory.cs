using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public static class Inventory
    {
        public static List<Item> Items = new List<Item>();

        // 아이템 추가
        public static void AddItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"'{item.Name}'을(를) 가방에 추가했습니다.");
        }

        // 아이템 제거
        public static void RemoveItem(Item item)
        {
            Items.Remove(item);
            Console.WriteLine($"'{item.Name}'을(를) 가방에서 제거했습니다.");
        }

        // 장착 여부 확인
        public static bool IsEquipped(Item item)
        {
            return item == Status.EquippedWeapon || item == Status.EquippedArmor;
        }

        // 아이템 장착
        public static void EquipItem(Item item)
        {
            if (item.IsWeapon)
            {
                Status.EquippedWeapon = item;
                Console.WriteLine($"'{item.Name}'을(를) 무기로 장착했습니다.");
            }
            else
            {
                Status.EquippedArmor = item;
                Console.WriteLine($"'{item.Name}'을(를) 갑옷으로 장착했습니다.");
            }
        }

        // 가방 출력
        public static void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("===== 가방 =====");

            if (Items.Count == 0)
            {
                Console.WriteLine("소지한 아이템이 없습니다.");
            }
            else
            {
                int index = 1;
                foreach (var item in Items)
                {
                    string equipText = IsEquipped(item) ? " [장착중]" : "";
                    Console.WriteLine($"{item.GetSummary(index)}{equipText}");
                    index++;
                }
            }

            Console.WriteLine("=================");
            Console.WriteLine("\n(스페이스바를 누르면 메뉴창으로 돌아갑니다.)");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        }
    }
}
