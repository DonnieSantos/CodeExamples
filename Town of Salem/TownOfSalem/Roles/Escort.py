from Role import *
from Alignments.Alignment import *

class Escort(Role):
    def __init__(self):
        return super().__init__("Escort", Aligment.TownSupport)