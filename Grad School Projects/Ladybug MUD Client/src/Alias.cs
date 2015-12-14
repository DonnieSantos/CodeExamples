using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////

[Serializable]
class alias

{
  public alias() { }
  public string name;
  public string output;
}

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////

[Serializable]
class action

{
  public int trigger_size;
  public int outcome_size;
  public string[] trigger;
  public string[] outcome;

  public action(string s1, string s2)

  {
    trigger_size = count_strings(s1);
    outcome_size = count_strings(s2);

    trigger = new string [trigger_size];
    outcome = new string [outcome_size];

    int trigger_count = 0;
    int outcome_count = 0;
    int current = 0;

    for (int i=0; i<s1.Length; i++)
    if (s1[i] == '%')

    {
      int j = check_variable(s1, i);

      if (j > 0)

      {
        if (i > current)

        {
          trigger[trigger_count] = s1.Substring(current, i-current);
          trigger_count++;
        }

        trigger[trigger_count] = s1.Substring(i, j+1);
        trigger_count++;

        current = i + j + 1;
      }
    }

    trigger[trigger_count] = s1.Substring(current, s1.Length-current);
    if (trigger[trigger_count] == "") trigger_size--;

    current = 0;

    for (int i=0; i<s2.Length; i++)
    if (s2[i] == '%')

    {
      int j = check_variable(s2, i);

      if (j > 0)

      {
        if (i > current)

        {
          outcome[outcome_count] = s2.Substring(current, i-current);
          outcome_count++;
        }

        outcome[outcome_count] = s2.Substring(i, j+1);
        outcome_count++;

        current = i + j + 1;
      }
    }

    outcome[outcome_count] = s2.Substring(current, s2.Length-current);
    if (outcome[outcome_count] == "") outcome_size--;
  }

  // ************************************************************************** //
  // ************************************************************************** //
  // ************************************************************************** //

  public int count_strings(string s)

  {
    int count = 1;
    int current = 0;

    for (int i=0; i<s.Length; i++)
    if (s[i] == '%')

    {
      int j = check_variable(s, i);

      if (j > 0)

      {
        if (i > current) count++;
        count++;
        current = i + j + 1;
      }
    }

    return count;
  }

  public int check_variable(string s, int n)

  {
    bool left_ok = false;
    bool right_ok = false;
    int variable_length = 0;

    if (n == 0) left_ok = true;
    else if ((n > 0) && (s[n-1] == ' ')) left_ok = true;

    if ((s.Length > n+1) && (is_number(s[n+1]) == true))

    {
      variable_length = 1;

      if (s.Length == n+2) right_ok = true;
      else if ((s.Length > n+2) && (s[n+2] == ' ')) right_ok = true;

      else if ((s.Length > n+2) && (is_number(s[n+2]) == true))

      {
        variable_length = 2;

        if (s.Length == n+3) right_ok = true;
        else if ((s.Length > n+3) && (s[n+3] == ' ')) right_ok = true;
      }
    }

    if ((right_ok) && (left_ok)) return variable_length;

    return 0;
  }

  public bool is_number(char c)

  {
    if ((c >= 48) && (c <= 57)) return true;
    return false;
  }

  public string get_trigger()

  {
    string temp = "";

    for (int i=0; i<trigger_size; i++)
      temp += trigger[i];

    return temp;
  }

  public string get_outcome()

  {
    string temp = "";

    for (int i=0; i<outcome_size; i++)
      temp += outcome[i];

    return temp;
  }

  // ************************************************************************** //
  // ****************************** Apply Action ****************************** //
  // ************************************************************************** //

  public string apply_action(string s)

