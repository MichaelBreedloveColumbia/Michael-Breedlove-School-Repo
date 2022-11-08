# Overview
The goal of this assignment was to demonstrate our understanding of different processing speeds. I chose to do this by way of converting my old SourceMod work to C#, and explaining how each method demonstrates the various Big-O speeds.

## Constant (O(1)) Run-Time
One of my plugins allows the user to build miniature UFOs, called drones, which will then follow them and perform a variety of tasks. If the player
has reached their maximum number of drones, and they attempt to build another one, their oldest drone will be destroyed.
This method demonstrates constant run-time, as no matter how large the player's drone array is, it will only ever destroy the drone in slot 0. As such,
the user can have two drones or two hundred, this method does not care, and will always take the same amount of time to execute.

## Linear (O(n)) Run-Time
One incredibly common linear run-time method I have become very familiar with in my time as a SourceMod programmer is the area of effect attack.
It's a fairly simple concept: deal damage to all enemies within a given radius. I've used it for explosions, magic, shockwaves, electricity - 
if you can think of an ability which would deal damage in an area, odds are I've coded it, both with and without damage falloff. Regardless, 
even with all of its flavors, ice cream is still ice cream, just as area of effect damage is still area of effect damage.
This demonstrates linear run-time. In the original SP code, "N" is the number of players on the enemy team, whereas in the hypothetical C# rewrite,
N is the size of the victims array. Regardless, the run-time increases by a consistent amount depending on the size of N, as it only cycles through
the given data one time per cycle. It is not independent of N, like in constant run-time, nor does its run-time grow exponentially larger like in
quadratic run-time.

## Quadratic (O(n^2)) Run-Time

Lastly, I have a plugin which allows the player to plant trip mines on surfaces. These trip mines arm themselves automatically after a short delay.
While armed, these trip mines scan for and connect to nearby trip mines planted by the same user, and connect to them with a team-colored laser.
When an enemy walks through one of these lasers, the mines connected by the laser will detonate. The method I have provided here is what I use in order
to connect the beams to one another.
This method demonstrates quadratic run-time, as it nests two loops. The outer loop runs N times, while the inner loop runs N times per cycle of the outer
loop. As such, this method runs O(N^2) times.
