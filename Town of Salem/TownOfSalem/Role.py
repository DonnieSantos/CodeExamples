class Role(object):
    def __init__(self, name, alignment):
        self.name = name
        self.alignment = alignment
    def toString(self):
        return "%s %s" % (self.name.ljust(15), self.alignment.value.ljust(15))