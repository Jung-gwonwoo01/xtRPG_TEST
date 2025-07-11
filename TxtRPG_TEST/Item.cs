using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtRPG_TEST
{
    public class Item
    {
        public string Name { get; set; }            // 아이템 이름
        public int Power { get; set; }              // 공격력 or 방어력
        public string Slot { get; set; }            // 무기 or 갑옷
        public int Price { get; set; }              // 아이템 가격
        public string Description { get; set; }     // 설명
        public bool IsWeapon { get; set; }          // 무기 여부

        public Item(string name, int power, string slot, int price, string description, bool isWeapon)
        {
            Name = name;
            Power = power;
            Slot = slot;
            Price = price;
            Description = description;
            IsWeapon = isWeapon;
        }

        // 아이템 정보 출력 (한 줄 요약용)
        public string GetSummary(int number)
        {
            string typeText = IsWeapon ? $"공격력 +{Power}" : $"방어력 +{Power}";
            return $"[{number}] {Name} / {typeText} / {Slot} / {Price}원 / \"{Description}\"";
        }
    }

    public static class ItemDatabase
    {
        public static List<Item> AllItems = new List<Item>
    {
        new Item("낡은 검", 2, "무기", 1200, "손 쉽게 구할 수 있는 검형태의 무기이다.", true),
        new Item("낡은 갑옷", 3, "갑옷", 1800, "냄새가 나는 오래된 갑옷이다. 누군가 입었던 흔적이 있다.", false),
        new Item("낡은 낫", 1, "무기", 1500, "부식이 일어났지만 쓸만해 보이는 낫이다.", true),
        new Item("검", 7, "무기", 3000, "잘 만들어진 검이다. 당신은 이 검을 어디선가 본적 있는것 같다.", true)
    };
    }
}
