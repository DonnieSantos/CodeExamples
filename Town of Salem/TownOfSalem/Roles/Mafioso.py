from Role import *
from Alignments.Alignment import *

class Mafioso(Role):
    def __init__(self):
        return super().__init__("Mafioso", Aligment.MafiaKilling)