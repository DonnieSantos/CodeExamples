from Role import *
from Alignments.Alignment import *

class Witch(Role):
    def __init__(self):
        return super().__init__("Witch", Aligment.NeutralEvil)