  {
    s = s.Trim();
    s = s.TrimStart('\n');
    s = s.TrimEnd('\n');
    s = s.TrimStart('\r');
    s = s.TrimEnd('\r');
    
    int[] pos = new int [trigger_size];

    for (int i=0; i<trigger_size; i++)

    {
      string temp = trigger[i];

      if (temp[0] != '%') pos[i] = s.IndexOf(temp);
      else pos[i] = -2;

      if (pos[i] == -1) return "";
    }

    int current = 0;

    for (int i=0; i<trigger_size-1; i++)
    if (pos[i] >= 0)

    {
      if (pos[i] < current) return "";
      current = pos[i];
    }

    if (pos[0] == -2) pos[0] = 0;
    
    for (int i=1; i<trigger_size-1; i++)
    if (pos[i] == -2)
    
    {
      pos[i] = pos[i-1] + trigger[i-1].Length;
    }

    string str = "";

    for (int i=0; i<outcome_size; i++)

    {
      string com = outcome[i];

      if (com[0] != '%') str = str + com;

      else

      {
        com = com.Substring(1);
        int var_id = Int32.Parse(com);

        for (int j=0; j<trigger_size; j++)

        {
          string trig = trigger[j];

          if (trig[0] == '%')

          {
            trig = trig.Substring(1);
            int trig_id = Int32.Parse(trig);

            if (trig_id == var_id)

            {
              int pos1 = pos[j];
              int pos2 = s.Length;
              
              if ((j+1) < (trigger_size)) pos2 = pos[j+1];
              
              string rep = s.Substring(pos1, (pos2-pos1));

              str = str + rep;
            }
          }
        }
      }
    }

    //Console.WriteLine("OUTPUT:  [" + s + "]");
    //Console.WriteLine("COMMAND: [" + str + "]");
    return str;
  }
}

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////

[Serializable]
public class alias_list

{
  public ArrayList list;

  public alias_list()

  {
    list = new ArrayList();
  }

  public int size()
  {
    return list.Count;
  }

  public string apply_aliasing(string s)

  {
    for (int i=0; i<list.Count; i++)

    {
      alias a = (alias)list[i];

      if (s == a.name) return a.output;

      while (s.IndexOf(";;" + a.name) != -1) {
        int pos = s.IndexOf(";;" + a.name);
        s = s.Remove(pos, a.name.Length+2);
        s = s.Insert(pos, ";;" + a.output); }
            
      while (s.IndexOf(a.name + ";;") != -1) {
        int pos = s.IndexOf(a.name + ";;");
        s = s.Remove(pos, a.name.Length+2);
        s = s.Insert(pos, a.output + ";;"); }
      
      if (s.StartsWith(a.name + " "))

      {
        s = s.Remove(0, a.name.Length+1);

        string output;

        if (targeted(a.output)) output = a.output.Replace("%", s);
        else output = a.output + " " + s;

        return output;
      }
    }

    return s;
  }

  // ************************************************************************** //
  // ************************************************************************** //
  // ************************************************************************** //

  public string try_add_alias(string s)

  {
    string a;
    int pos;

    if (s == "") return display_aliases();
    if (s.Trim(' ') == "") return display_aliases();

    if ((has_brackets(s)) && (!check_brackets(s)))
      return "Alias Name Bracket Mismatch.";

    if (has_brackets(s))
    
    {
      pos = s.IndexOf("} ");
      if (pos == -1) return "Alias Name Bracket Mismatch.";
      a = remove_brackets(s);
      s = s.Substring(pos+2, s.Length-pos-2);
      s = s.TrimStart(' '); 
    }

    else 
    
    {
      pos = s.IndexOf(" ");
      if (pos == -1) return "Missing Alias Definition.";
      a = s.Substring(0, pos);
      s = s.Substring(pos, s.Length-pos);
      s = s.TrimStart(' '); 
    }

    if (s.Length < 1) return "Missing Alias Definition.";

    if ((has_brackets(s)) && (!check_brackets(s)))
      return "Alias Name Bracket Mismatch.";

    if (has_brackets(s))
      s = remove_brackets(s);

    a = a.TrimEnd(' ');

    add_alias(a,s);

    return ("Alias Created:  [" + a + "]  --->  [" + s + "]");
  }

  public string try_remove_alias(string s)

  {
    string error_msg = "No Such Alias To Remove.";

    if (s == "") return display_aliases();
    if (s.Trim(' ') == "") return display_aliases();

    s = s.Trim(' ');

    bool removed = remove_alias(s);

    if (!removed) return error_msg;

    return ("Alias Removed:  [" + s + "]");
  }

  public bool add_alias(string s1, string s2)

  {
    alias a = new alias();
    a.name = s1;
    a.output = s2;

    bool found = remove_alias(s1);

    list.Add(a);

    return found;
  }

  public bool remove_alias(string name)

  {
    bool found = false;

    for (int i=0; i<list.Count; i++)

    {
      alias a = (alias)list[i];

      if (a.name == name) 
      {
        list.RemoveAt(i);
        found = true; 
      }
    }

    return found;
  }

