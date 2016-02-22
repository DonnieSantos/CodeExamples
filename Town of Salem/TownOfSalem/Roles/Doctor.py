from Role import *
from Alignments.Alignment import *

class Doctor(Role):
    def __init__(self):
        return super().__init__("Doctor", Aligment.TownProtective)