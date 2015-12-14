#ifndef _MATERIALS_H_
#define _MATERIALS_H_

class material
{
public:
	float kar, kag, kab;
	float kdr, kdg, kdb;
	float ksr, ksg, ksb;
	int illum;
	float ns;
	float alpha;
	char name[1024];
};

class materialList
{
private:
	class listItem
	{
	public:
		material* data;
		listItem* next;
	};
	listItem* head;
public:
	materialList();
	~materialList();
	void add(material* m);
	material* find(char* s);
};

materialList::materialList()
{
	head=NULL;
}

void materialList::add(material* m)
{
	listItem* newItem=new listItem;
	newItem->data=m;
	newItem->next=head;
	head=newItem;
}

material* materialList::find(char* s)
{
	listItem* searchItem=head;
	while(searchItem!=NULL)
	{
		if(!strcmp(s, searchItem->data->name))
			return searchItem->data;
		else
			searchItem=searchItem->next;
	}
	return NULL;
}

materialList::~materialList()
{
	listItem* delItem=head;
	while(delItem!=NULL)
	{
		listItem* nextItem=delItem->next;
		delete delItem;
		delItem=nextItem;
	}
}

#endif