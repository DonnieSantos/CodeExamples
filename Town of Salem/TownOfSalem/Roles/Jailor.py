from Role import *
from Alignments.Alignment import *

class Jailor(Role):
    def __init__(self):
        return super().__init__("Jailor", Aligment.TownKilling)