/*The following is a collection of code from previous SourceMod plugins I have written, used to represent constant, linear, and quadratic run-time.
Because SourcePawn, the language used by SourceMod, is very similar to C# in many ways, I have provided both the original SP code, as well as hypothetical
C# rewrites for the sake of this course.*/

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//CONSTANT (O(1)) RUN-TIME EXAMPLE:

/*One of my plugins allows the user to build miniature UFOs, called drones, which will then follow them and perform a variety of tasks. If the player
has reached their maximum number of drones, and they attempt to build another one, their oldest drone will be destroyed.

This method demonstrates constant run-time, as no matter how large the player's drone array is, it will only ever destroy the drone in slot 0. As such,
the user can have two drones or two hundred, this method does not care, and will always take the same amount of time to execute.*/

//ORIGINAL SP CODE:

public void Drone_DestroyOldest(int client)
{
	if (!IsValidClient(client))
		return;
		
	int oldest = Drone_UserDrones[client][0];
	
	if (IsValidEntity(oldest))
	{
		Drone_DestroyDrone(oldest);
	}
}

//HYPOTHETICAL C# REWRITE:

public void Drone_DestroyOldest(Drone[] DroneArray)
{
  if (DroneArray[0] != null)
  {
    DroneArray[0].DestroyDrone();
  }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//LINEAR (O(n)) RUN-TIME EXAMPLE:

/*One incredibly common linear run-time method I have become very familiar with in my time as a SourceMod programmer is the area of effect attack.
It's a fairly simple concept: deal damage to all enemies within a given radius. I've used it for explosions, magic, shockwaves, electricity - 
if you can think of an ability which would deal damage in an area, odds are I've coded it, both with and without damage falloff. Regardless, 
even with all of its flavors, ice cream is still ice cream, just as area of effect damage is still area of effect damage.

This demonstrates linear run-time. In the original SP code, "N" is the number of players on the enemy team, whereas in the hypothetical C# rewrite,
N is the size of the victims array. Regardless, the run-time increases by a consistent amount depending on the size of N, as it only cycles through
the given data one time per cycle. It is not independent of N, like in constant run-time, nor does its run-time grow exponentially larger like in
quadratic run-time.*/

//ORIGINAL SP CODE:

public void GenericAreaDMG(int attacker, float GroundZero[3], float radius, float damage)
{
  if (!IsValidClient(attacker))
    return;
    
  for (int i = 1; i <= MaxClients; i++)
  {
    if (IsValidClient(i) && IsPlayerAlive(i) && TF2_GetClientTeam(i) != TF2_GetClientTeam(attacker))
    {
      float VicLoc[3];
      GetClientAbsOrigin(i, VicLoc);
      
      if (GetVectorDistance(GroundZero, VicLoc) <= radius)
      {
        DealDamage(i, attacker, damage);
      }
    }
  }
}

//HYPOTHETICAL C# REWRITE:

public void GenericAreaDMG(Player attacker, Player[] victims, Vector3 GroundZero, float radius, float damage)
{
  if (attacker == null)
    return;
   
  foreach(Player i in victims)
  {
    if (GetVectorDistance(GroundZero, Player.Origin) <= radius)
    {
      DealDamage(i, attacker, damage);
    }
  }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//QUADRATIC (O(n^2)) RUN-TIME EXAMPLE:

/*Lastly, I have a plugin which allows the player to plant trip mines on surfaces. These trip mines arm themselves automatically after a short delay.
While armed, these trip mines scan for and connect to nearby trip mines planted by the same user, and connect to them with a team-colored laser.
When an enemy walks through one of these lasers, the mines connected by the laser will detonate. The method I have provided here is what I use in order
to connect the beams to one another.

This method demonstrates quadratic run-time, as it nests two loops. The outer loop runs N times, while the inner loop runs N times per cycle of the outer
loop. As such, this method runs O(N^2) times.*/

//ORIGINAL SP CODE:

public void Trip_TrackPlanted(int client)
{
	if (!IsValidClient(client))
	return;
	
	for (int mine = 0; mine < 12; mine++)
	{
		int ent = Trip_Entities[client][mine];
		
		if (IsValidEntity(ent) && ent > MaxClients && ent <= MAXENTITIES)
		{
			if (Trip_Armed[ent] && HasEntProp(ent, Prop_Send, "m_vecOrigin"))
			{
				float EntLoc[3];
				GetEntPropVector(ent, Prop_Send, "m_vecOrigin", EntLoc);
				
				for (int mine2 = 0; mine2 < 12; mine2++)
				{
					int ent2 = Trip_Entities[client][mine2];
					
					if (IsValidEntity(ent2) && ent2 != ent && ent2 > MaxClients && ent2 <= MAXENTITIES)
					{
						if (Trip_Armed[ent2] && HasEntProp(ent2, Prop_Send, "m_vecOrigin"))
						{
							float EntLoc2[3];
							GetEntPropVector(ent2, Prop_Send, "m_vecOrigin", EntLoc2);
							
							if (GetVectorDistance(EntLoc, EntLoc2, true) <= Pow(Trip_Radius[client], 2.0))
							{
								Beam_SpawnTeamColoredBeam(client, EntLoc, EntLoc2);
							}
						}
					}
				}
			}
		}
	}
}

//HYPOTHETICAL C# REWRITE:

public void Trip_TrackPlanted(TripMine[] mines)
{
  foreach(TripMine mine in mines)
  {
    Vector3 MineLoc1 = mine.Origin;
    
    foreach(TripMine mine2 in mines)
    {
      if (mine2 != mine)
      {
        Vector3 MineLoc2 = mine2.Origin;
        
        if (GetVectorDistance(MineLoc1, MineLoc2) <= mine.Radius)
        {
          Utility.SpawnTeamColoredBeam(mine.Owner, MineLoc, MineLoc2);
        }
      }
    }
  }
}
