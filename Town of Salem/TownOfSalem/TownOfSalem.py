from Player import Player
from Roles.Jailor import Jailor
from Roles.RoleGenerator import RoleGenerator
from Alignments.Alignment import Aligment
from Town import Town

# jailorRole = Jailor()
# jailor = Player("Giles Corey", jailorRole)
# print(jailor.toString())

# randomRole = RoleGenerator().CreateRole(Aligment.NeutralEvil)
# randomDude = Player("Alice Parker", randomRole)
# print(randomDude.toString())

town = Town()
town.print()