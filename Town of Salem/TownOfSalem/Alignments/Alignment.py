from enum import Enum

class Aligment(Enum):

    TownInvestigative = "Town (Investigative)"
    TownProtective = "Town (Protective)"
    TownSupport = "Town (Support)"
    TownKilling = "Town (Killing)"

    MafiaKilling = "Mafia (Killing)"
    MafiaSupport = "Mafia (Support)"

    NeutralEvil = "Neutral (Evil)"
    NeutralKilling = "Neutral (Killing)"
    NeutralBenign = "Neutral (Benign)"

    RandomTown = "Random Town"
    Any = "Any"