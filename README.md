# Lex_Luthor

### Setting up Database - MySQL within Docker
You will need Docker installed on your Operating System, as well as the Docker-Compose.
If you use Windows O.S, Docker-Compose comes by default with Docker Desktop instalation.

1 - navigate to repository main folder, where is located the Dockerfile and docker-compose.yml files.
2 - run ```docker-compose up``` in order to set up the MySQL container.
3 - When connecting to the database you may need to set ```allowPublicKeyRetrieval``` to <strong>true</strong> in order to get the public key from MySQL container and use the connection.
  <li>In DMS you will need to set this on connection properties or even in the MySQL Driver Properties</li>
  <li>In Application's you may need to set this in Connection String</li>
