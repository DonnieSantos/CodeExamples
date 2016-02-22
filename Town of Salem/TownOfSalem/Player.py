class Player(object):
    def __init__(self, name, role):
        self.name = name
        self.role = role
    def toString(self):
        return "%s %s" % (self.name.ljust(15), self.role.toString())