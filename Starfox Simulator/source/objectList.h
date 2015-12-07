class ShipList
{
public:
	inline ShipList();
	inline void insert(ship*);
	inline void reset();
	inline void next();
	inline ship* currentItem();
	inline void cleanUp();
private:
	class ShipListItem
	{
	public:
		ship* item;
		ShipListItem* next;
	};

	ShipListItem* head;
	ShipListItem* current;
};

ShipList::ShipList()
{
	head=NULL;
	current=NULL;
}
void ShipList::insert(ship* s)
{
	ShipListItem* newItem=new ShipListItem;
	newItem->item=s;
	newItem->next=head;
	head=newItem;
}

void ShipList::reset()
{
	current=head;
}

void ShipList::next()
{
	if(current!=NULL)
		current=current->next;
}

ship* ShipList::currentItem()
{
	if(current!=NULL)
		return current->item;
	else
		return NULL;
}

void ShipList::cleanUp()
{
	ShipListItem* i=new ShipListItem;
	i->next=head;
	bool pastHead=false;
	while(i->next!=NULL)
	{
		if(i->next->item->mesh->destroyed)
		{
			delete i->next->item;
			ShipListItem* delItem=i->next;
			i->next=delItem->next;
			delete delItem;
			if(!pastHead)
				head=i->next;
		}
		else
		{
			i=i->next;
			pastHead=true;
		}
	}
}

///////////////////////////////////
///////////////////////////////////
///////////////////////////////////
class ShotList
{
public:
	inline ShotList();
	inline void insert(shot*);
	inline void reset();
	inline void next();
	inline shot* currentItem();
	inline void cleanUp();
private:
	class ShotListItem
	{
	public:
		shot* item;
		ShotListItem* next;
	};

	ShotListItem* head;
	ShotListItem* current;
};

ShotList::ShotList()
{
	head=NULL;
	current=NULL;
}

void ShotList::insert(shot* s)
{
	ShotListItem* newItem=new ShotListItem;
	newItem->item=s;
	newItem->next=head;
	head=newItem;
}

void ShotList::reset()
{
	current=head;
}

void ShotList::next()
{
	if(current!=NULL)
		current=current->next;
}

shot* ShotList::currentItem()
{
	if(current!=NULL)
		return current->item;
	else
		return NULL;
}

void ShotList::cleanUp()
{
	ShotListItem* i=new ShotListItem;
	i->next=head;
	bool pastHead=false;
	while(i->next!=NULL)
	{
		if(i->next->item->m->destroyed)
		{
			delete i->next->item;
			ShotListItem* delItem=i->next;
			i->next=delItem->next;
			delete delItem;
			if(!pastHead)
				head=i->next;
		}
		else 
		{
			i=i->next;
			pastHead=true;
		}
	}
}
/////////////////////////////////////////////////////
/////////////////////////////////////////////////////
/////////////////////////////////////////////////////

class MeshList
{
public:
	inline MeshList();
	inline void insert(mesh_object*);
	inline void reset();
	inline void next();
	inline mesh_object* currentItem();
	inline void cleanUp();
private:
	class MeshListItem
	{
	public:
		mesh_object* item;
		MeshListItem* next;
	};

	MeshListItem* head;
	MeshListItem* current;
};

MeshList::MeshList()
{
	head=NULL;
	current=NULL;
}

void MeshList::insert(mesh_object* m)
{
	MeshListItem* newItem=new MeshListItem;
	newItem->item=m;
	newItem->next=head;
	head=newItem;
}

void MeshList::reset()
{
	current=head;
}

void MeshList::next()
{
	if(current!=NULL)
		current=current->next;
}

mesh_object* MeshList::currentItem()
{
	if(current==NULL)
		return NULL;
	else
		return current->item;
}

void MeshList::cleanUp()
{
	MeshListItem* i=new MeshListItem;
	i->next=head;
	bool pastHead=false;
	while(i->next!=NULL)
	{
		if(i->next->item->destroyed)
		{
			delete i->next->item;
			MeshListItem* delItem=i->next;
			i->next=delItem->next;
			delete delItem;
			if(!pastHead)
				head=i->next;
		}
		else
		{
			i=i->next;
			pastHead=true;
		}
	}
}
