using System.Collections.Generic;

public class Enums {

    public enum Menu {
        None,
        cheesecake,
        chocolatecake,
        cookiecheesecake,
        croissant,
        pancake,
        chocolatepancake,
        tirimasu
    }

    public static Dictionary<Menu, float> MenuTime = new Dictionary<Menu, float>() {
        { Menu.None, 0f },
        { Menu.cheesecake, 4f },
        { Menu.chocolatecake, 8f },
        { Menu.cookiecheesecake, 6f },
        { Menu.croissant, 6f },
        { Menu.pancake, 4f },
        { Menu.chocolatepancake, 6f },
        { Menu.tirimasu, 12f }
    };


    public enum Emoji {
        orderwaiting,
        menuwaiting,
        enjoying,
        angryleaving
    }
}
