# create objects
player1 = level.add_player1()
player2 = level.add_player2()

planet1 = level.add_planet()
planet2 = level.add_planet()
planet3 = level.add_planet()

# modify object's standard positions
#planet.mass = 1
#planet.health = 10
#planet.position = level.vector(2000, 2000)
#player1.spaceship.rotation = 10
player1.spaceship.position = level.vector(-1900, 0)
player2.spaceship.position = level.vector(+1900, 0)

planet1.health = 1000
planet1.radius = 300

distance = 700

planet2.health = 500
planet2.radius = 82
planet2.is_flexible = true
planet2.attack = 150;
planet2.position = level.vector(distance, 0)
planet2.velocity = level.vector(0, Math.sqrt(planet1.mass * physic.G / distance / (physic.N * 1000)))

planet3.position = level.vector(2000,2000)
planet3.radius = 150
planet3.mass = 6E23
planet3.health = 1000

