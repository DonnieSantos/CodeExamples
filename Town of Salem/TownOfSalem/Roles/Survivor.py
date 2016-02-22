from Role import *
from Alignments.Alignment import *

class Survivor(Role):
    def __init__(self):
        return super().__init__("Survivor", Aligment.NeutralBenign)