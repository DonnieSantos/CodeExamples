from Role import *
from Alignments.Alignment import *

class Investigator(Role):
    def __init__(self):
        return super().__init__("Investigator", Aligment.TownInvestigative)