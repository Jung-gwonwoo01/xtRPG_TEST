using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TxtRPG_TEST
{
    public static class Shop
    {
        public static void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("어서오세요. 필요한 게 있으시다면 편하게 말해주세요!");
                Console.WriteLine("[1] 아이템 구매");
                Console.WriteLine("[2] 아이템 판매");
                Console.WriteLine("[3] 나가기");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BuyItem();
                        break;
                    case "2":
                        SellItem();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 엔터를 누르세요.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // 1. 아이템 구매
        private static void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("==== 상점 아이템 목록 ====");

            for (int i = 0; i < ItemDatabase.AllItems.Count; i++)
            {
                var item = ItemDatabase.AllItems[i];
                Console.WriteLine(item.GetSummary(i + 1));
            }

            Console.WriteLine("==========================");
            Console.WriteLine("구매할 아이템 번호를 입력하세요. (0: 취소)");

            if (!int.TryParse(Console.ReadLine(), out int input) || input < 0 || input > ItemDatabase.AllItems.Count)
            {
                Console.WriteLine("잘못된 입력입니다. 엔터를 누르세요.");
                Console.ReadLine();
                return;
            }

            if (input == 0) return;

            var selectedItem = ItemDatabase.AllItems[input - 1];

            if (Inventory.Items.Contains(selectedItem))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                Console.ReadLine();
                return;
            }

            if (Status.Money < selectedItem.Price)
            {
                Console.WriteLine("소지금이 부족합니다.");
                Console.ReadLine();
                return;
            }

            // 구매 성공
            Status.Money -= selectedItem.Price;
            Inventory.AddItem(selectedItem);
            Console.WriteLine($"'{selectedItem.Name}'을(를) 구매했습니다!");
            Console.ReadLine();
        }

        // 2. 아이템 판매
        private static void SellItem()
        {
            while (true)
            {
                Console.Clear();
                if (Inventory.Items.Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("==== 판매 가능한 아이템 목록 ====");
                int index = 1;
                for (int i = 0; i < Inventory.Items.Count; i++)
                {
                    var item = Inventory.Items[i];
                    if (Inventory.IsEquipped(item))
                    {
                        Console.WriteLine($"[{index}] {item.Name} - 장착중인 아이템입니다. 판매할 수 없습니다.");
                    }
                    else
                    {
                        Console.WriteLine(item.GetSummary(index));
                    }
                    index++;
                }

                Console.WriteLine("=============================");
                Console.WriteLine("판매할 아이템 번호를 입력하세요. (0: 취소)");

                if (!int.TryParse(Console.ReadLine(), out int input) || input < 0 || input > Inventory.Items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다. 엔터를 누르세요.");
                    Console.ReadLine();
                    continue;
                }

                if (input == 0) return;

                var selectedItem = Inventory.Items[input - 1];

                if (Inventory.IsEquipped(selectedItem))
                {
                    Console.WriteLine("장착중인 아이템입니다. 판매하실 수 없습니다.");
                    Console.ReadLine();
                    continue;
                }

                // 판매 가격 계산 (70% 반올림)
                int sellPrice = (int)Math.Round(selectedItem.Price * 0.7 / 100.0) * 100;

                Status.Money += sellPrice;
                Inventory.RemoveItem(selectedItem);
                Console.WriteLine($"'{selectedItem.Name}'을(를) 판매했습니다. +{sellPrice}원");
                Console.ReadLine();
            }
        }
    }
}
