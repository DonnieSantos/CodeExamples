from Role import *
from Alignments.Alignment import *

class Arsonist(Role):
    def __init__(self):
        return super().__init__("Arsonist", Aligment.NeutralKilling)