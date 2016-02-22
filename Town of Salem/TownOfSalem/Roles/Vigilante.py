from Role import *
from Alignments.Alignment import *

class Vigilante(Role):
    def __init__(self):
        return super().__init__("Vigilante", Aligment.TownKilling)