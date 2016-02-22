from Roles.RoleGenerator import RoleGenerator
from Alignments.Alignment import Aligment
from Roles.Jailor import Jailor
from Roles.Godfather import Godfather
from Roles.Mafioso import Mafioso
from Player import Player

class Town(object):
    def __init__(self):
        self.town = []
        self.town.append(Player("Jailor", Jailor()))
        self.town.append(Player("Invest", RoleGenerator.SharedInstance().CreateRole(Aligment.TownInvestigative)))
        self.town.append(Player("Invest", RoleGenerator.SharedInstance().CreateRole(Aligment.TownInvestigative)))
        self.town.append(Player("Support", RoleGenerator.SharedInstance().CreateRole(Aligment.TownSupport)))
        self.town.append(Player("Support", RoleGenerator.SharedInstance().CreateRole(Aligment.TownSupport)))
        self.town.append(Player("Protect", RoleGenerator.SharedInstance().CreateRole(Aligment.TownProtective)))
        self.town.append(Player("TownKill", RoleGenerator.SharedInstance().CreateRole(Aligment.TownKilling)))
        self.town.append(Player("RandomTown", RoleGenerator.SharedInstance().CreateRole(Aligment.RandomTown)))
        self.town.append(Player("Godfather", Godfather()))
        self.town.append(Player("Mafioso", Mafioso()))
        self.town.append(Player("RandomMafia", RoleGenerator.SharedInstance().CreateRole(Aligment.MafiaSupport)))
        self.town.append(Player("NeutralKill", RoleGenerator.SharedInstance().CreateRole(Aligment.NeutralKilling)))
        self.town.append(Player("NeutralEvil", RoleGenerator.SharedInstance().CreateRole(Aligment.NeutralEvil)))
        self.town.append(Player("NeutralBenign", RoleGenerator.SharedInstance().CreateRole(Aligment.NeutralBenign)))
        self.town.append(Player("Any", RoleGenerator.SharedInstance().CreateRole(Aligment.Any)))
        return

    def print(self):
        for player in self.town:
            print(player.toString())
        return