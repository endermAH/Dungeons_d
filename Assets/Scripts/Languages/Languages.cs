using System.Collections.Generic;

namespace Languages
{
    public readonly struct WeaponDescription
    {
        public static TranslatableString Damage = new TranslatableString(new[] {"Damage", "Урон"});
        public static TranslatableString AttackSpeed = new TranslatableString(new[] {"Attack speed", "Скорость атаки"});
        public static TranslatableString AttackRadius = new TranslatableString(new[] {"Attack radius", "Радиус атаки"});
        
        public readonly TranslatableString Name;
        public readonly TranslatableString Description;

        public WeaponDescription(TranslatableString name, TranslatableString description)
        {
            Name = name;
            Description = description;
        }
    }
    public static class Languages
    {
        public const string English = "English";
        public const string Russian = "Russian";
        
        public static string[] SupportedLanguages = {Languages.English, Languages.Russian};
        
        public static WeaponDescription RegularSword = new WeaponDescription(
            new TranslatableString(new[] {"Regular sword", "Обычный меч"}),
            new TranslatableString(new[] {"This is a regular sword which you can buy in any swordshop", "Это самый обычный меч, который вы можете купить в любом магазине мечей"})
            );
    }
}
