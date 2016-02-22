from Role import *
from Alignments.Alignment import *

class Framer(Role):
    def __init__(self):
        return super().__init__("Framer", Aligment.MafiaSupport)