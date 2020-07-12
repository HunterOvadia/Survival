using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Flags]
public enum NPCFlags
{
    FLAG_FRIENDLY = (1 << 0),
    FLAG_ENEMY = (1 << 1),
    FLAG_DIALOGUE = (1 << 2),
    FLAG_SHOP = (1 << 3),
    FLAG_QUESTGIVER = (1 << 4)
}