# Utiliser une image de base OpenJDK
FROM openjdk:22-ea-17-jdk-slim

# Définir le répertoire de travail
WORKDIR /app

# Ajouter le fichier JAR généré par Maven au conteneur
COPY target/AirPark-productions-API-0.0.1-SNAPSHOT.jar app.jar

# Exposer le port de l'application
EXPOSE 8080

# Démarrer l'application Spring Boot
ENTRYPOINT ["java", "-jar", "app.jar"]
