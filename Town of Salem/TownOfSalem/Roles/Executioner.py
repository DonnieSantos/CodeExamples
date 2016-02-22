from Role import *
from Alignments.Alignment import *

class Executioner(Role):
    def __init__(self):
        return super().__init__("Executioner", Aligment.NeutralEvil)