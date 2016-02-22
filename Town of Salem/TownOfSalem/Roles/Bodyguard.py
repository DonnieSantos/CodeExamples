from Role import *
from Alignments.Alignment import *

class Bodyguard(Role):
    def __init__(self):
        return super().__init__("Bodyguard", Aligment.TownProtective)