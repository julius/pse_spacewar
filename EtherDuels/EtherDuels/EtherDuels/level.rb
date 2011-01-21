# create objects
player1 = level.add_player1()
player2 = level.add_player2()

planet1 = level.add_planet()
planet2 = level.add_planet()

# modify object's standard positions
#planet.mass = 1
#planet.health = 10
#planet.position = level.vector(2000, 2000)
#player1.spaceship.position = level.vector(0, 0)
#player1.spaceship.rotation = 10

planet1.position = level.vector(2000, -1500)
planet1.mass = 1E24
planet2.position = level.vector(-2000, 1500)
