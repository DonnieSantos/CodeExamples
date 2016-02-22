from Role import *
from Alignments.Alignment import *

class Amnesiac(Role):
    def __init__(self):
        return super().__init__("Amnesiac", Aligment.NeutralBenign)