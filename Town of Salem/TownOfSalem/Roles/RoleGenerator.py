from Alignments.Alignment import Aligment
from Roles.Investigator import Investigator
from Roles.Executioner import Executioner
from Roles.Bodyguard import Bodyguard
from Roles.Vigilante import Vigilante
from Roles.Veteran import Veteran
from Roles.Sheriff import Sheriff
from Roles.Doctor import Doctor
from Roles.Escort import Escort
from Roles.Lookout import Lookout
from Roles.Jester import Jester
from Roles.Witch import Witch
from Roles.Framer import Framer
from Roles.Survivor import Survivor
from Roles.SerialKiller import SerialKiller
from Roles.Werewolf import Werewolf
from Roles.Arsonist import Arsonist
from Roles.Amnesiac import Amnesiac
import random

class RoleGenerator(object):

    #########################################################################################################
    #########################################################################################################

    def __init__(self):
        return

    #########################################################################################################
    #########################################################################################################

    @staticmethod
    def SharedInstance():
        return RoleGenerator()

    #########################################################################################################
    #########################################################################################################

    def compareAlignment(self, alignment, acceptableAlignments) :
        for acceptableAlignment in acceptableAlignments :
            if alignment == acceptableAlignment :
                return True
        return False

    #########################################################################################################
    #########################################################################################################

    def CreateRole(self, alignment):

        eligibleRoles = []

        if self.compareAlignment(alignment, [Aligment.TownInvestigative, Aligment.RandomTown, Aligment.Any]) :
            eligibleRoles.append(Sheriff())
            eligibleRoles.append(Investigator())
        if self.compareAlignment(alignment, [Aligment.TownProtective, Aligment.RandomTown, Aligment.Any]) :
            eligibleRoles.append(Bodyguard())
            eligibleRoles.append(Doctor())
        if self.compareAlignment(alignment, [Aligment.TownSupport, Aligment.RandomTown, Aligment.Any]) :
            eligibleRoles.append(Escort())
            eligibleRoles.append(Lookout())
        if self.compareAlignment(alignment, [Aligment.TownKilling, Aligment.RandomTown, Aligment.Any]) :
            eligibleRoles.append(Veteran())
            eligibleRoles.append(Vigilante())
        if self.compareAlignment(alignment, [Aligment.MafiaSupport, Aligment.Any]) :
            eligibleRoles.append(Framer())
        if self.compareAlignment(alignment, [Aligment.NeutralKilling, Aligment.Any]) :
            eligibleRoles.append(SerialKiller())
            eligibleRoles.append(Werewolf())
            eligibleRoles.append(Arsonist())
        if self.compareAlignment(alignment, [Aligment.NeutralEvil, Aligment.Any]) :
            eligibleRoles.append(Jester())
            eligibleRoles.append(Executioner())
            eligibleRoles.append(Witch())
        if self.compareAlignment(alignment, [Aligment.NeutralBenign, Aligment.Any]) :
            eligibleRoles.append(Survivor())
            eligibleRoles.append(Amnesiac())

        randomIndex = random.randint(0, len(eligibleRoles) - 1)

        return eligibleRoles[randomIndex]

    #########################################################################################################
    #########################################################################################################