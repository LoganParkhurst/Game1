using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class Map
    {
        public string map0 = @"
                         ========
                         |      |
                         |      \
                         |      |
                         |      |
                         |      |
                         \      |
                         |      \
                         |      |
                         |      |
                         |      |
                         \      |
                         /      \
                         |      |
                         |      |
                         =\  @ /=
                           \  /
                          Outside";
        public string map1 = @"
                         ========
                         |      |         
                         |      \         
                         |      |         
                         |      |         
                         |      | 
                         \      |         
                         |      \         
         =================      |        
         |               |      | 
         |               |      |         
         |               \      |         
         |       @       /      \         
         |               |      |         
         |               |      |         
         =================\    /=
                           \  /
                          Outside";
        public string map2 = @"
                         ========
                         |      |         
                         |      \         
                         |      |         
                         |      |         
                         |      |
                         \      |         
                         |      \         
                         |      |         
                         |      ==========
                         |      |        |
                         \      |        |
                         /      \   @    |
                         |      |        |
                         |      |        |
                         =\    /==========
                           \  /
                          Outside";
        public string map3 = @"
                         ========
                         |      |        
                         |      \        
                         |      |        
                         |      |        
                         |      ==========
                         \      |        |
                         |      \   @    |
                         |      |        |
                         |      ==========
                         |      |        
                         \      |        
                         /      \        
                         |      |        
                         |      |        
                         =\    /=
                           \  /
                          Outside";
        public string map4 = @"
                         =================
                         |      |        |
                         |      \    @   |
                         |      |        |
                         |      |        |
                         |      ==========
                         \      |
                         |      \
                         |      |
                         |      |
                         |      |
                         \      |
                         /      \
                         |      |
                         |      |
                         =\    /=
                           \  /
                          Outside";
        public string map5 = @"
                         ========
                         |      |        
                         |      \        
                         |      |        
         ============/===|      |        
         |               |      |
         |       @       \      |        
         |               |      \        
         =================      |        
                         |      |
                         |      |        
                         \      |        
                         /      \        
                         |      |        
                         |      |        
                         =\    /=
                           \  /
                          Outside";
        public string map6 = @"
                 ================
                 |       |      |        
                 \   @   |      \        
                 |       |      |        
         ============/===|      |        
         |               |      |
         |               \      |        
         |               |      \        
         =================      |        
                         |      |
                         |      |        
                         \      |        
                         /      \        
                         |      |        
                         |      |        
                         =\    /=
                           \  /
                          Outside";
        public string map7 = @"
         ========================
         |       |       |      |         
         |   @   \       |      \         
         |       |       |      |         
         ============/===|      |         
         |               |      |
         |               \      |        
         |               |      \        
         =================      |        
                         |      |
                         |      |        
                         \      |        
                         /      \        
                         |      |        
                         |      |        
                         =\    /=
                           \  /
                          Outside";
       
        /*
         This is the map of the game
         =================================
         |       |       |      |        |
         |   7   \   6   |      \        |
         |       |       |      |   4    |
         ============/===|      |        |
         |               |      ==========
         |       5       \      |        |
         |               |  8   \   3    |
         =================      |        |
         |               |      ==========
         |               |      |        |
         |               \      |        |
         |      1        /      \   2    |
         |               |      |        |
         |               |      |        |
         =================\  0 /==========
                           \  /
                          Outside
        * -Enemy
        0: Main Door
        1: Grand Hall*
        2: Waiting room
        3: Bathroom
        4: Guest Room*
        5: Office
        7: Storage closet
        6: air lock*
        8: Hall Way*
         */
    }
}