  // ************************************************************************** //
  // ************************************************************************** //
  // ************************************************************************** //

  private string display_aliases()

  {
    string temp = "";

    if (list.Count == 0) return ("No Aliases Defined.");

    for (int i=0; i<list.Count; i++)

    {
      alias a = (alias)list[i];
      temp += "[" + a.name + "]  --->  [" + a.output + "]";
      if (i < list.Count-1) temp += "\n";
    }

    return temp;
  }

  private bool has_brackets(string s)

  {
    if (s.Length < 1) return false;
    if (s[0] != '{') return false;

    return true;
  }

  private bool check_brackets(string s)

  {
    if (!has_brackets(s)) return false;
    if (s.IndexOf("}") == -1) return false;

    return true;
  }

  private string remove_brackets(string s)

  {
    s = s.Remove(0,1);
    s = s.TrimStart(' ');

    int pos = s.IndexOf("}");
    s = s.Substring(0, pos);

    return s;
  }

  private bool targeted(string s)

  {
    if (s.IndexOf("%") != -1)
      return true;

    return false;
  }
}

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////

[Serializable]
public class action_list

{
  public ArrayList list;
  private string error_msg = "Action Usage: {trigger sequence} {desired outcome}";

  public action_list()

  {
    list = new ArrayList();
  }

  public int size()
	
  {
    return list.Count;
  }

  public string apply_actions(string s)

  {
    for (int i=0; i<list.Count; i++)

    {
      action temp = (action) list[i];
      string result = temp.apply_action(s);
      if (result != "") return result;
    }
		
    return "";
  }

  // ************************************************************************** //
  // ************************************************************************** //
  // ************************************************************************** //

  public string try_add_action(string s)

  {
    if (s == "") return display_actions();
    if (s.Trim(' ') == "") return display_actions();

    if (!has_brackets(s)) return error_msg;
    if (!check_brackets(s)) return error_msg;

    int pos = s.IndexOf("} ");

    if (pos == -1) return error_msg;

    string trigger = s.Substring(1,pos-1);
    trigger = trigger.Trim(' ');

    string outcome = s.Substring(pos+2, s.Length-pos-2);
    outcome = outcome.Trim(' ');

    if (!has_brackets(outcome)) return error_msg;
    if (!check_brackets(outcome)) return error_msg;

    outcome = remove_brackets(outcome);

    add_action(trigger, outcome);

    return ("Action Created:  [" + trigger + "]  --->  [" + outcome + "]");
  }

  public string try_remove_action(string trigger)

  {
    string error_msg = "No Such Action To Remove.";

    if (trigger == "") return display_actions();
    if (trigger.Trim(' ') == "") return display_actions();

    trigger = trigger.Trim(' ');

    bool removed = remove_action(trigger);

    if (!removed) return error_msg;

    return ("Action Removed:  [" + trigger + "]");
  }

  public bool add_action(string s1, string s2)

  {
    action act = new action(s1, s2);

    bool found = remove_action(s1);

    list.Add(act);

    return found;
  }

  public bool remove_action(string trigger)

  {
    bool found = false;

    for (int i=0; i<list.Count; i++)

    {
      action act = (action)list[i];

      if (act.get_trigger() == trigger) 
      {
        list.RemoveAt(i);
        found = true; }
    }

    return found;
  }

  // ************************************************************************** //
  // ************************************************************************** //
  // ************************************************************************** //

  private string display_actions()

  {
    string temp = "";

    if (list.Count == 0) return ("No Actions Defined.");

    for (int i=0; i<list.Count; i++)

    {
      action act = (action)list[i];
      temp += "[" + act.trigger + "]  --->  [" + act.outcome + "]";
      if (i < list.Count-1) temp += "\n";
    }

    return temp;
  }

  private bool has_brackets(string s)

  {
    if (s.Length < 1) return false;
    if (s[0] != '{') return false;

    return true;
  }

  private bool check_brackets(string s)

  {
    if (!has_brackets(s)) return false;
    if (s.IndexOf("}") == -1) return false;

    return true;
  }

  private string remove_brackets(string s)

  {
    s = s.Remove(0,1);
    s = s.TrimStart(' ');

    int pos = s.IndexOf("}");
    s = s.Substring(0, pos);

    return s;
  }
}