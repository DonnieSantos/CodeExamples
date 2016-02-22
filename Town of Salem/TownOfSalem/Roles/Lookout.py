from Role import *
from Alignments.Alignment import *

class Lookout(Role):
    def __init__(self):
        return super().__init__("Lookout", Aligment.TownSupport)