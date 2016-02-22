from Role import *
from Alignments.Alignment import *

class Sheriff(Role):
    def __init__(self):
        return super().__init__("Sheriff", Aligment.TownInvestigative)