from Role import *
from Alignments.Alignment import *

class SerialKiller(Role):
    def __init__(self):
        return super().__init__("Serial Killer", Aligment.NeutralKilling)