namespace Constants
    {
    public enum BATTLESTATE
    {
        IDLE,
        ATTACK,
        BLOCK,
        PARRY,
        EVADE
    }

    public enum MOVESTATE
    {
        IDLE,
        FORWARD,
        BACK,
        RUN,
        JUMP,
        STOOP,
        DIE

    }

    public enum DIRECTION
    {
        LEFT,
        RIGHT
    }

    public enum TYPE
    {
        FIRE,
        ICE,
        POISON,
        MAGIC,
        EARTH
    }

    public enum RARITY
    {
        COMMON,
        RARE,
        LEGENDARY
    }

    public enum ALLIANCE
    {
        FRIEND,
        ENEMY
    }

    public enum GAMEELEMENT
    {
        BASE,
        TOWER,
        WARRIOR,
        MINION,
        SUMMONED
    }

    public enum INPUT
    {
        PC,
        WINCONTROL,
    }
}

