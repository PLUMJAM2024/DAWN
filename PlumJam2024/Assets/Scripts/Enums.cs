using System.Collections.Generic;

public class Enums {

    public enum Menu {
        bread,
        cake,
        coffee
    }

    public static Dictionary<Menu, float> MenuTime = new Dictionary<Menu, float>() {
    { Menu.bread, 4f },
    { Menu.cake, 8f },
    { Menu.coffee, 6f }
    };


    public enum Emoji {
        orderwaiting,
        menuwaiting,
        enjoying,
        angryleaving
    }
}
